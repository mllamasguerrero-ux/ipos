create or alter procedure VENTAFUTUAPL_PRECOMPLETAR (
    DOCTOID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable TIPODOCTOID D_FK;
declare variable ESTATUSDOCTOID D_FK;
declare variable CANTIDAD D_CANTIDAD;
declare variable MOVTOREFID D_FK;
declare variable VENTAFUTUID D_FK;
declare variable FALTANTE integer;
BEGIN
   -- Si no es documento de compra 11.
   IF ((:DOCTOID IS NULL) OR (:DOCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1060;
      SUSPEND;
      EXIT;
   END

   -- Validar estatus.
   SELECT TIPODOCTOID, ESTATUSDOCTOID, VENTAFUTUID
   FROM DOCTO
   WHERE ID = :DOCTOID
   INTO :TIPODOCTOID, :ESTATUSDOCTOID, :VENTAFUTUID;

   -- Si no es documento de compra 21.
   IF ((:TIPODOCTOID IS NULL) OR (:TIPODOCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1060;
      SUSPEND;
      EXIT;
   END

   -- Si no es documento de compra 21.
   IF (:TIPODOCTOID <> 21 ) THEN
   BEGIN
      ERRORCODE = 1061;
      SUSPEND;
      EXIT;
   END

   -- Si el estatus no es borrador .
   IF (:ESTATUSDOCTOID <> 0) THEN
   BEGIN
      ERRORCODE = 1062;
      SUSPEND;
      EXIT;
   END


       
   SELECT ERRORCODE FROM ASIGNARLOTE_SURTIRPEDIDO (
    :DOCTOID )
    INTO  :ERRORCODE;

    IF(:ERRORCODE <> 0) THEN
    BEGIN
        SUSPEND;
        EXIT;
    END



   SUSPEND;
   
   WHEN ANY DO
   BEGIN
      ERRORCODE = 1063;
      SUSPEND;
   END
END