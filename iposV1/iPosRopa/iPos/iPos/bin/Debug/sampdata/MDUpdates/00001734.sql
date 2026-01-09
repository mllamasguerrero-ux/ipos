CREATE OR ALTER TRIGGER PERSONA_AU0_UTILIDAD FOR PERSONA
ACTIVE AFTER UPDATE POSITION 0
AS                           
declare variable MANEJAQUOTA d_boolcn;
declare variable DELTALOGRO D_PRECIO; 
declare variable DELTAUTILIDAD D_PRECIO;
declare variable ANIO INTEGER;
declare variable MES INTEGER;
declare variable QUOTAIDOLD D_FK;
declare variable QUOTAIDNEW D_FK;
begin
  /* Trigger text */

  IF(NEW.vendedorid <> OLD.vendedorid) THEN
  BEGIN

  --IF(NEW.estatusdoctoid = 1 and old.estatusdoctoid = 0 AND NEW.TIPODOCTOID IN (21,22,23,24,25,26)) THEN
         SELECT MANEJAQUOTA FROM PARAMETRO INTO :MANEJAQUOTA;
         IF(:MANEJAQUOTA = 'S') THEN
         BEGIN
         
            ANIO = EXTRACT (YEAR FROM CURRENT_DATE);
            MES = EXTRACT (MONTH FROM CURRENT_DATE);

             SELECT SUM(COALESCE(DOCTO.total, 0) * COALESCE(TIPODOCTO.sentidopago, 0)) DELTALOGRO,
                    SUM(COALESCE(DOCTO.utilidad, 0) * COALESCE(TIPODOCTO.sentidopago, 0)) DELTAUTILIDAD
                    FROM docto INNER JOIN TIPODOCTO ON TIPODOCTO.ID = DOCTO.TIPODOCTOID WHERE DOCTO.personaid = NEW.ID AND DOCTO.TIPODOCTOID IN (21,22,23,24,25,26)
                    AND DOCTO.estatusdoctoid = 1 AND DOCTO.vendedorutilidadid = OLD.vendedorid
                    AND EXTRACT (YEAR FROM COALESCE(DOCTO.FECHA, CURRENT_DATE)) = :ANIO
                    AND EXTRACT (MONTH FROM COALESCE(DOCTO.FECHA, CURRENT_DATE)) = :MES
                     INTO :deltalogro, :DELTAUTILIDAD;

            SELECT ID FROM QUOTA WHERE VENDEDORID = OLD.VENDEDORID AND ANIO = :ANIO AND MES = :MES INTO :QUOTAIDOLD;
            SELECT ID FROM QUOTA WHERE VENDEDORID = NEW.VENDEDORID AND ANIO = :ANIO AND MES = :MES INTO :QUOTAIDNEW;


            IF(COALESCE(:QUOTAIDOLD,0) <> 0) THEN
            BEGIN
                UPDATE QUOTA SET LOGRO = COALESCE(LOGRO,0) - :DELTALOGRO  , UTILIDAD = COALESCE(UTILIDAD, 0) - :DELTAUTILIDAD
                WHERE ID = :QUOTAIDOLD ;
            END


            IF(COALESCE(:QUOTAIDNEW,0) <> 0) THEN
            BEGIN
                UPDATE QUOTA SET LOGRO = COALESCE(LOGRO,0) + :DELTALOGRO  , UTILIDAD = COALESCE(UTILIDAD, 0) + :DELTAUTILIDAD
                WHERE ID = :QUOTAIDNEW;
            END
            ELSE
            BEGIN
                INSERT INTO QUOTA (VENDEDORID, ANIO, MES, QUOTA, LOGRO, UTILIDAD)
                VALUES ( NEW.VENDEDORID, :ANIO, :MES, 0, :deltalogro,  :DELTAUTILIDAD);
            END


            
            UPDATE DOCTO SET DOCTO.vendedorutilidadid = NEW.vendedorid
            WHERE DOCTO.personaid = NEW.ID AND DOCTO.TIPODOCTOID IN (21,22,23,24,25,26)
                    AND DOCTO.estatusdoctoid = 1
                     AND DOCTO.vendedorutilidadid = OLD.vendedorid
                    AND EXTRACT (YEAR FROM COALESCE(DOCTO.FECHA, CURRENT_DATE)) = :ANIO
                    AND EXTRACT (MONTH FROM COALESCE(DOCTO.FECHA, CURRENT_DATE)) = :MES;

            
         END





  END

end