
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

    public class Sat_metodopagoItemViewModel : BaseWebRecordViewModel<Sat_metodopagoBindingModel, Sat_metodopagoWebController, Sat_metodopagoItemVMInitialParameters, Sat_metodopagoListVMEventParameters>
    {

        public Sat_metodopagoBindingModel? Sat_metodopago { get { return Record; } set { Record = value; } }
        public Sat_metodopagoItemViewModel(string mode, Sat_metodopagoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
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


    public class Sat_metodopagoShowViewModel : Sat_metodopagoItemViewModel
    {
        public Sat_metodopagoShowViewModel(Sat_metodopagoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class Sat_metodopagoEditViewModel : Sat_metodopagoItemViewModel
    {
        public Sat_metodopagoEditViewModel(Sat_metodopagoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class Sat_metodopagoAddViewModel : Sat_metodopagoItemViewModel
    {
        public Sat_metodopagoAddViewModel(Sat_metodopagoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


