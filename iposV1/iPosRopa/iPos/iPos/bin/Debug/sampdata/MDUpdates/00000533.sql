create or alter procedure MATRIZ_ENVIOPEDIDO_COMPLETAR (
    DOCTOID D_FK,
    OBSERVACION D_OBSERVACION)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable TIPODOCTOID D_FK;
declare variable ESTATUSDOCTOID D_FK;
declare variable FALTANTES integer;
declare variable REFERENCIAS varchar(255);
declare variable EXISTENCIASINSUFICIENTES integer;
declare variable COSTOREPO D_COSTO;
BEGIN
   -- Si no es documento de compra 11.
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

   -- Si no es documento de compra 11.
   IF ((:TIPODOCTOID IS NULL) OR (:TIPODOCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1060;
      SUSPEND;
      EXIT;
   END

   -- Si no es documento de compra 11.
   IF (:TIPODOCTOID <> 81 ) THEN
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


   select count(*) from movto left join producto on movto.productoid = producto.id
   where movto.doctoid = :doctoid and (coalesce(producto.existencia,0) < movto.cantidad)
   and producto.inventariable = 'S'
   into :EXISTENCIASINSUFICIENTES  ;

   
   IF (coalesce(:EXISTENCIASINSUFICIENTES,0) <> 0) THEN
   BEGIN
      ERRORCODE = 3001;
      SUSPEND;
      EXIT;
   END



   update movto set costo = (select coalesce(costoreposicion,0) from producto where id = movto.productoid)
   where movto.doctoid = :doctoid;


   update movto set costoimporte = costo * movto.cantidad , precio = costo,
   importe = costo * movto.cantidad, subtotal = costo * movto.cantidad  , iva = 0, total = costo * movto.cantidad
   where movto.doctoid = :doctoid;


   -- Completar el documento con afectacion de inventarios.
   SELECT ERRORCODE
   FROM DOCTO_SAVE(:DOCTOID)
   INTO :ERRORCODE;
   
   IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
   BEGIN
      SUSPEND;
      EXIT;
   END
   



   UPDATE docto SET OBSERVACION = :OBSERVACION
   WHERE ID = :DOCTOID;

   SUSPEND;
   
   WHEN ANY DO
   BEGIN
      ERRORCODE = 1063;
      SUSPEND;
   END
END