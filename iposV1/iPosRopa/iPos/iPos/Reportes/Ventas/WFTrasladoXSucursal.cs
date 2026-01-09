using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;

namespace iPos.Reportes
{
    public partial class WFTrasladoXSucursal : IposForm
    {
        public WFTrasladoXSucursal()
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
                    p_item = Int64.Parse(this.SucursalComboBox.SelectedValue.ToString());
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

            String strReporte = "";
            switch(comboTipoReporte.SelectedIndex)
            {
                case 0: strReporte = "InformeTrasladosXDocto.frx"; break;
                case 1: strReporte = "InformeTraslados.frx"; break;
                case 2: strReporte = "InformeTrasladosSum.frx"; break;
            }

            report1.Load(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void WFTrasladoXSucursal_Load(object sender, EventArgs e)
        {
            comboTipoReporte.SelectedIndex = 0;

            SucursalComboBox.llenarDatos();
            SucursalComboBox.SelectedIndex = 0;
        }

        private void WFTrasladoXSucursal_FormClosing(object sender, FormClosingEventArgs e)
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
