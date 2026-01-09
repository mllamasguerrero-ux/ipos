create or alter procedure KIT_DESAMBLARALVUELOPORCAMBIO (
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
declare variable CUENTAKITS integer;
declare variable CUENTADIFERENCIA integer;
declare variable DOCTOREFID D_FK;
declare variable DOCTOREFKITID D_FK;
declare variable MOVTOPARENTREFID D_FK;
declare variable DOCTOKITPARENTREFID D_FK;
declare variable SENTIDOINVENTARIO D_SENTIDO;
BEGIN

   ERRORCODE = 0;
   


   SELECT TIPODOCTOID, ESTATUSDOCTOID  , ALMACENID, SUCURSALID, CAJAID, PERSONAID  ,VENDEDORID, ORIGENFISCALID , TIPODOCTO.sentidoinventario
   FROM DOCTO LEFT JOIN TIPODOCTO ON DOCTO.TIPODOCTOID = TIPODOCTO.ID
   WHERE DOCTO.ID = :DOCTOIDPARALLENAR
   INTO :TIPODOCTOID, :ESTATUSDOCTOID ,:ALMACENID, :SUCURSALID, :CAJAID, :PERSONAID, :VENDEDORID, :ORIGENFISCALID, :SENTIDOINVENTARIO;

   
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
   IF (COALESCE(:SENTIDOINVENTARIO ,0) <> 1 AND :TIPODOCTOID NOT IN (501,502,503,504)) THEN--(:TIPODOCTOID NOT IN (22,23,26,15)) THEN
   BEGIN
      ERRORCODE = 1071;
      SUSPEND;
      EXIT;
   END
   -- Solo admitir EstatusDocto = 0, Borrador.
   IF (:ESTATUSDOCTOID <> 1 ) THEN
   BEGIN
      ERRORCODE = 1072;
      SUSPEND;
      EXIT;
   END


     -- CHECAR SI HAY KITS A CREAR AL VUELO
   SELECT COUNT(*)
    FROM MOVTO M
     LEFT JOIN DOCTO D
       ON D.ID = M.DOCTOID
       LEFT JOIN PRODUCTO ON PRODUCTO.id = M.PRODUCTOID
   WHERE M.DOCTOID = :DOCTOIDPARALLENAR  AND COALESCE(PRODUCTO.ESKIT, 'N') = 'S'
      AND (M.CANTIDAD > 0) --AND COALESCE(M.CANTIDAD,0) > COALESCE(PRODUCTO.EXISTENCIA,0)
    INTO :CUENTAKITS;

    IF(COALESCE(:CUENTAKITS,0) <= 0) THEN
    BEGIN
      ERRORCODE = 0;
      SUSPEND;
      EXIT;
    END



   -- Inicializara para primer registro de movto
   DOCTOIDFORKIT = 0;
   TIPODOCTOIDFORKIT = 502;
                  
     FOR SELECT
      M.PRODUCTOID,
       M.LOTE,
      M.FECHAVENCE,
      COALESCE(M.CANTIDAD,0),

      0,
      0,
      M.COSTO,
      M.TIPODIFERENCIAINVENTARIOID,
      D.PERSONAID  ,
      D.VENDEDORID ,
      M.DESCRIPCION1,
      M.DESCRIPCION2,
      M.DESCRIPCION3 ,

      D.DOCTOREFID ,
      M.movtorefid
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
      :COSTO, :TIPODIFERENCIAINVENTARIOID, :PERSONAID , :VENDEDORID  , :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3,
      :DOCTOREFID , :MOVTOPARENTREFID
   DO
   BEGIN

            SELECT DOCTO.doctokitrefid FROM DOCTO WHERE ID = :DOCTOREFID INTO :DOCTOKITPARENTREFID;
          
            IF(COALESCE(:MOVTOPARENTREFID,0) = 0 ) THEN
            BEGIN
                SELECT FIRST 1 MOVTO.ID FROM MOVTO WHERE MOVTO.DOCTOID = :DOCTOREFID AND MOVTO.PRODUCTOID = :PRODUCTOID INTO :MOVTOPARENTREFID;
            END

            IF(COALESCE(:DOCTOKITPARENTREFID,0) > 0 AND COALESCE(:MOVTOPARENTREFID,0) > 0) THEN
            BEGIN

                select count(*) from
                (select MK.PRODUCTOID ,SUM(COALESCE(MK.CANTIDAD, 0) / COALESCE(MP.CANTIDAD, 1)) cantidadmk FROM MOVTO MK
                            INNER JOIN MOVTO MP ON MP.ID = MK.movtorefid
                            WHERE MK.DOCTOID = :DOCTOKITPARENTREFID AND MK.movtorefid = :MOVTOPARENTREFID  AND COALESCE(MP.cantidad,0) > 0
                            GROUP BY MK.PRODUCTOID) C
                    LEFT JOIN
                    (select K.PRODUCTOPARTEID , sum(COALESCE(K.cantidadparte,0)) cantidadkit  FROM  KITDEFINICION K where k.productokitid = :PRODUCTOID GROUP by K.PRODUCTOPARTEID) KIT
                        on c.productoid = kit.productoparteid
                  where coalesce(kit.cantidadkit,0) <> coalesce(c.cantidadmk,0)
                  INTO :CUENTADIFERENCIA;



               
               IF(COALESCE(:CUENTADIFERENCIA,0) = 0 ) THEN
               BEGIN
                
                   
                  select count(*) from
                    (select K.PRODUCTOPARTEID , sum(COALESCE(K.cantidadparte,0)) cantidadkit  FROM  KITDEFINICION K where k.productokitid = :PRODUCTOID GROUP by K.PRODUCTOPARTEID) KIT
                    LEFT JOIN
                    (select MK.PRODUCTOID ,SUM(COALESCE(MK.CANTIDAD, 0) / COALESCE(MP.CANTIDAD, 1)) cantidadmk FROM MOVTO MK
                            INNER JOIN MOVTO MP ON MP.ID = MK.movtorefid
                            WHERE MK.DOCTOID = :DOCTOKITPARENTREFID AND MK.movtorefid = :MOVTOPARENTREFID  AND COALESCE(MP.cantidad,0) > 0
                            GROUP BY MK.PRODUCTOID) C  on c.productoid = kit.productoparteid
                            where coalesce(kit.cantidadkit,0) <> coalesce(c.cantidadmk,0)
                  INTO :CUENTADIFERENCIA;
               END


               IF(COALESCE(:CUENTADIFERENCIA,0) <> 0 ) THEN
               BEGIN

                     IF(COALESCE(:DOCTOIDFORKIT,0) = 0) THEN
                     BEGIN

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
                                  SUSPEND;
                                  EXIT;
                        END

                        UPDATE DOCTO SET SUBTIPODOCTOID = 11, DOCTOKITREFID = :DOCTOKITPARENTREFID WHERE ID = :DOCTOIDFORKIT;



                            
                     END


                     SELECT DOCTOID, MOVTOID, ERRORCODE
                        FROM MOVTO_INSERT(:DOCTOIDFORKIT, 0, :ALMACENID, :SUCURSALID, :TIPODOCTOIDFORKIT, 0, 0, :PERSONAID, :VENDEDORID, 1, 0,
                        :PRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDAD, :CANTIDADSURTIDA, :CANTIDADFALTANTE, 0, 0, 0, 0,
                        :REFERENCIA, '', :COSTO, :SUCURSALTID, :ALMACENID, 'N', NULL, CURRENT_DATE, CURRENT_DATE, 0.00,:DOCTOIDPARALLENAR,NULL,NULL,NULL,NULL, :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3)
                        INTO :DOCTOIDFORKIT, :MOVTOID, :ERRORCODE;

                    IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
                    BEGIN
                        ERRORCODE = :ERRORCODE ;
                        SUSPEND;
                        EXIT;
                    END

                    UPDATE MOVTO SET MOVTOREFID = :MOVTOPARENTREFID  WHERE ID = :MOVTOID;


               END

            END


   END








    
   IF(COALESCE(:DOCTOIDFORKIT,0) <> 0) THEN
   BEGIN
        SELECT ERRORCODE
        FROM KIT_APLIDESENSAMBLE_REF(:DOCTOIDFORKIT)
        INTO :ERRORCODE;
   END

   IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
   BEGIN
      SUSPEND;
      EXIT;
   END



   ERRORCODE = 0;
   SUSPEND;
   
   /*
   WHEN ANY DO
   BEGIN
     ERRORCODE = 4006;
     SUSPEND;
   END    */
END