CREATE OR ALTER TRIGGER DOCTOPAGO_AIU0 FOR DOCTOPAGO
ACTIVE AFTER INSERT POSITION 0
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

BEGIN

-- Los pagos de apartados no se procesan aqui
IF(NEW.ESAPARTADO = 'N') THEN
BEGIN

   SELECT tipodoctoid from docto where  id = NEW.DOCTOID  INTO :TIPODOCTOIDENTRADA;
   SELECT tipodoctoid from docto where  id = NEW.DOCTOSALIDAID  INTO :TIPODOCTOIDSALIDA;

   if(:TIPODOCTOIDENTRADA  in (11,12,13,15,60,16,18,202,204) or :TIPODOCTOIDSALIDA in (11,12,13,15,60,16,18,202,204)) then
   begin
     exit;
   end

   SELECT abona, afectasaldopersona from formapago where id = new.formapagoid into :ABONA,:AFECTASALDOPERSONA;



    SELECT personaid FROM DOCTO WHERE ID = NEW.DOCTOID INTO :PERSONAIDENTRADA;   
    SELECT personaid FROM DOCTO WHERE ID = NEW.DOCTOSALIDAID INTO :PERSONAIDSALIDA;





   IF(:ABONA = 'S') then
   begin
       --if (:TIPODOCTOIDENTRADA IN (21,24,25) AND (NEW.formapagoid in (6,7) or NEW.tipopagoid = 1 ) ) THEN
        IF(NEW.DOCTOID  IS NOT NULL) THEN
       BEGIN


          select coalesce(sum(p.importe *
          (CASE WHEN ((TIPOPAGOID = 1 AND FORMAPAGOID IN (1,2,3,4,5,6,14,15,16)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (7)))  THEN 1
                when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6))) THEN -1
                ELSE 0 END)
          ),0) from doctopago p inner join formapago f on p.formapagoid = f.id
          where p.doctoid = new.doctoid and f.abona = 'S' into :abono;

                       /* anticipo */
          if(  :TIPODOCTOIDENTRADA = 203) then
          begin
                select coalesce(sum(p.importe *
                (CASE WHEN ((TIPOPAGOID = 2 AND FORMAPAGOID IN (1,2,3,4,5,7,14,15,16)) or (TIPOPAGOID = 1 AND FORMAPAGOID IN (6)))  THEN 1
                    when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6)))  THEN -1
                    ELSE 0 END)
                ),0) from doctopago p inner join formapago f on p.formapagoid = f.id
                where p.doctosalidaid = new.doctoid and f.abona = 'S' into :abono_aux;
                abono = :abono_aux - :abono;
          end


          UPDATE DOCTO SET ABONO = :ABONO , SALDO = CARGO - :ABONO WHERE ID = NEW.DOCTOID;

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
          select coalesce(sum(p.importe *
           (CASE WHEN ((TIPOPAGOID = 2 AND FORMAPAGOID IN (1,2,3,4,5,7,14,15,16)) or (TIPOPAGOID = 1 AND FORMAPAGOID IN (6)))  THEN 1
                when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6)))  THEN -1
                ELSE 0 END)
          ),0) from doctopago p inner join formapago f on p.formapagoid = f.id
          where p.doctosalidaid = new.doctosalidaid and f.abona = 'S' into :abono;

          /* anticipo */
          if(  :TIPODOCTOIDSALIDA = 201) then
          begin
                select coalesce(sum(p.importe *
                (CASE WHEN ((TIPOPAGOID = 1 AND FORMAPAGOID IN (1,2,3,4,5,6,14,15,16)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (7)))  THEN 1
                    when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6))) THEN -1
                    ELSE 0 END)
                ),0) from doctopago p inner join formapago f on p.formapagoid = f.id
                where p.doctoid = new.doctosalidaid and f.abona = 'S' into :abono_aux;
                abono = :abono_aux - :abono;
          end


          UPDATE DOCTO SET ABONO = :ABONO , SALDO = CARGO - :ABONO WHERE ID = NEW.DOCTOSALIDAID;
          
          SELECT FACTCONSID FROM DOCTO WHERE ID = NEW.DOCTOSALIDAID INTO :FACTCONSID;
          IF(COALESCE(:FACTCONSID,0) > 0 ) THEN
          BEGIN
            UPDATE DOCTO SET ABONO = ABONO + NEW.IMPORTE , SALDO = CARGO - (ABONO + NEW.IMPORTE) WHERE ID = :FACTCONSID;
          END

       END

    END

     IF(:afectasaldopersona  = 'S') THEN
     BEGIN

       IF(new.tipopagoid = 1) then
       begin
            SENTIDO = 1.00;
       end
       ELSE IF(new.tipopagoid = 2) THEN
       BEGIN
            SENTIDO = -1.00;
       END
       else
       begin
          SENTIDO = 0;
       end
     
        if (:TIPODOCTOIDENTRADA IN (21,24,25,201,31) AND NEW.TIPOPAGOID = 1 AND COALESCE(:PERSONAIDENTRADA,0) <> 0) THEN
        BEGIN
           UPDATE PERSONA SET SALDO = coalesce(SALDO,0) + (NEW.IMPORTE * :SENTIDO) WHERE ID = :PERSONAIDENTRADA;
        END
        ELSE if (:TIPODOCTOIDSALIDA in (22,23,203,33)  AND NEW.TIPOPAGOID = 2 AND COALESCE(:PERSONAIDSALIDA,0) <> 0) then
        BEGIN
           UPDATE PERSONA SET SALDO = coalesce(SALDO,0) + (NEW.IMPORTE * :SENTIDO) WHERE ID = :PERSONAIDSALIDA;
        END
     END





     RESTANTEBUFFER =   NEW.IMPORTE;





     
     IF(NEW.FORMAPAGOID = 4 AND NEW.TIPOPAGOID = 2 AND :TIPODOCTOIDSALIDA = 22 AND :RESTANTEBUFFER > 0
        AND NEW.tipoaplicacioncreditoid = 2 AND NEW.DOCTOID IS NOT NULL) THEN
     BEGIN
            SELECT D.ID, D.SALDO
            FROM DOCTO D
            WHERE D.SALDO > 0 AND D.ID = NEW.doctoid
            INTO   :DOCTOIDBUFFER, :SALDOBUFFER;

            IF(:DOCTOIDBUFFER IS NOT NULL AND COALESCE(:SALDOBUFFER,0)>0) THEN
            BEGIN
            
              IF(:RESTANTEBUFFER > :SALDOBUFFER) THEN
              BEGIN
                 INSERT INTO DOCTOPAGO ( DOCTOID, FORMAPAGOID, FECHA, FECHAHORA, CORTEID, IMPORTE, IMPORTERECIBIDO, IMPORTECAMBIO, TIPOPAGOID, DOCTOSALIDAID)
                             VALUES (:DOCTOIDBUFFER, 6, NEW.FECHA, NEW.FECHAHORA,NEW.CORTEID, :SALDOBUFFER,:SALDOBUFFER, 0, 1, NEW.DOCTOSALIDAID);
                  RESTANTEBUFFER = :RESTANTEBUFFER - :SALDOBUFFER;
              END
              ELSE
              BEGIN
                  
                   INSERT INTO DOCTOPAGO ( DOCTOID, FORMAPAGOID, FECHA, FECHAHORA, CORTEID, IMPORTE, IMPORTERECIBIDO, IMPORTECAMBIO, TIPOPAGOID, DOCTOSALIDAID)
                             VALUES (:DOCTOIDBUFFER, 6, NEW.FECHA, NEW.FECHAHORA,NEW.CORTEID, :RESTANTEBUFFER,:RESTANTEBUFFER, 0, 1, NEW.DOCTOSALIDAID);
                    RESTANTEBUFFER = 0;
              END
            END


     END


     






 END
END
