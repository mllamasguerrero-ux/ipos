using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;
//using Syncfusion.Windows.Controls;
using IposV3.Services.FacturaElectronica;
using System.Globalization;
using System.IO;
using System.Xml;
using IposV3.Services.Extensions;
using static IposV3.Services.FacturaElectronica.VirtualXmlHelper;

namespace IposV3.Services
{
    public class ConsolidacionService
    {


        private DoctoService _doctoService;
        private MovtoService _movtoService;
        private CorteService _corteService;
        public ConsolidacionService(
            DoctoService doctoService,
            MovtoService movtoService,
            CorteService corteService)
        {
            _doctoService = doctoService;
            _movtoService = movtoService;
            _corteService = corteService;
        }

        public List<Tmp_docto_porconsolidar> Docto_porconsolidar(long empresaId, long sucursalId, 
                                                               DateTimeOffset fechaIni, DateTimeOffset fechaFin,
                                                               BoolCN omitirVentasFranquicias, BoolCN incluirGastos,
                                                               decimal maximoMonto, BoolCN omitirVales,
                                                               BoolCN sumaCompletaVentas, long? grupoUsuarioId,
                                                               BoolCN omitirClientesRfc, decimal maximoPorcentaje, 
                                                               BoolCN omitirPagoTarjeta, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var parametro = localContext.Parametro.AsNoTracking()
                                            .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId)
                                            .Select(p => new { p.Pagoservconsolidado })
                                            .FirstOrDefault();

                if (parametro == null)
                    throw new Exception("no hay parametro");


                var lstBufferVentas = localContext.Docto.AsNoTracking()
                                                      .Include(d => d!.Docto_fact_elect)
                                                      .Include(d => d.Docto_fact_elect_consolidacion)
                                                      .Include(d => d.Usuario).ThenInclude(u => u!.Usuario_Preferencias)
                                                      .Include(d => d.Cliente)
                                                      .Include(d => d.Doctopagos).ThenInclude(dp => dp!.Pago)
                                                      .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                                                  (d.Fecha >= fechaIni && d.Fecha <= fechaFin) &&
                                                                   d.Docto_fact_elect!.Esfacturaelectronica != BoolCN.S &&
                                                                   d.Estatusdoctoid == 1 && d.Tipodoctoid == 21 &&
                                                                   (d.Docto_fact_elect_consolidacion!.Factconsid ?? 0) == 0 &&
                                                                   (d.Docto_fact_elect_consolidacion.Devconsid ?? 0) == 0 &&
                                                                   ( ( omitirVentasFranquicias == BoolCN.N) || (d.Subtipodoctoid != 7 && d.Subtipodoctoid != 8)) &&
                                                                   (( parametro!.Pagoservconsolidado  == BoolCN.S) || (d.Subtipodoctoid != 24 && d.Subtipodoctoid != 22) ) &&
                                                                   (( (grupoUsuarioId ?? 0) == 0 ) || (d.Usuario!.Usuario_Preferencias!.Grupousuarioid == grupoUsuarioId)) &&
                                                                   (( omitirClientesRfc == BoolCN.N) || ( (d.Cliente!.Rfc ?? "") == "" || (d.Cliente!.Rfc ?? "") == "XAXX010101000"))
                                                              
                                                      )
                                                      .Select(d => new Tmp_docto_porconsolidar(
                                                          d.EmpresaId,
                                                          d.SucursalId,
                                                          d.Id,
                                                          d.Fecha,
                                                          d.Serie,
                                                          d.Folio,
                                                          d.Importe,
                                                          d.Descuento,
                                                          d.Subtotal,
                                                          d.Iva,
                                                          d.Ieps,
                                                          d.Total,
                                                          d.Tipodoctoid,
                                                          (d.Docto_fact_elect != null ? d.Docto_fact_elect!.Ivaretenido : 0m),
                                                          (d.Docto_fact_elect != null ? d.Docto_fact_elect!.Isrretenido : 0m),
                                                          d.Saldo,
                                                          (d.Doctopagos != null ? d.Doctopagos!.Where(dp => dp.Pago!.Revertido != BoolCN.S && dp.Pago!.Formapagoid == 5).Sum(p => p.Importe) : 0m),
                                                          (d.Doctopagos != null ? d.Doctopagos.Where(dp => dp.Pago!.Revertido != BoolCN.S && dp.Pago!.Formapagoid == 2).Sum(p => p.Importe) : 0m),
                                                          0m, 1, null, BoolCS.S, null, BoolCN.N



                                                      )).ToList();

                


                var lstBufferDevoluciones = localContext.Docto.AsNoTracking()
                                                      .Include(d => d.Docto_devolucion).ThenInclude(dv => dv!.Doctoref)
                                                      .Include(d => d.Docto_devolucion).ThenInclude(dv => dv!.Doctoref).ThenInclude(d => d!.Docto_fact_elect)
                                                      .Include(d => d.Docto_devolucion).ThenInclude(dv => dv!.Doctoref).ThenInclude(d => d!.Docto_fact_elect_consolidacion)
                                                      .Include(d => d.Docto_devolucion).ThenInclude(dv => dv!.Doctoref).ThenInclude(d => d!.Usuario).ThenInclude(u => u!.Usuario_Preferencias)
                                                      .Include(d => d.Docto_devolucion).ThenInclude(dv => dv!.Doctoref).ThenInclude(d => d!.Cliente)
                                                      .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                                                  (d.Docto_devolucion!.Doctoref!.Fecha >= fechaIni && d.Docto_devolucion!.Doctoref!.Fecha <= fechaFin) &&
                                                                   d.Docto_devolucion!.Doctoref!.Docto_fact_elect!.Esfacturaelectronica != BoolCN.S &&
                                                                   d.Estatusdoctoid == 1 && d.Tipodoctoid == 22 &&
                                                                   (d.Docto_devolucion!.Doctoref!.Docto_fact_elect_consolidacion!.Factconsid ?? 0) == 0 &&
                                                                   (d.Docto_devolucion!.Doctoref!.Docto_fact_elect_consolidacion.Devconsid ?? 0) == 0 &&
                                                                   ((omitirVentasFranquicias == BoolCN.N) || (d.Docto_devolucion!.Doctoref!.Subtipodoctoid != 7 && d.Docto_devolucion!.Doctoref!.Subtipodoctoid != 8)) &&
                                                                   ((parametro!.Pagoservconsolidado == BoolCN.S) || (d.Docto_devolucion!.Doctoref!.Subtipodoctoid != 24 && d.Docto_devolucion!.Doctoref!.Subtipodoctoid != 22)) &&
                                                                   (((grupoUsuarioId ?? 0) == 0) || (d.Docto_devolucion!.Doctoref!.Usuario!.Usuario_Preferencias!.Grupousuarioid == grupoUsuarioId)) &&
                                                                   ((omitirClientesRfc == BoolCN.N) || ((d.Docto_devolucion!.Doctoref!.Cliente!.Rfc ?? "") == "" || (d.Docto_devolucion!.Doctoref!.Cliente!.Rfc ?? "") == "XAXX010101000"))

                                                      )
                                                      .Select(d => new Tmp_docto_porconsolidar(
                                                          d.EmpresaId,
                                                          d.SucursalId,
                                                          d.Id,
                                                          d.Fecha,
                                                          d.Serie,
                                                          d.Folio,
                                                          d.Importe * -1,
                                                          d.Descuento * -1,
                                                          d.Subtotal * -1,
                                                          d.Iva * -1,
                                                          d.Ieps * -1,
                                                          d.Total * -1,
                                                          d.Tipodoctoid,
                                                          (d.Docto_fact_elect != null ? d.Docto_fact_elect!.Ivaretenido * -1 : 0m),
                                                          (d.Docto_fact_elect != null ? d.Docto_fact_elect!.Isrretenido * -1 : 0m),
                                                          d.Saldo,
                                                          0m,
                                                          0m,
                                                          0m, 3, null, BoolCS.S, d.Docto_devolucion!.Doctorefid, BoolCN.N



                                                      )).ToList();

                if(omitirVales == BoolCN.S || omitirPagoTarjeta == BoolCN.S)
                {
                    lstBufferVentas.ForEach(l =>
                                                 {

                                                     if (
                                                         l.Total > 0 &&
                                                         (
                                                            (omitirVales == BoolCN.S && l.Abonoconvale > 0m) || 
                                                            (omitirPagoTarjeta == BoolCN.S && l.Abonocontarjeta > 0m)
                                                         ))
                                                     {
                                                         

                                                         var bufferTotal = l.Total - ((omitirVales == BoolCN.S ? l.Abonoconvale : 0m) +
                                                                           (omitirPagoTarjeta == BoolCN.S ? l.Abonocontarjeta : 0m) +
                                                                           (lstBufferDevoluciones != null ? lstBufferDevoluciones.Where(d => d.Doctorefid == l.Id).Sum(d => d.Total)
                                                                                                          : 0m)
                                                                             );
                                                         var totalOriginal = l.Total;
                                                         l.Total = bufferTotal > 0m ? bufferTotal : 0m;
                                                         var porcentajeCambio = l.Total / totalOriginal;

                                                         l.Iva = l.Total == 0m ? 0m : Math.Round(l.Iva * porcentajeCambio, 2);
                                                         l.Ieps = l.Total == 0m ? 0m : Math.Round(l.Ieps * porcentajeCambio, 2);
                                                         l.Descuento = 0m;
                                                         l.Subtotal = l.Total == 0m ? 0m : l.Total - l.Iva - l.Ieps;
                                                         l.Importe = l.Subtotal;
                                                         l.Ivaretenido = l.Total == 0m ? 0m : Math.Round(l.Ivaretenido * porcentajeCambio, 2);
                                                         l.Isrretenido = l.Total == 0m ? 0m : Math.Round(l.Isrretenido * porcentajeCambio, 2);
                                                         l.Montosajustados = BoolCN.S;

                                                         if (l.Total == 0)
                                                             l.Aplicado = BoolCS.N;

                                                         if (lstBufferDevoluciones != null)
                                                         {
                                                             foreach (var dev in lstBufferDevoluciones.Where(d => d.Doctorefid == l.Id))
                                                             {
                                                                 dev.Aplicado = BoolCS.N;

                                                             }
                                                         }
                                                     }
                                                 });
                    
                }

                if (incluirGastos != BoolCN.S)
                {
                    lstBufferDevoluciones.ForEach(l => l.Aplicado = BoolCS.N);
                }


                lstBufferVentas.Sort((s1, s2) => s1.Id.CompareTo(s2.Id));

                if(maximoPorcentaje > 0 && maximoMonto == 0)
                {
                    maximoMonto = (lstBufferVentas?.Sum(l => l.Total) ?? 0m) -
                                   (lstBufferDevoluciones?.Where(l => l.Aplicado == BoolCS.S).Sum(l => l.Total) ?? 0m);
                }

                if(maximoMonto > 0)
                {
                    decimal montoAcumulado = 0m;
                    for (int i = 0; i < (lstBufferVentas?.Count ?? 0); i++)
                    {

                        if ( montoAcumulado < maximoMonto)
                        {
                            montoAcumulado += lstBufferVentas![i].Total;
                        }
                        else
                        {
                            lstBufferVentas![i].Aplicado = BoolCS.N;
                        }
                    }
                }

                if(lstBufferDevoluciones != null && lstBufferVentas != null )
                {
                    lstBufferDevoluciones!.ForEach(l =>
                    {
                        if (l.Aplicado == BoolCS.S &&
                                                      lstBufferVentas!.Any(b => b.Id == l.Doctorefid && b.Aplicado == BoolCS.N))
                        {
                            l.Aplicado = BoolCS.N;
                        }
                    });
                }


                var lstBuffer = new List<Tmp_docto_porconsolidar>();
                if(lstBufferVentas != null)
                    lstBuffer.AddRange(lstBufferVentas);
                if (lstBufferDevoluciones != null)
                    lstBuffer.AddRange(lstBufferDevoluciones);

                return lstBuffer ;


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



        public bool Consolidar(long empresaId, long sucursalId,
                                                               DateTimeOffset fechaIni, DateTimeOffset fechaFin,
                                                               BoolCN omitirVentasFranquicias, BoolCN incluirGastos,
                                                               decimal maximoMonto, BoolCN omitirVales,
                                                               BoolCN sumaCompletaVentas, long? grupoUsuarioId,
                                                               BoolCN omitirClientesRfc, decimal maximoPorcentaje,
                                                               BoolCN omitirPagoTarjeta,
                                                               long usuarioId,
                                                               ref long? doctoConsolidadoId,
                                                               ApplicationDbContext localContext)
        {


            long? corteid;
            BoolCS? corte_activo;
            DateTimeOffset? fechacorte;
            DateTimeOffset? corte_inicia;
            DateTimeOffset? corte_termina;

            doctoConsolidadoId = null;


            try
            {


                var parametro = localContext.Parametro.AsNoTracking()
                                            .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId)
                                            .Select(p => new { p.Clienteconsolidadoid })
                                            .FirstOrDefault();

                if (parametro == null)
                    throw new Exception("no hay parametro");

                var sucursal = localContext.Sucursal.AsNoTracking()
                                            .Where(p => p.EmpresaId == empresaId && p.Id == sucursalId)
                                            .Select(p => new { p.Clave })
                                            .FirstOrDefault();

                if (sucursal == null)
                    throw new Exception("no hay sucursal");

                long? sucursal_id = localContext.Sucursal_info.AsNoTracking()
                                            .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId &&
                                                        p.Clave == sucursal.Clave)
                                            .Select(p => p.Id)
                                            .FirstOrDefault();


                _corteService.HayCorteActivo(empresaId, sucursalId, usuarioId,
                                               out corteid, out corte_activo, out fechacorte, out corte_inicia, out corte_termina, localContext);

                if (corteid == null || corteid == 0)
                {
                    throw new Exception("No hay corte activo");
                }


                var listaAConsolidar = Docto_porconsolidar(empresaId, sucursalId, fechaIni, fechaFin,
                                                       omitirVentasFranquicias, incluirGastos,
                                                       maximoMonto, omitirVales,
                                                       sumaCompletaVentas, grupoUsuarioId,
                                                       omitirClientesRfc, maximoPorcentaje,
                                                       omitirPagoTarjeta, localContext);

                if(listaAConsolidar == null || listaAConsolidar.Count == 0)
                {
                    return true;
                }



                var totales = new Tmp_suma_docto_porconsolidar(empresaId, sucursalId, listaAConsolidar);

                var aConsolidar = listaAConsolidar.Where(l => l.Tipoaplicacionid == 1).GroupBy(g => g.EmpresaId)
                    .Select(l => new { MinFolio = l.Min(g => g.Folio), MaxFolio = l.Max(g => g.Folio) })
                    .FirstOrDefault();

                var referencia = aConsolidar != null ?
                                  "Del folio " + aConsolidar.MinFolio.ToString() + " al folio " + aConsolidar.MaxFolio.ToString()
                                  : "";


                var doctoTrans = new DoctoTransaction()
                {
                    Empresaid = empresaId,
                    Sucursalid = sucursalId,
                    Activo = BoolCS.S,
                    Creado = DateTimeOffset.Now,
                    Creadopor_userid = usuarioId,
                    Estatusdoctoid = 0,
                    Usuarioid = usuarioId,
                    Corteid = corteid,
                    Fecha = DateTimeOffset.Now,
                    Fechahora =  DateTimeOffset.Now,
                    Serie = null,
                    Folio = null,
                    Importe = totales.Importe,
                    Descuento = totales.Descuento,
                    Subtotal = totales.Subtotal,
                    Iva = totales.Iva,
                    Ieps = totales.Ieps,
                    Total = totales.Total,
                    Cargo = totales.Total,
                    Abono = totales.Total - totales.Saldo,
                    Saldo = totales.Saldo,
                    Cajaid = null,
                    Almacenid = null,
                    Origenfiscalid = null,
                    Esapartado = BoolCN.N,
                    Doctoparentid = null,
                    Clienteid = parametro.Clienteconsolidadoid ?? 1,
                    Tipodoctoid = DBValues._DOCTO_TIPO_FACTCONSOLIDADA,
                    Proveedorid = null,
                    Sucursal_id = sucursal_id,
                    Referencia = referencia,
                    Referencias = "FACTURA CONSOLIDADA",
                    Fechavence = null

                };
                _doctoService.DoctoInsert(doctoTrans, ref doctoConsolidadoId, localContext);


                foreach(var item in listaAConsolidar)
                {
                    var doctoCons = localContext.Docto_fact_elect_consolidacion.FirstOrDefault(
                                                   f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Doctoid == item.Id);
                    if (doctoCons != null)
                    {
                        doctoCons.Factconsaplicado = item.Aplicado == BoolCS.S ? BoolCN.S : BoolCN.N;
                        doctoCons.Omitirvales = omitirVales;
                        doctoCons.Factconsid = doctoConsolidadoId;
                        doctoCons.Fecha_ini = fechaIni;
                        doctoCons.Fecha_fin = fechaFin;
                        doctoCons.Consolidado_subtotal = item.Aplicado != BoolCS.S ? 0m : item.Subtotal;
                        doctoCons.Consolidado_iva = item.Aplicado != BoolCS.S ? 0m : item.Iva;
                        doctoCons.Consolidado_ieps = item.Aplicado != BoolCS.S ? 0m : item.Ieps;
                        doctoCons.Consolidado_total = item.Aplicado != BoolCS.S ? 0m : item.Total;
                        doctoCons.Consolidado_iva_ret = item.Aplicado != BoolCS.S ? 0m : item.Ivaretenido;
                        doctoCons.Consolidado_isr_ret = item.Aplicado != BoolCS.S ? 0m : item.Isrretenido;

                        localContext.Update(doctoCons);
                    }
                    else
                    {
                        doctoCons = new Docto_fact_elect_consolidacion();
                        doctoCons.EmpresaId = empresaId;
                        doctoCons.SucursalId = sucursalId;
                        doctoCons.Doctoid = item.Id;
                        doctoCons.Devconsid = null;
                        doctoCons.Doctorefid2 = null;
                        doctoCons.Factconsaplicado = item.Aplicado == BoolCS.S ? BoolCN.S : BoolCN.N;
                        doctoCons.Omitirvales = omitirVales;
                        doctoCons.Factconsid = doctoConsolidadoId;
                        doctoCons.Fecha_ini = fechaIni;
                        doctoCons.Fecha_fin = fechaFin;
                        doctoCons.Consolidado_subtotal = item.Aplicado != BoolCS.S ?  0m : item.Subtotal;
                        doctoCons.Consolidado_iva = item.Aplicado != BoolCS.S ? 0m : item.Iva;
                        doctoCons.Consolidado_ieps = item.Aplicado != BoolCS.S ? 0m : item.Ieps;
                        doctoCons.Consolidado_total = item.Aplicado != BoolCS.S ? 0m : item.Total;
                        doctoCons.Consolidado_iva_ret = item.Aplicado != BoolCS.S ? 0m : item.Ivaretenido;
                        doctoCons.Consolidado_isr_ret = item.Aplicado != BoolCS.S ? 0m : item.Isrretenido;

                        localContext.Add(doctoCons);


                    }

                    var doctoImpuestos = localContext.Docto_impuestos.Where(
                                                   f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Doctoid == item.Id).ToList();

                    if (item.Montosajustados != BoolCN.S)
                    {
                        foreach (var doctoImpuesto in doctoImpuestos)
                        {
                            doctoImpuesto.Consolidado_Monto = item.Aplicado == BoolCS.N ? 0m : (item.Tipoaplicacionid == 3 ? doctoImpuesto.Monto  * -1 : doctoImpuesto.Monto);
                            doctoImpuesto.Consolidado_Base = item.Aplicado == BoolCS.N ? 0m : (item.Tipoaplicacionid == 3 ? doctoImpuesto.Base * -1 : doctoImpuesto.Base);

                            localContext.Update(doctoImpuesto);
                        }
                    }
                    else
                    {
                        //iva
                        if(item.Iva > 0)
                        {


                            var listaAProrreatear = doctoImpuestos.Where(d => d.Tipoimpuestoid == 2)
                                                                  .Select(x => new Prorrateo()
                                                                  {
                                                                      Id = x.Id,
                                                                      Cantidad = x.Monto,
                                                                      CantidadProrrateada = 0
                                                                  }).ToList();


                            MathIpos.Prorratear(item.Iva, 2, ref listaAProrreatear);

                            foreach (var doctoImpuesto in doctoImpuestos.Where(d => d.Tipoimpuestoid == 2))
                            {
                                if (doctoImpuesto.Tasaimpuesto == 0)
                                {
                                    doctoImpuesto.Consolidado_Monto = 0m;
                                    doctoImpuesto.Consolidado_Base = 0m;
                                }
                                else
                                {

                                    var prorrateoInfo = listaAProrreatear.SingleOrDefault(y => y.Id == item.Id);
                                    if (prorrateoInfo != null)
                                    {
                                        doctoImpuesto.Consolidado_Monto = prorrateoInfo.CantidadProrrateada;
                                        doctoImpuesto.Consolidado_Base = Decimal.Round((prorrateoInfo.CantidadProrrateada * 100) / doctoImpuesto.Tasaimpuesto, 4);
                                    }
                                }


                                localContext.Update(doctoImpuesto);
                            }
                        }

                        //ieps
                        if(item.Ieps > 0)
                        {


                            var listaAProrreatear = doctoImpuestos.Where(d => d.Tipoimpuestoid == 3)
                                                                  .Select(x => new Prorrateo()
                            {
                                Id = x.Id,
                                Cantidad = x.Monto,
                                CantidadProrrateada = 0
                            }).ToList();


                            MathIpos.Prorratear(item.Ieps, 2, ref listaAProrreatear);

                            foreach (var doctoImpuesto in doctoImpuestos.Where(d => d.Tipoimpuestoid == 3))
                            {
                                if (doctoImpuesto.Tasaimpuesto == 0)
                                {
                                    doctoImpuesto.Consolidado_Monto = 0m;
                                    doctoImpuesto.Consolidado_Base = 0m;
                                }
                                else
                                {

                                    var prorrateoInfo = listaAProrreatear.SingleOrDefault(y => y.Id == item.Id);
                                    if (prorrateoInfo != null)
                                    {
                                        doctoImpuesto.Consolidado_Monto = prorrateoInfo.CantidadProrrateada;
                                        doctoImpuesto.Consolidado_Base = Decimal.Round((prorrateoInfo.CantidadProrrateada * 100) / doctoImpuesto.Tasaimpuesto, 4);
                                    }
                                }


                                localContext.Update(doctoImpuesto);
                            }


                        }

                        //iva retenido
                        if (item.Ivaretenido > 0)
                        {


                            var listaAProrreatear = doctoImpuestos.Where(d => d.Tipoimpuestoid == 1002)
                                                                  .Select(x => new Prorrateo()
                                                                  {
                                                                      Id = x.Id,
                                                                      Cantidad = x.Monto,
                                                                      CantidadProrrateada = 0
                                                                  }).ToList();


                            MathIpos.Prorratear(item.Ivaretenido, 2, ref listaAProrreatear);

                            foreach (var doctoImpuesto in doctoImpuestos.Where(d => d.Tipoimpuestoid == 1002))
                            {
                                if (doctoImpuesto.Tasaimpuesto == 0)
                                {
                                    doctoImpuesto.Consolidado_Monto = 0m;
                                    doctoImpuesto.Consolidado_Base = 0m;
                                }
                                else
                                {

                                    var prorrateoInfo = listaAProrreatear.SingleOrDefault(y => y.Id == item.Id);
                                    if (prorrateoInfo != null)
                                    {
                                        doctoImpuesto.Consolidado_Monto = prorrateoInfo.CantidadProrrateada;
                                        doctoImpuesto.Consolidado_Base = Decimal.Round((prorrateoInfo.CantidadProrrateada * 100) / doctoImpuesto.Tasaimpuesto, 4);
                                    }
                                }


                                localContext.Update(doctoImpuesto);
                            }
                        }



                        //isr retenido
                        if (item.Isrretenido > 0)
                        {


                            var listaAProrreatear = doctoImpuestos.Where(d => d.Tipoimpuestoid == 1001)
                                                                  .Select(x => new Prorrateo()
                                                                  {
                                                                      Id = x.Id,
                                                                      Cantidad = x.Monto,
                                                                      CantidadProrrateada = 0
                                                                  }).ToList();


                            MathIpos.Prorratear(item.Isrretenido, 2, ref listaAProrreatear);

                            foreach (var doctoImpuesto in doctoImpuestos.Where(d => d.Tipoimpuestoid == 1003))
                            {
                                if (doctoImpuesto.Tasaimpuesto == 0)
                                {
                                    doctoImpuesto.Consolidado_Monto = 0m;
                                    doctoImpuesto.Consolidado_Base = 0m;
                                }
                                else
                                {

                                    var prorrateoInfo = listaAProrreatear.SingleOrDefault(y => y.Id == item.Id);
                                    if (prorrateoInfo != null)
                                    {
                                        doctoImpuesto.Consolidado_Monto = prorrateoInfo.CantidadProrrateada;
                                        doctoImpuesto.Consolidado_Base = Decimal.Round((prorrateoInfo.CantidadProrrateada * 100) / doctoImpuesto.Tasaimpuesto, 4);
                                    }
                                }


                                localContext.Update(doctoImpuesto);
                            }
                        }


                    }





                    localContext.SaveChanges();


                }

                var doctoConsolidadoIdDummy = doctoConsolidadoId;

                var doctoImpuestosAgrupados = localContext.Docto_impuestos.AsNoTracking()
                                                          .Include(d => d.Docto).ThenInclude(d => d.Docto_fact_elect_consolidacion)
                                                          .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && 
                                                                       d.Docto!.Docto_fact_elect_consolidacion!.Factconsaplicado == BoolCN.S &&
                                                                      d.Docto!.Docto_fact_elect_consolidacion!.Factconsid == doctoConsolidadoIdDummy)
                                                          .GroupBy(f => new { f.EmpresaId, f.SucursalId, f.Tipoimpuestoid, f.Tasaimpuesto })
                                                          .Select(d => new
                                                          {
                                                              d.Key.Tipoimpuestoid,
                                                              d.Key.Tasaimpuesto,
                                                              Base = d.Sum(g => g.Consolidado_Base),
                                                              Monto = d.Sum(g => g.Consolidado_Monto)
                                                          })
                                                          .ToList();
                if(doctoImpuestosAgrupados != null)
                {
                    foreach(var doctoimp in doctoImpuestosAgrupados)
                    {
                        var doctoImpuesto = new Docto_impuestos();

                        doctoImpuesto.EmpresaId = empresaId;
                        doctoImpuesto.SucursalId = sucursalId;
                        doctoImpuesto.Doctoid = doctoConsolidadoId;

                        doctoImpuesto.Base = doctoimp.Base;
                        doctoImpuesto.Consolidado_Base = doctoimp.Base;
                        doctoImpuesto.Tipoimpuestoid = doctoimp.Tipoimpuestoid;
                        doctoImpuesto.Tasaimpuesto = doctoimp.Tasaimpuesto;
                        doctoImpuesto.Monto = doctoimp.Monto;
                        doctoImpuesto.Consolidado_Monto = doctoimp.Monto;
                        
                        localContext.Add(doctoImpuesto);

                    }
                    localContext.SaveChanges();
                }
                                                          
                                                          


            }
            catch
            {
                throw;
            }


            return true;
        }



       

    }



}
