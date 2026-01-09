
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

    public class Sat_matpeligrosoItemViewModel : BaseWebRecordViewModel<Sat_matpeligrosoBindingModel, Sat_matpeligrosoWebController, Sat_matpeligrosoItemVMInitialParameters, Sat_matpeligrosoListVMEventParameters>
    {

        public Sat_matpeligrosoBindingModel? Sat_matpeligroso { get { return Record; } set { Record = value; } }
        public Sat_matpeligrosoItemViewModel(string mode, Sat_matpeligrosoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
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


    public class Sat_matpeligrosoShowViewModel : Sat_matpeligrosoItemViewModel
    {
        public Sat_matpeligrosoShowViewModel(Sat_matpeligrosoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class Sat_matpeligrosoEditViewModel : Sat_matpeligrosoItemViewModel
    {
        public Sat_matpeligrosoEditViewModel(Sat_matpeligrosoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class Sat_matpeligrosoAddViewModel : Sat_matpeligrosoItemViewModel
    {
        public Sat_matpeligrosoAddViewModel(Sat_matpeligrosoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


