using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace IposV3.Services
{
    public class PagosFacturaElectronicaService
    {

        private CorteService _corteService;

        private MaestroConsecutivoService _maestroConsecutivoService;
        public PagosFacturaElectronicaService(MaestroConsecutivoService maestroConsecutivoService, CorteService corteService)
        {
            _maestroConsecutivoService = maestroConsecutivoService;
            _corteService = corteService;
        }

        public void GenerarReciboElectronico(long empresaId, long sucursalId, long pagoId, 
                                             long vendedorId, 
                                             ref long? reciboElectronicoId, ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            long? corteid;
            BoolCS? corte_activo;
            DateTimeOffset? fechacorte;
            DateTimeOffset? corte_inicia;
            DateTimeOffset? corte_termina;

            reciboElectronicoId = null;

            try
            {
                _corteService.HayCorteActivo(empresaId, sucursalId, vendedorId,
                                               out corteid, out corte_activo, out fechacorte, out corte_inicia, out corte_termina, localContext);

                if (corteid == null || corteid == 0)
                {
                    throw new Exception("No hay corte activo");
                }


                var parametro = localContext.Parametro.AsNoTracking()
                    .Include(p => p.Sat_metodopago)
                    .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId)
                    .Select(p => new { Sat_metodopago_clave = p.Sat_metodopago != null ? p.Sat_metodopago.Clave : null ,
                                              p.Retencioniva, p.Retencionisr})
                    .FirstOrDefault();

                if (parametro == null)
                    throw new Exception("El parametro no fue encontrado");



                var pago = localContext.Pago.AsNoTracking()
                                       .Include(p => p.Formapagosat)
                                       .Include(p => p.Banco)
                                       .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Id == pagoId)
                                       .Select(p => new
                                       {
                                           Total = p.Importe,
                                           p.Reciboelectronicoid,
                                           p.Aplicado,
                                           Fechahora = (p.Formapagosat != null && p.Formapagosat.Clave == "02" ?
                                                                                p.Fechaaplicado :
                                                                      (p.Formapagosat != null && p.Formapagosat.Clave == "03" ?
                                                                                p.Fecharecepcion :
                                                                                p.Fechahora)
                                                                      ),
                                           Formapagosatclave = p.Formapagosat != null ? p.Formapagosat.Clave : null,
                                           Sat_bancarizado = p.Formapagosat != null ? p.Formapagosat.Sat_bancarizado : null,
                                           p.Referenciabancaria,
                                           p.Cuentapagocredito,
                                           Banconombre = p.Banco != null ? p.Banco.Nombre : null,
                                           Bancorfc = p.Banco != null ? p.Banco.Rfc : null,
                                           p.Cuentabancoempresaid,
                                           p.Clienteid


                                       })
                                       .FirstOrDefault();


                if (pago == null)
                    throw new Exception("El pago no fue encontrado");

                if((pago.Aplicado ?? BoolCN.S) != BoolCN.S && (pago.Formapagosatclave ?? "") == "02")
                    throw new Exception("los pagos de cheque deben estar aplicados");

                if(pago.Total == 0)
                    throw new Exception("El monto del pago debe ser mayor que cero");


                if ((pago.Reciboelectronicoid ?? 0) != 0)
                    throw new Exception("El recibo electronico ya se hizo");



                var sumatoriasDoctos = localContext.Doctopago.AsNoTracking()
                                                   .Include(dp => dp.Docto).ThenInclude(d => d!.Docto_fact_elect)
                                                   .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Pagoid == pagoId)
                                                   .GroupBy(p => p.Pagoid)
                                                   .Select(p => new
                                                   {
                                                       Subtotalorigen = p.Sum(y => y.Docto != null ? y.Docto.Subtotal : 0m),
                                                       Totalorigen = p.Sum(y => y.Docto != null ? y.Docto.Total : 0m),
                                                       Ivaorigen = p.Sum(y => y.Docto != null ? y.Docto.Iva : 0m),
                                                       Iepsorigen = p.Sum(y => y.Docto != null ? y.Docto.Ieps : 0m),
                                                       Impuestoorigen = p.Sum(y => y.Docto != null ? y.Docto.Iva + y.Docto.Ieps : 0m),
                                                       Clienteid = p.Min(y => y.Docto != null ? y.Docto.Clienteid : null),
                                                       Foliosat = p.Min(y => y.Docto != null && y.Docto.Docto_fact_elect != null ? y.Docto.Docto_fact_elect.Foliosat : null),
                                                       Seriesat = p.Min(y => y.Docto != null && y.Docto.Docto_fact_elect != null ? y.Docto.Docto_fact_elect.Seriesat : null),
                                                       Timbradouuid = p.Min(y => y.Docto != null && y.Docto.Docto_fact_elect != null ? y.Docto.Docto_fact_elect.Timbradouuid : null)

                                                   })
                                                   .FirstOrDefault();

                if(sumatoriasDoctos == null)
                    throw new Exception("No se encontraron los documentos pagados");

                if((sumatoriasDoctos.Foliosat ?? 0) == 0)
                    throw new Exception("Los documentos de origen no estan facturados");

                if(sumatoriasDoctos.Totalorigen <= 0m)
                    throw new Exception("El monto de los documentos origen debe ser mayor a cero");



                decimal factor = pago.Total  / sumatoriasDoctos.Totalorigen;
                decimal iva = Math.Round((pago.Total  / sumatoriasDoctos.Totalorigen) * sumatoriasDoctos.Ivaorigen, 2);
                decimal ieps = Math.Round((pago.Total  / sumatoriasDoctos.Totalorigen) * sumatoriasDoctos.Iepsorigen, 2);
                decimal impuesto  =  iva + ieps;
                decimal subtotal = pago.Total - impuesto;



                //CajaiD, Almacenid, Sucursaltid, Almacentid, Doctorefid, fechaini, fechafin, folio, serie
                var docto = new Docto()
                {
                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    Tipodoctoid = DBValues._DOCTO_TIPO_RECIBOELECTRONICO,
                    Estatusdoctoid = DBValues._DOCTO_ESTATUS_BORRADOR,
                    Clienteid = pago.Clienteid,
                    Usuarioid = vendedorId,
                    Corteid = corteid,
                    Fecha = DateTimeOffset.UtcNow,
                    Fechahora = DateTimeOffset.UtcNow,
                    Importe = subtotal,
                    Descuento = 0m,
                    Subtotal = subtotal,
                    Iva = iva,
                    Ieps = ieps,
                    Total = pago.Total,
                    Abono = pago.Total,
                    Saldo = 0m,
                    Referencia = "",
                    Referencias = "RECIBO ELECTRONICO",
                    Docto_fact_elect = new Docto_fact_elect()
                    {
                        EmpresaId = empresaId,
                        SucursalId = sucursalId,
                        Esfacturaelectronica = BoolCN.S
                    }


                };

                localContext.Docto.Add(docto);
                localContext.SaveChanges();


                var pagoGuardado = localContext.Pago.FirstOrDefault(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Id == pagoId);

                if (pagoGuardado == null)
                    throw new Exception("El pago no fue encontrado");

                pagoGuardado.Reciboelectronicoid = docto.Id;
                reciboElectronicoId = docto.Id;

                localContext.SaveChanges();





                var rfcemisorctaord = "";
                var nombancoordext = "";
                var ctaordenante = "";
                var rfcemisorctaben = "";
                var ctabeneficiario = "";

                if((pago.Sat_bancarizado ?? "N").StartsWith("S") &&
                    (pago.Bancorfc ?? "") != "" &&
                    (pago.Cuentabancoempresaid ?? 0)  != 0
                    )
                {
                    if((pago.Cuentapagocredito ?? "") == "")
                        throw new Exception("La cuenta de pago credito no puede estar vacia");

                    var cuentaBanco = localContext.Cuentabanco.AsNoTracking()
                        .FirstOrDefault(c => c.EmpresaId == empresaId && c.SucursalId == sucursalId && c.Id == pago.Cuentabancoempresaid);

                    if (cuentaBanco == null)
                        throw new Exception("La cuenta de banco no existe");


                    rfcemisorctaord = pago.Bancorfc;
                    nombancoordext = pago.Banconombre;
                    ctaordenante = pago.Cuentapagocredito;
                    rfcemisorctaben = cuentaBanco.Rfc;
                    ctabeneficiario = cuentaBanco.Nocuenta;


                }


                var pagoSat = new Pagosat()
                {

                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    Doctosatid = docto.Id,
                    Fechapago = pago.Fechahora,
                    Formadepagop = pago.Formapagosatclave,
                    Monedap = "MXN",
                    Tipocambiop = 1,
                    Monto = pago.Total,
                    Numoperacion = pago.Referenciabancaria,
                    Rfcemisorctaord = rfcemisorctaord,
                    Nombancoordext = nombancoordext,
                    Ctaordenante = ctaordenante,
                    Rfcemisorctaben = rfcemisorctaben,
                    Ctabeneficiario = ctabeneficiario,
                    Tipocadpago = "",
                    Certpago = "",
                    Cadpago = "",
                    Sellopago = "", 
                    Pagoid = pagoId
                };
                localContext.Pagosat.Add(pagoSat);
                localContext.SaveChanges();



                pagoGuardado.Pagosatid = pagoSat.Id;
                localContext.Update(pagoGuardado);


                docto.Docto_fact_elect_pagos = new Docto_fact_elect_pagos()
                {

                    EmpresaId = empresaId,
                    SucursalId = sucursalId,
                    Doctoid = docto.Id,
                    Pagosat = pagoSat.Id
                };
                localContext.Update(docto);

                localContext.SaveChanges();


                var doctoPagos = localContext.Doctopago.AsNoTracking()
                                                   .Include(dp => dp.Docto).ThenInclude(d => d!.Docto_fact_elect)
                                                   .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Pagoid == pagoId)
                                                   .ToList();

                if (doctoPagos == null)
                    throw new Exception("No se encontraron los documentos pagados");


                List<long> formasPagoCredito = new List<long>() { 6,7 };
                List<long> formasPagoDirectas = new List<long>() { 1, 2, 3, 5, 6, 14, 15, 16, 17, 18, 19, 20, 21 };
                List<long> formasPagoIndirectasEntrada = new List<long>() { 7, 19 };
                List<long> formasPagoIndirectasSalida = new List<long>() { 4, 6, 7, 18, 19 };

                decimal impSaldoAnt = 0m, impSaldoInsoluto = 0m;
                int cuentaParcialidades = 0;

                foreach (var doctoPago in doctoPagos)
                {

                    impSaldoAnt = 0m;
                    impSaldoInsoluto = 0m;
                    cuentaParcialidades = 0;

                    var acumuladoDoctoPago = localContext.Doctopago.AsNoTracking()
                                                         .Include(dp => dp.Pago)
                                                         .Include(dp => dp.Docto).ThenInclude(d => d!.Docto_fact_elect)
                                                         .Where(dp => dp.EmpresaId == empresaId && dp.SucursalId == sucursalId &&
                                                                     dp.Doctoid == doctoPago.Doctoid && dp.Pago != null && dp.Pagoid != pagoId &&
                                                                     ((dp.Pago.Reciboelectronicoid != null && dp.Pago.Reciboelectronicoid != 0 && dp.Pago.Reciboelectronicoid != 0) ||
                                                                       formasPagoCredito.Contains(dp.Formapagoid != null ? dp.Formapagoid!.Value : 0))
                                                               )
                                                         .GroupBy(dp => dp.Doctoid)
                                                        .Select(dp => new { CuentaParcialidades = dp.Count(),
                                                            AbonosSatDetalle = dp.Sum(y => y.Importe *
                                                                                          (
                                                                                           (y.Tipopagoid == 1 && formasPagoDirectas.Contains(y.Formapagoid != null ? y.Formapagoid!.Value : 0)) ? 1m :
                                                                                           (
                                                                                            (
                                                                                             (y.Tipopagoid == 1 && formasPagoIndirectasEntrada.Contains(y.Formapagoid != null ? y.Formapagoid!.Value : 0)) ||
                                                                                             (y.Tipopagoid == 2 && formasPagoIndirectasSalida.Contains(y.Formapagoid != null ? y.Formapagoid!.Value : 0)) 
                                                                                            ) ? -1m : 0m
                                                                                           )
                                                                                          )
                                                                                      )

                                                        }).FirstOrDefault();

                    impSaldoAnt = (doctoPago.Docto?.Total ?? 0m) - (acumuladoDoctoPago?.AbonosSatDetalle ?? 0m);
                    impSaldoInsoluto = impSaldoAnt - doctoPago.Importe ;

                    cuentaParcialidades = acumuladoDoctoPago?.CuentaParcialidades ?? 0;


                    var pagoDoctoSat = new Pagodoctosat()
                    {

                        EmpresaId = empresaId,
                        SucursalId = sucursalId,
                        Doctopagoid = doctoPago.Id,
                        Pagosatid = pagoSat.Id,
                        Iddocumento = doctoPago.Docto?.Docto_fact_elect?.Timbradouuid,
                        Serie = doctoPago.Docto?.Docto_fact_elect?.Seriesat,
                        Folio = doctoPago.Docto?.Docto_fact_elect?.Foliosat?.ToString(),
                        Monedadr = "MXN",
                        Tipocambiodr = "1",
                        Metododepagodr = parametro.Sat_metodopago_clave ?? "PPD",
                        Numparcialidad = cuentaParcialidades + 1,
                        Impsaldoant = impSaldoAnt,
                        Imppagado = doctoPago.Importe,
                        Impsaldoinsoluto = impSaldoInsoluto
                    };

                    localContext.Pagodoctosat.Add(pagoDoctoSat);
                    localContext.SaveChanges();

                    var doctoPagoGuardado = localContext.Doctopago
                                                        .FirstOrDefault(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Id == doctoPago.Id);

                    doctoPagoGuardado!.Pagodoctosatid = pagoDoctoSat.Id;



                    localContext.Doctopago.Update(doctoPagoGuardado!);
                    localContext.SaveChanges();


                }


                var pagoDoctoSatsGuardados = localContext.Pagodoctosat
                                                .Include(pds => pds.Doctopago).ThenInclude(dp => dp!.Docto).ThenInclude(d => d!.Docto_impuestos)
                                                .Include(pds => pds.Doctopago).ThenInclude(dp => dp!.Docto).ThenInclude(d => d!.Docto_fact_elect)
                                                .Where(pds => pds.EmpresaId == empresaId && pds.SucursalId == sucursalId && pds.Pagosatid == pagoSat.Id)
                                                .ToList();
                foreach(var pagoSatGuardado in pagoDoctoSatsGuardados)
                {

                    var montoAProrratearIva = Math.Round( ((pagoSatGuardado.Imppagado / pagoSatGuardado.Doctopago?.Docto?.Total ?? 0) == 0m ? 0m :
                                                            pagoSatGuardado.Doctopago?.Docto?.Iva *
                                                                pagoSatGuardado.Imppagado / pagoSatGuardado.Doctopago?.Docto?.Total) ?? 0m , 2);

                    if (montoAProrratearIva > 0)
                    {

                        var listaAProrratearIva = pagoSatGuardado.Doctopago?.Docto?.Docto_impuestos?
                                                                 .Where(i => i.Tipoimpuestoid == 2)
                                                                 .Select(x => new Prorrateo()
                                                                 {
                                                                     Id = x.Id,
                                                                     Cantidad = x.Monto,
                                                                     CantidadProrrateada = 0
                                                                 }).ToList();

                        MathIpos.Prorratear(montoAProrratearIva, 2, ref listaAProrratearIva!);

                        foreach (var prorrateoIva in listaAProrratearIva)
                        {
                            var doctoImpuesto = pagoSatGuardado.Doctopago?.Docto?.Docto_impuestos?.FirstOrDefault(i => i.Id == prorrateoIva.Id);
                            var pagoSatImp_tasa = doctoImpuesto?.Tasaimpuesto ?? 0m;
                            var pagoSatImp_importe = prorrateoIva.CantidadProrrateada;
                            var pagoSatImp_tipoImpuesto = "CONCEPTO_IVA";
                            var pagoSatImp_pagodoctosatid = pagoSatGuardado.Id;
                            var pagoSatImp_tipofactor = "Tasa";
                            var pagoSatImp_tasacuota = doctoImpuesto?.Tasaimpuesto ?? 0m;
                            var pagoSatImp_impuesto_text = "002";
                            var pagoSatImp_baseImpuesto = pagoSatImp_tasa > 0m ? Math.Round(((pagoSatImp_importe * 100m) / pagoSatImp_tasa), 2) : 0m;

                            //insertar el registro en pagosatimp
                            var pagoDoctoSatImp = new Pagodoctosat_imp()
                            {

                                EmpresaId = empresaId,
                                SucursalId = sucursalId,
                                Pagodoctosatid = pagoSatImp_pagodoctosatid,
                                Baseimp = pagoSatImp_baseImpuesto,
                                Tipofactor = pagoSatImp_tipofactor,
                                Tasacuota = pagoSatImp_tasacuota.ToString("N2"),
                                Tasa = pagoSatImp_tasa,
                                Impuesto = pagoSatImp_impuesto_text,
                                Importe = pagoSatImp_importe,
                                Tipoimpuesto = pagoSatImp_tipoImpuesto,
                                Iddocumento = pagoSatGuardado.Iddocumento
                            };
                            localContext.Pagodoctosat_Imp.Add(pagoDoctoSatImp);
                        }
                    }


                    var montoAProrratearIeps = Math.Round( ((pagoSatGuardado.Imppagado / pagoSatGuardado.Doctopago?.Docto?.Total ?? 0) == 0m ? 0m :
                                                            pagoSatGuardado.Doctopago?.Docto?.Ieps *
                                                                pagoSatGuardado.Imppagado / pagoSatGuardado.Doctopago?.Docto?.Total) ?? 0m, 2);

                    if(montoAProrratearIeps > 0)
                    {

                        var listaAProrratearIeps = pagoSatGuardado.Doctopago?.Docto?.Docto_impuestos?
                                                                 .Where(i => i.Tipoimpuestoid == 3)
                                                                 .Select(x => new Prorrateo()
                                                                 {
                                                                     Id = x.Id,
                                                                     Cantidad = x.Monto,
                                                                     CantidadProrrateada = 0
                                                                 }).ToList();


                        MathIpos.Prorratear(montoAProrratearIeps, 2, ref listaAProrratearIeps!);

                        foreach (var prorrateoIeps in listaAProrratearIeps)
                        {
                            var doctoImpuesto = pagoSatGuardado.Doctopago?.Docto?.Docto_impuestos?.FirstOrDefault(i => i.Id == prorrateoIeps.Id);
                            var pagoSatImp_tasa = doctoImpuesto?.Tasaimpuesto ?? 0m;
                            var pagoSatImp_importe = prorrateoIeps.CantidadProrrateada;
                            var pagoSatImp_tipoImpuesto = "CONCEPTO_IEPS";
                            var pagoSatImp_pagodoctosatid = pagoSatGuardado.Id;
                            var pagoSatImp_tipofactor = "Tasa";
                            var pagoSatImp_tasacuota = doctoImpuesto?.Tasaimpuesto ?? 0m;
                            var pagoSatImp_impuesto_text = "003";
                            var pagoSatImp_baseImpuesto = pagoSatImp_tasa > 0m ? Math.Round(((pagoSatImp_importe * 100m) / pagoSatImp_tasa), 2) : 0m;

                            //insertar el registro en pagosatimp
                            var pagoDoctoSatImp = new Pagodoctosat_imp()
                            {

                                EmpresaId = empresaId,
                                SucursalId = sucursalId,
                                Pagodoctosatid = pagoSatImp_pagodoctosatid,
                                Baseimp = pagoSatImp_baseImpuesto,
                                Tipofactor = pagoSatImp_tipofactor,
                                Tasacuota = pagoSatImp_tasacuota.ToString("N2"),
                                Tasa = pagoSatImp_tasa,
                                Impuesto = pagoSatImp_impuesto_text,
                                Importe = pagoSatImp_importe,
                                Tipoimpuesto = pagoSatImp_tipoImpuesto,
                                Iddocumento = pagoSatGuardado.Iddocumento
                            };
                            localContext.Pagodoctosat_Imp.Add(pagoDoctoSatImp);
                        }
                    }


                    var ivaRetenido = pagoSatGuardado.Doctopago?.Docto?.Docto_fact_elect?.Ivaretenido ?? 0;


                    var montoAProrratearIvaRetenido = Math.Round( ((pagoSatGuardado.Imppagado / pagoSatGuardado.Doctopago?.Docto?.Total ?? 0) == 0m ? 0m :
                                                            pagoSatGuardado.Doctopago?.Docto?.Docto_fact_elect?.Ivaretenido *
                                                                pagoSatGuardado.Imppagado / pagoSatGuardado.Doctopago?.Docto?.Total) ?? 0m, 2);

                    if (montoAProrratearIvaRetenido > 0)
                    {
                        var listaAProrratearIvaRetenido = new List<Prorrateo>() {
                                                        new Prorrateo()
                                                             {
                                                                 Id = 0,
                                                                 Cantidad = ivaRetenido,
                                                                 CantidadProrrateada = 0
                                                             }
                                        };


                        MathIpos.Prorratear(montoAProrratearIvaRetenido, 2, ref listaAProrratearIvaRetenido!);



                        foreach (var prorrateoIvaRetenido in listaAProrratearIvaRetenido)
                        {
                            var pagoSatImp_tasa = parametro.Retencioniva;
                            var pagoSatImp_importe = prorrateoIvaRetenido.CantidadProrrateada;
                            var pagoSatImp_tipoImpuesto = "CONCEPTO_IVARETENIDO";
                            var pagoSatImp_pagodoctosatid = pagoSatGuardado.Id;
                            var pagoSatImp_tipofactor = "Tasa";
                            var pagoSatImp_tasacuota = parametro.Retencioniva;
                            var pagoSatImp_impuesto_text = "002";
                            var pagoSatImp_baseImpuesto = pagoSatImp_tasa > 0m ? Math.Round(((pagoSatImp_importe * 100m) / pagoSatImp_tasa), 2) : 0m;

                            //insertar el registro en pagosatimp
                            var pagoDoctoSatImp = new Pagodoctosat_imp()
                            {

                                EmpresaId = empresaId,
                                SucursalId = sucursalId,
                                Pagodoctosatid = pagoSatImp_pagodoctosatid,
                                Baseimp = pagoSatImp_baseImpuesto,
                                Tipofactor = pagoSatImp_tipofactor,
                                Tasacuota = pagoSatImp_tasacuota.ToString("N2"),
                                Tasa = pagoSatImp_tasa,
                                Impuesto = pagoSatImp_impuesto_text,
                                Importe = pagoSatImp_importe,
                                Tipoimpuesto = pagoSatImp_tipoImpuesto,
                                Iddocumento = pagoSatGuardado.Iddocumento
                            };
                            localContext.Pagodoctosat_Imp.Add(pagoDoctoSatImp);
                        }
                    }




                    var isrRetenido = pagoSatGuardado.Doctopago?.Docto?.Docto_fact_elect?.Isrretenido ?? 0;

                    var montoAProrratearIsrRetenido = Math.Round( ((pagoSatGuardado.Imppagado / pagoSatGuardado.Doctopago?.Docto?.Total ?? 0) == 0m ? 0m :
                                                            pagoSatGuardado.Doctopago?.Docto?.Docto_fact_elect?.Isrretenido *
                                                                pagoSatGuardado.Imppagado / pagoSatGuardado.Doctopago?.Docto?.Total) ?? 0m, 2);
                    if (montoAProrratearIsrRetenido > 0)
                    {
                        var listaAProrratearIsrRetenido = new List<Prorrateo>() {
                                                        new Prorrateo()
                                                             {
                                                                 Id = 0,
                                                                 Cantidad = isrRetenido,
                                                                 CantidadProrrateada = 0
                                                             }
                                        };

                        MathIpos.Prorratear(montoAProrratearIsrRetenido, 2, ref listaAProrratearIsrRetenido!);



                        foreach (var prorrateoIsrRetenido in listaAProrratearIsrRetenido)
                        {
                            var pagoSatImp_tasa = parametro.Retencionisr;
                            var pagoSatImp_importe = prorrateoIsrRetenido.CantidadProrrateada;
                            var pagoSatImp_tipoImpuesto = "CONCEPTO_ISRRETENIDO";
                            var pagoSatImp_pagodoctosatid = pagoSatGuardado.Id;
                            var pagoSatImp_tipofactor = "Tasa";
                            var pagoSatImp_tasacuota = parametro.Retencionisr;
                            var pagoSatImp_impuesto_text = "001";
                            var pagoSatImp_baseImpuesto = pagoSatImp_tasa > 0m ? Math.Round(((pagoSatImp_importe * 100m) / pagoSatImp_tasa), 2) : 0m;

                            //insertar el registro en pagosatimp
                            var pagoDoctoSatImp = new Pagodoctosat_imp()
                            {

                                EmpresaId = empresaId,
                                SucursalId = sucursalId,
                                Pagodoctosatid = pagoSatImp_pagodoctosatid,
                                Baseimp = pagoSatImp_baseImpuesto,
                                Tipofactor = pagoSatImp_tipofactor,
                                Tasacuota = pagoSatImp_tasacuota.ToString("N2"),
                                Tasa = pagoSatImp_tasa,
                                Impuesto = pagoSatImp_impuesto_text,
                                Importe = pagoSatImp_importe,
                                Tipoimpuesto = pagoSatImp_tipoImpuesto,
                                Iddocumento = pagoSatGuardado.Iddocumento
                            };
                            localContext.Pagodoctosat_Imp.Add(pagoDoctoSatImp);
                        }
                    }

                   
                    localContext.SaveChanges();


                    string objImp = "03";
                    var cuentasImpuestos = localContext.Pagodoctosat_Imp.AsNoTracking()
                                                .Where(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId && i.Pagodoctosatid == pagoSatGuardado.Id )
                                                .GroupBy(i => 1)
                                                .Select(i => new
                                                {
                                                    CuentaIvas = i.Sum(s => s.Impuesto == "002" ? 1 : 0),
                                                    CuentaIeps = i.Sum(s => s.Impuesto == "003" ? 1 : 0)
                                                }).FirstOrDefault();

                    if (cuentasImpuestos == null || (cuentasImpuestos.CuentaIvas == 0 && cuentasImpuestos.CuentaIeps == 0))
                        objImp = "01";
                    else
                        objImp = "02";

                    pagoSatGuardado.Objetoimpdr = objImp;
                    localContext.Pagodoctosat.Update(pagoSatGuardado);
                    localContext.SaveChanges();

                }


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }
    }
}
