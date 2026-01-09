using FirebirdSql.Data.FirebirdClient;
using iPosBusinessEntity;
using iPosData;
using iPosReporting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Abonos
{
    public class ReciboElectronicoHelper
    {
        private string mensaje;
        private string m_strFileLog = String.Empty;

        public ReciboElectronicoHelper() { }

        public string Mensaje { get => mensaje; set => mensaje = value; }

        public bool Procesar(long folioPago, long clienteId, bool bModoAutomatico = false)
        {
            string comentarios = String.Empty;
            long doctoReciboId = 0;
            if(ProcesarSiAplica(folioPago, ref doctoReciboId, ref comentarios, clienteId, bModoAutomatico))
            {
                mensaje = comentarios;
                return true;
            }
            else
            {
                mensaje = "No se proceso. " + comentarios;
                return false;
            }
        }

        private bool ProcesarSiAplica(long pagoId, 
                                      ref long doctoReciboId, 
                                      ref string comentario,
                                      long clienteId, 
                                      bool bModoAutomatico 
                            )
        {
            CPAGOBE pagoBE = new CPAGOBE();
            CPAGOD pagoD = new CPAGOD();
            pagoBE.IID = pagoId;
            pagoBE = pagoD.seleccionarPAGO(pagoBE, null);
            if (pagoBE == null)
            {
                comentario = "El pago no existe";
                return false;
            }

            if (pagoBE.IRECIBOELECTRONICOID > 0)
            {
                doctoReciboId = pagoBE.IRECIBOELECTRONICOID;
                comentario = "El registro ya tiene un recibo electronico";
                return false;

            }

            if (pagoBE.IIMPORTE <= 0 || (pagoBE.IREVERTIDO != null && pagoBE.IREVERTIDO.Equals("S")))
            {
                return true;
            }

            CDOCTOD doctoD = new CDOCTOD();

            CPERSONAD personaD = new CPERSONAD();
            CPERSONABE personaBE = new CPERSONABE();
            personaBE.IID = clienteId;
            personaBE = personaD.seleccionarPERSONA(personaBE, null);


            if (personaBE != null)
            {

                if (!bModoAutomatico)
                {
                    if (MessageBox.Show("Desea registrar un recibo electronico de este abono ",
                                        "Confirmacion",
                                        MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return true;
                    }
                }


                    
                    if (pagoBE.IFORMAPAGOID != DBValues._FORMA_PAGO_EFECTIVO && (pagoBE.ICUENTAPAGOCREDITO == null || pagoBE.ICUENTAPAGOCREDITO.Trim().Equals("")))
                    {

                        WFCuentaPago cuentaPago = new WFCuentaPago(personaBE.ICREDITOREFERENCIAABONOS);
                        cuentaPago.ShowDialog();

                        string strCuentaPago = cuentaPago.strCuentaPago.Trim();

                        cuentaPago.Dispose();
                        GC.SuppressFinalize(cuentaPago);

                        if (strCuentaPago.Length == 0)
                        {

                            comentario = "Debe escribir la cuenta de pago para poder hacer el recibo electronico";
                            return false;
                        }

                        pagoBE.ICUENTAPAGOCREDITO = strCuentaPago;

                        if (!pagoD.CambiarCUENTAPAGOCREDITO_PAGOD(pagoBE, pagoBE, null))
                        {

                            MessageBox.Show("Error al actualizar la cuenta pago " + pagoD.IComentario);
                            return false;
                        }
                }



                    if (CurrentUserID.CurrentParameters.IVERSIONCFDI != null && 
                        (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")))
                    {
                        return ProcesarReciboElectronico33(pagoId, ref doctoReciboId, ref comentario, bModoAutomatico);
                    }
                    else
                    {
                        //return procesarReciboElectronico(pagoId, ref doctoReciboId, ref comentario);
                    }
            }

            return true;
        }

        private bool ProcesarReciboElectronico33(long pagoId, ref long doctoReciboId, ref string comentario, bool bModoAutomatico)
        {
            CDOCTOD doctoD = new CDOCTOD();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (!doctoD.RECIBOELECTRONICO_P_GENERAR_33(pagoId, CurrentUserID.CurrentUser.IID, ref doctoReciboId, fTrans))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    comentario = "Error al generar el recibo electronico " + doctoD.IComentario;
                    return false;
                }

                if (!GenerarFacturaElectronicaPorId(doctoReciboId, fTrans, ref comentario))
                {
                    doctoReciboId = 0;
                    fTrans.Rollback();
                    fConn.Close();
                    comentario = "No se pudo realizar la facturacion " + comentario;
                    if (m_strFileLog != null && m_strFileLog.Trim().Length > 0)
                    {
                        Process.Start("notepad.exe", m_strFileLog);
                    }

                    return false;

                }

                fTrans.Commit();
                fConn.Close();

                imprimirFacturaElectronicaPorId(doctoReciboId, bModoAutomatico);
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

            return true;
        }

        private bool GenerarFacturaElectronicaPorId(long doctoId, FbTransaction fTrans, ref string resComentario)
        {
            bool esVersion33 = (CurrentUserID.CurrentParameters.IVERSIONCFDI != null &&
                                (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")));

            CDOCTOBE docto = new CDOCTOBE();
            CDOCTOBE doctoRef = new CDOCTOBE();
            CDOCTOD doctoD = new CDOCTOD();
            docto.IID = doctoId;
            docto = doctoD.seleccionarDOCTO(docto, fTrans);

            if (docto == null)
            {

                resComentario = "No se encontro la factura electronica";
                return false;
            }

            doctoRef.IID = docto.IDOCTOREFID;
            doctoRef = doctoD.seleccionarDOCTO(doctoRef, fTrans);

            if (doctoRef == null && !esVersion33)
            {

                resComentario = "No se encontro la referencia de factura electronica";
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

            WFFacturaElectronica fe = new WFFacturaElectronica(
                docto, 
                CurrentUserID.CurrentParameters, 
                WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR, 
                fTrans, 
                doctoRef, 
                CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);

            fe.m_silentMode = true;
            fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, 
                                                                   DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            if (!retorno)
            {
                resComentario = fe.m_iComentario;
            }
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

        private bool imprimirFacturaElectronicaPorId(long doctoId,bool bModoAutomatico)
        {

            bool retorno;

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoRef = new CDOCTOBE();
            CDOCTOBE docto = new CDOCTOBE();
            docto.IID = doctoId;
            docto = doctoD.seleccionarDOCTO(docto, null);

            if (docto == null)
            {

                MessageBox.Show("No se encontro la factura electronica");
                return false;
            }

            doctoRef.IID = docto.IDOCTOREFID;
            doctoRef = doctoD.seleccionarDOCTO(doctoRef, null);

            if ((bool)docto.isnull["IFOLIOSAT"] || (bool)docto.isnull["IESTATUSDOCTOID"]
                || docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || docto.IFOLIOSAT <= 0)
            {
                MessageBox.Show("No se puede imprimir la factura electronica , " +
                                "cheque que se haya generado la factura electronica de este registro");
                return false;
            }


            WFFacturaElectronica fe = new WFFacturaElectronica(
                docto, 
                CurrentUserID.CurrentParameters, 
                WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_GENERARPDF, 
                doctoRef, 
                CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);

            fe.m_silentMode = bModoAutomatico;

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, 
                                                                   DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;
        }
    }
}
