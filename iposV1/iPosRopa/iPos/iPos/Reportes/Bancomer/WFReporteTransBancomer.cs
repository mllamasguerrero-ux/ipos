using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Reportes.Bancomer
{
    public partial class WFReporteTransBancomer : Form
    {
        public WFReporteTransBancomer()
        {
            InitializeComponent();
        }

        private void enviarButton_Click(object sender, EventArgs e)
        {

        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            string terminal;

            if (todasTermCheckBox.Checked)
            {
                terminal = "T";
            }
            else
            {
                if (String.IsNullOrEmpty(this.TERMINALIDTextBox.DbValue))
                {
                    MessageBox.Show("Seleccione una terminal valida");
                    return;
                }
                else
                {
                    terminal = this.TERMINALIDTextBox.DbValue;
                    terminal = terminal.PadLeft(8, '0');
                }
            }

            string dateStr = desdeDateTimePicker.Value.ToString();

            report1.SetParameterValue("TERMN", terminal);
            report1.SetParameterValue("FECHAINICIO", desdeDateTimePicker.Value.ToString("yyMMdd"));
            report1.SetParameterValue("FECHAFIN", hastaDateTimePicker.Value.AddDays(1).ToString("yyMMdd"));

            if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void RecargarReport()
        {
            string reportPath = FastReportsConfig.getPathForFile("ReporteBancomer.frx", FastReportsTipoFile.desistema);

            report1.Load(FastReportsConfig.getPathForFile("ReporteTransBancomer.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void WFReporteTransBancomer_Load(object sender, EventArgs e)
        {
            RecargarReport();
        }

        private void WFReporteTransBancomer_FormClosing(object sender, FormClosingEventArgs e)
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
