CREATE OR ALTER TRIGGER DOCTOPAGO_AI_ETIQUETACREDITO FOR DOCTOPAGO
ACTIVE AFTER INSERT POSITION 0
AS
begin
  /* Trigger text */

  IF(new.formapagoid in (4,6,7)) then
  begin
     if(coalesce(new.doctoid ,0) <> 0) then
     begin
        update docto set docto.hatenidocredito = 'S' where id = new.doctoid;
     end

     
     if(coalesce(new.doctosalidaid ,0) <> 0) then
     begin                      
        update docto set docto.hatenidocredito = 'S' where id = new.doctosalidaid;
     end
  end
end