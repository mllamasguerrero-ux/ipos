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
declare variable TIPODOCTOID D_FK;
declare variable DOCTOPAGOSAT D_FK;
BEGIN
    TIMBRADOFORMAPAGOSAT = '';

    ERRORCODE = 0;

    
   SELECT FIRST 1 SALDO, TOTAL, TIPODOCTOID, DOCTOPAGOSAT FROM DOCTO WHERE ID = :DOCTOID INTO :SALDO  , :TOTAL, :TIPODOCTOID, :DOCTOPAGOSAT;

   SELECT COUNT(*) FROM DOCTOPAGO WHERE DOCTOID = :DOCTOID  or DOCTOSALIDAID = :DOCTOID
   INTO :CUENTADOCTOPAGOS;

   IF(COALESCE(:CUENTADOCTOPAGOS,0) = 0 and COALESCE(:TIPODOCTOID,0) NOT IN (205)) THEN
   BEGIN
    ERRORCODE = 1084;
    SUSPEND;
    EXIT;
   END


   IF(COALESCE(:SALDO,0) = COALESCE(:TOTAL,0)) THEN
   BEGIN
    TIMBRADOFORMAPAGOSAT = '99';
    SUSPEND;
    EXIT;
   END


   ESPRIMERFORMAPAGO = 'S';


   IF(COALESCE(:TIPODOCTOID,0) <> 205) THEN
   BEGIN
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
     end
     ELSE IF(COALESCE(:TIPODOCTOID,0) = 205) THEN
     BEGIN

        

        SELECT FORMAPAGOSAT.clave,  FORMAPAGOSAT.NOMBRE
        FROM DOCTOPAGO LEFT JOIN
        FORMAPAGOSAT ON coalesce(DOCTOPAGO.formapagosatid,99) = FORMAPAGOSAT.ID
        WHERE DOCTOPAGO.ID = COALESCE(:DOCTOPAGOSAT,0)
        INTO :formapagosatclave, :formapagosatnombre ;

         TIMBRADOFORMAPAGOSAT  = :formapagosatclave;


     END


   ERRORCODE = 0;
   SUSPEND;
   
   /* WHEN ANY DO
    BEGIN
        ERRORCODE = 1009;
        SUSPEND;
    END  */
END