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
    public partial class WFReporteDeFacturacionIEPS : Form
    {
        long m_RutaEmbarqueId = -1;
        long m_tipodoctoId, m_estatusVenta;
        string m_EsFactura = "T";
        public WFReporteDeFacturacionIEPS()
        {
            InitializeComponent();
        }

       


        private void RecargarReport()
        {

            report1.Load(FastReportsConfig.getPathForFile("InformeDiarioFacturasIEPSEXP.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            RecargarReport();

            switch (CBTipoVenta.SelectedIndex)
            {
                case 0: this.m_tipodoctoId = -21; break;
                case 1: this.m_tipodoctoId = -22; break;
                case 2: this.m_tipodoctoId = 0; break;

                default: this.m_tipodoctoId = 0; break;

            }

            string estatusDoctoDesc = "";
            switch (CBEstatusVenta.SelectedIndex)
            {
                case 0: this.m_estatusVenta = (int)iPosData.DBValues._DOCTO_ESTATUS_COMPLETO; estatusDoctoDesc = "Completo";  break;
                case 1: this.m_estatusVenta = (int)iPosData.DBValues._DOCTO_ESTATUS_CANCELADA; estatusDoctoDesc = "Cancelada"; break;
                case 2: this.m_estatusVenta = -1; estatusDoctoDesc = "Todos"; break;

                default: this.m_tipodoctoId = -1; estatusDoctoDesc = "Todos"; break;

            }


            report1.SetParameterValue("FECHAINI", DTPFrom.Value);
            report1.SetParameterValue("FECHAFIN", DTPTo.Value);
            report1.SetParameterValue("TIPODOCTOID", m_tipodoctoId);
            report1.SetParameterValue("ESTATUSDOCTOID", m_estatusVenta);
            report1.SetParameterValue("ESTATUSDOCTODESC", estatusDoctoDesc);

            report1.SetParameterValue("VENDEDORID", (CBCajerosTodos.Checked) ? 0 : Decimal.Parse(this.VENDEDORIDTextBox.DbValue.ToString()));
            report1.SetParameterValue("VENDEDORNOMBRE", (CBCajerosTodos.Checked) ? "Todos" : this.VENDEDORIDTextBox.Text);

            report1.SetParameterValue("ALMACENID", 0);
            report1.SetParameterValue("NOMBREALMACEN", "");



            if (report1.Prepare())
                report1.ShowPrepared();
        }


        private void CBTipoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void WFReporteDeFacturacionIEPS_FormClosing(object sender, FormClosingEventArgs e)
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
