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
    public partial class WFAbonoIntercambioProveedores : Form
    {
        public WFAbonoIntercambioProveedores()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            Int64? p_cliente = 0;
            string p_proveedorNombre = "Todos";

            if(!cbTodosProveedores.Checked)
            {
                try
                {
                    p_cliente = Int64.Parse(this.PERSONAIDTextBox.DbValue.ToString());
                    p_proveedorNombre = PERSONALabel.Text;
                }
                catch
                {
                    MessageBox.Show("Seleccione un cliente valido");
                    return;
                }
            }

            report1.SetParameterValue("proveedorid", p_cliente);
            report1.SetParameterValue("proveedorNombre", p_proveedorNombre);
            report1.SetParameterValue("fechaInicio", DTPFrom.Value);
            report1.SetParameterValue("fechaFin", DTPTo.Value);

             if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void WFAbonoIntercambioProveedores_Load(object sender, EventArgs e)
        {
            report1.Load(FastReportsConfig.getPathForFile("IntercambioXProvee.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void WFAbonoIntercambioProveedores_FormClosing(object sender, FormClosingEventArgs e)
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
