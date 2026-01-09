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
    public partial class WFPedidosYaExportados : IposForm
    {
        DateTime m_FECHATO, m_FECHAFROM;
        //int m_TURNOID;
        public bool m_Confirmar;
        public int m_reenviarPedidoExistente = 0;
        public long m_expFileExistente = 0;
        public DateTime m_fechaPedidoExistente;
        public WFPedidosYaExportados()
        {
            InitializeComponent();
            m_Confirmar = false;
            m_reenviarPedidoExistente = 0;
            m_fechaPedidoExistente = DateTime.Today;
        }
        public WFPedidosYaExportados(DateTime fechaFrom, DateTime fechaTo/*, int turnoID*/):this()
        {
            m_FECHATO = fechaTo; 
            m_FECHAFROM = fechaFrom;
            //m_TURNOID = turnoID;
        }

        private void LlenarGrid()
        {
            try
            {
                this.lISTAPEDIDOSENVIADOSFECHATableAdapter.Fill(this.dSImportaciones.LISTAPEDIDOSENVIADOSFECHA,  m_FECHAFROM,m_FECHATO);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFPedidosYaExportados_Load(object sender, EventArgs e)
        {
            LlenarGrid();
            if (this.dSImportaciones.LISTAPEDIDOSENVIADOSFECHA.Rows.Count <= 0)
            {
                m_Confirmar = true;
                this.Close();
            }
        }

        private void BTNO_Click(object sender, EventArgs e)
        {
            m_Confirmar = false;
            this.Close();
        }

        private void BTSI_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se borraran los productos agregados manualmente y las modificaciones del pedido anterior. ¿Desea continuar?", "Eliminar detalle de venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m_Confirmar = true;
                this.Close();
            }
        }

        private void pedidosYaExportadosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (pedidosYaExportadosDataGridView.Columns[e.ColumnIndex].Name == "DG_REENVIAR")
                {
                    try
                    {
                        m_fechaPedidoExistente = (DateTime)pedidosYaExportadosDataGridView.Rows[e.RowIndex].Cells["DG_FECHA"].Value;
                        m_reenviarPedidoExistente = (int)(long)pedidosYaExportadosDataGridView.Rows[e.RowIndex].Cells["DG_DOCTOID"].Value;
                        this.m_expFileExistente = (long)pedidosYaExportadosDataGridView.Rows[e.RowIndex].Cells["DG_EXPFILEID"].Value;

                        
                            m_Confirmar = true;
                            this.Close();
                        //}
                    }
                    catch
                    {
                        m_reenviarPedidoExistente = 0;
                    }

                }
            }
        }

    }
}
