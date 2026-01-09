
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
using System.Collections.ObjectModel;
using IposV3.Model;
using IposV3.BindingModel;

using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace IposV3.ViewModels
{


    public class V_inventario_finedicionViewModel : BaseOperationalScreen
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



        public ObservableCollection<V_inventario_movto_detalleWFBindingModel> MovtoItems { get; set; }

        public V_inventario_movto_detalleParamBindingModel? paramList;
        public V_inventario_movto_detalleParamBindingModel? ParamList
        {
            get { return paramList; }
            set
            {
                paramList = value;
                NotifyOfPropertyChange();
            }
        }



        private string? movtoItemsLoadedText;
        public string? MovtoItemsLoadedText
        {
            get { return movtoItemsLoadedText; }
            set
            {
                movtoItemsLoadedText = value;
                NotifyOfPropertyChange();
            }
        }


        //waiting fields
        private bool isBusyMovtoList;
        public bool IsBusyMovtoList
        {
            get
            {
                return isBusyMovtoList;
            }
            set
            {
                isBusyMovtoList = value;
                NotifyOfPropertyChange("IsBusyMovtoList");
            }
        }

        public bool HabilitarFinEdicion
        {
            get
            {
                return CurrentDocto != null && CurrentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_BORRADOR;
            }
        }


        public bool HabilitarCompletar
        {
            get
            {
                return CurrentDocto != null && CurrentDocto.Estatusdoctoid == DBValues._DOCTO_ESTATUS_INVENTARIOFIN;
            }
        }

        public bool HabilitarEliminar
        {
            get
            {
                return CurrentDocto != null && CurrentDocto.Estatusdoctoid != DBValues._DOCTO_ESTATUS_COMPLETO;
            }
        }


        public GlobalSession? GlobalSession { get => GlobalVariable.CurrentSession; }
        public bool BProcessSuccess { get; protected set; }

        //Controller providers
        protected readonly DoctoWebController doctoProvider;
        protected readonly InventarioWebController inventarioController;

        public V_inventario_finedicionViewModel(
            InventarioWebController inventarioWebController, DoctoWebController doctoprovider, 
            ProductoWebController productoProvider, GlobalWebController globalControllerProvider,
            CorteWebController corteControllerProvider, UsuarioWebController usuarioControllerProvider,
            SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService, usuarioControllerProvider, corteControllerProvider)
        {

            this.doctoProvider = doctoprovider;
            this.inventarioController= inventarioController;

            MovtoItems = new ObservableCollection<V_inventario_movto_detalleWFBindingModel>();
            ParamList = new V_inventario_movto_detalleParamBindingModel();
            ClearDocto();
            ClearMovtoItems();
        }


        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            ScreenExtensions.TryActivateAsync(this);
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
            ClearDocto();
            CurrentDocto!.Id = doctoId;

            if (LoadDocto())
            {
                PreLoadListParam();
                ReloadMovtoItems();
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




        private void PreLoadListParam()
        {


            ParamList!.EmpresaId = currentDocto!.EmpresaId;
            ParamList.SucursalId = currentDocto.SucursalId;
            ParamList.DoctoId = currentDocto.Id;
            ParamList.Solodiferencias = false;
            ParamList.Todoslosproductos = false;
            ParamList.KitDesglosado = currentDocto.Docto_kit_Kitdesglosado == Model.BoolCN.S;
            paramList.AlmacenId = currentDocto.Almacenid;
        }


        public void ClearMovtoItems()
        {
            MovtoItems.Clear();
            NotifyOfPropertyChange("MovtoItems");
        }


       

        public void ReloadMovtoItems()
        {
            MovtoItems.Clear();
            try
            {
                IsBusyMovtoList = true;
                DateTime startTime = DateTime.Now;
                List<V_inventario_movto_detalleWFBindingModel> items = new List<V_inventario_movto_detalleWFBindingModel>();


                Task.Run(async () =>
                {

                    if (CurrentDocto!.Tipodoctoid == DBValues._DOCTO_TIPO_INVENTARIO_FISICOXLOC)
                    {
                        items = await this.inventarioController.V_inventario_movto_detalles_x_loc_groupedList(ParamList!) ?? items;
                    }
                    else
                    {
                        items = await this.inventarioController.V_inventario_movto_detallesList(ParamList!) ?? items;
                    }
                }).Wait();


                TimeSpan ts = DateTime.Now - startTime;
                Console.WriteLine("Total seconds " + ts.TotalSeconds.ToString());
                foreach (var item in items)
                {
                    MovtoItems.Add(item);
                }
                //NotifyOfPropertyChange("MovtoItems");
                MovtoItemsLoadedText = "Loaded!";


            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
            finally
            {
                IsBusyMovtoList = false;
            }
        }



        //private V_inventario_movto_detalleWFBindingModel ConvertFromXLoc(Fnc_inv_movto_grp_locResultBindingModel locItem)
        //{

        //    V_inventario_movto_detalleWFBindingModel retorno = new V_inventario_movto_detalleWFBindingModel();
        //    retorno.V_productoclave = locItem.V_productoclave;
        //    retorno.V_productonombre = locItem.V_productonombre;
        //    retorno.V_productodescripcion = locItem.V_productodescripcion;
        //    retorno.V_productolote = locItem.V_productolote;
        //    retorno.V_texto1 = locItem.V_texto1;
        //    retorno.V_texto2 = locItem.V_texto2;
        //    retorno.V_texto3 = locItem.V_texto3;
        //    retorno.V_texto4 = locItem.V_texto4;
        //    retorno.V_texto5 = locItem.V_texto5;
        //    retorno.V_texto6 = locItem.V_texto6;
        //    retorno.V_almacenclave = locItem.V_almacenclave;
        //    retorno.V_almacennombre = locItem.V_almacennombre;
        //    retorno.V_numero = locItem.V_numero;
        //    retorno.V_productoid = locItem.V_productoid;
        //    retorno.V_fechavence = locItem.V_fechavence;
        //    retorno.V_cantidadteorica = locItem.V_cantidadteorica;
        //    retorno.V_cantidadfisica = locItem.V_cantidadfisica;
        //    retorno.V_cantidaddiferencia = locItem.V_cantidaddiferencia;
        //    retorno.V_movtoid = locItem.V_movtoid;
        //    retorno.V_numero1 = locItem.V_numero1;
        //    retorno.V_numero2 = locItem.V_numero2;
        //    retorno.V_numero3 = locItem.V_numero3;
        //    retorno.V_numero4 = locItem.V_numero4;
        //    retorno.V_fecha1 = locItem.V_fecha1;
        //    retorno.V_fecha2 = locItem.V_fecha2;
        //    retorno.V_almacenid = locItem.V_almacenid;
        //    retorno.V_pzacaja = locItem.V_pzacaja;
        //    retorno.V_cajas = locItem.V_cajas;
        //    retorno.V_piezas = locItem.V_piezas;

        //    return retorno;


        //}

        public void TSBBuscar()
        {
            ReloadMovtoItems();
        }


        public void FinEdicion()
        {
            try
            {


                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";


                V_inventario_finedicionParamWFBindingModel inventario_finedicionParam = new V_inventario_finedicionParamWFBindingModel();
                inventario_finedicionParam.EmpresaId = GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid;
                inventario_finedicionParam.SucursalId = GlobalVariable.CurrentSession.CurrentConfiguracion.Sucursalid;
                inventario_finedicionParam.Doctoid = currentDocto!.Id;

                Task.Run<BaseResultBindingModel?>(async () =>
                                                      await inventarioController.Docto_inventario_finEdicion(inventario_finedicionParam)
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
                            DoImprimirDiferencias("Diferencias de inventario", true, false);
                            showPopUpMessage("Exito ", " Se realizo la operacion", "Success");
                        }
                        else
                        {
                            showPopUpMessage("Ocurrio un error ", comentario, "Error");
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());



                //BackgroundWorker worker = new BackgroundWorker();
                //BaseResultBindingModel tempResult = new BaseResultBindingModel();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {

                //        tempResult = inventarioController.Docto_inventario_finEdicion(inventario_finedicionParam);
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
                //        DoImprimirDiferencias("Diferencias de inventario", true, false);
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




        public void Completar()
        {
            try
            {


                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";
                V_inventario_aplicarParamWFBindingModel completarParam = new V_inventario_aplicarParamWFBindingModel();

                completarParam.EmpresaId = GlobalVariable.CurrentSession!.CurrentConfiguracion!.Empresaid;
                completarParam.SucursalId = GlobalVariable.CurrentSession.CurrentConfiguracion.Sucursalid;
                completarParam.Doctoid = currentDocto!.Id;
                completarParam.Usuarioid = GlobalVariable.CurrentSession.CurrentUsuario!.Id;


                Task.Run<BaseResultBindingModel?>(async () =>
                                                      await inventarioController.Docto_inventario_aplicar(completarParam)

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
                            //NotifyResultChanged();

                            this.DoImprimirInventarioCompleto("Inventario ingresado", false, false);
                            this.DoImprimirInventarioActual();
                            showPopUpMessage("Exito ", " Se realizo la operacion", "Success");
                            this.Back();
                        }
                        else
                        {
                            showPopUpMessage("Ocurrio un error ", comentario, "Error");
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());


                //BackgroundWorker worker = new BackgroundWorker();
                //BaseResultBindingModel tempResult = new BaseResultBindingModel();
                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {

                //        tempResult = inventarioController.Docto_inventario_aplicar(completarParam);
                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusy = false;

                //    BProcessSuccess = bSuccess;
                //    if (BProcessSuccess)
                //    {
                //        //NotifyResultChanged();

                //        this.DoImprimirInventarioCompleto("Inventario ingresado", false, false);
                //        this.DoImprimirInventarioActual();
                //        showPopUpMessage("Exito ", " Se realizo la operacion", "Success");
                //        this.Back();
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

        public void ImprimirDiferencias()
        {
            DoImprimirDiferencias("Diferencias de inventario", true, false);
        }


        public void ImprimirInventarioHecho()
        {
            DoImprimirInventarioCompleto("Inventario ingresado", true, false);
        }

        public void DoImprimirDiferencias(string titulo, bool soloDiferencias, bool todosLosProductos)
        {


            if (GlobalVariable.CurrentDataBaseConnectionFnc == null)
                return;

            ReporteShowingViewModel vm = IoC.Get<ReporteShowingViewModel>();


            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("EMPRESAID", CurrentDocto!.EmpresaId!.Value);
            dict.Add("SUCURSALID", CurrentDocto!.SucursalId!.Value);
            dict.Add("DOCTOID", CurrentDocto!.Id!.Value);
            dict.Add("SOLODIFERENCIAS", soloDiferencias ? "S": "N");
            dict.Add("TODOSLOSPRODUCTOS", todosLosProductos ? "S" : "N");
            dict.Add("TITULO", titulo);
            dict.Add("KITDESGLOSADO", CurrentDocto!.Docto_kit_Kitdesglosado == BoolCN.S ? "S" : "N");


            dict.Add("US_ID", GlobalSession!.CurrentUsuario!.Id);
            dict.Add("US_NAME", GlobalSession!.CurrentUsuario!.UsuarioNombre);


            var nombreReporte = "InformeInventarioIngresado.frx";

            vm.FastReportInfo = new FastReportInfo()
            {

                RutaReporte = FastReportsConfig.getPathForFile(nombreReporte, FastReportsTipoFile.desistema),
                DictionaryReporte = dict,
                ConnectionString = GlobalVariable.CurrentDataBaseConnectionFnc(),
                Userid = GlobalVariable.CurrentSession!.Usuarioid!.Value,
                UserName = GlobalVariable.CurrentSession!.CurrentUsuario!.Nombre
            };
            winManager.ShowDialogAsync(vm, null, CreateWinSettings("Diferencias de inventario", 0.75));
        }




        public void DoImprimirInventarioCompleto(string titulo, bool soloDiferencias, bool todosLosProductos)
        {


            if (GlobalVariable.CurrentDataBaseConnectionFnc == null)
                return;

            ReporteShowingViewModel vm = IoC.Get<ReporteShowingViewModel>();


            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("EMPRESAID", CurrentDocto!.EmpresaId!.Value);
            dict.Add("SUCURSALID", CurrentDocto!.SucursalId!.Value);
            dict.Add("DOCTOID", CurrentDocto!.Id!.Value);
            dict.Add("SOLODIFERENCIAS", soloDiferencias ? "S" : "N");
            dict.Add("TODOSLOSPRODUCTOS", todosLosProductos ? "S" : "N");
            dict.Add("TITULO", titulo);


            dict.Add("US_ID", GlobalSession!.CurrentUsuario!.Id);
            dict.Add("US_NAME", GlobalSession!.CurrentUsuario!.UsuarioNombre);


            var nombreReporte = "InformeInventarioCompleto.frx";

            vm.FastReportInfo = new FastReportInfo()
            {

                RutaReporte = FastReportsConfig.getPathForFile(nombreReporte, FastReportsTipoFile.desistema),
                DictionaryReporte = dict,
                ConnectionString = GlobalVariable.CurrentDataBaseConnectionFnc(),
                Userid = GlobalVariable.CurrentSession!.Usuarioid!.Value,
                UserName = GlobalVariable.CurrentSession!.CurrentUsuario!.Nombre
            };
            winManager.ShowDialogAsync(vm, null, CreateWinSettings("Inventario ingresado", 0.75));
        }


        public void DoImprimirInventarioActual()
        {


            if (GlobalVariable.CurrentDataBaseConnectionFnc == null)
                return;

            ReporteShowingViewModel vm = IoC.Get<ReporteShowingViewModel>();


            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("EMPRESAID", CurrentDocto!.EmpresaId!.Value);
            dict.Add("SUCURSALID", CurrentDocto!.SucursalId!.Value);


            dict.Add("US_ID", GlobalSession!.CurrentUsuario!.Id);
            dict.Add("US_NAME", GlobalSession!.CurrentUsuario!.UsuarioNombre);


            var nombreReporte = "InformeInventarioActual.frx";

            vm.FastReportInfo = new FastReportInfo()
            {

                RutaReporte = FastReportsConfig.getPathForFile(nombreReporte, FastReportsTipoFile.desistema),
                DictionaryReporte = dict,
                ConnectionString = GlobalVariable.CurrentDataBaseConnectionFnc(),
                Userid = GlobalVariable.CurrentSession!.Usuarioid!.Value,
                UserName = GlobalVariable.CurrentSession!.CurrentUsuario!.Nombre
            };
            winManager.ShowDialogAsync(vm, null, CreateWinSettings("Inventario Actual", 0.75));
        }



        public void EliminarInventario()
        {

            if (currentDocto == null || currentDocto.Id == null || currentDocto.Id.Value == 0)
            {

                showPopUpMessage("Informacion ", "No hay inventario a eliminar", "Warning");
                return;
            }

            if (currentDocto.Estatusdoctoid != null && currentDocto.Estatusdoctoid != Model.DBValues._DOCTO_ESTATUS_BORRADOR)
            {

                showPopUpMessage("Informacion ", "El inventario no se puede eliminar", "Warning");
                return;
            }





            try
            {

                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";



                Task.Run<BaseResultBindingModel?>(async () =>
                                                      await inventarioController.Docto_inventario_delete(currentDocto!.EmpresaId!.Value, currentDocto!.SucursalId!.Value, currentDocto!.Id!.Value)

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

                        var tempResult = t.Result;
                        BProcessSuccess = bSuccess;

                        if (BProcessSuccess)
                        {

                            if (tempResult == null)
                            {
                                showPopUpMessage("Error ", "Ocurrio un error indeterminado", "Error");
                            }
                            else if (tempResult.Result < 0)
                            {
                                showPopUpMessage("Error ", "Ocurrio un error " + tempResult.Usermessage, "Error");
                            }
                            else
                            {
                                showPopUpMessage(new MessageToUserSimple("Procesado", "Se ha cancelado el registro el registro", "Success"));
                                this.Back();
                            }

                        }
                        else
                        {
                            showPopUpMessage("Ocurrio un error ", comentario, "Error");
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());


                //BackgroundWorker worker = new BackgroundWorker();
                //BaseResultBindingModel tempResult = new BaseResultBindingModel();


                //worker.DoWork += (o, ea) =>
                //{
                //    try
                //    {

                //        tempResult = inventarioController.Docto_inventario_delete(currentDocto!.EmpresaId!.Value, currentDocto!.SucursalId!.Value, currentDocto!.Id!.Value);


                //    }
                //    catch (Exception ex) { bSuccess = false; comentario = ex.Message; }
                //};
                //worker.RunWorkerCompleted += (o, ea) =>
                //{
                //    IsBusy = false;

                //    BProcessSuccess = bSuccess;

                //    if (BProcessSuccess)
                //    {

                //        if (tempResult == null)
                //        {
                //            showPopUpMessage("Error ", "Ocurrio un error indeterminado", "Error");
                //        }
                //        else if (tempResult.Result < 0)
                //        {
                //            showPopUpMessage("Error ", "Ocurrio un error " + tempResult.Usermessage, "Error");
                //        }
                //        else
                //        {
                //            showPopUpMessage(new MessageToUserSimple("Procesado", "Se ha cancelado el registro el registro", "Success"));
                //            this.Back();
                //        }

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
                IsBusy = false;
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
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
