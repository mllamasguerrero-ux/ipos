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
    public partial class WFRptInventarioXLoc : Form
    {
        public WFRptInventarioXLoc()
        {
            InitializeComponent();
        }

        private void WFRptInventarioXLoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DSIposReportingC.PRODUCTOLOCATIONS' table. You can move, or remove it, as needed.
            //this.PRODUCTOLOCATIONSTableAdapter.Fill(this.DSIposReportingC.PRODUCTOLOCATIONS);
            // TODO: This line of code loads data into the 'DSIposReportingC.INVENTARIOXLOC_VIEW' table. You can move, or remove it, as needed.
            this.INVENTARIOXLOC_VIEWTableAdapter.Fill(this.DSIposReportingC.INVENTARIOXLOC_VIEW);
            
            this.reportViewer1.RefreshReport();
        }
    }
}
