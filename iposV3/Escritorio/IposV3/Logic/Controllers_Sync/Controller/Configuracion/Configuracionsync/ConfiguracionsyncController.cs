
using BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers;
using Npgsql;
using DataAccess;
using IposV3.Model;
using IposV3.Model.Syncr;
using BIPOS.Database.DAO;

namespace Controllers.Controller
{

    public class ConfiguracionsyncController : ConfiguracionsyncControllerGenerated,IConfiguracionsyncControllerProvider 
    {
        private OperationsContextFactory _operationsContextFactory;


        public ConfiguracionsyncController(IConfiguracionsyncDaoProvider dao, OperationsContextFactory operationsContextFactory) : base(dao)
        {
            this._operationsContextFactory = operationsContextFactory;
        }


        public IposV3.Model.Syncr.Configuracionsync? GetDefaultConfiguracion()
        {
            return dao.Select(null, "").FirstOrDefault();
        }

        public void Test()
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            var test = applicationDbContext.Empresa.Count();
            test = test + 1;
        }


    }
}

