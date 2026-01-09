
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

    public class TerminalpagoservicioItemViewModel : BaseWebRecordViewModel<TerminalpagoservicioBindingModel, TerminalpagoservicioWebController, TerminalpagoservicioItemVMInitialParameters, TerminalpagoservicioListVMEventParameters>
    {

        public TerminalpagoservicioBindingModel? Terminalpagoservicio { get { return Record; } set { Record = value; } }
        public TerminalpagoservicioItemViewModel(string mode, TerminalpagoservicioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

        }




        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Terminalpagoservicio","Sucursal_info","Sucursalinfoid", "SucursalinfoClave", "SucursalinfoNombre","IposV3.ViewModels.Sucursal_infoListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>();
            

        }

    }


    public class TerminalpagoservicioShowViewModel : TerminalpagoservicioItemViewModel
    {
        public TerminalpagoservicioShowViewModel(TerminalpagoservicioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class TerminalpagoservicioEditViewModel : TerminalpagoservicioItemViewModel
    {
        public TerminalpagoservicioEditViewModel(TerminalpagoservicioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class TerminalpagoservicioAddViewModel : TerminalpagoservicioItemViewModel
    {
        public TerminalpagoservicioAddViewModel(TerminalpagoservicioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


