
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
using IposV3.BindingModel;

namespace IposV3.ViewModels
{

    public class LineaItemViewModel : BaseWebRecordViewModel<LineaBindingModel, LineaWebController, LineaItemVMInitialParameters, LineaListVMEventParameters>
    {



        public LineaBindingModel? Linea { get { return Record; } set { Record = value; } }

        public bool MostrarAplicaMayoreoPorLinea { get; set; } = false;

        public LineaItemViewModel(string mode, LineaWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

        }


        //protected new void OnViewLoaded(object view)
        //{
        //    base.OnViewLoaded(view);



        //}



        protected override void fillCatalogConfiguration()
        {

            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          //new CatalogRelatedFields("Linea","Tiporecarga","Tiporecarga", "Tiporecarga", "Tiporecarganombre","IposV3.ViewModels.TiporecargaListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>()
            {
                new CatalogDef("Tiporecarga")
            };

            if (GlobalVariable.CurrentSession?.CurrentParametro?.Aplicarmayoreoporlinea != null &&
                GlobalVariable.CurrentSession?.CurrentParametro?.Aplicarmayoreoporlinea == BoolCN.S)
            {
                MostrarAplicaMayoreoPorLinea = true;
            }
            else
            {
                MostrarAplicaMayoreoPorLinea = false;
            }

        }

    }


    public class LineaShowViewModel : LineaItemViewModel
    {
        public LineaShowViewModel(LineaWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class LineaEditViewModel : LineaItemViewModel
    {
        public LineaEditViewModel(LineaWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class LineaAddViewModel : LineaItemViewModel
    {
        public LineaAddViewModel(LineaWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}

