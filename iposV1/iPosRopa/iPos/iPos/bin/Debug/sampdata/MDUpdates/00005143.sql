CREATE OR ALTER trigger docto_aukitref for docto
active after update position 0
AS
declare variable ERRORCODE D_ERRORCODE;
begin
  /* Trigger text */


    IF ((OLD.ESTATUSDOCTOID = 0) AND (NEW.ESTATUSDOCTOID = 1) ) THEN
    BEGIN
       SELECT errorcode FROM KIT_CREARREFERENCIA(NEW.ID) INTO :ERRORCODE;

    END


end