create or alter procedure COMPRA_COMPLETAR (
    DOCTOID D_FK,
    OBSERVACION D_OBSERVACION,
    VENDEDORID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable TIPODOCTOID D_FK;
declare variable ESTATUSDOCTOID D_FK;
declare variable FALTANTES integer;
declare variable REFERENCIAS varchar(255);
declare variable SUCURSALFUENTEEMPPROV D_CLAVE_NULL;
declare variable SUCURSALEMPPROV D_CLAVE_NULL;
declare variable SALDO D_PRECIO;
BEGIN
   -- Si no es documento de compra 11.
   IF ((:DOCTOID IS NULL) OR (:DOCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1060;
      SUSPEND;
      EXIT;
   END

   -- Validar estatus.
   SELECT DOCTO.TIPODOCTOID, DOCTO.ESTATUSDOCTOID, DOCTO.REFERENCIAS ,
        SUCURSAL.EMPPROV SUCURSALEMPPROV, SUCORIG.EMPPROV  SUCURSALFUENTEEMPPROV, DOCTO.SALDO
   FROM DOCTO
   LEFT JOIN SUCURSAL ON SUCURSAL.ID = DOCTO.SUCURSALID
   LEFT JOIN SUCURSAL SUCORIG ON SUCORIG.ID = DOCTO.SUCURSALTID
   WHERE DOCTO.ID = :DOCTOID
   INTO :TIPODOCTOID, :ESTATUSDOCTOID, :REFERENCIAS,
   :SUCURSALEMPPROV, :SUCURSALFUENTEEMPPROV, :SALDO;

   -- Si no es documento de compra 11.
   IF ((:TIPODOCTOID IS NULL) OR (:TIPODOCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1060;
      SUSPEND;
      EXIT;
   END

   -- Si no es documento de compra 11.
   IF (:TIPODOCTOID <> 11 and :TIPODOCTOID <> 41 ) THEN
   BEGIN
      ERRORCODE = 1061;
      SUSPEND;
      EXIT;
   END

   -- Si el estatus no es borrador .
   IF (:ESTATUSDOCTOID <> 0) THEN
   BEGIN
      ERRORCODE = 1062;
      SUSPEND;
      EXIT;
   END


   IF(COALESCE(:SUCURSALEMPPROV,'') = COALESCE( :SUCURSALFUENTEEMPPROV,'') AND COALESCE( :SUCURSALFUENTEEMPPROV,'') <> '') THEN
   BEGIN
    
        
         SELECT ERRORCODE
         FROM DOCTOPAGO_INSERT (
         NULL,
         17,
         CURRENT_DATE, CURRENT_TIMESTAMP, -1,
         :SALDO, 0.00, 0.00 ,
         2,
         :DOCTOID ,
         'N'  ,
         1 ,
         NULL,
         NULL,
         NULL  ,
         CURRENT_DATE,
         CURRENT_DATE,
         'N',
         1,
         NULL,
         NULL,
         NULL,
         NULL,
         NULL,
         NULL,
         NULL,
         NULL,
         NULL,
         NULL
       ) INTO  :ERRORCODE;

       
        IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
        BEGIN
            SUSPEND;
            EXIT;
        END

        UPDATE DOCTO SET ORIGENFISCALID = 2 WHERE ID = :DOCTOID;

   END
   ELSE IF(COALESCE(:SUCURSALEMPPROV,'') <> COALESCE( :SUCURSALFUENTEEMPPROV,'') AND
         COALESCE( :SUCURSALFUENTEEMPPROV,'') <> '' AND COALESCE( :SUCURSALEMPPROV,'') <> '') THEN
   BEGIN  
        UPDATE DOCTO SET ORIGENFISCALID = 3 WHERE ID = :DOCTOID;
   END


   -- Completar el documento con afectacion de inventarios.
   SELECT ERRORCODE
   FROM DOCTO_SAVE(:DOCTOID)
   INTO :ERRORCODE;
   
   IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
   BEGIN
      SUSPEND;
      EXIT;
   END
   

   -- Si hay diferencias, generar un documento de devolucion.
   SELECT COUNT(M.ID)
   FROM MOVTO M
   WHERE M.DOCTOID = :DOCTOID
      AND (M.CANTIDADFALTANTE > 0)
   INTO :FALTANTES;


   IF (:FALTANTES > 0) THEN
   BEGIN
      SELECT ERRORCODE
      FROM COMPRA_DEVOLVER(:DOCTOID, :VENDEDORID)
      INTO :ERRORCODE;
       
        IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
        BEGIN
            SUSPEND;
            EXIT;
         END

   END


   UPDATE docto SET OBSERVACION = :OBSERVACION  , SUBTIPODOCTOID = 23
   WHERE ID = :DOCTOID;

   SUSPEND;
   
   WHEN ANY DO
   BEGIN
      ERRORCODE = 1063;
      SUSPEND;
   END
END