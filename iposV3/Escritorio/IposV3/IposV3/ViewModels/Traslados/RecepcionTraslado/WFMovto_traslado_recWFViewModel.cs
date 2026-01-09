
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
using System.Collections.Specialized;
using Controllers.BindingModel;
using IposV3.BindingModel;

namespace IposV3.ViewModels
{

    public class WFMovto_traslado_recWFViewModel : BaseGenericViewModel
    {


        public Movto_traslado_rec_lstParamWFBindingModel? Movto_traslado_rec_selItem { get; set; }


        public Recibir_traslado_ParamWFBindingModel? Recibir_traslado_param { get; set; }



        //private Recibir_traslado_ParamWFBindingModel? recibir_traslado_param;
        //public Recibir_traslado_ParamWFBindingModel? Recibir_traslado_param
        //{
        //    get => recibir_traslado_param;
        //    set
        //    {
        //        recibir_traslado_param = value; NotifyOfPropertyChange("Recibir_traslado_param");
        //        recibir_traslado_param.PendingChange += CatalogField_PropertyChanging; 
        //        recibir_traslado_param.PropertyChanged += Recibir_traslado_paramPropertyChangedEventHandler;
        //    }
        //}


        public ObservableCollection<Movto_traslado_recWFBindingModel> Items { get; set; }

        public Movto_traslado_recWFBindingModel? selectedItem;

        public Movto_traslado_recWFBindingModel? SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                NotifyOfPropertyChange(() => CanEditItem);
            }
        }

        public PuntoTrasladoRecepcionWebController itemsProvider;
        protected readonly ImpoExpoWebController impoExpoProvider;

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




        //configuration
        public GlobalSession? GlobalSession { get => GlobalVariable.CurrentSession; }

        public bool AllowAdd { get; set; } = true;
        public bool AllowEdit { get; set; } = true;
        public bool AllowShow { get; set; } = true;

        public bool BProcessSuccess { get; protected set; }


        bool clearingOrLoadingDoctoInfo = false;

        public WFMovto_traslado_recWFViewModel(PuntoTrasladoRecepcionWebController itemsProvider,
                                                ImpoExpoWebController impoExpoProvider, 
                                                SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService)
        {

            this.itemsProvider = itemsProvider;
            this.impoExpoProvider = impoExpoProvider;

            Movto_traslado_rec_selItem = new Movto_traslado_rec_lstParamWFBindingModel();
            Movto_traslado_rec_selItem!.PendingChange += CatalogField_PropertyChanging;
            Movto_traslado_rec_selItem.EmpresaId = GlobalVariable.CurrentSession!.Empresaid;
            Movto_traslado_rec_selItem.SucursalId = GlobalVariable.CurrentSession!.Sucursalid;

            Recibir_traslado_param = new Recibir_traslado_ParamWFBindingModel();
            Recibir_traslado_param.EmpresaId = GlobalVariable.CurrentSession!.Empresaid;
            Recibir_traslado_param.SucursalId = GlobalVariable.CurrentSession!.Sucursalid;
            Recibir_traslado_param.UsuarioId = GlobalVariable.CurrentSession!.Usuarioid;
            Recibir_traslado_param.AlmacenId = DBValues._ALMACEN_DEFAULT;
            Recibir_traslado_param.Referencias = "";
            Recibir_traslado_param.PendingChange += CatalogField_PropertyChanging;
            Recibir_traslado_param.PropertyChanged += Recibir_traslado_paramPropertyChangedEventHandler;
            //this.Recibir_traslado_param.DoctoARecibirId 


            Items = new ObservableCollection<Movto_traslado_recWFBindingModel>();
            Items.CollectionChanged += MovtoItems_CollectionChanged;



        }


        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() { };
            lstCatalogDef = new List<CatalogDef>() {new CatalogDef(
                    "Almacen") };

        }

        public virtual void TSBBuscar()
        {
            ReloadItems();

        }

        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }


        public void LoadInfoEdit(Docto_traslado_recWFBindingModel doctoTraslado)
        {
            Movto_traslado_rec_selItem = new Movto_traslado_rec_lstParamWFBindingModel();
            Movto_traslado_rec_selItem.EmpresaId = doctoTraslado.EmpresaId;
            Movto_traslado_rec_selItem.SucursalId = doctoTraslado.SucursalId;
            Movto_traslado_rec_selItem.DoctoId = doctoTraslado.Id;

            Recibir_traslado_param!.DoctoARecibirId = doctoTraslado.Id;

            ReloadItems();
        }

        public async Task<System.Collections.Generic.List<Movto_traslado_recWFBindingModel>> DoGetItems()
        {
            System.Collections.Generic.List<Movto_traslado_recWFBindingModel> items = new System.Collections.Generic.List<Movto_traslado_recWFBindingModel>();

            if (Movto_traslado_rec_selItem == null)
                return items;


            items = await itemsProvider.Select_movto_traslado_rec_List(Movto_traslado_rec_selItem) ?? items;

            items.ForEach(i => { 
                i.Cantidadsurtida = i.Cantidad;
                i.Cantidadfaltante = 0;
                i.Cantidaddevuelta = 0;
            });



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
                System.Collections.Generic.List<Movto_traslado_recWFBindingModel> items = new System.Collections.Generic.List<Movto_traslado_recWFBindingModel>();


                
                Task.Run<List<Movto_traslado_recWFBindingModel>>(async () =>
                                                      await DoGetItems()
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
                        BProcessSuccess = bSuccess;
                        if (bSuccess)
                        {
                            items = t.Result;
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
                //        //Items = new ObservableCollection<Movto_traslado_recWFBindingModel>(items);
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

        public virtual bool CanEditItem
        {
            get { return SelectedItem != null; }
        }



        public void Docto_update_datos_ajustables()
        {


            bool bSuccess = true;
            IsBusy = true;
            var comentario = "";



            Task.Run<BaseResultBindingModel?>(async () =>
                                                  await itemsProvider.Docto_update_datos_ajustables(
                                                                           GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
                                                                           GlobalVariable.CurrentSession!.CurrentConfiguracion!.Sucursalid!.Value,
                                                                           Recibir_traslado_param?.DoctoARecibirId ?? 0,
                                                                           GlobalVariable.CurrentSession!.CurrentUsuario!.Id,
                                                                           Recibir_traslado_param?.AlmacenId,
                                                                           Recibir_traslado_param?.Referencias

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
                    if (!BProcessSuccess)
                    {
                        showPopUpMessage("Ocurrio un error ", comentario, "Error");
                    }
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());


            //BackgroundWorker worker = new BackgroundWorker();
            //BaseResultBindingModel result;
            //worker.DoWork += (o, ea) =>
            //{
            //    try
            //    {

            //        result = itemsProvider.Docto_update_datos_ajustables(
            //           GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
            //           GlobalVariable.CurrentSession!.CurrentConfiguracion!.Sucursalid!.Value,
            //           Recibir_traslado_param?.DoctoARecibirId ?? 0,
            //           GlobalVariable.CurrentSession!.CurrentUsuario!.Id,
            //           Recibir_traslado_param?.AlmacenId,
            //           Recibir_traslado_param?.Referencias

            //           );


            //        bSuccess = result != null && result.Result >= 0;
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
            //        showPopUpMessage("Ocurrio un error ", comentario, "Error");
            //    }
            //};
            //worker.RunWorkerAsync();
        }

        public void Procesar()
        {

            try
            {


                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";

                BaseResultBindingModel? tempResult = null;

                if (Recibir_traslado_param!.AlmacenId == null)
                    throw new Exception("Necesita definir el almacen");

                var lstMovtosARecibir = this.Items.Select(i => i.CreateRecepcion_movto_traslado_impo()).ToList(); //new List<Services.Recepcion_movto_traslado_impo>();


                Task.Run(async () =>
                                    {

                                        try
                                        {

                                            long? doctoDevolucionId = null;

                                            tempResult = await itemsProvider.Recibir_traslado(Recibir_traslado_param!,
                                                                                            lstMovtosARecibir);


                                            doctoDevolucionId = tempResult?.Result;
                                            bSuccess = (tempResult?.Result ?? 0) >= 0;



                                            if (bSuccess && doctoDevolucionId != null)
                                            {
                                                await impoExpoProvider.ExportTraslado(
                                                                         GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
                                                                         GlobalVariable.CurrentSession!.CurrentConfiguracion!.Sucursalid!.Value,
                                                                         GlobalSession!.CurrentSucursal!.Clave,
                                                                         GlobalSession.CurrentEmpresa!.Clave,
                                                                         doctoDevolucionId!.Value,
                                                                         null);
                                            }

                                            comentario = tempResult != null ? tempResult.Usermessage : "Error ...";


                                        }
                                        catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
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

                //worker.DoWork += async (o, ea) =>
                //{
                //    try
                //    {

                //        long? doctoDevolucionId = null;

                //        Task.Run(async () =>
                //        {
                //            tempResult = await itemsProvider.Recibir_traslado(Recibir_traslado_param!,
                //                                                        lstMovtosARecibir) ;
                //        }).Wait();


                //        doctoDevolucionId = tempResult?.Result;
                //        bSuccess = (tempResult?.Result ?? 0) >= 0;



                //        if (bSuccess && doctoDevolucionId != null )
                //        {
                //            await impoExpoProvider.ExportTraslado(
                //                                     GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid!.Value,
                //                                     GlobalVariable.CurrentSession!.CurrentConfiguracion!.Sucursalid!.Value,
                //                                     GlobalSession!.CurrentSucursal!.Clave, 
                //                                     GlobalSession.CurrentEmpresa!.Clave,
                //                                     doctoDevolucionId!.Value,
                //                                     null);
                //        }

                //        comentario = tempResult != null ? tempResult.Usermessage : "Error ...";


                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusy = false;

                //    BProcessSuccess = bSuccess;
                //    if (BProcessSuccess)
                //    {
                //        //PostSuccessFullAcceptActions(tempResult);
                //        //RecordResult = tempResult;
                //        //NotifyResultChanged();
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





        //main entities property changing
        protected void Recibir_traslado_paramPropertyChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {
            if (clearingOrLoadingDoctoInfo)
                return;

            switch (e.PropertyName)
            {
                case "Almacenid":
                    Docto_update_datos_ajustables();
                    break;


                case "Referencias":
                    Docto_update_datos_ajustables();
                    break;
                default:
                    break;
            }
        }


        //grid movto events

        void MovtoItem_PendingChange(object sender, AcceptPendingChangeEventArgs e)
        {
            Movto_traslado_recWFBindingModel movtoItem = (Movto_traslado_recWFBindingModel)sender;
            if (e.PropertyName == "Cantidadsurtida")
            {

                if (movtoItem.Cantidad != (decimal?)e.NewValue && 
                        (movtoItem.Motivodevolucionid == null || movtoItem.Motivodevolucionid == 0))
                {
                    Motivo_devolucionDefinicionWFViewModel vm = IoC.Get<Motivo_devolucionDefinicionWFViewModel>();
                    winManager.ShowDialogAsync(vm, null, CreateWinSettings("Diferencia inventario", 0.50));

                    if (!vm.Cancelled)
                    {
                        movtoItem.Motivodevolucionid = vm.Motivo_devolucionDefinicionItem!.Motivo_devolucionid;
                        if (vm.Motivo_devolucionDefinicionItem!.Motivo_devolucionid != 3)
                        {
                            movtoItem.Motivodevolucionclave = vm.Motivo_devolucionDefinicionItem!.Motivo_devolucionClave;
                            movtoItem.Motivodevolucionnombre = vm.Motivo_devolucionDefinicionItem!.Motivo_devolucionNombre;
                        }
                        else
                        {
                            movtoItem.Motivodevolucionnombre = vm.Motivo_devolucionDefinicionItem!.Otromotivodevolucion;
                            movtoItem.Otromotivodevolucion = vm.Motivo_devolucionDefinicionItem!.Otromotivodevolucion;
                        }
                    }
                    else
                    {
                        e.CancelPendingChange = true;
                    }
                }
                else
                {
                    movtoItem.Motivodevolucionid = null;
                    movtoItem.Motivodevolucionclave = null;
                    movtoItem.Motivodevolucionnombre = null;
                };

                if (!e.CancelPendingChange)
                {
                    movtoItem.Cantidadfaltante = movtoItem.Cantidad - movtoItem.Cantidadsurtida;
                    movtoItem.Cantidaddevuelta = movtoItem.Cantidad - movtoItem.Cantidadsurtida;
                }

            }
        }


        void MovtoItems_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (Movto_traslado_recWFBindingModel item in e.NewItems)
                {
                    item.PendingChange += MovtoItem_PendingChange;
                }

            if (e.OldItems != null)
            {
                foreach (Movto_traslado_recWFBindingModel item in e.OldItems)
                {
                    item.PendingChange -= MovtoItem_PendingChange;
                }
            }
        }

    }


}


