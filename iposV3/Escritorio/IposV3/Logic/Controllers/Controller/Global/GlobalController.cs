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



        private OperationsContextFactory _operationsContextFactory;
        public GlobalController(
                                OperationsContextFactory operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
        }

        public void llenarSesionPorConfiguracion(Configuracion config, 
                                                 OperationsContextFactory? operationsContextFactory,
                                                ref GlobalSession globalSession)
        {
            if(operationsContextFactory !=  null)
                _operationsContextFactory = operationsContextFactory;

            using var applicationDbContext = this._operationsContextFactory.Create();


            if (config != null)
            {
                var dbEmpresa = applicationDbContext.Empresa.FirstOrDefault(y => y.Id == config.Empresaid);
                globalSession.CurrentEmpresa = dbEmpresa != null ? new EmpresaBindingModel(dbEmpresa) : null;

                var dbSucursal = applicationDbContext.Sucursal.FirstOrDefault(y => y.Id == config.Sucursalid && y.EmpresaId == config.Empresaid);
                globalSession.CurrentSucursal = dbSucursal != null ? new SucursalBindingModel(dbSucursal) : null;

                var dbParametro = applicationDbContext.Parametro.FirstOrDefault(y => y.EmpresaId == config.Empresaid && y.SucursalId == config.Sucursalid);
                globalSession.CurrentParametro = dbParametro != null ? new ParametroBindingModel(dbParametro) : null;


                var claveSucursal = globalSession!.CurrentSucursal?.Clave;


                var dbSucursalInfo = applicationDbContext.Sucursal_info.Where(p => p.EmpresaId == config.Empresaid && p.SucursalId == config.Sucursalid &&
                                                                    p.Clave == claveSucursal).FirstOrDefault();
                globalSession.CurrentSucursalInfo = dbSucursalInfo != null ? new Sucursal_infoBindingModel(dbSucursalInfo) : null;

                if (config.Cajaid != null)
                {
                    var dbCaja = applicationDbContext.Caja.FirstOrDefault(y => y.EmpresaId == config.Empresaid && y.SucursalId == config.Sucursalid && y.Id == config.Cajaid.Value);
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
            using var applicationDbContext = this._operationsContextFactory.Create();


            if (configsync != null)
            {
                var dbEmpresa = applicationDbContext.Empresa.FirstOrDefault(y => y.Id == configsync.EmpresaId);
                globalSession.CurrentEmpresa = dbEmpresa != null ? new EmpresaBindingModel(dbEmpresa) : null;

                var dbSucursal = applicationDbContext.Sucursal.FirstOrDefault(y => y.Id == configsync.SucursalId && y.EmpresaId == configsync.EmpresaId);
                globalSession.CurrentSucursal = dbSucursal != null ? new SucursalBindingModel(dbSucursal) : null;

                var dbParametro = applicationDbContext.Parametro.FirstOrDefault(y => y.EmpresaId == configsync.EmpresaId && y.SucursalId == configsync.SucursalId);
                globalSession.CurrentParametro = dbParametro != null ? new ParametroBindingModel(dbParametro) : null;


                var claveSucursal = globalSession!.CurrentSucursal?.Clave;


                var dbSucursalInfo = applicationDbContext.Sucursal_info.Where(p => p.EmpresaId == configsync.EmpresaId && p.SucursalId == configsync.SucursalId &&
                                                                    p.Clave == claveSucursal).FirstOrDefault();
                globalSession.CurrentSucursalInfo = dbSucursalInfo != null ? new Sucursal_infoBindingModel(dbSucursalInfo) : null;



            }

        }


        //public void llenarSesionParaUsuario(int? usuarioId, Configuracion config, ref GlobalSession globalSession)
        //{

        //    if (usuarioId != null)
        //    {
        //        globalSession.CurrentUsuario = usuarioDao.Get_ById(new Usuario() { Id = usuarioId, Empresaid = config.Empresaid, Sucursalid = config.Sucursalid }, null);
        //        globalSession.CurrentParametros = llenarDatosParametros(new Parametros() { Id = 1, Empresaid = config.Empresaid, Sucursalid = config.Sucursalid }, null);
        //        globalSession.CurrentEmpresa = empresaDao.Get_ById(new Empresa() { Id = config.Empresaid, Empresaid = config.Empresaid, Sucursalid = 0 }, null);
        //        globalSession.CurrentSucursal = sucursalDao.Get_ById(new Sucursal() { Id = config.Sucursalid, Empresaid = config.Empresaid, Sucursalid = config.Sucursalid }, null);
        //    }
        //}


        public void llenarProductAutoCompleteList(ref GlobalSession? globalSession)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            if (globalSession == null)
                return;

            if (globalSession.ListadoAutoCompleteProd != null && globalSession.ListadoAutoCompleteProd.Count > 0)
            {
                return;
            }

            globalSession.ListadoAutoCompleteProd = applicationDbContext.Producto.Where(p => p.Activo == BoolCS.S)
                                                   .AsNoTracking()
                                                   .Select(y => new BindingModels.ProductoAutocompleteBindingModel(y)).ToList();


        }


        public void llenarClienteAutoCompleteList(ref GlobalSession? globalSession)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            if (globalSession == null)
                return;

            if (globalSession.ListadoAutoCompleteCliente != null && globalSession.ListadoAutoCompleteCliente.Count > 0)
            {
                return;
            }

            globalSession.ListadoAutoCompleteCliente = applicationDbContext.Cliente.Where(p => p.Activo == BoolCS.S)
                                                   .AsNoTracking()
                                                   .Select(y => new BindingModels.ClienteAutocompleteBindingModel(y)).ToList();


        }



    }
}
