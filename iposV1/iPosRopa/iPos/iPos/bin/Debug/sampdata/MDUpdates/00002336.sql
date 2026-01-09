create or alter procedure REBAJA_PREPARANC (
    DOCTOAREBAJARID D_FK,
    VENDEDORID D_FK)
returns (
    DOCTOID D_FK,
    ERRORCODE D_ERRORCODE)
as
declare variable REBAJAESPECIAL D_BOOLCN;
declare variable CREADOPOR_USERID D_FK;
declare variable ALMACENID D_FK;
declare variable SUCURSALID D_FK;
declare variable TIPODOCTOID D_FK;
declare variable ESTATUSDOCTOID D_FK;
declare variable ESTATUSDOCTOPAGOID D_FK;
declare variable PERSONAID D_FK;
declare variable CAJAID D_FK;
declare variable REFERENCIA D_REFERENCIA;
declare variable REFERENCIAS D_DESCRIPCION;
declare variable SUCURSALTID D_FK;
declare variable ALMACENTID D_FK;
declare variable FECHA D_FECHA;
declare variable VENCE D_FECHA;
declare variable DOCTOREFID D_FK;
declare variable MERCANCIAENTREGADA D_BOOLCS;
declare variable ORIGENFISCALID D_FK;
BEGIN

   -- Si no es documento de compra 11.
   IF ((:DOCTOAREBAJARID IS NULL) OR (:DOCTOAREBAJARID = 0)) THEN
   BEGIN
      ERRORCODE = 1060;
      SUSPEND;
      EXIT;
   END

   -- Validar estatus.
   SELECT
   CREADOPOR_USERID,
         ALMACENID,
         SUCURSALID,
         TIPODOCTOID,
         ESTATUSDOCTOID,
         ESTATUSDOCTOPAGOID,
         PERSONAID,
         CAJAID,
         REFERENCIA,
         REFERENCIAS,
         SUCURSALTID,
         ALMACENTID,
         FECHA,
         VENCE,
         DOCTOREFID  ,
         MERCANCIAENTREGADA ,
         ORIGENFISCALID
   FROM DOCTO
   WHERE DOCTO.ID = :DOCTOAREBAJARID
   INTO :CREADOPOR_USERID,
         :ALMACENID,
         :SUCURSALID,
         :TIPODOCTOID,
         :ESTATUSDOCTOID,
         :ESTATUSDOCTOPAGOID,
         :PERSONAID,
         :CAJAID,
         :REFERENCIA,
         :REFERENCIAS,
         :SUCURSALTID,
         :ALMACENTID,
         :FECHA,
         :VENCE,
         :DOCTOREFID  ,
         :MERCANCIAENTREGADA ,
         :ORIGENFISCALID;

   -- Si no es documento de compra 11.
   IF ((:TIPODOCTOID IS NULL) OR (:TIPODOCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1060;
      SUSPEND;
      EXIT;
   END

   -- Si no es documento de compra 11.
   IF (:TIPODOCTOID not in (21) ) THEN
   BEGIN
      ERRORCODE = 1061;
      SUSPEND;
      EXIT;
   END

   -- Si el estatus no es borrador .
   IF (:ESTATUSDOCTOID <> 1) THEN
   BEGIN
      ERRORCODE = 1062;
      SUSPEND;
      EXIT;
   END



    IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
    BEGIN
        SUSPEND;
        EXIT;
    END


    SELECT  COALESCE(REBAJAESPECIAL,'N') FROM PARAMETRO
    INTO  :REBAJAESPECIAL;

    IF(:REBAJAESPECIAL = 'N') THEN
    BEGIN
      ERRORCODE = -1;
      SUSPEND;
      EXIT;
    END



    
      SELECT DOCTOID, ERRORCODE
      FROM DOCTO_INSERT (
         :CREADOPOR_USERID,
         :ALMACENID,
         :SUCURSALID,
         22,
         :ESTATUSDOCTOID,
         :ESTATUSDOCTOPAGOID,
         :PERSONAID,
         :VENDEDORID,
         :CAJAID,
         :REFERENCIA,
         :REFERENCIAS,
         :SUCURSALTID,
         :ALMACENTID,
         :FECHA,
         :VENCE,
         :DOCTOAREBAJARID  ,
         :MERCANCIAENTREGADA ,
         :ORIGENFISCALID
      ) INTO :DOCTOID, :ERRORCODE;

        
        IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
        BEGIN
            SUSPEND;
            EXIT;
        END


        UPDATE docto SET SUBTIPODOCTOID = 13 WHERE ID = :DOCTOID;

   
    ERRORCODE = 0;
   SUSPEND;
   
   /*
    WHEN ANY DO
    BEGIN
        ERRORCODE = 1065;
        SUSPEND;
    END */

   -- Marcar los faltantes como ya generados.
ENd