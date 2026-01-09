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
    public partial class WFProductosXMarca : IposForm
    {
        public WFProductosXMarca()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            Int64? p_itemid = 0;

            if (!CBTodasItem.Checked)
            {
                try
                {
                    p_itemid = Int64.Parse(this.ITEMIDTextBox.DbValue.ToString());
                }
                catch
                {
                    MessageBox.Show("Seleccione un registro valido");
                    return;
                }
            }

            Int64? listaDePrecios = 0;
            if (LISTAPRECIOIDTextBox.SelectedIndex > 0)
                listaDePrecios = LISTAPRECIOIDTextBox.SelectedIndex;

            report1.SetParameterValue("ListaDePrecios", (Decimal)listaDePrecios);
            report1.SetParameterValue("MostrarExistencia", CBMostrarExistencia.Checked);
            report1.SetParameterValue("itemid", (Decimal)p_itemid);

            if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void RecargarReport()
        {

            report1.Load(FastReportsConfig.getPathForFile("InformeProductosXMarca.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void WFProductosXMarca_Load(object sender, EventArgs e)
        {
            RecargarReport();
        }

        private void WFProductosXMarca_FormClosing(object sender, FormClosingEventArgs e)
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
