
using BindingModels;
using IposV3.Model;
using IposV3.BindingModel;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
//using IposV3.Controllers.Controller;
//using DataAccess;
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

namespace IposV3.ViewModels
{

    public class Movto_solicitud_mercanciaWFViewModel : BaseOperationalScreen
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


        private ProductoBindingModel? currentProducto;
        public ProductoBindingModel? CurrentProducto { get => currentProducto; set { currentProducto = value; NotifyOfPropertyChange("CurrentProducto"); } }




        //Internal grids properties
        public ObservableCollection<Movto_solicitud_mercanciaWFBindingModel> MovtoItems { get; set; }
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


        //Controller providers
        protected readonly DoctoWebController doctoProvider;
        protected readonly MovtoWebController movtoProvider;
        protected readonly ProveedorWebController proveedorProvider;
        protected readonly ProductoWebController productoProvider;
        protected readonly Sucursal_infoWebController sucursal_extProvider;
        private readonly GlobalWebController globalControllerProvider;
        private readonly PuntoCompraWebController puntoCompraControllerProvider;
        private readonly PuntoSolicitudMercanciaWebController puntoSolicitudMercanciaControllerProvider;
        protected readonly ImpoExpoWebController impoExpoProvider;
        //protected readonly IEventAggregator aggregator;


        //public Movto_solicitud_mercanciaWFBindingModel? Movto_solicitud_mercanciaItem { get; set; }


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


        public Movto_solicitud_mercanciaWFViewModel(

            //controller providers
            DoctoWebController doctoprovider,
            MovtoWebController movtoprovider,
            ProveedorWebController proveedorprovider,
            Sucursal_infoWebController sucursal_extprovider,
            ProductoWebController productoProvider,
            PuntoCompraWebController puntoCompraControllerProvider,
            PuntoSolicitudMercanciaWebController puntoSolicitudMercanciaControllerProvider,
            GlobalWebController globalControllerProvider,
            UsuarioWebController usuarioControllerProvider,
            //TicketstemplatesControllerProvider ticketstemplatesControllerProvider,
            CorteWebController corteControllerProvider,
            ImpoExpoWebController impoExpoProvider,

            SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService, usuarioControllerProvider, corteControllerProvider)
        {


            //controller providers assign
            this.doctoProvider = doctoprovider;
            this.movtoProvider = movtoprovider;
            this.proveedorProvider = proveedorprovider;
            this.sucursal_extProvider = sucursal_extprovider;
            this.productoProvider = productoProvider;
            this.puntoCompraControllerProvider = puntoCompraControllerProvider;
            this.puntoSolicitudMercanciaControllerProvider = puntoSolicitudMercanciaControllerProvider;
            this.globalControllerProvider = globalControllerProvider;
            this.impoExpoProvider = impoExpoProvider;


            //suscribe to change events
            //this.aggregator = aggregator;
            this.aggregator.SubscribeOnUIThread(this);

            //fill catalogs configuration and autocomplete
            GlobalSession? bufferSession = GlobalVariable.CurrentSession;
            globalControllerProvider.llenarProductAutoCompleteList(ref bufferSession);
            fillCatalogConfiguration();


            //initialize clock
            initializeClock();


            //Clear and initialize movtoitems
            MovtoItems = new ObservableCollection<Movto_solicitud_mercanciaWFBindingModel>();
            MovtoItems.CollectionChanged += MovtoItems_CollectionChanged;
            ClearInfo();
            InitialState();


            //configurate fields
            ConfigureMovtoFields();

            //Movto_solicitud_mercanciaItem = new Movto_solicitud_mercanciaWFBindingModel();
            //Movto_solicitud_mercanciaItem!.PendingChange += CatalogField_PropertyChanging;


        }





        public virtual void ViewLoaded(EventArgs args)
        {
            //suscribe view to events
            aggregator.SubscribeOnUIThread(this.GetView());

            //check if corte is active
            ChecarCorteActivo();
        }



        //clear methods

        //clear all info in model
        public void ClearInfo()
        {
            ClearDocto();
            ClearMovto();
            ClearProducto();
            ClearMovtoItems();
            ConfigureCajasBotellas();
            //AssignProveedorInfo();

        }


        private void InitialState()
        {
            NuevaSolicitudMercancia();
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
            buffer.Tipodoctoid = Model.DBValues._DOCTO_TIPO_PEDIDO_COMPRA;
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
            //ClearListaPrecios();



        }

        public void NuevaSolicitudMercancia()
        {

            ClearInfo();
            CurrentDocto!.Referencia = "";
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
            //CurrentDocto.Proveedorid = Model.DBValues._CLIENTEMOSTRADOR;
            CurrentDocto.Tipodoctoid = Model.DBValues._DOCTO_TIPO_PEDIDO_COMPRA;
            CurrentDocto.Sucursal_id = GlobalSession!.CurrentSucursalInfo?.Id;
            //CurrentDocto.Docto_traslado_Sucursaltid = CurrentDocto.Sucursal_id;
            CurrentDocto.Docto_traslado_Almacentid = CurrentDocto.Almacenid;

            //AssignProveedorInfo();

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
            


        }
        protected override void fillCatalogConfiguration()
        {

            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("CurrentDocto","Sucursal_ext","Sucursaltid", "SucursaltClave", "SucursaltNombre","IposV3.ViewModels.Sucursal_extListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("CurrentDocto","Usuario","Usuarioid", "Usuariousername", "UsuarioNombre","IposV3.ViewModels.UsuarioListViewModel","SelectedItem","Username","Persona_nombre"),
                                          new CatalogRelatedFields("CurrentDocto","Estatusdocto","Estatusdoctoid", "EstatusdoctoClave", "EstatusdoctoNombre","IposV3.ViewModels.EstatusdoctoListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("CurrentDocto","Sucursal_info","Docto_traslado_Sucursaltid", "Docto_traslado_SucursaltClave", "Docto_traslado_SucursaltNombre","IposV3.ViewModels.Sucursal_infoListViewModel","SelectedItem","Clave")
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

            return new List<long>{ Model.DBValues._DERECHO_CAMBIARPRECIO_VENTA};
        }



        //Loading data methods
        //loading docto



        public void LoadSolicitudMercancia(long doctoId)
        {
            ClearInfo();
            ClearMovtoItems();
            CurrentDocto!.Id = doctoId;
            try
            {

                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";
                
                Task.Run(async () =>
                                                      await LoadDocto()
                                                 ).ContinueWith((t) =>
                {
                    IsBusy = false;

                    if (t.IsFaulted)
                    {
                        BProcessSuccess = false;
                        if (t.Exception != null)
                        {

                            comentario = t.Exception.Message;
                        }
                        else
                        {
                            comentario = "Ocurrio un Fault";
                        }
                        ErrorEditActions(comentario);
                    }
                    else if (t.IsCompleted)
                    {
                        BProcessSuccess = bSuccess;
                        if (!BProcessSuccess)
                        {
                            ErrorEditActions(comentario);
                        }
                        else
                        {
                            ReloadMovtoItems((int)CurrentDocto.Id);
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());


                //BackgroundWorker worker = new BackgroundWorker();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {
                //        LoadDocto();
                //    }
                //    catch (Exception ex)
                //    {
                //        bSuccess = false;
                //        comentario = ex.Message;
                //    }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusy = false;

                //    BProcessSuccess = bSuccess;
                //    if (!BProcessSuccess)
                //    {
                //        ErrorEditActions(comentario);
                //    }
                //    else
                //    {
                //        //AssignProveedorInfo();
                //        ReloadMovtoItems((int)CurrentDocto.Id);
                //    }
                //};
                //worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }

        }

        public async Task LoadDocto()
        {

            DoctoBindingModel? itemBuffer = null;


            itemBuffer = await doctoProvider.GetById(CurrentDocto!);

            if (itemBuffer != null)
            {
                CurrentDocto = itemBuffer;
            }
        }

        public void ReLoadbasicDocto()
        {

            DoctoBindingModel? itemBuffer = null;

            Task.Run(async () =>
            {
                itemBuffer = await doctoProvider.Get_BasicDocto(CurrentDocto!);
            }).Wait();

            if (itemBuffer != null)
            {
                CurrentDocto = itemBuffer;
            }
        }


        //loading movto items
        public async Task<List<Movto_solicitud_mercanciaWFBindingModel>> DoGetMovtoItems(long doctoId)
        {


            List<Movto_solicitud_mercanciaWFBindingModel> result = new List<Movto_solicitud_mercanciaWFBindingModel>();

            result = await puntoSolicitudMercanciaControllerProvider.Select_movto_solicitud_mercancia_List(new Movto_solic_merc_lstParamWFBindingModel(
                GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
                GlobalVariable.CurrentSession.CurrentConfiguracion.Sucursalid!.Value,
                doctoId
                )) ?? result;


            return result;
        }

        public void ReloadMovtoItems(long doctoId)
        {
            MovtoItems.Clear();
            try
            {
                bool bSuccess = true;
                IsBusyMovtoList = true;
                var comentario = "";
                System.Collections.Generic.List<Movto_solicitud_mercanciaWFBindingModel> items = new System.Collections.Generic.List<Movto_solicitud_mercanciaWFBindingModel>();

                
                Task.Run<List<Movto_solicitud_mercanciaWFBindingModel>>(async () =>
                                                      await DoGetMovtoItems(doctoId)
                                                 ).ContinueWith((t) =>
                {
                    IsBusyMovtoList = false;

                    if (t.IsFaulted)
                    {
                        BProcessSuccess = false;
                        if (t.Exception != null)
                        {

                            comentario = t.Exception.Message;
                        }
                        else
                        {
                            comentario = "Ocurrio un Fault";
                        }
                        ErrorEditActions(comentario);
                    }
                    else if (t.IsCompleted)
                    {

                        BProcessSuccess = bSuccess;
                        items = t.Result;

                        if (bSuccess)
                        {
                            foreach (var item in items)
                            {
                                MovtoItems.Add(item);
                            }
                            //ItemsLoadedText = "Loaded!";
                        }
                        else { ErrorEditActions("Ocurrio un error " + comentario); }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());


                //BackgroundWorker worker = new BackgroundWorker();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {
                //        items = DoGetMovtoItems(doctoId);
                //    }
                //    catch (Exception ex)
                //    {
                //        bSuccess = false;
                //        comentario = ex.Message;
                //    }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusyMovtoList = false;
                //    if (bSuccess)
                //    {
                //        foreach (var item in items)
                //        {
                //            MovtoItems.Add(item);
                //        }
                //        //ItemsLoadedText = "Loaded!";
                //    }
                //    else { ErrorEditActions("Ocurrio un error " + comentario); }

                //};
                //worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                ErrorEditActions("Ocurrio un error " + ex.Message);
            }
        }


        //complete info

        public async Task CompleteSucursalTInfoInDocto()
        {


            Sucursal_infoBindingModel? bufferItem = null;
            
            if(!(CurrentDocto == null || !CurrentDocto!.Docto_traslado_Sucursaltid.HasValue
                || CurrentDocto!.Docto_traslado_Sucursaltid == null || CurrentDocto!.Docto_traslado_Sucursaltid.Value == 0 ))
            {
                bufferItem = await sucursal_extProvider.GetById(new Sucursal_infoBindingModel()
                {
                    Id = CurrentDocto!.Docto_traslado_Sucursaltid,
                    EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                    SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid
                });
            }

            if (bufferItem != null)
            {

                CurrentDocto!.Docto_traslado_SucursaltClave = bufferItem.Clave;
                CurrentDocto!.Docto_traslado_SucursaltNombre = bufferItem.Nombre;
            }
            else
            {
                CurrentDocto!.Docto_traslado_SucursaltClave = "";
                CurrentDocto!.Docto_traslado_SucursaltNombre = "";
            }

        }

        private void AssignProducto(long productoId)
        {

            CurrentMovto!.Productoid = productoId;

            CurrentProducto = new ProductoBindingModel();
            CurrentProducto.EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid;
            CurrentProducto.SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid;
            CurrentProducto.Id = productoId;


            Task.Run(async () =>
            {
                CurrentProducto = await productoProvider.GetById(CurrentProducto);

            }).Wait();



            if (currentProducto == null)
            {
                CurrentProducto = new ProductoBindingModel();
                CurrentMovto.DescripcionProductoMovto = "";
            }
            else
            {
                CurrentMovto.DescripcionProductoMovto = currentProducto!.Nombre + " // " +
                                                        currentProducto!.Descripcion + " // " +
                                                        currentProducto!.Descripcion1 + " // " +
                                                        currentProducto!.Producto_existencia_Existencia;


            }
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

        public void DoctoPendingChangeEventHandler(object? sender, AcceptPendingChangeEventArgs e)
        {

            switch (e.PropertyName)
            {
                //case "Proveedorclave":
                //    CatalogField_PropertyChanging(sender, e);
                //    if (!e.CancelPendingChange && e.NewValue != e.OldValue)
                //    {
                //        AssignProveedorInfo();
                //    }
                //    break;

                default:
                    CatalogField_PropertyChanging(sender, e);
                    break;
            }
        }

        protected void MovtoPropertyChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {

                case "ProductoClave":
                    {
                        bool cancelPendingChange;
                        string outMessage;
                        this.DecipherCommand(currentMovto?.ProductoClave, out cancelPendingChange, out outMessage);
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
        public void ControlKeyDown(KeyEventArgs keyArgs)
        {
            Key key = keyArgs.Key;

            switch (key)
            {
                case Key.F3:
                    CancelarDocto();
                    break;
                case Key.F2:
                    NuevaSolicitudMercancia();
                    break;
                //case Key.F6:
                //    Pagar();
                //    break;
                case Key.System:
                    if (keyArgs.SystemKey == Key.F10)
                    {

                    }
                    break;

            }
        }



        //calculation prices
        private decimal PrecioCalculado(long? empresaId, long? sucursalId, long? productoId, long proveedorId, decimal cantidad, long sucursalTid)
        {
            decimal precioCalculado = 0;
            //fnc_preciosprod_ref_provParam.P_sucursaltid = sucursalTid;

            V_preciosProd_RefBindingModel? fnc_preciosprod_ref_provResult = null;

            Task.Run(async () =>
            {
                fnc_preciosprod_ref_provResult = await puntoCompraControllerProvider.Precioprod_ref_prov(empresaId!.Value, sucursalId!.Value, productoId!.Value, proveedorId, cantidad);

            }).Wait();

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

            dPrecioBaseSinImpuestos = tipodescuentoprodid == 2 ? precioCalculado : (producto.Producto_precios_Precio1 ?? 0m);
            return dPrecioBaseSinImpuestos;
        }




        //movto event handlers
        public virtual void ProductoKeyDown(KeyEventArgs keyArgs)
        {
            Key key = keyArgs.Key;
            if (key == Key.Enter)
            {
                keyArgs.Handled = true;

                if (currentProducto == null || currentProducto.Id == null || currentProducto.Id == 0)
                {

                    //V_producto_extListSubViewModel vm = IoC.Get<V_producto_extListSubViewModel>();
                    //vm.KendoParams.GeneralFilter.Value = CurrentMovto.Productoclave;
                    //winManager.ShowDialog(vm, null, CreateWinSettings("Productos", 0.75));


                    //if (vm.selectedItem != null && vm.selectedItem.Id != null)
                    //{
                    //    CurrentMovto.Productoclave = vm.selectedItem.Clave;
                    //}
                }


            }
        }

        public virtual void CantidadKeyDown(KeyEventArgs keyArgs)
        {
            Key key = keyArgs.Key;
            if (key == Key.Enter)
            {
                SaveMovto();
            }
        }



        //Decipher producto command
        private void DecipherCommand(string? commandText, out bool cancelPendingChange, out string outMessage)
        {
            long empresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid ?? 0;
            long sucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid ?? 0;
            ClearProducto();
            outMessage = "";
            cancelPendingChange = false;
            CurrentMovto!.DescripcionProductoMovto = "";

            if (commandText == null || commandText.Trim().Length == 0)
            {

                cancelPendingChange = true;
                return;
            }

            Movto_command_deciphered? decipherResult = null;

            Task.Run(async () =>
            {
                decipherResult = await  movtoProvider.DecipherCommand(empresaId, sucursalId, commandText);
            }).Wait();
            
            
            if (decipherResult == null)
            {
                cancelPendingChange = true;
                outMessage = "No se pudo encontrar el producto";
                return;
            }

            if (decipherResult.Productoid == null || decipherResult.Productoid == 0)
            {
                string errorMessage = decipherResult.Usermessage != null ? decipherResult.Usermessage : "No se pudo encontrar el producto";

                cancelPendingChange = true;
                outMessage = errorMessage;
                return;
            }



            CurrentMovto.Cantidad = decipherResult.Cantidad == 0 ? 1 : decipherResult.Cantidad;


            AssignProducto(decipherResult.Productoid.Value);
            //AssignPrecioDescuentos(currentProducto?.Producto_precios_Costorepo, null);
            //AssignListaPrecios(currentProducto!);
            ConfigureCajasBotellas();



            if (CajasBotellasActive)
                OneShotTimer.Start(() => aggregator.PublishOnBackgroundThreadAsync(new PuntoCompraUICommParams("SetFocus", new List<string>() { "Cajas" })), TimeSpan.FromMilliseconds(100));
            else if (CantidadEnabled)
                OneShotTimer.Start(() => aggregator.PublishOnBackgroundThreadAsync(new PuntoCompraUICommParams("SetFocus", new List<string>() { "CurrentMovto.Cantidad" })), TimeSpan.FromMilliseconds(100));
             else
                SaveMovto();
            //OneShotTimer.Start(() => aggregator.PublishOnUIThread(new PuntoCompraUICommParams("SetFocus", new List<string>() { "CurrentMovto.Cantidad" })), TimeSpan.FromMilliseconds(100));
            //aggregator.PublishOnUIThread(new PuntoCompraUICommParams("SetFocus", new List<string>() { "CurrentMovto.Cantidad" }));

        }



        //Save movto

        public void SaveMovtoRecord(MovtoSolicitudMercanciaTrans movto)
        {

            var precionetoenpv = GlobalVariable.CurrentSession?.CurrentParametro?.Precionetoenpv;

            if (CurrentDocto == null)
            {
                MessageBox.Show("Debe primero agregar el docto");
                return;
            }
            if (CurrentDocto.Id <= 0 || CurrentDocto.Id == null)
            {
                if (!SaveDoctoRecord())
                {
                    throw new Exception("Error al insertar el documento " + (Fnc_docto_prov_insertResult?.Usermessage ?? ""));
                }
            }

            movto.Doctoid = CurrentDocto!.Id!.Value;

            

            Task.Run(async () =>
            {
                Fnc_movto_prov_insertResult = await this.puntoSolicitudMercanciaControllerProvider.Movto_solicitud_mercancia_insert(movto);


            }).Wait();

            if (Fnc_movto_prov_insertResult.Result == null || Fnc_movto_prov_insertResult.Result.Value <= 0)
            {

                throw new Exception("Error al insertar el movimiento " +
                                        (Fnc_movto_prov_insertResult.Result == null ? "" : Fnc_movto_prov_insertResult.Usermessage));
            }

            ReLoadbasicDocto();

        }




        public void SaveMovto()
        {
            bool precionetoenpv = GlobalVariable.CurrentSession?.CurrentParametro?.Precionetoenpv == BoolCN.S;

            var Fnc_movto_prov_insertParam = new MovtoSolicitudMercanciaTrans();

            Fnc_movto_prov_insertParam.Loteimportado = CurrentMovto!.Loteimportado;
            Fnc_movto_prov_insertParam.Movtoparentid = null;
            Fnc_movto_prov_insertParam.Agrupaporparametro = BoolCN.N;
            Fnc_movto_prov_insertParam.Cargartarjetapreciomanual = BoolCN.N;
            Fnc_movto_prov_insertParam.Precioyavalidado = BoolCN.N;
            Fnc_movto_prov_insertParam.Usuarioid = GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value;

            Fnc_movto_prov_insertParam.Lote = CurrentMovto.Lote;
            Fnc_movto_prov_insertParam.Fechavence = CurrentMovto.Fechavence;
            Fnc_movto_prov_insertParam.Localidad = CurrentMovto.Movto_inventario_Localidad;
            Fnc_movto_prov_insertParam.Descripcion1 = CurrentMovto.Movto_comodin_Descripcion1;
            Fnc_movto_prov_insertParam.Descripcion2 = CurrentMovto.Movto_comodin_Descripcion2;
            Fnc_movto_prov_insertParam.Descripcion3 = CurrentMovto.Movto_comodin_Descripcion3;
            Fnc_movto_prov_insertParam.Empresaid = CurrentMovto!.EmpresaId!.Value;
            Fnc_movto_prov_insertParam.Sucursalid = CurrentMovto!.SucursalId!.Value;
            Fnc_movto_prov_insertParam.Id = CurrentMovto.Id != null ? CurrentMovto.Id : 0;
            Fnc_movto_prov_insertParam.Doctoid = CurrentDocto!.Id!.Value;
            Fnc_movto_prov_insertParam.Partida = CurrentMovto.Partida;
            Fnc_movto_prov_insertParam.Estatusmovtoid = CurrentMovto!.Estatusmovtoid!.Value;
            Fnc_movto_prov_insertParam.Productoid = CurrentMovto!.Productoid!.Value;

            Fnc_movto_prov_insertParam.Cantidad = (
                                                            CajasBotellasActive && Cajas > 0 ?
                                                                (Cajas * (CurrentProducto!.Producto_inventario_Pzacaja != null && CurrentProducto.Producto_inventario_Pzacaja.Value > 0 ? CurrentProducto.Producto_inventario_Pzacaja.Value : 1)) + CurrentMovto.Cantidad :
                                                              CurrentMovto.Cantidad
                                                              ) ?? 0m;
            Fnc_movto_prov_insertParam.Descuentoporcentaje = CurrentMovto.Descuentoporcentaje;

            Fnc_movto_prov_insertParam.Precio = precionetoenpv ? CurrentMovto.Precio : CurrentProducto!.calculaPrecioSinImpuestos(CurrentMovto!.Precio!.Value);

            if (!precionetoenpv)
            {
                Fnc_movto_prov_insertParam.Precioconimp = CurrentMovto!.Precio;
            }

            if (SaveMovto_(Fnc_movto_prov_insertParam))
            {
                ReloadMovtoItems((CurrentDocto?.Id ?? 0L));
                ClearMovto();
                ClearProducto();
                OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoCompraUICommParams("SetFocus", new List<string>() { "CurrentMovto.Productoclave" })), TimeSpan.FromMilliseconds(100));
            }

        }


        public bool SaveMovto_(MovtoSolicitudMercanciaTrans movto)
        {

            try
            {

                if (movto?.Productoid == null || movto.Productoid == 0)
                {
                    return false;
                }

                SaveMovtoRecord(movto);
                return true;

            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
                return false;
            }

        }


        //save docto
        public bool SaveDoctoRecord()
        {
            if (CurrentDocto == null)
                return false;

            var Fnc_docto_prov_insertParam = new DoctoSolicitudMercanciaTrans();

            Fnc_docto_prov_insertParam.Referencia = CurrentDocto.Referencia;
            Fnc_docto_prov_insertParam.Referencias = CurrentDocto.Referencias;
            Fnc_docto_prov_insertParam.Promocion = CurrentDocto.Docto_promocion_Promocion ?? BoolCN.N;
            Fnc_docto_prov_insertParam.Empresaid = CurrentDocto.EmpresaId!.Value;
            Fnc_docto_prov_insertParam.Sucursalid = CurrentDocto.SucursalId!.Value;
            Fnc_docto_prov_insertParam.Estatusdoctoid = CurrentDocto.Estatusdoctoid!.Value;
            Fnc_docto_prov_insertParam.Usuarioid = CurrentDocto.Usuarioid!.Value;
            Fnc_docto_prov_insertParam.Creadopor_userid = CurrentDocto.Usuarioid!.Value;
            Fnc_docto_prov_insertParam.Fecha = CurrentDocto.Fecha!.Value;
            Fnc_docto_prov_insertParam.Cajaid = CurrentDocto.Cajaid!.Value;
            Fnc_docto_prov_insertParam.Almacenid = CurrentDocto.Almacenid!.Value;
            Fnc_docto_prov_insertParam.Origenfiscalid = CurrentDocto.Origenfiscalid!.Value;
            Fnc_docto_prov_insertParam.Folio_c = CurrentDocto.Docto_compra_Folio;
            Fnc_docto_prov_insertParam.Factura_c = CurrentDocto.Docto_compra_Factura;
            Fnc_docto_prov_insertParam.Fechafactura_c = CurrentDocto.Docto_compra_Fechafactura;
            Fnc_docto_prov_insertParam.Fechavence_c = CurrentDocto.Fechavence;
            Fnc_docto_prov_insertParam.Doctoparentid = CurrentDocto.Doctoparentid;
            Fnc_docto_prov_insertParam.Proveedorid = null;
            Fnc_docto_prov_insertParam.Tipodoctoid = CurrentDocto.Tipodoctoid!.Value;
            Fnc_docto_prov_insertParam.Sucursal_id = CurrentDocto.Sucursal_id!.Value;
            Fnc_docto_prov_insertParam.Sucursaltid = CurrentDocto.Docto_traslado_Sucursaltid;
            Fnc_docto_prov_insertParam.Almacentid = CurrentDocto.Docto_traslado_Almacentid;


            Task.Run(async () =>
            {

                Fnc_docto_prov_insertResult = await puntoSolicitudMercanciaControllerProvider.Docto_solicitud_mercancia_insert(Fnc_docto_prov_insertParam);

            }).Wait();

            CurrentDocto.Id = Fnc_docto_prov_insertResult.Result;
            //ReloadMovtoItems((int)CurrentDocto.Id);


            return Fnc_docto_prov_insertResult.Result != null && Fnc_docto_prov_insertResult.Result.Value > 0;
        }


        //completar docto

        public void Completar()
        {


            bool bSuccess = true;
            IsBusy = true;
            var comentario = "";


            Task.Run<BaseResultBindingModel?>(async () =>
                                                  await puntoSolicitudMercanciaControllerProvider.Docto_solicitud_mercancia_save(
                                                           GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
                                                           GlobalVariable.CurrentSession!.CurrentConfiguracion!.Sucursalid!.Value,
                                                           CurrentDocto!.Id!.Value,
                                                           DBValues._DOCTO_ESTATUS_COMPLETO

                                                           )
                                             ).ContinueWith((t) =>
            {
                IsBusy = false;

                if (t.IsFaulted)
                {
                    BProcessSuccess = false;
                    if (t.Exception != null)
                    {

                        comentario = t.Exception.Message;
                    }
                    else
                    {
                        comentario = "Ocurrio un Fault";
                    }
                    ErrorEditActions(comentario);
                }
                else if (t.IsCompleted)
                {
                    bSuccess = t.Result != null && t.Result.Result >= 0;
                    comentario = t.Result != null ? t.Result.Usermessage : "Error ...";


                    if (bSuccess && CurrentDocto!.Docto_traslado_Sucursaltid != GlobalVariable.CurrentSession!.CurrentConfiguracion!.Sucursalid)
                    {
                        Task.Run(async () =>
                        {

                            await impoExpoProvider.ExportTraslado(
                                                    GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
                                                    GlobalVariable.CurrentSession!.CurrentConfiguracion!.Sucursalid!.Value,
                                                    GlobalSession!.CurrentSucursal!.Clave,
                                                    GlobalSession.CurrentEmpresa!.Clave,
                                                    CurrentDocto!.Id!.Value,
                                                    null);
                        }).Wait();
                    }

                    BProcessSuccess = bSuccess;
                    if (!BProcessSuccess)
                    {
                        ErrorEditActions(comentario);
                    }
                    else
                    {
                        //DoImprimirDoctoTicketLargo();
                        NuevaSolicitudMercancia();
                        OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoCompraUICommParams("SetFocus", new List<string>() { "CurrentMovto.Productoclave" })), TimeSpan.FromMilliseconds(100));
                    }


                }
            }, TaskScheduler.FromCurrentSynchronizationContext());



            //BackgroundWorker worker = new BackgroundWorker();
            //BaseResultBindingModel result;
            //worker.DoWork += async (o, ea) =>
            //{
            //    try
            //    {



            //        result = puntoSolicitudMercanciaControllerProvider.Docto_solicitud_mercancia_save(
            //           GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
            //           GlobalVariable.CurrentSession!.CurrentConfiguracion!.Sucursalid!.Value,
            //           CurrentDocto!.Id!.Value,
            //           DBValues._DOCTO_ESTATUS_COMPLETO

            //           );


            //        bSuccess = result != null && result.Result >= 0;
            //        if (bSuccess && CurrentDocto!.Docto_traslado_Sucursaltid != GlobalVariable.CurrentSession!.CurrentConfiguracion!.Sucursalid)
            //        {
            //            await impoExpoProvider.ExportTraslado(
            //                                     GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
            //                                     GlobalVariable.CurrentSession!.CurrentConfiguracion!.Sucursalid!.Value,
            //                                     GlobalSession!.CurrentSucursal!.Clave,
            //                                     GlobalSession.CurrentEmpresa!.Clave,
            //                                     CurrentDocto!.Id!.Value,
            //                                     null);
            //        }

            //        comentario = result != null ? result.Usermessage : "Error ...";


            //    }
            //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
            //};
            //worker.RunWorkerCompleted += (o, ea) =>
            //{
            //    IsBusy = false;

            //    BProcessSuccess = bSuccess;
            //    if (!BProcessSuccess)
            //    {
            //        ErrorEditActions(comentario);
            //    }
            //    else
            //    {
            //        //DoImprimirDoctoTicketLargo();
            //        NuevaSolicitudMercancia();
            //        OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoCompraUICommParams("SetFocus", new List<string>() { "CurrentMovto.Productoclave" })), TimeSpan.FromMilliseconds(100));
            //    }
            //};
            //worker.RunWorkerAsync();
        }



        //cancel docto
        public void CancelarDocto()
        {
            DoCancelarDocto();
        }

        private void DoCancelarDocto()
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
                        Task.Run(async () =>
                        {
                            resultOperation = await puntoCompraControllerProvider.Docto_prov_delete(CurrentDocto!.EmpresaId!.Value, CurrentDocto!.SucursalId!.Value, currentDocto!.Id!.Value);
                        }).Wait();

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

                            NuevaSolicitudMercancia();
                        }
                    }
                    else if (CurrentDocto.Estatusdoctoid == Model.DBValues._DOCTO_ESTATUS_COMPLETO)
                    {



                        BaseResultBindingModel? resultOperation = null;
                        Task.Run(async () =>
                        {
                            resultOperation = await puntoCompraControllerProvider.Docto_prov_cancel(CurrentDocto!.EmpresaId!.Value, CurrentDocto!.SucursalId!.Value, CurrentDocto!.Id!.Value, GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value);

                        }).Wait();

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

                            NuevaSolicitudMercancia();
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


        //grid movto events

        void MovtoItem_PendingChange(object sender, AcceptPendingChangeEventArgs e)
        {
            Movto_solicitud_mercanciaWFBindingModel movtoItem = (Movto_solicitud_mercanciaWFBindingModel)sender;
            if (e.PropertyName == "Cantidad")
            {
                //MessageBox.Show(e.OldValue.ToString() + " new val " + e.NewValue.ToString());
                //e.CancelPendingChange = false;
                e.CancelPendingChange = SaveMovtoFromGrid(movtoItem, "Cantidad", e.NewValue);
            }
        }

        void MovtoItems_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (Movto_solicitud_mercanciaWFBindingModel item in e.NewItems)
                    item.PendingChange += MovtoItem_PendingChange;

            if (e.OldItems != null)
                foreach (Movto_solicitud_mercanciaWFBindingModel item in e.OldItems)
                    item.PendingChange -= MovtoItem_PendingChange;
        }

        public bool SaveMovtoFromGrid(Movto_solicitud_mercanciaWFBindingModel movtoItem, string propertyChanged, object newVal)
        {


            var precionetoenpv = GlobalVariable.CurrentSession?.CurrentParametro?.Precionetoengrids;
            if (precionetoenpv == null)
                precionetoenpv = BoolCN.S;

            var Fnc_movto_prov_insertParam = new MovtoSolicitudMercanciaTrans();

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

            }

            bool retorno = SaveMovto_(Fnc_movto_prov_insertParam);

            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                new System.Action(() => ReloadMovtoItems((long)CurrentDocto!.Id!.Value)));



            return false;
        }

        public void MovtoGridKeyDown(KeyEventArgs keyArgs)
        {
            Key key = keyArgs.Key;
            if (key == Key.System && keyArgs.SystemKey == Key.F10)
            {
                MovtoDeleteSelected();

            }
        }
        public void MovtoDeleteSelected()
        {
            if (SelectedMovtoItems == null || SelectedMovtoItems.Count == 0 || CurrentDocto == null || CurrentDocto.Estatusdoctoid != Model.DBValues._DOCTO_ESTATUS_BORRADOR)
                return;



            if (ShowSiNoMessageBox("Realmente desea eliminar el(los) registro(s)", "Confirmacion"))
            {
                try
                {
                    var listIds = SelectedMovtoItems.Select(item => ((Movto_solicitud_mercanciaWFBindingModel)item).Id!.Value).ToList();

                    PuntoCompraBindingModel? puntoCompraBindingModel = null;

                    Task.Run(async () =>
                    {
                        puntoCompraBindingModel = await puntoCompraControllerProvider.Movto_prov_delete(CurrentDocto.EmpresaId!.Value, CurrentDocto.SucursalId!.Value, listIds, CurrentDocto!.Id!.Value);

                    }).Wait();


                    if (puntoCompraBindingModel?.BaseResultBindingModel != null && puntoCompraBindingModel.BaseResultBindingModel.Result >= 0)
                    {
                        CurrentDocto = puntoCompraBindingModel.CurrentDocto;
                        //MovtoItems.Clear();
                        //foreach (var movto in puntoCompraBindingModel.MovtoItems)
                        //{
                        //    MovtoItems.Add(movto);
                        //}

                        ClearMovto();
                        ClearProducto();
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


