create or alter procedure LLENAR_FOLIO_FACTURAELECTRONICA (
    DOCTOID D_FK,
    TIPOCOMPROBANTE D_STDTEXT_64)
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
declare variable SERIEABONO D_DOCTOSERIE;
declare variable TIPODOCTOID D_FK;
declare variable SERIECOMPRTRASLSAT D_DOCTOSERIE;
declare variable DOCTOCOMPROBANTEID D_FK;
BEGIN
            
        SELECT TIPODOCTOID FROM DOCTO WHERE ID = :DOCTOID INTO  :TIPODOCTOID;

        SELECT FIRST 1 SUCURSALID, SERIESAT, SERIESATDEVOLUCION, SERIESATABONO, SERIECOMPRTRASLSAT
        FROM PARAMETRO
        INTO         :SUCURSALID, :SERIEFACTURA, :SERIEDEVOLUCION, :SERIEABONO, :SERIECOMPRTRASLSAT;


        IF(COALESCE(:TIPOCOMPROBANTE , '') <> '') THEN
        BEGIN

            SELECT FIRST 1 COALESCE(FOLIOSAT,0) FROM doctocomprobante
            WHERE DOCTOID = :DOCTOID AND TIPOCOMPROBANTE = :TIPOCOMPROBANTE
            INTO :FOLIOSAT;

            IF(coalesce(:FOLIOSAT,0) <> 0) THEN
            BEGIN
                 
                ERRORCODE = 0;
                SUSPEND;
            END

            IF(COALESCE(:TIPOCOMPROBANTE,'') = 'T') THEN
            BEGIN  
                SERIESAT = :SERIECOMPRTRASLSAT;
            END

        END
        ELSE
        BEGIN
            SELECT COALESCE(FOLIOSAT,0) FROM DOCTO WHERE ID = :DOCTOID INTO :FOLIOSAT;

            IF(coalesce(:FOLIOSAT,0) <> 0) THEN
            BEGIN
                 
                ERRORCODE = 0;
                SUSPEND;
            END

            
            IF(:TIPODOCTOID IN (22,23)) THEN
            BEGIN
                SERIESAT = :SERIEDEVOLUCION;
            END
            ELSE IF(:TIPODOCTOID IN (205)) THEN
            BEGIN
                SERIESAT = :SERIEABONO;
            END
            ELSE
            BEGIN     
                SERIESAT = :SERIEFACTURA;
            END


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



           
        IF(COALESCE(:TIPOCOMPROBANTE , '') <> '') THEN
        BEGIN

            SELECT FIRST 1 ID FROM DOCTOCOMPROBANTE  WHERE DOCTOID = :DOCTOID AND TIPOCOMPROBANTE = :TIPOCOMPROBANTE
            INTO :DOCTOCOMPROBANTEID;

            IF(COALESCE(:DOCTOCOMPROBANTEID,0) = 0) THEN
            BEGIN
                INSERT INTO doctocomprobante
                ( ACTIVO, DOCTOID, TIPOCOMPROBANTE, FOLIOSAT, SERIESAT)
                VALUES
                ('S', :DOCTOID, :TIPOCOMPROBANTE, :FOLIOSAT, :SERIESAT);
            END
            ELSE
            BEGIN

            
                UPDATE doctocomprobante
                SET  FOLIOSAT = :FOLIOSAT, SERIESAT = :SERIESAT
                WHERE ID = :DOCTOCOMPROBANTEID;

            END

                
        END
        ELSE
        BEGIN  
            UPDATE DOCTO SET FOLIOSAT = :FOLIOSAT , SERIESAT =:SERIESAT WHERE ID = :DOCTOID;
        END

         ERRORCODE = 0;
         SUSPEND;
   
   /*WHEN ANY DO
   BEGIN
      ERRORCODE = 1012;
      SUSPEND;
   END   */

END