using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.Reportes.Catalogos
{
    public partial class WFInformeProductosMula : Form
    {
        int cantidadDeDias;
        public WFInformeProductosMula()
        {
            InitializeComponent();
        }

        private void WFInformeProductosMula_Load(object sender, EventArgs e)
        {

        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            RecargarReport();
            cantidadDeDias = int.Parse(numericUpDown1.Value.ToString());
            DateTime date = DateTime.Today.AddDays(-cantidadDeDias);

            report1.SetParameterValue("fechadiassinvender", date);

            if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void RecargarReport()
        {

            report1.Load(FastReportsConfig.getPathForFile("InformeProductosMulas.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void WFInformeProductosMula_FormClosing(object sender, FormClosingEventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
