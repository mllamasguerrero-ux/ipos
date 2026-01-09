CREATE OR ALTER trigger kitdefinicion_ai0 for kitdefinicion
active after insert or update position 0
AS
declare variable ERRORCODE D_ERRORCODE;
begin
  /* Trigger text */
  
  SELECT ERRORCODE FROM KIT_ACTUALIZARIMPUESTOKIT (NEW.productokitid) INTO :ERRORCODE;

end