using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.Guia
{
    public partial class WFGuiasAsignarVentas : Form
    {

        public DataRow m_rtnDataRow;

        public WFGuiasAsignarVentas()
        {
            InitializeComponent();
        }

        private void LlenarGrid()
        {


            this.vENTASPORENVIAR_TableAdapter.Fill(this.dSGuia.VENTASPORENVIAR_, DTPFrom.Value, DTPTo.Value);

        }




        private void RetornarSeleccion(bool bEnterKey)
        {
            try
            {
                int iRetornoRowIndex = vENTASPORENVIAR_DataGridView.CurrentRow.Index;
                DataGridViewRow dr = vENTASPORENVIAR_DataGridView.Rows[iRetornoRowIndex];

                m_rtnDataRow = (dr.DataBoundItem as DataRowView).Row;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }

        private void vENTASPORENVIAR_DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
                RetornarSeleccion(false);
        }

        private void vENTASPORENVIAR_DataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                RetornarSeleccion(true);
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void WFGuiasAsignarVentas_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

    }
}
