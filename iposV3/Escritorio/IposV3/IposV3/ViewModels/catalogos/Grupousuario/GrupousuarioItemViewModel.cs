
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

    public class GrupousuarioItemViewModel : BaseWebRecordViewModel<GrupousuarioBindingModel, GrupousuarioWebController, GrupousuarioItemVMInitialParameters, GrupousuarioListVMEventParameters>
    {

        public GrupousuarioBindingModel? Grupousuario { get { return Record; } set { Record = value; } }
        public GrupousuarioItemViewModel(string mode, GrupousuarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
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


    public class GrupousuarioShowViewModel : GrupousuarioItemViewModel
    {
        public GrupousuarioShowViewModel(GrupousuarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class GrupousuarioEditViewModel : GrupousuarioItemViewModel
    {
        public GrupousuarioEditViewModel(GrupousuarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class GrupousuarioAddViewModel : GrupousuarioItemViewModel
    {
        public GrupousuarioAddViewModel(GrupousuarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


