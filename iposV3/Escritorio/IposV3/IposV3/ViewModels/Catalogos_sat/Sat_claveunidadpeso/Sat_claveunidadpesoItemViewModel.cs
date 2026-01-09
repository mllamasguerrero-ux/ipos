
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

    public class Sat_claveunidadpesoItemViewModel : BaseWebRecordViewModel<Sat_claveunidadpesoBindingModel, Sat_claveunidadpesoWebController, Sat_claveunidadpesoItemVMInitialParameters, Sat_claveunidadpesoListVMEventParameters>
    {

        public Sat_claveunidadpesoBindingModel? Sat_claveunidadpeso { get { return Record; } set { Record = value; } }
        public Sat_claveunidadpesoItemViewModel(string mode, Sat_claveunidadpesoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
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


    public class Sat_claveunidadpesoShowViewModel : Sat_claveunidadpesoItemViewModel
    {
        public Sat_claveunidadpesoShowViewModel(Sat_claveunidadpesoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class Sat_claveunidadpesoEditViewModel : Sat_claveunidadpesoItemViewModel
    {
        public Sat_claveunidadpesoEditViewModel(Sat_claveunidadpesoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class Sat_claveunidadpesoAddViewModel : Sat_claveunidadpesoItemViewModel
    {
        public Sat_claveunidadpesoAddViewModel(Sat_claveunidadpesoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


