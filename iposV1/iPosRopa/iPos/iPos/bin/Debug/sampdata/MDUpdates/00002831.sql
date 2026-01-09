create or alter procedure VENTAMOVIL_ASIGNARPAGOCREDITO (
    DOCTOID D_FK,
    VENDEDORID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as              
declare variable HAYCORTEACTIVO D_BOOLCN;
declare variable CORTEID D_FK;
declare variable FECHACORTE D_FECHA;
declare variable SALDO D_PRECIO;
BEGIN

              
        SELECT HAYCORTEACTIVO,CORTEID,ERRORCODE, FECHACORTE
        FROM HAY_CORTE_ACTIVO(:VENDEDORID)
        INTO :HAYCORTEACTIVO, :CORTEID, :ERRORCODE, :FECHACORTE;
        
        IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
        BEGIN
                        SUSPEND;
                        EXIT;
        END

        
        IF(:HAYCORTEACTIVO <> 'S'  ) THEN
        BEGIN
          ERRORCODE = 1001;
          SUSPEND;
          EXIT;
        END


        SELECT SALDO FROM DOCTO WHERE ID = :DOCTOID INTO :SALDO;

      SELECT ERRORCODE
      FROM DOCTOPAGO_INSERT (
         :DOCTOID,
         4,
         current_date, current_time, :CORTEID,
         :SALDO, 0.00, 0.00 ,
         1  ,
         null ,
         'N' ,
         1 ,
         NULL,
         NULL,
         NULL  ,
         CURRENT_DATE,
         CURRENT_DATE,
         'S',
         1,
         NULL
      )   INTO :ERRORCODE;




   ERRORCODE = 0;
   SUSPEND;

   /*WHEN ANY DO
   BEGIN
      ERRORCODE = 1022;
      SUSPEND;
   END */
END
