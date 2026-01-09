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
    public partial class WFFacturasMovilesConError : IposForm
    {
        public WFFacturasMovilesConError()
        {
            InitializeComponent();
        }

        private void llenarGrid()
        {
            try
            {
                this.fACTURASCONERRORTableAdapter.Fill(this.dSMovil3.FACTURASCONERROR, dtpInicio.Value, dtpFin.Value);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnSeleccionarVenta_Click(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void WFFacturasMovilesConError_Load(object sender, EventArgs e)
        {
            

            llenarGrid();
        }



        private void fACTURASCONERRORDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                long docId = long.Parse(fACTURASCONERRORDataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                WFPuntoDeVenta wf = new WFPuntoDeVenta(docId);
                wf.ShowDialog();
                wf.Dispose();
                GC.SuppressFinalize(wf);

            }
        }
    }
}
