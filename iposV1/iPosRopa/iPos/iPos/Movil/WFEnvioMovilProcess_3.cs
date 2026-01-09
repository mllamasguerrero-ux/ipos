using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using iPosData;
using iPosBusinessEntity;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Globalization;


namespace iPos
{
    public partial class WFEnvioMovilProcess_3 : iPos.Tools.ScreenConfigurableForm
    {
        ProgressBar[] progressBars;
        BackgroundWorker[] backgroundWorkers;
        CheckBox[] checkboxes;
        int currentProgress = 0;
        bool bError = false;
        string strError = "";

        bool bCloseForm = false;


        ProgressBar progBar = null;
        BackgroundWorker bgworker = null;
        CheckBox chBox = null;

        public bool m_procesoCerrado = false;
        CDOCTOBE m_Docto = null;


        public WFEnvioMovilProcess_3()
        {
            InitializeComponent();
        }


        public WFEnvioMovilProcess_3(CDOCTOBE docto):this()
        {
            m_Docto = docto;
        }


        void inicializar()
        {
            bError = false;
            bCloseForm = false;
            strError = "";
            currentProgress = 0;
            foreach (CheckBox cb in checkboxes)
            {
                cb.Visible = false;
            }
        }

        void recursiveChecking()
        {
            if (currentProgress > 0 && progBar != null)
            {

                progBar.Style = ProgressBarStyle.Blocks;


                if (bError)
                {
                    MessageBox.Show(strError);
                    if (bCloseForm)
                        this.Close();
                    return;
                }
                if (currentProgress >= 3)
                {
                    btnProcesar.Enabled = false;
                    btnVerificar.Visible = true;
                }


                if (chBox != null)
                    chBox.Visible = true;
            }

            int maxProcess = CBVerificarProcesamiento.Checked ? 4 : 3;

            if (currentProgress >= maxProcess)
            {
                
                if (bCloseForm)
                    this.Close();
                return;
            }


            progBar = progressBars[currentProgress];
            bgworker = backgroundWorkers[currentProgress];
            chBox = checkboxes[currentProgress];
            progBar.Style = ProgressBarStyle.Marquee;
            bgworker.RunWorkerAsync();


        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {

            if (PreProcesarDocto())
            {

                inicializar();
                recursiveChecking();
            }


             WFImportarPendientesMovilcs envioPendientes = new WFImportarPendientesMovilcs(false);
                envioPendientes.ShowDialog();

            
        }

        private bool PreProcesarDocto()
        {
            m_Docto.IOBSERVACION = TBNota1.Text;
            m_Docto.IDESCRIPCION = TBNota2.Text;
            m_Docto.IORIGENFISCALID = CBOrigenFiscal.SelectedIndex != 1 ? DBValues._ORIGENFISCAL_REMISIONADO : DBValues._ORIGENFISCAL_FACTURADO;
            m_Docto.IMOVILPLAZOS = CBPlazos.Checked ? "S" : "N";
            m_Docto.IMOVILCONTADO = CBContrato.Checked ? "S" : "N";

            CDOCTOD doctoD = new CDOCTOD();
            if (!doctoD.ENVIOMOVIL_LASTMODIF(m_Docto, null))
            {
                MessageBox.Show("Ocurrio un error al actualizar los datos de notas y origen fiscal");
                return false;
            }
            return true;
        }

        private void WFEnvioMovilProcess_3_Load(object sender, EventArgs e)
        {

            configuraLaPantalla(false, true);

            if (CurrentUserID.CurrentParameters.IMOVILVERIFICARVENTA != null && CurrentUserID.CurrentParameters.IMOVILVERIFICARVENTA.Equals("S"))
                CBVerificarProcesamiento.Checked = true;

            progressBars = new ProgressBar[] { progressBar00, progressBar01, progressBar02, progressBar03};
            backgroundWorkers = new BackgroundWorker[] { backgroundWorker0, backgroundWorker1, backgroundWorker2, backgroundWorker3};
            checkboxes = new CheckBox[] { checkBox0, checkBox1, checkBox2, checkBox3 };


            if (CurrentUserID.CurrentParameters.ITIPOSYNCMOVIL.Equals(DBValues._TIPOSYNC_WS))
            {
                progressBar00.Visible = true;
                progressBar02.Visible = true;
                progressBar03.Visible = true;


                lblValidacioExistencia.Visible = true;
                lblEnvioVenta.Visible = true;
                lblVerificacionProcesamiento.Visible = true;

                CBVerificarProcesamiento.Visible = true;
            }
            else
            {
                progressBar00.Visible = false;
                progressBar02.Visible = false;
                progressBar03.Visible = false;

                checkBox0.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;

                lblValidacioExistencia.Visible = false;
                lblEnvioVenta.Visible = false;
                lblVerificacionProcesamiento.Visible = false;

                CBVerificarProcesamiento.Visible = false;
            }

            CBOrigenFiscal.SelectedIndex = 0;

            precargarInfo();

        }


        private void precargarInfo()
        {
            if(m_Docto != null)
            {
                this.TBNota1.Text = m_Docto.IOBSERVACION != null ? m_Docto.IOBSERVACION.Trim() : "";
                this.TBNota2.Text = m_Docto.IDESCRIPCION != null ? m_Docto.IDESCRIPCION.Trim() : "";
                CBOrigenFiscal.SelectedIndex = m_Docto.IORIGENFISCALID == DBValues._ORIGENFISCAL_FACTURADO ? 1 : 0;
                CBPlazos.Checked = m_Docto.IMOVILPLAZOS != null && m_Docto.IMOVILPLAZOS.Trim().Equals("S");
                CBContrato.Checked = m_Docto.IMOVILCONTADO != null && m_Docto.IMOVILCONTADO.Trim().Equals("S");

            }
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (currentProgress)
            {
                case 0: 
                    if (CurrentUserID.CurrentParameters.ITIPOSYNCMOVIL.Equals(DBValues._TIPOSYNC_WS))
                    {
                    //PreValidar();
                    }
                    else
                    {
                        chBox = null;
                    }
                    break;
                case 1: CerrarVenta();
                    //FinalizarVisita(); 
                    break;
                case 2:
                    if (CurrentUserID.CurrentParameters.ITIPOSYNCMOVIL.Equals(DBValues._TIPOSYNC_WS))
                    {

                        if (ConexionAInternet())
                        {
                            try
                            {
                                bool bErrorBuffer = false;
                                string strErrorBuffer = "";
                                ImportaFtpMovil.EnvioClientes(true, ref bErrorBuffer, ref strErrorBuffer);
                            }
                            catch{ }
                            EnviarVenta();
                        }
                        else
                        {
                            bError = true;
                            strError = "No hay internet para enviar la venta";
                        }

                    
                    }
                    else
                    {
                        chBox = null;
                    }
                    break;
                case 3: 
                    
                    if (CurrentUserID.CurrentParameters.ITIPOSYNCMOVIL.Equals(DBValues._TIPOSYNC_WS))
                    {
                        VerificarProcesamiento();
                    }
                    else
                    {
                        chBox = null;
                    }
                    break;
                default: break;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            currentProgress++;
            recursiveChecking();

        }


        private void PreValidar()
        {


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
                strError = "No se pudo obtener los detalles de la venta";
                return;
            }




            CPERSONABE cliente = new CPERSONABE();
            CPERSONAD clienteD = new CPERSONAD();
            cliente.IID = m_Docto.IPERSONAID;
            cliente = clienteD.seleccionarPERSONA(cliente, null);

            if (cliente == null)
            {
                bError = true;
                strError = "No se pudo obtener el cliente";
                return;
            }


            ArrayList vedps = new ArrayList();
            foreach (CMOVTOBE movto in movtos)
            {


                if (movto.IMOVTOADJUNTOAID > 0)
                    continue;

                if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 2 && CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 3)
                {
                    if (cliente != null && cliente.ICLAVE != null && cliente.ICLAVE.Trim().Length > 6)
                        cliente.ICLAVE = ImportaFtpMovil.convertCustomerClaveToClipClave(cliente.ICLAVE);
                }

                CM_VEDPBE vedpbe = CM_VEDPD.convertMovtoIntoVEDP(movto, m_Docto, cliente);
                if (vedpbe == null)
                {

                    bError = true;
                    strError = "No se pudieron convertir algunso detalles para enviarlos";
                    return;
                }

                vedps.Add(vedpbe);
            }


            CM_VEDPBE[] vedpbes = new CM_VEDPBE[vedps.Count];
            vedps.CopyTo(vedpbes, 0);
            string jsonStr = JsonConvert.SerializeObject(vedpbes, Formatting.Indented);

            string strRespuesta = "";
            try
            {

                strRespuesta = service1.ValidarVentaMovil_3(jsonStr, iPos.CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                    iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                    iPos.Tools.FTPManagement.m_strFTPFolderPassWs);


                if (!strRespuesta.StartsWith("["))
                {

                    bError = true;
                    strError = "No se pudo validar la venta: " + strRespuesta;
                }


                
                List<CM_PROPBE> prods = JsonConvert.DeserializeObject<List<CM_PROPBE>>(strRespuesta);
                if (prods.Count > 0)
                {
                    foreach (CM_VEDPBE detalle in vedpbes)
                    {
                        bool productoHayado = false; 
                        bool flagFaltaExistencia = false;
                        foreach (CM_PROPBE prod in prods)
                        {
                            if (detalle.IPRODUCTO.Trim().Equals(prod.IPRODUCTO.Trim()))
                            {
                                if (detalle.ICANTIDAD > prod.IEXIS1)
                                {
                                    //flagFaltaExistencia = true;
                                    //MessageBox.Show("Falta existencia - insuficiente");
                                    //return;

                                    flagFaltaExistencia = true;

                                }
                                productoHayado = true;
                                break;
                            }
                        }
                        if (!productoHayado || flagFaltaExistencia)
                        {

                            WFValidacionExistenciasMovil form = new WFValidacionExistenciasMovil(m_Docto, TipoValidacionMovil.porExistencia, prods, null);
                            form.ShowDialog();
                            bool bContinuar = form.m_bContinuar;
                            form.Dispose();
                            GC.SuppressFinalize(form);

                            if (bContinuar)
                            {
                                return;
                            }
                            else
                            {
                                bError = true;
                                strError = "Cancelado por falta de existencia";
                                return;
                            }

                            //MessageBox.Show("Falta existencia - producto no encontrado");
                            //return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("No se pudo validar las existencias. desea continuar? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    bError = true;
                    strError = ex.Message + ex.StackTrace;
                }
                return;
            }




        }


        private void CerrarVenta()
        {
             CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            pvd.CerrarVenta(m_Docto, null);
            if (pvd.IComentario == "" || pvd.IComentario == null)
            {
                m_procesoCerrado = true;

                CPRODUCTOD prodD = new CPRODUCTOD();
                prodD.CambiarFlagHistorialMovilPRODUCTOD(m_Docto.IID, null);
                bCloseForm = true;

            }
            else
            {
                bError = true;
                this.strError = pvd.IComentario;
            }


        }



        private void FinalizarVisita()
        {

            if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
            {
                CVISITAD visitaD = new CVISITAD();
                CVISITABE visitaBE = new CVISITABE();
                visitaBE = visitaD.seleccionarULTIMAVISITA(null);

                if (visitaBE != null && visitaBE.IPERSONAID == m_Docto.IPERSONAID)
                {
                    visitaBE.IHORAFIN = DateTime.Now;
                    visitaBE.IHIZOPEDIDO = "V";
                    visitaD.finalizarVISITAD(visitaBE, visitaBE, null);
                }
            }
        }

        private void ActualizarUltimaVisita()
        {
            if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
            {
                CVISITAD visitaD = new CVISITAD();
                CVISITABE visitaBE = new CVISITABE();
                visitaBE = visitaD.seleccionarULTIMAVISITA(null);

                if (visitaBE != null)
                {
                    visitaD.MOVILVISITA_ASIGNARHIZOPEDIDO(visitaBE, null);
                }
            }
        }

        private void EnviarVenta()
        {

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
                strError = "No se pudo obtener los detalles de la venta";
                return;
            }


            CDOCTOD doctoD = new CDOCTOD();
            m_Docto = doctoD.seleccionarDOCTO(m_Docto, null);


            CPERSONABE cliente = new CPERSONABE();
            CPERSONAD clienteD = new CPERSONAD();
            cliente.IID = m_Docto.IPERSONAID;
            cliente = clienteD.seleccionarPERSONA(cliente,null);

            if(cliente == null)
            {
                bError = true;
                strError = "No se pudo obtener el cliente";
                return;
            }


            ArrayList vedps = new ArrayList();
            foreach (CMOVTOBE movto in movtos)
            {
                /*
                if (movto.IMOVTOADJUNTOAID > 0)
                    continue;*/

                if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 2 && CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 3)
                {
                    if (cliente != null && cliente.ICLAVE != null && cliente.ICLAVE.Trim().Length > 6)
                        cliente.ICLAVE = ImportaFtpMovil.convertCustomerClaveToClipClave(cliente.ICLAVE);
                }

                CM_VEDPBE vedpbe = CM_VEDPD.convertMovtoIntoVEDP(movto, m_Docto, cliente);
                if (vedpbe == null)
                {

                    bError = true;
                    strError = "No se pudieron convertir algunso detalles para enviarlos";
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
                strRespuesta = service1.AgregarVentaMovil3(jsonStr,
                    m_Docto.IOBSERVACION, m_Docto.IDESCRIPCION, strEstatus, m_Docto.IMOVILPLAZOS, m_Docto.IMOVILCONTADO != null && m_Docto.IMOVILCONTADO.Trim().Length > 0 ? m_Docto.IMOVILCONTADO : "N",
                            iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

                if (!strRespuesta.Equals("exito"))
                {

                    bError = true;
                    strError = "No se pudo enviar la venta: " + strRespuesta;
                }
                else
                {


                    m_Docto.ITRASLADOAFTP = DBValues._DB_BOOLVALUE_SI;
                    doctoD.CambiarEnviadoFTPDOCTOD(m_Docto, null);

                }
            }
            catch(Exception ex)
            {
                bError = true;
                strError = ex.Message + ex.StackTrace;
                return;
            }



        }


      

        private void VerificarProcesamiento()
        {


            CDOCTOD doctoD = new CDOCTOD();
            m_Docto = doctoD.seleccionarDOCTO(m_Docto, null);

            int intento = 0;
            string strRespuesta = "";
            while (intento < 3)
            {
                intento++;
                Thread.Sleep(1000);

                try
                {
                    com.server.ipos.Service1 service1 = new com.server.ipos.Service1();
                    string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
                    if (strWebService.Trim().Length > 0)
                    {
                        service1.Url = strWebService.Trim();
                    }
                     strRespuesta = service1.VerificarVentaMovil_3(m_Docto.IFOLIO.ToString(), iPos.CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                        iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                        iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

                     if (!strRespuesta.StartsWith("["))
                     {
                         if (intento >= 3)
                         {
                             bError = true;
                             strError = "Al verificar :" + strRespuesta;
                             return;
                         }
                     }
                     else
                     {

                         m_Docto.ITRANREGSERVER = DBValues._DB_BOOLVALUE_SI;
                         doctoD.CambiarTranRegServerDOCTOD(m_Docto, null);

                        /*
                         List<CM_VEDPBE> detalles = JsonConvert.DeserializeObject<List<CM_VEDPBE>>(strRespuesta);
                         WFValidacionExistenciasMovil form = new WFValidacionExistenciasMovil(m_Docto, TipoValidacionMovil.porProcesados, null, detalles);
                         form.ShowDialog();
                         break;*/
                     }
                }
                catch(Exception ex)
                {
                    if (intento >= 3)
                    {
                        bError = true;
                        strError = "No se pudo verificar " + ex.Message + ex.StackTrace;
                        return;
                    }
                }
            }

            

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CBVerificarProcesamiento_CheckedChanged(object sender, EventArgs e)
        {
            lblVerificacionProcesamiento.Visible = CBVerificarProcesamiento.Checked;
            progressBar03.Visible = CBVerificarProcesamiento.Checked;

        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {

            lblVerificacionProcesamiento.Visible = true;
            progressBar03.Visible = true;
            checkBox3.Visible = false;

            bError = false;
            bCloseForm = false;
            strError = "";

            progBar = null;
            bgworker = null;
            chBox = null;

            currentProgress = 3;
            recursiveChecking();
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

        private void CBContrato_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CBPlazos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CBOrigenFiscal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TBNota2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBNota1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
