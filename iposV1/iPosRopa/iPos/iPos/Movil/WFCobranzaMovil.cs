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
    public partial class WFCobranzaMovil : iPos.Tools.ScreenConfigurableForm
    {

        public DataRow m_rtnDataRow = null;
        public bool m_bSelecionarRegistro = false;
        public String m_strBusqueda = "";
        public String m_strCliente = "";

        public WFCobranzaMovil()
        {
            InitializeComponent();
        }

        public WFCobranzaMovil(bool bSeleccionarRegistro):this()
        {
            m_bSelecionarRegistro = bSeleccionarRegistro;
        }


        public WFCobranzaMovil(bool bSeleccionarRegistro, string strCliente)
            : this(bSeleccionarRegistro)
        {
            m_strCliente = strCliente;
        }

        private void LlenarDatos()
        {
            try
            {

                string bufferBusquedaText = TBBusqueda.Text.ToUpper();
                if (bufferBusquedaText.Contains(" <(("))
                {
                    string[] strSeparators = new string[] { " <((" };

                    string[] strBuffert = bufferBusquedaText.Split(strSeparators, StringSplitOptions.RemoveEmptyEntries);
                    if (strBuffert.Count() > 0)
                        bufferBusquedaText = strBuffert[0];

                }

                String strABuscar = "%" + bufferBusquedaText + "%";
                this.cOBRANZAMOVILTableAdapter.Fill(this.dSMovil2.COBRANZAMOVIL,  m_strCliente, ((m_strCliente == null || m_strCliente.Trim().Length == 0) ? 0 : 1), strABuscar);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            coloreaGrid();
            muestraTotalSaldoMovil();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenarDatos();
        }

        private void TBBusqueda_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LlenarDatos();
            }
        }

        private void WFCobranzaMovil_Load(object sender, EventArgs e)
        {
            configuraLaPantalla(true, true);

            if(m_bSelecionarRegistro)
            {
                  cOBRANZAMOVILDataGridView.Columns["DGPAGAR"].Visible = false;
                  cOBRANZAMOVILDataGridView.Columns["VERPAGOS"].Visible = false;
            }

            if (CurrentUserID.CurrentParameters.IAUTOCOMPCLIENTE.Equals("S"))
            {

                //if (1 == 1 /*!CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S")*/)
                //{
                    try
                    {

                        this.TBBusqueda.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        this.TBBusqueda.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        this.TBBusqueda.AutoCompleteCustomSource = CurrentUserID.GetAutoSourceCollectionFromTableCliente();

                    }
                    catch
                    {
                    }
                //}
                //else
                //{
                //    this.addCustomAutoCompletePair(ref this.TBBusqueda, ref lstSearchComplete, CurrentUserID.GetAutoSourceCollectionFromTableCliente());
                //}
            }


            TBBusqueda.Text = m_strBusqueda;

            LlenarDatos();
        }

        private void coloreaGrid()
        {
            foreach (DataGridViewRow row in this.cOBRANZAMOVILDataGridView.Rows)
            {

                decimal saldoMovil = 0;

                try
                {
                    if (row.Cells["DGSALDOMOVIL"].Value != DBNull.Value)
                    {
                        saldoMovil = decimal.Parse(row.Cells["DGSALDOMOVIL"].Value.ToString());
                    }

                    if (saldoMovil > 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.White;

                        row.Cells["DGPAGAR"].Value = "PAGAR";
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        row.Cells["DGPAGAR"].Value = "";
                    }

                }
                catch
                {

                    row.DefaultCellStyle.BackColor = Color.White;
                }

            }
        }


        private void cOBRANZAMOVILDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            

            if (e.RowIndex != -1)
            {

                if (cOBRANZAMOVILDataGridView.Columns[e.ColumnIndex].Name == "DGPAGAR")
                {

                    if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 2)
                    {
                        MessageBox.Show("Esta opcion aun no esta habilitada");
                        return;
                    }

                    String strEnabled = cOBRANZAMOVILDataGridView.Rows[e.RowIndex].Cells["DGPAGAR"].Value.ToString();
                    if (strEnabled == null || strEnabled.Length == 0)
                        return;


                    long cobranzaId = long.Parse(cOBRANZAMOVILDataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                     long personaId = long.Parse(cOBRANZAMOVILDataGridView.Rows[e.RowIndex].Cells["DGPERSONAID"].Value.ToString());
                     decimal saldo = decimal.Parse(cOBRANZAMOVILDataGridView.Rows[e.RowIndex].Cells["DGSALDOMOVIL"].Value.ToString());

                     WFPagoMovil pm = new WFPagoMovil(personaId, cobranzaId,saldo);
                     pm.ShowDialog();
                     pm.Dispose();
                     GC.SuppressFinalize(pm);

                    LlenarDatos();

                }
                else if (cOBRANZAMOVILDataGridView.Columns[e.ColumnIndex].Name == "VERPAGOS")
                {
                    if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 2)
                    {
                        MessageBox.Show("Esta opcion aun no esta habilitada");
                        return;
                    }
                    long cobranzaId = long.Parse(cOBRANZAMOVILDataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                    WFCobranzaMovilDetalle wf = new WFCobranzaMovilDetalle(cobranzaId);
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);

                    LlenarDatos();
                }
            }
        }


        private void RetornarSeleccion(bool bEnterKey)
        {
            if (!m_bSelecionarRegistro)
                return;

            try
            {
                int iRetornoRowIndex = cOBRANZAMOVILDataGridView.CurrentRow.Index;
                DataGridViewRow dr = cOBRANZAMOVILDataGridView.Rows[iRetornoRowIndex];

                m_rtnDataRow = (dr.DataBoundItem as DataRowView).Row;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }


        private void cOBRANZAMOVILDataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {


                case Keys.Enter:
                    RetornarSeleccion(false);
                    break;
            }
        }

        private void cOBRANZAMOVILDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RetornarSeleccion(false);
        }

        private void muestraTotalSaldoMovil()
        {

            decimal dSumaSaldoMovil = 0;
            decimal dSumaAbonosMovil = 0;

            foreach (DataGridViewRow row in this.cOBRANZAMOVILDataGridView.Rows)
            {

                decimal saldoMovil = 0;
                decimal abonoMovil = 0;

                try
                {
                    if (row.Cells["DGSALDOMOVIL"].Value != DBNull.Value)
                    {
                        saldoMovil = decimal.Parse(row.Cells["DGSALDOMOVIL"].Value.ToString());
                    }

                    if (row.Cells["DGABONOSMOVIL"].Value != DBNull.Value)
                    {
                        abonoMovil = decimal.Parse(row.Cells["DGABONOSMOVIL"].Value.ToString());
                    }

                    dSumaSaldoMovil += saldoMovil;
                    dSumaAbonosMovil += abonoMovil;

                    
                }
                catch
                {

                    row.DefaultCellStyle.BackColor = Color.White;
                }

            }

            this.lbTotalSaldo.Text = dSumaSaldoMovil.ToString("N2");
            this.lbTotalAbono.Text = dSumaAbonosMovil.ToString("N2");
        }

        private void cOBRANZAMOVILDataGridView_Sorted(object sender, EventArgs e)
        {

            coloreaGrid();
            muestraTotalSaldoMovil();
        }
    }
}
