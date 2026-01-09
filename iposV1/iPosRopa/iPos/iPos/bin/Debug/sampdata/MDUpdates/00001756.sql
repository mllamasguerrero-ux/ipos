create or alter procedure INVFIS_GEN_COMPLETO (
    DOCTOID D_FK,
    PERSONAID D_FK,
    SUBTIPODOCTOID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable TIPODOCTOID D_FK;
declare variable ESTATUSDOCTOID D_FK;
declare variable PRODUCTOID D_FK;
declare variable LOTE D_LOTE;
declare variable FECHAVENCE D_FECHAVENCE;
declare variable CANTIDAD D_CANTIDAD;
declare variable COSTO D_COSTO;
declare variable ALMACENID D_FK;
declare variable SUCURSALID D_FK;
declare variable DUMMY_DOCTOID D_FK;
declare variable MOVTOID D_FK;
BEGIN
   SELECT TIPODOCTOID, ESTATUSDOCTOID, ALMACENID, SUCURSALID
   FROM DOCTO
   WHERE ID = :DOCTOID
   INTO :TIPODOCTOID, :ESTATUSDOCTOID, :ALMACENID, :SUCURSALID;
   
   -- Solo admitir TipoDocto = 50, captura de inventario fisico.
   IF (:TIPODOCTOID not in (50,53)) THEN
   BEGIN
      ERRORCODE = 1071;
      SUSPEND;
      EXIT;
   END

   -- Solo admitir EstatusDocto = 0, Borrador.
   IF (:ESTATUSDOCTOID <> 0) THEN
   BEGIN
      ERRORCODE = 1072;
      SUSPEND;
      EXIT;
   END
        
   IF( :SUBTIPODOCTOID IN (4)) THEN
   BEGIN
    -- Insertar en el docto, los productos del inventario, con existencia, que no esten ya en el docto.
    FOR
      SELECT PRODUCTOID, coalesce(CANTIDAD,0), LOTE, FECHAVENCE, COSTO
      FROM INVENTARIO
      WHERE coalesce(CANTIDAD,0) > 0
        AND PRODUCTOID NOT IN (SELECT PRODUCTOID FROM MOVTO WHERE DOCTOID = :DOCTOID)
      INTO :PRODUCTOID, :CANTIDAD, :LOTE, :FECHAVENCE, :COSTO 
    DO
    BEGIN
      SELECT DOCTOID, MOVTOID, ERRORCODE
      FROM MOVTO_INSERT(:DOCTOID, 0, :ALMACENID, :SUCURSALID, :TIPODOCTOID, 0, 0, :PERSONAID, 0, 1, 0,
         :PRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDAD, 0, 0, 0, 0, 0, 0,
         '', '', :COSTO, 0, 0, 'N', 0, CURRENT_DATE, CURRENT_DATE, 0.00,NULL,NULL,NULL,NULL,NULL, NULL, NULL, NULL)
      INTO :DUMMY_DOCTOID, :MOVTOID, :ERRORCODE;
      
      IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
      BEGIN
         SUSPEND;
         EXIT;
      END
    END
   END


   IF( :SUBTIPODOCTOID IN (9,4)) THEN
   BEGIN
    -- Insertar en el docto, los productos del inventario, con existencia, que no esten ya en el docto.
    FOR
      SELECT inventario.PRODUCTOID, coalesce(inventario.CANTIDAD,0), inventario.LOTE, inventario.FECHAVENCE, inventario.COSTO
      FROM INVENTARIO
      inner join
            (select movto.productoid,  coalesce(movto.lote,'') lote,  coalesce(movto.fechavence,'') fechavence from movto
                where doctoid= :doctoid
            group by movto.productoid,  coalesce(movto.lote,'') ,  coalesce(movto.fechavence,'') )  m
      on inventario.productoid = m.productoid
      WHERE coalesce(inventario.CANTIDAD,0) > 0
        AND (coalesce(inventario.lote,'') <> coalesce(m.lote,'') or coalesce(inventario.fechavence,'') <> coalesce(m.fechavence,''))
      INTO :PRODUCTOID, :CANTIDAD, :LOTE, :FECHAVENCE, :COSTO 
    DO
    BEGIN
      SELECT DOCTOID, MOVTOID, ERRORCODE
      FROM MOVTO_INSERT(:DOCTOID, 0, :ALMACENID, :SUCURSALID, :TIPODOCTOID, 0, 0, :PERSONAID, 0, 1, 0,
         :PRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDAD, 0, 0, 0, 0, 0, 0,
         '', '', :COSTO, 0, 0, 'N', 0, CURRENT_DATE, CURRENT_DATE, 0.00,NULL,NULL,NULL,NULL,NULL, NULL, NULL, NULL)
      INTO :DUMMY_DOCTOID, :MOVTOID, :ERRORCODE;
      
      IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
      BEGIN
         SUSPEND;
         EXIT;
      END
    END
   END
   


   UPDATE DOCTO SET SUBTIPODOCTOID = :SUBTIPODOCTOID /*4*/ WHERE ID = :DOCTOID;

   IF (:ERRORCODE <> 0) THEN
   BEGIN
      SUSPEND;
      EXIT;
   END

   -- Regresar el errorcode que haya, sea 0 o No;
   SUSPEND;
   
   WHEN ANY DO
   BEGIN
     ERRORCODE = 1076;
     SUSPEND;
   END
END
