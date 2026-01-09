using DataLayer.Importaciones;
using FirebirdSql.Data.FirebirdClient;
using iPosBusinessEntity;
using iPosData;
using iPosReporting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Importaciones
{
    public partial class WFDetallePedidoMovil : Form
    {
        private long doctoId;
        private ImportarDBF impDbfHelper;
        bool bTieneDerechoRutaEmbarque = false;
        private string m_strFileLog = "";
        private CDOCTOBE m_docto = null;
        private CPERSONABE m_cliente = null;

        bool bTieneDerechoImprimirTicket = true;
        bool bTieneDerechoImprimirReciboLargo = true;

        public WFDetallePedidoMovil()
        {
            InitializeComponent();
            impDbfHelper = new ImportarDBF();
        }

        public WFDetallePedidoMovil(long doctoId) : this()
        {
            this.doctoId = doctoId;
        }
        

        private void WFDetallePedidoMovil_Load(object sender, EventArgs e)
        {
            //checar si se necesita especificar ruta de embarque
            CUSUARIOSD usersD = new CUSUARIOSD();
            if (!usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._PONER_RUTA_EMBARQUE_EN_VENTA, null))
            {
                bTieneDerechoRutaEmbarque = false;
            }
            else
            {
                bTieneDerechoRutaEmbarque = true;
            }

            bTieneDerechoImprimirTicket = usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_IMPRIMIR_TICKETPEDIDOMOVIL, null);
            bTieneDerechoImprimirReciboLargo = usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_RECIBOLARGO_TICKETPEDIDOMOVIL, null);
            btnImprimirTicket.Visible = bTieneDerechoImprimirReciboLargo;
            btnImprimirTicket.Visible = bTieneDerechoImprimirTicket;


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

            PEDIDO_MOVIL_ENSAMBLE((int)doctoId, CurrentUserID.CurrentUser.IID);

            dETALLE_PEDIDO_MOVILDataGridView.Columns["CANTIDADAENVIAR"].Visible = btnAjustarExistencias.Visible =  CurrentUserID.CurrentParameters.IMOVIL3_PREIMPORTAR == "S";

            //LlenarGrid(doctoId);



            CDOCTOD doctoD = new CDOCTOD();
            CPERSONAD clienteD = new CPERSONAD();
            m_docto = new CDOCTOBE();
            m_docto.IID = doctoId;
            m_docto = doctoD.seleccionarDOCTO(m_docto, null);
             
            if(m_docto != null)
            {
                m_cliente = new CPERSONABE();
                m_cliente.IID = m_docto.IPERSONAID;
                m_cliente = clienteD.seleccionarPERSONA(m_cliente, null);

                if (m_cliente != null)
                {
                    if (m_cliente.IBLOQUEADO != null && m_cliente.IBLOQUEADO.Equals("S"))
                    {
                        LBEstatusCliente.Text = "Cliente bloqueado";
                    }
                }

            }

            LlenarGridAndAjustarAExistencias();


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

        private void LlenarGrid(long doctoId)
        {
            int almacenId = 0;
            if (CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"))
            {
                almacenId = (int)this.ObtainAlmacenId();
            }
            dETALLE_PEDIDO_MOVILTableAdapter1.Fill(dSImportaciones3.DETALLE_PEDIDO_MOVIL,
                                                  almacenId, (int)doctoId);
        }

        private long preguntarAsignarRutaEmbarque()
        {

            iPos.PuntoDeVenta.WFSeleccionarRutaEmbarque sre = new PuntoDeVenta.WFSeleccionarRutaEmbarque(true);
            sre.ShowDialog();

            long reId = sre.rutaEmbarqueId;

            sre.Dispose();
            GC.SuppressFinalize(sre);

            return reId;

        }

        private bool CambiarRutaEmbarque(long doctoId, long rutaEmbarqueId, FbTransaction fTrans)
        {
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoId;
            doctoBE.IRUTAEMBARQUEID = rutaEmbarqueId;

            CDOCTOD doctoD = new CDOCTOD();
            if (!doctoD.CambiarRutaEmbarqueDOCTOD(doctoBE, null))
            {
                throw new Exception("Error al actualizar la ruta de embarque " + doctoD.IComentario);
            }
            return true;
        }


        private bool CambiarVendedorCajero(long doctoId, long vendedorCajeroId, FbTransaction fTrans)
        {
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoId;
            doctoBE.IVENDEDORID = vendedorCajeroId;

            CDOCTOD doctoD = new CDOCTOD();
            if (!doctoD.CambiarVendedorCajeroDOCTOD(doctoBE, null))
            {
                throw new Exception("Error al actualizar el vendedor " + doctoD.IComentario);
            }
            return true;
        }


        private bool CambiarCantidadASurtir(FbTransaction fTrans)
        {
            CMOVTOD daoMovto = new CMOVTOD();
            foreach (DataGridViewRow row in dETALLE_PEDIDO_MOVILDataGridView.Rows)
            {
                long movtoID = long.Parse(row.Cells["DG_ID"].Value.ToString());
                decimal cantidadASurtir = decimal.Parse(row.Cells["CANTIDADAENVIAR"].Value.ToString());

                if(!daoMovto.CambiarCantidadSurtida(movtoID, cantidadASurtir, fTrans))
                {
                    return  false;
                }

            }
            return true;
        }






        private bool procesarVenta(long doctoId, long rutaEmbarqueId, bool imprimirFactura, bool imprimirRecibo, bool marcarComoFacturacionPendiente)
        {
            long doctoVentaId = 0;
            long doctoPago = 0;
            string message = String.Empty;


            //pregunta ruta de embarque si aplica
            if (bTieneDerechoRutaEmbarque && rutaEmbarqueId == 0)
            {
                rutaEmbarqueId = preguntarAsignarRutaEmbarque();
                if (rutaEmbarqueId == 0)
                {
                    MessageBox.Show("Debe definir una ruta de embarque");
                    return false;
                }
            }


            //obtenemos los datos del docto para conocer algunos detalles utiles
            CDOCTOBE docto = new CDOCTOBE();
            docto.IID = doctoId;
            CDOCTOD doctoD = new CDOCTOD();
            docto = doctoD.seleccionarDOCTO(docto, null);
            if (docto == null)
            {
                MessageBox.Show("El pedido no existe");
                return false;
            }


            //estado rebaja
            if (docto.IESTADOREBAJA == DBValues._ESTADOREBAJA_PENDIENTE)
            {
                MessageBox.Show("Venta por autorizar rebaja");
                return false;
            }
            else if (docto.IESTADOREBAJA == DBValues._ESTADOREBAJA_PENDIENTEXPRECIOMIN)
            {
                
                MessageBox.Show("Venta por autorizar precio abajo del minimo ");
                return false;
            }


            bool bEsFacturaElectronica = docto.IESFACTURAELECTRONICA != null && docto.IESFACTURAELECTRONICA.Equals("S");



            CSURTIDOD surtidoD = new CSURTIDOD();
            if (docto.IESTADOSURTIDOID != DBValues._DOCTO_SURTIDOESTADO_SURTIDO && docto.IMOVILCONTADO == "N" )
            {
                if (m_cliente != null && m_cliente.IBLOQUEADO != null && m_cliente.IBLOQUEADO.Equals("S"))
                {
                    MessageBox.Show("El cliente esta bloqueado");
                    if (docto.IESTADOSURTIDOID != DBValues._DOCTO_SURTIDOESTADO_CXC)
                    {
                        surtidoD.SURTIDO_ASIGNARESTADO(doctoId, "por proceso automatico movil", DBValues._DOCTO_SURTIDOESTADO_CXC, CurrentUserID.CurrentUser.IID, null);
                    }
                    return false;
                }

                if (m_cliente != null && m_cliente.ILIMITECREDITO > 0 && m_cliente.ILIMITECREDITO < (m_cliente.ISALDO * -1) + docto.ITOTAL)
                {


                    if (MessageBox.Show("En esta venta " + docto.IFOLIO.ToString() + "se sobrepasaria el limite de credito del cliente  " + m_cliente.INOMBRE + " , ¿Realmente desea hacerlo? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        long usuarioAutorizoBajoCredito = 0;
                        bool bTieneDerechoAVenderEncimadelCredito = false;
                        bool bCombinacionValida = false;
                        bool autorizacionBajoCredito = preguntarAutorizacionAbajoDelCredito(ref usuarioAutorizoBajoCredito,
                                                                                            ref bTieneDerechoAVenderEncimadelCredito,
                                                                                            ref bCombinacionValida);

                        if (!autorizacionBajoCredito)
                        {
                            if (docto.IESTADOSURTIDOID != DBValues._DOCTO_SURTIDOESTADO_CXC)
                            {
                                surtidoD.SURTIDO_ASIGNARESTADO(doctoId, "por proceso automatico movil", DBValues._DOCTO_SURTIDOESTADO_CXC, CurrentUserID.CurrentUser.IID, null);
                            }

                            if (!bCombinacionValida)
                            {
                                MessageBox.Show("Combinacion invalida");
                                return false;
                            }

                            if (!bTieneDerechoAVenderEncimadelCredito)
                            {
                                MessageBox.Show("Este usuario no tiene derechos (10020)");
                                return false;
                            }
                        }
                        else
                        {

                            if(!PreguntaComentarioAutorizacion(docto.IID, usuarioAutorizoBajoCredito, null))
                            {

                                MessageBox.Show("Debe agregar un comentario de autorizacion");
                                return false;
                            }

                            docto.IESTADOSURTIDOID = DBValues._DOCTO_SURTIDOESTADO_SURTIDO;
                            surtidoD.SURTIDO_ASIGNARESTADO(doctoId, "por proceso automatico movil", DBValues._DOCTO_SURTIDOESTADO_SURTIDO, usuarioAutorizoBajoCredito, null);
                            
                        }

                    }
                    else
                    {
                        return false;

                    }
                }
            }

            if (docto.IESTADOSURTIDOID == DBValues._DOCTO_SURTIDOESTADO_CXC && docto.IMOVILCONTADO == "N" && CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO != "S")
            {
                surtidoD.SURTIDO_ASIGNARESTADO(doctoId, "por proceso automatico movil", 0, CurrentUserID.CurrentUser.IID, null);
            }


            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;


            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();


                //actualiza la ruta de embarque si aplica
                if (rutaEmbarqueId != 0)
                {
                    CambiarRutaEmbarque(doctoId, rutaEmbarqueId, fTrans);
                }

                //cambiamos el vendedor para que se tome el usuario actualmente loguead
                //pero mantenemos el vendedorfinal que es el vendedor que hizo efectivamente la venta
                CambiarVendedorCajero(doctoId, CurrentUserID.CurrentUser.IID, fTrans);


                if (CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"))
                {
                    long almacenId = ObtainAlmacenId();
                    doctoD.CambiarALMACENID(doctoId, almacenId, fTrans);
                }


                if (CurrentUserID.CurrentParameters.IMOVIL3_PREIMPORTAR == "S")
                {
                    if(!CambiarCantidadASurtir(fTrans))
                    {
                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show("Problema al cambiar las cantidades a surtir. ");
                        return false;
                    }
                }

                bool success = impDbfHelper.PEDIDO_MOVIL_COMPLETAR(doctoId, ref doctoVentaId, ref doctoPago, fTrans);


                if (!success)
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("Problema al procesar: " + impDbfHelper.IComentario);
                    return false;
                }




                CDOCTOBE doctoGenerado = new CDOCTOBE();
                CDOCTOBE doctoAFacturar = new CDOCTOBE();
                doctoGenerado.IID = doctoVentaId;
                doctoGenerado = doctoD.seleccionarDOCTO(doctoGenerado, fTrans);
                if (doctoGenerado == null)
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("hubo un error no se proceso el registro ");
                    return false;
                }


                if (bEsFacturaElectronica)
                {

                    if (doctoGenerado.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
                    {
                        doctoAFacturar.IID = doctoGenerado.IDOCTOREFID;
                        doctoAFacturar = doctoD.seleccionarDOCTO(doctoAFacturar, fTrans);

                    }
                    else
                    {
                        doctoAFacturar = doctoGenerado;
                    }

                    if (marcarComoFacturacionPendiente)
                    {

                        docto.IFOLIOSAT = -3;
                        //if (!doctoD.CambiarFOLIOSATDOCTOD(docto, fTrans))
                        if (!doctoD.CambiarFOLIOSATDOCTOD(doctoAFacturar, fTrans))
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            MessageBox.Show("No se pudo marcar para facturacion pendiente " + doctoD.IComentario);

                            return false;

                        }
                    }
                    else
                    {

                        string resComentario = "";

                        //if (!generarFacturaElectronicaPorId(doctoVentaId, fTrans, ref resComentario))
                        if (!generarFacturaElectronicaPorId(doctoAFacturar.IID, fTrans, ref resComentario))
                        {

                            fTrans.Rollback();
                            fConn.Close();
                            MessageBox.Show("No se pudo realizar la facturacion " + resComentario);
                            if (m_strFileLog != null && m_strFileLog.Trim().Length > 0)
                            {
                                Process.Start("notepad.exe", m_strFileLog);
                            }




                            if (MessageBox.Show("Desea que la venta se remisione y quede pendiente la facturacion?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                return procesarVenta(doctoId, rutaEmbarqueId, imprimirFactura, imprimirRecibo, true);
                            }


                            return false;

                        }
                    }



                }


                fTrans.Commit();
                fConn.Close();

                if (doctoGenerado.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA)
                {
                    APLICARCUPONES_SIESNECESARIO(doctoVentaId, null);
                }

                


                if (doctoGenerado.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO
                    && doctoGenerado.IESTADOSURTIDOID != DBValues._DOCTO_SURTIDOESTADO_PENDIENTE)
                {

                    ExportarTraslados(doctoGenerado.IFOLIO);
                }



                if (bEsFacturaElectronica && imprimirFactura && !marcarComoFacturacionPendiente)
                    imprimirFacturaElectronicaPorId(doctoVentaId);

                if (imprimirRecibo)
                {
                    PosPrinter.ImprimirTicket(doctoVentaId, 0, false);

                    PosPrinter.ImprimirCuponesSiAplica(doctoVentaId, null);
                }

                return true;
            }
            catch (Exception exception)
            {
                fTrans.Rollback();
                fConn.Close();

                MessageBox.Show(exception.Message);

                return false;
            }


        }



        private bool APLICARCUPONES_SIESNECESARIO(long doctoId, FbTransaction fTrans)
        {
            if (CurrentUserID.CurrentParameters.IMANEJACUPONES.Equals("N"))
            {
                return true;
            }
            else
            {
                CPROMOCIOND promocionDao = new CPROMOCIOND();
                string hayCuponesAplicados = "";
                try
                {
                    return promocionDao.APLICAPROMOCIONESCUPONES(doctoId, ref hayCuponesAplicados, fTrans);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


        private bool PreguntaComentarioAutorizacion(long doctoId, long usuarioId, FbTransaction ftrans)
        {
            string comentarioAut = "";
            WFPreguntaComentario wf1_ = new WFPreguntaComentario();
            wf1_.ShowDialog();
            comentarioAut = wf1_.m_comentario.Trim();
            wf1_.Dispose();
            GC.SuppressFinalize(wf1_);

            if (comentarioAut != null && comentarioAut.Trim().Length > 0)
            {
                CDOCTOD doctoD = new CDOCTOD();
                doctoD.CambiarDOCTONOTASET(doctoId, DBValues._TIPODOCTONOTA_AUTORIZACION, DateTime.Now, usuarioId , comentarioAut, null);

                return true;
            }

            return false;

        }


        private bool PEDIDO_MOVIL_ENSAMBLE(long doctoId, long vendedorId)
        {

            FbConnection connection = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction transaction = null;


            bool bResult = true;
            

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                if(!impDbfHelper.PEDIDO_MOVIL_ENSAMBLE(doctoId,vendedorId, transaction))
                {

                    throw new Exception("Error: " + impDbfHelper.IComentario);
                }
                

                transaction.Commit();

            }
            catch (Exception exception)
            {
                transaction.Rollback();
                bResult = false;
                MessageBox.Show("Error: " + exception.Message + " StackTrace: " + exception.StackTrace);

            }
            finally
            {
                connection.Close();
            }
            

            return bResult;
        }



        private void procesarButton_Click(object sender, EventArgs e)
        {


            if (m_cliente != null)
            {
                if (m_cliente.IBLOQUEADO != null && m_cliente.IBLOQUEADO.Equals("S"))
                {
                    MessageBox.Show( "El cliente esta bloqueado");
                    return;
                }
            }



            if (procesarVenta(doctoId, 0, true, true, false))
            {

                MessageBox.Show("Proceso terminado con éxito.");
                this.Close();
            }

       
            
        }



        private bool generarFacturaElectronicaPorId(long doctoId, FbTransaction fTrans, ref string resComentario)
        {

            CDOCTOBE docto = new CDOCTOBE();
            CDOCTOD doctoD = new CDOCTOD();
            docto.IID = doctoId;
            docto = doctoD.seleccionarDOCTO(docto, fTrans);

            if (docto == null)
            {

                resComentario = "No se encontro la factura electronica";
                return false;
            }

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (docto.IFECHAHORA.Month != DateTime.Now.Month)
            {
                if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_FACTURARFUERADEMES, fTrans))
                {
                    resComentario = "No tiene derecho para facturar una remision fuera de este mes";
                    return false;
                }
            }



            bool retorno = false;





            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR, fTrans, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            fe.m_silentMode = true;
            fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            m_strFileLog = fe.m_strFileLog;
            fe.Dispose();
            GC.SuppressFinalize(fe);

            if (retorno)
            {
                docto.IESFACTURAELECTRONICA = "S";
                doctoD.ACTUALIZARESFACTURAELECTRONICA(docto, fTrans);
            }

            return retorno;
        }


        private bool imprimirFacturaElectronicaPorId(long doctoId)
        {

            bool retorno;

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE docto = new CDOCTOBE();
            docto.IID = doctoId;
            docto = doctoD.seleccionarDOCTO(docto, null);

            if (docto == null)
            {

                MessageBox.Show("No se encontro la factura electronica");
                return false;
            }


            if ((bool)docto.isnull["IFOLIOSAT"] || (bool)docto.isnull["IESTATUSDOCTOID"]
                || docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || docto.IFOLIOSAT <= 0)
            {
                MessageBox.Show("No se puede imprimir la factura electronica , cheque que se haya generado la factura electronica de este registro");
                return false;
            }


            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(docto, CurrentUserID.CurrentParameters, iPosReporting.WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_GENERARPDF, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;
        }




        private bool imprimirTicketFacturaElectronicaPorId(long doctoId)
        {
            bool retorno;

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoId;
            doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

            if ((bool)doctoBE.isnull["IFOLIOSAT"] || (bool)doctoBE.isnull["IESTATUSDOCTOID"]
               || doctoBE.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || doctoBE.IFOLIOSAT <= 0)
            {
                MessageBox.Show("No se puede imprimir la factura electronica , cheque que se haya generado la factura electronica de este registro");
                return false;
            }


            WFFacturaElectronica fe = new WFFacturaElectronica(doctoBE, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_IMPRIMIRTICKET, doctoBE, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.m_bForzarImpresionTicket = true;
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;

        }

        private void LlenarGridAndAjustarAExistencias()
        {
            this.LlenarGrid(this.m_docto.IID);

            foreach (DataGridViewRow row in dETALLE_PEDIDO_MOVILDataGridView.Rows)
            {

                if (row.Index == dETALLE_PEDIDO_MOVILDataGridView.NewRowIndex)
                {
                    continue;
                }

                decimal existencia = 0, cantAux = 0, cantidadEnviar = 0;
                try
                {
                    cantAux = Decimal.Parse(row.Cells["DG_CANTIDAD"].Value.ToString());
                    try { existencia = Decimal.Parse(row.Cells["DG_EXISTENCIA"].Value.ToString());  } catch { existencia = 0; }
                    
                    if (existencia > cantAux)
                    {
                        cantidadEnviar = cantAux;
                    }
                    else
                    {
                        cantidadEnviar = existencia;
                    }
                }
                catch
                {
                }

                row.Cells["CANTIDADAENVIAR"].Value = cantidadEnviar;
            }
        }

        private void btnAjustarExistencias_Click(object sender, EventArgs e)
        {
            LlenarGridAndAjustarAExistencias();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            Boolean usuarioTienePermisoDesgloseKit = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null);
            long dgDoctoId = doctoId;

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("pdoctoid", dgDoctoId);
            dictionary.Add("usaDatosDeEntregaCuandoExista", "N");
            dictionary.Add("desglosekits", usuarioTienePermisoDesgloseKit ? "S" : "N");
            dictionary.Add("creadoPorUserId", 0);
            string strReporte = "recibolargo.frx";


            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.deusuario), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }

        private void btnImprimirTicket_Click(object sender, EventArgs e)
        {

            try
            {
                PosPrinter.ImprimirTicket(doctoId, 0, true);

            }
            catch (Exception ex)
            {
            }
        }

        private void ALMACENComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {

            //LlenarGrid(this.m_docto.IID);
            LlenarGridAndAjustarAExistencias();
        }



        private bool preguntarAutorizacionAbajoDelCredito(ref long usuarioId, ref bool bTieneDerechoAVenderEncimadelCredito, ref bool bCombinacionValida)
        {
            usuarioId = 0;
            bCombinacionValida = true;
            bTieneDerechoAVenderEncimadelCredito = false;


            WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion();
            ps2.ShowDialog();
            CPERSONABE userBE = ps2.m_userBE;
            bool bPassValido = ps2.m_bPassValido;
            ps2.Dispose();
            GC.SuppressFinalize(ps2);

            if (!bPassValido || userBE == null)
            {
                bCombinacionValida = false;
                return false;
            }

            CUSUARIOSD usersD = new CUSUARIOSD();
            bTieneDerechoAVenderEncimadelCredito = usersD.UsuarioTienePermisos((int)userBE.IID, (int)DBValues._DERECHO_VENDERCONCREDITOEXCEDIDO, null);

            if (!bTieneDerechoAVenderEncimadelCredito)
            {
                return false;
            }

            usuarioId = userBE.IID;

            return true;

        }


        private void ExportarTraslados(int folio)
        {


            ImportaDesdeFtp iDBF = new ImportaDesdeFtp();
            //string strResultado = "";

            ArrayList resultadosExportacion = new ArrayList();
            if (!iDBF.EnviarArchivosAFtpDeTraslados(ref resultadosExportacion, folio))
            {

                StringBuilder strBuffer = new StringBuilder("");
                strBuffer.Append(iDBF.IComentario + "\n");
                foreach (string str in resultadosExportacion)
                {
                    strBuffer.Append(str);
                }
                MessageBox.Show("Error en la exportacion, se intentara mas tarde: " + strBuffer.ToString() + "\n");
            }
            else
                MessageBox.Show("La exportacion del traslado se ha realizado");


        }



    }
}
