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
    public partial class WFReciboGastoReporte : IposForm
    {
        public WFReciboGastoReporte()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            RecargarReport();
            Int64? p_cajero = 0;
            Int64? p_gasto = 0;
            String p_cajeroNombre = "Todos";
            String p_gastoNombre = "Todos";

            if (!CBTodas.Checked)
            {
                try
                {
                    p_cajero = Int64.Parse(this.ITEMIDTextBox.DbValue.ToString());
                    p_cajeroNombre = this.ITEMLabel.Text;
                }
                catch
                {
                    MessageBox.Show("Seleccione un cajero valido");
                    return;
                }
            }


            if (!CBTodosGastos.Checked)
            {
                try
                {
                    p_gasto = Int64.Parse(this.GASTOIDTextBox.DbValue.ToString());
                    p_gastoNombre = this.GASTOLabel.Text;
                }
                catch
                {
                    MessageBox.Show("Seleccione un tipo de gasto valido");
                    return;
                }
            }


            report1.SetParameterValue("cajeroid", (Decimal)p_cajero);
            report1.SetParameterValue("gastoid", (Decimal)p_gasto);
            report1.SetParameterValue("cajeronombre", p_cajeroNombre);
            report1.SetParameterValue("gastonombre", p_gastoNombre);
            report1.SetParameterValue("fechaini", DTPFrom.Value);
            report1.SetParameterValue("fechafin", DTPTo.Value);

            if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void RecargarReport()
        {

            report1.Load(FastReportsConfig.getPathForFile(CBSumarizado.Checked ? "InformeGastosSumarizado.frx" : "InformeGastos.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void WFReciboGastoReporte_Load(object sender, EventArgs e)
        {
        }

        private void WFReciboGastoReporte_FormClosing(object sender, FormClosingEventArgs e)
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
