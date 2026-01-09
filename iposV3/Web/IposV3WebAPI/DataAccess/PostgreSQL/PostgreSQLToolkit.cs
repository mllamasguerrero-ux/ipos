using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace DatabaseToolkit
{

    public class DBToolkitApplicationOptions
    {

        public string PostgreSQLHost { get; set; }

        public string PostgreSQLPort { get; set; }

        public string PostgreSQLUser { get; set; }

        public string PostgreSQLPass { get; set; }

    }

    public static class PostgreSQLToolkit 
    {

        /// <summary>
        /// Restore a PostgreSQL database using pg_restore. Make sure the following appsettings.json properties
        /// <see cref="ApplicationOptions.PostgreSQLHost"/>, <see cref="ApplicationOptions.PostgreSQLPort"/>,
        /// and <see cref="ApplicationOptions.PostgreSQLUser"/> are set and match exactly what's in your pgpass.conf file (Windows).
        /// </summary>
        /// <param name="databaseName">The name of the database on the Postgres server we're restoring.</param>
        /// <param name="localDatabasePath">The local file path to the .sql database file where we're restoring from.</param>
        public static void RestoreDatabase(string databaseName, string localDatabasePath, string rutaInstalacionPostgresql, DBToolkitApplicationOptions dbInfo)
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = "./SeedData/postgresql-restore.bat"; // Path.Combine("PostgreSQL", "./SeedData/postgresql-restore.bat");
            var host = dbInfo.PostgreSQLHost;
            var port = dbInfo.PostgreSQLPort;
            var user = dbInfo.PostgreSQLUser;
            var pass = dbInfo.PostgreSQLPass;
            var database = databaseName;
            var outputPath = localDatabasePath;

            // use pg_restore, specifying the host, port, user, database to restore, and the output path.
            // the host, port, user, and database must be an exact match with what's inside your pgpass.conf (Windows)
            startInfo.Arguments = $@"{host} {port} {user} {database} ""{outputPath}"" {pass} ""{rutaInstalacionPostgresql}""";

            //string test = $@"pg_restore --no-owner --dbname=postgresql://{user}:{pass}@{host}:{port}/{database} ""{outputPath}""";

            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            process.Close();
        }
    }
}
