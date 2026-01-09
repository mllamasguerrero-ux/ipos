CREATE OR ALTER VIEW PRODUCTOS_EXPORTVIEW(
    CLAVE,
    EAN,
    NOMBRE,
    DESCRIPCION,
    DESCRIPCION1,
    DESCRIPCION2,
    DESCRIPCION3,
    PROVEEDOR1,
    PROVEEDOR2,
    LINEA,
    MARCA,
    PRECIO1,
    PRECIO2,
    PRECIO3,
    PRECIO4,
    PRECIO5,
    TASAIVA,
    COSTOREPOSICION,
    COSTOULTIMO,
    COSTOPROMEDIO,
    INVENTARIABLE,
    NEGATIVOS,
    LIMITEPRECIO2,
    PRECIOMAXIMOPUBLICO,
    MANEJASTOCK,
    STOCK,
    MANEJALOTE,
    ESKIT,
    IMPRIMIR,
    PRODUCTOSUSTITUTO,
    CAMBIARPRECIO,
    TASAIMPUESTO,
    TASAIEPS)
AS
select
producto.CLAVE,
producto.EAN,
producto.NOMBRE,
producto.DESCRIPCION,
producto.DESCRIPCION1,
producto.DESCRIPCION2,
producto.DESCRIPCION3,
p1.clave as PROVEEDOR1,
p2.clave as PROVEEDOR2,
linea.clave as LINEA,
marca.clave as MARCA,
coalesce(producto.PRECIO1,0),
coalesce(producto.PRECIO2,0),
coalesce(producto.PRECIO3,0),
coalesce(producto.PRECIO4,0),
coalesce(producto.PRECIO5,0),
coalesce(producto.tasaiva,0) as TASAIVA,
coalesce(producto.COSTOREPOSICION,0),
coalesce(producto.COSTOULTIMO,0),
coalesce(producto.COSTOPROMEDIO,0),
producto.INVENTARIABLE,
producto.NEGATIVOS,
coalesce(producto.LIMITEPRECIO2,0),
coalesce(producto.PRECIOMAXIMOPUBLICO,0),
producto.MANEJASTOCK,
coalesce(producto.STOCK,0),
producto.MANEJALOTE,
producto.ESKIT,
producto.IMPRIMIR,
pr2.clave as PRODUCTOSUSTITUTO,
producto.CAMBIARPRECIO ,
producto.tasaimpuesto TASAIMPUESTO   ,
producto.tasaieps TASAIEPS


 from producto
 left join persona p1 on producto.proveedor1id = p1.id 
 left join persona p2 on producto.proveedor2id = p2.id
 left join linea  on producto.lineaid = linea.id
 left join marca  on producto.marcaid = marca.id
 left join tasaiva on producto.tasaivaid = tasaiva.id 
 left join producto pr2 on producto.productosustitutoid = pr2.id
;