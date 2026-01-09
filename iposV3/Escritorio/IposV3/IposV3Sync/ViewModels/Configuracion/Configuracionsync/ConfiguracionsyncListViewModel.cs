
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Dynamic;
using System.Net.Mime;
using System.Windows;
using System.Windows.Input;
using BindingModels;
using IposV3.Model;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
using IposV3Sync.Controllers.Controller;
using DataAccess;
using Models;
using ViewModels.BaseScreen;

namespace IposV3Sync.ViewModels
{

    public class ConfiguracionsyncListViewModel : ConfiguracionsyncListViewModelGenerated
    {


        public ConfiguracionsyncListViewModel(IConfiguracionsyncControllerProvider provider, SelectorWebController selectorProvider, IWindowManager winManager, IEventAggregator aggregator, IMessageBoxService messageBoxService) : 
                            base(provider,  selectorProvider,  winManager,  aggregator, messageBoxService)
        {
        }

    }

}

