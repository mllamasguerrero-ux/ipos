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
    public partial class FRptComisiones : Form
    {
        public FRptComisiones()
        {
            InitializeComponent();

        }

        private void FRptComisiones_Load(object sender, EventArgs e)
        {
            /*// TODO: This line of code loads data into the 'DSIposReportingC.DESGLOSE_COMISIONES' table. You can move, or remove it, as needed.
            this.DESGLOSE_COMISIONESTableAdapter.Fill(this.DSIposReportingC.DESGLOSE_COMISIONES);
            // TODO: This line of code loads data into the 'DSIposReportingC.RESUMEN_COMISIONES' table. You can move, or remove it, as needed.
            this.RESUMEN_COMISIONESTableAdapter.Fill(this.DSIposReportingC.RESUMEN_COMISIONES);
            this.reportViewer2.RefreshReport();*/
        }


        private void BTEnviar_Click(object sender, EventArgs e)
        {
                Microsoft.Reporting.WinForms.ReportParameter[] Param = new Microsoft.Reporting.WinForms.ReportParameter[2];
                Param[0] = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", DTPFrom.Value.ToString("dd/MM/yyyy"));
                Param[1] = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", DTPTo.Value.ToString("dd/MM/yyyy"));
                this.reportViewer1.LocalReport.SetParameters(Param);
                this.reportViewer2.LocalReport.SetParameters(Param);

                LoadDataSource();
                this.reportViewer1.RefreshReport(); 
                this.reportViewer2.RefreshReport();
        }

        private void LoadDataSource()
        {
            try
            {
                this.DESGLOSE_COMISIONESTableAdapter.Fill(this.DSIposReportingC.DESGLOSE_COMISIONES, this.DTPFrom.Value.Date, this.DTPTo.Value.Date);
                this.RESUMEN_COMISIONESTableAdapter.Fill(this.DSIposReportingC.RESUMEN_COMISIONES, this.DTPFrom.Value.Date, this.DTPTo.Value.Date);

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
