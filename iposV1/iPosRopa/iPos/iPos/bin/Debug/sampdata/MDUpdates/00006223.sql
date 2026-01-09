create or alter procedure KIT_APPLYTEMPTABLE
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable PRODUCTOKITCLAVE D_CLAVE_NULL;
declare variable PRODUCTOPARTECLAVE D_CLAVE_NULL;
declare variable KITID D_FK;
declare variable PRODUCTOKITID D_CLAVE_NULL;
declare variable PRODUCTOPARTEID D_CLAVE_NULL;
declare variable CUENTADIFERENCIA integer;
declare variable PRODUCTOEXISTENCIA D_CANTIDAD;
declare variable ALMACENID D_FK;
declare variable ORIGENFISCALID D_FK;
declare variable SUCURSALID D_FK;
declare variable MANEJAKITS D_BOOLCN;
declare variable DOCTOIDFORKIT D_FK;
declare variable TIPODOCTOIDFORKIT D_FK;
declare variable MOVTOID D_FK;
declare variable PERSONAID D_FK;
declare variable VENDEDORID D_FK;
declare variable REFERENCIA D_REFERENCIA;
declare variable CAJAID D_FK;
declare variable LOTE D_LOTE;
declare variable FECHAVENCE D_FECHAVENCE;
declare variable DESCRIPCION1 D_STDTEXT_64;
declare variable DESCRIPCION2 D_STDTEXT_64;
declare variable DESCRIPCION3 D_STDTEXT_64;
declare variable COSTO D_COSTO;
declare variable CANTIDAD D_CANTIDAD;
declare variable LOTEIMPORTADO D_FK;
BEGIN

   ERRORCODE = 0;
   TIPODOCTOIDFORKIT = 502;

   PERSONAID  = 1;
   VENDEDORID = 17;
   REFERENCIA = '';
   CAJAID = 1;
   LOTE = NULL;
   FECHAVENCE = NULL;
   DESCRIPCION1 = NULL;
   DESCRIPCION2 = NULL;
   DESCRIPCION3 = NULL;
   LOTEIMPORTADO = NULL;


   DELETE FROM KITDOCTOTEMP;

   SELECT PARAMETRO.sucursalid, PARAMETRO.manejakits FROM PARAMETRO  INTO :SUCURSALID, :MANEJAKITS;

   IF(COALESCE(:MANEJAKITS, 'N') = 'N') THEN
   BEGIN
        SUSPEND;
        EXIT;
   END

   FOR  SELECT ID, PRODUCTOKITCLAVE, PRODUCTOPARTECLAVE
        FROM KITDEFTEMP
        FOR UPDATE
        INTO :KITID, PRODUCTOKITCLAVE, PRODUCTOPARTECLAVE
        DO
        BEGIN
             PRODUCTOKITID = NULL;
             PRODUCTOPARTEID = NULL;
            

             SELECT FIRST 1 ID FROM PRODUCTO WHERE PRODUCTO.CLAVE = :PRODUCTOKITCLAVE INTO :PRODUCTOKITID;     
             SELECT FIRST 1 ID FROM PRODUCTO WHERE PRODUCTO.CLAVE = :PRODUCTOPARTECLAVE INTO :PRODUCTOPARTEID;
             UPDATE KITDEFTEMP SET PRODUCTOKITID = :PRODUCTOKITID, PRODUCTOPARTEID = :PRODUCTOPARTEID
             WHERE ID = :KITID;

        END


    FOR SELECT PRODUCTOKITID
        FROM kitdeftemp
        GROUP BY PRODUCTOKITID
        INTO :PRODUCTOKITID
        DO
        BEGIN

            
              select count(*) from
                (select K.PRODUCTOPARTEID , sum(COALESCE(K.cantidadparte,0)) cantidadkit, COALESCE(K.COSTOPARTE,0) COSTOPARTE  FROM  KITDEFTEMP K where k.productokitid = :PRODUCTOKITID GROUP by K.PRODUCTOPARTEID, COALESCE(K.COSTOPARTE,0)) C
                    LEFT JOIN
                    (select K.PRODUCTOPARTEID , sum(COALESCE(K.cantidadparte,0)) cantidadkit, COALESCE(K.COSTOPARTE,0) COSTOPARTE FROM  KITDEFINICION K where k.productokitid = :PRODUCTOKITID GROUP by K.PRODUCTOPARTEID, COALESCE(K.COSTOPARTE,0)) KIT
                        on c.productoparteid = kit.productoparteid  and C.COSTOPARTE = KIT.COSTOPARTE
                  where coalesce(kit.cantidadkit,0) <> coalesce(c.cantidadkit,0)
                  INTO :CUENTADIFERENCIA;

                  
               IF(COALESCE(:CUENTADIFERENCIA,0) = 0 ) THEN
               BEGIN
               
                    select count(*) from
                    (select K.PRODUCTOPARTEID , sum(COALESCE(K.cantidadparte,0)) cantidadkit, COALESCE(K.COSTOPARTE,0) COSTOPARTE FROM  KITDEFINICION K where k.productokitid = :PRODUCTOKITID GROUP by K.PRODUCTOPARTEID, COALESCE(K.COSTOPARTE,0)) KIT
                        LEFT JOIN
                         (select K.PRODUCTOPARTEID , sum(COALESCE(K.cantidadparte,0)) cantidadkit, COALESCE(K.COSTOPARTE,0) COSTOPARTE FROM  KITDEFTEMP K where k.productokitid = :PRODUCTOKITID GROUP by K.PRODUCTOPARTEID, COALESCE(K.COSTOPARTE,0)) C
                        on c.productoparteid = kit.productoparteid  and C.COSTOPARTE = KIT.COSTOPARTE
                    where coalesce(kit.cantidadkit,0) <> coalesce(c.cantidadkit,0)
                    INTO :CUENTADIFERENCIA;
               END




               IF(COALESCE(:CUENTADIFERENCIA,0) <> 0 ) THEN
               BEGIN
               PRODUCTOEXISTENCIA = 0;
                 SELECT EXISTENCIA, PRODUCTO.costoreposicion FROM PRODUCTO WHERE ID = :PRODUCTOKITID INTO :PRODUCTOEXISTENCIA, :COSTO;
                 IF(COALESCE(:PRODUCTOEXISTENCIA,0) > 0 ) THEN
                 BEGIN

                    FOR SELECT ALMACENID, ORIGENFISCALID, SUM(COALESCE(CANTIDAD,0) ) CANTIDAD
                        FROM INVENTARIO
                        WHERE PRODUCTOID = :PRODUCTOKITID AND ESAPARTADO <> 'S'
                        GROUP BY PRODUCTOID, ALMACENID, ORIGENFISCALID
                        HAVING SUM(COALESCE(CANTIDAD,0) ) > 0
                        INTO :ALMACENID, :ORIGENFISCALID, :CANTIDAD
                        DO
                        BEGIN

                             DOCTOIDFORKIT = 0;
                             SELECT DOCTOID FROM KITDOCTOTEMP
                             WHERE PRODUCTOKITID = :PRODUCTOKITID AND ALMACENID = :ALMACENID AND ORIGENFISCALID = :ORIGENFISCALID
                             INTO :DOCTOIDFORKIT;

                             IF(COALESCE(:DOCTOIDFORKIT ,0) = 0) THEN
                             BEGIN
                                
                                    SELECT ERRORCODE FROM
                                            CORTE_MOVIL_ASEGURAR(:VENDEDORID)
                                        INTO :ERRORCODE;
                                 
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
                                    NULL ,
                                    'S' ,
                                    :ORIGENFISCALID
                               ) INTO :DOCTOIDFORKIT, :ERRORCODE;


                               IF(:ERRORCODE <> 0 ) THEN
                               BEGIN
                                SUSPEND;
                                EXIT;
                               END

                               --UPDATE DOCTO SET SUBTIPODOCTOID = 11, DOCTOKITREFID = :DOCTOKITPARENTREFID WHERE ID = :DOCTOIDFORKIT;

                                INSERT INTO KITDOCTOTEMP
                                (  PRODUCTOKITID, ORIGENFISCALID, ALMACENID, DOCTOID)
                                VALUES (:PRODUCTOKITID, :ORIGENFISCALID, :ALMACENID, :DOCTOIDFORKIT);
                                    
                             END


                             
                            SELECT DOCTOID, MOVTOID, ERRORCODE
                            FROM MOVTO_INSERT(:DOCTOIDFORKIT, 0, :ALMACENID, :SUCURSALID, :TIPODOCTOIDFORKIT, 0, 0, :PERSONAID, :VENDEDORID, 1, 0,
                            :PRODUCTOKITID, :LOTE, :FECHAVENCE, :CANTIDAD, 0, 0, 0, 0, 0, 0,
                            :REFERENCIA, '', :COSTO, :SUCURSALID, :ALMACENID, 'N', NULL, CURRENT_DATE, CURRENT_DATE, 0.00,NULL,NULL,NULL,NULL,NULL, :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3, NULL, :LOTEIMPORTADO, 'N','N')
                            INTO :DOCTOIDFORKIT, :MOVTOID, :ERRORCODE;

                            IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
                            BEGIN
                                SUSPEND;
                                EXIT;
                            END

                            
                        END

                 END
               END
               ELSE
               BEGIN
                  DELETE FROM KITDEFTEMP WHERE PRODUCTOKITID = :PRODUCTOKITID;
               END



        END


        FOR SELECT DOCTOID FROM kitdoctotemp
            INTO :DOCTOIDFORKIT
            DO
            BEGIN

                
    
                IF(COALESCE(:DOCTOIDFORKIT,0) <> 0) THEN
                BEGIN
                    SELECT ERRORCODE
                    FROM KIT_APLICARDESENSAMBLE(:DOCTOIDFORKIT)
                    INTO :ERRORCODE;
                END

                IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
                BEGIN
                    SUSPEND;
                    EXIT;
                END
                
            END


            
        DELETE FROM KITDEFINICION WHERE PRODUCTOKITID IN (SELECT PRODUCTOKITID FROM kitdeftemp GROUP BY PRODUCTOKITID);

        INSERT INTO KITDEFINICION(PRODUCTOKITID, PRODUCTOPARTEID, CANTIDADPARTE, PRODUCTOKITCLAVE, PRODUCTOPARTECLAVE, COSTOPARTE)
        SELECT  PRODUCTOKITID, PRODUCTOPARTEID, CANTIDADPARTE, PRODUCTOKITCLAVE, PRODUCTOPARTECLAVE, COSTOPARTE
        FROM KITDEFTEMP;

        DELETE FROM KITDEFTEMP;

        DELETE FROM KITDOCTOTEMP;


        FOR SELECT PRODUCTOKITID
            FROM KITDEFINICION
            GROUP BY PRODUCTOKITID
            INTO :PRODUCTOKITID
            DO
            BEGIN
                SELECT ERRORCODE FROM KIT_ACTUALIZARIMPUESTOKIT (:PRODUCTOKITID ) INTO :ERRORCODE;
                
                IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
                BEGIN
                    SUSPEND;
                    EXIT;
                END
            END


        




   ERRORCODE = 0;
   SUSPEND;
   
   /*
   WHEN ANY DO
   BEGIN
     ERRORCODE = 1076;
     SUSPEND;
   END     */
END