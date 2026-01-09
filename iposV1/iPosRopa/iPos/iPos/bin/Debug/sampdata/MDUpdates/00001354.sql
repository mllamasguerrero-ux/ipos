CREATE OR ALTER VIEW MOVS(
    ID,
    DOCTOID,
    PARTIDA,
    ESTATUSMOVTOID,
    PRODUCTOID,
    LOTE,
    FECHAVENCE,
    CANTIDAD,
    PRECIOLISTA,
    DESCUENTO,
    PRECIO,
    IMPORTE,
    SUBTOTAL,
    IVA,
    TOTAL,
    IEPS,
    IMPUESTO)
AS
select
 id, doctoid, partida, estatusmovtoid, productoid, lote, fechavence,
 cantidad, preciolista, descuento, precio, importe, subtotal, iva, total,ieps, impuesto
from movto
order by
 doctoid desc, id desc
;