
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

    public class Sat_partetransporteItemViewModel : BaseWebRecordViewModel<Sat_partetransporteBindingModel, Sat_partetransporteWebController, Sat_partetransporteItemVMInitialParameters, Sat_partetransporteListVMEventParameters>
    {

        public Sat_partetransporteBindingModel? Sat_partetransporte { get { return Record; } set { Record = value; } }
        public Sat_partetransporteItemViewModel(string mode, Sat_partetransporteWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
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


    public class Sat_partetransporteShowViewModel : Sat_partetransporteItemViewModel
    {
        public Sat_partetransporteShowViewModel(Sat_partetransporteWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class Sat_partetransporteEditViewModel : Sat_partetransporteItemViewModel
    {
        public Sat_partetransporteEditViewModel(Sat_partetransporteWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class Sat_partetransporteAddViewModel : Sat_partetransporteItemViewModel
    {
        public Sat_partetransporteAddViewModel(Sat_partetransporteWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


