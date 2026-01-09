using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer.Importaciones;
using System.Collections;
using iPosData;
using iPosBusinessEntity;
using ConexionesBD;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.ApplicationBlocks.Data;
using Newtonsoft.Json;
using iPosReporting;

namespace iPos.Movil
{
    public class Movil3Sync
    {
        public static bool ObtenerDatosDelServer(ref string comentario)
        {
            //ArrayList strErrores = new ArrayList();

            ImportarDBF iDBF = new ImportarDBF();

            comentario = "";

            string strRespuesta = "";

            bool importacionExitosa = true;



            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();
            string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
            if (strWebService.Trim().Length > 0)
            {
                service1.Url = strWebService.Trim();
            }





            //clientes

            strRespuesta = service1.ObtenerClienteMovil_3("100", "N", iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                               iPos.Tools.FTPManagement.m_strFTPFolderWs,
                               iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

            if (!strRespuesta.StartsWith("["))
            {
                importacionExitosa = false;
                comentario += "\nAl verificar :" + strRespuesta;


            }
            else
            {

                List<CF_CLIPBE> clientes = JsonConvert.DeserializeObject<List<CF_CLIPBE>>(strRespuesta);
                foreach (CF_CLIPBE item in clientes)
                {
                    List<CF_CLIPBE> listaItemUnico = new List<CF_CLIPBE>();
                    listaItemUnico.Add(item);

                    string comentario2 = "";
                    if (!ImportaFtpMovil.ImportarDatosCliente_FromMovil3(listaItemUnico, false, ref comentario2))
                    {
                        item.IPROCESADO = "E";
                    }
                    else
                    {
                        item.IPROCESADO = "S";
                    }
                }


                var serialized = JsonConvert.SerializeObject(clientes);

                strRespuesta = service1.ActualizarClienteProcesadoMovil_3(serialized, "", iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                   iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                   iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                if (!strRespuesta.StartsWith("S"))
                {
                    importacionExitosa = false;
                    comentario += "\nAl actualizar el estado en el ws :" + strRespuesta;


                }
            }






            //ventas

            strRespuesta = service1.ObtenerVentasMovil_3("100", "N", iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                               iPos.Tools.FTPManagement.m_strFTPFolderWs,
                               iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

            if (!strRespuesta.StartsWith("["))
            {
                importacionExitosa = false;
                comentario += "\nAl verificar :" + strRespuesta;

            }
            else
            {

                List<FM_VENPBE> ventasMoviles = JsonConvert.DeserializeObject<List<FM_VENPBE>>(strRespuesta);
                foreach (FM_VENPBE ventaMovil in ventasMoviles)
                {
                    if (!iDBF.ImportarDatosPedidoMovilMatriz(ventaMovil, CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser))
                    {
                        ventaMovil.IPROCESADO = "E";
                    }
                    else
                    {
                        ventaMovil.IPROCESADO = "S";
                    }
                }


                var serialized = JsonConvert.SerializeObject(ventasMoviles);

                strRespuesta = service1.ActualizarProcesadoMovil_3(serialized, "", iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                   iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                   iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                if (!strRespuesta.StartsWith("S"))
                {
                    importacionExitosa = false;
                    comentario += "\nAl actualizar el estado en el ws :" + strRespuesta;
                    

                }
            }





            //compras
            try
            {
                strRespuesta = service1.ObtenerComprasMovil_3("100", "N", iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                   iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                   iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

                if (!strRespuesta.StartsWith("["))
                {
                    importacionExitosa = false;
                    comentario += "\nAl verificar :" + strRespuesta;

                }
                else
                {

                    List<FM_CMNPBE> ventasMoviles = JsonConvert.DeserializeObject<List<FM_CMNPBE>>(strRespuesta);
                    foreach (FM_CMNPBE ventaMovil in ventasMoviles)
                    {
                        if (!iDBF.ImportarDatosCompraMovilMatriz(ventaMovil, CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser))
                        {
                            ventaMovil.IPROCESADO = "E";
                        }
                        else
                        {
                            ventaMovil.IPROCESADO = "S";
                        }
                    }


                    var serialized = JsonConvert.SerializeObject(ventasMoviles);

                    strRespuesta = service1.ActualizarCompraProcesadoMovil_3(serialized, "", iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                       iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                       iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    if (!strRespuesta.StartsWith("S"))
                    {
                        importacionExitosa = false;
                        comentario += "\nAl actualizar el estado en el ws :" + strRespuesta;


                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            //cobranza

            strRespuesta = service1.ObtenerCobranzaMovil_3("100", "N", iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                               iPos.Tools.FTPManagement.m_strFTPFolderWs,
                               iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

            if (!strRespuesta.StartsWith("["))
            {
                importacionExitosa = false;
                comentario += "\nAl verificar :" + strRespuesta;
               

            }
            else
            {
                CR_PAGOMOVILD pagoMovilD = new CR_PAGOMOVILD();
                CR_DOCTOPAGOMOVILD doctoPagoMovilD = new CR_DOCTOPAGOMOVILD();
                List<CR_PAGOMOVILBE> pagosMoviles = JsonConvert.DeserializeObject<List<CR_PAGOMOVILBE>>(strRespuesta);



                foreach (CR_PAGOMOVILBE header in pagosMoviles)
                {


                    

                    if (header.IPROCESADO != null && (header.IPROCESADO.Equals("D") || header.IPROCESADO.Equals("K")))
                    {


                        header.IR_PAGOMOVILREFID = header.IID;
                        CR_PAGOMOVILBE saved = pagoMovilD.seleccionarR_PAGOMOVIL_x_REFID(header.IID, header.IVENDEDOR, null);


                        if (saved != null)
                        {
                            bool bRes = pagoMovilD.BorrarR_PAGOMOVILD(saved, null);
                            if (!bRes)
                            {
                                header.IPROCESADO = "K";
                                header.IID = header.IR_PAGOMOVILREFID;
                                continue;
                            }

                            bRes = doctoPagoMovilD.BorrarR_DOCTOPAGOMOVIL_x_PAGOMOVILID(saved.IID, null);
                            if (!bRes)
                            {
                                header.IPROCESADO = "K";
                                header.IID = header.IR_PAGOMOVILREFID;
                                continue;
                            }

                        }
                        else
                        {

                            header.IPROCESADO = "S";
                            header.IID = header.IR_PAGOMOVILREFID;
                        }


                    }
                    else
                    {





                        header.IR_PAGOMOVILREFID = header.IID;
                        CR_PAGOMOVILBE pagoMovilNuevo = pagoMovilD.AgregarR_PAGOMOVILD(header, null);
                        if (pagoMovilNuevo == null)
                        {
                            header.IPROCESADO = "E";
                            continue;
                        }

                        foreach (CR_DOCTOPAGOMOVILBE detallePago in header.Detalles)
                        {
                            detallePago.IPAGOMOVILID = pagoMovilNuevo.IID;
                            detallePago.IR_DOCTOPAGOMOVILREFID = detallePago.IID;



                            CR_DOCTOPAGOMOVILBE doctoPagoMovilNuevo = doctoPagoMovilD.AgregarR_DOCTOPAGOMOVILD(detallePago, null);
                            if (doctoPagoMovilNuevo == null)
                            {

                                header.IPROCESADO = "E";
                                continue;
                            }
                        }
                        header.IPROCESADO = "S";
                        header.IID = header.IR_PAGOMOVILREFID;


                        

                    }

                }



                var serialized = JsonConvert.SerializeObject(pagosMoviles);

                strRespuesta = service1.ActualizarCobranzaProcesadoMovil_3(serialized, "", iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                   iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                   iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                if (!strRespuesta.StartsWith("S"))
                {
                    importacionExitosa = false;
                    comentario += "\nAl actualizar el estado en el ws :" + strRespuesta;
                   

                }
            }




            //estado de sesion

            DateTime ultimaActSesion = CurrentUserID.CurrentParameters.IMOVIL_ULTCAM_SESION != null ? CurrentUserID.CurrentParameters.IMOVIL_ULTCAM_SESION : DateTime.MinValue;

            DateTime newActSesion = ultimaActSesion;

            strRespuesta = service1.getUpdatedMovilSesion(ultimaActSesion, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                               iPos.Tools.FTPManagement.m_strFTPFolderWs,
                               iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

            if (!strRespuesta.StartsWith("["))
            {
                importacionExitosa = false;
                comentario += "\nAl verificar :" + strRespuesta;
                

            }
            else
            {

                CMOVILSESIOND movilSesionD = new CMOVILSESIOND();
                List<CMOVILSESIONBE> sesiones = JsonConvert.DeserializeObject<List<CMOVILSESIONBE>>(strRespuesta);
                bool bErrorEnSesiones = false;
                foreach (CMOVILSESIONBE item in sesiones)
                {
                    CMOVILSESIONBE saved = new CMOVILSESIONBE();
                    saved.IVENDEDORCLAVE = item.IVENDEDORCLAVE;
                    saved = movilSesionD.seleccionarMOVILSESION_X_VEND(saved, null);

                    if (saved != null)
                    {
                        if (!movilSesionD.CambiarMOVILSESIOND_X_VEND(item, saved, null))
                        {
                            bErrorEnSesiones = true;
                            importacionExitosa = false;
                            comentario += "\nError al cambiar sesion" + movilSesionD.IComentario;
                        }
                        else
                        {
                            if(newActSesion.CompareTo(item.IMODIFICADO) < 0)
                                newActSesion = (DateTime)item.IMODIFICADO;
                        }
                    }
                    else
                    {
                        if (movilSesionD.AgregarMOVILSESIOND(item, null) == null)
                        {

                            bErrorEnSesiones = true;
                            importacionExitosa = false;
                            comentario += "\nError al agregar sesion" + movilSesionD.IComentario;
                        }
                        else
                        {
                            if (newActSesion.CompareTo(item.IMODIFICADO) < 0)
                                newActSesion = (DateTime)item.IMODIFICADO;
                        }

                    }

                }

                if(!bErrorEnSesiones && newActSesion.CompareTo(ultimaActSesion) != 0)
                {
                    CPARAMETROD pARAMETROD = new CPARAMETROD();
                    CurrentUserID.CurrentParameters.IMOVIL_ULTCAM_SESION = newActSesion;
                    pARAMETROD.CambiarMOVIL_ULTCAM_SESION(CurrentUserID.CurrentParameters, null);


                }



            }




            //requerimientos de envio por vendedor
            try
            {

                strRespuesta = service1.PendientesArchivosEnviarMovil3("10", iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                   iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                   iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                if (!strRespuesta.StartsWith("["))
                {
                    importacionExitosa = false;
                    comentario += "\nAl verificar :" + strRespuesta;


                }
                else
                {
                    
                    List<CM_SYNCBE> syncs = JsonConvert.DeserializeObject<List<CM_SYNCBE>>(strRespuesta);
                    foreach (CM_SYNCBE sync in syncs)
                    {
                        string comentarioLocal = "";
                        if(!CSyncArchivosMovil.ExportarArchivoConCobranzaAutomatico(sync.IVENDCLAVE, sync.IFECHAULTENVIOSUC, ref comentarioLocal))
                        {

                            importacionExitosa = false;
                            comentario += "\nAl enviar archivo cobranza automatico :" + comentarioLocal;
                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }

            return importacionExitosa;
        }




        public static bool procesarVentasAutomaticas(ref string comentario)
        {

            Importaciones.DSImportacionesTableAdapters.INFO_PEDIDOS_MOVIL_X_VENDEDORTableAdapter adapter = new iPos.Importaciones.DSImportacionesTableAdapters.INFO_PEDIDOS_MOVIL_X_VENDEDORTableAdapter();
            adapter.ClearBeforeFill = true;

            iPos.Importaciones.DSImportaciones dSImportaciones = new iPos.Importaciones.DSImportaciones();
            dSImportaciones.DataSetName = "DSImportaciones";
            dSImportaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            DataSet dsVendedores = usuariosD.enlistarUSUARIOSVENDEDORESCONVENTAAUTOMATICA();


            if(dsVendedores != null && dsVendedores.Tables[0] != null && 
                dsVendedores.Tables[0].Rows != null && dsVendedores.Tables[0].Rows.Count   > 0)
            {
                foreach(DataRow dr in dsVendedores.Tables[0].Rows)
                {
                    

                    int vendedor = int.Parse(dr["VENDEDORID"].ToString());
                    int usuarioId = int.Parse(dr["USUARIOID"].ToString());
                    string impresora = dr["IMPRESORA"] == DBNull.Value || dr["IMPRESORA"].ToString().Trim().Length == 1 ? null : dr["IMPRESORA"].ToString();
                    

                    adapter.Fill(dSImportaciones.INFO_PEDIDOS_MOVIL_X_VENDEDOR,
                                                                     "-1", DateTime.Today.AddDays(-5),
                                                                    vendedor,
                                                                    1, 0, "N");

                    CDOCTOD doctoD = new CDOCTOD();
                    string error = "";
                    comentario = "";
                    foreach (iPos.Importaciones.DSImportaciones.INFO_PEDIDOS_MOVIL_X_VENDEDORRow row in dSImportaciones.INFO_PEDIDOS_MOVIL_X_VENDEDOR.Rows)
                    {
                        if (!procesarVenta(row.ID, 0, true, true, false, impresora, usuarioId, out error))
                        {
                            //doctoD.CambiarESTATUSDOCTOPEDIDOID(row.ID, -1, null);
                            comentario += " " + error;

                        }
                    }
                }
            }




            return true;
        }



        public static bool procesarComprasAutomaticas(ref string comentario)
        {

            Importaciones.DSImportacionesTableAdapters.INFO_COMPRAS_MOVIL_X_VENDEDORTableAdapter adapter = new iPos.Importaciones.DSImportacionesTableAdapters.INFO_COMPRAS_MOVIL_X_VENDEDORTableAdapter();
            adapter.ClearBeforeFill = true;

            iPos.Importaciones.DSImportaciones dSImportaciones = new iPos.Importaciones.DSImportaciones();
            dSImportaciones.DataSetName = "DSImportaciones";
            dSImportaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            DataSet dsVendedores = usuariosD.enlistarUSUARIOSVENDEDORESCONCOMPRAAUTOMATICA();


            if (dsVendedores != null && dsVendedores.Tables[0] != null &&
                dsVendedores.Tables[0].Rows != null && dsVendedores.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsVendedores.Tables[0].Rows)
                {


                    int vendedor = int.Parse(dr["VENDEDORID"].ToString());
                    int usuarioId = int.Parse(dr["USUARIOID"].ToString());
                    string impresora = dr["IMPRESORA"] == DBNull.Value || dr["IMPRESORA"].ToString().Trim().Length == 1 ? null : dr["IMPRESORA"].ToString();


                    adapter.Fill(dSImportaciones.INFO_COMPRAS_MOVIL_X_VENDEDOR,
                                                                     "-1",
                                                                     DateTime.Today.AddDays(-5),
                                                                    vendedor,
                                                                    1);

                    CDOCTOD doctoD = new CDOCTOD();
                    string error = "";
                    comentario = "";
                    foreach (iPos.Importaciones.DSImportaciones.INFO_COMPRAS_MOVIL_X_VENDEDORRow row in dSImportaciones.INFO_COMPRAS_MOVIL_X_VENDEDOR.Rows)
                    {
                        
                        if (!procesarCompra(row.ID, true, impresora, usuarioId, out error))
                        {
                            //doctoD.CambiarESTATUSDOCTOPEDIDOID(row.ID, -1, null);
                            comentario += " " + error;

                        }
                    }
                }
            }




            return true;
        }

        

        public static bool procesarVenta(long doctoId, long rutaEmbarqueId, bool imprimirFactura, bool imprimirRecibo, bool marcarComoFacturacionPendiente, string impresora, int usuarioId, out string error)
        {
            long doctoVentaId = 0;
            long doctoPago = 0;
            string message = String.Empty;

            error = "";


            ImportarDBF impDbfHelper = new ImportarDBF();


            //obtenemos los datos del docto para conocer algunos detalles utiles
            CDOCTOBE docto = new CDOCTOBE();
            docto.IID = doctoId;
            CDOCTOD doctoD = new CDOCTOD();
            docto = doctoD.seleccionarDOCTO(docto, null);
            if (docto == null)
            {
                error = "El pedido no existe";
                return false;
            }



            //estado rebaja
            if (docto.IESTADOREBAJA == DBValues._ESTADOREBAJA_PENDIENTE)
            {
                error = "pendiente de autorizar rebaja";
                return false;
            }
            else if (docto.IESTADOREBAJA == DBValues._ESTADOREBAJA_PENDIENTEXPRECIOMIN)
            {

                error = "pendiente de autorizar precio abajo del minimo";
                return false;
            }




            CUSUARIOSD usuariosD = new CUSUARIOSD();
            bool bTieneDerechoRutaEmbarque = usuariosD.UsuarioTienePermisos((int)usuarioId, (int)DBValues._PONER_RUTA_EMBARQUE_EN_VENTA, null);
            bool bTieneDerechoCreditoExcedido = usuariosD.UsuarioTienePermisos((int)usuarioId, (int)DBValues._DERECHO_VENDERCONCREDITOEXCEDIDO, null);
            bool bTieneDerechoMovilSurtidoPostpuesto = usuariosD.UsuarioTienePermisos((int)usuarioId, (int)DBValues._DERECHO_MOVIL_SURTIDO_POSTPUESTO, null);

            if (bTieneDerechoMovilSurtidoPostpuesto)
                imprimirRecibo = false;

            string resComentario = "";



            CSURTIDOD surtidoD = new CSURTIDOD();
            if (docto.IESTADOSURTIDOID != DBValues._DOCTO_SURTIDOESTADO_SURTIDO  && docto.IMOVILCONTADO == "N" )
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

                        if (!bTieneDerechoCreditoExcedido)
                        {
                            error = "En esta venta " + docto.IFOLIO.ToString() + "se sobrepasaria el limite de credito del cliente  " + clienteBE.INOMBRE;
                            if (docto.IESTADOSURTIDOID != DBValues._DOCTO_SURTIDOESTADO_CXC)
                            {
                                surtidoD.SURTIDO_ASIGNARESTADO(doctoId, "por proceso automatico movil", DBValues._DOCTO_SURTIDOESTADO_CXC, CurrentUserID.CurrentUser.IID, null);
                            }
                            return false;
                        }

                    }
                }
            }
            if (docto.IESTADOSURTIDOID == DBValues._DOCTO_SURTIDOESTADO_CXC && docto.IMOVILCONTADO == "N" && 
                    CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO != "S" && CurrentUserID.CurrentParameters.IHABSURTIDOPOSTMOVIL != "S"
                     && !bTieneDerechoMovilSurtidoPostpuesto)
            {
                surtidoD.SURTIDO_ASIGNARESTADO(doctoId, "por proceso automatico movil", 0, CurrentUserID.CurrentUser.IID, null);
            }





            //pregunta ruta de embarque si aplica
            if (bTieneDerechoRutaEmbarque && rutaEmbarqueId == 0)
            {
                    error = "Debe definir una ruta de embarque";
                    return false;
            }



            bool bEsFacturaElectronica = false;



            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;


            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();


                //cambiamos el vendedor para que se tome el usuario actualmente loguead
                //pero mantenemos el vendedorfinal que es el vendedor que hizo efectivamente la venta
                CambiarVendedorCajero(doctoId, usuarioId, fTrans);

                bool success = impDbfHelper.PEDIDO_MOVIL_COMPLETAR(doctoId, ref doctoVentaId, ref doctoPago, fTrans);


                if (!success)
                {
                    fTrans.Rollback();
                    fConn.Close();
                    error = "Problema al procesar: " + impDbfHelper.IComentario;
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
                    error = "hubo un error no se proceso el registro ";
                    return false;
                }


                bEsFacturaElectronica = (doctoGenerado.IESTADOSURTIDOID == DBValues._DOCTO_SURTIDOESTADO_SURTIDO || doctoGenerado.IESTADOSURTIDOID == 0) &&
                                        doctoGenerado.IESFACTURAELECTRONICA != null && doctoGenerado.IESFACTURAELECTRONICA.Equals("S");


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


                    if (marcarComoFacturacionPendiente || bTieneDerechoMovilSurtidoPostpuesto)
                    {

                        //docto.IFOLIOSAT = -3;
                        doctoAFacturar.IFOLIOSAT = -3;
                        //if (!doctoD.CambiarFOLIOSATDOCTOD(docto, fTrans))
                        if (!doctoD.CambiarFOLIOSATDOCTOD(doctoAFacturar, fTrans))
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            error = "No se pudo marcar para facturacion pendiente " + doctoD.IComentario;

                            return false;

                        }
                    }
                    else
                    {


                        //if (!generarFacturaElectronicaPorId(doctoVentaId, fTrans, ref resComentario))
                        if (!generarFacturaElectronicaPorId(doctoAFacturar.IID, fTrans, ref resComentario))
                        {

                            fTrans.Rollback();
                            fConn.Close();
                            error = "No se pudo realizar la facturacion " + resComentario;

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
                    && doctoGenerado.IESTADOSURTIDOID != DBValues._DOCTO_SURTIDOESTADO_PENDIENTE
                    && doctoGenerado.IESTADOSURTIDOID != DBValues._DOCTO_SURTIDOESTADO_CXC)
                {

                    bool bBuffer = ExportarTraslados(doctoGenerado.IFOLIO, ref resComentario);

                    if (!bBuffer)
                        error = "Advertencia : No se pudo exportar el traslado " + resComentario;
                }


                if (bEsFacturaElectronica && imprimirFactura && !marcarComoFacturacionPendiente)
                {

                    bool bBuffer = imprimirFacturaElectronicaPorId(doctoVentaId, ref resComentario);

                    if (!bBuffer)
                        error = "Advertencia : No se pudo imprimir la factura electronica " + resComentario;
                    
                }

                if (imprimirRecibo)
                {
                    PosPrinter.ImprimirTicket(doctoVentaId, 0, false, false, 1, false, false, true, impresora);

                    PosPrinter.ImprimirCuponesSiAplica(doctoVentaId, null);
                }

                return true;
            }
            catch (Exception exception)
            {
                fTrans.Rollback();
                fConn.Close();

                error = exception.Message;

                return false;
            }
            finally
            {
                
            }


        }



        private static bool APLICARCUPONES_SIESNECESARIO(long doctoId, FbTransaction fTrans)
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

        public static bool procesarCompra(long doctoId,  bool imprimirRecibo,  string impresora, int usuarioId, out string error)
        {
            long doctoVentaId = 0;
            long doctoPago = 0;
            string message = String.Empty;

            error = "";


            ImportarDBF impDbfHelper = new ImportarDBF();


            //obtenemos los datos del docto para conocer algunos detalles utiles
            CDOCTOBE docto = new CDOCTOBE();
            docto.IID = doctoId;
            CDOCTOD doctoD = new CDOCTOD();
            docto = doctoD.seleccionarDOCTO(docto, null);
            if (docto == null)
            {
                error = "El pedido no existe";
                return false;
            }



            CUSUARIOSD usuariosD = new CUSUARIOSD();
            string resComentario = "";


            CPERSONAD clienteD = new CPERSONAD();
            CPERSONABE clienteBE = new CPERSONABE();
            clienteBE.IID = docto.IPERSONAID;
            clienteBE = clienteD.seleccionarPERSONA(clienteBE, null);

            

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;


            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();


                //cambiamos el vendedor para que se tome el usuario actualmente loguead
                //pero mantenemos el vendedorfinal que es el vendedor que hizo efectivamente la venta
                CambiarVendedorCajero(doctoId, usuarioId, fTrans);

                bool success = impDbfHelper.COMPRA_MOVIL_COMPLETAR(doctoId, DBValues._DOCTO_TIPO_COMPRA, ref doctoVentaId, ref doctoPago, fTrans);


                if (!success)
                {
                    fTrans.Rollback();
                    fConn.Close();
                    error = "Problema al procesar: " + impDbfHelper.IComentario;
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
                    error = "hubo un error no se proceso el registro ";
                    return false;
                }

                
                fTrans.Commit();
                fConn.Close();


                

                if (imprimirRecibo)
                    PosPrinter.ImprimirTicket(doctoVentaId, 0, false, false, 1, false, false, true, impresora);

                return true;
            }
            catch (Exception exception)
            {
                fTrans.Rollback();
                fConn.Close();

                error = exception.Message;

                return false;
            }
            finally
            {

            }


        }


        private static bool CambiarVendedorCajero(long doctoId, long vendedorCajeroId, FbTransaction fTrans)
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


        private static bool generarFacturaElectronicaPorId(long doctoId, FbTransaction fTrans, ref string resComentario)
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
            //m_strFileLog = fe.m_strFileLog;
            fe.Dispose();
            GC.SuppressFinalize(fe);

            if (retorno)
            {
                docto.IESFACTURAELECTRONICA = "S";
                doctoD.ACTUALIZARESFACTURAELECTRONICA(docto, fTrans);
            }

            return retorno;
        }


        private static bool imprimirFacturaElectronicaPorId(long doctoId, ref string resComentario)
        {

            bool retorno;

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE docto = new CDOCTOBE();
            docto.IID = doctoId;
            docto = doctoD.seleccionarDOCTO(docto, null);

            if (docto == null)
            {

                resComentario = "No se encontro la factura electronica";
                return false;
            }


            //if ((bool)docto.isnull["IFOLIOSAT"] || (bool)docto.isnull["IESTATUSDOCTOID"]
            //    || docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || docto.IFOLIOSAT <= 0)
            //{
            //    resComentario = "No se puede imprimir la factura electronica , cheque que se haya generado la factura electronica de este registro";
            //    return false;
            //}


            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(docto, CurrentUserID.CurrentParameters, iPosReporting.WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_GENERARPDF, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;
        }



        private static bool ExportarTraslados(int folio, ref string resComentario)
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
                resComentario = "Error en la exportacion, se intentara mas tarde: " + strBuffer.ToString() + "\n";
                return false;
            }
            else
            {
                resComentario = "La exportacion del traslado se ha realizado";
                return true;
            }


        }


    }
}
