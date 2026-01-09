using iPosData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos
{
    public partial class WFMovimientosProveedor : IposForm
    {
        long m_clienteID = 0;
        long m_selectedDoctoID = 0;
        string m_conSaldo = "N";
        public WFMovimientosProveedor()
        {
            InitializeComponent();
        }

        public WFMovimientosProveedor(long clienteID, string conSaldo):this()
        {
            m_clienteID = clienteID;
            m_conSaldo = conSaldo;
        }

        private void LlenarMovimientos()
        {
            int personaId = 0;
            try
            {
                personaId = Int32.Parse(this.PERSONAIDTextBox.DbValue.ToString());
                if(personaId == 0)
                {
                    MessageBox.Show("Seleccione un cliente valido");
                    CalcularTotalesMovimientos();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Seleccione un cliente valido");
                CalcularTotalesMovimientos();
                return;
            }

            if (CBTipo.SelectedIndex < 0)
            {

                MessageBox.Show("Seleccione un tipo de transaccion valido");
                CalcularTotalesMovimientos();
                return;
            }

            try
            {


                this.mOVIMIENTOSTableAdapter.Fill(this.dSFastReports.MOVIMIENTOS, "N", GetTipoDocto(),DTPFrom.Value,DTPTo.Value,
                    (Int32.Parse(this.PERSONAIDTextBox.DbValue.ToString())),
                    "T",
                    ((CBConSaldo.Checked) ? "S":"N"));
                CalcularTotalesMovimientos();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private int GetTipoDocto()
        {
            switch (CBTipo.SelectedIndex)
            {
                case 0: return -11;
                case 1: return -12;
                //case 2: return 16;
                default: return -11;
            }
        }

        private void BTMostrar_Click(object sender, EventArgs e)
        {

            this.dSFastReports.MOVIMIENTOSDETALLE.Clear();
            this.dSFastReports.GET_LISTA_ABONOS_DOCTO.Clear();
            LlenarMovimientos();
            LlenarNotas();
        }

        private void LlenaDetalles(long lDoctoId)
        {
            try
            {
                this.mOVIMIENTOSDETALLETableAdapter.Fill(this.dSFastReports.MOVIMIENTOSDETALLE, (int)lDoctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void mOVIMIENTOSDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                long lDoctoId = long.Parse(mOVIMIENTOSDataGridView.Rows[e.RowIndex].Cells["DOCTOID"].Value.ToString());
                this.m_selectedDoctoID = lDoctoId;
                HabilitarNegociacionesSiExisten();

                LlenaDetalles(lDoctoId);
                LlenaAbonos(lDoctoId);
            }
            catch
            {
            }
        }

        private void HabilitarNegociacionesSiExisten()
        {
            CLOGEVENTOTABLAD logEventD = new CLOGEVENTOTABLAD();

            this.btnNegociaciones.Enabled = (1 == logEventD.ExisteLOGEVENTOTABLAXRecordYTipo(
                                                                            m_selectedDoctoID,
                                                                            "Doctos",
                                                                            DBValues._TIPOEVENTOTABLA_NOTACOMPRA, null));


        }

        private void LlenaAbonos(long lDoctoId)
        {
            try
            {
                this.gET_LISTA_ABONOS_DOCTOTableAdapter.Fill(this.dSFastReports.GET_LISTA_ABONOS_DOCTO, (int)lDoctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFMovimientosProveedor_Load(object sender, EventArgs e)
        {
            this.CBTipo.SelectedIndex = 0;
            this.DTPFrom.Value = DateTime.Parse("01/01/2012");
            this.DTPTo.Value = DateTime.Parse("31/12/" + DateTime.Today.ToString("yyyy"));


            if (m_clienteID != 0)
            {
                string strBuffer = "";
                this.PERSONAIDTextBox.DbValue = m_clienteID.ToString();
                this.PERSONAIDTextBox.MostrarErrores = false;
                this.PERSONAIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.PERSONAIDTextBox.MostrarErrores = true;
            }

            CBConSaldo.Checked = m_conSaldo.Equals("S");


            if (m_clienteID != 0)
            {
                LlenarMovimientos();
                LlenarNotas();
            }

        }


        private void CalcularTotalesMovimientos()
        {
            int iCuenta = 0;
            decimal dTotal = 0;
            decimal dSaldo = 0;
            foreach (DataGridViewRow row in mOVIMIENTOSDataGridView.Rows)
            {

                if (row.Index == mOVIMIENTOSDataGridView.NewRowIndex)
                    continue;

                decimal total = decimal.Parse(row.Cells["DGTOTAL"].Value.ToString());
                decimal saldo = decimal.Parse(row.Cells["SALDO"].Value.ToString());

                dTotal += total;
                dSaldo += saldo;

                iCuenta++;
            }

            this.lblCantMov.Text = iCuenta.ToString();
            this.lblSumaSaldos.Text = dSaldo.ToString("N2");
            this.lblSumaTotales.Text = dTotal.ToString("N2");
        }


        private void LlenarNotas()
        {
            TBNota.Text = "";

            if (this.mOVIMIENTOSDataGridView.SelectedRows.Count > 0)
            {
                if (this.mOVIMIENTOSDataGridView.SelectedRows[0].Cells["DGNOTAPAGO"].Value != null)
                {
                    TBNota.Text += " Nota Transaccion : " + this.mOVIMIENTOSDataGridView.SelectedRows[0].Cells["DGNOTAPAGO"].Value.ToString();
                }
            }
            else if (this.mOVIMIENTOSDataGridView.SelectedCells.Count > 0)
            {
                if (this.mOVIMIENTOSDataGridView.Rows[mOVIMIENTOSDataGridView.SelectedCells[0].RowIndex].Cells["DGNOTAPAGO"].Value != null)
                {
                    TBNota.Text += " Nota Transaccion : " + this.mOVIMIENTOSDataGridView.Rows[mOVIMIENTOSDataGridView.SelectedCells[0].RowIndex].Cells["DGNOTAPAGO"].Value.ToString();
                }
            }


            if (this.gET_LISTA_ABONOS_DOCTODataGridView.SelectedRows.Count > 0)
            {
                if (this.gET_LISTA_ABONOS_DOCTODataGridView.SelectedRows[0].Cells["DGNOTASABONO"].Value != null)
                {
                    TBNota.Text += " Nota Abono : " + this.gET_LISTA_ABONOS_DOCTODataGridView.SelectedRows[0].Cells["DGNOTASABONO"].Value.ToString();
                }
            }
            else if (this.gET_LISTA_ABONOS_DOCTODataGridView.SelectedCells.Count > 0)
            {
                if (this.gET_LISTA_ABONOS_DOCTODataGridView.Rows[gET_LISTA_ABONOS_DOCTODataGridView.SelectedCells[0].RowIndex].Cells["DGNOTASABONO"].Value != null)
                {
                    TBNota.Text += " Nota Abono : " + this.gET_LISTA_ABONOS_DOCTODataGridView.Rows[gET_LISTA_ABONOS_DOCTODataGridView.SelectedCells[0].RowIndex].Cells["DGNOTASABONO"].Value.ToString();
                }
            }

        }

        private void gET_LISTA_ABONOS_DOCTODataGridView_SelectionChanged(object sender, EventArgs e)
        {
            LlenarNotas();
        }

        private void mOVIMIENTOSDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            LlenarNotas();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int personaId = 0;
            try
            {
                personaId = Int32.Parse(this.PERSONAIDTextBox.DbValue.ToString());
                if (personaId == 0)
                {
                    MessageBox.Show("Seleccione un cliente valido");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Seleccione un cliente valido");
                return;
            }

            if (CBTipo.SelectedIndex < 0)
            {

                MessageBox.Show("Seleccione un tipo de transaccion valido");
                return;
            }

            string esFactElectronica = "T";

            try
            {

                WFReporteMovProvee wf = new WFReporteMovProvee(GetTipoDocto(), DTPFrom.Value, DTPTo.Value,
                    (Int32.Parse(this.PERSONAIDTextBox.DbValue.ToString())),
                    esFactElectronica,
                    ((CBConSaldo.Checked) ? "S" : "N"),
                    CBTipo.Text,
                    PERSONALabel.Text);
                wf.ShowDialog();
                wf.Dispose();
                GC.SuppressFinalize(wf);

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnNegociaciones_Click(object sender, EventArgs e)
        {


            WFLogEventoTransaccion wf = new WFLogEventoTransaccion("Doctos", m_selectedDoctoID, DBValues._TIPOEVENTOTABLA_NOTACOMPRA);
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }
    }
}
