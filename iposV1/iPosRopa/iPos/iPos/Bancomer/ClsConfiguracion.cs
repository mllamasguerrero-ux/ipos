using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;

namespace iPos
{
    public class ClsConfiguracion
    {
        static String Puerto = "";
        static String TimeOutPinpad = "";
        static String pinpadId = "";
        static String afiliacion = "";
        static String terminal = "";
        static String IPHost = "";
        static int HeadConsec;
        static int SocketHost;
        static int TimeOutHost;
        static String NombreComercio = "";
        static String Folio = "";
        static String Log = "";
        private static String strDirUsuDB;
        static String Idbinescomercio = String.Empty;
        static String SA;
        static String Clave = String.Empty;
        static String ImpresionDirecta = "";
        private static String strDirActVersion;
        static String cash = String.Empty;
        static int cargallave;
        static int strActualiza;
        static int Conamex;

        public static int HeaderConsecutivo
        {
            get { return HeadConsec; }
            set { HeadConsec = value; }
        }
        public static String Comercio
        {
            get { return NombreComercio; }
        }
        public static String IpHost
        {
            get { return IPHost; }
        }
        public static int HostTimeOut
        {
            get { return TimeOutHost; }
        }
        public static int PuertoHost
        {
            get { return SocketHost; }
        }
        public static String PuertoSerie
        {
            get { return Puerto; }
        }
        public static String PinPadID
        {
            get { return pinpadId; }
        }
        public static String PinpadTimeOut
        {
            get
            {
                if (TimeOutPinpad == "")
                {
                    return TimeOutPinpad = "0";
                }
                else
                {
                    return TimeOutPinpad;
                }
            }
        }
        public static String Afiliacion
        {
            get { return afiliacion; }
        }
        public static String Terminal
        {
            get { return terminal; }
        }
        public static String IsFolio
        {
            get { return Folio; }
        }
        public static String IsLog
        {
            get { return Log; }
        }
        public static String DirUserDB
        {
            get { return strDirUsuDB; }
            set { strDirUsuDB = value; }
        }
        public static String IDBinesComercio
        {
            get { return Idbinescomercio; }
        }
        public static int CargaLlave
        {
            get { return cargallave; }

        }
        public static String SAO
        {
            get { return SA; }
        }
        //SOLO SI ES POR INTERNET
        public static String Password
        {
            get { return Clave; }
        }
        public static String Impresion
        {
            get { return ImpresionDirecta; }
        }
        public static String DIRACTVersion
        {
            get { return strDirActVersion; }
            set { strDirActVersion = value; }
        }
        public static String Cash
        {
            get { return cash; }
            set { cash = value; }
        }

        public static int BACTVersion
        {
            get { return strActualiza; }
            set { strActualiza = value; }
        }
        public static int ConAMEX
        {
            get { return Conamex; }
            set { Conamex = value; }
        }

        public static void LeeDatosFromTXT()
        {
            String strCadena = "";

            try
            {
                // Open the file and read it back.
                using (System.IO.StreamReader sr = System.IO.File.OpenText(Application.StartupPath + "/PinpadConfig.txt"))
                {
                    //SOLO LEE LA PRIMERA LINEA DEL ARCHIVO DONDE ESTA EL NOMBRE DEL COMERCIO
                    while ((strCadena = sr.ReadLine()) != null)
                    {

                        strCadena = strCadena.ToUpper();

                        if (strCadena.IndexOf("PINPADTIMEOUT") != -1)
                        {
                            TimeOutPinpad = strCadena.Substring(strCadena.LastIndexOf(":") + 1);
                            continue;
                        }
                        if (strCadena.IndexOf("NOMBREPUERTO") != -1)
                        {
                            Puerto = strCadena.Substring(strCadena.LastIndexOf(":") + 1);
                            continue;
                        }
                        if (strCadena.IndexOf("TIMEOUTHOST") != -1)
                        {
                            TimeOutHost = int.Parse(strCadena.Substring(strCadena.LastIndexOf(":") + 1));
                            continue;
                        }
                        if (strCadena.IndexOf("SOCKETHOST") != -1)
                        {
                            SocketHost = int.Parse(strCadena.Substring(strCadena.LastIndexOf(":") + 1));
                            continue;
                        }
                        if (strCadena.IndexOf("IPHOST") != -1)
                        {
                            IPHost = strCadena.Substring(strCadena.LastIndexOf(":") + 1);
                            continue;
                        }
                        if (strCadena.IndexOf("PINPADID") != -1)
                        {
                            pinpadId = strCadena.Substring(strCadena.LastIndexOf(":") + 1);
                            continue;
                        }
                        if (strCadena.IndexOf("AFILIACION") != -1)
                        {
                            afiliacion = strCadena.Substring(strCadena.LastIndexOf(":") + 1);
                            continue;
                        }
                        if (strCadena.IndexOf("TERMINAL") != -1)
                        {
                            terminal = strCadena.Substring(strCadena.LastIndexOf(":") + 1);
                            continue;
                        }
                        if (strCadena.IndexOf("HEADERCONSECUTIVO") != -1)
                        {
                            HeaderConsecutivo = int.Parse(strCadena.Substring(strCadena.LastIndexOf(":") + 1));
                            continue;
                        }
                        if (strCadena.IndexOf("NOMBRECOMERCIO") != -1)
                        {
                            NombreComercio = strCadena.Substring(strCadena.LastIndexOf(":") + 1).ToUpper();
                            continue;
                        }
                        if (strCadena.IndexOf("FOLIO") != -1)
                        {
                            Folio = strCadena.Substring(strCadena.LastIndexOf(":") + 1).ToUpper();
                            continue;
                        }
                        if (strCadena.IndexOf("LOG") != -1)
                        {
                            Log = strCadena.Substring(strCadena.LastIndexOf(":") + 1).ToUpper();
                            continue;
                        }
                        if (strCadena.IndexOf("DIRUSERDB") != -1)
                        {
                            DirUserDB = strCadena.Substring(strCadena.IndexOf(":") + 1).ToUpper();
                            continue;
                        }
                        if (strCadena.IndexOf("BINESCOMERCIO") != -1)
                        {
                            Idbinescomercio = strCadena.Substring(strCadena.LastIndexOf(":") + 1).ToUpper();
                            continue;
                        }
                        if (strCadena.IndexOf("SESIONABRIR") != -1)
                        {
                            SA = strCadena.Substring(strCadena.LastIndexOf(":") + 1).ToUpper();
                            continue;
                        }
                        if (strCadena.IndexOf("CARGALLAVE") != -1)
                        {
                            cargallave = int.Parse(strCadena.Substring(strCadena.LastIndexOf(":") + 1));
                        }
                        if (strCadena.IndexOf("VERSION") != -1) //Solo si la DLL es por INTERNET
                        {
                            Clave = strCadena.Substring(strCadena.LastIndexOf(":") + 1).ToLower();
                            continue;
                        }
                        if (strCadena.IndexOf("IMPRESIOND") != -1)
                        {
                            ImpresionDirecta = strCadena.Substring(strCadena.LastIndexOf(":") + 1);
                            continue;
                        }
                        if (strCadena.IndexOf("ACTUALIZACION") != -1)
                        {
                            BACTVersion = Convert.ToInt32(strCadena.Substring(strCadena.IndexOf(":") + 1).ToUpper());
                            continue;
                        }
                        if (strCadena.IndexOf("DIRACTPINPAD") != -1)
                        {
                            DIRACTVersion = strCadena.Substring(strCadena.IndexOf(":") + 1).ToUpper();
                            continue;
                        }
                        if (strCadena.IndexOf("CONAUX") != -1)
                        {
                            Conamex = int.Parse(strCadena.Substring(strCadena.LastIndexOf(":") + 1));
                            continue;
                        }
                        if (strCadena.IndexOf("CASH") != -1)
                        {
                            Cash = strCadena.Substring(strCadena.LastIndexOf(":") + 1).ToUpper();
                            continue;
                        }
                    }
                    sr.Close();

                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al Leer la configuracion\n" + Ex.Message);
            }

        }


    }
}
