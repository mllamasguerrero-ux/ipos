create or alter procedure CHEQUEDEVUELTO_GENERARVENTA (
    PAGOID D_FK,
    USERID D_FK)
returns (
    MOVTOID D_FK,
    DOCTOID D_FK,
    ERRORCODE D_ERRORCODE)
as
declare variable SUCURSALID D_FK;
declare variable PERSONAID D_FK;
declare variable PRODUCTOID D_FK;
declare variable PRECIO D_PRECIO;
declare variable DOCTOPAGOID D_FK;
declare variable HAYCORTEACTIVO D_BOOLCN;
declare variable CORTEID D_FK;
declare variable FECHACORTE D_FECHA;
BEGIN

        ERRORCODE = 0;

        
        SELECT HAYCORTEACTIVO,CORTEID,ERRORCODE, FECHACORTE
        FROM HAY_CORTE_ACTIVO(:USERID)
        INTO :HAYCORTEACTIVO, :CORTEID, :ERRORCODE, :FECHACORTE;
        
        IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
        BEGIN
                        SUSPEND;
                        EXIT;
        END


        IF(:HAYCORTEACTIVO <> 'S' OR :FECHACORTE < CURRENT_DATE ) THEN
        BEGIN  
                        ERRORCODE = 1001;
                        SUSPEND;
                        EXIT;
        END


      SELECT PERSONAID, IMPORTE
      FROM PAGO
      WHERE PAGO.ID  = :PAGOID
      INTO :PERSONAID, :PRECIO;


      SELECT FIRST 1 PARAMETRO.sucursalid FROM parametro INTO :SUCURSALID;

      SELECT PRODUCTOID FROM PRODUCTO_CHEQUEDEVUELTO(:USERID) INTO :PRODUCTOID;
      
      SELECT DOCTOID, ERRORCODE
      FROM DOCTO_INSERT (
         :USERID,
         1,
         :SUCURSALID,
         21,
         0,
         0,
         :PERSONAID,
         :USERID,
         1,
         '',
         '',
         NULL,
         NULL,
         CURRENT_DATE,
         CURRENT_DATE ,
         NULL ,
         'S' ,
         1
      ) INTO :DOCTOID, :ERRORCODE;

      
        UPDATE DOCTO SET SUBTIPODOCTOID = 27
         WHERE ID = :DOCTOID;


      IF (:ERRORCODE > 0) THEN
   BEGIN
      SUSPEND;
      EXIT;
   END

      SELECT ERRORCODE,MOVTOID --, DOCTOID
      FROM MOVTO_INSERT (
         :DOCTOID, 0, 1, :SUCURSALID, 21, 0, 0, :PERSONAID, :USERID, 1,
         0, :PRODUCTOID, NULL, NULL,  1, 0, 0, 0, 0, :PRECIO, 0,
         '', '', :PRECIO, NULL, NULL, 'N',
         0, CURRENT_DATE, CURRENT_DATE, 0.00 ,NULL,NULL,NULL,NULL,NULL , NULL, NULL, NULL , NULL, NULL, 'N','N'
      ) INTO :ERRORCODE,:MOVTOID;

      
        IF(COALESCE(:ERRORCODE ,0) <> 0) then
        BEGIN
            SUSPEND;
            EXIT;
        END


         SELECT DOCTOPAGOID, ERRORCODE
         FROM DOCTOPAGO_INSERT (
         :DOCTOID,
         4,
         CURRENT_DATE, CURRENT_TIMESTAMP, :CORTEID,
         :PRECIO, 0.00, 0.00 ,
         1,
         NULL ,
         'N'  ,
         1 ,
         NULL,
         NULL,
         NULL  ,
         CURRENT_DATE,
         CURRENT_DATE,
         'N',
         1,
         NULL,
         NULL,
         NULL,
         NULL,
         NULL,
         NULL,
         NULL,
         NULL,
         NULL,
         NULL,
         NULL
       ) INTO :DOCTOPAGOID, :ERRORCODE;




        SELECT ERRORCODE FROM DOCTO_SAVE(:DOCTOID) INTO :ERRORCODE;



SUSPEND;
END