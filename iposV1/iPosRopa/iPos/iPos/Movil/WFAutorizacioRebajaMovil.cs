using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosData;
using iPosBusinessEntity;

using FirebirdSql.Data.FirebirdClient;

namespace iPos
{
    public partial class WFAutorizacioRebajaMovil : iPos.Tools.ScreenConfigurableForm
    {
        CDOCTOBE m_doctoBE = new CDOCTOBE();
        long m_estadoRebaja = DBValues._ESTADOREBAJA_PENDIENTE;
        public WFAutorizacioRebajaMovil()
        {
            InitializeComponent();
        }
        public WFAutorizacioRebajaMovil(long estadoRebaja):this()
        {
            m_estadoRebaja = estadoRebaja;
        }

        private void LlenarGrid()
        {
            try
            {
                long clienteId = 0;
                long marcaId = 0;
                long productoId = 0;
                long vendedorFinalId = 0;
                long doctoId = 0;

                this.dSMovil5.REBAJAS_PROMOVIDAS_MOVIL.Clear();

                if (m_doctoBE == null || m_doctoBE.IID == 0)
                {
                    return;
                }


                    if (!CBTodosClientes.Checked)
                {
                    try
                    {
                        clienteId = Int64.Parse(this.CLIENTETextBox.DbValue.ToString());
                    }
                    catch
                    {
                    }
                }


                if (!CBTodosVendedores.Checked)
                {
                    try
                    {
                        vendedorFinalId = Int64.Parse(this.VENDEDORTextBox.DbValue.ToString());
                    }
                    catch
                    {
                    }
                }



                if (!CBTodosProductos.Checked)
                {
                    try
                    {
                        productoId = Int64.Parse(this.PRODUCTOTextBox.DbValue.ToString());
                    }
                    catch
                    {
                    }
                }



                
                this.rEBAJAS_PROMOVIDAS_MOVILTableAdapter.Fill(this.dSMovil5.REBAJAS_PROMOVIDAS_MOVIL, this.DTPFrom.Value, clienteId, productoId, marcaId, vendedorFinalId, m_doctoBE.IID, m_estadoRebaja);
                
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            coloreaGrid();
            
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {

            this.dSMovil5.REBAJAS_PROMOVIDAS_MOVIL.Clear();
            this.LlenarGridDocto();
        }

        private void WFAutorizacioRebajaMovil_Load(object sender, EventArgs e)
        {

            if (!ChecarCorteActivo())
                return;

            this.DTPFrom.Value = DateTime.Today.AddDays(-7);

            FormatGrid();

            // TODO: This line of code loads data into the 'dSRebajas.COMISION_COLOR_V2' table. You can move, or remove it, as needed.
            this.cOMISION_COLOR_V2TableAdapter.Fill(this.dSRebajas.COMISION_COLOR_V2);

            LlenarGridDocto();

            
        }

        private void FormatGrid()
        {
            DGALERTA3.Visible = m_estadoRebaja == DBValues._ESTADOREBAJA_PENDIENTEXPRECIOMIN;
            
            DGPRECIO.ReadOnly = m_estadoRebaja == DBValues._ESTADOREBAJA_PENDIENTEXPRECIOMIN;
            DGCDESCR.ReadOnly = m_estadoRebaja == DBValues._ESTADOREBAJA_PENDIENTEXPRECIOMIN;
            DGNPREC.ReadOnly = m_estadoRebaja == DBValues._ESTADOREBAJA_PENDIENTEXPRECIOMIN;
            DGDESCUENTOPORCENTAJE.ReadOnly = m_estadoRebaja == DBValues._ESTADOREBAJA_PENDIENTEXPRECIOMIN;
        }

        private void rEBAJAS_PROMOVIDASDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.RowIndex == rEBAJAS_PROMOVIDASDataGridView.NewRowIndex)
                return;

            if (rEBAJAS_PROMOVIDASDataGridView.Columns["DGAPROBAR"].Index != e.ColumnIndex &&
                rEBAJAS_PROMOVIDASDataGridView.Columns["DGRECHAZADA"].Index != e.ColumnIndex)
                return;

            if(rEBAJAS_PROMOVIDASDataGridView.Columns["DGAPROBAR"].Index == e.ColumnIndex )
            {
                bool bNewValue = bool.Parse(rEBAJAS_PROMOVIDASDataGridView.Rows[e.RowIndex].Cells["DGAPROBAR"].Value.ToString());
                if(bNewValue)
                {
                    rEBAJAS_PROMOVIDASDataGridView.Rows[e.RowIndex].Cells["DGRECHAZADA"].Value = false;
                    
                }

            }

            if (rEBAJAS_PROMOVIDASDataGridView.Columns["DGRECHAZADA"].Index == e.ColumnIndex)
            {
                bool bNewValue = bool.Parse(rEBAJAS_PROMOVIDASDataGridView.Rows[e.RowIndex].Cells["DGRECHAZADA"].Value.ToString());
                if (bNewValue)
                {
                    rEBAJAS_PROMOVIDASDataGridView.Rows[e.RowIndex].Cells["DGAPROBAR"].Value = false;
                }

            }
               

        }

        private void rEBAJAS_PROMOVIDASDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex != -1 || e.RowIndex == rEBAJAS_PROMOVIDASDataGridView.NewRowIndex)
                return;

            if (rEBAJAS_PROMOVIDASDataGridView.Columns["DGAPROBAR"].Index != e.ColumnIndex &&
                rEBAJAS_PROMOVIDASDataGridView.Columns["DGRECHAZADA"].Index != e.ColumnIndex)
                return;


            rEBAJAS_PROMOVIDASDataGridView.EndEdit();

        }

        private void PonerAprobarTodas()
        {

            foreach (DataGridViewRow dr in rEBAJAS_PROMOVIDASDataGridView.Rows)
            {
                dr.Cells["DGAPROBAR"].Value = true;
                dr.Cells["DGRECHAZADA"].Value = false;
            }
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {

            PonerAprobarTodas();
        }


        private void btnRechazar_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dr in rEBAJAS_PROMOVIDASDataGridView.Rows)
            {
                dr.Cells["DGAPROBAR"].Value = false;
                dr.Cells["DGRECHAZADA"].Value = true;
            }

        }


        private bool ValidarAplicacionMovimientos()
        {
            if (m_estadoRebaja == DBValues._ESTADOREBAJA_PENDIENTE)
                return true;


            CUSUARIOSD usuariosD = new CUSUARIOSD();

            bool bTieneDerechoAbajoMinimo = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_PRECIOABAJO_MINIMO, null);
            bool bTieneDerechoAbajoCosto = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_PRECIOABAJO_COSTO, null);



            foreach (DataGridViewRow dr in rEBAJAS_PROMOVIDASDataGridView.Rows)
            {
                bool aprobada = dr.Cells["DGAPROBAR"].Value != null && bool.Parse(dr.Cells["DGAPROBAR"].Value.ToString());
                if (!aprobada)
                    continue;

                string alerta3 = dr.Cells["DGALERTA3"].Value.ToString().Trim();
                if(
                    (alerta3 == "PRECIO MENOR AL COSTO" && !bTieneDerechoAbajoCosto) ||
                    (alerta3 == "PRECIO MENOR A PRECIO MINIMO" && !bTieneDerechoAbajoCosto && !bTieneDerechoAbajoMinimo)
                   )
                {
                    decimal precio = decimal.Parse(dr.Cells["DGPRECIO"].Value.ToString());
                    string producto = dr.Cells["DGPRODUCTOCLAVE"].Value.ToString();
                    MessageBox.Show("Del movimiento del producto " +  producto + " precio " + precio.ToString() + " no tiene suficientes derechos para autorizarlo");
                    return false;
                }
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Dictionary<long, List<DataGridViewRow>> mappedData = new Dictionary<long, List<DataGridViewRow>>();
            CDOCTOD doctoD = new CDOCTOD();

            if(!ValidarAplicacionMovimientos())
                return;


            if (m_doctoBE == null || m_doctoBE.IID == 0)
                return;

            m_doctoBE.IOBSERVACION = TBNota1.Text;
            m_doctoBE.IMOVILCONTADO = CBContrato.Checked ? "S" : "N";
            m_doctoBE.IMOVILPLAZOS = CBPlazos.Checked ? "S" : "N";
            doctoD.MOVIL_PEDIDO_CAMBIARNOTAS(m_doctoBE, null);

            foreach (DataGridViewRow dr in rEBAJAS_PROMOVIDASDataGridView.Rows)
            {


                bool aprobada = dr.Cells["DGAPROBAR"].Value != null && bool.Parse(dr.Cells["DGAPROBAR"].Value.ToString());
                bool rechazada = dr.Cells["DGRECHAZADA"].Value != null && bool.Parse(dr.Cells["DGRECHAZADA"].Value.ToString());
                long key = Int64.Parse(dr.Cells["DGDOCTOID"].Value.ToString());
                long movtoId = Int64.Parse(dr.Cells["DGMOVTOID"].Value.ToString());

                if (!aprobada && !rechazada)
                    continue;

                string strAprobado = aprobada ? "S" : "N";

                decimal cantidad = decimal.Parse(dr.Cells["DGCANTIDAD"].Value.ToString());
                decimal precio = decimal.Parse(dr.Cells["DGPRECIO"].Value.ToString());

                if(m_estadoRebaja == DBValues._ESTADOREBAJA_PENDIENTE)
                {

                    if (!doctoD.MOVILREBAJA_APROBACION(movtoId, cantidad, precio, strAprobado, null))
                    {

                        MessageBox.Show("Ocurrio un error al procesar la rebaja " + doctoD.IComentario);
                        return;
                    }

                }
                else if (m_estadoRebaja == DBValues._ESTADOREBAJA_PENDIENTEXPRECIOMIN)
                {

                    if (!doctoD.MOVILREBAJA_PRECMIN_APROBACION(movtoId, cantidad, precio, strAprobado, iPos.CurrentUserID.CurrentUser.IID, null))
                    {

                        MessageBox.Show("Ocurrio un error al procesar el precio minimo " + doctoD.IComentario);
                        return;
                    }
                }

            }

            

            //MessageBox.Show("Se completaron las operaciones");


            this.dSMovil5.REBAJAS_PROMOVIDAS_MOVIL.Clear();
            this.LlenarGridDocto();


        }


        private bool ChecarCorteActivo()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            DateTime fechaCorte = DateTime.MinValue;
            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
            {
                MessageBox.Show("Necesita abrir un corte");
                this.Close();
                return false;
            }
            else
            {
                TimeSpan ts = DateTime.Now - fechaCorte/*((fechaCorte == null) ? DateTime.MinValue : fechaCorte)*/;
                if (fechaCorte != null && fechaCorte < DateTime.Today && ts.Hours > 6)
                {

                    MessageBox.Show("Se tiene abierto un corte de una fecha pasada porfavor cierrelo antes de continuar");
                    this.Close();
                    return false;
                }
                else
                    return true;
            }

            //return true;

        }

        private void rEBAJAS_PROMOVIDASDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           // if (CurrentUserID.CurrentParameters.IVERSIONCOMISIONID != 2)
            //    return;

            //coloreaRow(rEBAJAS_PROMOVIDASDataGridView.Rows[e.RowIndex]);
        }


        private void coloreaGrid()
        {

            if (m_estadoRebaja == DBValues._ESTADOREBAJA_PENDIENTE &&
                CurrentUserID.CurrentParameters.IVERSIONCOMISIONID != 2)
                return;

            foreach (DataGridViewRow row in this.rEBAJAS_PROMOVIDASDataGridView.Rows)
            {
                if (m_estadoRebaja == DBValues._ESTADOREBAJA_PENDIENTEXPRECIOMIN)
                    coloreaRowPrecioMinimo(row);
                else
                    coloreaRow(row);
            }
        }
        private void coloreaRow(DataGridViewRow row)
        {
            if (CurrentUserID.CurrentParameters.IVERSIONCOMISIONID != 2)
                return;

            decimal nUtil =  (decimal)row.Cells["DGNUTIL"].Value ;
            string proveedorClave = row.Cells["DGPROVEEDORCLAVE"].Value.ToString();
            string colorBack = "BLANCO";

            try
            {


                colorBack = "BLANCO";
                var modifiedRows = this.dSRebajas.COMISION_COLOR_V2.Select("PROVEEDORCLAVE = '" + proveedorClave + "' AND MARGENMIN <= " + nUtil.ToString("####.##") + " AND (MARGENMAX >= " + nUtil.ToString("####.##") + "  or MARGENMAX < 0)");
                if (modifiedRows != null && modifiedRows.Length > 0)
                {
                    Rebajas.DSRebajas.COMISION_COLOR_V2Row dr = (Rebajas.DSRebajas.COMISION_COLOR_V2Row)modifiedRows[0];
                    colorBack = dr.COLOR;
                }
                else
                {
                    string strSelect = " PROVEEDORCLAVE = '' AND (MARGENMIN <= " + nUtil.ToString("####.##") + " AND (MARGENMAX >= " + nUtil.ToString("####.##") + "  or  MARGENMAX < 0)) or (MARGENMAX = 0 AND MARGENMIN = 0 AND " + nUtil.ToString("####.##") + " < 0)";
                    modifiedRows = this.dSRebajas.COMISION_COLOR_V2.Select(strSelect);
                    if (modifiedRows != null && modifiedRows.Length > 0)
                    {
                        Rebajas.DSRebajas.COMISION_COLOR_V2Row dr = (Rebajas.DSRebajas.COMISION_COLOR_V2Row)modifiedRows[0];
                        colorBack = dr.COLOR;
                    }
                }



                if (colorBack.Equals("ROJO"))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (colorBack.Equals("AMARILLO"))
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (colorBack.Equals("VERDE"))
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (colorBack.Equals("MAGENTA"))
                {
                    row.DefaultCellStyle.BackColor = Color.Magenta;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (colorBack.Equals("GRIS"))
                {
                    row.DefaultCellStyle.BackColor = Color.Gray;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }

            }
            catch
            {

                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }

        }


        private void coloreaRowPrecioMinimo(DataGridViewRow row)
        {


            string alerta3 = row.Cells["DGALERTA3"].Value.ToString().Trim();

            string colorBack = "BLANCO";

            try
            {
                colorBack = "BLANCO";

                if(alerta3 == "PRECIO MENOR AL COSTO")
                    colorBack = "ROJO";
                else if(alerta3 == "PRECIO MENOR A PRECIO MINIMO")
                    colorBack = "AMARILLO";


                if (colorBack.Equals("ROJO"))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (colorBack.Equals("AMARILLO"))
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }

            }
            catch
            {

                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }

        }

        private void rEBAJAS_PROMOVIDASDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
            e.ThrowException = false;
        }

        private void rEBAJAS_PROMOVIDASDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string columnName = rEBAJAS_PROMOVIDASDataGridView.Columns[e.ColumnIndex].Name;

            // Abort validation if cell is not in the CompanyName column.
            if (!columnName.Equals("DGPRECIO") && !columnName.Equals("DGCANTIDAD") && !columnName.Equals("DGDESCUENTOPORCENTAJE")) return;

            try
            {
                if(columnName.Equals("DGPRECIO"))
                {

                    decimal dPrecio = decimal.Parse(e.FormattedValue.ToString());
                    if (dPrecio <= 0)
                    {
                        MessageBox.Show("El precio no puede ser  menor que cero");
                        e.Cancel = true;
                    }
                }

                else if (columnName.Equals("DGDESCUENTOPORCENTAJE"))
                {

                    decimal dPorcentaje = decimal.Parse(e.FormattedValue.ToString());
                    if (dPorcentaje <= 0 || dPorcentaje > 100)
                    {
                        MessageBox.Show("El descuento no puede ser  menor que cero o mayor a 100");
                        e.Cancel = true;
                    }
                }
                else if (columnName.Equals("DGCANTIDAD"))
                {

                    decimal dCantidad = decimal.Parse(e.FormattedValue.ToString());
                    if (dCantidad <= 0)
                    {
                        MessageBox.Show("La cantidad no puede ser  menor que cero");
                        e.Cancel = true;
                    }
                }
            }
            catch
            {
            }
        }


        private void LlenarGridDocto()
        {
            try
            {
                long clienteId = 0;
                long marcaId = 0;
                long productoId = 0;
                long vendedorFinalId = 0;

                if (!CBTodosClientes.Checked)
                {
                    try
                    {
                        clienteId = Int64.Parse(this.CLIENTETextBox.DbValue.ToString());
                    }
                    catch
                    {
                    }
                }


                if (!CBTodosVendedores.Checked)
                {
                    try
                    {
                        vendedorFinalId = Int64.Parse(this.VENDEDORTextBox.DbValue.ToString());
                    }
                    catch
                    {
                    }
                }



                if (!CBTodosProductos.Checked)
                {
                    try
                    {
                        productoId = Int64.Parse(this.PRODUCTOTextBox.DbValue.ToString());
                    }
                    catch
                    {
                    }
                }

                this.rEBAJAS_PROMODOCTO_MOVILTableAdapter.Fill(this.dSMovil5.REBAJAS_PROMODOCTO_MOVIL, this.DTPFrom.Value, clienteId, productoId, marcaId, vendedorFinalId, m_estadoRebaja);
                

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            
        }

        private void rEBAJAS_PROMODOCTO_MOVILDataGridView_SelectionChanged(object sender, EventArgs e)
        {

            if (this.rEBAJAS_PROMODOCTO_MOVILDataGridView.SelectedRows.Count > 0)
            {
                m_doctoBE = new CDOCTOBE();
                this.dSMovil5.REBAJAS_PROMOVIDAS_MOVIL.Clear();
                long doctoId = Int64.Parse(this.rEBAJAS_PROMODOCTO_MOVILDataGridView.SelectedRows[0].Cells["DGID"].Value.ToString());
                actualizarDetalleRebaja(doctoId);
            }
            
        }


        private void actualizarDetalleRebaja(long doctoId)
        {
            TBNota1.Text = "";
            CBContrato.Checked = false;
            CBPlazos.Checked = false;

            m_doctoBE = new CDOCTOBE();
            m_doctoBE.IID = doctoId;

            this.dSMovil5.REBAJAS_PROMOVIDAS_MOVIL.Clear();


            CDOCTOD doctoD = new CDOCTOD();
            m_doctoBE = doctoD.seleccionarDOCTO(m_doctoBE, null);
            if (m_doctoBE == null || m_doctoBE.IID == 0)
            {
                m_doctoBE = new CDOCTOBE();
                return;
            }


            TBNota1.Text = m_doctoBE.IOBSERVACION;
            CBContrato.Checked = m_doctoBE.IMOVILCONTADO != null && m_doctoBE.IMOVILCONTADO.Equals("S");
            CBPlazos.Checked = m_doctoBE.IMOVILPLAZOS != null && m_doctoBE.IMOVILPLAZOS.Equals("S");


            LlenarGrid();
            PonerAprobarTodas(); 
        }
        

        private void rEBAJAS_PROMODOCTO_MOVILDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex < 0)
                    return;


                m_doctoBE = new CDOCTOBE();
                this.dSMovil5.REBAJAS_PROMOVIDAS_MOVIL.Clear();

                long doctoId = long.Parse(rEBAJAS_PROMODOCTO_MOVILDataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());

                actualizarDetalleRebaja(doctoId);
            }
            catch(Exception ex)
            {
            }
        }

        private void rEBAJAS_PROMOVIDASDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

            string columnName = rEBAJAS_PROMOVIDASDataGridView.Columns[e.ColumnIndex].Name;

            // Abort validation if cell is not in the CompanyName column.
            if ( !columnName.Equals("DGDESCUENTOPORCENTAJE")) return;

            try
            {

                if (columnName.Equals("DGDESCUENTOPORCENTAJE"))
                {

                    decimal dPorcentaje = decimal.Parse(rEBAJAS_PROMOVIDASDataGridView.Rows[e.RowIndex].Cells["DGDESCUENTOPORCENTAJE"].Value.ToString());
                    decimal dPrecio1 = decimal.Parse(rEBAJAS_PROMOVIDASDataGridView.Rows[e.RowIndex].Cells["DGPRECIO1"].Value.ToString());
                    decimal dPrecioNuevo = Math.Round(dPrecio1 * (1 - (dPorcentaje / 100.00m)), 2);
                    rEBAJAS_PROMOVIDASDataGridView.Rows[e.RowIndex].Cells["DGPRECIO"].Value = dPrecioNuevo;
                }
            }
            catch
            {
            }
        }
    }
}
