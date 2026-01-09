using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.PuntoDeVenta
{
    public partial class CortesAbiertos : IposForm
    {
        public DataRow m_rtnDataRow;
        public CortesAbiertos()
        {
            InitializeComponent();
        }

        private void LlenarGrid()
        {
            try
            {
                
                this.cortesAbiertosTableAdapter.Fill(this.dataSet1.CortesAbiertos, this.DTFecha.Value, this.CBTodos.Checked?"1":"0");

                TableDataGridView.Focus();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void CBTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (CBTodos.Checked)
                this.DTFecha.Enabled = false;
            else
                this.DTFecha.Enabled = true;

            LlenarGrid();
        }

        private void TableDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }


        private void RetornarSeleccion(bool bEnterKey)
        {
            try
            {
                int iRetornoRowIndex =  TableDataGridView.CurrentRow.Index;
                DataGridViewRow dr = TableDataGridView.Rows[iRetornoRowIndex];

                m_rtnDataRow = (dr.DataBoundItem as DataRowView).Row;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }

        private void TableDataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                RetornarSeleccion(true);
        }

        private void DTFecha_ValueChanged(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void CortesAbiertos_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void TableDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TableDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                RetornarSeleccion(false);
            }
        }

    }
}
