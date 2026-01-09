create or alter procedure DOCTO_ASIGNAR_FOLIO (
    DOCTOID type of D_FK)
returns (
    ERRORCODE type of D_ERRORCODE)
as
declare variable SUCURSALID D_FK;
declare variable CAJAID D_TIPOCAMBIO;
declare variable TIPODOCTOID D_DOCTOPLAZO;
declare variable SERIE D_DOCTOSERIE;
declare variable FOLIO D_DOCTOFOLIO;
BEGIN

  ERRORCODE = 0;

  SELECT SUCURSALID, CAJAID, TIPODOCTOID , FOLIO, SERIE
  FROM docto
  WHERE ID = :DOCTOID
  INTO :SUCURSALID, :CAJAID, :TIPODOCTOID, :FOLIO,  :SERIE;

  IF(COALESCE(:FOLIO,0) = 0) THEN
  BEGIN


  
            SELECT SERIE, FOLIO
            FROM GET_FOLIO(:SUCURSALID, :CAJAID, :TIPODOCTOID)
            INTO :SERIE, :FOLIO;


             UPDATE DOCTO
             SET SERIE =  :SERIE ,
             FOLIO = :FOLIO
             WHERE ID = :DOCTOID;
   END


      SUSPEND;

    WHEN ANY DO
   BEGIN
      ERRORCODE = 1016;
      SUSPEND;
   END

END