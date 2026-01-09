
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
using System.Threading;
using Syncfusion.Data;

namespace IposV3.ViewModels
{

    public class CorteItemViewModel : BaseWebRecordViewModel<CorteBindingModel, CorteWebController, CorteItemVMInitialParameters, CorteListVMEventParameters>
    {

        public bool IsPopupMode { get; set; } = false;

        public CorteBindingModel? Corte { get { return Record; } set { Record = value; } }
        public CorteItemViewModel(string mode, CorteWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

        }




        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          //new CatalogRelatedFields("Corte","Caja","Cajaid", "CajaClave", "CajaNombre","IposV3.ViewModels.CajaListViewModel","SelectedItem","Clave"),
                                          //new CatalogRelatedFields("Corte","Usuario","Cajeroid", "CajeroClave", "CajeroNombre","IposV3.ViewModels.UsuarioListViewModel","SelectedItem","Clave"),
                                          //new CatalogRelatedFields("Corte","Tipocorte","Tipocorteid", "TipocorteClave", "TipocorteNombre","IposV3.ViewModels.TipocorteListViewModel","SelectedItem","Clave"),
                                          //new CatalogRelatedFields("Corte","Corterecoleccion","Corterecoleccionid", "CorterecoleccionClave", "CorterecoleccionNombre","IposV3.ViewModels.CorterecoleccionListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>();
            

        }



        public void ExitWithActions(string title, string comentario, bool success)
        {

            if (IsPopupMode)
            {
                TryCloseAsync();
                return;
            }


            var eventParam = new HomeListVMEventParameters();
            eventParam.fillFields(true, true,
                                                                success ?
                                                                                new MessageToUserSimple(title, comentario, "Success") :
                                                                                new MessageToUserSimple(title, comentario, "Error"));

            var vm = IoC.Get<HomeViewModel>();
            aggregator.PublishOnUIThreadAsync(eventParam);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, false, false));
        }

    }


    public class CorteShowViewModel : CorteItemViewModel
    {
        public CorteShowViewModel(CorteWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class CorteEditViewModel : CorteItemViewModel
    {
        public CorteEditViewModel(CorteWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class CorteAddViewModel : CorteItemViewModel
    {
        public CorteAddViewModel(CorteWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }





    public class CorteAbrirViewModel : CorteItemViewModel
    {

        public bool SeAbrioCorte { get; set; } = false;

        public CorteAbrirViewModel(CorteWebController provider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Abrir", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
                preFillRecordToAdd();
                Record!.Cajeroid = GlobalVariable.CurrentSession?.Usuarioid;
                Record!.Fechacorte = DateTime.UtcNow;
                Record!.Inicia = DateTime.Now;
                Record!.Cajaid = GlobalVariable.CurrentSession?.CurrentCaja?.Id;
                Record!.PendingChange += CatalogField_PropertyChanging;
          
        }


        protected override void OnViewLoaded(object view)
        {

            
            base.OnViewLoaded(view);



            _ = AfterViewLoaded();


        }


        public async Task AfterViewLoaded()
        {

            var usuarioCorteActual = await provider.CorteActivoUsuario(Record!.EmpresaId, Record!.SucursalId, Record!.Cajeroid);
            if (usuarioCorteActual != null)
            {
                if (usuarioCorteActual.Activo == BoolCS.S)
                {

                    if (usuarioCorteActual.Fechacorte != null && usuarioCorteActual.Fechacorte.Value.DateTime.Date == DateTimeOffset.Now.Date)
                        ExitWithActions("Informacion", "El usuario ya tiene el corte abierto", false);
                    else
                        ExitWithActions("Informacion", "El usuario tiene un corte abierto de otra fecha , por favor cierrelo antes", false);

                }
                else
                {

                    //checar si se esta reabriendo el corte
                    var corteDeHoyUsuario = await provider.CorteUsuarioFecha(Record!.EmpresaId, Record!.SucursalId, Record!.Cajeroid, DateTimeOffset.Now);
                    if (corteDeHoyUsuario != null)
                    {
                        Record = corteDeHoyUsuario;
                        Record.PendingChange += CatalogField_PropertyChanging;
                        Record.Validate();
                    }
                }
            }
        }

        public override void Accept()
        {

            if (Record == null)
                return;

            Record.ModificadoPorId = GlobalVariable.CurrentSession?.Usuarioid;

            try
            {

                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";

                
                Task.Run(async () =>
                                                      await doAbrirCorte()
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
                        ErrorEditActions(Record, comentario);
                    }
                    else if (t.IsCompleted)
                    {

                        BProcessSuccess = bSuccess;
                        if (BProcessSuccess)
                        {
                            SeAbrioCorte = true;
                            SuccessEditActions(Record);
                        }
                        else
                        {
                            ErrorEditActions(Record, comentario);
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());

                //BackgroundWorker worker = new BackgroundWorker();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {
                //        doAbrirCorte();
                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusy = false;

                //    BProcessSuccess = bSuccess;
                //    if (BProcessSuccess)
                //    {
                //        SeAbrioCorte = true;
                //        SuccessEditActions(Record);
                //    }
                //    else
                //    {
                //        ErrorEditActions(Record, comentario);
                //    }
                //};
                //worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }

        }


        private async Task doAbrirCorte()
        {
            if (Record == null)
                return;

            await provider.AbrirCorte(Record);
        }


        public override void SuccessEditActions(CorteBindingModel record)
        {
            if (IsPopupMode)
            {
                TryCloseAsync();
                return;
            }

            var eventParam = new HomeListVMEventParameters();
            eventParam.fillFields(true, true,
                                                                BProcessSuccess ?
                                                                                new MessageToUserSimple("Exito", "Se inserto el registro", "Success") :
                                                                                new MessageToUserSimple("Error", "Occurrio un error ", "Error"));

            var vm = IoC.Get<HomeViewModel>();
            aggregator.PublishOnUIThreadAsync(eventParam);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, false, false));
        }


    }

    public class CorteCerrarViewModel : CorteItemViewModel
    {
        public bool SeCerroCorte { get; set; } = false;

        private GlobalWebController globalControllerProvider;
        public GlobalSession? GlobalSession { get; set; }
        public string? TestProductoClave { get; set; }

        public bool EsCajeroActual { get; set; } = false;
        public CorteCerrarViewModel(CorteWebController provider,  GlobalWebController globalControllerProvider, SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Cerrar", provider, selectorProvider, aggregator, winManager, messageBoxService)
        {
            aggregator.SubscribeOnPublishedThread(this);

            this.globalControllerProvider = globalControllerProvider;

            var localGlobalSession = GlobalVariable.CurrentSession;
            globalControllerProvider.llenarProductAutoCompleteList(ref localGlobalSession);
            GlobalSession = localGlobalSession;
        }


        public override async Task HandleAsync(CorteItemVMInitialParameters initialParameters, CancellationToken cancellationToken)
        {
            //if(initialParameters.Cajeroid == null)
            //    return Task.CompletedTask;

            //ObtenCorteDeCajero(initialParameters.Cajeroid!.Value);

            //return Task.CompletedTask;

            if (EsCajeroActual)
                return;

            if (initialParameters.Cajeroid == null)
                return;


            Record = await provider.CorteActivoUsuario(GlobalVariable.CurrentSession?.Empresaid, GlobalVariable.CurrentSession?.Sucursalid,initialParameters.Cajeroid!.Value);


            if (Record != null)
            {
                Record.PendingChange += CatalogField_PropertyChanging;
                Record.Validate();
                NotifyOfPropertyChange("Corte");
            }
        }


        public async Task ObtenCorteDeCajero(long cajeroId)
        {

            Record = await provider.CorteActivoUsuario(GlobalVariable.CurrentSession?.Empresaid, GlobalVariable.CurrentSession?.Sucursalid, cajeroId);


            if (Record != null)
            {
                Record.PendingChange += CatalogField_PropertyChanging;
                Record.Validate();
                NotifyOfPropertyChange("Corte");
            }
        }


        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            _ = this.AfterViewLoaded();


        }

        public async Task AfterViewLoaded()
        {
            if (EsCajeroActual && Record == null &&
                GlobalVariable.CurrentSession?.CurrentUsuario?.Id != null)
            {

                    await ObtenCorteDeCajero(GlobalVariable.CurrentSession!.CurrentUsuario!.Id!.Value);

                    if (Record == null || Record.Activo != BoolCS.S)
                    {
                        ExitWithActions("Informacion", "El usuario no tiene el corte abierto", false);
                    }

            }

        }


        public override void Accept()
        {

            if (Record == null)
                return;

            Record.ModificadoPorId = GlobalVariable.CurrentSession?.Usuarioid;

            try
            {

                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";

                
                Task.Run(async () =>
                                                      await doCerrarCorte()
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
                        ErrorEditActions(Record, comentario);
                    }
                    else if (t.IsCompleted)
                    {
                        BProcessSuccess = bSuccess;
                        if (BProcessSuccess)
                        {
                            SeCerroCorte = true;
                            SuccessEditActions(Record);
                        }
                        else
                        {
                            ErrorEditActions(Record, comentario);
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());


                //BackgroundWorker worker = new BackgroundWorker();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {
                //        doCerrarCorte();
                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusy = false;

                //    BProcessSuccess = bSuccess;
                //    if (BProcessSuccess)
                //    {
                //        SeCerroCorte = true;
                //        SuccessEditActions(Record);
                //    }
                //    else
                //    {
                //        ErrorEditActions(Record, comentario);
                //    }
                //};
                //worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }

        }


        private async Task doCerrarCorte()
        {
            if (Record == null)
                return;

            await provider.CerrarCorte(Record);
        }


        public override void SuccessEditActions(CorteBindingModel record)
        {
            if (IsPopupMode)
            {
                TryCloseAsync();
                return;
            }

            var eventParam = new HomeListVMEventParameters();
            eventParam.fillFields(true, true,
                                                                BProcessSuccess ?
                                                                                new MessageToUserSimple("Exito", "Se inserto el registro", "Success") :
                                                                                new MessageToUserSimple("Error", "Occurrio un error ", "Error"));

            var vm = IoC.Get<HomeViewModel>();
            aggregator.PublishOnUIThreadAsync(eventParam);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, false, false));
        }


    }

}


