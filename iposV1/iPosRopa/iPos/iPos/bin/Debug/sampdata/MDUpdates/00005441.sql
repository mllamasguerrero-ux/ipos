create or alter procedure PAGO_MARCAR_SATPUE_SIAPLICA (
    DOCTOID D_PK)
returns (
    REQUIEREAPLICARPAGOS D_BOOLCN,
    ERRORCODE D_ERRORCODE)
as
declare variable CUENTACREDITO D_INTEGER;
declare variable CUENTANOCREDITO D_INTEGER;
declare variable CUENTACREDITO_A D_INTEGER;
declare variable CUENTANOCREDITO_A D_INTEGER;
declare variable CUENTACREDITO_B D_INTEGER;
declare variable CUENTANOCREDITO_B D_INTEGER;
declare variable PAGOID D_FK;
BEGIN


   SELECT COUNT(*) FROM doctopago
   WHERE ((DOCTOPAGO.tipopagoid = 1 AND DOCTOPAGO.DOCTOID = :DOCTOID) )
   and doctopago.formapagoid = 4
   INTO :CUENTACREDITO_A;

   
   SELECT COUNT(*) FROM doctopago
   WHERE ((DOCTOPAGO.tipopagoid = 2 AND DOCTOPAGO.DOCTOSALIDAID = :DOCTOID))
   and doctopago.formapagoid = 4
   INTO :CUENTACREDITO_B;

   CUENTACREDITO = COALESCE(:CUENTACREDITO_A, 0) + COALESCE(:CUENTACREDITO_B, 0);

      
   SELECT COUNT(*) FROM doctopago
   WHERE ((DOCTOPAGO.tipopagoid = 1 AND DOCTOPAGO.DOCTOID = :DOCTOID))
   and doctopago.formapagoid IN (1,2,3,5,15,20,21)
   INTO :CUENTANOCREDITO_A;

   
   SELECT COUNT(*) FROM doctopago
   WHERE ((DOCTOPAGO.tipopagoid = 2 AND DOCTOPAGO.DOCTOSALIDAID = :DOCTOID))
   and doctopago.formapagoid IN (1,2,3,5,15,20,21)
   INTO :CUENTANOCREDITO_B;
                        
   CUENTANOCREDITO = COALESCE(:CUENTANOCREDITO_A, 0) + COALESCE(:CUENTANOCREDITO_B, 0);


   IF(COALESCE(:CUENTACREDITO,0) > 0 AND COALESCE(:CUENTANOCREDITO,0)> 0) THEN
   BEGIN
       REQUIEREAPLICARPAGOS = 'S';
   END
   ELSE
   BEGIN
        REQUIEREAPLICARPAGOS = 'N';
   END

   IF(COALESCE(:CUENTACREDITO,0) = 0 AND COALESCE(:CUENTANOCREDITO,0) > 0) THEN
   BEGIN
        UPDATE DOCTOPAGO
        SET DOCTOPAGO.reciboelectronicoid = -2
        WHERE ((DOCTOPAGO.tipopagoid = 1 AND DOCTOPAGO.DOCTOID = :DOCTOID))
            and doctopago.formapagoid IN (1,2,3,5,15,20,21)
            AND COALESCE(DOCTOPAGO.reciboelectronicoid,0) = 0;


            
        UPDATE DOCTOPAGO
        SET DOCTOPAGO.reciboelectronicoid = -2
        WHERE ((DOCTOPAGO.tipopagoid = 2 AND DOCTOPAGO.DOCTOSALIDAID = :DOCTOID))
            and doctopago.formapagoid IN (1,2,3,5,15,20,21)
            AND COALESCE(DOCTOPAGO.reciboelectronicoid,0) = 0;



        FOR SELECT  DOCTOPAGO.pagoid FROM DOCTOPAGO
                WHERE ((DOCTOPAGO.tipopagoid = 1 AND DOCTOPAGO.DOCTOID = :DOCTOID))
                and doctopago.formapagoid IN (1,2,3,5,15,20,21)
                AND COALESCE(DOCTOPAGO.reciboelectronicoid,0) = -2
                INTO :PAGOID
                DO
        BEGIN
           UPDATE PAGO SET PAGO.reciboelectronicoid = -2
            WHERE COALESCE(PAGO.reciboelectronicoid,0) = 0 AND ID = :PAGOID;

        END

        
        FOR SELECT  DOCTOPAGO.pagoid FROM DOCTOPAGO
                WHERE ((DOCTOPAGO.tipopagoid = 2 AND DOCTOPAGO.DOCTOSALIDAID = :DOCTOID))
                and doctopago.formapagoid IN (1,2,3,5,15,20,21)
                AND COALESCE(DOCTOPAGO.reciboelectronicoid,0) = -2
                INTO :PAGOID
                DO
        BEGIN
           UPDATE PAGO SET PAGO.reciboelectronicoid = -2
            WHERE COALESCE(PAGO.reciboelectronicoid,0) = 0 AND ID = :PAGOID;

        END




   END




   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1015;
      SUSPEND;
   END 
END