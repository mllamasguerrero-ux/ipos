create or alter procedure VENTA_PRECIERRE (
    DOCTOID D_FK,
    VENDEDORID D_FK,
    VENDEDORFINAL D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable TIPODOCTOID D_FK;
declare variable ESTATUSDOCTOID D_FK;
declare variable FALTANTES integer;
declare variable REFERENCIAS varchar(255);
declare variable DETALLESSINEXISTENCIA integer;
declare variable HAYEXISTENCIAPARAARMARKITS D_BOOLCS;
declare variable MANEJAKITS D_BOOLCN;
declare variable SENTIDOINVENTARIO D_SENTIDO;
declare variable CORTEID D_FK;
declare variable HAYCORTEACTIVO D_BOOLCN;
BEGIN


   SELECT HAYCORTEACTIVO,CORTEID,ERRORCODE
   FROM HAY_CORTE_ACTIVO(:VENDEDORID)
   INTO :HAYCORTEACTIVO, :CORTEID, :ERRORCODE;

   IF (:ERRORCODE > 0) THEN
   BEGIN
      SUSPEND;
      EXIT;
   END



   -- Si no es documento de compra 11.
   IF ((:DOCTOID IS NULL) OR (:DOCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1060;
      SUSPEND;
      EXIT;
   END

   -- Validar estatus.
   SELECT TIPODOCTOID, ESTATUSDOCTOID  , TIPODOCTO.sentidoinventario
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
   IF (:TIPODOCTOID not in (21,25,31, 321) ) THEN
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


    SELECT  COALESCE(MANEJAKITS,'N') FROM PARAMETRO
    INTO  :MANEJAKITS;



    IF( COALESCE(:MANEJAKITS,'N') = 'N' or (COALESCE(:sentidoinventario, 0) <> -1) /*:TIPODOCTOID NOT IN (21,31)*/) THEN
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


    -- Checar que si se necesita armar kits hay kits suficientes
     IF(COALESCE(:MANEJAKITS,'N') = 'S' AND (COALESCE(:sentidoinventario, 0) = -1)/*:TIPODOCTOID  IN (21,31)*/) THEN
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


    UPDATE DOCTO SET VENDEDORFINAL = :VENDEDORFINAL, VENDEDORID = :VENDEDORID, CORTEID = :CORTEID WHERE ID = :DOCTOID;

   
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