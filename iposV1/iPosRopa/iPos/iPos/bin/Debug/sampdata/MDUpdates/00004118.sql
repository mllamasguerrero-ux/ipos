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
    ENPROCESODESALIDA,
    TASAIMPUESTO,
    PRECIO_MAS_IMPUESTO,
    TASAIEPS,
    PRECIO_MAS_IEPS,
    PROMOMOVIL,
    HISTORIALMOVIL,
    PRECIO3,
    PRECIO4,
    PRECIO5,
    PRECIO2_MAS_IMPUESTO,
    PRECIO3_MAS_IMPUESTO,
    PRECIO4_MAS_IMPUESTO,
    PRECIO5_MAS_IMPUESTO,
    PRECIOCAJA_MAS_IMPUESTO)
AS
SELECT P.ID,
    upper(COALESCE(TRIM(P.CLAVE), ''))
    || upper(COALESCE(TRIM(P.EAN), ''))
    || upper(COALESCE(TRIM(P.NOMBRE), ''))
    || upper(COALESCE(TRIM(P.DESCRIPCION), ''))
    || upper(COALESCE(TRIM(P.DESCRIPCION1),''))
    || upper(COALESCE(TRIM(P.DESCRIPCION2), '')) producto,
     P.CLAVE, P.DESCRIPCION1, P.DESCRIPCION2, P.PRECIO1, P.LIMITEPRECIO2, P.PRECIO2 , P.EAN , P.EXISTENCIA, PR.NOMBRE as PROVEEDOR , P.INVENTARIABLE, P.NEGATIVOS
     , P.tasaiva TASAIVA, (P.precio1  * (1 + (P.TASAIEPS/100)) * (1 + (P.TASAIVA/100))) AS PRECIO_MAS_IVA
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
     p.ENPROCESODESALIDA,   
     P.tasaimpuesto TASAIMPUESTO,
     round((P.precio1  * cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0.0000 END) /100.0000)) * (1.0000 + (P.TASAIVA/100.0000)) as numeric(18,4))),2) AS PRECIO_MAS_IMPUESTO  ,
     P.tasaieps TASAIEPS,
     (P.precio1 * (1 + ((CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0 END)/100.0000))) AS PRECIO_MAS_IEPS ,
     P.PROMOMOVIL,
     P.HISTORIALMOVIL ,
     P.PRECIO3,
     P.PRECIO4,
     P.PRECIO5,

     (P.precio2  * cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0.0000 END) /100.0000)) * (1.0000 + (P.TASAIVA/100.0000)) as numeric(18,4))) AS PRECIO2_MAS_IMPUESTO ,
     (P.precio3 * cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0.0000 END) /100.0000)) * (1.0000 + (P.TASAIVA/100.0000)) as numeric(18,4))) AS PRECIO3_MAS_IMPUESTO ,
     (P.precio4 * cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0.0000 END) /100.0000)) * (1.0000 + (P.TASAIVA/100.0000)) as numeric(18,4))) AS PRECIO4_MAS_IMPUESTO ,
     (P.precio5 * cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0.0000 END) /100.0000)) * (1.0000 + (P.TASAIVA/100.0000)) as numeric(18,4))) AS PRECIO5_MAS_IMPUESTO ,
    (
      (
      ( CASE WHEN COALESCE(P.PZACAJA,1) > 1 AND COALESCE(PM.cambiarprecioxpzacaja,'N') = 'S' AND COALESCE(PM.listaprecioxpzacaja,0) > 0 THEN
           (case when PM.LISTAPRECIOXPZACAJA = 1 then P.PRECIO1
              when PM.LISTAPRECIOXPZACAJA = 2 then  P.PRECIO2
              when PM.LISTAPRECIOXPZACAJA = 3 then  P.PRECIO3
              when PM.LISTAPRECIOXPZACAJA = 4 then  P.PRECIO4
              when PM.LISTAPRECIOXPZACAJA = 5 then  P.PRECIO5
              else  P.PRECIO3
            end)
       ELSE
           P.PRECIO1
       END
       )
       *   CAST(  (1.0000 + ((CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0.0 END)/100.0000)) *  (1.0 + (P.TASAIVA/100.0000)) AS numeric(18,4))
       )
      ) *  (CASE WHEN COALESCE(P.PZACAJA,1.0) > 0 THEN COALESCE(P.PZACAJA,1.0) ELSE 1.0 END)  PRECIOCAJA_MAS_IMPUESTO



  FROM PRODUCTO  P
   LEFT join persona PR
      on PR.id = P.proveedor1id
      LEFT JOIN MARCA M ON M.id = P.marcaid
      left join productocaracteristicas c on c.productoid = p.id
      left join parametro PM on 1 = 1

    where coalesce(pm.esvendedormovil,'N') = 'N' or coalesce(p.activo,'S') = 'S'


  ORDER BY CLAVE
;