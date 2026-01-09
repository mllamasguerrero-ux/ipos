CREATE OR ALTER trigger persona_ai_proveecliente for persona
active after insert position 98
AS
  declare variable PROVEECLIENTEIDREF D_FK;
begin
  /* Trigger text */

  IF(COALESCE(NEW.proveeclienteid,0) <> 0 AND
     NEW.tipopersonaid IN (40,50)) THEN
  BEGIN

          UPDATE PERSONA SET proveeclienteid = NEW.ID WHERE ID = NEW.proveeclienteid;


  END
end