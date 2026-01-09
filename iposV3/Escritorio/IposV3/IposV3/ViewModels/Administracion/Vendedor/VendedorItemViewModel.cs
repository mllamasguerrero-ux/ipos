
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

    public class VendedorItemViewModel : BaseWebRecordViewModel<UsuarioBindingModel, UsuarioWebController, UsuarioItemVMInitialParameters, UsuarioListVMEventParameters>
    {

        public UsuarioBindingModel? Usuario { get { return Record; } set { Record = value; } }
        public VendedorItemViewModel(string mode, UsuarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }




        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Usuario","Grupousuario","Usuario_Preferencias_Grupousuarioid", "Usuario_Preferencias_GrupousuarioClave", "Usuario_Preferencias_GrupousuarioNombre","IposV3.ViewModels.GrupousuarioListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Usuario","Almacen","Usuario_Preferencias_Almacenid", "Usuario_Preferencias_AlmacenClave", "Usuario_Preferencias_AlmacenNombre","IposV3.ViewModels.AlmacenListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>();
            
            if (!lstCatalogDef.Any(y => y.CatalogName == "Saludo"))
                lstCatalogDef.Add(new CatalogDef("Saludo"));  
            if (!lstCatalogDef.Any(y => y.CatalogName == "Tipoprecio"))
                lstCatalogDef.Add(new CatalogDef("Tipoprecio")); 

        }

    }


    public class VendedorShowViewModel : VendedorItemViewModel
    {
        public VendedorShowViewModel(UsuarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class VendedorEditViewModel : VendedorItemViewModel
    {
        public VendedorEditViewModel(UsuarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class VendedorAddViewModel : VendedorItemViewModel
    {
        public VendedorAddViewModel(UsuarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


