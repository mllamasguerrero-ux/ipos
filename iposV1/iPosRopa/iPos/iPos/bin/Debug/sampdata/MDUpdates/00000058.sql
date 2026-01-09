create or alter procedure INVFIS_DIF_APLICAR (
    DOCTOID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable TIPODOCTOID D_FK;
declare variable ESTATUSDOCTOID D_FK;
BEGIN
   SELECT TIPODOCTOID, ESTATUSDOCTOID
   FROM DOCTO
   WHERE ID = :DOCTOID
   INTO :TIPODOCTOID, :ESTATUSDOCTOID;

   -- Interceptar docto no existente
   IF ((:TIPODOCTOID IS NULL) OR (:ESTATUSDOCTOID IS NULL)) THEN
   BEGIN
      ERRORCODE = 10710;
      SUSPEND;
      EXIT;
   END

   -- Solo admitir TipoDocto = 50, captura de inventario fisico.
   IF (:TIPODOCTOID != 50) THEN
   BEGIN
      ERRORCODE = 1071;
      SUSPEND;
      EXIT;
   END

   -- Solo admitir EstatusDocto = 0, Borrador.
   IF (:ESTATUSDOCTOID != 0 AND :ESTATUSDOCTOID != 3) THEN
   BEGIN
      ERRORCODE = 1072;
      SUSPEND;
      EXIT;
   END


   --Asegurarse de tener la existencia actual correcta
       
   SELECT ERRORCODE 
   FROM INVFIS_DIF_EXISTENCIAACTUAL(:DOCTOID)
   INTO :ERRORCODE;


   -- Procesar sobrantes.
   SELECT ERRORCODE 
   FROM INVFIS_DIF_GENERAR(:DOCTOID, 51)
   INTO :ERRORCODE;
   
   -- Procesar faltantes.
   SELECT ERRORCODE 
   FROM INVFIS_DIF_GENERAR(:DOCTOID, 52)
   INTO :ERRORCODE;

   IF (:ERRORCODE <> 0) THEN
   BEGIN
      SUSPEND;
      EXIT;
   END

   SELECT ERRORCODE
   FROM DOCTO_SAVE(:DOCTOID)
   INTO :ERRORCODE;

   -- Regresar el errorcode que haya, sea 0 o No;
   SUSPEND;
   
   WHEN ANY DO
   BEGIN
     ERRORCODE = 1076;
     SUSPEND;
   END
END