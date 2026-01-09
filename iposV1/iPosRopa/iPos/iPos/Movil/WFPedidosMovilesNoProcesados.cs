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
    public partial class WFPedidosMovilesNoProcesados : IposForm
    {
        public WFPedidosMovilesNoProcesados()
        {
            InitializeComponent();
        }

        private void llenarGrid()
        {
            try
            {
                this.pEDIDOSMOVILESNOPROCTableAdapter.Fill(this.dSMovil3.PEDIDOSMOVILESNOPROC, dtpInicio.Value, dtpFin.Value);
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

        private void WFPedidosMovilesNoProcesados_Load(object sender, EventArgs e)
        {
            

            llenarGrid();
        }

        private void pEDIDOSMOVILESNOPROCDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 )
            {
                long docId = long.Parse(pEDIDOSMOVILESNOPROCDataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                WFPuntoDeVenta wf = new WFPuntoDeVenta(docId);
                wf.ShowDialog();
                wf.Dispose();
                GC.SuppressFinalize(wf);

            }
        }
    }
}
