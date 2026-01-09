CREATE OR ALTER PROCEDURE DOCTO_SAVE (
    doctoid d_fk)
returns (
    errorcode d_errorcode)
as
declare variable movtoid d_fk;
declare variable estatusmovtoid d_fk;
BEGIN
   -- Grabar a Kardex e Inventarios.
   /*FOR SELECT ID, ESTATUSMOVTOID
   FROM MOVTO
   WHERE DOCTOID = :DOCTOID
   INTO :MOVTOID, :ESTATUSMOVTOID DO
   BEGIN
      IF (:ESTATUSMOVTOID = 0) THEN
      BEGIN
         UPDATE MOVTO
         SET ESTATUSMOVTOID = 1
         WHERE ID = :MOVTOID;
      END
   END   */
   update movto set estatusmovtoid = 1
   where doctoid = :DOCTOID AND ESTATUSMOVTOID = 0;

   -- Generar el pago del documento
   UPDATE DOCTO
   SET ESTATUSDOCTOID = 1
   WHERE ID = :DOCTOID;

   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1004;
      SUSPEND;
   END 
END