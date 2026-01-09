using DataAccess;
using IposV3.Model;
using Microsoft.EntityFrameworkCore;
using System;
using IposV3.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IposV3.BindingModel;
using BindingModels;

namespace IposV3.Controllers.Controller
{
    public class GlobalController
    {



        private IDbContextFactory<ApplicationDbContext> _operationsContextFactory;
        public GlobalController(
                                IDbContextFactory<ApplicationDbContext> operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
        }

        public void llenarSesionPorConfiguracion(Configuracion config,
                                                 IDbContextFactory<ApplicationDbContext>? operationsContextFactory,
                                                ref GlobalSession globalSession)
        {
            if(operationsContextFactory !=  null)
                _operationsContextFactory = operationsContextFactory;

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();


            if (config != null)
            {

                var dbEmpresa = applicationDbContext.Empresa.FirstOrDefault(y => y.Id == config.Empresaid);
                globalSession.CurrentEmpresa = dbEmpresa != null ? new EmpresaBindingModel(dbEmpresa) : null;

                var dbSucursal = applicationDbContext.Sucursal.FirstOrDefault(y => y.Id == config.Sucursalid && y.EmpresaId == config.Empresaid);
                globalSession.CurrentSucursal = dbSucursal != null ? new SucursalBindingModel(dbSucursal) : null;
                
                var dbParametro = applicationDbContext.Parametro.Include(c => c.Lista_precio_def)
                                              .Include(c => c.Listaprecioinimayo_)
                                              .Include(c => c.Tipodescuentoprod)
                                              .Include(c => c.Agrupacionventa)
                                              .Include(c => c.Precioajustedifinv)
                                              .Include(c => c.Encargado)
                                              .Include(c => c.Listaprecioxuempaque_)
                                              .Include(c => c.Listaprecioxpzacaja_)
                                              .Include(c => c.Tipoutilidad)
                                              .Include(c => c.Listapreciominimo_)
                                              .Include(c => c.Almacenrecepcion)
                                              .Include(c => c.Campoimpocostorepo)
                                              .Include(c => c.Clienteconsolidado)
                                              .Include(c => c.Sat_metodopago)
                                              .Include(c => c.Sat_regimenfiscal)
                                              .Include(c => c.Monederolistaprecio)
                                              .Include(c => c.Vendedormovil)
                                              .Include(c => c.Emidarecargalinea)
                                              .Include(c => c.Emidarecargamarca)
                                              .Include(c => c.Emidarecargaproveedor)
                                              .Include(c => c.Emidaserviciolinea)
                                              .Include(c => c.Emidaserviciomarca)
                                              .Include(c => c.Emidaservicioproveedor)
                                              .Include(c => c.Ultmensaje)
                                              .Include(c => c.Listapreciomaylinea_)
                                              .Include(c => c.Listapremedmaylinea_)
                                              .AsNoTracking().
                                              FirstOrDefault(y => y.EmpresaId == config.Empresaid && y.SucursalId == config.Sucursalid);
                globalSession.CurrentParametro = dbParametro != null ? new ParametroBindingModel(dbParametro) : null;

                
                var claveSucursal = globalSession!.CurrentSucursal?.Clave;


                var dbSucursalInfo = applicationDbContext.Sucursal_info
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(d => d.Gruposucursal)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(d => d.Cliente)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(d => d.Proveedor)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(d => d.Banco)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(d => d.Empprov)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_fact_elect).ThenInclude(d => d.Entregaestado)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_fact_elect).ThenInclude(d => d.Entrega_Sat_Colonia)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_fact_elect).ThenInclude(d => d.Entrega_Sat_Localidad)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_fact_elect).ThenInclude(d => d.Entrega_Sat_Municipio)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_importacion).ThenInclude(d => d.Listaprecio)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_importacion).ThenInclude(d => d.Surtidor)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_respaldo)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_traslado).ThenInclude(d => d.Preciorecepciontraslado_)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_traslado).ThenInclude(d => d.Precioenviotraslado_)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_traslado).ThenInclude(d => d.Lista_precio_traspaso_)
                                              .AsNoTracking()
                                              .Where(p => p.EmpresaId == config.Empresaid && p.SucursalId == config.Sucursalid &&
                                                                    p.Clave == claveSucursal).FirstOrDefault();
                globalSession.CurrentSucursalInfo = dbSucursalInfo != null ? new Sucursal_infoBindingModel(dbSucursalInfo) : null;

                if (config.Cajaid != null)
                {
                    var dbCaja = applicationDbContext.Caja.Include(c => c.Caja_bancomer)
                                                          .Include(c => c.Caja_emida).ThenInclude(d => d.Terminal)
                                                          .Include(c => c.Caja_emida).ThenInclude(d => d.Terminalservicios)
                                                          .AsNoTracking()
                                                          .FirstOrDefault(y => y.EmpresaId == config.Empresaid && y.SucursalId == config.Sucursalid && y.Id == config.Cajaid.Value);
                    globalSession.CurrentCaja = dbCaja != null ? new CajaBindingModel(dbCaja) : null;
                }
                else
                    globalSession.CurrentCaja = null;

                globalSession.CurrentConfiguracion = config;

                globalSession.CurrentLookups = applicationDbContext.Lookup.AsNoTracking().Where(y => y.EmpresaId == config.Empresaid && y.SucursalId == config.Sucursalid).Select(m => new LookupBindingModel(m)).ToList();


            }

        }


        public void llenarSesionPorConfiguracionsync(Configuracionsync configsync, ref GlobalSession globalSession)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();


            if (configsync != null)
            {
                var dbEmpresa = applicationDbContext.Empresa.FirstOrDefault(y => y.Id == configsync.EmpresaId);
                globalSession.CurrentEmpresa = dbEmpresa != null ? new EmpresaBindingModel(dbEmpresa) : null;

                var dbSucursal = applicationDbContext.Sucursal.FirstOrDefault(y => y.Id == configsync.SucursalId && y.EmpresaId == configsync.EmpresaId);
                globalSession.CurrentSucursal = dbSucursal != null ? new SucursalBindingModel(dbSucursal) : null;

                var dbParametro = applicationDbContext.Parametro.Include(c => c.Lista_precio_def)
                                              .Include(c => c.Listaprecioinimayo_)
                                              .Include(c => c.Tipodescuentoprod)
                                              .Include(c => c.Agrupacionventa)
                                              .Include(c => c.Precioajustedifinv)
                                              .Include(c => c.Encargado)
                                              .Include(c => c.Listaprecioxuempaque_)
                                              .Include(c => c.Listaprecioxpzacaja_)
                                              .Include(c => c.Tipoutilidad)
                                              .Include(c => c.Listapreciominimo_)
                                              .Include(c => c.Almacenrecepcion)
                                              .Include(c => c.Campoimpocostorepo)
                                              .Include(c => c.Clienteconsolidado)
                                              .Include(c => c.Sat_metodopago)
                                              .Include(c => c.Sat_regimenfiscal)
                                              .Include(c => c.Monederolistaprecio)
                                              .Include(c => c.Vendedormovil)
                                              .Include(c => c.Emidarecargalinea)
                                              .Include(c => c.Emidarecargamarca)
                                              .Include(c => c.Emidarecargaproveedor)
                                              .Include(c => c.Emidaserviciolinea)
                                              .Include(c => c.Emidaserviciomarca)
                                              .Include(c => c.Emidaservicioproveedor)
                                              .Include(c => c.Ultmensaje)
                                              .Include(c => c.Listapreciomaylinea_)
                                              .Include(c => c.Listapremedmaylinea_)
                                              .AsNoTracking()
                                              .FirstOrDefault(y => y.EmpresaId == configsync.EmpresaId && y.SucursalId == configsync.SucursalId);
                globalSession.CurrentParametro = dbParametro != null ? new ParametroBindingModel(dbParametro) : null;


                var claveSucursal = globalSession!.CurrentSucursal?.Clave;


                var dbSucursalInfo = applicationDbContext.Sucursal_info
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(d => d.Gruposucursal)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(d => d.Cliente)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(d => d.Proveedor)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(d => d.Banco)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(d => d.Empprov)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_fact_elect).ThenInclude(d => d.Entregaestado)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_fact_elect).ThenInclude(d => d.Entrega_Sat_Colonia)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_fact_elect).ThenInclude(d => d.Entrega_Sat_Localidad)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_fact_elect).ThenInclude(d => d.Entrega_Sat_Municipio)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_importacion).ThenInclude(d => d.Listaprecio)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_importacion).ThenInclude(d => d.Surtidor)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_respaldo)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_traslado).ThenInclude(d => d.Preciorecepciontraslado_)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_traslado).ThenInclude(d => d.Precioenviotraslado_)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_traslado).ThenInclude(d => d.Lista_precio_traspaso_)
                                              .AsNoTracking()
                                              .Where(p => p.EmpresaId == configsync.EmpresaId && p.SucursalId == configsync.SucursalId &&
                                                                    p.Clave == claveSucursal).FirstOrDefault();
                globalSession.CurrentSucursalInfo = dbSucursalInfo != null ? new Sucursal_infoBindingModel(dbSucursalInfo) : null;



            }

        }


        public void llenarSesionUsuario(ConfiguracionBindingModel config, ref GlobalSession globalSession)
        {


            if (config.Usuarioid != null)
            {
                using var applicationDbContext = this._operationsContextFactory.CreateDbContext();
                globalSession.FillUsuarioConfiguration(applicationDbContext,config.Empresaid, config.Sucursalid, config.Usuarioid);

            }
        }


        public void llenarProductAutoCompleteList(BaseParam param, ref GlobalSession? globalSession)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            if (globalSession == null)
                return;

            if (globalSession.ListadoAutoCompleteProd != null && globalSession.ListadoAutoCompleteProd.Count > 0)
            {
                return;
            }

            globalSession.ListadoAutoCompleteProd = applicationDbContext.Producto.Where(p =>
                                                    p.EmpresaId == param.P_empresaid && p.SucursalId == param.P_sucursalid && 
                                                    p.Activo == BoolCS.S)
                                                   .AsNoTracking()
                                                   .Select(y => new BindingModels.ProductoAutocompleteBindingModel(y)).ToList();


        }


        public void llenarClienteAutoCompleteList(BaseParam param, ref GlobalSession? globalSession)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            if (globalSession == null)
                return;

            if (globalSession.ListadoAutoCompleteCliente != null && globalSession.ListadoAutoCompleteCliente.Count > 0)
            {
                return;
            }

            globalSession.ListadoAutoCompleteCliente = applicationDbContext.Cliente.Where(p => 
                                                    p.EmpresaId == param.P_empresaid && p.SucursalId == param.P_sucursalid &&
                                                    p.Activo == BoolCS.S)
                                                   .AsNoTracking()
                                                   .Select(y => new BindingModels.ClienteAutocompleteBindingModel(y)).ToList();


        }



    }
}
