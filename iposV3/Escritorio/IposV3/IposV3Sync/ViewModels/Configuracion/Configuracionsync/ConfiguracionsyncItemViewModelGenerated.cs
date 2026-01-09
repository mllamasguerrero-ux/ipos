
using BindingModels;
using IposV3.Model;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
using IposV3Sync.Controllers.Controller;
using DataAccess;
using Models.CatalogSelector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.BaseScreen;

namespace IposV3Sync.ViewModels
{

    public class ConfiguracionsyncItemViewModelGenerated : BaseRecordViewModel<ConfiguracionsyncBindingModel, IConfiguracionsyncControllerProvider, ConfiguracionsyncItemVMInitialParameters, ConfiguracionsyncListVMEventParameters>
    {

        public ConfiguracionsyncBindingModel? Configuracionsync { get { return Record; } set { Record = value; } }
        public ConfiguracionsyncItemViewModelGenerated(string mode, IConfiguracionsyncControllerProvider provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

        }



        protected override void fillCatalogConfiguration()
        {

            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                    };
            lstCatalogDef = new List<CatalogDef>() { 
		 };
        }

    }
}

