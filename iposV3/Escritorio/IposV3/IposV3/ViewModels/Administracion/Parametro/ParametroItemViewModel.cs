
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

    public class ParametroItemViewModel : BaseWebRecordViewModel<ParametroBindingModel, ParametroWebController, ParametroItemVMInitialParameters, ParametroListVMEventParameters>
    {

        public ParametroBindingModel? Parametro { get { return Record; } set { Record = value; } }

        private ProductoWebController _productoController;

        private ConfiguracionWebController _configuracionController;


        private Prod_def_caracteristicasBindingModel? _prod_def_caracteristicasItem;
        public Prod_def_caracteristicasBindingModel? Prod_def_caracteristicasItem
        {
            get
            {
                return _prod_def_caracteristicasItem;
            }
            set
            {

                _prod_def_caracteristicasItem = value; NotifyOfPropertyChange("Prod_def_caracteristicasItem");
            }
        }


        private EmpresaBindingModel? _empresaItem;
        public EmpresaBindingModel? EmpresaItem
        {
            get
            {
                return _empresaItem;
            }
            set
            {

                _empresaItem = value; NotifyOfPropertyChange("EmpresaItem");
            }
        }


        public ParametroItemViewModel(string mode, ParametroWebController provider, 
                ProductoWebController productoController ,  ConfiguracionWebController configuracionController,
                SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
            base(mode, provider, selectorProvider, aggregator, winManager, messageBoxService)
        {

            _productoController = productoController;
            _configuracionController = configuracionController;

        }

        protected override void fillRecordToEdit(ParametroItemVMInitialParameters initialParameters)
        {
            base.fillRecordToEdit(initialParameters);

            var bufferProdDef = new Prod_def_caracteristicasBindingModel()
            {
                EmpresaId = GlobalVariable.CurrentSession!.Empresaid,
                SucursalId = GlobalVariable.CurrentSession.Sucursalid
            };


            Task.Run(async () =>
            {
                Prod_def_caracteristicasItem = await _productoController.ObtenerProd_def_Caracterisiticas(bufferProdDef) ?? bufferProdDef;

            }).Wait();

            EmpresaItem = GlobalVariable.CurrentSession!.CurrentEmpresa;
        }


        public override void Accept()
        {
            base.Accept();

            Task.Run(async () =>
            {

                await this._productoController.GuardarProd_def_caracteristicas(Prod_def_caracteristicasItem!);

                var result = await this._configuracionController.UpdateEmpresa(EmpresaItem!) ?? false;

                if (result)
                {

                    GlobalVariable.CurrentSession!.CurrentEmpresa = EmpresaItem;

                    //var bufferEmpresa = new Empresa();
                    //EmpresaItem!.FillEntityValues(ref bufferEmpresa);
                    //GlobalVariable.CurrentSession!.CurrentEmpresa = new EmpresaBindingModel( bufferEmpresa);


                }
            }).Wait();


        }

        protected override void fillCatalogConfiguration()
        {
            catalogRelatedFields = new List<CatalogRelatedFields>() {
                                          new CatalogRelatedFields("Parametro","Tipoprecio","Lista_precio_defid", "Lista_precio_defClave", "Lista_precio_defNombre","IposV3.ViewModels.TipoprecioListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Parametro","Tipodescuentoprod","Tipodescuentoprodid", "TipodescuentoprodClave", "TipodescuentoprodNombre","IposV3.ViewModels.TipodescuentoprodListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Parametro","Tipoprecio","Precioajustedifinvid", "PrecioajustedifinvClave", "PrecioajustedifinvNombre","IposV3.ViewModels.TipoprecioListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Parametro","Usuario","Encargadoid", "EncargadoClave", "EncargadoNombre","IposV3.ViewModels.UsuarioListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Parametro","Tipoutilidad","Tipoutilidadid", "TipoutilidadClave", "TipoutilidadNombre","IposV3.ViewModels.TipoutilidadListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Parametro","Almacen","Almacenrecepcionid", "AlmacenrecepcionClave", "AlmacenrecepcionNombre","IposV3.ViewModels.AlmacenListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Parametro","Tipoprecio","Campoimpocostorepoid", "CampoimpocostorepoClave", "CampoimpocostorepoNombre","IposV3.ViewModels.TipoprecioListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Parametro","Cliente","Clienteconsolidadoid", "ClienteconsolidadoClave", "ClienteconsolidadoNombre","IposV3.ViewModels.ClienteListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Parametro","Sat_metodopago","Sat_metodopagoid", "Sat_metodopagoClave", "Sat_metodopagoNombre","IposV3.ViewModels.Sat_metodopagoListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Parametro","Sat_regimenfiscal","Sat_regimenfiscalid", "Sat_regimenfiscalClave", "Sat_regimenfiscalNombre","IposV3.ViewModels.Sat_regimenfiscalListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Parametro","Usuario","Vendedormovilid", "VendedormovilClave", "VendedormovilNombre","IposV3.ViewModels.UsuarioListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Parametro","Linea","Emidarecargalineaid", "EmidarecargalineaClave", "EmidarecargalineaNombre","IposV3.ViewModels.LineaListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Parametro","Marca","Emidarecargamarcaid", "EmidarecargamarcaClave", "EmidarecargamarcaNombre","IposV3.ViewModels.MarcaListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Parametro","Proveedor","Emidarecargaproveedorid", "EmidarecargaproveedorClave", "EmidarecargaproveedorNombre","IposV3.ViewModels.ProveedorListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Parametro","Linea","Emidaserviciolineaid", "EmidaserviciolineaClave", "EmidaserviciolineaNombre","IposV3.ViewModels.LineaListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Parametro","Marca","Emidaserviciomarcaid", "EmidaserviciomarcaClave", "EmidaserviciomarcaNombre","IposV3.ViewModels.MarcaListViewModel","SelectedItem","Clave"),
                                          new CatalogRelatedFields("Parametro","Proveedor","Emidaservicioproveedorid", "EmidaservicioproveedorClave", "EmidaservicioproveedorNombre","IposV3.ViewModels.ProveedorListViewModel","SelectedItem","Clave")
                                    };
            lstCatalogDef = new List<CatalogDef>() { new CatalogDef(
                    "Tipoprecio"),new CatalogDef(
                    "Agrupacionventa"),new CatalogDef(
                    "FormatTicketCorto"),new CatalogDef(
                    "FiltroProductoSat"),new CatalogDef(
                    "ConfigPantalla"),new CatalogDef(
                    "TipoConexionMovil"),new CatalogDef(
                    "Tiposyncmovil"),new CatalogDef(
                    "ModoAlertaPV"),new CatalogDef(
                    "Tipoutilidad"),new CatalogDef(
                    "FormatoFactura")};

        } 

    }


    public class ParametroShowViewModel : ParametroItemViewModel
    {
        public ParametroShowViewModel(ParametroWebController provider,
                                    ProductoWebController productoController , ConfiguracionWebController configuracionController ,
                                    SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Show", provider, productoController , configuracionController , selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

    public class ParametroEditViewModel : ParametroItemViewModel
    {
        public ParametroEditViewModel(ParametroWebController provider,
                                    ProductoWebController productoController , ConfiguracionWebController configuracionController , 
                                    SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Edit", provider, productoController , configuracionController , selectorProvider, aggregator, winManager, messageBoxService)
        {
        }


        public override void SuccessEditActions(ParametroBindingModel record)
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
    }

    public class ParametroAddViewModel : ParametroItemViewModel
    {
        public ParametroAddViewModel(ParametroWebController provider,
                                    ProductoWebController productoController , ConfiguracionWebController configuracionController ,
                                    SelectorWebController selectorProvider, IEventAggregator aggregator, IWindowManager winManager, IMessageBoxService messageBoxService) :
                            base("Add", provider, productoController , configuracionController , selectorProvider, aggregator, winManager, messageBoxService)
        {
        }
    }

}


