CREATE OR ALTER VIEW RECIBO_DETAIL(
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
    PRODUCTOTEXTO1,
    PRODUCTOTEXTO2,
    PRODUCTOTEXTO3,
    PRODUCTOTEXTO4,
    PRODUCTOTEXTO5,
    PRODUCTOTEXTO6,
    PRODUCTONUMERO1,
    PRODUCTONUMERO2,
    PRODUCTONUMERO3,
    PRODUCTONUMERO4,
    PRODUCTOFECHA1,
    PRODUCTOFECHA2,
    DESCRIPCION3,
    ES_COMODIN,
    PRODUCTOMANEJALOTE)
AS
SELECT
        MOVTO.doctoid,

        (CASE
         WHEN (docto.tipodoctoid in  (/*11,*/41)) THEN MOVTO.cantidadsurtida
         ELSE MOVTO.cantidad
        END ) cantidad,

       
        CASE WHEN PRODUCTO.descripcion_comodin = 'S' AND MOVTO.descripcion1 IS NOT NULL AND MOVTO.descripcion1 <> '' THEN MOVTO.DESCRIPCION1 ELSE  PRODUCTO.DESCRIPCION1 END

        AS DESCRIPCION1,

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

        PRODUCTO.tasaiva TASAIVA,
        CASE WHEN docto.tipodoctoid = 21 then MOVTO.total + coalesce(MOVTO.DESCUENTOVALE,0) else MOVTO.total end total,
        MOVTO.lote,
        MOVTO.fechavence ,
        movto.cantidadfaltante ,
        MOVTO.cantidadsurtida  ,
        MOVTO.cantidad ,
        movto.IMPORTEDESCUENTO,
        MOVTO.IVA IMPORTEIVA ,
        coalesce(MOVTO.DESCUENTOVALE,0) descuentovale,
        linea.tiporecarga ,


        (CASE   WHEN (docto.tipodoctoid in  (11,41)) THEN

                        COALESCE(MOVTO.costo,0) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 )
                ELSE
                    COALESCE(MOVTO.precio,0) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 )
                END ) PRECIOCONIVA  ,

                c.texto1,
                c.texto2,
                c.texto3,
                c.texto4,
                c.texto5,
                c.texto6,
                c.numero1,
                c.numero2,
                c.numero3,
                c.numero4,
                c.fecha1, 
                c.fecha2,
           
        CASE WHEN PRODUCTO.descripcion_comodin = 'S' AND MOVTO.descripcion1 IS NOT NULL AND MOVTO.descripcion1 <> '' THEN MOVTO.DESCRIPCION3 ELSE  PRODUCTO.DESCRIPCION3 END AS DESCRIPCION3 ,
        PRODUCTO.descripcion_comodin ,
        PRODUCTO.manejalote



        FROM MOVTO left join docto on docto.id = movto.doctoid
        left JOIN PRODUCTO ON MOVTO.productoid = PRODUCTO.ID
        left join linea on linea.id = producto.lineaid
        left join PRODUCTOCARACTERISTICAS  c on c.productoid = producto.id
        order by movto.partida
;

