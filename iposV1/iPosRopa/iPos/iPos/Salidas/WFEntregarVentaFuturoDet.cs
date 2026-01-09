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
using iPosReporting;

namespace iPos
{
    public partial class WFEntregarVentaFuturoDet : IposForm
    {
        //string m_fileName;
        //DateTime m_fecha;
        //TimeSpan m_time;
        long m_doctoId;
        long m_tipodoctoId;
        bool m_rellenarsurtida = true;

        bool m_recepcionProcesada = false;

        public decimal d_totalVentaFuturo = 0;
        public decimal d_aplicadoVentaFuturo = 0;
        public decimal d_porAplicarVentaFuturo = 0;

        public WFEntregarVentaFuturoDet()
        {
            InitializeComponent();
        }
        public WFEntregarVentaFuturoDet(long doctoId,long tipodoctoId)
        {
            InitializeComponent();
            m_doctoId = doctoId;
            m_tipodoctoId = tipodoctoId;
            //m_fecha = fecha;
            //m_time = time;
        }
        private void WFEntregarVentaFuturoDet_Load(object sender, EventArgs e)
        {
            iMP_REC_DETDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            try
            {
                FormatearCamposPersonalizados();
                this.rECIBIRVENTASFUTUROTableAdapter.Fill(this.dSSalidasAux.RECIBIRVENTASFUTURO, (int)m_doctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            inicializaPorSurtir();

            totalVentaFutTextBox.Text = d_totalVentaFuturo.ToString("N2");
            aplicadoTextBox.Text = d_aplicadoVentaFuturo.ToString("N2");
            porAplicarTextBox.Text = d_porAplicarVentaFuturo.ToString("N2");


            CUSUARIOSD usersD = new CUSUARIOSD();
            if (!usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_AGREGAR_PROD_ALSURTIR_VENTAFUTURO, null))
            {
                pnlAdicionProductos.Enabled = false;
            }

            

        }



        private void BTRECIBIR_Click(object sender, EventArgs e)
        {

            CMOVTOD objRecD = new CMOVTOD();
            CMOVTOBE objRecBE = new CMOVTOBE();

            CDOCTOD objDoctoD = new CDOCTOD();
            CDOCTOBE objDoctoBE = new CDOCTOBE();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            bool bRes = false ;

            long newDoctoId = 0;

            string strProductosSinExistenciaSuficiente = "";

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
                    objRecBE.ICANTIDADSURTIDA = Decimal.Parse(row.Cells["GC_SURTIDA"].Value.ToString());
                    objRecBE.IPRODUCTOID = long.Parse(row.Cells["DGPRODUCTOID"].Value.ToString());
                    //objRecBE.ICANTIDAD = Decimal.Parse(row.Cells["GC_CANTIDAD"].Value.ToString());

                    if(newDoctoId > 0)
                    {
                        objRecBE.IDOCTOID = newDoctoId;
                    }


                    if (row.Cells["MANEJALOTE"].Value.ToString().Equals("S"))
                    {
                        try{
                            objRecBE.ILOTE = row.Cells["GC_LOTE"].Value.ToString();
                        }
                        catch{
                             objRecBE.ILOTE = "";
                        }


                        try
                        {
                            objRecBE.IFECHAVENCE = (DateTime)row.Cells["FECHAVENCE"].Value;
                        }
                        catch
                        {
                        }

                        if (objRecBE.ILOTE.Trim().Length == 0 && objRecBE.ICANTIDADSURTIDA > 0)
                        {
                            MessageBox.Show("Debe asignar lote al producto " + row.Cells["GC_PRODUCTO"].Value.ToString());
                            fConn.Close();
                            return;
                        }
                    }

                    

                    objRecBE.ITIPODIFERENCIAINVENTARIOID = 0;
                    try
                    {
                        if(row.Cells["GC_CANTIDAD"].Value != null)
                             if(row.Cells["GC_CANTIDAD"].Value.ToString() != "")
                                objRecBE.ITIPODIFERENCIAINVENTARIOID = long.Parse(row.Cells["DGC_RAZONDIFINVID"].Value.ToString());
                    }
                    catch
                    {
                    }

                    if (objRecBE.ICANTIDADSURTIDA != 0)
                    {
                         long movtoRefId  = long.Parse(row.Cells["MOVTOREFID"].Value.ToString());
                         string sProblemaConExis = "N";
                         if (objDoctoD.VENTAFUTUROAPLICAR_COPYMOVTO(ref objRecBE, movtoRefId, CurrentUserID.CurrentUser.IID,m_doctoId, ref sProblemaConExis, fTrans) == false)
                            {
                                
                                fTrans.Rollback();
                                fConn.Close();
                                MessageBox.Show(objDoctoD.IComentario);
                                return;
                            }

                        if(sProblemaConExis == "S")
                        {
                            strProductosSinExistenciaSuficiente += " " + row.Cells["GC_PRODUCTO"].Value.ToString() + " ";
                        }

                         newDoctoId = objRecBE.IDOCTOID;

                        

                    }
                }

                if(strProductosSinExistenciaSuficiente != null && strProductosSinExistenciaSuficiente.Trim().Length > 0)
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("Hay problemas con existencias en los siguientes productos : " + strProductosSinExistenciaSuficiente);
                    return;
                }

                objDoctoBE.IID = newDoctoId;
                if(!objDoctoD.VENTAFUTUAPL_PRECOMPLETAR(objDoctoBE,fTrans))
                {


                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show(objDoctoD.IComentario);
                    return;
                }

                fTrans.Commit();
                fConn.Close();


                objDoctoBE.IID = newDoctoId;
                objDoctoBE = objDoctoD.seleccionarDOCTO(objDoctoBE, null);

                if(objDoctoBE == null)
                {
                    MessageBox.Show("La venta no fue guardada");
                    return ;
                }


                CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                CCAJABE caja = pvd.ObtenerDatosCaja(iPos.CurrentUserID.CurrentCompania.IEM_CAJA);

                WFPagosBasico wp = new WFPagosBasico(objDoctoBE, caja, false, 0, null, tipoTransaccionV.t_venta, "N", null, false, false, 0, 0);
                wp.m_bCerrarVentaFuturoAplicada = true;
                wp.m_bCerrarTraspasoSalida = false;
                wp.m_bCerrarVenta = false;
                wp.m_bMantenerVentaFuturoAbierta = CBMantenerAbierta.Checked;
                wp.ShowDialog();

                bool bAlreadyClosedInDB = true;
                bool generarFacturaElectronica = (wp.m_generarFacturaElectronica && !wp.m_surtidoPostpuesto);


                if (wp.m_bPagoCompleto)
                {



                    objDoctoBE.IID = newDoctoId;
                    objDoctoBE.IOBSERVACION = TBObservaciones.Text;

                    objDoctoBE.IREFERENCIAS = "";
                    objDoctoBE.IVENDEDORID = CurrentUserID.CurrentUser.IID;

                    

                    if(!bAlreadyClosedInDB)
                    {

                        
                        fConn.Open();
                        fTrans = fConn.BeginTransaction();

                        bRes = objDoctoD.VENTAFUTUROAPLICACION_COMPLETAR(objDoctoBE, CBMantenerAbierta.Checked, fTrans);

                        if (bRes == false)
                        {
                            fTrans.Rollback();
                            fConn.Close();

                            pvd.CancelarVenta(objDoctoBE, CurrentUserID.CurrentUser, null);

                            MessageBox.Show(objDoctoD.IComentario);

                            wp.Dispose();
                            GC.SuppressFinalize(wp);

                            return;
                        }
                        fTrans.Commit();
                        fConn.Close();

                    }




                    if (generarFacturaElectronica)
                    {
                        imprimirFacturaElectronica(newDoctoId);
                        if(CurrentUserID.CurrentParameters.IRECIBOLARGOCONFACTURA.Equals("S"))
                        {
                            PosPrinter.ImprimirTicket(newDoctoId);
                        }
                    }
                    else 
                    {
                        PosPrinter.ImprimirTicket(newDoctoId);
                    }
                    






                    //iPos.PosPrinter.ImprimirTicket(m_doctoId, Ticket._OPCION_IMPRESION_COMPRA_DEVOLUCION);

                    MessageBox.Show("Se han confirmado con exito la recepción de mercancía");

                    m_recepcionProcesada = true;


                    this.Close();
                    this.Dispose();
                }
                else
                {

                    pvd.CancelarVenta(objDoctoBE, CurrentUserID.CurrentUser, null);
                }

                wp.Dispose();
                GC.SuppressFinalize(wp);
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

                CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                pvd.CancelarVenta(objDoctoBE, CurrentUserID.CurrentUser, null);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fConn.Close();
            }
            
            
        }


        private bool ExportarRecepcionDeCompra(FbTransaction ft)
        {
            CPARAMETROBE parametroBE = new CPARAMETROBE();
            CPARAMETROD parametroD = new CPARAMETROD();

            CCAJAD cajaD = new CCAJAD();
            CCAJABE cajaBE = new CCAJABE();


            CDOCTOD objDoctoD = new CDOCTOD();
            CDOCTOBE objDoctoBE = new CDOCTOBE();

            CSUCURSALBE sucursalDestinoBE = new CSUCURSALBE();

            parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                MessageBox.Show(parametroD.IComentario);
                return false;
            }
            if (parametroBE.ISUCURSALNUMERO == "")
            {

                MessageBox.Show("Define la sucursal en la pantalla de empresa");
                return false;
            }


            cajaBE.IID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;

            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);

            if (cajaBE == null)
            {
                MessageBox.Show(cajaD.IComentario);
                return false;
            }

            objDoctoBE.IID = m_doctoId;
            objDoctoBE = objDoctoD.seleccionarDOCTO(objDoctoBE, ft);

            if (objDoctoBE == null)
            {
                MessageBox.Show(objDoctoD.IComentario);
                return false;
            }

            ExportarDBF exportDbf = new ExportarDBF();
            if (!exportDbf.ExportRecepcionCompras(parametroBE, cajaBE, DateTime.Now, objDoctoBE.IID))
            {
                MessageBox.Show(exportDbf.IComentario);
                return false;
            }
            return true;
        }

        private void iMP_REC_DETDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //DataGridViewRow row = iMP_REC_DETDataGridView.Rows[e.RowIndex];
            //if(row.Cells["GC_CANTIDAD"].Value != null)
            //    row.Cells["GC_SURTIDA"].Value = row.Cells["GC_CANTIDAD"].Value;
        }

        private void iMP_REC_DETDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void iMP_REC_DETDataGridView_RowsAdded_1(object sender, DataGridViewRowsAddedEventArgs e)
        {

            foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
            {
                if (m_rellenarsurtida)
                {
                    row.Cells["MOVTOREFID"].Value = row.Cells["GC_MOVTOID"].Value;
                    if (row.Cells["GC_CANTIDAD"].Value != null)
                    {
                        //row.Cells["GC_SURTIDA"].Value = row.Cells["GC_CANTIDAD"].Value;
                    }
                }
            }
        }

        private void iMP_REC_DETDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            MessageBox.Show("Dato invalido , porfavor ingrese un dato valido");
            e.ThrowException = false;


        }

        private void iMP_REC_DETDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText =  iMP_REC_DETDataGridView.Columns[e.ColumnIndex].HeaderText;

            e.Cancel = false;

            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals("SURTIDA")) return;

            try
            {
                long movtoId = long.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_MOVTOID"].Value.ToString());
                decimal dSurtida = decimal.Parse(e.FormattedValue.ToString());
                decimal dCantidad = decimal.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_CANTIDADFALTANTE"].Value.ToString());
              
                // checar sumatoria de recepcion
                long movtoRefId = 0;
                decimal sumaCantidadGrupo = 0;
                DataGridViewRow dNewRow = null;
                if (iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["MANEJALOTE"].Value.ToString().Equals("S"))
                {

                    movtoRefId = long.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["MOVTOREFID"].Value.ToString());
                    sumaCantidadGrupo = getSumCantidadGrupo(movtoRefId, iMP_REC_DETDataGridView.Rows[e.RowIndex]);
                    dNewRow = getNewDataGridRowGroup(movtoRefId, iMP_REC_DETDataGridView.Rows[e.RowIndex]);
                    if (sumaCantidadGrupo + dSurtida > dCantidad)
                    {
                        MessageBox.Show("La cantidad surtida ( sumada por producto)  no puede ser mayor que la cantidad del pedido ni menor que cero");
                        e.Cancel = true;
                        return;
                    }
                }

                
                
                if ((dSurtida > dCantidad && movtoId != 0) || dSurtida < 0)
                {
                    MessageBox.Show("La cantidad surtida no puede ser mayor que la cantidad del pedido ni menor que cero");
                    e.Cancel = true;
                    return;
                }
                







            }
            catch
            {
            }

        }



        private void iMP_REC_DETDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

            /*string headerText = iMP_REC_DETDataGridView.Columns[e.ColumnIndex].HeaderText;


            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals("SURTIDA")) return;

            long movtoId = long.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_MOVTOID"].Value.ToString());
            decimal dSurtida = decimal.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_SURTIDA"].Value.ToString());
            decimal dCantidad = decimal.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_CANTIDAD"].Value.ToString());
              
            
            // checar sumatoria de recepcion
            long movtoRefId = 0;
            decimal sumaCantidadGrupo = 0;
            DataGridViewRow dNewRow = null;
            if (iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["MANEJALOTE"].Value.ToString().Equals("S"))
            {

                movtoRefId = long.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["MOVTOREFID"].Value.ToString());
                sumaCantidadGrupo = getSumCantidadGrupo(movtoRefId, iMP_REC_DETDataGridView.Rows[e.RowIndex]);
                dNewRow = getNewDataGridRowGroup(movtoRefId, iMP_REC_DETDataGridView.Rows[e.RowIndex]);
           
                if (sumaCantidadGrupo + dSurtida == dCantidad)
                {
                    if (dNewRow != null)
                    {
                        iMP_REC_DETDataGridView.Rows.Remove(dNewRow);
                    }
                }
                else if (sumaCantidadGrupo + dSurtida < dCantidad)
                {
                    if (dNewRow != null)
                    {
                        dNewRow.Cells["RECIBIDAS"].Value = dCantidad - (sumaCantidadGrupo + dSurtida);
                    }
                    else if(dSurtida > 0 )
                    {
                        m_rellenarsurtida = false;


                        this.dSSalidasAux.RECIBIRVENTASFUTURO.AcceptChanges();
                        Salidas.DSSalidasAux.RECIBIRVENTASFUTURORow desRow = this.dSSalidasAux.RECIBIRVENTASFUTURO.NewRECIBIRVENTASFUTURORow();
                        Salidas.DSSalidasAux.RECIBIRVENTASFUTURORow sourceRow = (Salidas.DSSalidasAux.RECIBIRVENTASFUTURORow)this.dSSalidasAux.RECIBIRVENTASFUTURO.Rows[e.RowIndex];
                        desRow.ItemArray = sourceRow.ItemArray.Clone() as object[];

                        desRow.LOTE = "";
                        desRow.FECHAVENCE = DateTime.Today;
                        desRow.CANTIDADSURTIDA = 0;
                        desRow.RECIBIDAS = dCantidad - (sumaCantidadGrupo + dSurtida);
                        desRow.MOVTOID = 0;


                        this.dSSalidasAux.RECIBIRVENTASFUTURO.Rows.InsertAt(desRow, e.RowIndex + 1);
                        iMP_REC_DETDataGridView.Refresh();




                        m_rellenarsurtida = true;

                    }
                }
                decimal currentRecibidas = updateRecibidas(movtoRefId, iMP_REC_DETDataGridView.Rows[e.RowIndex]);
                iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["RECIBIDAS"].Value = currentRecibidas;

                m_rellenarsurtida = false;
                this.dSSalidasAux.RECIBIRVENTASFUTURO.AcceptChanges();
                iMP_REC_DETDataGridView.Refresh();
                m_rellenarsurtida = true;
            }*/

            coloreaRow(iMP_REC_DETDataGridView.Rows[e.RowIndex]);

        }





        private CSUCURSALBE DatosSucursal(long lSucursalTid)
        {

            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();

            sucursalBE.IID = lSucursalTid;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);

            return sucursalBE;

        }

        private void ImprimirTicket(long doctoId)
        {


            CTICKET_DETAILD detailD = new CTICKET_DETAILD();
            CTICKET_FOOTERD footerD = new CTICKET_FOOTERD();
            CTICKET_HEADERD headerD = new CTICKET_HEADERD();


            CTICKET_FOOTERBE footerBE = new CTICKET_FOOTERBE();
            CTICKET_HEADERBE headerBE = new CTICKET_HEADERBE();
            CTICKET_DETAILBE[] ListaDetalles = detailD.seleccionarTICKET_DETAIL(doctoId, false,null);

            CSUCURSALBE sucursalBE = new CSUCURSALBE();

            
            int iXLetraRenglon = 0;
            string cantidadConLetra;

            footerBE.IDOCTOID = doctoId;
            headerBE.IDOCTOID = doctoId; 

            headerBE = headerD.seleccionarTICKET_HEADER(headerBE, null);
            footerBE = footerD.seleccionarTICKET_FOOTER(footerBE, false, null);


            cantidadConLetra = Numalet.ToCardinal(footerBE.ITOTAL).ToUpper();

            Ticket ticket = new Ticket();



            //si es una cancelacion
            if (headerBE.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA)
                ticket.AddHeaderLine("CANCELACION");


            //header deacuerdo al tipo
            switch (headerBE.ITIPODOCTOID)
            {
                case DBValues._DOCTO_TIPO_TRASPASO_REC:
                    {
                        sucursalBE = DatosSucursal(headerBE.ISUCURSALTID);
                        ticket.AddHeaderLine("RECEPCION TRASLADO");
                    }
                    break;
                case DBValues._DOCTO_TIPO_COMPRA:
                    {
                        ticket.AddHeaderLine("RECEPCION COMPRA");
                    }
                    break;

                case DBValues._DOCTO_TIPO_TRASPASO_ENVIO:
                    {

                        sucursalBE = DatosSucursal(headerBE.ISUCURSALTID);
                        ticket.AddHeaderLine("TRASLADO");
                    }
                    break;
                default:
                    break;

            }


            ticket.AddHeaderLine("      " + headerBE.INOMBRE);
            ticket.AddHeaderLine(headerBE.IDOMICICIO);
            ticket.AddHeaderLine(headerBE.ICIUDAD.Trim() + " , " + headerBE.IESTADO.Trim());
            ticket.AddHeaderLine("RFC: " + headerBE.IRFC);
            ticket.AddHeaderLine(new string('-', Ticket.maxChar));

            //
            switch (headerBE.ITIPODOCTOID)
            {
                case DBValues._DOCTO_TIPO_TRASPASO_REC:
                    {
                        ticket.AddHeaderLine("TRASLADO DE SUCURSAL : " + sucursalBE.ICLAVE);
                        ticket.AddHeaderLine("SUCURSAL FUENTE: " + sucursalBE.INOMBRE);
                    } 
                    break;

                case DBValues._DOCTO_TIPO_TRASPASO_ENVIO:
                    {
                        ticket.AddHeaderLine("TRASLADO A SUCURSAL : " + sucursalBE.ICLAVE);
                        ticket.AddHeaderLine("SUCURSAL DESTINO: " + sucursalBE.INOMBRE);
                    }
                    break;

                case DBValues._DOCTO_TIPO_VENTA:
                    {
                        ticket.AddHeaderLine("CLIENTE:  0000");
                        ticket.AddHeaderLine("CLIENTE DE MOSTRADOR");
                    }
                    break;

                default:
                    break;

            }

            ticket.AddHeaderLine("Vendedor: " + iPos.CurrentUserID.CurrentUser.INOMBRE);
            ticket.AddHeaderLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " Ticket " + headerBE.ITICKET);
            ticket.AddHeaderLine(new string('=', Ticket.maxChar));

            ticket.AddHeaderLine("DESCRIPCION               ");
            ticket.AddHeaderLine("CANTIDAD    PRECIO    %IVA      IMPORTE");

            ticket.AddHeaderLine(new string('-', Ticket.maxChar));
            foreach (CTICKET_DETAILBE detailItem in ListaDetalles)
            {
                ticket.AddItem(detailItem.ICANTIDAD.ToString(), detailItem.IDESCRIPCION1, detailItem.IPRECIO.ToString("N2"), detailItem.ISUBTOTAL.ToString("N2"), detailItem.IIVA.ToString(),
                              detailItem.ILOTE,
                              ((bool)detailItem.isnull["IFECHAVENCE"]) ? "" :
                               detailItem.IFECHAVENCE.ToString("dd/MM/yy"), "",
                                  ((bool)detailItem.isnull["ITIPORECARGA"]) ? "" : detailItem.ITIPORECARGA, 
                                  ((int)tipoImpresionItem.i_doslineas).ToString("N0"), 
                                  "");
            }
            //El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio 
            ticket.AddTotal("Sub-Total:", footerBE.ISUBTOTAL.ToString("N2"));
            ticket.AddTotal("Iva:", footerBE.IIVA.ToString("N2"));
            ticket.AddTotal("Descuento Total:", footerBE.IDESCUENTO_TOTAL.ToString("N2"));
            ticket.AddTotal("Total Compra:", footerBE.ITOTAL.ToString("N2"));
            ticket.AddTotal("Importe Recibido:", (footerBE.ITOTAL + footerBE.ICAMBIO).ToString("N2"));
            ticket.AddTotal("Cambio:", footerBE.ICAMBIO.ToString("N2")); //Ponemos un total en blanco que sirve de espacio 
            ticket.AddTotal("", "");
            ticket.AddTotal("", "");


            ticket.AddFooterLine(new string('-', Ticket.maxChar));

            ticket.AddFooterLine(cantidadConLetra.Substring((Ticket.maxChar * iXLetraRenglon)));

            ticket.AddFooterLine(footerBE.ICAJA /*+ " Turno: " + footerBE.ITURNO*/);
            ticket.AddFooterLine(new string('-', Ticket.maxChar));
            //ticket.AddFooterLine("Gracias por su compra");

            ticket.PrintTicketDirect(Ticket.GetReceiptPrinter());


        }



        private void FormatearCamposPersonalizados()
        {
            try
            {


                if (CurrentUserID.CurrentParameters.ICAMPOSCUSTOMALIMPORTAR.Equals("S"))
                {

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO1"] && CurrentUserID.CurrentParameters.ITEXTO1 != "")
                    {
                        iMP_REC_DETDataGridView.Columns["DGTEXTO1"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO1;
                    }
                    else
                    {
                        iMP_REC_DETDataGridView.Columns["DGTEXTO1"].Visible = false;
                    }



                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO2"] && CurrentUserID.CurrentParameters.ITEXTO2 != "")
                    {
                        iMP_REC_DETDataGridView.Columns["DGTEXTO2"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO2;
                    }
                    else
                    {
                        iMP_REC_DETDataGridView.Columns["DGTEXTO2"].Visible = false;
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO3"] && CurrentUserID.CurrentParameters.ITEXTO3 != "")
                    {
                        iMP_REC_DETDataGridView.Columns["DGTEXTO3"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO3;
                    }
                    else
                    {
                        iMP_REC_DETDataGridView.Columns["DGTEXTO3"].Visible = false;
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO4"] && CurrentUserID.CurrentParameters.ITEXTO4 != "")
                    {
                        iMP_REC_DETDataGridView.Columns["DGTEXTO4"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO4;
                    }
                    else
                    {
                        iMP_REC_DETDataGridView.Columns["DGTEXTO4"].Visible = false;
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO5"] && CurrentUserID.CurrentParameters.ITEXTO5 != "")
                    {
                        iMP_REC_DETDataGridView.Columns["DGTEXTO5"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO5;
                    }
                    else
                    {
                        iMP_REC_DETDataGridView.Columns["DGTEXTO5"].Visible = false;
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO6"] && CurrentUserID.CurrentParameters.ITEXTO6 != "")
                    {
                        iMP_REC_DETDataGridView.Columns["DGTEXTO6"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO6;
                    }
                    else
                    {
                        iMP_REC_DETDataGridView.Columns["DGTEXTO6"].Visible = false;
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO1"] && CurrentUserID.CurrentParameters.INUMERO1 != "")
                    {
                        iMP_REC_DETDataGridView.Columns["DGNUMERO1"].HeaderText = CurrentUserID.CurrentParameters.INUMERO1;
                    }
                    else
                    {
                        iMP_REC_DETDataGridView.Columns["DGNUMERO1"].Visible = false;
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO2"] && CurrentUserID.CurrentParameters.INUMERO2 != "")
                    {
                        iMP_REC_DETDataGridView.Columns["DGNUMERO2"].HeaderText = CurrentUserID.CurrentParameters.INUMERO2;
                    }
                    else
                    {
                        iMP_REC_DETDataGridView.Columns["DGNUMERO2"].Visible = false;
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO3"] && CurrentUserID.CurrentParameters.INUMERO3 != "")
                    {
                        iMP_REC_DETDataGridView.Columns["DGNUMERO3"].HeaderText = CurrentUserID.CurrentParameters.INUMERO3;
                    }
                    else
                    {
                        iMP_REC_DETDataGridView.Columns["DGNUMERO3"].Visible = false;
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO4"] && CurrentUserID.CurrentParameters.INUMERO4 != "")
                    {
                        iMP_REC_DETDataGridView.Columns["DGNUMERO4"].HeaderText = CurrentUserID.CurrentParameters.INUMERO4;
                    }
                    else
                    {
                        iMP_REC_DETDataGridView.Columns["DGNUMERO4"].Visible = false;
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["IFECHA1"] && CurrentUserID.CurrentParameters.IFECHA1 != "")
                    {
                        iMP_REC_DETDataGridView.Columns["DGFECHA1"].HeaderText = CurrentUserID.CurrentParameters.IFECHA1;
                    }
                    else
                    {
                        iMP_REC_DETDataGridView.Columns["DGFECHA1"].Visible = false;
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["IFECHA2"] && CurrentUserID.CurrentParameters.IFECHA2 != "")
                    {
                        iMP_REC_DETDataGridView.Columns["DGFECHA2"].HeaderText = CurrentUserID.CurrentParameters.IFECHA2;
                    }
                    else
                    {
                        iMP_REC_DETDataGridView.Columns["DGFECHA2"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void iMP_REC_DETDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (this.iMP_REC_DETDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString() == "Asigna Lote")
                {
                    if (iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["MANEJALOTE"].Value.ToString().Equals("S"))
                    {

                        decimal CANTIDADSURTIDA = Decimal.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_SURTIDA"].Value.ToString());
                        long PRODUCTOID = long.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGPRODUCTOID"].Value.ToString());
                        decimal CANTIDADORDENADA = Decimal.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_CANTIDAD"].Value.ToString());
                        long movtoId = long.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_MOVTOID"].Value.ToString());
                        decimal sumaOtrosLotes = 0;

                        CPRODUCTOD prodD = new CPRODUCTOD();
                        CPRODUCTOBE prod = new CPRODUCTOBE();
                        prod.IID = PRODUCTOID;
                        prod = prodD.seleccionarPRODUCTO(prod, null);

                        if(prod == null)
                        {

                            MessageBox.Show("El producto no existe");
                            return;
                        }

                        WFPreguntaLote pl_ = new WFPreguntaLote(prod, CANTIDADSURTIDA, 0, null);
                        pl_.ShowDialog();
                        ArrayList asignaciones_ = pl_.asignaciones;
                        pl_.Dispose();
                        GC.SuppressFinalize(pl_);

                        if (asignaciones_.Count <= 0)
                        {

                            MessageBox.Show("No se asignaron los lotes");
                            return;
                        }

                       
                        ArrayList asignacionesLote = asignaciones_;
                        int iRegLote = 0;
                        CAsignacionLote bufferLote;
                        if (asignacionesLote.Count > 1)
                        {
                            while (asignacionesLote.Count - 1 > iRegLote)
                            {
                                bufferLote = (CAsignacionLote)asignacionesLote[iRegLote];

                                this.dSSalidasAux.RECIBIRVENTASFUTURO.AddRECIBIRVENTASFUTURORow
                                    (
                                    m_doctoId,
                                    movtoId,
                                    "+",
                                    0,
                                    prod.ICLAVE,
                                    prod.IDESCRIPCION1,
                                    bufferLote.cantidad,
                                    bufferLote.lote,
                                    bufferLote.cantidad,
                                    bufferLote.cantidad,
                                    prod.ITEXTO1,
                                    prod.ITEXTO2,
                                    prod.ITEXTO3,
                                    prod.ITEXTO4,
                                    prod.ITEXTO5,
                                    prod.ITEXTO6,
                                    prod.INUMERO1, prod.INUMERO2, prod.INUMERO3, prod.INUMERO4,
                                    prod.IFECHA1, prod.IFECHA2,
                                    prod.IMANEJALOTE,
                                    bufferLote.fechaVence,
                                    movtoId,
                                    0,
                                    prod.IEXISTENCIA,
                                    prod.IINVENTARIABLE,
                                    prod.INEGATIVOS,
                                    prod.IID,
                                    prod.IENPROCESODESALIDA);

                                sumaOtrosLotes += bufferLote.cantidad;

                                iRegLote++;
                            }

                            bufferLote = (CAsignacionLote)asignacionesLote[iRegLote];
                            iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_LOTE"].Value = bufferLote.lote;
                            iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["FECHAVENCE"].Value = bufferLote.fechaVence;
                            iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_SURTIDA"].Value = bufferLote.cantidad;
                            iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_CANTIDAD"].Value = CANTIDADORDENADA - sumaOtrosLotes;

                        }
                        else if (asignacionesLote.Count == 1)
                        {
                            bufferLote = (CAsignacionLote)asignacionesLote[iRegLote];

                            iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_LOTE"].Value = bufferLote.lote;
                            iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["FECHAVENCE"].Value = bufferLote.fechaVence;
                            iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_SURTIDA"].Value = bufferLote.cantidad;
                        }



                        /*WFDefineLote pl = new WFDefineLote();
                        pl.m_descripcionProducto = iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_DESCRIPCION"].Value.ToString();
                        pl.ShowDialog();
                        iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_LOTE"].Value = pl.m_lote;
                        iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["FECHAVENCE"].Value = pl.m_fechaVence;*/
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private decimal getSumCantidadGrupo(long movtorefid, DataGridViewRow rowExcept)
        {
            decimal dSumCantidad = 0;
            foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
             {
                    
                 if (row.Index == iMP_REC_DETDataGridView.NewRowIndex)
                 {
                        continue;
                 }
                 long current_movtoRefId = long.Parse(row.Cells["MOVTOREFID"].Value.ToString());

                 if (current_movtoRefId == movtorefid && rowExcept != row)
                {

                    decimal cantidadSurtida = Decimal.Parse(row.Cells["GC_SURTIDA"].Value.ToString());
                    dSumCantidad += cantidadSurtida;
                }
            }

            return dSumCantidad;
        }




        private DataGridViewRow getNewDataGridRowGroup(long movtorefid, DataGridViewRow rowExcept)
        {
            DataGridViewRow dataRow = null;
            foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
            {

                if (row.Index == iMP_REC_DETDataGridView.NewRowIndex)
                {
                    continue;
                }
                long current_movtoRefId = long.Parse(row.Cells["MOVTOREFID"].Value.ToString());
                string lote =  row.Cells["GC_LOTE"].Value.ToString();
                if (current_movtoRefId == movtorefid && rowExcept != row && lote.Trim().Length == 0)
                {

                    decimal cantidadSurtida = Decimal.Parse(row.Cells["GC_SURTIDA"].Value.ToString());
                    dataRow = row;
                }
            }

            return dataRow;
        }


        private decimal updateRecibidas(long movtorefid, DataGridViewRow rowExcept)
        {
            decimal dRecibidasRow = 0;
            decimal dRecibidasCurrent = 0;
            
            foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
            {

                if (row.Index == iMP_REC_DETDataGridView.NewRowIndex)
                {
                    continue;
                }
                long current_movtoRefId = long.Parse(row.Cells["MOVTOREFID"].Value.ToString());
                decimal cantidadSurtida = Decimal.Parse(row.Cells["GC_SURTIDA"].Value.ToString());
                if (current_movtoRefId == movtorefid)
                {
                    if (rowExcept == row)
                    {
                        dRecibidasRow = dRecibidasCurrent;
                    }
                    else
                    {
                        row.Cells["RECIBIDAS"].Value = dRecibidasCurrent;
                    }

                    dRecibidasCurrent += cantidadSurtida;
                }
            }

            return dRecibidasRow;
        }

        private void WFEntregarVentaFuturoDet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!m_recepcionProcesada)
            {

                if (MessageBox.Show("Esto eliminara los cambios actuales . ¿Desea realmente cerrar el formulario? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Realmente desea eliminar esta venta a futuro? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            FinalizarDocto(this.m_doctoId, null);
        }


        public bool FinalizarDocto(long doctoID, FbTransaction st)
        {
            try
            {
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                bool iResult;


                doctoBE.IID = doctoID;

                doctoBE = doctoD.seleccionarDOCTO(doctoBE, st);

                if (doctoBE == null)
                {
                    MessageBox.Show("El docto ya no existe");
                    return false;
                }


                /*
                //Generar el archivo a enviar de log mail antes de eliminar el docto
                string strArchivoEnvioMail = GenerarArchivoDeDocto((int)doctoBE.IID);*/

                if (doctoBE.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR)
                {
                    iResult = doctoD.BorrarDOCTOD(doctoBE, st);
                }
                else
                    iResult = doctoD.VENTAFUTUROFINALIZAR(doctoBE.IID, st);


                if (!iResult)
                {
                    MessageBox.Show(doctoD.IComentario);
                    return false;
                }

                //Enviar el mail
                //EnvioMailRecepcionEliminada(strArchivoEnvioMail);

                HiloExistencias._IFLAGRECEPCIONREGISTROTRASLAEVENTOS++;

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
                return false;
            }
        }

        /*private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.rECIBIRVENTASFUTUROTableAdapter.Fill(this.dSSalidasAux.RECIBIRVENTASFUTURO, ((int)(System.Convert.ChangeType(dOCTOIDToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }*/



        private bool imprimirFacturaElectronica(long doctoId)
        {

            bool retorno;

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE docto = new CDOCTOBE();
            docto.IID = doctoId;
            docto = doctoD.seleccionarDOCTO(docto, null);

            if ((bool)docto.isnull["IFOLIOSAT"] || (bool)docto.isnull["IESTATUSDOCTOID"]
                || docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || docto.IFOLIOSAT <= 0)
            {
                MessageBox.Show("No se puede imprimir la factura electronica , cheque que se haya generado la factura electronica de este registro");
                return false;
            }




            WFFacturaElectronica fe = new WFFacturaElectronica(docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_GENERARPDF, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;
        }


        private void inicializaPorSurtir()
        {

            foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
            {

                decimal cantidad = 0;
                decimal recibidas = 0;

                try
                {

                    cantidad = Decimal.Parse(row.Cells["GC_CANTIDAD"].Value.ToString());
                }
                catch
                {

                }


                try
                {

                    recibidas = Decimal.Parse(row.Cells["RECIBIDAS"].Value.ToString());
                }
                catch
                {

                }


                cantidad = cantidad - recibidas;

                if (cantidad < 0)
                {
                    row.Cells["GC_SURTIDA"].Value = 0;
                }
                else
                {
                    row.Cells["GC_SURTIDA"].Value = cantidad;
                }

                coloreaRow(row);

                
            }
        }

        private void btnAjustarExistencias_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
            {

                if (row.Index == iMP_REC_DETDataGridView.NewRowIndex)
                {
                    continue;
                }

                decimal cantidadAPedir = 0;

                try
                {

                    cantidadAPedir = Decimal.Parse(row.Cells["GC_SURTIDA"].Value.ToString());
                }
                catch
                {

                }
                
                
                decimal existencia = 0;
                try
                {
                    existencia = Decimal.Parse(row.Cells["GC_EXISTENCIA"].Value.ToString());
                }
                catch
                {
                }


                if (existencia < 0)
                {
                    existencia = 0;
                }


                decimal enprocesodesalida = 0;
                try
                {
                    enprocesodesalida = Decimal.Parse(row.Cells["GC_ENPROCESODESALIDA"].Value.ToString());
                }
                catch
                {
                }

                if (enprocesodesalida < 0)
                {
                    enprocesodesalida = 0;
                }

                existencia = existencia - enprocesodesalida;

                if (existencia < 0)
                {
                    existencia = 0;
                }



                if (cantidadAPedir > existencia)
                {
                    if (existencia < 0)
                    {
                        row.Cells["GC_SURTIDA"].Value = 0;
                    }
                    else
                    {
                        row.Cells["GC_SURTIDA"].Value = existencia;
                    }
                    coloreaRow(row);
                }


            }
        }





        private void coloreaRow(DataGridViewRow row)
        {

            decimal existenciaMatriz = 0, cantidadPedido = 0, enprocesodesalida = 0;
            string inventariable = "N", negativos = "N";

            try
            {
                if (row.Cells["GC_EXISTENCIA"].Value != DBNull.Value)
                {
                    existenciaMatriz = decimal.Parse(row.Cells["GC_EXISTENCIA"].Value.ToString());
                }

                try
                {
                    if (row.Cells["GC_ENPROCESODESALIDA"].Value != DBNull.Value)
                    {
                        enprocesodesalida = Decimal.Parse(row.Cells["GC_ENPROCESODESALIDA"].Value.ToString());
                    }
                }
                catch
                {
                }


                if (row.Cells["GC_SURTIDA"].Value != DBNull.Value)
                {
                    cantidadPedido = decimal.Parse(row.Cells["GC_SURTIDA"].Value.ToString());
                }


                if (row.Cells["GC_INVENTARIABLE"].Value != DBNull.Value)
                {
                    inventariable = row.Cells["GC_INVENTARIABLE"].Value.ToString();
                }


                if (row.Cells["DG_NEGATIVOS"].Value != DBNull.Value)
                {
                    negativos = row.Cells["DG_NEGATIVOS"].Value.ToString();
                }

                if(existenciaMatriz < 0)
                {
                    existenciaMatriz = 0;
                }

                if (enprocesodesalida < 0)
                {
                    enprocesodesalida = 0;
                }

                existenciaMatriz = existenciaMatriz - enprocesodesalida;

                if (existenciaMatriz < 0)
                {
                    existenciaMatriz = 0;
                }


                if (cantidadPedido > existenciaMatriz && inventariable == "S" && negativos == "N")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
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
            row.Cells["GC_SURTIDA"].Style.BackColor = Color.GreenYellow;
            row.Cells["GC_SURTIDA"].Style.ForeColor = Color.Black;

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



        private bool BuscarProducto(ref CPRODUCTOBE prod)
        {
            CComprasD pvd = new CComprasD();
            prod = pvd.buscarPRODUCTOSPV(TBCodigo.Text.Trim(), CurrentUserID.CurrentParameters, null);
            if (prod != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



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
                this.TBCantidad.Focus();
                TBCantidad.Select(0, TBCantidad.Text.Length);
            }
        }

        private void TBCodigo_Validating(object sender, CancelEventArgs e)
        {

            if (TBCodigo.Text.Trim() == "")
                return;

            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {
                this.LBProductoDescripcion.Text = "";
                SeleccionarProducto(TBCodigo.Text.Trim());
                return;
            }
            this.LBProductoDescripcion.Text = prod.IDESCRIPCION;
        }



        private void PreProcessAdd()
        {

            long? P_IDDOCTO = null;
            decimal? P_CANTIDAD = null;
            long? P_IDPRODUCTO = null;
            string P_VD_VENDEDOR = CurrentUserID.CurrentUser.INOMBRE;
            string P_LOTE = "";
            long? P_USERID = iPos.CurrentUserID.CurrentUser.IID;
            int? US_SUPERVISORID = null;
            int? ALMACENID = (int)DBValues._DOCTO_ALMACEN_DEFAULT;/*CurrentUserID.CurrentUser.IUS_ALMACENID*/ ;
            long? SUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            DateTime P_FECHAVENCE = DateTime.MinValue;
            long? SUCURSALTID = 0;
            long? ALMACENTID = 0;
            decimal? P_CANTIDAD_PEDIDA = null;

            long? P_TIPODIFERENCIAINVENTARIOID = 0;

            long? P_MOVTOID = null;

            string P_LOCALIDAD = "";


            if (TBCodigo.Text.Trim() == "")
            {
                MessageBox.Show("El texto de este control no debe estar vacio");
                return;
            }

            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {

                MessageBox.Show("El producto no existe");
                return;
            }

            if (prod.IESPRODUCTOPADRE == "S")
            {
                MessageBox.Show("No puede seleccionar un producto padre");
                return;
            }

            P_IDPRODUCTO = prod.IID;

            try
            {
                P_CANTIDAD_PEDIDA = decimal.Parse(TBCantidad.Text.Trim());

            }
            catch
            {
                MessageBox.Show("La cantidad no tiene el formato adecuado");
                return;
            }


           /* if (P_CANTIDAD_PEDIDA > dMaxCantidad)
            {

                if (MessageBox.Show("La cantidad parece ser muy grande , seguro que desea continuar con esa cantidad ", "Cantidad muy grande", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
            }*/

            if (P_CANTIDAD_PEDIDA <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero ", "Cantidad menor o igual a cero", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }



            if (prod.IINVENTARIABLE != null && prod.IINVENTARIABLE.Equals("S") &&
                (prod.INEGATIVOS != null && prod.INEGATIVOS.Equals("N")))
            {
                if ((bool)prod.isnull["IEXISTENCIA"])
                {

                    MessageBox.Show("No hay existencia suficiente");
                    return;
                }

                if (P_CANTIDAD_PEDIDA > prod.IEXISTENCIA - prod.IENPROCESODESALIDA)
                {
                    MessageBox.Show("No hay existencia suficiente");
                    return;
                }

            }

            P_IDDOCTO = m_doctoId;

            P_CANTIDAD = P_CANTIDAD_PEDIDA;

           

            // aqui se decidira si agregar a un registro ya existente o no
            ArrayList rowsConMismoProducto = new ArrayList();
            bool bSeAgrego = false;
            foreach (iPos.Salidas.DSSalidasAux.RECIBIRVENTASFUTURORow dr in this.dSSalidasAux.RECIBIRVENTASFUTURO.Rows)
            {
                if(dr.PRODUCTOID == prod.IID)
                {

                    if(prod.IMANEJALOTE != null && prod.IMANEJALOTE.Equals("S") )
                    {
                        if (!dr.IsLOTENull() && dr.LOTE != null && dr.LOTE.Trim().Length > 0)
                        {
                            rowsConMismoProducto.Add(dr.LOTE);
                        }
                        else if(!rowsConMismoProducto.Contains(""))
                        {
                            rowsConMismoProducto.Add("");
                        }
                    }
                    else
                    {
                        dr.CANTIDAD = (dr.IsCANTIDADNull() ? 0 : dr.CANTIDAD) + (decimal)P_CANTIDAD;
                        dr.CANTIDADSURTIDA = (dr.IsCANTIDADSURTIDANull() ? 0 : dr.CANTIDADSURTIDA) + (decimal)P_CANTIDAD;
                        bSeAgrego = true;
                        MessageBox.Show("Se agrego a uno de los registros existentes de este producto");
                        break;
                    }
                }
            }

            if (!bSeAgrego && rowsConMismoProducto != null && rowsConMismoProducto.Count > 0)
            {

                string loteSeleccionado = "";

                if (!(rowsConMismoProducto.Count == 1 && ((string)rowsConMismoProducto[0]).Equals("")))
                {
                    WFSeleccionarLoteAgregado wf = new WFSeleccionarLoteAgregado();
                    wf.loteList = rowsConMismoProducto;
                    wf.ShowDialog();
                    loteSeleccionado = wf.lote;
                    wf.Dispose();
                    GC.SuppressFinalize(wf);
                }

                

                foreach (iPos.Salidas.DSSalidasAux.RECIBIRVENTASFUTURORow dr in this.dSSalidasAux.RECIBIRVENTASFUTURO.Rows)
                {
                    if (dr.PRODUCTOID == prod.IID && 
                          (
                            (loteSeleccionado.Equals("") && (dr.IsLOTENull() || dr.LOTE == null || dr.LOTE.Trim().Length == 0)) ||
                            (!dr.IsLOTENull() && loteSeleccionado.Equals(dr.LOTE))

                          )
                        )
                    {

                        dr.CANTIDAD = (dr.IsCANTIDADNull() ? 0 : dr.CANTIDAD) + (decimal)P_CANTIDAD;
                        dr.CANTIDADSURTIDA = (dr.IsCANTIDADSURTIDANull() ? 0 : dr.CANTIDADSURTIDA) + (decimal)P_CANTIDAD;
                        MessageBox.Show("Se agrego a uno de los registros existentes de este producto");
                        bSeAgrego = true;
                        break;
                    }
                }


            }



            if (!bSeAgrego)
            {
                try
                {

                    this.dSSalidasAux.RECIBIRVENTASFUTURO.AddRECIBIRVENTASFUTURORow
                        (
                        m_doctoId,
                        0,
                        "+",
                        0,
                        prod.ICLAVE,
                        prod.IDESCRIPCION1,
                        (decimal)P_CANTIDAD,
                        "",
                        (decimal)P_CANTIDAD,
                        (decimal)P_CANTIDAD,
                        prod.ITEXTO1,
                        prod.ITEXTO2,
                        prod.ITEXTO3,
                        prod.ITEXTO4,
                        prod.ITEXTO5,
                        prod.ITEXTO6,
                        prod.INUMERO1, prod.INUMERO2, prod.INUMERO3, prod.INUMERO4,
                        prod.IFECHA1, prod.IFECHA2,
                        prod.IMANEJALOTE,
                        P_FECHAVENCE,
                        0,
                        0,
                        prod.IEXISTENCIA,
                        prod.IINVENTARIABLE,
                        prod.INEGATIVOS,
                        prod.IID,
                        prod.IENPROCESODESALIDA);
                    PrepararSiguienteEntrada();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                }


                iMP_REC_DETDataGridView.Update();
                iMP_REC_DETDataGridView.Refresh();

            }
        }


        private void PrepararSiguienteEntrada()
        {
            this.TBCantidad.Text = "";
            this.TBCodigo.Text = "";
            this.TBCodigo.Focus();

        }

        private void BTAgregar_Click(object sender, EventArgs e)
        {
            PreProcessAdd();
        }


    }
}
