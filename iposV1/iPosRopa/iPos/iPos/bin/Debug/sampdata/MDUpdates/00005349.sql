create or alter procedure KIT_APLICAR (
    KITDOCTOID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable DOCTOIDPARTE D_FK;
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
declare variable VENDEDORID D_FK;
declare variable DESCRIPCION1 D_STDTEXT_64;
declare variable DESCRIPCION2 D_STDTEXT_64;
declare variable DESCRIPCION3 D_STDTEXT_64;
declare variable TIPODOCTOIDPARTE D_FK;
declare variable COUNTKITSSINPARTES integer;
declare variable LOTEIMPORTADO D_FK;
BEGIN

   ERRORCODE = 0;
   

   SELECT TIPODOCTOID, ESTATUSDOCTOID  , ALMACENID, SUCURSALID, CAJAID , ALMACENTID
   FROM DOCTO
   WHERE ID = :KITDOCTOID
   INTO :TIPODOCTOID, :ESTATUSDOCTOID ,:ALMACENID, :SUCURSALID, :CAJAID, :ALMACENTID;

   
   IF ((:KITDOCTOID IS NULL) OR (:KITDOCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 4005;
      SUSPEND;
      EXIT;
   END

   -- Interceptar docto no existente
   IF ((:TIPODOCTOID IS NULL) OR (:ESTATUSDOCTOID IS NULL)) THEN
   BEGIN
      ERRORCODE = 4003;
      SUSPEND;
      EXIT;
   END

   -- Solo admitir TipoDocto = 50, captura de inventario fisico.
   IF (:TIPODOCTOID NOT IN (501)) THEN
   BEGIN
      ERRORCODE = 4003;
      SUSPEND;
      EXIT;
   END

   -- Solo admitir EstatusDocto = 0, Borrador.
   IF (:ESTATUSDOCTOID != 0 ) THEN
   BEGIN
      ERRORCODE = 4004;
      SUSPEND;
      EXIT;
   END



    SELECT COUNT(*) COUNTKITSSINPARTES FROM MOVTO
    LEFT JOIN producto ON MOVTO.PRODUCTOID = PRODUCTO.ID
    WHERE movto.doctoid = :KITDOCTOID and coalesce(producto.eskit,'N') = 'S'
    and (select count(*) from kitdefinicion where kitdefinicion.productokitid = producto.id) = 0
    into :COUNTKITSSINPARTES;

    if(coalesce(:COUNTKITSSINPARTES,0) > 0) THEN
    BEGIN    
      ERRORCODE = 4002;
      SUSPEND;
      EXIT;
    END



   -- Inicializara para primer registro de movto
   DOCTOIDPARTE = 0;
   TIPODOCTOIDPARTE = 503;

   -- Agrega un MOVTO para cada registro con diferencia
   -- entre CANTIDAD y CANTIDADSURTIDA
   FOR SELECT
      K.productoparteid,
      M.LOTE,
      M.FECHAVENCE,
      COALESCE(K.cantidadparte,0) * COALESCE(M.CANTIDAD,0),
      M.CANTIDADSURTIDA,
      M.CANTIDADFALTANTE,
      M.COSTO,
      M.TIPODIFERENCIAINVENTARIOID,
      D.PERSONAID  ,
      D.VENDEDORID ,
      M.DESCRIPCION1,
      M.DESCRIPCION2,
      M.DESCRIPCION3 ,
      M.LOTEIMPORTADO
   FROM MOVTO M
     LEFT JOIN DOCTO D
       ON D.ID = M.DOCTOID
        INNER JOIN KITDEFINICION  K
          ON  K.productokitid = M.PRODUCTOID
   WHERE M.DOCTOID = :KITDOCTOID
      AND (M.CANTIDAD >0)
      ORDER BY M.partida
   INTO
      :PRODUCTOID, :LOTE, :FECHAVENCE,
      :CANTIDAD, :CANTIDADSURTIDA, :CANTIDADFALTANTE,
      :COSTO, :TIPODIFERENCIAINVENTARIOID, :PERSONAID , :VENDEDORID  , :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3 ,:LOTEIMPORTADO
   DO
   BEGIN
      COSTO = 0;

      SUCURSALTID = 0;




            SELECT DOCTOID, MOVTOID, ERRORCODE
            FROM MOVTO_INSERT(:DOCTOIDPARTE, 0, :ALMACENTID, :SUCURSALID, :TIPODOCTOIDPARTE, 0, 0, :PERSONAID, :VENDEDORID, 1, 0,
               :PRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDAD, :CANTIDADSURTIDA, :CANTIDADFALTANTE, 0, 0, 0, 0,
               :REFERENCIA, '', :COSTO, :SUCURSALTID, :ALMACENID, 'N', NULL, CURRENT_DATE, CURRENT_DATE, 0.00,:KITDOCTOID,NULL,NULL,NULL,NULL, :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3, NULL, :LOTEIMPORTADO, 'N','N')
            INTO :DOCTOIDPARTE, :MOVTOID, :ERRORCODE;

            IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
            BEGIN
            --insert into traza(valor) values('kkl. ' || cast(:productoid as varchar(10)));

               SUSPEND;
               EXIT;
            END
   END


   IF(COALESCE(:DOCTOIDPARTE,0) <> 0) THEN
   BEGIN
        SELECT ERRORCODE
        FROM DOCTO_SAVE(:DOCTOIDPARTE)
        INTO :ERRORCODE;
   END

   IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
   BEGIN
      SUSPEND;
      EXIT;
   END

   IF(COALESCE(:KITDOCTOID,0) <> 0) THEN
   BEGIN
        SELECT ERRORCODE
        FROM DOCTO_SAVE(:KITDOCTOID)
        INTO :ERRORCODE;
   END

   IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
   BEGIN
      SUSPEND;
      EXIT;
   END




   ERRORCODE = 0;
   SUSPEND;
   
   /*
   WHEN ANY DO
   BEGIN
     ERRORCODE = 1076;
     SUSPEND;
   END     */
END