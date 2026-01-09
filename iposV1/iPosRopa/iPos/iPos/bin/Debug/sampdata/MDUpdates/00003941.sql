CREATE OR ALTER VIEW GRIDPV(
    DOCTOID,
    MOVTOID,
    PARTIDA,
    GRIDLINE,
    CANTIDAD,
    DESCRIPCION,
    PRECIOUNIDAD,
    IMPORTE,
    TITULOSTOTALES,
    DESCUENTO,
    DESCRIPCION2,
    LOTE,
    CLAVEPRODUCTO,
    SUBTOTAL,
    IVA,
    TOTALVALE,
    TOTALVALEDESC1,
    TOTALVALEDESC2,
    TOTALVALEDESC3,
    TOTALVALEDESC4,
    TASAIVA,
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
    MOVTODESCRIPCION1,
    MOVTODESCRIPCION2,
    MOVTODESCRIPCION3,
    PRODUCTOID,
    IMAGEN,
    ORDEN,
    TASAIEPS,
    DESCUENTOPORCENTAJE,
    PORCENTAJEDESCUENTOMANUAL,
    TASAIMPUESTO,
    ALERTA,
    PZACAJA,
    MOVTOADJUNTOAID,
    UTILIDADMOVIL,
    AUTORIZACIONDESCNOTA,
    UNIDAD,
    INGRESOPRECIOMANUAL)
AS
SELECT
DOCTO.ID AS DOCTOID,
MOVTO.ID AS MOVTOID,
MOVTO.PARTIDA, 1 AS GRIDLINE,
MOVTO.CANTIDAD, CASE WHEN PRODUCTO.descripcion_comodin = 'S' AND
                         MOVTO.descripcion1 IS NOT NULL AND MOVTO.descripcion1 <> '' THEN MOVTO.DESCRIPCION1 ELSE PRODUCTO.DESCRIPCION1 END AS DESCRIPCION,

                         CASE WHEN MOVTO.TASAIMPUESTO IS NULL THEN
                                (case when coalesce(movto.estadorebaja,0) <> 0 then movto.precioconrebaja else MOVTO.PRECIO end) / (CASE WHEN DOCTO.TIPOCAMBIO = 0 or  DOCTO.TIPOCAMBIO IS NULL THEN 1 ELSE DOCTO.TIPOCAMBIO END)
                         ELSE
                                ((case when coalesce(movto.estadorebaja,0) <> 0 then movto.precioconrebaja else MOVTO.PRECIO end) * ((100.00 + MOVTO.TASAIVA) / 100.00) * ((100.00 + MOVTO.TASAIEPS) / 100.00)) / (CASE WHEN DOCTO.TIPOCAMBIO = 0 or  DOCTO.TIPOCAMBIO IS NULL THEN 1 ELSE DOCTO.TIPOCAMBIO END) END
                         AS PRECIOUNIDAD,

                         (case when coalesce(movto.estadorebaja,0) <> 0 then movto.totalconrebaja else MOVTO.TOTAL end) / (CASE WHEN DOCTO.TIPOCAMBIO = 0 or  DOCTO.TIPOCAMBIO IS NULL THEN 1 ELSE DOCTO.TIPOCAMBIO END) AS IMPORTE,

                         '' AS TITULOSTOTALES,
                          
                         (case when coalesce(movto.estadorebaja,0) <> 0  then coalesce(movto.total,0) - coalesce(movto.totalconrebaja,0) + coalesce(movto.descuento,0)  else MOVTO.DESCUENTO end) /
                         (CASE WHEN DOCTO.TIPOCAMBIO = 0 or  DOCTO.TIPOCAMBIO IS NULL THEN 1 ELSE DOCTO.TIPOCAMBIO END) AS DESCUENTO,


                         CASE WHEN PRODUCTO.descripcion_comodin = 'S' AND 
                         MOVTO.descripcion1 IS NOT NULL AND MOVTO.descripcion1 <> '' THEN MOVTO.DESCRIPCION2 ELSE PRODUCTO.DESCRIPCION2 END AS DESCRIPCION2,

                         MOVTO.LOTE, PRODUCTO.CLAVE AS CLAVEPRODUCTO,
                          MOVTO.SUBTOTAL / (CASE WHEN DOCTO.TIPOCAMBIO = 0 OR
                         DOCTO.TIPOCAMBIO IS NULL THEN 1 ELSE DOCTO.TIPOCAMBIO END) AS SUBTOTAL,
                         MOVTO.IVA / (CASE WHEN DOCTO.TIPOCAMBIO = 0 OR
                         DOCTO.TIPOCAMBIO IS NULL THEN 1 ELSE DOCTO.TIPOCAMBIO END) AS IVA,

                         CASE WHEN PRODUCTO.TIPOABC = 'S' AND (PERSONA.LISTAPRECIOID IS NULL OR
                         PERSONA.LISTAPRECIOID = 1) AND MOVTO.INGRESOPRECIOMANUAL = 'N' AND (NOT (PRODUCTO.pzacaja > 1 AND MOVTO.CANTIDAD >= PRODUCTO.pzacaja)) AND 
                         (NOT (PRODUCTO.pzacaja > 1 AND MOVTO.CANTIDAD >= PRODUCTO.U_EMPAQUE AND PRODUCTO.U_EMPAQUE > 1)) AND 
                         (NOT (PRODUCTO.UNIDAD LIKE '%KG%' AND MOVTO.CANTIDAD >= PRODUCTO.INI_MAYO AND PRODUCTO.MAYOKGS = 'S')) 
                         THEN




                            cast( (ROUND(
                                      /*PRECIO MAS BAJO POR VALE*/case when ROUND((MOVTO.PRECIOLISTA * ((100 - PARAMETRO.DESCUENTOVALE)/100.00)),2) < MOVTO.PRECIO  THEN   ROUND((MOVTO.PRECIOLISTA * ((100 - PARAMETRO.DESCUENTOVALE)/100.00)),2) ELSE MOVTO.PRECIO END
                                    * MOVTO.CANTIDAD , 2)) as d_importe)    +
                            cast( ROUND((  cast((ROUND(
                                    /*PRECIO MAS BAJO POR VALE*/case when ROUND((MOVTO.PRECIOLISTA * ((100 - PARAMETRO.DESCUENTOVALE)/100.00)),2) < MOVTO.PRECIO  THEN   ROUND((MOVTO.PRECIOLISTA * ((100 - PARAMETRO.DESCUENTOVALE)/100.00)),2) ELSE MOVTO.PRECIO END
                                     * MOVTO.CANTIDAD , 2)) as d_importe)  * (1 + (COALESCE (MOVTO.tasaieps,0)/100.00)) * (COALESCE (MOVTO.tasaiva,0)/100.00)) , 2)  as d_importe) +
                            cast( ROUND((  cast((ROUND(
                                    /*PRECIO MAS BAJO POR VALE*/case when ROUND((MOVTO.PRECIOLISTA * ((100 - PARAMETRO.DESCUENTOVALE)/100.00)),2) < MOVTO.PRECIO  THEN   ROUND((MOVTO.PRECIOLISTA * ((100 - PARAMETRO.DESCUENTOVALE)/100.00)),2) ELSE MOVTO.PRECIO END
                                     * MOVTO.CANTIDAD , 2)) as d_importe) * (COALESCE (MOVTO.tasaieps,0)/100.00)) ,2 )  as d_importe)


                         ELSE MOVTO.TOTAL /
                            (CASE WHEN DOCTO.TIPOCAMBIO = 0 OR
                                DOCTO.TIPOCAMBIO IS NULL THEN 1 ELSE DOCTO.TIPOCAMBIO END)

                         END AS TOTALVALE,


                         
                         CASE WHEN PRODUCTO.TIPOABC = 'S' AND (PERSONA.LISTAPRECIOID IS NULL OR
                         PERSONA.LISTAPRECIOID = 1) AND MOVTO.INGRESOPRECIOMANUAL = 'N' AND (NOT (PRODUCTO.pzacaja > 1 AND MOVTO.CANTIDAD >= PRODUCTO.pzacaja)) AND 
                         (NOT (PRODUCTO.pzacaja > 1 AND MOVTO.CANTIDAD >= PRODUCTO.U_EMPAQUE AND PRODUCTO.U_EMPAQUE > 1)) AND 
                         (NOT (PRODUCTO.UNIDAD LIKE '%KG%' AND MOVTO.CANTIDAD >= PRODUCTO.INI_MAYO AND PRODUCTO.MAYOKGS = 'S')) AND
                         (COALESCE(PARAMETRO.descuentotipo1porc,0) > 0)
                         THEN

                         cast( (ROUND( 
                                      /*PRECIO MAS BAJO POR VALE*/case when ROUND((MOVTO.PRECIOLISTA * ((100 - PARAMETRO.DESCUENTOVALE)/100.00)),2) < MOVTO.PRECIO  THEN   ROUND((MOVTO.PRECIOLISTA * ((100 - PARAMETRO.DESCUENTOVALE)/100.00)),2) ELSE MOVTO.PRECIO END
                                     * MOVTO.CANTIDAD , 2)) as d_importe)    +
                        cast( ROUND((  cast((ROUND( 
                                      /*PRECIO MAS BAJO POR VALE*/case when ROUND((MOVTO.PRECIOLISTA * ((100 - PARAMETRO.DESCUENTOVALE)/100.00)),2) < MOVTO.PRECIO  THEN   ROUND((MOVTO.PRECIOLISTA * ((100 - PARAMETRO.DESCUENTOVALE)/100.00)),2) ELSE MOVTO.PRECIO END
                                     * MOVTO.CANTIDAD , 2)) as d_importe)  * (1 + (COALESCE (MOVTO.tasaieps,0)/100.00)) * (COALESCE (MOVTO.tasaiva,0)/100.00)) , 2)  as d_importe) +
                        cast( ROUND((  cast((ROUND(  
                                      /*PRECIO MAS BAJO POR VALE*/case when ROUND((MOVTO.PRECIOLISTA * ((100 - PARAMETRO.DESCUENTOVALE)/100.00)),2) < MOVTO.PRECIO  THEN   ROUND((MOVTO.PRECIOLISTA * ((100 - PARAMETRO.DESCUENTOVALE)/100.00)),2) ELSE MOVTO.PRECIO END
                                      * MOVTO.CANTIDAD , 2)) as d_importe) * (COALESCE (MOVTO.tasaieps,0)/100.00)) ,2 )  as d_importe)


                         ELSE MOVTO.TOTAL /
                         (CASE WHEN DOCTO.TIPOCAMBIO = 0 OR
                         DOCTO.TIPOCAMBIO IS NULL THEN 1 ELSE DOCTO.TIPOCAMBIO END)

                         END AS TOTALVALEDESC1,
                         
                         CASE WHEN PRODUCTO.TIPOABC = 'S' AND (PERSONA.LISTAPRECIOID IS NULL OR
                         PERSONA.LISTAPRECIOID = 1) AND MOVTO.INGRESOPRECIOMANUAL = 'N' AND (NOT (PRODUCTO.pzacaja > 1 AND MOVTO.CANTIDAD >= PRODUCTO.pzacaja)) AND 
                         (NOT (PRODUCTO.pzacaja > 1 AND MOVTO.CANTIDAD >= PRODUCTO.U_EMPAQUE AND PRODUCTO.U_EMPAQUE > 1)) AND 
                         (NOT (PRODUCTO.UNIDAD LIKE '%KG%' AND MOVTO.CANTIDAD >= PRODUCTO.INI_MAYO AND PRODUCTO.MAYOKGS = 'S')) AND
                         (COALESCE(PARAMETRO.descuentotipo2porc,0) > 0)
                         THEN

                         cast( (ROUND(  
                                      /*PRECIO MAS BAJO POR VALE*/case when ROUND((MOVTO.PRECIOLISTA * ((100 - descuentotipo2porc)/100.00)),2) < MOVTO.PRECIO  THEN   ROUND((MOVTO.PRECIOLISTA * ((100 - PARAMETRO.descuentotipo2porc)/100.00)),2) ELSE MOVTO.PRECIO END
                                      * MOVTO.CANTIDAD , 2)) as d_importe)    +
                        cast( ROUND((  cast((ROUND(   
                                      /*PRECIO MAS BAJO POR VALE*/case when ROUND((MOVTO.PRECIOLISTA * ((100 - descuentotipo2porc)/100.00)),2) < MOVTO.PRECIO  THEN   ROUND((MOVTO.PRECIOLISTA * ((100 - PARAMETRO.descuentotipo2porc)/100.00)),2) ELSE MOVTO.PRECIO END
                                      * MOVTO.CANTIDAD , 2)) as d_importe)  * (1 + (COALESCE (MOVTO.tasaieps,0)/100.00)) * (COALESCE (MOVTO.tasaiva,0)/100.00)) , 2)  as d_importe) +
                        cast( ROUND((  cast((ROUND(   
                                      /*PRECIO MAS BAJO POR VALE*/case when ROUND((MOVTO.PRECIOLISTA * ((100 - descuentotipo2porc)/100.00)),2) < MOVTO.PRECIO  THEN   ROUND((MOVTO.PRECIOLISTA * ((100 - PARAMETRO.descuentotipo2porc)/100.00)),2) ELSE MOVTO.PRECIO END
                                      * MOVTO.CANTIDAD , 2)) as d_importe) * (COALESCE (MOVTO.tasaieps,0)/100.00)) ,2 )  as d_importe)


                         ELSE MOVTO.TOTAL /
                         (CASE WHEN DOCTO.TIPOCAMBIO = 0 OR
                         DOCTO.TIPOCAMBIO IS NULL THEN 1 ELSE DOCTO.TIPOCAMBIO END)

                         END AS TOTALVALEDESC2,

                         
                         CASE WHEN PRODUCTO.TIPOABC = 'S' AND (PERSONA.LISTAPRECIOID IS NULL or  PERSONA.LISTAPRECIOID = 1) AND MOVTO.INGRESOPRECIOMANUAL = 'N' AND (NOT (PRODUCTO.pzacaja > 1 AND MOVTO.CANTIDAD >= PRODUCTO.pzacaja)) AND
                         (NOT (PRODUCTO.pzacaja > 1 AND MOVTO.CANTIDAD >= PRODUCTO.U_EMPAQUE AND PRODUCTO.U_EMPAQUE > 1)) AND 
                         (NOT (PRODUCTO.UNIDAD LIKE '%KG%' AND MOVTO.CANTIDAD >= PRODUCTO.INI_MAYO AND PRODUCTO.MAYOKGS = 'S')) AND
                         (COALESCE(PARAMETRO.descuentotipo3porc,0) > 0)
                         THEN

                                cast( (ROUND(   
                                      /*PRECIO MAS BAJO POR VALE*/case when ROUND((MOVTO.PRECIOLISTA * ((100 - descuentotipo3porc)/100.00)),2) < MOVTO.PRECIO  THEN   ROUND((MOVTO.PRECIOLISTA * ((100 - PARAMETRO.descuentotipo3porc)/100.00)),2) ELSE MOVTO.PRECIO END
                                       * MOVTO.CANTIDAD , 2)) as d_importe)    +
                                cast( ROUND((  cast((ROUND(   
                                      /*PRECIO MAS BAJO POR VALE*/case when ROUND((MOVTO.PRECIOLISTA * ((100 - descuentotipo3porc)/100.00)),2) < MOVTO.PRECIO  THEN   ROUND((MOVTO.PRECIOLISTA * ((100 - PARAMETRO.descuentotipo3porc)/100.00)),2) ELSE MOVTO.PRECIO END
                                      * MOVTO.CANTIDAD , 2)) as d_importe)  * (1 + (COALESCE (MOVTO.tasaieps,0)/100.00)) * (COALESCE (MOVTO.tasaiva,0)/100.00)) , 2)  as d_importe) +
                                cast( ROUND((  cast((ROUND(   
                                      /*PRECIO MAS BAJO POR VALE*/case when ROUND((MOVTO.PRECIOLISTA * ((100 - descuentotipo3porc)/100.00)),2) < MOVTO.PRECIO  THEN   ROUND((MOVTO.PRECIOLISTA * ((100 - PARAMETRO.descuentotipo3porc)/100.00)),2) ELSE MOVTO.PRECIO END
                                       * MOVTO.CANTIDAD , 2)) as d_importe) * (COALESCE (MOVTO.tasaieps,0)/100.00)) ,2 )  as d_importe)


                         ELSE MOVTO.TOTAL /
                         (CASE WHEN DOCTO.TIPOCAMBIO = 0 OR
                         DOCTO.TIPOCAMBIO IS NULL THEN 1 ELSE DOCTO.TIPOCAMBIO END)

                         END AS TOTALVALEDESC3,

                         
                         CASE WHEN PRODUCTO.TIPOABC = 'S' AND (PERSONA.LISTAPRECIOID IS NULL OR
                         PERSONA.LISTAPRECIOID = 1) AND MOVTO.INGRESOPRECIOMANUAL = 'N' AND (NOT (PRODUCTO.pzacaja > 1 AND MOVTO.CANTIDAD >= PRODUCTO.pzacaja)) AND 
                         (NOT (PRODUCTO.pzacaja > 1 AND MOVTO.CANTIDAD >= PRODUCTO.U_EMPAQUE AND PRODUCTO.U_EMPAQUE > 1)) AND 
                         (NOT (PRODUCTO.UNIDAD LIKE '%KG%' AND MOVTO.CANTIDAD >= PRODUCTO.INI_MAYO AND PRODUCTO.MAYOKGS = 'S')) AND
                         (COALESCE(PARAMETRO.descuentotipo4porc,0) > 0)
                         THEN

                         cast( (ROUND( ROUND((MOVTO.PRECIO * ((100 - PARAMETRO.descuentotipo4porc)/100.00)),2) * MOVTO.CANTIDAD , 2)) as d_importe)    +
                        cast( ROUND((  cast((ROUND( ROUND((MOVTO.PRECIO * ((100 - PARAMETRO.descuentotipo4porc)/100.00)),2) * MOVTO.CANTIDAD , 2)) as d_importe)  * (1 + (COALESCE (MOVTO.tasaieps,0)/100.00)) * (COALESCE (MOVTO.tasaiva,0)/100.00)) , 2)  as d_importe) +
                        cast( ROUND((  cast((ROUND( ROUND((MOVTO.PRECIO * ((100 - PARAMETRO.descuentotipo4porc)/100.00)),2) * MOVTO.CANTIDAD , 2)) as d_importe) * (COALESCE (MOVTO.tasaieps,0)/100.00)) ,2 )  as d_importe)


                         ELSE MOVTO.TOTAL /
                         (CASE WHEN DOCTO.TIPOCAMBIO = 0 OR
                         DOCTO.TIPOCAMBIO IS NULL THEN 1 ELSE DOCTO.TIPOCAMBIO END)

                         END AS TOTALVALEDESC4,


                         MOVTO.TASAIVA, PRODUCTOCARACTERISTICAS.TEXTO1,
                         PRODUCTOCARACTERISTICAS.TEXTO2, PRODUCTOCARACTERISTICAS.TEXTO3, PRODUCTOCARACTERISTICAS.TEXTO4, PRODUCTOCARACTERISTICAS.TEXTO5, 
                         PRODUCTOCARACTERISTICAS.TEXTO6, PRODUCTOCARACTERISTICAS.NUMERO1, PRODUCTOCARACTERISTICAS.NUMERO2, 
                         PRODUCTOCARACTERISTICAS.NUMERO3, PRODUCTOCARACTERISTICAS.NUMERO4, MOVTO.DESCRIPCION1 AS MOVTODESCRIPCION1,
                         MOVTO.DESCRIPCION2 AS MOVTODESCRIPCION2, MOVTO.DESCRIPCION3 AS MOVTODESCRIPCION3, MOVTO.PRODUCTOID, PRODUCTO.IMAGEN  ,
                         MOVTO.ORDEN , MOVTO.TASAIEPS ,

                         (case when coalesce(movto.estadorebaja,0) <> 0 and coalesce(movto.preciolista,0) <> 0 then (coalesce(movto.PRECIOLISTA,1) - coalesce(MOVTO.PRECIOCONREBAJA,1))/coalesce(movto.PRECIOLISTA,1) else MOVTO.DESCUENTOPORCENTAJE end)   as DESCUENTOPORCENTAJE ,

                         MOVTO.porcentajedescuentomanual  ,
                         movto.tasaimpuesto   ,
                         /*CASE WHEN COALESCE(PARAMETRO.esvendedormovil,'N') <> 'S' or (COALESCE(PRODUCTO.MARGENMOVIL,0) = 0)  then  'NINGUNO'
                         ELSE CASE WHEN COALESCE(PRODUCTO.MARGENMOVIL,0) - COALESCE(movto.descuentoporcentaje,0) <= 2 THEN  'ROJO'
                                   WHEN COALESCE(PRODUCTO.MARGENMOVIL,0) - COALESCE(movto.descuentoporcentaje,0) > 2 and
                                        COALESCE(PRODUCTO.MARGENMOVIL,0) - COALESCE(movto.descuentoporcentaje,0) <= 3 THEN 'AMARILLO'
                                        ELSE '' END END*/
                         '' ALERTA ,
                         PRODUCTO.pzacaja ,
                         MOVTO.movtoadjuntoaid ,
                        (CASE WHEN DOCTO.TIPODOCTOID IN (301,321,322,323) AND coalesce(movto.precio,0) <> 0 then  round(100 - ((((100 * coalesce(producto.precio1,0)) - (coalesce(producto.precio1,0) * producto.margenmovil))/(100 * coalesce(movto.precio,1))) * 100), 2)  else 0 end)
                         UTILIDADMOVIL ,
                         case when coalesce(movto.estadorebaja ,0) = 1 then 'Autorizado' when coalesce(movto.estadorebaja ,0) = 2 then 'Rechazado' else 'no aplica' end AUTORIZACIONDESCNOTA  ,
                         PRODUCTO.UNIDAD ,
                         COALESCE(MOVTO.ingresopreciomanual ,'N') INGRESOPRECIOMANUAL
                                            


FROM            DOCTO INNER JOIN
                         MOVTO ON MOVTO.DOCTOID = DOCTO.ID LEFT OUTER JOIN
                         PRODUCTO ON PRODUCTO.ID = MOVTO.PRODUCTOID LEFT OUTER JOIN
                         LINEA ON LINEA.ID = PRODUCTO.LINEAID LEFT OUTER JOIN
                         PERSONA ON PERSONA.ID = DOCTO.PERSONAID LEFT OUTER JOIN
                         PRODUCTOCARACTERISTICAS ON PRODUCTOCARACTERISTICAS.PRODUCTOID = PRODUCTO.ID LEFT OUTER JOIN
                          PARAMETRO ON 1 = 1
WHERE         (MOVTO.CANTIDAD > 0)
ORDER BY MOVTO.ORDEN, MOVTO.PARTIDA
;