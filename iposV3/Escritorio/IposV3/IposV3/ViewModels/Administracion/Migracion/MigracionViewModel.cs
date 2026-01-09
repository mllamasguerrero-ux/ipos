
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

    public class MigracionViewModel : BaseOperationalScreen
    {

        public bool BProcessSuccess { get; protected set; }


        private MigracionBindingModel? item;
        public MigracionBindingModel? Item
        {
            get => item;
            set
            {
                item = value; NotifyOfPropertyChange("Item");
                if (item != null)
                {
                    item.PendingChange += MigracionPendingChangeEventHandler;
                    item.PropertyChanged += MigracionPropertyChangedEventHandler;
                }
            }
        }



        //protected readonly FirebirdMigrationWebController _firebirdMigrationController ;



        public MigracionViewModel(
            //FirebirdMigrationWebController firebirdMigrationController,
            CorteWebController corteControllerProvider, 
            UsuarioWebController usuarioControllerProvider,
            SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService, usuarioControllerProvider, corteControllerProvider)
        {
            //this._firebirdMigrationController = firebirdMigrationController;


            Item = new MigracionBindingModel();


            BIsReadOnly = false;


        }


        protected override void fillCatalogConfiguration()
        {

            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                    };
            lstCatalogDef = new List<CatalogDef>();

        }



        protected void MigracionPropertyChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {


                default:
                    break;
            }
        }

        public void MigracionPendingChangeEventHandler(object sender, AcceptPendingChangeEventArgs e)
        {

            switch (e.PropertyName)
            {

                default:
                    CatalogField_PropertyChanging(sender, e);
                    break;
            }
        }




        public void Accept()
        {

            if (Item == null)
            {
                showPopUpMessage(new MessageToUserSimple("Error", "No hay registro", "Error"));
                return;
            }

            if ((Item.Catalogos == null || Item.Catalogos.Value == BoolCS.N) &&
                (Item.Transacciones == null || Item.Transacciones.Value == BoolCN.N) &&
                (Item.InformacionEmpresa == null || Item.InformacionEmpresa.Value == BoolCS.N)
               )
            {

                showPopUpMessage(new MessageToUserSimple("Error", "Defina al menos una opcion a migrar", "Error"));
                return;
            }


            if ((Item.Cadenaconexion == null || string.IsNullOrEmpty(Item.Cadenaconexion))
               )
            {

                showPopUpMessage(new MessageToUserSimple("Error", "Defina la cadena de conexion a la bd", "Error"));
                return;
            }


            try
            {

                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";

                
                Task.Run(() =>
                                        {

                                            try
                                            {
                                                migrate(Item);
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
                        ErrorEditActions(Item, comentario);
                    }
                    else if (t.IsCompleted)
                    {

                        BProcessSuccess = bSuccess;
                        if (BProcessSuccess)
                        {
                            SuccessEditActions(Item);

                        }
                        else
                        {
                            ErrorEditActions(Item, comentario);
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());


                //BackgroundWorker worker = new BackgroundWorker();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {
                //        migrate(Item);
                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted +=  (o, ea) =>
                //{
                //    IsBusy = false;

                //    BProcessSuccess = bSuccess;
                //    if (BProcessSuccess)
                //    {
                //        SuccessEditActions(Item);

                //    }
                //    else
                //    {
                //        ErrorEditActions(Item, comentario);
                //    }
                //};
                //worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }

        }


        public void migrate(MigracionBindingModel record)
        {

            try
            {
                string fbCadenaConexion_char850 = $"{record.Cadenaconexion};Pooling=true;MinPoolSize=5;MaxPoolSize=50;Charset=dos850;";
                string fbCadenaConexion_chardefault = $"{record.Cadenaconexion};Pooling=true;MinPoolSize=5;MaxPoolSize=50;Charset=win1252;";
                //_firebirdMigrationController.ImportarDatosDeFirebird(record.Catalogos == BoolCS.S, record.Transacciones == BoolCN.S, record.InformacionEmpresa == BoolCS.S , 1, 1, fbCadenaConexion_char850, fbCadenaConexion_chardefault);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        public async Task Cancel()
        {

            BProcessSuccess = false;

            await TryCloseAsync(false);
        }

        public void SuccessEditActions(MigracionBindingModel record)
        {
            var eventParam = new HomeListVMEventParameters();
            eventParam.fillFields(true, true,
                                                                BProcessSuccess ?
                                                                                new MessageToUserSimple("Exito", "Se inserto el registro", "Success") :
                                                                                new MessageToUserSimple("Error", "Occurrio un error ", "Error"));

            var vm = IoC.Get<HomeViewModel>();
            aggregator.PublishOnUIThreadAsync(eventParam);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, false, false));
        }


        public virtual void ErrorEditActions(MigracionBindingModel record, string comentario)
        {
            showPopUpMessage("Ocurrio un error ", comentario, "Error");
        }





    }


}

