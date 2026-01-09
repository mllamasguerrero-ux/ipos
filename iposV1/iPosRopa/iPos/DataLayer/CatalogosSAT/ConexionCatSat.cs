using System;
using System.Collections.Generic;
using System.Text;
namespace ConexionesBD
{
    public class ConexionCatSat
    {
        private static string ConexionBase;
        public static string ConexionString()
        {
            if (ConexionBase == null)
            {
                string dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                return "data source=localhost;initial catalog=\"" + dataPath + "\\sat\\CATALOGOS.fdb" + "\";user id=sysdba;password=masterkey";
            }
            else
                return ConexionBase;
        }


        private static string ConexionBase_2022;
        public static string Conexion_2022_String()
        {
            if (ConexionBase_2022 == null)
            {
                string dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                return "data source=localhost;initial catalog=\"" + dataPath + "\\sat\\CATALOGOS_2022.fdb" + "\";user id=sysdba;password=masterkey";
            }
            else
                return ConexionBase;
        }

    }
}

