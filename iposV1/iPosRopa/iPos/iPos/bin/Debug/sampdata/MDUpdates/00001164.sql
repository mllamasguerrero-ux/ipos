CREATE OR ALTER VIEW TICKET_FOOTER(
    DOCTOID,
    SUBTOTAL,
    IVA,
    TOTAL,
    TOTAL_CON_LETRA,
    DESCUENTO_TOTAL,
    CAMBIO,
    CAJA,
    TURNO,
    PAGOEFECTIVO,
    PAGOTARJETA,
    PAGOCREDITO,
    PAGOCHEQUE,
    PAGOVALE,
    ABONO,
    SALDO,
    PAGOMONEDERO,
    ABONOMONEDERO,
    SALDOMONEDERO,
    VIGENCIAMONEDERO,
    MONEDERO,
    PAGOTRANSFERENCIA,
    PAGONOIDENTIFICADO)
AS
SELECT
       DOCTO.ID DOCTOID,
       DOCTO.subtotal,
       DOCTO.iva,
       DOCTO.total,
       '    ' total_con_letra ,
       docto.descuento ,
       coalesce(pagoEfectivo.importecambio,0) + coalesce(pagoCheque.Importecambio,0),
       caja.nombre,
       turno.nombre,
       pagoEfectivo.Importerecibido,
       pagoTarjeta.importe,
       pagoCredito.importe,
       pagoCheque.importe,
       pagoVale.importe,
       docto.abono,
       docto.saldo ,
       pagoMonedero.importe  ,
       DOCTO.ABONOMONEDERO   ,
       MONEDERO.saldo,
       MONEDERO.vigencia ,
       DOCTO.MONEDERO ,
       pagoTransferencia.importe,
       pagoNoIdentificado.importe

       from DOCTO
         left join (select doctoid, coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio, coalesce(sum(importerecibido),0) importerecibido from doctopago where formapagoid = 1 group by doctoid) pagoEfectivo on docto.id = pagoEfectivo.doctoid
         left join (select doctoid,coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio from doctopago where formapagoid = 2 group by doctoid) pagoTarjeta on docto.id = pagoTarjeta.doctoid
         left join (select doctoid, coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio from doctopago where formapagoid = 3 group by doctoid) pagoCheque on docto.id = pagoCheque.doctoid
         left join (select doctoid, coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio from doctopago where formapagoid = 4 group by doctoid) pagoCredito on docto.id = pagoCredito.doctoid  
         left join (select doctoid, coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio from doctopago where formapagoid = 5 group by doctoid) pagoVale on docto.id = pagoVale.doctoid   
         left join (select doctoid, coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio from doctopago where formapagoid = 14 group by doctoid) pagoMonedero on docto.id = pagoMonedero.doctoid     
         left join (select doctoid, coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio from doctopago where formapagoid = 15 group by doctoid) pagoTransferencia on docto.id = pagoTransferencia.doctoid   
         left join (select doctoid, coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio from doctopago where formapagoid = 16 group by doctoid) pagoNoIdentificado on docto.id = pagoNoIdentificado.doctoid
        left join caja on docto.cajaid = caja.id
        left join turno on docto.turnoid = turno.id  
        left join monedero on monedero.id = docto.monedero
;