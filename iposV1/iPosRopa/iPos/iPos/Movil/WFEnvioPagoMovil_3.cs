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


namespace iPos
{
    public partial class WFEnvioPagoMovil_3 : IposForm
    {
        bool bError = false;
        string strError = "";
        long pagoMovilId = 0;
        public WFEnvioPagoMovil_3()
        {
            InitializeComponent();
        }
        public WFEnvioPagoMovil_3(long pagoId) : this()
        {
            pagoMovilId = pagoId;
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

                EnviarPago();
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

                MessageBox.Show("El pago ha sido enviado");
                this.Close();

            }
        }
        

        private void EnviarPago()
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

            if (pagoMovilBE == null)
                return;

            pagoMovilBE.Detalles = new List<CDOCTOPAGOMOVILBE>();
            if(detalles != null && detalles.Length > 0)
            {
                pagoMovilBE.Detalles.AddRange(detalles);
            }

            List<CPAGOMOVILBE> listPago = new List<CPAGOMOVILBE>();
            listPago.Add(pagoMovilBE);

            string jsonStr = JsonConvert.SerializeObject(listPago, Formatting.Indented);

           

            string strRespuesta = "";
            try
            {
                

                strRespuesta = service1.AgregarCobranzaMovil_3(jsonStr,"", iPos.CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE,
                            iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

                if (!strRespuesta.Equals("exito"))
                {

                    bError = true;
                    strError = "No se pudo enviar la venta: " + strRespuesta;
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
                strError = ex.Message + ex.StackTrace;
                return;
            }



        }

        private void IntentarEnvio()
        {

            btnReintentar.Enabled = false;
            this.progressBar1.Style = ProgressBarStyle.Marquee;
            this.backgroundWorker1.RunWorkerAsync();
        }

        private void btnReintentar_Click(object sender, EventArgs e)
        {
            IntentarEnvio();
        }

        private void WFEnvioPagoMovil_3_Load(object sender, EventArgs e)
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

    }
}
