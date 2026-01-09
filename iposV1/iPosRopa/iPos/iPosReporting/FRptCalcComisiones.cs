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
    public partial class FRptCalcComisiones : Form
    {
        public FRptCalcComisiones()
        {
            InitializeComponent();
        }

        private void FRptCalcComisiones_Load(object sender, EventArgs e)
        {
        }

        private void LlenarDataSource()
        {
            try
            {
                this.cALC_COMISIONESTableAdapter.Fill(this.dSReportIpos.CALC_COMISIONES, DTPFrom.Value, DTPTo.Value);
                Microsoft.Reporting.WinForms.ReportParameter[] Param = new Microsoft.Reporting.WinForms.ReportParameter[2];
                Param[0] = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", DTPFrom.Value.ToString("dd/MM/yyyy"));
                Param[1] = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", DTPTo.Value.ToString("dd/MM/yyyy"));
                this.reportViewer1.LocalReport.SetParameters(Param);
                this.reportViewer1.Visible = true;
                this.reportViewer1.RefreshReport();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            LlenarDataSource();
        }

    }
}
