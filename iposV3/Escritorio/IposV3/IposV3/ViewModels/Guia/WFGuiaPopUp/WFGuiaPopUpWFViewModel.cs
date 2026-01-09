
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
using Controllers.BindingModel;
using System.Threading;

namespace IposV3.ViewModels
{

    public class WFGuiaPopUpWFViewModel : BaseOperationalScreen, IHandle<WFGuiaPopUpItemVMInitialParameters>
    {

        public bool BProcessSuccess { get; protected set; }


        private GuiaBindingModel? guiaItem;
        public GuiaBindingModel? GuiaItem
        {
            get => guiaItem;
            set
            {
                guiaItem = value; NotifyOfPropertyChange("CurrentDocto");
                if (guiaItem != null)
                {
                    guiaItem.PendingChange += GuiaPendingChangeEventHandler;
                    guiaItem.PropertyChanged += GuiaPropertyChangedEventHandler;
                }
            }
        }


        private string? mode;
        public string? Mode
        {
            get => mode;
            set
            {
                mode = value;
                NotifyOfPropertyChange("Mode");
                this.BIsReadOnly = mode != "Add";
            }
        }


        protected readonly GuiaWebController guiaProvider;



        public WFGuiaPopUpWFViewModel(
            GuiaWebController guiaProvider,
            CorteWebController corteControllerProvider, UsuarioWebController usuarioControllerProvider,
            SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService, usuarioControllerProvider, corteControllerProvider)
        {
            this.guiaProvider = guiaProvider;


            GuiaItem = new GuiaBindingModel();
            GuiaItem.EmpresaId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Empresaid;
            GuiaItem.SucursalId = GlobalVariable.CurrentSession?.CurrentConfiguracion?.Sucursalid;
            GuiaItem.Fecha = DateTimeOffset.UtcNow;
            GuiaItem.Fechaestimadarec = DateTimeOffset.UtcNow;
            GuiaItem.Horaestimadrec = DateTimeOffset.UtcNow;
            GuiaItem.Fechahora = DateTimeOffset.UtcNow;


            BIsReadOnly = false;

            this.Mode = "Add";

        }


        protected override void fillCatalogConfiguration()
        {

            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("GuiaItem","Usuario","Encargadoguiaid", "EncargadoguiaClave", "EncargadoguiaNombre","IposV3.ViewModels.UsuarioListViewModel","SelectedItem","UsuarioNombre"),
                                          new CatalogRelatedFields("GuiaItem","Vehiculo","Vehiculoid", "VehiculoClave", "VehiculoNombre","IposV3.ViewModels.VehiculoListViewModel","SelectedItem","Numpermisosct")
                                    };
            lstCatalogDef = new List<CatalogDef>();

        }



        protected void GuiaPropertyChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {


                default:
                    break;
            }
        }

        public void GuiaPendingChangeEventHandler(object sender, AcceptPendingChangeEventArgs e)
        {

            switch (e.PropertyName)
            {

                default:
                    CatalogField_PropertyChanging(sender, e);
                    break;
            }
        }


        public virtual Task HandleAsync(WFGuiaPopUpItemVMInitialParameters initialParameters, CancellationToken cancellationToken)
        {
            //this.Mode = "Show";
            //fillRecordToEdit(initialParameters);

            return Task.CompletedTask;
        }


        public async Task Accept()
        {
            if (GuiaItem == null)
            {
                showPopUpMessage(new MessageToUserSimple("Error", "No hay guia", "Error"));
                return;
            }

            if(GuiaItem.Encargadoguiaid == null || GuiaItem.Encargadoguiaid == 0)
            {

                showPopUpMessage(new MessageToUserSimple("Error", "Defina el encargado guia", "Error"));
                return;
            }

            if (GuiaItem.Vehiculoid == null || GuiaItem.Vehiculoid == 0)
            {

                showPopUpMessage(new MessageToUserSimple("Error", "Defina el vehiculo guia", "Error"));
                return;
            }

            if (GuiaItem.Fechahora == null || GuiaItem.Horaestimadrec == null)
            {

                showPopUpMessage(new MessageToUserSimple("Error", "Defina las horas de salida y recepcion", "Error"));
                return;
            }

            if (((GuiaItem.Fechahora - GuiaItem.Fechaestimadarec)?.TotalMinutes ?? 0) <= 0)
            {

                showPopUpMessage(new MessageToUserSimple("Advertencia", "La fecha/hora de salida es la misma que la fecha/hora de llegada, o la fecha de llegada es menor que la de salida.", "Warning"));
                return;
            }

            GuiaItem.Cajeroid  = GlobalVariable.CurrentSession!.Usuarioid;

            GuiaItem.Fecha = GuiaItem.Fechahora;
            GuiaItem.Fechaestimadarec = GuiaItem.Fechaestimadarec;

            BProcessSuccess = true;

            await TryCloseAsync(true);
        }

        public async Task Cancel()
        {

            BProcessSuccess = false;

            await TryCloseAsync(false);
        }


    }


}


