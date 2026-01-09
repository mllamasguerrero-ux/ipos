CREATE OR ALTER trigger producto_bu_autocomplete for producto
active before update position 0
AS
begin
  if (NEW.existencia <> OLD.existencia
      OR NEW.inventariable <> OLD.inventariable
      or NEW.negativos <> OLD.NEGATIVOS )
      then NEW.ultimocambioexistencia = CURRENT_TIMESTAMP;
end