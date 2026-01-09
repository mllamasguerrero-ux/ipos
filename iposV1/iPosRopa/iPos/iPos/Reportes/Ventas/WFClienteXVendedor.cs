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
    public partial class WFClienteXVendedor : IposForm
    {
        public WFClienteXVendedor()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            RecargarReport();
            Int64? p_item = 0;
            if (!CBTodas.Checked)
            {
                try
                {
                    p_item = Int64.Parse(this.ITEMIDTextBox.DbValue.ToString());
                }
                catch
                {
                    MessageBox.Show("Seleccione un registro valido");
                    return;
                }
            }
            report1.SetParameterValue("itemid", (Decimal)p_item);

            if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void RecargarReport()
        {

            report1.Load(FastReportsConfig.getPathForFile( "InformeClientesXVendedor.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void WFClienteXVendedor_Load(object sender, EventArgs e)
        {
        }

        private void WFClienteXVendedor_FormClosing(object sender, FormClosingEventArgs e)
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
