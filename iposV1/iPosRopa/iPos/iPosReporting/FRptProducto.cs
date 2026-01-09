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
    public partial class FRptProducto : Form
    {
        long m_lProductId = 0;
        public FRptProducto()
        {
            InitializeComponent();
        }


        public FRptProducto(long lProductId):this()
        {
            m_lProductId = lProductId;
        }

        private void FRptProducto_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DSReportIpos.PRODUCTO' table. You can move, or remove it, as needed.
            this.PRODUCTOTableAdapter.Fill(this.DSReportIpos.PRODUCTO, (int)m_lProductId);

            this.reportViewer1.RefreshReport();
        }
    }
}
