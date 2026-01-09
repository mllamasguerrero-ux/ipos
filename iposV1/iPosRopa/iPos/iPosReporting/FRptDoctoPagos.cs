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
	public partial class FRptDoctoPagos : Form
	{
		public FRptDoctoPagos()
		{
			InitializeComponent();
		}

		private void FRptDoctoPagos_Load(object sender, EventArgs e)
		{
            // TODO: This line of code loads data into the 'dSReportIpos2.DOCUMENTOSPAGOS' table. You can move, or remove it, as needed.
            //this.dOCUMENTOSPAGOSTableAdapter.Fill(this.dSReportIpos2.DOCUMENTOSPAGOS);
            CBFormaPago.SelectedIndex = 0;
            CBTipoDocto.SelectedIndex = 0;
            //this.reportViewer1.RefreshReport();
		}

		private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                long iTipoDocto;
                switch (CBTipoDocto.SelectedIndex)
                {
                    case 0: iTipoDocto = DBValues._DOCTO_TIPO_VENTA; break;
                    case 1: iTipoDocto = DBValues._DOCTO_TIPO_COMPRA; break;
                    default: iTipoDocto = DBValues._DOCTO_TIPO_VENTA; break;
                }

                long iFormaPago;
                switch (CBFormaPago.SelectedIndex)
                {
                    case 1: iFormaPago = DBValues._FORMA_PAGO_EFECTIVO; break;
                    case 2: iFormaPago = DBValues._FORMA_PAGO_TARJETA; break;
                    case 3: iFormaPago = DBValues._FORMA_PAGO_CHEQUE; break;
                    case 4: iFormaPago = DBValues._FORMA_PAGO_CREDITO; break;
                    case 5: iFormaPago = DBValues._FORMA_PAGO_INTERCAMBIOMERCANCIACREDITO; break;
                    case 6: iFormaPago = -2; break;
                    default: iFormaPago = 0; break;
                }


                Int64 iCajero = 0;
                try
                {
                    iCajero = (CBCajerosTodos.Checked) ? 0 : Int64.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
                }
                catch
                {
                    MessageBox.Show("Seleccione un cajero valido");
                }


                Int64 iGrupoCajero = 0;
                try
                {
                    iGrupoCajero = (CBGrupoCajerosTodos.Checked) ? 0 : Int64.Parse(this.GRUPOUSUARIOIDTextBox.DbValue.ToString());

                }
                catch
                {
                    MessageBox.Show("Seleccione un grupo de cajeros valido");
                }


                RecargarReport();
                report1.SetParameterValue("tipodoctoid", iTipoDocto);
                report1.SetParameterValue("fechaInicio", DTPFechaInicial.Value);
                report1.SetParameterValue("fechaFin", DTPFechaFinal.Value);
                report1.SetParameterValue("cajeroid", iCajero);
                report1.SetParameterValue("forma_pagoid", iFormaPago);
                report1.SetParameterValue("formaPagoNombre", this.CBFormaPago.Text);
                report1.SetParameterValue("cajeronombre", (CBCajerosTodos.Checked) ? "Todos" : this.VENDEDORLabel.Text);
                report1.SetParameterValue("tipodoctonombre", this.CBTipoDocto.Text);
                report1.SetParameterValue("grupocajeroid", iGrupoCajero);
                report1.SetParameterValue("grupocajeronombre", (CBGrupoCajerosTodos.Checked) ? "Todos" : this.GRUPOUSUARIOIDLabel.Text);



                if (report1.Prepare())
                    report1.ShowPrepared();

                /*

                Microsoft.Reporting.WinForms.ReportParameter[] Param = new Microsoft.Reporting.WinForms.ReportParameter[5];
                Param[0] = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", DTPFechaInicial.Value.ToString("dd/MM/yyyy"));
                Param[1] = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", DTPFechaFinal.Value.ToString("dd/MM/yyyy"));
                Param[2] = new Microsoft.Reporting.WinForms.ReportParameter("TipoDocto",this.CBTipoDocto.Text);
                Param[3] = new Microsoft.Reporting.WinForms.ReportParameter("FormaPago", this.CBFormaPago.Text);
                Param[4] = new Microsoft.Reporting.WinForms.ReportParameter("Cajero", (CBCajerosTodos.Checked) ? "Todos" : this.VENDEDORLabel.Text);


                Int64 iCajero = (CBCajerosTodos.Checked) ? 0 : Int64.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
                this.reportViewer1.LocalReport.SetParameters(Param);
                this.dOCUMENTOSPAGOSTableAdapter.Fill(this.dSReportIpos2.DOCUMENTOSPAGOS, iTipoDocto, iFormaPago, this.DTPFechaInicial.Value.Date, this.DTPFechaFinal.Value.Date, iCajero);
                this.reportViewer1.RefreshReport();*/

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
		}



        private void RecargarReport()
        {

            report1.Load(FastReportsConfigReport.getPathForFile("DocumentosFormaPago.frx", FastReportsConfigTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", ConexionesBD.ConexionBD.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", ConexionesBD.ConexionBD.CurrentUser.IID);
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
