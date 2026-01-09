
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

    public class TipodiferenciainventarioItemViewModel : BaseWebRecordViewModel<TipodiferenciainventarioBindingModel, TipodiferenciainventarioWebController, TipodiferenciainventarioItemVMInitialParameters, TipodiferenciainventarioListVMEventParameters>
    {

        public TipodiferenciainventarioBindingModel? Tipodiferenciainventario { get { return Record; } set { Record = value; } }
        public TipodiferenciainventarioItemViewModel(string mode, TipodiferenciainventarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

        }




        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Tipodiferenciainventario","Grupodiferenciainventario","Grupodiferenciainventarioid", "GrupodiferenciainventarioClave", "GrupodiferenciainventarioNombre","IposV3.ViewModels.GrupodiferenciainventarioListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>();
            

        }

    }


    public class TipodiferenciainventarioShowViewModel : TipodiferenciainventarioItemViewModel
    {
        public TipodiferenciainventarioShowViewModel(TipodiferenciainventarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class TipodiferenciainventarioEditViewModel : TipodiferenciainventarioItemViewModel
    {
        public TipodiferenciainventarioEditViewModel(TipodiferenciainventarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class TipodiferenciainventarioAddViewModel : TipodiferenciainventarioItemViewModel
    {
        public TipodiferenciainventarioAddViewModel(TipodiferenciainventarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


