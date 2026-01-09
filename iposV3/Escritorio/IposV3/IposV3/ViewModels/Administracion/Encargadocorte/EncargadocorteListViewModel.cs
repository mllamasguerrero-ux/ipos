
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
using System.Collections.Generic;

namespace IposV3.ViewModels
{

    public class EncargadocorteListViewModel : BaseWebListViewModel<UsuarioBindingModel, UsuarioWebController, UsuarioItemVMInitialParameters, UsuarioListVMEventParameters, UsuarioParam>
    {


        public EncargadocorteListViewModel(UsuarioWebController provider, UsuarioWebController usuarioController , SelectorWebController selectorProvider, IWindowManager winManager, IEventAggregator aggregator, IMessageBoxService messageBoxService) :
                            base(provider, usuarioController , selectorProvider, winManager, aggregator, messageBoxService, false)
        {
        }



        protected override System.Collections.Generic.List<long> DerechosEstandarToCheck()
        {
            return new System.Collections.Generic.List<long>{ Model.DBValues._DERECHO_ENCARGADOCORTE_VER,
                                   Model.DBValues._DERECHO_ENCARGADOCORTE_VER + 1000,
                                   Model.DBValues._DERECHO_ENCARGADOCORTE_VER + 2000,
                                   Model.DBValues._DERECHO_ENCARGADOCORTE_VER + 3000                };
        }

        protected override void preconfigureSearchParams()
        {
            KendoParams = new KendoParams("", "Nombre | UsuarioNombre ");
            KendoParams.Filter = new KendoFilters(
                 new List<KendoFilter>() { new KendoFilter("S", "eq", "Esencargadocorte", "false") }, "and");
        }

        protected override object EditViewModel()
        {
            return IoC.Get<EncargadocorteEditViewModel>();
        }

        protected override object ShowViewModel()
        {
            return IoC.Get<EncargadocorteShowViewModel>();
        }


        protected override object AddViewModel()
        {
            return IoC.Get<EncargadocorteAddViewModel>();
        }

    }
}
