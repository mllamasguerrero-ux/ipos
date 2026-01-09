create or alter procedure ORDENCOMPRA_COMPLETAR (
    DOCTOID D_FK,
    OBSERVACION D_OBSERVACION,
    REFERENCIAS D_REFERENCIA,
    VENDEDORID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable TIPODOCTOID D_FK;
declare variable ESTATUSDOCTOID D_FK;
declare variable FALTANTES integer;
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
   IF (:TIPODOCTOID <> 11 and :TIPODOCTOID <> 17 ) THEN
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



   update movto set
   cantidad = cantidadsurtida,
   cantidadderemision = cantidadsurtida,
   cantidaddefactura = 0,
   cantidadfaltante = 0,
   importe = cantidadsurtida * preciolista,
   subtotal = cantidadsurtida * precio,
   ieps = (cantidadsurtida * precio) * (tasaieps / 100) ,
   iva =  ((cantidadsurtida * precio) * ( 1 + (TASAIEPS / 100.00))) * (TASAIVA / 100.00),
   impuesto =    ((cantidadsurtida * precio) * ( 1 + (TASAIEPS / 100.00))) * (TASAIVA / 100.00) +  (cantidadsurtida * precio) * (tasaieps / 100),
   total =     (cantidadsurtida * precio) +
               (((cantidadsurtida * precio) * ( 1 + (TASAIEPS / 100.00))) * (TASAIVA / 100.00) +  (cantidadsurtida * precio) * (tasaieps / 100))

               where doctoid = :doctoid;




   -- Completar el documento con afectacion de inventarios.
   SELECT ERRORCODE
   FROM DOCTO_SAVE(:DOCTOID)
   INTO :ERRORCODE;
   
   IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
   BEGIN
      SUSPEND;
      EXIT;
   END
   
             /*
   -- Si hay diferencias, generar un documento de devolucion.
   SELECT COUNT(M.ID)
   FROM MOVTO M
   WHERE M.DOCTOID = :DOCTOID
      AND (M.CANTIDADFALTANTE > 0)
   INTO :FALTANTES;

   IF (:FALTANTES > 0) THEN
   BEGIN
      SELECT ERRORCODE
      FROM COMPRA_DEVOLVER(:DOCTOID, :VENDEDORID)
      INTO :ERRORCODE;
       
        IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
        BEGIN
            SUSPEND;
            EXIT;
         END

   END
                        */

   UPDATE docto SET OBSERVACION = :OBSERVACION , REFERENCIA = :REFERENCIAS
   WHERE ID = :DOCTOID;

   SUSPEND;
   
   WHEN ANY DO
   BEGIN
      ERRORCODE = 1063;
      SUSPEND;
   END
END