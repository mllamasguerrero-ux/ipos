
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Dynamic;
using System.Net.Mime;
using System.Windows;
using System.Windows.Input; 
using IposV3.ViewModels.BaseScreen;
using ViewModels.BaseScreen;
using BindingModels;
using IposV3.Model;
using IposV3.BindingModel;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
//using IposV3.Controllers.Controller;
//using DataAccess;
using Models;
using System.Threading.Tasks;
using System.Threading;

namespace IposV3.ViewModels
{

    public class ConfiguracionListViewModel : IposV3.ViewModels.BaseScreen.BaseScreen, IHandle<ConfiguracionListVMInitialParameters>, IHandle<ConfiguracionListVMEventParameters>
    {
        private readonly ConfiguracionWebController? itemsProvider;
        private readonly GlobalWebController? globalControllerProvider;
        private string? itemsLoadedText;
        public ConfiguracionBindingModel? selectedItem;
        public ObservableCollection<ConfiguracionBindingModel>? Items { get; private set; }
        private ConfiguracionParam? listParam;
        public Model.KendoParams? KendoParams { get;  set; }

        protected readonly IEventAggregator? aggregator;


        public string? ItemsLoadedText
        {
            get { return itemsLoadedText; }
            set
            {
                itemsLoadedText = value;
                NotifyOfPropertyChange();
            }
        }

        public ConfiguracionListViewModel(ConfiguracionWebController provider, SelectorWebController selectorProvider, GlobalWebController globalControllerProvider, 
            IWindowManager winManager, IEventAggregator aggregator, IMessageBoxService messageBoxService) : base(selectorProvider, winManager, messageBoxService)
        {
            itemsProvider = provider;
            this.globalControllerProvider = globalControllerProvider;
            Items = new ObservableCollection<ConfiguracionBindingModel>();
            listParam = new ConfiguracionParam(4,2);
            KendoParams = new Model.KendoParams("","clave|nombre");
            this.aggregator = aggregator;
            this.aggregator.SubscribeOnUIThread(this);
        }

        public bool CanEditItem
        {
            get { return SelectedItem != null; }
        }

        public void Edititem(ConfiguracionBindingModel selected)
        {
            this.SelectedItem = selected;

            var vm = IoC.Get<ConfiguracionEditViewModel>();
            aggregator.PublishOnUIThreadAsync(new ConfiguracionItemVMInitialParameters(SelectedItem.Id));
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
        }

        public void ShowItem(ConfiguracionBindingModel selected)
        {
            this.SelectedItem = selected;

            var vm = IoC.Get<ConfiguracionShowViewModel>();
            aggregator.PublishOnUIThreadAsync(new ConfiguracionItemVMInitialParameters(SelectedItem.Id));
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
        }



        public ConfigurationAction SelectItem(ConfiguracionBindingModel selected)
        {
            this.SelectedItem = selected;

            var strConnectionString = "Server=" + selected.Servidor + ";Port=" + selected.Puerto + ";Database=" + selected.Database + ";Uid=" + selected.Usuario + ";Pwd=" + selected.Password + ";Include Error Detail=true;";

            //var _context = IoC.Get<ApplicationDbContext>();
            //_context.Database.CloseConnection();
            //_context.ConnectionString = strConnectionString;
            //_context.Database.SetConnectionString(_context.ConnectionString);

            //var _operationContextFactory = IoC.Get<OperationsContextFactory>();
            //_operationContextFactory.ConnectionString = strConnectionString;

            IposV3.Views.ConnectionMgr.llenarSessionYCambiaConexion(this.SelectedItem?.Item);
            return new ConfigurationAction() { Action = "volver_atras", Parameters = new List<string>() {  } };

            //SetConfiguracionInGlobal(this.SelectedItem?.Item);
            //return new ConfigurationAction() { Action = "cambiar_conexion", Parameters = new List<string>() { _context.ConnectionString } };

            //var vm = IoC.Get<ConfiguracionShowViewModel>();
            //aggregator.PublishOnUIThreadAsync(new ConfiguracionItemVMInitialParameters(SelectedItem.Id));
            //aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
        }


        public virtual void Back()
        {
            MainWindowCommProvider?.GoToScreen(IoC.Get<WFLoginViewModel>());
            //aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }



        public void SelectItemByCell(ConfiguracionBindingModel selected)
        {
            this.SelectedItem = selected;
            this.TryCloseAsync();
        }

        public void AddItem()
        {
            
            var vm = IoC.Get<ConfiguracionAddViewModel>();
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
        }


        public void TSBBuscar()
        {
            ReloadItems();
        }
        public void TSTPalabrasClaveKeyDown(Key key)
        {
            if (key == Key.Enter)
            {
                TSBBuscar();
            }
        }


        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            ReloadItems();
            return Task.FromResult(true);
        }




        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            ScreenExtensions.TryActivateAsync(this);
        }



        public Task HandleAsync(ConfiguracionListVMInitialParameters parameters, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task HandleAsync(ConfiguracionListVMEventParameters parameters, CancellationToken cancellationToken)
        {
            if (parameters.IsReloadEvent)
                ReloadItems();
            return Task.CompletedTask;
        }
        

        public void CloseApp()
        {
            Application.Current.Shutdown();
        }

        public ConfiguracionBindingModel? SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                NotifyOfPropertyChange(() => CanEditItem);
            }
        }

        public bool CanRemoveItem
        {
            get { return SelectedItem != null; }
        }

        public void RemoveItem()
        {
            if(SelectedItem != null)
                Items?.Remove(SelectedItem);
        }



        //protected void SetConfiguracionInGlobal(Configuracion? config)
        //{
        //    if (config != null)
        //    {
        //        GlobalSession bufferSession = new GlobalSession();
        //        globalControllerProvider?.llenarSesionPorConfiguracion(config, ref bufferSession);
        //        GlobalVariable.CurrentSession = bufferSession;

        //        ConfigurationManager.AppSettings.Set("itemEmpresaIdForEditing", GlobalVariable.CurrentSession.Empresaid.ToString());
        //        ConfigurationManager.AppSettings.Set("itemSucursalIdForEditing", GlobalVariable.CurrentSession.Sucursalid.ToString());

        //    }
        //}
        public void ReloadItems()
        {
            Items?.Clear();
	    try
            {
                List<ConfiguracionBindingModel> items = new List<ConfiguracionBindingModel>();

                Task.Run(async () =>
                {
                   items = await itemsProvider!.SelectList(listParam, KendoParams) ?? items;

                }).Wait();

                foreach (var item in items! )
            	{
                	Items?.Add(item);
            	}
            	ItemsLoadedText = "Loaded!";
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
        }
    }
}
