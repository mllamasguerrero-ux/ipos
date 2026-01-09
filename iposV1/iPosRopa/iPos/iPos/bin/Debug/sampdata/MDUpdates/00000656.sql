CREATE OR ALTER VIEW TICKET_PROMOCIONESAPLICADAS(
    DOCTOID,
    MOVTOID,
    DESCRIPCION1,
    DESCRIPCION2,
    PROMOCIONDESGLOSE)
AS
SELECT
        MOVTO.doctoid,
        MOVTO.ID MOVTOID,

        PRODUCTO.descripcion1,
        PRODUCTO.descripcion2,
        MOVTO.promociondesglose
        FROM MOVTO left join docto on docto.id = movto.doctoid
        left JOIN PRODUCTO ON MOVTO.productoid = PRODUCTO.ID
        left join linea on linea.id = producto.lineaid
        WHERE MOVTO.promocion = 'S' AND
        COALESCE(MOVTO.promociondesglose,'') <> '' and coalesce(movto.monederoabono,0) = 0
        order by movto.partida
;
