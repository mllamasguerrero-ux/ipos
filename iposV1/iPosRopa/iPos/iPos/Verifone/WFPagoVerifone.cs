using iPos.Verifone;
using iPosBusinessEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VerifoneSdk;

namespace iPos
{
    public partial class WFPagoVerifone : IposForm
    {
        //esta es asignada desde fuera
        public PaymentSdk mPsdk { get; set; }
        public Listener mCommerceListener { get; set; }
        public string mAppSpecificData { get; set; }

        public string mOperation { get; set; }

        public bool mCheckingTransaccionAfterDisconnect { get; set; } = false;
        public int mRestOfWaitingTime { get; set; } = 0;
        public int mCheckingTransaccionTries { get; set; } = 3;
        public bool mCheckingTransaccionStatusAfterQuerying { get; set; } = false;
        public int mCheckingTransAuthorizedTries { get; set; } = 3;
        

        public bool mDeviceInitialized { get; set; }

        public DateTime? mFechaLogin { get; set; }

        public bool mPagoExitoso { get; set; }
        public bool mCancelacionExitosa { get; set; }
        public bool mReimpresionExitosa { get; set; }

        public bool mCerrarAlFinalizarSesion = false;
        public bool mEsperarSegundosAntesDeCerrar = false;

        public int mReIntentosAutomaticosPago = 1;

        public  bool mTearDownOnInitialize { get; set; } = false;

        public string mStrResTransaccion { get; set; } = "";

        public CVERIFONECAJACONFIGBE mVerifoneCajaConfig { get; set; }

        public CVERIFONEPAYMENTBE mVerifonePayment { get; set; }

        public VerifonePaymentParam mPaymentParam { get; set; }

        public ReceiptType mReceiptType { get; set; }

        public bool mPreguntarImprimirRecibosAlFinalizar { get; set; } = false;

        public WFPagoVerifone()
        {
            InitializeComponent();
        }

        public WFPagoVerifone(PaymentSdk psdk, Listener commerceListener, bool deviceInitialized, DateTime? fechaLogin) : this()
        {
            mPsdk = psdk;
            mCommerceListener = commerceListener;

            mDeviceInitialized = deviceInitialized;
            mFechaLogin = fechaLogin;

            mPagoExitoso = false;
            mCancelacionExitosa = false;
            mReimpresionExitosa = false;

            mReceiptType = ReceiptType.CUSTOMER;

        }


        private void WFPagoVerifone_Load(object sender, EventArgs e)
        {
            IniciaOperacion();
        }

        private void IniciaOperacion()
        {

            switch (mOperation)
            {
                case "Inicializar":
                    {
                        actualizaEstatus("Inicializando la terminal verifone", "info", true, null, false, null,null,null, true);
                        this.Initialize();
                        break;

                    }

                case "Pagar":
                    {

                        actualizaEstatus(this.mCheckingTransaccionAfterDisconnect ? "Checando el estatus del pago" : "Procesando pago", 
                                        "info", true, null, false, null, null, null, true);
                        this.Pagar();
                        break;
                    }

                case "Login":
                    {

                        actualizaEstatus("Login", "info", true, null, false, null, null, null, true);
                        this.Login();
                        break;
                    }

                case "Cancelar":
                    {

                        actualizaEstatus("Cancelando", "info", true, null, false, null, null, null, true);
                        this.Cancelar();
                        break;
                    }

                case "Reimprimir":
                    {

                        actualizaEstatus("Reimprimiendo", "info", true, null, false, null, null, null, true);
                        this.Reimprimir();
                        break;
                    }
            }
        }

        public void Log(string title, string content)
        {
            VerifoneLogControl.Write(title + " " + content );
        }

        public void InicializacionExitosa()
        {
            this.mDeviceInitialized = true;
            

            switch (mOperation)
            {
                case "Pagar":
                case "Cancelar":
                case "Reimprimir":
                    {
                        Login();
                        break;
                    }
                default:
                    {

                        actualizaEstatus("Inicializacion de la terminal verifone realizada", "exito", false,
                                        "Inicializacion de la terminal verifone realizada", false, null, null, null, true);

                        SetTimeout(() =>
                        {
                            this.Close();
                        }, 2000);

                        break;

                    }
            }
            
        }

        public void InicializacionFallida()
        {
            this.mDeviceInitialized = false;

            if (mReIntentosAutomaticosPago <= 0)
            {
                if (mCheckingTransaccionAfterDisconnect)
                {
                    TerminalDesconectadaAMedioPago();
                    return;
                }

                actualizaEstatus("Fallo la inicializacion de la terminal verifone ", "error", false,
                                "Fallo la inicialiacion de la terminal verifone , puede reintentar haciendo click en el boton 'Reintentar', si pasa varias veces haga click en resetear conexion ",
                                true, true, null, null, true);


            }

            ReintentarReinicializandoSiAplica();

            //MessageBox.Show("Fallo la inicializacion");
            //this.Close();
        }



        public void TeardownExitoso()
        {

            this.mDeviceInitialized = false;


            switch (mOperation)
            {
                case "Inicializar":
                case "Pagar":
                case "Cancelar":
                case "Reimprimir":
                    {
                        mTearDownOnInitialize = false;
                        this.Initialize();
                        break;
                    }
                default:
                    {

                        actualizaEstatus("Teardown de la terminal verifone realizada", "exito", false,
                                        "Teardown de la terminal verifone realizada", false, null, null, null, true);

                        SetTimeout(() =>
                        {
                            this.Close();
                        }, 2000);

                        break;

                    }
            }
        }


        public void TeardownFallida()
        {
            if(mCheckingTransaccionAfterDisconnect)
            {
                TerminalDesconectadaAMedioPago();
                return;
            }

            actualizaEstatus("Fallo el teardown de la terminal verifone ", "error", false,
                            "Fallo el teardown de la terminal verifone , puede reintentar haciendo click en el boton 'Reintentar', si pasa varias veces haga click en resetear conexion ",
                            true, true, null, null, true);
        }

        public void LoginExitoso()
        {

            this.mFechaLogin = DateTime.Now;
           
            switch(mOperation)
            {
                case "Pagar":
                case "Cancelar":
                case "Reimprimir":
                    {
                        StartSession();
                        break;
                    }
                default:
                    {
                        this.Close();
                        break;

                    }
            }
            

        }

        public void LoginFallido(bool requiereInicializacion)
        {
            this.mFechaLogin = null;
            this.mDeviceInitialized = !requiereInicializacion;


            if (mReIntentosAutomaticosPago <= 0)
            {
                actualizaEstatus("Fallo el login", "error", false,
                                "Fallo el login , puede reintentar haciendo click en el boton 'Reintentar',  en caso de que continue la situacion favor de contactar a sistemas",
                                true, true, null, null, true);
            }

            ReintentarReinicializandoSiAplica();


            //MessageBox.Show("Fallo el login");
            //this.Close();
        }

        public void ErrorEnTransactionEvent()
        {

            //switch (mOperation)
            //{
            //    case "Inicializar":
            //        {
            //            this.InicializacionFallida();
            //            break;

            //        }

            //    case "Pagar":
            //        {
            //            this.PagoError();
            //            break;
            //        }

            //    case "Cancelar":
            //        {
            //            this.CancelacionErronea(null);
            //            break;
            //        }

            //    case "Login":
            //        {
            //            this.LoginFallido(false);
            //            break;
            //        }

            //    case "Reimprimir":
            //        {
            //            this.ReimpresionErronea();
            //            break;
            //        }
            //}

        }

        public void LogWithEvent(string status, string type, string message)
        {
        //    if (ConsoleOutput.Text.Length > 1000)
        //        ConsoleOutput.Text = ConsoleOutput.Text.Substring(300);

        //    ConsoleOutput.Text += ("Status: " + status + "\n");
        //    ConsoleOutput.Text += ("Type: " + type + "\n");
        //    ConsoleOutput.Text += ("Message: " + message + "\n");
            
            var logText = ("Status: " + status + "\n");
            logText += ("Type: " + type + "\n");
            logText += ("Message: " + message + "\n");


            VerifoneLogControl.Write(logText);
        }




        public void Pagar()
        {
            if (!this.mDeviceInitialized)
                this.Initialize();
            else if (this.mFechaLogin == null || DateTime.Compare(this.mFechaLogin.Value.AddDays(1), DateTime.Now) <= 0)
                this.Login();
            else
                StartSession();
        }


        public void Cancelar()
        {
            if (!this.mDeviceInitialized)
                this.Initialize();
            else if (this.mFechaLogin == null || DateTime.Compare(this.mFechaLogin.Value.AddDays(1), DateTime.Now) <= 0)
                this.Login();
            else
                StartSession();
        }

        public void Reimprimir()
        {
            if (!this.mDeviceInitialized)
                this.Initialize();
            else if (this.mFechaLogin == null || DateTime.Compare(this.mFechaLogin.Value.AddDays(1), DateTime.Now) <= 0)
                this.Login();
            else
                StartSession();
        }

        public void SessionCreada()
        {
            switch (mOperation)
            {

                case "Pagar":
                    {

                        actualizaEstatus(this.mCheckingTransaccionAfterDisconnect ? "Checando el estatus del pago" : "Procesando pago", "info", true, null, false, null, null, null, true);
                        if (this.mCheckingTransaccionAfterDisconnect)
                            this.QueryTransaction();
                        else
                            ProcesarPago();
                        break;
                    }

                case "Cancelar":
                    {
                        actualizaEstatus("Cancelando", "info", true, null, false, null, null, null, true);
                        Void();
                        break;
                    }

                case "Reimprimir":
                    {
                        actualizaEstatus("Reimprimiendo", "info", true, null, false, null, null, null, true);
                        Reprint();
                        break;
                    }

                default:
                    {
                        this.Close();
                        break;

                    }
            }
        }

        public void SessionNoPudoCrearse(bool requieresInitialization)
        {

            mDeviceInitialized = !requieresInitialization;
            mFechaLogin = null;

            //if(mReIntentosAutomaticosPago > 0 &&  mOperation == "Pagar")
            //{

            //    actualizaEstatus("Reintentando", "info", false,
            //                    "Hubo problemas intentando inciando sesion en la terminal. Reintentando...",
            //                    false, true, null, null, true);

            //    mReIntentosAutomaticosPago--;
            //    this.IniciaOperacion();
            //}
            //else
            //{

                if (mReIntentosAutomaticosPago <= 0)
                {
                    actualizaEstatus("Fallo el inicio de sesion", "error", false,
                                    "Fallo el inicio de seion , puede reintentar haciendo click en el boton 'Reintentar',  en caso de que continue la situacion favor de contactar a sistemas",
                                    true, true, null, null, true);
                }


                ReintentarReinicializandoSiAplica();


            //}


            //MessageBox.Show("Fallo la creacion de la session");
        }

        public void PagoRealizado(PaymentCompletedEvent sdk_event ) 
        {
            PagoRealizado(sdk_event.Payment, sdk_event.InvoiceId, sdk_event.SessionId, sdk_event.Message, sdk_event.Status, true);
            

        }


        public void PagoRealizado(Payment payment, string invoiceId, string sessionId, string message, int status, bool cerrarAlFinalizarSesion)
        {
            CVERIFONEPAYMENTBE paymentBE = new CVERIFONEPAYMENTBE();
            //paymentBE.IPAGOID = 
            paymentBE.IAPPSPECIFICDATA = payment.AppSpecificData;
            paymentBE.IINVOICEID = invoiceId;
            paymentBE.ISESSIONID = sessionId;
            paymentBE.IPAYMENTID = payment.PaymentId;
            paymentBE.IMENSAJE = message;
            paymentBE.ISTATUS = status;
            paymentBE.IOPERACION = payment.RetrievalReferenceNumber;
            paymentBE.IAUTHCODE = payment.AuthCode;
            paymentBE.ITERMINAL = payment.TerminalId;
            paymentBE.IAFILIACION = payment.MerchantId;
            paymentBE.IAID = payment.CardInformation.EmvTags["84"] ?? "";
            paymentBE.ICARDBRAND = payment.CardInformation.PaymentBrand;
            paymentBE.ICARDTYPE = payment.CardInformation.AccountType.ToString();
            paymentBE.IMONTO = payment.PaymentAmount.ToDecimal();

            mVerifonePayment = paymentBE;

            actualizaEstatus("Pago realizado", "exito", false,
                            "Pago realizado", false, null, cerrarAlFinalizarSesion, true, true);

            mPagoExitoso = true;
            EndSession();


        }

        public void PagoRealizadoQueryEvent(TransactionQueryEvent sdk_event, Payment payment)
        {
            
            mCheckingTransaccionAfterDisconnect = false;
            mCheckingTransaccionStatusAfterQuerying = false;
            mRestOfWaitingTime = 0;
            mCheckingTransaccionTries = 3;
            mCheckingTransAuthorizedTries = 3;
            mAppSpecificData = payment.AppSpecificData;
            mPreguntarImprimirRecibosAlFinalizar = true;
            PagoRealizado(payment, sdk_event.InvoiceId, sdk_event.SessionId, sdk_event.Message, sdk_event.Status, true);
            



        }

        public void PagoEnProgresoQueryEvent()
        {

            EndSession(); 

            mCheckingTransaccionStatusAfterQuerying = true;
            mCheckingTransaccionTries = 3;
            
            if (--mCheckingTransAuthorizedTries > 0)
            {
                switch (mCheckingTransAuthorizedTries)
                {
                    case 2: mRestOfWaitingTime = 30; break;
                    case 1: mRestOfWaitingTime = 30; break;
                    default: mRestOfWaitingTime = 60; break;
                }

                actualizaEstatus("Esperando para volver a consultar la transacccion ...", "info", false,
                                "La autorizacion esta en progreso , se consultara nuevamente en " + mRestOfWaitingTime.ToString() +
                                " segundos,  en caso de que continue la situacion favor de contactar a sistemas",
                                 false, false, null, null, true);
                timerCheckingTransaction.Start();
            }
            else
            {
                mCheckingTransAuthorizedTries = 3;
                actualizaEstatus("La transaccion esta tardando en ser autorizada", "error", false,
                                "La transaccion aun no esta autorizada, puede reintentar consultar el estatus haciendo click en el boton 'Reintentar', si quiere hacer el pago nuevamente , cierre esta ventana y vuelva a mandar pagar,  en caso de que continue la situacion favor de contactar a sistemas",
                                true, true, null, null, true);
                this.mCerrarAlFinalizarSesion = false;
            }

        }

        public void PagoError()
        {
            //reset flags, numero de reintentos etc
            mCheckingTransaccionAfterDisconnect = false;
            mCheckingTransaccionStatusAfterQuerying = false;
            mRestOfWaitingTime = 0;
            mCheckingTransaccionTries = 3;
            mCheckingTransAuthorizedTries = 3;

            actualizaEstatus("Fallo el proceso de pago", "error", false,
                            "Fallo el proceso de pago, puede reintentar haciendo click en el boton 'Reintentar',  en caso de que continue la situacion favor de contactar a sistemas",
                            true, true, null, null, true);
            this.mCerrarAlFinalizarSesion = false;
            EndSession();


            //MessageBox.Show("Fallo la venta");
        }


        public void PagoErrorQueryEvent()
        {

            mCheckingTransaccionAfterDisconnect = false;
            mCheckingTransaccionStatusAfterQuerying = false;
            mRestOfWaitingTime = 0;
            mCheckingTransaccionTries = 3;
            mCheckingTransAuthorizedTries = 3;
            this.mCheckingTransaccionAfterDisconnect = false;
            PagoError();


        }

        public void TerminalDesconectadaAMedioPago()
        {
            mCheckingTransaccionAfterDisconnect = true;

            if (--mCheckingTransaccionTries > 0)
            {
                switch(mCheckingTransaccionTries)
                {
                    case 2: mRestOfWaitingTime = 15; break;
                    case 1: mRestOfWaitingTime = 30; break;
                    default : mRestOfWaitingTime = 60; break;
                }
                mReIntentosAutomaticosPago = 1;
                actualizaEstatus("Problema de conexion. Esperando para reconectar ...", "info", false,
                                "Ha habido un problema de conexion, se intentara conectar con la termina en " + mRestOfWaitingTime.ToString() +
                                " segundos,  en caso de que continue la situacion favor de contactar a sistemas",
                                 false, false, null, null, true);
                timerCheckingTransaction.Start();
            }
            else
            {
                mCheckingTransaccionTries = 3;
                actualizaEstatus("Fallaron los intentos de reconexion ", "error", false,
                                "Fallaron los intentos de reconexion, puede reintentar haciendo click en el boton 'Reintentar', si quiere hacer el pago nuevamente , cierre esta ventana y vuelva a mandar pagar,  en caso de que continue la situacion favor de contactar a sistemas",
                                true, true, null, null, true);
                this.mCerrarAlFinalizarSesion = false;
                EndSession();
            }
        }


        public void CancelacionExitosa(PaymentCompletedEvent sdk_event)
        {

            CVERIFONEPAYMENTBE paymentBE = new CVERIFONEPAYMENTBE();
            //paymentBE.IPAGOID = 
            paymentBE.IAPPSPECIFICDATA = sdk_event.Payment.AppSpecificData;
            paymentBE.IINVOICEID = sdk_event.InvoiceId;
            paymentBE.ISESSIONID = sdk_event.SessionId;
            paymentBE.IPAYMENTID = sdk_event.Payment.PaymentId;
            paymentBE.IMENSAJE = sdk_event.Message;
            paymentBE.ISTATUS = sdk_event.Status;
            paymentBE.IOPERACION = sdk_event.Payment.RetrievalReferenceNumber;
            paymentBE.IAUTHCODE = sdk_event.Payment.AuthCode;
            paymentBE.ITERMINAL = sdk_event.Payment.TerminalId;
            paymentBE.IAFILIACION = sdk_event.Payment.MerchantId;
            //paymentBE.IAID = sdk_event.Payment.CardInformation.EmvTags["84"] ?? "";
            //paymentBE.ICARDBRAND = sdk_event.Payment.CardInformation.PaymentBrand;
            //paymentBE.ICARDTYPE = sdk_event.Payment.CardInformation.AccountType.ToString();
            paymentBE.IMONTO = sdk_event.Payment.PaymentAmount.ToDecimal();

            mVerifonePayment = paymentBE;

            actualizaEstatus("Cancelacion realizada", "exito", false,
                            "Cancelacion realizada", false, null, true, true, true);


            mCancelacionExitosa = true;
            EndSession();
        }

        public void CancelacionErronea(PaymentCompletedEvent sdk_event)
        {
            

            actualizaEstatus("Fallo la cancelacion", "error", false,
                            "Fallo la cancelacion , puede reintentar haciendo click en el boton 'Reintentar',  en caso de que continue la situacion favor de contactar a sistemas",
                            true, true, null, null, true);

            mCancelacionExitosa = false;
            EndSession();
            //MessageBox.Show("Fallo la cancelacion");


        }


        public void ReimpresionExitosa()
        {
            actualizaEstatus("Reimpresion realizada", "exito", false,
                            "Reimpresion realizada", false, null, true, true, true);

            mReimpresionExitosa = true;
            EndSession();
        }

        public void ReimpresionErronea()
        {

           // MessageBox.Show("Fallo la cancelacion");

            actualizaEstatus("Fallo la reimpresion", "error", false,
                            "Fallo la reimpresion , puede reintentar haciendo click en el boton 'Reintentar',  en caso de que continue la situacion favor de contactar a sistemas",
                            true, true, null, null, true);
            mReimpresionExitosa = false;
            EndSession();

        }

        public void EndSessionExitoso()
        {

            if(this.mCerrarAlFinalizarSesion)
            {
                if (this.mEsperarSegundosAntesDeCerrar)
                {
                    SetTimeout(() =>
                    {
                        this.Close();
                    }, 2000);
                }
                else
                {
                    this.Close();
                }

            }

        }

        public void EndSessionFallido()
        {
            if (this.mCerrarAlFinalizarSesion)
            {
                if (this.mEsperarSegundosAntesDeCerrar)
                {
                    SetTimeout(() =>
                    {
                        this.Close();
                    }, 2000);
                }
                else
                {
                    this.Close();
                }

            }
        }


        public void Initialize()
        {
            this.mDeviceInitialized = false;
            this.mFechaLogin = null;

            if (mTearDownOnInitialize)
            {
                mPsdk.TearDown();
            }
            else
            {

                if (mPsdk.DeviceInformation != null)
                {
                    PsdkDeviceInformation current = (PsdkDeviceInformation)mPsdk.DeviceInformation;
                    mPsdk.UseDevice(current, false);
                    
                }
            }

            Log("Proceso comenzando :", "Initializacion...");



            var paramDict = new Dictionary<string, string>()
            {
                { "DEVICE_CONNECTION_TYPE_KEY",
                       "tcpip" }, //(mVerifoneCajaConfig != null && !string.IsNullOrEmpty(mVerifoneCajaConfig.IDEVICECONNECTIONTYPEKEY)) ? mVerifoneCajaConfig.IDEVICECONNECTIONTYPEKEY.Replace("/","").ToLower() :  "tcpip" },
                { "DEVICE_ADDRESS_KEY",
                        (mVerifoneCajaConfig != null && !string.IsNullOrEmpty(mVerifoneCajaConfig.IDEVICEADDRESSKEY)) ? mVerifoneCajaConfig.IDEVICEADDRESSKEY :  "" },
            };
            mPsdk.InitializeFromValues(mCommerceListener, paramDict);
        }


        public void Login()
        {
            Log("Proceso comenzando :", "Login...");
            var credentials = LoginCredentials.Create();
            credentials.UserId = (mVerifoneCajaConfig != null && !string.IsNullOrEmpty(mVerifoneCajaConfig.IUSERID)) ? mVerifoneCajaConfig.IUSERID : "username";
            credentials.Password = (mVerifoneCajaConfig != null && !string.IsNullOrEmpty(mVerifoneCajaConfig.ICONTRASENA)) ? mVerifoneCajaConfig.ICONTRASENA : null;
            credentials.ShiftNumber = (mVerifoneCajaConfig != null && !string.IsNullOrEmpty(mVerifoneCajaConfig.ISHIFTNUMBER)) ? mVerifoneCajaConfig.ISHIFTNUMBER : null;
            credentials.MerchantId = (mVerifoneCajaConfig != null && !string.IsNullOrEmpty(mVerifoneCajaConfig.IMERCHANTID)) ? mVerifoneCajaConfig.IMERCHANTID : null;

            var result = mPsdk.TransactionManager.LoginWithCredentials(credentials);
        }

        public void Logout()
        {
            Log("Proceso comenzando :", "Logout...");
            mPsdk.TransactionManager.Logout();
        }

        public void StartSession()
        {
            Log("Proceso comenzando :", "Iniciando Sesion...");
            Transaction transaction = Transaction.Create();
            var result = mPsdk.TransactionManager.StartSession(transaction);
        }

        public void EndSession()
        {
            //UpdateConsole("Clicked :", "EndSession...");
            mPsdk.TransactionManager.EndSession();
        }

        public void AddItemsToBasket()
        {
            Log("Proceso comenzando :", "AddItemsToBasket...");

        }

        public void ProcesarPago()
        {
            Log("Proceso comenzando :", "Pago..");
            var payment = Payment.Create();
            var requestAmouts = payment.RequestedAmounts;

            //<testing>
            payment.CustomerNote = this.mPaymentParam.CustomerNote;
            payment.SaleNote = this.mPaymentParam.SaleNote;
            payment.LocalPaymentId = this.mPaymentParam.LocalPaymentId;
            payment.CashierId = this.mPaymentParam.CashierId;
            payment.Venue = this.mPaymentParam.Venue;
            payment.Currency = this.mPaymentParam.Currency ?? "MXN";

            //</testing>
            

            requestAmouts.AddAmounts(ParseDecimal(this.mPaymentParam.Amount), new VerifoneSdk.Decimal(0),
                new VerifoneSdk.Decimal(0), null, null, null, ParseDecimal(this.mPaymentParam.Amount));
            mPsdk.TransactionManager.StartPayment(payment);
        }
        
        private VerifoneSdk.Decimal ParseDecimal(decimal valorDecimal)
        {

            long longValue = Convert.ToInt64(decimal.Round(valorDecimal * 100, 0));
            return new VerifoneSdk.Decimal(2, longValue);

        }

        public void PreAuth()
        {
            Log("Proceso comenzando :", "PreAutorizacion ...");
            var payment = Payment.Create();
            var requestAmounts = payment.RequestedAmounts;
            requestAmounts.AddAmounts(new VerifoneSdk.Decimal(5), new VerifoneSdk.Decimal(1), new VerifoneSdk.Decimal(0),
                new VerifoneSdk.Decimal(0), new VerifoneSdk.Decimal(0), new VerifoneSdk.Decimal(0),
                new VerifoneSdk.Decimal(6));
            payment.TransactionType = TransactionType.PRE_AUTHORIZATION;
            mPsdk.TransactionManager.StartPayment(payment);

        }

        public void PreAuthComplete()
        {
            Log("Proceso comenzando :", "PreAutorizacion completa...");
            var payment = Payment.Create();
            payment.AppSpecificData = mAppSpecificData;
            payment.TransactionType = TransactionType.PRE_AUTHORIZATION_COMPLETION;
            mPsdk.TransactionManager.StartPayment(payment);
        }

        public void Void()
        {
            Log("Proceso comenzando :", "Cancelacion...");
            var payment = Payment.Create();
            payment.AppSpecificData = mAppSpecificData;
            mPsdk.TransactionManager.ProcessVoid(payment);
        }

        public void Settlement()
        {
            Log("Proceso comenzando :", "Settlement...");
            Status status = mPsdk.TransactionManager.ReportManager.ClosePeriodAndReconcile(null);
            string s = "getActiveTotals: " + status.StatusCode.ToString() + " : " + status.Message;
        }

        public void QueryTransaction()
        {
            Log("Proceso comenzando :", "Query Transaction...");
            var transactionQuery = TransactionQuery.Create();
            transactionQuery.IsQueryingLastTransaction = true;
            Status sts = mPsdk.TransactionManager.ReportManager.QueryTransactions(transactionQuery);

            if (sts.StatusCode == StatusCode.DEVICE_CONNECTION_FAILED || sts.StatusCode == StatusCode.DEVICE_CONNECTION_LOST)
            {
                this.TerminalDesconectadaAMedioPago();
            }
            //else if (sts.StatusCode == StatusCode.COMMAND_IN_PROGRESS)
            //{
            //    this.TerminalDesconectadaAMedioPago();
            //}
        }

        public void Refund()
        {
            Log("Proceso comenzando :", "Reembolso...");
            var payment = Payment.Create();
            payment.AppSpecificData = mAppSpecificData;
            var requestAmounts = payment.RequestedAmounts;
            requestAmounts.AddAmounts(new VerifoneSdk.Decimal(6), new VerifoneSdk.Decimal(1),
                new VerifoneSdk.Decimal(1), new VerifoneSdk.Decimal(0), new VerifoneSdk.Decimal(0),
                new VerifoneSdk.Decimal(0), new VerifoneSdk.Decimal(8));
            mPsdk.TransactionManager.ProcessRefund(payment);

        }

        public void Reprint()
        {
            Log("Proceso comenzando :", "Impresion...");
            
            var payment = new Payment();
            payment.AppSpecificData = this.mAppSpecificData;
            mPsdk.TransactionManager.ReprintReceipt(payment, this.mReceiptType, DeliveryMethod.PRINT, null);

        }
        

        private void btnCerrar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Esta seguro de querer cerrar esta ventana? . Solo hagalo cuando haya revisado la terminal y no haya respuesta por un par de minutos ",
                                "Confirmacion",
                                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            this.mStrResTransaccion = "El usuario cerro la ventana , puede ser que no se haya realizado la operacion";
            this.Close();
        }

        private void btnReintentar_Click(object sender, EventArgs e)
        {
            this.mReIntentosAutomaticosPago = 1;
            IniciaOperacion();
        }

        private void btnTearDown_Click(object sender, EventArgs e)
        {
            TearDown();
        }

        public void TearDown()
        {

            Log(" Reseteando conexion :", "Reseteando conexion...");
            this.mDeviceInitialized = false;
            this.mFechaLogin = null;

            try
            {
                mPsdk.TearDown();
            }
            catch(Exception ex)
            {
                TeardownFallida();
            }
        }

        public void ReintentarReinicializandoSiAplica()
        {

            if (mReIntentosAutomaticosPago > 0)
            {

                actualizaEstatus("Reintentando sincronizacion con la terminal ", "info", true,
                                "Se esta reintentando la sincronizacion con la terminal ",
                                true, true, null, null, true);

                mReIntentosAutomaticosPago--;
                this.TearDown();
            }
        }


        public void actualizaEstatus(
            string strEstado,
            string tipoEstado, //info, error, exito
            bool? procesando,
            string mensaje,
            bool? reintentarHabilitado,
            bool? cerrarHabilitado,
            bool? cerrarAlFinalizarSesion,
            bool? esperarSegundosAntesDeCerrar,
            bool? limpiarMensaje
            )
        {
            this.Invoke(new Action(() => {
                actualizaEstatus_sync(strEstado, tipoEstado, procesando, mensaje,
                                        reintentarHabilitado, cerrarHabilitado, 
                                        cerrarAlFinalizarSesion, esperarSegundosAntesDeCerrar, limpiarMensaje);

            }));
        }

        public void actualizaEstatus_sync(
            string strEstado,
            string tipoEstado, //info, error, exito
            bool? procesando,
            string mensaje,
            bool? reintentarHabilitado,
            bool? cerrarHabilitado,
            bool? cerrarAlFinalizarSesion,
            bool? esperarSegundosAntesDeCerrar,
            bool? limpiarMensaje
            )
        {
            if (strEstado != null)
                lblMensajeOperacion.Text = strEstado;

            if (tipoEstado != null)
            {
                switch(tipoEstado)
                {
                    case "exito": lblMensajeOperacion.ForeColor = Color.Green; lblMensajeOperacion.BackColor = Color.White; break;
                    case "error": lblMensajeOperacion.ForeColor = Color.Red; lblMensajeOperacion.BackColor = Color.White; break;
                    default: lblMensajeOperacion.ForeColor = Color.White; lblMensajeOperacion.BackColor = Color.Transparent; break;
                }
            }

            if(procesando != null)
            {
                this.progressBar1.Style = procesando.Value ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
            }

            if (limpiarMensaje != null && limpiarMensaje.Value)
                this.ConsoleOutput.Text = "";

            if (mensaje != null)
                this.ConsoleOutput.Text += mensaje + "\n";

            if (reintentarHabilitado != null)
                this.btnReintentar.Visible = reintentarHabilitado.Value;

            if (cerrarHabilitado != null)
                this.btnCerrar.Visible = cerrarHabilitado.Value;




            if (cerrarAlFinalizarSesion != null)
                mCerrarAlFinalizarSesion = cerrarAlFinalizarSesion.Value ;

            if (esperarSegundosAntesDeCerrar != null)
                mEsperarSegundosAntesDeCerrar = esperarSegundosAntesDeCerrar.Value;
            

            }

        private void SetTimeout(Action action, int timeout)
        {
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = timeout;
            timer.Tick += delegate (object sender, EventArgs args)
            {
                action();
                timer.Stop();
            };
            timer.Start();
        }

        private void timerCheckingTransaction_Tick(object sender, EventArgs e)
        {
            if(--mRestOfWaitingTime > 0)
            {
                if(mCheckingTransaccionStatusAfterQuerying)
                {

                    actualizaEstatus("Esperando para volver a consultar la transacccion ...", "info", false,
                                    "La autorizacion esta en progreso , se consultara nuevamente en " + mRestOfWaitingTime.ToString() +
                                    " segundos,  en caso de que continue la situacion favor de contactar a sistemas",
                                     false, false, null, null, true);
                }
                else
                {

                    actualizaEstatus("Problema de conexion. Esperando para reconectar ...", "info", false,
                                    "Ha habido un problema de conexion, se intentara conectar con la terminal en " + mRestOfWaitingTime.ToString() +
                                    " segundos,  en caso de que continue la situacion favor de contactar a sistemas",
                                     false, false, null, null, true);
                }
                return;
            }
            timerCheckingTransaction.Stop();

            actualizaEstatus((mCheckingTransaccionStatusAfterQuerying ? "Checando estatus.." : "Reconectando.."), 
                                    "info", false,
                                   "Procesando...",
                                    false, false, null, null, true);

            if (mCheckingTransaccionStatusAfterQuerying)
                this.IniciaOperacion();

            if(mCheckingTransaccionAfterDisconnect)
                this.TearDown();
        }
        
    }


    public class VerifonePaymentParam
    {

        public string CustomerNote { get; set; }
        public string SaleNote { get; set; }
        public string LocalPaymentId { get; set; }
        public string CashierId { get; set; }
        public string Venue { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
