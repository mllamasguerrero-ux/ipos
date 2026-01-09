using FirebirdSql.Data.FirebirdClient;
using iPos.Verifone;
using iPosBusinessEntity;
using iPosData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using VerifoneSdk;

namespace iPos
{
    //public interface IVerifoneListenerCallBack
    //{
    //    void UpdateConsole(string title, string content);
    //    void UpdateConsolveWithEvent(string status, string type, string message);
    //}

    public class PagoVerifoneHelper
    {

        public static PaymentSdk mPsdk { get; set; }
        public static Listener mCommerceListener { get; set; }
        public static bool mDeviceInitialized { get; set; } = false;

        public static DateTime? mFechaLogin { get; set; } = null;


        public static string mAppSpecificData { get; set; }



        public static void LlenarConfiguracionVerifone(long cajaId)
        {

            CVERIFONECAJACONFIGBE verifoneCajaConfigBE = new CVERIFONECAJACONFIGBE();

            //por default pon inactivo
            verifoneCajaConfigBE.IACTIVO = "N";
            verifoneCajaConfigBE.ICAJAID = cajaId;

            CVERIFONECAJACONFIGD verifoneCajaConfigD = new CVERIFONECAJACONFIGD();
            CVERIFONECONFIGD verifoneConfigD = new CVERIFONECONFIGD();
            CVERIFONECONFIGBE verifoneConfigBE = new CVERIFONECONFIGBE();
            verifoneConfigBE = verifoneConfigD.seleccionarVERIFONECONFIG_Unico(null);
            if (verifoneConfigBE != null && verifoneConfigBE.IACTIVO == "S")
            {
                verifoneCajaConfigBE = verifoneCajaConfigD.seleccionarVERIFONECAJACONFIG_x_CAJAID(verifoneCajaConfigBE, null);

                if (verifoneCajaConfigBE == null)
                    verifoneCajaConfigBE = new CVERIFONECAJACONFIGBE();

                verifoneCajaConfigBE.IUSERID = string.IsNullOrEmpty(verifoneCajaConfigBE.IMERCHANTID) ?
                                                        verifoneConfigBE.IUSERID : verifoneCajaConfigBE.IUSERID;
                verifoneCajaConfigBE.ICONTRASENA = string.IsNullOrEmpty(verifoneCajaConfigBE.IMERCHANTID) ?
                                                        verifoneConfigBE.ICONTRASENA : verifoneCajaConfigBE.ICONTRASENA;
                verifoneCajaConfigBE.ISHIFTNUMBER = string.IsNullOrEmpty(verifoneCajaConfigBE.ISHIFTNUMBER) ?
                                                        verifoneConfigBE.ISHIFTNUMBER : verifoneCajaConfigBE.ISHIFTNUMBER;
                verifoneCajaConfigBE.IMERCHANTID = string.IsNullOrEmpty(verifoneCajaConfigBE.IMERCHANTID) ?
                                                        verifoneConfigBE.IMERCHANTID : verifoneCajaConfigBE.IMERCHANTID;
                verifoneCajaConfigBE.IOPERATORLOCALE = string.IsNullOrEmpty(verifoneCajaConfigBE.IOPERATORLOCALE) ?
                                                        verifoneConfigBE.IOPERATORLOCALE : verifoneCajaConfigBE.IOPERATORLOCALE;
            }
            iPos.CurrentUserID.CurrentVerifoneCajaConfig = verifoneCajaConfigBE;

        }

        public static void PreparaPinPad(bool limpiaConexionAntesDeInicializar)
       {

            if(mPsdk == null)
                mPsdk = new PaymentSdk();

            if(mCommerceListener == null)
                mCommerceListener = new Listener();

            if(limpiaConexionAntesDeInicializar)
            {
                mDeviceInitialized = false;
                mFechaLogin = null;
            }

            if (mDeviceInitialized)
            {
                return;
            }

            WFPagoVerifone fq = new WFPagoVerifone(mPsdk, mCommerceListener, mDeviceInitialized, mFechaLogin);
            mCommerceListener.mw = fq;
            fq.mOperation = "Inicializar";
            fq.mVerifoneCajaConfig = iPos.CurrentUserID.CurrentVerifoneCajaConfig;
            fq.mDeviceInitialized = mDeviceInitialized;
            fq.mFechaLogin = mFechaLogin;
            fq.mTearDownOnInitialize = limpiaConexionAntesDeInicializar;
            fq.ShowDialog();
            mPsdk = fq.mPsdk;
            mDeviceInitialized = fq.mDeviceInitialized;
            mFechaLogin = fq.mFechaLogin;
            mCommerceListener = fq.mCommerceListener;
            mCommerceListener.mw = null;
            fq.Dispose();
            GC.SuppressFinalize(fq);
        }

        public static bool Pagar(ref CDOCTOBE doctoBE, decimal montoPago, ref long verifonePaymentId, ref string strResTransaccion,ref bool reimprimirVouchers, FbTransaction st)
        {

            if (mPsdk == null)
                mPsdk = new PaymentSdk();

            if (mCommerceListener == null)
                mCommerceListener = new Listener();

            CVERIFONEPAYMENTD verifonePaymentD = new CVERIFONEPAYMENTD();
            CDOCTOD doctoD = new CDOCTOD();
            CVERIFONEPAYMENTBE verifonePayment = new CVERIFONEPAYMENTBE();

            //long consecutivoDiaFecha = 0;
            bool retorno = false;



            try
            {
                //no se si es necesario asignar el folio a la venta
                if (doctoBE.IFOLIO == 0)
                {
                    if (!doctoD.DOCTO_ASIGNAR_FOLIO(doctoBE, st))
                    {
                        strResTransaccion = "Hubo un error al asignar el folio ";
                        return false;
                    }

                    doctoBE = doctoD.seleccionarDOCTO(doctoBE, st);
                }


                ////obtener consecutivo
                //if (!verifonePaymentD.GETCONSECUTIVO(DateTime.Today, ref consecutivoDiaFecha, st))
                //{
                //    strResTransaccion = "Hubo un error al obtener el consecutivo ";
                //    return false;
                //}

                //caja
                CCAJAD cajaDB = new CCAJAD();
                CCAJABE cajaBEB = new CCAJABE();
                cajaBEB.IID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
                cajaBEB = cajaDB.seleccionarCAJA(cajaBEB, null);


                //sucursal
                CSUCURSALD sucursalDB = new CSUCURSALD();
                CSUCURSALBE sucursalBEB = new CSUCURSALBE();
                sucursalBEB.IID = iPos.CurrentUserID.CurrentParameters.ISUCURSALID;
                sucursalBEB = sucursalDB.seleccionarSUCURSAL(sucursalBEB, null);

                //vendedor
                CPERSONAD personaDB = new CPERSONAD();
                CPERSONABE personaBEB = new CPERSONABE();
                personaBEB.IID = doctoBE.IVENDEDORID;
                personaBEB = personaDB.seleccionarPERSONA(personaBEB, null);

                //string terminal = cajaBEB.INUMEROTERMINALBANCOMER.ToString();//la terminal se obtiene del catalogo de caja
                ////string sesion = ObtenerNumeroSession().ToString();//la sesion es el id del corte actual
                //string fechaHoraT = DateTime.Now.ToString("yyMMddHHmmss");//la fecha se formatea de acuerdo al documento pag 50
                //string referenciaComer = doctoBE.IFOLIO.ToString();//nosotros en la referencia del comercio mandamos el folio
                //string claveOp = personaBEB.ICLAVE;//la clave del operador es la clave del usuario
                //string afiliacion = !String.IsNullOrEmpty(CurrentUserID.CurrentCaja.IAFILIACIONBANCOMER) ?
                //                    CurrentUserID.CurrentCaja.IAFILIACIONBANCOMER :
                //                    ClsConfiguracion.Afiliacion;//la afliacion se obtiene de la base de datos o del archivo pinpadconfig.txt
                //string transaccionB = consecutivoDiaFecha.ToString();//consecutivo

                bool pagoExitoso = false;
                reimprimirVouchers = false;


                VerifonePaymentParam paymentParam = new VerifonePaymentParam();
                var temporalLocalPaymentId = Guid.NewGuid().ToString();
                
                //paymentParam.CustomerNote = personaBEB.ICLAVE;
                paymentParam.SaleNote = doctoBE.IFOLIO.ToString(); ;
                paymentParam.LocalPaymentId = temporalLocalPaymentId; // doctoBE.IID.ToString();
                paymentParam.CashierId = personaBEB.ICLAVE;
                paymentParam.Venue = sucursalBEB.INOMBRE;
                paymentParam.Currency =  "MXN";
                paymentParam.Amount = montoPago;


                WFPagoVerifone fq = new WFPagoVerifone(mPsdk, mCommerceListener, mDeviceInitialized, mFechaLogin);
                mCommerceListener.mw = fq;
                fq.mVerifoneCajaConfig = iPos.CurrentUserID.CurrentVerifoneCajaConfig;
                fq.mOperation = "Pagar";
                fq.mPaymentParam = paymentParam;
                fq.mDeviceInitialized = mDeviceInitialized;
                fq.mFechaLogin = mFechaLogin;
                fq.ShowDialog();
                mPsdk = fq.mPsdk;
                mDeviceInitialized = fq.mDeviceInitialized;
                mFechaLogin = fq.mFechaLogin;
                mCommerceListener = fq.mCommerceListener;
                //mAppSpecificData = fq.mAppSpecificData;
                verifonePayment = fq.mVerifonePayment;
                pagoExitoso = fq.mPagoExitoso;
                strResTransaccion = fq.mStrResTransaccion;
                reimprimirVouchers = fq.mPreguntarImprimirRecibosAlFinalizar;
                mCommerceListener.mw = null;
                fq.Dispose();
                GC.SuppressFinalize(fq);



                //guardar la informacion de verifone
                if (pagoExitoso)
                {

                    verifonePayment.IDOCTOID = doctoBE.IID;
                    verifonePayment.ITIPOTRANSACCION = "001";
                    verifonePayment.IESTADOTRANSACCIONID = 1;
                    //verifonePayment.ICREDITODEBITO = strCreditoDebito;
                    //verifonePayment.IVALTIPOCARD = strNumeroTarjeta;



                    // calcula credito / debito
                    //if (verifonePayment.INUMEROTARJETA != null && verifonePayment.INUMEROTARJETA.Trim().Length > 0)
                    //    verifonePayment.ICREDITODEBITO = ObtenerTipoTarjeta(verifonePayment.INUMEROTARJETA);

                    var bufferVerifontPayment = verifonePaymentD.AgregarVERIFONEPAYMENTD(verifonePayment, st);
                    if (bufferVerifontPayment == null)
                    {
                        MessageBox.Show("Se realizo la operacion  pero no se pudo guardar el registro " + verifonePaymentD.IComentario);
                    }
                    else
                    {
                        verifonePayment = bufferVerifontPayment;
                        verifonePaymentId = verifonePayment.IID;
                    }

                    //ponerle la bandera a pagobancomeraplicado a docto para saber que tiene pago aplicado por pinpad
                    doctoBE.IPAGOVERIFONEAPLICADO = "S";

                    if (!doctoD.CambiarPAGOVERIFONEAPLICADO(doctoBE, null))
                    {
                        MessageBox.Show("Se realizo la operacion  pero no se pudo poner la bandera del docto " + doctoD.IComentario);
                    }

                }

                return pagoExitoso;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }



        }



        public static bool Cancelar(ref CDOCTOBE doctoBE, long verifonePaymentOriginalId, ref long verifonePaymentId, ref string strResTransaccion, FbTransaction st)
        {

            if (mPsdk == null)
                mPsdk = new PaymentSdk();

            if (mCommerceListener == null)
                mCommerceListener = new Listener();

            
            CVERIFONEPAYMENTD verifonePaymentD = new CVERIFONEPAYMENTD();
            CDOCTOD doctoD = new CDOCTOD();
            CVERIFONEPAYMENTBE verifonePayment = new CVERIFONEPAYMENTBE();
            
            bool retorno = false;
            

            try
            {
                //obtener consecutivo
                //if (!bancomerParamD.BANCOMER_GETCONSECUTIVO(DateTime.Today, ref consecutivoDiaFecha, st))
                //{
                //    strResTransaccion = "Hubo un error al obtener el consecutivo ";
                //    return false;
                //}

                //obtener los datos de bancomer de la transaccion original
                CVERIFONEPAYMENTBE transOriginal = new CVERIFONEPAYMENTBE();
                transOriginal.IID = verifonePaymentOriginalId;
                transOriginal = verifonePaymentD.seleccionarVERIFONEPAYMENT(transOriginal, st);//se obtiene la transaccion original que se quierew cancelar

                if (transOriginal == null)
                {
                    strResTransaccion = "No se pudo obtener los datos de la transaccion original";
                    return false;
                }

                //se obtiene la cadena para la cancelacion llamando al metodo correspondiente, enviando los param. de la transaccion que se quiere cancelar
                //string cadenaVenta = obtenerCadenaParaCancelarPinPad(doctoBE, transOriginal/*, consecutivoDiaFecha*/);
                //Enviar.fncEglobalBBVA(cadenaVenta, 0, MacAlterna);//se envia la cadena

                bool cancelacionExitosa = false;


                WFPagoVerifone fq = new WFPagoVerifone(mPsdk, mCommerceListener, mDeviceInitialized, mFechaLogin);
                mCommerceListener.mw = fq;
                fq.mVerifoneCajaConfig = iPos.CurrentUserID.CurrentVerifoneCajaConfig;
                fq.mAppSpecificData = transOriginal.IAPPSPECIFICDATA;
                fq.mOperation = "Cancelar";
                fq.mDeviceInitialized = mDeviceInitialized;
                fq.mFechaLogin = mFechaLogin;
                fq.ShowDialog();
                mPsdk = fq.mPsdk;
                mDeviceInitialized = fq.mDeviceInitialized;
                mFechaLogin = fq.mFechaLogin;
                mCommerceListener = fq.mCommerceListener;
                cancelacionExitosa = fq.mCancelacionExitosa;
                verifonePayment = fq.mVerifonePayment;
                strResTransaccion = fq.mStrResTransaccion;
                mCommerceListener.mw = null;
                fq.Dispose();
                GC.SuppressFinalize(fq);
                

                


                //guardar informacion de transaccion de bancomer
                if (cancelacionExitosa)
                {

                    //guardar la informacion de cancelacion
                    verifonePayment.IDOCTOID = doctoBE.IID;
                    verifonePayment.ITIPOTRANSACCION = "002";
                    verifonePayment.IESTADOTRANSACCIONID = 1;
                    verifonePayment.IREFID = verifonePaymentOriginalId;



                    //// calcula credito / debito
                    //if (bancomerParam.INUMEROTARJETA != null && bancomerParam.INUMEROTARJETA.Trim().Length > 0)
                    //    bancomerParam.ICREDITODEBITO = ObtenerTipoTarjeta(bancomerParam.INUMEROTARJETA);
                    


                    var bufferVerifontPayment = verifonePaymentD.AgregarVERIFONEPAYMENTD(verifonePayment, st);
                    if (bufferVerifontPayment == null)
                    {
                        MessageBox.Show("Se realizo la operacion  pero no se pudo guardar el registro " + verifonePaymentD.IComentario);
                    }
                    else
                    {
                        verifonePayment = bufferVerifontPayment;
                        verifonePaymentId = verifonePayment.IID;
                    }



                    //poner la transaccion original como cancelada
                    transOriginal.IREFID = verifonePaymentId;
                    transOriginal.IESTADOTRANSACCIONID = 2;
                    verifonePaymentD.CambiarVERIFONEPAYMENT_ESTADO_Y_REFID(transOriginal, st);




                    // si ya no hay pagos con tarjeta pinpad activos en este docto cambiar el flag 
                    CVERIFONEPAYMENTBE bufferBanc = new CVERIFONEPAYMENTBE();
                    bufferBanc.IDOCTOID = transOriginal.IDOCTOID;
                    bufferBanc.ITIPOTRANSACCION = "001";
                    bufferBanc.IESTADOTRANSACCIONID = 1;
                    List<CVERIFONEPAYMENTBE> listaPagosSimple = verifonePaymentD.seleccionarVERIFONEPAYMENT_PORDOCTO_Simple(bufferBanc, st);
                    if (listaPagosSimple == null || listaPagosSimple.Count == 0)
                    {

                        doctoBE.IPAGOVERIFONEAPLICADO = "N";

                        if (!doctoD.CambiarPAGOVERIFONEAPLICADO(doctoBE, null))
                        {
                            MessageBox.Show("Se realizo la operacion  pero no se pudo cambiar la bandera del docto " + doctoD.IComentario);
                        }
                    }



                }

                return cancelacionExitosa;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }



        }


        public static void ImprimirVoucher(long verifonePaymentId, bool bImprimirCliente, bool bImprimirComercio)
        {

            if (mPsdk == null)
                mPsdk = new PaymentSdk();

            if (mCommerceListener == null)
                mCommerceListener = new Listener();

            CVERIFONEPAYMENTD verifonePaymentD = new CVERIFONEPAYMENTD();
            CVERIFONEPAYMENTBE verifonePaymentBE = new CVERIFONEPAYMENTBE();
            verifonePaymentBE.IID = verifonePaymentId;
            verifonePaymentBE = verifonePaymentD.seleccionarVERIFONEPAYMENT(verifonePaymentBE, null);

            bool impresionHecha = false;

            while (!impresionHecha)
            {
                if (bImprimirCliente)
                {
                    ImprimirVoucher(verifonePaymentBE.IAPPSPECIFICDATA, true);
                }
                if (bImprimirComercio)
                {
                    ImprimirVoucher(verifonePaymentBE.IAPPSPECIFICDATA, false);
                }

                if (MessageBox.Show("Se imprimieron correctamente los voucher?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    impresionHecha = true;
                }
            }

            

        }


        public static void ImprimirVoucher(string appSpecificData, bool bEsDeCliente)
        {


            WFPagoVerifone fq = new WFPagoVerifone(mPsdk, mCommerceListener, mDeviceInitialized, mFechaLogin);
            mCommerceListener.mw = fq;
            fq.mAppSpecificData = appSpecificData; 
            fq.mOperation = "Reimprimir";
            fq.mReceiptType = bEsDeCliente ? ReceiptType.CUSTOMER : ReceiptType.MERCHANT;
            fq.mDeviceInitialized = mDeviceInitialized;
            fq.mFechaLogin = mFechaLogin;
            fq.ShowDialog();
            mPsdk = fq.mPsdk;
            mDeviceInitialized = fq.mDeviceInitialized;
            mFechaLogin = fq.mFechaLogin;
            mCommerceListener = fq.mCommerceListener;
            mCommerceListener.mw = null;
            fq.Dispose();
            GC.SuppressFinalize(fq);

        }


        public static void Login()
        {

            if (mPsdk == null)
                mPsdk = new PaymentSdk();

            if (mCommerceListener == null)
                mCommerceListener = new Listener();

            WFPagoVerifone fq = new WFPagoVerifone(mPsdk, mCommerceListener, mDeviceInitialized, mFechaLogin);
            mCommerceListener.mw = fq;
            fq.mOperation = "Login";
            fq.mDeviceInitialized = mDeviceInitialized;
            fq.mFechaLogin = mFechaLogin;
            fq.ShowDialog();
            mPsdk = fq.mPsdk;
            mDeviceInitialized = fq.mDeviceInitialized;
            mFechaLogin = fq.mFechaLogin;
            mCommerceListener = fq.mCommerceListener;
            mCommerceListener.mw = null;
            fq.Dispose();
            GC.SuppressFinalize(fq);
        }

    }



    public class Listener : CommerceListener2
    {
        public WFPagoVerifone mw { get; set; }

        public Listener()
        {
        }

        public Listener(WFPagoVerifone m)
        {
            mw = m;
        }

        private void Log(string title, string content)
        {
            if(mw != null)
            {
                mw?.Invoke(new Action(() => { mw.Log(title, content); }));
            }
        }


        private void LogWithEvent(string status, string type, string message)
        {
            if (mw != null)
            {
                mw.Invoke(new Action(() => { mw.LogWithEvent(status, type, message); }));
            }
        }

        public override void HandleAmountAdjustedEvent(AmountAdjustedEvent sdk_event)
        {
            Log("AmountAdjustedEvent: ", "Invoked.\n");
        }

        public override void HandleBasketAdjustedEvent(BasketAdjustedEvent sdk_event)
        {
            Log("BasketAdjustedEvent: ", "Invoked.\n"); 
        }

        public override void HandleBasketEvent(BasketEvent sdk_event)
        {
            Log("BasketEvent: ", "Invoked.\n");
        }

        public override void HandleCardInformationReceivedEvent(CardInformationReceivedEvent sdk_event)
        {
            Log("CardInformationReceivedEvent: ", "Invoked.\n"); 
            var cardInfo = sdk_event.CardInformation;
            if (cardInfo != null)
            {
                string s = "Card Brand" + cardInfo.PaymentBrand + "\n" +
                            "PAN Last 4" + cardInfo.PanLast4 + "\n" +
                            "Track 2" + cardInfo.CardTrack2;

                Log("CardInformationReceivedEvent: ", s); 
            }
        }

        public override void HandleCommerceEvent(CommerceEvent sdk_event)
        {
            Log("CommerceEvent: ", "Invoked.\n");
            
            if(mw != null && mw.mOperation == "Reimprimir")
            {
                if(sdk_event.Status == 0 && (sdk_event.Type == "RECEIPT_REPRINTED" || sdk_event.Type == "RECEIPT_PRINTED"))
                {
                    Log("Reimpresion existosa ", "");
                    mw.ReimpresionExitosa();
                }
                else if(sdk_event.Status != 0)
                {
                    Log("Reimpresion erronea ", sdk_event.Message);
                    mw.ReimpresionErronea();
                }
            }
        }

        public override void HandleDeviceManagementEvent(DeviceManagementEvent sdk_event)
        {
            Log("DeviceManagementEvent: ", "Invoked.\n");
        }

        public override void HandleDeviceVitalsInformationEvent(DeviceVitalsInformationEvent sdk_event)
        {
            Log("DeviceVitalsInformationEvent: ", "Invoked.\n"); 
        }

        public override void HandleHostAuthorizationEvent(HostAuthorizationEvent sdk_event)
        {
            Log("HostAuthorizationEvent: ", "Invoked.\n");
        }

        public override void HandleHostFinalizeTransactionEvent(HostFinalizeTransactionEvent sdk_event)
        {
           Log("HostFinalizeTransactionEvent: ", "Invoked.\n"); 
        }

        public override void HandleLoyaltyReceivedEvent(LoyaltyReceivedEvent sdk_event)
        {
           Log("LoyaltyReceivedEvent: ", "Invoked.\n");
        }

        public override void HandleNotificationEvent(NotificationEvent sdk_event)
        {
           Log("NotificationEvent: ", "Invoked.\n");

            if (sdk_event.NotificationType == NotificationType.TRANSACTION_OUTCOME)
            {
                Console.WriteLine("NOTIFICATION TYPE " + sdk_event.NotificationType);
            }
        }

        public override void HandlePaymentCompletedEvent(PaymentCompletedEvent sdk_event)
        {
            Log("PaymentCompletedEvent: ", "Invoked.\n");

            if (sdk_event.Status == 0)
            {
                Log("PaymentCompletedEvent: ", "Payment Success.\n"); 
                
                //if(mw != null)
                //    mw.mAppSpecificData = sdk_event.Payment.AppSpecificData;



                string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
                string status = sdk_event.Status.ToString();
                string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
                LogWithEvent(status, type, message); 


                if(sdk_event.Payment.TransactionType == TransactionType.VOID_TYPE)
                {
                    if(sdk_event.Payment.AuthResult != AuthorizationResult.VOIDED)
                    {
                        mw?.CancelacionErronea(sdk_event);
                    }
                    else
                    {
                        mw?.CancelacionExitosa(sdk_event);
                    }

                }
                else if(sdk_event.Payment.TransactionType == TransactionType.PAYMENT)
                {
                    if(sdk_event.Payment.AuthResult != AuthorizationResult.AUTHORIZED)
                    {

                        mw?.Invoke(new Action(() => { mw.PagoError(); }));
                    }
                    else
                    {
                        
                        mw?.Invoke(new Action(() => { mw.PagoRealizado(sdk_event); }));
                    }
                }





            }
            else if(sdk_event.Status == StatusCode.DEVICE_CONNECTION_LOST)
            {

                Log("PaymentCompletedEvent: ", "Payment Connection Lost.\n");

                string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
                string status = sdk_event.Status.ToString();
                string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
                LogWithEvent(status, type, message);


                mw?.Invoke(new Action(() => { mw.TerminalDesconectadaAMedioPago(); }));
            }
            else
            {

                Log("PaymentCompletedEvent: ", "Payment Failure.\n");

                string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
                string status = sdk_event.Status.ToString();
                string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
                LogWithEvent(status, type, message); 


                mw?.Invoke(new Action(() => { mw.PagoError(); }));
            }




        }

        public override void HandlePrintEvent(PrintEvent sdk_event)
        {
            Log("PrintEvent: ", "Invoked.\n");

            //if(sdk_event.Status == 0 && sdk_event.Type)
            //{
            //    mw?.ReimpresionExitosa();
            //}
            //else
            //{
            //    Log("PrintEvent")
            //    mw?.ReimpresionErronea();
            //}
        }

        public override void HandleReceiptDeliveryMethodEvent(ReceiptDeliveryMethodEvent sdk_event)
        {
            Log("ReceiptDeliveryMethodEvent: ", "Invoked.\n");
        }

        public override void HandleReconciliationEvent(ReconciliationEvent sdk_event)
        {
            Log("ReconciliationEvent: ", "Invoked.\n");

            string s = "Status Code: " + sdk_event.Status.ToString() + "Message: " + sdk_event.Message;

            Log("ReconciliationEvent: ", s);

        }

        public override void HandleReconciliationsListEvent(ReconciliationsListEvent sdk_event)
        {
            Log("ReconciliationsListEvent: ", "Invoked.\n");
        }

        public override void HandleStatus(Status status)
        {
            Log("Status: ", "Invoked.\n");


            if (status.Type == "STATUS_INITIALIZED")
            {

                if (status.StatusCode == 0)
                {
                    Log("Connection Status: ", "Success.\n");
                    mw?.Invoke(new Action(() => { mw.InicializacionExitosa(); }));
                }
                else
                {
                    Log("Connection Status: ", "Failure.\n");
                    mw?.Invoke(new Action(() => { mw.InicializacionFallida(); }));

                    string type = status.Type.ToString();
                    LogWithEvent(status.StatusCode.ToString(), type, status.Message);
                }
            }
            else if(status.Type == "STATUS_TEARDOWN")
            {

                if (status.StatusCode == 0)
                {
                    Log("Teardown Status: ", "Success.\n");
                    mw?.Invoke(new Action(() => { mw.TeardownExitoso(); }));
                }
                else
                {
                    Log("Teardown Status: ", "Failure.\n");
                    mw?.Invoke(new Action(() => { mw.TeardownFallida(); }));

                    string type = status.Type.ToString();
                    LogWithEvent(status.StatusCode.ToString(), type, status.Message);
                }
            }

        }

        public override void HandleStoredValueCardEvent(StoredValueCardEvent sdk_event)
        {
            Log("StoredValueCardEvent: ", "Invoked.\n"); 
        }

        public override void HandleTransactionEvent(TransactionEvent sdk_event)
        {

            Log("TransactionEvent: ", "Invoked.\n");

            if (sdk_event.Status == 0)
            {
                Log("TransactionEvent: ", "Success.\n"); 

                if(sdk_event.Type == TransactionEvent.LOGIN_COMPLETED)
                {
                    mw?.Invoke(new Action(() => { mw.LoginExitoso(); }));
                }
                else if(sdk_event.Type == "SESSION_STARTED")
                {
                    mw?.Invoke(new Action(() => { mw.SessionCreada(); }));
                }
                else if (sdk_event.Type == "SESSION_ENDED")
                {
                    mw?.Invoke(new Action(() => { mw.EndSessionExitoso(); }));
                }
            }
            else
            {
                if (sdk_event.Type == "SESSION_STARTED")
                {
                    mw?.Invoke(new Action(() => { mw.SessionNoPudoCrearse(true); }));


                    Log("TransactionEvent: ", "Failure.\n");
                    mw?.Invoke(new Action(() => { mw.ErrorEnTransactionEvent(); }));
                }
                else if (sdk_event.Type == "LOGIN_COMPLETED")
                {
                    mw?.Invoke(new Action(() => { mw.LoginFallido(true); }));


                    Log("TransactionEvent: ", "Failure.\n");
                    mw?.Invoke(new Action(() => { mw.ErrorEnTransactionEvent(); }));
                }

                Log("TransactionEvent: ",  sdk_event.Message + "\n");


            }

            string type = sdk_event.Type == null ? "(null)" : sdk_event.Type.ToString();
            string status = sdk_event.Status.ToString();
            string message = sdk_event.Message == null ? "(null)" : sdk_event.Message.ToString();
            
            //mw?.Invoke(new Action(() => {
            //    if(mw != null)
            //        mw.UpdateConsolveWithEvent(status, type, message);
            //}));

        }

        public override void HandleTransactionQueryEvent(TransactionQueryEvent sdk_event)
        {
            Log("TransactionQueryEvent: ", "Invoked.\n");

            if (sdk_event.FoundPayments())
            {
                var payments = sdk_event.Payments;
                


                var payment = payments.FirstOrDefault(p => p.LocalPaymentId == mw.mPaymentParam.LocalPaymentId);
                


                if (payment.AuthResult == AuthorizationResult.AUTHORIZED)
                {

                    mw?.Invoke(new Action(() => { mw.PagoRealizadoQueryEvent(sdk_event, payment); }));
                }
                else if(payment.AuthResult == AuthorizationResult.IN_PROGRESS)
                {
                    
                    mw?.Invoke(new Action(() => { mw.PagoEnProgresoQueryEvent(); }));
                }
                else
                {

                    mw?.Invoke(new Action(() => { mw.PagoError(); }));
                }
            }
        }

        public override void HandleUserInputEvent(UserInputEvent sdk_event)
        {
            Log("UserInputEvent: ", "Invoked.\n");

            if (sdk_event.Status == StatusCode.SUCCESS)
            {
                var value = sdk_event.Values;
                if (sdk_event.InputType == VerifoneSdk.InputType.MENU_OPTIONS)
                {
                    string s = "Selected Index: " + value.SelectedIndices[0].ToString();
                    Log("UserInputEvent: ", s); 
                }
                else if (sdk_event.InputType == VerifoneSdk.InputType.CONFIRMATION)
                {
                    string s = "Selected Value: " + value.ToString();
                    Log("UserInputEvent: ", s); 
                }
            }
        }

        public override void HandlePinEvent(PinEvent @event)
        {
            throw new NotImplementedException();
        }

        public override void HandleScannerDataEvent(ScannerDataEvent @event)
        {
            throw new NotImplementedException();
        }

        public override void HandleScannerStateEvent(ScannerStateEvent @event)
        {
            throw new NotImplementedException();
        }

        public override void HandleTerminalConfigRequestEvent(ConfigurationRequestEvent @event)
        {
            throw new NotImplementedException();
        }
    }

}
