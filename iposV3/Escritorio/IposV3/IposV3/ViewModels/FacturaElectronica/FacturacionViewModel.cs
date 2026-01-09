
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
using IposV3.BindingModel;

namespace IposV3.ViewModels
{

    public class FacturacionViewModel : BaseGenericViewModel
    {

        public bool SeFacturo { get; set; }

        public long? EmpresaId { get; set; }
        public long? SucursalId { get; set; }
        public long? DoctoId { get; set; }

        public string? Tipocomprobanteespecial { get; set; }

        public bool Generarcartaporte { get; set; } = false;

        public CfdiWebController cfdiControllerProvider { get; set; }
        public bool BProcessSuccess { get; protected set; }

        public FacturacionViewModel(
            CfdiWebController cfdiControllerProvider,
            SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(selectorProvider, aggregator, winManager, messageBoxService)
        {
            this.cfdiControllerProvider = cfdiControllerProvider;
        }


        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>()
            {
            };

            lstCatalogDef = new List<CatalogDef>() {};

        }

        public void AsignarDatoParaFacturar(long? empresaId, long? sucursalId, long? doctoId, string? tipocomprobanteespecial, bool generarcartaporte)
        {

            EmpresaId = empresaId;
            SucursalId = sucursalId;
            DoctoId = doctoId;
            Tipocomprobanteespecial = tipocomprobanteespecial;
            Generarcartaporte = generarcartaporte;

        }


        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            GenerarFacturaElectronica();
        }


        public void GenerarFacturaElectronica()
        {

            //string resultMessage = "";
            try
            {

                bool bSuccess = true;
                IsBusy = true;
                var comentario = "";


                
                Task.Run<BaseResultBindingModel?>(async () =>
                                                      await cfdiControllerProvider.GeneraFacturaElectronica(EmpresaId!.Value, SucursalId!.Value, DoctoId!.Value, Tipocomprobanteespecial, Generarcartaporte,
                                                                                                GlobalVariable.CurrentSession!.CurrentParametro!,
                                                                                                new IposV3.Services.FacturaElectronica.VirtualXmlHelper.DispatcherDelegate(ShowFacturacionError))
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
                            SeFacturo = true;
                            showPopUpMessage("Exito ", " Se realizo la operacion", "Success");
                        }
                        else
                        {
                            showPopUpMessage("Ocurrio un error ", comentario, "Error");
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());

            }
            catch (Exception ex)
            {
                showPopUpMessage("Ocurrio un error ", ex.Message, "Error");
            }
            
        }

        public void ShowFacturacionError(int hXml)
        {

            System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(new System.Action(() =>
            {
                Services.FacturaElectronicaService.ShowError(hXml);
            }));

        }


    }
}
