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
    public partial class FRptKardex : Form
    {
        public FRptKardex()
        {
            InitializeComponent();
        }

        private void FRptKardex_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DSReportIpos.KARDEX1' table. You can move, or remove it, as needed.
            this.KARDEX1TableAdapter.Fill(this.DSReportIpos.KARDEX1);

            this.reportViewer1.RefreshReport();
        }
    }
}
