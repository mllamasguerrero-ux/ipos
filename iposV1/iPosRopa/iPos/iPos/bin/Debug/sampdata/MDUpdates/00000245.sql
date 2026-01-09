create view PRODUCTOS_EXPORTVIEW (

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
CAMBIARPRECIO
)
as
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
producto.PRECIO1,
producto.PRECIO2,
producto.PRECIO3,
producto.PRECIO4,
producto.PRECIO5,
tasaiva.clave as TASAIVA,
producto.COSTOREPOSICION,
producto.COSTOULTIMO,
producto.COSTOPROMEDIO,
producto.INVENTARIABLE,
producto.NEGATIVOS,
producto.LIMITEPRECIO2,
producto.PRECIOMAXIMOPUBLICO,
producto.MANEJASTOCK,
producto.STOCK,
producto.MANEJALOTE,
producto.ESKIT,
producto.IMPRIMIR,
pr2.clave as PRODUCTOSUSTITUTO,
producto.CAMBIARPRECIO


 from producto
 left join persona p1 on producto.proveedor1id = p1.id 
 left join persona p2 on producto.proveedor2id = p2.id
 left join linea  on producto.lineaid = linea.id
 left join marca  on producto.marcaid = marca.id
 left join tasaiva on producto.tasaivaid = tasaiva.id 
 left join producto pr2 on producto.productosustitutoid = pr2.id

