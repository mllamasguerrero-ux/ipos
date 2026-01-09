CREATE OR ALTER TRIGGER DOCTOPAGO_AU_HDR FOR DOCTOPAGO
ACTIVE AFTER UPDATE POSITION 0
AS
begin
  /* Trigger text */
  IF(COALESCE(NEW.revertido,'N') <> COALESCE(OLD.revertido, 'N')  OR
     COALESCE(NEW.APLICADO,'N') <> COALESCE(OLD.APLICADO, 'N')  OR
     COALESCE(NEW.fechaaplicado,'01.01.2000') <> COALESCE(OLD.fechaaplicado,'01.01.2000') or
     COALESCE(NEW.cuentapagocredito,'') <> COALESCE(old.cuentapagocredito,'') or
     COALESCE(NEW.refinterno,'') <> COALESCE(old.refinterno,'')) THEN
  BEGIN
    UPDATE PAGO SET REVERTIDO = NEW.REVERTIDO ,
                    APLICADO = NEW.APLICADO,
                    FECHAAPLICADO = NEW.FECHAAPLICADO,
                    CUENTAPAGOCREDITO = NEW.CUENTAPAGOCREDITO  ,
                    REFINTERNO = NEW.REFINTERNO
    WHERE ID = NEW.PAGOID;
  END
end