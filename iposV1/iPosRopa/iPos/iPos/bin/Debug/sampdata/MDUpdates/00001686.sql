CREATE trigger producto_ai0_autocomp for producto
active after insert position 0
AS
begin
  /* Trigger text */

  update parametro set lastchangeproddesc = current_timestamp;
end