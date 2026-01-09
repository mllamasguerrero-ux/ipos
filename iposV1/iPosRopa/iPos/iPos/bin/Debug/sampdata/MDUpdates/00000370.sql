CREATE OR ALTER VIEW TICKET_FOOTER_RECARGAS(
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
       sum(movto.subtotal) ,
       sum(movto.iva),
       sum(movto.total),
       '    ' total_con_letra ,
       sum(movto.descuento) ,
       cast(0 as decimal),
       caja.nombre,
       '',
       cast(0 as decimal),
       cast(0 as decimal),
       cast(0 as decimal),
       cast(0 as decimal),
       cast(0 as decimal)

       from DOCTO
       inner join movto on movto.doctoid = docto.id
        inner JOIN PRODUCTO ON MOVTO.productoid = PRODUCTO.ID
        left join caja on docto.cajaid = caja.id
        where producto.clave in ('7401','7402','7418','7419')
        group by docto.id, caja.nombre
;