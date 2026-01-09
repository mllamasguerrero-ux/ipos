
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

    public class CajaItemViewModel : BaseWebRecordViewModel<CajaBindingModel, CajaWebController, CajaItemVMInitialParameters, CajaListVMEventParameters>
    {

        public CajaBindingModel? Caja { get { return Record; } set { Record = value; } }
        public CajaItemViewModel(string mode, CajaWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

        }




        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Caja","Terminalpagoservicio","Caja_emida_Terminalid", "Caja_emida_TerminalClave", "Caja_emida_TerminalNombre","IposV3.ViewModels.TerminalpagoservicioListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Caja","Terminalpagoservicio","Caja_emida_Terminalserviciosid", "Caja_emida_TerminalserviciosClave", "Caja_emida_TerminalserviciosNombre","IposV3.ViewModels.TerminalpagoservicioListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>();
            

        }

    }


    public class CajaShowViewModel : CajaItemViewModel
    {
        public CajaShowViewModel(CajaWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class CajaEditViewModel : CajaItemViewModel
    {
        public CajaEditViewModel(CajaWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class CajaAddViewModel : CajaItemViewModel
    {
        public CajaAddViewModel(CajaWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


