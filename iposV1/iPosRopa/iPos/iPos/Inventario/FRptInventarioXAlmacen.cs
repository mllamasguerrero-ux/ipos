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
	public partial class FRptInventarioXAlmacen : IposForm
	{
		public FRptInventarioXAlmacen()
		{
			InitializeComponent();
		}

		private void FRptInventarioXAlmacen_Load(object sender, EventArgs e)
		{
            this.ALMACENComboBox.llenarDatos();


            report1.Load(FastReportsConfig.getPathForFile("productosXalmacen.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

		private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nombrealmacen = "Todos";
                string nombreproducto = "Todos";
                long almacenid = 0; long productoid = 0;

                if (!CBTodosProductos.Checked)
                {
                    productoid = Int64.Parse(this.PRODUCTOIDTextBox.DbValue.ToString());
                    nombreproducto = this.PRODUCTOIDTextBox.Text;
                }

                if (!CBTodosAlmacenes.Checked)
                {
                    almacenid = long.Parse(this.ALMACENComboBox.SelectedValue.ToString());
                    nombrealmacen = this.ALMACENComboBox.SelectedText;
                }


                report1.SetParameterValue("p_almaceninicio", (decimal)almacenid);
                report1.SetParameterValue("p_productoid", (decimal)productoid);
                report1.SetParameterValue("p_nombrealmacen", nombrealmacen);
                report1.SetParameterValue("p_nombreproducto", nombreproducto);

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

        private void FRptInventarioXAlmacen_FormClosing(object sender, FormClosingEventArgs e)
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
