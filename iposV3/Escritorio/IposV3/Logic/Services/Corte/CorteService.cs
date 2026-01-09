using IposV3.Model;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace IposV3.Services
{
    public class CorteService
    {

        public CorteService()
        {
        }



        public dynamic? CorteUsuarioFecha(long empresaId , long sucursalId, long cajeroId, DateTimeOffset corteFecha,
                                            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;


            try
            {



                var corte = localContext.Corte.AsNoTracking()
                                        .Where(c => c.EmpresaId == empresaId && c.SucursalId == sucursalId &&
                                                    c.Cajeroid == cajeroId && 
                                                    c.Activo == BoolCS.S &&
                                                    (c.Fechacorte != null && (c.Fechacorte!.Value.Date == DateTime.UtcNow.Date) &&
                                                    c.Inicia != null && c.Inicia > corteFecha
                                                     )
                                                     )
                                        .Select(c => new { c.Id, c.Activo, c.Fechacorte, c.Inicia, c.Termina })
                                        .FirstOrDefault();
                return corte;

            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }
        }



        public void HayCorteActivo(long empresaId, long sucursalId, long cajeroId,
                                    out long? corteid , out BoolCS? activo,
                                    out DateTimeOffset? fechacorte , out DateTimeOffset? inicia , out DateTimeOffset? termina ,
                                    ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            corteid = null;
            activo = BoolCS.N;
            fechacorte = null;
            inicia = null;
            termina = null;

            try
            {

                var nowV_10 = DateTimeOffset.UtcNow.AddHours(-10);

                var corte = this.CorteUsuarioFecha(empresaId, sucursalId, cajeroId, nowV_10, localContext);
                if(corte != null)
                {

                    corteid = corte.Id;
                    activo = corte.Activo;
                    fechacorte = corte.Fechacorte;
                    inicia = corte.Inicia;
                    termina = corte.Termina;
                }
                            
            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }

        //public void DoctoInsert(DoctoTransaction doctoTrans, ApplicationDbContext context)
        //{
        //    ApplicationDbContext? localContext;

        //    if (context != null)
        //        localContext = context;
        //    else
        //        localContext = this._applicationDbContext;

        //    var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
        //    localContext.ChangeTracker.LazyLoadingEnabled = false;

        //    try
        //    {


        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
        //    }

        //}
    }
}
