create or alter procedure KIT_DESAMBLARNOVIGENTES (
    VENDEDORID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable DOCTOID D_FK;
declare variable MOVTOID D_FK;
declare variable ALMACENID D_FK;
declare variable CAJAID D_FK;
declare variable SUCURSALID D_FK;
declare variable PRODUCTOID D_FK;
declare variable LOTE D_LOTE;
declare variable FECHAVENCE D_FECHAVENCE;
declare variable CANTIDAD D_CANTIDAD;
declare variable CANTIDADSURTIDA D_CANTIDAD;
declare variable CANTIDADFALTANTE D_CANTIDAD;
declare variable CANTIDADDIFERENCIA D_CANTIDAD;
declare variable ESTATUSDOCTOID D_FK;
declare variable FALTANTES integer;
declare variable REFERENCIA D_REFERENCIA;
declare variable COSTO D_COSTO;
declare variable SUCURSALTID D_FK;
declare variable ALMACENTID D_FK;
declare variable TIPODIFERENCIAINVENTARIOID D_FK;
declare variable TIPODOCTOID D_FK;
declare variable PERSONAID D_FK;
declare variable DESCRIPCION1 D_STDTEXT_64;
declare variable DESCRIPCION2 D_STDTEXT_64;
declare variable DESCRIPCION3 D_STDTEXT_64;
declare variable LOTEIMPORTADO D_FK;
declare variable EXISTENCIA D_CANTIDAD;
declare variable MANEJAKITS D_BOOLCN;
BEGIN

   ERRORCODE = 0;
   


   SELECT PARAMETRO.sucursalid, PARAMETRO.manejakits FROM PARAMETRO INTO :SUCURSALID, :MANEJAKITS;


   -- Inicializara para primer registro de movto
   DOCTOID = 0;
   TIPODOCTOID= 502;

   -- Agrega un MOVTO para cada registro con diferencia
   -- entre CANTIDAD y CANTIDADSURTIDA
   FOR SELECT
      p.id,
      I.LOTE,
      I.FECHAVENCE,
      COALESCE(I.CANTIDAD,0),
      0.0 CANTIDADSURTIDA,
      0.0 CANTIDADFALTANTE,
      P.costoreposicion,
      null TIPODIFERENCIA,
      1 PERSONAID  ,
      P.DESCRIPCION1,
      P.DESCRIPCION2,
      P.DESCRIPCION3,
      I.LOTEIMPORTADO,
      I.ALMACENID

   FROM
        PRODUCTO P
        INNER JOIN INVENTARIO I
        ON I.productoid = P.ID

   WHERE COALESCE(P.eskit,'N') = 'S' AND COALESCE(P.kittienevig,'N') = 'S' AND COALESCE(P.vigenciaprodkit,CURRENT_DATE) < CURRENT_DATE
          and COALESCE(I.cantidad,0) > 0
   INTO
      :PRODUCTOID, :LOTE, :FECHAVENCE,
      :CANTIDAD, :CANTIDADSURTIDA, :CANTIDADFALTANTE,
      :COSTO, :TIPODIFERENCIAINVENTARIOID, :PERSONAID  , :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3 ,:LOTEIMPORTADO,
      :ALMACENID
   DO
   BEGIN
      COSTO = 0;

      SUCURSALTID = 0;

            SELECT EXISTENCIA FROM PRODUCTO WHERE ID = :PRODUCTOID INTO :EXISTENCIA;

            IF(COALESCE(:EXISTENCIA,0) >= COALESCE(:CANTIDAD,0)) THEN
            BEGIN


                SELECT DOCTOID, MOVTOID, ERRORCODE
                FROM MOVTO_INSERT(:DOCTOID, 0, :ALMACENID, :SUCURSALID, :TIPODOCTOID, 0, 0, :PERSONAID, :VENDEDORID, 1, 0,
                    :PRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDAD, :CANTIDADSURTIDA, :CANTIDADFALTANTE, 0, 0, 0, 0,
                    :REFERENCIA, '', :COSTO, :SUCURSALID, :ALMACENID, 'N', NULL, CURRENT_DATE, CURRENT_DATE, 0.00,NULL,NULL,NULL,NULL,NULL, :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3, NULL, :LOTEIMPORTADO)
                INTO :DOCTOID, :MOVTOID, :ERRORCODE;

                IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
                BEGIN
                    --insert into traza(valor) values('kkl. ' || cast(:productoid as varchar(10)));

                    SUSPEND;
                    EXIT;
                END
            END
   END



   IF(COALESCE(:DOCTOID,0) > 0 ) THEN
   BEGIN
        SELECT ERRORCODE FROM KIT_APLICARDESENSAMBLE (:DOCTOID) INTO :ERRORCODE;

        
        IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
        BEGIN
            SUSPEND;
            EXIT;
        END
   END






   ERRORCODE = 0;
   SUSPEND;
   
   /*WHEN ANY DO
   BEGIN
     ERRORCODE = 4006;
     SUSPEND;
   END    */
END