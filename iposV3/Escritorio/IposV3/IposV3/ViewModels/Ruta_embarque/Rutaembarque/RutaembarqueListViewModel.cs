
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

    public class RutaembarqueListViewModel : BaseWebListViewModel<RutaembarqueBindingModel, RutaembarqueWebController, RutaembarqueItemVMInitialParameters, RutaembarqueListVMEventParameters, RutaembarqueParam>
    {


        public RutaembarqueListViewModel(RutaembarqueWebController provider, UsuarioWebController usuarioControllerProvider, SelectorWebController selectorProvider, IWindowManager winManager, IEventAggregator aggregator, IMessageBoxService messageBoxService) :
                            base(provider, usuarioControllerProvider, selectorProvider, winManager, aggregator, messageBoxService, true)
        {
        }

        protected override System.Collections.Generic.List<long> DerechosEstandarToCheck()
        {
            return new System.Collections.Generic.List<long>{ Model.DBValues._DERECHO_RUTAEMBARQUE_VER,
                                   Model.DBValues._DERECHO_RUTAEMBARQUE_VER + 1000,
                                   Model.DBValues._DERECHO_RUTAEMBARQUE_VER + 2000,
                                   Model.DBValues._DERECHO_RUTAEMBARQUE_VER + 3000                };
        }


        protected override void preconfigureSearchParams()
        {
            KendoParams = new KendoParams("", "Clave | Nombre ");
        }
    
        protected override object EditViewModel()
        {
            return IoC.Get<RutaembarqueEditViewModel>();
        }

        protected override object ShowViewModel()
        {
            return IoC.Get<RutaembarqueShowViewModel>();
        }


        protected override object AddViewModel()
        {
            return IoC.Get<RutaembarqueAddViewModel>();
        }
    }
}
