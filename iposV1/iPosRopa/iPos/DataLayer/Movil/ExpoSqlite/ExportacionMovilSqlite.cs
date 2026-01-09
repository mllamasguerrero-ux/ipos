using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLayer.Movil.ExpoSqlite
{
    public class ExportacionMovilSqlite
    {

        public static void CreateMovilDB(string ruta, string databasename)
        {
            DeleteMovilDB(ruta, databasename);

            SQLiteConnection.CreateFile(ruta + "/" +  databasename);

            GC.Collect();
        }

        public static void DeleteMovilDB(string ruta, string databasename)
        {
            FreeAllConnections();

            if (File.Exists(ruta + "/" + databasename))
                File.Delete(ruta + "/" + databasename);
            
        }

        public static void FreeAllConnections()
        {

            if (SQLiteConnection.ConnectionPool != null)
                SQLiteConnection.ConnectionPool.ClearAllPools();

            SQLiteConnection.ClearAllPools();
            GC.Collect();
        }

    }
}
