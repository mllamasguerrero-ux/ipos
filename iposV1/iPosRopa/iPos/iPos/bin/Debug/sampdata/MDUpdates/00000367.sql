CREATE OR ALTER PROCEDURE GET_FOLIO (
    sucursalid d_id,
    cajaid d_id,
    tipodoctoid d_id)
returns (
    serie d_doctoserie,
    folio d_doctofolio,
    errorcode d_errorcode)
as
declare variable sequencename varchar(127);
declare variable sucid varchar(12);
declare variable cajid varchar(12);
declare variable tipid varchar(12);
declare variable cuenta integer;
BEGIN
   IF ((:SUCURSALID IS NULL) OR (:SUCURSALID = 0)) THEN
   BEGIN
      ERRORCODE = 1044;
      SUSPEND;
      EXIT;
   END
   
   IF ((:CAJAID IS NULL) OR (:CAJAID = 0)) THEN
   BEGIN
      ERRORCODE = 1045;
      SUSPEND;
      EXIT;
   END
   
   IF ((:TIPODOCTOID IS NULL) OR (:TIPODOCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1046;
      SUSPEND;
      EXIT;
   END
   
  SELECT SERIE, SEQUENCENAME
  FROM FOLIO
  WHERE SUCURSALID = :SUCURSALID
    AND CAJAID = :CAJAID
    AND TIPODOCTOID = :TIPODOCTOID
  INTO :SERIE, :SEQUENCENAME;

  if( coalesce(:SEQUENCENAME,'') = ''  )   then
  begin
                    
      SELECT VALOR FROM PADZ(:SUCURSALID, 3) INTO :SUCID;
      SELECT VALOR FROM PADZ(:CAJAID, 2) INTO :CAJID;
      SELECT VALOR FROM PADZ(:TIPODOCTOID, 2) INTO :TIPID;

       SEQUENCENAME = 'SEQ' ||
            '_SUC_' || :SUCID ||
            '_CAJA_' || :CAJID ||
            '_TIPO_' || :TIPID || '';

            SERIE  = '';

            
        INSERT INTO FOLIO
               (SUCURSALID, CAJAID, TIPODOCTOID, SEQUENCENAME)
        VALUES
               (:SUCURSALID, :CAJAID, :TIPODOCTOID, :SEQUENCENAME);

   end



   SELECT COALESCE(COUNT(*), 0) AS CUENTA
   FROM RDB$GENERATORS
   WHERE RDB$GENERATOR_NAME = :SEQUENCENAME
   INTO :CUENTA;

   IF (:CUENTA = 0) THEN
   BEGIN
            EXECUTE STATEMENT
               'CREATE SEQUENCE ' || :SEQUENCENAME;
   end

  EXECUTE STATEMENT
    'SELECT NEXT VALUE FOR ' || :SEQUENCENAME || ' FROM RDB$DATABASE' INTO :FOLIO;

   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1047;
      SUSPEND;
   END 
END