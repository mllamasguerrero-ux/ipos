CREATE OR ALTER trigger producto_bi_autocomplete for producto
active before insert position 0
AS
begin
  NEW.ultimocambioexistencia = CURRENT_TIMESTAMP  ;
end