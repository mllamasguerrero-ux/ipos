CREATE OR ALTER VIEW TICKET_FOOTER_TRASLADO(
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
    MONEDERO)
AS
SELECT
       DOCTO.ID DOCTOID,

       (CASE WHEN docto.subtipodoctoid = 6 and  p.preciorealtraslados = 'N' THEN
                        sum(COALESCE(MOVTO.costo,0) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 ) * COALESCE(MOVTO.CANTIDAD,0))
                    ELSE
                        min(DOCTO.subtotal)
                    END
        )subtotal,

       (CASE WHEN docto.subtipodoctoid = 6 and  p.preciorealtraslados = 'N' THEN
                        sum(COALESCE(MOVTO.costo,0) * ((coalesce(MOVTO.tasaiva,0)) / 100 ) * COALESCE(MOVTO.CANTIDAD,0))
                    ELSE
                        min(DOCTO.iva)
                    END
        )iva,
       (CASE WHEN docto.subtipodoctoid = 6 and  p.preciorealtraslados = 'N' THEN
                        sum(COALESCE(MOVTO.costo,0) * ((100 + coalesce(MOVTO.tasaiva,0)) / 100 ) * COALESCE(MOVTO.CANTIDAD,0))
                    ELSE
                        min(DOCTO.total)
                    END
        ) total,
       '    ' total_con_letra ,
       (CASE WHEN docto.subtipodoctoid = 6 and  p.preciorealtraslados = 'N' THEN
                       0
                    ELSE
                        min(DOCTO.descuento)
                    END
        ) descuento ,
       0.00,
       caja.nombre,
       turno.nombre,
       0.00 ,
       0.00 ,
       0.00 ,
       0.00 ,
       0.00 ,
       0.00,
       0.00 ,
       0.00  ,
       0.00   ,
       0.00,
       CURRENT_DATE ,
       docto.monedero

       from DOCTO
       left join caja on docto.cajaid = caja.id
        left join turno on docto.turnoid = turno.id  
        left join monedero on monedero.id = docto.monedero
        left join movto on movto.doctoid = docto.id 
        left join (select first 1 * FROM parametro) p on 1 = 1

        group by  DOCTO.ID ,caja.nombre , turno.nombre, p.preciorealtraslados, docto.subtipodoctoid , docto.monedero
;