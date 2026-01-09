
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

    public class Sat_configautotransporteItemViewModel : BaseWebRecordViewModel<Sat_configautotransporteBindingModel, Sat_configautotransporteWebController, Sat_configautotransporteItemVMInitialParameters, Sat_configautotransporteListVMEventParameters>
    {

        public Sat_configautotransporteBindingModel? Sat_configautotransporte { get { return Record; } set { Record = value; } }
        public Sat_configautotransporteItemViewModel(string mode, Sat_configautotransporteWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
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


    public class Sat_configautotransporteShowViewModel : Sat_configautotransporteItemViewModel
    {
        public Sat_configautotransporteShowViewModel(Sat_configautotransporteWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class Sat_configautotransporteEditViewModel : Sat_configautotransporteItemViewModel
    {
        public Sat_configautotransporteEditViewModel(Sat_configautotransporteWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class Sat_configautotransporteAddViewModel : Sat_configautotransporteItemViewModel
    {
        public Sat_configautotransporteAddViewModel(Sat_configautotransporteWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


