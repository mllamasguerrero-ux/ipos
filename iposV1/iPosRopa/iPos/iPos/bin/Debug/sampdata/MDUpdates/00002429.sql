create or alter procedure GENERAR_PEDIDO (
    SUCURSALID D_FK,
    FECHA D_FECHA,
    CAJEROID D_FK,
    FORZADO D_BOOLCN,
    FECHATO D_FECHA,
    INCLUIRAPARTADO D_BOOLCS,
    SUBTIPODOCTOID D_FK)
returns (
    DOCTOID D_FK,
    ERRORCODE D_ERRORCODE)
as
declare variable PRODUCTOID D_FK;
declare variable CANTIDAD D_CANTIDAD;
declare variable TIPODOCTOID D_FK;
declare variable DOCTO2ID D_FK;
declare variable MOVTOID D_FK;
declare variable PRODUCTOCUENTA integer;
declare variable REFERENCIA D_REFERENCIA;
declare variable REFERENCIAS varchar(255);
declare variable COSTO D_COSTO;
declare variable SUCURSALTID D_FK;
declare variable ALMACENTID D_FK;
declare variable DOCTOACTUALID D_FK;
BEGIN
   IF ((:SUCURSALID IS NULL) OR (:SUCURSALID = 0)) THEN
   BEGIN
      ERRORCODE = 1055;
      SUSPEND;
      EXIT;
   END
  
   IF ((:FECHA IS NULL) OR (:FECHA > (CURRENT_DATE+365)) OR (:FECHA < (CURRENT_DATE-365))) THEN
   BEGIN
      ERRORCODE = 1056;
      SUSPEND;
      EXIT;
   END

   
   TIPODOCTOID = 14; -- Pedido Compra
   REFERENCIAS = NULL;
   SUCURSALTID = 0;
   ALMACENTID = 0;


   IF(:SUBTIPODOCTOID = 1) THEN
   BEGIN
        REFERENCIA =
     'PEDIDO SUC ' || :SUCURSALID || ' ' || :FECHATO ;

   -- Contar si hay registros para reportar.
        SELECT COUNT(M.ID)
        FROM  DOCTO D inner join MOVTO M
         ON D.ID = M.DOCTOID
        WHERE (D.FECHACORTE >= :FECHA  AND D.FECHACORTE <= :FECHATO)
        AND (D.TIPODOCTOID IN (21,31) or (d.tipodoctoid in (25) and :INCLUIRAPARTADO = 'S') )
        AND (D.ESTATUSDOCTOID = 1)
        AND ((D.ESTATUSDOCTOPEDIDOID IS NULL) OR (D.ESTATUSDOCTOPEDIDOID = 0) OR (:FORZADO = 'S'))

        INTO :PRODUCTOCUENTA;

   END
   ELSE
   BEGIN
   
        REFERENCIA =
     'PEDIDO SUC ' || :SUCURSALID || ' POR STOCK' ;

         SELECT count(PRODUCTO.ID)
          FROM PRODUCTO
          WHERE  PRODUCTO.manejastock = 'S' and
          (coalesce(PRODUCTO.stock,0) - (coalesce(PRODUCTO.existencia,0) + (CASE :INCLUIRAPARTADO WHEN 'S' THEN coalesce(PRODUCTO.existenciaapartado,0) ELSE 0 END ))) > 0
          INTO :PRODUCTOCUENTA;
   



   END

   
        IF ((:PRODUCTOCUENTA IS NULL) OR (:PRODUCTOCUENTA <= 0)) THEN
        BEGIN
            ERRORCODE = 1058;
            SUSPEND;
            EXIT;
        END
  
   -- Si hay prdductos para resurtir.


  
   -- Para mandar el mismo docto
   IF ((:DOCTOACTUALID = 0) OR (:DOCTOACTUALID IS NULL)) THEN
   BEGIN
      -- Pedido DOCTO. (GG: Fecha)
      SELECT DOCTOID, ERRORCODE
      FROM DOCTO_INSERT(0, 1, :SUCURSALID, :TIPODOCTOID, 1, 0, 1, :CAJEROID, 1,
        :REFERENCIA, :REFERENCIAS, :SUCURSALTID, :ALMACENTID, CURRENT_DATE, CURRENT_DATE,NULL,'S',1)
      INTO :DOCTOID, :ERRORCODE;

      UPDATE DOCTO SET FECHAINI = :FECHA , FECHAFIN = :FECHATO, SUBTIPODOCTOID = :SUBTIPODOCTOID WHERE ID = :DOCTOID;

      --update DOCTO set turnoid = :turnoid WHERE DOCTO.ID = :DOCTOID  ;
   END
   ELSE
   BEGIN
      DOCTOID = :DOCTOACTUALID;

      DELETE FROM MOVTO
      WHERE DOCTOID = :DOCTOID;
   END



   IF (:ERRORCODE > 0) THEN
   BEGIN
      SUSPEND;
      EXIT;
   END

   
   IF(:SUBTIPODOCTOID = 1) THEN
   BEGIN
        insert into movto (productoid, cantidad,doctoid)
        SELECT
        M.PRODUCTOID,
        SUM(M.CANTIDAD),
        :DOCTOID
        FROM  DOCTO D inner join MOVTO M
         ON D.ID = M.DOCTOID
        WHERE (D.FECHACORTE >= :FECHA  AND D.FECHACORTE <= :FECHATO)
        AND (D.TIPODOCTOID IN (21,31) or (d.tipodoctoid in (25) and :INCLUIRAPARTADO = 'S') )
        AND (D.ESTATUSDOCTOID = 1)
        AND ((D.ESTATUSDOCTOPEDIDOID IS NULL) OR (D.ESTATUSDOCTOPEDIDOID = 0) OR (:FORZADO = 'S'))
        GROUP BY M.PRODUCTOID;
   END
   ELSE
   BEGIN
         
        insert into movto (productoid, cantidad,doctoid)
        SELECT PRODUCTO.ID,

        CASE WHEN PRODUCTO.surtirporcaja = 'S' AND COALESCE(PRODUCTO.pzacaja,0) > 0 THEN

            ROUND( ((CASE WHEN :SUBTIPODOCTOID = 14 THEN  coalesce(PRODUCTO.stockmax,0) else coalesce(PRODUCTO.stock,0) end) - (coalesce(PRODUCTO.existencia,0) + (CASE :INCLUIRAPARTADO WHEN 'S' THEN coalesce(PRODUCTO.existenciaapartado,0) ELSE 0 END ))) / PRODUCTO.pzacaja  ,0) * PRODUCTO.PZACAJA
        ELSE
            ((CASE WHEN :SUBTIPODOCTOID = 14 THEN  coalesce(PRODUCTO.stockmax,0) else coalesce(PRODUCTO.stock,0) end) - (coalesce(PRODUCTO.existencia,0) + (CASE :INCLUIRAPARTADO WHEN 'S' THEN coalesce(PRODUCTO.existenciaapartado,0) ELSE 0 END )))
        END,

           :DOCTOID
          FROM PRODUCTO
          WHERE  PRODUCTO.manejastock = 'S'
          and (coalesce(PRODUCTO.stock,0) - (coalesce(PRODUCTO.existencia,0) + (CASE :INCLUIRAPARTADO WHEN 'S' THEN coalesce(PRODUCTO.existenciaapartado,0) ELSE 0 END ))) > 0 ;
          
   END


   --delete from movto where doctoid = :DOCTOID AND productoid not in ( select id from producto);
    
      UPDATE DOCTO
      SET ESTATUSDOCTOPEDIDOID = 1
      WHERE  (DOCTO.FECHACORTE >= :FECHA  AND DOCTO.FECHACORTE <= :FECHATO)
      AND (DOCTO.TIPODOCTOID IN (21,31) or (docto.tipodoctoid in (25) and :INCLUIRAPARTADO = 'S') )
      AND (DOCTO.ESTATUSDOCTOID = 1)
      AND ((DOCTO.ESTATUSDOCTOPEDIDOID IS NULL) OR (DOCTO.ESTATUSDOCTOPEDIDOID = 0) OR (:FORZADO = 'S')) ;




   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1059;
      SUSPEND;
   END
END