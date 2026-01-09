
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

    public class GrupodiferenciainventarioItemViewModel : BaseWebRecordViewModel<GrupodiferenciainventarioBindingModel, GrupodiferenciainventarioWebController, GrupodiferenciainventarioItemVMInitialParameters, GrupodiferenciainventarioListVMEventParameters>
    {

        public GrupodiferenciainventarioBindingModel? Grupodiferenciainventario { get { return Record; } set { Record = value; } }
        public GrupodiferenciainventarioItemViewModel(string mode, GrupodiferenciainventarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

        }




        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                    };
            lstCatalogDef = new List<CatalogDef>();
            

        }

    }


    public class GrupodiferenciainventarioShowViewModel : GrupodiferenciainventarioItemViewModel
    {
        public GrupodiferenciainventarioShowViewModel(GrupodiferenciainventarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class GrupodiferenciainventarioEditViewModel : GrupodiferenciainventarioItemViewModel
    {
        public GrupodiferenciainventarioEditViewModel(GrupodiferenciainventarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class GrupodiferenciainventarioAddViewModel : GrupodiferenciainventarioItemViewModel
    {
        public GrupodiferenciainventarioAddViewModel(GrupodiferenciainventarioWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


