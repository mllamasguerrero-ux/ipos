
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
using IposV3.Services;
using System.Windows;
using System.Threading;
using IposV3.ViewModels.utilities;
using System.Windows.Input;

namespace IposV3.ViewModels
{ 

    public class V_inventario_fisicoViewModel : BaseOperationalScreen, IHandle<V_inventario_listItemVMInitialParameters>
    {


       

        private V_inventario_movto_insertWFBindingModel? inventario_movto_insert_param;
        public V_inventario_movto_insertWFBindingModel? Inventario_movto_insert_param
        {
            get => inventario_movto_insert_param;
            set
            {
                inventario_movto_insert_param = value; NotifyOfPropertyChange("Inventario_movto_insert_param");
                if (inventario_movto_insert_param != null)
                {
                    inventario_movto_insert_param.PendingChange += Inventario_movto_insert_paramPendingChangeEventHandler;// CatalogField_PropertyChanging;
                    inventario_movto_insert_param.PropertyChanged += Inventario_movto_insert_paramChangedEventHandler;
                }


            }
        }



        private DoctoBindingModel? currentDocto;
        public DoctoBindingModel? CurrentDocto
        {
            get => currentDocto;
            set
            {
                currentDocto = value; NotifyOfPropertyChange("CurrentDocto");
                if (currentDocto != null)
                {
                    currentDocto.PropertyChanged += CurrentDocto_ChangedEventHandler;
                }
            }
        }

        private ProductoBindingModel? currentProducto;
        public ProductoBindingModel? CurrentProducto { get => currentProducto; set { currentProducto = value; NotifyOfPropertyChange("CurrentProducto"); } }



        public ObservableCollection<V_inventario_movto_detalleWFBindingModel> MovtoItems { get;  set; }

        public V_inventario_movto_detalleParamBindingModel? paramList;
        public V_inventario_movto_detalleParamBindingModel? ParamList
        {
            get { return paramList; }
            set
            {
                paramList = value;
                NotifyOfPropertyChange();
            }
        }


        private string? movtoItemsLoadedText;
        public string? MovtoItemsLoadedText
        {
            get { return movtoItemsLoadedText; }
            set
            {
                movtoItemsLoadedText = value;
                NotifyOfPropertyChange();
            }
        }




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


        public GlobalSession? GlobalSession { get => GlobalVariable.CurrentSession; }

        //Cajas
        public decimal cajas;
        public decimal Cajas { get => cajas; set { cajas = value; NotifyOfPropertyChange("Cajas"); } }

        //fields activation/habilitation
        private bool cajasBotellasActive;
        public bool CajasBotellasActive { get => cajasBotellasActive; set { cajasBotellasActive = value; NotifyOfPropertyChange("CajasBotellasActive"); } }


        private bool manejaLote;
        public bool ManejaLote { get => manejaLote; set { manejaLote = value; NotifyOfPropertyChange("ManejaLote"); } }


        private int loteNuevo;
        public int LoteNuevo { get => loteNuevo; set { loteNuevo = value; NotifyOfPropertyChange("LoteNuevo"); } }



        public bool BProcessSuccess { get; protected set; }

        //Controller providers
        protected readonly DoctoWebController doctoProvider;
        protected readonly MovtoWebController movtoProvider;
        protected readonly ProductoWebController productoProvider;
        private readonly GlobalWebController globalControllerProvider;

        protected readonly InventarioWebController inventarioController;


        public V_inventario_fisicoViewModel(
            InventarioWebController inventarioWebController, DoctoWebController doctoprovider, MovtoWebController movtoprovider, 
            ProductoWebController productoProvider, GlobalWebController globalControllerProvider,
            CorteWebController corteControllerProvider, UsuarioWebController usuarioControllerProvider,
            SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService, usuarioControllerProvider, corteControllerProvider)
        {


            //aggregator.Subscribe(this);

            this.doctoProvider = doctoprovider;
            this.movtoProvider = movtoprovider;
            this.productoProvider = productoProvider;
            this.globalControllerProvider = globalControllerProvider;
            this.inventarioController = inventarioController;

            MovtoItems = new ObservableCollection<V_inventario_movto_detalleWFBindingModel>();
            ParamList = new V_inventario_movto_detalleParamBindingModel();
            ClearDocto();
            ClearMovtoItems();
            ConfigureCajasBotellas();
            PreLoadListParam();

            Inventario_movto_insert_param = new V_inventario_movto_insertWFBindingModel();
            this.ClearCurrentMovto();
            

            //Inventario_movto_insert_param.PendingChange -= CatalogField_PropertyChanging;
            //Inventario_movto_insert_param.PendingChange += Inventario_movto_insert_paramPendingChangeEventHandler;
            //Inventario_movto_insert_param.PropertyChanged += Inventario_movto_insert_paramChangedEventHandler;


            //fill catalogs configuration and autocomplete
            GlobalSession? bufferSession = GlobalVariable.CurrentSession;
            globalControllerProvider.llenarProductAutoCompleteList(ref bufferSession);
            fillCatalogConfiguration();


        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            ScreenExtensions.TryActivateAsync(this);
        }



        protected override void fillCatalogConfiguration()
        {

            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Inventario_movto_insert_param","Producto","Productoid", "Productoclave", "Productonombre","IposV3.ViewModels.ProductoListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>() { new CatalogDef(
                    "Almacen"),new CatalogDef(
                    "LoteInventario")
        };
        }



        public virtual Task HandleAsync(V_inventario_listItemVMInitialParameters initialParameters, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }

        public  override void Back()
        {

            var eventParam = new V_inventario_listVMEventParameters();
            eventParam.fillFields(true, true,null);

            aggregator.PublishOnUIThreadAsync(eventParam);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }


        private void ClearDocto()
        {
            CurrentDocto = EmptyDocto();
            CurrentDocto.Docto_kit_Kitdesglosado = BoolCN.S;
        }

        private DoctoBindingModel EmptyDocto()
        {

            var buffer = new DoctoBindingModel();
            buffer.EmpresaId = GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid;
            buffer.SucursalId = GlobalVariable.CurrentSession.CurrentConfiguracion.Sucursalid;
            return buffer;
        }

        public void LoadInfoEdit(long? doctoId)
        {
            ClearDocto();
            CurrentDocto!.Id = doctoId;
            if (LoadDocto())
            {
                ClearCurrentMovto();
                PreLoadListParam();
                ReloadMovtoItems();
            }
        }

        private bool LoadDocto()
        {

            DoctoBindingModel? itemBuffer = null;

            Task.Run(async () =>
            {
                itemBuffer = await doctoProvider.GetById(CurrentDocto!);
            }).Wait();

            if (itemBuffer != null)
            {
                CurrentDocto = itemBuffer;
                return true;
            }

            return false;
        }


        private void PreLoadListParam()
        {
            ParamList!.Solodiferencias = false;
            ParamList.Todoslosproductos = false;
            ParamList.EmpresaId = GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid;
            ParamList.SucursalId = GlobalVariable.CurrentSession.CurrentConfiguracion.Sucursalid;

            LoadLoadListParamFromDocto();
        }


        private void LoadLoadListParamFromDocto()
        {
            ParamList!.EmpresaId = currentDocto!.EmpresaId;
            ParamList.SucursalId= currentDocto.SucursalId;
            ParamList.DoctoId = currentDocto.Id;
            ParamList.KitDesglosado = currentDocto.Docto_kit_Kitdesglosado == BoolCN.S ;
            ParamList.AlmacenId = currentDocto.Almacenid;
        }


        public void ClearMovtoItems()
        {
            MovtoItems.Clear();
            NotifyOfPropertyChange("MovtoItems");
        }
        public void ReloadMovtoItems()
        {
            MovtoItems.Clear();
            try
            {
                LoadLoadListParamFromDocto();
                IsBusyMovtoList = true;
                DateTime startTime = DateTime.Now;

                List<V_inventario_movto_detalleWFBindingModel> items = new List<V_inventario_movto_detalleWFBindingModel>();

                Task.Run(async () =>
                {
                    items = await this.inventarioController.V_inventario_movto_detallesList(ParamList!) ?? items;
                }).Wait();

                TimeSpan ts = DateTime.Now - startTime;
                Console.WriteLine("Total seconds " + ts.TotalSeconds.ToString());
                foreach (var item in items)
                {
                    MovtoItems.Add(item);
                }
                //NotifyOfPropertyChange("MovtoItems");
                MovtoItemsLoadedText = "Loaded!";


            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
            finally
            {
                IsBusyMovtoList = false;
            }
        }

        public void TSBBuscar()
        {
            ReloadMovtoItems();
        }

        //movto event handlers
        public virtual void ProductoKeyDown(KeyEventArgs keyArgs)
        {
            Key key = keyArgs.Key;
            if (key == Key.Enter)
            {
                //keyArgs.Handled = true;
                //if (currentProducto == null || currentProducto.Id == null || currentProducto.Id == 0)
                //{

                //    V_producto_extListSubViewModel vm = IoC.Get<V_producto_extListSubViewModel>();
                //    vm.KendoParams.GeneralFilter.Value = Inventario_movto_insert_param.Productoclave;
                //    winManager.ShowDialog(vm, null, CreateWinSettings("Productos", 0.75));


                //    if (vm.selectedItem != null && vm.selectedItem.Id != null)
                //    {
                //        Inventario_movto_insert_param.Productoclave = vm.selectedItem.Clave;
                //    }
                //}

            }
        }


        //clear all info in model
        public void ClearInfo()
        {
            ClearDocto();
            //ClearMovto();
            ClearProducto();
            ClearMovtoItems();

        }

        public void ClearCurrentMovto()
        {
            Cajas = 0;
            ClearProducto();
            Inventario_movto_insert_param!.Productoclave = "";
            Inventario_movto_insert_param.Productonombre = "";

            Inventario_movto_insert_param.EmpresaId = CurrentProducto!.EmpresaId;
            Inventario_movto_insert_param.SucursalId = CurrentProducto.SucursalId;
            Inventario_movto_insert_param.Productoid = null;
            Inventario_movto_insert_param.Lote = null;
            Inventario_movto_insert_param.Fechavence = null;
            Inventario_movto_insert_param.Doctoid = currentDocto!.Id;
            Inventario_movto_insert_param.Almacenid = currentDocto.Almacenid;
            Inventario_movto_insert_param.Productolocationsid = null;
            Inventario_movto_insert_param.DescripcionProductoMovto = null;
            Inventario_movto_insert_param.DescripcionCantidades = null;
            Inventario_movto_insert_param.LoteFechavenceConcatenado = null;

            Inventario_movto_insert_param.Cantidad = 0;

        }

        private void ClearProducto()
        {

            CurrentProducto = new ProductoBindingModel();
            CurrentProducto.EmpresaId = GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid;
            CurrentProducto.SucursalId = GlobalVariable.CurrentSession.CurrentConfiguracion.Sucursalid;

            if (Inventario_movto_insert_param != null)
            {
                Inventario_movto_insert_param.Productoid = 0;
                Inventario_movto_insert_param.DescripcionProductoMovto = "";
            }

            AssignProductCantidadesDescription();

            ManejaLote = false;
            LoteNuevo = 0;
            AssignCatalogLote();


        }

        private void ConfigureCajasBotellas()
        {
            var parametroCajasBotellas = GlobalVariable.CurrentSession?.CurrentParametro?.Cajasbotellas == BoolCN.S;
            //var currentProductUnitIsKg = currentProducto != null && currentProducto.Unidadclave != null && currentProducto.Unidadclave.ToUpper().Equals("KG");
            CajasBotellasActive = parametroCajasBotellas ;
        }




        public void Inventario_movto_insert_paramPendingChangeEventHandler(object sender, AcceptPendingChangeEventArgs e)
        {

            switch (e.PropertyName)
            {
                case "Anaquelid":
                    CatalogField_PropertyChanging(sender, e);

                    if (!e.CancelPendingChange && e.NewValue != e.OldValue)
                    {


                        string anaquelIdStr = "0";
                        if (e.NewValue != null && (long?)e.NewValue != -2)
                        {
                            anaquelIdStr = ((long?)e.NewValue).Value.ToString();
                        }

                        CatalogDef defProductLocations = new CatalogDef("ProductolocationsLibre");
                        defProductLocations.ExtraCondition = new KendoParams("", "localidad", new KendoFilters(new List<KendoFilter>() { new KendoFilter(anaquelIdStr, "eq", "Anaquelid", "S") }, "and"));
                        
                        Task.Run(async () =>
                        {
                            Catalogs!["ProductolocationsLibre"] = await selectorProvider.obtainCatalog(defProductLocations, new BaseParam(GlobalVariable.CurrentSession!.Empresaid, GlobalVariable.CurrentSession.Sucursalid));
                        }).Wait();

                        NotifyOfPropertyChange("Catalogs");

                    }
                    break;

                case "Productoclave":
                case "Productoid":
                    break;



                default:
                    CatalogField_PropertyChanging(sender, e);
                    break;
            }
        }


        protected void Inventario_movto_insert_paramChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {

                case "Productoclave":
                    {
                        bool cancelPendingChange;
                        string outMessage;
                        this.DecipherCommand(Inventario_movto_insert_param?.Productoclave, out cancelPendingChange, out outMessage);
                    }
                    break;


                default:
                    break;
            }

        }


        protected void CurrentDocto_ChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {

                case "Docto_kit_Kitdesglosado":
                    {
                        if(this.CurrentDocto != null && this.CurrentDocto.Id != null && this.CurrentDocto.Id > 0)
                        {
                            this.Cambiarkitdesglosado();
                        }

                    }
                    break;


                default:
                    break;
            }

        }


        //Decipher producto command
        private void DecipherCommand(string? commandText, out bool cancelPendingChange, out string outMessage)
        {
            long empresaId = GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value;
            long sucursalId = GlobalVariable.CurrentSession.CurrentConfiguracion.Sucursalid!.Value;
            ClearProducto();
            outMessage = "";
            cancelPendingChange = false;
            Inventario_movto_insert_param!.DescripcionProductoMovto = "";

            if (commandText == null || commandText.Trim().Length == 0)
            {

                cancelPendingChange = true;
                return;
            }

            Movto_command_deciphered? decipherResult = null;

            Task.Run(async () =>
            {
                decipherResult = await movtoProvider.DecipherCommand(empresaId, sucursalId, commandText);

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



            Inventario_movto_insert_param.Cantidad = decipherResult.Cantidad == 0 ? 1 : decipherResult.Cantidad;
            //Fnc_inv_movto_ins_locParam.Productoclave = decipherResult.prod

            AssignProducto(decipherResult.Productoid.Value);
            //ConfigureCajasBotellas();



            //if (CajasBotellasActive)
            //    OneShotTimer.Start(() => aggregator.PublishOnUIThread(new PuntoCompraUICommParams("SetFocus", new List<string>() { "Cajas" })), TimeSpan.FromMilliseconds(100));
            //else if (CantidadEnabled)
            //    OneShotTimer.Start(() => aggregator.PublishOnUIThread(new PuntoCompraUICommParams("SetFocus", new List<string>() { "CurrentMovto.Cantidad" })), TimeSpan.FromMilliseconds(100));


        }


        private void AssignProducto(long productoId)
        {

            Inventario_movto_insert_param!.Productoid = productoId;

            CurrentProducto = new ProductoBindingModel();
            CurrentProducto.EmpresaId = GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid;
            CurrentProducto.SucursalId = GlobalVariable.CurrentSession.CurrentConfiguracion.Sucursalid;
            CurrentProducto.Id = productoId;


            Task.Run(async () =>
            {
                CurrentProducto = await productoProvider.GetById(CurrentProducto);
            }).Wait();

            ManejaLote = CurrentProducto?.Producto_inventario_Manejalote != null && CurrentProducto?.Producto_inventario_Manejalote == BoolCN.S;
            //LoteNuevo = 0;


            if (CurrentProducto == null)
            {
                ClearProducto();
                Inventario_movto_insert_param.DescripcionProductoMovto = "";
            }
            else
            {
                Inventario_movto_insert_param.DescripcionProductoMovto = CurrentProducto.Nombre + " // " +
                                                        CurrentProducto.Descripcion + " // " +
                                                        CurrentProducto.Descripcion1 + " // " +
                                                        CurrentProducto.Producto_existencia_Existencia;

                AssignProductCantidadesDescription();
                AssignCatalogLote();



            }
        }



        private void AssignProductCantidadesDescription()
        {
            Inventario_movto_insert_param!.DescripcionCantidades = "";
            if (CurrentProducto == null || CurrentProducto.Id == null || CurrentProducto.Id == 0)
                return;

            V_inventario_movto_getInfoParamWFBindingModel param = new V_inventario_movto_getInfoParamWFBindingModel();

            param.EmpresaId = CurrentProducto.EmpresaId;
            param.SucursalId = CurrentProducto.SucursalId;
            param.Productoid = CurrentProducto.Id;
            param.Lote = Inventario_movto_insert_param.Lote;
            param.Fechavence = Inventario_movto_insert_param.Fechavence;

            param.Mododetalle = true;
            if (CurrentDocto != null && currentDocto!.Id != 0 && currentDocto.Id != null)
            {
                param.Doctoid = currentDocto.Id;
                param.Almacenid = currentDocto.Almacenid;
                param.Kitdesglosado = currentDocto.Docto_kit_Kitdesglosado == BoolCN.S;
            }
            else
            {

                param.Doctoid = 0;
                param.Almacenid = 0;// Fnc_inv_movto_ins_locParam.P_almacenid;
                param.Kitdesglosado = true;
            }

            V_inventario_movto_getInfoWFBindingModel? result = null;

            Task.Run(async () =>
            {
                result = await inventarioController.V_inventario_movto_getInfo(param);
            }).Wait();

            if (result != null && result != null)
            {
                Inventario_movto_insert_param.DescripcionCantidades =
                                    string.Format("Cant. Teorica: {0}, Cant. Fisica: {1}, Dif. {2}, Apartados {3} Pza caja {4} ",
                                                     result.Cantidadteorica, result.Cantidadfisica, result.Cantidaddiferencia, result.Apartados, result.Pzacaja);
            }

        }

        private void AssignCatalogLote()
        {

            //fnc_inv_movto_loteinfo
            Catalogs!["LoteInventario"] = new List<BaseSelector>();
            if (currentProducto == null || currentProducto.Id == null || currentProducto.Id == 0 ||
                currentProducto.Producto_inventario_Manejalote == null || 
                currentProducto.Producto_inventario_Manejalote != BoolCN.S)
            {

                NotifyOfPropertyChange("Catalogs");
                return;
            }

            List<Tmp_Inventario_movto_loteInfo>? result = null;

            Task.Run(async () =>
            {
                result = await this.inventarioController.Inventario_movto_loteInfo(
                                        GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid ?? 0,
                                        GlobalVariable.CurrentSession.CurrentConfiguracion.Sucursalid ?? 0,
                                        currentProducto!.Id!.Value,
                                        currentDocto?.Id,
                                        false);

            }).Wait();

            


            if (result != null && result.Count > 0)
            {
                List<BaseSelector> bufferSelector = new List<BaseSelector>();
                long consecutivo = 1;
                foreach (var item in result)
                {
                    bufferSelector.Add(new BaseSelector(
                        item.EmpresaId, 
                        item.SucursalId,
                        consecutivo++, 
                        (item.Lote ?? "") + " | " + (item.Fechavence ?? DateTimeOffset.Now.Date).ToString("d/M/yyyy"),
                        (item.Lote ?? "") + " | " + (item.Fechavence ?? DateTimeOffset.Now.Date).ToString("d/M/yyyy")));
                }

                Catalogs["LoteInventario"] = bufferSelector;
                NotifyOfPropertyChange("Catalogs");
            }

        }


        public void EliminarInventario()
        {

            if (currentDocto == null || currentDocto.Id == null || currentDocto.Id.Value == 0)
            {

                showPopUpMessage("Informacion ", "No hay inventario a eliminar", "Warning");
                return;
            }

            if (currentDocto.Estatusdoctoid != null && currentDocto.Estatusdoctoid != Model.DBValues._DOCTO_ESTATUS_BORRADOR)
            {

                showPopUpMessage("Informacion ", "El inventario no se puede eliminar", "Warning");
                return;
            }





            try
            {

                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";



                Task.Run<BaseResultBindingModel?>(async () =>
                                                      await inventarioController.Docto_inventario_delete(currentDocto!.EmpresaId!.Value, currentDocto!.SucursalId!.Value, currentDocto!.Id!.Value)

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
                        showPopUpMessage("Ocurrio un error ", comentario, "Error");
                    }
                    else if (t.IsCompleted)
                    {
                        bSuccess = t.Result != null && t.Result.Result >= 0;
                        comentario = t.Result != null ? t.Result.Usermessage : "Error ...";


                        var tempResult = t.Result;
                        BProcessSuccess = bSuccess;

                        if (BProcessSuccess)
                        {

                            if (tempResult == null)
                            {
                                showPopUpMessage("Error ", "Ocurrio un error indeterminado", "Error");
                            }
                            else if (tempResult.Result < 0)
                            {
                                showPopUpMessage("Error ", "Ocurrio un error " + tempResult.Usermessage, "Error");
                            }
                            else
                            {
                                showPopUpMessage(new MessageToUserSimple("Procesado", "Se ha cancelado el registro el registro", "Success"));
                                this.Back();
                            }

                        }
                        else
                        {
                            showPopUpMessage("Ocurrio un error ", comentario, "Error");
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());


                //BackgroundWorker worker = new BackgroundWorker();
                //BaseResultBindingModel tempResult = new BaseResultBindingModel();


                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {

                //        tempResult = inventarioController.Docto_inventario_delete(currentDocto!.EmpresaId!.Value, currentDocto!.SucursalId!.Value, currentDocto!.Id!.Value);


                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusy = false;

                //    BProcessSuccess = bSuccess;

                //    if (BProcessSuccess)
                //    {

                //        if (tempResult == null)
                //        {
                //            showPopUpMessage("Error ", "Ocurrio un error indeterminado", "Error");
                //        }
                //        else if (tempResult.Result < 0)
                //        {
                //            showPopUpMessage("Error ", "Ocurrio un error " + tempResult.Usermessage, "Error");
                //        }
                //        else
                //        {
                //            showPopUpMessage(new MessageToUserSimple("Procesado", "Se ha cancelado el registro el registro", "Success"));
                //            this.Back();
                //        }

                //    }
                //    else
                //    {
                //        showPopUpMessage("Ocurrio un error ", comentario, "Error");
                //    }
                //};
                //worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                IsBusy = false;
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
        }


        private void InsertDocto()
        {


                BaseResultBindingModel? tempResult = new BaseResultBindingModel();
                DoctoInventarioTrans tempParam = new DoctoInventarioTrans();

                tempParam.Empresaid = GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid ?? 0;
                tempParam.Sucursalid = GlobalVariable.CurrentSession.CurrentConfiguracion.Sucursalid ?? 0;
                tempParam.Usuarioid = GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value;
                tempParam.Estatusdoctoid = DBValues._DOCTO_ESTATUS_BORRADOR;

                tempParam.Creadopor_userid = GlobalVariable.CurrentSession.CurrentUsuario.Id!.Value;
                tempParam.Fecha = DateTime.Today;
                tempParam.Cajaid = GlobalVariable.CurrentSession.CurrentConfiguracion.Cajaid ?? 0;
                tempParam.Almacenid = Inventario_movto_insert_param!.Almacenid ?? 1;
                tempParam.Tipodoctoid = DBValues._DOCTO_TIPO_INVENTARIO_FISICO;
                tempParam.Almacentid = null;
                tempParam.Kitdesglosado = CurrentDocto?.Docto_kit_Kitdesglosado ?? BoolCN.S;


                long? doctoId = null;
            
            
                Task.Run(async () =>
                {
                    tempResult = await inventarioController.Docto_inventario_insert(tempParam);
                }).Wait();


                if(tempResult == null || tempResult.Result < 0)
                {
                    throw new Exception("Error al insertar el header " +  (tempResult?.Usermessage != null ? tempResult.Usermessage : ""));
                }

                doctoId = tempResult.Result;
                CurrentDocto!.Id = doctoId;
                this.LoadDocto();



        }

        public  void Accept()
        {
            try
            {

                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";

                Inventario_movto_insert_param!.EmpresaId = GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid;
                Inventario_movto_insert_param.SucursalId = GlobalVariable.CurrentSession.CurrentConfiguracion.Sucursalid;
                Inventario_movto_insert_param.Anaquelid = null;
                Inventario_movto_insert_param.Localidad = null;
                Inventario_movto_insert_param.Id = 0;
                Inventario_movto_insert_param.Usuarioid = GlobalVariable.CurrentSession.CurrentUsuario!.Id;
                Inventario_movto_insert_param.Doctoid = currentDocto!.Id;
                Inventario_movto_insert_param.Estatusmovtoid = DBValues._DOCTO_ESTATUS_BORRADOR;

                if(Inventario_movto_insert_param.Cantidad == null)
                {

                    IsBusy = false;
                    showPopUpMessage("Ocurrio un error ", "No se ha definido la cantidad", "Error");
                    return;
                }


                if (CurrentProducto == null)
                {

                    IsBusy = false;
                    showPopUpMessage("Ocurrio un error ", "No se ha definido el producto", "Error");
                    return;
                }


                if (CajasBotellasActive )
                {
                    decimal cantidadDeCajas = (CurrentProducto.Producto_inventario_Pzacaja != null ? CurrentProducto.Producto_inventario_Pzacaja.Value : 1) * Cajas;
                    Inventario_movto_insert_param.Cantidad += cantidadDeCajas;
                }

                if(CurrentProducto.Producto_inventario_Manejalote != null && CurrentProducto.Producto_inventario_Manejalote == BoolCN.S)
                {

                    if(LoteNuevo == 0)
                    {

                        if(Inventario_movto_insert_param.LoteFechavenceConcatenado == null ||
                            Inventario_movto_insert_param.LoteFechavenceConcatenado.Trim().Length == 0 ||
                            !Inventario_movto_insert_param.LoteFechavenceConcatenado.Contains(" | "))
                        {

                            IsBusy = false;
                            showPopUpMessage("Ocurrio un error ", "Debe definir lote y fecha vence", "Error");
                            return;
                        }

                        var strSplitBuffer = Inventario_movto_insert_param.LoteFechavenceConcatenado.Split(new string[] { " | " }, StringSplitOptions.None);
                        if (strSplitBuffer.Length < 2)
                        {
                            IsBusy = false;
                            showPopUpMessage("Ocurrio un error ", "Debe definir lote y fecha vence", "Error");
                            return;
                        }


                        Inventario_movto_insert_param.Lote = strSplitBuffer[0];
                        DateTimeOffset fechaVenceBuffer = DateTimeOffset.ParseExact(strSplitBuffer![1], "d/M/yyyy", null);
                        Inventario_movto_insert_param.Fechavence= fechaVenceBuffer;
                    }


                    if (Inventario_movto_insert_param.Lote == null || Inventario_movto_insert_param.Lote.Trim().Length == 0 ||
                        Inventario_movto_insert_param.Fechavence == null)
                    {
                        IsBusy = false;
                        showPopUpMessage("Ocurrio un error ", "Debe definir lote y fecha vence", "Error");
                        return;
                    }
                }
                else
                {

                    Inventario_movto_insert_param.Lote = null;
                    Inventario_movto_insert_param.Fechavence = null;
                }


                if (
                    (currentDocto == null || currentDocto.Id == null || currentDocto.Id.Value == 0) &&
                    (Inventario_movto_insert_param.Almacenid == null || Inventario_movto_insert_param.Almacenid == 0)
                    )
                {

                    IsBusy = false;
                    showPopUpMessage("Ocurrio un error ", "No se ha definido el almacen", "Error");
                    return;
                }



                Task.Run<BaseResultBindingModel?>(async () =>
                                                        {

                                                            if (currentDocto == null || currentDocto.Id == null || currentDocto.Id.Value == 0)
                                                            {
                                                                InsertDocto();
                                                                Inventario_movto_insert_param.Doctoid = currentDocto?.Id;
                                                            }
                                                           return await inventarioController.Movto_inventario_insert(Inventario_movto_insert_param.GetMovtoInventarioTrans());
                                                        }

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
                        showPopUpMessage("Ocurrio un error ", comentario, "Error");
                    }
                    else if (t.IsCompleted)
                    {
                        bSuccess = t.Result != null && t.Result.Result >= 0;
                        comentario = t.Result != null ? t.Result.Usermessage : "Error ...";


                        BProcessSuccess = bSuccess;
                        if (BProcessSuccess)
                        {
                            ReloadMovtoItems();
                            showPopUpMessage("Exito ", " Se realizo la operacion", "Success");
                            ClearCurrentMovto();

                        }
                        else
                        {
                            showPopUpMessage("Ocurrio un error ", comentario, "Error");
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());


                //BackgroundWorker worker = new BackgroundWorker();
                //BaseResultBindingModel tempResult = new BaseResultBindingModel();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {


                //        if (currentDocto == null || currentDocto.Id == null || currentDocto.Id.Value == 0)
                //        {
                //            InsertDocto();
                //            Inventario_movto_insert_param.Doctoid = currentDocto?.Id;
                //        }

                //        tempResult = inventarioController.Movto_inventario_insert(Inventario_movto_insert_param.GetMovtoInventarioTrans());
                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusy = false;

                //    BProcessSuccess = bSuccess;
                //    if (BProcessSuccess)
                //    {
                //        ReloadMovtoItems();
                //        showPopUpMessage("Exito ", " Se realizo la operacion", "Success");
                //        ClearCurrentMovto();

                //    }
                //    else
                //    {
                //        showPopUpMessage("Ocurrio un error ", comentario, "Error");
                //    }
                //};
                //worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                IsBusy = false;
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
        }


        public void SiguientePaso()
        {

            var vm = IoC.Get<V_inventario_paso2ViewModel>();
            vm.LoadInfoEdit(CurrentDocto!.Id);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
        }


        public void Cambiarkitdesglosado()
        {
            try
            {


                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";



                Task.Run<BaseResultBindingModel?>(async () =>
                                                      await inventarioController.Docto_inventario_cambiarkitdesglosado(
                                                                                    GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
                                                                                    GlobalVariable.CurrentSession.CurrentConfiguracion.Sucursalid!.Value,
                                                                                    currentDocto!.Id!.Value, currentDocto!.Docto_kit_Kitdesglosado!.Value
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
                        showPopUpMessage("Ocurrio un error ", comentario, "Error");
                    }
                    else if (t.IsCompleted)
                    {
                        bSuccess = t.Result != null && t.Result.Result >= 0;
                        comentario = t.Result != null ? t.Result.Usermessage : "Error ...";


                        BProcessSuccess = bSuccess;
                        if (BProcessSuccess)
                        {
                            showPopUpMessage("Exito ", " Se realizo la operacion", "Success");
                        }
                        else
                        {
                            showPopUpMessage("Ocurrio un error ", comentario, "Error");
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());


                //BackgroundWorker worker = new BackgroundWorker();
                //BaseResultBindingModel tempResult = new BaseResultBindingModel();



                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {

                //        tempResult = inventarioController.Docto_inventario_cambiarkitdesglosado(
                //            GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
                //            GlobalVariable.CurrentSession.CurrentConfiguracion.Sucursalid!.Value,
                //            currentDocto!.Id!.Value, currentDocto!.Docto_kit_Kitdesglosado!.Value
                //            );
                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusy = false;

                //    BProcessSuccess = bSuccess;
                //    if (BProcessSuccess)
                //    {
                //        showPopUpMessage("Exito ", " Se realizo la operacion", "Success");
                //    }
                //    else
                //    {
                //        showPopUpMessage("Ocurrio un error ", comentario, "Error");
                //    }
                //};
                //worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
        }


    }
}
