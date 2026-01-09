
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

    public class CuentaItemViewModel : BaseWebRecordViewModel<CuentaBindingModel, CuentaWebController, CuentaItemVMInitialParameters, CuentaListVMEventParameters>
    {

        public CuentaBindingModel? Cuenta { get { return Record; } set { Record = value; } }
        public CuentaItemViewModel(string mode, CuentaWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

        }




        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                    };
            lstCatalogDef = new List<CatalogDef>();
            
            if (!lstCatalogDef.Any(y => y.CatalogName == "Tipolineapoliza"))
                lstCatalogDef.Add(new CatalogDef("Tipolineapoliza"));  
            if (!lstCatalogDef.Any(y => y.CatalogName == "Formapagosat"))
                lstCatalogDef.Add(new CatalogDef("Formapagosat"));  
            if (!lstCatalogDef.Any(y => y.CatalogName == "Tipolineapoliza"))
                lstCatalogDef.Add(new CatalogDef("Tipolineapoliza")); 

        }

    }


    public class CuentaShowViewModel : CuentaItemViewModel
    {
        public CuentaShowViewModel(CuentaWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class CuentaEditViewModel : CuentaItemViewModel
    {
        public CuentaEditViewModel(CuentaWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class CuentaAddViewModel : CuentaItemViewModel
    {
        public CuentaAddViewModel(CuentaWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


