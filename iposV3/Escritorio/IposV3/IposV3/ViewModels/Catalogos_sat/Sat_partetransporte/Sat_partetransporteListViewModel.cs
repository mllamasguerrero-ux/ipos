
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

    public class Sat_partetransporteListViewModel : BaseWebListViewModel<Sat_partetransporteBindingModel, Sat_partetransporteWebController, Sat_partetransporteItemVMInitialParameters, Sat_partetransporteListVMEventParameters, Sat_partetransporteParam>
    {


        public Sat_partetransporteListViewModel(Sat_partetransporteWebController provider, SelectorWebController selectorProvider, IWindowManager winManager, IEventAggregator aggregator, IMessageBoxService messageBoxService) :
                            base(provider, selectorProvider, winManager, aggregator, messageBoxService)
        {
        }




        protected override void preconfigureSearchParams()
        {
            KendoParams = new KendoParams("", "Clave | Descripcion ");
        }
    
        protected override object EditViewModel()
        {
            return IoC.Get<Sat_partetransporteEditViewModel>();
        }

        protected override object ShowViewModel()
        {
            return IoC.Get<Sat_partetransporteShowViewModel>();
        }


        protected override object AddViewModel()
        {
            return IoC.Get<Sat_partetransporteAddViewModel>();
        }
    }
}
