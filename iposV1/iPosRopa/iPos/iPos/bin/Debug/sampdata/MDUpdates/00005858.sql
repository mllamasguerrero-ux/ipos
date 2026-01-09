CREATE OR ALTER trigger movtogasto_ai1 for movtogasto
active after insert position 1
AS
   DECLARE VARIABLE ERRORCODE D_ERRORCODE;
begin
  /* Trigger text */



   IF (NOT ((NEW.TOTAL IS NULL) )) THEN
    BEGIN
        SELECT ERRORCODE
        FROM DOCTO_ACUMULAR_TOTALES (
           NEW.DOCTOID,
           NEW.TOTAL,
           NEW.TOTAL,
           0,
           NEW.TOTAL  ,
           0,
           0  ,
           0 ,
           0,
           0,
           0,
           0
        ) INTO :ERRORCODE;
    END

end