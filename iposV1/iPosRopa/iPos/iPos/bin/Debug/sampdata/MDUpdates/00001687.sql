CREATE trigger producto_au0_autocmp for producto
active after update position 0
AS
begin
  /* Trigger text */

  if(old.descripcion1 <> new.descripcion1) then
  begin
    
      update parametro set lastchangeproddesc = current_timestamp;
  end

end
