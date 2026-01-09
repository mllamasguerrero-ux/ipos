CREATE OR ALTER VIEW TICKET_PROMOCIONESAPLICADAS(
    DOCTOID,
    MOVTOID,
    DESCRIPCION1,
    DESCRIPCION2,
    PROMOCIONDESGLOSE,
    CANTIDAD,
    PRECIO,
    PRECIOSINDESCUENTO,
    TOTAL,
    TOTALSINDESCUENTO)
AS
SELECT
        MOVTO.doctoid,
        MOVTO.ID MOVTOID,

        PRODUCTO.descripcion1,
        PRODUCTO.descripcion2,
        MOVTO.promociondesglose  ,
        MOVTO.CANTIDAD,
        MOVTO.precio,
        MOVTO.preciolista PRECIOSINDESCUENTO,
        MOVTO.TOTAL ,

        ROUND((MOVTO.preciolista * movto.cantidad * ( 1 + (
                CASE WHEN COALESCE(PARAMETRO.desgloseieps,'N') = 'N' THEN 0.00 ELSE coalesce(MOVTO.tasaieps,0)/100 END) ) ) *
         (1 + (coalesce(MOVTO.tasaiva,0)/100)) , 2)   as TOTALSINDESCUENTO

        FROM MOVTO left join docto on docto.id = movto.doctoid
        left JOIN PRODUCTO ON MOVTO.productoid = PRODUCTO.ID
        left join linea on linea.id = producto.lineaid
        LEFT JOIN PARAMETRO ON 1 = 1
        WHERE MOVTO.promocion = 'S' AND
        COALESCE(MOVTO.promociondesglose,'') <> '' and coalesce(movto.monederoabono,0) = 0
        order by movto.partida
;