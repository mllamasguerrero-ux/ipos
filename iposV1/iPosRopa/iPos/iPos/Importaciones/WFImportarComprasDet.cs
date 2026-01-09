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

namespace iPos
{
    public partial class WFImportarComprasDet : IposForm
    {
        //string m_fileName;
        //DateTime m_fecha;
        //TimeSpan m_time;
        long m_doctoId;
        long m_tipodoctoId;
        public WFImportarComprasDet()
        {
            InitializeComponent();
        }
        public WFImportarComprasDet(long doctoId,long tipodoctoId)
        {
            InitializeComponent();
            m_doctoId = doctoId;
            m_tipodoctoId = tipodoctoId;
            //m_fecha = fecha;
            //m_time = time;
        }
        private void WFImportarComprasDet_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSImportaciones.IMP_RECIBIDOS' table. You can move, or remove it, as needed.
            
            try
            {
                FormatearCamposPersonalizados();
                this.rECIBIRTableAdapter.Fill(this.dSImportaciones.RECIBIR, (int)m_doctoId);


                if (CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"))
                {
                    this.ALMACENComboBox.llenarDatos();
                    this.ALMACENComboBox.Visible = true;
                    this.lblAlmacen.Visible = true;

                    this.ALMACENComboBox.SelectedDataValue = CurrentUserID.CurrentUser.IALMACENID != 0 ? CurrentUserID.CurrentUser.IALMACENID : DBValues._DOCTO_ALMACEN_DEFAULT;
                }
                else
                {
                    this.ALMACENComboBox.Visible = false;
                    this.lblAlmacen.Visible = false;
                }

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }   
        }


        private long ObtainAlmacenId()
        {

            long almacenId = DBValues._DOCTO_ALMACEN_DEFAULT;
            if (CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"))
            {
                almacenId = int.Parse(this.ALMACENComboBox.SelectedValue.ToString());
            }
            return almacenId;
        }

        private void BTRECIBIR_Click(object sender, EventArgs e)
        {
            CMOVTOD objRecD = new CMOVTOD();
            CMOVTOBE objRecBE = new CMOVTOBE();

            CDOCTOD objDoctoD = new CDOCTOD();
            CDOCTOBE objDoctoBE = new CDOCTOBE();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            bool bRes = false;
            bool bHayDevolucion = false;

            long lDoctoNotaCredito = 0;


            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();


                if (CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"))
                {
                    long almacenId = ObtainAlmacenId();
                    objDoctoD.CambiarALMACENID(m_doctoId, almacenId, fTrans);
                }

                foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
                {
                    
                    if (row.Index == iMP_REC_DETDataGridView.NewRowIndex)
                    {
                        continue;
                    }
                    objRecBE = new CMOVTOBE();
                    objRecBE.IID = long.Parse(row.Cells["GC_MOVTOID"].Value.ToString());
                    objRecBE.ICANTIDADSURTIDA = Decimal.Parse(row.Cells["GC_SURTIDA"].Value.ToString());
                    objRecBE.ICANTIDAD = Decimal.Parse(row.Cells["GC_CANTIDAD"].Value.ToString());

                    if (objRecBE.ICANTIDADSURTIDA < objRecBE.ICANTIDAD)
                    {
                        bHayDevolucion = true;
                    }

                    try
                    {
                        if (row.Cells["GC_LOTE"].Value != DBNull.Value)
                        {

                            if (row.Cells["GC_LOTE"].Value.ToString().Trim().Length != 0)
                            {

                                objRecBE.ILOTE = row.Cells["GC_LOTE"].Value.ToString();
                                objRecBE.IFECHAVENCE = (DateTime)row.Cells["DGFECHAVENCE"].Value;
                            }

                        }
                    }
                    catch (Exception ex) { }


                    try
                    {
                        if (row.Cells["GC_LOTEIMPORTADO"].Value != DBNull.Value)
                        {

                            objRecBE.ILOTEIMPORTADO = long.Parse(row.Cells["GC_LOTEIMPORTADO"].Value.ToString()); ;

                        }
                    }
                    catch (Exception ex) { }


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
                        if (objRecD.RECIBIRMOVTOD(objRecBE, fTrans) == false)
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            MessageBox.Show(objRecD.IComentario);
                            return;
                        }
                    }
                }



                Hashtable tbl = new Hashtable();
                foreach (DataGridViewRow rowHd in iMP_REC_DETDataGridView.Rows)
                {

                    if (rowHd.Index == iMP_REC_DETDataGridView.NewRowIndex)
                    {
                        continue;
                    }


                    objDoctoBE.IID = objRecBE.IID = long.Parse(rowHd.Cells["GC_DOCTOID"].Value.ToString());
                    objDoctoBE.IOBSERVACION = TBObservaciones.Text;
                    objDoctoBE.IVENDEDORID = CurrentUserID.CurrentUser.IID;


                    if (!tbl.ContainsKey(objDoctoBE.IID) )
                    {
                        tbl.Add(objDoctoBE.IID, objDoctoBE.IID);


                        objDoctoBE.IFECHA = DateTime.Today;
                        objDoctoD.CambiarFECHA(objDoctoBE, fTrans);

                        if (m_tipodoctoId == DBValues._DOCTO_TIPO_COMPRA)
                            bRes = objDoctoD.COMPRA_COMPLETAR(objDoctoBE, fTrans);
                        else if (m_tipodoctoId == DBValues._DOCTO_TIPO_TRASPASO_REC)
                            bRes = objDoctoD.TRASLADO_COMPLETAR(objDoctoBE, fTrans);
                        else if (m_tipodoctoId == DBValues._DOCTO_TIPO_TRASPASO_ENVIO_DEVO)
                        {
                            objDoctoBE.IDOCTOIMPORTADOID = this.GetDoctoImportadoDeDocto(objDoctoBE.IID, fTrans);
                            bRes = objDoctoD.TRASLADODEVO_COMPLETAR(objDoctoBE, ref lDoctoNotaCredito, fTrans);
                        }
                        else if (m_tipodoctoId == DBValues._DOCTO_TIPO_PEDIDO_ENVIO_DEVO)
                        {
                            objDoctoBE.IDOCTOIMPORTADOID = this.GetDoctoImportadoDeDocto(objDoctoBE.IID, fTrans);
                            bRes = objDoctoD.PEDIDODEVO_COMPLETAR(objDoctoBE, ref lDoctoNotaCredito, fTrans);
                        }


                        //bRes = false;

                        if (bRes == false)
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            MessageBox.Show(objDoctoD.IComentario);
                            return;
                        }




                    }


                }


                fTrans.Commit();
                fConn.Close();


                
                objDoctoBE = objDoctoD.seleccionarDOCTO(objDoctoBE, null);
                if (objDoctoBE != null)
                {
                    m_tipodoctoId = objDoctoBE.ITIPODOCTOID;
                }

                if (  m_tipodoctoId == DBValues._DOCTO_TIPO_TRASPASO_REC)
                {
                    iPos.PosPrinter.ImprimirTicket(m_doctoId, Ticket._OPCION_IMPRESION_TRASLADO_RECEPCION);
                    if (bHayDevolucion)
                    {
                        iPos.PosPrinter.ImprimirTicket(m_doctoId, Ticket._OPCION_IMPRESION_TRASLADO_DEVOLUCION);
                    }
                }
                else if (m_tipodoctoId == DBValues._DOCTO_TIPO_COMPRA)
                {
                    iPos.PosPrinter.ImprimirTicket(m_doctoId, Ticket._OPCION_IMPRESION_COMPRA_RECEPCION);
                    if (bHayDevolucion)
                    {
                        iPos.PosPrinter.ImprimirTicket(m_doctoId, Ticket._OPCION_IMPRESION_COMPRA_DEVOLUCION);
                    }
                }
                else if (m_tipodoctoId == DBValues._DOCTO_TIPO_TRASPASO_ENVIO_DEVO)
                {

                    if(lDoctoNotaCredito > 0)
                    {
                        WFVentaDevolucion ventaDev = new WFVentaDevolucion(lDoctoNotaCredito, true);
                        ventaDev.ShowDialog();
                        ventaDev.Dispose();
                        GC.SuppressFinalize(ventaDev);
                    }
                    else
                    {

                        iPos.PosPrinter.ImprimirTicket(m_doctoId);
                    }
                }
                else if (m_tipodoctoId == DBValues._DOCTO_TIPO_PEDIDO_ENVIO_DEVO)
                {

                    if (lDoctoNotaCredito > 0)
                    {
                        WFVentaDevolucion ventaDev = new WFVentaDevolucion(lDoctoNotaCredito, true);
                        ventaDev.ShowDialog();
                        ventaDev.Dispose();
                        GC.SuppressFinalize(ventaDev);
                    }
                    else
                    {

                        iPos.PosPrinter.ImprimirTicket(m_doctoId);
                    }
                }
                else 
                {

                    iPos.PosPrinter.ImprimirTicket(m_doctoId);
                }

                

                MessageBox.Show("Se han confirmado con exito las importaciones");


                //exportando
                HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;

                if (m_tipodoctoId == DBValues._DOCTO_TIPO_TRASPASO_REC || m_tipodoctoId == DBValues._DOCTO_TIPO_TRASPASO_ENVIO_DEVO || m_tipodoctoId == DBValues._DOCTO_TIPO_PEDIDO_ENVIO_DEVO)
                    HiloExistencias._IFLAGRECEPCIONREGISTROTRASLAEVENTOS++;

                if (m_tipodoctoId == DBValues._DOCTO_TIPO_COMPRA)
                {
                    ExportarRecepcionDeCompra(null);

                    if (bHayDevolucion && CurrentUserID.CurrentParameters.IHAB_DEVOLUCIONSURTIDOSUC == "S")
                    {
                        ExportarPedidosDevo(m_doctoId);
                    }

                }
                else if (m_tipodoctoId == DBValues._DOCTO_TIPO_TRASPASO_REC)
                {
                    if (bHayDevolucion && CurrentUserID.CurrentParameters.IHAB_DEVOLUCIONTRASLADO == "S")
                    {
                        ExportarTrasladosDevo(m_doctoId);
                    }
                }

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




        private long  GetDoctoImportadoDeDocto(long doctoId, FbTransaction fTrans)
        {
            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoId;
            doctoBE = doctoD.seleccionarDOCTO(doctoBE, fTrans);
            if (doctoBE.IDOCTOIMPORTADOID != null)
            {
                return doctoBE.IDOCTOIMPORTADOID;
            }
            return 0;
        }


        private void ExportarTrasladosDevo(long doctoId)
        {


            CDOCTOD objDoctoD = new CDOCTOD();
            CDOCTOBE objDoctoBE = new CDOCTOBE();

            objDoctoBE.IID = doctoId;
            objDoctoBE = objDoctoD.seleccionarDOCTO(objDoctoBE, null);
            if(objDoctoBE == null)
            {
                MessageBox.Show("Hubo un error: no se encontro la informacion para devolucion");
                return;
            }

            ImportaDesdeFtp iDBF = new ImportaDesdeFtp();
            //string strResultado = "";
            ArrayList resultadosExportacion = new ArrayList();
            if (!iDBF.EnviarArchivosAFtpDeTrasladosDevo(ref resultadosExportacion, objDoctoBE.IFOLIO))
            {

                string strResultadoFinal = iDBF.IComentario + "\n";
                foreach (string strRes in resultadosExportacion)
                {
                    strResultadoFinal += strRes + "\n";
                }

                MessageBox.Show(strResultadoFinal);
            }
            else
                MessageBox.Show("La exportacion de la devolucion se ha realizado");


        }




        private void ExportarPedidosDevo(long doctoId)
        {


            CDOCTOD objDoctoD = new CDOCTOD();
            CDOCTOBE objDoctoBE = new CDOCTOBE();

            objDoctoBE.IID = doctoId;
            objDoctoBE = objDoctoD.seleccionarDOCTO(objDoctoBE, null);
            if (objDoctoBE == null)
            {
                MessageBox.Show("Hubo un error: no se encontro la informacion para devolucion");
                return;
            }

            ImportaDesdeFtp iDBF = new ImportaDesdeFtp();
            //string strResultado = "";
            ArrayList resultadosExportacion = new ArrayList();
            if (!iDBF.EnviarArchivosAFtpDePedidosDevo(ref resultadosExportacion, objDoctoBE.IFOLIO))
            {
                string strResultadoFinal = iDBF.IComentario + "\n";
                foreach (string strRes in resultadosExportacion)
                {
                    strResultadoFinal += strRes + "\n";
                }

                MessageBox.Show(strResultadoFinal);
            }
            else
                MessageBox.Show("La exportacion de la devolucion se ha realizado");


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
                if(row.Cells["GC_CANTIDAD"].Value != null)
                    row.Cells["GC_SURTIDA"].Value = row.Cells["GC_CANTIDAD"].Value;
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

            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals("SURTIDA")) return;

            try
            {
                decimal dSurtida = decimal.Parse(e.FormattedValue.ToString());
                decimal dCantidad = decimal.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString());
                if (dSurtida > dCantidad || dSurtida < 0)
                {
                    MessageBox.Show("La cantidad surtida no puede ser mayor que la cantidad del pedido ni menor que cero");
                    e.Cancel = true;
                }
                else if (dSurtida < dCantidad
                         && (iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells[10].Value == null || iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells[10].Value.ToString() == ""))
                {



                    WFSelRazonDiferencia look = new WFSelRazonDiferencia();
                    look.ShowDialog();

                    DataRow dr = look.m_rtnDataRow;

                    look.Dispose();
                    GC.SuppressFinalize(look);


                    if (dr != null)
                    {
                        iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells[10].Value = (long)dr[0];
                        iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells[11].Value = dr[7].ToString();
                    }
                    
                }
                else if(dSurtida == dCantidad)
                {

                    iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells[10].Value = null;
                    iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells[11].Value = "";
                }
            }
            catch
            {
            }

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


                case DBValues._DOCTO_TIPO_TRASPASO_ENVIO_DEVO:
                    {
                        sucursalBE = DatosSucursal(headerBE.ISUCURSALTID);
                        ticket.AddHeaderLine("REC. DE DEVOLUCION DE TRASLADO");
                    }
                    break;


                case DBValues._DOCTO_TIPO_PEDIDO_ENVIO_DEVO:
                    {
                        sucursalBE = DatosSucursal(headerBE.ISUCURSALTID);
                        ticket.AddHeaderLine("REC. DE DEVOLUCION DE PEDIDO");
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

                case DBValues._DOCTO_TIPO_TRASPASO_ENVIO_DEVO:
                    {
                        ticket.AddHeaderLine("REC. DE DEVO. TRASL. SUC. : " + sucursalBE.ICLAVE);
                        ticket.AddHeaderLine("SUCURSAL FUENTE: " + sucursalBE.INOMBRE);
                    }
                    break;


                case DBValues._DOCTO_TIPO_PEDIDO_ENVIO_DEVO:
                    {
                        ticket.AddHeaderLine("REC. DE DEVO. PEDIDO SUC. : " + sucursalBE.ICLAVE);
                        ticket.AddHeaderLine("SUCURSAL FUENTE: " + sucursalBE.INOMBRE);
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("pdoctoid", m_doctoId);
            dictionary.Add("usaDatosDeEntregaCuandoExista", "N");
            dictionary.Add("desglosekits", "N");

            string strReporte = "InformeRevisionPedido.frx";

            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema),dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }

        private void btnImprimirCorto_Click(object sender, EventArgs e)
        {
            LlenarDatosImpresion();
            ImprimirTicketRevision();
        }



        private void ImprimirTicketRevision()
        {

            
            CDOCTOD objDoctoD = new CDOCTOD();
            CDOCTOBE objDoctoBE = new CDOCTOBE();
            objDoctoBE.IID = m_doctoId;
            objDoctoBE = objDoctoD.seleccionarDOCTO(objDoctoBE, null);

            if(objDoctoBE == null)
                return;

            Ticket ticket = new Ticket();

            if (objDoctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA)
            {
                ticket.AddHeaderLine("Impresión para revisión recepcion compra");
            }
            else
            {
                ticket.AddHeaderLine("Impresión para revisión recepcion trasl.");
                CSUCURSALD sucursalD = new CSUCURSALD();
                CSUCURSALBE sucursalBE = new CSUCURSALBE();
                sucursalBE.IID = objDoctoBE.ISUCURSALTID;
                sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);
                if(sucursalBE != null)
                {

                    ticket.AddHeaderLine("De la sucursal  : " + sucursalBE.INOMBRE);
                }
            }

            ticket.AddHeaderLine("Impresión para revisión");
            ticket.AddHeaderLine("Fecha           : " + DateTime.Now.ToShortDateString());
            ticket.AddHeaderLine("Hora            : " + DateTime.Now.ToShortTimeString());
            ticket.AddHeaderLine("Archivo recibir : " + objDoctoBE.IREFERENCIAS);
            ticket.AddHeaderLine("Referencia      : " + objDoctoBE.IREFERENCIA);

            



            try
            {



                //this.gET_TICKET_ABONOTableAdapter.Fill(this.dataSet1.GET_TICKET_ABONO, m_doctoPago.IID);

                if (this.dSImportaciones.PEDIDODETALLEIMPRESION.Rows.Count <= 0)
                    return;

                foreach (iPos.Importaciones.DSImportaciones.PEDIDODETALLEIMPRESIONRow dr in this.dSImportaciones.PEDIDODETALLEIMPRESION.Rows)
                {
                    ticket.AddHeaderLine(new string(' ', Ticket.maxChar));
                    ticket.AddHeaderLine(Ticket.FormatPrintField(dr.DESCRIPCION1, Ticket.maxChar - 1, 1));

                    if (!dr.IsPZACAJANull() && dr.PZACAJA > 1)
                    {
                        decimal cajas = Math.Truncate(dr.CANTIDAD / dr.PZACAJA);
                        decimal pzas = Math.Truncate(dr.CANTIDAD % dr.PZACAJA);
                        string strCajasPzas = cajas.ToString("N0") + " cajas " + pzas.ToString("N0") + " pzas";
                        ticket.AddHeaderLine(Ticket.FormatPrintField(strCajasPzas, Ticket.maxChar - 1, 1));

                    }
                    else
                    {
                        ticket.AddHeaderLine(Ticket.FormatPrintField(dr.CANTIDAD.ToString("N3"), Ticket.maxChar - 1, 1));
                    }

                }



                ticket.AddFooterLine("");

                ticket.PrintTicketDirect(CurrentUserID.currentPrinter);//"IposPrinter3");


                MessageBox.Show("Se mando imprimir el ticket corto");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error , no se pudo imprimer el ticket " + ex.Message + " " + ex.StackTrace);
                this.Close();
            }


        }


        private void LlenarDatosImpresion()
        {
            try
            {
                this.pEDIDODETALLEIMPRESIONTableAdapter.Fill(this.dSImportaciones.PEDIDODETALLEIMPRESION, (int)m_doctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
