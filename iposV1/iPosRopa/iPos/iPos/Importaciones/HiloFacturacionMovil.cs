using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;

using iPosData;
using iPosBusinessEntity;
using System.Security.Permissions;
using System.Windows.Forms;

namespace iPos
{
    public class HiloFacturacionMovil
    {
        
        Thread p1;
        bool m_bSolicitudDeAbortar = false;
        public HiloFacturacionMovil()
        {
            p1 = new Thread(new ThreadStart(FacturacionMovilCicle));
            p1.SetApartmentState(ApartmentState.STA);
        }

        ~HiloFacturacionMovil()  // destructor
        {
        // cleanup statements...
            
        }

        public void IniciarFacturacionMovil()
        {         
            p1.Start();
        }

       //[SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        public void DetenerFacturacionMovil()
        {
            m_bSolicitudDeAbortar = true;
            
            //p1.Interrupt();
            if(!p1.Join(1000)) { // or an agreed resonable time
                p1.Abort();
            }

        }

        
        public void FacturacionMovilCicle()
        {

            ArrayList doctosIdAFacturar = new ArrayList();
            ArrayList doctosIdAEnviarRecibo = new ArrayList();

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOPAGOD doctoPagoD = new CDOCTOPAGOD();

            while (!m_bSolicitudDeAbortar)
                {

                    try
                    {
                        if (iPos.CurrentUserID.CurrentCompania.IHABILITAR_IMPEXP_AUT.Equals("S") && 
                            (iPos.CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO == null || !iPos.CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO.Equals("S")) &&
                            (iPos.CurrentUserID.CurrentParameters.IHABSURTIDOPOSTMOVIL == null || !iPos.CurrentUserID.CurrentParameters.IHABSURTIDOPOSTMOVIL.Equals("S")))
                        {
                            lock (iPos.CurrentUserID.thisLockFacturacionMovil)
                            {
                                doctosIdAFacturar = doctoD.seleccionarDOCTOSIDAFACTURACIONMOVIL(DateTime.Today, null);
                                
                                CPARAMETROD paramD = new CPARAMETROD();
                                CPARAMETROBE paramBE = paramD.seleccionarPARAMETROActual(null);

                                foreach(long doctoId in doctosIdAFacturar)
                                {
                                    CDOCTOBE doctoBE = new CDOCTOBE();
                                    doctoBE.IID = doctoId;
                                    doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

                                    if (doctoBE == null)
                                        continue;

                                    CDOCTOPAGOBE doctoPagoBE = new CDOCTOPAGOBE();
                                    doctoPagoBE = doctoPagoD.seleccionarPrimerDOCTOPAGO(doctoBE, null);

                                    if (doctoPagoBE == null)
                                        continue;

                                    bool retorno = false;

                                    if (ValidarDatosParaFacturaElectronica(doctoBE))
                                    {

                                        string formapagosattemporal = "";
                                        if (!doctoD.CALCULAR_TIMBRADOFORMAPAGOSAT(doctoBE, ref formapagosattemporal, null))
                                        {
                                            continue;
                                        }

                                        iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(doctoBE, paramBE, iPosReporting.WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR, doctoPagoBE, null, "N", false, formapagosattemporal);
                                    
                                        CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
                                        fe.m_silentMode = true;
                                        fe.ShowDialog();
                                        retorno = fe.m_facturacionRealizada;
                                        fe.Dispose();
                                        GC.SuppressFinalize(fe);


                                        if(retorno)
                                        {

                                            doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

                                            iPosReporting.WFFacturaElectronica fe2 = new iPosReporting.WFFacturaElectronica(doctoBE, paramBE, iPosReporting.WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_GENERARPDF, null, "N");
                                            fe2.m_silentMode = true;
                                            fe2.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
                                            fe2.ShowDialog();
                                            retorno = fe2.m_facturacionRealizada;
                                            fe2.Dispose();
                                            GC.SuppressFinalize(fe2);
                                        }
                                        else
                                        {
                                            doctoBE.IFOLIOSAT--;
                                            doctoD.CambiarFOLIOSATDOCTOD(doctoBE, null);
                                        }
                                    }
                                    else
                                    {
                                        doctoBE.IFOLIOSAT = -3;
                                        doctoD.CambiarFOLIOSATDOCTOD(doctoBE, null);
                                    }
                                    


                                }



                            //doctosIdAEnviarRecibo = doctoD.seleccionarDOCTOSIDAENVARRECIBOMOVIL(DateTime.Today, null);

                            //foreach (long doctoId in doctosIdAEnviarRecibo)
                            //{
                            //    CDOCTOBE doctoBE = new CDOCTOBE();
                            //    doctoBE.IID = doctoId;
                            //    doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

                            //    if (doctoBE == null)
                            //        continue;



                            //    CUSUARIOSD usuariosD = new CUSUARIOSD();
                            //    Boolean usuarioTienePermisoDesgloseKit = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null);

                            //    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                            //    dictionary.Add("pdoctoid", doctoBE.IID);
                            //    dictionary.Add("usaDatosDeEntregaCuandoExista", "N");
                            //    dictionary.Add("desglosekits", usuarioTienePermisoDesgloseKit ? "S" : "N");
                            //    string strReporte = "recibolargo.frx";
                            //    string stSubject = "Recibo movil";


                            //    CCLIENTEBE clienteBE = new CCLIENTEBE();
                            //    CPERSONAD personaD = new CPERSONAD();
                            //    clienteBE.m_PersonaBE.IID = doctoBE.IPERSONAID;
                            //    clienteBE.m_PersonaBE = personaD.seleccionarPERSONA(clienteBE.m_PersonaBE, null);


                            //    CPERSONABE vendedorBE = new CPERSONABE();
                            //    vendedorBE.IID = doctoBE.IVENDEDORID;
                            //    vendedorBE = personaD.seleccionarPERSONA(vendedorBE, null);

                            //    string emailTo = clienteBE.m_PersonaBE.IEMAIL1 != null && clienteBE.m_PersonaBE.IEMAIL1.Contains("@") ? clienteBE.m_PersonaBE.IEMAIL1 : "";
                            //    emailTo += vendedorBE.IEMAIL1 != null && vendedorBE.IEMAIL1.Contains("@") ? (emailTo == "" ? "" : ",") + vendedorBE.IEMAIL1 : "";



                            //    iPos.Login_and_Maintenance.WFReportSending rp = new Login_and_Maintenance.WFReportSending(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.deusuario), emailTo, dictionary, stSubject, "PDF");
                            //    rp.m_silentMode = true;
                            //    rp.ShowDialog();
                            //  rp.Dispose();
                            //  GC.SuppressFinalize(rp);

                            //    doctoBE.ITRANREGSERVER = "S";

                            //    doctoD.CambiarTranRegServerDOCTOD(doctoBE, null);
                            //}

                        }

                        }

                    }
                    catch(Exception ex)
                    {
                    }

                    Thread.Sleep( 30000);
                }
        }

            
        private bool ValidarDatosParaFacturaElectronica(CDOCTOBE docto)
        {
            CPuntoDeVentaD pd = new CPuntoDeVentaD();
            if (!pd.VALIDAR_PARAFACTURAELECTRONICA(docto, null))
            {
                return false;
            }
            return true;
        }

        
    }
}
