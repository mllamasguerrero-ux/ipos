
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
    public class Docto_pedido_entradaWFViewModel : BaseGenericViewModel
    {



        public Docto_ped_entr_lstParamWFBindingModel? Docto_pedido_entradaselItem { get; set; }

        public ObservableCollection<Docto_pedido_entradaWFBindingModel> Items { get; set; }

        public Docto_pedido_entradaWFBindingModel? selectedItem;

        public Docto_pedido_entradaWFBindingModel? SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                NotifyOfPropertyChange(() => CanEditItem);
            }
        }

        public PuntoPedidoEntradaWebController itemsProvider;

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



        public Docto_pedido_entradaWFViewModel(PuntoPedidoEntradaWebController itemsProvider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService)
        {

            this.itemsProvider = itemsProvider;

            Docto_pedido_entradaselItem = new Docto_ped_entr_lstParamWFBindingModel();
            Docto_pedido_entradaselItem!.PendingChange += CatalogField_PropertyChanging;
            Docto_pedido_entradaselItem.EmpresaId = GlobalVariable.CurrentSession!.Empresaid;
            Docto_pedido_entradaselItem.SucursalId = GlobalVariable.CurrentSession!.Sucursalid;

            Docto_pedido_entradaselItem.TipoDoctoId = DBValues._DOCTO_TIPO_TRASPASO_ENVIO_BORRADOR;
            Docto_pedido_entradaselItem.SoloPendientes = BoolCS.S;
            Docto_pedido_entradaselItem.Usuarioid = 0;
            Docto_pedido_entradaselItem.FechaIni = DateTimeOffset.UtcNow.AddDays(-100);
            Docto_pedido_entradaselItem.FechaFin = DateTimeOffset.UtcNow.AddDays(1);




            Items = new ObservableCollection<Docto_pedido_entradaWFBindingModel>();




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


        public async Task<System.Collections.Generic.List<Docto_pedido_entradaWFBindingModel>> DoGetItems()
        {
            System.Collections.Generic.List<Docto_pedido_entradaWFBindingModel> items = new System.Collections.Generic.List<Docto_pedido_entradaWFBindingModel>();

            if (Docto_pedido_entradaselItem == null)
                return items;


            items = await itemsProvider.Select_docto_pedido_entrada_List(Docto_pedido_entradaselItem) ?? new List<Docto_pedido_entradaWFBindingModel>();
            

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
                System.Collections.Generic.List<Docto_pedido_entradaWFBindingModel> items = new System.Collections.Generic.List<Docto_pedido_entradaWFBindingModel>();

                
                Task.Run<List<Docto_pedido_entradaWFBindingModel>>(async () =>
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
                //        //Items = new ObservableCollection<Docto_pedido_entradaWFBindingModel>(items);
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




        public void ShowItem(Docto_pedido_entradaWFBindingModel selected)
        {
            this.SelectedItem = selected;

            var vm = IoC.Get<Movto_pedido_entradaWFViewModel>();
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
            vm.LoadPedidoEntrada(selected.Id!.Value);
        }




        public virtual bool CanEditItem
        {
            get { return SelectedItem != null; }
        }



    }


}


