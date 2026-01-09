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
declare variable EXISTENCIASINSUFICIENTES integer;
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


          
   select count(*) from movto left join producto on movto.productoid = producto.id
   where movto.doctoid = :doctoid and (coalesce(producto.existencia,0) < movto.cantidad)
   and producto.inventariable = 'S'
   and (coalesce(producto.negativos,'N') = 'N' or coalesce(producto.manejalote,'N') = 'S' )
   into :EXISTENCIASINSUFICIENTES  ;

   
   IF (coalesce(:EXISTENCIASINSUFICIENTES,0) <> 0) THEN
   BEGIN
      ERRORCODE = 3001;
      SUSPEND;
      EXIT;
   END

   delete from movto where cantidad = 0 and movto.doctoid = :doctoid;


                   /*
   SELECT ERRORCODE FROM ASIGNARLOTE_SURTIRPEDIDO (
    :DOCTOID )
    INTO  :ERRORCODE;

    IF(:ERRORCODE <> 0) THEN
    BEGIN
        SUSPEND;
        EXIT;
    END
           */


   SUSPEND;
   
   WHEN ANY DO
   BEGIN
      ERRORCODE = 1063;
      SUSPEND;
   END
END