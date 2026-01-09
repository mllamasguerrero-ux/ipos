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

namespace iPosReporting
{
	public partial class FRptInvCosteado : Form
	{
        CPARAMETROBE currentParameter = null;
		public FRptInvCosteado()
		{
			InitializeComponent();
		}

        public FRptInvCosteado(CPARAMETROBE p_currentParameter):this()
        {
            currentParameter = p_currentParameter;
        }

		private void FRptInvCosteado_Load(object sender, EventArgs e)
		{
            this.aLMACENTableAdapter.Fill(this.dSReportIpos.ALMACEN); 
        }

		private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                long almacenId = (CBSoloAlmacen.Checked) ? long.Parse((comboBoxAlmacen.SelectedValue.ToString())) : 0;
                string nombreAlmacen = (CBSoloAlmacen.Checked) ? this.comboBoxAlmacen.Text : "Todos";

                Microsoft.Reporting.WinForms.ReportParameter[] Param = new Microsoft.Reporting.WinForms.ReportParameter[9];
                Param[0] = new Microsoft.Reporting.WinForms.ReportParameter("ProductoInicio", (TBProductoInicial.Text == "") ? "(PRIMERO)" : TBProductoInicial.Text);
                Param[1] = new Microsoft.Reporting.WinForms.ReportParameter("ProductoFin", (TBProductoFinal.Text == "") ? "(ULTIMO)" : TBProductoFinal.Text);

                Param[2] = new Microsoft.Reporting.WinForms.ReportParameter("TITULOTEXTO1", ((bool)currentParameter.isnull["ITEXTO1"]) ? "" : currentParameter.ITEXTO1);
                Param[3] = new Microsoft.Reporting.WinForms.ReportParameter("TITULOTEXTO2", ((bool)currentParameter.isnull["ITEXTO2"]) ? "" : currentParameter.ITEXTO2);
                Param[4] = new Microsoft.Reporting.WinForms.ReportParameter("TITULOTEXTO3", ((bool)currentParameter.isnull["ITEXTO3"]) ? "" : currentParameter.ITEXTO3);
                Param[5] = new Microsoft.Reporting.WinForms.ReportParameter("TITULOTEXTO4", ((bool)currentParameter.isnull["ITEXTO4"]) ? "" : currentParameter.ITEXTO4);
                Param[6] = new Microsoft.Reporting.WinForms.ReportParameter("TITULONUMERO1", ((bool)currentParameter.isnull["INUMERO1"]) ? "" : currentParameter.INUMERO1);
                Param[7] = new Microsoft.Reporting.WinForms.ReportParameter("TITULONUMERO2", ((bool)currentParameter.isnull["INUMERO2"]) ? "" : currentParameter.INUMERO2);
                Param[8] = new Microsoft.Reporting.WinForms.ReportParameter("NOMBREALMACEN", nombreAlmacen);




                this.reportViewer1.LocalReport.SetParameters(Param);
                this.iNVENTARIOCOSTEADOTableAdapter.Fill(this.dSReportIpos2.INVENTARIOCOSTEADO, TBProductoInicial.Text, ((TBProductoFinal.Text == "") ? "ZZZZ" : TBProductoFinal.Text), almacenId);
                this.reportViewer1.RefreshReport();

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


	}
}
