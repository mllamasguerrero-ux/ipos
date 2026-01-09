
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

    public class FormapagosatItemViewModel : BaseWebRecordViewModel<FormapagosatBindingModel, FormapagosatWebController, FormapagosatItemVMInitialParameters, FormapagosatListVMEventParameters>
    {

        public FormapagosatBindingModel? Formapagosat { get { return Record; } set { Record = value; } }
        public FormapagosatItemViewModel(string mode, FormapagosatWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

        }




        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                    };
            lstCatalogDef = new List<CatalogDef>();
            
            if (!lstCatalogDef.Any(y => y.CatalogName == "Formapago"))
                lstCatalogDef.Add(new CatalogDef("Formapago")); 

        }

    }


    public class FormapagosatShowViewModel : FormapagosatItemViewModel
    {
        public FormapagosatShowViewModel(FormapagosatWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class FormapagosatEditViewModel : FormapagosatItemViewModel
    {
        public FormapagosatEditViewModel(FormapagosatWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class FormapagosatAddViewModel : FormapagosatItemViewModel
    {
        public FormapagosatAddViewModel(FormapagosatWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


