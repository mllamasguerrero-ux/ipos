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
    public partial class WFProveedorEstadoCuenta : IposForm
    {
        public WFProveedorEstadoCuenta()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            Int64? p_cliente = 0;
            try
            {
                p_cliente =  Int64.Parse(this.PERSONAIDTextBox.DbValue.ToString());
            }
            catch
            {
                MessageBox.Show("Seleccione un cliente valido");
                return;
            }
            report1.SetParameterValue("cliente", p_cliente);
            report1.SetParameterValue("fechainicio", DTPFrom.Value);
            report1.SetParameterValue("fechafin", DTPTo.Value);

            if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void WFProveedorEstadoCuenta_Load(object sender, EventArgs e)
        {
            report1.Load(FastReportsConfig.getPathForFile("InformeProveedores.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);

        }

        private void WFProveedorEstadoCuenta_FormClosing(object sender, FormClosingEventArgs e)
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
