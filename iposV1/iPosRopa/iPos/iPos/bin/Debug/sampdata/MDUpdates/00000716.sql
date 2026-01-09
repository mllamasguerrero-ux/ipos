create or alter procedure COMPRA_PRECIERRE (
    DOCTOID D_FK,
    ORIGENFISCALID D_FK,
    VENCE D_FECHAVENCE,
    REFERENCIA D_REFERENCIA,
    REFERENCIAS D_DESCRIPCION)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable TIPODOCTOID D_FK;
declare variable ESTATUSDOCTOID D_FK;
declare variable FALTANTES integer;
declare variable DETALLESSINEXISTENCIA integer;
BEGIN

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

   -- Si no es documento de compra 11.
   IF ((:TIPODOCTOID IS NULL) OR (:TIPODOCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1060;
      SUSPEND;
      EXIT;
   END

   -- Si no es documento de compra 11.
   IF (:TIPODOCTOID not in (11,41,12,15) ) THEN
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



    IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
    BEGIN
        SUSPEND;
        EXIT;
    END




     IF (:TIPODOCTOID = 12) THEN
     BEGIN

            SELECT COUNT(*) FROM MOVTOS_SINEXISTENCIA WHERE DOCTOID = :DOCTOID
            INTO :DETALLESSINEXISTENCIA;

            IF(COALESCE(:DETALLESSINEXISTENCIA,0) > 0) then
            begin
                ERRORCODE = 1081;
                SUSPEND;
                EXIT;
            end
    END



    UPDATE DOCTO SET ORIGENFISCALID = :ORIGENFISCALID,
                     REFERENCIA = :REFERENCIA,
                     VENCE = :VENCE ,
                     REFERENCIAS = :REFERENCIAS
     WHERE ID = :DOCTOID;

    UPDATE MOVTO SET CANTIDADDEFACTURA = iif(:ORIGENFISCALID = 3, CANTIDAD, 0),
    CANTIDADDEREMISION = iif(:ORIGENFISCALID = 2, CANTIDAD, 0) ,
    CANTIDADDEINDEFINIDO = iif((:ORIGENFISCALID < 2 ), CANTIDAD, 0)
    WHERE DOCTOID = :DOCTOID;

   
    ERRORCODE = 0;
   SUSPEND;
   
    WHEN ANY DO
    BEGIN
        ERRORCODE = 1065;
        SUSPEND;
    END

   -- Marcar los faltantes como ya generados.
ENd