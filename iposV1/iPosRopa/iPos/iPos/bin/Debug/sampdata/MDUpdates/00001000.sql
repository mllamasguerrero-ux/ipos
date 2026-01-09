CREATE OR ALTER VIEW TICKET_DETAIL_TRASLADOS(
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
    PRECIOCONIVA)
AS
SELECT
        MOVTO.doctoid,

        (CASE
         WHEN (docto.tipodoctoid in  (11,41)) THEN MOVTO.cantidadsurtida
         ELSE MOVTO.cantidad
        END ) cantidad,

        PRODUCTO.descripcion1,
        PRODUCTO.descripcion2,
        (CASE WHEN docto.subtipodoctoid = 6 and  p.preciorealtraslados = 'N' THEN
                        COALESCE(MOVTO.preciovisibletraslado,0)
                    ELSE
                        COALESCE(MOVTO.costo,0)
                    END
        ) PRECIO,

        /*MOVTO.descuento*/
        (CASE WHEN docto.subtipodoctoid = 6 and  p.preciorealtraslados = 'N' THEN
                          0
                    ELSE
                        COALESCE(MOVTO.DESCUENTO,0)
                    END
        ),

        (CASE WHEN docto.subtipodoctoid = 6 and  p.preciorealtraslados = 'N' THEN
                        COALESCE(MOVTO.preciovisibletraslado,0) * COALESCE(MOVTO.CANTIDAD,0)
                    ELSE
                        COALESCE(MOVTO.costo,0) * COALESCE(MOVTO.CANTIDAD,0)
                    END
        ) subtotal,

        PRODUCTO.tasaiva IVA,
        (CASE WHEN docto.subtipodoctoid = 6 and  p.preciorealtraslados = 'N' THEN
                        COALESCE(MOVTO.preciovisibletraslado,0) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 ) *  COALESCE(MOVTO.CANTIDAD,0)
                    ELSE
                        COALESCE(MOVTO.costo,0) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 ) * COALESCE(MOVTO.CANTIDAD,0)
                    END
        ) total,
        MOVTO.lote,
        MOVTO.fechavence ,
        movto.cantidadfaltante ,
        MOVTO.cantidadsurtida  ,
        MOVTO.cantidad ,
        /*movto.IMPORTEDESCUENTO*/ 
        (CASE WHEN docto.subtipodoctoid = 6 and  p.preciorealtraslados = 'N' THEN
                          0
                    ELSE
                        COALESCE(MOVTO.IMPORTEDESCUENTO,0)
                    END
        ),
        /*MOVTO.IVA*/ 
        (CASE WHEN docto.subtipodoctoid = 6 and  p.preciorealtraslados = 'N' THEN
                             COALESCE(MOVTO.preciovisibletraslado,0) * (( coalesce(MOVTO.tasaiva,0)) / 100 )  * COALESCE(MOVTO.CANTIDAD,0)
                    ELSE
                        MOVTO.IVA
                    END
        ) IMPORTEIVA ,
        coalesce(MOVTO.DESCUENTOVALE,0) ,
        linea.tiporecarga ,


        (CASE WHEN docto.subtipodoctoid = 6 and  p.preciorealtraslados = 'N' THEN
                        COALESCE(MOVTO.preciovisibletraslado,0) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 )
                    ELSE
                        COALESCE(MOVTO.costo,0) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 )
                    END
        ) PRECIOCONIVA



        FROM MOVTO left join docto on docto.id = movto.doctoid
        left JOIN PRODUCTO ON MOVTO.productoid = PRODUCTO.ID
        left join linea on linea.id = producto.lineaid
        left join (select first 1 * FROM parametro) p on 1 = 1
        order by movto.partida
;