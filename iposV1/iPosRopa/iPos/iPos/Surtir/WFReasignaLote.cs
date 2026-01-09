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
using System.Globalization;

namespace iPos
{

    public partial class WFReasignaLote : IposForm
    {
        public string lote;
        public DateTime fechaVence;
        CPRODUCTOBE prod;
        decimal cantidad;
        long m_doctoId;
        decimal m_precio;
        long m_almacenid = 1;

        public ArrayList asignaciones;

        public bool m_esReasignacion = true;



        public WFReasignaLote()
        {
            InitializeComponent();
        }

        public WFReasignaLote(CPRODUCTOBE cProd, decimal pCantidad, long doctoId,  decimal precio, long almacenid)
        {
            InitializeComponent();
            this.prod = cProd;
            cantidad = pCantidad;
            
            m_doctoId = doctoId;
            m_precio = precio;
            m_almacenid = almacenid;
            asignaciones = new ArrayList();
        }
        private void formSkin1_Load(object sender, EventArgs e)
        {
            try
            {

                this.gridLotesTableAdapter1.Fill(this.dSPuntoDeVentaAux.GridLotes,  prod.IID, m_doctoId, m_precio, m_almacenid);

               LlenarComboLotesSalida(0, prod.IID);

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
                /*if (gridLotesDataGridView.Rows[e.RowIndex].Cells["ASURTIR"].Value != null)
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
                }*/


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

                /*if (dSurtida > dExistencia - dYaEnDocto)
                {
                    MessageBox.Show("La cantidad a surtir excede la disponible");
                    e.Cancel = true;
                }*/


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
            CReAsignacionLote buffer = null;
            foreach (DataGridViewRow row in gridLotesDataGridView.Rows)
            {
                if (row.Index == gridLotesDataGridView.NewRowIndex)
                {
                    continue;
                }

                buffer = new CReAsignacionLote();

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
                buffer.cantidadAnterior = decimal.Parse(row.Cells["CANTIDADENDOCTO"].Value.ToString());
                buffer.maxSurtible = decimal.Parse(row.Cells["DGCANTSURTIBLE"].Value.ToString());

                if (buffer.cantidad == 0 && buffer.cantidadAnterior == 0)
                    continue;

                buffer.lote = row.Cells["DG_LOTE"].Value.ToString();
                try
                {
                    buffer.fechaVence = (DateTime)row.Cells["DG_FECHAVENCE"].Value;
                }
                catch
                {
                }

                buffer.surtible = row.Cells["DGSURTIBLE"].Value.ToString();


                if (RBReasignacion.Checked)
                {
                    try
                    {
                        decimal dExistencia = decimal.Parse(row.Cells["DG_CANTIDAD"].Value.ToString());
                        if (dExistencia < dSurtida)
                        {

                            asignaciones.Clear();
                            MessageBox.Show("En el caso de reasignaciones no puede tomar mas de la cantidad existente en el sistema");
                            return;
                        }
                    }
                    catch
                    {
                    }
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

        private void BTIntercambioLotes_Click(object sender, EventArgs e)
        {
            WFIntercambioLotes wf = new WFIntercambioLotes();
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

        private void pnlLotes_Enter(object sender, EventArgs e)
        {

        }


        private void LlenarComboLotesSalida(long doctoId, long productoId)
        {
            try
            {
                this.r_LISTALOTESINVENTARIOTableAdapter.Fill(this.dSInventarioFisico2.R_LISTALOTESINVENTARIO, doctoId, productoId, "N");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnAgregarAListaDeLotes_Click(object sender, EventArgs e)
        {

            string  loteDestino = null;
            DateTime  fechaVenceDestino = DateTime.Today;

            if (RBSeleccionLote.Checked)
            {
                if (comboLoteDestino.SelectedIndex >= 0)
                {
                    string[] aux = comboLoteDestino.Text.Split('|');
                    if (aux.Count() == 2)
                    {
                        loteDestino = aux[0].Trim();
                        DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                        dtfi.ShortDatePattern = "dd/MM/yyyy";
                        dtfi.DateSeparator = "-";
                        fechaVenceDestino = Convert.ToDateTime(aux[1], dtfi);
                    }
                    else
                    {

                        MessageBox.Show("No se ha pudo identificar a que lote pertenece este producto");
                        return;
                    }

                }
            }
            else if (RBManualLote.Checked)
            {
                if (TBLote.Text.Trim().Length == 0)
                {
                    MessageBox.Show("No se ha seleccionado un lote valido");
                    return;
                }

                loteDestino = TBLote.Text;
                fechaVenceDestino = DTPFechaVence.Value;
            }
            else
            {
                MessageBox.Show("No se ha seleccionado un lote valido");
                return;
            }


            foreach(Inventario.DSInventarioFisico3.GridLotesRow item in this.dSPuntoDeVentaAux.GridLotes.Rows)
            {
                if(item.LOTE != null && item.LOTE.Equals(loteDestino) &&
                    item.FECHAVENCE != null && item.FECHAVENCE.Equals(fechaVenceDestino))
                {
                    MessageBox.Show("Ya hay un lote-fecha venc. asi en el grid");
                    return;
                }
            }


            Inventario.DSInventarioFisico3.GridLotesRow row = this.dSPuntoDeVentaAux.GridLotes.NewGridLotesRow();
            row.FECHAVENCE = fechaVenceDestino;
            row.LOTE = loteDestino;
            row.CANTIDADENDOCTO = 0;
            row.CANTIDAD = 0;
            row.CADUCADO = "N";
            row.PORCADUCAR = "N";
            row.SURTIBLE = "S";
            row.CANTSURTIBLE = 0;
            this.dSPuntoDeVentaAux.GridLotes.AddGridLotesRow(row);


        }

        private void formateaPorTipoDeProceso()
        {
            m_esReasignacion = RBReasignacion.Checked;
            pnlLotes.Visible = !RBReasignacion.Checked; 
        }

        private void RBReasignacion_CheckedChanged(object sender, EventArgs e)
        {
            formateaPorTipoDeProceso();
        }

        private void RBIntercambio_CheckedChanged(object sender, EventArgs e)
        {
            formateaPorTipoDeProceso();
        }






    }

    public class CReAsignacionLote
    {
        public string lote;
        public DateTime fechaVence;
        public decimal cantidad;
        public decimal cantidadAnterior;
        public string surtible;
        public decimal maxSurtible;
    }
}
