using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iPosData;
using iPosBusinessEntity;
using FirebirdSql.Data.FirebirdClient;

namespace iPos
{
    public partial class WFConsolidadoAutomatico : Form
    {


        private bool m_operacionExitosa;
        private string m_iComentario;

        List<long> facturasIdGeneradas = new List<long>();

        public WFConsolidadoAutomatico()
        {
            InitializeComponent();
            m_operacionExitosa = true;
            m_iComentario = "";
        }

        private void WFConsolidadoAutomatico_Load(object sender, EventArgs e)
        {

            bool bEsNecesarioConsolidacionAutomatica = (((!(bool)CurrentUserID.CurrentParameters.isnull["IHAB_CONSOLIDADOAUTOMATICO"]) && CurrentUserID.CurrentParameters.IHAB_CONSOLIDADOAUTOMATICO != null && CurrentUserID.CurrentParameters.IHAB_CONSOLIDADOAUTOMATICO.Equals("S")) &&
                (((bool)CurrentUserID.CurrentParameters.isnull["IULT_CONSOLIDADOAUTOMATICO"]) || CurrentUserID.CurrentParameters.IULT_CONSOLIDADOAUTOMATICO == null || CurrentUserID.CurrentParameters.IULT_CONSOLIDADOAUTOMATICO.AddDays(1).CompareTo(DateTime.Today) < 0)
                );

            if (!bEsNecesarioConsolidacionAutomatica)
            {
                this.Close();
                return;
            }

                m_operacionExitosa = true;
            m_iComentario = "";
            progressBar1.Style = ProgressBarStyle.Marquee;
            backgroundWorker1.RunWorkerAsync();
        }


        private void actualizarUltimaFechaConsolidacion(DateTime fechaCurrent)
        {

            CPARAMETROD parametroD = new CPARAMETROD();
            DateTime bufferDate = CurrentUserID.CurrentParameters.IULT_CONSOLIDADOAUTOMATICO;
            CurrentUserID.CurrentParameters.IULT_CONSOLIDADOAUTOMATICO = fechaCurrent;
            if (!parametroD.CambiarULT_CONSOLIDADOAUTOMATICOPARAMETROD(CurrentUserID.CurrentParameters, CurrentUserID.CurrentParameters, null))
            {
                CurrentUserID.CurrentParameters.IULT_CONSOLIDADOAUTOMATICO = bufferDate;
            }
        }


        private void imprimirFacturasGeneradas()
        {

            if (facturasIdGeneradas != null && facturasIdGeneradas.Count > 0)
            {

                foreach (long doctoIdFactCons in facturasIdGeneradas)
                {
                    imprimirFacturaElectronicaPorId(doctoIdFactCons);

                }


                if (MessageBox.Show("Desea imprimir el ticket de la factura electronica ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (long doctoIdFactCons in facturasIdGeneradas)
                    {

                        imprimirTicketFacturaElectronicaPorId(doctoIdFactCons);

                    }
                }

            }

        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {


            DateTime fechaInicio = DateTime.Today.AddDays(-8);
            DateTime fechaFin = DateTime.Today.AddDays(-1);


            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();
            sucursalBE.IID = CurrentUserID.CurrentParameters.ISUCURSALID;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);


            if ((!(bool)CurrentUserID.CurrentParameters.isnull["IULT_CONSOLIDADOAUTOMATICO"]) && CurrentUserID.CurrentParameters.IULT_CONSOLIDADOAUTOMATICO != null && CurrentUserID.CurrentParameters.IULT_CONSOLIDADOAUTOMATICO.AddDays(1).CompareTo(fechaInicio) > 0)
            {
                fechaInicio = CurrentUserID.CurrentParameters.IULT_CONSOLIDADOAUTOMATICO.AddDays(1);
            }

            for (DateTime fechaCurrent = fechaInicio; fechaCurrent.CompareTo(fechaFin) <= 0; fechaCurrent = fechaCurrent.AddDays(1))
            {
                FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                FbTransaction fTrans = null;
                try
                {

                    fConn.Open();
                    fTrans = fConn.BeginTransaction();

                    CCONSOLIDADOD consolidadoD = new CCONSOLIDADOD();
                    long doctoIdFactCons = 0;
                    string sOmitirVentasFranquicias = "S";// CBOMITIRFRANQUICIAS.Checked ? "S" : "N";
                    string sIncluirGastos = "S"; //CBIncluirGastos.Checked ? "S" : "N";
                    int errorCode = 0;

                    decimal maximoMonto = 0;
                    CMAXFACTD maxFactD = new CMAXFACTD();
                    CMAXFACTBE maxFactBE = null;


                    if (sucursalBE != null)
                    {
                        maxFactBE = maxFactD.seleccionarMAXFACTXSucursalYFecha(sucursalBE.ICLAVE, fechaCurrent, fTrans);

                    }


                    if (maxFactBE != null)
                    {
                        DayOfWeek dia = fechaCurrent.DayOfWeek;
                        switch(dia)
                        {
                            case DayOfWeek.Monday:
                                if(maxFactBE.ILUN_HAY != null && maxFactBE.ILUN_HAY.Equals("S") && maxFactBE.ILUN_MAX > 0)
                                {
                                    maximoMonto = maxFactBE.ILUN_MAX;
                                }
                                break;

                            case DayOfWeek.Tuesday:
                                if (maxFactBE.IMAR_HAY != null && maxFactBE.IMAR_HAY.Equals("S") && maxFactBE.IMAR_MAX > 0)
                                {
                                    maximoMonto = maxFactBE.IMAR_MAX;
                                }
                                break;

                            case DayOfWeek.Wednesday:
                                if (maxFactBE.IMIE_HAY != null && maxFactBE.IMIE_HAY.Equals("S") && maxFactBE.IMIE_MAX > 0)
                                {
                                    maximoMonto = maxFactBE.IMIE_MAX;
                                }
                                break;

                            case DayOfWeek.Thursday:
                                if (maxFactBE.IJUE_HAY != null && maxFactBE.IJUE_HAY.Equals("S") && maxFactBE.IJUE_MAX > 0)
                                {
                                    maximoMonto = maxFactBE.IJUE_MAX;
                                }
                                break;

                            case DayOfWeek.Friday:
                                if (maxFactBE.IVIE_HAY != null && maxFactBE.IVIE_HAY.Equals("S") && maxFactBE.IVIE_MAX > 0)
                                {
                                    maximoMonto = maxFactBE.IVIE_MAX;
                                }
                                break;

                            case DayOfWeek.Saturday:
                                if (maxFactBE.ISAB_HAY != null && maxFactBE.ISAB_HAY.Equals("S") && maxFactBE.ISAB_MAX > 0)
                                {
                                    maximoMonto = maxFactBE.ISAB_MAX;
                                }
                                break;

                            case DayOfWeek.Sunday:
                                if (maxFactBE.IDOM_HAY != null && maxFactBE.IDOM_HAY.Equals("S") && maxFactBE.IDOM_MAX > 0)
                                {
                                    maximoMonto = maxFactBE.IDOM_MAX;
                                }
                                break;

                            default: break;
                        }
                    }

                    string omitirClientesRFC = CurrentUserID.CurrentParameters.IFACTCONSMAXPOR > 0 ? "N" : "S";

                    if (!consolidadoD.CONSOLIDADO_GENERAR(fechaCurrent, fechaCurrent, CurrentUserID.CurrentUser.IID, ref doctoIdFactCons, sOmitirVentasFranquicias, sIncluirGastos, maximoMonto, CurrentUserID.CurrentParameters.ICONSFACTOMITIRVALES , 0, omitirClientesRFC, CurrentUserID.CurrentParameters.IFACTCONSMAXPOR, null, ref errorCode, fTrans))
                    {

                        fTrans.Rollback();
                        fConn.Close();

                        if (errorCode != DBValues._ERRORCODE_NOHAYREGISTROSCONSOLIDAR)
                        {
                            m_iComentario = "Ocurrio un error " + consolidadoD.IComentario;
                            //MessageBox.Show("Ocurrio un error " + consolidadoD.IComentario);
                            m_operacionExitosa = false;
                            return;
                        }
                        else
                        {
                            actualizarUltimaFechaConsolidacion(fechaCurrent);
                        }
                    }
                    else
                    {
                        string resComentario = "";


                        if (!generarFacturaElectronicaPorId(doctoIdFactCons, fTrans, ref resComentario))
                        {

                            fTrans.Rollback();
                            fConn.Close();
                            m_iComentario = "No se pudo realizar la facturacion de la fecha " +  fechaCurrent.ToString("dd/MM/yyyy") + " . " + resComentario;
                            m_operacionExitosa = false;
                            //MessageBox.Show("No se pudo realizar la facturacion " + resComentario);
                            //if (m_strFileLog != null && m_strFileLog.Trim().Length > 0)
                            //{
                            //    Process.Start("notepad.exe", m_strFileLog);
                            //}



                            return;

                        }




                        fTrans.Commit();
                        fConn.Close();



                        actualizarUltimaFechaConsolidacion(fechaCurrent);


                        facturasIdGeneradas.Add(doctoIdFactCons);


                    }

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






        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Blocks;
            if (m_operacionExitosa)
            {
                MessageBox.Show("La facturacion ha sido hecha correctamente puede continuar");
             
            }
            else
            {
                MessageBox.Show("Hubo un problema al hacer la facturacion automatica, favor de avisar al supervisor. Detalle : " + m_iComentario);
               
                
            }


            if (facturasIdGeneradas != null && facturasIdGeneradas.Count > 0)
            {
                imprimirFacturasGeneradas();
            }

            this.Close();
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





            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(docto, CurrentUserID.CurrentParameters, iPosReporting.WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR, fTrans, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
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


            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(doctoBE, CurrentUserID.CurrentParameters, iPosReporting.WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_IMPRIMIRTICKET, doctoBE, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.m_bForzarImpresionTicket = true;
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;

        }


    }
}
