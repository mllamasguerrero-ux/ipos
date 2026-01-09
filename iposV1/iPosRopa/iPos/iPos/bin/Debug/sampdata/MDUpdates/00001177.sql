create or alter procedure RESET_FOLIOS
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable SEQUENCENAME varchar(127);
declare variable CUENTA integer;
BEGIN



FOR SELECT
      FOLIO.sequencename
   FROM FOLIO
   INTO
      :SEQUENCENAME
   DO
   BEGIN

      
        SELECT COALESCE(COUNT(*), 0) AS CUENTA
        FROM RDB$GENERATORS
        WHERE RDB$GENERATOR_NAME = :SEQUENCENAME
        INTO :CUENTA;

        IF (:CUENTA > 0) THEN
        BEGIN
             
            EXECUTE STATEMENT
               'ALTER SEQUENCE ' ||  :SEQUENCENAME || ' RESTART WITH 0';
        END

   END

   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1047;
      SUSPEND;
   END 
END
