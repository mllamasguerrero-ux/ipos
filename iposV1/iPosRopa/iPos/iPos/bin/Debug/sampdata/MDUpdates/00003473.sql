create or alter procedure VENTAFUTURO_SALDOANTICIPOS (
    DOCTOID D_FK)
returns (
    SALDOANTICIPOS D_PRECIO,
    ERRORCODE D_ERRORCODE)
as
declare variable TIPODOCTOID D_FK;
declare variable ESTATUSDOCTOID D_FK;
BEGIN


   SALDOANTICIPOS  = 0;
   -- Si no es documento de compra 11.
   IF ((:DOCTOID IS NULL) OR (:DOCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1060;
      SUSPEND;
      EXIT;
   END

   -- Validar estatus.
   SELECT TIPODOCTOID, ESTATUSDOCTOID
   FROM DOCTO
   WHERE ID = :DOCTOID
   INTO :TIPODOCTOID, :ESTATUSDOCTOID;

   -- Si no es documento de compra 21.
   IF ((:TIPODOCTOID IS NULL) OR (:TIPODOCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1060;
      SUSPEND;
      EXIT;
   END

   -- Si no es documento de compra 21.
   IF (:TIPODOCTOID <> 821 ) THEN
   BEGIN
      ERRORCODE = 1061;
      SUSPEND;
      EXIT;
   END

   -- Si el estatus no es borrador .
   IF (:ESTATUSDOCTOID <> 1) THEN
   BEGIN
      ERRORCODE = 1062;
      SUSPEND;
      EXIT;
   END


     SELECT SUM(COALESCE(DOCTO.saldo,0)) SALDO
     FROM DOCTO
     WHERE DOCTO.tipodoctoid = 201 AND DOCTO.ESTATUSDOCTOID = 1 AND DOCTO.ventafutuid = :DOCTOID
     into :SALDOANTICIPOS;



   SUSPEND;
   
   WHEN ANY DO
   BEGIN
      ERRORCODE = 1063;
      SUSPEND;
   END
END