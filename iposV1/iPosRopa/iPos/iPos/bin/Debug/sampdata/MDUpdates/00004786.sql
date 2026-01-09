create or alter procedure TRASLADOPROMOCION_AJUSTXFINVIG
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
declare variable MANEJAPRODUCTOSPROMOCION D_BOOLCN;
BEGIN

   ERRORCODE = 0;
   

  SELECT PARAMETRO.sucursalid, MANEJAPRODUCTOSPROMOCION FROM PARAMETRO INTO :SUCURSALID, :MANEJAPRODUCTOSPROMOCION;

  IF(COALESCE(:MANEJAPRODUCTOSPROMOCION, 'N') = 'N') THEN
  BEGIN
   SUSPEND;
   EXIT;
  END
     
  TIPODOCTOIDAJUSTE = 1002;

  FOR SELECT
         I.almacenid
        FROM INVENTARIO I
        INNER JOIN PRODUCTO  P
          ON  P.ID = I.productoid
        WHERE P.esprodpromo = 'S' AND P.vigenciaprodpromo < CURRENT_DATE
            AND I.cantidad > 0
            GROUP BY I.almacenid
   INTO :ALMACENID
   DO
  BEGIN

   -- Inicializara para primer registro de movto
   DOCTOIDAJUSTE = 0;

   -- Agrega un MOVTO para cada registro con diferencia
   -- entre CANTIDAD y CANTIDADSURTIDA
   FOR SELECT
      P.ID,
      I.LOTE,
      I.FECHAVENCE,
       COALESCE(I.CANTIDAD,0),
      NULL, --M.CANTIDADSURTIDA,
      NULL, --M.CANTIDADFALTANTE,
      P.costoreposicion,
      0,--M.TIPODIFERENCIAINVENTARIOID,
      1,--D.PERSONAID  ,
      17,--D.VENDEDORID ,
      NULL,--M.DESCRIPCION1,
      NULL,--M.DESCRIPCION2,
      NULL,--M.DESCRIPCION3 ,
      I.LOTEIMPORTADO
   FROM INVENTARIO I
        INNER JOIN PRODUCTO  P
          ON  P.ID = I.productoid
   WHERE P.esprodpromo = 'S' AND P.vigenciaprodpromo < CURRENT_DATE
       AND I.cantidad > 0 AND I.almacenid = :ALMACENID
   INTO
      :PRODUCTOID, :LOTE, :FECHAVENCE,
      :CANTIDAD, :CANTIDADSURTIDA, :CANTIDADFALTANTE,
      :COSTO, :TIPODIFERENCIAINVENTARIOID, :PERSONAID , :VENDEDORID  , :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3 ,:LOTEIMPORTADO
   DO
   BEGIN
      COSTO = 0;

      SUCURSALTID = 0;




            SELECT DOCTOID, MOVTOID, ERRORCODE
            FROM MOVTO_INSERT(:DOCTOIDAJUSTE, 0, :ALMACENID, :SUCURSALID, :TIPODOCTOIDAJUSTE, 0, 0, :PERSONAID, :VENDEDORID, 1, 0,
               :PRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDAD, :CANTIDADSURTIDA, :CANTIDADFALTANTE, 0, 0, :COSTO, 0,
               NULL, '', :COSTO, NULL, NULL, 'N', NULL, CURRENT_DATE, CURRENT_DATE, 0.00,NULL,NULL,NULL,NULL,NULL, :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3, NULL, :LOTEIMPORTADO)
            INTO :DOCTOIDAJUSTE, :MOVTOID, :ERRORCODE;

            IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
            BEGIN
            --insert into traza(valor) values('kkl. ' || cast(:productoid as varchar(10)));

               SUSPEND;
               EXIT;
            END

   END



   IF(COALESCE(:DOCTOIDAJUSTE,0) <> 0) THEN
   BEGIN
        SELECT ERRORCODE
        FROM TRASLADOPROMOCION_APLICAR_DEST(:DOCTOIDAJUSTE)
        INTO :ERRORCODE;
   END

   IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
   BEGIN
      SUSPEND;
      EXIT;
   END


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