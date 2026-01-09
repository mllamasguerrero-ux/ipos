CREATE OR ALTER PROCEDURE CORTE_CERRAR (
    sucursalid d_fk,
    cajaid d_fk,
    corteid d_fk,
    fechacorte d_fecha,
    cajeroid d_fk,
    saldoinicial d_importe,
    ingreso d_importe,
    egreso d_importe,
    devolucion d_importe,
    aportacion d_importe,
    retiro d_importe,
    saldofinal d_importe,
    saldoreal d_importe,
    diferencia d_importe)
returns (
    errorcode d_errorcode)
as
declare variable activo d_boolcn;
BEGIN
   SELECT ACTIVO
   FROM CORTE
   WHERE ID = :CORTEID
   INTO :ACTIVO;

   IF (:CORTEID IS NULL) THEN
   BEGIN
      ERRORCODE = 1023;
      SUSPEND;
      EXIT;
   END

   IF (:ACTIVO <> 'S') THEN
   BEGIN
      ERRORCODE = 1024;
      SUSPEND;
      EXIT;
   END

   UPDATE CORTE
   SET
      /*
      INGRESO = :INGRESO,
      EGRESO = :EGRESO,
      DEVOLUCION = :DEVOLUCION,
      APORTACION = :APORTACION,
      RETIRO = :RETIRO,
      SALDOFINAL = :SALDOFINAL,
      */
      SALDOREAL = :SALDOREAL,
      DIFERENCIA = :DIFERENCIA,
      ACTIVO = 'N'
   WHERE ID = :CORTEID;

   UPDATE CAJA
   SET
      CORTEID = NULL, 
      FECHACORTE = NULL,
      CAJEROID = NULL,
      TURNOID = NULL
   WHERE ID = :CAJAID;


   delete  from movto
   where movto.doctoid in
   (select docto.id from
    docto
   where docto.corteid =  :CORTEID
   and docto.tipodoctoid = 21
   and docto.estatusdoctoid = 0
   );

   delete from docto
   where docto.corteid =  :CORTEID
   and docto.tipodoctoid = 21
   and docto.estatusdoctoid = 0;

   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1025;
      SUSPEND;
   END 
END