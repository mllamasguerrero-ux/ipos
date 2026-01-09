using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Movil
{
    public partial class WFPagosPorVendedorMovil : Form
    {
        public WFPagosPorVendedorMovil()
        {
            InitializeComponent();
        }

        private void WFPagosPorVendedorMovil_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void LlenarGrid()
        {

            // TODO: This line of code loads data into the 'dSMovil5.PAGOS_MOVIL_POR_VENDEDOR' table. You can move, or remove it, as needed.
            this.pAGOS_MOVIL_POR_VENDEDORTableAdapter.Fill(this.dSMovil5.PAGOS_MOVIL_POR_VENDEDOR);
        }

        private void pAGOS_MOVIL_POR_VENDEDORDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (pAGOS_MOVIL_POR_VENDEDORDataGridView.Columns[e.ColumnIndex].Name == "btnVer")
            {
                string claveVendedor = pAGOS_MOVIL_POR_VENDEDORDataGridView.Rows[e.RowIndex].Cells["DGVENDEDOR"].Value.ToString();
                DateTime fecha =  (DateTime)pAGOS_MOVIL_POR_VENDEDORDataGridView.Rows[e.RowIndex].Cells["DGFECHA"].Value;
                MostrarPagos(claveVendedor, fecha);
            }
        }

        public void MostrarPagos(string claveVendedor, DateTime fecha)
        {
            WFProcesarPagosVendedorMovil procesarPagos = new WFProcesarPagosVendedorMovil(claveVendedor, fecha);
            procesarPagos.ShowDialog();
            procesarPagos.Dispose();
            GC.SuppressFinalize(procesarPagos);

            LlenarGrid();
        }
    }
}
