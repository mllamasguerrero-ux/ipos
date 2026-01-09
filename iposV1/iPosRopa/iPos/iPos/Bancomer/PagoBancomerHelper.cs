using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;
using EglobalBBVA;
using iPosBusinessEntity;
using iPosData;
using FirebirdSql.Data.FirebirdClient;
using iPos.Tools;
using System.Collections;

namespace iPos
{
    public class PagoBancomerHelper
    {

        public static PinPadSC Enviar = null;

        private static String carga_llaves = String.Empty;


        private static String BCargaLlave = String.Empty;//Para Controlar la Carga de Llaves por Bandera 1
        private static String strVersion = String.Empty;//Para guardar el password del certificado
        private static String BACT = String.Empty;//Para Controlar Actualizacion de Version PinPad
        private static String SA = String.Empty;
        private static String MacAlterna = String.Empty; //Contiene el numero de la mac ficticia para multiafiliación.  

        public static String strResSync = "";
        public static String strResCargaLlaves = "";
        public static String strResActualizacion = "";

        public static String strResTransaccion = "";

        public static bool enSimulacion = false;
        public static bool enCertificacion = false;


        public static Dictionary<string, string> creditoDebitoMatch = new Dictionary<string, string>();


        public static bool LlenaCreditoDebitMatch()
        {
            try
            {
                // Open the file and read it back.
                using (System.IO.StreamReader sr = System.IO.File.OpenText(Application.StartupPath + "/ConcentradoCard.txt"))
                {
                    string strCadena = "";
                    //SOLO LEE LA PRIMERA LINEA DEL ARCHIVO DONDE ESTA EL NOMBRE DEL COMERCIO
                    while ((strCadena = sr.ReadLine()) != null)
                    {

                        strCadena = strCadena.ToUpper();

                        string[] strSplit = strCadena.Split(new string[] { "," }, StringSplitOptions.None);

                        if (strSplit != null && strSplit.Length >= 3)
                        {
                            creditoDebitoMatch[strSplit[0]] = strSplit[2];
                        }
                    }
                    sr.Close();

                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al Leer la configuracion\n" + Ex.Message);
            }

            return true;
        }

        public static string ObtenerTipoTarjeta(string numeroTarjeta)
        {
            string prefijoTarjeta = numeroTarjeta.Substring(0, 6);
            if(creditoDebitoMatch.ContainsKey(prefijoTarjeta))
            {
                return creditoDebitoMatch[prefijoTarjeta].ToUpper().Equals("D") ? "Débito" : "Crédito";
            }

            return "";
        }


        public static bool PreparaPinPadSC()
        {
            if (Enviar == null)
            {
                LlenaCreditoDebitMatch();
                Enviar = new PinPadSC();
                //Cadenas();



                //Se intenta mandar una sincronizacion inicial a la pinpad
                if (!MandarSincronizacion())
                {
                    MessageBox.Show("No se pudo lograr la sincronizacion " + strResSync);
                    return false;
                }

                //Se carga el archivo PinPadConfig.txt con la configuracion de la pinpad
                if (!CargarConfiguracionDePinPad())
                {
                    return false;
                }

                //Si dentro de la configuracion del archivo pinpadconfig el parametro cargaLlave es igual
                //a uno significa que se tiene que hacer una carga de llaves manual.
                if (ClsConfiguracion.CargaLlave == 1)
                {
                    if (!CargaLlaves())//carga de llaves
                    {

                        MessageBox.Show("No se pudieron cargar las llaves " + strResCargaLlaves);
                        return false;
                    }


                    if (!PagoBancomerHelper.MandarSincronizacion())
                    {
                        MessageBox.Show("No se pudo lograr la sincronizacion " + PagoBancomerHelper.strResSync);
                        return false;
                    }
                }
                else if (ClsConfiguracion.BACTVersion == 1) //Para Actualizar la versión del PinPad Forma Automatica
                {
                    ActualizarVersionPinPad();
                }

                SA = "0";
                BCargaLlave = "0";
                BACT = "0";


                ActualizaConfiguracionDePinPad();
            }

            return true;






        }




        public static bool MandarSincronizacion()
        {

            strResSync = "";

            if (Enviar == null)
            {

                Enviar = new PinPadSC();
            }

            try
            {
                Enviar.SincronicacionInicial();//Sincronizacion inicial
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo haer la sincronizacion inicial, verifique que este conectada la PinPad, Excepcion: " + ex);
                return false;
            }


            CBANCOMERPARAMBE bancomerParam = new CBANCOMERPARAMBE();//Objeto que guardara todos los campos tanto de la respuesta como de la request
            //simulacion solo para hacer pruebas
            if (enSimulacion)
            {
                bancomerParam.IRESPDLL = 0;//se simula el valor de la respuesta
            }
            else
            {
                bancomerParam = converteABancomerParamBE_PinPadSC(Enviar); //asignamos los datos del objeto de bancomer a nuestro objeto
            }




            if (bancomerParam.IRESPDLL != 0)//si al intenar la sincronizacion inicial respdll es dif de 0 es que no se realizo la sincronizacion
            {
                strResSync = Enviar.Response;
                return false;
            }

            return true;
        }

        public static bool CargarConfiguracionDePinPad()
        {
            //sencillamente carga el archivo PinPadConfig.txt con la configuracion del Pinpad
            try
            {
                string rutaArchivo = rutaArchivoPinPadConfig();
                if (!File.Exists(rutaArchivoPinPadConfig()))
                {
                    throw new Exception("No existe el archivo " + rutaArchivo);
                }

                ClsConfiguracion.LeeDatosFromTXT();
                return true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return false;
            }

        }


        public static bool ActualizaConfiguracionDePinPad()
        {
            //return true;
            //Esta funcion sobreescribe el archivo de configuracion del PinPad
            try
            {
                string rutaArchivo = rutaArchivoPinPadConfig();
                if (File.Exists(rutaArchivo))
                {
                    File.Delete(rutaArchivo);
                }

                string afiliacionStr = !String.IsNullOrEmpty(CurrentUserID.CurrentCaja.IAFILIACIONBANCOMER) ?
                    CurrentUserID.CurrentCaja.IAFILIACIONBANCOMER :
                    ClsConfiguracion.Afiliacion;

                using (StreamWriter w = File.AppendText(rutaArchivo))
                {

                    w.WriteLine("IPHOST:" + ClsConfiguracion.IpHost);
                    w.WriteLine("SOCKETHOST:" + ClsConfiguracion.PuertoHost);
                    w.WriteLine("PINPADTIMEOUT:" + ClsConfiguracion.PinpadTimeOut);
                    w.WriteLine("NOMBREPUERTO:" + ClsConfiguracion.PuertoSerie);
                    w.WriteLine("PINPADID:" + ClsConfiguracion.PinPadID);
                    w.WriteLine("AFILIACION:" + afiliacionStr);
                    w.WriteLine("TERMINAL:" + ClsConfiguracion.Terminal);
                    w.WriteLine("TIMEOUTHOST:" + ClsConfiguracion.HostTimeOut);
                    w.WriteLine("NOMBRECOMERCIO:" + ClsConfiguracion.Comercio);
                    w.WriteLine("HEADERCONSECUTIVO:" + ClsConfiguracion.HeaderConsecutivo);
                    w.WriteLine("FOLIO:" + ClsConfiguracion.IsFolio);
                    w.WriteLine("LOG:" + ClsConfiguracion.IsLog);
                    w.WriteLine("DIRUSERDB:" + ClsConfiguracion.DirUserDB);
                    w.WriteLine("BINESCOMERCIO:" + ClsConfiguracion.IDBinesComercio);
                    w.WriteLine("SESIONABRIR:" + SA);
                    w.WriteLine("CARGALLAVE:" + BCargaLlave);
                    w.WriteLine("VERSION:" + ClsConfiguracion.Password); //Solo si la DLL es por Internet
                    w.WriteLine("IMPRESIOND:" + ClsConfiguracion.Impresion);
                    w.WriteLine("ACTUALIZACION:" + BACT);
                    w.WriteLine("DIRACTPINPAD:" + ClsConfiguracion.DIRACTVersion);
                    w.WriteLine("CONAUX:" + ClsConfiguracion.ConAMEX);
                    w.WriteLine("CASH:" + ClsConfiguracion.Cash);
                    w.Flush();
                    w.Close();

                }

                return true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return false;
            }

        }

        public static bool CargaLlaves()
        {
            long consecutivoDiaFecha = 0;

            CCAJAD cajaDB = new CCAJAD();
            CCAJABE cajaBEB = new CCAJABE();

            CBANCOMERPARAMD bancomerParamD = new CBANCOMERPARAMD();
            CDOCTOD doctoD = new CDOCTOD();
            CBANCOMERPARAMBE bancomerParam = new CBANCOMERPARAMBE();

            //obtener consecutivo para la secuencia de transaccion
            if (!bancomerParamD.BANCOMER_GETCONSECUTIVO(DateTime.Today, ref consecutivoDiaFecha, null))
            {
                strResTransaccion = "Hubo un error al obtener el consecutivo ";
                return false;
            }


            cajaBEB.IID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;

            cajaBEB = cajaDB.seleccionarCAJA(cajaBEB, null);

            CPERSONAD personaDB = new CPERSONAD();
            CPERSONABE personaBEB = new CPERSONABE();

            personaBEB.IID = CurrentUserID.CurrentUser.IID;
            personaBEB = personaDB.seleccionarPERSONA(personaBEB, null);

            string terminal = cajaBEB.INUMEROTERMINALBANCOMER.ToString();//la terminal se obtiene del catalogo de caja
            string sesion = ObtenerNumeroSession().ToString();//la sesion es el id del corte actual
            string fechaHoraT = DateTime.Now.ToString("yyMMddHHmmss");//la fecha se formatea de acuerdo al documento pag 50
            string claveOp = personaBEB.ICLAVE;//la clave del operador es la clave del usuario
            string afiliacion = !String.IsNullOrEmpty(CurrentUserID.CurrentCaja.IAFILIACIONBANCOMER) ?
                                    CurrentUserID.CurrentCaja.IAFILIACIONBANCOMER :
                                    ClsConfiguracion.Afiliacion;//la afliacion se obtiene de la base de datos o del archivo pinpadconfig.txt
            string transaccionB = consecutivoDiaFecha.ToString();//consecutivo

            //se rellena y formatean las campos de acuerdo al manual pag.48 - 51
            rellenarCadenas(ref terminal, 8, "left", '0');
            rellenarCadenas(ref sesion, 4, "left", '0');
            rellenarCadenas(ref claveOp, 6, "left", ' ');
            rellenarCadenas(ref transaccionB, 4, "left", '0');
            rellenarCadenas(ref afiliacion, 8, "left", '0', true);

            //se obtiene la cadena de la llave llamando la funcion especifica para este proposito y mandando los parametros necesarios
            carga_llaves = obtenCadenaLlave(terminal, sesion, transaccionB, fechaHoraT, claveOp, afiliacion);
            Enviar.fncEglobalBBVA(carga_llaves, 0, "");//se llama a la funcion para cargar la llave mandando la cadena respectiva

            //simulacion
            if (enSimulacion)
            {
                bancomerParam.IRESPDLL = 0;
            }
            else
            {
                bancomerParam = converteABancomerParamBE_PinPadSC(Enviar);
            }


            if (bancomerParam.IRESPDLL != 0)
            {
                strResCargaLlaves = Enviar.Response;
                return false;
            }
            return true;
        }

        //Como el nombre lo dice actualiza la version del pinpad
        public static bool ActualizarVersionPinPad()
        {
            String CadEnviar = String.Empty;
            DialogResult Respuesta;

            Respuesta = MessageBox.Show("Se realizará actualización de versión del pinpad");
            if (Respuesta == DialogResult.OK)
            {
                CadEnviar = obtenerCadenaParaActualizarPinPad();
                Enviar.fncEglobalBBVA(CadEnviar, 0, "");

                CBANCOMERPARAMBE bancomerParam = new CBANCOMERPARAMBE();
                //simulacion
                if (enSimulacion)
                {
                    bancomerParam.IRESPDLL = 0;
                }
                else
                {
                    bancomerParam = converteABancomerParamBE_PinPadSC(Enviar);
                }

                if (bancomerParam.IRESPDLL != 0)
                {
                    if (bancomerParam.ClsResponse.ICODIGORESPUESTA /*C05_CodigoRespuesta*/ == String.Empty)
                    {
                        strResActualizacion = Enviar.Response;
                    }
                    else if (bancomerParam.ClsResponse.ICODIGORESPUESTA/*C05_CodigoRespuesta*/ != "00")
                    {
                        strResActualizacion = Enviar.ClsResponse.C16_Leyenda.Trim();
                    }
                }
                else
                {
                    if (bancomerParam.ClsResponse.ToString() != "")
                    {
                        String Mensaje = Enviar.ClsResponse.ToString();
                        MessageBox.Show(Mensaje);
                    }
                }
            }
            /*else if (Respuesta == DialogResult.Cancel)
            {
                //No enviamos la solicitud al PinPad
                //y continua con el proceso normal
            }*/

            return true;
        }



        public static bool CalcularPuntos(bool preparaPinPad, ref CBANCOMERPARAMBE bancomerParam, FbTransaction st)
        {

                 strResTransaccion = "";

            //preparamos la pinpad mandando la sincronizacion inicial y cargando lo necesario
            if (!PreparaPinPadSC())
            {
                strResTransaccion = strResSync + " - " + strResCargaLlaves;
            }

            //Boolean TransaccionViva = true;//indica si el proceso sigue en pie

            CBANCOMERPARAMD bancomerParamD = new CBANCOMERPARAMD();
            CDOCTOD doctoD = new CDOCTOD();

            long consecutivoDiaFecha = 0;
            bool retorno = false;

            //string strNumeroTarjeta = "";
            //string strCreditoDebito = "";

            try
            {


                //caja
                CCAJAD cajaDB = new CCAJAD();
                CCAJABE cajaBEB = new CCAJABE();
                cajaBEB.IID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
                cajaBEB = cajaDB.seleccionarCAJA(cajaBEB, null);


                //obtener consecutivo
                if (!bancomerParamD.BANCOMER_GETCONSECUTIVO(DateTime.Today, ref consecutivoDiaFecha, st))
                {
                    strResTransaccion = "Hubo un error al obtener el consecutivo ";
                    return false;
                }


                string terminal = cajaBEB.INUMEROTERMINALBANCOMER.ToString();//la terminal se obtiene del catalogo de caja
                string sesion = ObtenerNumeroSession().ToString();//la sesion es el id del corte actual
                string fechaHoraT = DateTime.Now.ToString("yyMMddHHmmss");//la fecha se formatea de acuerdo al documento pag 50
                string referenciaComer = "";//nosotros en la referencia del comercio mandamos el folio
                string claveOp = "";//la clave del operador es la clave del usuario
                string afiliacion = !String.IsNullOrEmpty(CurrentUserID.CurrentCaja.IAFILIACIONBANCOMER) ? 
                                    CurrentUserID.CurrentCaja.IAFILIACIONBANCOMER : 
                                    ClsConfiguracion.Afiliacion;//la afliacion se obtiene de la base de datos o del archivo pinpadconfig.txt

                string transaccionB = consecutivoDiaFecha.ToString();//consecutivo

                //se rellena y formatean las campos de acuerdo al manual pag.48 - 51
                rellenarCadenas(ref terminal, 8, "left", '0');
                rellenarCadenas(ref sesion, 4, "left", '0');
                rellenarCadenas(ref referenciaComer, 45, "left", ' ');
                rellenarCadenas(ref claveOp, 6, "right", '0');
                rellenarCadenas(ref transaccionB, 4, "left", '0');
                rellenarCadenas(ref afiliacion, 8, "left", '0', true);

                //se obtiene la cadena para la venta llamando al metodo correspondiente, enviando los param. necesarios
                string cadenaPuntos = obtenCadenaConsultarPuntos(
                                                                  terminal,
                                                                  sesion,
                                                                  transaccionB,
                                                                  fechaHoraT,
                                                                  referenciaComer,
                                                                  claveOp,
                                                                  afiliacion);

           
                //preparamos la pinpad mandando la sincronizacion inicial y cargando lo necesario

                Enviar.fncEglobalBBVA(cadenaPuntos, 0, "");
                                //simulacion donde asignamos valores ficticios solo para pruebas
                if (enSimulacion)
                {
                    bancomerParam = new CBANCOMERPARAMBE();
                    bancomerParam.IRESPDLL = 0;
                    bancomerParam.Pts = new CSTRUCPTOSBANCOMERBE();
                    bancomerParam.Pts.IPESOSSALDODISPONIBLE = "10000";
                    bancomerParam.Pts.IPUNTOSSALDODISPONIBLE = "5000";
                    bancomerParam.Pts.IPESOSSALDOANTERIOR = "10000";
                    bancomerParam.Pts.IPESOSREDIMIDOS = "10000";
                    bancomerParam.Pts.IPUNTOSSALDOANTERIOR = "5000";
                    bancomerParam.Pts.IPUNTOSREDIMIDOS = "5000";
                    bancomerParam.INUMEROTARJETA = "1234567891234567";
                }
                else
                {
                    bancomerParam = converteABancomerParamBE_PinPadSC(Enviar);
                }

                if (bancomerParam.IRESPDLL != 0)
                {
                    if (enCertificacion)
                    {
                        //estado erroneo 
                        bancomerParam.IESTADOTRANSACCIONID = -1;

                        // calcula credito / debito
                        if (bancomerParam.INUMEROTARJETA != null && bancomerParam.INUMEROTARJETA.Trim().Length > 0)
                            bancomerParam.ICREDITODEBITO = ObtenerTipoTarjeta(bancomerParam.INUMEROTARJETA);

                        //guardamos los campos de bancomer localmente
                        bancomerParamD.BANCOMERPARAM_GUARDAR(ref bancomerParam, st);
                    }

                    if (bancomerParam.ClsResponse.ICODIGORESPUESTA == String.Empty)
                    {
                        strResTransaccion = bancomerParam.ClsResponse.ToString();
                        return false;
                    }
                    else
                    {
                        strResTransaccion = bancomerParam.ClsResponse.ILEYENDA.Trim();
                        return false;
                    }
                }
                else
                {
                    retorno = true;
                }

                //guardar la informacion de bancomer
                if (retorno)
                {
                    bancomerParam.ITIPOTRANSACCION = "016";
                    bancomerParam.IESTADOTRANSACCIONID = 1;
                    //bancomerParam.ICREDITODEBITO = strCreditoDebito;
                    //bancomerParam.IVALTIPOCARD = strNumeroTarjeta;

                    // calcula credito / debito
                    if (bancomerParam.INUMEROTARJETA != null && bancomerParam.INUMEROTARJETA.Trim().Length > 0)
                        bancomerParam.ICREDITODEBITO = ObtenerTipoTarjeta(bancomerParam.INUMEROTARJETA);

                    if (!bancomerParamD.BANCOMERPARAM_GUARDAR(ref bancomerParam, st))
                    {
                        MessageBox.Show("Se realizo la operacion  pero no se pudo guardar el registro " + bancomerParamD.IComentario);
                    }

                }

                return true;
            }
            catch (Exception e)
            {
                strResTransaccion = "Excepcion local : " + e.Message;
                return false;
            }
        }

        public static bool Pagar(ref CDOCTOBE doctoBE, decimal montoPago, ref long bancomerParamId, FbTransaction st)
        {
            strResTransaccion = "";

            //preparamos la pinpad mandando la sincronizacion inicial y cargando lo necesario
            if (!PreparaPinPadSC())
            {
                strResTransaccion = strResSync + " - " + strResCargaLlaves;
            }

            Boolean TransaccionViva = true;//indica si el proceso sigue en pie

            CBANCOMERPARAMD bancomerParamD = new CBANCOMERPARAMD();
            CDOCTOD doctoD = new CDOCTOD();
            CBANCOMERPARAMBE bancomerParam = new CBANCOMERPARAMBE();

            long consecutivoDiaFecha = 0;
            bool retorno = false;

            //string strNumeroTarjeta = "";
            //string strCreditoDebito = "";

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

                //obtener consecutivo
                if (!bancomerParamD.BANCOMER_GETCONSECUTIVO(DateTime.Today, ref consecutivoDiaFecha, st))
                {
                    strResTransaccion = "Hubo un error al obtener el consecutivo ";
                    return false;
                }

                //caja
                CCAJAD cajaDB = new CCAJAD();
                CCAJABE cajaBEB = new CCAJABE();
                cajaBEB.IID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
                cajaBEB = cajaDB.seleccionarCAJA(cajaBEB, null);

                //vendedor
                CPERSONAD personaDB = new CPERSONAD();
                CPERSONABE personaBEB = new CPERSONABE();
                personaBEB.IID = doctoBE.IVENDEDORID;
                personaBEB = personaDB.seleccionarPERSONA(personaBEB, null);

                string terminal = cajaBEB.INUMEROTERMINALBANCOMER.ToString();//la terminal se obtiene del catalogo de caja
                string sesion = ObtenerNumeroSession().ToString();//la sesion es el id del corte actual
                string fechaHoraT = DateTime.Now.ToString("yyMMddHHmmss");//la fecha se formatea de acuerdo al documento pag 50
                string referenciaComer = doctoBE.IFOLIO.ToString();//nosotros en la referencia del comercio mandamos el folio
                string claveOp = personaBEB.ICLAVE;//la clave del operador es la clave del usuario
                string afiliacion = !String.IsNullOrEmpty(CurrentUserID.CurrentCaja.IAFILIACIONBANCOMER) ? 
                                    CurrentUserID.CurrentCaja.IAFILIACIONBANCOMER : 
                                    ClsConfiguracion.Afiliacion;//la afliacion se obtiene de la base de datos o del archivo pinpadconfig.txt
                string transaccionB = consecutivoDiaFecha.ToString();//consecutivo

                //se rellena y formatean las campos de acuerdo al manual pag.48 - 51
                rellenarCadenas(ref terminal, 8, "left", '0');
                rellenarCadenas(ref sesion, 4, "left", '0');
                rellenarCadenas(ref referenciaComer, 45, "left", ' ');
                rellenarCadenas(ref claveOp, 6, "right", 'x');
                rellenarCadenas(ref transaccionB, 4, "left", '0');
                rellenarCadenas(ref afiliacion, 8, "left", '0', true);

                //se obtiene la cadena para la venta llamando al metodo correspondiente, enviando los param. necesarios
                string cadenaVenta = obtenerCadenaParaVentaPinPad(
                                                                  terminal,
                                                                  sesion,
                                                                  transaccionB,
                                                                  fechaHoraT,
                                                                  referenciaComer,
                                                                  claveOp,
                                                                  afiliacion,
                                                                  doctoBE,
                                                                  montoPago);

                //enviamos la cadena mediante el metodo indicado     
                Enviar.fncEglobalBBVA(cadenaVenta, 0, MacAlterna);

                //simulacion donde asignamos valores ficticios solo para pruebas
                if (enSimulacion)
                {
                    Random rnd = new Random();

                    bancomerParam = new CBANCOMERPARAMBE();
                    bancomerParam.IRESPDLL = 0;
                    bancomerParam.ITNXCONPUNTOS = "N";
                    bancomerParam.IRESPONSE = "Exito";
                    bancomerParam.ClsResponse.ICODIGORESPUESTA = "00";
                    bancomerParam.INOAUTORIZACION = "123456";

                    bancomerParam.ClsResponse.IIMPORTE = montoPago.ToString("N2").Replace(",", "").Replace(".", "");
                    bancomerParam.ICLIENTE_CMP_COMERCIO = "CMP COMERCIO";
                    bancomerParam.ITIPOTRANSACCION = "?? ";//Segun esto yo puse este campo personalizado
                    bancomerParam.INUMEROTARJETA = "1234567890123456";
                    bancomerParam.IMONTO_CHEQUE_ACTUAL = montoPago.ToString("N2").Replace(",", "").Replace(".", "");
                    bancomerParam.ICRIPTOGRAMA = "CRIPTO";
                    bancomerParam.IREFERENCIAAFIN = "441111";
                    bancomerParam.IFIRMAAUTOGRAFA = "S";
                    bancomerParam.IFIRMAELECTRONICA = "N";
                    bancomerParam.IFIRMAQPS = "N";
                    bancomerParam.ClsRequest.INOSECUENCIA = "123456";
                    bancomerParam.ClsRequest.IFECHAHORACOMERCIO = "170526091926";

                    //bancomerParam.ICARDTIPO = 1;
                    bancomerParam.INUMEROTARJETA = "1234567890123456";
                    bancomerParam.ICREDITODEBITO = "Credito";

                    //borrar
                    bancomerParam.IIDTOKEN12 = "S";
                    bancomerParam.Pts = new CSTRUCPTOSBANCOMERBE();
                    bancomerParam.Pts.IPESOSSALDODISPONIBLE = "10000";
                    bancomerParam.Pts.IPUNTOSSALDODISPONIBLE = "5000";
                    bancomerParam.Pts.IPESOSSALDOANTERIOR = "10000";
                    bancomerParam.Pts.IPESOSREDIMIDOS = "10000";
                    bancomerParam.Pts.IPUNTOSSALDOANTERIOR = "5000";
                    bancomerParam.Pts.IPUNTOSREDIMIDOS = "5000";



                    bancomerParam.ClsResponse.ITERMINAL = "1234567";
                    bancomerParam.ClsResponse.ISESSION = "22";
                    bancomerParam.ClsResponse.ISECUENCIA = "12";
                    bancomerParam.ClsResponse.IIMPORTE = bancomerParam.ClsResponse.IIMPORTE.PadLeft(12, '0');
                    bancomerParam.ClsResponse.INOAUTORIZACION = "123456";
                    bancomerParam.ClsRequest.IREFERENCIACOMERCIO = "1";
                    bancomerParam.ClsResponse.ICVEOPERADOR = "1";
                    bancomerParam.ClsResponse.IAFILIACION = "AFSIMU";
                    bancomerParam.ClsResponse.IREFERENCIAFINAN = "2";



                }
                else
                {
                    //si no esta en simulacion, asignamos los campos de bancomer a nuestro objeto para modelarlo
                    bancomerParam = converteABancomerParamBE_PinPadSC(Enviar);


                }

                //caso diferente a exito
                if (bancomerParam.IRESPDLL != 0)
                {
                    if (enCertificacion)
                    {
                        //estado erroneo 
                        bancomerParam.IESTADOTRANSACCIONID = -1;


                        // calcula credito / debito
                        if (bancomerParam.INUMEROTARJETA != null && bancomerParam.INUMEROTARJETA.Trim().Length > 0)
                            bancomerParam.ICREDITODEBITO = ObtenerTipoTarjeta(bancomerParam.INUMEROTARJETA);

                        //guardamos los campos de bancomer localmente
                        bancomerParamD.BANCOMERPARAM_GUARDAR(ref bancomerParam, st);
                    }

                    if (bancomerParam.ClsResponse.ICODIGORESPUESTA == String.Empty)
                    {
                        strResTransaccion = bancomerParam.ClsResponse.ToString();
                        return false;
                    }
                    else
                    {
                        strResTransaccion = bancomerParam.ClsResponse.ILEYENDA.Trim();
                        return false;
                    }
                }
                else//caso de exito bancomerParam.IRESPDLL == 0
                {

                    

                    //el IIDTOKEN12 indica si el usuario tiene puntos
                   // if (bancomerParam.IIDTOKEN12 == "S")
                    if (bancomerParam.ITNXCONPUNTOS == "S")
                    {
                        string Respuesta;
                       WFCustomMessageBox bancomerMessageBox = new WFCustomMessageBox();
                       string cadenaMensajePuntos = "¿Desea usar sus puntos para esta operación? ";
                       bancomerMessageBox.Show("Puntos", cadenaMensajePuntos, "Si", "No", "Consultar", "Cancelar");
                        
                       Respuesta = "No";
                       Respuesta = bancomerMessageBox.result;

                       if (Respuesta == "Si")
                       {

                            //simulacion
                            if (enSimulacion)
                            {
                                //bancomerParam = new CBANCOMERPARAMBE();
                                bancomerParam.IRESPDLL = 0;
                            }
                            else
                            {
                                //se requiere obtener un nuevo consecutivo
                                /*if (!bancomerParamD.BANCOMER_GETCONSECUTIVO(DateTime.Today, ref consecutivoDiaFecha, st))
                                {
                                    Enviar.SincronizacionFinal();
                                    return false;
                                }*/

                                //indicamos que si quiere usar los puntos
                                Enviar.fncTerminaProceso(true);
                                bancomerParam = converteABancomerParamBE_PinPadSC(Enviar);
                            }

                        }
                        else if (Respuesta == "No")
                        {
                            //simulacion
                            if (enSimulacion)
                            {
                                //bancomerParam = new CBANCOMERPARAMBE();
                                bancomerParam.IRESPDLL = 0;
                            }
                            else
                            {
                                //se requiere un nuevo consecutivo
                                /*if (!bancomerParamD.BANCOMER_GETCONSECUTIVO(DateTime.Today, ref consecutivoDiaFecha, st))
                                {
                                    Enviar.SincronizacionFinal();
                                    return false;
                                }*/
                                //indicamos que no quiere usar los puntos
                                //Enviar.fncProcesoPuntos(false, consecutivoDiaFecha.ToString());
                                Enviar.fncTerminaProceso(false);
                                bancomerParam = converteABancomerParamBE_PinPadSC(Enviar);
                            }


                        }

                       else if (Respuesta == "Consultar")
                       {
                           if (!enSimulacion)
                           {
                               Enviar.SincronizacionFinal();

                           }

                           TransaccionViva = false;

                           
                       }
                       else
                       {
                           if (!enSimulacion)
                           {
                               Enviar.SincronizacionFinal();
                           }

                           TransaccionViva = false;
                       }
                    }

                   //if (Enviar.IDToken12 == true)
                  /*if (bancomerParam.ITNXCONPUNTOS == "S")
                    {
                        DialogResult Respuesta;
                        Respuesta = MessageBox.Show("¿Desea usar sus puntos para esta operación? ", "Punto Venta",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        if (Respuesta == DialogResult.Yes)
                        {
                            Enviar.fncTerminaProceso(true);
                            bancomerParam = converteABancomerParamBE_PinPadSC(Enviar);

                        }
                        else if (Respuesta == DialogResult.No)
                        {
                            Enviar.fncTerminaProceso(false);
                            bancomerParam = converteABancomerParamBE_PinPadSC(Enviar);
                        }
                        else
                        {
                            Enviar.SincronizacionFinal();
                            TransaccionViva = false;
                        }
                    }*/




                    if ((bancomerParam.ITBINES != "") && (bancomerParam.ITBINES != null))
                    {
                        MessageBox.Show(bancomerParam.ITBINES);
                    }
                    if (TransaccionViva)//si la transaccion sigue en pie
                    {
                        //en caso de exito
                        if ((bancomerParam.IRESPDLL == 0) && (bancomerParam.ClsResponse.ICODIGORESPUESTA == "00"))
                        {
                            strResTransaccion = bancomerParam.IRESPONSE;//se guarda la respuesta de la transaccion
                            retorno = true;
                        }
                        else if (bancomerParam.ClsResponse.ICODIGORESPUESTA == String.Empty)
                        {
                            strResTransaccion = bancomerParam.IRESPONSE;
                        }
                        else
                        {
                            strResTransaccion = bancomerParam.IRESPONSE;
                        }
                    }
                }


                //guardar la informacion de bancomer
                if (retorno)
                {
                    bancomerParam.IDOCTOID = doctoBE.IID;
                    bancomerParam.ITIPOTRANSACCION = "001";
                    bancomerParam.IESTADOTRANSACCIONID = 1;
                    //bancomerParam.ICREDITODEBITO = strCreditoDebito;
                    //bancomerParam.IVALTIPOCARD = strNumeroTarjeta;



                    // calcula credito / debito
                    if (bancomerParam.INUMEROTARJETA != null && bancomerParam.INUMEROTARJETA.Trim().Length > 0)
                        bancomerParam.ICREDITODEBITO = ObtenerTipoTarjeta(bancomerParam.INUMEROTARJETA);

                    if (!bancomerParamD.BANCOMERPARAM_GUARDAR(ref bancomerParam, st))
                    {
                        MessageBox.Show("Se realizo la operacion  pero no se pudo guardar el registro " + bancomerParamD.IComentario);
                    }
                    bancomerParamId = bancomerParam.IID;

                    //ponerle la bandera a pagobancomeraplicado a docto para saber que tiene pago aplicado por pinpad
                    doctoBE.IPAGOBANCOMERAPLICADO = "S";

                    if (!doctoD.CambiarPAGOBANCOMERAPLICADO(doctoBE, null))
                    {
                        MessageBox.Show("Se realizo la operacion  pero no se pudo poner la bandera del docto " + doctoD.IComentario);
                    }
                }

                return retorno;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }



        public static bool Cancelar(ref CDOCTOBE doctoBE, long bancomerParamOriginalId, ref long bancomerParamId, FbTransaction st)
        {

            /*validar que la fecha sea la misma*/
            strResTransaccion = "";

            if (!PreparaPinPadSC())
            {
                strResTransaccion = strResSync + " - " + strResCargaLlaves;
            }

            Boolean TransaccionViva = true;

            CBANCOMERPARAMD bancomerParamD = new CBANCOMERPARAMD();
            CDOCTOD doctoD = new CDOCTOD();
            CBANCOMERPARAMBE bancomerParam = new CBANCOMERPARAMBE();

            long consecutivoDiaFecha = 0;
            bool retorno = false;

            string strNumeroTarjeta = "";
            string strCreditoDebito = "";

            try
            {
                //obtener consecutivo
                if (!bancomerParamD.BANCOMER_GETCONSECUTIVO(DateTime.Today, ref consecutivoDiaFecha, st))
                {
                    strResTransaccion = "Hubo un error al obtener el consecutivo ";
                    return false;
                }

                //obtener los datos de bancomer de la transaccion original
                CBANCOMERPARAMBE transOriginal = new CBANCOMERPARAMBE();
                transOriginal.IID = bancomerParamOriginalId;
                transOriginal = bancomerParamD.seleccionarBANCOMERPARAM_COMPUESTO(transOriginal, st);//se obtiene la transaccion original que se quierew cancelar

                if (transOriginal == null)
                {
                    strResTransaccion = "No se pudo obtener los datos de la transaccion original";
                    return false;
                }

                //se obtiene la cadena para la cancelacion llamando al metodo correspondiente, enviando los param. de la transaccion que se quiere cancelar
                string cadenaVenta = obtenerCadenaParaCancelarPinPad(doctoBE, transOriginal/*, consecutivoDiaFecha*/);
                Enviar.fncEglobalBBVA(cadenaVenta, 0, MacAlterna);//se envia la cadena



                //simulacion donde se asignan valores ficticios solo para prueba
                if (enSimulacion)
                {
                    Random rnd = new Random();
                    bancomerParam = new CBANCOMERPARAMBE();
                    bancomerParam.IRESPDLL = 0;
                    bancomerParam.IRESPONSE = "Exito";
                    bancomerParam.ClsResponse.ICODIGORESPUESTA = "00";
                    bancomerParam.INOAUTORIZACION = rnd.Next(1, 10000).ToString();
                    bancomerParam.ClsResponse.IIMPORTE = transOriginal.ClsResponse.IIMPORTE;
                    bancomerParam.ICARDTIPO = 1;
                    bancomerParam.IVALTIPOCARD = "1234567890123456";
                    bancomerParam.ICREDITODEBITO = "Credito";
                }
                else
                {
                    bancomerParam = converteABancomerParamBE_PinPadSC(Enviar);
                }



                if (bancomerParam.IRESPDLL != 0)
                {
                    if (bancomerParam.ClsResponse.ICODIGORESPUESTA == String.Empty)
                    {
                        strResTransaccion = bancomerParam.ClsResponse.ToString();
                        return false;
                    }
                    else
                    {
                        strResTransaccion = bancomerParam.ClsResponse.ILEYENDA.Trim();
                        return false;
                    }
                }
                else
                {



                    //si hay algo en el campo de bines simplemente hay que mostrarlo
                    if ((bancomerParam.ITBINES != "") && (bancomerParam.ITBINES != null))
                    {
                        MessageBox.Show(bancomerParam.ITBINES);
                    }

                    if (TransaccionViva)
                    {
                        if ((bancomerParam.IRESPDLL == 0) && (bancomerParam.ClsResponse.ICODIGORESPUESTA == "00"))
                        {
                            strResTransaccion = bancomerParam.IRESPONSE;
                            retorno = true;
                        }
                        else if (bancomerParam.ClsResponse.ICODIGORESPUESTA == String.Empty)
                        {
                            strResTransaccion = bancomerParam.IRESPONSE;
                        }
                        else
                        {
                            strResTransaccion = bancomerParam.IRESPONSE;
                        }
                    }
                }


                //guardar informacion de transaccion de bancomer
                if (retorno)
                {

                    //guardar la informacion de cancelacion
                    bancomerParam.IDOCTOID = doctoBE.IID;
                    bancomerParam.ITIPOTRANSACCION = "002";
                    bancomerParam.IESTADOTRANSACCIONID = 1;
                    bancomerParam.IREFID = bancomerParamOriginalId;
                    //bancomerParam.ICREDITODEBITO = strCreditoDebito;
                    bancomerParam.IVALTIPOCARD = strNumeroTarjeta;



                    // calcula credito / debito
                    if (bancomerParam.INUMEROTARJETA != null && bancomerParam.INUMEROTARJETA.Trim().Length > 0)
                        bancomerParam.ICREDITODEBITO = ObtenerTipoTarjeta(bancomerParam.INUMEROTARJETA);

                    if (!bancomerParamD.BANCOMERPARAM_GUARDAR(ref bancomerParam, st))
                    {
                        MessageBox.Show("Se realizo la operacion  pero no se pudo guardar el registro " + bancomerParamD.IComentario);
                    }
                    bancomerParamId = bancomerParam.IID;



                    //poner la transaccion original como cancelada
                    transOriginal.IREFID = bancomerParamId;
                    transOriginal.IESTADOTRANSACCIONID = 2;
                    bancomerParamD.CambiarBANCOMERPARM_ESTADO_Y_REFID(transOriginal, st);




                    // si ya no hay pagos con tarjeta pinpad activos en este docto cambiar el flag 
                    CBANCOMERPARAMBE bufferBanc = new CBANCOMERPARAMBE();
                    bufferBanc.IDOCTOID = transOriginal.IDOCTOID;
                    bufferBanc.ITIPOTRANSACCION = "001";
                    bufferBanc.IESTADOTRANSACCIONID = 1;
                    List<CBANCOMERPARAMBE> listaPagosSimple = bancomerParamD.seleccionarBANCOMERPARAM_PORDOCTO_Simple(bufferBanc, st);
                    if (listaPagosSimple == null || listaPagosSimple.Count == 0)
                    {

                        doctoBE.IPAGOBANCOMERAPLICADO = "N";

                        if (!doctoD.CambiarPAGOBANCOMERAPLICADO(doctoBE, null))
                        {
                            MessageBox.Show("Se realizo la operacion  pero no se pudo cambiar la bandera del docto " + doctoD.IComentario);
                        }
                    }



                }

                return retorno;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        public static string rutaArchivoPinPadConfig()
        {
            return Application.StartupPath + "\\PinpadConfig.txt";
        }
        public static string obtenCadenaLlave(string terminal,
                                               string sesion,
                                               string transaccionB,
                                               string fechaHoraT,
                                               string claveOp,
                                               string afiliacion)
        {
            /**
             * Estructura del formato del mensaje APPLIMSJ Requerimiento
             * Pagina 34 del manual
             **/

            string cadenaLlaves =
                "092" +                                             //Código de transacción
                terminal +                                          //No. Terminal
                sesion +                                            //No. Sesion
                transaccionB +                                      //No. Secuencia
                "000000000000" +                                    //Importe Trans.
                "000000000000" +                                    //Propina
                "0000000" +                                         //Folio
                "3" +                                               //EMV
                "8" +                                               //Tipo de lector
                "0" +                                               //CVV2
                "00" +                                              //Meses financiamiento
                "00" +                                              //Parcializacion de pagos
                "00" +                                              //Promo
                "0" +                                               //Tipo de moneda
                "      " +                                          //Autorizacion
                "01" +                                              //Modo ingreso
                "    " +                                            //CVV2/CVC2
                "                                        " +        //Track II
                "   " +                                             //Numero de secuencia
                "000000000000" +                                    //Importe Cash back/Cash advance
                fechaHoraT +                                        //Fecha y hora
                "                                             " +   //Referencia del comercio
                "000000000000" +                                    //Otro importe
                claveOp +                                           //Clave de operador
                afiliacion +                                        //Afiliacion
                "    " +                                            //No. cuarto
                "00000000" +                                        //Referencia financiera
                "0" +                                               //Filler
                "000" +                                             //Filler
                "000" +                                             //Filler
                "0000" +                                            //Longitud pagos/multipagos
                "0000";                                             //Longitud campañas/garantías

            return cadenaLlaves;
        }

       /* public static string obtenCadenaConsultarPuntos(string terminal)
        {
            return "016" +                                             //Código de transacción
                   terminal +                                          //No. Terminal
                   "0000000000000000000000000000000000000000000000000                                                       000000000000000000000000                                             000000000000000000000000000000000000000000000000000";
       
                
                //"016000000000000000000000000000000000000000000000000000000000                                                       000000000000000000000000                                             000000000000000000000000000000000000000000000000000";
        }*/

        public static string obtenCadenaConsultarPuntos(string terminal,
                                                          string sesion,
                                                          string transaccion,
                                                          string fechaHora,
                                                          string referenciaComer,
                                                          string claveOperador,
                                                          string afiliacion)
        {
            /**
             * Estructura del formato del mensaje APPLIMSJ Requerimiento
             * Pagina 34 del manual
             **/

            string espacio45 = "".PadLeft(45);
            //string espacio135 = "".PadLeft(135);
            string cadenaVenta =
                "016" +                                                                         //Codigo de Transaccion
                terminal +                                                                      //No. Terminal
                sesion +                                                                        //No. Sesion    
                transaccion +                                                                   //No. Secuencia
                0.ToString("N2").Replace(",", "").Replace(".", "").PadLeft(12, '0') +   //Importe
                "000000000000" +                                                                //Propina
                "0000000" +                                                                     //Folio
                "3" +                                                                           //Capacidad EMV
                "8" +                                                                           //Tipo lector
                "0" +                                                                           //CVV2
                "00" +                                                                          //Meses de financiamiento
                "00" +                                                                          //Parcializacion de pagos
                "00" +                                                                          //Promociones
                "0" +                                                                           //Tipo de moneda
                "      " +                                                                      //Autorizacion
                "  " +                                                                          //Modo ingreso
                "    " +                                                                        //CVV2 CVC2
                "                                        " +                                    //Track-II
                "   " +                                                                         //Numero de secuencia tarjeta
                "000000000000" +                                                                //Importe CashBack CashAdvance
                fechaHora +                                                                     //Fecha y hora del comercio
                espacio45 + //referenciaComer +                                                               //Referencia del comercio
                "000000000000" +                                                                //Otro importe
                claveOperador +                                                                 //Clave operador
                afiliacion +                                                                    //Afiliacion
                "    " +                                                                        //No. Cuarto
                "00000000" +                                                                    //Referencia Financiera
                "0" +                                                                           //Codigo condicion del chip
                "000" +                                                                         //Filler
                "000" +                                                                         //Filler
                "0000" +                                                                        //Longitud pagos y multipagos
                "0000";                                                                     //Longitud campañas
                                                                                        

            return cadenaVenta;
        }


        public static string obtenerCadenaParaActualizarPinPad()
        {
            //TODO VER SI ES ALGO FIJO ESTA CADENA
            return "070000000010095175900000000000000000000000000000003800000000                                                       000000000000100125130417                                             000000000000000005085295470000000000000000000000005";
        }


        public static string obtenerCadenaParaVentaPinPad(string terminal,
                                                          string sesion,
                                                          string transaccion,
                                                          string fechaHora,
                                                          string referenciaComer,
                                                          string claveOperador,
                                                          string afiliacion,
                                                          CDOCTOBE doctoBE,
                                                          decimal montoPago)
        {
            /**
             * Estructura del formato del mensaje APPLIMSJ Requerimiento
             * Pagina 34 del manual
             **/

            string espacio45 = "".PadLeft(45);
            //string espacio135 = "".PadLeft(135);
            string cadenaVenta =
                "001" +                                                                         //Codigo de Transaccion
                terminal +                                                                      //No. Terminal
                sesion +                                                                        //No. Sesion    
                transaccion +                                                                   //No. Secuencia
                montoPago.ToString("N2").Replace(",", "").Replace(".", "").PadLeft(12, '0') +   //Importe
                "000000000000" +                                                                //Propina
                "0000000" +                                                                     //Folio
                "3" +                                                                           //Capacidad EMV
                "8" +                                                                           //Tipo lector
                "1" +                                                                           //CVV2
                "00" +                                                                          //Meses de financiamiento
                "00" +                                                                          //Parcializacion de pagos
                "00" +                                                                          //Promociones
                "0" +                                                                           //Tipo de moneda
                "      " +                                                                      //Autorizacion
                "  " +                                                                          //Modo ingreso
                "    " +                                                                        //CVV2 CVC2
                "                                        " +                                    //Track-II
                "   " +                                                                         //Numero de secuencia tarjeta
                "000000000000" +                                                                //Importe CashBack CashAdvance
                fechaHora +                                                                     //Fecha y hora del comercio
                espacio45 + //referenciaComer +                                                               //Referencia del comercio
                "000000000000" +                                                                //Otro importe
                claveOperador +                                                                 //Clave operador
                afiliacion +                                                                    //Afiliacion
                "    " +                                                                        //No. Cuarto
                "00000000" +                                                                    //Referencia Financiera
                "0" +                                                                           //Codigo condicion del chip
                "000" +                                                                         //Filler
                "000" +                                                                         //Filler
                "0000" +                                                                        //Longitud pagos y multipagos
                "0000";                                                                     //Longitud campañas
                                                                                        

            return cadenaVenta;
        }



        public static string obtenerCadenaParaCancelarPinPad(CDOCTOBE doctoBE, CBANCOMERPARAMBE transOriginal)
        {
            /**
             * Estructura del formato del mensaje APPLIMSJ Requerimiento
             * Pagina 34 del manual
             **/
            string terminal = transOriginal.ClsResponse.ITERMINAL;
            string sesion = transOriginal.ClsResponse.ISESSION;
            string secuencia = transOriginal.ClsResponse.ISECUENCIA;
            string referenciaComer = transOriginal.ClsRequest.IREFERENCIACOMERCIO;
            string claveOp = transOriginal.ClsResponse.ICVEOPERADOR;
            string afiliacion = transOriginal.ClsResponse.IAFILIACION;
            rellenarCadenas(ref terminal, 8, "left", '0');
            rellenarCadenas(ref sesion, 4, "left", '0');
            rellenarCadenas(ref secuencia, 4, "left", '0');
            rellenarCadenas(ref referenciaComer, 45, "left", ' ');
            rellenarCadenas(ref claveOp, 6, "right", 'x');
            rellenarCadenas(ref afiliacion, 8, "left", '0', true);

            string cadenaCancelacion =
                "201" +                                                     //Codigo de transaccion
                terminal +                                                  //No. Terminal
                sesion +                                                    //No. Sesion
                secuencia +                                                 //No. Secuencia de tranasaccion
                transOriginal.ClsResponse.IIMPORTE.PadLeft(12, '0') +       //Importe de la transaccion
                "000000000000" +                                            //Propina
                "0000000" +                                                 //Folio
                "3" +                                                       //Capacidad EMV
                "8" +                                                       //Tipo de lector
                "1" +                                                       //CVV2
                "00" +                                                      //Meses de financiamiento
                "00" +                                                      //Parcializacion de pagos
                "00" +                                                      //Promociones
                "0" +                                                       //Tipo de moneda
                transOriginal.ClsResponse.INOAUTORIZACION +                 //Autorizacion
                "  " +                                                      //Modo ingreso de la tarjeta
                "    " +                                                    //CVV2 CVC2
                "                                        " +                //Track II
                "   " +                                                     //Numero de secuencia de la tarjeta
                "000000000000" +                                            //Importe CashBack CashAdvance
                DateTime.Now.ToString("yyMMddHHmmss") +                     //Fecha y hora del comercio
                referenciaComer +                                           //Referencia del comercio
                "000000000000" +                                            //Otro importe
                claveOp +                                                   //Clave de operador
                afiliacion +                                                //Afiliacion
                "    " +                                                    //Numero de cuarto
                transOriginal.ClsResponse.IREFERENCIAFINAN +                //Referencia financiera
                "0" +                                                       //Codigo condicion del chip
                "000" +                                                     //Filler
                "000" +                                                     //Filler
                "0000" +                                                    //Longitud pagos y multipagos
                "0000";                                                     //Longitud campañas

            return cadenaCancelacion;
        }

        //covierte el objeto pinpadsc en nuestro objeto CBANCOMERPARAMBE
        public static CBANCOMERPARAMBE converteABancomerParamBE_PinPadSC(PinPadSC pinPad)
        {
            if (pinPad == null)
                return null;

            CBANCOMERPARAMBE bancomerParamBE = new CBANCOMERPARAMBE();
            llenaBancomerParamBE_PinPadSC(ref bancomerParamBE, pinPad);
            return bancomerParamBE;
        }

        public static void llenaBancomerParamBE_PinPadSC(ref CBANCOMERPARAMBE bancomerParamBE, PinPadSC pinPad)
        {

            bancomerParamBE.IAID = pinPad.AID;
            bancomerParamBE.IAMEX = short.Parse(PinPadSC.AMEX.ToString());
            bancomerParamBE.IBANCOMER = pinPad.Bancomer ? "S" : "N";
            bancomerParamBE.IBITCAMPANAS = pinPad.BitCampañas ? "S" : "N"; ;
            bancomerParamBE.ICAMPANAAUTORIZACION = pinPad.CampañaAutorizacion;
            bancomerParamBE.ICAMPANAREFERENCIA = pinPad.CampañaReferencia;
            //bancomerParamBE.ICAMPANAREFERENCIANUM = pinPad.;
            bancomerParamBE.ICARDREQUEST = pinPad.CardRequest;
            bancomerParamBE.ICARDTIPO = pinPad.CardTipo;
            //bancomerParamBE.IPROMOCIONES = pinPad.;
            bancomerParamBE.ICLIENTE_CMP_COMERCIO = pinPad.Cliente_CMP_Comercio;
            bancomerParamBE.ICLIENTE_TDC_STOCK = pinPad.Cliente_TDC_STOCK;
            //bancomerParamBE.ICLSREQUESTID = pinPad.cls;
            //bancomerParamBE.ICLSRESPONSEID = pinPad.ClsResponsePOSClsResponse;
            bancomerParamBE.ICODIGO_BENEFICIO1 = pinPad.Codigo_Beneficio1;
            bancomerParamBE.ICODIGO_BENEFICIO2 = pinPad.Codigo_Beneficio2;
            bancomerParamBE.ICODIGO_BENEFICIO3 = pinPad.Codigo_Beneficio3;
            bancomerParamBE.ICODIGO_BENEFICIO4 = pinPad.Codigo_Beneficio4;
            bancomerParamBE.ICODIGO_BENEFICIO5 = pinPad.Codigo_Beneficio5;
            bancomerParamBE.ICODIGO_BENEFICIO6 = pinPad.Codigo_Beneficio6;
            bancomerParamBE.ICODIGO_BENEFICIO7 = pinPad.Codigo_Beneficio7;
            bancomerParamBE.ICOMERCIO_CMP_COMERCIO = pinPad.Comercio_CMP_Comercio;
            bancomerParamBE.ICOMERCIO_TDC_STOCK = pinPad.Comercio_TDC_STOCK;
            bancomerParamBE.ICOMISION1 = pinPad.Comision1;
            bancomerParamBE.ICOMISION2 = pinPad.Comision2;
            bancomerParamBE.ICOMISION3 = pinPad.Comision3;
            bancomerParamBE.ICOMISION4 = pinPad.Comision4;
            bancomerParamBE.ICOMISION5 = pinPad.Comision5;
            bancomerParamBE.ICOMISION6 = pinPad.Comision6;
            bancomerParamBE.ICOMISION7 = pinPad.Comision7;
            bancomerParamBE.ICREDITODEBITO = pinPad.CreditoDebito;
            bancomerParamBE.ICRIPTOGRAMA = pinPad.Criptograma;
            bancomerParamBE.IECOUPNUMBER = pinPad.EcoupNumber;
            bancomerParamBE.IFACTOREXP = pinPad.FactorExp;
            bancomerParamBE.IFIRMAAUTOGRAFA = pinPad.FirmaAutografa ? "S" : "N";
            bancomerParamBE.IFIRMAELECTRONICA = pinPad.FirmaElectronica ? "S" : "N"; ;
            bancomerParamBE.IFIRMAQPS = pinPad.FirmaQPS ? "S" : "N"; ;
            bancomerParamBE.IGUIA_CIE = pinPad.Guia_CIE;
            bancomerParamBE.IIDTOKEN12 = pinPad.IDToken12 ? "S" : "N"; ;
            bancomerParamBE.IIDTOKEN13 = pinPad.IDToken13 ? "S" : "N"; ;
            bancomerParamBE.IIDTOKEN16 = pinPad.IDToken16 ? "S" : "N"; ;
            bancomerParamBE.IIDTOKENR7 = pinPad.IDTokenR7 ? "S" : "N"; ;
            bancomerParamBE.IIDTOKENR8 = pinPad.IDTokenR8 ? "S" : "N"; ;
            bancomerParamBE.IIMPORTE_BENEFICIO = pinPad.Importe_Beneficio;
            bancomerParamBE.IIMPORTE_UDIS = pinPad.ImporteUDIS;
            bancomerParamBE.IINDICADOR_CAMBIO_PLAZO = pinPad.Indicador_Cambio_Plazo;
            bancomerParamBE.IINDICADOR_DE_AVISO = pinPad.Indicador_de_Aviso;
            bancomerParamBE.IINDICAODR_DE_BENEFICIO = pinPad.Indicador_de_Beneficio;
            bancomerParamBE.IISFOLIO = pinPad.IsFolio;
            bancomerParamBE.IISOFFLINE = pinPad.ISOffline ? "S" : "N";
            bancomerParamBE.ILEYENDA = pinPad.Leyenda;
            bancomerParamBE.IMACADDALTERNATIVA = pinPad.MacAddAlternativa;
            bancomerParamBE.IMENSAJE_BASE_CHEQUE = pinPad.Mensaje_Base_Cheque;
            bancomerParamBE.IMENSAJE_BASE_CONTINUOS = pinPad.Mensaje_Base_Continuous;
            bancomerParamBE.IMENSAJE_CLIENTE = pinPad.Mensaje_Clente;
            bancomerParamBE.IMENSAJE_CLIENTE_EMISRO = pinPad.Mensaje_Cliente_Emisor;
            bancomerParamBE.IMENSAJE_COMERCIO = pinPad.Mensaje_Comercio;
            bancomerParamBE.IMODOINGRESO = pinPad.ModoIngreso;
            bancomerParamBE.IMONTO_BENEFICIO_MULTIPLE1 = pinPad.Monto_Beneficio_Multiple1;
            bancomerParamBE.IMONTO_BENEFICIO_SIMPLE1 = pinPad.Monto_Beneficio_Simple1;
            bancomerParamBE.IMONTO_CHEQUE_ACTUAL = pinPad.Monto_Cheque_Actual;
            bancomerParamBE.IMONTO_CHEQUE_ANTERIOR = pinPad.Monto_Cheques_Anterior;
            bancomerParamBE.IMONTO_CHEQUE_REDIMIDOS = pinPad.Monto_Cheques_Redimidos;
            bancomerParamBE.IMONTO_CONTINUOS_ACTUAL = pinPad.Monto_Continuos_Actual;
            bancomerParamBE.IMONTO_CONTINUOS_ANTERIOR = pinPad.Monto_Continuos_Anterior;
            bancomerParamBE.IMONTO_CONTINUOS_REDIMIDOS = pinPad.Monto_Continuos_Redimidos;
            bancomerParamBE.IMONTO_MULTIPLE2 = pinPad.Monto_Multiple2;
            bancomerParamBE.IMONTO_MULTIPLE3 = pinPad.Monto_Multiple3;
            bancomerParamBE.IMONTO_MULTIPLE4 = pinPad.Monto_Multiple4;
            bancomerParamBE.IMONTO_MULTIPLE5 = pinPad.Monto_Multiple5;
            bancomerParamBE.IMONTO_MULTIPLE6 = pinPad.Monto_Multiple6;
            bancomerParamBE.IMONTO_MULTIPLE7 = pinPad.Monto_Multiple7;
            bancomerParamBE.IMONTO_SIMPLE2 = pinPad.Monto_Simple2;
            bancomerParamBE.IMONTO_SIMPLE3 = pinPad.Monto_Simple3;
            bancomerParamBE.IMONTO_SIMPLE4 = pinPad.Monto_Simple4;
            bancomerParamBE.IMONTO_SIMPLE5 = pinPad.Monto_Simple5;
            bancomerParamBE.IMONTO_SIMPLE6 = pinPad.Monto_Simple6;
            bancomerParamBE.IMONTO_SIMPLE7 = pinPad.Monto_Simple7;
            bancomerParamBE.INOAUTORIZACION = pinPad.NoAutorizacion;
            bancomerParamBE.INOMBREAPLICACION = pinPad.NombreAplicacion;
            bancomerParamBE.INOMBRECLIENTE = pinPad.NombreCliente;
            bancomerParamBE.INUMERO_DE_BENEFICIOS = pinPad.Numero_de_Beneficios;
            bancomerParamBE.INUMEROTARJETA = pinPad.NumeroTarjeta;
            bancomerParamBE.INUMTARJETAII = pinPad.NumTarjetaII;
            //bancomerParamBE.IPAGOSMULTIPAGOSID = pinPad.PagosMultipagos ;
            bancomerParamBE.IPESOSREDIMIDOS = pinPad.PesosRedimidos;
            bancomerParamBE.IPESOSSALDOANTERIOR = pinPad.PesosSaldoAnterior;
            bancomerParamBE.IPESOSSALDODISPONIBLE = pinPad.PesosSaldoDisponible;
            bancomerParamBE.IPESOSSALDODISPONINLEEXP = pinPad.PesosSaldoDisponibleExp;
            bancomerParamBE.IPESOSSALDOREDIMIDOSEXP = pinPad.PesosSaldoRedimidoExp;
            bancomerParamBE.IPINPAD_USO = pinPad.PinPad_Uso ? "S" : "N"; ;
            bancomerParamBE.IPOOLADJUSTTYPE = pinPad.PoolAdjustType;
            bancomerParamBE.IPOOLID = pinPad.PoolID;
            bancomerParamBE.IPOOLNUMBER = pinPad.PoolNumber;
            bancomerParamBE.IPOOLUNITLABEL = pinPad.PoolUnitLabel;
            //bancomerParamBE.IPUNTOSID = pinPad.StrucPtosPuntos ? "S" : "N";
            bancomerParamBE.IPUNTOSREDIMIDOS = pinPad.PuntosRedimidos;
            bancomerParamBE.IPUNTOSSALDOANTERIOR = pinPad.PuntosSaldoAnterior;
            bancomerParamBE.IPUNTOSSALDODISPONIBLE = pinPad.PuntosSaldoDisponible;
            bancomerParamBE.IPUNTOSSALDODISPONIBLEEXP = pinPad.PuntosSaldoDisponibleExp;
            bancomerParamBE.IPUNTOSSALDOREDIMIDOSEXP = pinPad.PuntosSaldoRedimidoExp;
            bancomerParamBE.IR8_CODIGO_LEYENDA = pinPad.R8_Codigo_Leyenda;
            bancomerParamBE.IR8_LEYENDA = pinPad.R8_Leyenda;
            bancomerParamBE.IRAZON_SOCIAL = pinPad.Razon_Social;
            bancomerParamBE.IREFERENCIA_RESPUESTA = pinPad.referencia_Respuesta;
            //bancomerParamBE.IREFERENCIAAFIN = pinPad.;
            bancomerParamBE.IREQUEST = pinPad.Request;
            bancomerParamBE.IRESPDLL = pinPad.RespDLL;
            bancomerParamBE.IRESPONSE = pinPad.Response;
            bancomerParamBE.ISEGMENTNUMBER = pinPad.SegmentNumber;
            bancomerParamBE.ITBINES = pinPad.TBines;
            bancomerParamBE.ITIPO_BENEFICIO1 = pinPad.Tipo_Beneficio1;
            bancomerParamBE.ITIPO_BENEFICIO2 = pinPad.Tipo_Beneficio2;
            bancomerParamBE.ITIPO_BENEFICIO3 = pinPad.Tipo_Beneficio3;
            bancomerParamBE.ITIPO_BENEFICIO4 = pinPad.Tipo_Beneficio4;
            bancomerParamBE.ITIPO_BENEFICIO5 = pinPad.Tipo_Beneficio5;
            bancomerParamBE.ITIPO_BENEFICIO6 = pinPad.Tipo_Beneficio6;
            bancomerParamBE.ITIPO_BENEFICIO7 = pinPad.Tipo_Beneficio7;
            bancomerParamBE.ITIPO_RESPUESTA1 = pinPad.Tipo_Respuesta1;
            bancomerParamBE.ITIPO_RESPUESTA2 = pinPad.Tipo_Respuesta2;
            bancomerParamBE.ITIPO_RESPUESTA3 = pinPad.Tipo_Respuesta3;
            bancomerParamBE.ITIPO_RESPUESTA4 = pinPad.Tipo_Respuesta4;
            bancomerParamBE.ITIPO_RESPUESTA5 = pinPad.Tipo_Respuesta5;
            bancomerParamBE.ITIPO_RESPUESTA6 = pinPad.Tipo_Respuesta6;
            bancomerParamBE.ITIPO_RESPUESTA7 = pinPad.Tipo_Respuesta7;
            bancomerParamBE.ITIPOPOS = pinPad.TipoPOS;
            bancomerParamBE.ITNXCONPUNTOS = pinPad.TnxConPuntos ? "S" : "N";
            bancomerParamBE.ITOPERADOR = pinPad.TOperador;
            bancomerParamBE.IVALTIPOCARD = pinPad.ValTipoCard;
            bancomerParamBE.IVIGENCIAPROMOCIONESEXP = pinPad.VigenciaPromocionExp;


            if (bancomerParamBE.ClsRequest == null)
            {
                bancomerParamBE.ClsRequest = new CREQUESTBANCOMERBE();
            }


            if (pinPad.ClsRequest != null)
            {
                bancomerParamBE.ClsRequest.IISSINTJROPERADOR = ClsRequestPOS.IsSinTjrOperador ? "S" : "N";
                bancomerParamBE.ClsRequest.INOMAUTORIZACION = ClsRequestPOS.NomAutorizacion;
                bancomerParamBE.ClsRequest.INOMBRE = ClsRequestPOS.Nombre;
                bancomerParamBE.ClsRequest.IPAN = ClsRequestPOS.PAN;
                bancomerParamBE.ClsRequest.ITOPERADOR = ClsRequestPOS.Toperador;
                bancomerParamBE.ClsRequest.ICODTRANSACTION = pinPad.ClsRequest.C01_CodTransaction;
                bancomerParamBE.ClsRequest.ITERMINAL = pinPad.ClsRequest.C02_Teminal;
                bancomerParamBE.ClsRequest.ISESSION = pinPad.ClsRequest.C03_Session;
                bancomerParamBE.ClsRequest.ISECUENCIA = pinPad.ClsRequest.C04_secuencia;
                bancomerParamBE.ClsRequest.IIMPORTE = pinPad.ClsRequest.C05_Importe;
                bancomerParamBE.ClsRequest.IPROPINA = pinPad.ClsRequest.C06_Propina;
                bancomerParamBE.ClsRequest.IFOLIO = pinPad.ClsRequest.C07_Folio;
                bancomerParamBE.ClsRequest.ICAPEMV = pinPad.ClsRequest.C08_CapEMV;
                bancomerParamBE.ClsRequest.ITIPOLECTOR = pinPad.ClsRequest.C09_TipoLector;
                bancomerParamBE.ClsRequest.ICAPCVV2 = pinPad.ClsRequest.C10_CapCVV2;
                bancomerParamBE.ClsRequest.IMESESFIN = pinPad.ClsRequest.C11_MesesFin;
                bancomerParamBE.ClsRequest.IPARCIALIZACION = pinPad.ClsRequest.C12_Parcializacion;
                bancomerParamBE.ClsRequest.IPROMOCIONES = pinPad.ClsRequest.C13_Promociones;
                bancomerParamBE.ClsRequest.ITIPOMONEDA = pinPad.ClsRequest.C14_TipoMoneda;
                bancomerParamBE.ClsRequest.INOAUTORIZACION = pinPad.ClsRequest.C15_NoAutorizacion;
                bancomerParamBE.ClsRequest.IMODOINGRESO = pinPad.ClsRequest.C16_ModoIngreso;
                bancomerParamBE.ClsRequest.ICVV2 = pinPad.ClsRequest.C17_CVV2;
                bancomerParamBE.ClsRequest.ITRACK2 = pinPad.ClsRequest.C18_Track2;
                bancomerParamBE.ClsRequest.INOSECUENCIA = pinPad.ClsRequest.C19_NoSecuencia;
                bancomerParamBE.ClsRequest.IIMPORTECASH = pinPad.ClsRequest.C20_ImporteCash;
                bancomerParamBE.ClsRequest.IFECHAHORACOMERCIO = pinPad.ClsRequest.C21_FechaHoraComercio;
                bancomerParamBE.ClsRequest.IREFERENCIACOMERCIO = pinPad.ClsRequest.C22_ReferenciaComercio;
                bancomerParamBE.ClsRequest.IOTROIMPORTE = pinPad.ClsRequest.C23_OtroImporte;
                bancomerParamBE.ClsRequest.ICLAVEOPERADOR = pinPad.ClsRequest.C24_ClaveOperador;
                bancomerParamBE.ClsRequest.IAFILIACION = pinPad.ClsRequest.C25_Afiliacion;
                bancomerParamBE.ClsRequest.INUMEROCUARTO = pinPad.ClsRequest.C26_NumeroCuarto;
                bancomerParamBE.ClsRequest.IREFERENCIAFINANCIERA = pinPad.ClsRequest.C27_ReferenciaFinanciera;
                bancomerParamBE.ClsRequest.ICODIGOCONDCHIP = pinPad.ClsRequest.C28_CodigoCondChip;
                bancomerParamBE.ClsRequest.ILONGEMVFULL = pinPad.ClsRequest.C29_LongEMVfull;
                bancomerParamBE.ClsRequest.IDATOSEMVFULL = pinPad.ClsRequest.C30_DatosEMVfull;
                bancomerParamBE.ClsRequest.ILONGLEALTAD = pinPad.ClsRequest.C31_LongLealtad;
                bancomerParamBE.ClsRequest.IDATOSLEALTAD = pinPad.ClsRequest.C32_DatosLealtad;
                bancomerParamBE.ClsRequest.ILONGMULTIPAGOS = pinPad.ClsRequest.C33_LongMultipagos;
                bancomerParamBE.ClsRequest.IDATOSMULTIPAGOS = pinPad.ClsRequest.C34_DatosMultipagos;
                bancomerParamBE.ClsRequest.ILONGDATOSCIFRADOS = pinPad.ClsRequest.C35_LongDatosCifrados;
                bancomerParamBE.ClsRequest.IDATOSCIFRADOS = pinPad.ClsRequest.C36_DatosCifrados;
                bancomerParamBE.ClsRequest.ILONGCAMPANA = pinPad.ClsRequest.C37_LongCampaña;
                bancomerParamBE.ClsRequest.IDATOSCAMPANA = pinPad.ClsRequest.C38_DatosCampaña;
                bancomerParamBE.ClsRequest.ICONVENIOCIE = pinPad.ClsRequest.Convenio_CIE;
                bancomerParamBE.ClsRequest.IVERSION = pinPad.ClsRequest.Version;
            }


            if (bancomerParamBE.ClsResponse == null)
            {
                bancomerParamBE.ClsResponse = new CRESPONSEBANCOMERBE();
            }

            if (pinPad.ClsResponse != null)
            {
                bancomerParamBE.ClsResponse.ICODTRANSACTION = pinPad.ClsResponse.C01_CodTransaction;
                bancomerParamBE.ClsResponse.ITERMINAL = pinPad.ClsResponse.C02_Teminal;
                bancomerParamBE.ClsResponse.ISESSION = pinPad.ClsResponse.C03_Session;
                bancomerParamBE.ClsResponse.ISECUENCIA = pinPad.ClsResponse.C04_secuencia;
                bancomerParamBE.ClsResponse.ICODIGORESPUESTA = pinPad.ClsResponse.C05_CodigoRespuesta;
                bancomerParamBE.ClsResponse.INOAUTORIZACION = pinPad.ClsResponse.C06_NoAutorizacion;
                bancomerParamBE.ClsResponse.IAFILIACION = pinPad.ClsResponse.C07_Afiliacion;
                bancomerParamBE.ClsResponse.IFILLER1 = pinPad.ClsResponse.C08_filler1;
                bancomerParamBE.ClsResponse.IIMPORTE = pinPad.ClsResponse.C09_importe;
                bancomerParamBE.ClsResponse.IFILLER2 = pinPad.ClsResponse.C10_filler2;
                bancomerParamBE.ClsResponse.ITARJETA = pinPad.ClsResponse.C11_tarjeta;
                bancomerParamBE.ClsResponse.ICVEOPERADOR = pinPad.ClsResponse.C12_cveOperador;
                bancomerParamBE.ClsResponse.IFILLER3 = pinPad.ClsResponse.C13_Filer3;
                bancomerParamBE.ClsResponse.IFOLIO = pinPad.ClsResponse.C14_Folio;
                bancomerParamBE.ClsResponse.ILONGLEYENDA = pinPad.ClsResponse.C15_LongLeyenda;
                bancomerParamBE.ClsResponse.ILEYENDA = pinPad.ClsResponse.C16_Leyenda;
                bancomerParamBE.ClsResponse.IREFERENCIAFINAN = pinPad.ClsResponse.C17_referenciafinan;
                bancomerParamBE.ClsResponse.ILONGEMV = pinPad.ClsResponse.C18_LongEMV;
                bancomerParamBE.ClsResponse.IDATOSEMV = pinPad.ClsResponse.C19_DatosEMV;
                bancomerParamBE.ClsResponse.ILONGLEALTAD = pinPad.ClsResponse.C20_LongLealtad;
                bancomerParamBE.ClsResponse.IDATOSLEALTAD = pinPad.ClsResponse.C21_DatosLealtad;
                bancomerParamBE.ClsResponse.IREGISTRO1 = pinPad.ClsResponse.C22_Registro1;
                bancomerParamBE.ClsResponse.IREGISTRO2 = pinPad.ClsResponse.C23_Registro2;
                bancomerParamBE.ClsResponse.IREGISTRO3 = pinPad.ClsResponse.C24_Registro3;
                bancomerParamBE.ClsResponse.IREGISTRO4 = pinPad.ClsResponse.C25_Registro4;
                bancomerParamBE.ClsResponse.IREGISTRO5 = pinPad.ClsResponse.C26_Registro5;
                bancomerParamBE.ClsResponse.ILONGMULTIPAGOS = pinPad.ClsResponse.C27_LongMultipagos;
                bancomerParamBE.ClsResponse.IMULTIPAGOS = pinPad.ClsResponse.C28_Multipagos;
                bancomerParamBE.ClsResponse.ILONGDATOSCIFRADOS = pinPad.ClsResponse.C29_LongDatosCifrados;
                bancomerParamBE.ClsResponse.IDATOSCIFRADOS = pinPad.ClsResponse.C30_DatosCifrados;
                bancomerParamBE.ClsResponse.ILONGCAMPANA = pinPad.ClsResponse.C31_LongCampaña;
                bancomerParamBE.ClsResponse.IDATOSCAMPANA = pinPad.ClsResponse.C32_DatosCampaña;


                if (bancomerParamBE.ClsResponse.C00_Encabezado == null)
                {
                    bancomerParamBE.ClsResponse.C00_Encabezado = new CENCABEZADORESPONSEBANCOMERBE();
                }

                if (pinPad.ClsResponse.C00_Encabezado != null)
                {
                    bancomerParamBE.ClsResponse.C00_Encabezado.IENCABEZADOIP = pinPad.ClsResponse.C00_Encabezado.C01_EncabezadoIP;
                    bancomerParamBE.ClsResponse.C00_Encabezado.IMENSAJE = pinPad.ClsResponse.C00_Encabezado.C02_Mensaje;
                    bancomerParamBE.ClsResponse.C00_Encabezado.ITIPOMENSAJE = pinPad.ClsResponse.C00_Encabezado.C03_TipoMensaje;
                    bancomerParamBE.ClsResponse.C00_Encabezado.IIDSANDF = pinPad.ClsResponse.C00_Encabezado.C04_IdSandF;
                    bancomerParamBE.ClsResponse.C00_Encabezado.IIDSECUENCIAL = pinPad.ClsResponse.C00_Encabezado.C05_IdSecuencial;
                    bancomerParamBE.ClsResponse.C00_Encabezado.IDIRECCIONIP = pinPad.ClsResponse.C00_Encabezado.C06_DireccionIP;
                    bancomerParamBE.ClsResponse.C00_Encabezado.IENCABEZADOVERSION = pinPad.ClsResponse.C00_Encabezado.C07_EncabezadoVersion;
                    bancomerParamBE.ClsResponse.C00_Encabezado.IMACADDRESS = pinPad.ClsResponse.C00_Encabezado.C08_MacAddress;
                    bancomerParamBE.ClsResponse.C00_Encabezado.IVERSIONDLL = pinPad.ClsResponse.C00_Encabezado.C09_VersionDLL;
                    bancomerParamBE.ClsResponse.C00_Encabezado.ICONECTADOPINPAD = pinPad.ClsResponse.C00_Encabezado.C10_ConectadoPinPad;
                    bancomerParamBE.ClsResponse.C00_Encabezado.IUSOPINPAD = pinPad.ClsResponse.C00_Encabezado.C11_UsoPinPad;
                    bancomerParamBE.ClsResponse.C00_Encabezado.ILONGSEBEHPOS = pinPad.ClsResponse.C00_Encabezado.C12_LongSEBEHPOS;
                    bancomerParamBE.ClsResponse.C00_Encabezado.IMACADDALTERNATIVA = pinPad.ClsResponse.C00_Encabezado.MacAddAlternativa;
                    bancomerParamBE.ClsResponse.C00_Encabezado.IPINPADDETECTADO = pinPad.ClsResponse.C00_Encabezado.PinPadDetectado ? "S" : "N";
                    bancomerParamBE.ClsResponse.C00_Encabezado.IQPSENLONGMACADD = ClsEncabezado.QPSenLongMacAdd;
                    bancomerParamBE.ClsResponse.C00_Encabezado.ITELECARGAPINPAD = ClsEncabezado.TelecargaPinPad;
                }

            }


            if (bancomerParamBE.Pts == null)
            {
                bancomerParamBE.Pts = new CSTRUCPTOSBANCOMERBE();
            }
            //if (pinPad.Puntos != null)
            //{
            bancomerParamBE.Pts.ICARDREQUEST = pinPad.Puntos.CardRequest;
            bancomerParamBE.Pts.IECOUPNUMBER = pinPad.Puntos.EcoupNumber;
            bancomerParamBE.Pts.IFACTOREXP = pinPad.Puntos.FactorExp;
            bancomerParamBE.Pts.IPESOSREDIMIDOS = pinPad.Puntos.PesosRedimidos;
            bancomerParamBE.Pts.IPESOSSALDOANTERIOR = pinPad.Puntos.PesosSaldoAnterior;
            bancomerParamBE.Pts.IPESOSSALDODISPONIBLE = pinPad.Puntos.PesosSaldoDisponible;
            bancomerParamBE.Pts.IPESOSSALDODISPONINLEEXP = pinPad.Puntos.PesosSaldoDisponibleExp;
            bancomerParamBE.Pts.IPESOSSALDOREDIMIDOSEXP = pinPad.Puntos.PesosSaldoRedimidoExp;
            bancomerParamBE.Pts.IPOOLADJUSTTYPE = pinPad.Puntos.PoolAdjustType;
            bancomerParamBE.Pts.IPOOLID = pinPad.Puntos.PoolID;
            bancomerParamBE.Pts.IPOOLNUMBER = pinPad.Puntos.PoolNumber;
            bancomerParamBE.Pts.IPOOLUNITLABEL = pinPad.Puntos.PoolUnitLabel;
            bancomerParamBE.Pts.IPUNTOSREDIMIDOS = pinPad.Puntos.PuntosRedimidos;
            bancomerParamBE.Pts.IPUNTOSSALDOANTERIOR = pinPad.Puntos.PuntosSaldoAnterior;
            bancomerParamBE.Pts.IPUNTOSSALDODISPONIBLE = pinPad.Puntos.PuntosSaldoDisponible;
            bancomerParamBE.Pts.IPUNTOSSALDODISPONIBLEEXP = pinPad.Puntos.PuntosSaldoDisponibleExp;
            bancomerParamBE.Pts.IPUNTOSSALDOREDIMIDOEXP = pinPad.Puntos.PuntosSaldoRedimidoExp;
            bancomerParamBE.Pts.ISEGMENTNUMBER = pinPad.Puntos.SegmentNumber;
            bancomerParamBE.Pts.ITIPOPOS = pinPad.Puntos.TipoPOS;
            bancomerParamBE.Pts.IVIGENCIAPROMOCIONEXP = pinPad.Puntos.VigenciaPromocionExp;
            //}





        }

        //la sesion se obtiene del id del corte actual
        public static long ObtenerNumeroSession()
        {
            CCORTEBE corteBE = ObtenerCorteActual();
            if (corteBE == null)
            {
                return -1;
            }
            else
            {
                return corteBE.IID;
            }
        }


        public static CCORTEBE ObtenerCorteActual()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            DateTime fechaCorte = DateTime.MinValue;
            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
            {
                return null;
            }
            else
            {


                CCORTEBE corteBuffer = new CCORTEBE();
                CCORTED corteD = new CCORTED();
                corteBuffer.ICAJEROID = iPos.CurrentUserID.CurrentUser.IID;
                corteBuffer.IFECHACORTE = fechaCorte;
                corteBuffer = corteD.seleccionarCORTEXDIAyCAJERO(corteBuffer, null);

                return corteBuffer;
            }
        }

        public static void FijarDatosVariablesTicket(ref string firmaAutografa,
                                                     ref string firmaElectronica,
                                                     ref string firmaQps,
                                                     ref string criptograma,
                                                     ref string pagadoConPuntos,
                                                     ref string pesosAnteriores,
                                                     ref string pesosUsados,
                                                     ref string pesosDisponibles,
                                                     ref string puntosAnteriores,
                                                     ref string puntosUsados,
                                                     ref string puntosDisponibles,
                                                     ref string tipoTransaccion,
                                                     ref string importe,
                                                     ref string numeroTarjetaEncriptado,
                                                     ref string fechaHora,
                                                     ref string comercio,
                                                     ref string calle,
                                                     ref string numero,
                                                     ref string colonia,
                                                     ref string caja,
                                                     ref string terminal,
                                                     ref string modoIngreso,
                                                     ref string referenciaFin,
                                                     ref string secuencia,
                                                     ref string importePagadoConPuntos,
                                                     ref string importePorPagar,
                                                     ref CBANCOMERPARAMBE bancomerBE,
                                                     bool bManejaPuntos)
        {
            comercio = CurrentUserID.CurrentParameters.INOMBRE;
            calle = CurrentUserID.CurrentParameters.ICALLE;
            numero = CurrentUserID.CurrentParameters.INUMEROEXTERIOR;
            colonia = CurrentUserID.CurrentParameters.ICOLONIA;
            CCAJAD cajaDB = new CCAJAD();
            CCAJABE cajaBEB = new CCAJABE();
            cajaBEB.IID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
            cajaBEB = cajaDB.seleccionarCAJA(cajaBEB, null);
            caja = cajaBEB.INOMBRE;
            terminal = cajaBEB.INUMEROTERMINALBANCOMER.ToString();

            if (bancomerBE.ClsRequest.IMODOINGRESO == "05") modoIngreso = "I@1";
            if (bancomerBE.ClsRequest.IMODOINGRESO == "80") modoIngreso = "D@1";

            numeroTarjetaEncriptado = "xxxxxxxxxxxx" + bancomerBE.INUMEROTARJETA.Remove(0, 12);
            importe = " $" + formatoPesos(bancomerBE.ClsResponse.IIMPORTE);

            if (bancomerBE.IMODOINGRESO != null && bancomerBE.IMODOINGRESO == "05")
            {
                criptograma = bancomerBE.ICRIPTOGRAMA;
            }

            if (bManejaPuntos)
            {
                pagadoConPuntos = "Puntos Bancomer";

                puntosAnteriores = "Saldo Anterior (PTS)     :  " + formatoPtos(bancomerBE.Pts.IPUNTOSSALDOANTERIOR);
                pesosAnteriores = "Importe en pesos         : $" + formatoPesos(bancomerBE.Pts.IPESOSSALDOANTERIOR);
                puntosUsados = "Redimidos (PTS)          :  " + formatoPtos(bancomerBE.Pts.IPUNTOSREDIMIDOS);
                pesosUsados = "Importe en pesos         : $" + formatoPesos(bancomerBE.Pts.IPESOSREDIMIDOS);
                puntosDisponibles = "Saldo Actual (PTS)       :  " + formatoPtos(bancomerBE.Pts.IPUNTOSSALDODISPONIBLE);
                pesosDisponibles = "Importe en pesos         : $" + formatoPesos(bancomerBE.Pts.IPESOSSALDODISPONIBLE);


                importePagadoConPuntos = " $" + formatoPesos(bancomerBE.Pts.IPESOSREDIMIDOS);

                decimal importeDec = (decimal.Parse(bancomerBE.ClsResponse.IIMPORTE) / 100);
                decimal importePesosRedimidos = (decimal.Parse(bancomerBE.Pts.IPESOSREDIMIDOS) / 100);
                importePorPagar = " $" + (importeDec - importePesosRedimidos).ToString("N2");


            }

            if (bancomerBE.IFIRMAAUTOGRAFA == "S")
            {
                firmaAutografa = "            FIRMA           ";
            }
            else if (bancomerBE.IFIRMAELECTRONICA == "S")
            {
                firmaElectronica = "AUTORIZADO MEDIANTE FIRMA ELECTRONICA";
            }
            else if (bancomerBE.IFIRMAQPS == "S")
            {
                firmaQps = "AUTORIZADO MEDIANTE FIRMA QPS";
            }

            if (bancomerBE.ClsResponse.ICODTRANSACTION == "001")
            {
                tipoTransaccion = "VENTA";
            }
            else if (bancomerBE.ClsResponse.ICODTRANSACTION == "201")
            {
                tipoTransaccion = "CANCELACION";
            }
            else if (bancomerBE.ClsResponse.ICODTRANSACTION == "016")
            {
                tipoTransaccion = "CONSULTA DE PUNTOS";
            }
            else if (bancomerBE.ClsResponse.ICODTRANSACTION == "018")
            {
                tipoTransaccion = "VENTA";
            }

            fechaHora = bancomerBE.ClsRequest.IFECHAHORACOMERCIO;
            dateTimeFormat(ref fechaHora);


            if (bancomerBE.ClsResponse != null)
            {
                if (bancomerBE.ClsResponse.ISECUENCIA != null)
                {
                    secuencia = bancomerBE.ClsResponse.ISECUENCIA;
                }


                if (bancomerBE.ClsResponse.IREFERENCIAFINAN != null)
                {
                    referenciaFin = bancomerBE.ClsResponse.IREFERENCIAFINAN;
                }

            }
        }

        public static string[][] CrearDefinicionTicket(ref string firmaAutografa,
                                                     ref string firmaElectronica,
                                                     ref string firmaQps,
                                                     ref string criptograma,
                                                     ref string pagadoConPuntos,
                                                     ref string pesosUsados,
                                                     ref string pesosAnteriores,
                                                     ref string pesosDisponibles,
                                                     ref string puntosUsados,
                                                     ref string puntosAnteriores,
                                                     ref string puntosDisponibles,
                                                     ref string tipoTransaccion,
                                                     ref string importe,
                                                     ref string numeroTarjetaEncriptado,
                                                     ref string fechaHora,
                                                     ref string comercio,
                                                     ref string calle,
                                                     ref string numero,
                                                     ref string colonia,
                                                     ref string caja,
                                                     ref string terminal,
                                                     ref string modoIngreso,
                                                     ref string referenciaFin,
                                                     ref string secuencia,
                                                     ref CBANCOMERPARAMBE bancomerBE,
                                                     bool bEsDeCliente,
                                                     bool bManejaPuntos,
                                                     ref string importePagadoConPuntos,
                                                     ref string importePorPagar)
        {


            List<string[]> lstImpresion = new List<string[]>();

            lstImpresion.AddRange(new string[][]
            {
                new string[]
                {
                    comercio, "Grande", "S", "S", 
                    "40", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    calle + " " + numero, "Chica", "S", "S", 
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    colonia, "Chica", "S", "S", 
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    "BBVA Bancomer", "Grande", "S", "S", 
                    "40", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    bancomerBE.ClsResponse.IAFILIACION, "Chica", "S", "S",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    "", "Chica", "S", "S",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    fechaHora, "Chica", "S", "S",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                
                new string[]
                {
                    "", "Chica", "S", "S",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    tipoTransaccion, "Chica", "S", "S",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    "Caja: ", "Chica", "N", "N",
                    "25", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    caja, "Chica", "S", "N",
                    "25", "N", " ", "N", "Derecha", ""
                },
                                new string[]
                {
                    "Terminal: ", "Chica", "N", "N",
                    "25", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    terminal, "Chica", "S", "N",
                    "25", "N", " ", "N", "Derecha", ""
                },

                
                
                

                new string[]
                {
                    "Tarjeta: ", "Chica", "N", "N",
                    "25", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    numeroTarjetaEncriptado, "Chica", "S", "N",
                    "25", "N", " ", "N", "Derecha", ""
                },
                new string[]
                {
                    "", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    "Importe M.N. : ", "Chica", "N", "N",
                    "25", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    importe, "Chica", "S", "N",
                    "25", "N", " ", "N", "Derecha", ""
                }
            });


            if (bManejaPuntos)
            {
                lstImpresion.AddRange(new string[][]
                {   
                new string[]
                {
                    "Pagado con puntos bancomer : ", "Chica", "N", "N",
                    "30", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    importePagadoConPuntos, "Chica", "S", "N",
                    "20", "N", " ", "N", "Derecha", ""
                },
                
                new string[]
                {
                    "Total a pagar: ", "Chica", "N", "N",
                    "25", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    importePorPagar, "Chica", "S", "N",
                    "25", "N", " ", "N", "Derecha", ""
                }
                });

            }

            string strAidLabel = "";
            if (modoIngreso != "D@1")
            {
                strAidLabel = "AID: ";
            }

            lstImpresion.AddRange(new string[][]
            {
                new string[]
                {
                    "", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },

                //Checar como quieren mostrar en esta parte los puntos redimidos ( ver correo)
                
                new string[]
                {
                    modoIngreso, "Grande", "S", "S",
                    "40", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    bancomerBE.ICREDITODEBITO, "Grande", "S", "S",
                    "40", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    "", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },

                new string[]
                {
                    criptograma, "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {

                    strAidLabel, "Chica", "N", "N",
                    "25", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    bancomerBE.IAID, "Chica", "S", "N",
                    "25", "N", " ", "N", "Derecha", ""
                },
                new string[]
                {
                    "Aprobación: ", "Chica", "N", "N",
                    "25", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    bancomerBE.ClsResponse.INOAUTORIZACION, "Chica", "S", "N",
                    "25", "N", " ", "N", "Derecha", ""
                },
                new string[]
                {
                    "No. de secuencia: ", "Chica", "N", "N",
                    "25", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    secuencia, "Chica", "S", "N",
                    "25", "N", " ", "N", "Derecha", ""
                },
                new string[]
                {
                    "Referencia: ", "Chica", "N", "N",
                    "25", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    referenciaFin, "Chica", "S", "N",
                    "25", "N", " ", "N", "Derecha", ""
                },
            });


            if (bEsDeCliente && bManejaPuntos)
            {

                lstImpresion.AddRange(new string[][]
               {
                
                new string[]
                {
                    "", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                
                new string[]
                {
                    "-------------------------------------------------", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    pagadoConPuntos, "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                
                new string[]
                {
                    "", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                
                new string[]
                {
                    puntosAnteriores, "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    pesosAnteriores, "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    puntosUsados, "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    pesosUsados, "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    puntosDisponibles, "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    pesosDisponibles, "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                
                new string[]
                {
                    "-------------------------------------------------", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                
                new string[]
                {
                    "", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                }
                
            });
            }
            else
            {
                lstImpresion.AddRange(new string[][]
               {
                
                new string[]
                {
                    "", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    "", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                }
               });
            }



            lstImpresion.AddRange(new string[][]
            {
                new string[]
                {
                    "", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    "", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    "Pagaré negociable únicamente ", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    "con instituciones de crédito", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                }
            });


            if (firmaAutografa != null && firmaAutografa.Length > 0)
            {

                lstImpresion.AddRange(new string[][]
                {
                    new string[]
                    {
                        "", "Chica", "S", "S",
                        "55", "N", " ", "N", "Izquierda", ""
                    },
                    new string[]
                    {
                        "", "Chica", "S", "S",
                        "55", "N", " ", "N", "Izquierda", ""
                    },
                    new string[]
                    {
                        "", "Chica", "S", "S",
                        "55", "N", " ", "N", "Izquierda", ""
                    },
                    new string[]
                    {
                        "", "Chica", "S", "S",
                        "55", "N", " ", "N", "Izquierda", ""
                    },
                    new string[]
                    {
                        "___________________________________", "Chica", "S", "S",
                        "55", "N", " ", "N", "Izquierda", ""
                    },
                    new string[]
                    {
                        firmaAutografa, "Chica", "S", "S",
                        "55", "N", " ", "N", "Izquierda", ""
                    },
                });
            }


            lstImpresion.AddRange(new string[][]
            {
                new string[]
                {
                    firmaElectronica, "Chica", "S", "S",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    firmaQps, "Chica", "S", "S",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    "Por este pagaré me obligo incondicionalmente a", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    "pagar a la orden del banco acreditante el importe", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    "de este título. Este pagaré procede del contrato", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    "de apertura de crédito que el banco acreditante ", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    "y el tarjetahabiente tienen celebrado", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    "", "Chica", "S", "S",
                    "55", "N", " ", "N", "Izquierda", ""
                }

            });



            if (bEsDeCliente)
            {
                lstImpresion.AddRange(new string[][]
                {
                    new string[]
                    {
                    "Copia Cliente ", "Chica", "N", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                    }
                });
            }
            else
            {

                lstImpresion.AddRange(new string[][]
                {
                    new string[]
                    {
                        "Copia Comercio", "Chica", "N", "N",
                        "55", "N", " ", "N", "Izquierda", ""
                    }
                });
            }



            string[][] defCadenasFactura = lstImpresion.ToArray();

            return defCadenasFactura;
        }


        public static void FijarDatosTicketPuntos(
                                             ref string comercio,
                                             ref string calle,
                                             ref string numero,
                                             ref string colonia,
                                             ref string tipoTransaccion,
                                             ref string caja,
                                             ref string terminal,
                                             ref string numeroTarjetaEncriptado,
                                             ref string fechaHora,
                                             ref string pesosDisponibles,
                                             ref string puntosDisponibles,
                                             ref CBANCOMERPARAMBE bancomerBE)
        {
            comercio = CurrentUserID.CurrentParameters.INOMBRE;
            calle = CurrentUserID.CurrentParameters.ICALLE;
            numero = CurrentUserID.CurrentParameters.INUMEROEXTERIOR;
            colonia = CurrentUserID.CurrentParameters.ICOLONIA;
            CCAJAD cajaDB = new CCAJAD();
            CCAJABE cajaBEB = new CCAJABE();
            cajaBEB.IID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
            cajaBEB = cajaDB.seleccionarCAJA(cajaBEB, null);
            caja = cajaBEB.INOMBRE;
            terminal = cajaBEB.INUMEROTERMINALBANCOMER.ToString();
            numeroTarjetaEncriptado = "xxxxxxxxxxxx" + bancomerBE.INUMEROTARJETA.Remove(0, 12);
            puntosDisponibles = "Saldo Disponible (Puntos):  " + formatoPtos(bancomerBE.Pts.IPUNTOSSALDODISPONIBLE);
            pesosDisponibles = "Saldo Disponible (Pesos):  $" + formatoPesos(bancomerBE.Pts.IPESOSSALDODISPONIBLE);
        }


        public static string[][] CrearDefinicionTicketConsultaPuntos(ref string firmaAutografa,
                                                     ref string firmaElectronica,
                                                     ref string firmaQps,
                                                     ref string criptograma,
                                                     ref string pagadoConPuntos,
                                                     ref string pesosUsados,
                                                     ref string pesosAnteriores,
                                                     ref string pesosDisponibles,
                                                     ref string puntosUsados,
                                                     ref string puntosAnteriores,
                                                     ref string puntosDisponibles,
                                                     ref string tipoTransaccion,
                                                     ref string importe,
                                                     ref string numeroTarjetaEncriptado,
                                                     ref string fechaHora,
                                                     ref string comercio,
                                                     ref string calle,
                                                     ref string numero,
                                                     ref string colonia,
                                                     ref string caja,
                                                     ref string terminal,
                                                     ref string modoIngreso,
                                                     ref string referenciaFin,
                                                     ref string secuencia,
                                                     ref CBANCOMERPARAMBE bancomerBE)
        {





            string[][] defCadenasFactura = new string[][]
            {
                new string[]
                {
                    comercio, "Grande", "S", "S", 
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    calle + " " + numero, "Chica", "S", "S", 
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    colonia, "Chica", "S", "S", 
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    "BBVA Bancomer", "Grande", "S", "S", 
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    bancomerBE.ClsResponse.IAFILIACION, "Chica", "S", "S",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    "", "Chica", "S", "S",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    fechaHora, "Chica", "S", "S",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                
                new string[]
                {
                    "", "Chica", "S", "S",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    tipoTransaccion, "Chica", "S", "S",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    "Caja: ", "Chica", "N", "N",
                    "25", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    caja, "Chica", "S", "N",
                    "25", "N", " ", "N", "Derecha", ""
                },
                                new string[]
                {
                    "Terminal: ", "Chica", "N", "N",
                    "25", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    terminal, "Chica", "S", "N",
                    "25", "N", " ", "N", "Derecha", ""
                },
                new string[]
                {
                    "Tarjeta: ", "Chica", "N", "N",
                    "25", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    numeroTarjetaEncriptado, "Chica", "S", "N",
                    "25", "N", " ", "N", "Derecha", ""
                },
                
                
                
                new string[]
                {
                    "", "Chica", "S", "S",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                
                new string[]
                {
                    "==================================================", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                
                new string[]
                {
                    "CONSULTA DE BENEFICIOS", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                
                new string[]
                {
                    "-----------------------------", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                
                new string[]
                {
                    "Puntos Bancomer", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                
                new string[]
                {
                    "", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
               
                new string[]
                {
                    puntosDisponibles, "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                new string[]
                {
                    pesosDisponibles, "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },
                
                
                new string[]
                {
                    "==================================================", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                },

               
                new string[]
                {
                    "GRACIAS", "Chica", "S", "N",
                    "55", "N", " ", "N", "Izquierda", ""
                }
                
            };

            return defCadenasFactura;
        }


        public static void ImprimirVoucher(long bancomerParamId, bool bImprimirCliente, bool bImprimirComercio)
        {
            bool impresionHecha = false;

            while (!impresionHecha)
            {
                if (bImprimirCliente)
                {
                    ImprimirVoucher(bancomerParamId, true);
                }
                if (bImprimirComercio)
                {
                    ImprimirVoucher(bancomerParamId, false);
                }

                if (MessageBox.Show("Se imprimieron correctamente los voucher?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    impresionHecha = true;
                }
            }
        }

        public static void ImprimirVoucher(long bancomerParamId, bool bEsDeCliente)
        {
            CBANCOMERPARAMD bancomerD = new CBANCOMERPARAMD();
            CBANCOMERPARAMBE bancomerBE = new CBANCOMERPARAMBE();
            bancomerBE.IID = bancomerParamId;
            bancomerBE = bancomerD.seleccionarBANCOMERPARAM_COMPUESTO(bancomerBE, null);

            bool bManejaPuntos = (bancomerBE.Pts != null && bancomerBE.Pts.IPUNTOSREDIMIDOS != null && bancomerBE.Pts.IPUNTOSREDIMIDOS != "0" && bancomerBE.Pts.IPUNTOSREDIMIDOS != "");

            string firmaAutografa = "",
                   firmaElectronica = "",
                   firmaQps = "",
                   criptograma = "",
                   pagadoConPuntos = "",
                   pesosUsados = "",
                   pesosAnteriores = "",
                   pesosDisponibles = "",
                   puntosUsados = "",
                   puntosAnteriores = "",
                   puntosDisponibles = "",
                   fechaHora = "",
                   tipoTransaccion = "",
                   importe = "",
                   numeroTarjetaEncriptado = "",
                   comercio = "",
                   calle = "",
                   numero = "",
                   colonia = "",
                   caja = "",
                   terminal = "",
                   modoIngreso = "";

            string referenciaFin = "";
            string secuencia = "";
            string importePagadoConPuntos = "";
            string importePorPagar = "";

            FijarDatosVariablesTicket(
                ref firmaAutografa,
                ref firmaElectronica,
                ref firmaQps,
                ref criptograma,
                ref pagadoConPuntos,
                ref pesosAnteriores,
                ref pesosUsados,
                ref pesosDisponibles,
                ref puntosAnteriores,
                ref puntosUsados,
                ref puntosDisponibles,
                ref tipoTransaccion,
                ref importe,
                ref numeroTarjetaEncriptado,
                ref fechaHora,
                ref comercio,
                ref calle,
                ref numero,
                ref colonia,
                ref caja,
                ref terminal,
                ref modoIngreso,
                ref referenciaFin,
                ref secuencia,
                ref importePagadoConPuntos,
                ref importePorPagar,
                ref bancomerBE,
                bManejaPuntos
                );


            string[][] defCadenasFactura;

            //Si  es consulta de puntos
            if (bancomerBE.ITIPOTRANSACCION == "016")
            {
                FijarDatosTicketPuntos(
                                        ref comercio,
                                        ref calle,
                                        ref numero,
                                        ref colonia,
                                        ref tipoTransaccion,
                                        ref caja,
                                        ref terminal,
                                        ref numeroTarjetaEncriptado,
                                        ref fechaHora,
                                        ref pesosDisponibles,
                                        ref puntosDisponibles,
                                        ref bancomerBE);

                defCadenasFactura = CrearDefinicionTicketConsultaPuntos(
                   ref firmaAutografa,
                   ref firmaElectronica,
                   ref firmaQps,
                   ref criptograma,
                   ref pagadoConPuntos,
                   ref pesosUsados,
                   ref pesosAnteriores,
                   ref pesosDisponibles,
                   ref puntosUsados,
                   ref puntosAnteriores,
                   ref puntosDisponibles,
                   ref tipoTransaccion,
                   ref importe,
                   ref numeroTarjetaEncriptado,
                   ref fechaHora,
                   ref comercio,
                   ref calle,
                   ref numero,
                   ref colonia,
                   ref caja,
                   ref terminal,
                   ref modoIngreso,
                   ref referenciaFin,
                   ref secuencia,
                   ref bancomerBE);
            }
            else
            {
                //venta o cancelacion
                defCadenasFactura = CrearDefinicionTicket(
                   ref firmaAutografa,
                   ref firmaElectronica,
                   ref firmaQps,
                   ref criptograma,
                   ref pagadoConPuntos,
                   ref pesosUsados,
                   ref pesosAnteriores,
                   ref pesosDisponibles,
                   ref puntosUsados,
                   ref puntosAnteriores,
                   ref puntosDisponibles,
                   ref tipoTransaccion,
                   ref importe,
                   ref numeroTarjetaEncriptado,
                   ref fechaHora,
                   ref comercio,
                   ref calle,
                   ref numero,
                   ref colonia,
                   ref caja,
                   ref terminal,
                   ref modoIngreso,
                   ref referenciaFin,
                   ref secuencia,
                   ref bancomerBE,
                   bEsDeCliente,
                   bManejaPuntos,
                   ref importePagadoConPuntos,
                   ref importePorPagar);
            }


            ImpresorTicketGenerico.imprimir(
                ImpresorTicketGenerico.obtenTextoTicketDesdeDefiniciones(defCadenasFactura));

        }

        public static string formatoPesos(string s)
        {

            if (s == null || s == "")
                return "";

            return (float.Parse(s) / 100).ToString("N2");
        }

        public static string formatoPtos(string s)
        {


            if (s == null || s == "")
                return "";


            return int.Parse(s).ToString("N0");
        }


        private static void rellenarCadenas(ref string s, int t, string position, char c)
        {
            rellenarCadenas(ref s, t, position, c, false);
        }

        private static void rellenarCadenas(ref string s, int t, string position, char c, bool ultimosCaracteresPrioridad)
        {
            if (s.Length > t)
            {
                if(ultimosCaracteresPrioridad)
                {

                    s = s.Substring(s.Length - t , t);
                }
                else
                {

                    s = s.Substring(0, t);
                }
            }
            else if (s.Length < t)
            {
                if (position == "left")
                {
                    s = s.PadLeft(t, c);
                }
                else if (position == "right")
                {
                    s = s.PadRight(t, c);
                }
            }
        }


        private static void dateTimeFormat(ref string s)
        {
            string date = s.Substring(4, 2) + "/" + s.Substring(2, 2) + "/" + s.Substring(0, 2);
            string time = s.Substring(6, 2) + ":" + s.Substring(8, 2);

            s = "Fecha: " + date + "              Hora: " + time;
        }


    }
}
