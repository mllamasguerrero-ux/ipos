create or alter procedure COMPRA_PRECIERRE (
    DOCTOID D_FK,
    ORIGENFISCALID D_FK,
    VENCE D_FECHAVENCE,
    REFERENCIA D_REFERENCIA,
    REFERENCIAS D_DESCRIPCION,
    FECHAFACTURA D_FECHA)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable TIPODOCTOID D_FK;
declare variable ESTATUSDOCTOID D_FK;
declare variable FALTANTES integer;
declare variable DETALLESSINEXISTENCIA integer;
declare variable HAYEXISTENCIAPARAARMARKITS D_BOOLCS;
declare variable MANEJAKITS D_BOOLCN;
declare variable SENTIDOINVENTARIO D_SENTIDO;
BEGIN

   -- Si no es documento de compra 11.
   IF ((:DOCTOID IS NULL) OR (:DOCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1060;
      SUSPEND;
      EXIT;
   END

   -- Validar estatus.
   SELECT TIPODOCTOID, ESTATUSDOCTOID , TIPODOCTO.sentidoinventario
   FROM DOCTO  LEFT JOIN TIPODOCTO ON DOCTO.TIPODOCTOID = TIPODOCTO.ID
   WHERE DOCTO.ID = :DOCTOID
   INTO :TIPODOCTOID, :ESTATUSDOCTOID, :SENTIDOINVENTARIO;

   -- Si no es documento de compra 11.
   IF ((:TIPODOCTOID IS NULL) OR (:TIPODOCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1060;
      SUSPEND;
      EXIT;
   END

   -- Si no es documento de compra 11.
   IF (:TIPODOCTOID not in (11,41,12,15,16) ) THEN
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



    IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
    BEGIN
        SUSPEND;
        EXIT;
    END




     IF (COALESCE(:SENTIDOINVENTARIO,0) = -1 AND :TIPODOCTOID NOT IN (501,502,503,504)) THEN--(:TIPODOCTOID = 12) THEN
     BEGIN
     
        SELECT  COALESCE(MANEJAKITS,'N') FROM PARAMETRO
        INTO  :MANEJAKITS;

        IF( COALESCE(:MANEJAKITS,'N') = 'N' ) THEN
        BEGIN
                
            SELECT COUNT(*) FROM MOVTOS_SINEXISTENCIA WHERE DOCTOID = :DOCTOID
            INTO :DETALLESSINEXISTENCIA;
        END
        ELSE
        BEGIN
                 
            SELECT COUNT(*) FROM MOVTOS_SINEXISTENCIA_NOKIT WHERE DOCTOID = :DOCTOID
            INTO :DETALLESSINEXISTENCIA;
        END



            IF(COALESCE(:DETALLESSINEXISTENCIA,0) > 0) then
            begin
                ERRORCODE = 1081;
                SUSPEND;
                EXIT;
            end


             IF(COALESCE(:MANEJAKITS,'N') = 'S' ) THEN
            BEGIN
                HAYEXISTENCIAPARAARMARKITS = 'S';

                select HAYEXISTENCIA , ERRORCODE
                from KIT_HAYEXISALVUELOPARAENSAMBLE(:doctoid)
                into :HAYEXISTENCIAPARAARMARKITS, :ERRORCODE;

                IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
                BEGIN
                    SUSPEND;
                    EXIT;
                END

                IF(COALESCE(:HAYEXISTENCIAPARAARMARKITS, 'N') <> 'S') THEN
                BEGIN
                    ERRORCODE = 4001;
                    SUSPEND;
                    EXIT;
                END
        
            END



    END



    UPDATE DOCTO SET ORIGENFISCALID = :ORIGENFISCALID,
                     REFERENCIA = :REFERENCIA,
                     VENCE = :VENCE ,
                     REFERENCIAS = :REFERENCIAS,
                     FECHAFACTURA = :FECHAFACTURA
     WHERE ID = :DOCTOID;

    UPDATE MOVTO SET CANTIDADDEFACTURA = iif(:ORIGENFISCALID = 3, CANTIDAD, 0),
    CANTIDADDEREMISION = iif(:ORIGENFISCALID = 2, CANTIDAD, 0) ,
    CANTIDADDEINDEFINIDO = iif((:ORIGENFISCALID < 2 ), CANTIDAD, 0)
    WHERE DOCTOID = :DOCTOID;

   
    ERRORCODE = 0;
   SUSPEND;
   
    WHEN ANY DO
    BEGIN
        ERRORCODE = 1065;
        SUSPEND;
    END

   -- Marcar los faltantes como ya generados.
ENd