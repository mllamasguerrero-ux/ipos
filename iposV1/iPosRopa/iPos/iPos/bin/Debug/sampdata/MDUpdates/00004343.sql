CREATE OR ALTER trigger movto_biu_25 for movto
active before insert or update position 25
AS
DECLARE VARIABLE DESCPORC D_COSTO;
BEGIN
    IF ((NEW.PRECIOLISTA > NEW.PRECIO) ) THEN
    BEGIN

        IF(NEW.tipodoctoid NOT IN (11,12,13,14,15,16,17,18)) THEN
        BEGIN

            IF((NEW.DESCUENTO > 0.00) AND (NEW.DESCUENTO = (NEW.PRECIOLISTA - NEW.PRECIO))) THEN
            BEGIN
                DESCPORC = 100.00 * (CAST(NEW.DESCUENTO AS D_COSTO) / CAST(NEW.PRECIOLISTA AS D_COSTO));
                NEW.DESCUENTOPORCENTAJE = :DESCPORC;
            end
            ELSE
            BEGIN
                DESCPORC = ((NEW.PRECIOLISTA - NEW.PRECIO) * 100) / CAST(NEW.PRECIOLISTA AS D_COSTO);
                NEW.DESCUENTOPORCENTAJE = CAST(ROUND(:DESCPORC,2) AS D_PORCENTAJE);
            END

            IF( ROUND( ((100.00 - COALESCE(:descporc,0))/100) * NEW.PRECIOLISTA ,2) =  ROUND( ((100.00 - COALESCE(NEW.porcentajedescuentomanual,0))/100) * NEW.PRECIOLISTA ,2)  )
            THEN
            BEGIN
                NEW.DESCUENTOPORCENTAJE = COALESCE(NEW.porcentajedescuentomanual,0);
            END
        END

    END
    ELSE
    BEGIN
        DESCPORC = 0.00;
        NEW.DESCUENTOPORCENTAJE = CAST(ROUND(:DESCPORC,2) AS D_PORCENTAJE);
    END

    IF (NEW.DESCUENTO > 0.00) THEN
    BEGIN
        NEW.IMPORTEDESCUENTO = NEW.CANTIDAD * NEW.DESCUENTO;
    END
    ELSE
    BEGIN
        NEW.IMPORTEDESCUENTO = 0.00;
    END
END