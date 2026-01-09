CREATE OR ALTER trigger persona_au_proveecliente for persona
active after update position 98
AS
  declare variable PROVEECLIENTEIDREF D_FK;
begin
  /* Trigger text */

  IF(COALESCE(NEW.proveeclienteid,0) <> COALESCE(OLD.proveeclienteid,0) AND
     NEW.tipopersonaid IN (40,50)) THEN
  BEGIN

        IF(coalesce(old.proveeclienteid ,0) <> 0 ) THEN
        BEGIN
            UPDATE PERSONA SET PROVEECLIENTEID = NULL WHERE ID = OLD.proveeclienteid;
        END

      SELECT PROVEECLIENTEID FROM PERSONA WHERE ID = NEW.proveeclienteid
      INTO :PROVEECLIENTEIDREF;

      IF(COALESCE(:PROVEECLIENTEIDREF,0) <> COALESCE(NEW.ID,0)) THEN
      BEGIN
          UPDATE PERSONA SET proveeclienteid = NEW.ID WHERE ID = NEW.proveeclienteid;
      END

  END
end