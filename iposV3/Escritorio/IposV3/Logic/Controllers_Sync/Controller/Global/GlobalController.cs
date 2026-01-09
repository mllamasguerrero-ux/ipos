using DataAccess;
using IposV3.Model;
using IposV3Sync.BindingModel;
using Microsoft.EntityFrameworkCore;
using System;
using IposV3.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3Sync.Controllers.Controller
{
    public class GlobalController
    {



        private OperationsContextFactory _operationsContextFactory;
        public GlobalController(
                                OperationsContextFactory operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
        }

        public void llenarSesionPorConfiguracion(Configuracion config, ref GlobalSession globalSession)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            if (config != null)
            {
                globalSession.CurrentEmpresa = applicationDbContext.Empresa.FirstOrDefault(y => y.Id == config.Empresaid);
                globalSession.CurrentSucursal = applicationDbContext.Sucursal.FirstOrDefault(y => y.Id == config.Sucursalid && y.EmpresaId == config.Empresaid);
                globalSession.CurrentParametro = applicationDbContext.Parametro.FirstOrDefault(y => y.EmpresaId == config.Empresaid && y.SucursalId == config.Sucursalid);
                
                if (config.Cajaid != null)
                    globalSession.CurrentCaja = applicationDbContext.Caja.FirstOrDefault(y => y.EmpresaId == config.Empresaid && y.SucursalId == config.Sucursalid && y.Id == config.Cajaid.Value);
                else
                    globalSession.CurrentCaja = null;

                globalSession.CurrentConfiguracion = config;


            }

        }


        public void llenarSesionPorConfiguracionsync(IposV3.Model.Syncr.Configuracionsync configsync, ref GlobalSession globalSession)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            if (configsync != null)
            {
                globalSession.CurrentEmpresa = applicationDbContext.Empresa.FirstOrDefault(y => y.Id == configsync.Empresaid);
                globalSession.CurrentSucursal = applicationDbContext.Sucursal.FirstOrDefault(y => y.Id == configsync.Sucursalid && y.EmpresaId == configsync.Empresaid);
                globalSession.CurrentParametro = applicationDbContext.Parametro.FirstOrDefault(y => y.EmpresaId == configsync.Empresaid && y.SucursalId == configsync.Sucursalid);



                //globalSession.CurrentCaja = applicationDbContext.Caja.FirstOrDefault(y => y.Id == configsync.Cajaid && y.EmpresaId == configsync.EmpresaId && y.SucursalId == configsync.SucursalId);
                //globalSession.CurrentConfiguracionsync = configsync;
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


        //public void llenarProductAutoCompleteList(ref GlobalSession? globalSession)
        //{
        //    if (globalSession == null)
        //        return;

        //    if (globalSession.ListadoAutoCompleteProd != null && globalSession.ListadoAutoCompleteProd.Count > 0)
        //    {
        //        return;
        //    }

        //    globalSession.ListadoAutoCompleteProd = applicationDbContext.Producto.Where(p => p.Activo == BoolCS.S)
        //                                           .AsNoTracking()
        //                                           .Select(y => new BindingModels.ProductoAutocompleteBindingModel(y)).ToList();


        //}



    }
}
