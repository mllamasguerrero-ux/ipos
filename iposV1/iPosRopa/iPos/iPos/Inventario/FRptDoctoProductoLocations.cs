using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosData;
using iPosBusinessEntity;

namespace iPos
{
	public partial class FRptProductoLocations : IposForm
	{
		public FRptProductoLocations()
		{
			InitializeComponent();
		}

		private void FRptProductoLocations_Load(object sender, EventArgs e)
		{
            this.ANAQUELINICIOComboBox.llenarDatos();
            this.ANAQUELFINComboBox.llenarDatos();


            report1.Load(FastReportsConfig.getPathForFile("localidadproductos.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
		}

		private void button1_Click(object sender, EventArgs e)
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

		private void button2_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			//this.reportViewer1.RefreshReport();
        }

        private void FRptProductoLocations_FormClosing(object sender, FormClosingEventArgs e)
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
