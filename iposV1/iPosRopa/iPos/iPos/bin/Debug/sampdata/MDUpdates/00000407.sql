CREATE OR ALTER VIEW TICKET_DETAIL(
    DOCTOID,
    CANTIDAD,
    DESCRIPCION1,
    DESCRIPCION2,
    PRECIO,
    DESCUENTO,
    SUBTOTAL,
    IVA,
    TOTAL,
    LOTE,
    FECHAVENCE,
    FALTANTE,
    CANTIDADSURTIDA,
    CANTIDADNOMINAL,
    IMPORTEDESCUENTO,
    IMPORTEIVA,
    DESCUENTOVALE)
AS
SELECT
        MOVTO.doctoid,

        (CASE
         WHEN (docto.tipodoctoid in  (11,41)) THEN MOVTO.cantidadsurtida
         ELSE MOVTO.cantidad
        END ) cantidad,

        PRODUCTO.descripcion1,
        PRODUCTO.descripcion2,
        (CASE
         WHEN (docto.tipodoctoid in  (11,41)) THEN MOVTO.costo
         ELSE MOVTO.precio
        END ) PRECIO,

        MOVTO.descuento,

        (CASE
         WHEN (docto.tipodoctoid in  (11,41)) THEN MOVTO.costoimporte
         ELSE MOVTO.subtotal
         END ) subtotal,

        PRODUCTO.tasaiva IVA,
        MOVTO.total,
        MOVTO.lote,
        MOVTO.fechavence ,
        movto.cantidadfaltante ,
        MOVTO.cantidadsurtida  ,
        MOVTO.cantidad ,
        movto.IMPORTEDESCUENTO,
        MOVTO.IVA IMPORTEIVA ,
        coalesce(MOVTO.DESCUENTOVALE,0)
        FROM MOVTO left join docto on docto.id = movto.doctoid left JOIN PRODUCTO ON MOVTO.productoid = PRODUCTO.ID
        order by movto.partida
;