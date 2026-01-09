using BindingModels;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
//using IposV3.Controllers.Controller;
using IposV3.Model;
using IposV3.ViewModels.BaseScreen;
using ViewModels.BaseScreen;
using Models.CatalogSelector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IposV3.ViewModels
{

    public class BaseRecordViewModel<BM, PROV, INIP, LSTP> : BaseScreen.BaseScreen, IHandle<INIP> where BM : class, IBaseBindingModel, new() where PROV : IControllerProvider<BM> where INIP : BaseCommonInitialParameters where LSTP : BaseListVMEventParameters, new()
    {

        protected readonly PROV provider;
        protected readonly IEventAggregator aggregator;

        //public BM? Record { get; set; }


        private BM? record { get; set; }
        public BM? Record
        {
            get => record;
            set
            {
                record = value; NotifyOfPropertyChange("Record");

                if (Record != null)
                {
                    Record.PendingChange += CatalogField_PropertyChanging;
                    Record.PropertyChanged += RecordChangedEventHandler;
                }
            }
        }

        public bool BIsReadOnly { get; protected set; }

        public bool BProcessSuccess { get; protected set; }

        public string Mode { get; protected set; }



        private List<long> _derechosAChecar;


        private UsuarioWebController? _usuarioControllerProvider;

       

        public BaseRecordViewModel(string mode, PROV provider, UsuarioWebController? usuarioControllerProvider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) : base(selectorProvider, winManager, messageBoxService)
        {
            this.Mode = mode == null ? "Add" : mode;
            this.provider = provider;
            this.aggregator = aggregator;
            this.BIsReadOnly = false;


            _derechosAChecar = DerechosToCheck();
            if (usuarioControllerProvider != null)
            {
                _usuarioControllerProvider = usuarioControllerProvider;

                if (_derechosAChecar.Count() > 0)
                {
                    CheckDerechos();
                }
            }

            fillCatalogs();

            if (this.Mode == "Edit")
            {
                aggregator.SubscribeOnPublishedThread(this);
            }
            else if (this.Mode == "Add")
            {
                preFillRecordToAdd();
                Record!.PendingChange += CatalogField_PropertyChanging;

                preFillRecordToAddWithPropertyChangingEvent();
            }
            else if (this.Mode == "Show")
            {

                this.BIsReadOnly = true;
                aggregator.SubscribeOnPublishedThread(this);
            }
        }

        public BaseRecordViewModel(string mode, PROV provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) : 
            this(mode, provider, null,  selectorProvider,  aggregator,  winManager,  messageBoxService)
        {
        }


        public virtual void RecordChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {

            switch (e.PropertyName)
            {
                default:
                    break;
            }
        }

        protected virtual void preFillRecordToAdd()
        {

            BM rec = new BM();
            rec.CreadoPorId = GlobalVariable.CurrentSession?.Usuarioid;
            rec.EmpresaId = GlobalVariable.CurrentSession?.Empresaid;
            rec.SucursalId = GlobalVariable.CurrentSession?.Sucursalid;

            Record = rec;
        }

        protected virtual void preFillRecordToAddWithPropertyChangingEvent()
        {
        }


        protected virtual void fillRecordToEdit(INIP initialParameters)
        {

            BM item = new BM();

            item.Id = initialParameters.Id;
            item.EmpresaId = GlobalVariable.CurrentSession?.Empresaid;
            item.SucursalId = GlobalVariable.CurrentSession?.Sucursalid;

            Record = provider.GetById(item);

            if (Record == null)
                Record = new BM();

        }


        protected virtual void fillCatalogs()
        {
            long? empresaId = GlobalVariable.CurrentSession?.Empresaid;
            long? sucursalId = GlobalVariable.CurrentSession?.Sucursalid;
            fillCatalogConfiguration();

            if (lstCatalogDef != null)
            {

                Task.Run(async () =>
                {
                    Catalogs = await selectorProvider.ObtainCatalogs(lstCatalogDef!, new BaseParam(empresaId, sucursalId));
                }).Wait();
            }

            afterFillCatalogs();
        }

        protected virtual void afterFillCatalogs()
        {

        }
        
        protected virtual void fillCatalogConfiguration()
        {

            catalogRelatedFields = new List<CatalogRelatedFields>() { };
            lstCatalogDef = new List<CatalogDef>() { };
        }


        protected virtual void doInsert()
        {
            if (Record == null)
                return;

            provider.Insert(Record);
        }

        protected virtual void doUpdate()
        {
            if (Record == null)
                return;

            provider.Update(Record);
        }


        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            ScreenExtensions.TryActivateAsync(this);
        }

        public virtual void Back()
        {
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }


        public virtual Task HandleAsync(INIP initialParameters, CancellationToken cancellationToken)
        {
            if (this.Mode == "Edit" || this.Mode == "Show")
            {
                fillRecordToEdit(initialParameters);
            }


            if (this.Mode == "Edit" && Record != null)
            {
                Record.PendingChange += CatalogField_PropertyChanging;
                Record.Validate();
            }
            return Task.CompletedTask;
        }


        public virtual void Accept()
        {

            if (this.Mode == "Edit")
            {
                AcceptEdit();
            }
            else if (this.Mode == "Add")
            {
                AcceptAdd();
            }
        }


        public virtual void SuccessAddActions(BM record)
        {

            var eventParam = new LSTP();
            eventParam.fillFields(true, true,
                                                                BProcessSuccess ?
                                                                                new MessageToUserSimple("Exito", "Se inserto el registro", "Success") :
                                                                                new MessageToUserSimple("Error", "Occurrio un error ", "Error"));

            aggregator.PublishOnUIThreadAsync(eventParam);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }

        public virtual void ErrorAddActions(BM record, string comentario)
        {
            showPopUpMessage("Ocurrio un error ", comentario, "Error");
        }


        public virtual void SuccessEditActions(BM record)
        {
            var eventParam = new LSTP();
            eventParam.fillFields(true, true,
                                                                BProcessSuccess ?
                                                                                new MessageToUserSimple("Exito", "Se actualizo el registro", "Success") :
                                                                                new MessageToUserSimple("Error", "Occurrio un error ", "Error"));

            aggregator.PublishOnUIThreadAsync(eventParam);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }


        public virtual void ErrorEditActions(BM record, string comentario)
        {
            showPopUpMessage("Ocurrio un error ", comentario, "Error");
        }

        public virtual void AcceptEdit()
        {

            if (Record == null)
                return;

            Record.ModificadoPorId = GlobalVariable.CurrentSession?.Usuarioid;

            try
            {

                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (o, ea) =>
                {
                    try
                    {
                        doUpdate();
                    }
                    catch (Exception ex) { 
                        bSuccess = false; 
                        comentario = ex.Message; 
                    }
                };
                worker.RunWorkerCompleted += (o, ea) =>
                {
                    IsBusy = false;

                    BProcessSuccess = bSuccess;
                    if (BProcessSuccess)
                    {
                        SuccessEditActions(Record);
                    }
                    else
                    {
                        ErrorEditActions(Record, comentario);
                    }
                };
                worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }

        }


        public virtual void AcceptAdd()
        {
            if (Record == null)
                return;

            Record.Creado = DateTime.Now;
            Record.Modificado = DateTime.Now;

            try
            {

                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (o, ea) =>
                {
                    try
                    {
                        doInsert();
                    }
                    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                };
                worker.RunWorkerCompleted += (o, ea) =>
                {
                    IsBusy = false;

                    BProcessSuccess = bSuccess;
                    if (BProcessSuccess)
                    {
                        SuccessAddActions(Record);
                    }
                    else
                    {
                        ErrorAddActions(Record, comentario);
                    }

                };
                worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
        }

        public virtual void Cancel()
        {
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }


        public bool CanEmpresaid
        {
            get { return (this.Mode == "Add"); }
        }

        public bool CanSucursalid
        {
            get { return (this.Mode == "Add"); }
        }

        public bool CanId
        {
            get { return (this.Mode == "Add"); }
        }



        protected virtual List<long> DerechosToCheck()
        {
            return new List<long>();
        }


        protected virtual void CheckDerechos()
        {
            DerechosUsuario = new Dictionary<long, bool>();
            var derechos = _derechosAChecar;
            if (derechos == null || GlobalVariable.CurrentSession?.CurrentUsuario?.Id == null || _usuarioControllerProvider == null)
                return;



            Task.Run(async () =>
            {
                var buffer = await _usuarioControllerProvider!.Obtain_usuarios_derechos_List(GlobalVariable.CurrentSession!.Empresaid!.Value, GlobalVariable.CurrentSession!.Sucursalid!.Value, derechos, GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value);
                if (buffer != null)
                    DerechosUsuario = buffer;
            }).Wait();

        }



    }



    public class BaseListViewModel<BM, PROV, INIP, LSTP, PARAM> : BaseScreen.BaseScreen, IHandle<LSTP> where BM : class, IBaseBindingModel, new() where PROV : IControllerProvider<BM> where INIP : BaseCommonInitialParameters, new() where LSTP : BaseListVMEventParameters, new() where PARAM : BaseParam, new()
    {
        protected readonly PROV itemsProvider;
        protected string? itemsLoadedText;
        public BM? selectedItem;
        public ObservableCollection<BM> Items { get; private set; }
        public PARAM? ListParam { get; set; }
        public KendoParams? KendoParams { get; set; }

        protected readonly IEventAggregator aggregator;

        public bool IsSelectionMode { get; set; } = false;
        public bool AllowAdd { get; set; } = true;
        public bool AllowEdit { get; set; } = true;
        public bool AllowShow { get; set; } = true;
        public double BaseWidthFactor { get; set; } = 0.75;


        private UsuarioWebController? _usuarioControllerProvider;

        private string? hiddenColumns;
        public string? HiddenColumns { get => hiddenColumns; set { hiddenColumns = value; NotifyOfPropertyChange("HiddenColumns"); } }

        public bool ChecarDerechosEstandar { get; set; } = false;

        private List<long> _derechosEstandar;


        public string ItemsLoadedText
        {
            get { return itemsLoadedText ?? ""; }
            set
            {
                itemsLoadedText = value;
                NotifyOfPropertyChange();
            }
        }

        public BaseListViewModel(PROV provider, UsuarioWebController? usuarioControllerProvider, SelectorWebController selectorProvider, IWindowManager winManager, IEventAggregator aggregator, IMessageBoxService messageBoxService, bool checarDerechosEstandar) :
            base(selectorProvider, winManager, messageBoxService)
        {
            itemsProvider = provider;
            Items = new ObservableCollection<BM>();
            preFillParam();
            preconfigureSearchParams();
            fillCatalogs();

            this.aggregator = aggregator;
            this.aggregator.SubscribeOnUIThread(this);

            _usuarioControllerProvider = usuarioControllerProvider;
            _derechosEstandar = new List<long>();

            ChecarDerechosEstandar = checarDerechosEstandar;

            if(ChecarDerechosEstandar)
            {
                _derechosEstandar = DerechosEstandarToCheck();
                CheckDerechos();
                AllowAdd = (DerechosUsuario?[_derechosEstandar[3]] ?? false);
                AllowEdit = (DerechosUsuario?[_derechosEstandar[1]] ?? false);
                AllowShow = (DerechosUsuario?[_derechosEstandar[0]] ?? false);
            }



        }

        public BaseListViewModel(PROV provider,  SelectorWebController selectorProvider, IWindowManager winManager, IEventAggregator aggregator, IMessageBoxService messageBoxService) :
            this(provider, null, selectorProvider,  winManager, aggregator,  messageBoxService, false)
        {
            

        }
        protected virtual void preFillParam()
        {

            ListParam = new PARAM();
            if (GlobalVariable.CurrentSession != null)
            {

                ListParam.P_empresaid = GlobalVariable.CurrentSession.Empresaid;
                ListParam.P_sucursalid = GlobalVariable.CurrentSession.Sucursalid;
            }
        }

        protected virtual void preconfigureSearchParams()
        {
            KendoParams = new KendoParams("", @"""Clave""|""Nombre""");
        }

        protected virtual void fillCatalogs()
        {
            long? empresaId = GlobalVariable.CurrentSession?.Empresaid;
            long? sucursalId = GlobalVariable.CurrentSession?.Sucursalid;
            fillCatalogConfiguration();

            if (lstCatalogDef != null)
            {

                Task.Run(async () =>
                {
                    Catalogs = await selectorProvider.ObtainCatalogs(lstCatalogDef!, new BaseParam(empresaId, sucursalId));
                }).Wait();
            }
        }


        protected virtual void fillCatalogConfiguration()
        {

            catalogRelatedFields = new List<CatalogRelatedFields>() { };
            lstCatalogDef = new List<CatalogDef>() { };
        }

        public virtual bool CanEditItem
        {
            get { return SelectedItem != null; }
        }

        protected virtual object EditViewModel()
        {
            //return vm = IoC.Get<EditViewModel>();
            throw new Exception("not implemented");
        }

        protected virtual object ShowViewModel()
        {
            //return vm = IoC.Get<ShowViewModel>();
            throw new Exception("not implemented");
        }


        protected virtual object AddViewModel()
        {
            //return vm = IoC.Get<AddViewModel>();
            throw new Exception("not implemented");
        }


        public virtual void Edititem(BM selected)
        {

            this.SelectedItem = selected;

            var vm = EditViewModel();
            var inip = new INIP(); inip.Id = SelectedItem.Id;
            aggregator.PublishOnUIThreadAsync(inip);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
        }

        public virtual void ShowItem(BM selected)
        {
            this.SelectedItem = selected;

            var vm = ShowViewModel();
            var inip = new INIP(); inip.Id = SelectedItem.Id;
            aggregator.PublishOnUIThreadAsync(inip);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
        }


        public virtual void SelectItemByCell(BM selected)
        {
            if (IsSelectionMode)
            {
                this.SelectedItem = selected;
                this.TryCloseAsync();
            }
        }

        public virtual void AddItem()
        {

            var vm = AddViewModel();
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
        }


        public virtual void TSBBuscar()
        {
            ReloadItems();
        }
        public virtual void TSTPalabrasClaveKeyDown(Key key)
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

            if(ChecarDerechosEstandar)
            {
                if (!AllowEdit)
                {
                    HiddenColumns = HiddenColumns ?? "";

                    if (HiddenColumns!.Length > 0)
                        HiddenColumns += ",1";
                    else
                        HiddenColumns += "1";
                }
            }
        }

        protected virtual List<long> DerechosEstandarToCheck()
        {
            throw new Exception("Derechos estandar no asignados");
        }

        protected virtual void CheckDerechos()
        {
            DerechosUsuario = new Dictionary<long, bool>();
            var derechos = _derechosEstandar;
            if (derechos == null || GlobalVariable.CurrentSession?.CurrentUsuario?.Id == null || _usuarioControllerProvider == null)
                return;

            Task.Run(async () =>
            {
                var buffer = await _usuarioControllerProvider!.Obtain_usuarios_derechos_List(GlobalVariable.CurrentSession!.Empresaid!.Value, GlobalVariable.CurrentSession!.Sucursalid!.Value, derechos, GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value);
                if (buffer != null)
                    DerechosUsuario = buffer;
            }).Wait();


        }



        public Task HandleAsync(LSTP parameters, CancellationToken cancellationToken)
        {
            if (parameters.HasMessage && parameters.MsgSimple != null)
            {
                showPopUpMessage(parameters.MsgSimple);
            }

            if (parameters.IsReloadEvent)
                ReloadItems();

            return Task.CompletedTask;
        }


        public virtual void CloseApp()
        {
            Application.Current.Shutdown();
        }

        public BM? SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                NotifyOfPropertyChange(() => CanEditItem);
            }
        }

        public virtual bool CanRemoveItem
        {
            get { return SelectedItem != null; }
        }

        public virtual void RemoveItem()
        {
            if (SelectedItem == null)
                return;

            Items.Remove(SelectedItem);
        }

        public virtual System.Collections.Generic.List<BM> DoGetItems()
        {
            if (ListParam == null)
                return new List<BM>();

            System.Collections.Generic.List<BM> items = new System.Collections.Generic.List<BM>();
            items = itemsProvider.SelectList(ListParam, KendoParams);
            return items;
        }

        public virtual void ReloadItems()
        {
            Items.Clear();
            try
            {
                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";
                System.Collections.Generic.List<BM> items = new System.Collections.Generic.List<BM>();
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (o, ea) =>
                {
                    try
                    {
                        items = DoGetItems();
                    }
                    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                };
                worker.RunWorkerCompleted += (o, ea) =>
                {
                    IsBusy = false;
                    if (bSuccess)
                    {
                        foreach (var item in items)
                        {
                            Items.Add(item);
                        }
                        ItemsLoadedText = "Loaded!";
                    }
                    else { showPopUpMessage("Ocurrio un error ", comentario, "Error"); }

                };
                worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
        }

    }



    public class BaseWebRecordViewModel<BM, PROV, INIP, LSTP> : BaseScreen.BaseScreen, IHandle<INIP> where BM : class, IBaseBindingModel, new() where PROV : IWebControllerProvider<BM> where INIP : BaseCommonInitialParameters where LSTP : BaseListVMEventParameters, new()
    {

        protected readonly PROV provider;
        protected readonly IEventAggregator aggregator;

        //public BM? Record { get; set; }


        private BM? record { get; set; }
        public BM? Record
        {
            get => record;
            set
            {
                record = value; NotifyOfPropertyChange("Record");

                if (Record != null)
                {
                    Record.PendingChange += CatalogField_PropertyChanging;
                    Record.PropertyChanged += RecordChangedEventHandler;
                }
            }
        }

        public bool BIsReadOnly { get; protected set; }

        public bool BProcessSuccess { get; protected set; }

        public string Mode { get; protected set; }



        private List<long> _derechosAChecar;


        private UsuarioWebController? _usuarioControllerProvider;



        public BaseWebRecordViewModel(string mode, PROV provider, UsuarioWebController? usuarioControllerProvider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) : base(selectorProvider, winManager, messageBoxService)
        {
            this.Mode = mode == null ? "Add" : mode;
            this.provider = provider;
            this.aggregator = aggregator;
            this.BIsReadOnly = false;


            _derechosAChecar = DerechosToCheck();
            if (usuarioControllerProvider != null)
            {
                _usuarioControllerProvider = usuarioControllerProvider;

                if (_derechosAChecar.Count() > 0)
                {
                    CheckDerechos();
                }
            }

            fillCatalogs();

            if (this.Mode == "Edit")
            {
                aggregator.SubscribeOnPublishedThread(this);
            }
            else if (this.Mode == "Add")
            {
                preFillRecordToAdd();
                Record!.PendingChange += CatalogField_PropertyChanging;

                preFillRecordToAddWithPropertyChangingEvent();
            }
            else if (this.Mode == "Show")
            {

                this.BIsReadOnly = true;
                aggregator.SubscribeOnPublishedThread(this);
            }
        }

        public BaseWebRecordViewModel(string mode, PROV provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            this(mode, provider, null, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }


        public virtual void RecordChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {

            switch (e.PropertyName)
            {
                default:
                    break;
            }
        }

        protected virtual void preFillRecordToAdd()
        {

            BM rec = new BM();
            rec.CreadoPorId = GlobalVariable.CurrentSession?.Usuarioid;
            rec.EmpresaId = GlobalVariable.CurrentSession?.Empresaid;
            rec.SucursalId = GlobalVariable.CurrentSession?.Sucursalid;

            Record = rec;
        }

        protected virtual void preFillRecordToAddWithPropertyChangingEvent()
        {
        }


        protected virtual void fillRecordToEdit(INIP initialParameters)
        {

            BM item = new BM();

            item.Id = initialParameters.Id;
            item.EmpresaId = GlobalVariable.CurrentSession?.Empresaid;
            item.SucursalId = GlobalVariable.CurrentSession?.Sucursalid;




            var task = Task.Run<BM?>(async () => await provider.GetById(item));
            Record = task.Result;


            //Record = provider.GetById(item);


            if (Record == null)
                Record = new BM();

        }


        protected virtual void fillCatalogs()
        {
            long? empresaId = GlobalVariable.CurrentSession?.Empresaid;
            long? sucursalId = GlobalVariable.CurrentSession?.Sucursalid;
            fillCatalogConfiguration();

            if (lstCatalogDef != null)
            {

                Task.Run(async () =>
                {
                    Catalogs = await selectorProvider.ObtainCatalogs(lstCatalogDef!, new BaseParam(empresaId, sucursalId));
                }).Wait();
            }

            afterFillCatalogs();
        }

        protected virtual void afterFillCatalogs()
        {

        }

        protected virtual void fillCatalogConfiguration()
        {

            catalogRelatedFields = new List<CatalogRelatedFields>() { };
            lstCatalogDef = new List<CatalogDef>() { };
        }


        protected virtual void doInsert()
        {
            if (Record == null)
                return;

            var task = Task.Run<bool>(async () => await provider.Insert(Record));
            _ = task.Result;

            //provider.Insert(Record);
        }

        protected virtual void doUpdate()
        {
            if (Record == null)
                return;


            var task = Task.Run<bool>(async () => await provider.Update(Record));
            _ = task.Result;

            //provider.Update(Record);
        }


        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            ScreenExtensions.TryActivateAsync(this);
        }

        public virtual void Back()
        {
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }


        public virtual Task HandleAsync(INIP initialParameters, CancellationToken cancellationToken)
        {
            if (this.Mode == "Edit" || this.Mode == "Show")
            {
                fillRecordToEdit(initialParameters);
            }


            if (this.Mode == "Edit" && Record != null)
            {
                Record.PendingChange += CatalogField_PropertyChanging;
                Record.Validate();
            }
            return Task.CompletedTask;
        }


        public virtual void Accept()
        {

            if (this.Mode == "Edit")
            {
                AcceptEdit();
            }
            else if (this.Mode == "Add")
            {
                AcceptAdd();
            }
        }


        public virtual void SuccessAddActions(BM record)
        {

            var eventParam = new LSTP();
            eventParam.fillFields(true, true,
                                                                BProcessSuccess ?
                                                                                new MessageToUserSimple("Exito", "Se inserto el registro", "Success") :
                                                                                new MessageToUserSimple("Error", "Occurrio un error ", "Error"));

            aggregator.PublishOnUIThreadAsync(eventParam);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }

        public virtual void ErrorAddActions(BM record, string comentario)
        {
            showPopUpMessage("Ocurrio un error ", comentario, "Error");
        }


        public virtual void SuccessEditActions(BM record)
        {
            var eventParam = new LSTP();
            eventParam.fillFields(true, true,
                                                                BProcessSuccess ?
                                                                                new MessageToUserSimple("Exito", "Se actualizo el registro", "Success") :
                                                                                new MessageToUserSimple("Error", "Occurrio un error ", "Error"));

            aggregator.PublishOnUIThreadAsync(eventParam);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }


        public virtual void ErrorEditActions(BM record, string comentario)
        {
            showPopUpMessage("Ocurrio un error ", comentario, "Error");
        }

        public virtual void AcceptEdit()
        {

            if (Record == null)
                return;

            Record.ModificadoPorId = GlobalVariable.CurrentSession?.Usuarioid;

            try
            {

                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (o, ea) =>
                {
                    try
                    {
                        doUpdate();
                    }
                    catch (Exception ex)
                    {
                        bSuccess = false;
                        comentario = ex.Message;
                    }
                };
                worker.RunWorkerCompleted += (o, ea) =>
                {
                    IsBusy = false;

                    BProcessSuccess = bSuccess;
                    if (BProcessSuccess)
                    {
                        SuccessEditActions(Record);
                    }
                    else
                    {
                        ErrorEditActions(Record, comentario);
                    }
                };
                worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }

        }


        public virtual void AcceptAdd()
        {
            if (Record == null)
                return;

            Record.Creado = DateTime.Now;
            Record.Modificado = DateTime.Now;

            try
            {

                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (o, ea) =>
                {
                    try
                    {
                        doInsert();
                    }
                    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                };
                worker.RunWorkerCompleted += (o, ea) =>
                {
                    IsBusy = false;

                    BProcessSuccess = bSuccess;
                    if (BProcessSuccess)
                    {
                        SuccessAddActions(Record);
                    }
                    else
                    {
                        ErrorAddActions(Record, comentario);
                    }

                };
                worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
        }

        public virtual void Cancel()
        {
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }


        public bool CanEmpresaid
        {
            get { return (this.Mode == "Add"); }
        }

        public bool CanSucursalid
        {
            get { return (this.Mode == "Add"); }
        }

        public bool CanId
        {
            get { return (this.Mode == "Add"); }
        }



        protected virtual List<long> DerechosToCheck()
        {
            return new List<long>();
        }


        protected virtual void CheckDerechos()
        {
            DerechosUsuario = new Dictionary<long, bool>();
            var derechos = _derechosAChecar;
            if (derechos == null || GlobalVariable.CurrentSession?.CurrentUsuario?.Id == null || _usuarioControllerProvider == null)
                return;

            Task.Run(async () =>
            {
                var buffer = await _usuarioControllerProvider!.Obtain_usuarios_derechos_List(GlobalVariable.CurrentSession!.Empresaid!.Value, GlobalVariable.CurrentSession!.Sucursalid!.Value, derechos, GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value);
                if (buffer != null)
                    DerechosUsuario = buffer;
            }).Wait();


        }



    }


    public class BaseWebListViewModel<BM, PROV, INIP, LSTP, PARAM> : BaseScreen.BaseScreen, IHandle<LSTP> where BM : class, IBaseBindingModel, new() where PROV : IWebControllerProvider<BM> where INIP : BaseCommonInitialParameters, new() where LSTP : BaseListVMEventParameters, new() where PARAM : BaseParam, new()
    {
        protected readonly PROV itemsProvider;
        protected string? itemsLoadedText;
        public BM? selectedItem;
        public ObservableCollection<BM> Items { get; private set; }
        public PARAM? ListParam { get; set; }
        public KendoParams? KendoParams { get; set; }

        protected readonly IEventAggregator aggregator;

        public bool IsSelectionMode { get; set; } = false;
        public bool AllowAdd { get; set; } = true;
        public bool AllowEdit { get; set; } = true;
        public bool AllowShow { get; set; } = true;
        public double BaseWidthFactor { get; set; } = 0.75;


        private UsuarioWebController? _usuarioControllerProvider;

        private string? hiddenColumns;
        public string? HiddenColumns { get => hiddenColumns; set { hiddenColumns = value; NotifyOfPropertyChange("HiddenColumns"); } }

        public bool ChecarDerechosEstandar { get; set; } = false;

        private List<long> _derechosEstandar;


        public string ItemsLoadedText
        {
            get { return itemsLoadedText ?? ""; }
            set
            {
                itemsLoadedText = value;
                NotifyOfPropertyChange();
            }
        }

        public BaseWebListViewModel(PROV provider, UsuarioWebController? usuarioControllerProvider, SelectorWebController selectorProvider, IWindowManager winManager, IEventAggregator aggregator, IMessageBoxService messageBoxService, bool checarDerechosEstandar) :
            base(selectorProvider, winManager, messageBoxService)
        {
            itemsProvider = provider;
            Items = new ObservableCollection<BM>();
            preFillParam();
            preconfigureSearchParams();
            fillCatalogs();

            this.aggregator = aggregator;
            this.aggregator.SubscribeOnUIThread(this);

            _usuarioControllerProvider = usuarioControllerProvider;
            _derechosEstandar = new List<long>();

            ChecarDerechosEstandar = checarDerechosEstandar;

            if (ChecarDerechosEstandar)
            {
                _derechosEstandar = DerechosEstandarToCheck();
                CheckDerechos();
                AllowAdd = (DerechosUsuario?[_derechosEstandar[3]] ?? false);
                AllowEdit = (DerechosUsuario?[_derechosEstandar[1]] ?? false);
                AllowShow = (DerechosUsuario?[_derechosEstandar[0]] ?? false);
            }



        }

        public BaseWebListViewModel(PROV provider, SelectorWebController selectorProvider, IWindowManager winManager, IEventAggregator aggregator, IMessageBoxService messageBoxService) :
            this(provider, null, selectorProvider, winManager, aggregator, messageBoxService, false)
        {


        }
        protected virtual void preFillParam()
        {

            ListParam = new PARAM();
            if (GlobalVariable.CurrentSession != null)
            {

                ListParam.P_empresaid = GlobalVariable.CurrentSession.Empresaid;
                ListParam.P_sucursalid = GlobalVariable.CurrentSession.Sucursalid;
            }
        }

        protected virtual void preconfigureSearchParams()
        {
            KendoParams = new KendoParams("", @"""Clave""|""Nombre""");
        }

        protected virtual void fillCatalogs()
        {
            long? empresaId = GlobalVariable.CurrentSession?.Empresaid;
            long? sucursalId = GlobalVariable.CurrentSession?.Sucursalid;
            fillCatalogConfiguration();

            if (lstCatalogDef != null)
            {

                Task.Run(async () =>
                {
                    Catalogs = await selectorProvider.ObtainCatalogs(lstCatalogDef!, new BaseParam(empresaId, sucursalId));
                }).Wait();
            }
        }


        protected virtual void fillCatalogConfiguration()
        {

            catalogRelatedFields = new List<CatalogRelatedFields>() { };
            lstCatalogDef = new List<CatalogDef>() { };
        }

        public virtual bool CanEditItem
        {
            get { return SelectedItem != null; }
        }

        protected virtual object EditViewModel()
        {
            //return vm = IoC.Get<EditViewModel>();
            throw new Exception("not implemented");
        }

        protected virtual object ShowViewModel()
        {
            //return vm = IoC.Get<ShowViewModel>();
            throw new Exception("not implemented");
        }


        protected virtual object AddViewModel()
        {
            //return vm = IoC.Get<AddViewModel>();
            throw new Exception("not implemented");
        }


        public virtual void Edititem(BM selected)
        {

            this.SelectedItem = selected;

            var vm = EditViewModel();
            var inip = new INIP(); inip.Id = SelectedItem.Id;
            aggregator.PublishOnUIThreadAsync(inip);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
        }

        public virtual void ShowItem(BM selected)
        {
            this.SelectedItem = selected;

            var vm = ShowViewModel();
            var inip = new INIP(); inip.Id = SelectedItem.Id;
            aggregator.PublishOnUIThreadAsync(inip);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
        }


        public virtual void SelectItemByCell(BM selected)
        {
            if (IsSelectionMode)
            {
                this.SelectedItem = selected;
                this.TryCloseAsync();
            }
        }

        public virtual void AddItem()
        {

            var vm = AddViewModel();
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
        }


        public virtual void TSBBuscar()
        {
            ReloadItems();
        }
        public virtual void TSTPalabrasClaveKeyDown(Key key)
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

            if (ChecarDerechosEstandar)
            {
                if (!AllowEdit)
                {
                    HiddenColumns = HiddenColumns ?? "";

                    if (HiddenColumns!.Length > 0)
                        HiddenColumns += ",1";
                    else
                        HiddenColumns += "1";
                }
            }
        }

        protected virtual List<long> DerechosEstandarToCheck()
        {
            throw new Exception("Derechos estandar no asignados");
        }

        protected virtual void CheckDerechos()
        {
            DerechosUsuario = new Dictionary<long, bool>();
            var derechos = _derechosEstandar;
            if (derechos == null || GlobalVariable.CurrentSession?.CurrentUsuario?.Id == null || _usuarioControllerProvider == null)
                return;


            Task.Run(async () =>
            {
                var buffer = await _usuarioControllerProvider!.Obtain_usuarios_derechos_List(GlobalVariable.CurrentSession!.Empresaid!.Value, GlobalVariable.CurrentSession!.Sucursalid!.Value, derechos, GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value);
                if (buffer != null)
                    DerechosUsuario = buffer;
            }).Wait();



        }



        public Task HandleAsync(LSTP parameters, CancellationToken cancellationToken)
        {
            if (parameters.HasMessage && parameters.MsgSimple != null)
            {
                showPopUpMessage(parameters.MsgSimple);
            }

            if (parameters.IsReloadEvent)
                ReloadItems();

            return Task.CompletedTask;
        }


        public virtual void CloseApp()
        {
            Application.Current.Shutdown();
        }

        public BM? SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                NotifyOfPropertyChange(() => CanEditItem);
            }
        }

        public virtual bool CanRemoveItem
        {
            get { return SelectedItem != null; }
        }

        public virtual void RemoveItem()
        {
            if (SelectedItem == null)
                return;

            Items.Remove(SelectedItem);
        }

        public virtual async Task<System.Collections.Generic.List<BM>> DoGetItems()
        {
            if (ListParam == null)
                return new List<BM>();

            System.Collections.Generic.List<BM> items = new System.Collections.Generic.List<BM>();
            items = await itemsProvider.SelectList(ListParam, KendoParams);
            return items;
        }

        public virtual void ReloadItems()
        {
            Items.Clear();
            try
            {
                //bool bSuccess = true;
                IsBusy = true;
                var comentario = "";
                System.Collections.Generic.List<BM> items = new System.Collections.Generic.List<BM>();

                Task.Run<List<BM>>(async () => await DoGetItems()).ContinueWith((t) =>
                {
                    IsBusy = false;

                    if (t.IsFaulted)
                    {
                        //bSuccess = false; 
                        if(t.Exception != null)
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
                        items = t.Result;
                        foreach (var item in items)
                        {
                            Items.Add(item);
                        }
                        ItemsLoadedText = "Loaded!";
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());





                //BackgroundWorker worker = new BackgroundWorker();
                //worker.DoWork += async (o, ea) =>
                //{
                //    try
                //    {
                //        items = await DoGetItems();
                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusy = false;
                //    if (bSuccess)
                //    {
                //        foreach (var item in items)
                //        {
                //            Items.Add(item);
                //        }
                //        ItemsLoadedText = "Loaded!";
                //    }
                //    else { showPopUpMessage("Ocurrio un error ", comentario, "Error"); }

                //};
                //worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
        }

    }




    public class BaseGenericListViewModel<BM, INIP, LSTP, PARAM> : BaseScreen.BaseScreen, IHandle<LSTP> where BM : class, new() where INIP : BaseCommonInitialParameters, new() where LSTP : BaseListVMEventParameters, new() where PARAM : class
    {
        protected string? itemsLoadedText;
        public BM? selectedItem;
        public ObservableCollection<BM> Items { get; private set; }
        public PARAM? ListParam { get; set; }
        public KendoParams? KendoParams { get; set; }

        protected readonly IEventAggregator aggregator;

        public bool IsSelectionMode { get; set; } = false;
        public bool AllowAdd { get; set; } = true;
        public bool AllowEdit { get; set; } = true;
        public bool AllowShow { get; set; } = true;
        public double BaseWidthFactor { get; set; } = 0.75;


        private List<long> _derechosEstandar;


        private UsuarioWebController? _usuarioControllerProvider;


        public string ItemsLoadedText
        {
            get { return itemsLoadedText ?? ""; }
            set
            {
                itemsLoadedText = value;
                NotifyOfPropertyChange();
            }
        }


        public BaseGenericListViewModel( UsuarioWebController? usuarioControllerProvider, SelectorWebController selectorProvider, IWindowManager winManager, IEventAggregator aggregator, IMessageBoxService messageBoxService) :
            base(selectorProvider, winManager, messageBoxService)
        {
            _usuarioControllerProvider = usuarioControllerProvider;

            Items = new ObservableCollection<BM>();
            preFillParam();
            preconfigureSearchParams();
            fillCatalogs();

            this.aggregator = aggregator;
            this.aggregator.SubscribeOnUIThread(this);

            _derechosEstandar = this.DerechosEstandarToCheck();
            CheckDerechos();
        }



        protected virtual void preFillParam()
        {

            //ListParam = new PARAM();
            //if (GlobalVariable.CurrentSession != null)
            //{

            //    ListParam.P_empresaid = GlobalVariable.CurrentSession.Empresaid;
            //    ListParam.P_sucursalid = GlobalVariable.CurrentSession.Sucursalid;
            //}
            throw new Exception("not implemented");
        }

        protected virtual void preconfigureSearchParams()
        {
            KendoParams = new KendoParams("", @"""Clave""|""Nombre""");
        }

        protected virtual void fillCatalogs()
        {
            long? empresaId = GlobalVariable.CurrentSession?.Empresaid;
            long? sucursalId = GlobalVariable.CurrentSession?.Sucursalid;
            fillCatalogConfiguration();

            if (lstCatalogDef != null)
            {

                Task.Run(async () =>
                {
                    Catalogs = await selectorProvider.ObtainCatalogs(lstCatalogDef!, new BaseParam(empresaId, sucursalId));
                }).Wait();

            }
        }


        protected virtual void fillCatalogConfiguration()
        {

            catalogRelatedFields = new List<CatalogRelatedFields>() { };
            lstCatalogDef = new List<CatalogDef>() { };
        }


        protected virtual List<long> DerechosEstandarToCheck()
        {
            return new List<long>();
        }

        protected virtual void CheckDerechos()
        {
            DerechosUsuario = new Dictionary<long, bool>();
            var derechos = _derechosEstandar;
            if (derechos == null || derechos.Count == 0 || GlobalVariable.CurrentSession?.CurrentUsuario?.Id == null || _usuarioControllerProvider == null)
                return;


            Task.Run(async () =>
            {
                var buffer = await _usuarioControllerProvider!.Obtain_usuarios_derechos_List(GlobalVariable.CurrentSession!.Empresaid!.Value, GlobalVariable.CurrentSession!.Sucursalid!.Value, derechos, GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value);
                if (buffer != null)
                    DerechosUsuario = buffer;
            }).Wait();

        }


        public virtual bool CanEditItem
        {
            get { return SelectedItem != null; }
        }

        protected virtual object EditViewModel()
        {
            //return vm = IoC.Get<EditViewModel>();
            throw new Exception("not implemented");
        }

        protected virtual object ShowViewModel()
        {
            //return vm = IoC.Get<ShowViewModel>();
            throw new Exception("not implemented");
        }


        protected virtual object AddViewModel()
        {
            //return vm = IoC.Get<AddViewModel>();
            throw new Exception("not implemented");
        }


        public virtual void Edititem(BM selected)
        {
            //this.SelectedItem = selected;

            //var vm = EditViewModel();
            //var inip = new INIP(); inip.Id = SelectedItem.Id;
            //aggregator.PublishOnUIThreadAsync(inip);
            //aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
            throw new Exception("Not implemented");
        }

        public virtual void ShowItem(BM selected)
        {
            //this.SelectedItem = selected;

            //var vm = ShowViewModel();
            //var inip = new INIP(); inip.Id = SelectedItem.Id;
            //aggregator.PublishOnUIThreadAsync(inip);
            //aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
            throw new Exception("Not implemented");
        }


        public virtual void SelectItemByCell(BM selected)
        {
            if (IsSelectionMode)
            {
                this.SelectedItem = selected;
                this.TryCloseAsync();
            }
        }

        public virtual void AddItem()
        {

            var vm = AddViewModel();
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
        }


        public virtual void TSBBuscar()
        {
            ReloadItems();
        }
        public virtual void TSTPalabrasClaveKeyDown(Key key)
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



        public Task HandleAsync(LSTP parameters, CancellationToken cancellationToken)
        {
            if (parameters.HasMessage && parameters.MsgSimple != null)
            {
                showPopUpMessage(parameters.MsgSimple);
            }

            if (parameters.IsReloadEvent)
                ReloadItems();

            return Task.CompletedTask;
        }


        public virtual void CloseApp()
        {
            Application.Current.Shutdown();
        }

        public BM? SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                NotifyOfPropertyChange(() => CanEditItem);
            }
        }

        public virtual bool CanRemoveItem
        {
            get { return SelectedItem != null; }
        }

        public virtual void RemoveItem()
        {
            if (SelectedItem == null)
                return;

            Items.Remove(SelectedItem);
        }

        public virtual System.Collections.Generic.List<BM> DoGetItems()
        {
            //if (ListParam == null)
            //    return new List<BM>();

            //System.Collections.Generic.List<BM> items = new System.Collections.Generic.List<BM>();
            //items = itemsProvider.SelectList(ListParam, KendoParams);
            //return items;
            throw new Exception("Method Not implemented");
        }
        

        public virtual void ReloadItems()
        {
            Items.Clear();
            try
            {
                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";
                System.Collections.Generic.List<BM> items = new System.Collections.Generic.List<BM>();
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (o, ea) =>
                {
                    try
                    {
                        items = DoGetItems();
                    }
                    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                };
                worker.RunWorkerCompleted += (o, ea) =>
                {
                    IsBusy = false;
                    if (bSuccess)
                    {
                        foreach (var item in items)
                        {
                            Items.Add(item);
                        }
                        ItemsLoadedText = "Loaded!";
                    }
                    else { showPopUpMessage("Ocurrio un error ", comentario, "Error"); }

                };
                worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
        }

    }

    public class BaseGenericViewModel : BaseScreen.BaseScreen, IHandle<BaseListVMEventParameters>
    {
        public KendoParams? KendoParams { get; set; }

        protected readonly IEventAggregator aggregator;

        public double BaseWidthFactor { get; set; } = 0.75;



        public BaseGenericViewModel(SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager,  IMessageBoxService messageBoxService) :
            base(selectorProvider, winManager, messageBoxService)
        {
            fillCatalogs();

            this.aggregator = aggregator;
            this.aggregator.SubscribeOnUIThread(this);
        }

        protected virtual void fillCatalogs()
        {
            long? empresaId = GlobalVariable.CurrentSession?.Empresaid;
            long? sucursalId = GlobalVariable.CurrentSession?.Sucursalid;
            fillCatalogConfiguration();

            if (lstCatalogDef != null)
            {
                Task.Run(async () =>
                {
                    Catalogs = await selectorProvider.ObtainCatalogs(lstCatalogDef!, new BaseParam(empresaId, sucursalId));
                }).Wait();

            }
        }


        protected virtual void fillCatalogConfiguration()
        {

            catalogRelatedFields = new List<CatalogRelatedFields>() { };
            lstCatalogDef = new List<CatalogDef>() { };
        }

        
        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }



        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            ScreenExtensions.TryActivateAsync(this);
        }




        public virtual void CloseApp()
        {
            Application.Current.Shutdown();
        }



        public virtual void ShowMessageOnMainThread(MessageToUserSimple messageToUser)
        {

            var eventParam = new BaseListVMEventParameters();
            eventParam.fillFields(true, true, messageToUser);

            aggregator.PublishOnUIThreadAsync(eventParam);
        }

        public Task HandleAsync(BaseListVMEventParameters parameters, CancellationToken cancellationToken)
        {
            if (parameters.HasMessage && parameters.MsgSimple != null)
            {
                showPopUpMessage(parameters.MsgSimple);
            }


            return Task.CompletedTask;
        }



    }







}
