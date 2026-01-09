
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

    public class ProductolocationsItemViewModel : BaseWebRecordViewModel<ProductolocationsBindingModel, ProductolocationsWebController, ProductolocationsItemVMInitialParameters, ProductolocationsListVMEventParameters>
    {

        public ProductolocationsBindingModel? Productolocations { get { return Record; } set { Record = value; } }
        public ProductolocationsItemViewModel(string mode, ProductolocationsWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

        }




        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Productolocations","Producto","Productoid", "ProductoClave", "ProductoNombre","IposV3.ViewModels.ProductoListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Productolocations","Anaquel","Anaquelid", "AnaquelClave", "AnaquelNombre","IposV3.ViewModels.AnaquelListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Productolocations","Almacen","Almacenid", "AlmacenClave", "AlmacenNombre","IposV3.ViewModels.AlmacenListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>();
            

        }

    }


    public class ProductolocationsShowViewModel : ProductolocationsItemViewModel
    {
        public ProductolocationsShowViewModel(ProductolocationsWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class ProductolocationsEditViewModel : ProductolocationsItemViewModel
    {
        public ProductolocationsEditViewModel(ProductolocationsWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class ProductolocationsAddViewModel : ProductolocationsItemViewModel
    {
        public ProductolocationsAddViewModel(ProductolocationsWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


