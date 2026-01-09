using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos
{
    public partial class WFProveedorSaldo : Form
    {

        public long proveedorId = 0;
        public string solovencidos = "N";

        public WFProveedorSaldo()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            RecargarReport();
            Int64? p_proveedor = 0;
            if (!CBTodas.Checked)
            {

                try
                {
                    p_proveedor = Int64.Parse(this.PERSONAIDTextBox.DbValue.ToString());
                }
                catch
                {
                    MessageBox.Show("Seleccione un proveedor valido");
                    return;
                }
            }
            report1.SetParameterValue("proveedorid", p_proveedor);
            report1.SetParameterValue("solovencidos", solovencidos);

            if (report1.Prepare())
                report1.ShowPrepared();
        }


        private void RecargarReport()
        {

            report1.Load(FastReportsConfig.getPathForFile(CBSumarizado.Checked ? "InformeSaldosProveedorSum.frx" : "InformeSaldosProveedor.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void WFProveedorSaldo_Load(object sender, EventArgs e)
        {
        }

        private void WFProveedorSaldo_FormClosing(object sender, FormClosingEventArgs e)
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

        private void rdSoloVencidos_CheckedChanged(object sender, EventArgs e)
        {
            solovencidos = rdSoloVencidos.Checked ? "S" : "N";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SeleccionaProveedor();
        }

        private void SeleccionaProveedor()
        {

            iPos.Catalogos.WFProveedores look = new iPos.Catalogos.WFProveedores();
            look.m_bSelecionarRegistro = true;
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {

                string strBuffer = "";
                this.PERSONAIDTextBox.DbValue = ((long)dr["ID"]).ToString();
                this.PERSONAIDTextBox.MostrarErrores = false;
                this.PERSONAIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.PERSONAIDTextBox.MostrarErrores = true;
             


            }
        }
    }
}
