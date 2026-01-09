create or alter procedure TRASLADOPROMOCION_APLICAR_DEST (
    TRASLADOPROMOCIONID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable DOCTOIDAJUSTE D_FK;
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
declare variable TIPODOCTOIDAJUSTE D_FK;
declare variable COUNTPRODPROMOSINBASE integer;
declare variable LOTEIMPORTADO D_FK;
declare variable MOVTOREFID D_FK;
BEGIN

   ERRORCODE = 0;
   

   SELECT TIPODOCTOID, ESTATUSDOCTOID  , ALMACENID, SUCURSALID, CAJAID , ALMACENTID
   FROM DOCTO
   WHERE ID = :TRASLADOPROMOCIONID
   INTO :TIPODOCTOID, :ESTATUSDOCTOID ,:ALMACENID, :SUCURSALID, :CAJAID, :ALMACENTID;

   
   IF ((:TRASLADOPROMOCIONID IS NULL) OR (:TRASLADOPROMOCIONID = 0)) THEN
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
   IF (:TIPODOCTOID NOT IN (1002)) THEN
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



    SELECT COUNT(*) COUNTPRODPROMOSINBASE FROM MOVTO
    LEFT JOIN producto ON MOVTO.PRODUCTOID = PRODUCTO.ID
    WHERE movto.doctoid = :TRASLADOPROMOCIONID and coalesce(producto.esprodpromo,'N') = 'S'
          AND coalesce(producto.baseprodpromoid,0) = 0
    into :COUNTPRODPROMOSINBASE;

    if(coalesce(:COUNTPRODPROMOSINBASE,0) > 0) THEN
    BEGIN    
      ERRORCODE = 4002;
      SUSPEND;
      EXIT;
    END



   -- Inicializara para primer registro de movto
   DOCTOIDAJUSTE = 0;
   TIPODOCTOIDAJUSTE = 1004;

   -- Agrega un MOVTO para cada registro con diferencia
   -- entre CANTIDAD y CANTIDADSURTIDA
   FOR SELECT
      P.baseprodpromoid,
      M.LOTE,
      M.FECHAVENCE,
       COALESCE(M.CANTIDAD,0),
      M.CANTIDADSURTIDA,
      M.CANTIDADFALTANTE,
      P.costoreposicion,
      M.TIPODIFERENCIAINVENTARIOID,
      D.PERSONAID  ,
      D.VENDEDORID ,
      M.DESCRIPCION1,
      M.DESCRIPCION2,
      M.DESCRIPCION3 ,
      M.LOTEIMPORTADO ,
      M.ID
   FROM MOVTO M
     LEFT JOIN DOCTO D
       ON D.ID = M.DOCTOID
        INNER JOIN PRODUCTO  P
          ON  P.ID = M.PRODUCTOID
   WHERE M.DOCTOID = :TRASLADOPROMOCIONID
      AND (M.CANTIDAD > 0)
      ORDER BY M.partida
   INTO
      :PRODUCTOID, :LOTE, :FECHAVENCE,
      :CANTIDAD, :CANTIDADSURTIDA, :CANTIDADFALTANTE,
      :COSTO, :TIPODIFERENCIAINVENTARIOID, :PERSONAID , :VENDEDORID  , :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3 ,:LOTEIMPORTADO,
      :MOVTOREFID
   DO
   BEGIN
      COSTO = 0;

      SUCURSALTID = 0;




            SELECT DOCTOID, MOVTOID, ERRORCODE
            FROM MOVTO_INSERT(:DOCTOIDAJUSTE, 0, :ALMACENTID, :SUCURSALID, :TIPODOCTOIDAJUSTE, 0, 0, :PERSONAID, :VENDEDORID, 1, 0,
               :PRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDAD, :CANTIDADSURTIDA, :CANTIDADFALTANTE, 0, 0, :COSTO, 0,
               :REFERENCIA, '', :COSTO, :SUCURSALTID, :ALMACENID, 'N', NULL, CURRENT_DATE, CURRENT_DATE, 0.00,:TRASLADOPROMOCIONID,NULL,NULL,NULL,:MOVTOREFID, :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3, NULL, :LOTEIMPORTADO)
            INTO :DOCTOIDAJUSTE, :MOVTOID, :ERRORCODE;

            IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
            BEGIN
            --insert into traza(valor) values('kkl. ' || cast(:productoid as varchar(10)));

               SUSPEND;
               EXIT;
            END
            
            update movto set movtorefid = :movtoid where id = :movtorefid;
   END


   IF(COALESCE(:DOCTOIDAJUSTE,0) <> 0) THEN
   BEGIN
        SELECT ERRORCODE
        FROM DOCTO_SAVE(:DOCTOIDAJUSTE)
        INTO :ERRORCODE;
   END

   IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
   BEGIN
      SUSPEND;
      EXIT;
   END

   IF(COALESCE(:TRASLADOPROMOCIONID,0) <> 0) THEN
   BEGIN
        SELECT ERRORCODE
        FROM DOCTO_SAVE(:TRASLADOPROMOCIONID)
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