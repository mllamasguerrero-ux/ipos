using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using System.Collections;

namespace iPos
{

    public partial class WFPreguntaLote : IposForm
    {
        public string lote;
        public DateTime fechaVence;
        CPRODUCTOBE prod;
        decimal cantidad;
        long m_doctoId;
        long? m_almacenId = null;

        public ArrayList asignaciones;


        public WFPreguntaLote()
        {
            InitializeComponent();
        }

        public WFPreguntaLote(CPRODUCTOBE cProd, decimal pCantidad, long doctoId, long? almacenId)
        {
            InitializeComponent();
            this.prod = cProd;
            cantidad = pCantidad;
            
            m_doctoId = doctoId;
            asignaciones = new ArrayList();

            m_almacenId = almacenId;
        }
        private void formSkin1_Load(object sender, EventArgs e)
        {
            try
            {
                this.gridLotesTableAdapter1.Fill(this.dSPuntoDeVentaAux.GridLotes,  prod.IID, m_doctoId, m_almacenId);
                coloreaGrid();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
       
        private void RetornarSeleccion(bool bEnterKey)
        {
            int iRetornoRowIndex = /*(bEnterKey && gridLotesDataGridView.CurrentRow.Index < (gridLotesDataGridView.RowCount - 1))
                                        ? gridLotesDataGridView.CurrentRow.Index - 1 :*/ gridLotesDataGridView.CurrentRow.Index;
            DataGridViewRow dr = gridLotesDataGridView.Rows[iRetornoRowIndex];
            if (iRetornoRowIndex != gridLotesDataGridView.NewRowIndex)
            {
                lote = dr.Cells["DG_LOTE"].Value.ToString();
                //if(dr.Cells["DG_FECHAVENCE"].Value != null)
                try
                {
                    fechaVence = (DateTime)dr.Cells["DG_FECHAVENCE"].Value;
                }
                catch
                {
                }

                this.Close();
            }
        }

        private void gridLotesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //RetornarSeleccion(false);

            string headerText = gridLotesDataGridView.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the CompanyName column.
            if (headerText.Equals("CANT. A TOMAR")) return;


            try
            {
                if (gridLotesDataGridView.Rows[e.RowIndex].Cells["ASURTIR"].Value != null)
                {
                    if (!gridLotesDataGridView.Rows[e.RowIndex].Cells["ASURTIR"].Value.ToString().Equals("")) return;
                }

                decimal dYaEnDocto = 0;
                decimal dExistencia = 0;
                decimal dRestante = getRestante();

                try
                {
                    dYaEnDocto = decimal.Parse(gridLotesDataGridView.Rows[e.RowIndex].Cells["CANTIDADENDOCTO"].Value.ToString());
                }
                catch
                {
                }


                try
                {
                    dExistencia = decimal.Parse(gridLotesDataGridView.Rows[e.RowIndex].Cells["DG_CANTIDAD"].Value.ToString());
                }
                catch
                {
                }


                if (dRestante > dExistencia - dYaEnDocto)
                {
                    if (dExistencia - dYaEnDocto > 0)
                    {
                        gridLotesDataGridView.Rows[e.RowIndex].Cells["ASURTIR"].Value = dExistencia - dYaEnDocto;
                    }
                }
                else
                {
                    gridLotesDataGridView.Rows[e.RowIndex].Cells["ASURTIR"].Value = dRestante;
                   RetornarDatos();
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void gridLotesDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {

            //if (e.KeyChar == (char)13)
            //    RetornarSeleccion(true);
        }

        private void gridLotesDataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            /*
            if (e.KeyCode == Keys.Enter)
                RetornarSeleccion(true);*/
        }



        private void coloreaGrid()
        {
            foreach (DataGridViewRow row in this.gridLotesDataGridView.Rows)
            {

                coloreaRow(row);
            }
        }

        private void coloreaRow(DataGridViewRow row)
        {

            string caducado = "N";
            string porcaducar = "N";

            try
            {
                if (row.Cells["CADUCADO"].Value != DBNull.Value)
                {
                    caducado = row.Cells["CADUCADO"].Value.ToString();
                }

                if (row.Cells["PORCADUCAR"].Value != DBNull.Value)
                {
                    porcaducar = row.Cells["PORCADUCAR"].Value.ToString();
                }


                if (caducado == "S")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (porcaducar == "S")
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else 
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }

            }
            catch
            {

                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }

        }

        private void gridLotesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            coloreaRow(gridLotesDataGridView.Rows[e.RowIndex]);
        }

        private void gridLotesDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = gridLotesDataGridView.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals("CANT. A TOMAR")) return;


            try
            {

                if (e.FormattedValue.ToString().Equals("")) return;
                decimal dSurtida = decimal.Parse(e.FormattedValue.ToString());

                decimal dYaEnDocto = 0;
                decimal dExistencia = 0;
                try
                {
                    dYaEnDocto = decimal.Parse(gridLotesDataGridView.Rows[e.RowIndex].Cells["CANTIDADENDOCTO"].Value.ToString());
                }
                catch
                {
                }


                try
                {
                    dExistencia = decimal.Parse(gridLotesDataGridView.Rows[e.RowIndex].Cells["DG_CANTIDAD"].Value.ToString());
                }
                catch
                {
                }

                if (dSurtida > dExistencia - dYaEnDocto)
                {
                    MessageBox.Show("La cantidad a surtir excede la disponible");
                    e.Cancel = true;
                }


            }
            catch
            {
                e.Cancel = true;
            }

        }

        void RetornarDatos()
        {

            decimal cantidadSumada = 0;
            asignaciones.Clear();
            CAsignacionLote buffer = null;
            foreach (DataGridViewRow row in gridLotesDataGridView.Rows)
            {
                if (row.Index == gridLotesDataGridView.NewRowIndex)
                {
                    continue;
                }

                buffer = new CAsignacionLote();

                if (row.Cells["ASURTIR"].Value == null) continue;
                if (row.Cells["ASURTIR"].Value.ToString().Equals("")) continue;
                decimal dSurtida;
                try
                {

                    dSurtida = decimal.Parse(row.Cells["ASURTIR"].Value.ToString());
                }
                catch
                {
                    continue;
                }
                cantidadSumada += dSurtida;

                buffer.cantidad = decimal.Parse(row.Cells["ASURTIR"].Value.ToString());
                buffer.lote = row.Cells["DG_LOTE"].Value.ToString();
                try
                {
                    buffer.fechaVence = (DateTime)row.Cells["DG_FECHAVENCE"].Value;
                }
                catch
                {
                }
                asignaciones.Add(buffer);
            }

            if (cantidadSumada == cantidad)
            {
                this.Close();
            }
            else
            {
                asignaciones.Clear();
                MessageBox.Show("La cantidad no concuerda con lo que se esta requiriendo");
            }
        }


        private void BTPaymentSave_Click(object sender, EventArgs e)
        {
            RetornarDatos();
        }



        private decimal getRestante()
        {
            decimal cantidadSumada = 0;
            foreach (DataGridViewRow row in gridLotesDataGridView.Rows)
            {
                if (row.Index == gridLotesDataGridView.NewRowIndex)
                {
                    continue;
                }


                if (row.Cells["ASURTIR"].Value == null) continue;
                if (row.Cells["ASURTIR"].Value.ToString().Equals("")) continue;
                decimal dSurtida;
                try
                {

                    dSurtida = decimal.Parse(row.Cells["ASURTIR"].Value.ToString());
                }
                catch
                {
                    continue;
                }
                cantidadSumada += dSurtida;
            }

            return cantidad - cantidadSumada;
        }







    }

    public class CAsignacionLote
    {
        public string lote;
        public DateTime fechaVence;
        public decimal cantidad;
    }


}
