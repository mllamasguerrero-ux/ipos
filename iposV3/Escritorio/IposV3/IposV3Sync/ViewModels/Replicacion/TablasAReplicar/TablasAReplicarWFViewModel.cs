
using BindingModels;
using IposV3.Model;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
using IposV3Sync.Controllers.Controller;
using DataAccess;
using Models.CatalogSelector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Threading;
using Syncfusion.Data.Extensions;
using ViewModels.BaseScreen;

namespace IposV3Sync.ViewModels
{

    public class TablasAReplicarWFViewModel : BaseGenericViewModel
    {

        public ObservableCollection<GrupoTablasAReplicarWFBindingModel> GroupItems { get; private set; }

        public ObservableCollection<TablasAReplicarWFBindingModel> TablaItems { get; private set; }


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


        public ReplicacionController replicacionProvider;

        public TablasAReplicarWFViewModel(
            ReplicacionController replicacionProvider,
            SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService)
        {
            this.replicacionProvider = replicacionProvider;



            GroupItems = new ObservableCollection<GrupoTablasAReplicarWFBindingModel>();

            TablaItems = new ObservableCollection<TablasAReplicarWFBindingModel>();
        }


        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                    };
            lstCatalogDef = new List<CatalogDef>() { };

        }


        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            ReloadItems();
            return Task.FromResult(true);
        }


        public System.Collections.Generic.List<GrupoTablasAReplicarWFBindingModel> DoGroupGetItems()
        {
            return replicacionProvider.ListaGrupoTablasAReplicar(GlobalVariable.CurrentSession!.Empresaid!.Value, GlobalVariable.CurrentSession!.Sucursalid!.Value);
          
        }

        public System.Collections.Generic.List<TablasAReplicarWFBindingModel> DoTablaGetItems()
        {
            return replicacionProvider.ListaTablasAReplicar(GlobalVariable.CurrentSession!.Empresaid!.Value, GlobalVariable.CurrentSession!.Sucursalid!.Value);

        }
        public virtual void ReloadItems()
        {
            GroupItems.Clear();
            TablaItems.Clear();
            try
            {
                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";
                var groupItems = new System.Collections.Generic.List<GrupoTablasAReplicarWFBindingModel>();
                var tablaItems = new System.Collections.Generic.List<TablasAReplicarWFBindingModel>();
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (o, ea) =>
                {
                    try
                    {
                        groupItems = DoGroupGetItems();
                        tablaItems = DoTablaGetItems();
                    }
                    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                };
                worker.RunWorkerCompleted += (o, ea) =>
                {
                    IsBusy = false;
                    if (bSuccess)
                    {
                        foreach (var item in groupItems)
                        {
                            GroupItems.Add(item);
                        }
                        foreach (var item in tablaItems)
                        {
                            TablaItems.Add(item);
                        }
                        //Items = new ObservableCollection<Docto_solicitud_mercanciaWFBindingModel>(items);
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


        void seleccionarTablasPorGrupoSeleccionado()
        {

            if (!GroupItems.Any(g => g.FueModificado))
                return;

            var tablasASeleccionar = GroupItems.Where(g => g.Replicar && g.Tablas != null)
                                               .SelectMany(g =>  g.Tablas!.Select(t => t.Nombretabla!.Split('.').Last().ToLower()))
                                               .ToList();

            if(tablasASeleccionar != null)
                TablaItems.ForEach(y => y.Replicar = tablasASeleccionar.Contains(y.Nombretabla!.Split('.').Last().ToLower()));
        }

        public ConfigurationAction ContinueNavigationHandler(string currentStepTitle, string nextStepTitle, out bool cancel)
        {
            cancel = false;

            if (currentStepTitle == "Basico por grupo de tablas")
            {
                seleccionarTablasPorGrupoSeleccionado();
            }
            else if (currentStepTitle == "Detallado" && nextStepTitle != "Basico por grupo de tablas")
            {
                SaveReplConfiguration();
            }

            return new ConfigurationAction() { Action = "None", Parameters = null };
        }



        public void SaveReplConfiguration()
        {


            bool bSuccess = true;
            IsBusy = true;
            var comentario = "";
            BackgroundWorker worker = new BackgroundWorker();
            BaseResultBindingModel result;
            worker.DoWork +=  (o, ea) =>
            {
                try
                {

                    result = replicacionProvider.Aplicar_cambios_tablas_a_replicar(
                       GlobalVariable.CurrentSession!.Empresaid!.Value,
                       GlobalVariable.CurrentSession!.Sucursalid!.Value,
                       TablaItems.Where(t => t.Replicar).Select(t => t.Nombretabla!).ToList()

                       );


                    bSuccess = result != null && result.Result >= 0;
                    comentario = result != null ? result.Usermessage : "Error ...";


                }
                catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
            };
            worker.RunWorkerCompleted += (o, ea) =>
            {
                IsBusy = false;

                BProcessSuccess = bSuccess;
                if (!BProcessSuccess)
                {
                    ErrorEditActions(comentario);
                }
                else
                {
                    SuccessEditActions();
                    //OneShotTimer.Start(() => aggregator.PublishOnUIThreadAsync(new PuntoCompraUICommParams("SetFocus", new List<string>() { "CurrentMovto.Productoclave" })), TimeSpan.FromMilliseconds(100));
                }
            };
            worker.RunWorkerAsync();
        }


        public void ErrorEditActions(string comentario)
        {
            showPopUpMessage("Ocurrio un error ", comentario, "Error");
        }


        public void SuccessEditActions()
        {
            this.showPopUpMessage(new MessageToUserSimple("Exito", "Se actualizaron las tablas a replicar", "Success"));
        }
    }


}


