CREATE OR ALTER trigger docto_au_tasasieps for docto
active after update position 32
AS       
declare variable SENTIDOINVENTARIO D_SENTIDO;   
declare variable ERRORCODE D_ERRORCODE; 
begin
  /* Trigger text */

  
    SELECT TIPODOCTO.sentidoinventario
    FROM TIPODOCTO WHERE ID = NEW.tipodoctoid
    INTO :SENTIDOINVENTARIO;
  
    IF ((OLD.ESTATUSDOCTOID = 0) AND (NEW.ESTATUSDOCTOID = 1)  ) THEN
    BEGIN

        IF(COALESCE(:sentidoinventario, 0) <> 0) THEN
        BEGIN
           SELECT * FROM ACTUALIZAR_TABLA_IEPS_DOCTO(NEW.ID) INTO :ERRORCODE;
        END
    END



end