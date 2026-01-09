CREATE OR ALTER trigger movtogasto_ad1 for movtogasto
active after delete position 0
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
             0,
             0
        ) INTO :ERRORCODE;
    END
END