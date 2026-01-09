create or alter procedure REPL_IMPO_DEVOMATRIZ_CANC (
    DOCTOID D_FK,
    USERID D_FK,
    FECHA D_FECHA)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable CORTEID D_FK;
declare variable SUCURSALID D_FK;
declare variable ESTATUSDOCTOID D_FK;
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


         SELECT FIRST 1 ESTATUSDOCTOID FROM DOCTO WHERE ID = :DOCTOID INTO :ESTATUSDOCTOID;



       
        IF (COALESCE(:ESTATUSDOCTOID,0) <> 1) THEN
        BEGIN
            SUSPEND;
            EXIT;
        END

         
        SELECT ERRORCODE
        FROM COMPRADEVO_CANCEL_INICIAR(:DOCTOID,:USERID)
        INTO :ERRORCODE;
        
        IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
        BEGIN
            SUSPEND;
            EXIT;
        END


   SUSPEND;
   EXIT;


END