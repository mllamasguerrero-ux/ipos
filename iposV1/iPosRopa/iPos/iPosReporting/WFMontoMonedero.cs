using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPosReporting
{
    public partial class WFMontoMonedero : Form
    {
        public WFMontoMonedero()
        {
            InitializeComponent();
        }

        private void LlenarDataSource1()
        {
            try
            {
                this.MONEDEROTableAdapter.Fill(this.DSReportIpos2.MONEDERO, DTPFrom.Value, DTPTo.Value);
                Microsoft.Reporting.WinForms.ReportParameter[] Param = new Microsoft.Reporting.WinForms.ReportParameter[2];
                Param[0] = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", DTPFrom.Value.ToString("dd/MM/yyyy"));
                Param[1] = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", DTPTo.Value.ToString("dd/MM/yyyy"));

                this.rptResumen.LocalReport.SetParameters(Param);
                this.rptResumen.Visible = true;
                this.rptResumen.RefreshReport();

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void LlenarDataSource2()
        {
            try
            {
                this.MONEDEROMOVTOTableAdapter.Fill(this.DSReportIpos2.MONEDEROMOVTO, DTPFrom.Value, DTPTo.Value);
                Microsoft.Reporting.WinForms.ReportParameter[] Param = new Microsoft.Reporting.WinForms.ReportParameter[2];
                Param[0] = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", DTPFrom.Value.ToString("dd/MM/yyyy"));
                Param[1] = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", DTPTo.Value.ToString("dd/MM/yyyy"));

                this.rptDesglosado.LocalReport.SetParameters(Param);
                this.rptDesglosado.Visible = true;
                this.rptDesglosado.RefreshReport();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }


        private void LlenarDataSource3()
        {
            try
            {
                this.mONEDERONOABONADOS_TableAdapter1.Fill(this.dSReportIpos.MONEDERONOABONADOS_, DTPFrom.Value, DTPTo.Value);

                Microsoft.Reporting.WinForms.ReportParameter[] Param = new Microsoft.Reporting.WinForms.ReportParameter[2];
                Param[0] = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", DTPFrom.Value.ToString("dd/MM/yyyy"));
                Param[1] = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", DTPTo.Value.ToString("dd/MM/yyyy"));

                this.rptNoAbonado.LocalReport.SetParameters(Param);
                this.rptNoAbonado.Visible = true;
                this.rptNoAbonado.RefreshReport();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        
        private void BTEnviar_Click(object sender, EventArgs e)
        {
            LlenarDataSource1();
            LlenarDataSource2();
            LlenarDataSource3();
        }

        private void WFMontoMonedero_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DSReportIpos2.MONEDERONOABONADOS_' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'DSReportIpos2.MONEDERONOABONADOS' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'DSReportIpos2.MONEDEROMOVTO' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'DSReportIpos2.MONEDERO' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'dSReportIpos2.REP_DESGLOSEMONEDERO' table. You can move, or remove it, as needed.
            //this.rEP_DESGLOSEMONEDEROTableAdapter.Fill(this.dSReportIpos2.REP_DESGLOSEMONEDERO);
            // TODO: This line of code loads data into the 'dSReportIpos2.REP_DESGLOSEMONEDERO' table. You can move, or remove it, as needed.
            //this.rEP_DESGLOSEMONEDEROTableAdapter.Fill(this.dSReportIpos2.REP_DESGLOSEMONEDERO);



        }

    }
}
