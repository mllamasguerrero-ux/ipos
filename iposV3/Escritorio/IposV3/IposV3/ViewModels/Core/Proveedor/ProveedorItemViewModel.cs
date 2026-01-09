
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

    public class ProveedorItemViewModel : BaseWebRecordViewModel<ProveedorBindingModel, ProveedorWebController, ProveedorItemVMInitialParameters, ProveedorListVMEventParameters>
    {

        public ProveedorBindingModel? Proveedor { get { return Record; } set { Record = value; } }
        public ProveedorItemViewModel(string mode, ProveedorWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

        }




        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Proveedor","Cliente","Proveeclienteid", "ProveeclienteClave", "ProveeclienteNombre","IposV3.ViewModels.ClienteListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Proveedor","Usuario","Vendedorid", "VendedorClave", "VendedorNombre","IposV3.ViewModels.UsuarioListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>();
            if (!lstCatalogDef.Any(y => y.CatalogName == "DiasDeLaSemana"))
                lstCatalogDef.Add(new CatalogDef("DiasDeLaSemana"));
            if (!lstCatalogDef.Any(y => y.CatalogName == "Tipoprecio"))
                lstCatalogDef.Add(new CatalogDef("Tipoprecio"));
            if (!lstCatalogDef.Any(y => y.CatalogName == "Saludo"))
                lstCatalogDef.Add(new CatalogDef("Saludo"));


        }

    }


    public class ProveedorShowViewModel : ProveedorItemViewModel
    {
        public ProveedorShowViewModel(ProveedorWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class ProveedorEditViewModel : ProveedorItemViewModel
    {
        public ProveedorEditViewModel(ProveedorWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class ProveedorAddViewModel : ProveedorItemViewModel
    {
        public ProveedorAddViewModel(ProveedorWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


