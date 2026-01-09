CREATE OR ALTER VIEW TICKET_SUMATORIA(
    DOCTOID,
    KILOGRAMOS,
    CAJAS,
    PIEZAS)
AS
SELECT
   DOCTO.ID AS DOCTOID,


    sum(
            case when coalesce(MKITREF.ID,0) = 0 then
                case when  producto.unidad = 'KG' then
                 (CASE WHEN (docto.tipodoctoid in  (41)) THEN cast(movto.cantidadsurtida as numeric(18,3)) ELSE cast(movto.cantidad as numeric(18,3)) END )
                else
                    0.00
                end
             else
                case when  pkitref.unidad = 'KG' then
                    cast(mkitref.cantidad as numeric(18,3))
                    else
                    0.00
                 end

             end
        ) KILOGRAMOS,

        sum(

            case when coalesce(MKITREF.ID,0) = 0  then
                case
                    when  producto.unidad = 'KG' then
                        0.00
                    when  ( coalesce(producto.pzacaja,0) = 0 or  coalesce(producto.pzacaja,0) = 1 ) then
                        0.00
                else
                    trunc(coalesce(     (CASE WHEN (docto.tipodoctoid in  (41)) THEN movto.cantidadsurtida ELSE movto.cantidad END   )   ,0)/coalesce(producto.pzacaja,1))
                end
            else
                case
                    when  pkitref.unidad = 'KG' then
                        0.00
                    when  ( coalesce(pkitref.pzacaja,0) = 0 or  coalesce(pkitref.pzacaja,0) = 1 ) then
                        0.00
                    else
                        trunc(coalesce( mkitref.cantidad  ,0)/coalesce(pkitref.pzacaja,1))
                    end
            end


          )  CAJAS ,

          sum(
                
            case when coalesce(MKITREF.ID,0) = 0 then
                case
                    when  producto.unidad = 'KG' then
                        0.00
                    when  ( coalesce(producto.pzacaja,0) = 0 or  coalesce(producto.pzacaja,0) = 1 ) then
                        (CASE WHEN (docto.tipodoctoid in  (41)) THEN movto.cantidadsurtida ELSE movto.cantidad END )
                    else
                        mod(coalesce(    (CASE WHEN (docto.tipodoctoid in  (41)) THEN movto.cantidadsurtida ELSE movto.cantidad END )   ,0),coalesce(producto.pzacaja,1))
                end
            else
                case
                    when  pkitref.unidad = 'KG' then
                        0.00
                    when  ( coalesce(pkitref.pzacaja,0) = 0 or  coalesce(pkitref.pzacaja,0) = 1 ) then
                         mkitref.cantidad
                    else
                        mod(coalesce( mkitref.cantidad  ,0),coalesce(pkitref.pzacaja,1))
                end

            end


             ) PIEZAS





        FROM
        docto
        left join MOVTO on docto.id = movto.doctoid
        left JOIN PRODUCTO ON MOVTO.productoid = PRODUCTO.ID
        left join parametro on 1 = 1
        left join MOVTO MKITREF ON MKITREF.doctoid = COALESCE(docto.doctokitrefid,0) AND MKITREF.movtorefid = MOVTO.ID
        left JOIN PRODUCTO PKITREF ON MKITREF.productoid = PKITREF.ID

        GROUP BY DOCTO.ID
;