CREATE OR ALTER TRIGGER DOCTO_BU0_TRASLADO FOR DOCTO
ACTIVE BEFORE UPDATE POSITION 0
AS
begin
  /* Trigger text */

  
       IF(   NEW.TIPODOCTOID = 31 AND COALESCE(NEW.subtipodoctoid,0) = 8 ) THEN
       BEGIN
              NEW.abono = NEW.total;
              NEW.saldo = 0;
       END
end