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
    public partial class WFAbonoProveedores : Form
    {
        public WFAbonoProveedores()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            Int64? p_cliente = 0;
            Int64? p_usuario = 0;

            if(!cbTodosProveedores.Checked)
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

            if(!cbTodosUsuarios.Checked)
            {
                try
                {
                    p_usuario = Int64.Parse(this.USUARIOIDTextBox.DbValue.ToString());
                }
                catch
                {
                    MessageBox.Show("Seleccione un usuario valido");
                    return;
                }
            }

            report1.SetParameterValue("proveedorid", p_cliente);
            report1.SetParameterValue("vendedorid", p_usuario);
            report1.SetParameterValue("fechaini", DTPFrom.Value);
            report1.SetParameterValue("fechafin", DTPTo.Value);

             if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void WFAbonoProveedores_Load(object sender, EventArgs e)
        {
            report1.Load(FastReportsConfig.getPathForFile("InformeAbonoAProveedores.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void WFAbonoProveedores_FormClosing(object sender, FormClosingEventArgs e)
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
