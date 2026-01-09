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
//using IposV3.Controllers.Controller;
using IposV3.ViewModels;
using System.Windows.Forms;
using IposV3.Model;
using IposV3.BindingModel;
using BindingModels;

namespace IposV3.ViewModels
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


        private readonly MenuitemsWebController itemsProvider;
        private readonly ParametroWebController parametroProvider;

        protected readonly ConfiguracionWebController? configuracionProvider;
        protected readonly GlobalWebController? globalControllerProvider;



        public List<ConfigurationAction> ConfigurationActionList { get; set; }

        public MainWindowViewModel(
                                MenuitemsWebController itemsProvider, ParametroWebController parametroProvider,
                                ConfiguracionWebController? configuracionProvider, GlobalWebController? globalControllerProvider,
                                IEventAggregator aggregator, IWindowManager winManager)
        {

            this.aggregator = aggregator;
            this.aggregator.SubscribeOnUIThread(this);

            this.winManager = winManager;

            this.itemsProvider = itemsProvider;
            this.parametroProvider = parametroProvider;
            this.configuracionProvider = configuracionProvider;
            this.globalControllerProvider = globalControllerProvider;

            ConfigurationActionList = new List<ConfigurationAction>();

            LeftMenuShowed = false;



            try
            {
                //CurrentContent = IoC.Get<HomeViewModel>();
                //var loginWindow = IoC.Get<HomeViewModel>();

                llenarSessionDefault();

                var loginWindow = IoC.Get<WFLoginViewModel>();
                loginWindow.MainWindowCommProvider = this;
                CurrentContent = loginWindow;

                _importRecentItemCommand = new RelayCommand(ImportRecentItemCommandExecuted);



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


            Configuracion? defaultConfig = null; 
            Task.Run(async () =>
            {
                defaultConfig = await this.configuracionProvider!.GetDefaultConfiguracion(); 
            }).Wait();

            IposV3.Views.ConnectionMgr.llenarSessionYCambiaConexion(defaultConfig);

            
        }


        //public void MigrateDataBase()
        //{
        //    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        //    var _context = IoC.Get<ApplicationDbContext>();
        //    var _contextFactory = IoC.Get<OperationsContextFactory>();

        //    var configuracionProvider = IoC.Get<ConfiguracionController>();
        //    Configuracion? defaultConfig = configuracionProvider?.GetDefaultConfiguracion();
        //    if (defaultConfig != null)
        //    {
        //        _context.Database.CloseConnection();
        //        _context.ConnectionString = "Server=" + defaultConfig.Servidor + ";Port=" + defaultConfig.Puerto + ";Database=" + defaultConfig.Database + ";Uid=" + defaultConfig.Usuario + ";Pwd=" + defaultConfig.Password + ";";
        //        _context.Database.SetConnectionString(_context.ConnectionString);

        //        _contextFactory.ConnectionString = "Server=" + defaultConfig.Servidor + ";Port=" + defaultConfig.Puerto + ";Database=" + defaultConfig.Database + ";Uid=" + defaultConfig.Usuario + ";Pwd=" + defaultConfig.Password + ";";

        //    }


        //    var migrationsJustApplied = _context.Database.GetPendingMigrations().ToList();
        //    _context.Database.Migrate();


        //    IposV3.Migrations.Seed.MigrationService.RunSpecialMigrationProcesses(_context, migrationsJustApplied);


        //}

        private void ImportRecentItemCommandExecuted(object? parameter)
        {
            var mData = (MyMenuData?)parameter;

            if (mData == null)
                return;

            IposV3.ViewModels.BaseScreen.BaseScreen screen;

            //System.Diagnostics.Debug.WriteLine("mData.MenuId" + mData.MenuId.ToString());

            switch (mData.MenuId.ToString())
            {

                case "2"://  Clientes
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<ClienteListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                case "9"://  punto de venta
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<PuntoVentaViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                case "16"://  compra
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<PuntoCompraViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                case "18"://  proveedores
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<ProveedorListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                case "19": //Linea
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<LineaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                case "20": //Marca
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<MarcaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                case "21"://  productos
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<ProductoListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;

                        //contentHistory.Clear();
                        //screen = IoC.Get<WFProductoEditWFViewModel>();
                        //screen.MainWindowCommProvider = this;
                        //CurrentContent = screen;
                        //LeftMenuShowed = false;
                        //break;
                    }



                //Corte cerrar
                case "30":
                    {
                        contentHistory.Clear();

                        var vm = IoC.Get<CorteCerrarViewModel>();
                        vm.EsCajeroActual = true;

                        screen = vm;

                        screen.MainWindowCommProvider = this;


                        var inip = new CorteItemVMInitialParameters();
                        inip.Cajeroid = GlobalVariable.CurrentSession!.Usuarioid; 
                        aggregator.PublishOnUIThreadAsync(inip);

                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                //Corte abrir
                case "52":
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<CorteAbrirViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "10"://devolucion de compra
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<PuntoCompraDevoViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                case "6"://nota de credito
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<PuntoVentaDevoViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "13":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<WFDocto_traslado_recWFViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                case "14":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<Docto_pedido_entradaWFViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                case "363":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<Docto_solicitud_mercanciaWFViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }



                case "68"://  producto locations
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<ProductolocationsListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "81":// tasaiva
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<TasaivaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }



                case "82"://  moneda
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<MonedaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                case "83"://  bancos
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<BancoListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                case "88"://  sucursales:
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<Sucursal_infoListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                case "89": // grupo sucursal
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<GruposucursalListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }



                case "91": // anaqueles
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<AnaquelListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "94"://  estados
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<EstadopaisListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                case "95":// Unidades:
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<UnidadListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                case "97":// Promociones:
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<PromocionListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }



                case "213":// grupos de usuario:
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<GrupousuarioListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "216"://  Gasto
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<GastoListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }



                case "226":// tipo transaccion:
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<TipotransaccionListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }



                case "232":// cajas:
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<CajaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "238"://  rutas de embarque
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<RutaembarqueListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "242"://  contenido
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<ContenidoListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                case "243"://  clasifica
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<ClasificaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "246"://  motivo devolucion
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<Motivo_devolucionListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "286":// area:
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<AreaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "292"://  almacenes
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<AlmacenListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "295"://  plazos
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<PlazoListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "336":// lista precios:
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<ListaprecioListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                case "337"://  max fact
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<MaxfactListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "349"://  motivos de cambio de fecha de aplicacion
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<Motivo_camfecListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                case "358"://  tipo cliente
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<SubtipoclienteListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }



                case "61"://perfiles
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<PerfilesListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "51"://inventario
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<V_inventario_listViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }



                case "23"://  usuarios
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<UsuarioListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;


                        //contentHistory.Clear();
                        //screen = IoC.Get<WFUsuarioEditWFViewModel>();
                        //screen.MainWindowCommProvider = this;
                        //CurrentContent = screen;
                        //LeftMenuShowed = false;
                        //break;

                    }


                case "3"://  vendedores
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<VendedorListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;


                    }

                case "271"://  encargado guia
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<EncargadoguiaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;


                    }


                case "366"://  encargado corte
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<EncargadocorteListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;


                    }


                case "307"://  sat aduana
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<Sat_aduanaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "305"://  sat producto servicio
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<Sat_productoservicioListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }




                case "328"://  sat uso cfdi
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<Sat_usocfdiListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "248"://  emida product
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<EmidaproductListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "250"://  merchant pagos servicio
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<MerchantpagoservicioListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "233"://  terminal pago servicio
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<TerminalpagoservicioListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "251"://  clerk pago servicio
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<ClerkpagoservicioListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "289"://  gasto adicional
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<GastoadicionalListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "217"://  cuenta
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<CuentaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "329"://  cuenta banco
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<CuentabancoListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "121"://  campo referencia precio
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<CamporeferenciaprecioListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "26"://  reportes
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<ReportesListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                //CurrentContent = IoC.Get<ParametroListViewModel>();
                case "29":
                    {
                        contentHistory.Clear();


                        var currentParametro = ObtainCurrentParametro();

                        if(currentParametro != null)
                            screen = IoC.Get<ParametroEditViewModel>();
                        else
                            screen = IoC.Get<ParametroAddViewModel>();



                        if (currentParametro != null)
                        {
                            var inip = new ParametroItemVMInitialParameters(currentParametro.Id);
                            aggregator.PublishOnUIThreadAsync(inip);
                        }

                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;

                        break;
                    }




                case "330"://  pagos
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<WFPagosCompuestosListWFViewModel>();

                        var inip = new WFPagosCompuestosVMInitialParameters(DBValues._DOCTO_TIPO_VENTA);
                        aggregator.PublishOnUIThreadAsync(inip);


                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                case "371"://  pagos
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<WFPagosCompuestosListWFViewModel>();


                        var inip = new WFPagosCompuestosVMInitialParameters(DBValues._DOCTO_TIPO_COMPRA);
                        aggregator.PublishOnUIThreadAsync(inip);


                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }



                case "79"://  abonos a clientes
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<WFAbonosViewModel>();

                        var inip = new WFAbonosItemVMInitialParameters(DBValues._DOCTO_TIPO_VENTA);
                        aggregator.PublishOnUIThreadAsync(inip);

                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                case "78"://  abonos a proveedores
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<WFAbonosViewModel>();

                        var inip = new WFAbonosItemVMInitialParameters(DBValues._DOCTO_TIPO_COMPRA);
                        aggregator.PublishOnUIThreadAsync(inip);

                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                case "370"://  vehiculos
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<VehiculoListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                case "203"://  consolidado
                    {

                        contentHistory.Clear();
                        screen = IoC.Get<WFConsolidadoWFViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }





                case "-2":
                    {

                        contentHistory.Clear();

                        LeftMenuShowed = false;
                        break;
                    }


                case "-4":
                    {


                        contentHistory.Clear();
                        LeftMenuShowed = false;
                        break;
                    }






            }

            switch(mData.MyHeader + "List")
            {


                case "MigracionList":// migracion:
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<MigracionViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }


                //CurrentContent = IoC.Get<CajaListViewModel>();
                case "CajaList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<CajaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<PerfilesListViewModel>();
                case "PerfilesList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<PerfilesListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<GruposucursalListViewModel>();
                case "GruposucursalList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<GruposucursalListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<GrupousuarioListViewModel>();
                case "GrupousuarioList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<GrupousuarioListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<MonedaListViewModel>();
                case "MonedaList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<MonedaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<TasaiepsListViewModel>();
                case "TasaiepsList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<TasaiepsListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<TasaivaListViewModel>();
                case "TasaivaList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<TasaivaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<UnidadListViewModel>();
                case "UnidadList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<UnidadListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<EstadopaisListViewModel>();
                case "EstadopaisList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<EstadopaisListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<SubtipoclienteListViewModel>();
                case "SubtipoclienteList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<SubtipoclienteListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<TiporecargaListViewModel>();
                case "TiporecargaList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<TiporecargaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<FormapagosatListViewModel>();
                case "FormapagosatList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<FormapagosatListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<Sat_aduanaListViewModel>();
                case "Sat_aduanaList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<Sat_aduanaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<Sat_claveunidadpesoListViewModel>();
                case "Sat_claveunidadpesoList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<Sat_claveunidadpesoListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<Sat_coloniaListViewModel>();
                case "Sat_coloniaList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<Sat_coloniaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<Sat_localidadListViewModel>();
                case "Sat_localidadList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<Sat_localidadListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<Sat_matpeligrosoListViewModel>();
                case "Sat_matpeligrosoList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<Sat_matpeligrosoListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<Sat_metodopagoListViewModel>();
                case "Sat_metodopagoList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<Sat_metodopagoListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<Sat_municipioListViewModel>();
                case "Sat_municipioList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<Sat_municipioListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<Sat_paisListViewModel>();
                case "Sat_paisList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<Sat_paisListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<Sat_productoservicioListViewModel>();
                case "Sat_productoservicioList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<Sat_productoservicioListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<Sat_regimenfiscalListViewModel>();
                case "Sat_regimenfiscalList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<Sat_regimenfiscalListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<Sat_tipoembalajeListViewModel>();
                case "Sat_tipoembalajeList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<Sat_tipoembalajeListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<Sat_unidadmedidaListViewModel>();
                case "Sat_unidadmedidaList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<Sat_unidadmedidaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<Sat_usocfdiListViewModel>();
                case "Sat_usocfdiList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<Sat_usocfdiListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<EstadocobranzaListViewModel>();
                case "EstadocobranzaList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<EstadocobranzaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<EstadopagocontrareciboListViewModel>();
                case "EstadopagocontrareciboList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<EstadopagocontrareciboListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<TipotransaccionListViewModel>();
                case "TipotransaccionList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<TipotransaccionListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<ClerkpagoservicioListViewModel>();
                case "ClerkpagoservicioList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<ClerkpagoservicioListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<MerchantpagoservicioListViewModel>();
                case "MerchantpagoservicioList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<MerchantpagoservicioListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<TerminalpagoservicioListViewModel>();
                case "TerminalpagoservicioList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<TerminalpagoservicioListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<GastoadicionalListViewModel>();
                case "GastoadicionalList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<GastoadicionalListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<EstadoguiaListViewModel>();
                case "EstadoguiaList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<EstadoguiaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<TipoentregaListViewModel>();
                case "TipoentregaList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<TipoentregaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<AlmacenListViewModel>();
                case "AlmacenList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<AlmacenListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<AnaquelListViewModel>();
                case "AnaquelList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<AnaquelListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<GrupodiferenciainventarioListViewModel>();
                case "GrupodiferenciainventarioList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<GrupodiferenciainventarioListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<TipodiferenciainventarioListViewModel>();
                case "TipodiferenciainventarioList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<TipodiferenciainventarioListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<MensajenivelurgenciaListViewModel>();
                case "MensajenivelurgenciaList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<MensajenivelurgenciaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<BancoListViewModel>();
                case "BancoList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<BancoListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<FormapagoListViewModel>();
                case "FormapagoList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<FormapagoListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<Motivo_camfecListViewModel>();
                case "Motivo_camfecList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<Motivo_camfecListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<CuentabancoListViewModel>();
                case "CuentabancoList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<CuentabancoListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<PlazoListViewModel>();
                case "PlazoList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<PlazoListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<TipolineapolizaListViewModel>();
                case "TipolineapolizaList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<TipolineapolizaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<CamporeferenciaprecioListViewModel>();
                case "CamporeferenciaprecioList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<CamporeferenciaprecioListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<TipodescuentoprodListViewModel>();
                case "TipodescuentoprodList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<TipodescuentoprodListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<TipoutilidadListViewModel>();
                case "TipoutilidadList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<TipoutilidadListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<RangopromocionListViewModel>();
                case "RangopromocionList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<RangopromocionListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<TipopromocionListViewModel>();
                case "TipopromocionList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<TipopromocionListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<ClasificaListViewModel>();
                case "ClasificaList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<ClasificaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<ContenidoListViewModel>();
                case "ContenidoList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<ContenidoListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<ReportesListViewModel>();
                case "ReportesList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<ReportesListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<RutaembarqueListViewModel>();
                case "RutaembarqueList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<RutaembarqueListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<Motivo_devolucionListViewModel>();
                case "Motivo_devolucionList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<Motivo_devolucionListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                //CurrentContent = IoC.Get<EmidaproductListViewModel>();
                case "EmidaproductList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<EmidaproductListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<CuentaListViewModel>();
                case "CuentaList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<CuentaListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }

                //CurrentContent = IoC.Get<PromocionListViewModel>();
                case "PromocionList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<PromocionListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }



                //CurrentContent = IoC.Get<Sucursal_infoListViewModel>();
                case "Sucursal_infoList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<Sucursal_infoListViewModel>();
                        screen.MainWindowCommProvider = this;
                        CurrentContent = screen;
                        LeftMenuShowed = false;
                        break;
                    }
                //CurrentContent = IoC.Get<UsuarioListViewModel>();
                case "UsuarioList":
                    {
                        contentHistory.Clear();
                        screen = IoC.Get<UsuarioListViewModel>();
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



        private ObservableCollection<DemoItem> GenerateDemoItems()
        {

            return new ObservableCollection<DemoItem>
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

            Task.Run(async () =>
            {
                lst = await itemsProvider.SelectPorUsuario(empresaId, sucursalId, usuarioId) ?? lst;
            }).Wait();

            
            //lst.Add(TestMenus());


            //data = new ObservableCollection<MyMenuData>(lst.Select(x => new MyMenuData(x)).ToList());
            data.Clear();
            foreach (var item in lst.Select(x => new MyMenuData(x)).ToList())
                data.Add(item);



            data.Add(TestingMenu());


            OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("data"));

        }


        public void GoToScreen(BaseScreen.BaseScreen screen)
        {

            contentHistory.Clear();
            screen.MainWindowCommProvider = this;
            CurrentContent = screen;
            LeftMenuShowed = false;
        }


        private MyMenuData TestingMenu()
        {

            var listSubItems = new List<MyMenuData>()
            {

                new MyMenuData() { MenuId = -101, MyHeader = "Migracion"},
                new MyMenuData() { MenuId = -101, MyHeader = "Caja"},
                new MyMenuData() { MenuId = -102, MyHeader = "Perfiles"},
                new MyMenuData() { MenuId = -103, MyHeader = "Sucursal_info"},
                new MyMenuData() { MenuId = -104, MyHeader = "Usuario"},
                new MyMenuData() { MenuId = -105, MyHeader = "Gruposucursal"},
                new MyMenuData() { MenuId = -106, MyHeader = "Grupousuario"},
                new MyMenuData() { MenuId = -107, MyHeader = "Moneda"},
                new MyMenuData() { MenuId = -108, MyHeader = "Tasaieps"},
                new MyMenuData() { MenuId = -109, MyHeader = "Tasaiva"},
                new MyMenuData() { MenuId = -110, MyHeader = "Unidad"},
                new MyMenuData() { MenuId = -111, MyHeader = "Estadopais"},
                new MyMenuData() { MenuId = -112, MyHeader = "Subtipocliente"},
                new MyMenuData() { MenuId = -113, MyHeader = "Tiporecarga"},
                new MyMenuData() { MenuId = -114, MyHeader = "Formapagosat"},
                new MyMenuData() { MenuId = -115, MyHeader = "Sat_aduana"},
                new MyMenuData() { MenuId = -116, MyHeader = "Sat_claveunidadpeso"},
                new MyMenuData() { MenuId = -117, MyHeader = "Sat_colonia"},
                new MyMenuData() { MenuId = -118, MyHeader = "Sat_localidad"},
                new MyMenuData() { MenuId = -119, MyHeader = "Sat_matpeligroso"},
                new MyMenuData() { MenuId = -120, MyHeader = "Sat_metodopago"},
                new MyMenuData() { MenuId = -121, MyHeader = "Sat_municipio"},
                new MyMenuData() { MenuId = -122, MyHeader = "Sat_pais"},
                new MyMenuData() { MenuId = -123, MyHeader = "Sat_productoservicio"},
                new MyMenuData() { MenuId = -124, MyHeader = "Sat_regimenfiscal"},
                new MyMenuData() { MenuId = -125, MyHeader = "Sat_tipoembalaje"},
                new MyMenuData() { MenuId = -126, MyHeader = "Sat_unidadmedida"},
                new MyMenuData() { MenuId = -127, MyHeader = "Sat_usocfdi"},
                new MyMenuData() { MenuId = -128, MyHeader = "Estadocobranza"},
                new MyMenuData() { MenuId = -129, MyHeader = "Estadopagocontrarecibo"},
                new MyMenuData() { MenuId = -130, MyHeader = "Cliente"},
                new MyMenuData() { MenuId = -131, MyHeader = "Producto"},
                new MyMenuData() { MenuId = -132, MyHeader = "Proveedor"},
                new MyMenuData() { MenuId = -133, MyHeader = "Tipotransaccion"},
                new MyMenuData() { MenuId = -134, MyHeader = "Clerkpagoservicio"},
                new MyMenuData() { MenuId = -135, MyHeader = "Emidaproduct"},
                new MyMenuData() { MenuId = -136, MyHeader = "Merchantpagoservicio"},
                new MyMenuData() { MenuId = -137, MyHeader = "Terminalpagoservicio"},
                new MyMenuData() { MenuId = -138, MyHeader = "Gastoadicional"},
                new MyMenuData() { MenuId = -139, MyHeader = "Estadoguia"},
                new MyMenuData() { MenuId = -140, MyHeader = "Tipoentrega"},
                new MyMenuData() { MenuId = -141, MyHeader = "Almacen"},
                new MyMenuData() { MenuId = -142, MyHeader = "Anaquel"},
                new MyMenuData() { MenuId = -143, MyHeader = "Grupodiferenciainventario"},
                new MyMenuData() { MenuId = -144, MyHeader = "Tipodiferenciainventario"},
                new MyMenuData() { MenuId = -145, MyHeader = "Mensajenivelurgencia"},
                new MyMenuData() { MenuId = -146, MyHeader = "Banco"},
                new MyMenuData() { MenuId = -147, MyHeader = "Formapago"},
                new MyMenuData() { MenuId = -148, MyHeader = "Motivo_camfec"},
                new MyMenuData() { MenuId = -149, MyHeader = "Cuenta"},
                new MyMenuData() { MenuId = -150, MyHeader = "Cuentabanco"},
                new MyMenuData() { MenuId = -151, MyHeader = "Plazo"},
                new MyMenuData() { MenuId = -152, MyHeader = "Tipolineapoliza"},
                new MyMenuData() { MenuId = -153, MyHeader = "Camporeferenciaprecio"},
                new MyMenuData() { MenuId = -154, MyHeader = "Tipodescuentoprod"},
                new MyMenuData() { MenuId = -155, MyHeader = "Tipoutilidad"},
                new MyMenuData() { MenuId = -156, MyHeader = "Promocion"},
                new MyMenuData() { MenuId = -157, MyHeader = "Rangopromocion"},
                new MyMenuData() { MenuId = -158, MyHeader = "Tipopromocion"},
                new MyMenuData() { MenuId = -159, MyHeader = "Clasifica"},
                new MyMenuData() { MenuId = -160, MyHeader = "Contenido"},
                new MyMenuData() { MenuId = -161, MyHeader = "Reportes"},
                new MyMenuData() { MenuId = -162, MyHeader = "Rutaembarque"},
                new MyMenuData() { MenuId = -163, MyHeader = "Motivo_devolucion"}

            };



            return new MyMenuData()
            {
                MenuId = -100,
                MyHeader = "Inicio",
                SubItems = listSubItems
            };
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

        private ParametroBindingModel? ObtainCurrentParametro()
        {

            ParametroBindingModel? item = new ParametroBindingModel();

            item.Id = 0;
            item.EmpresaId = GlobalVariable.CurrentSession?.Empresaid;
            item.SucursalId = GlobalVariable.CurrentSession?.Sucursalid;


            Task.Run(async () =>
            {
                item = await this.parametroProvider.GetById(item);
            }).Wait();

            return item;
        }

    }
}