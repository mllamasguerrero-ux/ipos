create view lotesinventarioview (
PRODUCTOID,
PRODUCTO,
LOTE,
CANTIDAD,
FECHAVENCE,
CADUCADO,
PORCADUCAR)
as
SELECT   producto.id,     producto.clave AS PRODUCTO, inventario.lote AS LOTE, sum(coalesce(inventario.cantidad,0)) AS CANTIDAD, inventario.fechavence AS FECHAVENCE,
    case when datediff(day from current_date to coalesce(inventario.fechavence, current_date )) < 0 then 'S' else 'N' end CADUCADO ,
    case when datediff(day from current_date to coalesce(inventario.fechavence, current_date )) < PARAMETRO.cortacaducidad then 'S' else 'N' end PORCADUCAR

FROM            inventario LEFT OUTER JOIN
                         producto ON inventario.productoid = producto.id LEFT OUTER JOIN
                         parametro on 1 = 1
    group by producto.id,     producto.clave, inventario.lote, inventario.fechavence ,PARAMETRO.cortacaducidad
ORDER BY abs(datediff(day from current_date to coalesce(inventario.fechavence, current_date ))), inventario.lote