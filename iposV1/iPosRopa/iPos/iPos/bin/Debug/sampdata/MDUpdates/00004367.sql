CREATE OR ALTER trigger movtogasto_au1 for movtogasto
active after update position 1
AS                 
   DECLARE VARIABLE ERRORCODE D_ERRORCODE;
begin
  /* Trigger text */
    IF (NOT ((NEW.TOTAL IS NULL) )) THEN
    BEGIN
        SELECT ERRORCODE
        FROM DOCTO_ACUMULAR_TOTALES (
           NEW.DOCTOID,
           NEW.TOTAL - OLD.TOTAL,
           NEW.TOTAL - OLD.TOTAL,
           0,
           NEW.TOTAL - OLD.TOTAL ,
           0 ,
           0  ,
           0,
           0,
           0,
           0
        ) INTO :ERRORCODE;
    END

end