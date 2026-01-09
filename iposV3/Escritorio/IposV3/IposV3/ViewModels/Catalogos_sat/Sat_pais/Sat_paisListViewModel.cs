
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Dynamic;
using System.Net.Mime;
using System.Windows;
using System.Windows.Input;
using IposV3.ViewModels.BaseScreen;
using ViewModels.BaseScreen;
using BindingModels;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
//using IposV3.Controllers.Controller;
//using DataAccess;
using Models;
using IposV3.Model;
using IposV3.ViewModels;

namespace IposV3.ViewModels
{

    public class Sat_paisListViewModel : BaseWebListViewModel<Sat_paisBindingModel, Sat_paisWebController, Sat_paisItemVMInitialParameters, Sat_paisListVMEventParameters, Sat_paisParam>
    {


        public Sat_paisListViewModel(Sat_paisWebController provider, SelectorWebController selectorProvider, IWindowManager winManager, IEventAggregator aggregator, IMessageBoxService messageBoxService) :
                            base(provider, selectorProvider, winManager, aggregator, messageBoxService)
        {
        }




        protected override void preconfigureSearchParams()
        {
            KendoParams = new KendoParams("", "Sat_clave | Sat_descripcion ");
        }
    
        protected override object EditViewModel()
        {
            return IoC.Get<Sat_paisEditViewModel>();
        }

        protected override object ShowViewModel()
        {
            return IoC.Get<Sat_paisShowViewModel>();
        }


        protected override object AddViewModel()
        {
            return IoC.Get<Sat_paisAddViewModel>();
        }
    }
}
