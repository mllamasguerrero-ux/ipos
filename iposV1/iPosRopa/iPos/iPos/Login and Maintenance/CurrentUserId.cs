using iPosBusinessEntity;
using System.Collections;
using System.Windows.Forms;
using iPosData;

using System.Collections.Generic;
using System.Data;
using System;


namespace iPos
{
    public class CurrentUserID
    {
        public static CPERSONABE CurrentUser
        {
            get
            {
                return ConexionesBD.ConexionBD.CurrentUser;
            }
            set
            {
                ConexionesBD.ConexionBD.CurrentUser = value;
            }
        }

        //private static CPARAMETROBE currentParameters;
        public static CPARAMETROBE CurrentParameters
        {
            get
            {
                //return currentParameters;
                return ConexionesBD.ConexionBD.CurrentParameters;
            }
            set
            {
                //currentParameters = value;
                ConexionesBD.ConexionBD.CurrentParameters = value;
            }
        }


        private static CCAJABE currentCaja;
        public static CCAJABE CurrentCaja
        {
            get
            {
                return currentCaja;
            }
            set
            {
                currentCaja = value;
            }
        }

        


        private static CVERIFONECAJACONFIGBE currentVerifoneCajaConfig;
        public static CVERIFONECAJACONFIGBE CurrentVerifoneCajaConfig
        {
            get
            {
                return currentVerifoneCajaConfig;
            }
            set
            {
                currentVerifoneCajaConfig = value;
            }
        }



        public static string SUCURSAL_CLAVE;


        public static bool ES_SUPERVISOR = false;
        public static bool ES_ADMINISTRADOR = false;

        public static string DBLocation = "";

        public static object thisLock = new object();

        public static object thisLockImportaciones = new object();


        public static object thisLockFacturacionMovil = new object();

        public static System.Drawing.Size mainWinSize = new System.Drawing.Size(1, 1);

        public static bool HABILITARVENDEDOR_MOVIL = true;


        public static string currentPrinter = "";


        private static string currentPrinterRecargas;
        public static string CurrentPrinterRecargas
        {
            get
            {
                return ConexionesBD.ConexionBD.CurrentPrinterRecargas;
            }
            set
            {
                ConexionesBD.ConexionBD.CurrentPrinterRecargas = value;
            }
        }




        private static CEMPRESASBE currentCompania;
        public static CEMPRESASBE CurrentCompania
        {
            get
            {
                return currentCompania;
            }
            set
            {
                currentCompania = value;
            }
        }


        private static int rechazoRetiroCajaCuenta = 0;
        public static int RechazoRetiroCajaCuenta
        {
            get
            {
                return rechazoRetiroCajaCuenta;
            }
            set
            {
                rechazoRetiroCajaCuenta = value;
            }
        }




        public static Hashtable listados = new Hashtable();


        public static AutoCompleteStringCollection listadoAutoCompleteProd = null;
        public static AutoCompleteStringCollection listadoAutoCompleteProdConExis = null;
        public static DateTime fechaLastLlenadoAutocomplete = DateTime.MinValue;
        public static DateTime fechaLastLlenadoAutocompleteConExis = DateTime.MinValue;
        public static bool forceRefillAutoCompleteProd = false;
        public static bool forceRefillAutoCompleteProdConExis = false;

        public static bool UpdataAutoCompleteExistenceSingleProduct(string clave, string existencia)
        {
            if (listadoAutoCompleteProd != null)
            {
                string strKey = " <((" + clave.Trim() + "))>" + " ";
                int i = 0, iExiste = -1;
                bool bExiste = false;
                string newStr = "";

                foreach (string str in listadoAutoCompleteProd)
                {
                    if (str.Contains(strKey))
                    {
                        string[] strSeparators = new string[] { strKey };

                        string[] strPlit = str.Split(strSeparators, System.StringSplitOptions.None);

                        if (strPlit.Length > 0)
                            newStr += strPlit[0];

                        newStr += strKey;

                        newStr += existencia;
                        bExiste = true;
                        iExiste = i;

                        break;
                    }
                    i++;
                }

                if (bExiste)
                {
                    listadoAutoCompleteProd.RemoveAt(iExiste);
                    listadoAutoCompleteProd.Insert(iExiste, newStr);
                }
            }
            return true;
        }

        public static AutoCompleteStringCollection GetAutoSourceProductoConExis(bool forceUpdate)
        {
            forceRefillAutoCompleteProdConExis = true;

            return GetAutoSourceProductoConExis();

        }

        public static AutoCompleteStringCollection GetAutoSourceProductoConExis()
        {
            CPARAMETROD paramD = new CPARAMETROD();
            //Aqui se ve si hay cambios en la descripcion de productos..se mantiene igual
            System.DateTime LASTCHANGEPRODDESC = paramD.seleccionarLASTCHANGEPRODDESC(null);


            if (CurrentParameters != null)
            {
                if (CurrentParameters.IAUTOCOMPPROD.Equals("N"))
                    return null;
            }
            else
            {
                return null;
            }

            if (!forceRefillAutoCompleteProdConExis && listadoAutoCompleteProdConExis != null &&
                fechaLastLlenadoAutocompleteConExis >= LASTCHANGEPRODDESC)

                return listadoAutoCompleteProdConExis;

            forceRefillAutoCompleteProdConExis = false;

            CPRODUCTOD prodD = new CPRODUCTOD();

            bool bMovil = CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S");

            DataTable table = prodD.getProductoNombresConExis(bMovil);

            AutoCompleteStringCollection autoSourceCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in table.Rows)
            {

                // row[3].ToString().Trim()seria la existencia

                autoSourceCollection.Add(row[0].ToString().Trim() + " Exist: " + row[3].ToString().Trim() + " " + " <((" + row[1].ToString().Trim() + "))>" + " " + row[2].ToString()); //assuming required data is in first column

            }

            listadoAutoCompleteProdConExis = autoSourceCollection;

            fechaLastLlenadoAutocompleteConExis = System.DateTime.Now;

            return listadoAutoCompleteProdConExis;

        }

        public static AutoCompleteStringCollection GetAutoSourceCollectionFromTable(bool forceUpdate)
        {
            forceRefillAutoCompleteProd = true;
            return GetAutoSourceCollectionFromTable();
        }

        public static AutoCompleteStringCollection GetAutoSourceCollectionFromTable()
        {

            CPARAMETROD paramD = new CPARAMETROD();
            System.DateTime LASTCHANGEPRODDESC = paramD.seleccionarLASTCHANGEPRODDESC(null);


            if (CurrentParameters != null)
            {
                if (CurrentParameters.IAUTOCOMPPROD.Equals("N"))
                    return null;
            }
            else
            {
                return null;
            }

            if (!forceRefillAutoCompleteProd && listadoAutoCompleteProd != null && fechaLastLlenadoAutocomplete >= LASTCHANGEPRODDESC)
                return listadoAutoCompleteProd;

            forceRefillAutoCompleteProd = false;

            CPRODUCTOD prodD = new CPRODUCTOD();

            bool bMovil = CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S");

            DataTable table = prodD.getProductoNombres(bMovil);

            AutoCompleteStringCollection autoSourceCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in table.Rows)
            {

                autoSourceCollection.Add(row[0].ToString().Trim() + " <((" + row[1].ToString().Trim() + "))>" + " " + row[2].ToString()); //assuming required data is in first column

            }

            listadoAutoCompleteProd = autoSourceCollection;

            fechaLastLlenadoAutocomplete = System.DateTime.Now;

            return listadoAutoCompleteProd;

        }


        public static List<string> listAutoCompleteProd = null;
        public static List<string> GetListProdAutoSourceFromTable()
        {

            CPARAMETROD paramD = new CPARAMETROD();
            System.DateTime LASTCHANGEPRODDESC = paramD.seleccionarLASTCHANGEPRODDESC(null);


            if (CurrentParameters != null)
            {
                if (CurrentParameters.IAUTOCOMPPROD.Equals("N"))
                    return null;
            }
            else
            {
                return null;
            }

            if (listAutoCompleteProd != null && fechaLastLlenadoAutocomplete >= LASTCHANGEPRODDESC)
                return listAutoCompleteProd;



            CPRODUCTOD prodD = new CPRODUCTOD();
            bool bMovil = CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S");

            DataTable table = prodD.getProductoNombres(bMovil);
            listAutoCompleteProd = new List<string>();

            AutoCompleteStringCollection autoSourceCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in table.Rows)
            {

                listAutoCompleteProd.Add(row[0].ToString().Trim() + " <((" + row[1].ToString().Trim() + "))>" + " " + row[2].ToString()); //assuming required data is in first column

            }


            fechaLastLlenadoAutocomplete = System.DateTime.Now;

            return listAutoCompleteProd;

        }


        public static AutoCompleteStringCollection listadoAutoCompleteCliente = null;
        public static System.DateTime fechaLastLlenadoAutocompleteCliente = System.DateTime.MinValue;

        public static AutoCompleteStringCollection GetAutoSourceCollectionFromTableCliente()
        {

            CPARAMETROD paramD = new CPARAMETROD();
            System.DateTime LASTCHANGECLIENTENOMBRE = paramD.seleccionarLASTCHANGECLIENTENOMBRE(null);


            if (CurrentParameters != null)
            {
                if (CurrentParameters.IAUTOCOMPCLIENTE.Equals("N"))
                    return null;
            }
            else
            {
                return null;
            }

            if (listadoAutoCompleteCliente != null && fechaLastLlenadoAutocompleteCliente >= LASTCHANGECLIENTENOMBRE)
                return listadoAutoCompleteCliente;

            CCLIENTED clienteD = new CCLIENTED();

            DataTable table = clienteD.getClientesNombres();

            AutoCompleteStringCollection autoSourceCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in table.Rows)
            {

                autoSourceCollection.Add(row[0].ToString().Trim() + " <((" + row[1].ToString().Trim() + "))>"); //assuming required data is in first column

            }

            listadoAutoCompleteCliente = autoSourceCollection;

            fechaLastLlenadoAutocompleteCliente = System.DateTime.Now;

            return listadoAutoCompleteCliente;

        }





        public static AutoCompleteStringCollection listadoAutoCompleteProveedor = null;
        public static System.DateTime fechaLastLlenadoAutocompleteProveedor = System.DateTime.MinValue;

        public static AutoCompleteStringCollection GetAutoSourceCollectionFromTableProveedor()
        {

            CPARAMETROD paramD = new CPARAMETROD();
            System.DateTime LASTCHANGEPROVEEDORNOMBRE = paramD.seleccionarLASTCHANGECLIENTENOMBRE(null);


            if (CurrentParameters != null)
            {
                if (CurrentParameters.IAUTOCOMPCLIENTE.Equals("N"))
                    return null;
            }
            else
            {
                return null;
            }

            if (listadoAutoCompleteProveedor != null && fechaLastLlenadoAutocompleteProveedor >= LASTCHANGEPROVEEDORNOMBRE)
                return listadoAutoCompleteProveedor;

            CPROVEEDORD proveedorD = new CPROVEEDORD();

            DataTable table = proveedorD.getProveedoresNombres();

            AutoCompleteStringCollection autoSourceCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in table.Rows)
            {

                autoSourceCollection.Add(row[0].ToString().Trim() + " <((" + row[1].ToString().Trim() + "))>"); //assuming required data is in first column

            }

            listadoAutoCompleteProveedor = autoSourceCollection;

            fechaLastLlenadoAutocompleteProveedor = System.DateTime.Now;

            return listadoAutoCompleteProveedor;

        }


        


        public static int BinarySearchForMatch(AutoCompleteStringCollection list,
    System.Func<string, int> comparer)
        {
            int min = 0;
            int max = list.Count - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;
                int comparison = comparer(list[mid]);
                if (comparison == 0)
                {
                    return mid;
                }
                if (comparison < 0)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
            }
            return ~min;
        }


        public static bool EsMatrizPrincipal()
        {
            bool bEsMatrizPrincipal = false;
            if (CurrentUserID.CurrentCompania.IESMATRIZ == "S")
            {
                CSUCURSALD sucursalD = new CSUCURSALD();
                CSUCURSALBE sucursalBE = new CSUCURSALBE();
                sucursalBE.IID = CurrentUserID.CurrentParameters.ISUCURSALID;
                sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);

                if (sucursalBE != null)
                {
                    if (!((bool)sucursalBE.isnull["ISURTIDOR"] || sucursalBE.ISURTIDOR == null || sucursalBE.ISURTIDOR.Trim().Length == 0 || sucursalBE.IESMATRIZ == null || !sucursalBE.IESMATRIZ.Equals("S")))
                    {
                        bEsMatrizPrincipal = false;
                    }
                    else
                    {

                        bEsMatrizPrincipal = true;
                    }
                }
                
            }

            return bEsMatrizPrincipal;
        }

    }
}