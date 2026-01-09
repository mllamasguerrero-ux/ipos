CREATE OR ALTER TRIGGER PERSONA_REPL_BU FOR PERSONA
ACTIVE BEFORE UPDATE POSITION 0
AS
begin
  /* Trigger text */

  IF(NEW.tipopersonaid = 50 AND
        NEW.id <> 1 AND
        COALESCE(NEW.replmodificado,current_timestamp) = COALESCE(OLD.replmodificado,CURRENT_TIMESTAMP) AND
        COALESCE(NEW.saldo,0) <> COALESCE(OLD.SALDO,0) ) THEN
    BEGIN
        NEW.replmodificado = CURRENT_TIMESTAMP;
    END
end