create or alter procedure DOCTO_SAVE (
    DOCTOID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable MOVTOID D_FK;
declare variable ESTATUSMOVTOID D_FK;
declare variable PERSONAID D_FK;
declare variable PERSONAAPARTADOID D_FK;
declare variable ESTADOSURTIDOID D_FK;
BEGIN

   SELECT ESTADOSURTIDOID FROM DOCTO WHERE ID = :DOCTOID INTO :ESTADOSURTIDOID;

    UPDATE DOCTO SET DOCTO.prekitestatus = 1 WHERE ID = :DOCTOID;


   update movto set estatusmovtoid = 1
   where doctoid = :DOCTOID AND ESTATUSMOVTOID = 0;


   -- Generar el pago del documento
   UPDATE DOCTO
   SET ESTATUSDOCTOID = 1
   WHERE ID = :DOCTOID;

   UPDATE DOCTO SET DOCTO.postkitestatus = 1 WHERE ID = :DOCTOID;

   SELECT PERSONAID, PERSONAAPARTADOID FROM DOCTO WHERE ID = :DOCTOID INTO :PERSONAID, :PERSONAAPARTADOID;

   if(:personaid <> 1) then
   begin
        SELECT ERRORCODE FROM PERSONA_AJUSTAR_SALDOS(:PERSONAID) INTO :ERRORCODE;
   end
        
   if(:personaapartadoid is not null) then
   begin
        SELECT ERRORCODE FROM PERSONAAPARTADO_AJUSTAR_SALDOS(:PERSONAAPARTADOID) INTO :ERRORCODE;
   end


   ERRORCODE = 0;
   SUSPEND;
         /*
   WHEN ANY DO
   BEGIN
      ERRORCODE = 1004;
      SUSPEND;
   END */
END