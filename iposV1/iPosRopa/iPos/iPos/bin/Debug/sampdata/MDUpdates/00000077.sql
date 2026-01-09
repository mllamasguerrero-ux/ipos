CREATE OR ALTER VIEW STOCK_FALTANTE(
    EAN,
    CLAVE,
    NOMBRE,
    DESCRIPCION,
    EXISTENCIA,
    STOCK,
    FALTANTE)
AS
select EAN, CLAVE, NOMBRE, DESCRIPCION1, coalesce(sum(inventario.cantidad),0) EXISTENCIA, coalesce(STOCK,0) STOCK,  (coalesce(STOCK,0) - coalesce(sum(inventario.cantidad),0) ) FALTANTE
 from producto left join inventario on producto.id = inventario.productoid
 where   MANEJASTOCk = 'S'
 group by    EAN, CLAVE, NOMBRE, DESCRIPCION1,  STOCK
 having        (coalesce(STOCK,0) - coalesce(sum(inventario.cantidad),0) ) > 0
 order by  EAN, CLAVE, NOMBRE
;