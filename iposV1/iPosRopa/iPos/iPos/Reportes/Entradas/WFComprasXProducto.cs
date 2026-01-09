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
    public partial class WFComprasXProducto : IposForm
    {
        public WFComprasXProducto()
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
            report1.SetParameterValue("fechaini", DTPFrom.Value);
            report1.SetParameterValue("fechafin", DTPTo.Value);

            if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void RecargarReport()
        {

            report1.Load(FastReportsConfig.getPathForFile("InformeComprasXProducto.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void WFComprasXProducto_Load(object sender, EventArgs e)
        {
        }

        private void WFComprasXProducto_FormClosing(object sender, FormClosingEventArgs e)
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

        private void ITEMButton_Click(object sender, EventArgs e)
        {
            LOOKPROD look;
            look = new LOOKPROD("",false, TipoProductoNivel.tp_hijos);
            //look.m_showEmptyIfNoFilter = false;
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                this.ITEMIDTextBox.Text = dr["CLAVE"].ToString().Trim();
                ITEMIDTextBox.Focus();
                ITEMIDTextBox.Select(ITEMIDTextBox.Text.Length, 0);
            }
        }
    }
}
