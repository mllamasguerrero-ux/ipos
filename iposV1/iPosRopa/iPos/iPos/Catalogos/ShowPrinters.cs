using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Printing;
using System.Text;
using System.Windows.Forms;

namespace iPos
{

    public partial class ShowPrinters : IposForm
    {
        public static string auxPrinterName;


        public ShowPrinters()
        {
            InitializeComponent();
        }

        public ShowPrinters(List<string> listP)
        {
            InitializeComponent();

            var source = new BindingSource();
            source.DataSource = listP.Select(x => new { Value = x }).ToList(); ;
            dtgvListOfPrinters.DataSource = source;
        }

        private void dtgvListOfPrinters_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvListOfPrinters.SelectedCells.Count > 0)
            {
                int selectedrowindex = dtgvListOfPrinters.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dtgvListOfPrinters.Rows[selectedrowindex];

                auxPrinterName = Convert.ToString(selectedRow.Cells["Value"].Value);

                this.Close();
            }
        }

        
    }
}
