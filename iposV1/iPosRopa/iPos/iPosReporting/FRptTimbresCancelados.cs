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
    public partial class FRptTimbresCancelados : Form
    {
        public FRptTimbresCancelados()
        {
            InitializeComponent();

        }

        private void FRptTimbresCancelados_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DSIposReportingC.TIMBRESCANCELADOS' table. You can move, or remove it, as needed.
            //this.TIMBRESCANCELADOSTableAdapter.Fill(this.DSIposReportingC.TIMBRESCANCELADOS);
            // TODO: This line of code loads data into the 'DSIposReportingC.TIMBRESCANCELADOS' table. You can move, or remove it, as needed.
           // this.TIMBRESCANCELADOSTableAdapter.Fill(this.DSIposReportingC.TIMBRESCANCELADOS);

            TIMBRADOCANCELADOComboBox.SelectedIndex = 0;
           
        }


        private void BTEnviar_Click(object sender, EventArgs e)
        {
                Microsoft.Reporting.WinForms.ReportParameter[] Param = new Microsoft.Reporting.WinForms.ReportParameter[2];
                Param[0] = new Microsoft.Reporting.WinForms.ReportParameter("FechaInicio", DTPFrom.Value.ToString("dd/MM/yyyy"));
                Param[1] = new Microsoft.Reporting.WinForms.ReportParameter("FechaFin", DTPTo.Value.ToString("dd/MM/yyyy"));
                this.reportViewer1.LocalReport.SetParameters(Param);

                LoadDataSource();
                this.reportViewer1.RefreshReport(); 
        }

        private void LoadDataSource()
        {
            try
            {
                string TIMBRADOCANCELADO = "T";
                switch(TIMBRADOCANCELADOComboBox.SelectedIndex)
                {
                    case 0: TIMBRADOCANCELADO = "T"; break;
                    case 1: TIMBRADOCANCELADO = "S"; break;
                    case 2: TIMBRADOCANCELADO = "N"; break;
                    default : TIMBRADOCANCELADO = "T"; break;
                }

                this.TIMBRESCANCELADOSTableAdapter.Fill(this.DSIposReportingC.TIMBRESCANCELADOS, this.DTPFrom.Value.Date, this.DTPTo.Value.Date,TIMBRADOCANCELADO);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

       
    }
}
