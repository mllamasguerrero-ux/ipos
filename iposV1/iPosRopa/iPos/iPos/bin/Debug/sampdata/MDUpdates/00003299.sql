create or alter procedure CALCULAR_TIMBRADOFORMAPAGOSAT (
    DOCTOID D_FK)
returns (
    TIMBRADOFORMAPAGOSAT D_STDTEXT_SHORT,
    ERRORCODE D_ERRORCODE)
as
declare variable CUENTADOCTOPAGOS integer;
declare variable FORMAPAGOSATID D_FK;
declare variable SALDO D_PRECIO;
declare variable TOTAL D_PRECIO;
declare variable ESPRIMERFORMAPAGO D_BOOLCS;
declare variable FORMAPAGOSATCLAVE D_CLAVE_NULL;
declare variable FORMAPAGOSATNOMBRE D_NOMBRE;
declare variable IMPORTEXFORMAPAGO D_PRECIO;
BEGIN
    TIMBRADOFORMAPAGOSAT = '';

    ERRORCODE = 0;

   SELECT COUNT(*) FROM DOCTOPAGO WHERE DOCTOID = :DOCTOID  or DOCTOSALIDAID = :DOCTOID
   INTO :CUENTADOCTOPAGOS;

   IF(COALESCE(:CUENTADOCTOPAGOS,0) = 0) THEN
   BEGIN
    ERRORCODE = 1084;
    SUSPEND;
    EXIT;
   END


   SELECT FIRST 1 SALDO, TOTAL FROM DOCTO WHERE ID = :DOCTOID INTO :SALDO  , :TOTAL;

   IF(COALESCE(:SALDO,0) = COALESCE(:TOTAL,0)) THEN
   BEGIN
    TIMBRADOFORMAPAGOSAT = '99';
    SUSPEND;
    EXIT;
   END


   ESPRIMERFORMAPAGO = 'S';

   FOR
     SELECT FORMAPAGOSAT.clave,  FORMAPAGOSAT.NOMBRE , sum(coalesce(doctopago.importe,0))
     FROM DOCTOPAGO LEFT JOIN
     FORMAPAGOSAT ON coalesce(DOCTOPAGO.formapagosatid,99) = FORMAPAGOSAT.ID
     WHERE DOCTOID = :DOCTOID  or DOCTOSALIDAID = :DOCTOID and doctopago.formapagoid in (1,2,3,5,14,15)
     group by coalesce(DOCTOPAGO.formapagosatid,99) , FORMAPAGOSAT.clave,  FORMAPAGOSAT.NOMBRE
     having sum(coalesce(doctopago.importe,0)) > 0
     order by sum(coalesce(doctopago.importe,0)) desc
     into :formapagosatclave, :formapagosatnombre, :IMPORTEXFORMAPAGO
     do
     begin


        IF(coalesce(:saldo,0) > coalesce(:IMPORTEXFORMAPAGO,0)) then
        begin
        
            if(:ESPRIMERFORMAPAGO  = 'S') then
            begin
                TIMBRADOFORMAPAGOSAT  = '99';
                ESPRIMERFORMAPAGO  = 'N';
            end
            else
            begin 
               TIMBRADOFORMAPAGOSAT  = :TIMBRADOFORMAPAGOSAT || ',' || '99';
            end
        end


        if(:ESPRIMERFORMAPAGO  = 'S') then
        begin
            TIMBRADOFORMAPAGOSAT  = :formapagosatclave;
            ESPRIMERFORMAPAGO  = 'N';
        end
        else
        begin 
            TIMBRADOFORMAPAGOSAT  = :TIMBRADOFORMAPAGOSAT || ',' || :formapagosatclave;
        end
        
     end


   ERRORCODE = 0;
   SUSPEND;
   
    WHEN ANY DO
    BEGIN
        ERRORCODE = 1009;
        SUSPEND;
    END
END