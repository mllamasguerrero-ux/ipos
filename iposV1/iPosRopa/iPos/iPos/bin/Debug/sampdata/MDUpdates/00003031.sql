CREATE OR ALTER TRIGGER MOVTOGASTO_AI1 FOR MOVTOGASTO
ACTIVE AFTER INSERT POSITION 1
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
           0
        ) INTO :ERRORCODE;
    END

end