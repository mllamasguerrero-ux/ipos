create or alter procedure REPL_IMPO_DEVOMATRIZ_COMP (
    DOCTOID D_FK,
    USERID D_FK,
    FECHA D_FECHA)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable IMPORTEPAGO D_IMPORTE;
declare variable CORTEID D_FK;
declare variable DOCTOPAGOID D_FK;
declare variable SUCURSALID D_FK;
BEGIN


   SELECT PARAMETRO.SUCURSALID FROM PARAMETRO INTO :SUCURSALID;


   
   SELECT ID FROM CORTE WHERE CAJEROID = :USERID AND FECHACORTE = :FECHA INTO :CORTEID;

   IF(COALESCE(:CORTEID , 0) = 0) THEN
   BEGIN
       SELECT ERRORCODE,  CORTEID FROM
        CORTE_ABRIR (
                :FECHA,
                :SUCURSALID ,
                :USERID ,
                0,
            1) INTO :ERRORCODE, :CORTEID;

            
        IF (:ERRORCODE > 0) THEN
        BEGIN
            SUSPEND;
            EXIT;
        END
   END






         SELECT FIRST 1 TOTAL FROM DOCTO WHERE ID = :DOCTOID INTO :IMPORTEPAGO;


         SELECT DOCTOPAGOID, ERRORCODE
         FROM DOCTOPAGO_INSERT (
         :DOCTOID,
         4,
         CURRENT_DATE, CURRENT_TIMESTAMP, :CORTEID,
         :IMPORTEPAGO, 0.00, 0.00 ,
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
         NULL
       ) INTO :DOCTOPAGOID, :ERRORCODE;

       
        IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
        BEGIN
            SUSPEND;
            EXIT;
        END

         
        SELECT ERRORCODE
        FROM DOCTO_SAVE(:DOCTOID)
        INTO :ERRORCODE;
        
        IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
        BEGIN
            SUSPEND;
            EXIT;
        END


   SUSPEND;
   EXIT;


END