using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.Reportes.Ventas
{
    public partial class WFReporteDeVentasXRuta : Form
    {
        long m_RutaEmbarqueId = -1;
        long m_tipodoctoId, m_estatusVenta;
        string m_EsFactura = "T";
        public WFReporteDeVentasXRuta()
        {
            InitializeComponent();
        }

        private void BTRutaEmbarque_Click(object sender, EventArgs e)
        {
            SeleccionaRutaEmbarque();
        }

        private void SeleccionaRutaEmbarque()
        {
            iPos.Catalogos.WFRutasEmbarque look = new iPos.Catalogos.WFRutasEmbarque();
            //look.m_bSelecionarRegistro = true;
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                LBRutaNombre.Text = dr["NOMBRE"].ToString().Trim();
                m_RutaEmbarqueId = (long)dr["ID"];
            }

        }


        private void RecargarReport()
        {

            report1.Load(FastReportsConfig.getPathForFile("ReporteDeVentasXRuta.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            RecargarReport();
            if (m_RutaEmbarqueId == -1)
            {
                MessageBox.Show("Seleccione una rutade embarque, o marque todas");
                return;
            }

            switch (CBTipoVenta.SelectedIndex)
            {
                case 0: this.m_tipodoctoId = (int)iPosData.DBValues._DOCTO_TIPO_VENTA; break;
                case 1: this.m_tipodoctoId = (int)iPosData.DBValues._DOCTO_TIPO_VENTA_FUTURO; break;
                case 2: this.m_tipodoctoId = 0; break;

                default: this.m_tipodoctoId = 0; break;

            }

            switch (CBEstatusVenta.SelectedIndex)
            {
                case 0: this.m_estatusVenta = (int)iPosData.DBValues._DOCTO_ESTATUS_COMPLETO; break;
                case 1: this.m_estatusVenta = (int)iPosData.DBValues._DOCTO_ESTATUS_BORRADOR; break;
                case 2: this.m_estatusVenta = -1; break;

                default: this.m_estatusVenta = -1; break;

            }

            if(CBEsFactura.Enabled == true)
            {
                switch (CBEsFactura.SelectedIndex)
                {
                    case 0: this.m_EsFactura = "S"; break;
                    case 1: this.m_EsFactura = "N"; break;
                    case 2: this.m_EsFactura = "T"; break;

                    default: this.m_EsFactura = "T"; break;

                 }
            }

            report1.SetParameterValue("fechaini", DTPFrom.Value);
            report1.SetParameterValue("fechafin", DTPTo.Value);
            report1.SetParameterValue("tipodoctoid", m_tipodoctoId);
            report1.SetParameterValue("esfactura", m_EsFactura);
            report1.SetParameterValue("estatusdoctoid", m_estatusVenta);
            report1.SetParameterValue("rutaembarqueid", m_RutaEmbarqueId);



            if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void CBRutasTodas_CheckedChanged(object sender, EventArgs e)
        {
            if(CBRutasTodas.Checked == true)
            {
                m_RutaEmbarqueId = 0;
                LBRutaNombre.Text = "...";
            }
            else
            {
                m_RutaEmbarqueId = -1;
            }
        }

        private void CBTipoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CBTipoVenta.SelectedIndex == 0)
            {
                lblEsFactura.Enabled = true;
                CBEsFactura.Enabled = true;
            }
        }

        private void WFReporteDeVentasXRuta_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
