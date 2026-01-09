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
    public partial class WFInformeCatalogoProductos : IposForm
    {
        public WFInformeCatalogoProductos()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            Int64? p_linea = 0;
            Int64? p_proveedor = 0;
            Int64? p_marca = 0;

            if (!CBTodasLineas.Checked)
            {
                try
                {
                    p_linea = Int64.Parse(this.LINEAIDTextBox.DbValue.ToString());
                }
                catch
                {
                    MessageBox.Show("Seleccione una linea valida");
                    return;
                }
            }


            if (!CBTodosProveedores.Checked)
            {
                try
                {
                    p_proveedor = Int64.Parse(this.PROVEEDOR1IDTextBox.DbValue.ToString());
                }
                catch
                {
                    MessageBox.Show("Seleccione un proveedor valido");
                    return;
                }
            }


            if (!CBTodasMarcas.Checked)
            {
                try
                {
                    p_marca = Int64.Parse(this.MARCAIDTextBox.DbValue.ToString());
                }
                catch
                {
                    MessageBox.Show("Seleccione una marca valida");
                    return;
                }
            }



            report1.SetParameterValue("proveedorid", (Decimal)p_proveedor);
            report1.SetParameterValue("marcaid", (Decimal)p_marca);
            report1.SetParameterValue("lineaid", (Decimal)p_linea);

            if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void RecargarReport()
        {

            report1.Load(FastReportsConfig.getPathForFile("InformeCatalogoProductos.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void WFInformeCatalogoProductos_Load(object sender, EventArgs e)
        {
            RecargarReport();
        }

        private void WFInformeCatalogoProductos_FormClosing(object sender, FormClosingEventArgs e)
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
