using System.Configuration;
using System.Windows.Controls;
using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using Caliburn.Micro;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows;
using System.Dynamic;
using System.Windows.Automation.Provider;
using Controllers.BindingModel.Menu;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Threading;
using Controllers.Controller;
using IposV3Sync.Controllers.Controller;
using IposV3Sync.ViewModels;
using System.Windows.Forms;
using IposV3.Model;
using IposV3Sync.BindingModel;
using BindingModels;

namespace IposV3Sync.ViewModels
{
    public class MainWindowViewModel : Conductor<object>, INotifyPropertyChanged, IHandle<NavigationParameter>,  IMainWindowCommProvider
    {
        private ObservableCollection<MyMenuData> _data = new ObservableCollection<MyMenuData>();
        public ObservableCollection<MyMenuData> data
        {
            get { return _data; }
            set
            {
                _data = value;
                NotifyOfPropertyChange();
            }
        }


        private ICommand? _importRecentItemCommand;
        public ICommand ImportRecentItemCommand
        {
            get { return _importRecentItemCommand ?? (_importRecentItemCommand = new RelayCommand(ImportRecentItemCommandExecuted)); }
        }


        private object? _currentContent;

        //public List<ConfigurationAction> ConfigurationActionList { get; set; }


        bool _leftMenuShowed;
        public bool LeftMenuShowed
        {
            get { return _leftMenuShowed; }
            set
            {
                _leftMenuShowed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LeftMenuShowed)));
            }
        }

        public new event PropertyChangedEventHandler? PropertyChanged;

        
        public object? CurrentContent
        {
            get => _currentContent;
            set
            {
                if (value == null || value.Equals(_currentContent)) return;

                _currentContent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentContent)));
            }
        }




        protected readonly IEventAggregator aggregator;


        public Queue<object> contentHistory = new Queue<object>();

        protected readonly IWindowManager winManager;



        protected readonly ConfiguracionController? configuracionProvider;
        protected readonly GlobalController? globalControllerProvider;

        private readonly IConfiguracionsyncControllerProvider configuracionsyncControllerProvider;

        private ApplicationDbContext context;


        public List<ConfigurationAction> ConfigurationActionList { get; set; }

        public MainWindowViewModel(ApplicationDbContext context, 
                                ConfiguracionController? configuracionProvider, GlobalController? globalControllerProvider,
                                IConfiguracionsyncControllerProvider configuracionsyncControllerProvider,
                                IEventAggregator aggregator, IWindowManager winManager)
        {

            this.aggregator = aggregator;
            this.aggregator.SubscribeOnUIThread(this);

            this.winManager = winManager;

            this.configuracionProvider = configuracionProvider;
            this.globalControllerProvider = globalControllerProvider;
            this.configuracionsyncControllerProvider = configuracionsyncControllerProvider;
            this.context = context;

            ConfigurationActionList = new List<ConfigurationAction>();

            LeftMenuShowed = false;



            try
            {
                //CurrentContent = IoC.Get<HomeViewModel>();
                //var loginWindow = IoC.Get<HomeViewModel>();

                llenarSessionDefault();

                var loginWindow = IoC.Get<HomeSyncViewModel>();
                loginWindow.MainWindowCommProvider = this;
                CurrentContent = loginWindow;

                _importRecentItemCommand = new RelayCommand(ImportRecentItemCommandExecuted);

                FillMenuData(0, 0, 0);



                //FillMenuData(GlobalVariable.CurrentSession!.Empresaid!.Value,
                //            GlobalVariable.CurrentSession!.Sucursalid!.Value,
                //             GlobalVariable.CurrentSession!.Usuarioid!.Value);

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

        }



        public void llenarSessionDefault()
        {

            IposV3.Model.Syncr.Configuracionsync? defaultConfig = this.configuracionsyncControllerProvider.GetDefaultConfiguracion();
            if (defaultConfig != null)
            {
                //GlobalVariable.CurrentSession = new GlobalSession();
                GlobalSession bufferSession = new GlobalSession();
                globalControllerProvider?.llenarSesionPorConfiguracionsync(defaultConfig, ref bufferSession);
                GlobalVariable.CurrentSession = bufferSession;

                ConfigurationManager.AppSettings.Set("itemEmpresaIdForEditing", GlobalVariable.CurrentSession.Empresaid.ToString());
                ConfigurationManager.AppSettings.Set("itemSucursalIdForEditing", GlobalVariable.CurrentSession.Sucursalid.ToString());


                string connectionStr = "Server=" + defaultConfig.Serverlocal + ";Port=" + defaultConfig.Portlocal + ";Database=" + defaultConfig.Dblocal + ";Uid=" + defaultConfig.Usuariolocal + ";Pwd=" + defaultConfig.Passwordlocal + ";";
                ConfigurationActionList.Add(new ConfigurationAction() { Action = "cambiar_conexion", Parameters = new List<string>() { connectionStr } });

            }
        }



        private long? ExistingConfifigurationSync()
        {

            var items = this.configuracionsyncControllerProvider.SelectList(null, new KendoParams());
            if (items != null && items.Count > 0)
            {
                return items.First().Id;
            }

            return null;

        }
        private void ImportRecentItemCommandExecuted(object? parameter)
        {
            var mData = (MyMenuData?)parameter;

            if (mData == null)
                return;

            ViewModels.BaseScreen.BaseScreen screen;

            //System.Diagnostics.Debug.WriteLine("mData.MenuId" + mData.MenuId.ToString());

            switch (mData.MenuId.ToString())
            {





                case "-2":
                    {


                        contentHistory.Clear();

                        var existingConfig = ExistingConfifigurationSync();


                        if (existingConfig == null || existingConfig.Value == 0)
                        {

                            screen = IoC.Get<ConfiguracionsyncAddViewModel>();
                        }
                        else
                        {

                            screen = IoC.Get<ConfiguracionsyncEditViewModel>();
                            aggregator.PublishOnUIThreadAsync(new ConfiguracionsyncItemVMInitialParameters(existingConfig));
                        }
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;

                    }


                case "-4":
                    {


                        contentHistory.Clear();
                        screen = IoC.Get<TablasAReplicarWFViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }






            }



        }


        protected dynamic CreateWinSettings(string strTitle, double sizePercentage)
        {

            return CreateWinSettings(strTitle, sizePercentage, sizePercentage);
        }

        protected dynamic CreateWinSettings(string strTitle, double sizePercentageWidth, double sizePercentageHeight)
        {

            dynamic settings = new ExpandoObject();
            settings.WindowStyle = WindowStyle.ThreeDBorderWindow;
            settings.ShowInTaskbar = true;
            settings.Title = strTitle;
            settings.WindowState = WindowState.Normal;
            settings.ResizeMode = ResizeMode.CanResize;
            settings.SizeToContent = System.Windows.SizeToContent.Manual;
            settings.Width = SystemParameters.PrimaryScreenWidth * sizePercentageWidth;
            settings.Height = SystemParameters.PrimaryScreenHeight * sizePercentageHeight;

            return settings;
        }



        private ObservableCollection<IposV3Sync.DemoItem> GenerateDemoItems()
        {

            return new ObservableCollection<IposV3Sync.DemoItem>
            {
                //new DemoItem("Home",IoC.Get<ClienteListViewModel>()
                //),
                // new DemoItem("Palette", IoC.Get<ProveedorListViewModel>())
            };
        }



        public void Handle(NavigationParameter navParameters)
        {

            if (navParameters.GoBack)
            {
                if (contentHistory.Count() <= 0)
                    return;

                var content = contentHistory.Dequeue();
                CurrentContent = content;
                //SelectedItem = new DemoItem("", content);
                return;
            }

            if (!navParameters.KeepHistory)
                contentHistory.Clear();

            if(CurrentContent != null)
                contentHistory.Enqueue(CurrentContent);

            //SelectedItem = new DemoItem("", navParameters.Content);
            CurrentContent = navParameters.Content ?? CurrentContent;


        }

        //public async Task IHandle<NavigationParameter>.HandleAsync(NavigationParameter message, CancellationToken cancellationToken)
        //{
        //    Handle(message);
        //    return Task.CompleteTask;
        //}
        public  Task HandleAsync(NavigationParameter message, CancellationToken cancellationToken)
        {
            Handle(message);
            return Task.CompletedTask;
        }


        public void FillMenuData(long empresaId, long sucursalId, long usuarioId)
        {

            List<MyMenuDataBindingModel> lst = new List<MyMenuDataBindingModel>();
            lst.Add(TestMenus());


            ////data = new ObservableCollection<MyMenuData>(lst.Select(x => new MyMenuData(x)).ToList());
            data.Clear();
            foreach (var item in lst.Select(x => new MyMenuData(x)).ToList())
                data.Add(item);



            //data.Add(TestingMenu());


            OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("data"));

        }


        public void GoToScreen(ViewModels.BaseScreen.BaseScreen screen)
        {

            contentHistory.Clear();
            screen.MainWindowCommProvider = this;
            CurrentContent = screen;
            LeftMenuShowed = false;
        }



        private MyMenuDataBindingModel TestMenus()
        {

            MyMenuDataBindingModel testMenu = new MyMenuDataBindingModel()
            {
                MyHeader = "General",
                MenuId = -1,
                SubItems = new List<MyMenuDataBindingModel>()
                {

                            
                    

            //MyHeader = "ProductolocationsList",
                    new MyMenuDataBindingModel()
                    {
                        MyHeader = "Configuracion",
                        MenuId = -2
                    },

                    new MyMenuDataBindingModel()
                    {
                        MyHeader = "Tablas de replicacion",
                        MenuId = -4
                    },

            //NewTest Menu Generator Flag


                    new MyMenuDataBindingModel()
                    {
                        MyHeader = "Estado de proceso",
                        MenuId = -5
                    }



                }
            };

            return testMenu;
        }

        

    }
}