CREATE OR ALTER TRIGGER MOVTO_AD_1 FOR MOVTO
ACTIVE AFTER DELETE POSITION 10
AS
    declare variable ERRORCODE D_ERRORCODE;
BEGIN
   --insert into traza values ('antes ' || CAST(coalesce(OLD.TOTAL,0) AS VARCHAR(10)));
    IF (NOT ((OLD.TOTAL IS NULL) OR (OLD.TOTAL = 0))) THEN
    BEGIN
   --insert into traza values ('durante');
        SELECT ERRORCODE
        FROM DOCTO_ACUMULAR_TOTALES (
            OLD.DOCTOID,
            - OLD.IMPORTE,
            - OLD.SUBTOTAL,
            - OLD.IVA,
            - OLD.TOTAL  ,
            - OLD.MONEDEROABONO,
            - OLD.ISRRETENIDO,
            - OLD.IVARETENIDO
        ) INTO :ERRORCODE;
   --insert into traza values ('durante 2' || :ERRORCODE);
    END
   --insert into traza values ('despues');
END