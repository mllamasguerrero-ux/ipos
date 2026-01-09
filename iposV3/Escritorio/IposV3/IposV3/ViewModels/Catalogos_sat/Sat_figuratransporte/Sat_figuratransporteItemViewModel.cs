
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

    public class Sat_figuratransporteItemViewModel : BaseWebRecordViewModel<Sat_figuratransporteBindingModel, Sat_figuratransporteWebController, Sat_figuratransporteItemVMInitialParameters, Sat_figuratransporteListVMEventParameters>
    {

        public Sat_figuratransporteBindingModel? Sat_figuratransporte { get { return Record; } set { Record = value; } }
        public Sat_figuratransporteItemViewModel(string mode, Sat_figuratransporteWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
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


    public class Sat_figuratransporteShowViewModel : Sat_figuratransporteItemViewModel
    {
        public Sat_figuratransporteShowViewModel(Sat_figuratransporteWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class Sat_figuratransporteEditViewModel : Sat_figuratransporteItemViewModel
    {
        public Sat_figuratransporteEditViewModel(Sat_figuratransporteWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class Sat_figuratransporteAddViewModel : Sat_figuratransporteItemViewModel
    {
        public Sat_figuratransporteAddViewModel(Sat_figuratransporteWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


