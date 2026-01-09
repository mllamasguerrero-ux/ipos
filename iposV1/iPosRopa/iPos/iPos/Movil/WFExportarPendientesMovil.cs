using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using iPosBusinessEntity;
using iPosData;
using System.Collections;
using Newtonsoft.Json;

using System.EnterpriseServices;
using FirebirdSql.Data.FirebirdClient;
using ConexionesBD;
using Microsoft.ApplicationBlocks.Data;
using System.Globalization;

namespace iPos
{
    public partial class WFImportarPendientesMovilcs : IposForm
    {
        bool bError = false;
        string strError = "";

        bool bCancelar = false;
        bool m_bShowMensajesError = false;


        public WFImportarPendientesMovilcs()
        {
            InitializeComponent();

            m_bShowMensajesError = true;
        }

        public WFImportarPendientesMovilcs(bool bShowMensajesError) : this()
        {
            m_bShowMensajesError = bShowMensajesError;
        }


        private void WFImportarPendientesMovilcs_Load(object sender, EventArgs e)
        {
            if (ConexionAInternet())
                IntentarEnvio();
            else
            {
                MessageBox.Show("No se detecto internet para enviar la venta, quedara pendiente de enviar");
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bCancelar = true;
        }


        private void EnvioPendientes()
        {

            if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 2)
            {
                /**/FbDataReader dr = null;
            FbConnection pcn = null;
                try
                {

                    System.Collections.ArrayList parts = new ArrayList();
                    //FbParameter auxPar;

                    String CmdTxt = @"select ID from PAGOMOVIL where ESTATUS = 1 AND ENVIADOWS <> 'S' and TIPOPAGOID = 5 ";


                    FbParameter[] arParms = new FbParameter[parts.Count];
                    parts.CopyTo(arParms, 0);



                    dr = SqlHelper.ExecuteReader(ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);


                    while (dr.Read() && !bCancelar)
                    {


                        if (dr["ID"] != System.DBNull.Value)
                        {
                            long pagoID = (long)(dr["ID"]);
                            EnviarPago(pagoID);
                        }
                    }
                    Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                }
                catch
                {

                    Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                }
            }

            if (CurrentUserID.CurrentParameters.ITIPOSYNCMOVIL.Equals(DBValues._TIPOSYNC_WS))
            {
                /**/FbDataReader dr = null;
            FbConnection pcn = null;
                try
                {

                    System.Collections.ArrayList parts = new ArrayList();
                    //FbParameter auxPar;

                    String CmdTxt = @"select ID from DOCTO where ESTATUSDOCTOID = 1 AND TIPODOCTOID = 321 AND TRASLADOAFTP <> 'S' ";


                    FbParameter[] arParms = new FbParameter[parts.Count];
                    parts.CopyTo(arParms, 0);



                    dr = SqlHelper.ExecuteReader(ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);


                    while (dr.Read() && !bCancelar)
                    {


                        if (dr["ID"] != System.DBNull.Value)
                        {
                            long doctoID = (long)(dr["ID"]);
                            EnviarVenta(doctoID);
                        }
                    }
                    Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                }
                catch
                {

                    Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                }
            }

            ImportaFtpMovil.EnvioClientes(false, ref bError, ref strError);

        }

        private void IntentarEnvio()
        {

            btnReintentar.Enabled = false;
            this.progressBar1.Style = ProgressBarStyle.Marquee;
            this.backgroundWorker1.RunWorkerAsync();
        }

        private bool ConexionAInternet()
        {
            Ping myPing = new Ping();
            String host = "google.com";
            byte[] buffer = new byte[32];
            int timeout = 1000;
            PingOptions pingOptions = new PingOptions();
            try
            {
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
            }
            catch
            {

            }
            return false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            EnvioPendientes();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.progressBar1.Style = ProgressBarStyle.Blocks;
            if (bError)
            {
                btnReintentar.Enabled = true;

                if (m_bShowMensajesError)
                    MessageBox.Show("Ocurrio un error: " + strError);
                else
                    this.Close();
            }
            else
            {

                if (m_bShowMensajesError)
                    MessageBox.Show("Lo pendiente ha sido enviado");

                this.Close();

            }
        }

        private void btnReintentar_Click(object sender, EventArgs e)
        {
            IntentarEnvio();
        }




        public static CM_CHGPBE convertPagoIntoCHGP(CPAGOMOVILBE pagoBE)
        {


            string referencia = "";
            if (pagoBE.IREFERENCIABANCARIA != null)
                if (pagoBE.IREFERENCIABANCARIA.Trim().Length > 6)
                    referencia = pagoBE.IREFERENCIABANCARIA.Trim().Substring(pagoBE.IREFERENCIABANCARIA.Trim().Length - 6, 6);
                else
                    referencia = pagoBE.IREFERENCIABANCARIA;



            CM_CHGPBE item = new CM_CHGPBE();
            item.IPAGO = pagoBE.IID.ToString().PadLeft(8, '0');
            item.IFECHA = pagoBE.IFECHAELABORACION;
            item.ITIPO = pagoBE.IFORMAPAGOID.ToString();
            item.IBANCO = (pagoBE.IBANCOTEXT == null) ? "" : pagoBE.IBANCOTEXT;
            item.IID_NUM = referencia;
            item.IIMPORTE = pagoBE.IIMPORTE;
            item.ISALDO = pagoBE.IIMPORTE - pagoBE.IAPLICADO - pagoBE.IIMPORTECAMBIO;
            item.IINTERESES = 0;
            item.IID = pagoBE.ICORTEID.ToString();
            item.IID_FECHA = pagoBE.IFECHA;
            item.IID_HORA = "X";
            item.IF_DEPOSITO = pagoBE.IFECHARECEPCION;
            return item;


        }


        public static CM_CHDPBE convertDetallePagoIntoCHDP(CDOCTOPAGOMOVILBE pagoDetalleBE, CPAGOMOVILBE pagoBE)
        {


            CM_CHDPBE item = new CM_CHDPBE();

            item.IPAGO = pagoDetalleBE.IPAGOMOVILID.ToString().PadLeft(8, '0'); ;
            item.IFECHA = pagoBE.IFECHA;
            item.IVENTA = pagoDetalleBE.IVENTACOBRANZA;
            item.ICARGO = pagoDetalleBE.ISALDOANTERIOR;
            item.IABONO = pagoDetalleBE.IIMPORTE + pagoDetalleBE.ISALDOPAGO;
            item.ISALDO = pagoDetalleBE.ISALDOPAGO;//pagoDetalleBE.ISALDONUEVO;
            item.IINTERESES = 0;
            item.INUMERO = (int)pagoDetalleBE.IID;
            item.IID = pagoBE.ICORTEID.ToString();
            item.IID_FECHA = pagoBE.IFECHA;
            item.IID_HORA = "X";
            return item;


        }


        private void EnviarPago(long pagoMovilId)
        {

            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();

            string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
            if (strWebService.Trim().Length > 0)
            {
                service1.Url = strWebService.Trim();
            }


            CDOCTOPAGOMOVILD doctoPagoMovilD = new CDOCTOPAGOMOVILD();
            CDOCTOPAGOMOVILBE[] detalles = doctoPagoMovilD.seleccionarDOCTOPAGOMOVIL_DEPAGO(pagoMovilId, null);
            CPAGOMOVILBE pagoMovilBE = new CPAGOMOVILBE();
            CPAGOMOVILD pagoMovilD = new CPAGOMOVILD();
            pagoMovilBE.IID = pagoMovilId;
            pagoMovilBE = pagoMovilD.seleccionarPAGOMOVIL(pagoMovilBE, null);


            //ArrayList headerArray = new ArrayList();
            ArrayList detailsArray = new ArrayList();


            CM_CHGPBE header = convertPagoIntoCHGP(pagoMovilBE);
            CM_CHGPBE[] headerbes = new CM_CHGPBE[1];
            headerbes[0] = header;
            string jsonStrHdr = JsonConvert.SerializeObject(headerbes, Formatting.Indented);

            foreach (CDOCTOPAGOMOVILBE detalle in detalles)
            {
                CM_CHDPBE detail = convertDetallePagoIntoCHDP(detalle, pagoMovilBE);
                if (detail == null)
                {

                    bError = true;
                    strError += " /No se pudieron convertir algunso detalles para enviarlos del pago : " + pagoMovilId.ToString();
                    return;
                }

                detailsArray.Add(detail);
            }


            CM_CHDPBE[] detailbes = new CM_CHDPBE[detailsArray.Count];
            detailsArray.CopyTo(detailbes, 0);
            string jsonStr = JsonConvert.SerializeObject(detailbes, Formatting.Indented);

            string strRespuesta = "";
            try
            {
                strRespuesta = service1.AgregarCobranzaMovil(jsonStrHdr, jsonStr, pagoMovilId.ToString().PadLeft(8, '0'),
                            iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

                if (!strRespuesta.Equals("exito"))
                {

                    bError = true;
                    strError += " / No se pudo enviar el pago : " + pagoMovilId.ToString()  + " - " + strRespuesta;
                }
                else
                {


                    pagoMovilBE.IENVIADOWS = DBValues._DB_BOOLVALUE_SI;
                    pagoMovilD.CambiarEnviadoWS(pagoMovilBE, null);

                }
            }
            catch (Exception ex)
            {
                bError = true;
                strError += " /Excepcion al procesar el pago : " + pagoMovilId.ToString()  + " " + ex.Message + ex.StackTrace;
                return;
            }



        }



        private void EnviarVenta(long doctoId)
        {
            CDOCTOBE m_Docto = new CDOCTOBE();
            m_Docto.IID = doctoId;

            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();
            string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
            if (strWebService.Trim().Length > 0)
            {
                service1.Url = strWebService.Trim();
            }
            CMOVTOD movtoD = new CMOVTOD();
            CMOVTOBE[] movtos = movtoD.seleccionarMOVTOSDEDOCTO(m_Docto.IID, null);



            if (movtos == null)
            {
                bError = true;
                strError += "No se pudo obtener los detalles de la venta: " + m_Docto.IFOLIO.ToString();
                return;
            }


            CDOCTOD doctoD = new CDOCTOD();
            m_Docto = doctoD.seleccionarDOCTO(m_Docto, null);


            CPERSONABE cliente = new CPERSONABE();
            CPERSONAD clienteD = new CPERSONAD();
            cliente.IID = m_Docto.IPERSONAID;
            cliente = clienteD.seleccionarPERSONA(cliente, null);

            if (cliente == null)
            {
                bError = true;
                strError += " /No se pudo obtener el cliente de la venta: " + m_Docto.IFOLIO.ToString();
                return;
            }


            ArrayList vedps = new ArrayList();
            foreach (CMOVTOBE movto in movtos)
            {



                if (movto.IMOVTOADJUNTOAID > 0)
                    continue;



                if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 2 && CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 3 && CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 4)
                {
                    if (cliente != null && cliente.ICLAVE != null && cliente.ICLAVE.Trim().Length > 6)
                        cliente.ICLAVE = ImportaFtpMovil.convertCustomerClaveToClipClave(cliente.ICLAVE);
                }


                CM_VEDPBE vedpbe = CM_VEDPD.convertMovtoIntoVEDP(movto, m_Docto, cliente);
                if (vedpbe == null)
                {

                    bError = true;
                    strError  += " /No se pudieron convertir algunso detalles para enviarlos de la venta " + m_Docto.IFOLIO.ToString();
                    return;
                }

                vedps.Add(vedpbe);
            }


            var numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";

            CM_VEDPBE[] vedpbes = new CM_VEDPBE[vedps.Count];
            vedps.CopyTo(vedpbes, 0);
            string jsonStr = JsonConvert.SerializeObject(vedpbes, Formatting.Indented);
            jsonStr = jsonStr + "||||" + m_Docto.ITOTAL.ToString(numberFormatInfo);

            string strRespuesta = "";
            try
            {

                string strEstatus = m_Docto.IORIGENFISCALID == DBValues._ORIGENFISCAL_FACTURADO ? "F" : "R";

                if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 2)
                {
                    strRespuesta = service1.AgregarVentaMovil_2(jsonStr,
                                m_Docto.IOBSERVACION, m_Docto.IDESCRIPCION, strEstatus, m_Docto.IMOVILPLAZOS, m_Docto.IMOVILCONTADO != null && m_Docto.IMOVILCONTADO.Trim().Length > 0 ? m_Docto.IMOVILCONTADO : "N",
                            iPos.CurrentUserID.CurrentParameters.IBDSERVERWS, iPos.CurrentUserID.CurrentUser.IUSERNAME,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                }
                else if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 1)
                {
                    strRespuesta = service1.AgregarVentaMovil(jsonStr,
                                m_Docto.IOBSERVACION, m_Docto.IDESCRIPCION, strEstatus, m_Docto.IMOVILPLAZOS, m_Docto.IMOVILCONTADO != null && m_Docto.IMOVILCONTADO.Trim().Length > 0 ? m_Docto.IMOVILCONTADO : "N",
                                iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                    iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                    iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                }
                else if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
                {
                    strRespuesta = service1.AgregarVentaMovil3(jsonStr,
                                m_Docto.IOBSERVACION, m_Docto.IDESCRIPCION, strEstatus, m_Docto.IMOVILPLAZOS, m_Docto.IMOVILCONTADO != null && m_Docto.IMOVILCONTADO.Trim().Length > 0 ? m_Docto.IMOVILCONTADO : "N",
                                iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,iPos.CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE,
                                    iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                    iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                }

                if (!strRespuesta.Equals("exito") && !strRespuesta.Equals("No se puede volver a enviar"))
                {

                    bError = true;
                    strError += " /No se pudo enviar la venta: " + m_Docto.IFOLIO.ToString() + " " + strRespuesta;
                }
                else
                {


                    m_Docto.ITRASLADOAFTP = DBValues._DB_BOOLVALUE_SI;
                    doctoD.CambiarEnviadoFTPDOCTOD(m_Docto, null);

                }
            }
            catch (Exception ex)
            {
                bError = true;
                strError += "Excepcion al procesar la venta: "  + m_Docto.IFOLIO.ToString() + " " + ex.Message + ex.StackTrace;
                return;
            }



        }









    }
}
