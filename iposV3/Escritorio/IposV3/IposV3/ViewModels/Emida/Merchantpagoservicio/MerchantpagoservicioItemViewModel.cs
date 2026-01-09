
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

    public class MerchantpagoservicioItemViewModel : BaseWebRecordViewModel<MerchantpagoservicioBindingModel, MerchantpagoservicioWebController, MerchantpagoservicioItemVMInitialParameters, MerchantpagoservicioListVMEventParameters>
    {

        public MerchantpagoservicioBindingModel? Merchantpagoservicio { get { return Record; } set { Record = value; } }
        public MerchantpagoservicioItemViewModel(string mode, MerchantpagoservicioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

        }




        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Merchantpagoservicio","Sucursal_info","Sucursal_id", "Sucursal_infoClave", "Sucursal_infoNombre","IposV3.ViewModels.Sucursal_infoListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>();
            

        }

    }


    public class MerchantpagoservicioShowViewModel : MerchantpagoservicioItemViewModel
    {
        public MerchantpagoservicioShowViewModel(MerchantpagoservicioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class MerchantpagoservicioEditViewModel : MerchantpagoservicioItemViewModel
    {
        public MerchantpagoservicioEditViewModel(MerchantpagoservicioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class MerchantpagoservicioAddViewModel : MerchantpagoservicioItemViewModel
    {
        public MerchantpagoservicioAddViewModel(MerchantpagoservicioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


