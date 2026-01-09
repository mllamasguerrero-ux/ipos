CREATE OR ALTER trigger doctopago_au_hdr for doctopago
active after update position 0
AS
begin
  /* Trigger text */
  IF(COALESCE(NEW.revertido,'N') <> COALESCE(OLD.revertido, 'N')  OR
     COALESCE(NEW.APLICADO,'N') <> COALESCE(OLD.APLICADO, 'N')  OR
     COALESCE(NEW.fechaaplicado,'01.01.2000') <> COALESCE(OLD.fechaaplicado,'01.01.2000')) THEN
  BEGIN
    UPDATE PAGO SET REVERTIDO = NEW.REVERTIDO ,
                    APLICADO = NEW.APLICADO,
                    FECHAAPLICADO = NEW.FECHAAPLICADO
    WHERE ID = NEW.PAGOID;
  END
end