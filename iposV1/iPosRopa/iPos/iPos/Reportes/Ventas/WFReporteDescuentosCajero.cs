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
    public partial class WFReporteDescuentosCajero : IposForm
    {
        public WFReporteDescuentosCajero()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            int?  p_cajero;
            p_cajero = (this.CBCajerosTodos.Checked) ? 0 : Int32.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
            report1.SetParameterValue("VENDEDORID", p_cajero);
            report1.SetParameterValue("FECHAINICIO", DTPFrom.Value);
            report1.SetParameterValue("FECHAFIN", DTPTo.Value);

            if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void WFReporteDescuentosCajero_Load(object sender, EventArgs e)
        {
            report1.Load(FastReportsConfig.getPathForFile("DescuentosXCajero.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);

        }

        private void WFReporteDescuentosCajero_FormClosing(object sender, FormClosingEventArgs e)
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
