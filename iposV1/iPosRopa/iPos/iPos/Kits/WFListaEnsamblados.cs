using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosData;

namespace iPos
{
    public partial class WFListaEnsamblados : IposForm
    {

        public DataRow m_rtnDataRow = null;
        int iPrevRetornoRowIndex = -1;
        int iTipoDoctoId = 0;
        public WFListaEnsamblados()
        {
            InitializeComponent();
            iTipoDoctoId = (int)DBValues._DOCTO_TIPO_ENSAMBLE;
        }
        public WFListaEnsamblados(int tipoDoctoId):this()
        {
            
            iTipoDoctoId = tipoDoctoId;
        }

        private void LlenarGrid()
        {
            try
            {
                int iEstatusDoctoId = this.CBEstatus.SelectedIndex;
                this.eNSAMBLESTableAdapter.Fill(this.dSKits.ENSAMBLES, DTPFechaInicio.Value, DTPFechaFin.Value, iEstatusDoctoId, iTipoDoctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFListaEnsamblados_Load(object sender, EventArgs e)
        {
            this.CBEstatus.SelectedIndex = 0;
            LlenarGrid();
        }

        private void BTNBuscar_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }


        private void RetornarSeleccion(bool bEnterKey)
        {
            try
            {
                int iRetornoRowIndex = eNSAMBLESDataGridView.CurrentRow.Index;
                DataGridViewRow dr = eNSAMBLESDataGridView.Rows[iRetornoRowIndex];

                m_rtnDataRow = (dr.DataBoundItem as DataRowView).Row;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }

        private void eNSAMBLESDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                RetornarSeleccion(false);
            }
        }

        private void eNSAMBLESDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void eNSAMBLESDataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                int iBufferTabIndex = eNSAMBLESDataGridView.CurrentRow.Index;
                if (iBufferTabIndex == iPrevRetornoRowIndex)
                {
                    iPrevRetornoRowIndex = -1;
                    RetornarSeleccion(false);
                }
                else
                {
                    iPrevRetornoRowIndex = eNSAMBLESDataGridView.CurrentRow.Index;
                }
            }
        }
    }
}
