
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

    public class WFDoctosConSaldoViewModel : BaseGenericViewModel
    {



        private V_DoctosConSaldo_SelectorBindingModel? v_DoctosConSaldo_SelectorItem;
        public V_DoctosConSaldo_SelectorBindingModel? V_DoctosConSaldo_SelectorItem
        {
            get => v_DoctosConSaldo_SelectorItem;
            set
            {
                v_DoctosConSaldo_SelectorItem = value; NotifyOfPropertyChange("V_DoctosConSaldo_SelectorItem");

                if (v_DoctosConSaldo_SelectorItem != null)
                {
                    //v_DoctosConSaldo_SelectorItem.PendingChange += V_DoctosConSaldo_SelectorItemChangeEventHandler;
                    v_DoctosConSaldo_SelectorItem.PropertyChanged += V_DoctosConSaldo_SelectorItemChangedEventHandler;
                }
            }
        }


        public ObservableCollection<V_docto_con_saldoWFBindingModel> Items { get; set; }

        public V_docto_con_saldoWFBindingModel? selectedItem;

        public V_docto_con_saldoWFBindingModel? SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                NotifyOfPropertyChange();
                //NotifyOfPropertyChange(() => CanEditItem);
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

                if (V_DoctosConSaldo_SelectorItem != null)
                {

                    V_DoctosConSaldo_SelectorItem.TipodoctoId = tipoDoctoId;
                }

                NotifyOfPropertyChange();
                NotifyOfPropertyChange("EsTransaccionDeSalida");
            }
        }



        public bool EsTransaccionDeSalida
        {
            get { return tipoDoctoId == DBValues._DOCTO_TIPO_VENTA; }
        }



        private ClienteBindingModel? clientePago;
        public ClienteBindingModel? ClientePago { get => clientePago; set { clientePago = value; NotifyOfPropertyChange("ClientePago"); } }

        protected readonly ClienteWebController clienteProvider;

        private ProveedorBindingModel? proveedorPago;
        public ProveedorBindingModel? ProveedorPago { get => proveedorPago; set { proveedorPago = value; NotifyOfPropertyChange("ProveedorPago"); } }

        protected readonly ProveedorWebController proveedorProvider;



        public WFDoctosConSaldoViewModel(PagoWebController itemsProvider, ClienteWebController clienteprovider, ProveedorWebController proveedorProvider,
            SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService)
        {
            this.itemsProvider = itemsProvider;
            this.clienteProvider = clienteprovider;
            this.proveedorProvider = proveedorProvider;

            V_DoctosConSaldo_SelectorItem = new V_DoctosConSaldo_SelectorBindingModel();
            V_DoctosConSaldo_SelectorItem!.PendingChange += CatalogField_PropertyChanging;
            V_DoctosConSaldo_SelectorItem.EmpresaId = GlobalVariable.CurrentSession!.Empresaid;
            V_DoctosConSaldo_SelectorItem.SucursalId = GlobalVariable.CurrentSession!.Sucursalid;
            V_DoctosConSaldo_SelectorItem.FechaInicial = DateTimeOffset.Now.Date.AddMonths(-1);
            V_DoctosConSaldo_SelectorItem.FechaFinal = DateTimeOffset.Now.Date;
            V_DoctosConSaldo_SelectorItem.EstatusDoctoId = DBValues._DOCTO_ESTATUS_COMPLETO;
            V_DoctosConSaldo_SelectorItem.TipodoctoId = DBValues._DOCTO_TIPO_VENTA;


            Items = new ObservableCollection<V_docto_con_saldoWFBindingModel>();

            this.TipoDoctoId = DBValues._DOCTO_TIPO_VENTA;

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



        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("V_DoctosConSaldo_SelectorItem","Cliente","ClienteId", "ClienteClave", "ClienteNombre","IposV3.ViewModels.ClienteListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("V_DoctosConSaldo_SelectorItem","Proveedor","ProveedorId", "ProveedorClave", "ProveedorNombre","IposV3.ViewModels.ProveedorListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("V_DoctosConSaldo_SelectorItem","Usuario","UsuarioId", "UsuarioClave", "UsuarioNombre","IposV3.ViewModels.UsuarioListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>();
            
        }




        private void V_DoctosConSaldo_SelectorItemChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {

                case "ClienteId":
                    AssignClientInfo();
                    break;


                case "ProveedorId":
                    AssignProveedorInfo();
                    break;

                default:
                    break;
            }
        }

        public void AssignClientInfo()
        {
            if (V_DoctosConSaldo_SelectorItem?.ClienteId.HasValue != true || V_DoctosConSaldo_SelectorItem!.ClienteId!.Value == 0)
            {
                ClientePago = new ClienteBindingModel();
                return;
            }

            Task.Run(async () =>
            {

                ClientePago = await clienteProvider.GetById(new ClienteBindingModel()
                {
                    Id = V_DoctosConSaldo_SelectorItem!.ClienteId!.Value,
                    EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                    SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid
                });
            }).Wait();

        }


        public void AssignProveedorInfo()
        {
            if (V_DoctosConSaldo_SelectorItem?.ProveedorId.HasValue != true || V_DoctosConSaldo_SelectorItem!.ProveedorId!.Value == 0)
            {
                ProveedorPago = new ProveedorBindingModel();
                return;
            }

            Task.Run(async () =>
            {

                ProveedorPago = await proveedorProvider.GetById(new ProveedorBindingModel()
                {
                    Id = V_DoctosConSaldo_SelectorItem!.ProveedorId!.Value,
                    EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid,
                    SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid
                });
            }).Wait();
        }



        public virtual void TSBBuscar()
        {
            ReloadItems();

        }


        public void SelectItemByCell(V_docto_con_saldoWFBindingModel selected)
        {
                this.SelectedItem = selected;
                this.TryCloseAsync();
        }


        public async Task<System.Collections.Generic.List<V_docto_con_saldoWFBindingModel>> DoGetItems()
        {
            System.Collections.Generic.List<V_docto_con_saldoWFBindingModel> items = new System.Collections.Generic.List<V_docto_con_saldoWFBindingModel>();

            if(V_DoctosConSaldo_SelectorItem == null)
                return items;

            items = await itemsProvider.DoctosConSaldoList(
                                                    V_DoctosConSaldo_SelectorItem.EmpresaId!.Value,
                                                    V_DoctosConSaldo_SelectorItem.SucursalId!.Value,
                                                    V_DoctosConSaldo_SelectorItem.TipodoctoId ?? tipoDoctoId,
                                                    V_DoctosConSaldo_SelectorItem.ClienteId,
                                                    V_DoctosConSaldo_SelectorItem.ProveedorId,
                                                    V_DoctosConSaldo_SelectorItem.SoloTimbrados ?? false,
                                                    V_DoctosConSaldo_SelectorItem.UsuarioId,
                                                    V_DoctosConSaldo_SelectorItem.CorteActivo ?? false,
                                                    V_DoctosConSaldo_SelectorItem.Referencia ?? "",
                                                    V_DoctosConSaldo_SelectorItem.FechaInicial,
                                                    V_DoctosConSaldo_SelectorItem.FechaFinal,
                                                    V_DoctosConSaldo_SelectorItem.EstatusDoctoId) ?? items;



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
                System.Collections.Generic.List<V_docto_con_saldoWFBindingModel> items = new System.Collections.Generic.List<V_docto_con_saldoWFBindingModel>();

                
                Task.Run<List<V_docto_con_saldoWFBindingModel>>(async () =>
                                                      await DoGetItems()
                                                 ).ContinueWith((t) =>
                {
                    IsBusy = false;

                    if (t.IsFaulted)
                    {
                        bSuccess = false;
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

    }



}


