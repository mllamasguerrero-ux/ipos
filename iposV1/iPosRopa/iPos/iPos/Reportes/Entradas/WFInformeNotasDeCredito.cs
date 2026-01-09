using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.Reportes
{
    public partial class WFInformeNotasDeCredito : IposForm
    {
        public WFInformeNotasDeCredito()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            RecargarReport();
            report1.SetParameterValue("fechaini", DTPFrom.Value);
            report1.SetParameterValue("fechafin", DTPTo.Value);
            report1.SetParameterValue("almacenid", CBTodosAlmacenes.Checked ? 0 : Decimal.Parse(this.ALMACENComboBox.SelectedValue.ToString()) );

            if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void RecargarReport()
        {

            report1.Load(FastReportsConfig.getPathForFile(CBSumarizado.Checked ? "InformeNotasDeCreditoSum.frx" : "InformeNotasDeCreditoDetalle.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void WFInformeNotasDeCredito_Load(object sender, EventArgs e)
        {

            this.ALMACENComboBox.llenarDatos();
        }

        private void WFInformeNotasDeCredito_FormClosing(object sender, FormClosingEventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DTPFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DTPTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


    }
}
