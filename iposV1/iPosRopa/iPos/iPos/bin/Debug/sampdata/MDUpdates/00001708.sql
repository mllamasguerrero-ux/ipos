CREATE OR ALTER TRIGGER DOCTO_AU0_UTILIDAD FOR DOCTO
ACTIVE AFTER UPDATE POSITION 0
AS  
declare variable MANEJAQUOTA d_boolcn;
declare variable SENTIDOPAGO D_SENTIDO;
declare variable DELTALOGRO D_PRECIO; 
declare variable DELTAUTILIDAD D_PRECIO;


declare variable ANIO INTEGER;
declare variable MES INTEGER;
declare variable QUOTAID D_FK;

begin
  /* Trigger text */

  
  IF(NEW.estatusdoctoid = 1 and old.estatusdoctoid = 0 AND NEW.TIPODOCTOID IN (21,22,23,24,25,26)) THEN
  BEGIN



         SELECT MANEJAQUOTA FROM PARAMETRO INTO :MANEJAQUOTA;
         IF(:MANEJAQUOTA = 'S') THEN
         BEGIN

            SELECT SENTIDOPAGO FROM TIPODOCTO WHERE ID = NEW.tipodoctoid INTO :SENTIDOPAGO;
            deltalogro = COALESCE(NEW.total,0) * :SENTIDOPAGO;
            DELTAUTILIDAD = COALESCE(NEW.utilidad, 0) * :SENTIDOPAGO;

            
            ANIO = EXTRACT (YEAR FROM CURRENT_DATE);
            MES = EXTRACT (MONTH FROM CURRENT_DATE);
            SELECT ID FROM QUOTA WHERE VENDEDORID = NEW.vendedorutilidadid AND ANIO = :ANIO AND MES = :MES INTO :QUOTAID;

            
            IF(COALESCE(:QUOTAID,0) <> 0) THEN
            BEGIN
                UPDATE QUOTA SET LOGRO = COALESCE(LOGRO,0) + :DELTALOGRO  , UTILIDAD = COALESCE(UTILIDAD, 0) + :DELTAUTILIDAD
                WHERE ID = :QUOTAID;
            END
            ELSE
            BEGIN
                INSERT INTO QUOTA (VENDEDORID, ANIO, MES, QUOTA, LOGRO, UTILIDAD)
                VALUES ( NEW.vendedorutilidadid, :ANIO, :MES, 0, :deltalogro,  :DELTAUTILIDAD);
            END





            
         END

  END


  



end