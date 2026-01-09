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
declare variable VERSIONCFDI D_STDTEXT_SHORT;
declare variable CUENTADOCTOPAGOCREDITO integer;
declare variable CUENTAPAGOSTOPE integer;
declare variable CUENTABUFFER integer;
declare variable IMPORTEMAX D_IMPORTE;
declare variable PRE_FORMAPAGOSAT D_STDTEXT_SHORT;
BEGIN
    TIMBRADOFORMAPAGOSAT = '';

    ERRORCODE = 0;

    SELECT VERSIONCFDI FROM PARAMETRO INTO :VERSIONCFDI;
    
   SELECT FIRST 1 SALDO, TOTAL, TIPODOCTOID, DOCTOPAGOSAT , TIMBRADOFORMAPAGOSAT
   FROM DOCTO WHERE ID = :DOCTOID INTO :SALDO  , :TOTAL, :TIPODOCTOID, :DOCTOPAGOSAT, :PRE_FORMAPAGOSAT;

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

  IF(COALESCE(:VERSIONCFDI,'') <> '3.3') THEN
  BEGIN
   IF(COALESCE(:TIPODOCTOID,0) <> 205) THEN
   BEGIN
    FOR
     SELECT FORMAPAGOSAT.clave,  FORMAPAGOSAT.NOMBRE , sum(coalesce(doctopago.importe,0))
     FROM DOCTOPAGO LEFT JOIN
     FORMAPAGOSAT ON coalesce(DOCTOPAGO.formapagosatid,99) = FORMAPAGOSAT.ID
     WHERE DOCTOID = :DOCTOID  or DOCTOSALIDAID = :DOCTOID and doctopago.formapagoid in (1,2,3,5,14,15,20,21)
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
    END
    ELSE
    BEGIN
        
        IF(COALESCE(:TIPODOCTOID,0) <> 205) THEN
        BEGIN

        
            SELECT COUNT(*) FROM DOCTOPAGO WHERE DOCTOID = :DOCTOID
            AND DOCTOPAGO.formapagoid = 4 INTO :CUENTADOCTOPAGOCREDITO;

            
            IF(COALESCE(:CUENTADOCTOPAGOCREDITO, 0) > 0 ) THEN
            BEGIN      
                TIMBRADOFORMAPAGOSAT  = '99';
            END
            ELSE
                
                SELECT FIRST 1 FORMAPAGOSAT.CLAVE CLAVE, SUM(COALESCE(DOCTOPAGO.IMPORTE,0)) IMPORTEMAX
                FROM doctopago
                LEFT JOIN FORMAPAGOSAT ON FORMAPAGOSAT.ID = DOCTOPAGO.FORMAPAGOSATID
                WHERE ((:TIPODOCTOID = 21 AND DOCTOID = :DOCTOID) or (:TIPODOCTOID = 22 AND DOCTOSALIDAID = :DOCTOID)  )
                    AND COALESCE(DOCTOPAGO.formapagosatid,0) <> 0 AND
                    COALESCE(DOCTOPAGO.revertido, 'N') = 'N'  AND DOCTOPAGO.formapagoid IN (1,2,3,5,15)
                GROUP BY DOCTOPAGO.formapagosatid ,FORMAPAGOSAT.CLAVE
                ORDER by SUM(COALESCE(DOCTOPAGO.IMPORTE,0)) DESC
                INTO :formapagosatclave, :IMPORTEMAX;




                --SI HAY MAS DE UN PAGO TOPE Y HAY UNA FORMA DE PAGO PRECARGADA
                IF( COALESCE(:PRE_FORMAPAGOSAT,'') <> '') THEN
                BEGIN
                  IF(COALESCE(:FORMAPAGOSATCLAVE,'') <> COALESCE(:PRE_FORMAPAGOSAT,'')) THEN
                  BEGIN
                       SELECT FIRST 1  1 CUENTABUFFER
                        FROM doctopago
                        LEFT JOIN FORMAPAGOSAT ON FORMAPAGOSAT.ID = DOCTOPAGO.FORMAPAGOSATID
                        WHERE ((:TIPODOCTOID = 21 AND DOCTOID = :DOCTOID) or (:TIPODOCTOID = 22 AND DOCTOSALIDAID = :DOCTOID)  )
                            AND COALESCE(DOCTOPAGO.formapagosatid,0) <> 0 AND
                            COALESCE(DOCTOPAGO.revertido, 'N') = 'N'  AND DOCTOPAGO.formapagoid IN (1,2,3,5,15)
                            AND FORMAPAGOSAT.clave = :PRE_FORMAPAGOSAT
                            GROUP BY DOCTOPAGO.formapagosatid ,FORMAPAGOSAT.CLAVE
                            HAVING SUM(COALESCE(DOCTOPAGO.IMPORTE,0)) = :IMPORTEMAX
                            INTO :CUENTABUFFER;


                         IF(COALESCE(:cuentabuffer, 0) > 0) THEN
                         BEGIN
                             formapagosatclave = :PRE_FORMAPAGOSAT;
                         END
                  END

                END

                TIMBRADOFORMAPAGOSAT  = COALESCE(:formapagosatclave,'99');




        END
        ELSE
        BEGIN
            

            
                SELECT FORMAPAGOSAT.clave,  FORMAPAGOSAT.NOMBRE
                FROM DOCTOPAGO LEFT JOIN
                FORMAPAGOSAT ON coalesce(DOCTOPAGO.formapagosatid,99) = FORMAPAGOSAT.ID
                WHERE DOCTOPAGO.ID = COALESCE(:DOCTOPAGOSAT,0)
                INTO :formapagosatclave, :formapagosatnombre ;

                TIMBRADOFORMAPAGOSAT  = :formapagosatclave;



        END

    END


   ERRORCODE = 0;
   SUSPEND;
   
   /* WHEN ANY DO
    BEGIN
        ERRORCODE = 1009;
        SUSPEND;
    END  */
END