using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Caliburn.Micro;

namespace IposV3Sync.Views
{
    public class ConnectionMgr
    {




        public static void ChangeConnectionString(string? strConn)
        {

            if (strConn == null || strConn.Length == 0)
                return;

            ApplicationDbContext context = IoC.Get<ApplicationDbContext>();
            OperationsContextFactory operationsContextFactory = IoC.Get<OperationsContextFactory>();

            System.Configuration.Configuration _config =
             ConfigurationManager.OpenExeConfiguration(
             ConfigurationUserLevel.None);
            _config.ConnectionStrings.ConnectionStrings["WpfIpos.Properties.Settings.ConnectionIpos"].ConnectionString = strConn;
            _config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(_config.ConnectionStrings.SectionInformation.Name);

            context.ConnectionString = strConn;
            //context.Database.GetDbConnection().ConnectionString = strConn;
            //context.Database.CloseConnection();
            context.Database.CloseConnection();
            context.Database.SetConnectionString(strConn);

            operationsContextFactory.ConnectionString = strConn;

            //IposV3.Properties.Settings.Default.Reload();

        }

        public static string? GetConnectionString()
        {
            System.Configuration.Configuration _config =
             ConfigurationManager.OpenExeConfiguration(
             ConfigurationUserLevel.None);
            return _config.ConnectionStrings.ConnectionStrings["WpfIpos.Properties.Settings.ConnectionIpos"]?.ConnectionString;
        }

    }
}
