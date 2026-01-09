using Controllers.Controller;
using FastReport.Data;
using IposV3.Controllers.Controller;
using IposV3.Controllers.Controller.Utils;
using IposV3.Model;
using IposV3.Services;
using IposV3WebAPI.Services;
using IposV3WebAPI.Services.S3;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options
                    .UseLazyLoadingProxies()
                    //.UseLoggerFactory(dbLoggerFactory)
                    .UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContextFactory<ApplicationDbContext>(options =>
                options
                    .UseLazyLoadingProxies()
                    //.UseLoggerFactory(dbLoggerFactory)
                    .UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));


            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


            services.AddControllers();

            // Services 
            services.AddScoped<S3Service>();
            services.AddScoped<TestingService>();


            //internal controllers

            services.AddScoped<CatalogSelector>();

            services.AddScoped<SelectorController>();

            services.AddScoped<UnidadController>();

            services.AddScoped<GruposucursalController>();

            services.AddScoped<CajaController>();

            services.AddScoped<ParametroController>();

            services.AddScoped<PerfilesController>();

            services.AddScoped<Sucursal_infoController>();

            services.AddScoped<UsuarioController>();

            services.AddScoped<VehiculoController>();

            services.AddScoped<GruposucursalController>();

            services.AddScoped<GrupousuarioController>();

            services.AddScoped<LineaController>();

            services.AddScoped<MarcaController>();

            services.AddScoped<MonedaController>();

            services.AddScoped<TasaiepsController>();

            services.AddScoped<TasaivaController>();

            services.AddScoped<UnidadController>();

            services.AddScoped<EstadopaisController>();

            services.AddScoped<SubtipoclienteController>();

            services.AddScoped<TiporecargaController>();

            services.AddScoped<FormapagosatController>();

            services.AddScoped<Sat_aduanaController>();

            services.AddScoped<Sat_claveunidadpesoController>();

            services.AddScoped<Sat_coloniaController>();

            services.AddScoped<Sat_configautotransporteController>();

            services.AddScoped<Sat_figuratransporteController>();

            services.AddScoped<Sat_localidadController>();

            services.AddScoped<Sat_matpeligrosoController>();

            services.AddScoped<Sat_metodopagoController>();

            services.AddScoped<Sat_municipioController>();

            services.AddScoped<Sat_paisController>();

            services.AddScoped<Sat_partetransporteController>();

            services.AddScoped<Sat_productoservicioController>();

            services.AddScoped<Sat_regimenfiscalController>();

            services.AddScoped<Sat_subtiporemController>();

            services.AddScoped<Sat_tipoembalajeController>();

            services.AddScoped<Sat_tipopermisoController>();

            services.AddScoped<Sat_unidadmedidaController>();

            services.AddScoped<Sat_usocfdiController>();

            services.AddScoped<EstadocobranzaController>();

            services.AddScoped<ConfiguracionController>();

            services.AddScoped<EstadopagocontrareciboController>();

            services.AddScoped<ClienteController>();

            services.AddScoped<DoctoController>();

            services.AddScoped<MovtoController>();

            services.AddScoped<ProductoController>();

            services.AddScoped<ProveedorController>();

            services.AddScoped<CorteController>();

            services.AddScoped<TipotransaccionController>();

            services.AddScoped<ClerkpagoservicioController>();

            services.AddScoped<EmidaproductController>();

            services.AddScoped<MerchantpagoservicioController>();

            services.AddScoped<TerminalpagoservicioController>();

            services.AddScoped<MaxfactController>();

            services.AddScoped<GastoadicionalController>();

            services.AddScoped<GastoController>();

            services.AddScoped<MovtogastosadicController>();

            services.AddScoped<EstadoguiaController>();

            services.AddScoped<GuiaController>();

            services.AddScoped<TipoentregaController>();

            services.AddScoped<AlmacenController>();

            services.AddScoped<AnaquelController>();

            services.AddScoped<GrupodiferenciainventarioController>();

            services.AddScoped<LotesimportadosController>();

            services.AddScoped<ProductolocationsController>();

            services.AddScoped<TipodiferenciainventarioController>();

            services.AddScoped<KitdefinicionController>();

            services.AddScoped<AreaController>();

            services.AddScoped<MensajenivelurgenciaController>();

            services.AddScoped<PagoController>();

            services.AddScoped<BancoController>();

            services.AddScoped<FormapagoController>();

            services.AddScoped<Motivo_camfecController>();

            services.AddScoped<CuentabancoController>();

            services.AddScoped<CuentaController>();

            services.AddScoped<PlazoController>();

            services.AddScoped<TipolineapolizaController>();

            services.AddScoped<PromocionController>();

            services.AddScoped<RangopromocionController>();

            services.AddScoped<TipopromocionController>();

            services.AddScoped<ClasificaController>();

            services.AddScoped<ContenidoController>();

            services.AddScoped<ReportesController>();

            services.AddScoped<RutaembarqueController>();

            services.AddScoped<Motivo_devolucionController>();


            services.AddScoped<PuntoCompraController>();

            services.AddScoped<PuntoCompraDevoController>();

            services.AddScoped<PuntoVentaController>();

            services.AddScoped<PuntoVentaDevoController>();

            services.AddScoped<CfdiController>();

            services.AddScoped<ConsolidadoController>();

            services.AddScoped<InventarioController>();

            services.AddScoped<LoteController>();

            services.AddScoped<MenuitemsController>();

            services.AddScoped<PuntoPedidoEntradaController>();

            services.AddScoped<PuntoTrasladoRecepcionController>();

            services.AddScoped<PuntoSolicitudMercanciaController>();

            services.AddScoped<CamporeferenciaprecioController>();

            services.AddScoped<ListaprecioController>();

            services.AddScoped<TipodescuentoprodController>();

            services.AddScoped<TipoutilidadController>();

            services.AddScoped<GlobalController>();


            services.AddScoped<KitdefinicionService>();

            services.AddScoped<DoctoService>();

            services.AddScoped<MovtoService>();

            services.AddScoped<DoctoMovtoService>();

            services.AddScoped<ImpuestosService>();

            services.AddScoped<ProveeduriaService>();


            services.AddScoped<ProvDevoService>();


            services.AddScoped<TrasladoRecepcionService>();


            services.AddScoped<SolicitudMercanciaService>();


            services.AddScoped<PedidoEntradaService>();

            services.AddScoped<VendeduriaService>();


            services.AddScoped<VenddevoService>();

            services.AddScoped<CorteService>();

            services.AddScoped<MaestroConsecutivoService>();

            services.AddScoped<InventarioService>();

            services.AddScoped<PagoService>();

            services.AddScoped<PagosFacturaElectronicaService>();

            services.AddScoped<UsuarioService>();

            services.AddScoped<FacturaElectronicaService>();

            services.AddScoped<CartaporteFacturaElectronicaService>();


            services.AddScoped<InventarioOperativoService>();

            services.AddScoped<ConsolidacionService>();

            services.AddScoped<PuntoVenta_ApiAux>();

            services.AddScoped<PuntoCompra_ApiAux>();

            services.AddScoped<PuntoVentaDevo_ApiAux>();

            services.AddScoped<PuntoCompraDevo_ApiAux>();


            services.AddScoped<ProductoService>();

            services.AddFastReport();
            FastReport.Utils.RegisteredObjects.AddConnection(typeof(PostgresDataConnection));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseFastReport();
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
