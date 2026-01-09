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
    public partial class WFMovimientosCliente : IposForm
    {
        long m_clienteID = 0;
        string m_conSaldo = "N";
        


        public WFMovimientosCliente()
        {
            InitializeComponent();
        }

        public WFMovimientosCliente(long clienteID, string conSaldo):this()
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

            string esFactElectronica = "T";
            switch(CBOrigenFiscal.SelectedIndex)
            {
                case 1: esFactElectronica = "N"; break;
                case 2: esFactElectronica = "S"; break;
                default: esFactElectronica = "T"; break;
            }

            try
            {


                this.mOVIMIENTOSTableAdapter.Fill(this.dSFastReports.MOVIMIENTOS, 
                    ((CBEspeciales.Checked) ? "S" : "N"),
                    GetTipoDocto(),DTPFrom.Value,DTPTo.Value,
                    (Int32.Parse(this.PERSONAIDTextBox.DbValue.ToString())),
                    esFactElectronica,
                    ((CBConSaldo.Checked) ? "S" : "N"));
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
                case 0: return -21;
                case 1: return -22;
                case 2: return 31;
                default: return -21;
            }
        }

        private void BTMostrar_Click(object sender, EventArgs e)
        {
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
                LlenaDetalles(lDoctoId);
                LlenaAbonos(lDoctoId);
            }
            catch
            {
            }
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

        private void WFMovimientosCliente_Load(object sender, EventArgs e)
        {
            this.CBTipo.SelectedIndex = 0;
            this.DTPFrom.Value = DateTime.Parse("01/01/2012");
            this.DTPTo.Value = DateTime.Parse("31/12/" + DateTime.Today.ToString("yyyy"));
            this.CBOrigenFiscal.SelectedIndex = 0;


            if (m_clienteID != 0)
            {
                string strBuffer = "";
                this.PERSONAIDTextBox.DbValue = m_clienteID.ToString();
                this.PERSONAIDTextBox.MostrarErrores = false;
                this.PERSONAIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.PERSONAIDTextBox.MostrarErrores = true;
            }

            CBConSaldo.Checked = m_conSaldo.Equals("S");


            CUSUARIOSD usersD = new CUSUARIOSD();
            if (usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VER_UTILIDAD_VENTAS, null))
            {
                this.DGPORC_UTILIDAD.Visible = true;
                this.DG_DETALLE_PORC_UTILIDAD.Visible = true;
            }
            


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
            switch (CBOrigenFiscal.SelectedIndex)
            {
                case 1: esFactElectronica = "N"; break;
                case 2: esFactElectronica = "S"; break;
                default: esFactElectronica = "T"; break;
            }

            try
            {

                WFReporteMovClientes wf = new WFReporteMovClientes( GetTipoDocto(), DTPFrom.Value, DTPTo.Value,
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


        private void LlenarNotas()
        {
            TBNota.Text = "";

            if(this.mOVIMIENTOSDataGridView.SelectedRows.Count > 0 || this.mOVIMIENTOSDataGridView.SelectedCells.Count > 0)
            {
                int iRowIndex = this.mOVIMIENTOSDataGridView.SelectedRows.Count > 0 ? this.mOVIMIENTOSDataGridView.SelectedRows[0].Index :
                                        mOVIMIENTOSDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.mOVIMIENTOSDataGridView.Rows[iRowIndex];

                if (selectedRow.Cells["DGNOTAPAGO"].Value != null)
                {
                    TBNota.Text += " Nota Transaccion : " + selectedRow.Cells["DGNOTAPAGO"].Value.ToString();
                }

                if (selectedRow.Cells["DGNOTAAUTORIZACIONCREDITO"].Value != null && selectedRow.Cells["DGNOTAAUTORIZACIONCREDITO"].Value.ToString().Length > 0)
                {
                    TBNota.Text += Environment.NewLine + " Nota autorizacion credito : " + selectedRow.Cells["DGNOTAAUTORIZACIONCREDITO"].Value.ToString();
                }


                if (selectedRow.Cells["DGNOTACANCELACION"].Value != null && selectedRow.Cells["DGNOTACANCELACION"].Value.ToString().Length > 0)
                {
                    TBNota.Text += Environment.NewLine + " Nota cancelacion: " + selectedRow.Cells["DGNOTACANCELACION"].Value.ToString();
                }


                if (
                    (selectedRow.Cells["DGNOTAMOVIL1"].Value != null && selectedRow.Cells["DGNOTAMOVIL1"].Value.ToString().Length > 0 ) ||
                    (selectedRow.Cells["DGNOTAMOVIL2"].Value != null && selectedRow.Cells["DGNOTAMOVIL2"].Value.ToString().Length > 0)
                  )
                {
                    TBNota.Text += Environment.NewLine + " Nota Movil : ";

                    if ((selectedRow.Cells["DGNOTAMOVIL1"].Value != null && selectedRow.Cells["DGNOTAMOVIL1"].Value.ToString().Length > 0))
                    {
                        TBNota.Text += " " + selectedRow.Cells["DGNOTAMOVIL1"].Value.ToString()  ;
                    }

                    if ((selectedRow.Cells["DGNOTAMOVIL2"].Value != null && selectedRow.Cells["DGNOTAMOVIL2"].Value.ToString().Length > 0))
                    {
                        TBNota.Text += " " + selectedRow.Cells["DGNOTAMOVIL2"].Value.ToString();
                    }
                }

            }
            //else if (this.mOVIMIENTOSDataGridView.SelectedCells.Count > 0)
            //{
            //    if (this.mOVIMIENTOSDataGridView.Rows[mOVIMIENTOSDataGridView.SelectedCells[0].RowIndex].Cells["DGNOTAPAGO"].Value != null)
            //    {
            //        TBNota.Text += " Nota Transaccion : " + this.mOVIMIENTOSDataGridView.Rows[mOVIMIENTOSDataGridView.SelectedCells[0].RowIndex].Cells["DGNOTAPAGO"].Value.ToString();
            //    }
            //}


            if (this.gET_LISTA_ABONOS_DOCTODataGridView.SelectedRows.Count > 0)
            {
                if (this.gET_LISTA_ABONOS_DOCTODataGridView.SelectedRows[0].Cells["DGNOTASABONO"].Value != null)
                {
                    TBNota.Text += Environment.NewLine + " Nota Abono : " + this.gET_LISTA_ABONOS_DOCTODataGridView.SelectedRows[0].Cells["DGNOTASABONO"].Value.ToString();
                }
            }
            else if (this.gET_LISTA_ABONOS_DOCTODataGridView.SelectedCells.Count > 0)
            {
                if (this.gET_LISTA_ABONOS_DOCTODataGridView.Rows[gET_LISTA_ABONOS_DOCTODataGridView.SelectedCells[0].RowIndex].Cells["DGNOTASABONO"].Value != null)
                {
                    TBNota.Text += Environment.NewLine + " Nota Abono : " + this.gET_LISTA_ABONOS_DOCTODataGridView.Rows[gET_LISTA_ABONOS_DOCTODataGridView.SelectedCells[0].RowIndex].Cells["DGNOTASABONO"].Value.ToString();
                }
            }

        }

        private void mOVIMIENTOSDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            LlenarNotas();
        }

        private void gET_LISTA_ABONOS_DOCTODataGridView_SelectionChanged(object sender, EventArgs e)
        {
            LlenarNotas();
        }

        private void btnImprimirSaldos_Click(object sender, EventArgs e)
        {

            string esFactElectronica = "T";
            switch (CBOrigenFiscal.SelectedIndex)
            {
                case 1: esFactElectronica = "N"; break;
                case 2: esFactElectronica = "S"; break;
                default: esFactElectronica = "T"; break;
            }

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("tipodoctoid", GetTipoDocto());
            dictionary.Add("consaldo", ((CBConSaldo.Checked) ? "S" : "N"));
            dictionary.Add("esfactura", esFactElectronica);
            dictionary.Add("fechaini", DTPFrom.Value);
            dictionary.Add("fechafin", DTPTo.Value);
            dictionary.Add("personaid", (Int32.Parse(this.PERSONAIDTextBox.DbValue.ToString())));

            dictionary.Add("tipodoctonombre", CBTipo.Text);
            dictionary.Add("personanombre", this.PERSONALabel.Text);




            string strReporte = "InformeMovimientosXCliente.frx";



            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }
    }
}
