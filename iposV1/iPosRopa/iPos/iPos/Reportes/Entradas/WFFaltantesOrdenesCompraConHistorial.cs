using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.Reportes.Entradas
{
    public partial class WFFaltantesOrdenesCompraConHistorial : IposForm
    {
        public WFFaltantesOrdenesCompraConHistorial()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            Int64? p_cliente = 0;

            if (!CBTodos.Checked)
            {
                try
                {
                    p_cliente = Int64.Parse(this.PERSONAIDTextBox.DbValue.ToString());
                }
                catch
                {
                    MessageBox.Show("Seleccione un cliente valido");
                    return;
                }
            }
            else p_cliente = 0;

            report1.SetParameterValue("PROVEEDORID", p_cliente);
            report1.SetParameterValue("NOMBREPROVEEDOR", p_cliente == 0 ? "Todos" : PERSONAIDTextBox.Text);
            report1.SetParameterValue("FECHAPREVIAINI", DTPFrom.Value);
            report1.SetParameterValue("FECHAPREVIAFIN", DTPTo.Value);
            report1.SetParameterValue("CONTRASLADOS", CBTraslados.Checked ? "S" : "N");

            if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void WFFaltantesOrdenesCompraConHistorial_Load(object sender, EventArgs e)
        {
            report1.Load(FastReportsConfig.getPathForFile("InformeFaltantesConHistorial.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);

        }

        private void WFFaltantesOrdenesCompraConHistorial_FormClosing(object sender, FormClosingEventArgs e)
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
