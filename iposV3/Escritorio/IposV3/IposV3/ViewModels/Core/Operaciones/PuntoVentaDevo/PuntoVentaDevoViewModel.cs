
using BindingModels;
using IposV3.Model;
using IposV3.BindingModel;
using Caliburn.Micro;
using Controllers;
using Controllers.BindingModel;
using Controllers.Controller;
//using IposV3.Controllers.Controller;
//using DataAccess;
using IposV3.ViewModels.BaseScreen;
using ViewModels.BaseScreen;
using IposV3.ViewModels.core.operaciones.puntoventa;
using Models.CatalogSelector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using IposV3.ViewModels.utilities;
using System.Collections.Specialized;
using IposV3.Services;
using IposV3.ViewModels.Models;
using IposV3.Services.ExtensionsLocal;
using System.Threading;

namespace IposV3.ViewModels
{
    public class PuntoVentaDevoViewModel : BaseOperationalScreen
    {

        //Main entities
        private DoctoBindingModel? currentDocto;
        public DoctoBindingModel? CurrentDocto
        {
            get => currentDocto;
            set
            {
                currentDocto = value; NotifyOfPropertyChange("CurrentDocto");
                if (currentDocto != null)
                {
                    currentDocto.PendingChange += DoctoPendingChangeEventHandler;// CatalogField_PropertyChanging;
                    currentDocto.PropertyChanged += DoctoPropertyChangedEventHandler;
                }
            }
        }

        private DoctoBindingModel? currentDoctoRef;
        public DoctoBindingModel? CurrentDoctoRef
        {
            get => currentDoctoRef;
            set
            {
                currentDoctoRef = value; NotifyOfPropertyChange("CurrentDoctoRef");
            }
        }

        private MovtoBindingModel? currentMovto;
        public MovtoBindingModel? CurrentMovto
        {
            get => currentMovto;
            set
            {
                currentMovto = value; NotifyOfPropertyChange("CurrentMovto");

                if (currentMovto != null)
                {
                    currentMovto.PendingChange += MovtoPendingChangeEventHandler;// CatalogField_PropertyChanging;
                    currentMovto.PropertyChanged += MovtoPropertyChangedEventHandler;
                }
            }
        }

        private ClienteBindingModel? currentCliente;
        public ClienteBindingModel? CurrentCliente { get => currentCliente ; set{ currentCliente = value; NotifyOfPropertyChange("CurrentCliente"); } }

        private ProductoBindingModel? currentProducto;
        public ProductoBindingModel? CurrentProducto { get => currentProducto; set { currentProducto = value; NotifyOfPropertyChange("CurrentProducto"); } }


        //Internal grids properties
        public ObservableCollection<V_movto_vend_to_devoWFBindingModel> MovtoToDevoItems { get; set; }
        public ObservableCollection<V_movto_venddevoWFBindingModel> MovtoItems { get; set; }
        public ObservableCollection<object>? SelectedMovtoItems { get; set; }


        //Operation result properties
        public BaseResultBindingModel? Fnc_docto_venddevo_insertResult { get; set; }
        public BaseResultBindingModel? Fnc_movto_venddevo_insertResult { get; set; }
        public bool BProcessSuccess { get; protected set; }

        //configuration
        public GlobalSession? GlobalSession { get => GlobalVariable.CurrentSession; }

        //fields activation/habilitation
        private bool cajasBotellasActive;
        public bool CajasBotellasActive { get => cajasBotellasActive; set { cajasBotellasActive = value; NotifyOfPropertyChange("CajasBotellasActive"); } }

        private bool cantidadEnabled;
        public bool CantidadEnabled { get => cantidadEnabled; set { cantidadEnabled = value; NotifyOfPropertyChange("CantidadEnabled"); } }

        private bool precioEnabled;
        public bool PrecioEnabled { get => precioEnabled; set { precioEnabled = value; NotifyOfPropertyChange("PrecioEnabled"); } }

        private bool descuentoEnabled;
        public bool DescuentoEnabled { get => descuentoEnabled; set { descuentoEnabled = value; NotifyOfPropertyChange("DescuentoEnabled"); } }

        private bool listaPrecioEnabled;
        public bool ListaPrecioEnabled { get => listaPrecioEnabled; set { listaPrecioEnabled = value; NotifyOfPropertyChange("ListaPrecioEnabled"); } }



        private bool manejAlmacen;
        public bool ManejaAlmacen { get => manejAlmacen; set { manejAlmacen = value; NotifyOfPropertyChange("ManejaAlmacen"); } }


        //special fields
        //Cajas
        public decimal cajas;
        public decimal Cajas { get => cajas; set { cajas = value; NotifyOfPropertyChange("Cajas"); } }

        //Current date
        private DateTime _currentDateTime;
        public DateTime CurrentDateTime_
        {
            get
            {
                return _currentDateTime;
            }
            set
            {
                if (value != _currentDateTime)
                {
                    _currentDateTime = value;
                    NotifyOfPropertyChange(() => this.CurrentDateTime_);
                }
            }
        }

        //list price fields
        private Dictionary<string, decimal>? listaPrecios;
        public Dictionary<string, decimal>? ListaPrecios
        {
            get
            {
                return listaPrecios;
            }
            set
            {
                if (value != listaPrecios)
                {
                    listaPrecios = value;
                    NotifyOfPropertyChange(() => this.ListaPrecios);
                }
            }
        }

        private decimal selectedListPrice;
        public decimal SelectedListPrice
        {
            get
            {
                return selectedListPrice;
            }
            set
            {
                //if (value != selectedListPrice)
                // {
                selectedListPrice = value;
                NotifyOfPropertyChange(() => this.SelectedListPrice);
                OnListPriceChanged();
                // }
            }
        }

        //Controller providers
        protected readonly DoctoWebController doctoProvider;
        protected readonly MovtoWebController movtoProvider;
        protected readonly ClienteWebController clienteProvider;
        protected readonly ProductoWebController productoProvider;
        protected readonly Sucursal_infoWebController sucursal_extProvider;
        private readonly GlobalWebController globalControllerProvider;
        //private readonly ITicketstemplatesControllerProvider ticketstemplatesControllerProvider;
        private readonly InventarioWebController inventarioControllerProvider;
        private readonly PuntoVentaDevoWebController puntoVentaDevoControllerProvider;
        private readonly PuntoVentaWebController puntoVenta_ControllerProvider;
        //protected readonly IEventAggregator aggregator;

        //waiting fields
        private bool isBusyMovtoList;
        public bool IsBusyMovtoList
        {
            get
            {
                return isBusyMovtoList;
            }
            set
            {
                isBusyMovtoList = value;
                NotifyOfPropertyChange("IsBusyMovtoList");

            }
        }



        public Dictionary<string, bool> BoolBindingExpression { get; set; }
        public Dictionary<string, string> StringBindingExpression { get; set; }

        private bool DisableCatalogSearchingDocto = false;

        ReportesWebController _reportesWebController;

        private long TransaccionEnCurso = 0;

        public PuntoVentaDevoViewModel(
            //controller providers
            DoctoWebController doctoprovider,
            MovtoWebController movtoprovider,
            ClienteWebController clienteprovider,
            Sucursal_infoWebController sucursal_extprovider,
            ProductoWebController productoProvider,
            PuntoVentaDevoWebController puntoVentaDevoControllerProvider,
            PuntoVentaWebController puntoVenta_ControllerProvider,
            GlobalWebController globalControllerProvider,
            UsuarioWebController usuarioControllerProvider,
            //TicketstemplatesControllerProvider ticketstemplatesControllerProvider,
            InventarioWebController inventarioControllerProvider,
            //IImpoExpoControllerProvider impoExpoProvider,
            CorteWebController corteControllerProvider,
            ReportesWebController reportesWebController,
            //general windows parameters
            SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :

            base(
                selectorProvider, aggregator, winManager, messageBoxService, usuarioControllerProvider, corteControllerProvider)
        {

            //controller providers assign
            this.doctoProvider = doctoprovider;
            this.movtoProvider = movtoprovider;
            this.clienteProvider = clienteprovider;
            this.sucursal_extProvider = sucursal_extprovider;
            this.productoProvider = productoProvider;
            this.globalControllerProvider = globalControllerProvider;
            //this.ticketstemplatesControllerProvider = ticketstemplatesControllerProvider;
            this.inventarioControllerProvider = inventarioControllerProvider;
            //this.impoExpoProvider = impoExpoProvider;
            this.puntoVentaDevoControllerProvider = puntoVentaDevoControllerProvider;
            this.puntoVenta_ControllerProvider = puntoVenta_ControllerProvider;

            this._reportesWebController = reportesWebController;

            //suscribe to change events
            //this.aggregator = aggregator;
            this.aggregator.SubscribeOnUIThread(this);

            //fill catalogs configuration and autocomplete
            GlobalSession? bufferSession = GlobalVariable.CurrentSession;
            globalControllerProvider.llenarProductAutoCompleteList(ref bufferSession);
            fillCatalogConfiguration();


            //initialize clock
            initializeClock();


            BoolBindingExpression = new Dictionary<string, bool>();
            StringBindingExpression = new Dictionary<string, string>();
            fillBoolBindingExpressions();
            fillStringBindingExpressions();

            //Clear and initialize movtoitems
            MovtoItems = new ObservableCollection<V_movto_venddevoWFBindingModel>();
            MovtoItems.CollectionChanged += MovtoItems_CollectionChanged;
            MovtoToDevoItems = new ObservableCollection<V_movto_vend_to_devoWFBindingModel>();
            MovtoToDevoItems.CollectionChanged += MovtoToDevoItems_CollectionChanged;
            


        }


        public virtual async void ViewLoaded(EventArgs args)
        {
            await InitialState();
            ConfigureMovtoFields();

            //suscribe view to events
            aggregator.SubscribeOnUIThread(this.GetView());

            this.ManejaAlmacen = GlobalVariable.CurrentSession?.CurrentParametro?.Manejaalmacen == BoolCN.S;

            ChecarCorteActivo();
        }




        // Bool expresions

        private void fillBoolBindingExpressions()
        {
            try
            {
                var boolBindingExpression = new Dictionary<string, bool>();

                boolBindingExpression.Clear();

                boolBindingExpression.Add("NuevaVentaDevoVacia", this.currentDocto != null && (this.currentDocto.Id ?? 0) == 0 && this.currentDocto.Tipodoctoid == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO);
                
                boolBindingExpression.Add("TransaccionEnBorrador", this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_BORRADOR);
                boolBindingExpression.Add("TransaccionCompleta", this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_COMPLETO);
                boolBindingExpression.Add("TransaccionCancelada", this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_CANCELADA);
                boolBindingExpression.Add("DerechoCambiarAlmacen", (DerechosUsuario?[Model.DBValues._DERECHO_CAMBIARDEALMACEN] ?? false));
                boolBindingExpression.Add("ManejaAlmacen", !(GlobalSession?.CurrentParametro?.Manejaalmacen == BoolCN.S));
                boolBindingExpression.Add("ManejaReceta", !(GlobalSession?.CurrentParametro?.Manejareceta == BoolCN.S));

                boolBindingExpression.Add("HabilitarCancelar", this.currentDocto != null && (this.currentDocto.Id ?? 0) != 0 && this.currentDocto.Estatusdoctoid != DBValues._DOCTO_ESTATUS_CANCELADA);
                boolBindingExpression.Add("HabilitarPago", this.currentDocto != null && (this.currentDocto.Id ?? 0) != 0 && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_BORRADOR);
                boolBindingExpression.Add("HabilitarAlmacen", (DerechosUsuario?[Model.DBValues._DERECHO_CAMBIARDEALMACEN] ?? false) &&
                                                           this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_BORRADOR);
                

                boolBindingExpression.Add("EsFacturaElectronica", (this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_COMPLETO &&
                                                                    (this.currentDocto.Docto_fact_elect_Esfacturaelectronica ?? BoolCN.N) == BoolCN.S));
                boolBindingExpression.Add("HabilitarConvertirFE", (this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_COMPLETO &&
                                                                   this.currentDocto.Tipodoctoid == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO && (this.currentDocto.Docto_fact_elect_Esfacturaelectronica ?? BoolCN.N) == BoolCN.N));

                



                BoolBindingExpression = boolBindingExpression;

                NotifyOfPropertyChange("BoolBindingExpression");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        private void fillStringBindingExpressions()
        {
            var stringBindingExpression = new Dictionary<string, string>();

            stringBindingExpression.Clear();

            stringBindingExpression.Add("DataGridBackground",
                            (this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_BORRADOR ? "#FFFFFFFF" : "#EEEEEEEE"));


            StringBindingExpression = stringBindingExpression;

            NotifyOfPropertyChange("StringBindingExpression");
        }

        private void updateBoolBindingExpressions()
        {
            var boolBindingExpression = BoolBindingExpression;


            boolBindingExpression["NuevaVentaDevoVacia"] = this.currentDocto != null && (this.currentDocto.Id ?? 0) == 0 && this.currentDocto.Tipodoctoid == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO;
            

            boolBindingExpression["TransaccionEnBorrador"] = this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_BORRADOR;
            boolBindingExpression["TransaccionCompleta"] = this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_COMPLETO;
            boolBindingExpression["TransaccionCancelada"] = this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_CANCELADA;

            boolBindingExpression["HabilitarCancelar"] = this.currentDocto != null && (this.currentDocto.Id ?? 0) != 0 && this.currentDocto.Estatusdoctoid != DBValues._DOCTO_ESTATUS_CANCELADA;
            boolBindingExpression["HabilitarPago"] = this.currentDocto != null && (this.currentDocto.Id ?? 0) != 0 && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_BORRADOR;
            boolBindingExpression["HabilitarAlmacen"] = (DerechosUsuario?[Model.DBValues._DERECHO_CAMBIARDEALMACEN] ?? false) &&
                                                  this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_BORRADOR;
           


            boolBindingExpression["EsFacturaElectronica"] = ((this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_COMPLETO &&
                                                                (this.currentDocto.Docto_fact_elect_Esfacturaelectronica ?? BoolCN.N) == BoolCN.S));
            boolBindingExpression["HabilitarConvertirFE"] = ((this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_COMPLETO &&
                                                               this.currentDocto.Tipodoctoid == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO && (this.currentDocto.Docto_fact_elect_Esfacturaelectronica ?? BoolCN.N) == BoolCN.N));


            BoolBindingExpression = boolBindingExpression;

            NotifyOfPropertyChange("BoolBindingExpression");
        }


        private void updateStringBindingExpressions()
        {
            var stringBindingExpression = StringBindingExpression;

            stringBindingExpression["DataGridBackground"] = (this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_BORRADOR ? "#FFFFFFFF" : "#EEEEEEEE");

            StringBindingExpression = stringBindingExpression;

            NotifyOfPropertyChange("StringBindingExpression");
        }


        //clear methods
        //clear all info in model
        public DoctoBindingModel EmptyDocto(long? tipoDoctoId = null)
        {
            var docto = new DoctoBindingModel()
            {
                EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid,
                Id = 0,
                Tipodoctoid = tipoDoctoId
            };
            return docto;
        }

        public async Task ClearInfo()
        {

            CurrentDocto = EmptyDocto(Model.DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO);

            ClearMovto();

            ClearProducto();

            ClearMovtoItems();

            ClearMovtoToDevoItems();

            ConfigureCajasBotellas();

            await AssignClientInfo();
        }

        private void ClearProducto()
        {

            CurrentProducto = new ProductoBindingModel();
            CurrentProducto.EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid;
            CurrentProducto.SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid;


            if (CurrentMovto != null)
                CurrentMovto.Productoid = 0;
        }

        private async Task InitialState()
        {
            await ClearInfo();
        }


        public void ClearMovtoToDevoItems()
        {
            this.MovtoToDevoItems.Clear();
        }

        public void ClearMovtoItems()
        {
            MovtoItems.Clear();
        }


        public void ClearMovto()
        {

            CurrentMovto = new MovtoBindingModel();
            CurrentMovto.EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid;
            CurrentMovto.SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid;
            CurrentMovto.Estatusmovtoid = Model.DBValues._MOVTO_ESTATUS_BORRADOR;
            CurrentMovto.Cantidad = 0;
            CurrentMovto.Precio = 0;
            CurrentMovto.Descuento = 0;
            Cajas = 0;
            ClearListaPrecios();



        }

        public async Task NuevaVenta()
        {

            DisableCatalogSearchingDocto = true;

            await ClearInfo();

            CurrentDocto = new DoctoBindingModel();


            CurrentDocto.Referencia = "";
            CurrentDocto.Referencias = "";
            CurrentDocto.Docto_apartado_Mercanciaentregada = BoolCN.S;
            CurrentDocto.Docto_info_pago_Pagocontarjeta = TipoPagoConTarjeta.N;
            CurrentDocto.Docto_info_pago_Pagoacredito = BoolCN.N;
            CurrentDocto.Docto_promocion_Promocion = BoolCN.N;
            CurrentDocto.EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid;
            CurrentDocto.SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid;


            CurrentDocto.Estatusdoctoid = Model.DBValues._DOCTO_ESTATUS_BORRADOR;
            CurrentDocto.Usuarioid = GlobalVariable.CurrentSession?.CurrentUsuario?.Id;
            CurrentDocto.UsuarioNombre = GlobalVariable.CurrentSession?.CurrentUsuario?.Nombre;
            CurrentDocto.Fecha = DateTimeOffset.Now.Date;
            CurrentDocto.Cajaid = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Cajaid;
            CurrentDocto.Almacenid = GlobalVariable.CurrentSession?.CurrentParametro?.Almacenrecepcionid;
            CurrentDocto.Origenfiscalid = Model.DBValues._ORIGENFISCAL_REMISIONADO;
            CurrentDocto.Doctoparentid = null;
            CurrentDocto.Clienteid = Model.DBValues._CLIENTEMOSTRADOR;
            CurrentDocto.Tipodoctoid = Model.DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO;
            CurrentDocto.Sucursal_id = GlobalSession?.CurrentSucursalInfo?.Id;
            CurrentDocto.Docto_traslado_Sucursaltid = CurrentDocto.Sucursal_id;
            CurrentDocto.Docto_traslado_Almacentid = CurrentDocto.Almacenid;



            PuntoVentaToDevoListViewModel vm = IoC.Get<PuntoVentaToDevoListViewModel>();
            vm.IsSelectionMode = true;
            vm.ListParam = new V_docto_vend_to_devoParamWFBindingModel()
            {
                P_empresaid = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                P_sucursalid = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid,
                P_usuarioid = GlobalVariable.CurrentSession!.CurrentUsuario!.Id,
                _usuarioclave = GlobalVariable.CurrentSession!.CurrentUsuario!.Clave,
                P_usuarionombre = GlobalVariable.CurrentSession!.CurrentUsuario!.Nombre,
                //P_corteactivo = "N",
                P_estatusdoctoid = 1,
                P_tipodoctoid = 21,
                P_fechaini = DateTime.Today.AddDays(-365),
                P_fechafin = DateTime.Today//,
                //P_cajeroid = 0,
                //P_clienteid = 0
            };
            winManager.ShowDialogAsync(vm, null, CreateWinSettings("Ventas a devolver", 0.75));

            if (vm.SelectedItem != null && vm.SelectedItem.Id != null)
            {

                CurrentDocto.Clienteid = vm.SelectedItem.Clienteid;
                CurrentDocto.Docto_devolucion_Doctorefid = vm.SelectedItem.Id;

                PuntoVentaDevoBindingModel? puntoVentaDevoBindingModel = null;

                puntoVentaDevoBindingModel = await this.puntoVentaDevoControllerProvider.GetInitialDocumentInfoFromRef(new PuntoVentaDevoBindingModel()
                {
                    CurrentDocto = this.currentDocto

                });

                if (puntoVentaDevoBindingModel?.BaseResultBindingModel != null && puntoVentaDevoBindingModel.BaseResultBindingModel.Result >= 0)
                {
                    CurrentDocto.Almacenid = puntoVentaDevoBindingModel.CurrentDocto!.Almacenid;
                    CurrentDocto.Origenfiscalid = puntoVentaDevoBindingModel.CurrentDocto!.Origenfiscalid;

                    CurrentDoctoRef = puntoVentaDevoBindingModel.CurrentDoctoRef;


                    MovtoToDevoItems.Clear();
                    if (puntoVentaDevoBindingModel.MovtoToDevoItems != null)
                    {
                        foreach (var item in puntoVentaDevoBindingModel.MovtoToDevoItems)
                        {
                            MovtoToDevoItems.Add(item);
                        }
                    }

                    CurrentCliente = puntoVentaDevoBindingModel.CurrentCliente;

                    if (currentDocto != null && CurrentCliente != null && this.DisableCatalogSearchingDocto)
                    {
                        currentDocto.ClienteClave = CurrentCliente.Clave;
                        currentDocto.ClienteNombre = CurrentCliente.Nombre;
                    }

                    updateBoolBindingExpressions();
                    updateStringBindingExpressions();

                }


            }



            DisableCatalogSearchingDocto = false;

        }


        //configuration

        private void ConfigureMovtoFields()
        {

            var parametroCajasBotellas = GlobalVariable.CurrentSession?.CurrentParametro?.Cajasbotellas == BoolCN.S;
            bool? parametroCompraConCantidad = true;//BIPOS.Models.Parametros.GetBoolFromClaveAndList(GlobalVariable.CurrentSession.CurrentParametros, "uicompraconcantidad");

            CantidadEnabled = (parametroCompraConCantidad != null && parametroCompraConCantidad.Value) || (parametroCajasBotellas && parametroCajasBotellas);
            PrecioEnabled = DerechosUsuario?[Model.DBValues._DERECHO_CAMBIARPRECIO_VENTA] ?? false;
            DescuentoEnabled = DerechosUsuario?[Model.DBValues._DERECHO_CAMBIARDESCUENTO_VENTA] ?? false;
            ListaPrecioEnabled = false; //DerechosUsuario[Model.DBValues._DERECHO_CAMBIARPRECIOXLISTA_VENTA];



        }
        private void ConfigureCajasBotellas()
        {
            var parametroCajasBotellas = GlobalVariable.CurrentSession?.CurrentParametro?.Cajasbotellas == BoolCN.S;
            var currentProductUnitIsKg = currentProducto != null && currentProducto.UnidadClave != null && currentProducto.UnidadClave.ToUpper().Equals("KG");
            CajasBotellasActive = (parametroCajasBotellas && !currentProductUnitIsKg);
        }
        protected override void fillCatalogConfiguration()
        {


            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("CurrentDocto","Cliente","Clienteid", "ClienteClave", "ClienteNombre","IposV3.ViewModels.ClienteListViewModel","SelectedItem","Clave","Nombre"),
                                          new CatalogRelatedFields("CurrentDocto","Sucursal_ext","Sucursaltid", "SucursaltClave", "SucursaltNombre","IposV3.ViewModels.Sucursal_extListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("CurrentDocto","Usuario","Usuarioid", "Usuariousername", "UsuarioNombre","IposV3.ViewModels.UsuarioListViewModel","SelectedItem","Username","Persona_nombre"),
                                          new CatalogRelatedFields("CurrentDocto","Estatusdocto","Estatusdoctoid", "EstatusdoctoClave", "EstatusdoctoNombre","IposV3.ViewModels.EstatusdoctoListViewModel","SelectedItem","Clave")//,
                                          //new CatalogRelatedFields("CurrentDocto","Tipodocto","Tipodoctoid", "TipodoctoClave", "TipodoctoNombre","IposV3.ViewModels.TipodoctoListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>()
            {
                new CatalogDef("Almacen"),
                new CatalogDef("Origenfiscal")
            };

            Task.Run(async () =>
            {
                Catalogs = await selectorProvider.ObtainCatalogs(lstCatalogDef, new BaseParam(GlobalVariable.CurrentSession!.Empresaid, GlobalVariable.CurrentSession.Sucursalid));
            }).Wait();

        }


        //other initializations
        private void initializeClock()
        {
            CurrentDateTime_ = DateTime.Now;
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 1, 0), DispatcherPriority.Normal, delegate
            {
                CurrentDateTime_ = DateTime.Now;
            }, System.Windows.Application.Current.Dispatcher);
            timer.Start();
        }

        protected override List<long> DerechosToCheck()
        {

            return new List<long>{ Model.DBValues._DERECHO_CAMBIARPRECIO_VENTA ,
                                   Model.DBValues._DERECHO_CAMBIARDESCUENTO_VENTA,
                                   Model.DBValues._DERECHO_CAMBIARPRECIOXLISTA_VENTA,
                                    Model.DBValues._DERECHO_DEVOLUCIONAPROV_CONSULTA,
                                    Model.DBValues._DERECHO_CAMBIARDEALMACEN};
        }


        //Loading data methods
        //loading docto
        public async Task LoadVenta(long doctoId)
        {
            await ClearInfo();
            //ClearMovtoItems();
            //ClearMovtoToDevoItems();

            CurrentDocto!.Id = doctoId;

            try
            {

                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";

                await LoadDoctoFullInfo();
                IsBusy = false;


                BProcessSuccess = bSuccess;
                if (!BProcessSuccess)
                {
                    ErrorEditActions(comentario);
                }

                updateBoolBindingExpressions();
                updateStringBindingExpressions();

            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }





        }



        public async Task LoadDoctoFullInfo()
        {
            PuntoVentaDevoBindingModel? puntoVentaDevoBindingModel = null;

            puntoVentaDevoBindingModel = await this.puntoVentaDevoControllerProvider.GetDocumentInfo(new PuntoVentaDevoBindingModel()
            {
                CurrentDocto = this.currentDocto

            });

            if (puntoVentaDevoBindingModel?.BaseResultBindingModel != null && puntoVentaDevoBindingModel.BaseResultBindingModel.Result >= 0)
            {
                CurrentDocto = puntoVentaDevoBindingModel.CurrentDocto;
                CurrentDoctoRef = puntoVentaDevoBindingModel.CurrentDoctoRef;

                MovtoItems.Clear();
                foreach (var item in puntoVentaDevoBindingModel.MovtoItems)
                {
                    MovtoItems.Add(item);
                }

                MovtoToDevoItems.Clear();
                if (puntoVentaDevoBindingModel.MovtoToDevoItems != null)
                {
                    foreach (var item in puntoVentaDevoBindingModel.MovtoToDevoItems)
                    {
                        MovtoToDevoItems.Add(item);
                    }
                }

                CurrentCliente = puntoVentaDevoBindingModel.CurrentCliente;

                if (currentDocto != null && CurrentCliente != null && this.DisableCatalogSearchingDocto)
                {
                    currentDocto.ClienteClave = CurrentCliente.Clave;
                    currentDocto.ClienteNombre = CurrentCliente.Nombre;
                }

            }
        }



        //loading movto items
        public async Task<List<V_movto_venddevoWFBindingModel>> DoGetMovtoItems(long doctoId)
        {
            List<V_movto_venddevoWFBindingModel> results = new List<V_movto_venddevoWFBindingModel>();

            results = await puntoVentaDevoControllerProvider.Select_V_movto_venddevo_List(
                                        GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
                                        GlobalVariable.CurrentSession.CurrentConfiguracion.Sucursalid!.Value,
                                        doctoId
                                        ) ?? results;

            return results;

        }


        public async Task<List<V_movto_vend_to_devoWFBindingModel>> DoGetMovtoToDevoItems(long doctoId, long doctoRefId)
        {
            List<V_movto_vend_to_devoWFBindingModel> results = new List<V_movto_vend_to_devoWFBindingModel>();


            results = await puntoVentaDevoControllerProvider.Select_V_movto_vend_to_devo_List(
                                    GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
                                    GlobalVariable.CurrentSession.CurrentConfiguracion.Sucursalid!.Value,
                                    doctoId,
                                    doctoRefId
                                    ) ?? results;

            return results;
        }


        //complete info
        public async Task AssignClientInfo()
        {

            if (CurrentDocto?.Clienteid.HasValue != true || CurrentDocto!.Clienteid!.Value == 0)
            {
                CurrentCliente = new ClienteBindingModel();
                return;
            }


            ClienteBindingModel? buffer = null;


            buffer = await clienteProvider.GetById(new ClienteBindingModel()
            {
                Id = CurrentDocto.Clienteid.Value,
                EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid

            });

            CurrentCliente = buffer;

            if (currentDocto != null && buffer != null && this.DisableCatalogSearchingDocto)
            {
                currentDocto.ClienteClave = buffer.Clave;
                currentDocto.ClienteNombre = buffer.Nombre;
            }


        }


        private void DoAssignProducto(ProductoBindingModel? buffer)
        {


            currentProducto = buffer;

            if (currentProducto == null)
            {
                CurrentProducto = new ProductoBindingModel();
                CurrentMovto!.DescripcionProductoMovto = "";
            }
            else
            {
                CurrentMovto!.DescripcionProductoMovto = currentProducto!.Nombre + " // " +
                                                        currentProducto!.Descripcion + " // " +
                                                        currentProducto!.Descripcion1 + " // " +
                                                        currentProducto!.Producto_existencia_Existencia;


            }
        }


        //opening transaction
        public async Task AbrirVentaCerrada()
        {
            await AbrirVenta(false);
        }

        public async Task AbrirVentaPendiente()
        {
            await AbrirVenta(true);
        }

        public async Task AbrirVenta(bool borrador)
        {

            PuntoVentaDevoListViewModel vm = IoC.Get<PuntoVentaDevoListViewModel>();
            vm.IsSelectionMode = true;
            vm.ListParam = new V_docto_venddevoParamWFBindingModel()
            {
                P_empresaid = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                P_sucursalid = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid,
                P_usuarioid = GlobalVariable.CurrentSession!.CurrentUsuario!.Id,
                _usuarioclave = GlobalVariable.CurrentSession!.CurrentUsuario!.Clave,
                P_usuarionombre = GlobalVariable.CurrentSession!.CurrentUsuario!.Nombre,
                //P_corteactivo = "N",
                P_estatusdoctoid = borrador ? Model.DBValues._DOCTO_ESTATUS_BORRADOR : Model.DBValues._DOCTO_ESTATUS_COMPLETO,
                P_tipodoctoid = Model.DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO,
                P_fechaini = DateTime.Today.AddDays(-365),
                P_fechafin = DateTime.Today//,
                //P_cajeroid = 0,
                //P_clienteid = 0
            };
            winManager.ShowDialogAsync(vm, null, CreateWinSettings("Notas de credito", 0.75));


            if (vm.selectedItem != null && vm.selectedItem.Id != null)
            {
                await LoadVenta(vm.selectedItem.Id.Value);
            }
            else
            {

                updateBoolBindingExpressions();
                updateStringBindingExpressions();
            }

            //Temporal 
            //LoadVenta(79);
        }



        //main entities property changing

        protected void DoctoPropertyChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                default:
                    break;
            }

        }

        public async void DoctoPendingChangeEventHandler(object sender, AcceptPendingChangeEventArgs e)
        {

            switch (e.PropertyName)
            {
                case "Clienteclave":
                    if (this.DisableCatalogSearchingDocto)
                        return;

                    CatalogField_PropertyChanging(sender, e);
                    if (!e.CancelPendingChange && e.NewValue != e.OldValue)
                    {
                        await AssignClientInfo();
                    }
                    break;

                default:
                    if (this.DisableCatalogSearchingDocto)
                        return;

                    CatalogField_PropertyChanging(sender, e);
                    break;
            }
        }


        protected async void MovtoPropertyChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {

                case "ProductoClave":
                    {
                       await this.DecipherCommand(currentMovto?.ProductoClave, true);
                    }
                    break;


                case "Precio":
                    {

                        if (CurrentMovto?.Productoid == null || CurrentMovto.Productoid == 0)
                            return;

                        await this.AssignPrecioDescuentos(currentMovto?.Precio, null);
                    }
                    break;

                case "Descuentoporcentaje":
                    {

                        if (CurrentMovto?.Productoid == null || CurrentMovto.Productoid == 0)
                            return;

                        await this.AssignPrecioDescuentos(null, currentMovto?.Descuentoporcentaje);
                    }
                    break;

                default:
                    break;
            }

        }

        public void MovtoPendingChangeEventHandler(object sender, AcceptPendingChangeEventArgs e)
        {

            switch (e.PropertyName)
            {

                default:
                    CatalogField_PropertyChanging(sender, e);
                    break;
            }
        }



        //key event handlers
        public async Task ControlKeyDown(KeyEventArgs keyArgs)
        {
            Key key = keyArgs.Key;

            switch(key)
            {
                case Key.F3:
                    await CancelarDocto();
                    break;
                case Key.F2:
                    await NuevaVenta();
                    break;
                case Key.F4:
                    await AbrirVentaPendiente();
                    break;
                case Key.F5:
                    await AbrirVentaCerrada();
                    break;
                case Key.F6:
                    await Pagar();
                    break;
                case Key.System:
                    if(keyArgs.SystemKey == Key.F10)
                    {

                    }
                    break;


                case (Key.F12):
                    {
                        if (Keyboard.Modifiers == ModifierKeys.Control)
                        {
                            if (this.currentDocto != null && currentDocto.Estatusdoctoid.In(0, 1) &&
                                this.currentDocto.Id != null && this.currentDocto.Id != 0 &&
                                (this.currentDocto.Docto_fact_elect_Timbradouuid == null || this.currentDocto.Docto_fact_elect_Timbradouuid.Length == 0))
                            {

                                if (await Facturar(this.currentDocto.Id.Value))
                                {

                                    MessageBox.Show("Se facturo");
                                    //imprimirFacturaElectronica();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo facturar");
                                }


                            }
                            else
                            {

                                MessageBox.Show("No hay documento a facturar o ya se facturo");
                            }
                        }
                        break;
                    }

            }
        }





        //calculation prices
        private async Task<decimal> PrecioCalculado(long? empresaId, long? sucursalId, long? productoId, long clienteId, decimal cantidad, long sucursalTid)
        {
            decimal precioCalculado = 0;
            //fnc_preciosprod_ref_provParam.P_sucursaltid = sucursalTid;

            V_preciosProd_RefBindingModel? fnc_preciosprod_ref_provResult = null;

            fnc_preciosprod_ref_provResult = await puntoVenta_ControllerProvider.Precioprod_ref_vend(empresaId!.Value, sucursalId!.Value, productoId!.Value, clienteId, cantidad);

            if (fnc_preciosprod_ref_provResult != null && fnc_preciosprod_ref_provResult.Preciolista != null)
                precioCalculado = fnc_preciosprod_ref_provResult.Preciolista.Value;
            else
                precioCalculado = 0;

            return precioCalculado;
        }

        private decimal PrecioBaseSinImpuestos(long? empresaId, long? sucursalId, long? productoId, long clienteId, decimal cantidad, decimal precioCalculado, long sucursalTid, ProductoBindingModel producto)
        {
            var tipodescuentoprodid = GlobalVariable.CurrentSession?.CurrentParametro?.Tipodescuentoprodid;
            decimal dPrecioBaseSinImpuestos = 0;

            dPrecioBaseSinImpuestos = tipodescuentoprodid == 2 ? precioCalculado : (producto.Producto_precios_Precio1 ?? 0m);
            return dPrecioBaseSinImpuestos;
        }

        private async Task<(decimal?,decimal?)> AssignPrecioDescuentosOut(long? empresaId, long? sucursalId, decimal? precio, 
                                                                        decimal? descuento, long? productoId, long clienteId, 
                                                                        decimal cantidad, bool precionetoenpv, 
                                                                        ProductoBindingModel producto)
        {


            var precio_final = precio;
            var descuento_final = descuento;

            decimal precioCalculado = 0;
            decimal dPrecioBaseSinImpuestos = 0;
            bool precioEnBaseADescuento = precio == null && descuento != null;
            bool precioPorCalcular = precio == null && descuento == null;

            decimal precioAMostrar = 0m;
            decimal descuentoAMostrar = 0m;

            precioCalculado = await PrecioCalculado(GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                                              GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid,
                                              productoId, clienteId,
                                              cantidad, 0);

            dPrecioBaseSinImpuestos = PrecioBaseSinImpuestos(empresaId,
                                              sucursalId,
                                              productoId, clienteId,
                                              cantidad, precioCalculado, 0, producto);

            if (precioEnBaseADescuento)
            {
                precioAMostrar = (precioCalculado * ((100 - descuento!.Value) / 100));
                descuentoAMostrar = descuento!.Value;
            }
            else
            {
                if (precioPorCalcular)
                    precioAMostrar = precioCalculado;
                else
                {
                    if (!precionetoenpv)
                        precioAMostrar = producto.calculaPrecioSinImpuestos(precio!.Value);
                    else
                        precioAMostrar = precio!.Value;

                }


                descuentoAMostrar = 100.00m - ((100.00m * precioAMostrar) / dPrecioBaseSinImpuestos);
            }

            if (!precionetoenpv)
                precioAMostrar = producto.calculaPrecioConImpuestos(precioAMostrar);

            if (precioEnBaseADescuento || precioPorCalcular)
                precio_final = precioAMostrar;

            if (!precioEnBaseADescuento)
                descuento_final = descuentoAMostrar;

            return (precio_final, descuento_final);

        }

        private async Task AssignPrecioDescuentos(decimal? precio, decimal? descuento) //(long productoId, long clienteId, decimal cantidad)
        {
            var precionetoenpv = GlobalVariable.CurrentSession?.CurrentParametro?.Precionetoenpv;

            decimal? precio_final = precio;
            decimal? descuento_final = descuento;

            var bufferPrecioDescuentoFinal = await AssignPrecioDescuentosOut(GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                                              GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid,
                                              precio, descuento,
                                              CurrentProducto?.Id, CurrentCliente!.Id!.Value,
                                              CurrentMovto!.Cantidad!.Value, precionetoenpv == BoolCN.S, CurrentProducto!);
            precio_final = bufferPrecioDescuentoFinal.Item1;
            descuento_final = bufferPrecioDescuentoFinal.Item2;



            CurrentMovto._Precio = precio_final;
            CurrentMovto._Descuentoporcentaje = descuento_final;
            NotifyOfPropertyChange("CurrentMovto");


        }

        private void AssignListaPrecios(ProductoBindingModel prod)
        {
            if (prod == null)
                return;

            ClearListaPrecios();
            var precionetoenpv = GlobalVariable.CurrentSession?.CurrentParametro?.Precionetoenpv;
            decimal precio1 = precionetoenpv == BoolCN.S ? prod.Producto_precios_Precio1 ?? 0m : prod.calculaPrecioConImpuestos(prod.Producto_precios_Precio1 ?? 0m);
            decimal precio2 = precionetoenpv == BoolCN.S ? prod.Producto_precios_Precio2 ?? 0m : prod.calculaPrecioConImpuestos(prod.Producto_precios_Precio2 ?? 0m);
            decimal precio3 = precionetoenpv == BoolCN.S ? prod.Producto_precios_Precio3 ?? 0m : prod.calculaPrecioConImpuestos(prod.Producto_precios_Precio3 ?? 0m);
            decimal precio4 = precionetoenpv == BoolCN.S ? prod.Producto_precios_Precio4 ?? 0m : prod.calculaPrecioConImpuestos(prod.Producto_precios_Precio4 ?? 0m);
            decimal precio5 = precionetoenpv == BoolCN.S ? prod.Producto_precios_Precio5 ?? 0m : prod.calculaPrecioConImpuestos(prod.Producto_precios_Precio5 ?? 0m);
            decimal precio6 = precionetoenpv == BoolCN.S ? prod.Producto_precios_Precio6 ?? 0m : prod.calculaPrecioConImpuestos(prod.Producto_precios_Precio6 ?? 0m);

            Dictionary<string, decimal> listPrecios = new Dictionary<string, decimal>();
            listPrecios.Add("Precio 1: " + precio1.ToString("N2"), precio1);
            listPrecios.Add("Precio 2: " + precio2.ToString("N2"), precio2);
            listPrecios.Add("Precio 3: " + precio3.ToString("N2"), precio3);
            listPrecios.Add("Precio 4: " + precio4.ToString("N2"), precio4);
            listPrecios.Add("Precio 5: " + precio5.ToString("N2"), precio5);
            listPrecios.Add("Precio 6: " + precio6.ToString("N2"), precio6);
            ListaPrecios = listPrecios;
        }

        public void ClearListaPrecios()
        {
            ListaPrecios = new Dictionary<string, decimal>();

            selectedListPrice = 0;
            NotifyOfPropertyChange(() => this.ListaPrecios);
        }


        //movto event handlers
        public virtual void ProductoKeyDown(KeyEventArgs keyArgs)
        {
            Key key = keyArgs.Key;
            if (key == Key.Enter && Interlocked.Read(ref this.TransaccionEnCurso) <= 0)
            {
                keyArgs.Handled = true;

                if (currentProducto == null || currentProducto.Id == null || currentProducto.Id == 0)
                {
                    this.MostrarLookUpDeProducto();
                }


            }
        }

        private void MostrarLookUpDeProducto()
        {

            ProductoListViewModel vm = IoC.Get<ProductoListViewModel>();
            vm.IsSelectionMode = true;
            vm.KendoParams!.GeneralFilter!.Value = CurrentMovto!.ProductoClave;
            winManager.ShowDialogAsync(vm, null, CreateWinSettings("Productos", 0.75));


            if (vm.selectedItem != null && vm.selectedItem.Id != null)
            {
                CurrentMovto.ProductoClave = vm.selectedItem.Clave;
            }
        }

        public async Task CantidadKeyDown(KeyEventArgs keyArgs)
        {
            Key key = keyArgs.Key;
            if (key == Key.Enter)
            {
                await SaveMovto(null);
            }
        }

        public async Task PrecioKeyDown(KeyEventArgs keyArgs)
        {

            Key key = keyArgs.Key;
            if (key == Key.Enter)
            {
                await SaveMovto(null);
            }
            else if (key == Key.Down)
            {
                //selectedListPrice = CurrentMovto?.Precio != null ? CurrentMovto.Precio.Value : 0;
                //NotifyOfPropertyChange(() => this.SelectedListPrice);
                ListaPrecioEnabled = DerechosUsuario![Model.DBValues._DERECHO_CAMBIARPRECIOXLISTA_VENTA];
                OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoVentaUICommParams("SetFocus", new List<string>() { "P_precioLista" })), TimeSpan.FromMilliseconds(100));
            }
        }

        public virtual void ListPriceLostFocus()
        {
            ListaPrecioEnabled = false;
        }
        private void OnListPriceChanged()
        {
            //if (!ListaPrecioEnabled)
            //   return;

            CurrentMovto!.Precio = selectedListPrice;
            ListaPrecioEnabled = false;
            OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoVentaUICommParams("SetFocus", new List<string>() { "CurrentMovto.Precio" })), TimeSpan.FromMilliseconds(100));
        }

        public async Task DescuentoporcentajeKeyDown(KeyEventArgs keyArgs)
        {
            Key key = keyArgs.Key;
            if (key == Key.Enter)
            {
                await SaveMovto(null);
            }
        }


        //Decipher producto command
        private async Task<(bool, string)> DecipherCommand(string? commandText, bool abrirPopUpProductoSiEsNecesario = false)
        {
            if (Interlocked.Read(ref this.TransaccionEnCurso) > 0)
                return(false, "");


            Interlocked.Increment(ref TransaccionEnCurso);


            long empresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid ?? 0;
            long sucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid ?? 0;
            ClearProducto();

            var outMessage = "";
            bool cancelPendingChange = false;
            CurrentMovto!.DescripcionProductoMovto = "";

            bool saveMovto =  !CajasBotellasActive && !CantidadEnabled && !PrecioEnabled && !DescuentoEnabled;

            try
            {
                if (commandText == null || commandText.Trim().Length == 0)
                {

                    return (cancelPendingChange, outMessage);
                }


                PuntoVentaDevoBindingModel? puntoVentaBindingModel = null;

                puntoVentaBindingModel = await this.puntoVentaDevoControllerProvider.DecipherCommand(
                                                                            empresaId, sucursalId, commandText, GlobalVariable.CurrentSession?.CurrentParametro?.Precionetoenpv,
                                                                            GlobalVariable.CurrentSession?.CurrentParametro?.Tipodescuentoprodid, saveMovto, manejAlmacen, currentDocto, GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value);



                if (puntoVentaBindingModel == null || puntoVentaBindingModel.DecipherResult == null)
                {
                    cancelPendingChange = true;
                    outMessage = "No se pudo encontrar el producto";
                    return (cancelPendingChange, outMessage);
                }

                if (puntoVentaBindingModel.DecipherResult.Productoid == null || puntoVentaBindingModel.DecipherResult.Productoid == 0)
                {
                    string errorMessage = puntoVentaBindingModel.DecipherResult.Usermessage != null ?
                                          puntoVentaBindingModel.DecipherResult.Usermessage : "No se pudo encontrar el producto";

                    cancelPendingChange = true;
                    outMessage = errorMessage;
                    return (cancelPendingChange, outMessage);
                }

                if (!saveMovto || (saveMovto && (puntoVentaBindingModel.BaseResultBindingModel.Result ?? 0) < 0))
                {


                    CurrentMovto.Cantidad = puntoVentaBindingModel.CurrentMovto?.Cantidad;
                    CurrentMovto.Productoid = puntoVentaBindingModel.CurrentProducto?.Id;

                    DoAssignProducto(puntoVentaBindingModel.CurrentProducto);


                    CurrentMovto._Precio = puntoVentaBindingModel.CurrentMovto?.Precio;
                    CurrentMovto._Descuentoporcentaje = puntoVentaBindingModel.CurrentMovto?.Descuentoporcentaje;

                    await AssignPrecioDescuentos(null, null);
                    AssignListaPrecios(currentProducto!);
                    ConfigureCajasBotellas();

                    if (CajasBotellasActive)
                        OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoVentaUICommParams("SetFocus", new List<string>() { "Cajas" })), TimeSpan.FromMilliseconds(100));
                    else if (CantidadEnabled)
                        OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoVentaUICommParams("SetFocus", new List<string>() { "CurrentMovto.Cantidad" })), TimeSpan.FromMilliseconds(100));
                    else if (PrecioEnabled)
                        OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoVentaUICommParams("SetFocus", new List<string>() { "CurrentMovto.Precio" })), TimeSpan.FromMilliseconds(100));
                    else if (DescuentoEnabled)
                        OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoVentaUICommParams("SetFocus", new List<string>() { "CurrentMovto.Descuento" })), TimeSpan.FromMilliseconds(100));


                    if (saveMovto)
                    {
                        await SaveMovto(null);
                    }
                }
                else
                {


                    if (puntoVentaBindingModel.BaseResultBindingModel != null && puntoVentaBindingModel.BaseResultBindingModel.Result >= 0)
                    {
                        CurrentDocto = puntoVentaBindingModel.CurrentDocto;
                        MovtoItems.Clear();
                        foreach (var item in puntoVentaBindingModel.MovtoItems)
                        {
                            MovtoItems.Add(item);
                        }

                        MovtoToDevoItems.Clear();
                        foreach (var item in puntoVentaBindingModel.MovtoToDevoItems)
                        {
                            MovtoToDevoItems.Add(item);
                        }


                        ClearMovto();
                        ClearProducto();

                        updateBoolBindingExpressions();
                        updateStringBindingExpressions();

                        OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoVentaUICommParams("SetFocus", new List<string>() { "CurrentMovto.Productoclave" })), TimeSpan.FromMilliseconds(100));


                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {


                while (Interlocked.Read(ref this.TransaccionEnCurso) > 0)
                    Interlocked.Decrement(ref this.TransaccionEnCurso);

                if (abrirPopUpProductoSiEsNecesario)
                {
                    if (currentProducto == null || currentProducto.Id == null || currentProducto.Id == 0)
                    {
                        this.MostrarLookUpDeProducto();

                    }
                }

            }

            return (cancelPendingChange, outMessage);


        }

        //Save movto

        public async Task<bool> SaveMovtoToDevoFromGrid(V_movto_vend_to_devoWFBindingModel movtoItem, string propertyChanged, object newVal)
        {


            var precionetoenpv = GlobalVariable.CurrentSession?.CurrentParametro?.Precionetoengrids;
            if (precionetoenpv == null)
                precionetoenpv = BoolCN.S;


            var Fnc_movto_venddevo_insertParam = new MovtoVenddevoTrans();

            Fnc_movto_venddevo_insertParam.Fechavence = movtoItem.Fechavence;
            Fnc_movto_venddevo_insertParam.Loteimportado = movtoItem.Loteimportado;
            Fnc_movto_venddevo_insertParam.Movtoparentid = null;
            Fnc_movto_venddevo_insertParam.Agrupaporparametro = BoolCN.N;
            Fnc_movto_venddevo_insertParam.Cargartarjetapreciomanual = BoolCN.N;
            Fnc_movto_venddevo_insertParam.Precioyavalidado = BoolCN.N;
            Fnc_movto_venddevo_insertParam.Usuarioid = GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value;

            Fnc_movto_venddevo_insertParam.Lote = movtoItem.Lote;
            Fnc_movto_venddevo_insertParam.Localidad = null;//movtoItem.Localidad;
            Fnc_movto_venddevo_insertParam.Descripcion1 = movtoItem.Descripcion1;
            Fnc_movto_venddevo_insertParam.Descripcion2 = movtoItem.Descripcion2;
            Fnc_movto_venddevo_insertParam.Descripcion3 = movtoItem.Descripcion3;
            Fnc_movto_venddevo_insertParam.Empresaid = movtoItem.EmpresaId!.Value;
            Fnc_movto_venddevo_insertParam.Sucursalid = movtoItem.SucursalId!.Value;
            Fnc_movto_venddevo_insertParam.Movtoadevolverid = movtoItem.Movtorefid;
            Fnc_movto_venddevo_insertParam.Id = movtoItem.Movtoid;
            Fnc_movto_venddevo_insertParam.Doctoid = currentDocto!.Id!.Value;
            Fnc_movto_venddevo_insertParam.Partida = movtoItem.Partida;
            Fnc_movto_venddevo_insertParam.Estatusmovtoid = Model.DBValues._MOVTO_ESTATUS_BORRADOR;
            Fnc_movto_venddevo_insertParam.Productoid = movtoItem.Productoid!.Value;

            Fnc_movto_venddevo_insertParam.Precio = movtoItem.Preciounidadref;


            switch (propertyChanged)
            {
                case "Cantidad":
                    {
                        Fnc_movto_venddevo_insertParam.Cantidad = (decimal?)((decimal)newVal - (movtoItem.Cantidad ?? 0m)) ?? 0m;
                        Fnc_movto_venddevo_insertParam.Precio = movtoItem.Preciounidadref;
                        //Fnc_movto_venddevo_insertParam.Descuentoporcentaje = null;
                        break;
                    }


            }


            await SaveMovto(Fnc_movto_venddevo_insertParam);


            return true;
        }

        public async Task<bool> SaveMovtoFromGrid(V_movto_venddevoWFBindingModel movtoItem, string propertyChanged, object newVal)
        {


            var precionetoenpv = GlobalVariable.CurrentSession?.CurrentParametro?.Precionetoengrids;
            if (precionetoenpv == null)
                precionetoenpv = BoolCN.S;

            var Fnc_movto_venddevo_insertParam = new MovtoVenddevoTrans();



            Fnc_movto_venddevo_insertParam.Fechavence = movtoItem.Fechavence;
            Fnc_movto_venddevo_insertParam.Loteimportado = movtoItem.Loteimportado;
            Fnc_movto_venddevo_insertParam.Movtoparentid = null;
            Fnc_movto_venddevo_insertParam.Agrupaporparametro = BoolCN.N;
            Fnc_movto_venddevo_insertParam.Cargartarjetapreciomanual = BoolCN.N;
            Fnc_movto_venddevo_insertParam.Precioyavalidado = BoolCN.N;
            Fnc_movto_venddevo_insertParam.Usuarioid = GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value;

            Fnc_movto_venddevo_insertParam.Lote = movtoItem.Lote;
            Fnc_movto_venddevo_insertParam.Localidad = null;//movtoItem.Localidad;
            Fnc_movto_venddevo_insertParam.Descripcion1 = movtoItem.Descripcion1;
            Fnc_movto_venddevo_insertParam.Descripcion2 = movtoItem.Descripcion2;
            Fnc_movto_venddevo_insertParam.Descripcion3 = movtoItem.Descripcion3;
            Fnc_movto_venddevo_insertParam.Empresaid = movtoItem.EmpresaId!.Value;
            Fnc_movto_venddevo_insertParam.Sucursalid = movtoItem.SucursalId!.Value;
            Fnc_movto_venddevo_insertParam.Id = movtoItem.Id;
            Fnc_movto_venddevo_insertParam.Doctoid = movtoItem.Doctoid!.Value;
            Fnc_movto_venddevo_insertParam.Partida = movtoItem.Partida;
            Fnc_movto_venddevo_insertParam.Estatusmovtoid = Model.DBValues._MOVTO_ESTATUS_BORRADOR;
            Fnc_movto_venddevo_insertParam.Productoid = movtoItem.Productoid!.Value;
            Fnc_movto_venddevo_insertParam.Movtoadevolverid = movtoItem.Devolucionmovtorefid;




            switch (propertyChanged)
            {
                case "Cantidad":
                    {
                        Fnc_movto_venddevo_insertParam.Cantidad = (decimal?)((decimal)newVal - movtoItem.Cantidad) ?? 0m;
                        Fnc_movto_venddevo_insertParam.Precio = null;
                        Fnc_movto_venddevo_insertParam.Descuentoporcentaje = null;
                        break;
                    }

                case "Preciomostrar":
                    {
                        Fnc_movto_venddevo_insertParam.Cantidad = 0m;


                        var product = new ProductoBindingModel();
                        product.EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid;
                        product.SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid;
                        product.Id = movtoItem.Productoid;


                        product = await productoProvider.GetById(product);

                        decimal? precio_final = (decimal)newVal;
                        decimal? descuento_final = null;

                        var bufferPrecioDescuentoFinal =  await AssignPrecioDescuentosOut(GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                                                          GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid,
                                                          (decimal)newVal, null,
                                                          product!.Id, CurrentCliente!.Id!.Value,
                                                          (movtoItem.Cantidad ?? 0m), (precionetoenpv.Value == BoolCN.S), product);
                        precio_final = bufferPrecioDescuentoFinal.Item1;
                        descuento_final = bufferPrecioDescuentoFinal.Item2;

                        Fnc_movto_venddevo_insertParam.Precio = precionetoenpv.Value == BoolCN.S ? precio_final : product.calculaPrecioSinImpuestos((precio_final ?? 0m));
                        Fnc_movto_venddevo_insertParam.Descuentoporcentaje = descuento_final;

                        break;
                    }

                case "Descuentoporcentaje":
                    {

                        Fnc_movto_venddevo_insertParam.Cantidad = 0;
                        Fnc_movto_venddevo_insertParam.Descuentoporcentaje = (decimal)newVal;


                        var product = new ProductoBindingModel();
                        product.EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid;
                        product.SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid;
                        product.Id = movtoItem.Productoid;


                        product = await productoProvider.GetById(product);

                        decimal? precio_final = null;
                        decimal? descuento_final = (decimal)newVal;



                        var bufferPrecioDescuentoFinal = await AssignPrecioDescuentosOut(GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                                                          GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid,
                                                           null, (decimal)newVal,
                                                          product!.Id, CurrentCliente!.Id!.Value,
                                                          (movtoItem.Cantidad ?? 0m), (precionetoenpv.Value == BoolCN.S), product);
                        precio_final = bufferPrecioDescuentoFinal.Item1;
                        descuento_final = bufferPrecioDescuentoFinal.Item2;


                        Fnc_movto_venddevo_insertParam.Precio = precionetoenpv.Value == BoolCN.S ? precio_final : product.calculaPrecioSinImpuestos((precio_final ?? 0m));
                        Fnc_movto_venddevo_insertParam.Descuentoporcentaje = descuento_final;


                        break;
                    }
            }


            await SaveMovto(Fnc_movto_venddevo_insertParam);


            return true;
        }




        public async Task SaveMovto(MovtoVenddevoTrans? movtoEditado)
        {

            if (Interlocked.Read(ref this.TransaccionEnCurso) > 0)
                return;


            Interlocked.Increment(ref TransaccionEnCurso);

            System.Collections.ArrayList? lotesSeleccionados = null;
            System.Collections.ArrayList? lotesImportadosSeleccionados = null;
            decimal? precio = null;
            decimal? cantidadTotal = null;
            bool precionetoenpv = GlobalVariable.CurrentSession?.CurrentParametro?.Precionetoenpv == BoolCN.S;

            try
            {

                if (movtoEditado == null)
                {




                    cantidadTotal = (
                                                                    CajasBotellasActive && Cajas > 0 ?
                                                                        (Cajas * (CurrentProducto!.Producto_inventario_Pzacaja != null && CurrentProducto.Producto_inventario_Pzacaja.Value > 0 ? CurrentProducto.Producto_inventario_Pzacaja.Value : 1)) + CurrentMovto!.Cantidad :
                                                                      CurrentMovto!.Cantidad
                                                                      ) ?? 0m;

                    precio = precionetoenpv ? CurrentMovto.Precio : CurrentProducto!.calculaPrecioSinImpuestos(CurrentMovto!.Precio!.Value);


                    if (cantidadTotal != null && cantidadTotal.Value > 0 &&
                        (CurrentMovto.Id == null || CurrentMovto.Id == 0))
                    {

                        //pregunta lote if needed
                        if (!PreguntaLoteIfNeeded(cantidadTotal.Value, out lotesSeleccionados))
                        {

                            showPopUpMessage("Defina primero los lotes ", "Defina primero los lotes", "Error");
                            return;
                        }
                        else if (!PreguntaLoteImportadoIfNeeded(cantidadTotal.Value, out lotesImportadosSeleccionados))
                        {

                            showPopUpMessage("Defina primero los lotes importados", "Defina primero los lotes importados", "Error");
                            return;
                        }

                        lotesSeleccionados = lotesSeleccionados != null ? lotesSeleccionados : lotesImportadosSeleccionados;
                    }
                }

                PuntoVentaDevoBindingModel? puntoVentaDevoBindingModel = null;


                puntoVentaDevoBindingModel = new PuntoVentaDevoBindingModel();
                puntoVentaDevoBindingModel.MovtoTransList = new List<MovtoVenddevoTrans>();
                puntoVentaDevoBindingModel.CurrentDocto = currentDocto;


                if (lotesSeleccionados != null && movtoEditado == null)
                {
                    foreach (V_movto_lote_seleccionWFBindingModel loteSel in lotesSeleccionados.OfType<V_movto_lote_seleccionWFBindingModel>())
                    {
                        CurrentMovto!.Id = 0;
                        var Fnc_movto_vendeduria_insertParam = FillAddMovtoParameters(CurrentMovto, CurrentDocto!, precionetoenpv,
                                                                precio, loteSel.CantidadATomar, loteSel?.Lote, loteSel?.Fechavence,
                                                                null, GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value);
                        puntoVentaDevoBindingModel.MovtoTransList.Add(Fnc_movto_vendeduria_insertParam);
                    }

                    foreach (V_movto_loteimpo_selWFBindingModel loteSel in lotesSeleccionados.OfType<V_movto_loteimpo_selWFBindingModel>())
                    {
                        CurrentMovto!.Id = 0;
                        var Fnc_movto_vendeduria_insertParam = FillAddMovtoParameters(CurrentMovto, CurrentDocto!, precionetoenpv,
                                                                precio, loteSel.CantidadATomar, loteSel?.Lote, loteSel?.Fechavence,
                                                                loteSel?.Loteimportado, GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value);
                        puntoVentaDevoBindingModel.MovtoTransList.Add(Fnc_movto_vendeduria_insertParam);
                    }

                }
                else if (movtoEditado == null)
                {

                    var bufferMovtoItemTrans = FillAddMovtoParameters(CurrentMovto!, CurrentDocto!, precionetoenpv,
                                                                    precio, cantidadTotal, null, null, null, GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value);
                    puntoVentaDevoBindingModel.MovtoTransList.Add(bufferMovtoItemTrans);
                }
                else
                {

                    puntoVentaDevoBindingModel.MovtoTransList.Add(movtoEditado!);
                }


                puntoVentaDevoBindingModel = await this.puntoVentaDevoControllerProvider.SaveMovto(puntoVentaDevoBindingModel);


                if (puntoVentaDevoBindingModel?.BaseResultBindingModel != null && puntoVentaDevoBindingModel.BaseResultBindingModel.Result >= 0)
                {
                    CurrentDocto = puntoVentaDevoBindingModel.CurrentDocto;



                    MovtoItems.Clear();
                    if (puntoVentaDevoBindingModel.MovtoItems != null)
                    {

                        foreach (var item in puntoVentaDevoBindingModel.MovtoItems)
                        {
                            MovtoItems.Add(item);
                        }

                    }

                    MovtoToDevoItems.Clear();
                    if (puntoVentaDevoBindingModel.MovtoToDevoItems != null)
                    {

                        foreach (var item in puntoVentaDevoBindingModel.MovtoToDevoItems)
                        {
                            MovtoToDevoItems.Add(item);
                        }

                    }


                    ClearMovto();
                    ClearProducto();
                    updateBoolBindingExpressions();
                    updateStringBindingExpressions();
                    OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoVentaUICommParams("SetFocus", new List<string>() { "CurrentMovto.Productoclave" })), TimeSpan.FromMilliseconds(100));
                }
                else
                {
                    ErrorEditActions(puntoVentaDevoBindingModel?.BaseResultBindingModel?.Usermessage ?? "Ocurrio un error");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {

                while (Interlocked.Read(ref this.TransaccionEnCurso) > 0)
                    Interlocked.Decrement(ref this.TransaccionEnCurso);
            }




        }


        public MovtoVenddevoTrans FillAddMovtoParameters(MovtoBindingModel movto, DoctoBindingModel docto, bool? precionetoenpv,
                                           decimal? precio, decimal? cantidad, string? lote, DateTimeOffset? fechavence,
                                           long? loteImportado, long usuarioId)
        {


            var Fnc_movto_venddevo_insertParam = new MovtoVenddevoTrans();

            Fnc_movto_venddevo_insertParam.Loteimportado = movto!.Loteimportado;
            Fnc_movto_venddevo_insertParam.Movtoparentid = null;
            Fnc_movto_venddevo_insertParam.Agrupaporparametro = BoolCN.N;
            Fnc_movto_venddevo_insertParam.Cargartarjetapreciomanual = BoolCN.N;
            Fnc_movto_venddevo_insertParam.Precioyavalidado = BoolCN.N;
            Fnc_movto_venddevo_insertParam.Usuarioid = GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value;


            Fnc_movto_venddevo_insertParam.Lote = movto.Lote;
            Fnc_movto_venddevo_insertParam.Fechavence = movto.Fechavence;
            Fnc_movto_venddevo_insertParam.Localidad = movto.Movto_inventario_Localidad;
            Fnc_movto_venddevo_insertParam.Descripcion1 = movto.Movto_comodin_Descripcion1;
            Fnc_movto_venddevo_insertParam.Descripcion2 = movto.Movto_comodin_Descripcion2;
            Fnc_movto_venddevo_insertParam.Descripcion3 = movto.Movto_comodin_Descripcion3;
            Fnc_movto_venddevo_insertParam.Empresaid = movto!.EmpresaId!.Value;
            Fnc_movto_venddevo_insertParam.Sucursalid = movto!.SucursalId!.Value;
            Fnc_movto_venddevo_insertParam.Id = movto.Id != null ? movto.Id : 0;
            Fnc_movto_venddevo_insertParam.Doctoid = docto!.Id!.Value;
            Fnc_movto_venddevo_insertParam.Partida = movto.Partida;
            Fnc_movto_venddevo_insertParam.Estatusmovtoid = movto!.Estatusmovtoid!.Value;
            Fnc_movto_venddevo_insertParam.Productoid = movto!.Productoid!.Value;



            Fnc_movto_venddevo_insertParam.Cantidad = cantidad!.Value;
            Fnc_movto_venddevo_insertParam.Descuentoporcentaje = movto.Descuentoporcentaje;

            Fnc_movto_venddevo_insertParam.Precio = precio;

            if (!(precionetoenpv ?? false))
            {
                Fnc_movto_venddevo_insertParam.Precioconimp = CurrentMovto!.Precio;
            }

            return Fnc_movto_venddevo_insertParam;

        }



        //lotes

        //lote movto
        private bool PreguntaLoteIfNeeded(decimal cantidadASeleccionar, out System.Collections.ArrayList? lotesSeleccionados)
        {
            lotesSeleccionados = null;

            if (CurrentMovto!.Lote != null && CurrentMovto.Lote.Length > 0)
                return true;

            CurrentMovto.Lote = null;
            CurrentMovto.Fechavence = null;

            if (CurrentProducto == null || CurrentProducto.Id == 0)
                return false;

            if (CurrentProducto.Producto_inventario_Manejalote == null || CurrentProducto.Producto_inventario_Manejalote != BoolCN.S)
                return true;

            MovtoLoteListViewModel vm = IoC.Get<MovtoLoteListViewModel>();
            vm.ListParam!.EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid;
            vm.ListParam!.SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid;
            vm.ListParam!.Productoid = CurrentProducto.Id;
            vm.ListParam!.Productoclave = CurrentProducto.Clave;
            vm.ListParam!.Productonombre = CurrentProducto.Nombre;

            vm.ListParam!.Almacenid = this.CurrentDocto!.Almacenid;

            vm.CantidadASeleccionar = cantidadASeleccionar;


            vm.ListParam.Doctoid = CurrentDocto!.Id;

            //vm.RecordParam.Restante = CurrentDocto.Total.Value;
            winManager.ShowDialogAsync(vm, null, CreateWinSettings("Seleccion de lote", 0.60, 0.80));

            if (vm.SelectedItems == null || vm.SelectedItems.Count == 0)
                return false;

            lotesSeleccionados = vm.SelectedItems;

            return true;

        }




        //lote movto
        private bool PreguntaLoteImportadoIfNeeded(decimal cantidadASeleccionar, out System.Collections.ArrayList? lotesSeleccionados)
        {
            lotesSeleccionados = null;

            if (CurrentMovto!.Loteimportado != null && CurrentMovto.Loteimportado > 0)
                return true;

            CurrentMovto.Loteimportado = null;

            if (CurrentProducto == null || CurrentProducto.Id == 0)
                return false;

            if (CurrentProducto.Producto_loteimportado_Manejaloteimportado == null || CurrentProducto.Producto_loteimportado_Manejaloteimportado != BoolCN.S)
                return true;

            MovtoLoteimportadoListViewModel vm = IoC.Get<MovtoLoteimportadoListViewModel>();
            vm.ListParam!.EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid;
            vm.ListParam!.SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid;
            vm.ListParam!.Productoid = CurrentProducto.Id;
            vm.ListParam!.Productoclave = CurrentProducto.Clave;
            vm.ListParam!.Productonombre = CurrentProducto.Nombre;

            vm.ListParam!.Almacenid = this.CurrentDocto!.Almacenid;

            vm.CantidadASeleccionar = cantidadASeleccionar;


            vm.ListParam.Doctoid = CurrentDocto!.Id;

            //vm.RecordParam.Restante = CurrentDocto.Total.Value;
            winManager.ShowDialogAsync(vm, null, CreateWinSettings("Seleccion de lote", 0.60, 0.80));

            if (vm.SelectedItems == null || vm.SelectedItems.Count == 0)
                return false;

            lotesSeleccionados = vm.SelectedItems;

            return true;

            //return true;
        }

        //pay and complete transaction

        public async Task Pagar()
        {
            try
            {
                if (CurrentDocto == null || CurrentDocto.Id == null || CurrentDocto.Id == 0 || CurrentDocto.Estatusdoctoid == null ||
                   CurrentDocto.Estatusdoctoid.Value != Model.DBValues._DOCTO_ESTATUS_BORRADOR)
                    return;

                //ScreenpagonotacreditoObtainItemSubViewModel vm = IoC.Get<ScreenpagonotacreditoObtainItemSubViewModel>();
                //vm.RecordParam.Total = CurrentDocto.Total;
                //winManager.ShowDialog(vm, null, CreateWinSettings("Ventas", 0.60, 0.80));

                V_pagomultiple_ventadevoViewModel vm = IoC.Get<V_pagomultiple_ventadevoViewModel>();
                vm.PagoItem!.Total = CurrentDocto.Total;
                winManager.ShowDialogAsync(vm, null, CreateWinSettings("Notas de credito", 0.60, 0.80));

                //temporal 
                //var vm_BProcessSuccess = true;
                if (vm.BProcessSuccess)
                {

                    V_pagomultiple_ventadevoWFBindingModel pagosParam = vm.PagoItem;
                    //ScreenpagonotacreditoParam pagosParam = new ScreenpagonotacreditoParam();
                    //pagosParam.Montoefectivo = CurrentDocto.Total;

                    List<DoctoPagoDirect> paymentList = new List<DoctoPagoDirect>();
                    var paymentParam = new DoctoPagoDirect();

                    if (ZeroIfNull(pagosParam.Montoefectivo) > 0.0m)
                    {
                        paymentParam = new DoctoPagoDirect()
                        {
                            Empresaid = CurrentDocto.EmpresaId!.Value,
                            Sucursalid = CurrentDocto.SucursalId!.Value,
                            Doctoid = CurrentDocto.Id,
                            Corteid = this.CorteId,
                            Formapagoid = Model.DBValues._FORMA_PAGO_EFECTIVO,
                            Formapagosatid = Model.DBValues._FORMA_PAGOSAT_EFECTIVO,
                            Importe = pagosParam.Montoefectivo!.Value,
                            Importecambio = 0.0m,// decimal ? P_importecambio
                            Bancoid = null, // long ? P_bancoid
                            Referenciabancaria = null, // string P_referenciabancaria
                            Espagoinicial = BoolCN.S, //, string P_espagoinicial
                            Tipopagoid = Model.DBValues._TIPOPAGO_SALIDA, // long ? P_tipopagoid
                            Tipoabonoid = Model.DBValues._TIPO_ABONO_INICIAL,// long ? P_tipoabonoid
                            Clienteid = CurrentDocto.Clienteid,// ? P_clienteid
                            Proveedorid = null,//, long ? P_proveedorid
                            Usuarioid = GlobalSession?.CurrentUsuario?.Id, //, long ? P_usuarioid
                            Sentidopago = -1//, int ? P_sentidopago

                        };
                        paymentList.Add(paymentParam);
                    }


                    if (ZeroIfNull(pagosParam.Montocreditoautomatico) > 0.0m)
                    {

                        paymentParam = new DoctoPagoDirect()
                        {
                            Empresaid = CurrentDocto.EmpresaId!.Value,
                            Sucursalid = CurrentDocto.SucursalId!.Value,
                            Doctoid = CurrentDocto.Id,
                            Corteid = this.CorteId,
                            Formapagoid = Model.DBValues._FORMA_PAGO_CREDITO,
                            Formapagosatid = Model.DBValues._FORMA_PAGOSAT_OTRO,
                            Importe = pagosParam.Montocreditoautomatico!.Value,
                            Importecambio = 0.0m,// decimal ? P_importecambio
                            Bancoid = null, // long ? P_bancoid
                            Referenciabancaria = null, // string P_referenciabancaria
                            Espagoinicial = BoolCN.S, //, string P_espagoinicial
                            Tipopagoid = Model.DBValues._TIPOPAGO_SALIDA, // long ? P_tipopagoid
                            Tipoabonoid = Model.DBValues._TIPO_ABONO_INICIAL,// long ? P_tipoabonoid
                            Clienteid = CurrentDocto.Clienteid,// ? P_clienteid
                            Proveedorid = null,//, long ? P_proveedorid
                            Usuarioid = GlobalSession?.CurrentUsuario?.Id, //, long ? P_usuarioid
                            Sentidopago = -1//, int ? P_sentidopago
                        };
                        paymentList.Add(paymentParam);
                    }

                    await CompletarDocto(pagosParam, paymentList);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task CompletarDocto(V_pagomultiple_ventadevoWFBindingModel pagosParam, List<DoctoPagoDirect> paymentList)
        {

            bool bSuccess = true;
            IsBusy = true;
            var comentario = "";


            try
            {


                var result = await puntoVentaDevoControllerProvider.Docto_venddevo_and_payments_save(
                                                       GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
                                                       GlobalVariable.CurrentSession!.CurrentConfiguracion!.Sucursalid!.Value,
                                                       CurrentDocto!.Id!.Value,
                                                       paymentList

                                    );

                bSuccess = result != null && result.Result >= 0;

                bSuccess = result != null && result.Result >= 0;
                comentario = result != null ? result.Usermessage : "Error ...";


                BProcessSuccess = bSuccess;
                if (!BProcessSuccess)
                {
                    ErrorEditActions(comentario);
                }
                else
                {

                    if (pagosParam.Generarfacturaelectronica != null && pagosParam.Generarfacturaelectronica.Equals("S"))
                    {
                        await this.Facturar(CurrentDocto!.Id!.Value);
                    }

                    await DoImprimirDoctoTicketLargo();
                    await InitialState();
                    updateBoolBindingExpressions();
                    updateStringBindingExpressions();
                    OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoVentaUICommParams("SetFocus", new List<string>() { "CurrentMovto.Productoclave" })), TimeSpan.FromMilliseconds(100));
                }
            }
            catch (Exception ex)
            {

                comentario = ex.Message;
                ErrorEditActions(comentario);

            }
            finally
            {
                this.IsBusy = false;
            }


        }


        private async Task<bool> Facturar(long doctoId)
        {

            FacturacionViewModel vm = IoC.Get<FacturacionViewModel>();
            vm.AsignarDatoParaFacturar(
                                        GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
                                        GlobalVariable.CurrentSession!.CurrentConfiguracion!.Sucursalid!.Value,
                                       doctoId,
                                       null, false);
            await winManager.ShowDialogAsync(vm, null, CreateWinSettings("Facturacion", 0.25));

            if (vm.SeFacturo)
            {
                showPopUpMessage(new MessageToUserSimple("Procesado", "Se hizo la facturacion", "Success"));
            }
            else
            {
                showPopUpMessage(new MessageToUserSimple("Problema", "No se puedo hacer la facturacion", "Information"));
            }


            return true;
        }



        //cancel docto
        public async Task CancelarDocto()
        {
            await DoCancelarDocto();
        }

        private async Task DoCancelarDocto()
        {
            try
            {
                if (CurrentDocto == null || CurrentDocto.Id == null ||
                   CurrentDocto.Id == 0 || (CurrentDocto.Estatusdoctoid != null &&
                                            CurrentDocto.Estatusdoctoid != Model.DBValues._DOCTO_ESTATUS_BORRADOR &&
                                            CurrentDocto.Estatusdoctoid != Model.DBValues._DOCTO_ESTATUS_COMPLETO))
                {
                    ErrorEditActions("No se puede eliminar el documento, no existe o no esta en estatus borrador");
                }

                if (ShowSiNoMessageBox("Realmente desea cancelar el documento", "Confirmacion"))
                {
                    if (CurrentDocto!.Estatusdoctoid == null || CurrentDocto.Estatusdoctoid == Model.DBValues._DOCTO_ESTATUS_BORRADOR)
                    {
                        BaseResultBindingModel? resultOperation = null;
                        resultOperation = await puntoVentaDevoControllerProvider.Docto_venddevo_delete(CurrentDocto!.EmpresaId!.Value, CurrentDocto!.SucursalId!.Value, currentDocto!.Id!.Value);


                        if (resultOperation == null)
                        {
                            ErrorEditActions("Ocurrio un error indeterminado");
                        }
                        else if (resultOperation.Result < 0)
                        {
                            ErrorEditActions("Ocurrio un error " + resultOperation.Usermessage);
                        }
                        else
                        {
                            showPopUpMessage(new MessageToUserSimple("Procesado", "Se ha cancelado el registro el registro", "Success"));

                            await NuevaVenta();
                        }
                    }
                    else if (CurrentDocto.Estatusdoctoid == Model.DBValues._DOCTO_ESTATUS_COMPLETO)
                    {
                        BaseResultBindingModel? resultOperation = null;

                        resultOperation = await puntoVentaDevoControllerProvider.Docto_venddevo_cancel(CurrentDocto!.EmpresaId!.Value, CurrentDocto!.SucursalId!.Value, CurrentDocto!.Id!.Value, GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value);


                        if (resultOperation == null)
                        {
                            ErrorEditActions("Ocurrio un error indeterminado");
                        }
                        else if (resultOperation.Result < 0)
                        {
                            ErrorEditActions("Ocurrio un error " + resultOperation.Usermessage);
                        }
                        else
                        {
                            showPopUpMessage(new MessageToUserSimple("Procesado", "Se ha cancelado el registro el registro", "Success"));

                            await NuevaVenta();
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                ErrorEditActions("Ocurrio un error " + ex.Message);
            }

        }


        //cancel movto
        public void CancelMovto()
        {

            ClearMovto();
            ClearProducto();
            OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoVentaUICommParams("SetFocus", new List<string>() { "CurrentMovto.Productoclave" })), TimeSpan.FromMilliseconds(100));

        }

        //print docto
        public async Task ImprimirDocto()
        {
            await DoImprimirDoctoTicketLargo();
        }

        private async Task DoImprimirDoctoTicketLargo()
        {

            if (GlobalVariable.CurrentDataBaseConnectionFnc == null)
                return;



            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("pempresaid", CurrentDocto!.EmpresaId!.Value);
            dict.Add("psucursalid", CurrentDocto.SucursalId!.Value);
            dict.Add("pdoctoid", CurrentDocto.Id!.Value);
            dict.Add("usaDatosDeEntregaCuandoExista", "N");
            dict.Add("desglosekits", "S");
            dict.Add("marcaAgua", "N");
            dict.Add("enDolar", "N");
            dict.Add("creadoPorUserId", 0);


            FastReportInfo fastReportInfo = new FastReportInfo()
            {
                //RutaReporte = FastReportsConfig.getPathForFile("TicketCompras.frx", FastReportsTipoFile.desistema),
                RutaReporte = FastReportsConfig.getPathForFile("RECIBOLARGO.frx", FastReportsTipoFile.desistema),
                DictionaryReporte = dict,
                ConnectionString = GlobalVariable.CurrentDataBaseConnectionFnc(),
                Userid = GlobalVariable.CurrentSession!.Usuarioid!.Value,
                UserName = GlobalVariable.CurrentSession!.CurrentUsuario!.Nombre
            };


            ReporteFrxShowingViewModel vm = IoC.Get<ReporteFrxShowingViewModel>();

            var dictTables = await this._reportesWebController.GetReportData(fastReportInfo);

            fastReportInfo.DictionaryTables = dictTables;
            fastReportInfo.RutaReporte = FastReportsConfig.getPathFrxForFile("RECIBOLARGO.frx", FastReportsTipoFile.desistema);

            vm.FastReportInfo = fastReportInfo;

            winManager.ShowDialogAsync(vm, null, CreateWinSettings("Devolucion de Ventas", 0.75));
        }

        private void DoImprimirDoctoTicketCorto()
        {

            try
            {
                if (CurrentDocto == null || CurrentDocto.Id == null ||
                   CurrentDocto.Id == 0)
                {
                    ErrorEditActions("No se puede imprimir el documento");
                }
                //TODO HACER LA IMPRESION DE TICKET CORTO


            }
            catch (Exception ex)
            {
                ErrorEditActions("Ocurrio un error " + ex.Message);
            }

        }


        //grid movto events

        async void MovtoToDevoItem_PendingChange(object sender, AcceptPendingChangeEventArgs e)
        {
            V_movto_vend_to_devoWFBindingModel movtoItem = (V_movto_vend_to_devoWFBindingModel)sender;
            if (e.PropertyName == "Cantidad")
            {
                //MessageBox.Show(e.OldValue.ToString() + " new val " + e.NewValue.ToString());
                //e.CancelPendingChange = false;
                e.CancelPendingChange = await SaveMovtoToDevoFromGrid(movtoItem, "Cantidad", e.NewValue);
            }
        }

        void MovtoToDevoItems_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (V_movto_vend_to_devoWFBindingModel item in e.NewItems)
                    item.PendingChange += MovtoToDevoItem_PendingChange;

            if (e.OldItems != null)
                foreach (V_movto_vend_to_devoWFBindingModel item in e.OldItems)
                    item.PendingChange -= MovtoToDevoItem_PendingChange;
        }


        async void MovtoItem_PendingChange(object sender, AcceptPendingChangeEventArgs e)
        {
            V_movto_venddevoWFBindingModel movtoItem = (V_movto_venddevoWFBindingModel)sender;
            if (e.PropertyName == "Cantidad")
            {
                //MessageBox.Show(e.OldValue.ToString() + " new val " + e.NewValue.ToString());
                //e.CancelPendingChange = false;
                e.CancelPendingChange = await SaveMovtoFromGrid(movtoItem, "Cantidad", e.NewValue);
            }
            else if (e.PropertyName == "Preciomostrar")
            {
                e.CancelPendingChange = await SaveMovtoFromGrid(movtoItem, "Preciomostrar", e.NewValue);
            }
            else if (e.PropertyName == "Descuentoporcentaje")
            {
                e.CancelPendingChange = await SaveMovtoFromGrid(movtoItem, "Descuentoporcentaje", e.NewValue);
            }
        }

        void MovtoItems_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (V_movto_venddevoWFBindingModel item in e.NewItems)
                    item.PendingChange += MovtoItem_PendingChange;

            if (e.OldItems != null)
                foreach (V_movto_venddevoWFBindingModel item in e.OldItems)
                    item.PendingChange -= MovtoItem_PendingChange;
        }


        public async Task MovtoGridKeyDown(KeyEventArgs keyArgs)
        {
            Key key = keyArgs.Key;
            if (key == Key.System && keyArgs.SystemKey == Key.F10)
            {
                await MovtoDeleteSelected();

            }
        }

        public async Task MovtoDeleteSelected()
        {
            if (SelectedMovtoItems == null || SelectedMovtoItems.Count == 0 || CurrentDocto == null || CurrentDocto.Estatusdoctoid != Model.DBValues._DOCTO_ESTATUS_BORRADOR)
                return;

            if (ShowSiNoMessageBox("Realmente desea eliminar el(los) registro(s)", "Confirmacion"))
            {
                try
                {
                    PuntoVentaDevoBindingModel? puntoVentaDevoBindingModel = null;

                    foreach (var item in SelectedMovtoItems)
                    {
                        var movtoItem = (V_movto_venddevoWFBindingModel)item;



                        var listIds = SelectedMovtoItems.Select(item => ((V_movto_venddevoWFBindingModel)item).Id!.Value).ToList();


                        puntoVentaDevoBindingModel = await puntoVentaDevoControllerProvider.Movto_venddevo_delete(movtoItem.EmpresaId!.Value, movtoItem.SucursalId!.Value, listIds, CurrentDocto!.Id!.Value);

                        if (puntoVentaDevoBindingModel?.BaseResultBindingModel != null && puntoVentaDevoBindingModel?.BaseResultBindingModel.Result < 0)
                        {
                            ErrorEditActions("Ocurrio un error " + puntoVentaDevoBindingModel?.BaseResultBindingModel!.Usermessage);
                            return;
                        }

                    }

                    if (puntoVentaDevoBindingModel?.BaseResultBindingModel != null && puntoVentaDevoBindingModel.BaseResultBindingModel.Result >= 0)
                    {
                        CurrentDocto = puntoVentaDevoBindingModel.CurrentDocto;
                        MovtoItems.Clear();
                        foreach (var movto in puntoVentaDevoBindingModel.MovtoItems)
                        {
                            MovtoItems.Add(movto);
                        }

                        MovtoToDevoItems.Clear();
                        foreach (var movto in puntoVentaDevoBindingModel.MovtoToDevoItems)
                        {
                            MovtoToDevoItems.Add(movto);
                        }

                        ClearMovto();
                        ClearProducto();
                        updateBoolBindingExpressions();
                        updateStringBindingExpressions();
                        OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoVentaUICommParams("SetFocus", new List<string>() { "CurrentMovto.Productoclave" })), TimeSpan.FromMilliseconds(100));
                    }

                }
                catch (Exception ex)
                {
                    ErrorEditActions("Ocurrio un error al eliminar los registros. Descripcion tecnica:  " + ex.Message);
                }
            }

        }



        //closing
        public override async Task TryCloseAsync(bool? dialogResult = null)
        {

            var vm = IoC.Get<HomeViewModel>();
            await aggregator.PublishOnBackgroundThreadAsync(new NavigationParameter(vm, true, false));

        }


        //messaging
        public void SuccessEditActions(BaseListVMEventParameters record)
        {

            var eventParam = new BaseListVMEventParameters();
            eventParam.fillFields(true, true,
                                                                BProcessSuccess ?
                                                                                new MessageToUserSimple("Exito", "Se inserto el registro", "Success") :
                                                                                new MessageToUserSimple("Error", "Occurrio un error ", "Error"));

            aggregator.PublishOnUIThreadAsync(eventParam);
            //aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }

        public void ErrorEditActions(string comentario)
        {
            showPopUpMessage("Ocurrio un error ", comentario, "Error");
        }




    }
}
