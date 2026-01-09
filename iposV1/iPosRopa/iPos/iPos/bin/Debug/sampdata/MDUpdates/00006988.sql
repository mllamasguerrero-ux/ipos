create or alter procedure MOVILCREDITO_PONERPENDIENTE (
    DOCTOID D_FK,
    USUARIOID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable MOVTOID D_FK;
declare variable ESTATUSDOCTOID D_FK;
declare variable ALMACENID D_FK;
declare variable SUCURSALID D_FK;
declare variable PERSONAID D_FK;
declare variable TIPODOCTOID D_FK;
declare variable COTI_ENRUTADA D_BOOLCN_NULL;
BEGIN

   --SEPROMOVIOREBAJA = 'N';



   -- Leer del DOCTO a cancelar.
   SELECT ESTATUSDOCTOID, TIPODOCTOID  , COTI_ENRUTADA
   FROM DOCTO
   WHERE ID = :DOCTOID
   INTO :ESTATUSDOCTOID, :TIPODOCTOID, :COTI_ENRUTADA;

   -- Si no esta vigente: Salir.
   IF (:ESTATUSDOCTOID <> 0) THEN
   BEGIN
      ERRORCODE = 1082;
      SUSPEND;
      EXIT;
   END

   -- Si no es de los tipos b?sicos: Salir.
   IF (:TIPODOCTOID NOT IN (331) AND NOT (:TIPODOCTOID = 21 AND COALESCE(:COTI_ENRUTADA,'N') = 'S')) THEN
   BEGIN
      ERRORCODE = 1008;
      SUSPEND;
      EXIT;
   END


      
        UPDATE DOCTO SET PERSONAIDSURTIDO = NULL, PERSONAIDAPROBACIONCXC = NULL,
                         ESTADOSURTIDOID = 4 WHERE ID = :DOCTOID;



   ERRORCODE = 0;
   SUSPEND;
   
    WHEN ANY DO
    BEGIN
        ERRORCODE = 1009;
        SUSPEND;
    END
END