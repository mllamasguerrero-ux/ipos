
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

    public class PlazoItemViewModel : BaseWebRecordViewModel<PlazoBindingModel, PlazoWebController, PlazoItemVMInitialParameters, PlazoListVMEventParameters>
    {

        private bool mostrarAlmacen = true;
        public bool MostrarAlmacen { get { return mostrarAlmacen; } set { mostrarAlmacen = value; } }

        public PlazoBindingModel? Plazo { get { return Record; } set { Record = value; } }
        public PlazoItemViewModel(string mode, PlazoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
            this.MostrarAlmacen = GlobalVariable.CurrentSession?.CurrentParametro?.Manejaalmacen == BoolCN.N;
        }




        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Plazo","Almacen","Almacenid", "AlmacenClave", "AlmacenNombre","IposV3.ViewModels.AlmacenListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>();
            

        }

    }


    public class PlazoShowViewModel : PlazoItemViewModel
    {
        public PlazoShowViewModel(PlazoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class PlazoEditViewModel : PlazoItemViewModel
    {
        public PlazoEditViewModel(PlazoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class PlazoAddViewModel : PlazoItemViewModel
    {
        public PlazoAddViewModel(PlazoWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


