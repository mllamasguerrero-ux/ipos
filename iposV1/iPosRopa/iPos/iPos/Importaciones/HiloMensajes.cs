using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using System.Security.Permissions;
using iPosData;
using System.Security.Permissions;
using iPosBusinessEntity;
using System.Net.Http;
using Newtonsoft.Json;
using FirebirdSql.Data.FirebirdClient;

namespace iPos
{
    public class HiloMensajes
    {

        bool m_bSolicitudDeAbortar = false;

        Thread p1;
        private System.Windows.Threading.Dispatcher dispatcher;


        public HiloMensajes()
        {
            this.dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            p1 = new Thread(new ThreadStart(ProcesaMensajes));
        }

        ~HiloMensajes()  // destructor
        {
            // cleanup statements...

        }

        public void IniciarHiloMensajes()
        {
            p1.Start();
        }

        //[SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        public void DetenerHiloMensajes()
        {
            m_bSolicitudDeAbortar = true;

            //p1.Interrupt();
            if (!p1.Join(1000))
            { // or an agreed resonable time
                p1.Abort();
            }
        }


        private void DescargarMensajes()
        {
            // 
            string comentario = "";
            DescargarMensajes(ref comentario);


        }

        private bool DescargarMensajes(ref string comentario)
        {
            comentario = "";

            //string urlMensajeEnvio = @"http://localhost:51932/WcfMensajeriaWS.svc/GetMensaje/test";
            string urlMensajeEnvio = CurrentUserID.CurrentParameters.IWSMENSAJERIA != null ?
                                    CurrentUserID.CurrentParameters.IWSMENSAJERIA + @"/GetMensaje" :
                                "";

            HttpClient client = new HttpClient();

            List<CMENSAJEBE> mensajeList = new List<CMENSAJEBE>();
            List<CMENSAJEAREABE> mensajeAreaList = new List<CMENSAJEAREABE>();
            List<CMENSAJEADJUNTOSBE> mensajeAdjuntosList = new List<CMENSAJEADJUNTOSBE>();

            CMENSAJEADJUNTOSD mensajeAdjuntosD = new CMENSAJEADJUNTOSD();
            CMENSAJEAREAD mensajeAreasD = new CMENSAJEAREAD();
            CMENSAJED mensajeD = new CMENSAJED();

            CPARAMETROD parametroD = new CPARAMETROD();

            CAREAD areaD = new CAREAD();

            try
            {


                Dictionary<string, string> datos = new Dictionary<string, string>();






                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, urlMensajeEnvio);




                requestMessage.Headers.Add("empresa", CurrentUserID.CurrentParameters.IFTPFOLDER);
                requestMessage.Headers.Add("idminimo", CurrentUserID.CurrentParameters.IULTMENSAJEID.ToString());
                requestMessage.Headers.Add("clavesuc", CurrentUserID.CurrentParameters.ISUCURSALNUMERO);
                requestMessage.Headers.Add("password", "");


                HttpResponseMessage response = client.SendAsync(requestMessage).Result;
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;

                    string res = "";

                    string strJsonRetorno = JsonConvert.DeserializeObject<string>(content);


                    Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(strJsonRetorno);


                    List<CMENSAJESUCBE> mensajesucs = new List<CMENSAJESUCBE>();
                    List<CMENSAJEADJUNTOSBE> mensajeadjs = new List<CMENSAJEADJUNTOSBE>();
                    List<CMENSAJEAREABE> mensajeareas = new List<CMENSAJEAREABE>();



                    if (values.ContainsKey("res"))
                    {

                        res = values["res"].ToString();
                    }

                    if (values.ContainsKey("comentario"))
                    {

                        comentario = values["comentario"].ToString();
                    }

                    if (res == "S")
                    {

                        if (values.ContainsKey("mensaje"))
                        {

                            mensajeList = JsonConvert.DeserializeObject<List<CMENSAJEBE>>(values["mensaje"].ToString());
                        }

                        if (values.ContainsKey("mensajeadj"))
                        {

                            mensajeAdjuntosList = JsonConvert.DeserializeObject<List<CMENSAJEADJUNTOSBE>>(values["mensajeadj"].ToString());
                        }

                        if (values.ContainsKey("mensajearea"))
                        {

                            mensajeAreaList = JsonConvert.DeserializeObject<List<CMENSAJEAREABE>>(values["mensajearea"].ToString());
                        }
                    }

                    response.Dispose();


                    if (res == "S" && mensajeList != null && mensajeList.Count > 0)
                    {

                        FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                        FbTransaction fTrans = null;

                        try
                        {

                           //Aqui ve co
                            
                            fConn.Open();
                            fTrans = fConn.BeginTransaction();


                            foreach(CMENSAJEBE mensaje in mensajeList)
                            {

                               


                                    CMENSAJEBE mensajeBuffer = new CMENSAJEBE();
                                    mensajeBuffer.IMENSAJEID = mensaje.IID;
                                    mensajeBuffer.IMENSAJETIPOID = DBValues._TIPO_MENSAJE_ENTRADA;
                                    mensajeBuffer.IMENSAJEESTADOID = DBValues._ESTADO_MENSAJE_RECIBIDO;
                                    mensajeBuffer.IASUNTO = mensaje.IASUNTO;
                                    mensajeBuffer.ICODIGOLECTURA = mensaje.ICODIGOLECTURA;
                                    mensajeBuffer.IFECHA = mensaje.IFECHA;
                                    mensajeBuffer.IFECHAHORA = mensaje.IFECHAHORA;
                                    mensajeBuffer.IPARATODASSUC = mensaje.IPARATODASSUC;
                                    mensajeBuffer.IPARATODASAREAS = mensaje.IPARATODASAREAS;
                                    mensajeBuffer.ISOLOADMIN = mensaje.ISOLOADMIN;
                                    mensajeBuffer.IRESTRICTIVO = mensaje.IRESTRICTIVO;
                                    mensajeBuffer.IMENSAJERAIZID = mensaje.IMENSAJERAIZID;
                                    mensajeBuffer.IMENSAJEPADREID = mensaje.IMENSAJEPADREID;
                                    mensajeBuffer.IMENSAJEUSUARIO = mensaje.IMENSAJEUSUARIO;
                                    mensajeBuffer.INIVELDEURGENCIAID = mensaje.INIVELDEURGENCIAID;
                                    mensajeBuffer.ISUCURSALFUENTECLAVE = mensaje.ISUCURSALFUENTECLAVE;
                                    mensajeBuffer.IMENSAJE = mensaje.IMENSAJE;

                                    mensajeBuffer = mensajeD.AgregarMENSAJED(mensajeBuffer, fTrans);

                                    if(mensajeBuffer == null)
                                    {
                                        fTrans.Rollback();
                                        fConn.Close();
                                        comentario = "Error al generar el mensaje " + mensajeD.IComentario;
                                        return false;

                                    }


                                    foreach (CMENSAJEADJUNTOSBE adjunto in mensajeAdjuntosList)
                                    {

                                        if (adjunto.IIDMENSAJE != mensaje.IID)
                                            continue;

                                        CMENSAJEADJUNTOSBE mensajeAdjBuffer = new CMENSAJEADJUNTOSBE();
                                        mensajeAdjBuffer.IIDMENSAJE = mensajeBuffer.IID;
                                        mensajeAdjBuffer.IRUTAADJUNTO = adjunto.IRUTAADJUNTO;
                                        mensajeAdjBuffer.INOMBREARCHIVO = adjunto.INOMBREARCHIVO;
                                        mensajeAdjBuffer.IFTPADJUNTO = adjunto.IFTPADJUNTO;

                                        mensajeAdjBuffer = mensajeAdjuntosD.AgregarMENSAJEADJUNTOSD(mensajeAdjBuffer, fTrans);

                                        if (mensajeAdjBuffer == null)
                                        {
                                            fTrans.Rollback();
                                            fConn.Close();
                                            comentario = "Error al guardar el adjunto " + mensajeAdjuntosD.IComentario;
                                            return false;


                                        }

                                    }


                                    foreach (CMENSAJEAREABE mensajeArea in mensajeAreaList)
                                    {

                                        if (mensajeArea.IIDMENSAJE != mensaje.IID)
                                            continue;

                                        CAREABE areaBE = new CAREABE();
                                        areaBE.ICLAVE = mensajeArea.ICLAVEAREA;

                                        areaBE = areaD.seleccionarAREAXCLAVE(areaBE, fTrans);

                                        if(areaBE == null)
                                        {
                                            continue;
                                        }

                                        CMENSAJEAREABE mensajeAreaBuffer = new CMENSAJEAREABE();
                                        mensajeAreaBuffer.IIDMENSAJE = mensajeBuffer.IID;
                                        mensajeAreaBuffer.ICLAVEAREA = areaBE.ICLAVE;
                                        mensajeAreaBuffer.IIDAREA = areaBE.IID;

                                        mensajeAreaBuffer = mensajeAreasD.AgregarMENSAJEAREAD(mensajeAreaBuffer, fTrans);

                                        if (mensajeAreaBuffer == null)
                                        {
                                            fTrans.Rollback();
                                            fConn.Close();
                                            comentario = "Error al guardar el adjunto " + mensajeAreasD.IComentario;
                                            return false;

                                        }

                                    }



                               if (mensaje.IID > CurrentUserID.CurrentParameters.IULTMENSAJEID)
                               {
                                    CurrentUserID.CurrentParameters.IULTMENSAJEID = mensaje.IID;
                                    if (!parametroD.CambiarULTMENSAJEID(CurrentUserID.CurrentParameters, CurrentUserID.CurrentParameters, fTrans))
                                   {

                                       fTrans.Rollback();
                                       fConn.Close();
                                       comentario = "Error al actualizar el mensajeid " + mensajeAreasD.IComentario;
                                       return false;
                                   }
                                    CurrentUserID.CurrentParameters = parametroD.seleccionarPARAMETROActual(fTrans);
                                }
                                
                            }


                            fTrans.Commit();
                            fConn.Close();


                        }
                        catch
                        {
                            try
                            {
                                fTrans.Rollback();
                            }
                            catch { }

                            fConn.Close();
                        }
                        finally
                        {
                            fConn.Close();
                        }
                    }
                    else
                    {
                        comentario = "Error de respuesta del ws " ;
                        return false;
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                comentario = "Excepcion " + ex.Message;
                return false;
            }



        }




        public void ProcesaMensajes()
        {

            if (CurrentUserID.CurrentParameters.IHABMENSAJERIA == null || !CurrentUserID.CurrentParameters.IHABMENSAJERIA.Equals("S"))
                return;
            

            while (!m_bSolicitudDeAbortar)
            {

                try
                {

                    if (iPos.CurrentUserID.CurrentCompania.IHABILITAR_IMPEXP_AUT.Equals("S"))
                    {
                        DescargarMensajes();
                    }

                }
                catch
                {

                }


                try
                {
                    //mandar llamar al procedimiento de MENSAJES_ALERTAUSUARIO para ver los 4 datos
                    long actualUserId = CurrentUserID.CurrentUser.IID;
                    CPERSONAD userD = new CPERSONAD();
                    bool ES_ADMINISTRADOR = userD.UsuarioEsAdmin(actualUserId, null);
                    bool ES_SUPERVISOR = userD.UsuarioEsAdmin(actualUserId, null);

                    string esAdmin = ES_ADMINISTRADOR || ES_SUPERVISOR ? "S" : "N";

                    int cMensjSnLeer = 0, cMensjSnLeerRest = 0, cMensjSnLeerAdm = 0, cMensjSnLeerAdmRest = 0;

                    CMENSAJED daoMensaje = new CMENSAJED();
                    daoMensaje.llamarMENSAJES_ALERTAUSUARIO(actualUserId, esAdmin, ref cMensjSnLeer, ref cMensjSnLeerRest, ref cMensjSnLeerAdm, ref cMensjSnLeerAdmRest, null);


                    if (cMensjSnLeer > 0 || cMensjSnLeerAdmRest > 0)
                    {
                        this.dispatcher.Invoke(new Action(() =>
                        {
                            WFMensajesNotificacion wf = new WFMensajesNotificacion(cMensjSnLeer, cMensjSnLeerRest, cMensjSnLeerAdm, cMensjSnLeerAdmRest);
                            wf.ShowDialog();
                            wf.Dispose();
                            GC.SuppressFinalize(wf);
                        }));
                    }


                }
                catch
                {

                }

                Thread.Sleep(5 * 60 * 1000);
            }

        }
    }
}
