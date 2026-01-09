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
    public partial class FRptImpresionPreciosXLocalidad : Form
    {
        public FRptImpresionPreciosXLocalidad()
        {
            InitializeComponent();
        }

        private void FRptImpresionPreciosXLocalidad_Load(object sender, EventArgs e)
        {
            this.ANAQUELINICIOComboBox.llenarDatos();
            this.ANAQUELFINComboBox.llenarDatos();


            report1.Load(FastReportsConfig.getPathForFile("ImpresionDePreciosXLocalidad.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                string anaquelinicio = "Todos";
                string anaquelfin = "Todos";
                if (!CBTodos.Checked)
                {
                    anaquelinicio = this.ANAQUELINICIOComboBox.Text.ToString();
                    anaquelfin = this.ANAQUELFINComboBox.Text.ToString();
                }


                report1.SetParameterValue("p_anaquelinicio", anaquelinicio);
                report1.SetParameterValue("p_anaquelfin", anaquelfin);
                report1.SetParameterValue("p_todos", (CBTodos.Checked) ? "1" : "0");
                report1.SetParameterValue("existenciaP", (cbSinExistencias.Checked) ? "-1" : "0");

                if (report1.Prepare())
                    report1.ShowPrepared();



                /*Microsoft.Reporting.WinForms.ReportParameter[] Param = new Microsoft.Reporting.WinForms.ReportParameter[2];
                Param[0] = new Microsoft.Reporting.WinForms.ReportParameter("anaquelinicio", anaquelinicio);
                Param[1] = new Microsoft.Reporting.WinForms.ReportParameter("anaquelfin", anaquelfin);

                this.reportViewer1.LocalReport.SetParameters(Param);
                this.PRODUCTOLOCATIONSTableAdapter.Fill(this.DSCortesB.PRODUCTOLOCATIONS, anaquelinicio, anaquelfin, (CBTodos.Checked) ? (Int16)1 : (Int16)0);
                this.reportViewer1.RefreshReport();*/

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void FRptImpresionPreciosXLocalidad_FormClosing(object sender, FormClosingEventArgs e)
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
