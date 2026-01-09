CREATE OR ALTER trigger doctopago_ai_vale for doctopago
active after insert position 998
AS
    declare variable ERRORCODE D_ERRORCODE;
begin
  /* Trigger text */

  IF(COALESCE(NEW.doctoid ,0) > 0 AND COALESCE(NEW.formapagoid,0) = 5) THEN
  BEGIN
    
     SELECT ERRORCODE FROM ASIGNARTOTALESSINVALE(NEW.doctoid) INTO :ERRORCODE;

  END


end