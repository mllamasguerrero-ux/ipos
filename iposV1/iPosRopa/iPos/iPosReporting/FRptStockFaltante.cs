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
    public partial class FRptStockFaltante : Form
    {
        public FRptStockFaltante()
        {
            InitializeComponent();
        }

        private void FRptStockFaltante_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSReportIpos.STOCK_FALTANTE' table. You can move, or remove it, as needed.
            this.sTOCK_FALTANTETableAdapter.Fill(this.dSReportIpos.STOCK_FALTANTE);

            this.reportViewer1.RefreshReport();
        }
    }
}
