CREATE OR ALTER trigger kitdefinicion_ad0 for kitdefinicion
active after delete position 0
AS
declare variable ERRORCODE D_ERRORCODE;
begin
  /* Trigger text */


  SELECT ERRORCODE FROM KIT_ACTUALIZARIMPUESTOKIT (OLD.productokitid) INTO :ERRORCODE;



end