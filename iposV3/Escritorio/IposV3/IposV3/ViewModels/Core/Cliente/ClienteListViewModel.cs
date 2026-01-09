
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
using IposV3.BindingModel;

namespace IposV3.ViewModels
{

    public class ClienteListViewModel : BaseWebListViewModel<ClienteBindingModel, ClienteWebController, ClienteItemVMInitialParameters, ClienteListVMEventParameters, ClienteParam>
    {
        public bool PermitirVerSaldo { get; set; } = true;
        private readonly GlobalWebController globalControllerProvider;

        public GlobalSession? GlobalSession { get => GlobalVariable.CurrentSession; }

        public ClienteListViewModel(ClienteWebController provider, UsuarioWebController usuarioControllerProvider, GlobalWebController globalControllerProvider, SelectorWebController selectorProvider, IWindowManager winManager, IEventAggregator aggregator, IMessageBoxService messageBoxService) :
                            base(provider, usuarioControllerProvider, selectorProvider, winManager, aggregator, messageBoxService, true)
        {
            this.globalControllerProvider = globalControllerProvider;

            PermitirVerSaldo =  (DerechosUsuario?[Model.DBValues._DERECHO_VERENLISTA_SALDO_PROVEEDORES] ?? false);

            //fill catalogs configuration and autocomplete
            GlobalSession? bufferSession = GlobalVariable.CurrentSession;
            globalControllerProvider.llenarClienteAutoCompleteList(ref bufferSession);

        }


        protected override System.Collections.Generic.List<long> DerechosEstandarToCheck()
        {
            return new System.Collections.Generic.List<long>{ Model.DBValues._DERECHO_CLIENTE_VER,
                                   Model.DBValues._DERECHO_CLIENTE_VER + 1000,
                                   Model.DBValues._DERECHO_CLIENTE_VER + 2000,
                                   Model.DBValues._DERECHO_CLIENTE_VER + 3000,
                                   Model.DBValues._DERECHO_VERENLISTA_SALDO_PROVEEDORES};
        }



        protected override void preconfigureSearchParams()
        {
            KendoParams = new KendoParams("", "Clave | Contacto1.Nombre | Rfc | Nombres ");
        }
    
        protected override object EditViewModel()
        {
            return IoC.Get<ClienteEditViewModel>();
        }

        protected override object ShowViewModel()
        {
            return IoC.Get<ClienteShowViewModel>();
        }


        protected override object AddViewModel()
        {
            return IoC.Get<ClienteAddViewModel>();
        }

    }
}
