
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

    public class Sat_usocfdiItemViewModel : BaseWebRecordViewModel<Sat_usocfdiBindingModel, Sat_usocfdiWebController, Sat_usocfdiItemVMInitialParameters, Sat_usocfdiListVMEventParameters>
    {

        public Sat_usocfdiBindingModel? Sat_usocfdi { get { return Record; } set { Record = value; } }
        public Sat_usocfdiItemViewModel(string mode, Sat_usocfdiWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

        }




        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                    };
            lstCatalogDef = new List<CatalogDef>();
            

        }

    }


    public class Sat_usocfdiShowViewModel : Sat_usocfdiItemViewModel
    {
        public Sat_usocfdiShowViewModel(Sat_usocfdiWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class Sat_usocfdiEditViewModel : Sat_usocfdiItemViewModel
    {
        public Sat_usocfdiEditViewModel(Sat_usocfdiWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class Sat_usocfdiAddViewModel : Sat_usocfdiItemViewModel
    {
        public Sat_usocfdiAddViewModel(Sat_usocfdiWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


