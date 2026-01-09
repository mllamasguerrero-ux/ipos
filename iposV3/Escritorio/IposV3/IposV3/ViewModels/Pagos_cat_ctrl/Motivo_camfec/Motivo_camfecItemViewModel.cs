
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

    public class Motivo_camfecItemViewModel : BaseWebRecordViewModel<Motivo_camfecBindingModel, Motivo_camfecWebController, Motivo_camfecItemVMInitialParameters, Motivo_camfecListVMEventParameters>
    {

        public Motivo_camfecBindingModel? Motivo_camfec { get { return Record; } set { Record = value; } }
        public Motivo_camfecItemViewModel(string mode, Motivo_camfecWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
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


    public class Motivo_camfecShowViewModel : Motivo_camfecItemViewModel
    {
        public Motivo_camfecShowViewModel(Motivo_camfecWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class Motivo_camfecEditViewModel : Motivo_camfecItemViewModel
    {
        public Motivo_camfecEditViewModel(Motivo_camfecWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class Motivo_camfecAddViewModel : Motivo_camfecItemViewModel
    {
        public Motivo_camfecAddViewModel(Motivo_camfecWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


