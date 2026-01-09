create or alter procedure RETIRO_CAJA_COMPLETAR (
    DOCTOID D_FK,
    TOTALEFECTIVO D_PRECIO,
    TOTALCHEQUE D_PRECIO,
    TOTALVALE D_PRECIO)
returns (
    ERRORCODE type of D_ERRORCODE)
as
declare variable DOCTOERRORCODE type of D_FK;
declare variable CORTEID D_FK;
declare variable TOTAL D_IMPORTE;
declare variable DOCTOFECHA D_FECHA;
declare variable DOCTOFECHAHORA D_TIMESTAMP;
BEGIN

   ERRORCODE = 0;


   TOTAL = COALESCE(:TOTALEFECTIVO,0) + COALESCE(:TOTALCHEQUE,0) + COALESCE(:TOTALVALE,0);

   SELECT CORTEID, FECHA, FECHAHORA FROM DOCTO WHERE ID = :DOCTOID INTO :CORTEID, :DOCTOFECHA, :DOCTOFECHAHORA;


   UPDATE DOCTO SET TOTAL = :TOTAL, SUBTOTAL = :TOTAL , CARGO = :total,  SALDO = :TOTAL
   WHERE ID = :DOCTOID;

   SELECT CORTEID FROM DOCTO WHERE ID = :DOCTOID INTO :CORTEID;


   
   SELECT ERRORCODE FROM DOCTO_SAVE(:DOCTOID)
   INTO :ERRORCODE;
   
   IF (:ERRORCODE > 0) THEN
   BEGIN
      ERRORCODE = :DOCTOERRORCODE;
      SUSPEND;
      EXIT;
   END


   IF( COALESCE(:TOTALEFECTIVO,0) > 0 ) THEN
   BEGIN

     SELECT ERRORCODE
      FROM DOCTOPAGO_INSERT (
         NULL,
         1,
         :DOCTOFECHA,
         :DOCTOFECHAHORA,
         :CORTEID,
         :TOTALEFECTIVO,
         0,
         0 ,
         2,
         :DOCTOID,
         'N' ,
         1,
         NULL,
         NULL,
         NULL,
         :DOCTOFECHA,
         :DOCTOFECHA,
         'S',
         1,
         NULL
      ) INTO :ERRORCODE;
               
      IF (:ERRORCODE > 0) THEN
      BEGIN
            ERRORCODE = :DOCTOERRORCODE;
            SUSPEND;
            EXIT;
      END


    END


    
   IF( COALESCE(:TOTALCHEQUE,0) > 0 ) THEN
   BEGIN

     SELECT ERRORCODE
      FROM DOCTOPAGO_INSERT (
         NULL,
         3,
         :DOCTOFECHA,
         :DOCTOFECHAHORA,
         :CORTEID,
         :TOTALCHEQUE,
         0,
         0 ,
         2,
         :DOCTOID,
         'N' ,
         1,
         NULL,
         NULL,
         NULL,
         :DOCTOFECHA,
         :DOCTOFECHA,
         'S',
         1,
         NULL
      ) INTO :ERRORCODE;
               
      IF (:ERRORCODE > 0) THEN
      BEGIN
            ERRORCODE = :DOCTOERRORCODE;
            SUSPEND;
            EXIT;
      END


    END



    
    
   IF( COALESCE(:TOTALVALE,0) > 0 ) THEN
   BEGIN

     SELECT ERRORCODE
      FROM DOCTOPAGO_INSERT (
         NULL,
         5,
         :DOCTOFECHA,
         :DOCTOFECHAHORA,
         :CORTEID,
         :TOTALVALE,
         0,
         0 ,
         2,
         :DOCTOID,
         'N' ,
         1,
         NULL,
         NULL,
         NULL,
         :DOCTOFECHA,
         :DOCTOFECHA,
         'S',
         1,
         NULL
      ) INTO :ERRORCODE;
               
      IF (:ERRORCODE > 0) THEN
      BEGIN
            ERRORCODE = :DOCTOERRORCODE;
            SUSPEND;
            EXIT;
      END


    END






    ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1004;
      SUSPEND;
   END 

END