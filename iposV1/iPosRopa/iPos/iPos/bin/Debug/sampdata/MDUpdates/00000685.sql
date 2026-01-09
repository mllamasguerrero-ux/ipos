create or alter procedure GENERAR_FOLIOS_FACTELEC (
    SUCURSALID D_FK,
    SERIE D_DOCTOSERIE)
returns (
    SEQUENCENAME varchar(127),
    ERRORCODE D_ERRORCODE)
as
--declare variable sequencename varchar(127);
declare variable SUCID varchar(12);
declare variable CUENTA integer;
BEGIN
   SELECT VALOR FROM PADZ(:SUCURSALID, 3) INTO :SUCID;


         SEQUENCENAME = 'SEQ_FE_' || :SUCID || '_' || :serie;

         SELECT COALESCE(COUNT(*), 0) AS CUENTA
         FROM RDB$GENERATORS
         WHERE RDB$GENERATOR_NAME = :SEQUENCENAME
         INTO :CUENTA;

         IF (:CUENTA = 0) THEN
         BEGIN
            EXECUTE STATEMENT
               'CREATE SEQUENCE ' || SEQUENCENAME;



         END

         
            INSERT INTO FOLIO
               (SUCURSALID, CAJAID, TIPODOCTOID, SEQUENCENAME,SERIE)
            VALUES
               (:SUCURSALID, 1,  29, :SEQUENCENAME,:SERIE);

    ERRORCODE = 0;
    SUSPEND;
    
    WHEN ANY DO
    BEGIN
        ERRORCODE = 3333;
        SUSPEND;
    END
END