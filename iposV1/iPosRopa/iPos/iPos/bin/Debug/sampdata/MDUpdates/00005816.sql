CREATE OR ALTER trigger doctopago_aiu4_intercambio for doctopago
active after insert position 0
AS
declare variable ABONO d_precio;
declare variable TIPODOCTOIDENTRADA d_fk;
declare variable TIPODOCTOIDSALIDA d_fk;
declare variable ABONA d_boolcn;
declare variable AFECTASALDOPERSONA D_BOOLCN ;
declare variable SENTIDO d_precio;
declare variable PERSONAIDENTRADA D_FK;
declare variable PERSONAIDSALIDA D_FK;
declare variable DOCTOIDBUFFER D_FK;
declare variable SALDOBUFFER D_PRECIO;   
declare variable RESTANTEBUFFER D_PRECIO;
declare variable abono_aux d_precio;   
declare variable FACTCONSID D_FK;
declare variable VENTAFUTUIDENTRADA D_FK;
declare variable SUBTIPODOCTOIDENTRADA D_FK;

declare variable SALDOPROVEEDOR D_IMPORTE;

declare variable SENTIDOFORMAPAGO D_PRECIO; 
declare variable SOLOABONOAPLICADO D_BOOLCN;  
declare variable ABONONOAPLICADO d_precio;

BEGIN

-- Los pagos de apartados no se procesan aqui
IF(NEW.ESAPARTADO = 'N' and NEW.FORMAPAGOID IN (18,19)) THEN
BEGIN

   SELECT tipodoctoid from docto where  id = NEW.DOCTOID  INTO :TIPODOCTOIDENTRADA;
   SELECT tipodoctoid from docto where  id = NEW.DOCTOSALIDAID  INTO :TIPODOCTOIDSALIDA;

   SELECT abona, afectasaldopersona from formapago where id = new.formapagoid into :ABONA,:AFECTASALDOPERSONA;


      
   SELECT FIRST 1  SOLOABONOAPLICADO FROM PARAMETRO INTO :SOLOABONOAPLICADO;
    SELECT personaid, subtipodoctoid, ventafutuid FROM DOCTO WHERE ID = NEW.DOCTOID INTO :PERSONAIDENTRADA, :SUBTIPODOCTOIDENTRADA, :VENTAFUTUIDENTRADA;
    SELECT personaid FROM DOCTO WHERE ID = NEW.DOCTOSALIDAID INTO :PERSONAIDSALIDA;





   IF(:ABONA = 'S') then
   begin
       --if (:TIPODOCTOIDENTRADA IN (21,24,25) AND (NEW.formapagoid in (6,7) or NEW.tipopagoid = 1 ) ) THEN
        IF(NEW.DOCTOID  IS NOT NULL) THEN
       BEGIN


          select coalesce(sum(p.importe *
            (
                CASE WHEN ((TIPOPAGOID = 1 AND FORMAPAGOID IN (1,2,3,4,5,6,14,15,16,17,18,20,21)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (7,19)))  THEN 1
                when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6,18))) THEN -1
                ELSE 0 END)  *
            (
                CASE WHEN COALESCE(:SOLOABONOAPLICADO,'N') = 'N' OR COALESCE(APLICADO,'N') = 'S' OR FORMAPAGOID <> 3 THEN 1
                ELSE 0 END
             )
          ),0) ABONO ,
            coalesce(sum(p.importe *
            (
                CASE WHEN ((TIPOPAGOID = 1 AND FORMAPAGOID IN (1,2,3,4,5,6,14,15,16,17,18,20,21)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (7,19)))  THEN 1
                when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6,18))) THEN -1
                ELSE 0 END)  *
            (
                CASE WHEN COALESCE(:SOLOABONOAPLICADO,'N') = 'N' OR COALESCE(APLICADO,'N') = 'S' OR FORMAPAGOID <> 3 THEN 0
                ELSE 1 END
             )
          ),0) ABONONOAPLICADO  from doctopago p inner join formapago f on p.formapagoid = f.id
          where p.doctoid = new.doctoid and f.abona = 'S' into :abono,:ABONONOAPLICADO;

                       /* anticipo */
          if(  :TIPODOCTOIDENTRADA = 203) then
          begin
                select coalesce(sum(p.importe *
                (CASE WHEN ((TIPOPAGOID = 2 AND FORMAPAGOID IN (1,2,3,4,5,7,14,15,16,17,19,20,21)) or (TIPOPAGOID = 1 AND FORMAPAGOID IN (6,18)))  THEN 1
                    when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6,18)))  THEN -1
                    ELSE 0 END)   *
                (
                    CASE WHEN COALESCE(:SOLOABONOAPLICADO,'N') = 'N' OR COALESCE(APLICADO,'N') = 'S' OR FORMAPAGOID <> 3 THEN 1
                    ELSE 0 END
                )
                ),0) from doctopago p inner join formapago f on p.formapagoid = f.id
                where p.doctosalidaid = new.doctoid and f.abona = 'S' into :abono_aux;
                abono = :abono_aux - :abono;
          end


          UPDATE DOCTO SET ABONO = :ABONO , SALDO = CARGO - :ABONO, ABONONOAPLICADO = :ABONONOAPLICADO WHERE ID = NEW.DOCTOID;

          SELECT FACTCONSID FROM DOCTO WHERE ID = NEW.DOCTOID INTO :FACTCONSID;
          IF(COALESCE(:FACTCONSID,0) > 0 ) THEN
          BEGIN

            UPDATE DOCTO SET ABONO = ABONO + NEW.IMPORTE , SALDO = CARGO - (ABONO + NEW.IMPORTE) WHERE ID = :FACTCONSID;
          END


       END


       FACTCONSID = 0;
       
       --if (:TIPODOCTOIDSALIDA = 22 AND (NEW.formapagoid  in (6,7) or NEW.tipopagoid = 2 )) THEN
       IF(NEW.DOCTOSALIDAID  IS NOT NULL) THEN
       BEGIN
          select
            coalesce(sum(p.importe *
                (
                    CASE WHEN ((TIPOPAGOID = 2 AND FORMAPAGOID IN (1,2,3,4,5,7,14,15,16,17,19,20,21)) or (TIPOPAGOID = 1 AND FORMAPAGOID IN (6,18)))  THEN 1
                    when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6,18)))  THEN -1
                    ELSE 0 END)   *
                (
                    CASE WHEN COALESCE(:SOLOABONOAPLICADO,'N') = 'N' OR COALESCE(APLICADO,'N') = 'S' OR FORMAPAGOID <> 3 THEN 1
                    ELSE 0 END
                )
            ),0) ABONO,
            coalesce(sum(p.importe *
                (
                    CASE WHEN ((TIPOPAGOID = 2 AND FORMAPAGOID IN (1,2,3,4,5,7,14,15,16,17,19,20,21)) or (TIPOPAGOID = 1 AND FORMAPAGOID IN (6,18)))  THEN 1
                    when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6,18)))  THEN -1
                    ELSE 0 END)   *
                (
                    CASE WHEN COALESCE(:SOLOABONOAPLICADO,'N') = 'N' OR COALESCE(APLICADO,'N') = 'S' OR FORMAPAGOID <> 3 THEN 0
                    ELSE 1 END
                )
            ),0) ABONONOAPLICADO from doctopago p inner join formapago f on p.formapagoid = f.id
          where p.doctosalidaid = new.doctosalidaid and f.abona = 'S' into :abono,:ABONONOAPLICADO;

          /* anticipo */
          if(  :TIPODOCTOIDSALIDA in  (201)) then
          begin
                select coalesce(sum(p.importe *
                    (
                        CASE WHEN ((TIPOPAGOID = 1 AND FORMAPAGOID IN (1,2,3,4,5,6,14,15,16,17,18,20,21)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (7,19)))  THEN 1
                        when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6,18))) THEN -1
                        ELSE 0 END)  *
                    (
                        CASE WHEN COALESCE(:SOLOABONOAPLICADO,'N') = 'N' OR COALESCE(APLICADO,'N') = 'S' OR FORMAPAGOID <> 3 THEN 1
                        ELSE 0 END
                    )
                ),0) from doctopago p inner join formapago f on p.formapagoid = f.id
                where p.doctoid = new.doctosalidaid and f.abona = 'S' into :abono_aux;
                abono = :abono_aux - :abono;
          end


          UPDATE DOCTO SET ABONO = :ABONO , SALDO = CARGO - :ABONO, ABONONOAPLICADO = :ABONONOAPLICADO WHERE ID = NEW.DOCTOSALIDAID;
          
          SELECT FACTCONSID FROM DOCTO WHERE ID = NEW.DOCTOSALIDAID INTO :FACTCONSID;
          IF(COALESCE(:FACTCONSID,0) > 0 ) THEN
          BEGIN
            UPDATE DOCTO SET ABONO = ABONO + NEW.IMPORTE , SALDO = CARGO - (ABONO + NEW.IMPORTE) WHERE ID = :FACTCONSID;
          END

       END

    END

     IF(:afectasaldopersona  = 'S') THEN
     BEGIN

       SENTIDOFORMAPAGO = case when NEW.FORMAPAGOID = 18 then 1.00 ELSE -1.00 END;

       IF(new.tipopagoid = 1) then
       begin
            SENTIDO = 1.00 * SENTIDOFORMAPAGO;
       end
       ELSE IF(new.tipopagoid = 2) THEN
       BEGIN
            SENTIDO = -1.00 * SENTIDOFORMAPAGO;
       END
       else
       begin
          SENTIDO = 0;
       end
                                  

     
        if (:TIPODOCTOIDENTRADA IN (21,24,25,201,31)  AND COALESCE(:PERSONAIDENTRADA,0) <> 0) THEN
        BEGIN
           UPDATE PERSONA SET SALDO = coalesce(SALDO,0) + (NEW.IMPORTE * :SENTIDO) WHERE ID = :PERSONAIDENTRADA;
        END
        if (:TIPODOCTOIDSALIDA in (11,12,13,15,60,16,18,202,204)   AND COALESCE(:PERSONAIDSALIDA,0) <> 0) then
        BEGIN
           UPDATE PERSONA SET SALDO = coalesce(SALDO,0) + (NEW.IMPORTE * :SENTIDO * -1) WHERE ID = :PERSONAIDSALIDA;

        END
     END




     






 END
END