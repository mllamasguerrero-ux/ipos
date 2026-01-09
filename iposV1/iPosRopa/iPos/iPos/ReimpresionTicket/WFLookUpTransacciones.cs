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
    public partial class WFLookUpTransacciones : IposForm
    {

        long m_statusDoctoId, m_cajaId, m_tipoDoctoId;
        bool m_bEsFacturaElectronica = false;

        public DataRow m_rtnDataRow;

        public WFLookUpTransacciones()
        {
            InitializeComponent();
        }




        public WFLookUpTransacciones(long statusDoctoId, long cajaId, long tipoDoctoId, bool bEsFacturaElectronica)
            : this(statusDoctoId,  cajaId, tipoDoctoId)
        {
            m_bEsFacturaElectronica = bEsFacturaElectronica;
        }

        public WFLookUpTransacciones(long statusDoctoId, long cajaId, long  tipoDoctoId):this()
        {
            InitializeComponent();
            m_statusDoctoId = statusDoctoId;
            m_cajaId = cajaId;
            m_tipoDoctoId = tipoDoctoId;
        }


        private void Filtrar()
        {
            try
            {
                DateTime dtBuffer = DateTime.MinValue;
                if (CBFecha.Checked)
                    dtBuffer = dateTimePicker1.Value;
                this.transaccionesListaTableAdapter.Fill(this.dataSet1.TransaccionesLista, (int)m_statusDoctoId, (int)m_tipoDoctoId, dtBuffer, ((m_bEsFacturaElectronica) ? "S":"N"));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void BTBuscar_Click(object sender, EventArgs e)
        {

            Filtrar();
        }


        private void RetornarSeleccion(bool bEnterKey)
        {
            try
            {
                int iRetornoRowIndex = /*(bEnterKey && transaccionesListaDataGridView.CurrentRow.Index < (transaccionesListaDataGridView.RowCount - 1)) 
                                        ? transaccionesListaDataGridView.CurrentRow.Index - 1 :*/ transaccionesListaDataGridView.CurrentRow.Index;
                DataGridViewRow dr = this.transaccionesListaDataGridView.Rows[iRetornoRowIndex];

                m_rtnDataRow = (dr.DataBoundItem as DataRowView).Row;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }

        private void transaccionesListaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
                RetornarSeleccion(false);
        }

        private void transaccionesListaDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {

            //if (e.KeyChar == (char)13)
            //    RetornarSeleccion(true);
        }

        private void WFLookUpTransacciones_Load(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void transaccionesListaDataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                RetornarSeleccion(true);
        }

    }
}
