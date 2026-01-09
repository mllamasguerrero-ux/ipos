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
    public partial class WFQuotaXVendedor : IposForm
    {
        public WFQuotaXVendedor()
        {
            InitializeComponent();
        }


        private void setDefaultAnio()
        {
            ANIOINICIALTextBox.Value = DateTime.Today.Year;
            ANIOFINALTextBox.Value = DateTime.Today.Year;
        }


        private void BTEnviar_Click(object sender, EventArgs e)
        {
            RecargarReport();
            Int64? p_item = 0;
            string nombreVendedor = "Todos";
            if (!CBTodas.Checked)
            {
                try
                {
                    p_item = Int64.Parse(this.ITEMIDTextBox.DbValue.ToString());
                    nombreVendedor = this.ITEMIDTextBox.Text;
                }
                catch
                {
                    MessageBox.Show("Seleccione un registro valido");
                    return;
                }
            }
            report1.SetParameterValue("VENDEDORID", (Decimal)p_item);
            report1.SetParameterValue("ANIOINICIAL", (Decimal)ANIOINICIALTextBox.Value);
            report1.SetParameterValue("ANIOFINAL", (Decimal)ANIOFINALTextBox.Value);
            report1.SetParameterValue("NOMBREVENDEDOR", nombreVendedor);


            if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void RecargarReport()
        {

            report1.Load(FastReportsConfig.getPathForFile("InformeQuotas.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void WFQuotaXVendedor_Load(object sender, EventArgs e)
        {
            setDefaultAnio();
        }

        private void WFQuotaXVendedor_FormClosing(object sender, FormClosingEventArgs e)
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
