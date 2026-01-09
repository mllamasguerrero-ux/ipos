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
	public partial class FormKardexResumido : Form
	{
		public FormKardexResumido()
		{
			InitializeComponent();
		}

		private void FormKardexResumido_Load(object sender, EventArgs e)
		{
            // TODO: This line of code loads data into the 'dSReportIpos.GET_KARDEX_REPORT_SUMMARY' table. You can move, or remove it, as needed.
            //this.gET_KARDEX_REPORT_SUMMARYTableAdapter.Fill(this.dSReportIpos.GET_KARDEX_REPORT_SUMMARY);
            //this.reportViewer1.RefreshReport();
		}

		private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Microsoft.Reporting.WinForms.ReportParameter[] Param = new Microsoft.Reporting.WinForms.ReportParameter[4];
                Param[0] = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", DTPFechaInicial.Value.ToString("dd/MM/yyyy"));
                Param[1] = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", DTPFechaFinal.Value.ToString("dd/MM/yyyy"));
                Param[2] = new Microsoft.Reporting.WinForms.ReportParameter("ProductoInicio", (TBProductoInicial.Text == "") ? "(PRIMERO)" : TBProductoInicial.Text);
                Param[3] = new Microsoft.Reporting.WinForms.ReportParameter("ProductoFin", (TBProductoFinal.Text == "") ? "(ULTIMO)" : TBProductoFinal.Text);


                this.reportViewer1.LocalReport.SetParameters(Param);

                this.gET_KARDEX_REPORT_SUMMARYTableAdapter.Fill(this.dSReportIpos.GET_KARDEX_REPORT_SUMMARY, TBProductoInicial.Text, TBProductoFinal.Text, this.DTPFechaInicial.Value.Date, this.DTPFechaFinal.Value.Date, DBValues._DOCTO_ALMACEN_DEFAULT);

			//this.kARDEX1TableAdapter.Fill(this.DSReportIpos.KARDEX1);
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


        //private void fillToolStripButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.gET_KARDEX_REPORTTableAdapter.Fill(this.dSReportIpos.GET_KARDEX_REPORT, pROD_CLAVE_INIToolStripTextBox.Text, pROD_CLAVE_FINToolStripTextBox.Text, new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(fECHAINIToolStripTextBox.Text, typeof(System.DateTime))))), new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(fECHAFINToolStripTextBox.Text, typeof(System.DateTime))))), new System.Nullable<long>(((long)(System.Convert.ChangeType(aLMACENIDToolStripTextBox.Text, typeof(long))))));
        //    }
        //    catch (System.Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //    }

        //}


	}
}
