using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Windows;
using Caliburn.Micro;
using Castle.Core;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using IposV3.Model;
using IposV3.Views;
using IposV3.ViewModels;
using Models;
using StudentsManager.ViewModels;
using StudentsManager.Views;
using Component = Castle.MicroKernel.Registration.Component;
using Controllers.BindingModel.Menu;
using Controllers.Controller;
//using IposV3.Controllers.Controller;
//using IposV3.Controllers.Controller.Utils;
using IposV3.DataAccess;
using IposV3.Services;
using ViewModels.BaseScreen;
using FastReport.Data;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace StudentsManager
{
    public class Bootstrapper : BootstrapperBase {
        private WindsorContainer? container;

        public Bootstrapper() {
            Initialize();
        }

        protected override IEnumerable<Assembly> SelectAssemblies() {
            return new[] {
                //typeof (MainViewModel).Assembly,
                //typeof (MainView).Assembly,
                typeof (MainWindowViewModel).Assembly,
                typeof (MainWindowView).Assembly
            };
        }

        protected override void Configure() {

            Func<string> getGeneralConnectionStringPtr = GetGeneralConnectionString;
            GlobalVariable.CurrentDataBaseConnectionFnc = getGeneralConnectionStringPtr;


            container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new AppSettingsConvention());


            FastReport.Utils.RegisteredObjects.AddConnection(typeof(PostgresDataConnection));
            var serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();

            container.Register(
                Component.For<IEventAggregator>()
                    .ImplementedBy<EventAggregator>()
                    .LifestyleSingleton(),
                Component.For<Caliburn.Micro.IWindowManager>()
                    .ImplementedBy<Caliburn.Micro.WindowManager>()
                    .LifestyleSingleton(),


                //dao
                Component.For<ConfiguracionDao>()
                    .ImplementedBy<ConfiguracionDao>(),


                //Component.For<SelectorController>()
                //    .ImplementedBy<SelectorController>(),


                //Component.For<CatalogSelector>()
                //    .ImplementedBy<CatalogSelector>(),





                 Component.For<IMessageBoxService>()
                    .ImplementedBy<Controls.WPFMessageBoxService>(),

                //Component.For<MenuitemsController>()
                //    .ImplementedBy<MenuitemsController>(),



                //Component.For<MarcaController>()
                //    .ImplementedBy<MarcaController>(),

                //Component.For<LineaController>()
                //    .ImplementedBy<LineaController>(),


                //Component.For<ProductoController>()
                //    .ImplementedBy<ProductoController>(),



                //Component.For<CajaController>()
                //    .ImplementedBy<CajaController>(),

                //Component.For<PerfilesController>()
                //    .ImplementedBy<PerfilesController>(),

                //Component.For<Sucursal_infoController>()
                //    .ImplementedBy<Sucursal_infoController>(),

                //Component.For<UsuarioController>()
                //    .ImplementedBy<UsuarioController>(),

                //Component.For<GruposucursalController>()
                //    .ImplementedBy<GruposucursalController>(),

                //Component.For<GrupousuarioController>()
                //    .ImplementedBy<GrupousuarioController>(),

                //Component.For<MonedaController>()
                //    .ImplementedBy<MonedaController>(),

                //Component.For<TasaiepsController>()
                //    .ImplementedBy<TasaiepsController>(),

                //Component.For<TasaivaController>()
                //    .ImplementedBy<TasaivaController>(),

                //Component.For<UnidadController>()
                //    .ImplementedBy<UnidadController>(),

                //Component.For<EstadopaisController>()
                //    .ImplementedBy<EstadopaisController>(),

                //Component.For<SubtipoclienteController>()
                //    .ImplementedBy<SubtipoclienteController>(),

                //Component.For<TiporecargaController>()
                //    .ImplementedBy<TiporecargaController>(),

                //Component.For<FormapagosatController>()
                //    .ImplementedBy<FormapagosatController>(),

                //Component.For<Sat_aduanaController>()
                //    .ImplementedBy<Sat_aduanaController>(),

                //Component.For<Sat_claveunidadpesoController>()
                //    .ImplementedBy<Sat_claveunidadpesoController>(),

                //Component.For<Sat_coloniaController>()
                //    .ImplementedBy<Sat_coloniaController>(),

                //Component.For<Sat_localidadController>()
                //    .ImplementedBy<Sat_localidadController>(),

                //Component.For<Sat_matpeligrosoController>()
                //    .ImplementedBy<Sat_matpeligrosoController>(),

                //Component.For<Sat_metodopagoController>()
                //    .ImplementedBy<Sat_metodopagoController>(),

                //Component.For<Sat_municipioController>()
                //    .ImplementedBy<Sat_municipioController>(),

                //Component.For<Sat_paisController>()
                //    .ImplementedBy<Sat_paisController>(),

                //Component.For<Sat_productoservicioController>()
                //    .ImplementedBy<Sat_productoservicioController>(),

                //Component.For<Sat_regimenfiscalController>()
                //    .ImplementedBy<Sat_regimenfiscalController>(),

                //Component.For<Sat_tipoembalajeController>()
                //    .ImplementedBy<Sat_tipoembalajeController>(),

                //Component.For<Sat_unidadmedidaController>()
                //    .ImplementedBy<Sat_unidadmedidaController>(),

                //Component.For<Sat_usocfdiController>()
                //    .ImplementedBy<Sat_usocfdiController>(),

                //Component.For<EstadocobranzaController>()
                //    .ImplementedBy<EstadocobranzaController>(),

                //Component.For<EstadopagocontrareciboController>()
                //    .ImplementedBy<EstadopagocontrareciboController>(),

                //Component.For<ClienteController>()
                //    .ImplementedBy<ClienteController>(),

                //Component.For<ProveedorController>()
                //    .ImplementedBy<ProveedorController>(),

                //Component.For<TipotransaccionController>()
                //    .ImplementedBy<TipotransaccionController>(),

                //Component.For<ClerkpagoservicioController>()
                //    .ImplementedBy<ClerkpagoservicioController>(),

                //Component.For<EmidaproductController>()
                //    .ImplementedBy<EmidaproductController>(),

                //Component.For<MerchantpagoservicioController>()
                //    .ImplementedBy<MerchantpagoservicioController>(),

                //Component.For<TerminalpagoservicioController>()
                //    .ImplementedBy<TerminalpagoservicioController>(),

                //Component.For<GastoadicionalController>()
                //    .ImplementedBy<GastoadicionalController>(),

                //Component.For<EstadoguiaController>()
                //    .ImplementedBy<EstadoguiaController>(),

                //Component.For<TipoentregaController>()
                //    .ImplementedBy<TipoentregaController>(),

                //Component.For<AlmacenController>()
                //    .ImplementedBy<AlmacenController>(),

                //Component.For<AnaquelController>()
                //    .ImplementedBy<AnaquelController>(),

                //Component.For<GrupodiferenciainventarioController>()
                //    .ImplementedBy<GrupodiferenciainventarioController>(),

                //Component.For<TipodiferenciainventarioController>()
                //    .ImplementedBy<TipodiferenciainventarioController>(),

                //Component.For<MensajenivelurgenciaController>()
                //    .ImplementedBy<MensajenivelurgenciaController>(),

                //Component.For<BancoController>()
                //    .ImplementedBy<BancoController>(),

                //Component.For<FormapagoController>()
                //    .ImplementedBy<FormapagoController>(),

                //Component.For<Motivo_camfecController>()
                //    .ImplementedBy<Motivo_camfecController>(),

                //Component.For<CuentaController>()
                //    .ImplementedBy<CuentaController>(),

                //Component.For<CuentabancoController>()
                //    .ImplementedBy<CuentabancoController>(),

                //Component.For<PlazoController>()
                //    .ImplementedBy<PlazoController>(),

                //Component.For<TipolineapolizaController>()
                //    .ImplementedBy<TipolineapolizaController>(),

                //Component.For<CamporeferenciaprecioController>()
                //    .ImplementedBy<CamporeferenciaprecioController>(),

                //Component.For<TipodescuentoprodController>()
                //    .ImplementedBy<TipodescuentoprodController>(),

                //Component.For<TipoutilidadController>()
                //    .ImplementedBy<TipoutilidadController>(),

                //Component.For<PromocionController>()
                //    .ImplementedBy<PromocionController>(),

                //Component.For<RangopromocionController>()
                //    .ImplementedBy<RangopromocionController>(),

                //Component.For<TipopromocionController>()
                //    .ImplementedBy<TipopromocionController>(),

                //Component.For<ClasificaController>()
                //    .ImplementedBy<ClasificaController>(),

                //Component.For<ContenidoController>()
                //    .ImplementedBy<ContenidoController>(),

                //Component.For<ReportesController>()
                //    .ImplementedBy<ReportesController>(),

                //Component.For<RutaembarqueController>()
                //    .ImplementedBy<RutaembarqueController>(),

                //Component.For<Motivo_devolucionController>()
                //    .ImplementedBy<Motivo_devolucionController>(),

                //Component.For<ParametroController>()
                //    .ImplementedBy<ParametroController>(),

                //Component.For<ConfiguracionController>()
                //    .ImplementedBy<ConfiguracionController>(),

                //Component.For<GlobalController>()
                //    .ImplementedBy<GlobalController>(),

                //Component.For<KitdefinicionController>()
                //    .ImplementedBy<KitdefinicionController>(),

                //Component.For<CorteController>()
                //    .ImplementedBy<CorteController>(),


                //Component.For<DoctoController>()
                //    .ImplementedBy<DoctoController>(),


                //Component.For<MovtoController>()
                //    .ImplementedBy<MovtoController>(),

                //Component.For<PuntoCompraController>()
                //    .ImplementedBy<PuntoCompraController>(),


                //Component.For<PuntoSolicitudMercanciaController>()
                //    .ImplementedBy<PuntoSolicitudMercanciaController>(),

                //Component.For<PuntoPedidoEntradaController>()
                //    .ImplementedBy<PuntoPedidoEntradaController>(),

                //Component.For<PuntoCompraDevoController>()
                //    .ImplementedBy<PuntoCompraDevoController>(),

                //Component.For<PuntoVentaController>()
                //    .ImplementedBy<PuntoVentaController>(),

                //Component.For<PuntoVentaDevoController>()
                //    .ImplementedBy<PuntoVentaDevoController>(),

                //Component.For<InventarioController>()
                //    .ImplementedBy<InventarioController>(),


                //Component.For<LotesimportadosController>()
                //    .ImplementedBy<LotesimportadosController>(),


                //Component.For<LoteController>()
                //    .ImplementedBy<LoteController>(),

                //Component.For<CfdiController>()
                //    .ImplementedBy<CfdiController>(),

                //Component.For<PagoController>()
                //    .ImplementedBy<PagoController>(),

                //Component.For<VehiculoController>()
                //    .ImplementedBy<VehiculoController>(),

                //Component.For<Sat_subtiporemController>()
                //    .ImplementedBy<Sat_subtiporemController>(),

                //Component.For<Sat_configautotransporteController>()
                //    .ImplementedBy<Sat_configautotransporteController>(),

                //Component.For<Sat_tipopermisoController>()
                //    .ImplementedBy<Sat_tipopermisoController>(),

                //Component.For<GuiaController>()
                //    .ImplementedBy<GuiaController>(),


                //Component.For<ImpoExpoController>()
                //    .ImplementedBy<ImpoExpoController>(),


                //Component.For<PuntoTrasladoRecepcionController>()
                //    .ImplementedBy<PuntoTrasladoRecepcionController>(),

                //Component.For<FirebirdMigrationController>()
                //    .ImplementedBy<FirebirdMigrationController>(),



                //Component.For<MaxfactController>()
                //    .ImplementedBy<MaxfactController>(),

                //Component.For<AreaController>()
                //    .ImplementedBy<AreaController>(),

                //Component.For<ListaprecioController>()
                //    .ImplementedBy<ListaprecioController>(),

                //Component.For<GastoController>()
                //    .ImplementedBy<GastoController>(),

                //Component.For<ProductolocationsController>()
                //    .ImplementedBy<ProductolocationsController>(),

                //Component.For<MovtogastosadicController>()
                //    .ImplementedBy<MovtogastosadicController>(),



                //Component.For<ConsolidadoController>()
                //    .ImplementedBy<ConsolidadoController>(),


                //Component.For<KitdefinicionService>()
                //    .ImplementedBy<KitdefinicionService>(),


                //Component.For<DoctoService>()
                //    .ImplementedBy<DoctoService>(),

                //Component.For<MovtoService>()
                //    .ImplementedBy<MovtoService>(),

                //Component.For<DoctoMovtoService>()
                //    .ImplementedBy<DoctoMovtoService>(),

                //Component.For<ImpuestosService>()
                //    .ImplementedBy<ImpuestosService>(),

                //Component.For<ProveeduriaService>()
                //    .ImplementedBy<ProveeduriaService>(),


                //Component.For<ProvDevoService>()
                //    .ImplementedBy<ProvDevoService>(),


                //Component.For<TrasladoRecepcionService>()
                //    .ImplementedBy<TrasladoRecepcionService>(),


                //Component.For<SolicitudMercanciaService>()
                //    .ImplementedBy<SolicitudMercanciaService>(),


                //Component.For<PedidoEntradaService>()
                //    .ImplementedBy<PedidoEntradaService>(),

                //Component.For<VendeduriaService>()
                //    .ImplementedBy<VendeduriaService>(),


                //Component.For<VenddevoService>()
                //    .ImplementedBy<VenddevoService>(),

                //Component.For<CorteService>()
                //    .ImplementedBy<CorteService>(),

                //Component.For<MaestroConsecutivoService>()
                //    .ImplementedBy<MaestroConsecutivoService>(),

                //Component.For<InventarioService>()
                //    .ImplementedBy<InventarioService>(),

                //Component.For<PagoService>()
                //    .ImplementedBy<PagoService>(),

                //Component.For<PagosFacturaElectronicaService>()
                //    .ImplementedBy<PagosFacturaElectronicaService>(),

                //Component.For<UsuarioService>()
                //    .ImplementedBy<UsuarioService>(),

                //Component.For<FacturaElectronicaService>()
                //    .ImplementedBy<FacturaElectronicaService>(),

                //Component.For<CartaporteFacturaElectronicaService>()
                //    .ImplementedBy<CartaporteFacturaElectronicaService>(),


                //Component.For<InventarioOperativoService>()
                //    .ImplementedBy<InventarioOperativoService>(),

                //Component.For<ConsolidacionService>()
                //    .ImplementedBy<ConsolidacionService>(),


                //Component.For<ProductoService>()
                //    .ImplementedBy<ProductoService>(),


                Component.For<CajaWebController>()
                .ImplementedBy<CajaWebController>(),

                Component.For<ParametroWebController>()
                .ImplementedBy<ParametroWebController>(),

                Component.For<PerfilesWebController>()
                .ImplementedBy<PerfilesWebController>(),

                Component.For<Sucursal_infoWebController>()
                .ImplementedBy<Sucursal_infoWebController>(),

                Component.For<UsuarioWebController>()
                .ImplementedBy<UsuarioWebController>(),

                Component.For<VehiculoWebController>()
                .ImplementedBy<VehiculoWebController>(),

                Component.For<GruposucursalWebController>()
                .ImplementedBy<GruposucursalWebController>(),

                Component.For<GrupousuarioWebController>()
                .ImplementedBy<GrupousuarioWebController>(),

                Component.For<LineaWebController>()
                .ImplementedBy<LineaWebController>(),

                Component.For<MarcaWebController>()
                .ImplementedBy<MarcaWebController>(),

                Component.For<MonedaWebController>()
                .ImplementedBy<MonedaWebController>(),

                Component.For<TasaiepsWebController>()
                .ImplementedBy<TasaiepsWebController>(),

                Component.For<TasaivaWebController>()
                .ImplementedBy<TasaivaWebController>(),

                Component.For<UnidadWebController>()
                .ImplementedBy<UnidadWebController>(),

                Component.For<EstadopaisWebController>()
                .ImplementedBy<EstadopaisWebController>(),

                Component.For<SubtipoclienteWebController>()
                .ImplementedBy<SubtipoclienteWebController>(),

                Component.For<TiporecargaWebController>()
                .ImplementedBy<TiporecargaWebController>(),

                Component.For<FormapagosatWebController>()
                .ImplementedBy<FormapagosatWebController>(),

                Component.For<Sat_aduanaWebController>()
                .ImplementedBy<Sat_aduanaWebController>(),

                Component.For<Sat_claveunidadpesoWebController>()
                .ImplementedBy<Sat_claveunidadpesoWebController>(),

                Component.For<Sat_coloniaWebController>()
                .ImplementedBy<Sat_coloniaWebController>(),

                Component.For<Sat_configautotransporteWebController>()
                .ImplementedBy<Sat_configautotransporteWebController>(),

                Component.For<Sat_figuratransporteWebController>()
                .ImplementedBy<Sat_figuratransporteWebController>(),

                Component.For<Sat_localidadWebController>()
                .ImplementedBy<Sat_localidadWebController>(),

                Component.For<Sat_matpeligrosoWebController>()
                .ImplementedBy<Sat_matpeligrosoWebController>(),

                Component.For<Sat_metodopagoWebController>()
                .ImplementedBy<Sat_metodopagoWebController>(),

                Component.For<Sat_municipioWebController>()
                .ImplementedBy<Sat_municipioWebController>(),

                Component.For<Sat_paisWebController>()
                .ImplementedBy<Sat_paisWebController>(),

                Component.For<Sat_partetransporteWebController>()
                .ImplementedBy<Sat_partetransporteWebController>(),

                Component.For<Sat_productoservicioWebController>()
                .ImplementedBy<Sat_productoservicioWebController>(),

                Component.For<Sat_regimenfiscalWebController>()
                .ImplementedBy<Sat_regimenfiscalWebController>(),

                Component.For<Sat_subtiporemWebController>()
                .ImplementedBy<Sat_subtiporemWebController>(),

                Component.For<Sat_tipoembalajeWebController>()
                .ImplementedBy<Sat_tipoembalajeWebController>(),

                Component.For<Sat_tipopermisoWebController>()
                .ImplementedBy<Sat_tipopermisoWebController>(),

                Component.For<Sat_unidadmedidaWebController>()
                .ImplementedBy<Sat_unidadmedidaWebController>(),

                Component.For<Sat_usocfdiWebController>()
                .ImplementedBy<Sat_usocfdiWebController>(),

                Component.For<EstadocobranzaWebController>()
                .ImplementedBy<EstadocobranzaWebController>(),

                Component.For<ConfiguracionWebController>()
                .ImplementedBy<ConfiguracionWebController>(),

                Component.For<EstadopagocontrareciboWebController>()
                .ImplementedBy<EstadopagocontrareciboWebController>(),

                Component.For<ClienteWebController>()
                .ImplementedBy<ClienteWebController>(),

                Component.For<DoctoWebController>()
                .ImplementedBy<DoctoWebController>(),

                Component.For<MovtoWebController>()
                .ImplementedBy<MovtoWebController>(),

                Component.For<ProductoWebController>()
                .ImplementedBy<ProductoWebController>(),

                Component.For<ProveedorWebController>()
                .ImplementedBy<ProveedorWebController>(),

                Component.For<CorteWebController>()
                .ImplementedBy<CorteWebController>(),

                Component.For<TipotransaccionWebController>()
                .ImplementedBy<TipotransaccionWebController>(),

                Component.For<ClerkpagoservicioWebController>()
                .ImplementedBy<ClerkpagoservicioWebController>(),

                Component.For<EmidaproductWebController>()
                .ImplementedBy<EmidaproductWebController>(),

                Component.For<MerchantpagoservicioWebController>()
                .ImplementedBy<MerchantpagoservicioWebController>(),

                Component.For<TerminalpagoservicioWebController>()
                .ImplementedBy<TerminalpagoservicioWebController>(),

                Component.For<MaxfactWebController>()
                .ImplementedBy<MaxfactWebController>(),

                Component.For<GastoadicionalWebController>()
                .ImplementedBy<GastoadicionalWebController>(),

                Component.For<GastoWebController>()
                .ImplementedBy<GastoWebController>(),

                Component.For<MovtogastosadicWebController>()
                .ImplementedBy<MovtogastosadicWebController>(),

                Component.For<EstadoguiaWebController>()
                .ImplementedBy<EstadoguiaWebController>(),

                Component.For<GuiaWebController>()
                .ImplementedBy<GuiaWebController>(),

                Component.For<TipoentregaWebController>()
                .ImplementedBy<TipoentregaWebController>(),

                Component.For<AlmacenWebController>()
                .ImplementedBy<AlmacenWebController>(),

                Component.For<AnaquelWebController>()
                .ImplementedBy<AnaquelWebController>(),

                Component.For<GrupodiferenciainventarioWebController>()
                .ImplementedBy<GrupodiferenciainventarioWebController>(),

                Component.For<LotesimportadosWebController>()
                .ImplementedBy<LotesimportadosWebController>(),

                Component.For<ProductolocationsWebController>()
                .ImplementedBy<ProductolocationsWebController>(),

                Component.For<TipodiferenciainventarioWebController>()
                .ImplementedBy<TipodiferenciainventarioWebController>(),

                Component.For<KitdefinicionWebController>()
                .ImplementedBy<KitdefinicionWebController>(),

                Component.For<AreaWebController>()
                .ImplementedBy<AreaWebController>(),

                Component.For<MensajenivelurgenciaWebController>()
                .ImplementedBy<MensajenivelurgenciaWebController>(),

                Component.For<PagoWebController>()
                .ImplementedBy<PagoWebController>(),

                Component.For<BancoWebController>()
                .ImplementedBy<BancoWebController>(),

                Component.For<FormapagoWebController>()
                .ImplementedBy<FormapagoWebController>(),

                Component.For<Motivo_camfecWebController>()
                .ImplementedBy<Motivo_camfecWebController>(),

                Component.For<CuentabancoWebController>()
                .ImplementedBy<CuentabancoWebController>(),

                Component.For<CuentaWebController>()
                .ImplementedBy<CuentaWebController>(),

                Component.For<PlazoWebController>()
                .ImplementedBy<PlazoWebController>(),

                Component.For<TipolineapolizaWebController>()
                .ImplementedBy<TipolineapolizaWebController>(),

                Component.For<PromocionWebController>()
                .ImplementedBy<PromocionWebController>(),

                Component.For<RangopromocionWebController>()
                .ImplementedBy<RangopromocionWebController>(),

                Component.For<TipopromocionWebController>()
                .ImplementedBy<TipopromocionWebController>(),

                Component.For<ClasificaWebController>()
                .ImplementedBy<ClasificaWebController>(),

                Component.For<ContenidoWebController>()
                .ImplementedBy<ContenidoWebController>(),

                Component.For<ReportesWebController>()
                .ImplementedBy<ReportesWebController>(),

                Component.For<RutaembarqueWebController>()
                .ImplementedBy<RutaembarqueWebController>(),

                Component.For<Motivo_devolucionWebController>()
                .ImplementedBy<Motivo_devolucionWebController>(),

                Component.For<SelectorWebController>()
                .ImplementedBy<SelectorWebController>(),

                Component.For<PuntoCompraWebController>()
                .ImplementedBy<PuntoCompraWebController>(),

                Component.For<PuntoCompraDevoWebController>()
                .ImplementedBy<PuntoCompraDevoWebController>(),

                Component.For<PuntoVentaWebController>()
                .ImplementedBy<PuntoVentaWebController>(),

                Component.For<PuntoVentaDevoWebController>()
                .ImplementedBy<PuntoVentaDevoWebController>(),

                Component.For<CfdiWebController>()
                .ImplementedBy<CfdiWebController>(),

                Component.For<ConsolidadoWebController>()
                .ImplementedBy<ConsolidadoWebController>(),

                Component.For<InventarioWebController>()
                .ImplementedBy<InventarioWebController>(),

                Component.For<LoteWebController>()
                .ImplementedBy<LoteWebController>(),

                Component.For<MenuitemsWebController>()
                .ImplementedBy<MenuitemsWebController>(),

                Component.For<PuntoPedidoEntradaWebController>()
                .ImplementedBy<PuntoPedidoEntradaWebController>(),

                Component.For<PuntoTrasladoRecepcionWebController>()
                .ImplementedBy<PuntoTrasladoRecepcionWebController>(),

                Component.For<PuntoSolicitudMercanciaWebController>()
                .ImplementedBy<PuntoSolicitudMercanciaWebController>(),

                Component.For<CamporeferenciaprecioWebController>()
                .ImplementedBy<CamporeferenciaprecioWebController>(),

                Component.For<ListaprecioWebController>()
                .ImplementedBy<ListaprecioWebController>(),

                Component.For<TipodescuentoprodWebController>()
                .ImplementedBy<TipodescuentoprodWebController>(),

                Component.For<TipoutilidadWebController>()
                .ImplementedBy<TipoutilidadWebController>(),

                Component.For<GlobalWebController>()
                .ImplementedBy<GlobalWebController>(),

                Component.For<ImpoExpoWebController>()
                .ImplementedBy<ImpoExpoWebController>(),





                Castle.MicroKernel.Registration.Component.For<IHttpClientFactory>()
                    .Instance(serviceProvider.GetService<IHttpClientFactory>()!)
                    .LifestyleSingleton()





                //    .DependsOn(Dependency.OnValue<Func<string>>(getGeneralConnectionStringPtr))

                );
            RegisterViewModels();
            RegisterServices();
            container.AddFacility<TypedFactoryFacility>();

           

            ViewLocator.NameTransformer.AddRule(
                @"StudentsManager.ViewModels.AddStudentViewModel",
                @"StudentsManager.Views.AddEditStudentView");

            ViewLocator.NameTransformer.AddRule(
                @"StudentsManager.ViewModels.EditStudentViewModel",
                @"StudentsManager.Views.AddEditStudentView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.HomeViewModel",
                @"IposV3.Views.HomeView");



            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.MarcaAddViewModel",
                @"IposV3.Views.MarcaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.MarcaEditViewModel",
                @"IposV3.Views.MarcaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.MarcaShowViewModel",
                @"IposV3.Views.MarcaAddEditView");


            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.LineaAddViewModel",
                @"IposV3.Views.LineaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.LineaEditViewModel",
                @"IposV3.Views.LineaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.LineaShowViewModel",
                @"IposV3.Views.LineaAddEditView");



            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.CajaAddViewModel",
                @"IposV3.Views.CajaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.CajaEditViewModel",
                @"IposV3.Views.CajaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.CajaShowViewModel",
                @"IposV3.Views.CajaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.PerfilesAddViewModel",
                @"IposV3.Views.PerfilesAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.PerfilesEditViewModel",
                @"IposV3.Views.PerfilesAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.PerfilesShowViewModel",
                @"IposV3.Views.PerfilesAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sucursal_infoAddViewModel",
                @"IposV3.Views.Sucursal_infoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sucursal_infoEditViewModel",
                @"IposV3.Views.Sucursal_infoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sucursal_infoShowViewModel",
                @"IposV3.Views.Sucursal_infoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.UsuarioAddViewModel",
                @"IposV3.Views.UsuarioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.UsuarioEditViewModel",
                @"IposV3.Views.UsuarioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.UsuarioShowViewModel",
                @"IposV3.Views.UsuarioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.GruposucursalAddViewModel",
                @"IposV3.Views.GruposucursalAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.GruposucursalEditViewModel",
                @"IposV3.Views.GruposucursalAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.GruposucursalShowViewModel",
                @"IposV3.Views.GruposucursalAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.GrupousuarioAddViewModel",
                @"IposV3.Views.GrupousuarioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.GrupousuarioEditViewModel",
                @"IposV3.Views.GrupousuarioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.GrupousuarioShowViewModel",
                @"IposV3.Views.GrupousuarioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.MonedaAddViewModel",
                @"IposV3.Views.MonedaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.MonedaEditViewModel",
                @"IposV3.Views.MonedaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.MonedaShowViewModel",
                @"IposV3.Views.MonedaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TasaiepsAddViewModel",
                @"IposV3.Views.TasaiepsAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TasaiepsEditViewModel",
                @"IposV3.Views.TasaiepsAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TasaiepsShowViewModel",
                @"IposV3.Views.TasaiepsAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TasaivaAddViewModel",
                @"IposV3.Views.TasaivaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TasaivaEditViewModel",
                @"IposV3.Views.TasaivaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TasaivaShowViewModel",
                @"IposV3.Views.TasaivaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.UnidadAddViewModel",
                @"IposV3.Views.UnidadAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.UnidadEditViewModel",
                @"IposV3.Views.UnidadAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.UnidadShowViewModel",
                @"IposV3.Views.UnidadAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EstadopaisAddViewModel",
                @"IposV3.Views.EstadopaisAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EstadopaisEditViewModel",
                @"IposV3.Views.EstadopaisAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EstadopaisShowViewModel",
                @"IposV3.Views.EstadopaisAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.SubtipoclienteAddViewModel",
                @"IposV3.Views.SubtipoclienteAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.SubtipoclienteEditViewModel",
                @"IposV3.Views.SubtipoclienteAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.SubtipoclienteShowViewModel",
                @"IposV3.Views.SubtipoclienteAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TiporecargaAddViewModel",
                @"IposV3.Views.TiporecargaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TiporecargaEditViewModel",
                @"IposV3.Views.TiporecargaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TiporecargaShowViewModel",
                @"IposV3.Views.TiporecargaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.FormapagosatAddViewModel",
                @"IposV3.Views.FormapagosatAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.FormapagosatEditViewModel",
                @"IposV3.Views.FormapagosatAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.FormapagosatShowViewModel",
                @"IposV3.Views.FormapagosatAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_aduanaAddViewModel",
                @"IposV3.Views.Sat_aduanaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_aduanaEditViewModel",
                @"IposV3.Views.Sat_aduanaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_aduanaShowViewModel",
                @"IposV3.Views.Sat_aduanaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_claveunidadpesoAddViewModel",
                @"IposV3.Views.Sat_claveunidadpesoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_claveunidadpesoEditViewModel",
                @"IposV3.Views.Sat_claveunidadpesoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_claveunidadpesoShowViewModel",
                @"IposV3.Views.Sat_claveunidadpesoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_coloniaAddViewModel",
                @"IposV3.Views.Sat_coloniaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_coloniaEditViewModel",
                @"IposV3.Views.Sat_coloniaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_coloniaShowViewModel",
                @"IposV3.Views.Sat_coloniaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_localidadAddViewModel",
                @"IposV3.Views.Sat_localidadAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_localidadEditViewModel",
                @"IposV3.Views.Sat_localidadAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_localidadShowViewModel",
                @"IposV3.Views.Sat_localidadAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_matpeligrosoAddViewModel",
                @"IposV3.Views.Sat_matpeligrosoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_matpeligrosoEditViewModel",
                @"IposV3.Views.Sat_matpeligrosoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_matpeligrosoShowViewModel",
                @"IposV3.Views.Sat_matpeligrosoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_metodopagoAddViewModel",
                @"IposV3.Views.Sat_metodopagoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_metodopagoEditViewModel",
                @"IposV3.Views.Sat_metodopagoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_metodopagoShowViewModel",
                @"IposV3.Views.Sat_metodopagoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_municipioAddViewModel",
                @"IposV3.Views.Sat_municipioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_municipioEditViewModel",
                @"IposV3.Views.Sat_municipioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_municipioShowViewModel",
                @"IposV3.Views.Sat_municipioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_paisAddViewModel",
                @"IposV3.Views.Sat_paisAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_paisEditViewModel",
                @"IposV3.Views.Sat_paisAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_paisShowViewModel",
                @"IposV3.Views.Sat_paisAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_productoservicioAddViewModel",
                @"IposV3.Views.Sat_productoservicioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_productoservicioEditViewModel",
                @"IposV3.Views.Sat_productoservicioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_productoservicioShowViewModel",
                @"IposV3.Views.Sat_productoservicioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_regimenfiscalAddViewModel",
                @"IposV3.Views.Sat_regimenfiscalAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_regimenfiscalEditViewModel",
                @"IposV3.Views.Sat_regimenfiscalAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_regimenfiscalShowViewModel",
                @"IposV3.Views.Sat_regimenfiscalAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_tipoembalajeAddViewModel",
                @"IposV3.Views.Sat_tipoembalajeAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_tipoembalajeEditViewModel",
                @"IposV3.Views.Sat_tipoembalajeAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_tipoembalajeShowViewModel",
                @"IposV3.Views.Sat_tipoembalajeAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_unidadmedidaAddViewModel",
                @"IposV3.Views.Sat_unidadmedidaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_unidadmedidaEditViewModel",
                @"IposV3.Views.Sat_unidadmedidaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_unidadmedidaShowViewModel",
                @"IposV3.Views.Sat_unidadmedidaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_usocfdiAddViewModel",
                @"IposV3.Views.Sat_usocfdiAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_usocfdiEditViewModel",
                @"IposV3.Views.Sat_usocfdiAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_usocfdiShowViewModel",
                @"IposV3.Views.Sat_usocfdiAddEditView");


            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_tipopermisoAddViewModel",
                @"IposV3.Views.Sat_tipopermisoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_tipopermisoEditViewModel",
                @"IposV3.Views.Sat_tipopermisoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_tipopermisoShowViewModel",
                @"IposV3.Views.Sat_tipopermisoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EstadocobranzaAddViewModel",
                @"IposV3.Views.EstadocobranzaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EstadocobranzaEditViewModel",
                @"IposV3.Views.EstadocobranzaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EstadocobranzaShowViewModel",
                @"IposV3.Views.EstadocobranzaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EstadopagocontrareciboAddViewModel",
                @"IposV3.Views.EstadopagocontrareciboAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EstadopagocontrareciboEditViewModel",
                @"IposV3.Views.EstadopagocontrareciboAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EstadopagocontrareciboShowViewModel",
                @"IposV3.Views.EstadopagocontrareciboAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ClienteAddViewModel",
                @"IposV3.Views.ClienteAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ClienteEditViewModel",
                @"IposV3.Views.ClienteAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ClienteShowViewModel",
                @"IposV3.Views.ClienteAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ProductoAddViewModel",
                @"IposV3.Views.ProductoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ProductoEditViewModel",
                @"IposV3.Views.ProductoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ProductoShowViewModel",
                @"IposV3.Views.ProductoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ProveedorAddViewModel",
                @"IposV3.Views.ProveedorAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ProveedorEditViewModel",
                @"IposV3.Views.ProveedorAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ProveedorShowViewModel",
                @"IposV3.Views.ProveedorAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipotransaccionAddViewModel",
                @"IposV3.Views.TipotransaccionAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipotransaccionEditViewModel",
                @"IposV3.Views.TipotransaccionAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipotransaccionShowViewModel",
                @"IposV3.Views.TipotransaccionAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ClerkpagoservicioAddViewModel",
                @"IposV3.Views.ClerkpagoservicioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ClerkpagoservicioEditViewModel",
                @"IposV3.Views.ClerkpagoservicioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ClerkpagoservicioShowViewModel",
                @"IposV3.Views.ClerkpagoservicioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EmidaproductAddViewModel",
                @"IposV3.Views.EmidaproductAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EmidaproductEditViewModel",
                @"IposV3.Views.EmidaproductAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EmidaproductShowViewModel",
                @"IposV3.Views.EmidaproductAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.MerchantpagoservicioAddViewModel",
                @"IposV3.Views.MerchantpagoservicioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.MerchantpagoservicioEditViewModel",
                @"IposV3.Views.MerchantpagoservicioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.MerchantpagoservicioShowViewModel",
                @"IposV3.Views.MerchantpagoservicioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TerminalpagoservicioAddViewModel",
                @"IposV3.Views.TerminalpagoservicioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TerminalpagoservicioEditViewModel",
                @"IposV3.Views.TerminalpagoservicioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TerminalpagoservicioShowViewModel",
                @"IposV3.Views.TerminalpagoservicioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.GastoadicionalAddViewModel",
                @"IposV3.Views.GastoadicionalAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.GastoadicionalEditViewModel",
                @"IposV3.Views.GastoadicionalAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.GastoadicionalShowViewModel",
                @"IposV3.Views.GastoadicionalAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EstadoguiaAddViewModel",
                @"IposV3.Views.EstadoguiaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EstadoguiaEditViewModel",
                @"IposV3.Views.EstadoguiaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EstadoguiaShowViewModel",
                @"IposV3.Views.EstadoguiaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipoentregaAddViewModel",
                @"IposV3.Views.TipoentregaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipoentregaEditViewModel",
                @"IposV3.Views.TipoentregaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipoentregaShowViewModel",
                @"IposV3.Views.TipoentregaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.AlmacenAddViewModel",
                @"IposV3.Views.AlmacenAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.AlmacenEditViewModel",
                @"IposV3.Views.AlmacenAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.AlmacenShowViewModel",
                @"IposV3.Views.AlmacenAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.AnaquelAddViewModel",
                @"IposV3.Views.AnaquelAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.AnaquelEditViewModel",
                @"IposV3.Views.AnaquelAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.AnaquelShowViewModel",
                @"IposV3.Views.AnaquelAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.GrupodiferenciainventarioAddViewModel",
                @"IposV3.Views.GrupodiferenciainventarioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.GrupodiferenciainventarioEditViewModel",
                @"IposV3.Views.GrupodiferenciainventarioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.GrupodiferenciainventarioShowViewModel",
                @"IposV3.Views.GrupodiferenciainventarioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipodiferenciainventarioAddViewModel",
                @"IposV3.Views.TipodiferenciainventarioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipodiferenciainventarioEditViewModel",
                @"IposV3.Views.TipodiferenciainventarioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipodiferenciainventarioShowViewModel",
                @"IposV3.Views.TipodiferenciainventarioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.MensajenivelurgenciaAddViewModel",
                @"IposV3.Views.MensajenivelurgenciaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.MensajenivelurgenciaEditViewModel",
                @"IposV3.Views.MensajenivelurgenciaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.MensajenivelurgenciaShowViewModel",
                @"IposV3.Views.MensajenivelurgenciaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.BancoAddViewModel",
                @"IposV3.Views.BancoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.BancoEditViewModel",
                @"IposV3.Views.BancoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.BancoShowViewModel",
                @"IposV3.Views.BancoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.FormapagoAddViewModel",
                @"IposV3.Views.FormapagoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.FormapagoEditViewModel",
                @"IposV3.Views.FormapagoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.FormapagoShowViewModel",
                @"IposV3.Views.FormapagoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Motivo_camfecAddViewModel",
                @"IposV3.Views.Motivo_camfecAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Motivo_camfecEditViewModel",
                @"IposV3.Views.Motivo_camfecAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Motivo_camfecShowViewModel",
                @"IposV3.Views.Motivo_camfecAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.CuentaAddViewModel",
                @"IposV3.Views.CuentaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.CuentaEditViewModel",
                @"IposV3.Views.CuentaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.CuentaShowViewModel",
                @"IposV3.Views.CuentaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.CuentabancoAddViewModel",
                @"IposV3.Views.CuentabancoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.CuentabancoEditViewModel",
                @"IposV3.Views.CuentabancoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.CuentabancoShowViewModel",
                @"IposV3.Views.CuentabancoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.PlazoAddViewModel",
                @"IposV3.Views.PlazoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.PlazoEditViewModel",
                @"IposV3.Views.PlazoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.PlazoShowViewModel",
                @"IposV3.Views.PlazoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipolineapolizaAddViewModel",
                @"IposV3.Views.TipolineapolizaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipolineapolizaEditViewModel",
                @"IposV3.Views.TipolineapolizaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipolineapolizaShowViewModel",
                @"IposV3.Views.TipolineapolizaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.CamporeferenciaprecioAddViewModel",
                @"IposV3.Views.CamporeferenciaprecioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.CamporeferenciaprecioEditViewModel",
                @"IposV3.Views.CamporeferenciaprecioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.CamporeferenciaprecioShowViewModel",
                @"IposV3.Views.CamporeferenciaprecioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipodescuentoprodAddViewModel",
                @"IposV3.Views.TipodescuentoprodAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipodescuentoprodEditViewModel",
                @"IposV3.Views.TipodescuentoprodAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipodescuentoprodShowViewModel",
                @"IposV3.Views.TipodescuentoprodAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipoutilidadAddViewModel",
                @"IposV3.Views.TipoutilidadAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipoutilidadEditViewModel",
                @"IposV3.Views.TipoutilidadAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipoutilidadShowViewModel",
                @"IposV3.Views.TipoutilidadAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.PromocionAddViewModel",
                @"IposV3.Views.PromocionAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.PromocionEditViewModel",
                @"IposV3.Views.PromocionAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.PromocionShowViewModel",
                @"IposV3.Views.PromocionAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.RangopromocionAddViewModel",
                @"IposV3.Views.RangopromocionAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.RangopromocionEditViewModel",
                @"IposV3.Views.RangopromocionAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.RangopromocionShowViewModel",
                @"IposV3.Views.RangopromocionAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipopromocionAddViewModel",
                @"IposV3.Views.TipopromocionAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipopromocionEditViewModel",
                @"IposV3.Views.TipopromocionAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.TipopromocionShowViewModel",
                @"IposV3.Views.TipopromocionAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ClasificaAddViewModel",
                @"IposV3.Views.ClasificaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ClasificaEditViewModel",
                @"IposV3.Views.ClasificaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ClasificaShowViewModel",
                @"IposV3.Views.ClasificaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ContenidoAddViewModel",
                @"IposV3.Views.ContenidoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ContenidoEditViewModel",
                @"IposV3.Views.ContenidoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ContenidoShowViewModel",
                @"IposV3.Views.ContenidoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ReportesAddViewModel",
                @"IposV3.Views.ReportesAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ReportesEditViewModel",
                @"IposV3.Views.ReportesAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ReportesShowViewModel",
                @"IposV3.Views.ReportesAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.RutaembarqueAddViewModel",
                @"IposV3.Views.RutaembarqueAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.RutaembarqueEditViewModel",
                @"IposV3.Views.RutaembarqueAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.RutaembarqueShowViewModel",
                @"IposV3.Views.RutaembarqueAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Motivo_devolucionAddViewModel",
                @"IposV3.Views.Motivo_devolucionAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Motivo_devolucionEditViewModel",
                @"IposV3.Views.Motivo_devolucionAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Motivo_devolucionShowViewModel",
                @"IposV3.Views.Motivo_devolucionAddEditView");


            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ParametroAddViewModel",
                @"IposV3.Views.ParametroAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ParametroEditViewModel",
                @"IposV3.Views.ParametroAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ParametroShowViewModel",
                @"IposV3.Views.ParametroAddEditView");


            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.VendedorAddViewModel",
                @"IposV3.Views.VendedorAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.VendedorEditViewModel",
                @"IposV3.Views.VendedorAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.VendedorShowViewModel",
                @"IposV3.Views.VendedorAddEditView");



            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EncargadoguiaAddViewModel",
                @"IposV3.Views.EncargadoguiaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EncargadoguiaEditViewModel",
                @"IposV3.Views.EncargadoguiaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EncargadoguiaShowViewModel",
                @"IposV3.Views.EncargadoguiaAddEditView");


            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EncargadogcorteAddViewModel",
                @"IposV3.Views.EncargadocorteAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EncargadocorteEditViewModel",
                @"IposV3.Views.EncargadocorteAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.EncargadocorteShowViewModel",
                @"IposV3.Views.EncargadocorteAddEditView");


            //@"IposV3.ViewModels.ConfiguracionAddViewModel", //addviewmodel
            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ConfiguracionAddViewModel", //addviewmodel
                @"IposV3.Views.ConfiguracionAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ConfiguracionEditViewModel",
                @"IposV3.Views.ConfiguracionAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ConfiguracionShowViewModel",
                @"IposV3.Views.ConfiguracionAddEditView");



            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.VehiculoAddViewModel", //addviewmodel
                @"IposV3.Views.VehiculoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.VehiculoEditViewModel",
                @"IposV3.Views.VehiculoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.VehiculoShowViewModel",
                @"IposV3.Views.VehiculoAddEditView");


            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_subtiporemAddViewModel",
                @"IposV3.Views.Sat_subtiporemAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_subtiporemEditViewModel",
                @"IposV3.Views.Sat_subtiporemAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_subtiporemShowViewModel",
                @"IposV3.Views.Sat_subtiporemAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_configautotransporteAddViewModel",
                @"IposV3.Views.Sat_configautotransporteAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_configautotransporteEditViewModel",
                @"IposV3.Views.Sat_configautotransporteAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.Sat_configautotransporteShowViewModel",
                @"IposV3.Views.Sat_configautotransporteAddEditView");


            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.MaxfactAddViewModel",
                @"IposV3.Views.MaxfactAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.MaxfactEditViewModel",
                @"IposV3.Views.MaxfactAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.MaxfactShowViewModel",
                @"IposV3.Views.MaxfactAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.AreaAddViewModel",
                @"IposV3.Views.AreaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.AreaEditViewModel",
                @"IposV3.Views.AreaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.AreaShowViewModel",
                @"IposV3.Views.AreaAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ListaprecioAddViewModel",
                @"IposV3.Views.ListaprecioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ListaprecioEditViewModel",
                @"IposV3.Views.ListaprecioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ListaprecioShowViewModel",
                @"IposV3.Views.ListaprecioAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.GastoAddViewModel",
                @"IposV3.Views.GastoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.GastoEditViewModel",
                @"IposV3.Views.GastoAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.GastoShowViewModel",
                @"IposV3.Views.GastoAddEditView");


            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ProductolocationsAddViewModel",
                @"IposV3.Views.ProductolocationsAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ProductolocationsEditViewModel",
                @"IposV3.Views.ProductolocationsAddEditView");

            ViewLocator.NameTransformer.AddRule(
                @"IposV3.ViewModels.ProductolocationsShowViewModel",
                @"IposV3.Views.ProductolocationsAddEditView");


            MessageBinder.SpecialValues.Add("$pressedkey", (context) =>
            {
                // NOTE: IMPORTANT - you MUST add the dictionary key as lowercase as CM
                // does a ToLower on the param string you add in the action message, in fact ideally
                // all your param messages should be lowercase just in case. I don't really like this
                // behaviour but that's how it is!
                var keyArgs = context.EventArgs as System.Windows.Input.KeyEventArgs;

                if (keyArgs != null)
                    return keyArgs.Key;

                return null;
            });

        }




        //public void MigrateDataBase()
        //{
        //    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        //    var _context = IoC.Get<ApplicationDbContext>();
        //    var _contextFactory = IoC.Get<OperationsContextFactory>();

        //    var configuracionProvider = IoC.Get<ConfiguracionController>();
        //    Configuracion? defaultConfig = configuracionProvider?.GetDefaultConfiguracion();
        //    if(defaultConfig != null)
        //    {
        //        _context.Database.CloseConnection();
        //        _context.ConnectionString = "Server=" + defaultConfig.Servidor + ";Port=" + defaultConfig.Puerto + ";Database=" + defaultConfig.Database + ";Uid=" + defaultConfig.Usuario + ";Pwd=" + defaultConfig.Password + ";";
        //        _context.Database.SetConnectionString(_context.ConnectionString);

        //        _contextFactory.ConnectionString = "Server=" + defaultConfig.Servidor + ";Port=" + defaultConfig.Puerto + ";Database=" + defaultConfig.Database + ";Uid=" + defaultConfig.Usuario + ";Pwd=" + defaultConfig.Password + ";";
                

                
        //    }


        //    var migrationsJustApplied = _context.Database.GetPendingMigrations().ToList();
        //    _context.Database.Migrate();


        //    IposV3.Migrations.Seed.MigrationService.RunSpecialMigrationProcesses(_context, migrationsJustApplied);

        //}







        public static string GetGeneralConnectionString()
        {

            System.Configuration.Configuration _config =
             ConfigurationManager.OpenExeConfiguration(
             ConfigurationUserLevel.None);
            return _config.ConnectionStrings.ConnectionStrings["WpfIpos.Properties.Settings.ConnectionIpos"].ConnectionString; 


        }

        protected override object GetInstance(Type service, string key) {
            return string.IsNullOrWhiteSpace(key)
                ? container!.Resolve(service)
                : container!.Resolve(key, service);
        }

        private void RegisterViewModels() {
            //container.Register(Classes.FromAssembly(typeof (MainViewModel).Assembly)
            //    .Where(x => x.Name.EndsWith("ViewModel"))
            //    .Configure(x => x.LifeStyle.Is(LifestyleType.Transient)));

            container!.Register(Classes.FromAssembly(typeof(MainWindowViewModel).Assembly)
                .Where(x => x.Name.EndsWith("ViewModel"))
                .Configure(x => x.LifeStyle.Is(LifestyleType.Transient)));



        }

        private void RegisterServices()
        {

            //container!.Register(Classes.FromAssembly(typeof(UsuarioService).Assembly)
            //    .Where(x => x.Name.EndsWith("Service"))
            //    .Configure(x => x.LifeStyle.Is(LifestyleType.Transient)));



        }

        protected override void OnStartup(object sender, StartupEventArgs e) {

            //IposV3.Services.FirebirdMigrationHelper.FirebirdPreparaciones();
            //MigrateDataBase();
            DisplayRootViewForAsync<MainWindowViewModel>();
        }
    }

    public class AppSettingsConvention : ISubDependencyResolver {
        public bool CanResolve(
            CreationContext context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel model,
            DependencyModel dependency) {
            return ConfigurationManager.AppSettings.AllKeys
                .Contains(dependency.DependencyKey)
                   && TypeDescriptor
                       .GetConverter(dependency.TargetType)
                       .CanConvertFrom(typeof (string));
        }

        public object Resolve(
            CreationContext context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel model,
            DependencyModel dependency) {
            return TypeDescriptor
                .GetConverter(dependency.TargetType)
                .ConvertFrom(
                    ConfigurationManager.AppSettings[dependency.DependencyKey] ?? new object()) ?? new object();
        }
    }


}