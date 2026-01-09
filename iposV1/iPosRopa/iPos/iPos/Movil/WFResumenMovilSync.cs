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
using System.Globalization;

namespace iPos
{
    public partial class WFResumenMovilSync : iPos.Tools.ScreenConfigurableForm
    {

        long m_iDoctoId = 0;
        string m_folio = "";
        int m_currentIndex = -1;

        CDOCTOBE m_Docto = null;
        
        bool bError = false;
        string strError = "";

        public WFResumenMovilSync()
        {
            InitializeComponent();
        }

        private void WFResumenMovilSync_Load(object sender, EventArgs e)
        {
            configuraLaPantalla(true, true);

            // TODO: This line of code loads data into the 'dSMovil.ESTADOSYNC' table. You can move, or remove it, as needed.
            this.eSTADOSYNCTableAdapter.Fill(this.dSMovil.ESTADOSYNC);

            HabilitaBotonChequeo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void eSTADOSYNCDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (eSTADOSYNCDataGridView.Columns[e.ColumnIndex].Name == "RECHECAR")
            {
                m_currentIndex = e.RowIndex; ;
                m_iDoctoId = (long)eSTADOSYNCDataGridView.Rows[m_currentIndex].Cells["DG_DOCTOID"].Value;
                m_folio = eSTADOSYNCDataGridView.Rows[m_currentIndex].Cells["DG_FOLIO"].Value.ToString();

                
                CDOCTOD doctoD = new CDOCTOD();
                m_Docto = new CDOCTOBE();
                m_Docto.IID = m_iDoctoId;
                m_Docto = doctoD.seleccionarDOCTO(m_Docto, null);

                bError = false;
                strError = "";

                progressBar03.Visible = true;
                progressBar03.Style = ProgressBarStyle.Marquee;
            backgroundWorker3.RunWorkerAsync();

            }
            else if (eSTADOSYNCDataGridView.Columns[e.ColumnIndex].Name == "REENVIAR")
            {
                m_currentIndex = e.RowIndex; ;
                m_iDoctoId = (long)eSTADOSYNCDataGridView.Rows[m_currentIndex].Cells["DG_DOCTOID"].Value;
                m_folio = eSTADOSYNCDataGridView.Rows[m_currentIndex].Cells["DG_FOLIO"].Value.ToString();


                CDOCTOD doctoD = new CDOCTOD();
                m_Docto = new CDOCTOBE();
                m_Docto.IID = m_iDoctoId;
                m_Docto = doctoD.seleccionarDOCTO(m_Docto, null);

                bError = false;
                strError = "";

                progressBar02.Visible = true;
                progressBar02.Style = ProgressBarStyle.Marquee;
                backgroundWorker2.RunWorkerAsync();

            }
            else if (eSTADOSYNCDataGridView.Columns[e.ColumnIndex].Name == "VERIFICAR")
            {
                m_currentIndex = e.RowIndex; ;
                m_iDoctoId = (long)eSTADOSYNCDataGridView.Rows[m_currentIndex].Cells["DG_DOCTOID"].Value;
                m_folio = eSTADOSYNCDataGridView.Rows[m_currentIndex].Cells["DG_FOLIO"].Value.ToString();

                
                CDOCTOD doctoD = new CDOCTOD();
                m_Docto = new CDOCTOBE();
                m_Docto.IID = m_iDoctoId;
                m_Docto = doctoD.seleccionarDOCTO(m_Docto, null);

                bError = false;
                strError = "";

                progressBar1.Visible = true;
                progressBar1.Style = ProgressBarStyle.Marquee;
                 backgroundWorker1.RunWorkerAsync();

            }
        }



        private void VerificarProcesamiento( bool bSoloChecar)
        {

            if (m_Docto == null || (!bSoloChecar && m_Docto.ITRANREGSERVER != null && m_Docto.ITRANREGSERVER.Equals("S")))
                return;

             CDOCTOD doctoD = new CDOCTOD();

            string strRespuesta = "";

                try
                {
                    com.server.ipos.Service1 service1 = new com.server.ipos.Service1();
                    string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
                    if (strWebService.Trim().Length > 0)
                    {
                        service1.Url = strWebService.Trim();
                    }

                    if(CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
                    {

                        strRespuesta = service1.VerificarVentaMovil_3(m_Docto.IFOLIO.ToString(), iPos.CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                       iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                       iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    }
                    else
                    {

                        strRespuesta = service1.VerificarVentaMovil(m_Docto.IFOLIO.ToString(), iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                       iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                       iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    }


                    if (!strRespuesta.StartsWith("["))
                    {
                            bError = true;
                            strError = "Al verificar :" + strRespuesta;
                            return;
                       
                    }
                    else
                    {
                        if (!bSoloChecar)
                        {
                            m_Docto.ITRANREGSERVER = DBValues._DB_BOOLVALUE_SI;
                            doctoD.CambiarTranRegServerDOCTOD(m_Docto, null);
                        }

                        if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 3 && CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 4)
                        {
                            List<CM_VEDPBE> detalles = JsonConvert.DeserializeObject<List<CM_VEDPBE>>(strRespuesta);
                            WFValidacionExistenciasMovil form = new WFValidacionExistenciasMovil(m_Docto, TipoValidacionMovil.porProcesados, null, detalles);
                            form.ShowDialog();
                            form.Dispose();
                            GC.SuppressFinalize(form);
                        }
                    }
                }
                catch (Exception ex)
                {
                        bError = true;
                        strError = "No se pudo verificar " + ex.Message + ex.StackTrace;
                        return;
                }
            



        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
           VerificarProcesamiento( false);
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            progressBar03.Style = ProgressBarStyle.Blocks;
            progressBar03.Visible = false;
           if (bError)
           {
               MessageBox.Show(strError);
           }
           else
           {
               eSTADOSYNCDataGridView.Rows[m_currentIndex].Cells["DGPROCESADO"].Value = "S";

               eSTADOSYNCDataGridView.Rows[m_currentIndex].Cells["RECHECAR"].ReadOnly = true;
               eSTADOSYNCDataGridView.Rows[m_currentIndex].Cells["RECHECAR"].Style.BackColor = Color.Red;
               m_currentIndex = -1;
           }
        }



        public void HabilitaBotonChequeo()
        {

            foreach (DataGridViewRow row in this.eSTADOSYNCDataGridView.Rows)
            {

                string procesado = "";

                if (row.Cells["DGPROCESADO"].Value != DBNull.Value)
                {
                    procesado = row.Cells["DGPROCESADO"].Value.ToString().Trim();
                }


                if (procesado.Equals("S"))
                {
                    row.Cells["RECHECAR"].ReadOnly = true;
                    row.Cells["RECHECAR"].Style.BackColor = Color.Red;
                }

            }
        }


        public void FormatGrid()
        {

            this.eSTADOSYNCDataGridView.BackgroundColor = Color.White;
            this.eSTADOSYNCDataGridView.DefaultCellStyle.BackColor = Color.White;

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


                if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 2 && CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 3 && CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 4)
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

                if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 2)
                {
                    strRespuesta = service1.AgregarVentaMovil_2(jsonStr,
                                m_Docto.IOBSERVACION, m_Docto.IDESCRIPCION, strEstatus, m_Docto.IMOVILPLAZOS, m_Docto.IMOVILCONTADO != null && m_Docto.IMOVILCONTADO.Trim().Length > 0 ? m_Docto.IMOVILCONTADO : "N",
                            iPos.CurrentUserID.CurrentParameters.IBDSERVERWS, iPos.CurrentUserID.CurrentUser.IUSERNAME,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                }
                else if(CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 1)
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
                                iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO, iPos.CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE,
                                    iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                    iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                }

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
            catch (Exception ex)
            {
                bError = true;
                strError = ex.Message + ex.StackTrace;
                return;
            }



        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            EnviarVenta();
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar02.Style = ProgressBarStyle.Blocks;
            progressBar02.Visible = false;
            if (bError)
            {
                MessageBox.Show(strError);
            }
            else
            {
                eSTADOSYNCDataGridView.Rows[m_currentIndex].Cells["DGENVIADO"].Value = "S";

                eSTADOSYNCDataGridView.Rows[m_currentIndex].Cells["REENVIAR"].ReadOnly = true;
                eSTADOSYNCDataGridView.Rows[m_currentIndex].Cells["REENVIAR"].Style.BackColor = Color.Red;
                m_currentIndex = -1;
            }
        }




       

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            VerificarProcesamiento(true);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Visible = false;
            if (bError)
            {
                MessageBox.Show(strError);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            WFImportarPendientesMovilcs envioPendientes = new WFImportarPendientesMovilcs();
            envioPendientes.ShowDialog();
            envioPendientes.Dispose();
            GC.SuppressFinalize(envioPendientes);
        }

        private void btnActualizarPrecios_Click(object sender, EventArgs e)
        {
            WFImportarPreciosNuevosMovil wf = new WFImportarPreciosNuevosMovil(true);
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

    }
}
