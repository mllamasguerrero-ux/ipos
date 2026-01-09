using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using iPosData;
using iPosBusinessEntity;
using FirebirdSql.Data.FirebirdClient;

namespace iPos.PuntoDeVenta
{
    public partial class WFCreditoAplicacion : IposForm
    {
        CDOCTOBE m_doctoBE;
        public ArrayList m_listaPagos;
        public decimal m_montoAAplicar = 0;
        public WFCreditoAplicacion()
        {
            InitializeComponent();
        }
        public WFCreditoAplicacion(CDOCTOBE doctoBE) : this()
        {
            m_doctoBE = doctoBE;
        }

        private void LlenarGrid()
        {
            try
            {
                this.gET_CREDITO_LISTA_A_APLICARTableAdapter.Fill(this.dSPuntoDeVentaAux.GET_CREDITO_LISTA_A_APLICAR, m_doctoBE.IID);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFCreditoAplicacion_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void gET_CREDITO_LISTA_A_APLICARDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            DataGridView view = (DataGridView)sender;
            MessageBox.Show("Dato invalido , porfavor ingrese un dato valido");
            e.ThrowException = false;
        }

        private void gET_CREDITO_LISTA_A_APLICARDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            string columnName = gET_CREDITO_LISTA_A_APLICARDataGridView.Columns[e.ColumnIndex].Name;

            // Abort validation if cell is not in the CompanyName column.
            if (!columnName.Equals("DGSALDOAAPLICAR")) return;

            try
            {
                decimal dSaldoAAplicar = decimal.Parse(e.FormattedValue.ToString());
                decimal dSaldo = decimal.Parse(gET_CREDITO_LISTA_A_APLICARDataGridView.Rows[e.RowIndex].Cells["DGSALDO"].Value.ToString());
                if (dSaldoAAplicar > dSaldo || dSaldoAAplicar < 0)
                {
                    MessageBox.Show("El saldo a aplicar no puede ser mayor que el saldo de la transaccion ni menor que cero");
                    e.Cancel = true;
                }
            }
            catch
            {
            }
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            m_listaPagos = new ArrayList();
            m_montoAAplicar = 0;
            DataRow dr;
            foreach (DataGridViewRow row in gET_CREDITO_LISTA_A_APLICARDataGridView.Rows)
            {
                decimal dSaldoAAplicar = decimal.Parse(row.Cells["DGSALDOAAPLICAR"].Value.ToString());

                if (dSaldoAAplicar > 0)
                {

                    dr = (row.DataBoundItem as DataRowView).Row;
                    dr["SALDOAAPLICAR"] = dSaldoAAplicar;
                    m_listaPagos.Add(dr);
                    m_montoAAplicar += dSaldoAAplicar;
                }

            }
            this.Close();
        }
    }
}
