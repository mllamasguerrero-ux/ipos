using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace IposV3.Services
{
    public class PagoService
    {


        private MaestroConsecutivoService _maestroConsecutivoService;
        public PagoService(MaestroConsecutivoService maestroConsecutivoService)
        {
            _maestroConsecutivoService = maestroConsecutivoService;
        }


        public void Docto_pago_complete(long empresaId, long sucursalId, long id, long usuarioId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var docto_pago_info = localContext.Doctopago.AsNoTracking()
                                                  .Include(d => d.Docto).ThenInclude(t => t!.Tipodocto)
                                                  .Include(d => d.Formapago)
                                                  .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == id)
                                                  .Select(doctopago => new
                                                  {
                                                      doctopago.Activo,
                                                      doctopago.Creado,
                                                      doctopago.CreadoPorId,
                                                      doctopago.Modificado,
                                                      doctopago.ModificadoPorId,
                                                      doctopago.Doctoid,
                                                      doctopago.Fecha,
                                                      doctopago.Fechahora,
                                                      doctopago.Corteid,
                                                      doctopago.Importe,
                                                      doctopago.Tipopagoid,
                                                      doctopago.Tipoabonoid,
                                                      doctopago.Estatusdoctopagoid,
                                                      doctopago.Sentidopago,
                                                      doctopago.Formapagoid,
                                                      doctopago.Pagoid,
                                                      doctopago.Sentidoabonodocto,
                                                      doctopago.Sentidoabonocliente,
                                                      doctopago.Sentidoabonoproveedor,
                                                      doctopago.Sentidoabonocorte,
                                                      doctopago.Sentidoabonopago,
                                                      doctopago.Esapartado,
                                                      doctopago.Tipoaplicacioncreditoid,
                                                      doctopago.Espagoinicial,
                                                      Doctocorteid = doctopago.Docto != null ? doctopago.Docto.Corteid :null,
                                                      TipoDoctoId = doctopago.Docto != null ? doctopago.Docto.Tipodoctoid : null,
                                                      ClienteId = doctopago.Docto != null ? doctopago.Docto.Clienteid : null,
                                                      ProveedorId = doctopago.Docto != null ? doctopago.Docto.Proveedorid : null,

                                                      //tipodocto


                                                      Tipodocto_sentidopago = doctopago.Docto != null && doctopago.Docto.Tipodocto != null ? doctopago.Docto.Tipodocto.Sentidopago : 0,
                                                      Tipodocto_sentidopagoapartados = doctopago.Docto != null && doctopago.Docto.Tipodocto != null ? doctopago.Docto.Tipodocto.Sentidopagoapartados : 0,
                                                      Tipodocto_sentidocostopromedio = doctopago.Docto != null && doctopago.Docto.Tipodocto != null ? doctopago.Docto.Tipodocto.Sentidocostopromedio : 0,
                                                      Tipodocto_sentidoabonocliente = doctopago.Docto != null && doctopago.Docto.Tipodocto != null ? doctopago.Docto.Tipodocto.Sentidoabonocliente : 0,
                                                      Tipodocto_sentidoabonoproveedor = doctopago.Docto != null && doctopago.Docto.Tipodocto != null ? doctopago.Docto.Tipodocto.Sentidoabonoproveedor : 0,
                                                      Tipodocto_sentidoabonomismocorte = doctopago.Docto != null && doctopago.Docto.Tipodocto != null ? doctopago.Docto.Tipodocto.Sentidoabonomismocorte : 0,
                                                      Tipodocto_sentidoabonootrocorte = doctopago.Docto != null && doctopago.Docto.Tipodocto != null ? doctopago.Docto.Tipodocto.Sentidoabonootrocorte : 0,


                                                      Formapago_abona = doctopago.Docto != null && doctopago.Formapago != null ? doctopago.Formapago.Abona : BoolCS.S,
                                                      Formapago_afectasaldopersona = doctopago.Docto != null && doctopago.Formapago != null ? doctopago.Formapago.Afectasaldopersona : BoolCS.S,
                                                      Formapago_afectasaldoapartados = doctopago.Docto != null && doctopago.Formapago != null ? doctopago.Formapago.Afectasaldoapartados : BoolCN.S,
                                                      Formapago_sentidoabonopago = doctopago.Docto != null && doctopago.Formapago != null ? doctopago.Formapago.Sentidoabonopago : 0,
                                                      Formapago_afectasaldocorte = doctopago.Docto != null && doctopago.Formapago != null ? doctopago.Formapago.Afectasaldocorte : BoolCS.S



                                                  }).FirstOrDefault();

                if (docto_pago_info == null)
                    throw new Exception("No hay informacion del doctopago");



                if((docto_pago_info.Estatusdoctopagoid ?? 0) != 0)
                    throw new Exception("El registro ya esta completo");




                var sentidoabonopago = docto_pago_info.Formapago_sentidoabonopago ;
                var sentidoabonodocto = docto_pago_info.Formapago_abona  != BoolCS.S ? 0 : 1 ;
                var sentidoabonocliente = docto_pago_info.Formapago_afectasaldopersona != BoolCS.S ? 0 : docto_pago_info.Tipodocto_sentidoabonocliente  ;
                var sentidoabonoproveedor = docto_pago_info.Formapago_afectasaldopersona != BoolCS.S ? 0 : docto_pago_info.Tipodocto_sentidoabonoproveedor ;
                var sentidoabonocorte = docto_pago_info.Formapago_afectasaldocorte != BoolCS.S ? 0 :
                                     ((docto_pago_info.Corteid ?? 0) != (docto_pago_info.Doctocorteid ?? 0) ?
                                            docto_pago_info.Tipodocto_sentidoabonootrocorte  :
                                            docto_pago_info.Tipodocto_sentidoabonomismocorte 
                                      );

                var doctopago = localContext.Doctopago
                                                  .SingleOrDefault(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == id);


                if (doctopago == null)
                    throw new Exception("No hay informacion del doctopago");

                doctopago.Sentidoabonodocto = sentidoabonodocto;
                doctopago.Sentidoabonocliente = sentidoabonocliente;
                doctopago.Sentidoabonoproveedor = sentidoabonoproveedor;
                doctopago.Sentidoabonocorte = sentidoabonocorte;
                doctopago.Sentidoabonopago = sentidoabonopago;

                localContext.Update(doctopago);


                var kardex_abono_trans = new Kardex_abono_transaccion()
                {
                    Empresaid = empresaId,
                    Sucursalid = sucursalId,
                    Activo = docto_pago_info.Activo,
                    Creado = docto_pago_info.Creado,
                    Creadopor_userid = docto_pago_info.CreadoPorId,
                    Tipomovimientokardexabonoid = 2,
                    Fechahora = DateTime.Now,
                    Importe = docto_pago_info.Importe,
                    Importecambio = 0m,
                    Clienteid = docto_pago_info.ClienteId,
                    Proveedorid = docto_pago_info.ProveedorId,
                    Pagoid = docto_pago_info.Pagoid,
                    Doctopagoid = id,
                    Formapagoid = docto_pago_info.Formapagoid,
                    Doctoid = docto_pago_info.Doctoid,
                    Tipodoctoid = docto_pago_info.TipoDoctoId,
                    Corteid = docto_pago_info.Corteid,
                    Sentidoabonodocto = sentidoabonodocto,
                    Sentidoabonocliente = sentidoabonocliente,
                    Sentidoabonoproveedor = sentidoabonoproveedor,
                    Sentidoabonocorte = sentidoabonocorte
                };

                Kardex_abono_insert_basico(kardex_abono_trans, localContext);


                doctopago.Estatusdoctopagoid = 1;

                localContext.Update(doctopago);



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



        public void Cliente_recalcular_saldos(long empresaId, long sucursalId, long clienteId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var clienteInfo = localContext.Cliente.AsNoTracking()
                                               .Include(c => c.Subtipocliente)
                                               .Where(c => c.EmpresaId == empresaId && c.SucursalId == sucursalId && c.Id == clienteId)
                                               .Select(c => new { Esmostrador = c.Subtipocliente != null ? c.Subtipocliente.Esmostrador : BoolCN.N })
                                               .FirstOrDefault();

                if (clienteInfo == null)
                    throw new Exception("No existe informacion del cliente");

                if (clienteInfo.Esmostrador == BoolCN.S)
                    return;


                var totalesdocto_info = localContext.Docto.AsNoTracking()
                                                .Include(d => d.Tipodocto)
                                                .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && 
                                                            (d.Estatusdoctoid == 1 || d.Estatusdoctoid == 2) &&
                                                            d.Clienteid == clienteId && d.Tipodocto != null && d.Tipodocto.Sentidoabonocliente != 0)
                                                .GroupBy(d => new { d.Clienteid })
                                                .Select(d => new { Total = d.Sum(s => s.Total * s.Tipodocto!.Sentidoabonocliente) })
                                                .FirstOrDefault();
                var totalesdocto = totalesdocto_info == null ? 0m : totalesdocto_info.Total;

                var abonospago_info = localContext.Doctopago.AsNoTracking()
                                                    .Include(dp => dp.Pago)
                                                    .Where(dp => dp.EmpresaId == empresaId && dp.SucursalId == sucursalId &&
                                                                 dp.Pago!.Clienteid == clienteId && dp.Sentidoabonocliente != 0 &&
                                                                 dp.Estatusdoctopagoid == 1)
                                                    .GroupBy(dp => new { dp.Pago!.Clienteid })
                                                    .Select(dp => new { AbonosPago = dp.Sum(s => (s.Sentidoabonocliente ?? 0) * (s.Importe)) })
                                                    .FirstOrDefault();

                var abonospago  = abonospago_info == null ? 0m : abonospago_info.AbonosPago;

                var saldo = totalesdocto - abonospago;

                var cliente_pago = localContext.Cliente_pago
                                               .FirstOrDefault(cp => cp.EmpresaId == empresaId && cp.SucursalId == sucursalId && cp.Clienteid == clienteId);

                if(cliente_pago != null)
                {
                    cliente_pago.Saldo = saldo;
                    localContext.Update(cliente_pago);
                }
                else
                {
                    cliente_pago = new Cliente_pago()
                    {

                        EmpresaId = empresaId,
                        SucursalId = sucursalId,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        CreadoPorId = null,
                        Modificado = DateTimeOffset.Now,
                        ModificadoPorId = null,
                        Clienteid = clienteId,
                        Saldo = saldo,
                        Saldoapartadonegativo = 0m,
                        Saldoapartadopositivo = 0m,
                        Saldosnegativos = 0m,
                        Saldospositivos = 0m,
                        Ultimaventa = null
                    };
                    localContext.Add(cliente_pago);
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




        public void Proveedor_recalcular_saldos(long empresaId, long sucursalId, long proveedorId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {


                var totalesdocto_info = localContext.Docto.AsNoTracking()
                                                .Include(d => d.Tipodocto)
                                                .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                                            (d.Estatusdoctoid == 1 || d.Estatusdoctoid == 2) &&
                                                            d.Proveedorid == proveedorId && d.Tipodocto != null && d.Tipodocto.Sentidoabonoproveedor != 0)
                                                .GroupBy(d => new { d.Proveedorid })
                                                .Select(d => new { Total = d.Sum(s => s.Total * s.Tipodocto!.Sentidoabonoproveedor) })
                                                .FirstOrDefault();
                var totalesdocto = totalesdocto_info == null ? 0m : totalesdocto_info.Total;

                var abonospago_info = localContext.Doctopago.AsNoTracking()
                                                    .Include(dp => dp.Pago)
                                                    .Where(dp => dp.EmpresaId == empresaId && dp.SucursalId == sucursalId &&
                                                                 dp.Pago!.Proveedorid == proveedorId && dp.Sentidoabonoproveedor != 0 &&
                                                                 dp.Estatusdoctopagoid == 1)
                                                    .GroupBy(dp => new { dp.Pago!.Proveedorid })
                                                    .Select(dp => new { AbonosPago = dp.Sum(s => (s.Sentidoabonoproveedor ?? 0) * (s.Importe)) })
                                                    .FirstOrDefault();


                var abonospago = abonospago_info == null ? 0m : abonospago_info.AbonosPago;

                var saldo = totalesdocto - abonospago;

                var proveedor_pago = localContext.Proveedor_pago
                                               .FirstOrDefault(cp => cp.EmpresaId == empresaId && cp.SucursalId == sucursalId && cp.Proveedorid == proveedorId);

                if (proveedor_pago != null)
                {
                    proveedor_pago.Saldo = saldo;
                    localContext.Update(proveedor_pago);
                }
                else
                {
                    proveedor_pago = new Proveedor_pago()
                    {

                        EmpresaId = empresaId,
                        SucursalId = sucursalId,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.Now,
                        CreadoPorId = null,
                        Modificado = DateTimeOffset.Now,
                        ModificadoPorId = null,
                        Proveedorid = proveedorId,
                        Saldo = saldo,
                        Saldosnegativos = 0m,
                        Saldospositivos = 0m
                    };
                    localContext.Add(proveedor_pago);
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



        public void Docto_recalcular_saldos(long empresaId, long sucursalId, long doctoId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var abonosdocto_info = localContext.Doctopago.AsNoTracking()
                                                    .Where(dp => dp.EmpresaId == empresaId && dp.SucursalId == sucursalId &&
                                                                 dp.Doctoid == doctoId && dp.Sentidoabonodocto != 0 &&
                                                                 dp.Estatusdoctopagoid == 1)
                                                    .GroupBy(dp => new { dp.Doctoid })
                                                    .Select(dp => new { AbonosPago = dp.Sum(s => (s.Sentidoabonodocto ?? 0) * (s.Importe)) })
                                                    .FirstOrDefault();

                var abonosdocto = abonosdocto_info != null ? abonosdocto_info.AbonosPago : 0m;

                var docto = localContext.Docto
                    .FirstOrDefault(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                                                 d.Id == doctoId);

                if (docto == null)
                    throw new Exception("el docto no existe");

                docto.Abono = abonosdocto;
                docto.Saldo = docto.Total - abonosdocto;

                localContext.Update(docto);

                localContext.SaveChanges();


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


        public void Corte_recalcular_saldos(long empresaId, long sucursalId, long corteId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {



                var abonoscorte_info = localContext.Doctopago.AsNoTracking()
                                                    .Where(dp => dp.EmpresaId == empresaId && dp.SucursalId == sucursalId &&
                                                                 dp.Corteid == corteId && dp.Sentidoabonocorte != 0 &&
                                                                 dp.Estatusdoctopagoid == 1)
                                                    .GroupBy(dp => new { dp.Corteid })
                                                    .Select(dp => new { 
                                                        Saldoparcial = dp.Sum(s => (s.Sentidoabonocorte ?? 0) * (s.Importe))
                                                        })
                                                    .FirstOrDefault();



                var saldoparcial = abonoscorte_info != null ? abonoscorte_info.Saldoparcial : 0m;
                var ingreso = abonoscorte_info != null && abonoscorte_info.Saldoparcial > 0 ? abonoscorte_info.Saldoparcial : 0m;
                var egreso = abonoscorte_info != null && abonoscorte_info.Saldoparcial > 0 ? abonoscorte_info.Saldoparcial : 0m;



                var corte = localContext.Corte
                    .FirstOrDefault(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId &&
                                                                 d.Id == corteId);

                if (corte == null)
                    throw new Exception("el corte no existe");

                corte.Saldofinal = corte.Saldoinicial + saldoparcial;
                corte.Ingreso = ingreso;
                corte.Egreso = egreso;

                localContext.Update(corte);


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


        public void Pago_complete(long empresaId, long sucursalId, long id, long usuarioId,
            ApplicationDbContext localContext)
        {
           

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var pago_info = localContext.Pago.AsNoTracking()
                                            .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Id == id)
                                            .Select(p => new { p.Estatuspagoid, p.Corteid, p.Clienteid, p.Proveedorid })
                                            .FirstOrDefault();

                if (pago_info == null)
                    throw new Exception("El pago no se encontro");

                if (pago_info.Estatuspagoid != 0)
                    return;

                var doctoPagoIds = localContext.Doctopago.AsNoTracking()
                                        .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Pagoid == id)
                                        .Select(p => p.Id)
                                        .ToList();

                if (doctoPagoIds == null || doctoPagoIds.Count == 0)
                    return;

                foreach (var doctoPagoId in doctoPagoIds)
                {
                    Docto_pago_complete(empresaId, sucursalId, doctoPagoId, usuarioId, localContext);
                }

                long folio = 0;
                _maestroConsecutivoService.GenerarConsecutivo(empresaId, sucursalId, Tipo_consecutivo.FolioPago, null, "Pago", "Folio", "public",
                                                                            null, null, null, out folio, localContext);


                var pago = localContext.Pago
                                        .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Id == id)
                                        .FirstOrDefault();

                if (pago == null)
                    throw new Exception("El pago es null");

                pago.Estatuspagoid = 1;
                pago.Folio = (int)folio;
                localContext.Update(pago);

                localContext.SaveChanges();

                var docto_list = localContext.Doctopago.AsNoTracking()
                                            .Where(dp => dp.EmpresaId == empresaId && dp.SucursalId == sucursalId &&
                                                         dp.Pagoid == id && dp.Doctoid != null)
                                            .Select(dp => dp.Doctoid)
                                            .ToList();

                if (docto_list != null && docto_list.Count > 0)
                {
                    foreach (var doctoId in docto_list)
                    {
                        Docto_recalcular_saldos(empresaId, sucursalId, doctoId!.Value, localContext);
                    }
                }

                if (pago_info.Clienteid != null)
                    Cliente_recalcular_saldos(empresaId, sucursalId, pago_info.Clienteid.Value, localContext);

                if (pago_info.Proveedorid != null)
                    Proveedor_recalcular_saldos(empresaId, sucursalId, pago_info.Proveedorid.Value, localContext);

                if (pago_info.Corteid != null)
                    Corte_recalcular_saldos(empresaId, sucursalId, pago_info.Corteid.Value, localContext);


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


        public void Pago_completar_by_docto(long empresaId, long sucursalId, long doctoId, long usuarioId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var pago_ids = localContext.Doctopago.AsNoTracking()
                                            .Include(dp => dp.Pago)
                                            .Where(dp => dp.EmpresaId == empresaId && dp.SucursalId == sucursalId &&
                                                          dp.Doctoid == doctoId && dp.Pago != null && dp.Pago.Estatuspagoid == 0)
                                            .Select(dp => dp.Pagoid)
                                            .Distinct()
                                            .ToList();

                if (pago_ids == null || pago_ids.Count() <= 0)
                    return;

                foreach(var pagoId in pago_ids)
                {
                    Pago_complete(empresaId, sucursalId, pagoId!.Value, usuarioId, localContext);
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


        public void Kardex_abono_insert_basico(Kardex_abono_transaccion kardex_abono_trans,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var kardex_abono = new Kardexabono();
                kardex_abono.EmpresaId = kardex_abono_trans.Empresaid;
                kardex_abono.SucursalId = kardex_abono_trans.Sucursalid;
                kardex_abono.Id = kardex_abono_trans.Id;
                kardex_abono.Activo = kardex_abono_trans.Activo;
                kardex_abono.Creado = kardex_abono_trans.Creado;
                kardex_abono.CreadoPorId = kardex_abono_trans.Creadopor_userid;
                kardex_abono.Tipomovimientokardexabonoid = kardex_abono_trans.Tipomovimientokardexabonoid;
                kardex_abono.Fechahora = kardex_abono_trans.Fechahora;
                kardex_abono.Importe = kardex_abono_trans.Importe;
                kardex_abono.Importecambio = kardex_abono_trans.Importecambio;
                kardex_abono.Clienteid = kardex_abono_trans.Clienteid;
                kardex_abono.Proveedorid = kardex_abono_trans.Proveedorid;
                kardex_abono.Pagoid = kardex_abono_trans.Pagoid;
                kardex_abono.Doctopagoid = kardex_abono_trans.Doctopagoid;
                kardex_abono.Formapagoid = kardex_abono_trans.Formapagoid;
                kardex_abono.Doctoid = kardex_abono_trans.Doctoid;
                kardex_abono.Tipodoctoid = kardex_abono_trans.Tipodoctoid;
                kardex_abono.Corteid = kardex_abono_trans.Corteid;
                kardex_abono.Sentidoabonodocto = kardex_abono_trans.Sentidoabonodocto;
                kardex_abono.Sentidoabonocliente = kardex_abono_trans.Sentidoabonocliente;
                kardex_abono.Sentidoabonoproveedor = kardex_abono_trans.Sentidoabonoproveedor;
                kardex_abono.Sentidoabonocorte = kardex_abono_trans.Sentidoabonocorte;
                localContext.Add(kardex_abono);



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



        public void Pago_insertar_basico(Pago_transaccion pago_transaccion, ref long? pagoId, 
                                        ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            if((pago_transaccion.Formapagoid ?? 0) != 0 && (pago_transaccion.Formapagosatid ?? 0) == 0)
            {
                var formaPagoSat = localContext.Formapagosat.AsNoTracking().FirstOrDefault(f => f.Formapagoid == pago_transaccion.Formapagoid);
                if (formaPagoSat != null)
                    pago_transaccion.Formapagosatid = formaPagoSat.Id;
            }

            try
            {
                var pago = new Pago()
                {
                    EmpresaId = pago_transaccion.Empresaid,
                    SucursalId = pago_transaccion.Sucursalid,
                    Creado = pago_transaccion.Creado,
                    Modificado = pago_transaccion.Creado,
                    CreadoPorId = pago_transaccion.Creadopor_userid,
                    ModificadoPorId = pago_transaccion.Creadopor_userid,

                    Referenciabancaria = pago_transaccion.Referenciabancaria,
                    Notas = pago_transaccion.Notas,
                    Aplicado = pago_transaccion.Aplicado,
                    Cuentapagocredito = pago_transaccion.Cuentapagocredito,
                    Revertido = pago_transaccion.Revertido ?? BoolCN.N,
                    Formapagoid = pago_transaccion.Formapagoid,
                    Fecha = pago_transaccion.Fecha ?? DateTimeOffset.UtcNow,
                    Fechahora = pago_transaccion.Fechahora ?? DateTimeOffset.UtcNow,
                    Corteid = pago_transaccion.Corteid,
                    Importe = pago_transaccion.Importe,
                    Importerecibido = pago_transaccion.Importerecibido,
                    Importecambio = pago_transaccion.Importecambio,
                    Tipopagoid = pago_transaccion.Tipopagoid,
                    Estatuspagoid = 0,
                    Bancoid = pago_transaccion.Bancoid,
                    Fechaelaboracion = pago_transaccion.Fechaelaboracion,
                    Fecharecepcion = pago_transaccion.Fecharecepcion,
                    Pagoparentid = pago_transaccion.Pagoparentid,
                    Formapagosatid = pago_transaccion.Formapagosatid,
                    Clienteid = pago_transaccion.Clienteid,
                    Proveedorid = pago_transaccion.Proveedorid,
                    Sentidopago = pago_transaccion.Sentidopago,
                    //Folio = pago_transaccion.,
                    //Fechaaplicado = pago_transaccion.,
                    Comision = pago_transaccion.Comision,
                    Cuentabancoempresaid = pago_transaccion.Cuentabancoempresaid,
                    Reciboelectronicoid = pago_transaccion.Reciboelectronicoid
                    //efinterno = pago_transaccion.


                };

                localContext.Add(pago);
                localContext.SaveChanges();

                pagoId = pago.Id;


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


        public void Docto_pago_insertar_basico(DoctoPago_transaccion doctopago_transaccion, 
                                                ref long? doctoPagoId, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var docto_pago = new Doctopago()
                {
                    EmpresaId = doctopago_transaccion.Empresaid,
                    SucursalId = doctopago_transaccion.Sucursalid,
                    Id = doctopago_transaccion.Id,
                    Activo = doctopago_transaccion.Activo,
                    Creado = doctopago_transaccion.Creado,
                    CreadoPorId = doctopago_transaccion.Creadopor_userid,
                    Esapartado = doctopago_transaccion.Esapartado,
                    Espagoinicial = doctopago_transaccion.Espagoinicial,
                    Doctoid = doctopago_transaccion.Doctoid,
                    Fecha = doctopago_transaccion.Fecha ?? DateTimeOffset.UtcNow,
                    Fechahora = doctopago_transaccion.Fechahora ?? DateTimeOffset.UtcNow,
                    Corteid = doctopago_transaccion.Corteid,
                    Importe = doctopago_transaccion.Importe,
                    Tipopagoid = doctopago_transaccion.Tipopagoid,
                    Tipoabonoid = doctopago_transaccion.Tipoabonoid,
                    Estatusdoctopagoid = 0,
                    Sentidopago = doctopago_transaccion.Sentidopago,
                    Formapagoid = doctopago_transaccion.Formapagoid,
                    Pagoid = doctopago_transaccion.Pagoid,
                    Sentidoabonodocto = null,
                    Sentidoabonocliente = null,
                    Sentidoabonoproveedor = null,
                    Sentidoabonocorte = null,
                    Sentidoabonopago = null,
                    Tipoaplicacioncreditoid = doctopago_transaccion.Tipoaplicacioncreditoid,
                    Refinterno = null,
                    Doctopagoparentid = doctopago_transaccion.Doctopagoparentid
                };


                localContext.Add(docto_pago);
                localContext.SaveChanges();

                doctoPagoId = docto_pago.Id;

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


        public void PagoCompuestoInsert(Pago_transaccion pagoTransaccion, List<DoctoPago_transaccion> doctoPagoTransacciones,
                                        ref long? pagoId, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;


            try
            {

                Pago_insertar_basico(pagoTransaccion, ref pagoId, localContext);

                if ((pagoId ?? 0) == 0)
                    throw new Exception("El pago no se inserto");

                long? doctoPagoId = null;
                foreach (var doctoPagoTransaction in doctoPagoTransacciones)
                {
                    doctoPagoTransaction.Pagoid = pagoId;
                    Docto_pago_insertar_basico(doctoPagoTransaction, ref doctoPagoId, localContext);
                }


                Pago_complete(pagoTransaccion.Empresaid, pagoTransaccion.Sucursalid, pagoId!.Value, pagoTransaccion.Creadopor_userid ?? 0, localContext);
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


        public void PagoCompuestoRevertir(long empresaId, long sucursalId, long pagoARevertirId, 
                                           long usuarioId, long corteId, string? notas,
                                        ref long? pagoId, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;


            try
            {

                var pagoARevertirItem = localContext.Pago.AsNoTracking()
                                                    .Include(p => p.Doctopagos)
                                                    .FirstOrDefault(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId &&
                                                                         p.Id == pagoARevertirId);

                if(pagoARevertirItem == null)
                {
                    throw new Exception("No existe el pago");
                }

                if (pagoARevertirItem.Revertido == BoolCN.S)
                    throw new Exception("El pago ya esta revertido");

                var pagoTransaccion = new Pago_transaccion()
                {
                    Empresaid = pagoARevertirItem.EmpresaId,
                    Sucursalid = pagoARevertirItem.SucursalId,
                    Id = 0,
                    Activo = BoolCS.S,
                    Creado = DateTimeOffset.UtcNow,
                    Creadopor_userid = usuarioId,
                    Formapagoid = pagoARevertirItem!.Formapagoid == 18 ? 19 : pagoARevertirItem.Formapagoid,
                    Fecha = DateTimeOffset.Now.Date,
                    Fechahora = DateTimeOffset.Now,
                    Corteid = corteId,

                    Importe = pagoARevertirItem!.Formapagoid == 18 ? pagoARevertirItem.Importe : pagoARevertirItem.Importe * -1m,
                    Importerecibido = pagoARevertirItem!.Formapagoid == 18 ? pagoARevertirItem.Importerecibido : pagoARevertirItem.Importerecibido * -1m,
                    Importecambio = pagoARevertirItem!.Formapagoid == 18 ? pagoARevertirItem.Importecambio : pagoARevertirItem.Importecambio * -1m,
                    Formapagosatid = pagoARevertirItem!.Formapagoid == 18 ? 99 : pagoARevertirItem!.Formapagosatid,

                    Tipopagoid = pagoARevertirItem.Tipopagoid,
                    Bancoid = pagoARevertirItem.Bancoid,
                    Referenciabancaria = pagoARevertirItem.Referenciabancaria,
                    Notas = notas,
                    Fechaelaboracion = DateTimeOffset.Now.Date,
                    Fecharecepcion = DateTimeOffset.Now.Date,
                    Fechaaplicado = DateTimeOffset.Now.Date,
                    Aplicado = BoolCN.S,
                    Pagoparentid = pagoARevertirItem.Id,
                    Clienteid = pagoARevertirItem.Clienteid,
                    Proveedorid = pagoARevertirItem.Proveedorid,
                    Sentidopago = pagoARevertirItem.Sentidopago ?? 1,
                    Comision = pagoARevertirItem.Comision ,
                    Cuentapagocredito = pagoARevertirItem.Cuentapagocredito,
                    Cuentabancoempresaid = pagoARevertirItem.Cuentabancoempresaid,
                    Reciboelectronicoid = null

                };


                Pago_insertar_basico(pagoTransaccion, ref pagoId, localContext);


                if ((pagoId ?? 0) == 0)
                    throw new Exception("El pago no se inserto");

                long? doctoPagoId = null;
                if (pagoARevertirItem.Doctopagos != null)
                {
                    foreach (var doctoPagoARevertir in pagoARevertirItem.Doctopagos)
                    {

                        var doctoPagoTransaction = new DoctoPago_transaccion()
                        {
                            Empresaid = doctoPagoARevertir.EmpresaId,
                            Sucursalid = doctoPagoARevertir.SucursalId,
                            Id = 0,
                            Activo = BoolCS.S,
                            Creado = DateTimeOffset.UtcNow,
                            Creadopor_userid = usuarioId,
                            Doctoid = doctoPagoARevertir.Doctoid,
                            Fecha = DateTimeOffset.Now.Date,
                            Fechahora = DateTimeOffset.Now,
                            Corteid = corteId,
                            Importe = pagoARevertirItem!.Formapagoid == 18 ? pagoARevertirItem.Importe : pagoARevertirItem.Importe * -1m,
                            Tipopagoid = doctoPagoARevertir.Tipopagoid,
                            Tipoabonoid = pagoARevertirItem!.Formapagoid == 18 ? 2 : 3,
                            Sentidopago = doctoPagoARevertir.Sentidopago ?? 1,
                            Formapagoid = doctoPagoARevertir!.Formapagoid == 18 ? 19 : doctoPagoARevertir.Formapagoid,
                            Pagoid = pagoId,
                            Esapartado = doctoPagoARevertir.Esapartado,
                            Tipoaplicacioncreditoid = doctoPagoARevertir.Tipoaplicacioncreditoid,
                            Espagoinicial = BoolCN.N,
                            Doctopagoparentid = doctoPagoARevertir.Id
                            

                        };

                        Docto_pago_insertar_basico(doctoPagoTransaction, ref doctoPagoId, localContext);
                    }
                }


                Pago_complete(pagoTransaccion.Empresaid, pagoTransaccion.Sucursalid, pagoId!.Value, pagoTransaccion.Creadopor_userid ?? 0, localContext);


                long localPagoId = pagoId!.Value;
                var pagoReversion = localContext.Pago
                                                    .FirstOrDefault(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId &&
                                                                         p.Id == localPagoId);
                var pagoOriginal = localContext.Pago
                                                    .FirstOrDefault(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId &&
                                                                         p.Id == pagoARevertirId);

                if (pagoReversion != null && pagoOriginal != null)
                {


                    var pago_pago = new Pago_pago()
                    {
                        EmpresaId = empresaId,
                        SucursalId = sucursalId,
                        Pagoid1 = pagoOriginal!.Id,
                        Pagoid2 = pagoReversion!.Id,
                        Monto = pagoOriginal!.Importe,
                        Tiporelacionpagoid = 1
                    };
                    localContext.Pago_pago.Add(pago_pago);

                    pagoReversion.Revertido = BoolCN.S;
                    pagoOriginal.Revertido = BoolCN.S;
                    localContext.Pago.Update(pagoReversion);
                    localContext.Pago.Update(pagoOriginal);

                    localContext.SaveChanges();
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

        public void Docto_pago_directo(DoctoPagoDirect doctoPagoDirect, 
                                        ref long? pagoId, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var pagoTransaccion = new Pago_transaccion()
                {
                    Empresaid = doctoPagoDirect.Empresaid,
                    Sucursalid = doctoPagoDirect.Sucursalid,
                    Id = doctoPagoDirect.Id,
                    Activo = BoolCS.S,
                    Creado = DateTimeOffset.UtcNow,
                    Creadopor_userid = doctoPagoDirect.Usuarioid,
                    Formapagoid = doctoPagoDirect.Formapagoid,
                    Fecha = doctoPagoDirect.Fecha,
                    Fechahora = doctoPagoDirect.Fechahora,
                    Corteid = doctoPagoDirect.Corteid,
                    Importe = (doctoPagoDirect.Docto2id ?? 0) == 0 ? doctoPagoDirect.Importe : 0m,
                    Importerecibido = (doctoPagoDirect.Docto2id ?? 0) == 0 ? doctoPagoDirect.Importerecibido : 0m,
                    Importecambio = (doctoPagoDirect.Docto2id ?? 0) == 0 ? doctoPagoDirect.Importecambio : 0m,
                    Tipopagoid = doctoPagoDirect.Tipopagoid,
                    Bancoid = doctoPagoDirect.Bancoid,
                    Referenciabancaria = doctoPagoDirect.Referenciabancaria,
                    Notas = doctoPagoDirect.Notas,
                    Fechaelaboracion = doctoPagoDirect.Fechaelaboracion,
                    Fecharecepcion = doctoPagoDirect.Fecharecepcion,
                    Aplicado = doctoPagoDirect.Aplicado,
                    Pagoparentid = doctoPagoDirect.Pagoparentid,
                    Formapagosatid = doctoPagoDirect.Formapagosatid,
                    Clienteid = doctoPagoDirect.Clienteid,
                    Proveedorid = doctoPagoDirect.Proveedorid,
                    Sentidopago = doctoPagoDirect.Sentidopago,
                    Fechaaplicado = doctoPagoDirect.Fechaaplicado,
                    Comision = doctoPagoDirect.Comision,
                    Cuentapagocredito = doctoPagoDirect.Cuentapagocredito,
                    Cuentabancoempresaid = doctoPagoDirect.Cuentabancoempresaid,
                    Reciboelectronicoid = null

                };


                Pago_insertar_basico(pagoTransaccion, ref pagoId, localContext);

                if ((pagoId ?? 0) == 0)
                    throw new Exception("El pago no se inserto");


                var doctoPagoTransaction = new DoctoPago_transaccion()
                {
                    Empresaid = doctoPagoDirect.Empresaid,
                    Sucursalid = doctoPagoDirect.Sucursalid,
                    Id = doctoPagoDirect.Id,
                    Activo = BoolCS.S,
                    Creado = DateTimeOffset.UtcNow,
                    Creadopor_userid = doctoPagoDirect.Usuarioid,
                    Doctoid = doctoPagoDirect.Doctoid,
                    Fecha = doctoPagoDirect.Fecha,
                    Fechahora = doctoPagoDirect.Fechahora,
                    Corteid = doctoPagoDirect.Corteid,
                    Importe = doctoPagoDirect.Importe,
                    Tipopagoid = doctoPagoDirect.Tipopagoid,
                    Tipoabonoid = doctoPagoDirect.Tipoabonoid,
                    Sentidopago = doctoPagoDirect.Sentidopago,
                    Formapagoid = doctoPagoDirect.Formapagoid,
                    Pagoid = pagoId!.Value,
                    Esapartado = doctoPagoDirect.Esapartado,
                    Tipoaplicacioncreditoid = doctoPagoDirect.Tipoaplicacioncreditoid,
                    Espagoinicial = doctoPagoDirect.Espagoinicial,
                    Doctopagoparentid = null

                };

                long? doctoPagoId = null;
                Docto_pago_insertar_basico(doctoPagoTransaction, ref doctoPagoId, localContext);

                if ((doctoPagoDirect.Docto2id ?? 0) != 0)
                {

                    var doctoPagoTransaction2 = new DoctoPago_transaccion()
                    {
                        Empresaid = doctoPagoDirect.Empresaid,
                        Sucursalid = doctoPagoDirect.Sucursalid,
                        Id = doctoPagoDirect.Id,
                        Activo = BoolCS.S,
                        Creado = DateTimeOffset.UtcNow,
                        Creadopor_userid = doctoPagoDirect.Usuarioid,
                        Doctoid = doctoPagoDirect.Docto2id,
                        Fecha = doctoPagoDirect.Fecha,
                        Fechahora = doctoPagoDirect.Fechahora,
                        Corteid = doctoPagoDirect.Corteid,
                        Importe = doctoPagoDirect.Importe,
                        Tipopagoid = doctoPagoDirect.Tipopagoid,
                        Tipoabonoid = doctoPagoDirect.Tipoabonoid,
                        Sentidopago = doctoPagoDirect.Sentidopago * -1,
                        Formapagoid = doctoPagoDirect.Formapagoid + 10000,
                        Pagoid = pagoId!.Value,
                        Esapartado = doctoPagoDirect.Esapartado,
                        Tipoaplicacioncreditoid = doctoPagoDirect.Tipoaplicacioncreditoid,
                        Espagoinicial = doctoPagoDirect.Espagoinicial,
                        Doctopagoparentid = null

                    };

                    long? doctoPagoId2 = null;
                    Docto_pago_insertar_basico(doctoPagoTransaction2, ref doctoPagoId2, localContext);
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


        public void Pago_copiar_para_cancelar(
              long empresaId, long sucursalId,
              long doctoId, long doctoCancelacionId ,
              long usuarioId , long corteId ,
              ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var doctoPagosInfo = localContext.Doctopago.AsNoTracking()
                                                .Include(dp => dp.Pago)
                                                .Where(dp => dp.EmpresaId == empresaId && dp.SucursalId == sucursalId &&
                                                             dp.Doctoid == doctoId && dp.Pago!.Estatuspagoid == 1 && dp.Estatusdoctopagoid == 1 &&
                                                             dp.Pago!.Revertido != BoolCN.S && (dp.Tipoabonoid == 1 || dp.Tipoabonoid == 2)
                                                        )
                                                .Select(dp => new
                                                {
                                                    dp.Pagoid,
                                                    dp.EmpresaId,
                                                    dp.SucursalId,
                                                    dp.Id,
                                                    dp.Doctoid,
                                                    dp.Formapagoid,
                                                    dp.Fecha,
                                                    dp.Fechahora,
                                                    dp.Corteid,
                                                    dp.Importe,
                                                    dp.Tipopagoid,
  		                                            dp.Esapartado,
  		                                            dp.Tipoaplicacioncreditoid ,
  		                                            dp.Pago!.Bancoid,
                                                    dp.Pago!.Referenciabancaria,
                                                    dp.Pago!.Notas,
                                                    dp.Pago!.Fechaelaboracion,
                                                    dp.Pago!.Fecharecepcion,
                                                    dp.Espagoinicial,
  		                                            dp.Tipoabonoid,
                                                    dp.Pago!.Pagoparentid,
                                                    dp.Pago!.Formapagosatid,
                                                    dp.Pago!.Comision ,
                                                    dp.Pago!.Cuentapagocredito ,
                                                    dp.Pago!.Cuentabancoempresaid ,
                                                    dp.Pago!.Aplicado ,
                                                    dp.Pago!.Fechaaplicado ,
                                                    dp.Pago!.Clienteid ,
                                                    dp.Pago!.Proveedorid ,
                                                    dp.Sentidopago
                                                })
                                                .ToList();

                if (doctoPagosInfo == null || doctoPagosInfo.Count == 0)
                    return;

                foreach(var doctoPagoInfo in doctoPagosInfo)
                {
                    long? newTipoPagoId = 1;
                    switch(doctoPagoInfo.Tipopagoid)
                    {
                        case 1: newTipoPagoId = 2; break;
                        case 2: newTipoPagoId = 1; break;
                        case 3: newTipoPagoId = 4; break;
                        case 4: newTipoPagoId = 3; break;
                        case 5: newTipoPagoId = 6; break;
                        case 6: newTipoPagoId = 5; break;
                        default: newTipoPagoId = 1; break;
                    }

                    var doctoPagoDirect = new DoctoPagoDirect()
                    {
                        Empresaid = doctoPagoInfo.EmpresaId,
                        Sucursalid = doctoPagoInfo.SucursalId,
                        Id = 0,
                        Doctoid = doctoPagoInfo.Doctoid,
                        Formapagoid = doctoPagoInfo.Formapagoid,
                        Fecha = doctoPagoInfo.Fecha,
                        Fechahora = doctoPagoInfo.Fechahora,
                        Corteid = corteId,
                        Importe = doctoPagoInfo.Importe,
                        Importerecibido = doctoPagoInfo.Importe,
                        Importecambio = 0m,
                        Tipopagoid = newTipoPagoId,
                        Docto2id = null,
                        Esapartado = doctoPagoInfo.Esapartado,
                        Tipoaplicacioncreditoid = doctoPagoInfo.Tipoaplicacioncreditoid,
                        Bancoid = doctoPagoInfo.Bancoid,
                        Referenciabancaria = doctoPagoInfo.Referenciabancaria,
                        Notas = doctoPagoInfo.Notas,
                        Fechaelaboracion = doctoPagoInfo.Fechaelaboracion,
                        Fecharecepcion = doctoPagoInfo.Fecharecepcion,
                        Espagoinicial = doctoPagoInfo.Espagoinicial,
                        Tipoabonoid = doctoPagoInfo.Tipoabonoid == 1 ? 2 : 1, 
                        Pagoparentid = doctoPagoInfo.Pagoparentid,
                        Formapagosatid = doctoPagoInfo.Formapagosatid,
                        Bancomerparamid = null,
                        Comision = doctoPagoInfo.Comision,
                        Cuentapagocredito = doctoPagoInfo.Cuentapagocredito,
                        Cuentabancoempresaid = doctoPagoInfo.Cuentabancoempresaid,
                        Aplicado = doctoPagoInfo.Aplicado,
                        Fechaaplicado = doctoPagoInfo.Fechaaplicado,
                        Clienteid = doctoPagoInfo.Clienteid,
                        Proveedorid = doctoPagoInfo.Proveedorid,
                        Usuarioid = usuarioId,
                        Sentidopago = (doctoPagoInfo.Sentidopago ?? 0) * -1


                    };

                    long? pagoIdBuffer = null;
                    Docto_pago_directo(doctoPagoDirect, ref pagoIdBuffer, localContext);

                    if ((pagoIdBuffer ?? 0) == 0)
                        throw new Exception("El pago no fue insertado");
                    
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







        public List<Tmp_PagosList> PagosList(long empresaId, long sucursalId,
                                        long? tipodoctoid,
                                        long? formapagoid, long? clienteId, long? proveedorId,
                                        DateTimeOffset fechainicial, DateTimeOffset fechafinal,
                                        bool solofiscales, bool incluircancelaciones, 
                                        BoolCN? aplicado, bool aplicadosYNoAplicados, 
                                        bool timbrado , bool timbradosYNoTimbrados,
                                        ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var lstPagos = localContext.Pago.AsNoTracking()
                                                      .Include(p => p.Formapago)
                                                      .Include(p => p.Formapagosat)
                                                      .Include(p => p.Tipopago)
                                                      .Include(p => p.Banco)
                                                      .Include(p => p.Cliente)
                                                      .Include(p => p.Proveedor)
                                                      .Include(p => p.Doctopagos)!.ThenInclude(d => d!.Docto)
                                                      .ThenInclude(d => d!.Docto_fact_elect).ThenInclude(d => d!.Cfdi)
                                              .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId &&
                                                          ((tipodoctoid == 21 && p.Clienteid != null ) ||
                                                           (tipodoctoid == 11 && p.Proveedorid != null)) &&
                                                          p.Formapagoid != 4 && p.Fecha >= fechainicial && p.Fecha <= fechafinal &&
                                                          ((tipodoctoid == 21 && p.Tipopagoid == 1) ||
                                                           (tipodoctoid == 11 && p.Tipopagoid == 2)) &&
                                                          (incluircancelaciones || p.Revertido == BoolCN.N) && //((p.Revertido  == BoolCN.N && (p.Tipoabonoid ?? 1) != 3))
                                                          (p.Formapagoid == formapagoid || (formapagoid ?? 0) == 0) &&
                                                          (p.Aplicado == aplicado || aplicadosYNoAplicados) &&
                                                          (((p.Reciboelectronicoid ?? 0) != 0 && timbrado) ||
                                                           ((p.Reciboelectronicoid ?? 0) == 0 && !timbrado) ||
                                                            timbradosYNoTimbrados
                                                          ) &&
                                                          (p.Clienteid == clienteId || (clienteId ?? 0) == 0) &&
                                                          (p.Proveedorid == proveedorId || (proveedorId ?? 0) == 0)
                                                          
                                                          )
                                                      .Select(m => new
                                                      {
                                                          m.EmpresaId,
                                                          m.SucursalId,
                                                          m.Id,
                                                          m.Fecha,
                                                          m.Fechahora,
                                                          m.Importe,
                                                          Formapagoclave = m.Formapago != null ? m.Formapago.Clave : "",
                                                          Formapagonombre = m.Formapago != null ? m.Formapago.Nombre : "",
                                                          Formapagosatclave = m.Formapagosat != null ? m.Formapagosat.Clave : "",
                                                          Formapagosatnombre = m.Formapagosat != null ? m.Formapagosat.Nombre : "",
                                                          Bancoclave = m.Banco != null ? m.Banco.Clave : "",
                                                          m.Referenciabancaria,
                                                          Tipopagoclave = m.Tipopago != null ? m.Tipopago.Clave : "",
                                                          Tipopagonombre = m.Tipopago != null ? m.Tipopago.Nombre : "",
                                                          Banconombre = m.Banco != null ? m.Banco.Nombre : "",
                                                          Timbrado = (m.Reciboelectronicoid ?? 0) != 0 ? "S" : "N",
                                                          m.Aplicado,
                                                          ClienteClave = m.Cliente != null ? m.Cliente.Clave : "",
                                                          ClienteNombre = m.Cliente != null ? m.Cliente.Nombre : "",
                                                          ProveedorClave = m.Proveedor != null ? m.Proveedor.Clave : "",
                                                          ProveedorNombre = m.Proveedor != null ? m.Proveedor.Nombre : "",

                                                          Countfacturados = m.Doctopagos!.Where(y => y.Docto != null && y.Docto.Docto_fact_elect != null &&
                                                                                    y.Docto.Docto_fact_elect.Esfacturaelectronica == BoolCN.S &&
                                                                                    (y.Docto.Docto_fact_elect.Timbradouuidcancelacion ?? "") != "")
                                                                      .Count(),

                                                          Countremisionados = m.Doctopagos!.Where(y => !(y.Docto != null && y.Docto.Docto_fact_elect != null &&
                                                                                    y.Docto.Docto_fact_elect.Esfacturaelectronica == BoolCN.S &&
                                                                                    (y.Docto.Docto_fact_elect.Timbradouuidcancelacion ?? "") != ""))
                                                                      .Count(),

                                                          Counttipopue = m.Doctopagos!.Where(y => y.Docto != null && y.Docto.Docto_fact_elect != null &&
                                                                                    y.Docto.Docto_fact_elect.Cfdi != null &&
                                                                                    y.Docto.Docto_fact_elect.Cfdi.Metodopago == "PUE")
                                                                      .Count()


                                                      }).ToList()
                                                      .Where(t => !solofiscales || t.Countfacturados > 0 && t.Countremisionados == 0 && t.Counttipopue == 0)
                                                      .Select(m => new Tmp_PagosList(

                                                          m.EmpresaId,
                                                          m.SucursalId,
                                                          m.Id,
                                                          m.Fecha,
                                                          m.Fechahora,
                                                          m.Importe,
                                                          m.Formapagoclave,
                                                          m.Formapagonombre,
                                                          m.Formapagosatclave,
                                                          m.Formapagosatnombre,
                                                          m.Bancoclave,
                                                          m.Banconombre,
                                                          m.Referenciabancaria,
                                                          m.Tipopagoclave,
                                                          m.Tipopagonombre,
                                                          m.Timbrado,
                                                          m.Aplicado,
                                                          m.ClienteClave,
                                                          m.ClienteNombre,
                                                          m.ProveedorClave,
                                                          m.ProveedorNombre


                                                      )).ToList();

                return lstPagos;


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




        public List<Tmp_DoctosConSaldoList> DoctosConSaldoList(long empresaId, long sucursalId,
                                        long? tipodoctoid, 
                                        long? clienteId, long? proveedorId,
                                        bool soloTimbrados, long? usuarioId,
                                        bool corteActivo, string? referencia,
                                        DateTimeOffset? fechaInicial, DateTimeOffset? fechaFinal,
                                        long? estatusDoctoId,
                                        ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            if (tipodoctoid == null)
                tipodoctoid = DBValues._DOCTO_TIPO_VENTA;

            if (estatusDoctoId == null)
                estatusDoctoId = DBValues._DOCTO_ESTATUS_COMPLETO;

            try
            {

                var lstDoctosConSaldo = localContext.Docto.AsNoTracking()
                                                      .Include(p => p.Sucursal_info)
                                                      .Include(p => p.Docto_traslado).ThenInclude(d => d!.Sucursalt)
                                                      .Include(p => p.Cliente)
                                                      .Include(p => p.Proveedor)
                                                      .Include(p => p.Estatusdocto)
                                                      .Include(p => p.Tipodocto)
                                                      .Include(p => p.Corte)
                                                      .Include(p => p.Caja)
                                                      .Include(p => p.Docto_fact_elect)
                                                      .Include(p => p.Usuario)
                                                      .Include(p => p.Docto_info_pago)
                                              .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId &&
                                                          (p.Tipodoctoid == tipodoctoid ||
                                                           (tipodoctoid == 22 && (p.Tipodoctoid == 21 || p.Tipodoctoid == 22 || p.Tipodoctoid == 202)) ||
                                                           (tipodoctoid == 12 && (p.Tipodoctoid == 12 || p.Tipodoctoid == 202))) && 
                                                          ((p.Estatusdoctoid == estatusDoctoId || (p.Estatusdoctoid == 1 || estatusDoctoId == 2))) &&
                                                          (p.Clienteid == clienteId || clienteId == 0) &&
                                                          (p.Proveedorid == proveedorId || proveedorId == 0) && 
                                                          (!soloTimbrados || (p.Docto_fact_elect != null && p.Docto_fact_elect.Esfacturaelectronica == BoolCN.S &&
                                                                                    (p.Docto_fact_elect.Timbradouuidcancelacion ?? "") != "")
                                                          ) &&
                                                          p.Saldo > 0 &&
                                                          (usuarioId == null || p.Usuarioid == usuarioId) &&
                                                          (!corteActivo || (p.Corte != null && p.Corte.Activo == BoolCS.S)) &&
                                                          (referencia == null || referencia == "" || (p.Referencia != null && p.Referencia == referencia  )) &&
                                                          ((fechaInicial == null || p.Fecha >= fechaInicial)  && (fechaFinal == null || p.Fecha <= fechaFinal))
                                                      )
                                                      .Select(m => new Tmp_DoctosConSaldoList(
                                                          m.EmpresaId,
                                                          m.SucursalId,
                                                          m.Id,
m.Sucursal_id,
m.Sucursal_info != null ? m.Sucursal_info.Clave : "",
m.Sucursal_info != null ? m.Sucursal_info.Nombre : "",

                                                          m.Cajaid,
m.Caja != null ? m.Caja.Clave : "",
m.Caja != null ? m.Caja.Nombre : "",

                                                          m.Fecha,
                                                          m.Serie,
                                                          m.Total,
                                                          m.Estatusdoctoid,
m.Estatusdocto != null ? m.Estatusdocto.Clave : "",
m.Estatusdocto != null ? m.Estatusdocto.Nombre : "",

                                                          m.Tipodoctoid,
m.Tipodocto != null ? m.Tipodocto.Clave : "",
m.Tipodocto != null ? m.Tipodocto.Nombre : "",


                                                          m.Referencia,
m.Docto_traslado != null ? m.Docto_traslado.Sucursaltid : null,
m.Docto_traslado != null && m.Docto_traslado.Sucursalt != null ? m.Docto_traslado.Sucursalt.Clave : "",
m.Docto_traslado != null && m.Docto_traslado.Sucursalt != null ? m.Docto_traslado.Sucursalt.Nombre : "",

                                                          m.Folio,
m.Cliente != null ? m.Cliente.Clave : "",
m.Cliente != null ? m.Cliente.Nombre : "",
m.Proveedor != null ? m.Proveedor.Clave : "",
m.Proveedor != null ? m.Proveedor.Nombre : "",
m.Usuario != null ? m.Usuario.Clave : "",
m.Usuario != null ? m.Usuario.Nombre : "",
((m.Saldo - (m.Docto_info_pago == null ? 0 : m.Docto_info_pago.Abononoaplicado)) *
                                                                             ((m.Tipodoctoid == 201 || m.Tipodoctoid == 202) ? -1 : 1)),
0m,
m.Docto_fact_elect != null ? m.Docto_fact_elect.Esfacturaelectronica : BoolCN.N,
m.Docto_fact_elect != null && (m.Docto_fact_elect.Timbradouuid ?? "") != "" ? "S" : "N",
m.Docto_fact_elect != null ? ((m.Docto_fact_elect.Seriesat ?? "") + (m.Docto_fact_elect.Foliosat == null ? "" : m.Docto_fact_elect.Foliosat.ToString())) : ""



                                                      )).ToList();

                return lstDoctosConSaldo;


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



        public List<Tmp_DoctoPagosAplicadosList> DoctoPagosAplicadosList(long empresaId, long sucursalId,
                                        long pagoid,
                                        ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                var lstDoctoPagosAplicados = localContext.Doctopago.AsNoTracking()
                                                      .Include(p => p.Docto).ThenInclude(d => d!.Docto_fact_elect)
                                              .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId &&
                                                          p.Pagoid == pagoid 
                                                      )
                                                      .Select(m => new Tmp_DoctoPagosAplicadosList(
                                                          m.EmpresaId,
                                                          m.SucursalId,
                                                          m.Id,
                                                          m.Importe,
m.Docto != null ? m.Docto.Folio : null,
m.Docto != null && m.Docto.Docto_fact_elect != null ? ((m.Docto.Docto_fact_elect.Seriesat ?? "") + (m.Docto.Docto_fact_elect.Foliosat == null ? "" : m.Docto.Docto_fact_elect.Foliosat.ToString())) : "",
m.Docto != null && m.Docto.Docto_fact_elect != null ? m.Docto.Docto_fact_elect.Esfacturaelectronica : BoolCN.N,
m.Docto != null && m.Docto.Docto_fact_elect != null && (m.Docto.Docto_fact_elect.Timbradouuid ?? "") != "" ? "S" : "N"


                                                      )).ToList();

                return lstDoctoPagosAplicados;


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




        public List<TmpDoctoPagoItem> DoctoPagosList(long empresaId, long sucursalId,
                                        long doctoid,
                                        ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;



            try
            {

                var formasDePago1 = new long?[] { 1, 2, 3, 4, 5, 7, 14, 15, 16, 17, 19, 20, 21 };
                var formasDePago2 = new long?[] { 6, 18 };
                var formasDePago3 = new long?[] { 7, 19 };

                var tipoDoctosEntrada = new long?[] { 11, 22, 202, 1011 };
                var tipoDoctosSalida = new long?[] { 21, 25, 201, 31 };

                var lstPagos = localContext.Doctopago.AsNoTracking()
                                                      .Include(d => d.Pago)
                                                      .Include(d => d.Pago).ThenInclude(p => p!.Formapago)
                                                      .Include(d => d.Pago).ThenInclude(p => p!.Formapagosat)
                                                      .Include(d => d.Pago).ThenInclude(p => p!.Tipopago)
                                                      .Include(d => d.Pago).ThenInclude(p => p!.Banco)
                                                      .Include(d => d.Pago).ThenInclude(p => p!.Cliente)
                                                      .Include(d => d.Pago).ThenInclude(p => p!.Proveedor)
                                                      .Include(d => d.Pago).ThenInclude(p => p!.Pago_bancomer)
                                                      .Include(d => d.Pago).ThenInclude(p => p!.Cuentabancoempresa)
                                                      .Include(d => d.Tipoabono)
                                                      .Include(d => d.Docto)
                                              .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId &&
                                                          p.Pago!.Formapago!.Abona == BoolCS.S && p.Doctoid == doctoid
                                                     )
                                                      .Select(m => new TmpDoctoPagoItem(
                                                          m.EmpresaId,
                                                          m.SucursalId,
                                                          m.Id,
                                                          m.Pagoid,
                                                          m.Fecha,
                                                          m.Fechahora,
(m.Docto!.Tipodoctoid == 202 ? "Anticipo de proveedor" :
                                                                       (m.Pago!.Formapagosat == null || m.Pago!.Formapagosatid == 99 ||
                                                                        m.Pago!.Formapagoid == 20 || m.Pago!.Formapagoid == 21 ?
                                                                            (m.Pago!.Formapago != null ? m.Pago!.Formapago.Nombre : "") :
                                                                            (m.Pago!.Formapagosat != null ? m.Pago!.Formapagosat.Nombre : "")
                                                                        )
                                                                      ),
m.Importe *
                                                                   (
                                                                    (
                                                                        (
                                                                            ((tipoDoctosEntrada.Contains(m.Docto!.Tipodoctoid) && m.Pago!.Tipopagoid == 2) ||
                                                                             (tipoDoctosSalida.Contains(m.Docto!.Tipodoctoid) && m.Pago!.Tipopagoid == 1)) &&
                                                                            (new long?[] { 1, 2, 3, 4, 5, 7, 14, 15, 16, 17, 19, 20, 21 }).Contains(m.Pago!.Formapagoid)
                                                                         ) ||
                                                                        (
                                                                            ((tipoDoctosEntrada.Contains(m.Docto!.Tipodoctoid) && m.Pago!.Tipopagoid == 1) ||
                                                                             (tipoDoctosSalida.Contains(m.Docto!.Tipodoctoid) && m.Pago!.Tipopagoid == 2)) &&
                                                                            (new long?[] { 6, 18 }).Contains(m.Pago!.Formapagoid)
                                                                         )
                                                                    ) ? 1m :
                                                                    (
                                                                      (
                                                                        (
                                                                            m.Pago!.Tipopagoid == 1 &&
                                                                            (new long?[] { 7, 19 }).Contains(m.Pago!.Formapagoid)
                                                                         ) ||
                                                                        (
                                                                            m.Pago!.Tipopagoid == 2 &&
                                                                            (new long?[] { 6, 18 }).Contains(m.Pago!.Formapagoid)
                                                                         )
                                                                      ) ? -1m : 0m

                                                                    )
                                                                   ),
m.Pago!.Formapago != null ? m.Pago!.Formapago.Clave : "",
m.Pago!.Formapago != null ? m.Pago!.Formapago.Nombre : "",
m.Pago!.Formapagosat != null ? m.Pago!.Formapagosat.Clave : "",
m.Pago!.Formapagosat != null ? m.Pago!.Formapagosat.Nombre : "",


                                                          m.Pago!.Referenciabancaria,
m.Pago!.Tipopago != null ? m.Pago!.Tipopago.Clave : "",
m.Pago!.Tipopago != null ? m.Pago!.Tipopago.Nombre : "",
m.Pago!.Banco != null ? m.Pago!.Banco.Clave : "",
m.Pago!.Banco != null ? m.Pago!.Banco.Nombre : "",


                                                          m.Pago!.Fechaelaboracion,
                                                          m.Pago!.Fecharecepcion,
                                                          m.Pago!.Reciboelectronicoid,
(m.Pago!.Pago_bancomer == null || m.Pago!.Pago_bancomer!.Bancomerparamid == 0 ? BoolCN.N : BoolCN.S),
(m.Pago!.Pago_bancomer == null ? m.Pago!.Pago_bancomer!.Bancomerparamid : 0),

                                                          m.Pago!.Comision,
                                                          m.Pago!.Notas,
                                                          m.Pago!.Aplicado,
                                                          m.Pago!.Fechaaplicado,
                                                          m.Docto!.Tipodoctoid == 202 && m.Docto!.Docto_info_pago != null ?
                                                                    m.Docto!.Docto_info_pago!.Totalanticipo :
                                                                    m.Pago!.Importe,
                                                          m.Pago!.Refinterno,
                                                          m.Tipoabono!.Nombre,

                                                          m.Pago.Formapagoid,
                                                          m.Pago.Formapagosatid,
                                                          m.Pago.Clienteid,
                                                          m.Pago.Proveedorid,
                                                          m.Pago.Bancoid,
                                                          m.Pago.Tipopagoid,
                                                          m.Pago.Cuentabancoempresaid,
                                                          m.Pago.Cuentapagocredito ,
                                                          m.Pago.Sentidopago ,
                                                          m.Pago.Pagoparentid,
                                                          m.Pago.Cuentabancoempresa != null ? m.Pago.Cuentabancoempresa!.Clave : "",
                                                          m.Pago.Cuentabancoempresa != null ? m.Pago.Cuentabancoempresa!.Nombre : "" ,
                                                          m.Pago.Cliente != null ? m.Pago.Cliente!.Clave : "",
                                                          m.Pago.Cliente != null ? m.Pago.Cliente!.Nombre : "",
                                                          m.Pago.Proveedor != null ? m.Pago.Proveedor!.Clave : "",
                                                          m.Pago.Proveedor != null ? m.Pago.Proveedor!.Nombre : "",
                                                          m.Pago.Revertido,
                                                          (m.Pago.Importe != m.Importe)




                                                      )).ToList();

                return lstPagos;


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


    public class Kardex_abono_transaccion
    {
        public long Empresaid { get; set; }
        public long Sucursalid { get; set; }
        public long Id { get; set; }
        public BoolCS Activo { get; set; }
        public DateTimeOffset Creado { get; set; }
        public long? Creadopor_userid { get; set; }
        public long? Tipomovimientokardexabonoid { get; set; }
        public DateTimeOffset Fechahora { get; set; }
        public decimal Importe { get; set; }
        public decimal Importecambio { get; set; }
        public long? Clienteid { get; set; }
        public long? Proveedorid { get; set; }
        public long? Pagoid { get; set; }
        public long? Doctopagoid { get; set; }
        public long? Formapagoid { get; set; }
        public long? Doctoid { get; set; }
        public long? Tipodoctoid { get; set; }
        public long? Corteid { get; set; }
        public int Sentidoabonodocto { get; set; }
        public int Sentidoabonocliente { get; set; }
        public int Sentidoabonoproveedor { get; set; }
        public int Sentidoabonocorte { get; set; }

    }



    public class Tmp_PagosList
    {
        public long EmpresaId { get; }
        public long SucursalId { get; }
        public long Id { get; }
        public DateTimeOffset? Fecha { get; }
        public DateTimeOffset? Fechahora { get; }
        public decimal Importe { get; }
        public string Formapagoclave { get; }
        public string Formapagonombre { get; }
        public string Formapagosatclave { get; }
        public string Formapagosatnombre { get; }
        public string? Bancoclave { get; }
        public string? Banconombre { get; }
        public string? Referenciabancaria { get; }
        public string Tipopagoclave { get; }
        public string Tipopagonombre { get; }
        public string Timbrado { get; }
        public BoolCN? Aplicado { get; }
        public string ClienteClave { get; }
        public string ClienteNombre { get; }
        public string ProveedorClave { get; }
        public string ProveedorNombre { get; }

        public Tmp_PagosList(long empresaId, long sucursalId, long id, DateTimeOffset? fecha, DateTimeOffset? fechahora, decimal importe, string formapagoclave, string formapagonombre, string formapagosatclave, string formapagosatnombre, string? bancoclave, string? banconombre, string? referenciabancaria, string tipopagoclave, string tipopagonombre, string timbrado, BoolCN? aplicado, string clienteClave, string clienteNombre, string proveedorClave, string proveedorNombre)
        {
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            Id = id;
            Fecha = fecha;
            Fechahora = fechahora;
            Importe = importe;
            Formapagoclave = formapagoclave;
            Formapagonombre = formapagonombre;
            Formapagosatclave = formapagosatclave;
            Formapagosatnombre = formapagosatnombre;
            Bancoclave = bancoclave;
            Banconombre = banconombre;
            Referenciabancaria = referenciabancaria;
            Tipopagoclave = tipopagoclave;
            Tipopagonombre = tipopagonombre;
            Timbrado = timbrado;
            Aplicado = aplicado;
            ClienteClave = clienteClave;
            ClienteNombre = clienteNombre;
            ProveedorClave = proveedorClave;
            ProveedorNombre = proveedorNombre;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_PagosList other &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   Id == other.Id &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha, other.Fecha) &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fechahora, other.Fechahora) &&
                   Importe == other.Importe &&
                   Formapagoclave == other.Formapagoclave &&
                   Formapagonombre == other.Formapagonombre &&
                   Formapagosatclave == other.Formapagosatclave &&
                   Formapagosatnombre == other.Formapagosatnombre &&
                   Bancoclave == other.Bancoclave &&
                   Banconombre == other.Banconombre &&
                   Referenciabancaria == other.Referenciabancaria &&
                   Tipopagoclave == other.Tipopagoclave &&
                   Tipopagonombre == other.Tipopagonombre &&
                   Timbrado == other.Timbrado &&
                   Aplicado == other.Aplicado &&
                   ClienteClave == other.ClienteClave &&
                   ClienteNombre == other.ClienteNombre &&
                   ProveedorClave == other.ProveedorClave &&
                   ProveedorNombre == other.ProveedorNombre;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(EmpresaId);
            hash.Add(SucursalId);
            hash.Add(Id);
            hash.Add(Fecha);
            hash.Add(Fechahora);
            hash.Add(Importe);
            hash.Add(Formapagoclave);
            hash.Add(Formapagonombre);
            hash.Add(Formapagosatclave);
            hash.Add(Formapagosatnombre);
            hash.Add(Bancoclave);
            hash.Add(Banconombre);
            hash.Add(Referenciabancaria);
            hash.Add(Tipopagoclave);
            hash.Add(Tipopagonombre);
            hash.Add(Timbrado);
            hash.Add(Aplicado);
            hash.Add(ClienteClave);
            hash.Add(ClienteNombre);
            hash.Add(ProveedorClave);
            hash.Add(ProveedorNombre);
            return hash.ToHashCode();
        }
    }

    public class Tmp_DoctosConSaldoList
    {
        public long EmpresaId { get; }
        public long SucursalId { get; }
        public long Id { get; }
        public long? Sucursal_info_id { get; }
        public string Sucursal_info_clave { get; }
        public string Sucursal_info_nombre { get; }
        public long? Cajaid { get; }
        public string Cajaclave { get; }
        public string Cajanombre { get; }
        public DateTimeOffset? Fecha { get; }
        public string? Serie { get; }
        public decimal Total { get; }
        public long? Estatusdoctoid { get; }
        public string Estatusdoctoclave { get; }
        public string Estatusdoctonombre { get; }
        public long? Tipodoctoid { get; }
        public string Tipodoctoclave { get; }
        public string Tipodoctonombre { get; }
        public string? Referencia { get; }
        public long? SucursalDestinoid { get; }
        public string SucursalDestinoclave { get; }
        public string SucursalDestinonombre { get; }
        public int? Folio { get; }
        public string ClienteClave { get; }
        public string ClienteNombre { get; }
        public string ProveedorClave { get; }
        public string ProveedorNombre { get; }
        public string? UsuarioClave { get; }
        public string UsuarioNombre { get; }
        public decimal Saldo { get; }
        public decimal MontoAplicar { get; }
        public BoolCN EsFacturaEletronica { get; }
        public string EstaTimbrado { get; }
        public string SerieFolioSat { get; }

        public Tmp_DoctosConSaldoList(long empresaId, long sucursalId, long id, long? sucursal_info_id, string sucursal_info_clave, string sucursal_info_nombre, long? cajaid, string cajaclave, string cajanombre, DateTimeOffset? fecha, string? serie, decimal total, long? estatusdoctoid, string estatusdoctoclave, string estatusdoctonombre, long? tipodoctoid, string tipodoctoclave, string tipodoctonombre, string? referencia, long? sucursalDestinoid, string sucursalDestinoclave, string sucursalDestinonombre, int? folio, string clienteClave, string clienteNombre, string proveedorClave, string proveedorNombre, string? usuarioClave, string usuarioNombre, decimal saldo, decimal montoAplicar, BoolCN esFacturaEletronica, string estaTimbrado, string serieFolioSat)
        {
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            Id = id;
            Sucursal_info_id = sucursal_info_id;
            Sucursal_info_clave = sucursal_info_clave;
            Sucursal_info_nombre = sucursal_info_nombre;
            Cajaid = cajaid;
            Cajaclave = cajaclave;
            Cajanombre = cajanombre;
            Fecha = fecha;
            Serie = serie;
            Total = total;
            Estatusdoctoid = estatusdoctoid;
            Estatusdoctoclave = estatusdoctoclave;
            Estatusdoctonombre = estatusdoctonombre;
            Tipodoctoid = tipodoctoid;
            Tipodoctoclave = tipodoctoclave;
            Tipodoctonombre = tipodoctonombre;
            Referencia = referencia;
            SucursalDestinoid = sucursalDestinoid;
            SucursalDestinoclave = sucursalDestinoclave;
            SucursalDestinonombre = sucursalDestinonombre;
            Folio = folio;
            ClienteClave = clienteClave;
            ClienteNombre = clienteNombre;
            ProveedorClave = proveedorClave;
            ProveedorNombre = proveedorNombre;
            UsuarioClave = usuarioClave;
            UsuarioNombre = usuarioNombre;
            Saldo = saldo;
            MontoAplicar = montoAplicar;
            EsFacturaEletronica = esFacturaEletronica;
            EstaTimbrado = estaTimbrado;
            SerieFolioSat = serieFolioSat;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_DoctosConSaldoList other &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   Id == other.Id &&
                   Sucursal_info_id == other.Sucursal_info_id &&
                   Sucursal_info_clave == other.Sucursal_info_clave &&
                   Sucursal_info_nombre == other.Sucursal_info_nombre &&
                   Cajaid == other.Cajaid &&
                   Cajaclave == other.Cajaclave &&
                   Cajanombre == other.Cajanombre &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha, other.Fecha) &&
                   Serie == other.Serie &&
                   Total == other.Total &&
                   Estatusdoctoid == other.Estatusdoctoid &&
                   Estatusdoctoclave == other.Estatusdoctoclave &&
                   Estatusdoctonombre == other.Estatusdoctonombre &&
                   Tipodoctoid == other.Tipodoctoid &&
                   Tipodoctoclave == other.Tipodoctoclave &&
                   Tipodoctonombre == other.Tipodoctonombre &&
                   Referencia == other.Referencia &&
                   SucursalDestinoid == other.SucursalDestinoid &&
                   SucursalDestinoclave == other.SucursalDestinoclave &&
                   SucursalDestinonombre == other.SucursalDestinonombre &&
                   Folio == other.Folio &&
                   ClienteClave == other.ClienteClave &&
                   ClienteNombre == other.ClienteNombre &&
                   ProveedorClave == other.ProveedorClave &&
                   ProveedorNombre == other.ProveedorNombre &&
                   UsuarioClave == other.UsuarioClave &&
                   UsuarioNombre == other.UsuarioNombre &&
                   Saldo == other.Saldo &&
                   MontoAplicar == other.MontoAplicar &&
                   EsFacturaEletronica == other.EsFacturaEletronica &&
                   EstaTimbrado == other.EstaTimbrado &&
                   SerieFolioSat == other.SerieFolioSat;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(EmpresaId);
            hash.Add(SucursalId);
            hash.Add(Id);
            hash.Add(Sucursal_info_id);
            hash.Add(Sucursal_info_clave);
            hash.Add(Sucursal_info_nombre);
            hash.Add(Cajaid);
            hash.Add(Cajaclave);
            hash.Add(Cajanombre);
            hash.Add(Fecha);
            hash.Add(Serie);
            hash.Add(Total);
            hash.Add(Estatusdoctoid);
            hash.Add(Estatusdoctoclave);
            hash.Add(Estatusdoctonombre);
            hash.Add(Tipodoctoid);
            hash.Add(Tipodoctoclave);
            hash.Add(Tipodoctonombre);
            hash.Add(Referencia);
            hash.Add(SucursalDestinoid);
            hash.Add(SucursalDestinoclave);
            hash.Add(SucursalDestinonombre);
            hash.Add(Folio);
            hash.Add(ClienteClave);
            hash.Add(ClienteNombre);
            hash.Add(ProveedorClave);
            hash.Add(ProveedorNombre);
            hash.Add(UsuarioClave);
            hash.Add(UsuarioNombre);
            hash.Add(Saldo);
            hash.Add(MontoAplicar);
            hash.Add(EsFacturaEletronica);
            hash.Add(EstaTimbrado);
            hash.Add(SerieFolioSat);
            return hash.ToHashCode();
        }
    }

    public class Tmp_DoctoPagosAplicadosList
    {
        public long EmpresaId { get; }
        public long SucursalId { get; }
        public long Id { get; }
        public decimal Importe { get; }
        public int? Docto_Folio { get; }
        public string Docto_SerieFolioSat { get; }
        public BoolCN Esfacturaelectronica { get; }
        public string Estatimbrado { get; }

        public Tmp_DoctoPagosAplicadosList(long empresaId, long sucursalId, long id, decimal importe, int? docto_Folio, string docto_SerieFolioSat, BoolCN esfacturaelectronica, string estatimbrado)
        {
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            Id = id;
            Importe = importe;
            Docto_Folio = docto_Folio;
            Docto_SerieFolioSat = docto_SerieFolioSat;
            Esfacturaelectronica = esfacturaelectronica;
            Estatimbrado = estatimbrado;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_DoctoPagosAplicadosList other &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   Id == other.Id &&
                   Importe == other.Importe &&
                   Docto_Folio == other.Docto_Folio &&
                   Docto_SerieFolioSat == other.Docto_SerieFolioSat &&
                   Esfacturaelectronica == other.Esfacturaelectronica &&
                   Estatimbrado == other.Estatimbrado;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EmpresaId, SucursalId, Id, Importe, Docto_Folio, Docto_SerieFolioSat, Esfacturaelectronica, Estatimbrado);
        }
    }


    /*
     
       p_empresaid public.d_id,
  p_sucursalid public.d_id,
  p_id public.d_id,
  p_doctoid public.d_fk,
  p_formapagoid public.d_fk,
  p_fecha public.d_fecha,
  p_fechahora public.d_timestamp,
  p_corteid public.d_fk,
  p_importe public.d_importe,
  p_importerecibido public.d_importe,
  p_importecambio public.d_importe,
  p_tipopagoid public.d_fk,
  p_docto2id public.d_fk,
  p_esapartado public.d_boolcn,
  p_tipoaplicacioncreditoid public.d_fk,
  p_bancoid public.d_fk,
  p_referenciabancaria public.d_stdtext_light,
  p_notas public.d_stdtext_medium,
  p_fechaelaboracion public.d_fecha,
  p_fecharecepcion public.d_fecha,
  p_espagoinicial public.d_boolcn,
  p_tipoabonoid public.d_fk,
  p_pagoparentid public.d_fk,
  p_formapagosatid public.d_fk,
  p_bancomerparamid public.d_fk,
  p_comision public.d_importe,
  p_cuentapagocredito public.d_stdtext_light,
  p_cuentabancoempresaid public.d_fk,
  p_aplicado public.d_boolcn_null,
  p_fechaaplicado public.d_fecha,
  p_clienteid public.d_fk,
  p_proveedorid public.d_fk,
  p_usuarioid public.d_fk,
  p_sentidopago public.d_integer,
     */

}
