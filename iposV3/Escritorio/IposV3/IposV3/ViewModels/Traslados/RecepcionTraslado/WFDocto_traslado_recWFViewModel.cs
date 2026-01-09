
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

    public class WFDocto_traslado_recWFViewModel : BaseGenericViewModel
    {



        public Docto_traslado_rec_lstParamWFBindingModel? Docto_traslado_recselItem  { get; set; }

        public ObservableCollection<Docto_traslado_recWFBindingModel> Items { get; set; }

        public Docto_traslado_recWFBindingModel? selectedItem;

        public Docto_traslado_recWFBindingModel? SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                NotifyOfPropertyChange(() => CanEditItem);
            }
        }

        public PuntoTrasladoRecepcionWebController itemsProvider;

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



        public WFDocto_traslado_recWFViewModel(PuntoTrasladoRecepcionWebController itemsProvider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService)
        {

            this.itemsProvider = itemsProvider;

            Docto_traslado_recselItem = new Docto_traslado_rec_lstParamWFBindingModel();
            Docto_traslado_recselItem!.PendingChange += CatalogField_PropertyChanging;
            Docto_traslado_recselItem.EmpresaId = GlobalVariable.CurrentSession!.Empresaid;
            Docto_traslado_recselItem.SucursalId = GlobalVariable.CurrentSession!.Sucursalid;

            Docto_traslado_recselItem.TipoDoctoId = DBValues._DOCTO_TIPO_TRASPASO_REC;
            Docto_traslado_recselItem.EstatusDoctoId = DBValues._DOCTO_ESTATUS_BORRADOR;
            Docto_traslado_recselItem.Usuarioid = 0;
            Docto_traslado_recselItem.FechaIni = DateTimeOffset.UtcNow.AddDays(-100);
            Docto_traslado_recselItem.FechaFin = DateTimeOffset.UtcNow.AddDays(1);




            Items = new ObservableCollection<Docto_traslado_recWFBindingModel>();




        }


        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() { };
            lstCatalogDef = new List<CatalogDef>() { new CatalogDef(
                    "Estatusdocto_Proveeduria")};

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


        public async Task<System.Collections.Generic.List<Docto_traslado_recWFBindingModel>> DoGetItems()
        {
            System.Collections.Generic.List<Docto_traslado_recWFBindingModel> items = new System.Collections.Generic.List<Docto_traslado_recWFBindingModel>();

            if (Docto_traslado_recselItem == null)
                return items;


            items = await itemsProvider.Select_docto_traslado_rec_List(Docto_traslado_recselItem) ?? items;

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
                System.Collections.Generic.List<Docto_traslado_recWFBindingModel> items = new System.Collections.Generic.List<Docto_traslado_recWFBindingModel>();

                
                Task.Run<List<Docto_traslado_recWFBindingModel>>(async () =>
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
                //        //Items = new ObservableCollection<Docto_traslado_recWFBindingModel>(items);
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
        }


        public void ShowItem(Docto_traslado_recWFBindingModel selected)
        {
            this.SelectedItem = selected;

            var vm = IoC.Get<WFMovto_traslado_recWFViewModel>();
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
            vm.LoadInfoEdit(selected);
        }




        public virtual bool CanEditItem
        {
            get { return SelectedItem != null; }
        }
        


    }


}


