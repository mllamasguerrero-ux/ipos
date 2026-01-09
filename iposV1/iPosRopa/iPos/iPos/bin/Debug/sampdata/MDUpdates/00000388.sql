CREATE OR ALTER PROCEDURE DOCTO_RECALCULAR_DETALLES (
    doctorecalcularid d_fk)
returns (
    errorcode d_errorcode)
as
declare variable estatusdoctoid d_fk;
declare variable movtoid d_fk;
declare variable almacenid d_fk;
declare variable sucursalid d_fk;
declare variable personaid d_fk;
declare variable tipodoctorecalcularid d_fk;
declare variable productoid d_fk;
declare variable lote d_lote;
declare variable fechavence d_fechavence;
declare variable cantidad d_cantidad;
declare variable precio d_precio;
declare variable costo d_costo;
declare variable referencia d_referencia;
declare variable referencias varchar(255);
declare variable serie varchar(31);
declare variable folio integer;
declare variable almacentid d_fk;
declare variable sucursaltid d_fk;
declare variable tipodiferenciainventarioid d_fk;
BEGIN
   -- Leer del DOCTO a cancelar.
   SELECT ESTATUSDOCTOID, TIPODOCTOID
   FROM DOCTO
   WHERE ID = :DOCTORECALCULARID
   INTO :ESTATUSDOCTOID, :TIPODOCTORECALCULARID;

   -- Si no esta vigente: Salir.
   IF (:ESTATUSDOCTOID <> 0) THEN
   BEGIN
      ERRORCODE = 1082;
      SUSPEND;
      EXIT;
   END

   -- Si no es de los tipos b?sicos: Salir.
   IF (:TIPODOCTORECALCULARID NOT IN (11, 21, 31, 41)) THEN
   BEGIN
      ERRORCODE = 1008;
      SUSPEND;
      EXIT;
   END

   -- Leer del DOCTO a recalcular.
   SELECT ALMACENID, SUCURSALID, PERSONAID, SERIE, FOLIO, SUCURSALTID, ALMACENTID
   FROM DOCTO
   WHERE ID = :DOCTORECALCULARID
   INTO :ALMACENID, :SUCURSALID, :PERSONAID, :SERIE, :FOLIO, :SUCURSALTID, :ALMACENTID;



   -- Agrega los MOVTO.
   


   FOR SELECT
      ID, PRODUCTOID, LOTE, FECHAVENCE, CANTIDAD, PRECIO, COSTO, 
      TIPODIFERENCIAINVENTARIOID
   FROM MOVTO
   WHERE DOCTOID = :DOCTORECALCULARID
   INTO
      :MOVTOID, :PRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDAD, :PRECIO, :COSTO, 
      :TIPODIFERENCIAINVENTARIOID
   DO
   BEGIN

      SELECT ERRORCODE
      FROM MOVTO_INSERT (
         :DOCTORECALCULARID, 0, :ALMACENID, :SUCURSALID, :TIPODOCTORECALCULARID, 0, 0, :PERSONAID, 5, 1,
         0, :PRODUCTOID, :LOTE, :FECHAVENCE, /*:CANTIDAD*/0, 0, 0, 0, 0, /*:PRECIO*/NULL, 0,
         /*:REFERENCIA*/ '', /*:REFERENCIAS*/ '', :COSTO, :SUCURSALID, :ALMACENID, 'N',
         :TIPODIFERENCIAINVENTARIOID, CURRENT_DATE, CURRENT_DATE, 0.00
      ) INTO :ERRORCODE;




        IF(:ERRORCODE <> 0) THEN
        BEGIN
          SUSPEND;
          EXIT;
        END

   END


   ERRORCODE = 0;
   SUSPEND;
   
    WHEN ANY DO
    BEGIN
        ERRORCODE = 1009;
        SUSPEND;
    END
END