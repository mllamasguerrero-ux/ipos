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
    PRECIOCAJA_MAS_IMPUESTO,
    PRECIOMEDIOMAYOREOCONTARJETA,
    PRECIOMAYOREOCONTARJETA,
    U_EMPAQUE,
    PZACAJA,
    CAJAS,
    PIEZAS,
    ESKIT,
    KITTIENEVIG,
    VIGENCIAPRODKIT,
    COSTOREPOSICION,
    TASAIEPSAPLICABLE,
    TASAIVAAPLICABLE,
    COSTOREPOCONUTILIMP,
    COSTOREPOCONUTIL,
    COSTOREPOCONUTILMACROIMP,
    COSTOREPOCONUTILMACRO)
AS
select P.ID,
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
      CASE WHEN COALESCE(P.eskit, 'N') = 'S' AND COALESCE(P.TASAIEPSEXT,0) > 0  AND COALESCE(P.TASAIVAEXT,0) > 0  THEN
            round((P.precio1  * cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPSEXT ELSE 0.0000 END) /100.00)) * (1.00 + (P.TASAIVAEXT/100.00)) as numeric(18,8))),2)
      else
            round((P.precio1  * cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0.0000 END) /100.00)) * (1.00 + (P.TASAIVA/100.00)) as numeric(18,4))),2)
       END
      AS PRECIO_MAS_IMPUESTO  ,
     P.tasaieps TASAIEPS,
     (P.precio1 * (1 + ((CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0 END)/100.0000))) AS PRECIO_MAS_IEPS ,
     P.PROMOMOVIL,
     P.HISTORIALMOVIL ,
     P.PRECIO3,
     P.PRECIO4,
     P.PRECIO5,

     CASE WHEN COALESCE(P.eskit, 'N') = 'S'  AND COALESCE(P.TASAIEPSEXT,0) > 0  AND COALESCE(P.TASAIVAEXT,0) > 0   THEN
            round((P.precio2  * cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPSEXT ELSE 0.0000 END) /100.00)) * (1.00 + (P.TASAIVAEXT/100.00)) as numeric(18,4))),2)
      else
            round((P.precio2  * cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0.0000 END) /100.00)) * (1.00 + (P.TASAIVA/100.00)) as numeric(18,4))),2)
       END
      AS PRECIO2_MAS_IMPUESTO,

      CASE WHEN COALESCE(P.eskit, 'N') = 'S' AND COALESCE(P.TASAIEPSEXT,0) > 0  AND COALESCE(P.TASAIVAEXT,0) > 0    THEN
            round((P.precio3  * cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPSEXT ELSE 0.0000 END) /100.00)) * (1.00 + (P.TASAIVAEXT/100.00)) as numeric(18,4))),2)
      else
            round((P.precio3  * cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0.0000 END) /100.00)) * (1.00 + (P.TASAIVA/100.00)) as numeric(18,4))),2)
       END
      AS PRECIO3_MAS_IMPUESTO,

      CASE WHEN COALESCE(P.eskit, 'N') = 'S' AND COALESCE(P.TASAIEPSEXT,0) > 0  AND COALESCE(P.TASAIVAEXT,0) > 0    THEN
            round((P.precio4  * cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPSEXT ELSE 0.0000 END) /100.00)) * (1.00 + (P.TASAIVAEXT/100.00)) as numeric(18,4))),2)
      else
            round((P.precio4  * cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0.0000 END) /100.00)) * (1.00 + (P.TASAIVA/100.00)) as numeric(18,4))),2)
       END
      AS PRECIO4_MAS_IMPUESTO ,

      CASE WHEN COALESCE(P.eskit, 'N') = 'S' AND COALESCE(P.TASAIEPSEXT,0) > 0  AND COALESCE(P.TASAIVAEXT,0) > 0    THEN
            round((P.precio5  * cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPSEXT ELSE 0.0000 END) /100.00)) * (1.00 + (P.TASAIVAEXT/100.00)) as numeric(18,4))),2)
      else
            round((P.precio5  * cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0.0000 END) /100.00)) * (1.00 + (P.TASAIVA/100.00)) as numeric(18,4))),2)
       END
      AS PRECIO5_MAS_IMPUESTO,


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
      ) *  (CASE WHEN COALESCE(P.PZACAJA,1.0) > 0 THEN COALESCE(P.PZACAJA,1.0) ELSE 1.0 END)  PRECIOCAJA_MAS_IMPUESTO ,

      MINVALUE
      (
      (CASE MOSTRADOR.listaprecioid WHEN 1 THEN P.PRECIO1 WHEN 2 THEN P.PRECIO2 WHEN 3 THEN P.PRECIO3 WHEN 4 THEN P.PRECIO4 WHEN 5 THEN P.PRECIO5 ELSE P.PRECIO1 END
       * cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0.0000 END) /100.0000)) * (1.0000 + (P.TASAIVA/100.0000)) as numeric(18,4)))
         ,
      ((100.0000 + COALESCE(PM.COMISIONPORTARJETA,0.00))/100.0000) * cast((P.precio3 * (1.00 + ((CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0.00 END)/100.00)) * (1.00 + (P.TASAIVA/100.00))) as d_precio)
      ) AS PRECIOMEDIOMAYOREOCONTARJETA,


      MINVALUE
      (
      (CASE MOSTRADOR.listaprecioid WHEN 1 THEN P.PRECIO1 WHEN 2 THEN P.PRECIO2 WHEN 3 THEN P.PRECIO3 WHEN 4 THEN P.PRECIO4 WHEN 5 THEN P.PRECIO5 ELSE P.PRECIO1 END
       * cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0.0000 END) /100.0000)) * (1.0000 + (P.TASAIVA/100.0000)) as numeric(18,4)))
         ,

      CASE WHEN COALESCE(P.PRECIO6,0) > 0 THEN  cast((P.precio6 * (1 + ((CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0 END)/100.00)) * (1 + (P.TASAIVA/100.00))) as d_precio)
           ELSE ((100.0000 + COALESCE(PM.COMISIONPORTARJETA,0.00))/100.0000) * cast((P.precio4 * (1 + ((CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0 END)/100.00)) * (1 + (P.TASAIVA/100.00))) as d_precio)
      END
      ) PRECIOMAYOREOCONTARJETA ,
      P.u_empaque, 
      P.PZACAJA,

       case
            when  ( coalesce(p.pzacaja,0) = 0 or  coalesce(p.pzacaja,0) = 1 ) then
                 0.00
            else
                trunc(coalesce(     P.EXISTENCIA   ,0)/coalesce(p.pzacaja,1))
        end   CAJAS ,

        case
            when  ( coalesce(p.pzacaja,0) = 0 or  coalesce(p.pzacaja,0) = 1 ) then
                 P.EXISTENCIA
            else
                mod(coalesce(    P.EXISTENCIA   ,0),coalesce(p.pzacaja,1))
        end  PIEZAS ,
        COALESCE(P.ESKIT,'N') ESKIT,
        P.KITTIENEVIG ,
        P.VIGENCIAPRODKIT,

        coalesce(P.COSTOREPOSICION,0) COSTOREPOSICION,
      CASE WHEN COALESCE(P.eskit, 'N') = 'S' AND COALESCE(P.TASAIEPSEXT,0) > 0  AND COALESCE(P.TASAIVAEXT,0) > 0    THEN
            (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPSEXT ELSE 0.0000 END)
      else
            (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0.0000 END)
       END  TASAIEPSAPLICABLE,
            
      CASE WHEN COALESCE(P.eskit, 'N') = 'S' AND COALESCE(P.TASAIEPSEXT,0) > 0  AND COALESCE(P.TASAIVAEXT,0) > 0    THEN
            P.TASAIVAEXT
      else
            P.TASAIVA
       END  TASAIVAAPLICABLE ,

      round(
      (
        CASE WHEN (1.0 - (coalesce(PM.porcutilidadlistado,0.00)/100.00)) > 0.00 THEN
            CAST((coalesce(P.costoreposicion,0) / (1.0 - (coalesce(PM.porcutilidadlistado,0.0)/100.00))   ) AS NUMERIC(18,4)) 
        ELSE
            CAST((coalesce(P.costoreposicion,0) * (1.0 + (coalesce(PM.porcutilidadlistado,0.0)/100.00))   ) AS NUMERIC(18,4))
        END
       )
           *
      CASE WHEN COALESCE(P.eskit, 'N') = 'S' AND COALESCE(P.TASAIEPSEXT,0) > 0  AND COALESCE(P.TASAIVAEXT,0) > 0    THEN
            (  cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPSEXT ELSE 0.0000 END) /100.00)) * (1.00 + (P.TASAIVAEXT/100.00)) as numeric(18,4)))
      else
            (  cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0.0000 END) /100.00)) * (1.00 + (P.TASAIVA/100.00)) as numeric(18,4)))
       END
       ,2)
      AS COSTOREPOCONUTILIMP ,

      round(
            
        CASE WHEN (1.0 - (coalesce(PM.porcutilidadlistado,0.00)/100.00)) > 0.00 THEN
            CAST((coalesce(P.costoreposicion,0) / (1.0 - (coalesce(PM.porcutilidadlistado,0.0)/100.00))   ) AS NUMERIC(18,4)) 
        ELSE
            CAST((coalesce(P.costoreposicion,0) * (1.0 + (coalesce(PM.porcutilidadlistado,0.0)/100.00))   ) AS NUMERIC(18,4))
        END

        ,2)
      AS COSTOREPOCONUTIL        ,

      
      round(
      (
        CASE WHEN (1.0 - (coalesce(PM.porcutilmacrolistado,0.00)/100.00)) > 0.00 THEN
            CAST((coalesce(P.costoreposicion,0) / (1.0 - (coalesce(PM.porcutilmacrolistado,0.0)/100.00))   ) AS NUMERIC(18,4))
        ELSE
            CAST((coalesce(P.costoreposicion,0) * (1.0 + (coalesce(PM.porcutilmacrolistado,0.0)/100.00))   ) AS NUMERIC(18,4))
        END
       )
           *
       CASE WHEN COALESCE(P.eskit, 'N') = 'S' AND COALESCE(P.TASAIEPSEXT,0) > 0  AND COALESCE(P.TASAIVAEXT,0) > 0    THEN
            (   cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPSEXT ELSE 0.0000 END) /100.00)) * (1.00 + (P.TASAIVAEXT/100.00)) as numeric(18,4)))
       else
            (   cast( (1.0000 + ( (CASE WHEN COALESCE(PM.desgloseieps,'N') = 'S' THEN P.TASAIEPS ELSE 0.0000 END) /100.00)) * (1.00 + (P.TASAIVA/100.00)) as numeric(18,4)))
       END      
        ,2)
      AS COSTOREPOCONUTILMACROIMP ,

      
      round(
      (
        CASE WHEN (1.0 - (coalesce(PM.porcutilmacrolistado,0.00)/100.00)) > 0.00 THEN
            CAST((coalesce(P.costoreposicion,0) / (1.0 - (coalesce(PM.porcutilmacrolistado,0.0)/100.00))   ) AS NUMERIC(18,4))
        ELSE
            CAST((coalesce(P.costoreposicion,0) * (1.0 + (coalesce(PM.porcutilmacrolistado,0.0)/100.00))   ) AS NUMERIC(18,4))
        END
       )
       ,2)
      AS COSTOREPOCONUTILMACRO





  FROM PRODUCTO  P
   LEFT join persona PR
on PR.id = P.proveedor1id
      LEFT JOIN MARCA M ON M.id = P.marcaid
left join productocaracteristicas c on c.productoid = p.id
left join parametro PM on 1 = 1
left join persona MOSTRADOR ON MOSTRADOR.ID = 1

where coalesce(pm.esvendedormovil,'N') = 'N' or coalesce(p.activo,'S') = 'S'


  ORDER BY CLAVE
;