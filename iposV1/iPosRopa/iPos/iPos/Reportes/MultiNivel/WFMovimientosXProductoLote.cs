using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;

namespace iPos.Reportes
{
    public partial class WFMovimientosXProductoLote : IposForm
    {

        CPRODUCTOBE m_prod = null;
        public WFMovimientosXProductoLote()
        {
            InitializeComponent();
        }


        public WFMovimientosXProductoLote(CPRODUCTOBE prod):this()
        {
            m_prod = prod;
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            RecargarReport();
            Int64? p_item = 0;
            try
            {
                    p_item = Int64.Parse(this.ITEMIDTextBox.DbValue.ToString());
            }
            catch
            {
                    MessageBox.Show("Seleccione un registro valido");
                    return;
            }
            report1.SetParameterValue("itemid", (Decimal)p_item);

            string lote = "";
            if (RBSeleccionLote.Checked)
            {
                string[] aux = comboLote.Text.Split('|');
                if (aux.Count() == 2)
                {
                    lote = aux[0].Trim();
                }
            }
            else
            {
                lote = TBLote.Text;
            }

            report1.SetParameterValue("lote", lote);

            if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void RecargarReport()
        {

            report1.Load(FastReportsConfig.getPathForFile("InformeMovimientosXProductoLote.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void WFMovimientosXProductoLote_Load(object sender, EventArgs e)
        {
            if(m_prod != null)
            {

                string strBuffer = "";
                this.ITEMIDTextBox.DbValue = m_prod.ICLAVE.ToString();
                this.ITEMIDTextBox.MostrarErrores = false;
                this.ITEMIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.ITEMIDTextBox.MostrarErrores = true;
            }
        }

        private void WFMovimientosXProductoLote_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                report1.Delete();
                report1.Dispose();
            }
            catch
            {
            }
        }


        private void SeleccionaProducto()
        {

            LOOKPROD look;
            look = new LOOKPROD(ITEMIDTextBox.Text, !CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"), TipoProductoNivel.tp_hijos, 0);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                string strBuffer = "";
                this.ITEMIDTextBox.DbValue = ((long)dr["ID"]).ToString();
                this.ITEMIDTextBox.MostrarErrores = false;
                this.ITEMIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.ITEMIDTextBox.MostrarErrores = true;

                this.ITEMIDTextBox.Focus();

                
            }
        }

        private void ITEMButton_Click(object sender, EventArgs e)
        {
            this.SeleccionaProducto();
        }




        private void LlenarComboLotes(long doctoId, long productoId)
        {
            try
            {
                this.r_LISTALOTESINVENTARIOTableAdapter.Fill(this.dSInventarioFisico2.R_LISTALOTESINVENTARIO, doctoId, productoId,"N");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }



        private bool BuscarProducto(ref CPRODUCTOBE prod)
        {
            CComprasD pvd = new CComprasD();
            prod = pvd.buscarPRODUCTOSPV(ITEMIDTextBox.Text.Trim(), CurrentUserID.CurrentParameters, null);
            if (prod != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ITEMIDTextBox_Validating(object sender, CancelEventArgs e)
        {
            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {
                SeleccionaProducto();
                return;
            }

            m_prod = prod;

            if (prod.IMANEJALOTE == "S")
            {
                LlenarComboLotes(0, prod.IID);
            }
            else
            {
            }

        }



    }
}
