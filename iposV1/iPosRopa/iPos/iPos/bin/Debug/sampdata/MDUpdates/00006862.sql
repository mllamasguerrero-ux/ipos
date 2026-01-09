create or alter procedure GET_PROMO_PRECIO (
    PRODUCTOID D_FK,
    PERSONAID D_FK,
    CANTIDAD D_CANTIDAD,
    PRECIO1 D_PRECIO,
    PRECIOPREVIO D_PRECIO,
    HABPROMOCIONBODEGAZO D_BOOLCN,
    PAGOCONTARJETA D_CHAR)
returns (
    PRECIOPROMO D_PRECIO,
    ESPROMOCION D_BOOLCN,
    PROMOCIONID D_FK,
    PROMOCIONDESGLOSE D_STDTEXT_64,
    MONEDEROABONO D_PRECIO,
    ERRORCODE D_ERRORCODE)
as
declare variable DIASEMANA smallint;
declare variable CANTIDADLLEVATE D_CANTIDAD;
declare variable CANTIDADPROMO D_CANTIDAD;
declare variable TIPOPROMOCIONID D_FK;
declare variable IMPORTEPROMO D_PRECIO;
declare variable PORCPROMO D_PORCENTAJE;
declare variable PRECIOACTUAL D_PRECIO;
declare variable CANTIDADPROMOPORAPLICACION D_CANTIDAD;
declare variable NUMAPLICACIONES D_CANTIDAD;
declare variable APLICADOSRESIDUALES D_CANTIDAD;
declare variable CANTIDADCONPROMO D_CANTIDAD;
declare variable CANTIDADSINPROMO D_CANTIDAD;
declare variable PRECIOBUFFER D_PRECIO;
declare variable PRECIOSINPROMO D_PRECIO;
declare variable PROMOCIONIDBUFFER D_FK;
declare variable PRECIOBUFFERPROMO D_PRECIO;
declare variable ENMONEDERO D_BOOLCN;
declare variable TASAIVA D_PORCENTAJE;
declare variable TASAIEPS D_PORCENTAJE;
declare variable TASAIMPUESTO D_PORCENTAJE;
declare variable COSTO D_PRECIO;
declare variable LISTAPRECIOCLIENTE D_FK;
declare variable MONEDEROLISTAPRECIOID D_FK;
declare variable MONEDEROCAMPOREF D_CLAVE_NULL;
declare variable SKIPLOOP D_BOOLCN;     
declare variable COMISIONPORTARJETA D_PRECIO;
BEGIN



     DIASEMANA = EXTRACT ( WEEKDAY FROM CURRENT_DATE);
     --0  = DOMINGO
     PRECIOACTUAL = :PRECIOPREVIO;

     PRECIOPROMO = :PRECIOPREVIO;
     ESPROMOCION = 'N';
     PROMOCIONID = NULL;
     PROMOCIONDESGLOSE = NULL;
     MONEDEROABONO = 0;

     
     IF(COALESCE(:PAGOCONTARJETA,'N') IN ('S','D','C')) THEN
     BEGIN
        SELECT CASE WHEN COALESCE(:PAGOCONTARJETA,'N') = 'D' THEN
                        COMISIONDEBPORTARJETA
                 ELSE   COMISIONPORTARJETA
               END FROM PARAMETRO INTO :COMISIONPORTARJETA;
     END
     ELSE
     BEGIN
        COMISIONPORTARJETA = 0;
     END

     
   FOR SELECT PROMOCION.ID,
     PROMOCION.CANTIDADLLEVATE,
     PROMOCION.cantidad,
     PROMOCION.tipopromocionid,
     PROMOCION.importe,
     PROMOCION.porcentajedescuento,
     PROMOCION.enmonedero,
     COALESCE(PRODUCTO.TASAIVA,0) ,   
     COALESCE(PRODUCTO.TASAIEPS,0) ,
     COALESCE(PRODUCTO.TASAIMPUESTO,0) ,
     PRODUCTO.costoreposicion
     FROM PROMOCION
     LEFT JOIN PRODUCTO ON :PRODUCTOID = PRODUCTO.id   
        LEFT JOIN
            (SELECT
                PROMOCION.id PROMOCIONID,
                SUM(CASE WHEN COALESCE(PROMOCIONSUCURSAL.sucursalid,0) = COALESCE(PARAMETRO.sucursalid,0) THEN 1 ELSE 0 END) APLICAENSUCURSAL,
                SUM(CASE WHEN COALESCE(PROMOCIONSUCURSAL.sucursalid,0) <> 0 THEN 1 ELSE 0 END) SUCURSALESDONDEAPLICA
                FROM PROMOCION
                LEFT JOIN PROMOCIONSUCURSAL ON PROMOCION.ID = PROMOCIONSUCURSAL.promocionid
                LEFT JOIN PARAMETRO ON 1 = 1
                GROUP BY PROMOCION.ID
                ) PROMOSUC ON PROMOSUC.PROMOCIONID = PROMOCION.ID
     WHERE
     ((PROMOCION.rangopromocionid = 1 AND PROMOCION.productoid = :PRODUCTOID) OR
     (PROMOCION.rangopromocionid = 2 AND PROMOCION.lineaid = PRODUCTO.lineaid /*AND PRODUCTO.id = :PRODUCTOID*/) or
      PROMOCION.TIPOPROMOCIONID = 7 )
     AND PROMOCION.fechainicio <= CURRENT_DATE AND PROMOCION.FECHAFIN >= current_date
     AND (PROMOCION.tipopromocionid <> 7 or  COALESCE(:HABPROMOCIONBODEGAZO,'N') = 'S'  )
     AND
     (
     (PROMOCION.lunes = 'S' AND :DIASEMANA = 1 ) or
     (PROMOCION.martes = 'S' AND :DIASEMANA = 2 ) or
     (PROMOCION.miercoles = 'S' AND :DIASEMANA = 3 ) or
     (PROMOCION.jueves = 'S' AND :DIASEMANA = 4 ) or
     (PROMOCION.viernes = 'S' AND :DIASEMANA =5 ) or
     (PROMOCION.sabado = 'S' AND :DIASEMANA = 6 ) or
     (PROMOCION.domingo = 'S' AND :DIASEMANA = 0 )

     )
     AND PROMOCION.activo = 'S' 
        AND (COALESCE( PROMOSUC.SUCURSALESDONDEAPLICA ,0) = 0 OR COALESCE(PROMOSUC.APLICAENSUCURSAL,0) > 0)
        AND COALESCE(PROMOCION.esmultidetalle,'N') <> 'S'
   INTO
      :PROMOCIONIDBUFFER, :CANTIDADLLEVATE, :CANTIDADPROMO,
      :tipopromocionid, :IMPORTEPROMO, :PORCPROMO, :ENMONEDERO, :TASAIVA, :TASAIEPS, :TASAIMPUESTO, :COSTO
   DO
   BEGIN
        SKIPLOOP = 'N';


       --VALIDATE MONEDERO
       IF(COALESCE(:ENMONEDERO,'N') = 'S' ) THEN
       BEGIN
          SELECT FIRST 1 COALESCE(MONEDEROLISTAPRECIOID,0), COALESCE(MONEDEROCAMPOREF,'') FROM PARAMETRO INTO :MONEDEROLISTAPRECIOID, :MONEDEROCAMPOREF;
          SELECT FIRST 1 PERSONA.listaprecioid FROM PERSONA WHERE ID = :PERSONAID INTO :LISTAPRECIOCLIENTE;

          IF(:MONEDEROLISTAPRECIOID <> 0 AND :MONEDEROLISTAPRECIOID <  COALESCE(:LISTAPRECIOCLIENTE,1)) THEN
          BEGIN
             SKIPLOOP = 'S';
          END
       END


       IF(COALESCE(:SKIPLOOP,'N') = 'N') THEN
       BEGIN
        IF(:TIPOPROMOCIONID = 1) THEN
        BEGIN
            IF(:CANTIDAD >= :CANTIDADPROMO) THEN
            BEGIN
                CANTIDADPROMOPORAPLICACION = :CANTIDADLLEVATE - :CANTIDADPROMO;
                NUMAPLICACIONES = FLOOR(:CANTIDAD/:CANTIDADLLEVATE);
                APLICADOSRESIDUALES = :CANTIDAD - (:CANTIDADLLEVATE * :NUMAPLICACIONES) - :CANTIDADPROMO;
                IF(:APLICADOSRESIDUALES < 0) THEN
                BEGIN
                    APLICADOSRESIDUALES = 0;
                END
                CANTIDADCONPROMO = (:NUMAPLICACIONES * :CANTIDADPROMOPORAPLICACION ) + :APLICADOSRESIDUALES;
                CANTIDADSINPROMO = :CANTIDAD - :CANTIDADCONPROMO;
                PRECIOBUFFER = (:CANTIDADSINPROMO * :PRECIO1)/:CANTIDAD;

                -- PRECIO CON COMISION
                PRECIOBUFFER = :PRECIOBUFFER * ((100.00 + COALESCE(:COMISIONPORTARJETA,0.00))/100.00) ;

                IF( :PRECIOBUFFER < :PRECIOACTUAL) THEN
                BEGIN
                   PRECIOACTUAL = :PRECIOBUFFER;
                   ESPROMOCION = 'S';
                   PROMOCIONID = :PROMOCIONIDBUFFER;
                   PROMOCIONDESGLOSE = 'GRATIS ' || CAST(:CANTIDADCONPROMO AS VARCHAR(10))
                                     || ' Y CON PRECIO ' ||  CAST(:PRECIO1 AS VARCHAR(10))
                                     || ' ' || CAST(:CANTIDADSINPROMO AS VARCHAR(10));
                                     
                   MONEDEROABONO = 0;
                END

            END
        END
        ELSE IF (:TIPOPROMOCIONID = 2) THEN
        BEGIN
            IF(:CANTIDAD >= :CANTIDADPROMO) THEN
            BEGIN

                PRECIOBUFFERPROMO = (:IMPORTEPROMO/((100.00 + :TASAIMPUESTO)/100.00))/:CANTIDADPROMO;

                --INSERT INTO TRAZA(VALOR) VALUES (CAST(:PRECIOBUFFERPROMO AS VARCHAR(10)));

                NUMAPLICACIONES = FLOOR(:CANTIDAD/:CANTIDADPROMO);
                CANTIDADCONPROMO = :NUMAPLICACIONES * :CANTIDADPROMO;
                CANTIDADSINPROMO = :CANTIDAD - :CANTIDADCONPROMO;
                PRECIOBUFFER = ((PRECIOBUFFERPROMO * CANTIDADCONPROMO) + (:PRECIO1 * :CANTIDADSINPROMO))/:CANTIDAD;
                 
                -- PRECIO CON COMISION
                PRECIOBUFFER = :PRECIOBUFFER * ((100.00 + COALESCE(:COMISIONPORTARJETA,0.00))/100.00) ;
                    
                --INSERT INTO TRAZA(VALOR) VALUES (CAST(:PRECIOBUFFER AS VARCHAR(10)));

                IF( :PRECIOBUFFER < :PRECIOACTUAL) THEN
                BEGIN
                   PRECIOACTUAL = :PRECIOBUFFER;
                   ESPROMOCION = 'S';
                   PROMOCIONID = :PROMOCIONIDBUFFER;
                   PROMOCIONDESGLOSE = 'CON PRECIO ' || CAST(PRECIOBUFFERPROMO AS VARCHAR(10))
                                     || ' ' || CAST(:CANTIDADCONPROMO AS VARCHAR(10))
                                     || ' Y CON PRECIO ' ||  CAST(:PRECIO1 AS VARCHAR(10))
                                     || ' ' || CAST(:CANTIDADSINPROMO AS VARCHAR(10));  
                   MONEDEROABONO = 0;
                END

            END
        END 
        ELSE IF (:TIPOPROMOCIONID = 3) THEN
        BEGIN
                PRECIOBUFFER =  (:PRECIO1 * :CANTIDAD * (1.00 - (COALESCE(:PORCPROMO,0)/100.00)))/:CANTIDAD;

                -- PRECIO CON COMISION
                PRECIOBUFFER = :PRECIOBUFFER * ((100.00 + COALESCE(:COMISIONPORTARJETA,0.00))/100.00) ;

                IF( :PRECIOBUFFER < :PRECIOACTUAL) THEN
                BEGIN
                    IF(COALESCE(:ENMONEDERO,'N') <> 'S' ) THEN
                    BEGIN

                        PRECIOACTUAL = :PRECIOBUFFER;
                        ESPROMOCION = 'S';
                        PROMOCIONID = :PROMOCIONIDBUFFER;
                        PROMOCIONDESGLOSE = 'GRATIS ' || CAST(:CANTIDADCONPROMO AS VARCHAR(10))
                                     || ' Y CON PRECIO ' ||  CAST(:PRECIO1 AS VARCHAR(10))
                                     || ' ' || CAST(:CANTIDADSINPROMO AS VARCHAR(10));
                        MONEDEROABONO = 0;
                   END
                   ELSE
                   BEGIN

                        MONEDEROABONO =   (:PRECIO1 - :PRECIOBUFFER)*:CANTIDAD;

                        IF(COALESCE(:MONEDEROCAMPOREF,'') = 'TOTAL') THEN
                        BEGIN
                            MONEDEROABONO  = CAST((:MONEDEROABONO * ( 1 + (COALESCE(:TASAIEPS,0) / 100.00))) * (1 + (COALESCE(:TASAIVA,0) / 100.00)) AS D_IMPORTE);
                        END

                        ESPROMOCION = 'S';
                        PROMOCIONID = :PROMOCIONIDBUFFER;     
                        --INSERT INTO TRAZA(VALOR) VALUES (CAST(:PRECIOBUFFER AS VARCHAR(10)));
                        PROMOCIONDESGLOSE = 'APLICADO A MONEDERO :' || CAST(:MONEDEROABONO AS VARCHAR(10)) ;
                   END
                END
                    
        END   
        ELSE IF (:TIPOPROMOCIONID = 6) THEN
        BEGIN
            IF(:CANTIDAD >= :CANTIDADPROMO) THEN
            BEGIN

                PRECIOBUFFERPROMO = (:IMPORTEPROMO/((100.00 + :TASAIMPUESTO)/100.00))/:CANTIDADPROMO;

                PRECIOBUFFER = PRECIOBUFFERPROMO ;
                
                -- PRECIO CON COMISION
                PRECIOBUFFER = :PRECIOBUFFER * ((100.00 + COALESCE(:COMISIONPORTARJETA,0.00))/100.00) ;
                    
                --INSERT INTO TRAZA(VALOR) VALUES (CAST(:PRECIOBUFFER AS VARCHAR(10)));

                IF( :PRECIOBUFFER < :PRECIOACTUAL) THEN
                BEGIN
                   PRECIOACTUAL = :PRECIOBUFFER;
                   ESPROMOCION = 'S';
                   PROMOCIONID = :PROMOCIONIDBUFFER;
                   PROMOCIONDESGLOSE = 'CON PRECIO ' || CAST(PRECIOBUFFERPROMO AS VARCHAR(10))
                                     || ' ' || CAST(:CANTIDADCONPROMO AS VARCHAR(10));
                   MONEDEROABONO = 0;
                END

            END
        END
        
        IF(:TIPOPROMOCIONID = 7 ) THEN
        BEGIN

                if((1.00 - (COALESCE(:PORCPROMO,0)/100.00)) > 0) then
                BEGIN
                    PRECIOBUFFER =  ( coalesce(:COSTO,0) /  (1.00 - (COALESCE(:PORCPROMO,0)/100.00)));
                    --INSERT INTO TRAZA(VALOR) VALUES ( 'TE 1' || CAST(:COSTO AS VARCHAR(12)));
                    --INSERT INTO TRAZA(VALOR) VALUES ( 'TE 2' || CAST(:PORCPROMO AS VARCHAR(12)));
                END
                else
                BEGIN
                    PRECIOBUFFER = :PRECIOACTUAL ;
                END
                
                -- PRECIO CON COMISION
                PRECIOBUFFER = :PRECIOBUFFER * ((100.00 + COALESCE(:COMISIONPORTARJETA,0.00))/100.00) ;

                IF( :PRECIOBUFFER < :PRECIOACTUAL) THEN
                BEGIN


                    IF(COALESCE(:ENMONEDERO,'N') <> 'S' ) THEN
                    BEGIN

                        PRECIOACTUAL = :PRECIOBUFFER;
                        ESPROMOCION = 'S';
                        PROMOCIONID = :PROMOCIONIDBUFFER;
                        PROMOCIONDESGLOSE = 'GRATIS ' || CAST(:CANTIDADCONPROMO AS VARCHAR(10))
                                     || ' Y CON PRECIO ' ||  CAST(:PRECIO1 AS VARCHAR(10))
                                     || ' ' || CAST(:CANTIDADSINPROMO AS VARCHAR(10));
                        MONEDEROABONO = 0;
                   END
                   ELSE
                   BEGIN

                        MONEDEROABONO =   (:PRECIO1 - :PRECIOBUFFER)*:CANTIDAD;    

                        IF(COALESCE(:MONEDEROCAMPOREF,'') = 'TOTAL') THEN
                        BEGIN
                            MONEDEROABONO  = CAST((:MONEDEROABONO * ( 1 + (COALESCE(:TASAIEPS,0) / 100.00))) * (1 + (COALESCE(:TASAIVA,0) / 100.00)) AS D_IMPORTE);
                        END

                        ESPROMOCION = 'S';
                        PROMOCIONID = :PROMOCIONIDBUFFER;     
                        --INSERT INTO TRAZA(VALOR) VALUES (CAST(:PRECIOBUFFER AS VARCHAR(10)));
                        PROMOCIONDESGLOSE = 'APLICADO  A  MONEDERO ' || CAST(:MONEDEROABONO AS VARCHAR(10)) ;
                   END
                END
        END
     END
   END



  
    PRECIOPROMO = PRECIOACTUAL;




   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1051;
      SUSPEND;
   END 
END
