
using BindingModels;
using IposV3.Model;
using IposV3.BindingModel;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
//using IposV3.Controllers.Controller;
//using DataAccess;
using IposV3.ViewModels.BaseScreen;
using ViewModels.BaseScreen;
using Models.CatalogSelector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IposV3.Services;

namespace IposV3.ViewModels
{


    public class WFLoginViewModel : BaseScreen.BaseScreen
    {
        private readonly GlobalWebController globalControllerProvider;
        protected readonly UsuarioWebController provider;
        protected readonly IEventAggregator aggregator;

        public WFLoginParamBindingModel WFLoginParam { get; protected set; }
        public WFLoginResultBindingModel WFLoginResult { get; protected set; }

        public bool BIsReadOnly { get; protected set; }
        public bool BProcessSuccess { get; protected set; }


        public WFLoginViewModel( UsuarioWebController provider, SelectorWebController selectorProvider, GlobalWebController globalControllerProvider,
                                   IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base( selectorProvider,  winManager, messageBoxService)
        {


            this.provider = provider;
            this.globalControllerProvider = globalControllerProvider;
            this.aggregator = aggregator;
            this.BIsReadOnly = false;
            this.BProcessSuccess = false;

            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                    };
            lstCatalogDef = new List<CatalogDef>() { 
		 };

            Task.Run(async () =>
            {
                Catalogs = await selectorProvider.ObtainCatalogs(lstCatalogDef, new BaseParam(GlobalVariable.CurrentSession!.Empresaid, GlobalVariable.CurrentSession.Sucursalid));
            }).Wait();

            WFLoginParam = new WFLoginParamBindingModel(GlobalVariable.CurrentSession.Empresaid, GlobalVariable.CurrentSession.Sucursalid);
            WFLoginResult = new WFLoginResultBindingModel();

            WFLoginParam.PendingChange  += CatalogField_PropertyChanging;
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            ScreenExtensions.TryActivateAsync(this);

            //try
            //{
            //    var listaAProrreatear = new List<Prorrateo>() {
            //                                                                                new Prorrateo(){ Id= 1, Cantidad = 1000m, CantidadProrrateada = 0},
            //                                                                                new Prorrateo(){ Id= 2, Cantidad = 800m, CantidadProrrateada = 0},
            //                                                                                new Prorrateo(){ Id= 3, Cantidad = 1200m, CantidadProrrateada = 0}};

            //    MathIpos.Prorratear(100m, 0, ref listaAProrreatear);

            //}
            //catch { }
        }

        public virtual void Back()
        {
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }

        public void Accept()
        {

            try
            {


                Task.Run(async () =>
                {

                    WFLoginResult = await provider.ValidateLogin(WFLoginParam) ?? WFLoginResult;
                }).Wait();

                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("WFLoginResult"));


                if (WFLoginResult.Result > 0 && (MainWindowCommProvider != null))
                {
                    MainWindowCommProvider.FillMenuData(GlobalVariable.CurrentSession!.Empresaid!.Value, GlobalVariable.CurrentSession!.Sucursalid!.Value, (long)WFLoginResult.Result!.Value);
                    MainWindowCommProvider.GoToScreen(IoC.Get<HomeViewModel>());


                    GlobalSession? bufferSession = GlobalVariable.CurrentSession!;
                    this.globalControllerProvider.llenarSesionUsuario((long?)WFLoginResult.Result.Value, ref bufferSession);
                    GlobalVariable.CurrentSession = bufferSession;
                    //bufferSession.FillUsuarioConfiguration(context, GlobalVariable.CurrentSession!.Empresaid!.Value, GlobalVariable.CurrentSession!.Sucursalid!.Value, (long?)WFLoginResult.Result.Value);


                }

            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
        }

        public  void Cancel()
        {
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }



        public virtual void Configuration()
        {
            MainWindowCommProvider?.GoToScreen(IoC.Get<ConfiguracionListViewModel>());
        }


        public  bool CanP_empresaid
        {
            get { return true; }
        }

        public  bool CanP_sucursalid
        {
            get { return true; }
        }

        public  bool CanP_username
        {
            get { return true; }
        }

        public  bool CanP_claveacceso
        {
            get { return true; }
        }





    }



}
