
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
using System.Threading;
using System.Windows.Threading;

namespace IposV3.ViewModels
{

    public class CambiocontrasenaWFViewModel : BaseGenericViewModel
    {

        public CambiocontrasenaWFBindingModel? CambiocontrasenaItem { get; set; }

        public bool PreguntarContrasenaAnterior { get; set; } = true;


        private UsuarioWebController provider;
        public bool BProcessSuccess { get; protected set; }
        public bool Cancelled { get; set; }



        public CambiocontrasenaWFViewModel(UsuarioWebController provider , SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService)
        {
            this.provider = provider;
            this.IsBusy = false;
            this.Cancelled = true;
            CambiocontrasenaItem = new CambiocontrasenaWFBindingModel();
            CambiocontrasenaItem!.PendingChange += CatalogField_PropertyChanging;


        }


        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                    };
            lstCatalogDef = new List<CatalogDef>() { };

        }



        public virtual void Accept()
        {


            if (PreguntarContrasenaAnterior && CambiocontrasenaItem!.Contrasena != CambiocontrasenaItem.ContrasenaAnterior)
            {

                showPopUpMessage("Ocurrio un error ", "La contraseña anterior y nueva no coinciden", "Error");
                return;
            }

            if (CambiocontrasenaItem!.ContrasenaNueva != CambiocontrasenaItem.ContrasenaConfirmacion)
            {

                showPopUpMessage("Ocurrio un error ", "La contraseña nueva y su confirmacion no coinciden", "Error");
                return;
            }

            if (string.IsNullOrEmpty(CambiocontrasenaItem!.ContrasenaNueva))
            {

                showPopUpMessage("Ocurrio un error ", "La contraseña no puede estar vacia", "Error");
                return;
            }

            CambiocontrasenaItem.ModificadoPorId = GlobalVariable.CurrentSession?.CurrentUsuario?.Id;

            try
            {

                //bool bSuccess = true;
                IsBusy = true;
                var comentario = "";

                
                Task.Run<bool?>(async () =>
                                                      await provider.UpdateContrasena(CambiocontrasenaItem)
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
                        if (BProcessSuccess)
                        {
                            this.Cancelled = false;
                            ShowMessageOnMainThread(new MessageToUserSimple("Exito", "Se cambio la contraseña", "Success"));
                            Task.Run(() =>
                            {
                                Thread.Sleep(2000); // delay

                                this.TryCloseAsync();
                            });


                        }
                        else
                        {
                            showPopUpMessage("Ocurrio un error ", comentario, "Error");
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());


                //BackgroundWorker worker = new BackgroundWorker();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {
                //        provider.UpdateContrasena(CambiocontrasenaItem);
                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusy = false;


                //    BProcessSuccess = bSuccess;
                //    if (BProcessSuccess)
                //    {
                //        this.Cancelled = false;
                //        ShowMessageOnMainThread(new MessageToUserSimple("Exito", "Se cambio la contraseña", "Success"));
                //        //this.TryCloseAsync();
                //        Task.Run(() =>
                //        {
                //            Thread.Sleep(2000); // delay

                //            this.TryCloseAsync();
                //        });


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
            finally
            {

            }

        }


        public void Cancel()
        {
            this.Cancelled = true;
            this.TryCloseAsync();
        }

        //public override void ShowMessageOnMainThread(MessageToUserSimple messageToUser)
        //{
        //    base.ShowMessageOnMainThread(messageToUser);
        //    //if (messageToUser.Tipo == "Success")
        //    //{
        //    //    Thread.Sleep(3000);
        //    //    this.TryCloseAsync();
        //    //}
        //}



    }


}


