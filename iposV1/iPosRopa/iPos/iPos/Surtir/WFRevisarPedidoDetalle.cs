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
using FirebirdSql.Data.FirebirdClient;
using System.Collections;
using DataLayer.Importaciones;
using ConexionesBD;
using Microsoft.ApplicationBlocks.Data;
using iPosReporting;
using Newtonsoft.Json;
using iPos.Surtir;

namespace iPos
{
    public partial class WFRevisarPedidoDetalle : IposForm
    {
        //string m_fileName;
        //DateTime m_fecha;
        //TimeSpan m_time;
        long m_doctoId;
        long m_almacenId = 0;
        int m_folio = 0;
        string m_nombrecliente = "";
        DateTime m_fecha = DateTime.MinValue;

        decimal dMaxCantidad = 1000;

        public bool m_bCancelar;

        public bool m_procesoCompleto = false;


        CDOCTOBE m_doctoBE = null;

        private bool m_bRecienAbierto = true;



        private string iComentario;
        public string IComentario
        {
            get
            {
                return this.iComentario;
            }
            set
            {
                this.iComentario = value;
            }
        }

        public WFRevisarPedidoDetalle()
        {
            InitializeComponent();
        }
        public WFRevisarPedidoDetalle(long doctoId, int folio, string nombreCliente, DateTime fecha, long almacenid)
        {
            InitializeComponent();
            m_doctoId = doctoId;
            m_bCancelar = true;
            m_folio = folio;
            m_nombrecliente = nombreCliente;
            m_fecha = fecha;
            m_almacenId = almacenid;
        }
        private void WFRevisarPedidoDetalle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSImportaciones.IMP_RECIBIDOS' table. You can move, or remove it, as needed.



            lblFolio.Text = m_folio.ToString();
            lblCliente.Text = m_nombrecliente;
            lblFecha.Text = m_fecha.ToString("dd/MM/yyyy");

            LlenarDoctoBE(m_doctoId);
            try
            {
                this.rEVISADO_POR_LOTE_VIEWTableAdapter.Fill(this.dSSurtido.REVISADO_POR_LOTE_VIEW, (int)m_doctoId);


            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            //this.reportViewer1.RefreshReport();


            TBCodigo.Focus();
        }


        private void LlenarDoctoBE(long m_doctoId)
        {
            m_doctoBE = new CDOCTOBE();
            m_doctoBE.IID = m_doctoId;

            CDOCTOD doctoD = new CDOCTOD();
            m_doctoBE = doctoD.seleccionarDOCTO(m_doctoBE, null);
        }


        private void BTRECIBIR_Click(object sender, EventArgs e)
        {

            CMOVTOD objRecD = new CMOVTOD();
            CMOVTOBE objRecBE = new CMOVTOBE();

            CDOCTOD objDoctoD = new CDOCTOD();
            CDOCTOBE objDoctoBE = new CDOCTOBE();

            bool hayDetallesConMenos = false;
            bool hayDetallesConMas = false;
            List<CINCIDENCIABE> incidenciasMenos = new List<CINCIDENCIABE>();

            validarRevision(ref hayDetallesConMenos, ref hayDetallesConMas, ref incidenciasMenos);

            if(hayDetallesConMas)
            {
                MessageBox.Show("No puede registrar productos de mas");
                return;
            }


            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;


            ArrayList resultadosExportacion = new ArrayList();

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
                {

                    if (row.Index == iMP_REC_DETDataGridView.NewRowIndex)
                    {
                        continue;
                    }
                    objRecBE = new CMOVTOBE();
                    objRecBE.IID = long.Parse(row.Cells["GC_MOVTOID"].Value.ToString());
                    objRecBE.ICANTIDAD = Decimal.Parse(row.Cells["GC_CANTIDAD"].Value.ToString());
                    objRecBE.ICANTIDADREVISADA = Decimal.Parse(row.Cells["GC_APEDIR"].Value.ToString());



                    //if (objRecBE.ICANTIDAD != 0)
                    //{
                    if (objRecD.REVISARMOVTOD(objRecBE, fTrans) == false)
                    {
                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show(objRecD.IComentario);
                        return;
                    }
                    // }
                }


                objDoctoBE.IID = this.m_doctoId;



                objDoctoBE.IID = this.m_doctoId;
                objDoctoBE.IESTADOREVISADOID = DBValues._DOCTO_REVISIONFINAL_REVISADO;

                if (objDoctoD.CambiarESTADOREVISADOID(objDoctoBE, fTrans) == false)
                {

                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show(objRecD.IComentario);
                    return;
                }

                
                
                fTrans.Commit();
                fConn.Close();

                m_procesoCompleto = true;

                objDoctoBE = objDoctoD.seleccionarDOCTO(objDoctoBE, null);


                if (hayDetallesConMenos)
                {

                    //incidencia cantidad menos
                    foreach (CINCIDENCIABE incidencia in incidenciasMenos)
                    {
                        AgregarIncidencia(DBValues._TIPOINCIDENCIA_MENOR_CANTIDAD, incidencia.IMOVTOID, incidencia.IPRODUCTOID, "", "", incidencia.ICANTIDAD1, incidencia.ICANTIDAD2, false, false);

                    }
                }

                ImprimirTicketRevision(this.m_doctoId);

                m_bCancelar = false;


                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                try
                {
                    fTrans.Rollback();
                }
                catch
                {
                }
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fConn.Close();
            }


        }


        private void validarRevision(ref bool hayDetallesConMenos, ref bool hayDetallesConMas, ref List<CINCIDENCIABE> incidenciasMenos)
        {
            hayDetallesConMenos = false;
            hayDetallesConMas = false;

            foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
            {

                decimal cantidad = Decimal.Parse(row.Cells["GC_CANTIDAD"].Value.ToString());
                decimal cantidadRevisada = Decimal.Parse(row.Cells["GC_APEDIR"].Value.ToString());
                long movtoId = long.Parse(row.Cells["GC_MOVTOID"].Value.ToString());
                long productoId = long.Parse(row.Cells["DGPRODUCTOID"].Value.ToString());

                if (cantidad > cantidadRevisada)
                {
                    hayDetallesConMenos = true;

                    CINCIDENCIABE item = new CINCIDENCIABE();
                    item.IMOVTOID = movtoId;
                    item.IPRODUCTOID = productoId;
                    item.ICANTIDAD1 = cantidad;
                    item.ICANTIDAD2 = cantidadRevisada;
                    incidenciasMenos.Add(item);


                }
                else if(cantidad < cantidadRevisada)
                {
                    hayDetallesConMas = true;
                }
            }
        }


        private void iMP_REC_DETDataGridView_RowsAdded_1(object sender, DataGridViewRowsAddedEventArgs e)
        {

            //foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
            //{
            //    if(row.Cells["GC_CANTIDAD"].Value != null)
            //        row.Cells["GC_APEDIR"].Value = row.Cells["GC_CANTIDAD"].Value;
            //}
        }

        private void iMP_REC_DETDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            //MessageBox.Show("Dato invalido , porfavor ingrese un dato valido");
            e.ThrowException = false;


        }

        private void iMP_REC_DETDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = iMP_REC_DETDataGridView.Columns[e.ColumnIndex].Name;

            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals("GC_APEDIR")) return;

            try
            {
                decimal dSurtida = decimal.Parse(e.FormattedValue.ToString());
                decimal dCantidad = decimal.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_CANTIDAD"].Value.ToString());

                decimal dCantidadSurtidaAnterior = decimal.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_APEDIR"].Value.ToString());



                if (dSurtida == dCantidadSurtidaAnterior)
                    return;

                if (/*dSurtida > dCantidad ||*/ dSurtida < 0)
                {
                    MessageBox.Show("La cantidad surtida no puede ser  menor que cero");
                    e.Cancel = true;
                }
                else if (dSurtida != dCantidad
                         && (iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_APEDIR"].Value == null || iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_APEDIR"].Value.ToString() == ""))
                {


                    iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_APEDIR"].Value = null;
                    iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_CANTIDADFALTANTE"].Value = "";
                    //iMP_REC_DETDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);


                }
                else if (dSurtida == dCantidad)
                {

                    //iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_APEDIR"].Value = null;
                    //iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_CANTIDADFALTANTE"].Value = "";
                }

                //incidencia cambio directo
                long movtoId = long.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_MOVTOID"].Value.ToString());
                long productoId = long.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGPRODUCTOID"].Value.ToString());
                AgregarIncidencia(DBValues._TIPOINCIDENCIA_CAMBIO_DIRECTO, movtoId, productoId, "", "", dCantidadSurtidaAnterior, dSurtida, true, true);

            }
            catch
            {
            }

        }






        private void TBCodigo_Validating(object sender, CancelEventArgs e)
        {
            //if (TBCodigo.Text.Trim() == "")
            //    return;

            //CPRODUCTOBE prod = new CPRODUCTOBE();
            //if (!BuscarProducto(ref prod))
            //{
            //    this.LBProductoDescripcion.Text = "";
            //    SeleccionarProducto(TBCodigo.Text.Trim());
            //    return;
            //}
            //this.LBProductoDescripcion.Text = prod.IDESCRIPCION;

        }


        private void TBCodigo_Validated(object sender, EventArgs e)
        {

        }



        //private bool BuscarProducto(ref CPRODUCTOBE prod)
        //{
        //    CComprasD pvd = new CComprasD();
        //    prod = pvd.buscarPRODUCTOSPV(TBCodigo.Text.Trim(), CurrentUserID.CurrentParameters, null);
        //    if (prod != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}



        private void SeleccionarProducto(string strDescripcion)
        {

            LOOKPROD look;
            if (strDescripcion == "")
                look = new LOOKPROD("", false, TipoProductoNivel.tp_hijos);
            else
                look = new LOOKPROD(strDescripcion, false, TipoProductoNivel.tp_hijos);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                this.TBCodigo.Text = dr["CLAVE"].ToString().Trim();
                TBCodigo.Focus();
                TBCodigo.Select(TBCodigo.Text.Length, 0);
            }
        }

        private void TBCodigo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (TBCodigo.Text.Trim() == "")
                {
                    SeleccionarProducto(TBCodigo.Text.Trim());
                    return;
                }



                bool bTienePrefijoBascula = false;
                CPRODUCTOBE prod = new CPRODUCTOBE();
                decimal cantidad = 1;
                bool bPreguntaCantidad = false;
                CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                bool esEmpaque = false;
                bool esCaja = false;

                DecifrarComando(TBCodigo.Text, ref prod, ref cantidad, ref bPreguntaCantidad, ref pvd, ref esEmpaque, ref esCaja, true, ref bTienePrefijoBascula);

                if (prod == null)
                {
                    SeleccionarProducto(TBCodigo.Text.Trim());
                    return ;
                }

                LBProductoDescripcion.Text = prod.IDESCRIPCION;




                this.BTAgregar.Focus();
                //TBCantidad.Select(0, TBCantidad.Text.Length);
            }
        }



        public ArrayList SplitCommandLine(string commandLine, ArrayList splitChars)
        {
            ArrayList commandElemts = new ArrayList();
            PVCommandElement elemInicial = new PVCommandElement();
            elemInicial.commandText = commandLine;
            elemInicial.commandOper = ' ';
            commandElemts.Add(elemInicial);
            foreach (Object objSep in splitChars)
            {
                char[] cSep = new char[1];
                cSep[0] = (char)objSep;
                ArrayList BufferArr = new ArrayList();
                foreach (Object objComm in commandElemts)
                {
                    PVCommandElement pvComm = (PVCommandElement)objComm;

                    string[] splittedComm = pvComm.commandText.Split(cSep, StringSplitOptions.RemoveEmptyEntries);
                    int numSplittedStr = splittedComm.Count();
                    for (int iSplitIndex = 0; iSplitIndex < numSplittedStr; iSplitIndex++)
                    {
                        PVCommandElement bufferElem = new PVCommandElement();
                        bufferElem.commandText = splittedComm[iSplitIndex];
                        if (iSplitIndex == 0 && numSplittedStr > 1)
                        {
                            bufferElem.commandOper = cSep[0]/*pvComm.commandOper*/;
                        }
                        else
                        {
                            bufferElem.commandOper = pvComm.commandOper/*cSep[0]*/;
                        }
                        BufferArr.Add(bufferElem);
                    }
                }
                commandElemts.Clear();
                commandElemts = (ArrayList)BufferArr.Clone();
            }
            return commandElemts;
        }

        private void DecifrarComando(string texto, ref CPRODUCTOBE prod, ref Decimal cantidad, ref bool bPreguntaCantidad, ref CPuntoDeVentaD pvd, ref bool esEmpaque, ref bool esCaja, bool sustituirProdPromCaducado, ref bool tienePrefijoBascula)
        {

            bool bLastAssigned = false; // ultima busqueda

            string bufferBusquedaText = texto;
            if (bufferBusquedaText.Contains(" <(("))
            {
                string[] strSeparators = new string[] { " <((" };


                string[] strBuffert = bufferBusquedaText.Split(strSeparators, StringSplitOptions.RemoveEmptyEntries);
                if (strBuffert.Count() > 1)
                {

                    //ultima busqueda
                    bLastAssigned = true;
                    //this.strLastProductoSearch = strBuffert[0];


                    bufferBusquedaText = strBuffert[strBuffert.Count() - 1];


                    string[] strSeparatorsBeta = new string[] { "))>" };

                    string[] strBufferz = bufferBusquedaText.Split(strSeparatorsBeta, StringSplitOptions.RemoveEmptyEntries);
                    if (strBufferz.Count() > 0)
                        bufferBusquedaText = strBufferz[0];

                    if (bufferBusquedaText.Trim().Length > 0)
                        texto = bufferBusquedaText.Trim();
                }

            }

            ArrayList splitChars = new ArrayList();
            splitChars.Add('*');
            splitChars.Add('%');
            string commandLine = texto;
            ArrayList commandElemts = SplitCommandLine(commandLine, splitChars);
            int prodIndex = -1, cantIndex = -1, /*descIndex = -1,*/ contIndex;

            decimal cantidadAux = 1;


            contIndex = 0;
            foreach (Object objComm in commandElemts)
            {
                contIndex++;
                PVCommandElement pvComm = (PVCommandElement)objComm;
                if (/*pvComm.commandOper == '*' ||*/ pvComm.commandOper == ' ')
                {
                    prod = pvd.buscarPRODUCTOSPV(pvComm.commandText, ref cantidadAux, ref bPreguntaCantidad, CurrentUserID.CurrentParameters, ref esEmpaque, ref esCaja, ref tienePrefijoBascula, null);
                    if (prod != null)
                    {
                        //ultima busqueda
                        if (!bLastAssigned)
                        {
                            bLastAssigned = true;
                            //this.strLastProductoSearch = pvComm.commandText;
                        }


                        prodIndex = contIndex;
                        break;
                    }
                }

            }

            contIndex = 0;
            foreach (Object objComm in commandElemts)
            {
                contIndex++;
                if (contIndex == prodIndex)
                {
                    continue;
                }
                PVCommandElement pvComm = (PVCommandElement)objComm;
                if (pvComm.commandOper == '*' || pvComm.commandOper == ' ')
                {
                    Decimal buffCant;
                    if (Decimal.TryParse(pvComm.commandText, out buffCant))
                    {
                        cantidad = buffCant;
                        cantIndex = contIndex;
                        break;
                    }
                }

            }


            if (sustituirProdPromCaducado && prod != null &&
                (prod.IEXISTENCIA <= 0) &&
                CurrentUserID.CurrentParameters.IMANEJAPRODUCTOSPROMOCION != null && CurrentUserID.CurrentParameters.IMANEJAPRODUCTOSPROMOCION.Equals("S") &&
                prod.IBASEPRODPROMOID > 0)
            {
                CPRODUCTOD prodD = new CPRODUCTOD();
                CPRODUCTOBE prodBE = new CPRODUCTOBE();
                prodBE.IID = prod.IBASEPRODPROMOID;
                prodBE = prodD.seleccionarPRODUCTO(prodBE, null);

                if (prodBE != null)
                {
                    prod = prodBE;
                }
            }

            cantidad = cantidad * ((cantidadAux == 0) ? 1 : cantidadAux);
        }


        private void TBCantidad_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    this.BTAgregar.Focus();
            //}
        }


        private void ProcessAdd()
        {
            
            long? P_IDPRODUCTO = null;
            string P_VD_VENDEDOR = CurrentUserID.CurrentUser.INOMBRE;
            long? P_USERID = iPos.CurrentUserID.CurrentUser.IID;
            long? SUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            DateTime P_FECHAVENCE = DateTime.MinValue;
            decimal? P_CANTIDAD_PEDIDA = null;




            if (TBCodigo.Text.Trim() == "")
            {
                MessageBox.Show("El texto de este control no debe estar vacio");
                return;
            }
            




            bool bTienePrefijoBascula = false;
            CPRODUCTOBE prod = new CPRODUCTOBE();
            decimal cantidad = 1;
            bool bPreguntaCantidad = false;
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            bool esEmpaque = false;
            bool esCaja = false;

            DecifrarComando(TBCodigo.Text, ref prod, ref cantidad, ref bPreguntaCantidad, ref pvd, ref esEmpaque, ref esCaja, true, ref bTienePrefijoBascula);


            if (prod.IESPRODUCTOPADRE == "S")
            {
                MessageBox.Show("No puede seleccionar un producto padre");
                return;
            }

            P_IDPRODUCTO = prod.IID;
            P_CANTIDAD_PEDIDA = cantidad;

            //try
            //{
            //    P_CANTIDAD_PEDIDA = decimal.Parse(TBCantidad.Text.Trim());

            //}
            //catch
            //{
            //    MessageBox.Show("La cantidad no tiene el formato adecuado");
            //    return;
            //}


            if (P_CANTIDAD_PEDIDA > dMaxCantidad)
            {

                if (MessageBox.Show("La cantidad parece ser muy grande , seguro que desea continuar con esa cantidad ", "Cantidad muy grande", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
            }

            if (P_CANTIDAD_PEDIDA <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero ", "Cantidad menor o igual a cero", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }









            Surtir.DSSurtido.REVISADO_POR_LOTE_VIEWRow rowEdicion = null;

            // aqui se decidira si agregar a un registro ya existente o no
            bool bExisteProductoEnDocumento = false;
            foreach (Surtir.DSSurtido.REVISADO_POR_LOTE_VIEWRow dr in this.dSSurtido.REVISADO_POR_LOTE_VIEW)
            {
                if (dr.PRODUCTOID == prod.IID)
                {
                    bExisteProductoEnDocumento = true;
                    rowEdicion = dr;

                    if (dr.CANTIDAD >= dr.CANTIDADREVISADA + P_CANTIDAD_PEDIDA)
                    {
                        dr.CANTIDADREVISADA += P_CANTIDAD_PEDIDA.Value;
                        P_CANTIDAD_PEDIDA = 0;


                    }
                    else
                    {
                        decimal cambio = dr.CANTIDAD - dr.CANTIDADREVISADA;
                        dr.CANTIDADREVISADA += cambio;
                        P_CANTIDAD_PEDIDA -= cambio; 
                    }
                }
            }
            if (bExisteProductoEnDocumento)
            {
                if(P_CANTIDAD_PEDIDA.Value > 0 && rowEdicion != null)
                {
                    
                    

                    rowEdicion.CANTIDADREVISADA += P_CANTIDAD_PEDIDA.Value;

                    //incidencia cantidad mayor
                    // CANTIDAD - CANTIDADREVISADA
                   AgregarIncidencia(DBValues._TIPOINCIDENCIA_MAYOR_CANTIDAD, 0, prod.IID, "", "", rowEdicion.CANTIDAD, rowEdicion.CANTIDADREVISADA, false, false);

                }
                coloreaGrid();
                PrepararSiguienteEntrada();
            }
            else
            {
                MessageBox.Show("el producto no esta en la venta");
            }


        }


                
       


        


        private void PrepararSiguienteEntrada()
        {
            //this.TBCantidad.Text = "";
            this.TBCodigo.Text = "";
            //this.TBLocalidad.Text = "";
            this.TBCodigo.Focus();
            
        }

        private void BTAgregar_Click(object sender, EventArgs e)
        {
            ProcessAdd();
        }




        private void coloreaGrid()
        {
            foreach (DataGridViewRow row in this.iMP_REC_DETDataGridView.Rows)
            {
                coloreaRow(row);
            }
        }


        private void coloreaRow(DataGridViewRow row)
        {

            decimal cantidad = 0, cantidadPedido = 0;

            try
            {


                if (row.Cells["GC_APEDIR"].Value != DBNull.Value)
                {
                    cantidadPedido = decimal.Parse(row.Cells["GC_APEDIR"].Value.ToString());
                }


                if (row.Cells["GC_CANTIDAD"].Value != DBNull.Value)
                {
                    cantidad = decimal.Parse(row.Cells["GC_CANTIDAD"].Value.ToString());
                }

                if (cantidadPedido > cantidad)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if(cantidad == cantidadPedido)
                {

                    row.DefaultCellStyle.BackColor = Color.Green;
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
            row.Cells["GC_APEDIR"].Style.BackColor = Color.GreenYellow;
            row.Cells["GC_APEDIR"].Style.ForeColor = Color.Black;

        }

        private void iMP_REC_DETDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (iMP_REC_DETDataGridView.Columns[e.ColumnIndex].Name == "GC_PRODUCTO" && e.Value != null && e.Value != DBNull.Value)
            {
                coloreaRow(iMP_REC_DETDataGridView.Rows[e.RowIndex]);
            }
        }

        private void iMP_REC_DETDataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && iMP_REC_DETDataGridView["GC_PRODUCTO", e.RowIndex].Value != null && iMP_REC_DETDataGridView["GC_PRODUCTO", e.RowIndex].Value != DBNull.Value)
            {
                coloreaRow(iMP_REC_DETDataGridView.Rows[e.RowIndex]);
            }
        }
        
        
        
        


        
        private void iMP_REC_DETDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void WFRevisarPedidoDetalle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(m_procesoCompleto)
            {
                //preguntar si 

                if (MessageBox.Show("Completo el proceso... Desea guardar alguna nota adicional de incidencias? ", "Incidencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //incidencia nota
                    AgregarIncidencia(DBValues._TIPOINCIDENCIA_NOTA_REVISION, 0, 0, "", "", 0, 0, true, true);

                }
            }
            else
            {
                //incidencia cancelacion
                AgregarIncidencia(DBValues._TIPOINCIDENCIA_CANCELACION_REVISION, 0, 0, "", "", 0, 0, true, true);

            }




        }



        private void AgregarIncidencia(long tipoIncidenciaId, long movtoId, long productoId, string nota1, string nota2, decimal cantidad1, decimal cantidad2, bool preguntarNota, bool forzarNota )
        {
            string strNota = nota1;

            if (preguntarNota)
            {
                WFNotaIncidencia look = new WFNotaIncidencia(forzarNota, "Nota de incidencia");
                look.ShowDialog();

                strNota = look.strNotaIncidencia;

                look.Dispose();
                GC.SuppressFinalize(look);
            }


            CINCIDENCIAD incidenciaD = new CINCIDENCIAD();
            CINCIDENCIABE incidenciaBE = new CINCIDENCIABE();
            incidenciaBE.ITIPOINCIDENCIAID = tipoIncidenciaId;
            incidenciaBE.IFECHAHORA = DateTime.Now;
            incidenciaBE.IVENDEDORID = CurrentUserID.CurrentUser.IID;
            incidenciaBE.IDOCTOID = this.m_doctoId;
            incidenciaBE.IMOVTOID = movtoId;
            incidenciaBE.IPRODUCTOID = productoId;
            incidenciaBE.INOTA1 = strNota;
            incidenciaBE.INOTA2 = nota2;
            incidenciaBE.ICANTIDAD1 = cantidad1;
            incidenciaBE.ICANTIDAD2 = cantidad2;

            incidenciaD.AgregarINCIDENCIAD(incidenciaBE, null);

        }






        public static bool ImprimirTicketRevision(long doctoId)
        {
            try
            {


                Ticket ticket = new Ticket();
                ticket.OpenDrawer(ConexionesBD.ConexionBD.currentPrinter);//"IposPrinter3");

                FastReport.Report report = new FastReport.Report();
                report.Load(FastReportsConfig.getPathForFile(@"TicketRevisados.frx", FastReportsTipoFile.desistema));;
                FastReport.Utils.Config.ReportSettings.ShowProgress = false;

                report.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
                report.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
                report.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);


                report.SetParameterValue("pdoctoid", doctoId);

                //Aqui llenas todos los parametros
                report.PrintSettings.ShowDialog = false;
                report.Prepare();



                report.PrintSettings.Printer = ConexionesBD.ConexionBD.currentPrinter;

                try
                {

                    report.Print();
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Error al procesar el ticket " + ex.Message + ex.StackTrace);
                   
                    return false;
                }
            }
            catch (Exception ex2)
            {
                
                MessageBox.Show("Error al procesar el ticket " + ex2.Message + ex2.StackTrace);
                return false;
            }

            return true;
        }

        private void WFRevisarPedidoDetalle_Shown(object sender, EventArgs e)
        {
            if(m_bRecienAbierto)
            {
                TBCodigo.Focus();
                m_bRecienAbierto = false;
            }
        }
    }
}
