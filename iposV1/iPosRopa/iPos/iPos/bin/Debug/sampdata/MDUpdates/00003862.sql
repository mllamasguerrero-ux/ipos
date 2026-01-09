create or alter procedure TRASPASO_COMPLETAR (
    DOCTOID D_FK,
    OBSERVACION D_OBSERVACION,
    VENDEDORID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable TIPODOCTOID D_FK;
declare variable ESTATUSDOCTOID D_FK;
declare variable FALTANTES integer;
declare variable REFERENCIAS varchar(255);
BEGIN
   -- Si no es documento de compra 41.
   IF ((:DOCTOID IS NULL) OR (:DOCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1060;
      SUSPEND;
      EXIT;
   END

   -- Validar estatus.
   SELECT TIPODOCTOID, ESTATUSDOCTOID, REFERENCIAS
   FROM DOCTO
   WHERE ID = :DOCTOID
   INTO :TIPODOCTOID, :ESTATUSDOCTOID, :REFERENCIAS;

   -- Si no es documento de compra 41.
   IF ((:TIPODOCTOID IS NULL) OR (:TIPODOCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1060;
      SUSPEND;
      EXIT;
   END

   -- Si no es documento de compra 41.
   IF (:TIPODOCTOID <> 41) THEN
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

   --insert into traza values('Trapaso completar 1');

   -- Completar el documento con afectacion de inventarios.
   SELECT ERRORCODE
   FROM DOCTO_SAVE(:DOCTOID)
   INTO :ERRORCODE;
  
   IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
   BEGIN
      SUSPEND;
      EXIT;
   END
  
       
   --insert into traza values('Trapaso completar 2');

   -- Si hay diferencias, generar un documento de devolucion.
  /* SELECT COUNT(M.ID)
   FROM MOVTO M
   WHERE M.DOCTOID = :DOCTOID
      AND (M.CANTIDADFALTANTE > 0)
   INTO :FALTANTES;

   
   --insert into traza values('Trapaso c 3 ' || CAST(:DOCTOID AS VARCHAR(20)) ||  ' --- ' || cast(:FALTANTES AS VARCHAR(10)));

   IF (:FALTANTES > 0) THEN
   BEGIN
   
    --insert into traza values('Trapaso c 4 ' );
      SELECT ERRORCODE
      FROM TRASPASO_DEVOLVER(:DOCTOID,:VENDEDORID)
      INTO :ERRORCODE;
   END */

   
   UPDATE docto SET OBSERVACION = :OBSERVACION
   WHERE ID = :DOCTOID;

   SUSPEND;
  
   WHEN ANY DO
   BEGIN
      ERRORCODE = 1063;
      SUSPEND;
   END
END