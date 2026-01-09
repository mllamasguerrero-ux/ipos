create or alter procedure DOCTO_RECALCULAR_PROMOMONTOMIN (
    DOCTORECALCULARID D_FK)
returns (
    HUBOMOVIMIENTOS D_BOOLCN,
    ERRORCODE D_ERRORCODE)
as
declare variable ESTATUSDOCTOID D_FK;
declare variable MOVTOID D_FK;
declare variable ALMACENID D_FK;
declare variable SUCURSALID D_FK;
declare variable PERSONAID D_FK;
declare variable TIPODOCTORECALCULARID D_FK;
declare variable PRODUCTOID D_FK;
declare variable LOTE D_LOTE;
declare variable FECHAVENCE D_FECHAVENCE;
declare variable CANTIDAD D_CANTIDAD;
declare variable PRECIO D_PRECIO;
declare variable COSTO D_COSTO;
declare variable REFERENCIA D_REFERENCIA;
declare variable REFERENCIAS varchar(255);
declare variable SERIE varchar(31);
declare variable FOLIO integer;
declare variable ALMACENTID D_FK;
declare variable SUCURSALTID D_FK;
declare variable TIPODIFERENCIAINVENTARIOID D_FK;
declare variable DESCRIPCION1 D_STDTEXT_64;
declare variable DESCRIPCION2 D_STDTEXT_64;
declare variable DESCRIPCION3 D_STDTEXT_64;
declare variable FECHADOCTO D_FECHA;
declare variable PAGOCONTARJETA D_BOOLCN_NULL;
declare variable DIASEMANA smallint;
declare variable PROMOCIONIDBUFFER D_FK;
declare variable IMPORTEPROMO D_PRECIO;
declare variable PORCPROMO D_PORCENTAJE;
declare variable ENMONEDERO D_BOOLCN;
declare variable LINEAID D_FK;
declare variable TASAIVA D_PORCENTAJE;
declare variable TASAIEPS D_PORCENTAJE;
declare variable TASAIMPUESTO D_PORCENTAJE;
declare variable SUMATOTALSINPROMO D_PRECIO;
declare variable SUMATOTALCONPROMO D_PRECIO;
declare variable PRECIOSINPROMO D_PRECIO;
declare variable PRECIOCONPROMO D_PRECIO;
declare variable PRECIOORIGINAL D_PRECIO;
declare variable TOTALORIGINAL D_PRECIO;
declare variable PRECIOLISTA D_PRECIO;
declare variable INGRESOPRECIOMANUAL D_BOOLCN;
declare variable APLICOPROMOXMONTOMIN D_BOOLCN_NULL;
declare variable IVASINPROMO D_PRECIO;
declare variable IEPSSINPROMO D_PRECIO;
declare variable IMPUESTOSINPROMO D_PRECIO;
declare variable SUBTOTALSINPROMO D_PRECIO;
declare variable IVACONPROMO D_PRECIO;
declare variable IEPSCONPROMO D_PRECIO;
declare variable IMPUESTOCONPROMO D_PRECIO;
declare variable SUBTOTALCONPROMO D_PRECIO;
declare variable TIPOMAYOREOID D_FK;
declare variable DESGLOSEIEPS type of D_BOOLCN;
declare variable PORCPROMOAPLICAR D_PORCENTAJE;
declare variable VENDEDORID D_FK;
declare variable CAJAID D_FK;
declare variable PORCPROMOAPLICAREXACTO numeric(18,5);
declare variable HABPROMOXMONTOMIN D_BOOLCN;
declare variable DESCRIPCIONLINEA D_DESCRIPCION;
BEGIN

   HUBOMOVIMIENTOS = 'N';

   SELECT FIRST 1 HABPROMOXMONTOMIN FROM PARAMETRO INTO :HABPROMOXMONTOMIN;

   IF(COALESCE(:HABPROMOXMONTOMIN,'N') = 'N') THEN
   BEGIN
        SUSPEND;
        EXIT;
   END

   -- Leer del DOCTO a cancelar.
   SELECT ESTATUSDOCTOID, TIPODOCTOID , FECHA , vendedorid, cajaid
   FROM DOCTO
   WHERE ID = :DOCTORECALCULARID
   INTO :ESTATUSDOCTOID, :TIPODOCTORECALCULARID, :FECHADOCTO, :VENDEDORID, :CAJAID;

   
   DIASEMANA = EXTRACT ( WEEKDAY FROM :FECHADOCTO);

   -- Si no esta vigente: Salir.
   IF (:ESTATUSDOCTOID <> 0) THEN
   BEGIN
      ERRORCODE = 1082;
      SUSPEND;
      EXIT;
   END

   -- Si no es de los tipos b?sicos: Salir.
   IF (:TIPODOCTORECALCULARID NOT IN (11, 21, 31, 41, 321)) THEN
   BEGIN
      ERRORCODE = 1008;
      SUSPEND;
      EXIT;
   END

   -- Leer del DOCTO a recalcular.
   SELECT ALMACENID, SUCURSALID, PERSONAID, SERIE, FOLIO, SUCURSALTID, ALMACENTID, PAGOCONTARJETA , TIPOMAYOREOID
   FROM DOCTO
   WHERE ID = :DOCTORECALCULARID
   INTO :ALMACENID, :SUCURSALID, :PERSONAID, :SERIE, :FOLIO, :SUCURSALTID, :ALMACENTID, :PAGOCONTARJETA, :TIPOMAYOREOID;


   
   SELECT DESGLOSEIEPS FROM PARAMETRO INTO :DESGLOSEIEPS;
   DESGLOSEIEPS = COALESCE(:DESGLOSEIEPS,'N');
   
   FOR SELECT FIRST 1 PROMOCION.ID
     FROM movto
     INNER JOIN PRODUCTO ON PRODUCTO.ID = MOVTO.PRODUCTOID
     INNER JOIN LINEA ON LINEA.ID = PRODUCTO.LINEAID
     INNER JOIN PROMOCION ON PROMOCION.lineaid = PRODUCTO.LINEAID
     WHERE
     MOVTO.DOCTOID =  :DOCTORECALCULARID AND
     PROMOCION.tipopromocionid = 5  AND
     (PROMOCION.rangopromocionid = 2 AND PROMOCION.lineaid = PRODUCTO.lineaid )
     AND PROMOCION.fechainicio <= CURRENT_DATE AND PROMOCION.FECHAFIN >= current_date
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

     GROUP BY
     PROMOCION.ID
   INTO
      :PROMOCIONIDBUFFER
   DO
   BEGIN

   SELECT  PROMOCION.importe,
     PROMOCION.porcentajedescuento,
     PROMOCION.enmonedero,
     PROMOCION.lineaid ,
     LINEA.nombre
     FROM PROMOCION
     LEFT JOIN LINEA ON LINEA.ID = PROMOCION.LINEAID
     WHERE PROMOCION.ID = :PROMOCIONIDBUFFER
     INTO  :IMPORTEPROMO, :PORCPROMO, :ENMONEDERO, :LINEAID, :DESCRIPCIONLINEA ;


     
    SUMATOTALSINPROMO = 0;
    SUMATOTALCONPROMO = 0;

    FOR
        SELECT MOVTO.id,  MOVTO.PRODUCTOID, MOVTO.PRECIO, MOVTO.INGRESOPRECIOMANUAL,
        MOVTO.tasaiva, MOVTO.tasaieps, MOVTO.TASAIMPUESTO , MOVTO.PRECIOLISTA,
        MOVTO.TOTAL, MOVTO.APLICOPROMOXMONTOMIN  , MOVTO.CANTIDAD ,
        MOVTO.LOTE, MOVTO.FECHAVENCE, MOVTO.COSTO,
        MOVTO.TIPODIFERENCIAINVENTARIOID , MOVTO.DESCRIPCION1, MOVTO.DESCRIPCION2, MOVTO.DESCRIPCION3

        FROM MOVTO INNER JOIN PRODUCTO ON MOVTO.PRODUCTOID = PRODUCTO.id
        WHERE MOVTO.DOCTOID = :DOCTORECALCULARID
        AND PRODUCTO.LINEAID = :LINEAID
        INTO :MOVTOID, :PRODUCTOID, :PRECIOORIGINAL, :INGRESOPRECIOMANUAL ,
        :TASAIVA, :TASAIEPS, :TASAIMPUESTO, :PRECIOLISTA ,
        :TOTALORIGINAL, :APLICOPROMOXMONTOMIN   , :CANTIDAD ,
        :LOTE, :FECHAVENCE, :COSTO,
        :TIPODIFERENCIAINVENTARIOID , :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3
        DO
        BEGIN


            -- afinacion de tasas
            TASAIVA = COALESCE(:TASAIVA, 0);

            IF(:DESGLOSEIEPS = 'N') then
            BEGIN
                TASAIEPS = 0.00;
            END
            ELSE
            BEGIN
                TASAIEPS = COALESCE(:TASAIEPS, 0);
            END



           IF(COALESCE(:INGRESOPRECIOMANUAL, 'N') = 'S'  ) THEN
           BEGIN
                PRECIOSINPROMO = :PRECIOORIGINAL;
                PRECIOCONPROMO = :PRECIOORIGINAL;
                SUMATOTALSINPROMO = :SUMATOTALSINPROMO + :TOTALORIGINAL;
                SUMATOTALCONPROMO = :SUMATOTALCONPROMO + :TOTALORIGINAL;

           END
           ELSE
           BEGIN
                --SIN PROMO
                IF(COALESCE(:APLICOPROMOXMONTOMIN, 'N') = 'N')THEN
                BEGIN  
                    PRECIOSINPROMO = :PRECIOORIGINAL; 
                    SUMATOTALSINPROMO = :SUMATOTALSINPROMO + :TOTALORIGINAL;
                END
                ELSE
                BEGIN

                    
                     SELECT ERRORCODE
                     FROM MOVTO_INSERT (
                                           :DOCTORECALCULARID, 0, :ALMACENID, :SUCURSALID, :TIPODOCTORECALCULARID, 0, 0, :PERSONAID, :VENDEDORID, :CAJAID,
                                           0, :PRODUCTOID, :LOTE, :FECHAVENCE, 0, 0, 0, 0, 0, NULL/*:PRECIOSINPROMO*/ , 0,
                                           '',  '', :COSTO, :SUCURSALID, :ALMACENID, 'N',
                                           :TIPODIFERENCIAINVENTARIOID, CURRENT_DATE, CURRENT_DATE, null,NULL ,NULL,NULL,:MOVTOID,NULL , :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3 , 'N'
                                        ) INTO :ERRORCODE;
                                        
                     IF(:ERRORCODE <> 0) THEN
                     BEGIN
                                            SUSPEND;
                                            EXIT;
                     END
                     HUBOMOVIMIENTOS = 'S';

                     
                     UPDATE MOVTO SET  APLICOPROMOXMONTOMIN = 'N'--, INGRESOPRECIOMANUAL = 'N'
                     WHERE ID = :MOVTOID;

                     SELECT SUBTOTAL, IVA, IEPS , PRECIO
                     FROM MOVTO
                     WHERE ID = :MOVTOID
                     INTO :SUBTOTALSINPROMO, :IVASINPROMO, :IEPSSINPROMO, :PRECIOSINPROMO;



                     IMPUESTOSINPROMO = IVASINPROMO + IEPSSINPROMO;
                     SUMATOTALSINPROMO = :SUMATOTALSINPROMO + :SUBTOTALSINPROMO + :IMPUESTOSINPROMO;

                END


                --CONPROMO
                     PRECIOCONPROMO = :PRECIOLISTA * (1 - (:PORCPROMO /100));


                     IF(:PRECIOCONPROMO > :PRECIOSINPROMO) then
                     BEGIN
                        PRECIOCONPROMO = :PRECIOSINPROMO;
                     END

                     SUBTOTALCONPROMO = :CANTIDAD * :PRECIOCONPROMO;

                     IF (:TASAIEPS > 0.00) THEN
                       IEPSCONPROMO =   :SUBTOTALCONPROMO * (:TASAIEPS / 100.00);
                     ELSE
                       IEPSCONPROMO = 0.00;

                     IF (:TASAIVA > 0.00) THEN
                       IVACONPROMO = (:SUBTOTALCONPROMO * ( 1 + (:TASAIEPS / 100.00))) * (:TASAIVA / 100.00);
                     ELSE
                       IVACONPROMO = 0.00;

                     IMPUESTOCONPROMO = IVACONPROMO + IEPSCONPROMO;
                     SUMATOTALCONPROMO = :SUMATOTALCONPROMO + :SUBTOTALCONPROMO + :IMPUESTOCONPROMO;



           END
        END



        IF(:SUMATOTALSINPROMO > COALESCE(:IMPORTEPROMO,0) AND COALESCE(:IMPORTEPROMO,0) > 0
           AND :SUMATOTALSINPROMO > :SUMATOTALCONPROMO) THEN
        BEGIN


             PORCPROMOAPLICAREXACTO = COALESCE(:PORCPROMO,0);


             /*
             IF( :SUMATOTALCONPROMO  <  COALESCE(:IMPORTEPROMO,0)) THEN
             BEGIN

                PORCPROMOAPLICAREXACTO = COALESCE(:PORCPROMO,0) *
                                    (1.0000 -  (( COALESCE(:IMPORTEPROMO,0) - :SUMATOTALCONPROMO ) /  (:SUMATOTALSINPROMO - :SUMATOTALCONPROMO) )
                                    );

                -- asegurarse de que el monto de la suma sea un poquito menor del limite
                PORCPROMOAPLICAREXACTO = :PORCPROMOAPLICAREXACTO + 0.1;


                 -- hay que redondear al 2 decimal ceiling
                 --PORCPROMOAPLICAR = (CEIL(:PORCPROMOAPLICAREXACTO * 100.0))/100 ;



             END   */





             FOR
                    SELECT MOVTO.id,  MOVTO.PRODUCTOID, MOVTO.PRECIO, MOVTO.INGRESOPRECIOMANUAL,
                    MOVTO.tasaiva, MOVTO.tasaieps, MOVTO.TASAIMPUESTO , MOVTO.PRECIOLISTA,
                    MOVTO.TOTAL, MOVTO.APLICOPROMOXMONTOMIN  , MOVTO.CANTIDAD,
                    MOVTO.LOTE, MOVTO.FECHAVENCE, MOVTO.COSTO,
                    MOVTO.TIPODIFERENCIAINVENTARIOID , MOVTO.DESCRIPCION1, MOVTO.DESCRIPCION2, MOVTO.DESCRIPCION3
                    FROM MOVTO
                    INNER JOIN PRODUCTO ON MOVTO.PRODUCTOID = PRODUCTO.id
                    WHERE MOVTO.DOCTOID = :DOCTORECALCULARID
                    AND PRODUCTO.LINEAID = :LINEAID
                    INTO :MOVTOID, :PRODUCTOID, :PRECIOORIGINAL, :INGRESOPRECIOMANUAL ,
                    :TASAIVA, :TASAIEPS, :TASAIMPUESTO, :PRECIOLISTA ,
                    :TOTALORIGINAL, :APLICOPROMOXMONTOMIN   , :CANTIDAD,
                    :LOTE, :FECHAVENCE, :COSTO,
                    :TIPODIFERENCIAINVENTARIOID , :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3
                    DO
                    BEGIN


                       IF(COALESCE(:INGRESOPRECIOMANUAL, 'N') <> 'S'  ) THEN
                       BEGIN



                            --SIN PROMO
                            IF(COALESCE(:APLICOPROMOXMONTOMIN, 'N') = 'N')THEN
                            BEGIN
                                PRECIOSINPROMO = :PRECIOORIGINAL;
                            END
                            ELSE
                            BEGIN
                                 SELECT PRECIO, ERRORCODE
                                 FROM GET_PRODUCTO_PRECIO(:PRODUCTOID, :PERSONAID, :CANTIDAD, :PAGOCONTARJETA, :TIPOMAYOREOID)
                                 INTO :PRECIOSINPROMO, :ERRORCODE;
                            END
             
                            --PRECIOCONPROMO = :PRECIOLISTA * (1 - (:PORCPROMO /100));


             
             
                            --CONPROMO
                                 PRECIOCONPROMO = :PRECIOLISTA * (1 - (:PORCPROMOAPLICAREXACTO /100));

             
                                 IF(:PRECIOCONPROMO < :PRECIOSINPROMO) then
                                 BEGIN

                                        -- LLAMAR MOVTO INSERT
                                 
                                        SELECT ERRORCODE
                                        FROM MOVTO_INSERT (
                                           :DOCTORECALCULARID, 0, :ALMACENID, :SUCURSALID, :TIPODOCTORECALCULARID, 0, 0, :PERSONAID, :VENDEDORID, :CAJAID,
                                           0, :PRODUCTOID, :LOTE, :FECHAVENCE, 0, 0, 0, 0, 0, :PRECIOCONPROMO, 0,
                                           '',  '', :COSTO, :SUCURSALID, :ALMACENID, 'N',
                                           :TIPODIFERENCIAINVENTARIOID, CURRENT_DATE, CURRENT_DATE, null,NULL ,NULL,NULL,:MOVTOID,NULL , :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3 , 'S'
                                        ) INTO :ERRORCODE;




                                         IF(:ERRORCODE <> 0) THEN
                                         BEGIN
                                            SUSPEND;
                                            EXIT;
                                          END   
                                        HUBOMOVIMIENTOS = 'S';

                                          UPDATE MOVTO SET  APLICOPROMOXMONTOMIN = 'S', INGRESOPRECIOMANUAL = 'N',
                                          PROMOCION = 'S', PROMOCIONID =  :PROMOCIONIDBUFFER ,
                                          PROMOCIONDESGLOSE = SUBSTRING(
                                                                ('DESC ' || CAST( :PORCPROMO AS VARCHAR(10))
                                                             || ' MONTO SUP. A ' ||  CAST(:IMPORTEPROMO AS VARCHAR(10))
                                                             || ' LINEA ' || COALESCE(:DESCRIPCIONLINEA,''))
                                                             from 1 FOR 63)
                                          WHERE ID = :MOVTOID;


                                   END


             
                       END
                    END




            
        END






   END




   ERRORCODE = 0;
   SUSPEND;
   
    /*WHEN ANY DO
    BEGIN
        ERRORCODE = 1009;
        SUSPEND;
    END*/
END