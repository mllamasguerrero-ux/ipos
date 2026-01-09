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
    public partial class WFImpPedidosMovPorVendedor : Form
    {
        private long vendedorId;
        private int enRuta;
        private string coti_enrutada;
        private ImportarDBF impDbfHelper;
        bool bTieneDerechoRutaEmbarque = false;
        bool bTieneDerechoEliminarPedido = false;
        private string vendedorClave = "";

        private string m_strFileLog = "";


        private bool m_loadingForm = true;
        bool m_usuarioPuedeCambiarAlmacen = false;

        public WFImpPedidosMovPorVendedor()
        {
            InitializeComponent();
            impDbfHelper = new ImportarDBF();
        }

        public WFImpPedidosMovPorVendedor(long vendedorId, int enRuta, string coti_enrutada) : this()
        {
            this.vendedorId = vendedorId;
            this.enRuta = enRuta;
            this.coti_enrutada = coti_enrutada;
        }

        public WFImpPedidosMovPorVendedor(long vendedorId, int enRuta) : this(vendedorId, enRuta,"N")
        {
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            
        }

        private void WFImpPedidosMovPorVendedor_Load(object sender, EventArgs e)
        {
            CPERSONABE persona = new CPERSONABE();
            CPERSONAD personaDao = new CPERSONAD();

            persona = personaDao.SeleccionarPersonaPorId(vendedorId, null);

            datosVendedorLabel.Text = persona.ICLAVE + "-" + persona.INOMBRE;

            vendedorClave = persona.ICLAVE;


            CUSUARIOSD usersD = new CUSUARIOSD();
            if (!usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._PONER_RUTA_EMBARQUE_EN_VENTA, null))
            {
                bTieneDerechoRutaEmbarque = false;
            }
            else
            {
                bTieneDerechoRutaEmbarque = true;
            }

            if (!usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_ELIMINARVENTAMOVIL, null))
            {
                bTieneDerechoEliminarPedido = false;
            }
            else
            {
                bTieneDerechoEliminarPedido = true;
            }



            if (CurrentUserID.CurrentParameters.IMOVIL3_PREIMPORTAR == "S")
            {
                procesarTodosButton.Visible = false;
                iNFO_PEDIDOS_MOVIL_X_VENDEDORDataGridView.Columns["PROCESAR"].Visible = false;
            }

            //llenar almacen
            if (CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"))
            {
                m_usuarioPuedeCambiarAlmacen = usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CAMBIARDEALMACEN, null);

                this.ALMACENComboBox.llenarDatos();
                this.pnlAlmacen.Visible = true;
                this.pnlAlmacen.Enabled = m_usuarioPuedeCambiarAlmacen;

                this.ALMACENComboBox.SelectedDataValue = CurrentUserID.CurrentUser.IALMACENID != 0 ? CurrentUserID.CurrentUser.IALMACENID : DBValues._DOCTO_ALMACEN_DEFAULT;
            }
            else
            {
                this.pnlAlmacen.Visible = false;
            }

            LlenarGrid();

            m_loadingForm = false;

        }


        private void LlenarGrid()
        {
            long almacenId = CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S")  ? long.Parse(this.ALMACENComboBox.SelectedDataValue.ToString()) : 0;



            iNFO_PEDIDOS_MOVIL_X_VENDEDORTableAdapter.Fill(dSImportaciones.INFO_PEDIDOS_MOVIL_X_VENDEDOR,
                                                             enRuta.ToString(), DateTime.Today.AddDays(-5),
                                                            (int)vendedorId,
                                                            0, (int)almacenId, this.coti_enrutada);


            FijarColorVendedorEnRuta();


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

        private void iNFO_PEDIDOS_MOVIL_X_VENDEDORDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            long doctoId = (long)iNFO_PEDIDOS_MOVIL_X_VENDEDORDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;
            if (iNFO_PEDIDOS_MOVIL_X_VENDEDORDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString().Equals("VER"))
            {
                
                WFDetallePedidoMovil wf = new WFDetallePedidoMovil(doctoId);
                wf.ShowDialog();
                wf.Dispose();
                GC.SuppressFinalize(wf);
                LlenarGrid();
            }
            else if(iNFO_PEDIDOS_MOVIL_X_VENDEDORDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString().Equals("PROCESAR"))
            {
                string errorProceso = "";
                long almacenId = ObtainAlmacenId();
                bool result = procesarVenta(doctoId, 0, true, true,false, almacenId, out errorProceso);
                if (!result && errorProceso != "" && errorProceso != null)
                    MessageBox.Show(errorProceso);

                LlenarGrid();
            }
            else if (iNFO_PEDIDOS_MOVIL_X_VENDEDORDataGridView.Columns[e.ColumnIndex].Name.Equals("DGELIMINAR"))
            {

                if(!bTieneDerechoEliminarPedido)
                {
                    MessageBox.Show("No tiene derecho a eliminar pedido");
                    return;
                }


                if (MessageBox.Show("Desea eliminar el registro? ",
                                    "Confirmacion",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    eliminarVenta(doctoId, 0, true, true, false);
                    LlenarGrid();
                }
            }


        }




        private bool procesarVenta(long doctoId, long rutaEmbarqueId, bool imprimirFactura, bool imprimirRecibo, bool marcarComoFacturacionPendiente, long almacenId, out string error )
        {
            long doctoVentaId = 0;
            long doctoPago = 0;
            string message = String.Empty;

            error = "";


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
            if(docto.IESTADOREBAJA == DBValues._ESTADOREBAJA_PENDIENTE)
            {
                error = "pendiente de autorizar rebaja";
                MessageBox.Show("Venta por autorizar rebaja");
                return false;
            }
            else if(docto.IESTADOREBAJA == DBValues._ESTADOREBAJA_PENDIENTEXPRECIOMIN)
            {

                error = "pendiente de autorizar precio abajo del minimo";
                MessageBox.Show("Venta por autorizar precio abajo del minimo ");
                return false;
            }


            CSURTIDOD surtidoD = new CSURTIDOD();
            if ( docto.IESTADOSURTIDOID != DBValues._DOCTO_SURTIDOESTADO_SURTIDO  && 
                 (docto.IMOVILCONTADO == "N" || docto.ICOTI_ENRUTADA == "S") )
            {
                CPERSONAD clienteD = new CPERSONAD();
                CPERSONABE clienteBE = new CPERSONABE();
                clienteBE.IID = docto.IPERSONAID;
                clienteBE = clienteD.seleccionarPERSONA(clienteBE, null);

                if (clienteBE != null)
                {
                    if (clienteBE.IBLOQUEADO != null && clienteBE.IBLOQUEADO.Equals("S"))
                    {
                        //MessageBox.Show("El cliente esta bloqueado");
                        error = "bloqueado";
                        if (docto.IESTADOSURTIDOID != DBValues._DOCTO_SURTIDOESTADO_CXC)
                        {
                            surtidoD.SURTIDO_ASIGNARESTADO(doctoId, "por proceso automatico movil", DBValues._DOCTO_SURTIDOESTADO_CXC, CurrentUserID.CurrentUser.IID, null);
                        }
                        return false;
                    }

                    if (clienteBE.ILIMITECREDITO > 0 && clienteBE.ILIMITECREDITO < (clienteBE.ISALDO * -1) + docto.ITOTAL)
                    {


                        if (MessageBox.Show("En esta venta " + docto.IFOLIO.ToString() + "se sobrepasaria el limite de credito del cliente  " + clienteBE.INOMBRE + " , ¿Realmente desea hacerlo? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            }


            if (docto.IESTADOSURTIDOID == DBValues._DOCTO_SURTIDOESTADO_CXC && docto.IMOVILCONTADO == "N" && CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO != "S")
            {
                surtidoD.SURTIDO_ASIGNARESTADO(doctoId, "por proceso automatico movil", 0, CurrentUserID.CurrentUser.IID, null);
            }



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



            bool bEsFacturaElectronica = docto.IESFACTURAELECTRONICA != null && docto.IESFACTURAELECTRONICA.Equals("S");



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
                    doctoD.CambiarALMACENID(doctoId, almacenId, fTrans);
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


                    if(doctoGenerado.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
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

                        //docto.IFOLIOSAT = -3;
                        doctoAFacturar.IFOLIOSAT = -3;
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
                                return procesarVenta(doctoId, rutaEmbarqueId, imprimirFactura, imprimirRecibo, true,almacenId, out error);
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


        private bool eliminarVenta(long doctoId, long rutaEmbarqueId, bool imprimirFactura, bool imprimirRecibo, bool marcarComoFacturacionPendiente)
        {
            string message = String.Empty;

            


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

            bool bEsFacturaElectronica = docto.IESFACTURAELECTRONICA != null && docto.IESFACTURAELECTRONICA.Equals("S");



            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;


            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if(!doctoD.BorrarDOCTO(docto,fTrans))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("No se pudo borrar el registro ");
                    return false;

                }

                fTrans.Commit();
                fConn.Close();
                

                return true;
            }
            catch (Exception exception)
            {
                fTrans.Rollback();
                fConn.Close();

                MessageBox.Show(exception.Message);

                return false;
            }
            finally
            {
                fConn.Close();
            }
            


        }

        private void FijarColorVendedorEnRuta()
        {
            foreach (DataGridViewRow row in iNFO_PEDIDOS_MOVIL_X_VENDEDORDataGridView.Rows)
            {
                row.DefaultCellStyle.BackColor = enRuta == 0 ? Color.White : Color.Yellow;
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
            fe.m_vendedorId = CurrentUserID.CurrentUser.IID;
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




        private long  preguntarAsignarRutaEmbarque()
        {

            iPos.PuntoDeVenta.WFSeleccionarRutaEmbarque sre = new PuntoDeVenta.WFSeleccionarRutaEmbarque(true);
            sre.ShowDialog();

            long reId = sre.rutaEmbarqueId;

            sre.Dispose();
            GC.SuppressFinalize(sre);

            return reId;
            
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


        private bool CambiarRutaEmbarque(long doctoId, long rutaEmbarqueId, FbTransaction fTrans)
        {
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoId;
            doctoBE.IRUTAEMBARQUEID = rutaEmbarqueId;

            CDOCTOD doctoD = new CDOCTOD();
            if (!doctoD.CambiarRutaEmbarqueDOCTOD(doctoBE, null))
            {
                throw new Exception("Error al actualizar la ruta de embarque " +  doctoD.IComentario);
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


        private void procesarTodosButton_Click(object sender, EventArgs e)
        {
            string message = String.Empty;


            //pregunta ruta de embarque si aplica
            long rutaEmbarqueId = 0;
            if(bTieneDerechoRutaEmbarque)
            {
                rutaEmbarqueId = preguntarAsignarRutaEmbarque();
                if(rutaEmbarqueId == 0)
                {
                    MessageBox.Show("Debe definir una ruta de embarque");
                    return;
                }
            }
            

            try
            {
                int registrosConErrorBloqueo = 0;
                foreach (DataGridViewRow row in iNFO_PEDIDOS_MOVIL_X_VENDEDORDataGridView.Rows)
                {
                    long doctoId = (long)row.Cells["DGID"].Value;
                    long almacenId = ObtainAlmacenId();
                    string errorProceso = "";
                    if (!this.procesarVenta(doctoId, rutaEmbarqueId, CBImprimirRecibosFacturas.Checked, CBImprimirRecibosFacturas.Checked, false, almacenId, out errorProceso))
                    {
                        if (errorProceso == "bloqueado")
                        {
                            registrosConErrorBloqueo++;
                            continue;
                        }
                        if (MessageBox.Show("Desea continuar el procesado de las siguientes ventas moviles?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return;
                        }
                    }

                }

                if (registrosConErrorBloqueo > 0)
                {
                    MessageBox.Show("Hubo registros que no se pudiero procesar porque el cliente esta bloqueado o se excedio en su limite de credito");
                }

            }
            catch (Exception exception)
            {
            }

            

            LlenarGrid();
        }

        private void fillStatus()
        {
            foreach (DataGridViewRow row in iNFO_PEDIDOS_MOVIL_X_VENDEDORDataGridView.Rows)
            {
                if (row.Index == iNFO_PEDIDOS_MOVIL_X_VENDEDORDataGridView.NewRowIndex)
                    continue;

                DataGridViewImageCell cell = row.Cells["BOLITASALDO"] as DataGridViewImageCell;
                DataGridViewTextBoxCell cellstatus = row.Cells["STATUSSALDO"] as DataGridViewTextBoxCell;
                if (cellstatus != null)
                {
                    if (cellstatus.Value.ToString().Trim().Equals("BLOQUEADO"))
                        cell.Value = (System.Drawing.Image)iPos.Properties.Resources.redcircle;
                    else if (cellstatus.Value.ToString().Trim().Equals("EXCEDIDO"))
                        cell.Value = (System.Drawing.Image)iPos.Properties.Resources.ambarcircle;
                    else
                        cell.Value = (System.Drawing.Image)iPos.Properties.Resources.greencircle;
                }
            }
        }

        private void iNFO_PEDIDOS_MOVIL_X_VENDEDORDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            fillStatus();
        }

        private void ALMACENComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_loadingForm)
                LlenarGrid();
        }
    }
}
