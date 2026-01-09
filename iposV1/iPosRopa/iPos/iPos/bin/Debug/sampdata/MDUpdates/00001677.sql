create or alter procedure CORTE_CERRAR (
    SUCURSALID D_FK,
    CORTEID D_FK,
    FECHACORTE D_FECHA,
    CAJEROID D_FK,
    SALDOINICIAL D_IMPORTE,
    INGRESO D_IMPORTE,
    EGRESO D_IMPORTE,
    DEVOLUCION D_IMPORTE,
    APORTACION D_IMPORTE,
    RETIRO D_IMPORTE,
    SALDOFINAL D_IMPORTE,
    SALDOREAL D_IMPORTE,
    DIFERENCIA D_IMPORTE,
    SALDOREALCREDITO D_IMPORTE)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable ACTIVO D_BOOLCN;
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
      SALDOREAL  = :SALDOREAL,
      DIFERENCIA = :DIFERENCIA,
      SALDOREALCREDITO = :SALDOREALCREDITO,
      ACTIVO = 'N'
   WHERE ID = :CORTEID;

   UPDATE PERSONA
   SET
      CORTEID = NULL
   WHERE ID = :CAJEROID;


   delete  from movto
   where movto.doctoid in
   (select docto.id from
    docto
   where docto.corteid =  :CORTEID
   and docto.tipodoctoid not in (29,50,51,52,53,60,61,71,201,202,203,204,16,17,18)
   and docto.estatusdoctoid = 0
   );

   delete from docto
   where docto.corteid =  :CORTEID
   and docto.tipodoctoid not in (29,50,51,52,53,60,61,71,201,202,203,204,16,17,18)
   and docto.estatusdoctoid = 0;

   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1025;
      SUSPEND;
   END 
END