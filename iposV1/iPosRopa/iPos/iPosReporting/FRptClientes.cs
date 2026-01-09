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
    public partial class FRptClientes : Form
    {
        public FRptClientes()
        {
            InitializeComponent();
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "iPosReporting.RptClientes.rdlc";
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.CLIENTESTableAdapter.Fill(this.DSReportIpos.CLIENTES);
            this.reportViewer1.RefreshReport();
        }
    }
}