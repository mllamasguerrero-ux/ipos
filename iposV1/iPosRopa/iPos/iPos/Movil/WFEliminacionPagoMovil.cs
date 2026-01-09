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
using Newtonsoft.Json;

using System.Net.NetworkInformation;

using FirebirdSql.Data.FirebirdClient;


namespace iPos
{
    public partial class WFEliminacionPagoMovil : IposForm
    {
        bool bError = false;
        string strError = "";
        long pagoMovilId = 0;
        public Boolean bEliminado = false;
        public WFEliminacionPagoMovil()
        {
            InitializeComponent();
        }
        public WFEliminacionPagoMovil(long pagoId) : this()
        {
            pagoMovilId = pagoId;
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

                EliminarPago();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.progressBar1.Style = ProgressBarStyle.Blocks;
            if (bError)
            {
                btnReintentar.Enabled = true;
                MessageBox.Show("Ocurrio un error: " + strError);
            }
            else
            {

                MessageBox.Show("El pago ha sido eliminado");
                this.Close();

            }
        }


        public static CM_CHGPBE convertPagoIntoCHGP(CPAGOMOVILBE pagoBE)
        {

                
            string referencia = "";
            if(pagoBE.IREFERENCIABANCARIA != null)
              if( pagoBE.IREFERENCIABANCARIA.Trim().Length > 6)
                  referencia = pagoBE.IREFERENCIABANCARIA.Trim().Substring(pagoBE.IREFERENCIABANCARIA.Trim().Length - 6, 6);
              else
                  referencia = pagoBE.IREFERENCIABANCARIA;
                


            CM_CHGPBE item = new CM_CHGPBE();
            item.IPAGO = pagoBE.IID.ToString().PadLeft(8,'0') ;
			item.IFECHA = pagoBE.IFECHAELABORACION ;
            item.ITIPO = pagoBE.IFORMAPAGOID.ToString();
            item.IBANCO = (pagoBE.IBANCOTEXT == null) ? "" : pagoBE.IBANCOTEXT;
			item.IID_NUM = referencia;
			item.IIMPORTE = pagoBE.IIMPORTE ;
			item.ISALDO = pagoBE.IIMPORTE - pagoBE.IAPLICADO - pagoBE.IIMPORTECAMBIO ;
			item.IINTERESES = 0 ;
			item.IID = pagoBE.ICORTEID.ToString() ;
			item.IID_FECHA = pagoBE.IFECHA ;
			item.IID_HORA = "X" ;
            item.IF_DEPOSITO = pagoBE.IFECHARECEPCION;
            return item;


        }

        
        public static CM_CHDPBE convertDetallePagoIntoCHDP(CDOCTOPAGOMOVILBE pagoDetalleBE,CPAGOMOVILBE pagoBE)
        {


            CM_CHDPBE item = new CM_CHDPBE();
            
			item.IPAGO= pagoDetalleBE.IPAGOMOVILID.ToString().PadLeft(8,'0') ; ;
			item.IFECHA= pagoBE.IFECHA ;
			item.IVENTA= pagoDetalleBE.IVENTACOBRANZA ;
            item.ICARGO = pagoDetalleBE.ISALDOANTERIOR;
            item.IABONO = pagoDetalleBE.IIMPORTE + pagoDetalleBE.ISALDOPAGO;
            item.ISALDO = pagoDetalleBE.ISALDOPAGO;//pagoDetalleBE.ISALDONUEVO;
			item.IINTERESES= 0 ;
			item.INUMERO= (int)pagoDetalleBE.IID ;
			item.IID=  pagoBE.ICORTEID.ToString() ;
			item.IID_FECHA= pagoBE.IFECHA;
			item.IID_HORA= "X" ;
            return item;


        }


        private void EliminarPago()
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
                CM_CHDPBE detail = convertDetallePagoIntoCHDP(detalle, pagoMovilBE );
                if (detail == null)
                {

                    bError = true;
                    strError = "No se pudieron convertir algunso detalles para enviarlos";
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


                if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
                {
                    strRespuesta = service1.EliminarCobranzaMovil_3( pagoMovilId.ToString().PadLeft(8, '0'), CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE,
                            iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                }
                else
                {
                    strRespuesta = service1.EliminarCobranzaMovil(jsonStrHdr, jsonStr, pagoMovilId.ToString().PadLeft(8, '0'),
                            iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                }



                if (!strRespuesta.Equals("exito"))
                {

                    bError = true;
                    strError = "No se pudo cancelar el pago en el servidor y tendra que esperar a que tenga conexion " + strRespuesta;
                }
                else
                {

                    if(!this.eliminarPagoMovil(pagoMovilBE))
                    {
                        bError = true;
                        strError = "No se pudo cancelar el pago en la base de datos local : " + strError;
                    }
                    else
                    {
                        bEliminado = true;
                    }

                }
            }
            catch (Exception ex)
            {
                bError = true;
                strError = ex.Message + ex.StackTrace;
                return;
            }



        }

        private void IntentarEnvio()
        {
            bError = false;
            btnReintentar.Enabled = false;
            this.progressBar1.Style = ProgressBarStyle.Marquee;
            this.backgroundWorker1.RunWorkerAsync();
        }

        private void btnReintentar_Click(object sender, EventArgs e)
        {
            IntentarEnvio();
        }

        private void WFEliminacionPagoMovil_Load(object sender, EventArgs e)
        {

            if (ConexionAInternet())
                IntentarEnvio();
            else
            {
                MessageBox.Show("No se detecto internet para enviar la venta, quedara pendiente de enviar");
                this.Close();
            }

            
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



        private Boolean eliminarPagoMovil( CPAGOMOVILBE pagoBE)
        {

            CPAGOMOVILD pagoMOVILD = new CPAGOMOVILD();
            /*CPAGOMOVILBE pagoBE = new CPAGOMOVILBE();
            pagoBE.IID = m_doctoPago.IID;*/
            pagoBE.ICORTEID = CurrentUserID.CurrentUser.ICORTEID;

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;


            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (!pagoMOVILD.CancelarPAGOMOVILD(pagoBE, fTrans))
                {

                    fTrans.Rollback();
                    fConn.Close();

                    this.strError = pagoMOVILD.IComentario;
                    return false;
                }

                fTrans.Commit();
                fConn.Close();
                return true;

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
                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }

            return false;

        }



    }
}
