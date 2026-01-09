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
    public partial class WFSelRazonDiferencia : IposForm
    {


        public DataRow m_rtnDataRow;

        public WFSelRazonDiferencia()
        {
            InitializeComponent();
        }


        private void WFSelRazonDiferencia_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSImportaciones.TIPODIFERENCIAINVENTARIO' table. You can move, or remove it, as needed.
            this.tIPODIFERENCIAINVENTARIOTableAdapter.Fill(this.dSImportaciones.TIPODIFERENCIAINVENTARIO);

        }


        private void RetornarSeleccion(bool bEnterKey)
        {
            try
            {
                int iRetornoRowIndex = /*(bEnterKey && tIPODIFERENCIAINVENTARIODataGridView.CurrentRow.Index < (tIPODIFERENCIAINVENTARIODataGridView.RowCount - 1))
                                         ? tIPODIFERENCIAINVENTARIODataGridView.CurrentRow.Index - 1 :*/ tIPODIFERENCIAINVENTARIODataGridView.CurrentRow.Index;
                DataGridViewRow dr = tIPODIFERENCIAINVENTARIODataGridView.Rows[iRetornoRowIndex];

                m_rtnDataRow = (dr.DataBoundItem as DataRowView).Row;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }

        private void tIPODIFERENCIAINVENTARIODataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                RetornarSeleccion(false);
        }

        private void tIPODIFERENCIAINVENTARIODataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {

            //if (e.KeyChar == (char)13)
            //    RetornarSeleccion(true);
        }

        private void tIPODIFERENCIAINVENTARIODataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                RetornarSeleccion(true);
        }
    }
}
