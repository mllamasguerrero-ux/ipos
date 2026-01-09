CREATE OR ALTER PROCEDURE CORTE_TOTALES (
    sucursalid d_fk,
    cajeroid d_fk)
returns (
    corteid d_fk,
    fechacorte d_fecha,
    saldoinicial d_importe,
    ingreso d_importe,
    egreso d_importe,
    devolucion d_importe,
    saldofinal d_importe,
    aportacion d_importe,
    retiro d_importe,
    ingresotarjeta d_importe,
    ingresoefectivo d_importe,
    ingresocredito d_importe,
    ingresocheque d_importe,
    ingresovale d_importe,
    cambiocheque d_importe,
    errorcode d_errorcode)
as
declare variable activo d_boolcn;
declare variable ticketsventa integer;
declare variable ticketsdevolucion integer;
BEGIN

   SELECT CORTEID
   FROM PERSONA
   WHERE ID = :CAJEROID
   INTO :CORTEID ;




   SELECT  ACTIVO, SALDOINICIAL, APORTACION, RETIRO, FECHACORTE
   FROM CORTE
   WHERE ID = :CORTEID
   INTO :ACTIVO, :SALDOINICIAL, :APORTACION, :RETIRO,  :FECHACORTE;

   IF (:CORTEID IS NULL) THEN
   BEGIN
      ERRORCODE = 1020;
      SUSPEND;
      EXIT;
   END

   IF (:ACTIVO <> 'S') THEN
   BEGIN
      ERRORCODE = 1021;
      SUSPEND;
      EXIT;
   END

   SELECT COALESCE(SUM(TOTAL), 0.00)
   FROM DOCTO
   WHERE TIPODOCTOID = 21
     AND FECHA = :FECHACORTE
     AND SUCURSALID = :SUCURSALID
     --AND CAJAID = :CAJAID
     --AND TURNOID = :TURNOID
     AND VENDEDORID = :CAJEROID
      AND ESTATUSDOCTOID IN (1,2)
   INTO :INGRESO;

   SELECT COALESCE(COUNT(*), 0)
   FROM DOCTO
   WHERE TIPODOCTOID = 21
     AND FECHA = :FECHACORTE
     AND SUCURSALID = :SUCURSALID
     --AND CAJAID = :CAJAID
     --AND TURNOID = :TURNOID
     AND VENDEDORID = :CAJEROID
      AND ESTATUSDOCTOID IN (1, 2)
   INTO :TICKETSVENTA;
   
   SELECT COALESCE(SUM(TOTAL), 0.00)
   FROM DOCTO
   WHERE TIPODOCTOID = 23
     AND FECHA = :FECHACORTE
     AND SUCURSALID = :SUCURSALID
     --AND CAJAID = :CAJAID
     --AND TURNOID = :TURNOID
     AND VENDEDORID = :CAJEROID
      AND ESTATUSDOCTOID = 1
   INTO :EGRESO;

   SELECT COALESCE(COUNT(*), 0)
   FROM DOCTO
   WHERE TIPODOCTOID = 23
     AND FECHA = :FECHACORTE
     AND SUCURSALID = :SUCURSALID
     --AND CAJAID = :CAJAID
     --AND TURNOID = :TURNOID
     AND VENDEDORID = :CAJEROID
      AND ESTATUSDOCTOID = 1
   INTO :TICKETSDEVOLUCION;

   SELECT COALESCE(SUM(TOTAL), 0.00)
   FROM DOCTO
   WHERE TIPODOCTOID = 23
     AND FECHA = :FECHACORTE
     AND SUCURSALID = :SUCURSALID
     --AND CAJAID = :CAJAID
     --AND TURNOID = :TURNOID
     AND VENDEDORID = :CAJEROID
      AND ESTATUSDOCTOID = 1
   INTO :DEVOLUCION;



  
   SELECT COALESCE(SUM(doctopago.importe), 0.00)
   FROM DOCTO
   inner join doctopago on docto.id = doctopago.doctoid
   WHERE docto.TIPODOCTOID = 21
     AND docto.FECHA = :FECHACORTE
     AND docto.SUCURSALID = :SUCURSALID
     --AND docto.CAJAID = :CAJAID
     --AND docto.TURNOID = :TURNOID
     AND docto.VENDEDORID = :CAJEROID
      AND docto.ESTATUSDOCTOID IN (1,2)
      and doctopago.formapagoid = 1
   INTO :INGRESOEFECTIVO;

                              
   SELECT COALESCE(SUM(doctopago.importe), 0.00)
   FROM DOCTO
   inner join doctopago on docto.id = doctopago.doctoid
   WHERE docto.TIPODOCTOID = 21
     AND docto.FECHA = :FECHACORTE
     AND docto.SUCURSALID = :SUCURSALID
     --AND docto.CAJAID = :CAJAID
     --AND docto.TURNOID = :TURNOID
     AND docto.VENDEDORID = :CAJEROID
      AND docto.ESTATUSDOCTOID  IN (1,2)
      and doctopago.formapagoid = 2
   INTO :INGRESOTARJETA;

             
   SELECT COALESCE(SUM(doctopago.importe), 0.00)  ,
           COALESCE(SUM(doctopago.importecambio), 0.00)
   FROM DOCTO
   inner join doctopago on docto.id = doctopago.doctoid
   WHERE docto.TIPODOCTOID = 21
     AND docto.FECHA = :FECHACORTE
     AND docto.SUCURSALID = :SUCURSALID
     --AND docto.CAJAID = :CAJAID
     --AND docto.TURNOID = :TURNOID
     AND docto.VENDEDORID = :CAJEROID
      AND docto.ESTATUSDOCTOID  IN (1,2)
      and doctopago.formapagoid = 3
   INTO :INGRESOCHEQUE, :CAMBIOCHEQUE;

             
   SELECT COALESCE(SUM(doctopago.importe), 0.00)
   FROM DOCTO
   inner join doctopago on docto.id = doctopago.doctoid
   WHERE docto.TIPODOCTOID = 21
     AND docto.FECHA = :FECHACORTE
     AND docto.SUCURSALID = :SUCURSALID
     --AND docto.CAJAID = :CAJAID
     --AND docto.TURNOID = :TURNOID
     AND docto.VENDEDORID = :CAJEROID
      AND docto.ESTATUSDOCTOID IN (1,2)
      and doctopago.formapagoid = 4
   INTO :INGRESOCREDITO;

      SELECT COALESCE(SUM(doctopago.importe), 0.00)
   FROM DOCTO
   inner join doctopago on docto.id = doctopago.doctoid
   WHERE docto.TIPODOCTOID = 21
     AND docto.FECHA = :FECHACORTE
     AND docto.SUCURSALID = :SUCURSALID
     --AND docto.CAJAID = :CAJAID
     --AND docto.TURNOID = :TURNOID
     AND docto.VENDEDORID = :CAJEROID
      AND docto.ESTATUSDOCTOID IN (1,2)
      and doctopago.formapagoid = 5
   INTO :INGRESOVALE;


   SALDOFINAL = :SALDOINICIAL + :INGRESO - :EGRESO;

   UPDATE CORTE
   SET
      INGRESO = :INGRESO,
      EGRESO = :EGRESO,
      SALDOFINAL = :SALDOFINAL,
      DEVOLUCION = :DEVOLUCION,
        NUMEROTICKETS = :TICKETSVENTA,
        NUMERODEVOLUCIONES = :TICKETSDEVOLUCION ,
        INGRESOEFECTIVO = :INGRESOEFECTIVO,
        INGRESOTARJETA = :INGRESOTARJETA,
        INGRESOCREDITO = :INGRESOCREDITO,    
        INGRESOCHEQUE = :INGRESOCHEQUE ,
        INGRESOVALE = :INGRESOVALE ,
        CAMBIOCHEQUE = :CAMBIOCHEQUE
   WHERE ID = :CORTEID;

   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1022;
      SUSPEND;
   END
END