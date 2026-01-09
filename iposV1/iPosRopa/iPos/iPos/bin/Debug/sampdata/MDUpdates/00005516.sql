create or alter procedure KIT_CREARREFERENCIA (
    DOCTOIDPARALLENAR D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable DOCTOIDFORKIT D_FK;
declare variable MOVTOID D_FK;
declare variable ALMACENID D_FK;
declare variable CAJAID D_FK;
declare variable SUCURSALID D_FK;
declare variable PRODUCTOID D_FK;
declare variable LOTE D_LOTE;
declare variable FECHAVENCE D_FECHAVENCE;
declare variable CANTIDAD D_CANTIDAD;
declare variable CANTIDADSURTIDA D_CANTIDAD;
declare variable CANTIDADFALTANTE D_CANTIDAD;
declare variable CANTIDADDIFERENCIA D_CANTIDAD;
declare variable ESTATUSDOCTOID D_FK;
declare variable FALTANTES integer;
declare variable REFERENCIA D_REFERENCIA;
declare variable COSTO D_COSTO;
declare variable SUCURSALTID D_FK;
declare variable ALMACENTID D_FK;
declare variable TIPODIFERENCIAINVENTARIOID D_FK;
declare variable TIPODOCTOID D_FK;
declare variable PERSONAID D_FK;
declare variable VENDEDORID D_FK;
declare variable DESCRIPCION1 D_STDTEXT_64;
declare variable DESCRIPCION2 D_STDTEXT_64;
declare variable DESCRIPCION3 D_STDTEXT_64;
declare variable TIPODOCTOIDFORKIT D_FK;
declare variable ORIGENFISCALID D_FK;
declare variable MOVTOREFID D_FK;
declare variable CUENTAKITS integer;
declare variable CANTIDADFINAL D_CANTIDAD;
declare variable PRORRATEO numeric(18,4);
declare variable SUMATOTALCOSTOCONIMPUESTO D_PORCENTAJE;
declare variable TOTAL D_PRECIO;
declare variable SUBTOTAL D_PRECIO;
declare variable DETALLEKITTASAIVA D_PORCENTAJE;
declare variable DETALLEKITTASAIEPS D_PORCENTAJE;
declare variable DETALLEKITTASAIMPUESTO D_PORCENTAJE;
declare variable DETALLEKITTOTAL D_PRECIO;
declare variable DETALLEKITSUBTOTAL D_PRECIO;
declare variable DETALLEKITIVA D_PRECIO;
declare variable DETALLEKITIEPS D_PRECIO;
declare variable DETALLEKITPRECIO D_PRECIO;
declare variable DETALLEKITPRECIOLISTA D_PRECIO;
declare variable DETALLEKITPRODUCTOID D_FK;
declare variable DOCTOREFID D_FK;
declare variable DOCTOREFKITID D_FK;
declare variable MOVTOPARENTREFID D_FK;
declare variable DOCTOKITPARENTREFID D_FK;
declare variable SENTIDOINVENTARIO D_SENTIDO;
declare variable LOTEIMPORTADO D_FK;
declare variable TASAIEPSPARTE D_DECIMAL_EXACT;
declare variable TASAIVAPARTE D_DECIMAL_EXACT;
declare variable TASASUBTOTALPARTE D_DECIMAL_EXACT;
declare variable VERSIONKIT D_INTEGER;
BEGIN

   ERRORCODE = 0;
   MOVTOPARENTREFID = 0;
   DOCTOKITPARENTREFID = 0;


   SELECT TIPODOCTOID, ESTATUSDOCTOID  , ALMACENID, SUCURSALID, CAJAID, PERSONAID  ,VENDEDORID, ORIGENFISCALID , TIPODOCTO.sentidoinventario , DOCTOREFID
   FROM DOCTO LEFT JOIN TIPODOCTO ON DOCTO.TIPODOCTOID = TIPODOCTO.ID
   WHERE DOCTO.ID = :DOCTOIDPARALLENAR
   INTO :TIPODOCTOID, :ESTATUSDOCTOID ,:ALMACENID, :SUCURSALID, :CAJAID, :PERSONAID, :VENDEDORID, :ORIGENFISCALID, :SENTIDOINVENTARIO, :DOCTOREFID;

   
   IF ((:DOCTOIDPARALLENAR IS NULL) OR (:DOCTOIDPARALLENAR = 0)) THEN
   BEGIN
      ERRORCODE = 1073;
      SUSPEND;
      EXIT;
   END

   -- Interceptar docto no existente
   IF ((:TIPODOCTOID IS NULL) OR (:ESTATUSDOCTOID IS NULL)) THEN
   BEGIN
      ERRORCODE = 10710;
      SUSPEND;
      EXIT;
   END



   -- Solo admitir TipoDocto = 50, captura de inventario fisico.
   IF ( COALESCE(:SENTIDOINVENTARIO,0) = 0 or :TIPODOCTOID IN (501,502,503,504)  /*:TIPODOCTOID NOT IN (11,21,25,31,41,321 , 12,13, 15,22,23,24,26,32,33,42,43,322,323, 211,213)*/) THEN
   BEGIN
      ERRORCODE = 4007;
      SUSPEND;
      EXIT;
   END          


   -- Solo admitir EstatusDocto = 0, Borrador.
   IF (:ESTATUSDOCTOID != 1 ) THEN
   BEGIN
      ERRORCODE = 1072;
      SUSPEND;
      EXIT;
   END


        
     -- CHECAR SI HAY KITS A REFERENCIAR
   SELECT COUNT(*)
    FROM MOVTO M
     LEFT JOIN DOCTO D
       ON D.ID = M.DOCTOID
       LEFT JOIN PRODUCTO ON PRODUCTO.id = M.PRODUCTOID
   WHERE M.DOCTOID = :DOCTOIDPARALLENAR  AND COALESCE(PRODUCTO.ESKIT, 'N') = 'S'
      AND (M.CANTIDAD > 0)
    INTO :CUENTAKITS;

    IF(coalesce(:CUENTAKITS,0) <= 0) THEN
    BEGIN
      ERRORCODE = 0;
      SUSPEND;
      EXIT;
    END




   -- Inicializara para primer registro de movto
   DOCTOIDFORKIT = 0;
   TIPODOCTOIDFORKIT = 505;
                  







    SELECT DOCTOID, ERRORCODE
      FROM DOCTO_INSERT (
         :VENDEDORID,
         :ALMACENID,
         :SUCURSALID,
         :TIPODOCTOIDFORKIT,
         0,
         0,
         :PERSONAID,
         :VENDEDORID,
         :CAJAID,
         :REFERENCIA,
         '',
         0,
         :ALMACENID,
         CURRENT_DATE,
         CURRENT_DATE,
         :DOCTOIDPARALLENAR ,
         'S' ,
         :ORIGENFISCALID
      ) INTO :DOCTOIDFORKIT, :ERRORCODE;



      
     IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
     BEGIN
            --insert into traza(valor) values('kkl. ' || cast(:productoid as varchar(10)));
               SUSPEND;
               EXIT;
     END


     --determinar la version del kit
     IF (:TIPODOCTOID IN (12,13, 15,22,23,24,26,32,33,42,43,322,323)) THEN
     BEGIN
            SELECT DOCTO.doctokitrefid FROM DOCTO WHERE ID = :DOCTOREFID INTO :DOCTOKITPARENTREFID;
     END
     IF (:TIPODOCTOID IN (11,21,25,31,41,321) OR COALESCE(:DOCTOKITPARENTREFID,0) = 0) THEN
     BEGIN
        UPDATE DOCTO SET VERSIONKIT = 2 WHERE ID IN (:DOCTOIDFORKIT, :DOCTOIDPARALLENAR) ;
     END




   -- Agrega un MOVTO para cada registro con diferencia
   -- entre CANTIDAD y CANTIDADSURTIDA
   FOR SELECT
      M.PRODUCTOID,
      M.LOTE,
      M.FECHAVENCE,
      COALESCE(M.CANTIDAD,0)  ,
      0,
      0,
      M.COSTO,
      M.TIPODIFERENCIAINVENTARIOID,
      D.PERSONAID  ,
      D.VENDEDORID ,
      M.DESCRIPCION1,
      M.DESCRIPCION2,
      M.DESCRIPCION3  ,
      M.id  ,
      M.total,
      M.subtotal ,
      D.DOCTOREFID ,
      M.movtorefid ,
      M.LOTEIMPORTADO
   FROM MOVTO M
     LEFT JOIN DOCTO D
       ON D.ID = M.DOCTOID
       LEFT JOIN PRODUCTO ON PRODUCTO.id = M.PRODUCTOID
   WHERE M.DOCTOID = :DOCTOIDPARALLENAR  AND COALESCE(PRODUCTO.ESKIT, 'N') = 'S'
      AND (M.CANTIDAD > 0)
      ORDER BY M.partida
   INTO
      :PRODUCTOID, :LOTE, :FECHAVENCE,
      :CANTIDAD, :CANTIDADSURTIDA, :CANTIDADFALTANTE,
      :COSTO, :TIPODIFERENCIAINVENTARIOID, :PERSONAID , :VENDEDORID  , :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3 , :MOVTOREFID ,
      :TOTAL, :SUBTOTAL, :DOCTOREFID , :MOVTOPARENTREFID, :LOTEIMPORTADO
   DO
   BEGIN
       --INSERT INTO TRAZA(VALOR) VALUES('dref11: ' || cast(COALESCE(:DOCTOREFID,0) AS VARCHAR(10)) || ' dllena: ' || cast(COALESCE(:DOCTOIDPARALLENAR,0) AS VARCHAR(10)));
       IF (:TIPODOCTOID IN (12,13, 15,22,23,24,26,32,33,42,43,322,323)) THEN
       BEGIN

            SELECT DOCTO.doctokitrefid FROM DOCTO WHERE ID = :DOCTOREFID INTO :DOCTOKITPARENTREFID;
          
            IF(COALESCE(:MOVTOPARENTREFID,0) = 0 ) THEN
            BEGIN
                SELECT FIRST 1 MOVTO.ID FROM MOVTO WHERE MOVTO.DOCTOID = :DOCTOREFID AND MOVTO.PRODUCTOID = :PRODUCTOID INTO :MOVTOPARENTREFID;
            END

        END

        
    IF (:TIPODOCTOID IN (11,21,25,31,41,321) OR COALESCE(:MOVTOPARENTREFID,0) = 0 OR COALESCE(:DOCTOKITPARENTREFID,0) = 0) THEN
    BEGIN

        FOR SELECT   DETALLEKITCANTIDAD ,
                    DETALLEKITTASAIVA ,
                    DETALLEKITTASAIEPS ,
                    DETALLEKITTASAIMPUESTO ,
                    DETALLEKITTOTAL ,
                    DETALLEKITSUBTOTAL ,
                    DETALLEKITIVA ,
                    DETALLEKITIEPS ,
                    DETALLEKITPRECIO ,
                    DETALLEKITPRECIOLISTA ,
                    DETALLEKITPRODUCTOID ,
                    PRORRATEO ,
                    TASAIEPSPARTE ,
                    TASAIVAPARTE ,
                    TASACOSTOTOTALPARTE ,

                    ERRORCODE FROM KIT_OBTENREFERENCIA ( :DOCTOIDPARALLENAR,:MOVTOREFID)
                    INTO
                    :CANTIDADFINAL ,
                    :DETALLEKITTASAIVA ,
                    :DETALLEKITTASAIEPS ,
                    :DETALLEKITTASAIMPUESTO ,
                    :DETALLEKITTOTAL ,
                    :DETALLEKITSUBTOTAL ,
                    :DETALLEKITIVA ,
                    :DETALLEKITIEPS ,
                    :DETALLEKITPRECIO ,
                    :DETALLEKITPRECIOLISTA ,
                    :DETALLEKITPRODUCTOID ,
                    :PRORRATEO ,
                    :TASAIEPSPARTE ,
                    :TASAIVAPARTE ,
                    :TASASUBTOTALPARTE ,
                    :ERRORCODE
                 DO
                 BEGIN
                 
                        COSTO = 0;
                        SUCURSALTID = 0;
                        ALMACENTID = 0;

                        SELECT DOCTOID, MOVTOID, ERRORCODE
                        FROM MOVTO_INSERT(:DOCTOIDFORKIT, 0, :ALMACENID, :SUCURSALID, :TIPODOCTOIDFORKIT, 0, 0, :PERSONAID, :VENDEDORID, 1, 0,
                            :DETALLEKITPRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDAD, :CANTIDADSURTIDA, :CANTIDADFALTANTE, 0, 0, 0, 0,
                            :REFERENCIA, '', :COSTO, :SUCURSALTID, :ALMACENID, 'N', NULL, CURRENT_DATE, CURRENT_DATE, 0.00,:DOCTOIDPARALLENAR,NULL,NULL,NULL,:MOVTOREFID, :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3, NULL, :LOTEIMPORTADO, 'N','N')
                        INTO :DOCTOIDFORKIT, :MOVTOID, :ERRORCODE;

                        IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
                        BEGIN
                            --insert into traza(valor) values('kkl. ' || cast(:productoid as varchar(10)));
                            ERRORCODE = :ERRORCODE ;
                            SUSPEND;
                            EXIT;
                        END


                        UPDATE MOVTO
                            SET CANTIDAD = :CANTIDADFINAL,
                                CANTIDADSURTIDA = :PRORRATEO,
                                TASAIVA = :DETALLEKITTASAIVA,
                                TASAIEPS = :DETALLEKITTASAIEPS,
                                TASAIMPUESTO = :DETALLEKITTASAIMPUESTO ,
                                TOTAL = ROUND(:DETALLEKITTOTAL,2),
                                SUBTOTAL =  ROUND(:DETALLEKITSUBTOTAL,2),
                                IVA = ROUND(:DETALLEKITIVA,2),
                                IEPS = ROUND(:DETALLEKITIEPS,2),
                                PRECIO = ROUND(:DETALLEKITPRECIO,2) ,
                                PRECIOLISTA = :DETALLEKITPRECIOLISTA,
                                MOVTOREFID = :MOVTOREFID ,
                                TASAIEPSPARTE = :TASAIEPSPARTE ,
                                TASAIVAPARTE = :TASAIVAPARTE ,
                                TASASUBTOTALPARTE = :TASASUBTOTALPARTE
                                WHERE ID = :MOVTOID;

                 END



      END
      ELSE IF (:TIPODOCTOID IN (12,13, 15,22,23,24,26,32,33,42,43,322,323) AND COALESCE(:MOVTOPARENTREFID,0) <> 0 AND COALESCE(:DOCTOKITPARENTREFID,0) <> 0) THEN
      BEGIN

          SELECT VERSIONKIT FROM DOCTO WHERE ID = :DOCTOKITPARENTREFID INTO :VERSIONKIT;

          IF(COALESCE(:VERSIONKIT,0) < 2) THEN
          BEGIN
                     
                FOR SELECT

                    MK.cantidadsurtida  PRORRATEO,
                    (COALESCE(MK.CANTIDAD, 0) / COALESCE(MP.CANTIDAD, 1)) * COALESCE(:CANTIDAD ,0) CANTIDADFINAL,
                    PRODUCTO.TASAIVA TASAIVA,
                    PRODUCTO.TASAIEPS TASAIEPS,
                    PRODUCTO.tasaimpuesto TASAIMPUESTO,
                    PRODUCTO.precio1 PRECIOLISTA  ,
                    MK.PRODUCTOID


                    FROM MOVTO MK
                    INNER JOIN MOVTO MP ON MP.ID = MK.movtorefid
                    INNER JOIN PRODUCTO  ON PRODUCTO.ID = MK.PRODUCTOID
                    INNER JOIN PARAMETRO ON 1 = 1
                    WHERE MK.DOCTOID = :DOCTOKITPARENTREFID AND MK.movtorefid = :MOVTOPARENTREFID  AND COALESCE(MP.cantidad,0) > 0
                    INTO
                    :PRORRATEO,
                    :CANTIDADFINAL ,
                    :DETALLEKITTASAIVA ,
                    :DETALLEKITTASAIEPS ,
                    :DETALLEKITTASAIMPUESTO,
                    :DETALLEKITPRECIOLISTA ,
                    :DETALLEKITPRODUCTOID
                DO
                BEGIN
   
                    COSTO = 0;
                    SUCURSALTID = 0;
                    ALMACENTID = 0;

                    SELECT DOCTOID, MOVTOID, ERRORCODE
                    FROM MOVTO_INSERT(:DOCTOIDFORKIT, 0, :ALMACENID, :SUCURSALID, :TIPODOCTOIDFORKIT, 0, 0, :PERSONAID, :VENDEDORID, 1, 0,
                    :DETALLEKITPRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDAD, :CANTIDADSURTIDA, :CANTIDADFALTANTE, 0, 0, 0, 0,
                    :REFERENCIA, '', :COSTO, :SUCURSALTID, :ALMACENID, 'N', NULL, CURRENT_DATE, CURRENT_DATE, 0.00,:DOCTOIDPARALLENAR,NULL,NULL,NULL,:MOVTOREFID, :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3, NULL, :LOTEIMPORTADO, 'N','N')
                    INTO :DOCTOIDFORKIT, :MOVTOID, :ERRORCODE;

                    IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
                    BEGIN
                    --insert into traza(valor) values('kkl. ' || cast(:productoid as varchar(10)));
                        ERRORCODE = :ERRORCODE ;
                        SUSPEND;
                        EXIT;
                    END

                    DETALLEKITTOTAL =  :TOTAL * :PRORRATEO ;
                    DETALLEKITSUBTOTAL = (:DETALLEKITTOTAL  )  / ((1.00 + (:DETALLEKITTASAIVA/100.00)) * (1.00 + (:DETALLEKITTASAIEPS/100.00))  );
                    DETALLEKITIEPS = :DETALLEKITTOTAL * (:DETALLEKITTASAIEPS/100.00);
                    DETALLEKITIVA = (:DETALLEKITTOTAL * (1.00 + :DETALLEKITTASAIEPS/100.00)) * (:DETALLEKITTASAIVA/100.00);
                    DETALLEKITPRECIO = :DETALLEKITSUBTOTAL / :CANTIDADFINAL;


                    UPDATE MOVTO
                    SET CANTIDAD = :CANTIDADFINAL,
                    CANTIDADSURTIDA = :PRORRATEO,
                    TASAIVA = :DETALLEKITTASAIVA,
                    TASAIEPS = :DETALLEKITTASAIEPS,
                    TASAIMPUESTO = :DETALLEKITTASAIMPUESTO ,
                    TOTAL = ROUND(:DETALLEKITTOTAL,2),
                    SUBTOTAL =  ROUND(:DETALLEKITSUBTOTAL,2),
                    IVA = ROUND(:DETALLEKITIVA,2),
                    IEPS = ROUND(:DETALLEKITIEPS,2),
                    PRECIO = ROUND(:DETALLEKITPRECIO,2) ,
                    PRECIOLISTA = :DETALLEKITPRECIOLISTA,
                    MOVTOREFID = :MOVTOREFID
                    WHERE ID = :MOVTOID;
                END


          END
          ELSE
          BEGIN

                FOR SELECT   DETALLEKITCANTIDAD ,
                    DETALLEKITTASAIVA ,
                    DETALLEKITTASAIEPS ,
                    DETALLEKITTASAIMPUESTO ,
                    DETALLEKITTOTAL ,
                    DETALLEKITSUBTOTAL ,
                    DETALLEKITIVA ,
                    DETALLEKITIEPS ,
                    DETALLEKITPRECIO ,
                    DETALLEKITPRECIOLISTA ,
                    DETALLEKITPRODUCTOID ,
                    PRORRATEO ,
                    TASAIEPSPARTE ,
                    TASAIVAPARTE ,
                    TASACOSTOTOTALPARTE ,

                    ERRORCODE FROM KIT_OBTENREFERENCIA ( :DOCTOIDPARALLENAR,:MOVTOREFID)
                    INTO
                    :CANTIDADFINAL ,
                    :DETALLEKITTASAIVA ,
                    :DETALLEKITTASAIEPS ,
                    :DETALLEKITTASAIMPUESTO ,
                    :DETALLEKITTOTAL ,
                    :DETALLEKITSUBTOTAL ,
                    :DETALLEKITIVA ,
                    :DETALLEKITIEPS ,
                    :DETALLEKITPRECIO ,
                    :DETALLEKITPRECIOLISTA ,
                    :DETALLEKITPRODUCTOID ,
                    :PRORRATEO ,
                    :TASAIEPSPARTE ,
                    :TASAIVAPARTE ,
                    :TASASUBTOTALPARTE ,
                    :ERRORCODE
                 DO
                 BEGIN
                 
                        COSTO = 0;
                        SUCURSALTID = 0;
                        ALMACENTID = 0;

                        SELECT DOCTOID, MOVTOID, ERRORCODE
                        FROM MOVTO_INSERT(:DOCTOIDFORKIT, 0, :ALMACENID, :SUCURSALID, :TIPODOCTOIDFORKIT, 0, 0, :PERSONAID, :VENDEDORID, 1, 0,
                            :DETALLEKITPRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDAD, :CANTIDADSURTIDA, :CANTIDADFALTANTE, 0, 0, 0, 0,
                            :REFERENCIA, '', :COSTO, :SUCURSALTID, :ALMACENID, 'N', NULL, CURRENT_DATE, CURRENT_DATE, 0.00,:DOCTOIDPARALLENAR,NULL,NULL,NULL,:MOVTOREFID, :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3, NULL, :LOTEIMPORTADO, 'N','N')
                        INTO :DOCTOIDFORKIT, :MOVTOID, :ERRORCODE;

                        IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
                        BEGIN
                            --insert into traza(valor) values('kkl. ' || cast(:productoid as varchar(10)));
                            ERRORCODE = :ERRORCODE ;
                            SUSPEND;
                            EXIT;
                        END


                        UPDATE MOVTO
                            SET CANTIDAD = :CANTIDADFINAL,
                                CANTIDADSURTIDA = :PRORRATEO,
                                TASAIVA = :DETALLEKITTASAIVA,
                                TASAIEPS = :DETALLEKITTASAIEPS,
                                TASAIMPUESTO = :DETALLEKITTASAIMPUESTO ,
                                TOTAL = ROUND(:DETALLEKITTOTAL,2),
                                SUBTOTAL =  ROUND(:DETALLEKITSUBTOTAL,2),
                                IVA = ROUND(:DETALLEKITIVA,2),
                                IEPS = ROUND(:DETALLEKITIEPS,2),
                                PRECIO = ROUND(:DETALLEKITPRECIO,2) ,
                                PRECIOLISTA = :DETALLEKITPRECIOLISTA,
                                MOVTOREFID = :MOVTOREFID ,
                                TASAIEPSPARTE = :TASAIEPSPARTE ,
                                TASAIVAPARTE = :TASAIVAPARTE ,
                                TASASUBTOTALPARTE = :TASASUBTOTALPARTE
                                WHERE ID = :MOVTOID;

                 END
        


          END



      END


   END











    
   IF(COALESCE(:DOCTOIDFORKIT,0) <> 0) THEN
   BEGIN

        UPDATE DOCTO SET DOCTO.doctokitrefid = :DOCTOIDFORKIT WHERE ID = :DOCTOIDPARALLENAR;
        UPDATE DOCTO SET DOCTO.doctokitrefid = :DOCTOIDPARALLENAR WHERE ID =  :DOCTOIDFORKIT;

        SELECT ERRORCODE
        FROM DOCTO_SAVE(:DOCTOIDFORKIT)
        INTO :ERRORCODE;


   END

   IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
   BEGIN
      SUSPEND;
      EXIT;
   END



   ERRORCODE = 0;
   SUSPEND;
   
   WHEN ANY DO
   BEGIN
     ERRORCODE = 1076;
     SUSPEND;
   END
END