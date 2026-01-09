using BindingModels;
using Caliburn.Micro;
using Controllers.Controller;
using IposV3Sync.Controllers.Controller;
using IposV3.Model;
using ViewModels.BaseScreen;
using MaterialDesignColors;
using Models.CatalogSelector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IposV3Sync.ViewModels
{
    public class HomeSyncViewModel : IposV3Sync.ViewModels.BaseScreen.BaseScreen, IHandle<HomeSyncListVMEventParameters>
    {


        protected readonly IEventAggregator aggregator;

        public HomeSyncViewModel(SelectorWebController selectorProvider, IWindowManager winManager, IMessageBoxService messageBoxService, 
                                IEventAggregator aggregator) : base( selectorProvider, winManager, messageBoxService)
        {

            this.aggregator = aggregator;
            this.aggregator.SubscribeOnUIThread(this);


            this.messageBoxService = messageBoxService;
            MessageToUser = new MessageToUser("titulo", "este es un mensaje", "Information", false);


            //MarcaBindingModel marcaB = new MarcaBindingModel();
            //marcaB.EmpresaId = 5;
            //marcaB.SucursalId = 4;
            //marcaB.Clave = "Toyota";
            //marcaB.Nombre = " Marca Japonesa Toyota";

            //var result = marcaController.Insert(marcaB);

            //var listMarcas = marcaController.GetAll();




            //KendoParams kendoParams = new KendoParams();
            //kendoParams.GeneralFilter = new KendoGeneralFilter("Japol", null);

            //MarcaParam param = new MarcaParam(5, 4, null, null);

            //var listMarcas = marcaController.SelectList(param, kendoParams);
            //var test = listMarcas;




            //LineaBindingModel lineaB = new LineaBindingModel();
            //lineaB.EmpresaId = 5;
            //lineaB.SucursalId = 4;
            //lineaB.Clave = "Yaris";
            //lineaB.Nombre = "Linea Yaris TY";
            //lineaB.Acumulapromocion = BoolCN.S;
            //lineaB.Gpoimp = "Grupo x";
            //lineaB.Descuentovale = 1;

            //var result = lineaController.Insert(lineaB);

            //ProductoBindingModel prod = new ProductoBindingModel();
            //prod.Clave = "TequilaLlamas";
            //prod.Nombre = "Tequila Manuel Llamas";
            //prod.Descripcion = "El autentico Tequila";

            //prod.EmpresaId = 5;
            //prod.SucursalId = 4;
            //prod.Lineaid = 1;
            //prod.Marcaid = 1;


            //this.productoController.Insert(prod);

            //ProductoBindingModel prod = new ProductoBindingModel();
            //prod.EmpresaId = 5;
            //prod.SucursalId = 4;
            //prod.Id = 1;
            //prod =  this.productoController.GetById(prod);
            //prod.Productocaracteristicas_Numero1 = 23;
            //this.productoController.Update(prod);
            //prod = this.productoController.GetById(prod);

            //KendoParams kendoParams = new KendoParams();
            //kendoParams.Filter = new KendoFilters(
            //new List<KendoFilter>() { new KendoFilter("llamas", "contains", "Clave", "false") }, "and");
            //kendoParams.GeneralFilter = new KendoGeneralFilter("searchx", @"""Clave""|""Nombre""|Productocaracteristicas.Texto1");

            //MarcaParam param = new MarcaParam(5, 4, null, null);

            //ProductoParam param = new ProductoParam(5, 4);
            //var listMarcas = productoController.SelectList(param, kendoParams);
            //var listMarcas = productoController.Select(param, "searchx", @"""Clave""|""Nombre""|Productocaracteristicas.Texto1");



        }

        ~HomeSyncViewModel()
        {
            this.aggregator.Unsubscribe(this);
        }

       


        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        protected override Task OnInitializeAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

       


        public Task HandleAsync(HomeSyncListVMEventParameters parameters, CancellationToken cancellationToken)
        {
            if (parameters.HasMessage && parameters.MsgSimple != null)
            {
                showPopUpMessage(parameters.MsgSimple);
            }


            return Task.CompletedTask;
        }

    }
}
