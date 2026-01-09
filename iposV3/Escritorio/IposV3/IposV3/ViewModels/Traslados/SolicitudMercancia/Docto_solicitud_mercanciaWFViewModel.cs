
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
    public class Docto_solicitud_mercanciaWFViewModel : BaseGenericViewModel
    {



        public Docto_solic_merc_lstParamWFBindingModel? Docto_solicitud_mercanciaselItem { get; set; }

        public ObservableCollection<Docto_solicitud_mercanciaWFBindingModel> Items { get; set; }

        public Docto_solicitud_mercanciaWFBindingModel? selectedItem;

        public Docto_solicitud_mercanciaWFBindingModel? SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                NotifyOfPropertyChange(() => CanEditItem);
            }
        }

        public PuntoSolicitudMercanciaWebController itemsProvider;

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


        public bool AllowAdd { get; set; } = true;
        public bool AllowEdit { get; set; } = true;
        public bool AllowShow { get; set; } = true;



        public Docto_solicitud_mercanciaWFViewModel(PuntoSolicitudMercanciaWebController itemsProvider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService)
        {

            this.itemsProvider = itemsProvider;

            Docto_solicitud_mercanciaselItem = new Docto_solic_merc_lstParamWFBindingModel();
            Docto_solicitud_mercanciaselItem!.PendingChange += CatalogField_PropertyChanging;
            Docto_solicitud_mercanciaselItem.EmpresaId = GlobalVariable.CurrentSession!.Empresaid;
            Docto_solicitud_mercanciaselItem.SucursalId = GlobalVariable.CurrentSession!.Sucursalid;

            Docto_solicitud_mercanciaselItem.TipoDoctoId = DBValues._DOCTO_TIPO_PEDIDO_COMPRA;
            Docto_solicitud_mercanciaselItem.SoloPendientes = BoolCS.S;
            Docto_solicitud_mercanciaselItem.Usuarioid = 0;
            Docto_solicitud_mercanciaselItem.FechaIni = DateTimeOffset.UtcNow.AddDays(-100);
            Docto_solicitud_mercanciaselItem.FechaFin = DateTimeOffset.UtcNow.AddDays(1);




            Items = new ObservableCollection<Docto_solicitud_mercanciaWFBindingModel>();




        }


        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() { };
            lstCatalogDef = new List<CatalogDef>() { };

        }

        public virtual void TSBBuscar()
        {
            ReloadItems();

        }

        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            ReloadItems();
            return Task.FromResult(true);
        }


        public async Task<System.Collections.Generic.List<Docto_solicitud_mercanciaWFBindingModel>> DoGetItems()
        {
            System.Collections.Generic.List<Docto_solicitud_mercanciaWFBindingModel> items = new System.Collections.Generic.List<Docto_solicitud_mercanciaWFBindingModel>();

            if (Docto_solicitud_mercanciaselItem == null)
                return items;


            items = await itemsProvider.Select_docto_traslado_rec_List(Docto_solicitud_mercanciaselItem) ?? new List<Docto_solicitud_mercanciaWFBindingModel>();
            

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
                System.Collections.Generic.List<Docto_solicitud_mercanciaWFBindingModel> items = new System.Collections.Generic.List<Docto_solicitud_mercanciaWFBindingModel>();

                
                Task.Run<List<Docto_solicitud_mercanciaWFBindingModel>>(async () =>
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
                            //Items = new ObservableCollection<Docto_solicitud_mercanciaWFBindingModel>(items);
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
                //        //Items = new ObservableCollection<Docto_solicitud_mercanciaWFBindingModel>(items);
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

            //var vm = IoC.Get<WFPagoCompuestoEditWFViewModel>();
            //aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
            

            var vm = IoC.Get<Movto_solicitud_mercanciaWFViewModel>();
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
        }


        public void ShowItem(Docto_solicitud_mercanciaWFBindingModel selected)
        {
            this.SelectedItem = selected;

            var vm = IoC.Get<Movto_solicitud_mercanciaWFViewModel>();
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
            vm.LoadSolicitudMercancia(selected.Id!.Value);
        }




        public virtual bool CanEditItem
        {
            get { return SelectedItem != null; }
        }



    }


}


