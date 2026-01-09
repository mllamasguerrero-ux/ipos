CREATE OR ALTER trigger doctopago_corteupd_ai100 for doctopago
active after insert position 100
AS  
declare variable ERRORCODE D_ERRORCODE; 
declare variable MANEJARETIRODECAJA D_BOOLCN;
declare variable CORTEACTIVO D_BOOLCN;
begin
  /* Trigger text */
      SELECT FIRST 1 PARAMETRO.manejarretirodecaja FROM PARAMETRO INTO :MANEJARETIRODECAJA;
      SELECT FIRST 1 ACTIVO FROM CORTE WHERE ID = NEW.CORTEID INTO :CORTEACTIVO;
      IF((COALESCE(:manejaretirodecaja, 'N') = 'S' or (COALESCE(:CORTEACTIVO,'S') = 'N') ) and COALESCE(NEW.CORTEID,0) <> 0  AND COALESCE(NEW.FORMAPAGOID,0) IN (1,3,5)) THEN
      BEGIN
        SELECT ERRORCODE FROM CORTE_TOTALES_PORID( NEW.CORTEID )
        INTO :ERRORCODE;
      END
end