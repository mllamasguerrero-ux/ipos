
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

    public class AnaquelItemViewModel : BaseWebRecordViewModel<AnaquelBindingModel, AnaquelWebController, AnaquelItemVMInitialParameters, AnaquelListVMEventParameters>
    {

        public AnaquelBindingModel? Anaquel { get { return Record; } set { Record = value; } }
        public AnaquelItemViewModel(string mode, AnaquelWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

        }




        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Anaquel","Almacen","Almacenid", "AlmacenClave", "AlmacenNombre","IposV3.ViewModels.AlmacenListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>();
            

        }

    }


    public class AnaquelShowViewModel : AnaquelItemViewModel
    {
        public AnaquelShowViewModel(AnaquelWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class AnaquelEditViewModel : AnaquelItemViewModel
    {
        public AnaquelEditViewModel(AnaquelWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class AnaquelAddViewModel : AnaquelItemViewModel
    {
        public AnaquelAddViewModel(AnaquelWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


