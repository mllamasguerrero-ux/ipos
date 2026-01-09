using System;
using System.Collections.Generic;
using System.Text;
namespace ConexionesBD
{
    public class ConexionMEBD
    {
        public static string ConexionBase;
        public static string ConexionString()
        {
            if (ConexionBase == null)
            {
                string dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                return "data source=localhost;initial catalog=\"" + dataPath + "\\SystemData\\systemdata" + "\";user id=sysdba;password=masterkey";
                //return "data source=localhost;initial catalog=\"C:\\Documents and Settings\\manuel\\Mis documentos\\Visual Studio 2008\\Projects\\ipos\\iPos\\bin\\Debug\\SystemData\\systemdata\";user id=sysdba;password=masterkey";
            }
            else
                return ConexionBase;
        }
    }
}
