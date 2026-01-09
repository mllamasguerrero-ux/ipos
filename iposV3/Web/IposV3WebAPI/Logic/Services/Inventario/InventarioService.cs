using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace IposV3.Services
{
    public class InventarioService
    {

        public InventarioService()
        {
        }

        public void AplicarEnProcesoSalida(
              long empresaId, long sucursalId, long productoId,
              decimal cantidad, long almacenId, long tipoDoctoId, ApplicationDbContext localContext)
        {


            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;



            try
            {
                if (tipoDoctoId == 0)
                    return;


                var tipoDocto = localContext.Tipodocto.AsNoTracking().FirstOrDefault(t => t.Id == tipoDoctoId);
                if (tipoDocto == null || tipoDocto.Sentidoenprocesosalida == 0)
                    return;


                var producto = localContext.Producto.AsNoTracking().Include(p => p.Producto_inventario)
                                                    .FirstOrDefault(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId &&
                                                                         p.Id == productoId);

                if (producto == null || (producto.Producto_inventario?.Inventariable ?? BoolCS.N) != BoolCS.S ||
                                       (producto.Producto_inventario?.Negativos ?? BoolCN.N) == BoolCN.S)
                    return;

                var producto_existencia = localContext.Producto_existencia
                                                    .FirstOrDefault(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Productoid == productoId);

                if (producto_existencia != null)
                {
                    producto_existencia.Enprocesodesalida += cantidad;
                    producto_existencia.Ultimocambioexistencia = DateTimeOffset.Now;
                    localContext.Update(producto_existencia);
                }
                else
                {
                    producto_existencia = new Producto_existencia() {
                        EmpresaId = empresaId,
                        SucursalId = sucursalId,
                        Productoid = productoId,
                        Activo = BoolCS.S,
                        Enprocesodesalida = cantidad,
                        Existencia = 0,
                        Ultimocambioexistencia = DateTimeOffset.Now
                    };
                    localContext.Add(producto_existencia);
                }


                var producto_almacen = localContext.Productoalmacen
                                                    .FirstOrDefault(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Productoid == productoId && p.Almacenid == almacenId);

                if (producto_almacen != null)
                {
                    producto_almacen.Enprocesodesalida += cantidad;
                    localContext.Update(producto_almacen);
                }
                else
                {
                    producto_almacen = new Productoalmacen()
                    {
                        EmpresaId = empresaId,
                        SucursalId = sucursalId,
                        Productoid = productoId,
                        Almacenid = almacenId,
                        Activo = BoolCS.S,
                        Enprocesodesalida = cantidad
                    };
                    localContext.Add(producto_almacen);
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





        public void VerificarExistencia(
            long empresaId, long sucursalId, long productoId,
            decimal cantidad, long tipoDoctoId, long almacenId,
            string? lote, DateTimeOffset? fechaVence,
            BoolCN ignoreAlmacen, BoolCN ignoreLote, BoolCN ignoreEnProcesoSalida,
            BoolCN ignoreParaArmar, BoolCN onlyVerify, long? movtoRefId,
            out BoolCS hayExistencia, out decimal existencia, out decimal existenciaParaArmarKit,
            out decimal existenciaTotal, out decimal enProcesoDeSalida,
            ApplicationDbContext localContext)
        {


            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            hayExistencia = BoolCS.N;
            existencia = 0m;
            existenciaParaArmarKit = 0m;
            existenciaTotal = 0m;
            enProcesoDeSalida = 0m;



            try
            {

                var producto = localContext.Producto.AsNoTracking()
                                            .Include(p => p.Producto_inventario)
                                            .Include(p => p.Producto_kit)
                                            .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Id == productoId)
                                            .Select(p => new {
                                                Inventariable = p.Producto_inventario != null ? p.Producto_inventario.Inventariable : BoolCS.N,
                                                Negativos = p.Producto_inventario != null ? p.Producto_inventario.Negativos : BoolCN.N,
                                                Eskit = p.Producto_kit != null ? p.Producto_kit.Eskit : BoolCN.N,
                                                Existencia = p.Producto_existencia != null ? p.Producto_existencia.Existencia : 0m,
                                                Enprocesodesalida = p.Producto_existencia != null ? p.Producto_existencia.Enprocesodesalida : 0m,
                                                Manejalote = p.Producto_inventario != null ? p.Producto_inventario.Manejalote : BoolCN.N

                                            }).FirstOrDefault()
                                            ;

                var tipoDocto = localContext.Tipodocto.AsNoTracking()
                                            .FirstOrDefault(t => t.Id == tipoDoctoId);

                var parametro = localContext.Parametro.AsNoTracking()
                                            .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId)
                                            .Select(p => new { p.Manejaalmacen, p.Manejakits })
                                            .FirstOrDefault()
                                            ;

                if (producto == null)
                    throw new Exception("Producto no encontrado");

                if (tipoDocto == null)
                    throw new Exception("Tipo docto no encontrado");

                if (parametro == null)
                    throw new Exception("Parametro no encontrado");

                if (producto!.Inventariable != BoolCS.S || 
                   (onlyVerify == BoolCN.S &&
                      (
                       (producto!.Negativos == BoolCN.S) ||
                       (tipoDocto!.Sentidoinventario == 0) ||
                       (tipoDocto!.Verif_exist == BoolCN.N) ||
                       (cantidad <= 0)
                      )
                   )
                )
                {

                    hayExistencia = BoolCS.S;
                    existencia = 0m;
                    existenciaParaArmarKit = 0m;
                    existenciaTotal = 0m;

                }

                var existenciasInventarioSumarizadas = localContext.Inventario.AsNoTracking()
                    .Where(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId && i.Productoid == productoId && i.Esapartado != BoolCN.S)
                    .GroupBy(m => new { m.EmpresaId, m.SucursalId, m.Productoid })
                    .Select(g => new
                    {
                        Existencia = g.Sum(s =>
                            (
                                (
                                    producto.Manejalote == BoolCN.N || ignoreLote == BoolCN.S ||
                                    (
                                        ((s.Lote == null && lote == null) || s.Lote == lote) &&
                                        ((s.Fechavence == null && fechaVence == null) || s.Fechavence == fechaVence)
                                    )
                                ) &&
                                (
                                    parametro.Manejaalmacen != BoolCN.S || ignoreAlmacen == BoolCN.S ||
                                    ((s.Almacenid == null && almacenId == 0) || s.Almacenid == almacenId)
                                )
                             ) ? s.Cantidad : 0m

                           ),

                        ExistenciaTotal = g.Sum(s =>
                            (
                                (
                                    parametro.Manejaalmacen != BoolCN.S || ignoreAlmacen == BoolCN.S ||
                                    ((s.Almacenid == null && almacenId == 0) || s.Almacenid == almacenId)
                                )
                             ) ? s.Cantidad : 0m

                           )

                    }).FirstOrDefault();



                var buffer_enprocesodesalida = localContext.Productoalmacen.AsNoTracking()
                    .Where(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId && i.Productoid == productoId &&
                                (
                                    parametro.Manejaalmacen != BoolCN.S || ignoreAlmacen == BoolCN.S ||
                                    ((i.Almacenid == null && almacenId == 0) || i.Almacenid == almacenId)
                                )
                          )
                    .GroupBy(m => new { m.EmpresaId, m.SucursalId, m.Productoid })
                    .Select(g => g.Sum(s => s.Enprocesodesalida))
                    .FirstOrDefault();


                existencia = existenciasInventarioSumarizadas?.Existencia ?? 0m;
                existenciaTotal = existenciasInventarioSumarizadas?.ExistenciaTotal ?? 0m;
                enProcesoDeSalida = buffer_enprocesodesalida;

                if (existencia >= cantidad &&
                    (ignoreEnProcesoSalida == BoolCN.S || tipoDocto.Sentidoenprocesosalida == 0 ||
                    existenciaTotal - enProcesoDeSalida >= cantidad))
                {
                    hayExistencia = BoolCS.S;
                }


                if (onlyVerify == BoolCN.S && hayExistencia == BoolCS.S)
                {
                    return;
                }





                if (parametro.Manejakits == BoolCN.S && producto.Eskit == BoolCN.S && ignoreParaArmar != BoolCN.S)
                {


                    var kitDefiniciones = KitMovtoDefiniciones(empresaId, sucursalId, movtoRefId, productoId, localContext);




                    //var test_0 = (from kd in kitDefiniciones
                    //                                         from inv in localContext.Inventario.Where(i => kd.EmpresaId == i.EmpresaId && sucursalId == i.SucursalId &&
                    //                                                                                kd.Productoparteid == i.Productoid).DefaultIfEmpty()
                    //                                         select new
                    //                                         {
                    //                                             Productoparteid = kd.Productoparteid,
                    //                                             CantidadParte = kd.Cantidadparte,
                    //                                             Cantidad = inv.Cantidad,
                    //                                             producto.Enprocesodesalida
                    //                                         }
                    //                                    ).ToList();

                    //var buffer_existencia_para_armar_test = (from kd in kitDefiniciones
                    //                                    from inv in localContext.Inventario.Where(i => kd.EmpresaId == i.EmpresaId && sucursalId == i.SucursalId &&
                    //                                                                           kd.Productoparteid == i.Productoid).DefaultIfEmpty()
                    //                                    select new
                    //                                    {
                    //                                        Productoparteid = kd.Productoparteid,
                    //                                        CantidadParte = kd.Cantidadparte,
                    //                                        Cantidad = inv.Cantidad,
                    //                                        producto.Enprocesodesalida
                    //                                    }
                    //                                    ).ToList();

                    //var buffer_existencia_para_armar_test_2 = (from buffer in buffer_existencia_para_armar_test
                    //                                           group buffer by buffer.Productoparteid into sg
                    //                                           select new
                    //                                           {
                    //                                               Productoparteid = sg.Key,
                    //                                               CantidadDisponible = sg.Sum(item => (item.Cantidad - (ignoreEnProcesoSalida == BoolCN.S || tipoDocto.Sentidoenprocesosalida == 0 ? 0m : item.Enprocesodesalida)) / item.CantidadParte)
                    //                                           }).DefaultIfEmpty().Min(y => y.CantidadDisponible);

                    var buffer_existencia_para_armar = (from kd in kitDefiniciones
                                                          from inv in localContext.Inventario.Where(i => kd.EmpresaId == i.EmpresaId && sucursalId == i.SucursalId &&
                                                                                                 kd.Productoparteid == i.Productoid).DefaultIfEmpty()
                                                          //from prod in localContext.Producto_existencia.Where(i => kd.EmpresaId == i.EmpresaId && sucursalId == i.SucursalId &&
                                                          //                                       kd.Productoparteid == i.Productoid).DefaultIfEmpty()
                                                          select new
                                                          {
                                                              Productoparteid = kd.Productoparteid,
                                                              CantidadParte = kd.Cantidadparte,
                                                              Cantidad = inv?.Cantidad ?? 0m,
                                                              producto.Enprocesodesalida
                                                          } into buffer
                                                          group buffer by buffer.Productoparteid into sg
                                                          select new
                                                          {
                                                              Productoparteid = sg.Key,
                                                              CantidadDisponible = sg.Sum(item => (item.Cantidad - (ignoreEnProcesoSalida == BoolCN.S || tipoDocto.Sentidoenprocesosalida == 0 ? 0m : item.Enprocesodesalida)) / item.CantidadParte)
                                                          }).DefaultIfEmpty().Min(y => y!.CantidadDisponible);


                    //var buffer_existencia_para_armar = from s in buffer_existencia_para_armar_1
                    //                                   select new
                    //                                    {
                    //                                        s.Productoparteid,
                    //                                        CantidadDisponible = sg.Sum(
                    //                                                        item => (item.Cantidad - (ignoreEnProcesoSalida == BoolCN.S || tipoDocto.Sentidoenprocesosalida == 0 ? 0m : s.Enprocesodesalida)) / item.CantidadParte
                    //                                                     )
                    //                                    }).DefaultIfEmpty().Min(y => y.CantidadDisponible)
                    //            ;


                    buffer_existencia_para_armar = decimal.Round(buffer_existencia_para_armar, 0);
                    existenciaParaArmarKit = buffer_existencia_para_armar;

                    if (hayExistencia != BoolCS.S && existenciaParaArmarKit > 0 &&
                        existencia + existenciaParaArmarKit >= cantidad)
                        hayExistencia = BoolCS.S;


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


        public void MovtoAplicarEnProcesoSalida(
              long empresaId, long sucursalId, long movtoId,
              decimal cantidad, ApplicationDbContext localContext)
        {


            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;


            long? productoId;
            BoolCN manejaAlmacen = BoolCN.N;
            BoolCN manejaKits = BoolCN.N;

            long? almacenId;
            long? tipoDoctoId;


            BoolCN ensamblarKits = BoolCN.N;
            short sentidoEnProcesoDeSalida = 0;


            BoolCS inventariable = BoolCS.S;
            BoolCN negativos = BoolCN.N;
            BoolCN eskit = BoolCN.N;
            BoolCN kitImpFijo = BoolCN.N;

            string? lote;
            DateTimeOffset? fechaVence;

            BoolCS hayExistencia = BoolCS.N;
            decimal existencia = 0m;
            decimal existenciaParaArmarKit = 0m;
            decimal existenciaTotal = 0m;
            decimal enProcesoDeSalida = 0m;

            decimal cantidad_directa = 0m;
            decimal cantidad_a_armarkit = 0m;
            decimal cantidad_a_desarmarkit = 0m;



            try
            {

                var parametro = localContext.Parametro.AsNoTracking()
                                            .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId)
                                            .Select(p => new { p.Manejaalmacen, p.Manejakits })
                                            .FirstOrDefault();

                if (parametro == null)
                    throw new Exception("El parametro no esta configurado");

                manejaAlmacen = parametro.Manejaalmacen;
                manejaKits = parametro.Manejakits;

                var bufferMovto = localContext.Movto.AsNoTracking()
                                              .Include(m => m.Docto)
                                              .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Id == movtoId)
                                              .Select(m => new { m.Docto!.Almacenid, m.Docto.Tipodoctoid, m.Productoid, m.Lote, m.Fechavence })
                                              .FirstOrDefault();


                if (bufferMovto == null)
                    throw new Exception("El registro de movto no se encontro");

                almacenId = bufferMovto.Almacenid;
                tipoDoctoId = bufferMovto.Tipodoctoid;
                productoId = bufferMovto.Productoid;
                lote = bufferMovto.Lote;
                fechaVence = bufferMovto.Fechavence;



                var tipoDocto = localContext.Tipodocto.AsNoTracking()
                                            .Where(m => m.Id == tipoDoctoId)
                                            .Select(t => new { t.Ensamblarkits, t.Sentidoenprocesosalida })
                                            .FirstOrDefault();

                if (tipoDocto == null)
                    throw new Exception("Tipo de docto no encontrado");

                ensamblarKits = tipoDocto.Ensamblarkits;
                sentidoEnProcesoDeSalida = tipoDocto.Sentidoenprocesosalida;



                var producto = localContext.Producto.AsNoTracking()
                                            .Include(p => p.Producto_inventario)
                                            .Include(p => p.Producto_kit)
                                            .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Id == productoId)
                                            .Select(p => new
                                            {
                                                Inventariable = p.Producto_inventario != null ? p.Producto_inventario.Inventariable : BoolCS.N,
                                                Negativos = p.Producto_inventario != null ? p.Producto_inventario.Negativos : BoolCN.N,
                                                Eskit = p.Producto_kit != null ? p.Producto_kit.Eskit : BoolCN.N,
                                                KitImpFijo = p.Producto_kit != null ? p.Producto_kit.Kitimpfijo : BoolCN.N
                                            }).FirstOrDefault();


                if (producto == null)
                    throw new Exception("Producto no encontrado");

                inventariable = producto.Inventariable;
                negativos = producto.Negativos;
                eskit = producto.Eskit;
                kitImpFijo = producto.KitImpFijo;


                if (inventariable != BoolCS.S || negativos == BoolCN.S)
                {
                    return;
                }





                if (manejaKits != BoolCN.S || eskit != BoolCN.S || ensamblarKits != BoolCN.S)
                {
                    AplicarEnProcesoSalida(empresaId, sucursalId, productoId!.Value, cantidad,
                                           almacenId!.Value, tipoDoctoId!.Value, localContext);

                    return;
                }
                else
                {

                    if (cantidad > 0)
                    {

                        VerificarExistencia(empresaId, sucursalId, productoId!.Value, cantidad,
                                           tipoDoctoId!.Value, almacenId!.Value, lote, fechaVence,
                                           BoolCN.N, BoolCN.S, BoolCN.N, BoolCN.N, BoolCN.N, movtoId,
                                           out hayExistencia, out existencia, out existenciaParaArmarKit,
                                           out existenciaTotal, out enProcesoDeSalida, localContext);



                        if (existencia >= cantidad)
                        {


                            AplicarEnProcesoSalida(empresaId, sucursalId, productoId!.Value, cantidad,
                                                   almacenId!.Value, tipoDoctoId!.Value, localContext);

                            return;
                        }
                        else if (existencia + existenciaParaArmarKit >= cantidad)
                        {

                            cantidad_directa = (existencia > 0 && existencia <= cantidad) ?
                                                    existencia :
                                                    (existencia > 0 && existencia > cantidad ?
                                                          cantidad : 0);

                            cantidad_a_armarkit = cantidad - cantidad_directa;





                            if (cantidad_directa > 0)
                            {

                                AplicarEnProcesoSalida(empresaId, sucursalId, productoId!.Value, cantidad_directa,
                                                       almacenId!.Value, tipoDoctoId!.Value, localContext);

                            }

                            if (cantidad_a_armarkit > 0)
                            {

                                var kitDefiniciones = KitMovtoDefiniciones(empresaId, sucursalId, movtoId, productoId!.Value, localContext);


                                foreach (var rec_kitdef in kitDefiniciones)
                                {
                                    if (rec_kitdef.Productoparteid > 0)
                                    {

                                        AplicarEnProcesoSalida(empresaId, sucursalId, rec_kitdef.Productoparteid!.Value,
                                                                rec_kitdef.Cantidadparte * cantidad_a_armarkit,
                                                                almacenId!.Value, tipoDoctoId!.Value, localContext);
                                    }
                                }

                                var movto_kit = localContext.Movto_kit.FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                                            i.Movtoid == movtoId);
                                if (movto_kit != null)
                                {
                                    movto_kit.Enprocesopartes = movto_kit.Enprocesopartes + cantidad_a_armarkit;
                                    localContext.Update(movto_kit);
                                }
                                else
                                {
                                    movto_kit = new Movto_kit() {
                                        EmpresaId = empresaId,
                                        SucursalId = sucursalId,
                                        Movtoid = movtoId,
                                        Enprocesopartes = cantidad_a_armarkit,
                                        Kitimpfijo = kitImpFijo
                                    };
                                    localContext.Add(movto_kit);
                                }




                            }



                        }




                    }
                    else
                    {

                        var movto_kit = localContext.Movto_kit.FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                                    i.Movtoid == movtoId);

                        var enProcesoPartes = 0m;
                        if (movto_kit != null)
                            enProcesoPartes = movto_kit.Enprocesopartes;


                        cantidad_a_desarmarkit = ((cantidad * -1) >= enProcesoPartes) ?
                                                        enProcesoPartes :
                                                        (cantidad * -1);

                        cantidad_directa = (cantidad * -1) - cantidad_a_desarmarkit;



                        if (cantidad_a_desarmarkit > 0)
                        {

                            var kitDefiniciones = KitMovtoDefiniciones(empresaId, sucursalId, movtoId, productoId!.Value, localContext);

                            foreach (var rec_kitdef in kitDefiniciones)
                            {
                                if (rec_kitdef.Productoparteid > 0)
                                {

                                    AplicarEnProcesoSalida(empresaId, sucursalId, rec_kitdef.Productoparteid!.Value,
                                                            rec_kitdef.Cantidadparte * cantidad_a_desarmarkit * (-1),
                                                            almacenId!.Value, tipoDoctoId!.Value, localContext);
                                }
                            }

                            if (movto_kit != null)
                            {
                                movto_kit.Enprocesopartes = movto_kit.Enprocesopartes + cantidad_a_armarkit;
                                localContext.Update(movto_kit);
                            }
                            else
                            {
                                movto_kit = new Movto_kit()
                                {
                                    EmpresaId = empresaId,
                                    SucursalId = sucursalId,
                                    Movtoid = movtoId,
                                    Enprocesopartes = cantidad_a_armarkit,
                                    Kitimpfijo = kitImpFijo
                                };
                                localContext.Add(movto_kit);
                            }
                        }

                        if (cantidad_directa > 0)
                        {

                            AplicarEnProcesoSalida(empresaId, sucursalId, productoId!.Value, cantidad_directa * (-1),
                                                   almacenId!.Value, tipoDoctoId!.Value, localContext);

                        }

                    }

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


        public List<KitDefinicionAux> KitMovtoDefiniciones(long empresaId, long sucursalId, long? movtoId,
              long productoId, ApplicationDbContext localContext)
        {

            if (movtoId != null && movtoId != 0)
            {
                var bufferRetorno = localContext.Movto_kit_def.AsNoTracking()
                .Where(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId && i.Movtoid == movtoId &&
                                        i.Productokitid == productoId)
                            .GroupBy(i => new { i.EmpresaId, i.SucursalId, i.Productoparteid })
                            .Select(i => new KitDefinicionAux() {
                                EmpresaId = i.Key.EmpresaId,
                                SucursalId = i.Key.SucursalId,
                                Productoparteid = i.Key.Productoparteid,
                                Cantidadparte = i.Sum(s => s.Cantidadparte)
                            }).ToList();
                if (bufferRetorno != null && bufferRetorno.Count > 0)
                    return bufferRetorno;
            }


            return localContext.Kitdefinicion.AsNoTracking()
                                            .Where(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                        i.Productokitid == productoId)
                                            .GroupBy(i => new { i.EmpresaId, i.SucursalId, i.Productoparteid })
                                            .Select(i => new KitDefinicionAux()
                                            {
                                                EmpresaId = i.Key.EmpresaId,
                                                SucursalId = i.Key.SucursalId,
                                                Productoparteid = i.Key.Productoparteid,
                                                Cantidadparte = i.Sum(s => s.Cantidadparte)
                                            }).ToList();
        }




        public void SeleccionOrigenFiscal(long empresaId, long sucursalId,
              long productoId, decimal cantidad, long tipoDoctoId,
              long? almacenId, string? lote, DateTimeOffset? fechaVence,
              long? loteImportado, BoolCN esApartado, BoolCN esFacturaElectronica,
              out decimal cantidad_facturado, out decimal cantidad_remisionado,
              out decimal cantidad_indefinido, ApplicationDbContext localContext)
        {

            short sentidoInventario = 0;
            BoolCN negativos = BoolCN.N;
            BoolCN dividir_rem_fact = BoolCN.N;

            decimal existencia_indefinido = 0m;
            decimal existencia_remisionado = 0m;
            decimal existencia_facturado = 0m;
            decimal existencia_general = 0m;


            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            cantidad_facturado = 0m;
            cantidad_remisionado = 0m;
            cantidad_indefinido = 0m;

            var cantidad_restante = 0m;
            var cantidad_buffer = 0m;


            try
            {
                var tipoDocto = localContext.Tipodocto.AsNoTracking()
                                            .Where(t => t.Id == tipoDoctoId)
                                            .Select(t => new { SentidoInventario = esApartado == BoolCN.S ? t.Sentidoinventarioapartados : t.Sentidoinventario })
                                            .FirstOrDefault();
                if (tipoDocto == null)
                    throw new Exception("El tipo docto no fue encontrado");

                sentidoInventario = tipoDocto.SentidoInventario;

                var producto = localContext.Producto.AsNoTracking()
                                                    .Include(p => p.Producto_inventario)
                                                    .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId &&
                                                                         p.Id == productoId)
                                                    .Select(p => new { Negativos = p.Producto_inventario != null ? p.Producto_inventario.Negativos : BoolCN.N })
                                                    .FirstOrDefault();

                if (producto == null)
                    throw new Exception("El producto no fue encontrado");

                negativos = producto.Negativos;


                var parametro = localContext.Parametro.AsNoTracking()
                                            .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId)
                                            .Select(p => new { p.Dividir_rem_fact })
                                            .FirstOrDefault();


                if (parametro == null)
                    throw new Exception("El parametro no fue encontrado");

                dividir_rem_fact = parametro.Dividir_rem_fact;


                if (sentidoInventario == 1)
                {

                    cantidad_facturado = 0m;
                    cantidad_remisionado = cantidad;
                    cantidad_indefinido = 0m;
                    return;
                }
                else
                {

                    var inventario = localContext.Inventario.AsNoTracking()
                                                 .Where(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Productoid == productoId &&
                                                             (lote == null || lote.Trim() == "" || (lote == i.Lote && (fechaVence == i.Fechavence))) &&
                                                             (loteImportado == null || loteImportado == i.Loteimportado) &&
                                                             (((almacenId == null || almacenId == 0) && (i.Almacenid == null || i.Almacenid == 0)) || (almacenId != null && almacenId.Value == i.Almacenid)) &&
                                                             (esApartado == i.Esapartado)
                                                        )
                                                 .GroupBy(g => new { g.EmpresaId, g.SucursalId, g.Productoid })
                                                 .Select(s => new { existencia_indefinido = s.Sum(i => (i.Origenfiscalid == 1 ? i.Cantidad : 0)),
                                                     existencia_remisionado = s.Sum(i => (i.Origenfiscalid == 2 ? i.Cantidad : 0)),
                                                     existencia_facturado = s.Sum(i => (i.Origenfiscalid == 3 ? i.Cantidad : 0)),
                                                     existencia_general = s.Sum(i => i.Cantidad)
                                                 })
                                                 .FirstOrDefault();

                    existencia_indefinido = inventario?.existencia_indefinido ?? 0m;
                    existencia_remisionado = inventario?.existencia_remisionado ?? 0m;
                    existencia_facturado = inventario?.existencia_facturado ?? 0m;
                    existencia_general = inventario?.existencia_general ?? 0m;


                    if (existencia_general < cantidad && negativos != BoolCN.S)
                    {

                        cantidad_facturado = 0m;
                        cantidad_remisionado = 0m;
                        cantidad_indefinido = 0m;

                        throw new Exception("la cantidad requerida es mayor a la existencia ");
                    }

                    cantidad_facturado = 0m;
                    cantidad_remisionado = 0m;
                    cantidad_indefinido = 0m;
                    cantidad_restante = cantidad;

                    if (esFacturaElectronica == BoolCN.N)
                    {

                        if (existencia_facturado > existencia_remisionado)
                        {

                            cantidad_buffer = existencia_facturado - existencia_remisionado;
                            cantidad_remisionado = cantidad_remisionado + (cantidad_buffer > cantidad_restante ? cantidad_restante : cantidad_buffer);
                            cantidad_restante = cantidad_restante - cantidad_remisionado;
                            existencia_remisionado = existencia_remisionado - cantidad_remisionado;
                        }
                        else if (existencia_facturado < existencia_remisionado)
                        {

                            cantidad_buffer = existencia_remisionado - existencia_facturado;
                            cantidad_facturado = cantidad_facturado + (cantidad_buffer > cantidad_restante ? cantidad_restante : cantidad_buffer);
                            cantidad_restante = cantidad_restante - cantidad_facturado;
                            existencia_facturado = existencia_facturado - cantidad_facturado;

                        }

                        if (cantidad_restante > 0 && existencia_facturado > 0)
                        {

                            cantidad_buffer = existencia_facturado;
                            cantidad_facturado = cantidad_facturado + (cantidad_buffer > cantidad_restante ? cantidad_restante : cantidad_buffer);
                            cantidad_restante = cantidad_restante - cantidad_facturado;
                            existencia_facturado = existencia_facturado - cantidad_facturado;
                        }

                        if (cantidad_restante > 0 && existencia_remisionado > 0)
                        {

                            cantidad_buffer = existencia_remisionado;
                            cantidad_remisionado = cantidad_remisionado + (cantidad_buffer > cantidad_restante ? cantidad_restante : cantidad_buffer);
                            cantidad_restante = cantidad_restante - cantidad_remisionado;
                            existencia_remisionado = existencia_remisionado - cantidad_remisionado;
                        }


                        if (cantidad_restante > 0 && existencia_indefinido > 0)
                        {

                            cantidad_buffer = existencia_indefinido;
                            cantidad_indefinido = cantidad_indefinido + (cantidad_buffer > cantidad_restante ? cantidad_restante : cantidad_buffer);
                            cantidad_restante = cantidad_restante - cantidad_indefinido;
                            existencia_indefinido = existencia_indefinido - cantidad_indefinido;
                        }

                    }
                    else
                    {


                        if (cantidad_restante > 0 && existencia_remisionado > 0)
                        {

                            cantidad_buffer = existencia_remisionado;
                            cantidad_remisionado = cantidad_remisionado + (cantidad_buffer > cantidad_restante ? cantidad_restante : cantidad_buffer);
                            cantidad_restante = cantidad_restante - cantidad_remisionado;
                            existencia_remisionado = existencia_remisionado - cantidad_remisionado;
                        }

                        if (cantidad_restante > 0 && existencia_facturado > 0)
                        {

                            cantidad_buffer = existencia_facturado;
                            cantidad_facturado = cantidad_facturado + (cantidad_buffer > cantidad_restante ? cantidad_restante : cantidad_buffer);
                            cantidad_restante = cantidad_restante - cantidad_facturado;
                            existencia_facturado = existencia_facturado - cantidad_facturado;
                        }


                        if (cantidad_restante > 0 && existencia_indefinido > 0)
                        {

                            cantidad_buffer = existencia_indefinido;
                            cantidad_indefinido = cantidad_indefinido + (cantidad_buffer > cantidad_restante ? cantidad_restante : cantidad_buffer);
                            cantidad_restante = cantidad_restante - cantidad_indefinido;
                            existencia_indefinido = existencia_indefinido - cantidad_indefinido;
                        }
                    }






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



        public void Kardex_insert_transaccion(
              long empresaId, long sucursalId,
              BoolCS activo, DateTimeOffset creado, long? creadopor_userid, long? tipodoctoid,
              long? doctoid, long? movtoid, DateTimeOffset? fecha, DateTimeOffset? fechahora,
              long productoId, decimal cantidad, string? lote, DateTimeOffset? fechaVence,
              long? loteImportado, long? almacenId, long? origenFiscalId,
              BoolCN esApartado, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            decimal new_existencia = 0m, new_existenciaFacturado = 0m, new_existenciaRemisionado = 0m, new_existenciaIndefinido = 0m;
            decimal new_existenciaApartado = 0m, new_existenciaApartadoFacturado = 0m, new_existenciaApartadoRemisionado = 0m, new_existenciaApartadoIndefinido = 0m;

            try
            {
                Kardex k = new Kardex();
                k.EmpresaId = empresaId;
                k.SucursalId = sucursalId;
                k.Activo = activo;
                k.Creado = creado;
                k.CreadoPorId = creadopor_userid;
                k.Tipodoctoid = tipodoctoid;
                k.Doctoid = doctoid;
                k.Movtoid = movtoid;
                k.Fecha = fecha;
                k.Fechahora = fechahora;
                k.Productoid = productoId;
                k.Cantidad = cantidad;
                k.Lote = lote;
                k.Fechavence = fechaVence;
                k.Loteimportado = loteImportado;
                k.Almacenid = almacenId;
                k.Origenfiscalid = origenFiscalId;
                k.Esapartado = esApartado;

                localContext.Add(k);


                var inventario = localContext.Inventario
                                             .Where(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Productoid == productoId &&
                                                             (((origenFiscalId == null || origenFiscalId == 0) && (i.Origenfiscalid == null || i.Origenfiscalid == 0)) || (origenFiscalId != null && origenFiscalId == i.Origenfiscalid)) &&
                                                             (lote == null || lote.Trim() == "" || (lote == i.Lote && (fechaVence == i.Fechavence))) &&
                                                             (loteImportado == null || loteImportado == i.Loteimportado) &&
                                                             (((almacenId == null || almacenId == 0) && (i.Almacenid == null || i.Almacenid == 0)) || (almacenId != null && almacenId.Value == i.Almacenid)) &&
                                                             (esApartado == i.Esapartado)
                                                             )
                                             .FirstOrDefault();



                if (inventario != null)
                {
                    inventario.Cantidad += cantidad;
                    localContext.Update(inventario);
                }
                else
                {
                    Inventario inv = new Inventario();

                    inv.Modificado = DateTimeOffset.UtcNow;
                    inv.ModificadoPorId = creadopor_userid;
                    inv.EmpresaId = empresaId;
                    inv.SucursalId = sucursalId;
                    inv.Activo = BoolCS.S;
                    inv.Creado = DateTimeOffset.UtcNow;
                    inv.CreadoPorId = creadopor_userid;
                    inv.Productoid = productoId;
                    inv.Cantidad = cantidad;
                    inv.Lote = lote;
                    inv.Fechavence = fechaVence;
                    inv.Loteimportado = loteImportado;
                    inv.Almacenid = almacenId;
                    inv.Origenfiscalid = origenFiscalId;
                    inv.Esapartado = esApartado;
                    localContext.Add(inv);

                }

                localContext.SaveChanges();

                var inventarioSumarizado = localContext.Inventario.AsNoTracking()
                                             .Where(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Productoid == productoId)
                                             .GroupBy(g => new { g.EmpresaId, g.SucursalId, g.Productoid })
                                             .Select(g => new {
                                                 Existencia = g.Sum(s => (s.Esapartado == BoolCN.N ? s.Cantidad : 0)),
                                                 ExistenciaFacturado = g.Sum(s => (s.Esapartado == BoolCN.N && s.Origenfiscalid == 3 ? s.Cantidad : 0)),
                                                 ExistenciaRemisionado = g.Sum(s => (s.Esapartado == BoolCN.N && s.Origenfiscalid == 2 ? s.Cantidad : 0)),
                                                 ExistenciaIndefinido = g.Sum(s => (s.Esapartado == BoolCN.N && s.Origenfiscalid == 1 ? s.Cantidad : 0)),

                                                 ExistenciaApartado = g.Sum(s => (s.Esapartado == BoolCN.S ? s.Cantidad : 0)),
                                                 ExistenciaApartadoFacturado = g.Sum(s => (s.Esapartado == BoolCN.S && s.Origenfiscalid == 3 ? s.Cantidad : 0)),
                                                 ExistenciaApartadoRemisionado = g.Sum(s => (s.Esapartado == BoolCN.S && s.Origenfiscalid == 2 ? s.Cantidad : 0)),
                                                 ExistenciaApartadoIndefinido = g.Sum(s => (s.Esapartado == BoolCN.S && s.Origenfiscalid == 1 ? s.Cantidad : 0))
                                             })
                                             .FirstOrDefault();

                if (inventarioSumarizado != null)
                {
                    new_existencia = inventarioSumarizado.Existencia;
                    new_existenciaFacturado = inventarioSumarizado.ExistenciaFacturado;
                    new_existenciaRemisionado = inventarioSumarizado.ExistenciaRemisionado;
                    new_existenciaIndefinido = inventarioSumarizado.ExistenciaIndefinido;

                    new_existenciaApartado = inventarioSumarizado.ExistenciaApartado;
                    new_existenciaApartadoFacturado = inventarioSumarizado.ExistenciaApartadoFacturado;
                    new_existenciaApartadoRemisionado = inventarioSumarizado.ExistenciaApartadoRemisionado;
                    new_existenciaApartadoIndefinido = inventarioSumarizado.ExistenciaApartadoIndefinido;
                }


                var producto_existencia = localContext.Producto_existencia
                                                      .FirstOrDefault(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId &&
                                                                           p.Productoid == productoId);

                if (producto_existencia != null)
                {
                    producto_existencia.Existencia = new_existencia;
                    localContext.Update(producto_existencia);
                }
                else
                {
                    producto_existencia = new Producto_existencia();

                    producto_existencia.Modificado = DateTimeOffset.UtcNow;
                    producto_existencia.ModificadoPorId = creadopor_userid;
                    producto_existencia.EmpresaId = empresaId;
                    producto_existencia.SucursalId = sucursalId;
                    producto_existencia.Activo = BoolCS.S;
                    producto_existencia.Creado = DateTimeOffset.UtcNow;
                    producto_existencia.CreadoPorId = creadopor_userid;
                    producto_existencia.Productoid = productoId;
                    producto_existencia.Existencia = new_existencia;
                    localContext.Add(producto_existencia);
                }


                var producto_origenfiscal = localContext.Producto_origenfiscal
                                                      .FirstOrDefault(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId &&
                                                                           p.Productoid == productoId);

                if (producto_origenfiscal != null)
                {
                    producto_origenfiscal.Existenciafacturado = new_existenciaFacturado;
                    producto_origenfiscal.Existenciaremisionado = new_existenciaRemisionado;
                    producto_origenfiscal.Existenciaindefinido = new_existenciaIndefinido;

                    localContext.Update(producto_origenfiscal);
                }
                else
                {

                    producto_origenfiscal = new Producto_origenfiscal();

                    producto_origenfiscal.Modificado = DateTimeOffset.UtcNow;
                    producto_origenfiscal.ModificadoPorId = creadopor_userid;
                    producto_origenfiscal.EmpresaId = empresaId;
                    producto_origenfiscal.SucursalId = sucursalId;
                    producto_origenfiscal.Activo = BoolCS.S;
                    producto_origenfiscal.Creado = DateTimeOffset.UtcNow;
                    producto_origenfiscal.CreadoPorId = creadopor_userid;
                    producto_origenfiscal.Productoid = productoId;
                    producto_origenfiscal.Existenciafacturado = new_existenciaFacturado;
                    producto_origenfiscal.Existenciaremisionado = new_existenciaRemisionado;
                    producto_origenfiscal.Existenciaindefinido = new_existenciaIndefinido;

                    localContext.Add(producto_origenfiscal);
                }

                var producto_apartado = localContext.Producto_apartado
                                                      .FirstOrDefault(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId &&
                                                                           p.Productoid == productoId);

                if (producto_apartado != null)
                {
                    producto_apartado.Existenciafacturadoapartado = new_existenciaApartadoFacturado;
                    producto_apartado.Existenciaremisionadoapartado = new_existenciaApartadoRemisionado;
                    producto_apartado.Existenciaindefinidoapartado = new_existenciaApartadoIndefinido;
                    producto_apartado.Existenciaapartado = new_existenciaApartado;

                    localContext.Update(producto_apartado);
                }
                else
                {

                    producto_apartado = new Producto_apartado();

                    producto_apartado.Modificado = DateTimeOffset.UtcNow;
                    producto_apartado.ModificadoPorId = creadopor_userid;
                    producto_apartado.EmpresaId = empresaId;
                    producto_apartado.SucursalId = sucursalId;
                    producto_apartado.Activo = BoolCS.S;
                    producto_apartado.Creado = DateTimeOffset.UtcNow;
                    producto_apartado.CreadoPorId = creadopor_userid;
                    producto_apartado.Productoid = productoId;
                    producto_apartado.Existenciafacturadoapartado = new_existenciaApartadoFacturado;
                    producto_apartado.Existenciaremisionadoapartado = new_existenciaApartadoRemisionado;
                    producto_apartado.Existenciaindefinidoapartado = new_existenciaApartadoIndefinido;
                    producto_apartado.Existenciaapartado = new_existenciaApartado;

                    localContext.Add(producto_apartado);
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



        public void MovtoInventarioAplicar(long empresaId, long sucursalId, long movtoId, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            BoolCN manejarLoteImportacion = BoolCN.N;

            long productoId;
            decimal cantidad;
            long tipoDoctoId;
            long? almacenId;
            string? lote;
            DateTimeOffset? fechaVence;
            long? loteImportado;
            BoolCN esApartado = BoolCN.N;
            BoolCN esFacturaElectronica = BoolCN.N;
            long? doctoId;
            long? origenFiscalId;
            decimal existencia = 0m;
            BoolCN negativos = BoolCN.N; ;
            BoolCS inventariable = BoolCS.S;
            BoolCN manejaLote = BoolCN.N; ;
            BoolCN manejaLoteImportado = BoolCN.N; ;

            short sentidoInventario = 0;

            long? creadoPorUserId;

            decimal cantidad_facturado = 0;
            decimal cantidad_remisionado = 0;
            decimal cantidad_indefinido = 0;

            try
            {

                var parametro = localContext.Parametro.AsNoTracking()
                                            .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId)
                                            .Select(p => new { p.Manejarloteimportacion })
                                            .FirstOrDefault();
                if (parametro == null)
                    throw new Exception("El parametro no existe");

                manejarLoteImportacion = parametro!.Manejarloteimportacion;

                var movtoInfo = localContext.Movto.AsNoTracking()
                                            .Include(m => m.Docto).ThenInclude(m => m!.Tipodocto)
                                            .Include(m => m.Docto).ThenInclude(m => m!.Docto_fact_elect)
                                            .Include(m => m.Producto).ThenInclude(p => p!.Producto_inventario)
                                            .Include(m => m.Producto).ThenInclude(p => p!.Producto_loteimportado)
                                            .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Id == movtoId)
                                            .Select(m => new { m.Doctoid, m.CreadoPorId, m.Productoid, m.Cantidad,
                                                Tipodoctoid = (m.Docto == null ? null : m.Docto.Tipodoctoid),
                                                Almacenid = (m.Docto == null ? null : m.Docto.Almacenid),
                                                Esapartado = (m.Docto == null ? BoolCN.N : m.Docto.Esapartado),
                                                Origenfiscalid = (m.Docto == null ? null : m.Docto.Origenfiscalid),
                                                Esfacturaelectronica = (m.Docto == null || m.Docto.Docto_fact_elect == null ? BoolCN.N : m.Docto.Docto_fact_elect.Esfacturaelectronica),
                                                m.Lote, m.Fechavence, m.Loteimportado,

                                                Negativos = ((m.Producto == null || m.Producto.Producto_inventario == null) ? BoolCN.N : m.Producto.Producto_inventario.Negativos),
                                                Inventariable = ((m.Producto == null || m.Producto.Producto_inventario == null) ? BoolCS.S : m.Producto.Producto_inventario.Inventariable),
                                                SentidoInventario = m.Docto == null || m.Docto.Tipodocto == null ? (short)0 : (m.Docto.Esapartado == BoolCN.S ? m.Docto.Tipodocto.Sentidoinventarioapartados : m.Docto.Tipodocto.Sentidoinventario),
                                                Manejalote = ((m.Producto == null || m.Producto.Producto_inventario == null) ? BoolCN.N : m.Producto.Producto_inventario.Manejalote),
                                                Manejaloteimportado = ((m.Producto == null || m.Producto.Producto_loteimportado == null) ? BoolCN.N : m.Producto.Producto_loteimportado.Manejaloteimportado)
                                            })
                                            .FirstOrDefault();

                if (movtoInfo == null)
                    throw new Exception("Movto no encontrado");

                productoId = movtoInfo.Productoid!.Value;
                cantidad = movtoInfo.Cantidad;
                tipoDoctoId = movtoInfo.Tipodoctoid!.Value;
                almacenId = movtoInfo.Almacenid;
                lote = movtoInfo.Lote;
                fechaVence = movtoInfo.Fechavence;
                loteImportado = movtoInfo.Loteimportado;
                esApartado = movtoInfo.Esapartado;
                esFacturaElectronica = movtoInfo.Esfacturaelectronica;
                doctoId = movtoInfo.Doctoid;
                origenFiscalId = movtoInfo.Origenfiscalid;

                negativos = movtoInfo.Negativos;
                inventariable = movtoInfo.Inventariable;
                manejaLote = movtoInfo.Manejalote;
                manejaLoteImportado = movtoInfo.Manejaloteimportado;

                sentidoInventario = movtoInfo.SentidoInventario;

                creadoPorUserId = movtoInfo.CreadoPorId;


                if (inventariable == BoolCS.N || sentidoInventario == 0)
                {
                    return;
                }



                if (manejaLoteImportado == BoolCN.S && manejarLoteImportacion == BoolCN.S &&
                     (loteImportado == null || loteImportado == 0))
                {
                    throw new Exception("No esta definido el lote importado y se requiere ");
                }

                if (manejaLote == BoolCN.S && (lote == null || lote == ""))
                    throw new Exception("No esta definido el lote y se requiere ");

                var existenciabuffer = localContext.Inventario.AsNoTracking()
                                                        .Where(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             (((origenFiscalId == null || origenFiscalId == 0) && (i.Origenfiscalid == null || i.Origenfiscalid == 0)) || (origenFiscalId != null && origenFiscalId.Value == i.Origenfiscalid)) &&
                                                             i.Productoid == productoId &&
                                                             (lote == null || lote.Trim() == "" || (lote == i.Lote && (fechaVence == i.Fechavence))) &&
                                                             (loteImportado == null || loteImportado == i.Loteimportado) &&
                                                             (((almacenId == null || almacenId == 0) && (i.Almacenid == null || i.Almacenid == 0)) || (almacenId != null && almacenId.Value == i.Almacenid)) &&
                                                             (esApartado == i.Esapartado)
                                                        ).
                                                        GroupBy(i => new { i.EmpresaId, i.SucursalId, i.Productoid })
                                                        .Select(g => new { Existencia = g.Sum(s => s.Cantidad) })
                                                        .FirstOrDefault();

                if (existenciabuffer != null)
                    existencia = existenciabuffer.Existencia;


                if ((existencia < cantidad && sentidoInventario == -1) ||
                    (origenFiscalId == null || origenFiscalId == 0))
                {
                    SeleccionOrigenFiscal(empresaId, sucursalId, productoId,
                                          cantidad, tipoDoctoId, almacenId,
                                          lote, fechaVence, loteImportado,
                                          esApartado, esFacturaElectronica,
                                          out cantidad_facturado, out cantidad_remisionado,
                                          out cantidad_indefinido, localContext);
                }
                else if ((origenFiscalId != null && origenFiscalId != 0))
                {

                    cantidad_remisionado = origenFiscalId == 2 ? cantidad : 0m;
                    cantidad_facturado = origenFiscalId == 3 ? cantidad : 0m;
                    cantidad_indefinido = origenFiscalId == 1 ? cantidad : 0m;
                }




                if (cantidad_remisionado > 0)
                {
                    Kardex_insert_transaccion(empresaId, sucursalId,
                                                BoolCS.S, DateTimeOffset.Now, creadoPorUserId, tipoDoctoId,
                                                doctoId!.Value, movtoId, DateTimeOffset.Now.Date, DateTimeOffset.Now,
                                                productoId, cantidad_remisionado * sentidoInventario, lote, fechaVence,
                                                loteImportado, almacenId, 2,
                                                esApartado, localContext);
                
                 }

                if (cantidad_facturado > 0)
                {
                    Kardex_insert_transaccion(empresaId, sucursalId,
                                                BoolCS.S, DateTimeOffset.Now, creadoPorUserId, tipoDoctoId,
                                                doctoId!.Value, movtoId, DateTimeOffset.Now.Date, DateTimeOffset.Now,
                                                productoId, cantidad_facturado * sentidoInventario, lote, fechaVence,
                                                loteImportado, almacenId, 3,
                                                esApartado, localContext);

                }

                if (cantidad_indefinido > 0)
                {
                    Kardex_insert_transaccion(empresaId, sucursalId,
                                                BoolCS.S, DateTimeOffset.Now, creadoPorUserId, tipoDoctoId,
                                                doctoId!.Value, movtoId, DateTimeOffset.Now.Date, DateTimeOffset.Now,
                                                productoId, cantidad_indefinido * sentidoInventario, lote, fechaVence,
                                                loteImportado, almacenId, 1,
                                                esApartado, localContext);

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




        public List<Tmp_MovtoLoteSeleccion> MovtoLoteSeleccion(long empresaId, long sucursalId, long productoId, long almacenId, 
                                                long? doctoId, ApplicationDbContext? localContext)
        {
            if (localContext == null) throw new Exception("El local context no puede ser nulo");

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var parametro = localContext.Parametro.AsNoTracking()
                                            .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId)
                                            .Select(p => new { p.Cortacaducidad })
                                            .FirstOrDefault();

                if (parametro == null)
                    throw new Exception("no hay parametro");


                var movtosInDocto = localContext.Movto.AsNoTracking()
                                                .Where(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId && i.Doctoid == doctoId && i.Productoid == productoId)
                                                .Select(m => new { m.Id,  m.Lote, m.Fechavence, m.Cantidad})
                                                .ToList();


                var lstInventarioLote = localContext.Inventario.AsNoTracking()
                                                      .Include(m => m.Producto)
                                                      .Include(m => m.Almacen)
                                                      .Where(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId && i.Productoid == productoId &&
                                                                    (i.Almacenid == almacenId || almacenId == 0))
                                                      .GroupBy(i => new {
                                                          i.EmpresaId,
                                                          i.SucursalId,
                                                          i.Productoid,
                                                          Productoclave = i.Producto != null ?  i.Producto.Clave : null,
                                                          Productonombre = i.Producto != null ? i.Producto.Nombre : null,
                                                          i.Lote ,
                                                          i.Fechavence,
                                                          i.Almacenid,
                                                          Almacenclave = i.Almacen != null ? i.Almacen.Clave : null,
                                                          Almacennombre = i.Almacen != null ? i.Almacen.Nombre : null,

                                                      })
                                                      .Select(i => new
                                                      {
                                                          i.Key.EmpresaId,
                                                          i.Key.SucursalId,
                                                          i.Key.Productoid,
                                                          i.Key.Productoclave,
                                                          i.Key.Productonombre,
                                                          i.Key.Lote,
                                                          i.Key.Fechavence,
                                                          i.Key.Almacenid,
                                                          i.Key.Almacenclave,
                                                          i.Key.Almacennombre,
                                                          Cantidad = i.Sum(g => g.Cantidad)
                                                      }).ToList()
                                                      .Select( i => new Tmp_MovtoLoteSeleccion(

                                                          i.EmpresaId,
                                                          i.SucursalId,
                                                          i.Productoid,
                                                          i.Productoclave,
                                                          i.Productonombre,
                                                          i.Lote,
                                                          i.Fechavence,
                                                          i.Almacenid,
                                                          i.Almacenclave,
                                                          i.Almacennombre,
                                                          i.Cantidad,
i.Fechavence == null ? true : (i.Fechavence!.Value.Date < DateTimeOffset.Now.Date),
i.Fechavence == null ? true : (i.Fechavence!.Value.Date < DateTimeOffset.Now.Date.AddDays(parametro.Cortacaducidad * -1)),
movtosInDocto.Sum(x => x.Fechavence == i.Fechavence && x.Lote == i.Lote ? x.Cantidad : 0m)


                                                      )).ToList();

                return lstInventarioLote;


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


        public List<Tmp_MovtoLoteImportadoSeleccion> MovtoLoteImportadoSeleccion(long empresaId, long sucursalId, long productoId, long almacenId,
                                                long? doctoId, ApplicationDbContext? localContext)
        {
            if (localContext == null) throw new Exception("El local context no puede ser nulo");

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var parametro = localContext.Parametro.AsNoTracking()
                                            .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId)
                                            .Select(p => new { p.Cortacaducidad })
                                            .FirstOrDefault();

                if (parametro == null)
                    throw new Exception("no hay parametro");


                var movtosInDocto = localContext.Movto.AsNoTracking()
                                                .Where(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId && i.Doctoid == doctoId && i.Productoid == productoId)
                                                .Select(m => new { m.Id, m.Lote, m.Fechavence, m.Loteimportado, m.Cantidad })
                                                .ToList();


                var lstInventarioLote = localContext.Inventario.AsNoTracking()
                                                      .Include(m => m.Producto)
                                                      .Include(m => m.Almacen)
                                                      .Where(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId && i.Productoid == productoId &&
                                                                    (i.Almacenid == almacenId || almacenId == 0))
                                                      .GroupBy(i => new {
                                                          i.EmpresaId,
                                                          i.SucursalId,
                                                          i.Productoid,
                                                          Productoclave = i.Producto != null ? i.Producto.Clave : null,
                                                          Productonombre = i.Producto != null ? i.Producto.Nombre : null,
                                                          i.Lote,
                                                          i.Fechavence,
                                                          i.Almacenid,
                                                          Almacenclave = i.Almacen != null ? i.Almacen.Clave : null,
                                                          Almacennombre = i.Almacen != null ? i.Almacen.Nombre : null,
                                                          i.Loteimportado,
                                                          i.Loteimportado_!.Pedimento,
                                                          i.Loteimportado_!.Fechaimportacion

                                                      })
                                                      .Select(i => new
                                                      {
                                                          i.Key.EmpresaId,
                                                          i.Key.SucursalId,
                                                          i.Key.Productoid,
                                                          i.Key.Productoclave,
                                                          i.Key.Productonombre,
                                                          i.Key.Lote,
                                                          i.Key.Fechavence,
                                                          i.Key.Almacenid,
                                                          i.Key.Almacenclave,
                                                          i.Key.Almacennombre,
                                                          i.Key.Loteimportado,
                                                          i.Key.Pedimento,
                                                          i.Key.Fechaimportacion,
                                                          Cantidad = i.Sum(g => g.Cantidad)
                                                      }).ToList()
                                                      .Select(i => new Tmp_MovtoLoteImportadoSeleccion(

                                                          i.EmpresaId,
                                                          i.SucursalId,
                                                          i.Productoid,
                                                          i.Productoclave,
                                                          i.Productonombre,
                                                          i.Lote,
                                                          i.Fechavence,
                                                          i.Almacenid,
                                                          i.Almacenclave,
                                                          i.Almacennombre,
                                                          i.Loteimportado,
                                                          i.Pedimento,
                                                          i.Cantidad,
                                                          i.Fechaimportacion,
                    movtosInDocto.Sum(x => x.Fechavence == i.Fechavence && x.Lote == i.Lote && x.Loteimportado == i.Loteimportado ? x.Cantidad : 0m)


                                                      )).ToList();

                return lstInventarioLote;


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




    }

    public class KitDefinicionAux
    {
        public long EmpresaId { get; set; }
        public long SucursalId { get; set; }
        public long? Productoparteid { get; set; }
        public decimal Cantidadparte { get; set; }
    }

    public class Tmp_MovtoLoteSeleccion
    {
        public long EmpresaId { get; }
        public long SucursalId { get; }
        public long? Productoid { get; }
        public string? Productoclave { get; }
        public string? Productonombre { get; }
        public string? Lote { get; }
        public DateTimeOffset? Fechavence { get; }
        public long? Almacenid { get; }
        public string? Almacenclave { get; }
        public string? Almacennombre { get; }
        public decimal Cantidad { get; }
        public bool Caducado { get; }
        public bool Porcaducar { get; }
        public decimal Cantidadendocto { get; }

        public Tmp_MovtoLoteSeleccion(long empresaId, long sucursalId, long? productoid, string? productoclave, string? productonombre, string? lote, DateTimeOffset? fechavence, long? almacenid, string? almacenclave, string? almacennombre, decimal cantidad, bool caducado, bool porcaducar, decimal cantidadendocto)
        {
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            Productoid = productoid;
            Productoclave = productoclave;
            Productonombre = productonombre;
            Lote = lote;
            Fechavence = fechavence;
            Almacenid = almacenid;
            Almacenclave = almacenclave;
            Almacennombre = almacennombre;
            Cantidad = cantidad;
            Caducado = caducado;
            Porcaducar = porcaducar;
            Cantidadendocto = cantidadendocto;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_MovtoLoteSeleccion other &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   Productoid == other.Productoid &&
                   Productoclave == other.Productoclave &&
                   Productonombre == other.Productonombre &&
                   Lote == other.Lote &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence, other.Fechavence) &&
                   Almacenid == other.Almacenid &&
                   Almacenclave == other.Almacenclave &&
                   Almacennombre == other.Almacennombre &&
                   Cantidad == other.Cantidad &&
                   Caducado == other.Caducado &&
                   Porcaducar == other.Porcaducar &&
                   Cantidadendocto == other.Cantidadendocto;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(EmpresaId);
            hash.Add(SucursalId);
            hash.Add(Productoid);
            hash.Add(Productoclave);
            hash.Add(Productonombre);
            hash.Add(Lote);
            hash.Add(Fechavence);
            hash.Add(Almacenid);
            hash.Add(Almacenclave);
            hash.Add(Almacennombre);
            hash.Add(Cantidad);
            hash.Add(Caducado);
            hash.Add(Porcaducar);
            hash.Add(Cantidadendocto);
            return hash.ToHashCode();
        }
    }

    public class Tmp_MovtoLoteImportadoSeleccion : TransitionClass
    {
        public long EmpresaId { get; }
        public long SucursalId { get; }
        public long? Productoid { get; }
        public string? Productoclave { get; }
        public string? Productonombre { get; }
        public string? Lote { get; }
        public DateTimeOffset? Fechavence { get; }
        public long? Almacenid { get; }
        public string? Almacenclave { get; }
        public string? Almacennombre { get; }
        public long? Loteimportado { get; }
        public string? Pedimento { get; }
        public decimal Cantidad { get; }
        public DateTimeOffset? Fechaimportacion { get; }

        public decimal Cantidadendocto { get; }

       public Tmp_MovtoLoteImportadoSeleccion()
        {

        }

        public Tmp_MovtoLoteImportadoSeleccion(long empresaId, long sucursalId, long? productoid, string? productoclave, string? productonombre, string? lote, DateTimeOffset? fechavence, long? almacenid, string? almacenclave, string? almacennombre, long? loteimportado, string? pedimento, decimal cantidad, DateTimeOffset? fechaimportacion, decimal cantidadendocto)
        {
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            Productoid = productoid;
            Productoclave = productoclave;
            Productonombre = productonombre;
            Lote = lote;
            Fechavence = fechavence;
            Almacenid = almacenid;
            Almacenclave = almacenclave;
            Almacennombre = almacennombre;
            Loteimportado = loteimportado;
            Pedimento = pedimento;
            Cantidad = cantidad;
            Fechaimportacion = fechaimportacion;
            Cantidadendocto = cantidadendocto;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_MovtoLoteImportadoSeleccion other &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   Productoid == other.Productoid &&
                   Productoclave == other.Productoclave &&
                   Productonombre == other.Productonombre &&
                   Lote == other.Lote &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence, other.Fechavence) &&
                   Almacenid == other.Almacenid &&
                   Almacenclave == other.Almacenclave &&
                   Almacennombre == other.Almacennombre &&
                   Loteimportado == other.Loteimportado &&
                   Pedimento == other.Pedimento &&
                   Cantidad == other.Cantidad;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(EmpresaId);
            hash.Add(SucursalId);
            hash.Add(Productoid);
            hash.Add(Productoclave);
            hash.Add(Productonombre);
            hash.Add(Lote);
            hash.Add(Fechavence);
            hash.Add(Almacenid);
            hash.Add(Almacenclave);
            hash.Add(Almacennombre);
            hash.Add(Loteimportado);
            hash.Add(Pedimento);
            hash.Add(Cantidad);
            return hash.ToHashCode();
        }
    }
}
