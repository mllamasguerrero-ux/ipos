create or alter procedure REBAJA_CERRARNC (
    DOCTOID D_FK,
    CORTEID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable ESTATUSDOCTOID D_FK;
declare variable DOCTOVENTAID D_FK;
declare variable SUBTIPODOCTOID D_FK;
declare variable TIPODOCTOID D_FK;
declare variable TOTAL D_PRECIO;
BEGIN

   ERRORCODE  = 0;

   -- Leer del DOCTO a cancelar.
   SELECT ESTATUSDOCTOID , DOCTOREFID  , TIPODOCTOID, SUBTIPODOCTOID , TOTAL
   FROM DOCTO
   WHERE ID = :DOCTOID
   INTO :ESTATUSDOCTOID, :DOCTOVENTAID, :TIPODOCTOID, :SUBTIPODOCTOID , :TOTAL;

   -- Si no esta vigente: Salir.
   IF (:ESTATUSDOCTOID <> 0) THEN
   BEGIN
      ERRORCODE = 1007;
      SUSPEND;
      EXIT;
   END

   
   IF (:TIPODOCTOID NOT IN (22) AND :SUBTIPODOCTOID NOT IN (13)) THEN
   BEGIN
      ERRORCODE = 1008;
      SUSPEND;
      EXIT;
   END


   UPDATE MOVTO SET MOVTO.costoreposicion = 0 WHERE DOCTOID = :DOCTOID;

   UPDATE MOVTO SET MOVTO.estadorebaja = 2, cantautrebaja = cantidad  WHERE ID IN (SELECT COALESCE(MOVTO2.MOVTOREFID,0) from MOVTO MOVTO2 WHERE MOVTO2.doctoid = :DOCTOID);


   -- Completar el documento con afectacion de inventarios.
   SELECT ERRORCODE
   FROM DOCTO_SAVE(:DOCTOID)
   INTO :ERRORCODE;

   
   IF(:ERRORCODE <> 0) THEN
   BEGIN
      SUSPEND;
      EXIT;
   END





   SELECT ERRORCODE
      FROM DOCTOPAGO_INSERT (
         :DOCTOVENTAID ,
    6,
    CURRENT_DATE,
    CURRENT_TIME,
    :CORTEID,
    :TOTAL,
    :TOTAL,
    0,
    1,
    :DOCTOID,
    'N',
    NULL,
    NULL,
    NULL,
    NULL,
    CURRENT_DATE,
    CURRENT_DATE,
    'N',
    2,
    NULL ,
    NULL ,
    NULL ,
    NULL
      ) INTO :ERRORCODE;


      
   IF(:ERRORCODE <> 0) THEN
   BEGIN
      SUSPEND;
      EXIT;
   END

   ERRORCODE = 0;
   SUSPEND;
   
    WHEN ANY DO
    BEGIN
        ERRORCODE = 1009;
        SUSPEND;
    END
END