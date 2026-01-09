create or alter procedure CALCULARCORTESABIERTOSFECHA (
    FECHA D_FECHA)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable CORTEID D_FK;
BEGIN

   FOR SELECT
      CORTE.ID
   FROM CORTE
   WHERE (corte.fechacorte = :FECHA) AND (corte.activo = 'S')
   INTO
      :CORTEID
   DO
   BEGIN

        SELECT ERRORCODE FROM CORTE_TOTALES_PORID( :CORTEID )
        INTO :ERRORCODE;

        
        IF(COALESCE(:ERRORCODE,0) <> 0 ) THEN
        BEGIN
            SUSPEND;
            EXIT;
        END

   END

   ERRORCODE = 0;
   SUSPEND;
   
    WHEN ANY DO
    BEGIN
        ERRORCODE = 1009;
        SUSPEND;
    END
END