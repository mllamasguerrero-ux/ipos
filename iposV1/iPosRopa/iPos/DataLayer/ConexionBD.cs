using System;
using System.Collections.Generic;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using iPosBusinessEntity;
using iPosData;

namespace ConexionesBD
{
    public class ConexionBD
    {
        public static string ConexionBase;
        public static string ConexionString()
        {
            if (ConexionBase == null)
            {

                //string pooling = "Pooling=true;MinPoolSize=5;MaxPoolSize=50;";
                string pooling = "";
                return "data source=localhost;initial catalog=\"C:\\Documents and Settings\\manuel\\Mis documentos\\iposdb\\iposdb\";user id=sysdba;password=masterkey;" + pooling;
            }
            else
                return ConexionBase;
        }


        public static string ConexionBasePoolingForced;
        public static string ConexionStringPoolingForced()
        {
            if (ConexionBasePoolingForced == null)
            {

                if (ConexionBase != null)
                {
                    ConexionBasePoolingForced = ConexionBase.Replace(";Pooling=false;", "");
                    return ConexionBasePoolingForced;
                }
                else
                {
                    return null;
                }


            }
            else
                return ConexionBasePoolingForced;
        }



        public static string ConexionBaseSinPooling;
        public static string ConexionStringSinPooling()
        {
            if (ConexionBaseSinPooling == null)
            {

                if (ConexionBase != null)
                {
                    ConexionBaseSinPooling = ConexionBase.Replace(";Pooling=false;", "");
                    ConexionBaseSinPooling += ";Pooling=false;";
                    return ConexionBaseSinPooling;
                }
                else
                {
                    return null;
                }


            }
            else
                return ConexionBaseSinPooling;
        }


        private static CEMPRESASBE currentCompania = null;
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



        private static CPARAMETROBE currentParameters;
        public static CPARAMETROBE CurrentParameters
        {
            get
            {
                return currentParameters;
            }
            set
            {
                currentParameters = value;
            }
        }

        private static CPERSONABE currentUser;
        public static CPERSONABE CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
            }
        }



        private static string currentPrinterRecargas;
        public static string CurrentPrinterRecargas
        {
            get
            {
                return currentPrinterRecargas;
            }
            set
            {
                currentPrinterRecargas = value;
            }
        }

        public static string currentPrinter = "";

        /* public static string ConexionStringSinPooling()
         {
             string pooling = "Pooling=false;";
             return ConexionString() + pooling;
         }*/


        private static bool? tieneDerechoAVerSumasGrid = false;
        public static bool TieneDerechoAVerSumasGrid
        {
            get
            {
                if(tieneDerechoAVerSumasGrid.HasValue)
                {
                    if(ConexionBase == null || currentUser == null)
                    {
                        return false;
                    }

                    CUSUARIOSD usuariosD = new CUSUARIOSD();
                    if (usuariosD.UsuarioTienePermisos((int)currentUser.IID, (int)DBValues._DERECHO_TOTALES_GRID, null))
                    {
                        tieneDerechoAVerSumasGrid = true;
                    }
                    else
                    {
                        tieneDerechoAVerSumasGrid = false;
                    }
                }


                return tieneDerechoAVerSumasGrid.Value;
            }
            set
            {
                tieneDerechoAVerSumasGrid = value;
            }
        }




    }
}
