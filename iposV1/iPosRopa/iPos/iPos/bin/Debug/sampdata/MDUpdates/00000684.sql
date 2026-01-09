create or alter procedure LLENAR_FOLIO_FACTURAELECTRONICA (
    DOCTOID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable SUCURSALID D_FK;
declare variable SERIESAT D_DOCTOSERIE;
declare variable FOLIOSAT D_DOCTOFOLIO;
declare variable CUENTA integer;
declare variable SEQUENCENAME varchar(127);
declare variable SERIEFACTURA D_DOCTOSERIE;
declare variable SERIEDEVOLUCION D_DOCTOSERIE;
declare variable TIPODOCTOID D_FK;
BEGIN


        SELECT COALESCE(FOLIOSAT,0), TIPODOCTOID FROM DOCTO WHERE ID = :DOCTOID INTO :FOLIOSAT, :TIPODOCTOID;

        IF(:FOLIOSAT <> 0) THEN
        BEGIN
                 
         ERRORCODE = 0;
         SUSPEND;
        END

        SELECT FIRST 1 SUCURSALID, SERIESAT, SERIESATDEVOLUCION
        FROM PARAMETRO
        INTO         :SUCURSALID, :SERIEFACTURA, :SERIEDEVOLUCION;

        IF(:TIPODOCTOID IN (22,23)) THEN
        BEGIN
            SERIESAT = :SERIEDEVOLUCION;
        END
        ELSE
        BEGIN     
            SERIESAT = :SERIEFACTURA;
        END


 
         SELECT COALESCE(COUNT(*), 0) AS CUENTA
         FROM FOLIO
         where SUCURSALID = :SUCURSALID AND SERIE = :SERIESAT
         INTO :CUENTA;

         IF (:CUENTA = 0) THEN
         BEGIN



              SELECT ERRORCODE FROM  GENERAR_FOLIOS_FACTELEC(:SUCURSALID,:SERIESAT)
              INTO :ERRORCODE;

              IF(:errorcode <> 0) THEN
              BEGIN
                    SUSPEND;
                    EXIT;
              END


         END

         SELECT SEQUENCENAME FROM folio
         WHERE   SUCURSALID = :SUCURSALID AND SERIE = :SERIESAT
         INTO :SEQUENCENAME;


        EXECUTE STATEMENT
           'SELECT NEXT VALUE FOR ' || :SEQUENCENAME || ' FROM RDB$DATABASE' INTO :FOLIOSAT;


         UPDATE DOCTO SET FOLIOSAT = :FOLIOSAT , SERIESAT =:SERIESAT WHERE ID = :DOCTOID;

         ERRORCODE = 0;
         SUSPEND;
   
   /*WHEN ANY DO
   BEGIN
      ERRORCODE = 1012;
      SUSPEND;
   END   */

END