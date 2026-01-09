
using BindingModels;
using IposV3.Model;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
//using DataAccess;
using Models.CatalogSelector; 
using IposV3.ViewModels.BaseScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using IposV3.Controllers.Controller;
using ViewModels.BaseScreen;
using System.Collections.ObjectModel;
using System.Windows;
using System.Threading;

namespace IposV3.ViewModels
{

    public class MovtogastosadicEditViewModel : BaseGenericViewModel
    {

        private MovtogastosadicBindingModel? record;
        public MovtogastosadicBindingModel? Record
        {
            get => record;
            set
            {
                record = value; NotifyOfPropertyChange("Record");

                if (record != null)
                {
                    record.PendingChange += CatalogField_PropertyChanging;
                }
            }
        }


        public ObservableCollection<MovtogastosadicBindingModel> Items { get; set; }


        public bool BProcessSuccess { get; protected set; }



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


        private DoctoBindingModel? currentDocto;
        public DoctoBindingModel? CurrentDocto
        {
            get => currentDocto;
            set
            {
                currentDocto = value; NotifyOfPropertyChange("CurrentDocto");

                if (currentDocto != null)
                {
                    currentDocto.PendingChange += CatalogField_PropertyChanging;
                }
            }
        }

        MovtogastosadicWebController provider;
        public MovtogastosadicEditViewModel(MovtogastosadicWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService)
        {
            Record = new MovtogastosadicBindingModel();
            this.provider = provider;

            Items = new ObservableCollection<MovtogastosadicBindingModel>();

            KendoParams = new KendoParams("", @"""Clave""|""Nombre""");


        }



        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Record","Gastoadicional","Movtogastosadicid", "GastoadicionalClave", "GastoadicionalNombre","IposV3.ViewModels.GastoadicionalListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>() { };

        }


        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            ReloadItems();
            return Task.FromResult(true);
        }


        protected async Task<MovtogastosadicWebBindingModel?> doInsert()
        {
            if (Record == null)
                return null;

            return await provider.InsertMultiFuncional(Record);
        }


        protected async Task<MovtogastosadicWebBindingModel?> doDelete(MovtogastosadicBindingModel selected)
        {
            if (selected == null)
                return null;

            return await provider.DeleteMultiFuncional(selected);
        }



        public void Deleteitem(MovtogastosadicBindingModel selected)
        {

            try
            {

                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";
                MovtogastosadicWebBindingModel? resultDelete = null;

                Task.Run(async () =>
                                        resultDelete = await doDelete(selected)
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
                        ErrorAddActions(selected, comentario);
                    }
                    else if (t.IsCompleted)
                    {
                        BProcessSuccess = resultDelete?.BaseResultBindingModel.Result >= 0;
                        if (BProcessSuccess)
                        {
                            SuccessAddActions(Record);
                            Record = new MovtogastosadicBindingModel();

                            this.Items.Clear();

                            foreach (var item in resultDelete!.Items)
                            {
                                Items.Add(item);
                            }

                        }
                        else
                        {
                            ErrorAddActions(Record, (resultDelete?.BaseResultBindingModel?.Usermessage ?? comentario));
                        }
                    }

                }, TaskScheduler.FromCurrentSynchronizationContext());


                //BackgroundWorker worker = new BackgroundWorker();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {
                //        doDelete(selected);
                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusy = false;

                //    BProcessSuccess = bSuccess;
                //    if (BProcessSuccess)
                //    {
                //        SuccessAddActions(selected);
                //    }
                //    else
                //    {
                //        ErrorAddActions(selected, comentario);
                //    }

                //};
                //worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
        }

        public void AcceptItem()
        {
            if (Record == null || CurrentDocto == null)
                return;

            if(Record.Monto == null || Record.Monto == 0)
            {
                MessageBox.Show("Necesita ingresar un monto mayor a cero");
                return;
            }


            if (Record.Movtogastosadicid == null || Record.Movtogastosadicid == 0)
            {
                MessageBox.Show("Necesita definir un gasto");
                return;
            }


            Record.Creado = DateTime.Now;
            Record.Modificado = DateTime.Now;
            Record.EmpresaId = CurrentDocto.EmpresaId;
            Record.SucursalId = CurrentDocto.SucursalId;
            Record.Doctoid = CurrentDocto.Id;
            Record.Partida = Items.Max(x => x.Partida) + 1 ?? 1;


            try
            {

                IsBusy = true;
                var comentario = "";
                MovtogastosadicWebBindingModel? resultInsert = null;



                Task.Run(async () =>
                                      resultInsert =  await doInsert()
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
                        ErrorAddActions(Record, comentario);
                    }
                    else if (t.IsCompleted)
                    {
                        BProcessSuccess = resultInsert?.BaseResultBindingModel.Result >= 0;
                        if (BProcessSuccess)
                        {
                            SuccessAddActions(Record);
                            Record = new MovtogastosadicBindingModel();

                            this.Items.Clear();

                            foreach (var item in resultInsert!.Items)
                            {
                                Items.Add(item);
                            }

                        }
                        else
                        {
                            ErrorAddActions(Record, (resultInsert?.BaseResultBindingModel?.Usermessage ?? comentario));
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());

                //BackgroundWorker worker = new BackgroundWorker();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {
                //        doInsert();
                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusy = false;

                //    BProcessSuccess = bSuccess;
                //    if (BProcessSuccess)
                //    {
                //        SuccessAddActions(Record);
                //        Record = new MovtogastosadicBindingModel();
                //    }
                //    else
                //    {
                //        ErrorAddActions(Record, comentario);
                //    }

                //};
                //worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
        }



        public virtual async Task<System.Collections.Generic.List<MovtogastosadicBindingModel>> DoGetItems()
        {

            if (CurrentDocto == null)
                return new List<MovtogastosadicBindingModel>();



            System.Collections.Generic.List<MovtogastosadicBindingModel> items = new System.Collections.Generic.List<MovtogastosadicBindingModel>();
            items = await provider.SelectListByDocto(new MovtogastosadicParam( CurrentDocto.EmpresaId, CurrentDocto.SucursalId, CurrentDocto.Id ),
                                            KendoParams!) ?? new List<MovtogastosadicBindingModel>();
            return items;
        }


        public void ReloadItems()
        {
            Items.Clear();
            try
            {
                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";
                System.Collections.Generic.List<MovtogastosadicBindingModel> items = new System.Collections.Generic.List<MovtogastosadicBindingModel>();


                
                Task.Run<List<MovtogastosadicBindingModel>>(async () =>
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

        public void SuccessAddActions(MovtogastosadicBindingModel? record)
        {
            showPopUpMessage("Exito ", " Se realizo la operacion", "Success");

            //ReloadItems();
        }

        public  void ErrorAddActions(MovtogastosadicBindingModel? record, string comentario)
        {
            showPopUpMessage("Ocurrio un error ", comentario, "Error");
        }


        public void Cancel()
        {
            this.TryCloseAsync();
        }

    }


}


