create or alter procedure DOCTO_UNSAVE (
    DOCTOID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable MOVTOID D_FK;
declare variable ESTATUSMOVTOID D_FK;
declare variable PERSONAID D_FK;
declare variable PERSONAAPARTADOID D_FK;
BEGIN
   update movto set estatusmovtoid = 0
   where doctoid = :DOCTOID AND ESTATUSMOVTOID = 1;

   -- Generar el pago del documento
   UPDATE DOCTO
   SET ESTATUSDOCTOID = 0
   WHERE ID = :DOCTOID;




   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1004;
      SUSPEND;
   END
END