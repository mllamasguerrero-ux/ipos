CREATE OR ALTER TRIGGER PRODUCTO_AU0_AUTOCMP FOR PRODUCTO
ACTIVE AFTER UPDATE POSITION 0
AS
begin
  /* Trigger text */

  if(old.descripcion1 <> new.descripcion1) then
  begin
    
      update parametro set lastchangeproddesc = current_timestamp;
  end


  
   IF(NEW.cambioparamovil IS NOT NULL AND COALESCE(NEW.cambioparamovil, CURRENT_TIMESTAMP) <> COALESCE(OLD.cambioparamovil, CURRENT_TIMESTAMP)   ) THEN
   BEGIN
       UPDATE PARAMETRO SET PRODCAMBIOPARAMOVIL = NEW.CAMBIOPARAMOVIL WHERE PRODCAMBIOPARAMOVIL is null or PRODCAMBIOPARAMOVIL < NEW.CAMBIOPARAMOVIL;

   END

end