using BindingModels;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
using IposV3Sync.Controllers.Controller;
using IposV3.Model;
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
using ViewModels.BaseScreen;

namespace IposV3Sync.ViewModels
{

    public class BaseRecordViewModel<BM, PROV, INIP, LSTP> : BaseScreen.BaseScreen, IHandle<INIP> where BM : class, IBaseBindingModel, new() where PROV : IControllerProvider<BM> where INIP : BaseCommonInitialParameters where LSTP : BaseListVMEventParameters, new()
    {

        protected readonly PROV provider;
        protected readonly IEventAggregator aggregator;

        public BM? Record { get; set; }

        public bool BIsReadOnly { get; protected set; }

        public bool BProcessSuccess { get; protected set; }

        public string Mode { get; protected set; }


        public BaseRecordViewModel(string mode, PROV provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) : base(selectorProvider, winManager, messageBoxService)
        {
            this.Mode = mode == null ? "Add" : mode;
            this.provider = provider;
            this.aggregator = aggregator;
            this.BIsReadOnly = false;


            fillCatalogs();

            if (this.Mode == "Edit")
            {
                aggregator.SubscribeOnPublishedThread(this);
            }
            else if (this.Mode == "Add")
            {
                preFillRecordToAdd();
                Record!.PendingChange += CatalogField_PropertyChanging;
            }
            else if (this.Mode == "Show")
            {

                this.BIsReadOnly = true;
                aggregator.SubscribeOnPublishedThread(this);
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
                Catalogs = selectorProvider.ObtainCatalogs(lstCatalogDef, new BaseParam(empresaId, sucursalId));
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





    }



    public class BaseListViewModel<BM, PROV, INIP, LSTP, PARAM> : BaseScreen.BaseScreen, IHandle<LSTP> where BM : class, IBaseBindingModel, new() where PROV : IControllerProvider<BM> where INIP : BaseCommonInitialParameters, new() where LSTP : BaseListVMEventParameters, new() where PARAM : BaseParam, new()
    {
        protected readonly PROV itemsProvider;
        protected string? itemsLoadedText;
        public BM? selectedItem;
        public ObservableCollection<BM> Items { get; private set; }
        protected PARAM? ListParam { get; set; }
        public KendoParams? KendoParams { get; set; }

        protected readonly IEventAggregator aggregator;

        public bool IsSelectionMode { get; set; } = false;
        public bool AllowAdd { get; set; } = true;
        public bool AllowEdit { get; set; } = true;
        public bool AllowShow { get; set; } = true;
        public double BaseWidthFactor { get; set; } = 0.75;


        public string ItemsLoadedText
        {
            get { return itemsLoadedText ?? ""; }
            set
            {
                itemsLoadedText = value;
                NotifyOfPropertyChange();
            }
        }

        public BaseListViewModel(PROV provider, SelectorWebController selectorProvider, IWindowManager winManager, IEventAggregator aggregator, IMessageBoxService messageBoxService) :
            base(selectorProvider, winManager, messageBoxService)
        {
            itemsProvider = provider;
            Items = new ObservableCollection<BM>();
            preFillParam();
            preconfigureSearchParams();
            fillCatalogs();

            this.aggregator = aggregator;
            this.aggregator.SubscribeOnUIThread(this);
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
                Catalogs = selectorProvider.ObtainCatalogs(lstCatalogDef, new BaseParam(empresaId, sucursalId));
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


        public string ItemsLoadedText
        {
            get { return itemsLoadedText ?? ""; }
            set
            {
                itemsLoadedText = value;
                NotifyOfPropertyChange();
            }
        }

        public BaseGenericListViewModel( SelectorWebController selectorProvider, IWindowManager winManager, IEventAggregator aggregator, IMessageBoxService messageBoxService) :
            base(selectorProvider, winManager, messageBoxService)
        {
            Items = new ObservableCollection<BM>();
            preFillParam();
            preconfigureSearchParams();
            fillCatalogs();

            this.aggregator = aggregator;
            this.aggregator.SubscribeOnUIThread(this);
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
                Catalogs = selectorProvider.ObtainCatalogs(lstCatalogDef, new BaseParam(empresaId, sucursalId));
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

    public class BaseGenericViewModel : BaseScreen.BaseScreen 
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
                Catalogs = selectorProvider.ObtainCatalogs(lstCatalogDef, new BaseParam(empresaId, sucursalId));
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

       
    }







}
