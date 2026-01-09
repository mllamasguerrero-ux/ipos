
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

    public class UnidadItemViewModel : BaseWebRecordViewModel<UnidadBindingModel, UnidadWebController, UnidadItemVMInitialParameters, UnidadListVMEventParameters>
    {

        public UnidadBindingModel? Unidad { get { return Record; } set { Record = value; } }
        public UnidadItemViewModel(string mode, UnidadWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

        }




        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Unidad","Sat_unidadmedida","Sat_unidadmedidaid", "Sat_unidadmedidaClave", "Sat_unidadmedidaNombre","IposV3.ViewModels.Sat_unidadmedidaListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>();
            

        }

    }


    public class UnidadShowViewModel : UnidadItemViewModel
    {
        public UnidadShowViewModel(UnidadWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class UnidadEditViewModel : UnidadItemViewModel
    {
        public UnidadEditViewModel(UnidadWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class UnidadAddViewModel : UnidadItemViewModel
    {
        public UnidadAddViewModel(UnidadWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


