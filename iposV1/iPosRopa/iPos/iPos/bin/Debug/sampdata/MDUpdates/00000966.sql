CREATE OR ALTER VIEW PRODUCTOS(
    ID,
    PRODUCTO,
    CLAVE,
    DESCRIPCION1,
    DESCRIPCION2,
    PRECIO1,
    LIMITEPRECIO2,
    PRECIO2,
    EAN,
    EXISTENCIA,
    PROVEEDOR,
    INVENTARIABLE,
    NEGATIVOS,
    TASAIVA,
    PRECIO_MAS_IVA,
    DESCONTINUADO,
    ESPRODUCTOPADRE,
    EXISTENCIAAPARTADO,
    TEXTO1,
    TEXTO2,
    TEXTO3,
    TEXTO4,
    TEXTO5,
    TEXTO6,
    NUMERO1,
    NUMERO2,
    NUMERO3,
    NUMERO4,
    FECHA1,
    FECHA2,
    ENPROCESODESALIDA)
AS
SELECT P.ID,
    COALESCE(TRIM(P.CLAVE), '')
    ||COALESCE(TRIM(P.EAN), '')
    ||COALESCE(TRIM(P.NOMBRE), '')
    ||COALESCE(TRIM(P.DESCRIPCION), '')
    ||COALESCE(TRIM(P.DESCRIPCION1),'')
    ||COALESCE(TRIM(P.DESCRIPCION2), '') producto,
     P.CLAVE, P.DESCRIPCION1, P.DESCRIPCION2, P.PRECIO1, P.LIMITEPRECIO2, P.PRECIO2 , P.EAN , P.EXISTENCIA, PR.NOMBRE as PROVEEDOR , P.INVENTARIABLE, P.NEGATIVOS
     , P.tasaiva TASAIVA, (P.precio1 * (1 + (P.TASAIVA/100))) AS PRECIO_MAS_IVA
     , COALESCE(M.descontinuado,'N') AS DESCONTINUADO,   COALESCE(p.esproductopadre,'N') AS ESPRODUCTOPADRE ,
     p.existenciaapartado,
     c.texto1, 
     c.texto2,
     c.texto3,
     c.texto4,
     c.texto5,
     c.texto6,
     c.numero1,
     c.numero2, 
     c.numero3,
     c.numero4,
     c.fecha1, 
     c.fecha2,
     p.ENPROCESODESALIDA
  FROM PRODUCTO  P
   LEFT join persona PR
      on PR.id = P.proveedor1id
      LEFT JOIN MARCA M ON M.id = P.marcaid
      left join productocaracteristicas c on c.productoid = p.id


  ORDER BY CLAVE
;