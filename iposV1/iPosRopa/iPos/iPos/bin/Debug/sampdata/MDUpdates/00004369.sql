CREATE OR ALTER trigger movto_ai_1 for movto
active after insert position 10
AS
    DECLARE VARIABLE ERRORCODE D_ERRORCODE;
BEGIN
    IF (NOT ((NEW.TOTAL IS NULL) OR (NEW.TOTAL = 0))) THEN
    BEGIN
        SELECT ERRORCODE
        FROM DOCTO_ACUMULAR_TOTALES (
           NEW.DOCTOID,
           NEW.IMPORTE,
           NEW.SUBTOTAL,
           NEW.IVA,
           NEW.TOTAL  ,
           NEW.MONEDEROABONO,
           NEW.ISRRETENIDO,
           NEW.IVARETENIDO,
           NEW.IEPS,
           NEW.IMPUESTO,
           NEW.IMPORTEENDOLAR
        ) INTO :ERRORCODE;
    END
END