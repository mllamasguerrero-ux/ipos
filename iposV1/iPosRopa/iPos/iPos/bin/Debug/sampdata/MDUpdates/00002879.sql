CREATE or alter  trigger movto_bu_ordencompra for movto
active before update position 8
AS
declare variable movtoidordencompra d_fk ;
--declare variable doctoid d_fk ;
begin
  /* Trigger text */

  IF(NEW.TIPODOCTOID = 16) THEN
  BEGIN
      if(old.estatusmovtoid = 0 and new.estatusmovtoid = 1) then
      begin
        new.cantidadfaltante = new.cantidad;
        new.cantidadsurtida = 0;

      end

  END




end

