create or alter procedure RETIRO_CAJA_INSERT (
    ALMACENID type of D_FK,
    SUCURSALID type of D_FK,
    TIPODOCTOID type of D_FK,
    VENDEDORID type of D_FK,
    PERSONAID type of D_FK,
    CAJAID type of D_FK,
    REFERENCIA type of D_REFERENCIA,
    REFERENCIAS varchar(255),
    FECHA D_FECHA,
    VENCE D_FECHA)
returns (
    DOCTOID type of D_PK,
    ERRORCODE type of D_ERRORCODE)
as
declare variable DOCTOERRORCODE type of D_FK;
declare variable CORTEID D_FK;
declare variable SERIE D_DOCTOSERIE;
declare variable FOLIO D_DOCTOFOLIO;
BEGIN

   ERRORCODE = 0;


      SELECT DOCTOID, ERRORCODE
      FROM DOCTO_INSERT (
         :VENDEDORID,
         :ALMACENID,
         :SUCURSALID,
         :TIPODOCTOID,
         0,
         1,
         :PERSONAID,
         :VENDEDORID,
         :CAJAID,
         :REFERENCIA,
         :REFERENCIAS,
         NULL,
         NULL,
         :FECHA,
         :VENCE ,
         NULL ,
         'S' ,
         1
      ) INTO :DOCTOID, :DOCTOERRORCODE;


      IF (:DOCTOERRORCODE > 0) THEN
   BEGIN
      ERRORCODE = :DOCTOERRORCODE;
      SUSPEND;
      EXIT;
   END

   
   SELECT SERIE, FOLIO
   FROM GET_FOLIO(:SUCURSALID, :CAJAID, :TIPODOCTOID)
   INTO :SERIE, :FOLIO;

   UPDATE DOCTO SET FOLIO = :FOLIO, SERIE = :SERIE
   WHERE ID = :DOCTOID;


    ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1004;
      SUSPEND;
   END 

END