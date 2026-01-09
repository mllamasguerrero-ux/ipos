CREATE OR ALTER TRIGGER MOVTOGASTO_AD1 FOR MOVTOGASTO
ACTIVE AFTER DELETE POSITION 0
AS
    declare variable ERRORCODE D_ERRORCODE;
BEGIN
    IF (NOT ((OLD.TOTAL IS NULL) OR (OLD.TOTAL = 0))) THEN
    BEGIN
        SELECT ERRORCODE
        FROM DOCTO_ACUMULAR_TOTALES (
            OLD.DOCTOID,
            - OLD.TOTAL,
            - OLD.TOTAL,
             0,
            - OLD.TOTAL  ,
             0,
             0,
             0,
             0,
             0
        ) INTO :ERRORCODE;
    END
END