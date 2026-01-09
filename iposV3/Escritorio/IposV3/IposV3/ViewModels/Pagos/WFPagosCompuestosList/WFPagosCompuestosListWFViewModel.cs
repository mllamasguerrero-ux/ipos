
using BindingModels;
using IposV3.Model;
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
using System.Collections.ObjectModel;
using System.Threading;

namespace IposV3.ViewModels
{

    public class WFPagosCompuestosListWFViewModel : BaseGenericViewModel, IHandle<WFPagosCompuestosVMInitialParameters>, IHandle<WFPagosListVMEventParameters>
    {

        public V_pagos_compuestos_list_selWFBindingModel? V_pagos_compuestos_list_selItem { get; set; }

        public ObservableCollection<V_pago_compuestoWFBindingModel> Items { get; set; }

        public V_pago_compuestoWFBindingModel? selectedItem;

        public V_pago_compuestoWFBindingModel? SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                NotifyOfPropertyChange(() => CanEditItem);
            }
        }

        public PagoWebController itemsProvider;

        protected string? itemsLoadedText;
        public string ItemsLoadedText
        {
            get { return itemsLoadedText ?? ""; }
            set
            {
                itemsLoadedText = value;
                NotifyOfPropertyChange();
            }
        }



        public long tipoDoctoId;
        public long TipoDoctoId
        {
            get { return tipoDoctoId; }
            set
            {
                tipoDoctoId = value;
                NotifyOfPropertyChange();
            }
        }


        public bool AllowAdd { get; set; } = true;
        public bool AllowEdit { get; set; } = true;
        public bool AllowShow { get; set; } = true;

        public bool EsTransaccionDeSalida
        {
            get { return tipoDoctoId == DBValues._DOCTO_TIPO_VENTA; }
        }


        public WFPagosCompuestosListWFViewModel(PagoWebController itemsProvider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService)
        {
            this.itemsProvider = itemsProvider;

            V_pagos_compuestos_list_selItem = new V_pagos_compuestos_list_selWFBindingModel();
            V_pagos_compuestos_list_selItem!.PendingChange += CatalogField_PropertyChanging;
            V_pagos_compuestos_list_selItem.EmpresaId = GlobalVariable.CurrentSession!.Empresaid;
            V_pagos_compuestos_list_selItem.SucursalId = GlobalVariable.CurrentSession!.Sucursalid;
            V_pagos_compuestos_list_selItem.Aplicados = "Todos";
            V_pagos_compuestos_list_selItem.Timbrados = "Todos";
            V_pagos_compuestos_list_selItem.Fechainicial = DateTimeOffset.Now.Date.AddMonths(-1);


            Items = new ObservableCollection<V_pago_compuestoWFBindingModel>();

            this.TipoDoctoId = DBValues._DOCTO_TIPO_VENTA;


        }


        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            V_pagos_compuestos_list_selItem!.Tipodoctoid = TipoDoctoId;
            ReloadItems();
            return Task.FromResult(true);

        }



        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            ScreenExtensions.TryActivateAsync(this);

        }

        protected override void fillCatalogConfiguration()
        {


            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("V_pagos_compuestos_list_selItem","Cliente","Clienteid", "Clienteclave", "Clientenombre","IposV3.ViewModels.ClienteListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("V_pagos_compuestos_list_selItem","Proveedor","Proveedorid", "Proveedorclave", "Proveedornombre","IposV3.ViewModels.ProveedorListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>() { new CatalogDef(
                    "Formapago")};

        }


        public virtual void TSBBuscar()
        {
            ReloadItems();

        }


        public async Task<System.Collections.Generic.List<V_pago_compuestoWFBindingModel>> DoGetItems()
        {
            System.Collections.Generic.List<V_pago_compuestoWFBindingModel> items = new System.Collections.Generic.List<V_pago_compuestoWFBindingModel>();

            if (V_pagos_compuestos_list_selItem == null)
                return items;


            items = await itemsProvider.PagoCompuestoList(V_pagos_compuestos_list_selItem) ?? items;

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
                System.Collections.Generic.List<V_pago_compuestoWFBindingModel> items = new System.Collections.Generic.List<V_pago_compuestoWFBindingModel>();

                
                Task.Run<List<V_pago_compuestoWFBindingModel>>(async () =>
                                                      await DoGetItems()
                                                 ).ContinueWith((t) =>
                {
                    IsBusy = false;

                    if (t.IsFaulted)
                    {
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
                        items = t.Result;

                        if (bSuccess)
                        {
                            foreach (var item in items)
                            {
                                Items.Add(item);
                            }
                            ItemsLoadedText = "Loaded!";
                        }
                        else { showPopUpMessage("Ocurrio un error ", comentario, "Error"); }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());


                //BackgroundWorker worker = new BackgroundWorker();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {
                //        items = DoGetItems();
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
                //        //Items = new ObservableCollection<V_pago_compuestoWFBindingModel>(items);
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


        public void AddItem()
        {

            var vm = IoC.Get<WFPagoCompuestoEditWFViewModel>();
            var inip = new WFPagosItemVMInitialParameters();
            inip.TipoDoctoId = this.tipoDoctoId;
            aggregator.PublishOnUIThreadAsync(inip);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
        }


        public void ShowItem(V_pago_compuestoWFBindingModel selected)
        {
            this.SelectedItem = selected;

            var vm = ShowViewModel();
            var inip = new WFPagosItemVMInitialParameters(); 
            inip.Id = SelectedItem.Id;
            inip.Mode = "Show";
            inip.TipoDoctoId = this.tipoDoctoId;
            aggregator.PublishOnUIThreadAsync(inip);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
        }


        public void Edititem(V_pago_compuestoWFBindingModel selected)
        {
            this.SelectedItem = selected;

            var vm = ShowViewModel();
            var inip = new WFPagosItemVMInitialParameters();
            inip.Id = SelectedItem.Id;
            inip.Mode = "Edit";
            inip.TipoDoctoId = this.tipoDoctoId;
            aggregator.PublishOnUIThreadAsync(inip);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
        }

        public virtual bool CanEditItem
        {
            get { return SelectedItem != null; }
        }


        protected object ShowViewModel()
        {
            return IoC.Get<WFPagoCompuestoEditWFViewModel>();
        }




        public Task HandleAsync(WFPagosCompuestosVMInitialParameters parameters, CancellationToken cancellationToken)
        {
            this.TipoDoctoId = parameters.TipoDoctoId ?? DBValues._DOCTO_TIPO_VENTA;
            return Task.CompletedTask;
        }

        public Task HandleAsync(WFPagosListVMEventParameters message, CancellationToken cancellationToken)
        {
            this.ReloadItems();
            return Task.CompletedTask;
        }
    }

}


