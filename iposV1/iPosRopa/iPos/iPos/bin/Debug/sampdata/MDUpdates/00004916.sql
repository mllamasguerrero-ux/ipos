execute block
as
declare variable doctoid d_fk;  
declare variable doctosalidaid d_fk;
declare variable ABONO D_IMPORTE;
begin



  for select doctopago.doctoid
     from doctopago where doctopago.formapagoid in (18,19)
     group by doctopago.doctoid
     into
        :DOCTOID
     do
     begin



       --if (:TIPODOCTOIDENTRADA IN (21,24,25) AND (NEW.formapagoid in (6,7) or NEW.tipopagoid = 1 ) ) THEN
        IF(:DOCTOID  IS NOT NULL) THEN
       BEGIN


          select coalesce(sum(p.importe *
          (CASE WHEN ((TIPOPAGOID = 1 AND FORMAPAGOID IN (1,2,3,4,5,6,14,15,16,17,18,20,21)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (7,19)))  THEN 1
                when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6,18))) THEN -1
                ELSE 0 END)
          ),0) from doctopago p inner join formapago f on p.formapagoid = f.id
          where p.doctoid = :doctoid and f.abona = 'S' into :abono;




          UPDATE DOCTO SET ABONO = :ABONO , SALDO = CARGO - :ABONO WHERE ID = :DOCTOID;


       END




    end



  for select  doctopago.doctosalidaid
     from doctopago where doctopago.formapagoid in (18,19)
     group by  doctopago.doctosalidaid
     into
         :DOCTOSALIDAID
     do
     begin



       --if (:TIPODOCTOIDSALIDA = 22 AND (NEW.formapagoid  in (6,7) or NEW.tipopagoid = 2 )) THEN
       IF(:DOCTOSALIDAID  IS NOT NULL) THEN
       BEGIN
          select coalesce(sum(p.importe *
           (CASE WHEN ((TIPOPAGOID = 2 AND FORMAPAGOID IN (1,2,3,4,5,7,14,15,16,17,19,20,21)) or (TIPOPAGOID = 1 AND FORMAPAGOID IN (6,18)))  THEN 1
                when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6,18)))  THEN -1
                ELSE 0 END)
          ),0) from doctopago p inner join formapago f on p.formapagoid = f.id
          where p.doctosalidaid = :doctosalidaid and f.abona = 'S' into :abono;



          UPDATE DOCTO SET ABONO = :ABONO , SALDO = CARGO - :ABONO WHERE ID = :DOCTOSALIDAID;


       END

    end
 END