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
    PAGOVALE)
AS
SELECT
       DOCTO.ID DOCTOID,
       DOCTO.subtotal,
       DOCTO.iva,
       DOCTO.total,
       '    ' total_con_letra ,
       docto.descuento ,
       pagoEfectivo.importecambio,
       caja.nombre,
       turno.nombre,
       pagoEfectivo.importe,
       pagoTarjeta.importe,
       pagoCredito.importe,
       pagoCheque.importe,
       pagoVale.importe

       from DOCTO
         left join (select doctoid, coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio from doctopago where formapagoid = 1 group by doctoid) pagoEfectivo on docto.id = pagoEfectivo.doctoid
         left join (select doctoid,coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio from doctopago where formapagoid = 2 group by doctoid) pagoTarjeta on docto.id = pagoTarjeta.doctoid
         left join (select doctoid, coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio from doctopago where formapagoid = 3 group by doctoid) pagoCheque on docto.id = pagoCheque.doctoid
         left join (select doctoid, coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio from doctopago where formapagoid = 4 group by doctoid) pagoCredito on docto.id = pagoCredito.doctoid  
         left join (select doctoid, coalesce(sum(importe),0) importe, coalesce(sum(importecambio),0) importecambio from doctopago where formapagoid = 5 group by doctoid) pagoVale on docto.id = pagoVale.doctoid
        left join caja on docto.cajaid = caja.id
        left join turno on docto.turnoid = turno.id
;