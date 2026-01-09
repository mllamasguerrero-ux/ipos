CREATE OR ALTER PROCEDURE DOCTO_PAGOS (
    doctoid d_fk,
    fecha d_fecha,
    fechahora d_timestamp,
    corteid d_fk,
    importetotalapagar d_importe,
    importeefectivo d_importe,
    importetarjeta d_importe,
    importecheque d_importe,
    importecredito d_importe,
    importevale d_importe,
    importeefectivorecibido d_importe)
returns (
    errorcode d_errorcode)
as
declare variable formapagoid d_fk;
declare variable importecambio d_importe;
declare variable importeefectivoneto d_importe;
BEGIN
   IMPORTEEFECTIVO = COALESCE(:IMPORTEEFECTIVO, 0.0000);
   IMPORTETARJETA = COALESCE(:IMPORTETARJETA, 0.0000);
   IMPORTECHEQUE = COALESCE(:IMPORTECHEQUE, 0.0000);
   IMPORTECREDITO = COALESCE(:IMPORTECREDITO, 0.0000);
   IMPORTEVALE =    COALESCE(:IMPORTEVALE, 0.0000);
  
   IMPORTEEFECTIVONETO = :IMPORTETOTALAPAGAR - :IMPORTETARJETA - :IMPORTECHEQUE - :IMPORTECREDITO - :IMPORTEVALE;

   IMPORTECAMBIO = :IMPORTEEFECTIVORECIBIDO - :IMPORTEEFECTIVONETO;
  
   IF (:IMPORTEEFECTIVONETO > 0.00) THEN
   BEGIN
      FORMAPAGOID = 1; -- Efectivo
      SELECT ERRORCODE
      FROM DOCTOPAGO_INSERT (
         :DOCTOID,
         :FORMAPAGOID,
         :FECHA, :FECHAHORA, :CORTEID,
         :IMPORTEEFECTIVONETO,
         :IMPORTEEFECTIVORECIBIDO,
         :IMPORTECAMBIO
      ) INTO :ERRORCODE;
   END

   IF (:IMPORTETARJETA > 0.00) THEN
   BEGIN
      FORMAPAGOID = 2; -- Tarjeta
      SELECT ERRORCODE
      FROM DOCTOPAGO_INSERT (
         :DOCTOID,
         :FORMAPAGOID,
         :FECHA, :FECHAHORA, :CORTEID,
         :IMPORTETARJETA, 0.00, 0.00
      ) INTO :ERRORCODE;
   END

   IF (:IMPORTECHEQUE > 0.00) THEN
   BEGIN
      FORMAPAGOID = 3; -- Cheque
      SELECT ERRORCODE
      FROM DOCTOPAGO_INSERT (
         :DOCTOID,
         :FORMAPAGOID,
         :FECHA, :FECHAHORA, :CORTEID,
         :IMPORTECHEQUE, 0.00, 0.00
      ) INTO :ERRORCODE;
   END

   IF (:IMPORTECREDITO > 0.00) THEN
   BEGIN
      FORMAPAGOID = 4; -- Credito
      SELECT ERRORCODE
      FROM DOCTOPAGO_INSERT (
         :DOCTOID,
         :FORMAPAGOID,
         :FECHA, :FECHAHORA, :CORTEID,
         :IMPORTECREDITO, 0.00, 0.00
      ) INTO :ERRORCODE;
   END

   
   IF (:IMPORTEVALE > 0.00) THEN
   BEGIN
      FORMAPAGOID = 5; -- vALE
      SELECT ERRORCODE
      FROM DOCTOPAGO_INSERT (
         :DOCTOID,
         :FORMAPAGOID,
         :FECHA, :FECHAHORA, :CORTEID,
         :IMPORTEVALE, 0.00, 0.00
      ) INTO :ERRORCODE;
   END

   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1016;
      SUSPEND;
   END
END