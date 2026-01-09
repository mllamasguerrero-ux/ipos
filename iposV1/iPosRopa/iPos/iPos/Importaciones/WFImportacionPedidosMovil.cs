using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Importaciones
{
    public partial class WFImportacionPedidosMovil : Form
    {
        int m_tipoDoctoId = 331;
        public WFImportacionPedidosMovil()
        {
            InitializeComponent();
        }
        public WFImportacionPedidosMovil(int tipoDoctoId):this()
        {
            m_tipoDoctoId = tipoDoctoId;
        }

        private void WFImportacionPedidosMovil_Load(object sender, EventArgs e)
        {
            LlenarGrid();

            if(m_tipoDoctoId == 341)
            {
                this.Text = "Información de Compras Pendientes por Vendedor";
            }
        }

        private void LlenarGrid()
        {
            try
            {
                // TODO: This line of code loads data into the 'dSImportaciones.INFO_PEDIDOS_MOVIL' table. You can move, or remove it, as needed.
                this.iNFO_PEDIDOS_MOVILTableAdapter.Fill(this.dSImportaciones.INFO_PEDIDOS_MOVIL,m_tipoDoctoId);

                FijarColorVendedorEnRuta();
            }
            catch(Exception e)
            {
                MessageBox.Show("Hubo un problema al llenar el grid: " + e.Message);
            }
        }

        private void FijarColorVendedorEnRuta()
        {
            foreach (DataGridViewRow row in iNFO_PEDIDOS_MOVILDataGridView.Rows)
            {
                bool enRuta = ((int)row.Cells["DGENRUTA"].Value == 1 ? true : false);

                if (enRuta)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void iNFO_PEDIDOS_MOVILDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (iNFO_PEDIDOS_MOVILDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString().Equals("VER"))
                {
                    long vendedorId = (long)iNFO_PEDIDOS_MOVILDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;
                    int enRuta = (int)iNFO_PEDIDOS_MOVILDataGridView.Rows[e.RowIndex].Cells["DGENRUTA"].Value;

                    var bufferCotiEnrutada = iNFO_PEDIDOS_MOVILDataGridView.Rows[e.RowIndex].Cells["DGCOTI_ENRUTADA"].Value ;
                    string cotiEnrutada = bufferCotiEnrutada != null && bufferCotiEnrutada != DBNull.Value ? bufferCotiEnrutada.ToString() : "N";


                    if (this.m_tipoDoctoId == iPosData.DBValues._DOCTO_TIPO_COMPRAMOVIL)
                    {


                        WFImpComprasMovPorVendedor wf = new WFImpComprasMovPorVendedor(vendedorId, enRuta);
                        wf.ShowDialog();
                        wf.Dispose();
                        GC.SuppressFinalize(wf);
                    }
                    else
                    {

                        WFImpPedidosMovPorVendedor wf = new WFImpPedidosMovPorVendedor(vendedorId, enRuta, cotiEnrutada);
                        wf.ShowDialog();
                        wf.Dispose();
                        GC.SuppressFinalize(wf);
                    }



                    LlenarGrid();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
