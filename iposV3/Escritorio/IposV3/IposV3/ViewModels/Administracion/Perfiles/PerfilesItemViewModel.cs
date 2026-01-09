
using BindingModels;
using IposV3.Model;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
//using IposV3.Controllers.Controller;
//using DataAccess;
using Models.CatalogSelector; 
using IposV3.ViewModels.BaseScreen;
using ViewModels.BaseScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.ViewModels
{

    public class PerfilesItemViewModel : BaseWebRecordViewModel<PerfilesBindingModel, PerfilesWebController, PerfilesItemVMInitialParameters, PerfilesListVMEventParameters>
    {

        public PerfilesBindingModel? Perfiles { get { return Record; } set { Record = value; } }

        public List<PerfilDerechoItemBindingModel> Perfiles_derechosItems { get; set; }
        public PerfilesItemViewModel(string mode, PerfilesWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {


            Perfiles_derechosItems = new List<PerfilDerechoItemBindingModel>();
        }


        protected override async void fillRecordToEdit(PerfilesItemVMInitialParameters initialParameters)
        {
            base.fillRecordToEdit(initialParameters);

            PerfilesBindingModel item = new PerfilesBindingModel();

            item.Id = initialParameters.Id;
            item.EmpresaId = GlobalVariable.CurrentSession?.Empresaid;
            item.SucursalId = GlobalVariable.CurrentSession?.Sucursalid;

            var kendoParams = new KendoParams("", @"");
            Perfiles_derechosItems = await provider.GetPerfilesDerechos(item, kendoParams) ?? new List<PerfilDerechoItemBindingModel>();

        }


        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                    };
            lstCatalogDef = new List<CatalogDef>();
            

        }




        protected override void doInsert()
        {
            if (Record == null)
                return;

            provider.Insert(Record);

            provider.UpdatePerfilesDerechos(Record, Perfiles_derechosItems);
        }

        protected override void doUpdate()
        {
            if (Record == null)
                return;

            provider.Update(Record);

            provider.UpdatePerfilesDerechos(Record, Perfiles_derechosItems);
        }

    }


    public class PerfilesShowViewModel : PerfilesItemViewModel
    {
        public PerfilesShowViewModel(PerfilesWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class PerfilesEditViewModel : PerfilesItemViewModel
    {
        public PerfilesEditViewModel(PerfilesWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class PerfilesAddViewModel : PerfilesItemViewModel
    {
        public PerfilesAddViewModel(PerfilesWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


