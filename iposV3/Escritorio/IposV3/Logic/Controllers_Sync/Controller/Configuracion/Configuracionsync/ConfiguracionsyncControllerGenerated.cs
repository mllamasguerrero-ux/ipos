
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

    public class ConfiguracionsyncControllerGenerated : BaseController<ConfiguracionsyncBindingModel>, IConfiguracionsyncControllerProviderGenerated
    {
        protected IConfiguracionsyncDaoProvider dao ;

        public ConfiguracionsyncControllerGenerated(IConfiguracionsyncDaoProvider dao) 
        {
            this.dao = dao;
        }



        public override ConfiguracionsyncBindingModel? GetById(ConfiguracionsyncBindingModel itemSelect)
        {
            ConfiguracionsyncBindingModel? item = new ConfiguracionsyncBindingModel();
            item.Item = dao.Get_ById(itemSelect.Item, null) ?? item.Item;
            return item;
        }

        public override List<ConfiguracionsyncBindingModel> GetAll()
        {
            return dao.GetAll_(null).Select(x => new ConfiguracionsyncBindingModel(x)).ToList();
           
        }


        public override List<ConfiguracionsyncBindingModel> SelectList(object? param, KendoParams? kendoParams)
        {
            return dao.SelectList(null, (ConfiguracionsyncParam?)param, kendoParams).Select(x => new ConfiguracionsyncBindingModel(x)).ToList();
        }
        


        public override bool Insert(ConfiguracionsyncBindingModel item)
        {
            return dao.Insert(item.Item,null);
        }
        public override List<ConfiguracionsyncBindingModel> Select( string search)
        {

            return dao.Select(null,search).Select(x => new ConfiguracionsyncBindingModel(x)).ToList();
        }
        public override List<ConfiguracionsyncBindingModel> SelectById(ConfiguracionsyncBindingModel itemSelect)
        {

            return dao.Select_ById(itemSelect.Item,null).Select(x => new ConfiguracionsyncBindingModel(x)).ToList();
        }
        public override bool Update(ConfiguracionsyncBindingModel item)
        {
            if (item.HasErrors)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            return dao.Update(item.Item, null);

        }
        public override bool Delete(ConfiguracionsyncBindingModel item)
        {

            return dao.Delete(item.Item, null);
        }



        //views
	


        //commands
	

        //impo-expo
	

    }
}

