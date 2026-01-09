
using BindingModels;
using Caliburn.Micro;
using Controllers;
using Controllers.Controller;
//using IposV3.Controllers.Controller;
//using DataAccess;
using Models.CatalogSelector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IposV3.ViewModels.BaseScreen;
using ViewModels.BaseScreen;

namespace IposV3.ViewModels
{


    public class V_inventario_paso2ViewModel : BaseOperationalScreen
    {



        private DoctoBindingModel? currentDocto;
        public DoctoBindingModel? CurrentDocto
        {
            get => currentDocto;
            set
            {
                currentDocto = value; NotifyOfPropertyChange("CurrentDocto");
            }
        }

        private int _subtipoDocto;
        public int SubtipoDocto { get { return _subtipoDocto; } set { _subtipoDocto = value; NotifyOfPropertyChange("SubtipoDocto"); } }



        private V_inventario_genComplParamWFBindingModel? inventario_genComplParam;
        public V_inventario_genComplParamWFBindingModel? Inventario_genComplParam
        {
            get => inventario_genComplParam;
            set
            {
                inventario_genComplParam = value; NotifyOfPropertyChange("Inventario_genComplParam");
                //inventario_genComplParam.PendingChange += Inventario_genComplParamPendingChangeEventHandler;// CatalogField_PropertyChanging;
                //inventario_genComplParam.PropertyChanged += Inventario_genComplParamChangedEventHandler;


            }
        }


        public bool BProcessSuccess { get; protected set; }

        //Controller providers
        protected readonly DoctoWebController doctoProvider;
        protected readonly InventarioWebController inventarioProvider;

        public V_inventario_paso2ViewModel(InventarioWebController inventarioProvider, DoctoWebController doctoProvider,
            CorteWebController corteControllerProvider, UsuarioWebController usuarioControllerProvider,
            SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService, usuarioControllerProvider, corteControllerProvider)
        {

            this.doctoProvider = doctoProvider;
            this.inventarioProvider = inventarioProvider;

            Inventario_genComplParam = new V_inventario_genComplParamWFBindingModel();

            SubtipoDocto = 0;
            ClearDocto();
        }


        private void ClearDocto()
        {
            CurrentDocto = EmptyDocto();
        }

        private DoctoBindingModel EmptyDocto()
        {

            var buffer = new DoctoBindingModel();
            buffer.EmpresaId = GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid;
            buffer.SucursalId = GlobalVariable.CurrentSession.CurrentConfiguracion.Sucursalid;
            return buffer;
        }

        public void LoadInfoEdit(long? doctoId)
        {
            SubtipoDocto = 0;
            ClearDocto();
            CurrentDocto!.Id = doctoId;
            if (LoadDocto())
            {
                if(CurrentDocto != null && CurrentDocto.Subtipodoctoid != null )
                {
                    SubtipoDocto = (int)CurrentDocto.Subtipodoctoid.Value;
                    Inventario_genComplParam!.Subtipodoctoid = CurrentDocto.Subtipodoctoid;
                }
            }
        }


        private bool LoadDocto()
        {

            DoctoBindingModel? itemBuffer = null;

            Task.Run(async () =>
            {
                itemBuffer = await doctoProvider.GetById(CurrentDocto!);
            }).Wait();

            if (itemBuffer != null)
            {
                CurrentDocto = itemBuffer;
                return true;
            }

            return false;
        }


        
        public void Accept()
        {
            try
            {



                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";

                Inventario_genComplParam!.EmpresaId = GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid;
                Inventario_genComplParam.SucursalId = GlobalVariable.CurrentSession.CurrentConfiguracion.Sucursalid;
                Inventario_genComplParam.Usuarioid = GlobalVariable.CurrentSession.CurrentUsuario!.Id;
                Inventario_genComplParam.Doctoid = currentDocto!.Id;
                Inventario_genComplParam.Almacenid = currentDocto.Almacenid;

                Inventario_genComplParam.Subtipodoctoid =  SubtipoDocto;


                Task.Run<BaseResultBindingModel?>(async () =>
                                                      await this.inventarioProvider.Docto_inventario_genCompleto(Inventario_genComplParam)

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
                        if (BProcessSuccess)
                        {
                            showPopUpMessage("Exito ", " Se realizo la operacion", "Success");
                            SiguientePaso();
                        }
                        else
                        {
                            showPopUpMessage("Ocurrio un error ", comentario, "Error");
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());

                //BackgroundWorker worker = new BackgroundWorker();
                //BaseResultBindingModel? tempResult = new BaseResultBindingModel();
                //worker.DoWork += (o, ea) =>
                //{

                //    if (SubtipoDocto == 0)
                //    {
                //        tempResult = null;
                //    }
                //    else
                //    {
                //        try
                //        {
                //            tempResult = this.inventarioProvider.Docto_inventario_genCompleto(Inventario_genComplParam);
                //        }
                //        catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //    }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusy = false;

                //    BProcessSuccess = bSuccess;
                //    if (BProcessSuccess)
                //    {
                //        //if(tempResult != null)
                //        //{ 
                //        //    PostSuccessFullAcceptActions(tempResult);
                //        //    RecordResult = tempResult;
                //        //}
                //        //NotifyResultChanged();

                //        showPopUpMessage("Exito ", " Se realizo la operacion", "Success");
                //        SiguientePaso();
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



        public void SiguientePaso()
        {

            var vm = IoC.Get<V_inventario_finedicionViewModel>();
            vm.LoadInfoEdit(CurrentDocto!.Id);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(vm, true, false));
        }


        public override void Back()
        {

            var eventParam = new V_inventario_listVMEventParameters();
            eventParam.fillFields(true, true, null);

            aggregator.PublishOnUIThreadAsync(eventParam);
            aggregator.PublishOnUIThreadAsync(new NavigationParameter(null, false, true));
        }


    }
}
