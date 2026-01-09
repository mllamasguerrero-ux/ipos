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
declare variable PRECIOENVIOTRASLADO D_FK;
BEGIN



   SELECT S.preciorecepciontraslado FROM DOCTO D INNER JOIN SUCURSAL S ON D.SUCURSALTID = S.id
   where d.id = :doctoid
   into :PRECIOENVIOTRASLADO;



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
   and producto.inventariable = 'S' --and producto.negativos = 'S'
   into :EXISTENCIASINSUFICIENTES  ;

   
   IF (coalesce(:EXISTENCIASINSUFICIENTES,0) <> 0) THEN
   BEGIN
      ERRORCODE = 3001;
      SUSPEND;
      EXIT;
   END

   delete from movto where cantidad = 0 and movto.doctoid = :doctoid;


   update movto set costo = (

   select case
   when :precioenviotraslado = 1 then coalesce(costoreposicion,0)
   when :precioenviotraslado = 4 then coalesce(precio1,0)
   when :precioenviotraslado = 5 then coalesce(precio2,0)
   when :precioenviotraslado = 6 then coalesce(precio3,0)
   when :precioenviotraslado = 7 then coalesce(precio4,0)
   when :precioenviotraslado = 8 then coalesce(precio5,0)
   else coalesce(costoreposicion,0)
   end from producto where id = movto.productoid


   )
   where movto.doctoid = :doctoid;


   update movto set costoimporte = costo * movto.cantidad , precio = costo,
   importe = costo * movto.cantidad, subtotal = costo * movto.cantidad  , iva = 0, total = costo * movto.cantidad
   where movto.doctoid = :doctoid;

         update docto
         set importe =  (select sum(coalesce(m.importe,0)) from movto m where m.doctoid = :doctoid) ,
         subtotal    =  (select sum(coalesce(m.subtotal,0)) from movto m where m.doctoid = :doctoid) ,
         iva   =  (select sum(coalesce(m.iva,0)) from movto m where m.doctoid = :doctoid) ,
         total    =  (select sum(coalesce(m.total,0)) from movto m where m.doctoid = :doctoid)
         where id = :doctoid;



         
   SELECT ERRORCODE FROM ASIGNARLOTE_SURTIRPEDIDO (
    :DOCTOID )
    INTO  :ERRORCODE;

    IF(:ERRORCODE <> 0) THEN
    BEGIN
        SUSPEND;
        EXIT;
    END


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
   
   /*WHEN ANY DO
   BEGIN
      ERRORCODE = 1063;
      SUSPEND;
   END */
END