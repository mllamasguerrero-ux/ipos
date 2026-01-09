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
    public partial class WFClienteEstadoCuenta : IposForm
    {
        public WFClienteEstadoCuenta()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            RecargarReport();
            string p_esapartado;
            p_esapartado = (this.CBESAPARTADO.Checked) ? "S" : "N";
            Int64? p_cliente = 0;
            try
            {
                p_cliente = (this.CBESAPARTADO.Checked) ? Int64.Parse(this.PERSONAAPARTADOIDTextBox.DbValue.ToString()) : Int64.Parse(this.PERSONAIDTextBox.DbValue.ToString());
            }
            catch
            {
                MessageBox.Show("Seleccione un cliente valido");
                return;
            }
            report1.SetParameterValue("cliente", p_cliente);
            report1.SetParameterValue("fechainicio", DTPFrom.Value);
            report1.SetParameterValue("fechafin", DTPTo.Value);
            report1.SetParameterValue("esapartado", p_esapartado);

            if (report1.Prepare())
                report1.ShowPrepared();
        }


        private void RecargarReport()
        {

            report1.Load(FastReportsConfig.getPathForFile((this.CBESAPARTADO.Checked) ? "InformeclientesApartado.frx" : "Informeclientes.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);


        }

        private void WFClienteEstadoCuenta_Load(object sender, EventArgs e)
        {
            report1.Load(FastReportsConfig.getPathForFile("Informeclientes.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);

        }

        private void WFClienteEstadoCuenta_FormClosing(object sender, FormClosingEventArgs e)
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

        private void CBESAPARTADO_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlClientes.Enabled = !CBESAPARTADO.Checked;
            this.pnlClientesApartado.Enabled = CBESAPARTADO.Checked;
        }

    }
}
