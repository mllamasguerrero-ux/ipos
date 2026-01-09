CREATE OR ALTER TRIGGER MOVTO_AU_ULTIMOS FOR MOVTO
ACTIVE AFTER UPDATE POSITION 0
AS
begin
  /* Trigger text */

  
      IF ((OLD.ESTATUSMOVTOID = 0) AND (NEW.ESTATUSMOVTOID = 1))THEN
      BEGIN
         IF(NEW.tipodoctoid = 11) THEN
         BEGIN
            UPDATE PRODUCTO SET ULTIMACOMPRA = NEW.fecha WHERE ID = NEW.productoid;
         END 
         ELSE IF(NEW.tipodoctoid = 21) THEN
         BEGIN
             UPDATE PRODUCTO SET ULTIMAVENTA = NEW.fecha WHERE ID = NEW.productoid;
         END
      END

end