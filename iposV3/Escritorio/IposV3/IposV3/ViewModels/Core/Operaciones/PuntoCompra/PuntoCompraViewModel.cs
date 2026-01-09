
using BindingModels;
using IposV3.Model;
using IposV3.BindingModel;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
using Models.CatalogSelector;
using IposV3.ViewModels.BaseScreen;
using ViewModels.BaseScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.BindingModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Threading;
using System.Windows.Input;
using IposV3.ViewModels.utilities;
using IposV3.ViewModels.core.operaciones.puntocompra;
using System.Windows;
using IposV3.Services;
using IposV3.ViewModels.Models;
using System.Threading;

namespace IposV3.ViewModels
{
    public class PuntoCompraViewModel : BaseOperationalScreen
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

        private ProveedorBindingModel? currentProveedor;
        public ProveedorBindingModel? CurrentProveedor { get => currentProveedor; set { currentProveedor = value; NotifyOfPropertyChange("CurrentProveedor"); } }


        private ProductoBindingModel? currentProducto;
        public ProductoBindingModel? CurrentProducto { get => currentProducto; set { currentProducto = value; NotifyOfPropertyChange("CurrentProducto"); } }




        //Internal grids properties
        public ObservableCollection<V_movto_proveeduriaWFBindingModel> MovtoItems { get; set; }
        public ObservableCollection<object>? SelectedMovtoItems { get; set; }


        //Operation result properties
        public BaseResultBindingModel? Fnc_docto_prov_insertResult { get; set; }
        public BaseResultBindingModel? Fnc_movto_prov_insertResult { get; set; }
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
                selectedListPrice = value;
                NotifyOfPropertyChange(() => this.SelectedListPrice);
                OnListPriceChanged();
            }
        }


        //Controller providers
        protected readonly DoctoWebController doctoProvider;
        protected readonly MovtoWebController movtoProvider;
        protected readonly ProveedorWebController proveedorProvider;
        protected readonly ProductoWebController productoProvider;
        protected readonly Sucursal_infoWebController sucursal_extProvider;
        private readonly GlobalWebController globalControllerProvider;
        //private readonly ITicketstemplatesControllerProvider ticketstemplatesControllerProvider;
        private readonly PuntoCompraWebController puntoCompraControllerProvider;
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
        public PuntoCompraViewModel(
            //controller providers
            DoctoWebController doctoprovider,
            MovtoWebController movtoprovider,
            ProveedorWebController proveedorprovider,
            Sucursal_infoWebController sucursal_extprovider,
            ProductoWebController productoProvider,
            PuntoCompraWebController puntoCompraControllerProvider,
            GlobalWebController globalControllerProvider,
            UsuarioWebController usuarioControllerProvider,
            //TicketstemplatesControllerProvider ticketstemplatesControllerProvider,
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
            this.proveedorProvider = proveedorprovider;
            this.sucursal_extProvider = sucursal_extprovider;
            this.productoProvider = productoProvider;
            this.puntoCompraControllerProvider = puntoCompraControllerProvider;
            this.globalControllerProvider = globalControllerProvider;
            //this.ticketstemplatesControllerProvider = ticketstemplatesControllerProvider;

            this._reportesWebController = reportesWebController;

            //suscribe to change events
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
            MovtoItems = new ObservableCollection<V_movto_proveeduriaWFBindingModel>();
            MovtoItems.CollectionChanged += MovtoItems_CollectionChanged;
            




        }





        public virtual async void ViewLoaded(EventArgs args)
        {
            await ClearInfo();
            await InitialState();


            //configurate fields
            ConfigureMovtoFields();

            //suscribe view to events
            aggregator.SubscribeOnUIThread(this.GetView());

            this.ManejaAlmacen = GlobalVariable.CurrentSession?.CurrentParametro?.Manejaalmacen == BoolCN.S;

            //check if corte is active
            ChecarCorteActivo();
        }


        // Bool expresions

        private void fillBoolBindingExpressions()
        {
            var boolBindingExpression = new Dictionary<string, bool>();

            boolBindingExpression.Clear();

            boolBindingExpression.Add("NuevaCompraVacia", this.currentDocto != null && (this.currentDocto.Id ?? 0) == 0 && this.currentDocto.Tipodoctoid == DBValues._DOCTO_TIPO_COMPRA);
            boolBindingExpression.Add("NuevaOrdenDeCompraVacia", this.currentDocto != null && (this.currentDocto.Id ?? 0) == 0 && this.currentDocto.Tipodoctoid == DBValues._DOCTO_TIPO_ORDEN_COMPRA);
            boolBindingExpression.Add("EsCompra", this.currentDocto != null && this.currentDocto.Tipodoctoid == DBValues._DOCTO_TIPO_COMPRA);
            boolBindingExpression.Add("EsOrdenDeCompra", this.currentDocto != null && this.currentDocto.Tipodoctoid == DBValues._DOCTO_TIPO_ORDEN_COMPRA);
            boolBindingExpression.Add("TransaccionEnBorrador", this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_BORRADOR);
            boolBindingExpression.Add("TransaccionCompleta", this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_COMPLETO);
            boolBindingExpression.Add("TransaccionCancelada", this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_CANCELADA);
            boolBindingExpression.Add("DerechoCambiarAlmacen", (DerechosUsuario?[Model.DBValues._DERECHO_CAMBIARDEALMACEN] ?? false));
            boolBindingExpression.Add("DerechoCambiarGastosAdic", (DerechosUsuario?[Model.DBValues._DERECHO_GASTOSADIC_COMPRA] ?? false));
            boolBindingExpression.Add("DerechoImportarCompras", (DerechosUsuario?[Model.DBValues._DERECHO_IMPORTAR_COMPRAS] ?? false));
            boolBindingExpression.Add("ManejaGastosAdicionales", !(GlobalSession?.CurrentParametro?.Manejagastosadic == BoolCN.S));
            boolBindingExpression.Add("ManejaAlmacen", !(GlobalSession?.CurrentParametro?.Manejaalmacen == BoolCN.S));

            boolBindingExpression.Add("HabilitarCancelar", this.currentDocto != null && (this.currentDocto.Id ?? 0) != 0 && this.currentDocto.Estatusdoctoid != DBValues._DOCTO_ESTATUS_CANCELADA);
            boolBindingExpression.Add("HabilitarPago", this.currentDocto != null && (this.currentDocto.Id ?? 0) != 0 && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_BORRADOR);
            boolBindingExpression.Add("HabilitarAlmacen", (DerechosUsuario?[Model.DBValues._DERECHO_CAMBIARDEALMACEN] ?? false) &&
                                                       this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_BORRADOR);
            boolBindingExpression.Add("HabilitarGastosAdicionales", (DerechosUsuario?[Model.DBValues._DERECHO_GASTOSADIC_COMPRA] ?? false) &&
                                                       this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_BORRADOR);



            BoolBindingExpression = boolBindingExpression;

            NotifyOfPropertyChange("BoolBindingExpression");
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


            boolBindingExpression["NuevaCompraVacia"] = this.currentDocto != null && (this.currentDocto.Id ?? 0) == 0 && this.currentDocto.Tipodoctoid == DBValues._DOCTO_TIPO_COMPRA;
            boolBindingExpression["NuevaOrdenDeCompraVacia"] = this.currentDocto != null && (this.currentDocto.Id ?? 0) == 0 && this.currentDocto.Tipodoctoid == DBValues._DOCTO_TIPO_ORDEN_COMPRA;
            boolBindingExpression["EsCompra"] = this.currentDocto != null && this.currentDocto.Tipodoctoid == DBValues._DOCTO_TIPO_COMPRA;
            boolBindingExpression["EsOrdenDeCompra"] = this.currentDocto != null && this.currentDocto.Tipodoctoid == DBValues._DOCTO_TIPO_ORDEN_COMPRA;
            boolBindingExpression["TransaccionEnBorrador"] = this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_BORRADOR;
            boolBindingExpression["TransaccionCompleta"] = this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_COMPLETO;
            boolBindingExpression["TransaccionCancelada"] = this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_CANCELADA;

            boolBindingExpression["HabilitarCancelar"] = this.currentDocto != null && (this.currentDocto.Id ?? 0) != 0 && this.currentDocto.Estatusdoctoid != DBValues._DOCTO_ESTATUS_CANCELADA;
            boolBindingExpression["HabilitarPago"] = this.currentDocto != null && (this.currentDocto.Id ?? 0) != 0 && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_BORRADOR;
            boolBindingExpression["HabilitarAlmacen"] = (DerechosUsuario?[Model.DBValues._DERECHO_CAMBIARDEALMACEN] ?? false) &&
                                                  this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_BORRADOR;
            boolBindingExpression["HabilitarGastosAdicionales"] = (DerechosUsuario?[Model.DBValues._DERECHO_GASTOSADIC_COMPRA] ?? false) &&
                                                       this.currentDocto != null && this.currentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_BORRADOR;



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
        public async Task ClearInfo()
        {
            ClearDocto();
            ClearMovto();
            ClearProducto();
            ClearMovtoItems();
            ConfigureCajasBotellas();
            await AssignProveedorInfo();

        }


        private async Task InitialState()
        {
            await NuevaCompra();
        }


        private void ClearDocto()
        {
            CurrentDocto = EmptyDocto();
        }

        private DoctoBindingModel EmptyDocto()
        {

            var buffer = new DoctoBindingModel();
            buffer.EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid;
            buffer.SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid;
            //buffer.Tipodoctoid = Model.DBValues._DOCTO_TIPO_COMPRA;
            return buffer;
        }

        private void ClearProducto()
        {

            CurrentProducto = new ProductoBindingModel();
            CurrentProducto.EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid;
            CurrentProducto.SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid;

            if (CurrentMovto != null)
                CurrentMovto.Productoid = 0;


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

        public async Task NuevaCompra()
        {

            DisableCatalogSearchingDocto = true;
            await ClearInfo();
            CurrentDocto!.Referencia = "";
            CurrentDocto.Referencias = "";
            CurrentDocto.Docto_apartado_Mercanciaentregada = BoolCN.S;
            CurrentDocto.Docto_info_pago_Pagocontarjeta = TipoPagoConTarjeta.N;
            CurrentDocto.Docto_info_pago_Pagoacredito = BoolCN.N;
            CurrentDocto.Docto_promocion_Promocion = BoolCN.N;
            CurrentDocto.EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid;
            CurrentDocto.SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid;
            CurrentDocto.Estatusdoctoid = Model.DBValues._DOCTO_ESTATUS_BORRADOR;
            CurrentDocto.EstatusdoctoNombre = "Borrador";
            CurrentDocto.Usuarioid = GlobalVariable.CurrentSession?.CurrentUsuario?.Id;
            CurrentDocto.UsuarioNombre = GlobalVariable.CurrentSession?.CurrentUsuario?.Nombre;
            CurrentDocto.Fecha = DateTimeOffset.Now.Date;
            CurrentDocto.Cajaid = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Cajaid;

            CurrentDocto.Almacenid = GlobalVariable.CurrentSession?.CurrentUsuario?.Usuario_Preferencias_Almacenid ??
                                                        (GlobalVariable.CurrentSession?.CurrentParametro?.Almacenrecepcionid ?? Model.DBValues._ALMACEN_DEFAULT);

            CurrentDocto.Origenfiscalid = Model.DBValues._ORIGENFISCAL_REMISIONADO;
            CurrentDocto.Doctoparentid = null;
            //CurrentDocto.Proveedorid = Model.DBValues._CLIENTEMOSTRADOR;
            CurrentDocto.Tipodoctoid = Model.DBValues._DOCTO_TIPO_COMPRA;
            CurrentDocto.TipodoctoNombre = "Compra";
            CurrentDocto.Sucursal_id = GlobalSession?.CurrentSucursalInfo?.Id;
            CurrentDocto.Docto_traslado_Sucursaltid = CurrentDocto.Sucursal_id;
            CurrentDocto.Docto_traslado_Almacentid = CurrentDocto.Almacenid;

            await AssignProveedorInfo();

            updateBoolBindingExpressions();
            updateStringBindingExpressions();

            DisableCatalogSearchingDocto = false;

        }


        public async Task NuevaOrdenCompra()
        {

            await ClearInfo();
            CurrentDocto!.Referencia = "";
            CurrentDocto.Referencias = "";
            CurrentDocto.Docto_apartado_Mercanciaentregada = BoolCN.S;
            CurrentDocto.Docto_info_pago_Pagocontarjeta = TipoPagoConTarjeta.N;
            CurrentDocto.Docto_info_pago_Pagoacredito = BoolCN.N;
            CurrentDocto.Docto_promocion_Promocion = BoolCN.N;
            CurrentDocto.EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid;
            CurrentDocto.SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid;
            CurrentDocto.Estatusdoctoid = Model.DBValues._DOCTO_ESTATUS_BORRADOR;
            CurrentDocto.EstatusdoctoNombre = "Borrador";
            CurrentDocto.Usuarioid = GlobalVariable.CurrentSession?.CurrentUsuario?.Id;
            CurrentDocto.UsuarioNombre = GlobalVariable.CurrentSession?.CurrentUsuario?.Nombre;
            CurrentDocto.Fecha = DateTimeOffset.Now.Date;
            CurrentDocto.Cajaid = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Cajaid;

            CurrentDocto.Almacenid = GlobalVariable.CurrentSession?.CurrentUsuario?.Usuario_Preferencias_Almacenid ??
                                                        (GlobalVariable.CurrentSession?.CurrentParametro?.Almacenrecepcionid ?? Model.DBValues._ALMACEN_DEFAULT);

            CurrentDocto.Origenfiscalid = Model.DBValues._ORIGENFISCAL_REMISIONADO;
            CurrentDocto.Doctoparentid = null;
            //CurrentDocto.Proveedorid = Model.DBValues._CLIENTEMOSTRADOR;
            CurrentDocto.Tipodoctoid = Model.DBValues._DOCTO_TIPO_ORDEN_COMPRA;
            CurrentDocto.TipodoctoNombre = "Orden de Compra";
            CurrentDocto.Sucursal_id = GlobalSession?.CurrentSucursalInfo?.Id;
            CurrentDocto.Docto_traslado_Sucursaltid = CurrentDocto.Sucursal_id;
            CurrentDocto.Docto_traslado_Almacentid = CurrentDocto.Almacenid;

            await AssignProveedorInfo();

            updateBoolBindingExpressions();
            updateStringBindingExpressions();

        }



        //Configuration
        private void ConfigureCajasBotellas()
        {
            var parametroCajasBotellas = GlobalVariable.CurrentSession?.CurrentParametro?.Cajasbotellas == BoolCN.S;
            var currentProductUnitIsKg = currentProducto != null && currentProducto.UnidadClave != null && currentProducto.UnidadClave.ToUpper().Equals("KG");
            CajasBotellasActive = (parametroCajasBotellas && !currentProductUnitIsKg);
        }
        private void ConfigureMovtoFields()
        {

            var parametroCajasBotellas = GlobalVariable.CurrentSession?.CurrentParametro?.Cajasbotellas == BoolCN.S;
            bool? parametroCompraConCantidad = true;//BIPOS.Models.Parametros.GetBoolFromClaveAndList(GlobalVariable.CurrentSession.CurrentParametros, "uicompraconcantidad");

            CantidadEnabled = (parametroCompraConCantidad != null && parametroCompraConCantidad.Value) || (parametroCajasBotellas && parametroCajasBotellas);
            PrecioEnabled = DerechosUsuario?[Model.DBValues._DERECHO_CAMBIARPRECIO_VENTA] ?? false;
            DescuentoEnabled = DerechosUsuario?[Model.DBValues._DERECHO_CAMBIARDESCUENTO_VENTA] ?? false;
            ListaPrecioEnabled = false; //DerechosUsuario[Model.DBValues._DERECHO_CAMBIARPRECIOXLISTA_VENTA];


        }
        protected override void fillCatalogConfiguration()
        {

            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("CurrentDocto","Proveedor","Proveedorid", "ProveedorClave", "ProveedorNombre","IposV3.ViewModels.ProveedorListViewModel","SelectedItem","Clave","Nombre"),
                                          new CatalogRelatedFields("CurrentDocto","Sucursal_info","Docto_traslado_Sucursaltid", "Docto_traslado_SucursaltClave", "Docto_traslado_SucursaltNombre","IposV3.ViewModels.Sucursal_infoListViewModel","SelectedItem","Clave"),
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
                                   Model.DBValues._DERECHO_CAMBIARDEALMACEN,
                                   Model.DBValues._DERECHO_GASTOSADIC_COMPRA,
                                   Model.DBValues._DERECHO_IMPORTAR_COMPRAS};
        }



        //Loading data methods
        //loading docto
        public async Task LoadCompra(long doctoId)
        {
            await ClearInfo();
            ClearMovtoItems();
            CurrentDocto!.Id = doctoId;
            try
            {

                IsBusy = true;

                await LoadDoctoFullInfo();

                updateBoolBindingExpressions();
                updateStringBindingExpressions();

            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
            finally
            {
                this.IsBusy = false;
            }

        }



        public async Task LoadDoctoFullInfo()
        {
            PuntoCompraBindingModel? puntoCompraBindingModel = null;

            puntoCompraBindingModel = await this.puntoCompraControllerProvider.GetDocumentInfo(new PuntoCompraBindingModel()
            {
                CurrentDocto = this.currentDocto

            });

            if (puntoCompraBindingModel?.BaseResultBindingModel != null && puntoCompraBindingModel.BaseResultBindingModel.Result >= 0)
            {
                CurrentDocto = puntoCompraBindingModel.CurrentDocto;
                MovtoItems.Clear();
                foreach (var item in puntoCompraBindingModel.MovtoItems)
                {
                    MovtoItems.Add(item);
                }

                CurrentProveedor = puntoCompraBindingModel.CurrentProveedor;

                if (currentDocto != null && CurrentProveedor != null && this.DisableCatalogSearchingDocto)
                {
                    currentDocto.ProveedorClave = CurrentProveedor.Clave;
                    currentDocto.ProveedorNombre = CurrentProveedor.Nombre;
                }

            }
        }



        //loading movto items
        public async Task<List<V_movto_proveeduriaWFBindingModel>> DoGetMovtoItems(long doctoId)
        {
            List<V_movto_proveeduriaWFBindingModel> results = new List<V_movto_proveeduriaWFBindingModel>();
            results = await puntoCompraControllerProvider.Select_V_movto_proveeduria_List(
                                    GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
                                    GlobalVariable.CurrentSession.CurrentConfiguracion.Sucursalid!.Value,
                                    doctoId
                                    ) ?? results;

            return results;
        }

        public async Task ReloadMovtoItems(long doctoId)
        {
            MovtoItems.Clear();
            try
            {
                //bool bSuccess = true;
                IsBusyMovtoList = true;
                System.Collections.Generic.List<V_movto_proveeduriaWFBindingModel> items = new System.Collections.Generic.List<V_movto_proveeduriaWFBindingModel>();

                items = await DoGetMovtoItems(doctoId);

                foreach (var item in items)
                {
                    MovtoItems.Add(item);
                }

            }
            catch (Exception ex)
            {
                ErrorEditActions("Ocurrio un error " + ex.Message);
            }
        }

        //complete info
        public async Task AssignProveedorInfo()
        {
            if (CurrentDocto?.Proveedorid.HasValue != true || CurrentDocto!.Proveedorid!.Value == 0)
            {
                CurrentProveedor = new ProveedorBindingModel();
                return;
            }


            ProveedorBindingModel? buffer = null;

            buffer = await proveedorProvider.GetById(new ProveedorBindingModel()
                {
                    Id = CurrentDocto.Proveedorid.Value,
                    EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                    SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid
                });


            CurrentProveedor = buffer;

            if (currentDocto != null && buffer != null && this.DisableCatalogSearchingDocto)
            {
                currentDocto.ProveedorClave = buffer.Clave;
                currentDocto.ProveedorNombre = buffer.Nombre;
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

        public async Task AbrirCompraCerrada()
        {
            await AbrirCompra(false);
        }

        public async Task AbrirCompraPendiente()
        {
            await AbrirCompra(true);
        }

        public async Task AbrirCompra(bool borrador)
        {

            PuntoCompraListViewModel vm = IoC.Get<PuntoCompraListViewModel>();
            vm.IsSelectionMode = true;
            vm.ListParam = new V_docto_proveeduriaParamWFBindingModel()
            {
                P_empresaid = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                P_sucursalid = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid,
                P_usuarioid = GlobalVariable.CurrentSession!.CurrentUsuario!.Id,
                _usuarioclave = GlobalVariable.CurrentSession!.CurrentUsuario!.Clave,
                P_usuarionombre = GlobalVariable.CurrentSession!.CurrentUsuario!.Nombre,
                P_tipodoctoid = Model.DBValues._DOCTO_TIPO_COMPRA,
                P_fechaini = DateTimeOffset.Now.Date.AddDays(-100),
                P_fechafin = DateTimeOffset.Now.Date.Date,
                P_estatusdoctoid = borrador ? Model.DBValues._DOCTO_ESTATUS_BORRADOR : Model.DBValues._DOCTO_ESTATUS_COMPLETO,
                P_corteActual = BoolCS.S,
                P_todosUsuarios = BoolCS.N,
                P_todosAlmacenes = BoolCS.S,
                P_porFecha = BoolCS.S
        };
            vm.FillParamsByConfig();
            winManager.ShowDialogAsync(vm, null, CreateWinSettings("Compras", 0.75));

            if (vm.selectedItem != null && vm.selectedItem.Id != null)
            {
                await LoadCompra(vm.selectedItem.Id.Value);
                
            }
            else
            {

                updateBoolBindingExpressions();
                updateStringBindingExpressions();
            }


            //Temporal 
            //LoadCompra(53);
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

        public async void DoctoPendingChangeEventHandler(object? sender, AcceptPendingChangeEventArgs e)
        {

            switch (e.PropertyName)
            {
                case "ProveedorClave":
                    if (this.DisableCatalogSearchingDocto)
                        return;

                    CatalogField_PropertyChanging(sender, e);
                    if (!e.CancelPendingChange && e.NewValue != e.OldValue)
                    {
                        await AssignProveedorInfo();
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
                        await this.DecipherCommand(currentMovto?.ProductoClave);
                    }
                    break;


                case "Precio":
                    {

                        if (CurrentMovto?.Productoid == null || CurrentMovto.Productoid == 0)
                            return;

                        await this.AssignPrecioDescuentos(currentMovto!.Precio, null);
                    }
                    break;

                case "Descuentoporcentaje":
                    {

                        if (CurrentMovto?.Productoid == null || CurrentMovto.Productoid == 0)
                            return;

                        await this.AssignPrecioDescuentos(null, currentMovto!.Descuentoporcentaje);
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

            switch (key)
            {
                case Key.F3:
                    await CancelarDocto();
                    break;
                case Key.F2:
                    await NuevaCompra();
                    break;
                case Key.F4:
                    await AbrirCompraPendiente();
                    break;
                case Key.F5:
                    await AbrirCompraCerrada();
                    break;
                case Key.F6:
                    await Pagar();
                    break;
                case Key.System:
                    if (keyArgs.SystemKey == Key.F10)
                    {

                    }
                    break;

            }
        }



        //calculation prices
        private async Task<decimal> PrecioCalculado(long? empresaId, long? sucursalId, long? productoId, long proveedorId, decimal cantidad, long sucursalTid)
        {
            decimal precioCalculado = 0;
            //fnc_preciosprod_ref_provParam.P_sucursaltid = sucursalTid;
            V_preciosProd_RefBindingModel? fnc_preciosprod_ref_provResult = null;


            fnc_preciosprod_ref_provResult = await puntoCompraControllerProvider.Precioprod_ref_prov(empresaId!.Value, sucursalId!.Value, productoId!.Value, proveedorId, cantidad);


            if (fnc_preciosprod_ref_provResult != null && fnc_preciosprod_ref_provResult.Preciolista != null)
                precioCalculado = fnc_preciosprod_ref_provResult.Preciolista.Value;
            else
                precioCalculado = 0;

            return precioCalculado;
        }

        private decimal PrecioBaseSinImpuestos(long? empresaId, long? sucursalId, long? productoId, long proveedorId, decimal cantidad, decimal precioCalculado, long sucursalTid, ProductoBindingModel producto)
        {
            var tipodescuentoprodid = GlobalVariable.CurrentSession?.CurrentParametro?.Tipodescuentoprodid;
            decimal dPrecioBaseSinImpuestos = 0;

            dPrecioBaseSinImpuestos = tipodescuentoprodid == 2 ? precioCalculado : (producto.Producto_precios_Costorepo ?? 0m);
            return dPrecioBaseSinImpuestos;
        }

        private async Task<(decimal?, decimal?)> AssignPrecioDescuentosOut(long? empresaId, long? sucursalId, decimal? precio, decimal? descuento, long? productoId, long proveedorId, decimal cantidad, bool precionetoenpv, ProductoBindingModel producto)
        {

            decimal? precio_final = precio;
            decimal? descuento_final = descuento;

            decimal precioCalculado = 0;
            decimal dPrecioBaseSinImpuestos = 0;
            bool precioEnBaseADescuento = precio == null && descuento != null;
            bool precioPorCalcular = precio == null && descuento == null;

            decimal precioAMostrar = 0m;
            decimal descuentoAMostrar = 0m;

            precioCalculado = await PrecioCalculado(GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                                              GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid,
                                              productoId, proveedorId,
                                              cantidad, 0);

            dPrecioBaseSinImpuestos = PrecioBaseSinImpuestos(empresaId,
                                              sucursalId,
                                              productoId, proveedorId,
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

        private async Task AssignPrecioDescuentos(decimal? precio, decimal? descuento) //(long productoId, long proveedorId, decimal cantidad)
        {
            var precionetoenpv = GlobalVariable.CurrentSession?.CurrentParametro?.Precionetoenpv;

            decimal? precio_final = precio;
            decimal? descuento_final = descuento;

            var bufferPrecioDescuentoFinal = await AssignPrecioDescuentosOut(GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                                              GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid,
                                              precio, descuento,
                                              CurrentProducto?.Id, CurrentProveedor!.Id!.Value,
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
            decimal precio1 = precionetoenpv == BoolCN.S ? prod.Producto_precios_Precio1 ?? 0m : prod.calculaPrecioSinImpuestos(prod.Producto_precios_Precio1 ?? 0m);
            decimal precio2 = precionetoenpv == BoolCN.S ? prod.Producto_precios_Precio2 ?? 0m : prod.calculaPrecioSinImpuestos(prod.Producto_precios_Precio2 ?? 0m);
            decimal precio3 = precionetoenpv == BoolCN.S ? prod.Producto_precios_Precio3 ?? 0m : prod.calculaPrecioSinImpuestos(prod.Producto_precios_Precio3 ?? 0m);
            decimal precio4 = precionetoenpv == BoolCN.S ? prod.Producto_precios_Precio4 ?? 0m : prod.calculaPrecioSinImpuestos(prod.Producto_precios_Precio4 ?? 0m);
            decimal precio5 = precionetoenpv == BoolCN.S ? prod.Producto_precios_Precio5 ?? 0m : prod.calculaPrecioSinImpuestos(prod.Producto_precios_Precio5 ?? 0m);
            decimal precio6 = precionetoenpv == BoolCN.S ? prod.Producto_precios_Precio6 ?? 0m : prod.calculaPrecioSinImpuestos(prod.Producto_precios_Precio6 ?? 0m);

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
            if (key == Key.Enter && Interlocked.Read(ref this.TransaccionEnCurso) <= 0)
            {
                await SaveMovto(null);
            }
            else if (key == Key.Down && Interlocked.Read(ref this.TransaccionEnCurso) <= 0)
            {
                //selectedListPrice = CurrentMovto?.Precio != null ? CurrentMovto.Precio.Value : 0;
                //NotifyOfPropertyChange(() => this.SelectedListPrice);
                ListaPrecioEnabled = DerechosUsuario![Model.DBValues._DERECHO_CAMBIARPRECIOXLISTA_VENTA];
                OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoCompraUICommParams("SetFocus", new List<string>() { "P_precioLista" })), TimeSpan.FromMilliseconds(100));
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
            OneShotTimer.Start(() => aggregator.PublishOnBackgroundThreadAsync(new PuntoCompraUICommParams("SetFocus", new List<string>() { "CurrentMovto.Precio" })), TimeSpan.FromMilliseconds(100));
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
                return (false, "");

            Interlocked.Increment(ref TransaccionEnCurso);

            long empresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid ?? 0;
            long sucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid ?? 0;
            ClearProducto();
            string outMessage = "";
            bool cancelPendingChange = false;
            CurrentMovto!.DescripcionProductoMovto = "";

            bool saveMovto = !CajasBotellasActive && !CantidadEnabled && !PrecioEnabled && !DescuentoEnabled;

            try
            {

                if (commandText == null || commandText.Trim().Length == 0)
                {

                    cancelPendingChange = true;
                    return (cancelPendingChange, outMessage);
                }

                if (!validarDocto())
                {
                    OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoCompraUICommParams("SetFocus", new List<string>() { "CurrentDocto.ProveedorClave" })), TimeSpan.FromMilliseconds(100));
                     
                    return (cancelPendingChange, outMessage);
                }



                PuntoCompraBindingModel? puntoCompraBindingModel = null;

                puntoCompraBindingModel = await this.puntoCompraControllerProvider.DecipherCommand(
                                                                            empresaId, sucursalId, commandText, GlobalVariable.CurrentSession?.CurrentParametro?.Precionetoenpv,
                                                                            GlobalVariable.CurrentSession?.CurrentParametro?.Tipodescuentoprodid, saveMovto, manejAlmacen, currentDocto,
                                                                            GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value);


                if (puntoCompraBindingModel == null || puntoCompraBindingModel.DecipherResult == null)
                {
                    cancelPendingChange = true;
                    outMessage = "No se pudo encontrar el producto";
                    return (cancelPendingChange, outMessage);
                }

                if (puntoCompraBindingModel.DecipherResult.Productoid == null || puntoCompraBindingModel.DecipherResult.Productoid == 0)
                {
                    string errorMessage = puntoCompraBindingModel.DecipherResult.Usermessage != null ?
                                          puntoCompraBindingModel.DecipherResult.Usermessage : "No se pudo encontrar el producto";

                    cancelPendingChange = true;
                    outMessage = errorMessage;
                    return (cancelPendingChange, outMessage);
                }

                if (!saveMovto || (saveMovto && (puntoCompraBindingModel.BaseResultBindingModel.Result ?? 0) < 0))
                {
                    CurrentMovto.Cantidad = puntoCompraBindingModel.CurrentMovto?.Cantidad;
                    CurrentMovto.Productoid = puntoCompraBindingModel.CurrentProducto?.Id;

                    DoAssignProducto(puntoCompraBindingModel.CurrentProducto);


                    CurrentMovto._Precio = puntoCompraBindingModel.CurrentMovto?.Precio;
                    CurrentMovto._Descuentoporcentaje = puntoCompraBindingModel.CurrentMovto?.Descuentoporcentaje;

                    await AssignPrecioDescuentos(null, null);
                    AssignListaPrecios(currentProducto!);
                    ConfigureCajasBotellas();

                    if (CajasBotellasActive)
                        OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoCompraUICommParams("SetFocus", new List<string>() { "Cajas" })), TimeSpan.FromMilliseconds(100));
                    else if (CantidadEnabled)
                        OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoCompraUICommParams("SetFocus", new List<string>() { "CurrentMovto.Cantidad" })), TimeSpan.FromMilliseconds(100));
                    else if (PrecioEnabled)
                        OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoCompraUICommParams("SetFocus", new List<string>() { "CurrentMovto.Precio" })), TimeSpan.FromMilliseconds(100));
                    else if (DescuentoEnabled)
                        OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoCompraUICommParams("SetFocus", new List<string>() { "CurrentMovto.Descuento" })), TimeSpan.FromMilliseconds(100));


                    if (saveMovto)
                    {
                        await SaveMovto(null);
                    }

                }
                else
                {
                    if (puntoCompraBindingModel.BaseResultBindingModel != null && puntoCompraBindingModel.BaseResultBindingModel.Result >= 0)
                    {
                        CurrentDocto = puntoCompraBindingModel.CurrentDocto;
                        MovtoItems.Clear();
                        foreach (var item in puntoCompraBindingModel.MovtoItems)
                        {
                            MovtoItems.Add(item);
                        }

                        ClearMovto();
                        ClearProducto();
                        updateBoolBindingExpressions();
                        updateStringBindingExpressions();

                        OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoCompraUICommParams("SetFocus", new List<string>() { "CurrentMovto.Productoclave" })), TimeSpan.FromMilliseconds(100));
                        
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


        //lote movto
        private bool PreguntaLoteIfNeeded()
        {
            if (CurrentMovto!.Lote != null && CurrentMovto.Lote.Length > 0)
                return true;

            CurrentMovto.Lote = null;
            CurrentMovto.Fechavence = null;

            if (CurrentProducto == null || CurrentProducto.Id == 0)
                return false;

            if (CurrentProducto.Producto_inventario_Manejalote == null || CurrentProducto.Producto_inventario_Manejalote != BoolCN.S)
                return true;

            LoteDefinicionWFViewModel vm = IoC.Get<LoteDefinicionWFViewModel>();
            vm.LoteItem!.Productoid = CurrentProducto.Id;
            vm.LoteItem!.Productoclave = CurrentProducto.Clave;
            vm.LoteItem!.Productonombre = CurrentProducto.Nombre;
            winManager.ShowDialogAsync(vm, null, CreateWinSettingsWithPixels("Seleccion de lote", 500, 540));

            if (vm.BProcessSuccess)
            {
                CurrentMovto.Lote = vm.LoteItem!.Lote;
                CurrentMovto.Fechavence = vm.LoteItem!.Fechavence;
                return true;
            }

            return false;
        }


        //lote importado movto
        private bool PreguntaLoteImportadoIfNeeded()
        {
            if (CurrentMovto!.Loteimportado != null && CurrentMovto.Loteimportado.Value > 0)
                return true;

            CurrentMovto.Loteimportado = null;


            if (CurrentProducto == null || CurrentProducto.Id == 0)
                return false;

            if (CurrentProducto.Producto_loteimportado_Manejaloteimportado == null || CurrentProducto.Producto_loteimportado_Manejaloteimportado != BoolCN.S)
                return true;

            LoteImportadoDefinicionWFViewModel vm = IoC.Get<LoteImportadoDefinicionWFViewModel>();
            vm.LoteImportadoItem!.P_empresaid = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid;
            vm.LoteImportadoItem!.P_sucursalid = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid;
            vm.LoteImportadoItem!.Productoid = CurrentProducto.Id;
            vm.LoteImportadoItem!.Productoclave = CurrentProducto.Clave;
            vm.LoteImportadoItem!.Productonombre = CurrentProducto.Nombre;
            winManager.ShowDialogAsync(vm, null, CreateWinSettings("Compras", 0.60, 0.60));

            if (vm.BProcessSuccess)
            {
                CurrentMovto.Loteimportado = vm.LoteImportadoId;
                return true;
            }

            return false;
        }


        //descripcion comodin movto
        private bool PreguntaDescripcionComodinIfNeeded()
        {

            if (CurrentProducto == null || CurrentProducto.Id == 0)
                return false;

            if (CurrentProducto.Producto_comodin_Descripcion_comodin == null || 
                CurrentProducto.Producto_comodin_Descripcion_comodin != BoolCN.S)
                return true;

            if (CurrentMovto!.Id != null && CurrentMovto.Id > 0)
                return true;

            if (!string.IsNullOrEmpty(CurrentMovto!.Movto_comodin_Descripcion1) ||
                !string.IsNullOrEmpty(CurrentMovto!.Movto_comodin_Descripcion2) ||
                !string.IsNullOrEmpty(CurrentMovto!.Movto_comodin_Descripcion3) )
                return true;

            CurrentMovto.Movto_comodin_Descripcion1 = null;
            CurrentMovto.Movto_comodin_Descripcion2 = null;
            CurrentMovto.Movto_comodin_Descripcion3 = null;



            WFDescripcionComodinWFViewModel vm = IoC.Get<WFDescripcionComodinWFViewModel>();
            winManager.ShowDialogAsync(vm, null, CreateWinSettingsWithPixels("Descripcion comodin", 500, 500));

            if (vm.BProcessSuccess)
            {
                CurrentMovto.Movto_comodin_Descripcion1 = vm.WFDescripcionComodinItem!.Tbdesc1;
                CurrentMovto.Movto_comodin_Descripcion2 = vm.WFDescripcionComodinItem!.Tbdesc2;
                CurrentMovto.Movto_comodin_Descripcion3 = vm.WFDescripcionComodinItem!.Tbdesc3;
                return true;
            }

           

            return false;
        }



        //gastos adicionales
        private bool PreguntaGastosAdicionalesIfNeeded()
        {
            if(CurrentDocto == null || (CurrentDocto.Id ?? 0) == 0 || (CurrentDocto.Tipodoctoid ?? 0) != DBValues._DOCTO_TIPO_COMPRA)
                return true;

            if (GlobalSession!.CurrentParametro!.Manejagastosadic != BoolCN.S)
                return true;


            if (!ShowSiNoMessageBox("Desea agregar gastos adicionales", "Confirmacion"))
                return true;

               MovtogastosadicEditViewModel vm = IoC.Get<MovtogastosadicEditViewModel>();
                vm.CurrentDocto = CurrentDocto;
                winManager.ShowDialogAsync(vm, null, CreateWinSettingsWithPixels("Gastos adicionales de compra", 650, 600));


            return true;
        }

        //Save movto

        private bool validarDocto()
        {


            if (CurrentDocto == null)
            {
                MessageBox.Show("Debe primero agregar el docto");
                return false;
            }
            if (CurrentDocto.Id <= 0 || CurrentDocto.Id == null)
            {

                if( CurrentDocto?.Almacenid == null)
                {
                    switch(CurrentDocto!.Tipodoctoid)
                    {
                        case DBValues._DOCTO_TIPO_ORDEN_COMPRA:
                            CurrentDocto.Almacenid = DBValues._ALMACEN_DEFAULT;
                            break;

                        default:
                            MessageBox.Show("Debe elegir un almacen");
                            return false;
                    }
                      
                }
            
                if (CurrentDocto.Tipodoctoid == DBValues._DOCTO_TIPO_COMPRA && CurrentDocto?.Proveedorid == null)
                {

                    MessageBox.Show("Debe elegir un proveedor ");
                    return false;
                }

                if (CurrentDocto.Tipodoctoid == DBValues._DOCTO_TIPO_COMPRA && CurrentDocto?.Origenfiscalid == null)
                {

                    switch (CurrentDocto!.Tipodoctoid)
                    {
                        case DBValues._DOCTO_TIPO_ORDEN_COMPRA:
                            CurrentDocto.Origenfiscalid = DBValues._ORIGENFISCAL_REMISIONADO;
                            break;

                        default:
                            MessageBox.Show("Debe elegir un origen fiscal");
                            return false;
                    }

                }
                
            }

            return true;

        }



        public MovtoProvTrans FillAddMovtoParameters(MovtoBindingModel movto, DoctoBindingModel docto, bool? precionetoenpv,
                                           decimal? precio, decimal? cantidad, string? lote, DateTimeOffset? fechavence,
                                           long? loteImportado, long usuarioId)
        {

            var Fnc_movto_prov_insertParam = new MovtoProvTrans();


            Fnc_movto_prov_insertParam.Loteimportado = loteImportado ?? movto.Loteimportado;
            Fnc_movto_prov_insertParam.Movtoparentid = null;
            Fnc_movto_prov_insertParam.Agrupaporparametro = BoolCN.N;
            Fnc_movto_prov_insertParam.Cargartarjetapreciomanual = BoolCN.N;
            Fnc_movto_prov_insertParam.Precioyavalidado = BoolCN.N;
            Fnc_movto_prov_insertParam.Usuarioid = usuarioId;

            Fnc_movto_prov_insertParam.Lote = lote ?? movto.Lote;
            Fnc_movto_prov_insertParam.Fechavence = fechavence ?? movto.Fechavence;
            Fnc_movto_prov_insertParam.Localidad = movto.Movto_inventario_Localidad;
            Fnc_movto_prov_insertParam.Descripcion1 = movto.Movto_comodin_Descripcion1;
            Fnc_movto_prov_insertParam.Descripcion2 = movto.Movto_comodin_Descripcion2;
            Fnc_movto_prov_insertParam.Descripcion3 = movto.Movto_comodin_Descripcion3;
            Fnc_movto_prov_insertParam.Empresaid = movto!.EmpresaId!.Value;
            Fnc_movto_prov_insertParam.Sucursalid = movto!.SucursalId!.Value;
            Fnc_movto_prov_insertParam.Id = movto.Id != null ? movto!.Id : 0;
            Fnc_movto_prov_insertParam.Doctoid = docto!.Id!.Value;
            Fnc_movto_prov_insertParam.Partida = movto.Partida;
            Fnc_movto_prov_insertParam.Estatusmovtoid = movto!.Estatusmovtoid!.Value;
            Fnc_movto_prov_insertParam.Productoid = movto!.Productoid!.Value;

            Fnc_movto_prov_insertParam.Cantidad = cantidad!.Value;
            Fnc_movto_prov_insertParam.Descuentoporcentaje = movto.Descuentoporcentaje;

            Fnc_movto_prov_insertParam.Precio = precio;

            if (!(precionetoenpv ?? false))
            {
                Fnc_movto_prov_insertParam.Precioconimp = movto!.Precio;
            }

            return Fnc_movto_prov_insertParam;
        }


        public async Task SaveMovto(MovtoProvTrans? movtoEditado)
        {

            if (Interlocked.Read(ref this.TransaccionEnCurso) > 0)
                return;


            Interlocked.Increment(ref TransaccionEnCurso);


            try
            {

                decimal? precio = null;
                decimal? cantidadTotal = null;
                bool precionetoenpv = GlobalVariable.CurrentSession?.CurrentParametro?.Precionetoenpv == BoolCN.S;

                if (movtoEditado == null)
                {

                    if (!PreguntaLoteIfNeeded())
                    {
                        MessageBox.Show("Debe seleccionar un lote");
                        return;
                    }

                    if (!PreguntaLoteImportadoIfNeeded())
                    {

                        MessageBox.Show("Debe seleccionar un lote importado");
                        return;
                    }


                    if (!PreguntaDescripcionComodinIfNeeded())
                    {

                        MessageBox.Show("Debe escribir por lo menos la descripcion 1");
                        return;
                    }


                    if (!validarDocto())
                        return;



                    cantidadTotal = (
                                                                    CajasBotellasActive && Cajas > 0 ?
                                                                        (Cajas * (CurrentProducto!.Producto_inventario_Pzacaja != null && CurrentProducto.Producto_inventario_Pzacaja.Value > 0 ? CurrentProducto.Producto_inventario_Pzacaja.Value : 1)) + CurrentMovto!.Cantidad :
                                                                      CurrentMovto!.Cantidad
                                                                      ) ?? 0m;

                    precio = precionetoenpv ? CurrentMovto.Precio : CurrentProducto!.calculaPrecioSinImpuestos(CurrentMovto!.Precio!.Value);


                }

                PuntoCompraBindingModel? puntoCompraBindingModel = null;

                puntoCompraBindingModel = new PuntoCompraBindingModel();
                puntoCompraBindingModel.MovtoTransList = new List<MovtoProvTrans>();
                puntoCompraBindingModel.CurrentDocto = currentDocto;


                if (movtoEditado == null)
                {

                    var bufferMovtoItemTrans = FillAddMovtoParameters(CurrentMovto!, CurrentDocto!, precionetoenpv,
                                                                    precio, cantidadTotal, null, null, null, GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value);
                    bufferMovtoItemTrans.EsMovtoPrincipal = true;
                    puntoCompraBindingModel.MovtoTransList.Add(bufferMovtoItemTrans);
                }
                else
                {

                    movtoEditado.EsMovtoPrincipal = true;
                    puntoCompraBindingModel.MovtoTransList.Add(movtoEditado!);
                }


                puntoCompraBindingModel = await this.puntoCompraControllerProvider.SaveMovto(puntoCompraBindingModel);


                if (puntoCompraBindingModel?.BaseResultBindingModel != null && puntoCompraBindingModel.BaseResultBindingModel.Result >= 0)
                {
                    CurrentDocto = puntoCompraBindingModel.CurrentDocto;

                    MovtoItems.Clear();
                    if (puntoCompraBindingModel.MovtoItems != null)
                    {

                        foreach (var item in puntoCompraBindingModel.MovtoItems)
                        {
                            MovtoItems.Add(item);
                        }

                    }


                    ClearMovto();
                    ClearProducto();
                    updateBoolBindingExpressions();
                    updateStringBindingExpressions();
                    OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoCompraUICommParams("SetFocus", new List<string>() { "CurrentMovto.Productoclave" })), TimeSpan.FromMilliseconds(100));
                }
                else
                {
                    ErrorEditActions(puntoCompraBindingModel?.BaseResultBindingModel?.Usermessage ?? "Ocurrio un error");
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
            }


        }







        //pay and complete transaction

        public async Task Pagar()
        {
            try
            {
                if (CurrentDocto == null || CurrentDocto.Id == null || CurrentDocto.Id == 0 || CurrentDocto.Estatusdoctoid == null ||
                   CurrentDocto.Estatusdoctoid.Value != Model.DBValues._DOCTO_ESTATUS_BORRADOR)
                    return;


                PreguntaGastosAdicionalesIfNeeded();

                //TODO temporal
                V_pagomultiple_compraViewModel vm = IoC.Get<V_pagomultiple_compraViewModel>();
                vm.PagoItem!.Total = CurrentDocto.Total;
                vm.PagoItem!.Restante = CurrentDocto.Total;
                winManager.ShowDialogAsync(vm, null, CreateWinSettings("Compras", 0.60, 0.80));


                //temporal 
                //var vm_BProcessSuccess = true;
                //if(vm_BProcessSuccess)

                if (vm.BProcessSuccess)
                {

                    //TODO temporal
                    V_pagomultiple_compraWFBindingModel pagosParam = vm.PagoItem;
                    //V_pagomultiple_compraWFBindingModel pagosParam = new V_pagomultiple_compraWFBindingModel();
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
                            Clienteid = null,// ? P_clienteid
                            Proveedorid = CurrentDocto.Proveedorid,//, long ? P_proveedorid
                            Usuarioid = GlobalSession?.CurrentUsuario?.Id, //, long ? P_usuarioid
                            Sentidopago = -1//, int ? P_sentidopago
                        };
                        paymentList.Add(paymentParam);
                    }

                    if (ZeroIfNull(pagosParam.Montotarjeta) > 0.0m)
                    {

                        paymentParam = new DoctoPagoDirect() {
                                Empresaid = CurrentDocto.EmpresaId!.Value,
                                Sucursalid = CurrentDocto.SucursalId!.Value,
                                Doctoid = CurrentDocto.Id,
                                Corteid = this.CorteId,
                                Formapagoid = Model.DBValues._FORMA_PAGO_TARJETA,
                                Formapagosatid = pagosParam.Tipotarjeta,
                                Importe = pagosParam.Montotarjeta!.Value,
                                Importecambio = 0.0m,// decimal ? P_importecambio
                                Bancoid = pagosParam.Bancotarjetaid, // long ? P_bancoid
                                Referenciabancaria = pagosParam.Referenciatarjeta, // string P_referenciabancaria
                                Espagoinicial = BoolCN.S, //, string P_espagoinicial
                                Tipopagoid = Model.DBValues._TIPOPAGO_SALIDA, // long ? P_tipopagoid
                                Tipoabonoid = Model.DBValues._TIPO_ABONO_INICIAL,// long ? P_tipoabonoid
                                Clienteid = null,// ? P_clienteid
                                Proveedorid = CurrentDocto.Proveedorid,//, long ? P_proveedorid
                                Usuarioid = GlobalSession?.CurrentUsuario?.Id, //, long ? P_usuarioid
                                Sentidopago = -1//, int ? P_sentidopago
                        };
                        paymentList.Add(paymentParam);
                    }

                    if (ZeroIfNull(pagosParam.Montocheque) > 0.0m)
                    {

                        paymentParam = new DoctoPagoDirect() {
                                Empresaid = CurrentDocto.EmpresaId!.Value,
                                Sucursalid = CurrentDocto.SucursalId!.Value,
                                Doctoid = CurrentDocto.Id,
                                Corteid = this.CorteId,
                                Formapagoid = Model.DBValues._FORMA_PAGO_CHEQUE,
                                Formapagosatid = Model.DBValues._FORMA_PAGOSAT_CHEQUE,
                                Importe = pagosParam.Montocheque!.Value,
                                Importecambio = 0.0m,// decimal ? P_importecambio
                                Bancoid = pagosParam.Bancochequeid, // long ? P_bancoid
                                Referenciabancaria = pagosParam.Referenciacheque, // string P_referenciabancaria
                                Espagoinicial = BoolCN.S, //, string P_espagoinicial
                                Tipopagoid = Model.DBValues._TIPOPAGO_SALIDA, // long ? P_tipopagoid
                                Tipoabonoid = Model.DBValues._TIPO_ABONO_INICIAL,// long ? P_tipoabonoid
                                Clienteid = null,// ? P_clienteid
                                Proveedorid = CurrentDocto.Proveedorid,//, long ? P_proveedorid
                                Usuarioid = GlobalSession?.CurrentUsuario?.Id, //, long ? P_usuarioid
                                Sentidopago = -1//, int ? P_sentidopago
                        };
                        paymentList.Add(paymentParam);
                    }


                    if (ZeroIfNull(pagosParam.Montotransferencia) > 0.0m)
                    {

                        paymentParam = new DoctoPagoDirect() {
                                Empresaid = CurrentDocto.EmpresaId!.Value,
                                Sucursalid = CurrentDocto.SucursalId!.Value,
                                Doctoid = CurrentDocto.Id,
                                Corteid = this.CorteId,
                                Formapagoid = Model.DBValues._FORMA_PAGO_TRANSFERENCIA,
                                Formapagosatid = Model.DBValues._FORMA_PAGOSAT_TRANSFERENCIA,
                                Importe = pagosParam.Montotransferencia!.Value,
                                Importecambio = 0.0m,// decimal ? P_importecambio
                                Bancoid = pagosParam.Bancotransferenciaid, // long ? P_bancoid
                                Referenciabancaria = pagosParam.Referenciatransferencia, // string P_referenciabancaria
                                Espagoinicial = BoolCN.S, //, string P_espagoinicial
                                Tipopagoid = Model.DBValues._TIPOPAGO_SALIDA, // long ? P_tipopagoid
                                Tipoabonoid = Model.DBValues._TIPO_ABONO_INICIAL,// long ? P_tipoabonoid
                                Clienteid = null,// ? P_clienteid
                                Proveedorid = CurrentDocto.Proveedorid,//, long ? P_proveedorid
                                Usuarioid = GlobalSession?.CurrentUsuario?.Id, //, long ? P_usuarioid
                                Sentidopago = -1//, int ? P_sentidopago
                        };
                        paymentList.Add(paymentParam);
                    }

                    if (ZeroIfNull(pagosParam.Montocredito) > 0.0m)
                    {

                        paymentParam = new DoctoPagoDirect() {
                                Empresaid = CurrentDocto.EmpresaId!.Value,
                                Sucursalid = CurrentDocto.SucursalId!.Value,
                                Doctoid = CurrentDocto.Id,
                                Corteid = this.CorteId,
                                Formapagoid = Model.DBValues._FORMA_PAGO_CREDITO,
                                Formapagosatid = Model.DBValues._FORMA_PAGOSAT_OTRO,
                                Importe = pagosParam.Montocredito!.Value,
                                Importecambio = 0.0m,// decimal ? P_importecambio
                                Bancoid = null, // long ? P_bancoid
                                Referenciabancaria = null, // string P_referenciabancaria
                                Espagoinicial = BoolCN.S, //, string P_espagoinicial
                                Tipopagoid = Model.DBValues._TIPOPAGO_SALIDA, // long ? P_tipopagoid
                                Tipoabonoid = Model.DBValues._TIPO_ABONO_INICIAL,// long ? P_tipoabonoid
                                Clienteid = null,// ? P_clienteid
                                Proveedorid = CurrentDocto.Proveedorid,//, long ? P_proveedorid
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

        public async Task CompletarDocto(V_pagomultiple_compraWFBindingModel pagosParam, List<DoctoPagoDirect> paymentList)
        {
            

            bool bSuccess = true;
            IsBusy = true;
            var comentario = "";

            try
            {
                var result = await puntoCompraControllerProvider.Docto_prov_and_payments_save(
                                                                    GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
                                                                    GlobalVariable.CurrentSession!.CurrentConfiguracion!.Sucursalid!.Value,
                                                                    CurrentDocto!.Id!.Value,
                                                                    paymentList
                                                                    );

                bSuccess = result != null && result.Result >= 0;
                comentario = result != null ? result.Usermessage : "Error ...";

                if (!bSuccess)
                {
                    ErrorEditActions(comentario);
                }
                else
                {

                    if (GlobalSession!.CurrentUsuario!.Ticketlargo == BoolCN.S)
                    {
                        await DoImprimirDoctoTicketLargo();
                    }
                    else
                    {
                        DoImprimirDoctoTicketCorto();
                    }





                    await NuevaCompra();
                    OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoCompraUICommParams("SetFocus", new List<string>() { "CurrentMovto.Productoclave" })), TimeSpan.FromMilliseconds(100));

                    updateBoolBindingExpressions();
                    updateStringBindingExpressions();

                }



            }
            catch(Exception ex)
            {

                comentario = ex.Message;
                ErrorEditActions(comentario);


            }
            finally
            {
                this.IsBusy = false;
            }




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
                    return;
                }

                if (ShowSiNoMessageBox("Realmente desea cancelar el documento", "Confirmacion"))
                {

                    if (CurrentDocto.Estatusdoctoid == null || CurrentDocto.Estatusdoctoid == Model.DBValues._DOCTO_ESTATUS_BORRADOR)
                    {

                        BaseResultBindingModel? resultOperation = null;

                        resultOperation = await puntoCompraControllerProvider.Docto_prov_delete(CurrentDocto!.EmpresaId!.Value, CurrentDocto!.SucursalId!.Value, currentDocto!.Id!.Value);
                        
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

                            await NuevaCompra();
                        }
                    }
                    else if (CurrentDocto.Estatusdoctoid == Model.DBValues._DOCTO_ESTATUS_COMPLETO)
                    {


                        BaseResultBindingModel? resultOperation = null;

                        resultOperation = await puntoCompraControllerProvider.Docto_prov_cancel(CurrentDocto!.EmpresaId!.Value, CurrentDocto!.SucursalId!.Value, CurrentDocto!.Id!.Value, GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value);
                        

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

                            await NuevaCompra();
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
            OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoCompraUICommParams("SetFocus", new List<string>() { "CurrentMovto.Productoclave" })), TimeSpan.FromMilliseconds(100));

        }



        //print docto
        public async Task ImprimirDocto()
        {

            if (GlobalSession!.CurrentUsuario!.Ticketlargo == BoolCN.S)
            {
                await DoImprimirDoctoTicketLargo();
            }
            else
            {
                DoImprimirDoctoTicketCorto();
            }
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

            winManager.ShowDialogAsync(vm, null, CreateWinSettings("Compras", 0.75));


        }

        private void DoImprimirDoctoTicketCorto()
        {

            if (GlobalVariable.CurrentDataBaseConnectionFnc == null)
                return;

            ReportePrintingViewModel vm = IoC.Get<ReportePrintingViewModel>();


            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("pempresaid", CurrentDocto!.EmpresaId!.Value);
            dict.Add("psucursalid", CurrentDocto.SucursalId!.Value);
            dict.Add("pdoctoid", CurrentDocto.Id!.Value);
            dict.Add("usaDatosDeEntregaCuandoExista", "N");
            dict.Add("desglosekits", "S");
            dict.Add("marcaAgua", "N");
            dict.Add("enDolar", "N");
            dict.Add("creadoPorUserId", 0);


            vm.FastReportInfo = new FastReportInfo()
            {
                //RutaReporte = FastReportsConfig.getPathForFile("TicketCompras.frx", FastReportsTipoFile.desistema),
                RutaReporte = FastReportsConfig.getPathForFile("TicketCompras.frx", FastReportsTipoFile.desistema),
                DictionaryReporte = dict,
                ConnectionString = GlobalVariable.CurrentDataBaseConnectionFnc(),
                Userid = GlobalVariable.CurrentSession!.Usuarioid!.Value,
                UserName = GlobalVariable.CurrentSession!.CurrentUsuario!.Nombre
            };
            winManager.ShowDialogAsync(vm, null, CreateWinSettings("Compras", 0.75));

        }



        //grid movto events

        async void MovtoItem_PendingChange(object sender, AcceptPendingChangeEventArgs e)
        {
            V_movto_proveeduriaWFBindingModel movtoItem = (V_movto_proveeduriaWFBindingModel)sender;
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
                foreach (V_movto_proveeduriaWFBindingModel item in e.NewItems)
                    item.PendingChange += MovtoItem_PendingChange;

            if (e.OldItems != null)
                foreach (V_movto_proveeduriaWFBindingModel item in e.OldItems)
                    item.PendingChange -= MovtoItem_PendingChange;
        }

        public async Task<bool> SaveMovtoFromGrid(V_movto_proveeduriaWFBindingModel movtoItem, string propertyChanged, object newVal)
        {


            var precionetoenpv = GlobalVariable.CurrentSession?.CurrentParametro?.Precionetoengrids;
            if (precionetoenpv == null)
                precionetoenpv = BoolCN.S;

            var Fnc_movto_prov_insertParam = new MovtoProvTrans();

            Fnc_movto_prov_insertParam.Fechavence = movtoItem.Fechavence;
            Fnc_movto_prov_insertParam.Loteimportado = movtoItem.Loteimportado;
            Fnc_movto_prov_insertParam.Movtoparentid = null;
            Fnc_movto_prov_insertParam.Agrupaporparametro = BoolCN.N;
            Fnc_movto_prov_insertParam.Cargartarjetapreciomanual = BoolCN.N;
            Fnc_movto_prov_insertParam.Precioyavalidado = BoolCN.N;
            Fnc_movto_prov_insertParam.Usuarioid = GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value;

            Fnc_movto_prov_insertParam.Lote = movtoItem.Lote;
            Fnc_movto_prov_insertParam.Localidad = null;//movtoItem.Localidad;
            Fnc_movto_prov_insertParam.Descripcion1 = movtoItem.Descripcion1;
            Fnc_movto_prov_insertParam.Descripcion2 = movtoItem.Descripcion2;
            Fnc_movto_prov_insertParam.Descripcion3 = movtoItem.Descripcion3;
            Fnc_movto_prov_insertParam.Empresaid = movtoItem.EmpresaId!.Value;
            Fnc_movto_prov_insertParam.Sucursalid = movtoItem.SucursalId!.Value;
            Fnc_movto_prov_insertParam.Id = movtoItem.Id;
            Fnc_movto_prov_insertParam.Doctoid = movtoItem.Doctoid!.Value;
            Fnc_movto_prov_insertParam.Partida = movtoItem.Partida;
            Fnc_movto_prov_insertParam.Estatusmovtoid = Model.DBValues._MOVTO_ESTATUS_BORRADOR;
            Fnc_movto_prov_insertParam.Productoid = movtoItem.Productoid!.Value;


            switch (propertyChanged)
            {
                case "Cantidad":
                    {
                        Fnc_movto_prov_insertParam.Cantidad = (decimal?)((decimal)newVal - movtoItem.Cantidad) ?? 0m;
                        Fnc_movto_prov_insertParam.Precio = null;
                        Fnc_movto_prov_insertParam.Descuentoporcentaje = null;
                        break;
                    }

                case "Preciomostrar":
                    {
                        Fnc_movto_prov_insertParam.Cantidad = 0;


                        var product = new ProductoBindingModel();
                        product.EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid;
                        product.SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid;
                        product.Id = movtoItem.Productoid;


                        product = await productoProvider.GetById(product);

                        if (product == null || CurrentProveedor == null || movtoItem == null)
                            return false;

                        decimal? precio_final = (decimal)newVal;
                        decimal? descuento_final = null;

                        var bufferPrecioDescuentoFinal = await AssignPrecioDescuentosOut(GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                                                          GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid,
                                                          (decimal)newVal, null,
                                                          product.Id, CurrentProveedor.Id!.Value,
                                                          (movtoItem.Cantidad ?? 0m), (precionetoenpv.Value == BoolCN.S), product);
                        precio_final = bufferPrecioDescuentoFinal.Item1;
                        descuento_final = bufferPrecioDescuentoFinal.Item2;

                        Fnc_movto_prov_insertParam.Precio = precionetoenpv.Value == BoolCN.S ? precio_final : product.calculaPrecioSinImpuestos((precio_final ?? 0m));
                        Fnc_movto_prov_insertParam.Descuentoporcentaje = descuento_final;

                        break;
                    }

                case "Descuentoporcentaje":
                    {
                        Fnc_movto_prov_insertParam.Cantidad = 0;
                        Fnc_movto_prov_insertParam.Descuentoporcentaje = (decimal)newVal;



                        var product = new ProductoBindingModel();
                        product.EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid;
                        product.SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid;
                        product.Id = movtoItem.Productoid;


                        product = await productoProvider.GetById(product);

                        if (product == null || CurrentProveedor == null || movtoItem == null)
                            return false;

                        decimal? precio_final = null;
                        decimal? descuento_final = (decimal)newVal;

                        var bufferPrecioDescuentoFinal = await AssignPrecioDescuentosOut(GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                                                          GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid,
                                                           null, (decimal)newVal,
                                                          product.Id, CurrentProveedor.Id!.Value,
                                                          (movtoItem.Cantidad ?? 0m), (precionetoenpv.Value == BoolCN.S), product);
                        precio_final = bufferPrecioDescuentoFinal.Item1;
                        descuento_final = bufferPrecioDescuentoFinal.Item2;


                        Fnc_movto_prov_insertParam.Precio = precionetoenpv.Value == BoolCN.S ? precio_final : product.calculaPrecioSinImpuestos((precio_final ?? 0m));
                        Fnc_movto_prov_insertParam.Descuentoporcentaje = descuento_final;


                        break;
                    }
            }

            await SaveMovto(Fnc_movto_prov_insertParam);

            //Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
            //    new System.Action(() => ReloadMovtoItems((long)CurrentDocto!.Id!.Value)));



            return false;
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
                    var listIds = SelectedMovtoItems.Select(item => ((V_movto_proveeduriaWFBindingModel)item).Id!.Value).ToList();

                    PuntoCompraBindingModel? puntoCompraBindingModel = null;

                    puntoCompraBindingModel = await puntoCompraControllerProvider.Movto_prov_delete(CurrentDocto.EmpresaId!.Value, CurrentDocto.SucursalId!.Value, listIds, CurrentDocto!.Id!.Value);



                    if (puntoCompraBindingModel?.BaseResultBindingModel != null && puntoCompraBindingModel.BaseResultBindingModel.Result >= 0)
                    {
                        CurrentDocto = puntoCompraBindingModel.CurrentDocto;
                        MovtoItems.Clear();
                        foreach (var movto in puntoCompraBindingModel.MovtoItems)
                        {
                            MovtoItems.Add(movto);
                        }

                        ClearMovto();
                        ClearProducto();
                        updateBoolBindingExpressions();
                        updateStringBindingExpressions();
                        OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoCompraUICommParams("SetFocus", new List<string>() { "CurrentMovto.Productoclave" })), TimeSpan.FromMilliseconds(100));
                    }
                    else if (puntoCompraBindingModel?.BaseResultBindingModel != null && puntoCompraBindingModel?.BaseResultBindingModel.Result < 0)
                    {
                        ErrorEditActions("Ocurrio un error " + puntoCompraBindingModel?.BaseResultBindingModel!.Usermessage);
                        return;
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
                                                                                new MessageToUserSimple("Exito", "Se completo la operacion ", "Success") :
                                                                                new MessageToUserSimple("Error", "Occurrio un error ", "Error"));

            aggregator.PublishOnBackgroundThreadAsync(eventParam);
            //aggregator.PublishOnUIThread(new NavigationParameter(null, false, true));
        }

        public void ErrorEditActions(string comentario)
        {
            showPopUpMessage("Ocurrio un error ", comentario, "Error");
        }


    }
}
