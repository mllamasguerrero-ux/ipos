
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

    public class Sat_tipopermisoItemViewModel : BaseWebRecordViewModel<Sat_tipopermisoBindingModel, Sat_tipopermisoWebController, Sat_tipopermisoItemVMInitialParameters, Sat_tipopermisoListVMEventParameters>
    {

        public Sat_tipopermisoBindingModel? Sat_tipopermiso { get { return Record; } set { Record = value; } }
        public Sat_tipopermisoItemViewModel(string mode, Sat_tipopermisoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
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


    public class Sat_tipopermisoShowViewModel : Sat_tipopermisoItemViewModel
    {
        public Sat_tipopermisoShowViewModel(Sat_tipopermisoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class Sat_tipopermisoEditViewModel : Sat_tipopermisoItemViewModel
    {
        public Sat_tipopermisoEditViewModel(Sat_tipopermisoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class Sat_tipopermisoAddViewModel : Sat_tipopermisoItemViewModel
    {
        public Sat_tipopermisoAddViewModel(Sat_tipopermisoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


