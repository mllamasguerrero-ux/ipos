create or alter view TICKET_SUMATORIA (

DOCTOID,
KILOGRAMOS,
CAJAS,
PIEZAS
)
as
SELECT
   DOCTO.ID AS DOCTOID,

        sum(case
            when  producto.unidad = 'KG' then
                 (CASE WHEN (docto.tipodoctoid in  (41)) THEN cast(movto.cantidadsurtida as numeric(18,3)) ELSE cast(movto.cantidad as numeric(18,3)) END )
           
            else
                0.00

        end)  KILOGRAMOS,

        sum(case
            when  producto.unidad = 'KG' then
                 0.00
            when  ( coalesce(producto.pzacaja,0) = 0 or  coalesce(producto.pzacaja,0) = 1 ) then
                 0.00
            else
                trunc(coalesce(     (CASE WHEN (docto.tipodoctoid in  (41)) THEN movto.cantidadsurtida ELSE movto.cantidad END   )   ,0)/coalesce(producto.pzacaja,1))
        end )  CAJAS ,

        sum(case
            when  producto.unidad = 'KG' then
                 0.00
            when  ( coalesce(producto.pzacaja,0) = 0 or  coalesce(producto.pzacaja,0) = 1 ) then
                 (CASE WHEN (docto.tipodoctoid in  (41)) THEN movto.cantidadsurtida ELSE movto.cantidad END )
            else
                mod(coalesce(    (CASE WHEN (docto.tipodoctoid in  (41)) THEN movto.cantidadsurtida ELSE movto.cantidad END )   ,0),coalesce(producto.pzacaja,1))
        end ) PIEZAS





        FROM
        docto
        left join MOVTO on docto.id = movto.doctoid
        left JOIN PRODUCTO ON MOVTO.productoid = PRODUCTO.ID
        left join parametro on 1 = 1

        GROUP BY DOCTO.ID



       