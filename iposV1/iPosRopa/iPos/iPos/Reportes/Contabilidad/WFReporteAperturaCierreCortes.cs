using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Reportes.Contabilidad
{
    public partial class WFReporteAperturaCierreCortes : Form
    {
        public WFReporteAperturaCierreCortes()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            RecargarReport();
            Int64? p_cajero = 0;

            if (!CBTodas.Checked)
            {
                try
                {
                    p_cajero = Int64.Parse(this.ITEMIDTextBox.DbValue.ToString());
                }
                catch
                {
                    MessageBox.Show("Seleccione un cajero valido");
                    return;
                }
            }
            report1.SetParameterValue("cajeroid", (Decimal)p_cajero);
            report1.SetParameterValue("fechaini", DTPFrom.Value);
            report1.SetParameterValue("fechafin", DTPTo.Value);

            if (report1.Prepare())
                report1.ShowPrepared();

        }

        private void RecargarReport()
        {

            report1.Load(FastReportsConfig.getPathForFile("ReporteAperturaCierreCorteXFecha.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void WFReporteAperturaCierreCortes_FormClosing(object sender, FormClosingEventArgs e)
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
