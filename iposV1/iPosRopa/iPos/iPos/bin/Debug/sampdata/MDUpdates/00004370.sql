CREATE OR ALTER trigger movto_au_1 for movto
active after update position 10
AS
   DECLARE VARIABLE ERRORCODE D_ERRORCODE;
BEGIN
    /*if   (new.total is not null and
        (coalesce(new.importe,0) <> coalesce(old.importe,0) or
         coalesce(new.subtotal,0) <> coalesce(old.subtotal,0) or
         coalesce(new.iva,0) <> coalesce(old.iva,0) or
         coalesce(new.total,0) <> coalesce(old.total,0) or
         coalesce(new.monederoabono,0) <> coalesce(old.monederoabono,0)
         )
      ) then*/

   IF (NOT ((NEW.TOTAL IS NULL) /*OR (NEW.TOTAL = 0)*/)) THEN
    BEGIN
        SELECT ERRORCODE
        FROM DOCTO_ACUMULAR_TOTALES (
           NEW.DOCTOID,
           NEW.IMPORTE - OLD.IMPORTE,
           NEW.SUBTOTAL - OLD.SUBTOTAL,
           NEW.IVA - OLD.IVA,
           NEW.TOTAL - OLD.TOTAL ,
           COALESCE(NEW.MONEDEROABONO,0) - COALESCE(OLD.MONEDEROABONO,0) ,
           COALESCE(NEW.ISRRETENIDO,0) - COALESCE(OLD.ISRRETENIDO,0)  ,
           COALESCE(NEW.IVARETENIDO,0) - COALESCE(OLD.IVARETENIDO,0) ,
           NEW.IEPS - OLD.IEPS,
           NEW.IMPUESTO - OLD.IMPUESTO ,
           COALESCE(NEW.IMPORTEENDOLAR,0) - COALESCE(OLD.IMPORTEENDOLAR,0)
        ) INTO :ERRORCODE;
    END
END