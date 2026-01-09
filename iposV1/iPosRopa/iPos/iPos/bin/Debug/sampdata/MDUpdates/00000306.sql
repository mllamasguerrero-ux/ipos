CREATE OR ALTER PROCEDURE GENERAR_PEDIDO (
    sucursalid d_fk,
    fecha d_fecha,
    turnoid d_fk,
    forzado d_boolcn)
returns (
    doctoid d_fk,
    errorcode d_errorcode)
as
declare variable productoid d_fk;
declare variable cantidad d_cantidad;
declare variable tipodoctoid d_fk;
declare variable docto2id d_fk;
declare variable movtoid d_fk;
declare variable productocuenta integer;
declare variable referencia d_referencia;
declare variable referencias varchar(255);
declare variable costo d_costo;
declare variable sucursaltid d_fk;
declare variable almacentid d_fk;
declare variable doctoactualid d_fk;
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
  
   IF ((:TURNOID IS NULL) /*OR (:TURNOID = 0)*/) THEN
   BEGIN
      ERRORCODE = 1057;
      SUSPEND;
      EXIT;
   END

   -- Contar si hay registros para reportar.
   SELECT COUNT(M.ID)
   FROM MOVTO M
      LEFT JOIN DOCTO D
         ON D.ID = M.DOCTOID
      LEFT JOIN CORTE C
         ON C.ID = D.CORTEID
   WHERE D.FECHACORTE = :FECHA
      AND ((C.TURNOID = :TURNOID) OR (:TURNOID = 4))
      AND (D.TIPODOCTOID IN (21,31))
      AND (D.ESTATUSDOCTOID = 1)
      AND ((D.ESTATUSDOCTOPEDIDOID IS NULL) OR (D.ESTATUSDOCTOPEDIDOID = 0) OR (:FORZADO = 'S'))
   INTO :PRODUCTOCUENTA;

   IF ((:PRODUCTOCUENTA IS NULL) OR (:PRODUCTOCUENTA <= 0)) THEN
   BEGIN
      ERRORCODE = 1058;
      SUSPEND;
      EXIT;
   END
  
   -- Si hay prdductos para resurtir.
  
   TIPODOCTOID = 14; -- Pedido Compra

   REFERENCIA =
     'PEDIDO SUC ' || :SUCURSALID || ' ' || :FECHA || ' T. ' || :TURNOID;
    
   REFERENCIAS = NULL;

   SUCURSALTID = 0;
   ALMACENTID = 0;
    
   SELECT COALESCE(MAX(D.ID), 0)
   FROM DOCTO D
   WHERE D.FECHA = :FECHA
      AND D.TURNOID = :TURNOID
      AND D.TIPODOCTOID = 14
   INTO :DOCTOACTUALID;
  
   -- Para mandar el mismo docto
   IF ((:DOCTOACTUALID = 0) OR (:DOCTOACTUALID IS NULL)) THEN
   BEGIN
      -- Pedido DOCTO. (GG: Fecha)
      SELECT DOCTOID, ERRORCODE
      FROM DOCTO_INSERT(0, 1, :SUCURSALID, :TIPODOCTOID, 1, 0, 1, 0, 1,
        :REFERENCIA, :REFERENCIAS, :SUCURSALTID, :ALMACENTID, :FECHA, :FECHA)
      INTO :DOCTOID, :ERRORCODE;

      update DOCTO set turnoid = :turnoid WHERE DOCTO.ID = :DOCTOID  ;
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

   FOR SELECT
      M.PRODUCTOID,
      SUM(M.CANTIDAD)
   FROM MOVTO M
      LEFT JOIN DOCTO D
         ON D.ID = M.DOCTOID
      LEFT JOIN CORTE C
         ON C.ID = D.CORTEID
   WHERE D.FECHACORTE = :FECHA
      AND ((C.TURNOID = :TURNOID) OR (:TURNOID = 4))
      AND (D.TIPODOCTOID IN (21,31))
      AND (D.ESTATUSDOCTOID = 1)
      AND ((D.ESTATUSDOCTOPEDIDOID IS NULL) OR (D.ESTATUSDOCTOPEDIDOID = 0) OR (:FORZADO = 'S'))
   GROUP BY M.PRODUCTOID
   INTO
      :PRODUCTOID, :CANTIDAD
   DO
   BEGIN
      COSTO = 0;

      -- Pedido MOVTO. (GG: Fecha)
      SELECT DOCTOID, MOVTOID, ERRORCODE
      FROM MOVTO_INSERT(:DOCTOID, 0, 1, 1, :TIPODOCTOID, 1, 0, 1, 0, 0, 0,
         :PRODUCTOID, NULL, NULL, :CANTIDAD, 0, :CANTIDAD, 0, 0, 0, 0, :REFERENCIA, :REFERENCIAS, :COSTO,
       :SUCURSALTID, :ALMACENTID, 'N', 0, :FECHA, :FECHA, 0.00)
      INTO :DOCTO2ID, :MOVTOID, :ERRORCODE;

      IF (:ERRORCODE > 0) THEN
      BEGIN
         SUSPEND;
         EXIT;
      END
   END

   -- Marcar los pedidos como YA pedidos con ESTATUSDOCTOPEDIDOID = 1
   FOR SELECT
      DISTINCT D.ID
   FROM MOVTO M
      LEFT JOIN DOCTO D
         ON D.ID = M.DOCTOID
      LEFT JOIN CORTE C
         ON C.ID = D.CORTEID
   WHERE D.FECHACORTE = :FECHA
      AND ((C.TURNOID = :TURNOID) OR (:TURNOID = 4))
      AND (D.TIPODOCTOID IN (21,31))
      AND (D.ESTATUSDOCTOID = 1)
      AND ((D.ESTATUSDOCTOPEDIDOID IS NULL) OR (D.ESTATUSDOCTOPEDIDOID = 0) OR (:FORZADO = 'S'))
   INTO
      :DOCTO2ID
   DO
   BEGIN
      UPDATE DOCTO
      SET ESTATUSDOCTOPEDIDOID = 1
      WHERE ID = :DOCTO2ID;
   END

   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1059;
      SUSPEND;
   END
END