create or alter procedure GET_FOLIO (
    SUCURSALID D_ID,
    CAJAID D_ID,
    TIPODOCTOID D_ID)
returns (
    SERIE D_DOCTOSERIE,
    FOLIO D_DOCTOFOLIO,
    ERRORCODE D_ERRORCODE)
as
declare variable SEQUENCENAME varchar(127);
declare variable SUCID varchar(12);
declare variable TIPID varchar(12);
declare variable CUENTA integer;
declare variable MAXFOLIO integer;
BEGIN
   IF ((:SUCURSALID IS NULL) OR (:SUCURSALID = 0)) THEN
   BEGIN
      ERRORCODE = 1044;
      SUSPEND;
      EXIT;
   END
   
   CAJAID = -1;

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

   /* GET THE SAME FOLIO FOR VENTAS APARTADO Y VENTAS NORMALES */
   if(:TIPODOCTOID = 25) THEN
   BEGIN
      TIPODOCTOID = 21;
   END

   
  SELECT SERIE, SEQUENCENAME
  FROM FOLIO
  WHERE SUCURSALID = :SUCURSALID
    AND CAJAID = -1
    AND TIPODOCTOID = :TIPODOCTOID
  INTO :SERIE, :SEQUENCENAME;

  if( coalesce(:SEQUENCENAME,'') = ''  )   then
  begin
                    
      SELECT VALOR FROM PADZ(:SUCURSALID, 3) INTO :SUCID;
      --SELECT VALOR FROM PADZ(:CAJAID, 2) INTO :CAJID;
      SELECT VALOR FROM PADZ(:TIPODOCTOID, 2) INTO :TIPID;

       SEQUENCENAME = 'SEQ' ||
            '_SUC_' || :SUCID ||
            '_UNI_' || --:CAJID ||
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

           select coalesce(max(folio),0) from docto where tipodoctoid = :tipodoctoid and  SUCURSALID = :SUCURSALID
           into :MAXFOLIO;
           MAXFOLIO = :MAXFOLIO + 10000;
            EXECUTE STATEMENT
               'CREATE SEQUENCE ' || :SEQUENCENAME;

            EXECUTE STATEMENT
               'ALTER SEQUENCE ' ||  :SEQUENCENAME || ' RESTART WITH ' || :MAXFOLIO;

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