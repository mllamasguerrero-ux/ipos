using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos
{
    public partial class WFImportarDeExcel : IposForm
    {
        public WFImportarDeExcel()
        {
            InitializeComponent();
        }

        private void BTImpCatExcel_Click(object sender, EventArgs e)
        {
            WFImportarCatalogoDeExcel wfe = new WFImportarCatalogoDeExcel();
            wfe.ShowDialog();
            wfe.Dispose();
            GC.SuppressFinalize(wfe);
        }
    }
}
