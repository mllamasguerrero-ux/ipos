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
    DESCUENTOVALE,
    TIPORECARGA,
    PRECIOCONIVA,
    DESCRIPCION3,
    ES_COMODIN,
    TASAIEPS,
    IMPORTEIEPS,
    TASAIMPUESTO,
    IMPUESTO)
AS
SELECT
        MOVTO.doctoid,

        (CASE
         WHEN (docto.tipodoctoid in  (11,41)) THEN MOVTO.cantidadsurtida
         ELSE MOVTO.cantidad
        END ) cantidad,

        CASE WHEN PRODUCTO.descripcion_comodin = 'S' AND MOVTO.descripcion1 IS NOT NULL AND MOVTO.descripcion1 <> '' THEN MOVTO.DESCRIPCION1 ELSE  PRODUCTO.DESCRIPCION1 END AS DESCRIPCION1,
        CASE WHEN PRODUCTO.descripcion_comodin = 'S' AND MOVTO.descripcion1 IS NOT NULL AND MOVTO.descripcion1 <> '' THEN MOVTO.DESCRIPCION2 ELSE  PRODUCTO.DESCRIPCION2 END AS DESCRIPCION2,

        (CASE
         WHEN (docto.tipodoctoid in  (11,41)) THEN MOVTO.costo
         ELSE MOVTO.precio
        END ) PRECIO,

        MOVTO.descuento,

        (CASE
         WHEN (docto.tipodoctoid in  (/*11,*/41)) THEN MOVTO.costoimporte
         ELSE MOVTO.subtotal
         END ) subtotal,

        MOVTO.tasaiva IVA,
        MOVTO.total,
        MOVTO.lote,
        MOVTO.fechavence ,
        movto.cantidadfaltante ,
        MOVTO.cantidadsurtida  ,
        MOVTO.cantidad ,
        movto.IMPORTEDESCUENTO,
        MOVTO.IVA IMPORTEIVA ,
        coalesce(MOVTO.DESCUENTOVALE,0) ,
        linea.tiporecarga ,


        (CASE   WHEN (docto.tipodoctoid in  (11,41)) THEN

                        COALESCE(MOVTO.costo,0) * ((100 + coalesce(MOVTO.tasaieps,0)) / 100 ) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 )
                ELSE
                    COALESCE(MOVTO.precio,0) * ((100 + coalesce(MOVTO.tasaieps,0)) / 100 ) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 )
                END ) PRECIOCONIVA ,

         
        CASE WHEN PRODUCTO.descripcion_comodin = 'S' AND MOVTO.descripcion1 IS NOT NULL AND MOVTO.descripcion1 <> '' THEN MOVTO.DESCRIPCION3 ELSE  PRODUCTO.DESCRIPCION3 END AS DESCRIPCION3 ,
        PRODUCTO.descripcion_comodin ,
        
        MOVTO.tasaieps,
        MOVTO.IEPS,
        movto.tasaimpuesto,
        movto.impuesto AS IMPUESTO


        FROM MOVTO left join docto on docto.id = movto.doctoid
        left JOIN PRODUCTO ON MOVTO.productoid = PRODUCTO.ID
        left join linea on linea.id = producto.lineaid
        order by movto.orden, movto.partida
;