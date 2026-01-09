CREATE OR ALTER PROCEDURE DOCTO_ACTUALIZAR_CLIENTE (
    doctoid type of d_fk,
    personaid type of d_fk)
returns (
    errorcode type of d_errorcode)
as
BEGIN

  ERRORCODE = 0;

   UPDATE DOCTO SET PERSONAID = :PERSONAID WHERE ID = :DOCTOID;


      SELECT ERRORCODE
      FROM DOCTO_RECALCULAR_DETALLES (
         :DOCTOID
      ) INTO :ERRORCODE;

      SUSPEND;

    WHEN ANY DO
   BEGIN
      ERRORCODE = 1016;
      SUSPEND;
   END

END