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
    PAGOVALE,
    ABONO,
    SALDO,
    PAGOMONEDERO,
    ABONOMONEDERO,
    SALDOMONEDERO,
    VIGENCIAMONEDERO,
    MONEDERO,
    PAGOTRANSFERENCIA,
    PAGONOIDENTIFICADO,
    IEPS,
    IMPUESTO)
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
       cast(0 as decimal),
       cast(0 as decimal),
       cast(0 as decimal),
       cast(0 as decimal),
       cast(0 as decimal),
       cast(0 as decimal),
       current_date,
       cast(0 as bigint), 
       cast(0 as decimal),
       cast(0 as decimal),
       sum(movto.ieps),
       sum(movto.impuesto)

       from DOCTO
       inner join movto on movto.doctoid = docto.id
        inner JOIN PRODUCTO ON MOVTO.productoid = PRODUCTO.ID   
        inner join linea on linea.id = producto.lineaid
         and (linea.tiporecarga is not null and (linea.tiporecarga = 'SIMPLE' OR linea.tiporecarga = 'MULTIPLE'))
        left join caja on docto.cajaid = caja.id
        group by docto.id, caja.nombre
;