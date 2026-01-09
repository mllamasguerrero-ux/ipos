using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Windows;
using IposV3.BindingModel;
using IposV3.ViewModels;
using Controllers.Controller;
//using IposV3.Controllers.Controller;

namespace IposV3.Views
{
    public class ConnectionMgr
    {

        //public static void ChangeConnectionString(string? strConn, bool closeConnection = true)
        //{

        //    if (strConn == null || strConn.Length == 0)
        //        return;

        //    ApplicationDbContext context = IoC.Get<ApplicationDbContext>();
        //    OperationsContextFactory operationsContextFactory = IoC.Get<OperationsContextFactory>();

        //    System.Configuration.Configuration _config =
        //     ConfigurationManager.OpenExeConfiguration(
        //     ConfigurationUserLevel.None);
        //    _config.ConnectionStrings.ConnectionStrings["WpfIpos.Properties.Settings.ConnectionIpos"].ConnectionString = strConn;
        //    _config.Save(ConfigurationSaveMode.Modified);
        //    ConfigurationManager.RefreshSection(_config.ConnectionStrings.SectionInformation.Name);


        //    context.ConnectionString = strConn;
        //    //context.Database.GetDbConnection().ConnectionString = strConn;
        //    //context.Database.CloseConnection();
        //    if(closeConnection)
        //        context.Database.CloseConnection();
        //    //MessageBox.Show("Paso 306");
        //    //context.Database.SetConnectionString(strConn);
        //    //MessageBox.Show("Paso 307");

        //    operationsContextFactory.ConnectionString = strConn;


        //    //IposV3.Properties.Settings.Default.Reload();

        //}

        //public static string? GetConnectionString()
        //{
        //    System.Configuration.Configuration _config =
        //     ConfigurationManager.OpenExeConfiguration(
        //     ConfigurationUserLevel.None);
        //    return _config.ConnectionStrings.ConnectionStrings["WpfIpos.Properties.Settings.ConnectionIpos"]?.ConnectionString;
        //}



        public static void llenarSessionYCambiaConexion(Configuracion? config)
        {

            if (config != null)
            {
                var globalControllerProvider = IoC.Get<GlobalWebController>();
                GlobalSession bufferSession = new GlobalSession();
                globalControllerProvider?.llenarSesionPorConfiguracion(config, ref bufferSession); //operationsContextFactory, 
                GlobalVariable.CurrentSession = bufferSession;
            }
            else
            {
                GlobalVariable.CurrentSession = new GlobalSession();
            }

            //if (config != null)
            //{

            //    var globalControllerProvider  = IoC.Get<GlobalWebController>();
            //    //var operationsContextFactory = IoC.Get<OperationsContextFactory>();

            //    GlobalSession bufferSession = new GlobalSession();

            //    string connectionStr = "Server=" + config!.Servidor + ";Port=" + config.Puerto + ";Database=" + config.Database + ";Uid=" + config.Usuario + ";Pwd=" + config.Password + ";Include Error Detail=true;";
            //    IposV3.Views.ConnectionMgr.ChangeConnectionString(connectionStr, false);
            //    MigrateDataBase(config);

            //    globalControllerProvider?.llenarSesionPorConfiguracion(config, ref bufferSession); //operationsContextFactory, 
            //    GlobalVariable.CurrentSession = bufferSession;

            //}
            //else
            //{

            //    GlobalVariable.CurrentSession = new GlobalSession();
            //}
        }



        //public static void MigrateDataBase(Configuracion? config)
        //{
        //    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        //    var _context = IoC.Get<ApplicationDbContext>();
        //    var _contextFactory = IoC.Get<OperationsContextFactory>();

        //    var configuracionProvider = IoC.Get<ConfiguracionWebController>();
        //    //Configuracion? defaultConfig = configuracionProvider?.GetDefaultConfiguracion();
        //    if (config != null)
        //    {
        //        _context.Database.CloseConnection();
        //        _context.ConnectionString = "Server=" + config.Servidor + ";Port=" + config.Puerto + ";Database=" + config.Database + ";Uid=" + config.Usuario + ";Pwd=" + config.Password + ";";
        //        _context.Database.SetConnectionString(_context.ConnectionString);

        //        _contextFactory.ConnectionString = "Server=" + config.Servidor + ";Port=" + config.Puerto + ";Database=" + config.Database + ";Uid=" + config.Usuario + ";Pwd=" + config.Password + ";";

        //    }

        //    try
        //    {

        //        var migrationsJustApplied = _context.Database.GetPendingMigrations().ToList();
        //        _context.Database.Migrate();


        //        IposV3.Migrations.Seed.MigrationService.RunSpecialMigrationProcesses(_context, migrationsJustApplied);
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.Message.ToString());
        //        throw;
        //    }


        //}

    }
}
