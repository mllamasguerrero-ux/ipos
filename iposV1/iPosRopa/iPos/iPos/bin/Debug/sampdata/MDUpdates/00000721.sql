CREATE OR ALTER TRIGGER MOVTO_BU20 FOR MOVTO
ACTIVE BEFORE UPDATE POSITION 20
AS
begin
  /* Trigger text */
  
   IF ((OLD.ESTATUSMOVTOID = 0) AND (NEW.ESTATUSMOVTOID = 1) AND old.registroprocesosalida = 'S')THEN
   BEGIN
       NEW.registroprocesosalida = 'N';
   END
end