using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace IposV3.Services
{
    public class DoctoService
    {

        private CorteService _corteService;
        public DoctoService(CorteService corteService)
        {
            _corteService = corteService;
        }


        public void DoctoInsert(DoctoTransaction doctoTrans, ref long? doctoId, ApplicationDbContext localContext)
        {


            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            long? corteid;
            BoolCS? corte_activo;
            DateTimeOffset? fechacorte;
            DateTimeOffset? corte_inicia;
            DateTimeOffset? corte_termina;

            doctoId = null;

            try
            {
                _corteService.HayCorteActivo(doctoTrans.Empresaid, doctoTrans.Sucursalid, doctoTrans.Usuarioid!.Value,
                                               out corteid, out corte_activo, out fechacorte, out corte_inicia, out corte_termina, localContext);

                if(corteid == null || corteid == 0) {
                    throw new Exception("No hay corte activo");
                }

                doctoTrans.Corteid = corteid;

                Docto doctoItem = new Docto();
                doctoItem.Modificado = DateTimeOffset.UtcNow;
                doctoItem.ModificadoPorId = doctoTrans.Creadopor_userid;
                doctoItem.EmpresaId = doctoTrans.Empresaid;
                doctoItem.SucursalId = doctoTrans.Sucursalid;
                //doctoItem.Id = doctoTrans.Id;
                doctoItem.Activo = doctoTrans.Activo;
                doctoItem.Creado = DateTimeOffset.UtcNow;
                doctoItem.CreadoPorId = doctoTrans.Creadopor_userid;


                doctoItem.Estatusdoctoid = doctoTrans.Estatusdoctoid;
                doctoItem.Usuarioid = doctoTrans.Usuarioid;
                doctoItem.Corteid = doctoTrans.Corteid;
                doctoItem.Fecha = doctoTrans.Fecha;
                doctoItem.Fechahora = doctoTrans.Fechahora;
                doctoItem.Serie = doctoTrans.Serie;
                doctoItem.Folio = doctoTrans.Folio;
                doctoItem.Importe = doctoTrans.Importe;
                doctoItem.Descuento = doctoTrans.Descuento;
                doctoItem.Subtotal = doctoTrans.Subtotal;
                doctoItem.Iva = doctoTrans.Iva;
                doctoItem.Ieps = doctoTrans.Ieps;
                doctoItem.Total = doctoTrans.Total;
                doctoItem.Cargo = doctoTrans.Cargo;
                doctoItem.Abono = doctoTrans.Abono;
                doctoItem.Saldo = doctoTrans.Saldo;
                doctoItem.Cajaid = doctoTrans.Cajaid;
                doctoItem.Almacenid = doctoTrans.Almacenid;
                doctoItem.Origenfiscalid = doctoTrans.Origenfiscalid;
                doctoItem.Esapartado = doctoTrans.Esapartado;
                doctoItem.Doctoparentid = doctoTrans.Doctoparentid;
                doctoItem.Clienteid = doctoTrans.Clienteid;
                doctoItem.Tipodoctoid = doctoTrans.Tipodoctoid;
                doctoItem.Proveedorid = doctoTrans.Proveedorid;
                doctoItem.Sucursal_id = doctoTrans.Sucursal_id;
                doctoItem.Referencia = doctoTrans.Referencia;
                doctoItem.Referencias = doctoTrans.Referencias;
                doctoItem.Fechavence = doctoTrans.Fechavence;
                localContext.Add(doctoItem);


                localContext.SaveChanges();

                doctoId = doctoItem.Id;

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




        public void DoctoUpdate(DoctoTransaction doctoTrans, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;


            try
            {

                var doctoItem = localContext.Docto.FirstOrDefault(d => d.EmpresaId == doctoTrans.Empresaid && d.SucursalId == doctoTrans.Sucursalid &&
                                                                         d.Id == doctoTrans.Id);
                if (doctoItem == null)
                    throw new Exception("El docto no fue encontrado");   

                doctoItem.Modificado = DateTimeOffset.UtcNow;
                doctoItem.ModificadoPorId = doctoTrans.Creadopor_userid;
                doctoItem.Activo = doctoTrans.Activo;


                doctoItem.Usuarioid = doctoTrans.Usuarioid;
                doctoItem.Corteid = doctoTrans.Corteid;
                doctoItem.Fecha = doctoTrans.Fecha;
                doctoItem.Fechahora = doctoTrans.Fechahora;
                doctoItem.Serie = doctoTrans.Serie;
                doctoItem.Folio = doctoTrans.Folio;
                doctoItem.Importe = doctoTrans.Importe;
                doctoItem.Descuento = doctoTrans.Descuento;
                doctoItem.Subtotal = doctoTrans.Subtotal;
                doctoItem.Iva = doctoTrans.Iva;
                doctoItem.Ieps = doctoTrans.Ieps;
                doctoItem.Total = doctoTrans.Total;
                doctoItem.Cargo = doctoTrans.Cargo;
                doctoItem.Abono = doctoTrans.Abono;
                doctoItem.Saldo = doctoTrans.Saldo;
                doctoItem.Cajaid = doctoTrans.Cajaid;
                doctoItem.Almacenid = doctoTrans.Almacenid;
                doctoItem.Origenfiscalid = doctoTrans.Origenfiscalid;
                doctoItem.Esapartado = doctoTrans.Esapartado;
                doctoItem.Doctoparentid = doctoTrans.Doctoparentid;
                doctoItem.Clienteid = doctoTrans.Clienteid;
                doctoItem.Tipodoctoid = doctoTrans.Tipodoctoid;
                doctoItem.Proveedorid = doctoTrans.Proveedorid;
                doctoItem.Sucursal_id = doctoTrans.Sucursal_id;
                doctoItem.Referencia = doctoTrans.Referencia;
                doctoItem.Referencias = doctoTrans.Referencias;
                doctoItem.Fechavence = doctoTrans.Fechavence;
                localContext.Update(doctoItem);

                //localContext.SaveChanges();

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



        public List<DoctoImpuestoCalculado> CalcularImpuestosDocto(
            long empresaId, long sucursalId, 
            long doctoId, ApplicationDbContext localContext)
        {



            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            var listaDoctoImpuestosCalculados = new List<DoctoImpuestoCalculado>();
            var listaDoctoImpuestosCalculadosBuffer = new List<DoctoImpuestoCalculado>();

            try
            {


                var impuestosIvaNoKit = localContext.Movto.AsNoTracking()
                                            .Where( m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == doctoId &&
                                                         (m.Eskit == BoolCN.N || m.Kitimpfijo == BoolCN.S) && m.Tasaiva > 0m)
                                            .GroupBy(m => new { m.EmpresaId, m.SucursalId, m.Doctoid, m.Tasaiva })
                                            .Select(g => new DoctoImpuestoCalculado()
                                            {
                                                Empresaid = g.Key.EmpresaId,
                                                Sucursalid = g.Key.SucursalId,
                                                DoctoId = g.Key.Doctoid,
                                                Tasaimpuesto = g.Key.Tasaiva,
                                                Tipoimpuestoid = 2,
                                                Monto = g.Sum(s => s.Iva),
                                                Base = g.Sum(s => s.Subtotal + s.Ieps)
                                            }).ToList();
                listaDoctoImpuestosCalculadosBuffer.AddRange(impuestosIvaNoKit);


                var impuestosIvaKit = localContext.Movto_kit_def.AsNoTracking().Include(m => m.Movto)
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Movto != null && m.Movto.Doctoid == doctoId &&
                                                         (m.Movto.Eskit == BoolCN.S && m.Movto.Kitimpfijo == BoolCN.N) && m.Tasaiva > 0m)
                                            .GroupBy(m => new { m.EmpresaId, m.SucursalId, m.Movto!.Doctoid, m.Tasaiva })
                                            .Select(g => new DoctoImpuestoCalculado()
                                            {
                                                Empresaid = g.Key.EmpresaId,
                                                Sucursalid = g.Key.SucursalId,
                                                DoctoId = g.Key.Doctoid,
                                                Tasaimpuesto = g.Key.Tasaiva,
                                                Tipoimpuestoid = 2,
                                                Monto = g.Sum(s => s.Montoiva),
                                                Base = g.Sum(s => s.Montosubtotal + s.Montoieps)
                                            }).ToList();
                listaDoctoImpuestosCalculadosBuffer.AddRange(impuestosIvaKit);


                var impuestosIepsNoKit = localContext.Movto.AsNoTracking()
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == doctoId &&
                                                         (m.Eskit == BoolCN.N || m.Kitimpfijo == BoolCN.S) && m.Tasaieps > 0m)
                                            .GroupBy(m => new { m.EmpresaId, m.SucursalId, m.Doctoid, m.Tasaieps })
                                            .Select(g => new DoctoImpuestoCalculado()
                                            {
                                                Empresaid = g.Key.EmpresaId,
                                                Sucursalid = g.Key.SucursalId,
                                                DoctoId = g.Key.Doctoid,
                                                Tasaimpuesto = g.Key.Tasaieps,
                                                Tipoimpuestoid = 3,
                                                Monto = g.Sum(s => s.Ieps),
                                                Base = g.Sum(s => s.Subtotal )
                                            }).ToList();
                listaDoctoImpuestosCalculadosBuffer.AddRange(impuestosIepsNoKit);


                var impuestosIepsKit = localContext.Movto_kit_def.AsNoTracking().Include(m => m.Movto)
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Movto != null && m.Movto.Doctoid == doctoId &&
                                                         (m.Movto.Eskit == BoolCN.S && m.Movto.Kitimpfijo == BoolCN.N) && m.Tasaieps > 0m)
                                            .GroupBy(m => new { m.EmpresaId, m.SucursalId, m.Movto!.Doctoid, m.Tasaieps })
                                            .Select(g => new DoctoImpuestoCalculado()
                                            {
                                                Empresaid = g.Key.EmpresaId,
                                                Sucursalid = g.Key.SucursalId,
                                                DoctoId = g.Key.Doctoid,
                                                Tasaimpuesto = g.Key.Tasaieps,
                                                Tipoimpuestoid = 3,
                                                Monto = g.Sum(s => s.Montoieps),
                                                Base = g.Sum(s => s.Montosubtotal)
                                            }).ToList();
                listaDoctoImpuestosCalculadosBuffer.AddRange(impuestosIepsKit);


                var impuestosIsrRetenido = localContext.Movto.AsNoTracking()
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == doctoId &&
                                                          m.Tasaisrretenido > 0m)
                                            .GroupBy(m => new { m.EmpresaId, m.SucursalId, m.Doctoid, m.Tasaisrretenido })
                                            .Select(g => new DoctoImpuestoCalculado()
                                            {
                                                Empresaid = g.Key.EmpresaId,
                                                Sucursalid = g.Key.SucursalId,
                                                DoctoId = g.Key.Doctoid,
                                                Tasaimpuesto = g.Key.Tasaisrretenido,
                                                Tipoimpuestoid = 1001,
                                                Monto = g.Sum(s => s.Isrretenido),
                                                Base = g.Sum(s => s.Subtotal)
                                            }).ToList();
                listaDoctoImpuestosCalculadosBuffer.AddRange(impuestosIsrRetenido);


                var impuestosIvaRetenido = localContext.Movto.AsNoTracking()
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == doctoId &&
                                                          m.Tasaivaretenido > 0m)
                                            .GroupBy(m => new { m.EmpresaId, m.SucursalId, m.Doctoid, m.Tasaivaretenido })
                                            .Select(g => new DoctoImpuestoCalculado()
                                            {
                                                Empresaid = g.Key.EmpresaId,
                                                Sucursalid = g.Key.SucursalId,
                                                DoctoId = g.Key.Doctoid,
                                                Tasaimpuesto = g.Key.Tasaivaretenido,
                                                Tipoimpuestoid = 1002,
                                                Monto = g.Sum(s => s.Ivaretenido),
                                                Base = g.Sum(s => s.Subtotal)
                                            }).ToList();
                listaDoctoImpuestosCalculadosBuffer.AddRange(impuestosIvaRetenido);


                listaDoctoImpuestosCalculados = listaDoctoImpuestosCalculadosBuffer
                                            .GroupBy(m => new { m.Empresaid, m.Sucursalid, m.DoctoId, 
                                                                m.Tasaimpuesto, m.Tipoimpuestoid
                                            })
                                            .Select(g => new DoctoImpuestoCalculado()
                                            {
                                                Empresaid = g.Key.Empresaid ,
                                                Sucursalid = g.Key.Sucursalid ,
                                                DoctoId = g.Key.DoctoId ,
                                                Tasaimpuesto = g.Key.Tasaimpuesto ,
                                                Tipoimpuestoid = g.Key.Tipoimpuestoid ,
                                                Monto = g.Sum(s => s.Monto),
                                                Base = g.Sum(s => s.Base)
                                            }).ToList();

                return listaDoctoImpuestosCalculados;


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



        //aqui me quede 02 07 2023 Es el view core.fnc_docto_sync_movto_imp..sigue core.fnc_docto_sync_movto_totales
        public void ActualizarImpuestosDocto(
            long empresaId, long sucursalId,
            long doctoId, ApplicationDbContext localContext)
        {



            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;


            try
            {

                var listaDoctoImpuestosCalculados = CalcularImpuestosDocto(empresaId, sucursalId, doctoId, localContext);
                
                localContext.Docto_impuestos
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Doctoid == doctoId)
                    .Update(x => new Docto_impuestos() { Activo = BoolCS.N });

                foreach(var impuesto_calculado in listaDoctoImpuestosCalculados)
                {

                    var doctoImpuesto = localContext.Docto_impuestos
                                                    .Where(f => f.EmpresaId == empresaId &&
                                                                f.SucursalId == sucursalId &&
                                                                f.Doctoid == doctoId &&
                                                                f.Tipoimpuestoid == impuesto_calculado.Tipoimpuestoid &&
                                                                f.Tasaimpuesto == impuesto_calculado.Tasaimpuesto).FirstOrDefault();
                    
                    if(doctoImpuesto != null)
                    {
                        doctoImpuesto.Monto = impuesto_calculado.Monto;
                        doctoImpuesto.Base = impuesto_calculado.Base;
                        doctoImpuesto.Activo = BoolCS.S;
                        localContext.Docto_impuestos.Update(doctoImpuesto);
                    }
                    else
                    {
                        doctoImpuesto = new Docto_impuestos();
                        doctoImpuesto.EmpresaId = empresaId;
                        doctoImpuesto.SucursalId = sucursalId;
                        doctoImpuesto.Activo = BoolCS.S;
                        doctoImpuesto.Doctoid = doctoId;
                        doctoImpuesto.Tipoimpuestoid = impuesto_calculado.Tipoimpuestoid;
                        doctoImpuesto.Tasaimpuesto = impuesto_calculado.Tasaimpuesto;
                        doctoImpuesto.Monto = impuesto_calculado.Monto;
                        doctoImpuesto.Base = impuesto_calculado.Base;
                        localContext.Docto_impuestos.Add(doctoImpuesto);
                    }
                }

                localContext.SaveChanges();

                localContext.Docto_impuestos
                    .Where(f => f.EmpresaId == empresaId && f.SucursalId == sucursalId && f.Doctoid == doctoId && f.Activo == BoolCS.N)
                    .Delete();

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



        public void SincronizarTotales(long empresaId, long sucursalId,
            long doctoId, ApplicationDbContext localContext)
        {


            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;




            try
            {
                var totalesMovto = localContext.Movto.AsNoTracking()
                                                     .Where(m => m.EmpresaId == empresaId &&
                                                                 m.SucursalId == sucursalId && m.Doctoid == doctoId)
                                                      .GroupBy(m => new { m.EmpresaId, m.SucursalId, m.Doctoid })
                                                      .Select(g => new MovtoTotales()
                                                      {
                                                          Importe = g.Sum(s => s.Importe),
                                                          Descuento = g.Sum(s => s.Descuento),
                                                          Subtotal = g.Sum(s => s.Subtotal),
                                                          Iva = g.Sum(s => s.Iva),
                                                          Ieps = g.Sum(s => s.Ieps),
                                                          Total = g.Sum(s => s.Total),
                                                          Cargo = g.Sum(s => s.Cargo),
                                                          Isrretenido = g.Sum(s => s.Isrretenido),
                                                          Ivaretenido = g.Sum(s => s.Ivaretenido),

                                                      }).FirstOrDefault();

                totalesMovto = totalesMovto ?? new MovtoTotales();

                this.ActualizarImpuestosDocto(empresaId, sucursalId, doctoId, localContext);

                var docto = localContext.Docto.FirstOrDefault(m => m.EmpresaId == empresaId &&
                                                                 m.SucursalId == sucursalId && m.Id == doctoId);

                if (docto != null)
                {
                    docto.Importe = totalesMovto.Importe;
                    docto.Descuento = totalesMovto.Descuento;
                    docto.Subtotal = totalesMovto.Subtotal;
                    docto.Iva = totalesMovto.Iva;
                    docto.Ieps = totalesMovto.Ieps;
                    docto.Total = totalesMovto.Total;
                    docto.Cargo = totalesMovto.Cargo;
                    localContext.Update(docto);
                }

                var doctoFactElect = localContext.Docto_fact_elect.FirstOrDefault(f => f.EmpresaId == empresaId &&
                                                                                       f.SucursalId == sucursalId && f.Doctoid == doctoId);
                if(doctoFactElect != null)
                {
                    doctoFactElect.Isrretenido = totalesMovto.Isrretenido;
                    doctoFactElect.Ivaretenido = totalesMovto.Ivaretenido;

                    localContext.Update(doctoFactElect);
                }
                else
                {
                    doctoFactElect = new Docto_fact_elect();
                    doctoFactElect.EmpresaId = empresaId;
                    doctoFactElect.SucursalId = sucursalId;
                    doctoFactElect.Doctoid = doctoId;
                    doctoFactElect.Isrretenido = totalesMovto.Isrretenido;
                    doctoFactElect.Ivaretenido = totalesMovto.Ivaretenido;

                    localContext.Add(doctoFactElect);


                }

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










        public void Generar_consecutivo_folio(long empresaId, long sucursalId, long doctoId,
            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {


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





        public List<Tmp_docto_basico> Docto_basico(long empresaId, long sucursalId,long doctoId, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {


                var lstDoctoBasico = localContext.Docto.AsNoTracking()
                                                 .Include(x => x.Docto_compra)
                                                 .Include(x => x.Proveedor)
                                                 .Include(x => x.Cliente)
                                                 .Include(x => x.Origenfiscal)
                                                 .Include(x => x.Docto_fact_elect)
                                                 .Include(x => x.Docto_traslado).ThenInclude(s => s!.Sucursalt)
                                                 .Include(x => x.Tipodocto)
                                                      .Where(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == doctoId
                                                      )
                                                      .Select(d => new Tmp_docto_basico(
                                                          d.EmpresaId,
                                                          d.SucursalId,
                                                          d.Id,
                                                          d.Activo,
                                                          d.Estatusdoctoid,
                                                          d.Usuarioid,
                                                          d.Fecha,
                                                          d.Serie,
                                                          d.Folio,
                                                          d.Importe,
                                                          d.Descuento,
                                                          d.Subtotal,
                                                          d.Iva,
                                                          d.Ieps,
                                                          d.Total,
                                                          d.Cajaid,
                                                          d.Proveedorid,
d.Proveedor != null ? d.Proveedor.Clave : null,
d.Proveedor != null ? d.Proveedor.Nombre : null,
                                                          d.Clienteid,
d.Cliente != null ? d.Cliente.Clave : null,
d.Cliente != null ? d.Cliente.Nombre : null,
                                                          d.Tipodoctoid,
d.Tipodocto != null ? d.Tipodocto.Clave : null,
d.Tipodocto != null ? d.Tipodocto.Nombre : null,
                                                          d.Referencia,
                                                          d.Origenfiscalid,
d.Origenfiscal != null ? d.Origenfiscal.Clave : null,
d.Origenfiscal != null ? d.Origenfiscal.Nombre : null,
d.Origenfiscal != null ? d.Origenfiscal.Nombre : null,
d.Docto_compra != null ? d.Docto_compra.Fechafactura : null,
d.Fechavence ,
d.Docto_compra != null ? d.Docto_compra.Folio : null,
d.Almacenid,
d.Docto_fact_elect != null ? d.Docto_fact_elect.Timbradouuid : null,

                                        d.Docto_traslado != null ? d.Docto_traslado.Sucursaltid : null,
                                        d.Docto_traslado != null && d.Docto_traslado.Sucursalt != null ? d.Docto_traslado.Sucursalt.Clave : null,
                                        d.Docto_traslado != null && d.Docto_traslado.Sucursalt != null ? d.Docto_traslado.Sucursalt.Nombre : null

                                                      )).ToList();

                return lstDoctoBasico;


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



    public class DoctoImpuestoCalculado
    {
        public long Empresaid { get; set; }
        public long Sucursalid { get; set; }
        public long? DoctoId { get; set; }
        public long? Tipoimpuestoid { get; set; }
        public decimal Tasaimpuesto { get; set; } = 0m;

        public decimal Monto { get; set; } = 0m;

        public decimal Base { get; set; } = 0m;
    }

    public class MovtoTotales
    {

        public decimal Importe { get; set; } = 0m;
        public decimal Descuento { get; set; } = 0m;
        public decimal Subtotal { get; set; } = 0m;
        public decimal Iva { get; set; } = 0m;
        public decimal Ieps { get; set; } = 0m;
        public decimal Total { get; set; } = 0m;
        public decimal Cargo { get; set; } = 0m;
        public decimal Isrretenido { get; set; } = 0m;
        public decimal Ivaretenido { get; set; } = 0m;
    }

    public class DoctoTransaction : TransitionClass
    {
        public long Empresaid { get; set; }
        public long Sucursalid { get; set; }
        public long Id { get; set; }
        public BoolCS Activo { get; set; }
        public DateTimeOffset Creado { get; set; }
        public long? Creadopor_userid { get; set; }
        public long? Estatusdoctoid { get; set; }
        public long? Usuarioid { get; set; }
        public long? Corteid { get; set; }
        public DateTimeOffset Fecha { get; set; }
        public DateTimeOffset Fechahora { get; set; }
        public string? Serie { get; set; }
        public int? Folio { get; set; }
        public decimal Importe { get; set; }
        public decimal Descuento { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Ieps { get; set; }
        public decimal Total { get; set; }
        public decimal Cargo { get; set; }
        public decimal Abono { get; set; }
        public decimal Saldo { get; set; }
        public long? Cajaid { get; set; }
        public long? Almacenid { get; set; }
        public long? Origenfiscalid { get; set; }
        public BoolCN Esapartado { get; set; }
        public long? Doctoparentid { get; set; }
        public long? Clienteid { get; set; }
        public long? Tipodoctoid { get; set; }
        public long? Proveedorid { get; set; }
        public long? Sucursal_id { get; set; }
        public string? Referencia { get; set; }
        public string? Referencias { get; set; }

        public DateTimeOffset? Fechavence { get; set; }
    }

    public class Tmp_docto_basico
    {
        public long EmpresaId { get; }
        public long SucursalId { get; }
        public long Id { get; }
        public BoolCS Activo { get; }
        public long? Estatusdoctoid { get; }
        public long? Usuarioid { get; }
        public DateTimeOffset? Fecha { get; }
        public string? Serie { get; }
        public int? Folio { get; }
        public decimal Importe { get; }
        public decimal Descuento { get; }
        public decimal Subtotal { get; }
        public decimal Iva { get; }
        public decimal Ieps { get; }
        public decimal Total { get; }
        public long? Cajaid { get; }
        public long? Proveedorid { get; }
        public string? ProveedorClave { get; }
        public string? ProveedorNombre { get; }
        public long? Clienteid { get; }
        public string? ClienteClave { get; }
        public string? ClienteNombre { get; }
        public long? Tipodoctoid { get; }
        public string? TipodoctoClave { get; }
        public string? TipodoctoNombre { get; }
        public string? Referencia { get; }
        public long? Origenfiscalid { get; }
        public string? OrigenfiscalClave { get; }
        public string? OrigenfiscalNombre { get; }
        public string? Docto_compra_Factura { get; }
        public DateTimeOffset? Docto_compra_Fechafactura { get; }
        public DateTimeOffset? Docto_compra_Fechavence { get; }
        public string? Docto_compra_Folio { get; }
        public long? Almacenid { get; }
        public string? Docto_fact_elect_Timbradouuid { get; }

        public long? Docto_traslado_Sucursaltid { get; }
        public string? Docto_traslado_SucursaltClave { get; }
        public string? Docto_traslado_SucursaltNombre { get; }


        public Tmp_docto_basico(long empresaId, long sucursalId, long id, BoolCS activo, long? estatusdoctoid, long? usuarioid, DateTimeOffset? fecha, string? serie, int? folio, decimal importe, decimal descuento, decimal subtotal, decimal iva, decimal ieps, decimal total, long? cajaid, long? proveedorid, string? proveedorClave, string? proveedorNombre, long? clienteid, string? clienteClave, string? clienteNombre, long? tipodoctoid, string? tipodoctoClave, string? tipodoctoNombre, string? referencia, long? origenfiscalid, string? origenfiscalClave, string? origenfiscalNombre, string? docto_compra_Factura, DateTimeOffset? docto_compra_Fechafactura, DateTimeOffset? docto_compra_Fechavence, string? docto_compra_Folio, long? almacenid, string? docto_fact_elect_Timbradouuid,
                                long? sucursaltid, string? sucursaltClave, string? sucursaltNombre)
        {
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            Id = id;
            Activo = activo;
            Estatusdoctoid = estatusdoctoid;
            Usuarioid = usuarioid;
            Fecha = fecha;
            Serie = serie;
            Folio = folio;
            Importe = importe;
            Descuento = descuento;
            Subtotal = subtotal;
            Iva = iva;
            Ieps = ieps;
            Total = total;
            Cajaid = cajaid;
            Proveedorid = proveedorid;
            ProveedorClave = proveedorClave;
            ProveedorNombre = proveedorNombre;
            Clienteid = clienteid;
            ClienteClave = clienteClave;
            ClienteNombre = clienteNombre;
            Tipodoctoid = tipodoctoid;
            TipodoctoClave = tipodoctoClave;
            TipodoctoNombre = tipodoctoNombre;
            Referencia = referencia;
            Origenfiscalid = origenfiscalid;
            OrigenfiscalClave = origenfiscalClave;
            OrigenfiscalNombre = origenfiscalNombre;
            Docto_compra_Factura = docto_compra_Factura;
            Docto_compra_Fechafactura = docto_compra_Fechafactura;
            Docto_compra_Fechavence = docto_compra_Fechavence;
            Docto_compra_Folio = docto_compra_Folio;
            Almacenid = almacenid;
            Docto_fact_elect_Timbradouuid = docto_fact_elect_Timbradouuid;
            Docto_traslado_Sucursaltid = sucursaltid;
            Docto_traslado_SucursaltClave = sucursaltClave;
            Docto_traslado_SucursaltNombre = sucursaltNombre;
    }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_docto_basico other &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   Id == other.Id &&
                   Activo == other.Activo &&
                   Estatusdoctoid == other.Estatusdoctoid &&
                   Usuarioid == other.Usuarioid &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha, other.Fecha) &&
                   Serie == other.Serie &&
                   Folio == other.Folio &&
                   Importe == other.Importe &&
                   Descuento == other.Descuento &&
                   Subtotal == other.Subtotal &&
                   Iva == other.Iva &&
                   Ieps == other.Ieps &&
                   Total == other.Total &&
                   Cajaid == other.Cajaid &&
                   Proveedorid == other.Proveedorid &&
                   ProveedorClave == other.ProveedorClave &&
                   ProveedorNombre == other.ProveedorNombre &&
                   Clienteid == other.Clienteid &&
                   ClienteClave == other.ClienteClave &&
                   ClienteNombre == other.ClienteNombre &&
                   Tipodoctoid == other.Tipodoctoid &&
                   TipodoctoClave == other.TipodoctoClave &&
                   TipodoctoNombre == other.TipodoctoNombre &&
                   Referencia == other.Referencia &&
                   Origenfiscalid == other.Origenfiscalid &&
                   OrigenfiscalClave == other.OrigenfiscalClave &&
                   OrigenfiscalNombre == other.OrigenfiscalNombre &&
                   Docto_compra_Factura == other.Docto_compra_Factura &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Docto_compra_Fechafactura, other.Docto_compra_Fechafactura) &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Docto_compra_Fechavence, other.Docto_compra_Fechavence) &&
                   Docto_compra_Folio == other.Docto_compra_Folio &&
                   Almacenid == other.Almacenid &&
                   Docto_fact_elect_Timbradouuid == other.Docto_fact_elect_Timbradouuid;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(EmpresaId);
            hash.Add(SucursalId);
            hash.Add(Id);
            hash.Add(Activo);
            hash.Add(Estatusdoctoid);
            hash.Add(Usuarioid);
            hash.Add(Fecha);
            hash.Add(Serie);
            hash.Add(Folio);
            hash.Add(Importe);
            hash.Add(Descuento);
            hash.Add(Subtotal);
            hash.Add(Iva);
            hash.Add(Ieps);
            hash.Add(Total);
            hash.Add(Cajaid);
            hash.Add(Proveedorid);
            hash.Add(ProveedorClave);
            hash.Add(ProveedorNombre);
            hash.Add(Clienteid);
            hash.Add(ClienteClave);
            hash.Add(ClienteNombre);
            hash.Add(Tipodoctoid);
            hash.Add(TipodoctoClave);
            hash.Add(TipodoctoNombre);
            hash.Add(Referencia);
            hash.Add(Origenfiscalid);
            hash.Add(OrigenfiscalClave);
            hash.Add(OrigenfiscalNombre);
            hash.Add(Docto_compra_Factura);
            hash.Add(Docto_compra_Fechafactura);
            hash.Add(Docto_compra_Fechavence);
            hash.Add(Docto_compra_Folio);
            hash.Add(Almacenid);
            hash.Add(Docto_fact_elect_Timbradouuid);
            return hash.ToHashCode();
        }
    }
}
