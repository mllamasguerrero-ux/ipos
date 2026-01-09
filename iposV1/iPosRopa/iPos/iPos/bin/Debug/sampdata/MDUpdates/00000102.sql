CREATE OR ALTER PROCEDURE MOVTO_INSERT (
    DOCTOACTUALID TYPE OF D_FK,
    CREADOPOR_USERID TYPE OF D_FK,
    ALMACENID TYPE OF D_FK,
    SUCURSALID TYPE OF D_FK,
    TIPODOCTOID TYPE OF D_FK,
    ESTATUSDOCTOID TYPE OF D_FK,
    ESTATUSDOCTOPAGOID TYPE OF D_FK,
    PERSONAID TYPE OF D_FK,
    VENDEDORID TYPE OF D_FK,
    CAJAID TYPE OF D_FK,
    PARTIDA SMALLINT,
    PRODUCTOID TYPE OF D_FK,
    LOTE TYPE OF D_LOTE,
    FECHAVENCE TYPE OF D_FECHAVENCE,
    CANTIDAD TYPE OF D_CANTIDAD,
    CANTIDADSURTIDA TYPE OF D_CANTIDAD,
    CANTIDADFALTANTE TYPE OF D_CANTIDAD,
    CANTIDADDEVUELTA TYPE OF D_CANTIDAD,
    CANTIDADSALDO TYPE OF D_CANTIDAD,
    PRECIO TYPE OF D_PRECIO,
    ESTATUSMOVTOID TYPE OF D_FK,
    REFERENCIA TYPE OF D_REFERENCIA,
    REFERENCIAS VARCHAR(255),
    COSTO TYPE OF D_COSTO,
    SUCURSALTID TYPE OF D_FK,
    ALMACENTID TYPE OF D_FK,
    PROMOCION TYPE OF D_BOOLCN,
    TIPODIFERENCIAINVENTARIOID TYPE OF D_FK,
    FECHA D_FECHA,
    VENCE D_FECHA)
RETURNS (
    DOCTOID TYPE OF D_PK,
    MOVTOID TYPE OF D_PK,
    ERRORCODE TYPE OF D_ERRORCODE)
AS
DECLARE VARIABLE PRECIOLISTA TYPE OF D_PRECIO;
DECLARE VARIABLE DESCUENTOPORCENTAJE TYPE OF D_PORCENTAJE;
DECLARE VARIABLE DESCUENTO TYPE OF D_PRECIO;
DECLARE VARIABLE IMPORTE TYPE OF D_PRECIO;
DECLARE VARIABLE SUBTOTAL TYPE OF D_PRECIO;
DECLARE VARIABLE TASAIVA TYPE OF D_PORCENTAJE;
DECLARE VARIABLE IVA TYPE OF D_PRECIO;
DECLARE VARIABLE TOTAL TYPE OF D_PRECIO;
DECLARE VARIABLE COSTOPROMEDIO TYPE OF D_COSTO;
DECLARE VARIABLE COSTOIMPORTE TYPE OF D_COSTO;
DECLARE VARIABLE CARGO TYPE OF D_PRECIO;
DECLARE VARIABLE ABONO TYPE OF D_PRECIO;
DECLARE VARIABLE SALDO TYPE OF D_PRECIO;
DECLARE VARIABLE DOCTOERRORCODE TYPE OF D_FK;
DECLARE VARIABLE CANTIDADACUM TYPE OF D_CANTIDAD;
DECLARE VARIABLE PRECIOACTUAL TYPE OF D_PRECIO;
DECLARE VARIABLE PRECIONUEVO TYPE OF D_PRECIO;
DECLARE VARIABLE MOVTOACTUALID TYPE OF D_FK;
BEGIN
   -- Si no se recibe valor en el parametro DoctoActualId, es docto nuevo.
   IF ((:DOCTOACTUALID IS NULL) OR (:DOCTOACTUALID = 0)) THEN
   BEGIN
      SELECT DOCTOID, ERRORCODE
      FROM DOCTO_INSERT (
         :CREADOPOR_USERID,
         :ALMACENID,
         :SUCURSALID,
         :TIPODOCTOID,
         :ESTATUSDOCTOID,
         :ESTATUSDOCTOPAGOID,
         :PERSONAID,
         :VENDEDORID,
         :CAJAID,
         :REFERENCIA,
         :REFERENCIAS,
         :SUCURSALTID,
         :ALMACENTID,
         :FECHA,
         :VENCE
      ) INTO :DOCTOID, :DOCTOERRORCODE;
   END
   ELSE
   BEGIN
      DOCTOERRORCODE = 0;
      DOCTOID = :DOCTOACTUALID;
   END

   IF (:DOCTOERRORCODE > 0) THEN
   BEGIN
      ERRORCODE = :DOCTOERRORCODE;
      SUSPEND;
      EXIT;
   END

   -- Tomar precio del producto.
   -- ... REVISAR ESTO CON MANUEL, PARA RASTREAR LA APLICACION DEL COSTO.
   -- Si NO se recibe el costo, tomar costo promedio del producto
   IF ((:COSTO IS NULL) OR (:COSTO = 0))  THEN
   BEGIN
      SELECT PRECIO1, TASAIVA, :COSTOPROMEDIO
      FROM PRODUCTO
      WHERE ID = :PRODUCTOID
      INTO :PRECIOLISTA, :TASAIVA, :COSTO;
   END
   -- Si SI se recibe el costo, entonces tomar el costo que se recibe.
   ELSE
   BEGIN
      SELECT PRECIO1, TASAIVA
      FROM PRODUCTO
      WHERE ID = :PRODUCTOID
      INTO :PRECIOLISTA, :TASAIVA;
   END

   -- Buscar el MovtoId
   -- Si no recibimos lote por (Docto, Producto)
   IF ((:LOTE IS NULL) OR (:LOTE = '')) THEN
   BEGIN
      SELECT COALESCE(ID, 0)
      FROM MOVTO
      WHERE DOCTOID = :DOCTOID
        AND PRODUCTOID = :PRODUCTOID
      INTO :MOVTOACTUALID;
   END
   -- Si recibimos lote por (Docto, Producto, Lote, FechaVence)
   ELSE
   BEGIN
      SELECT COALESCE(ID, 0)
      FROM MOVTO
      WHERE DOCTOID = :DOCTOID
        AND PRODUCTOID = :PRODUCTOID
        AND LOTE = :LOTE
        AND FECHAVENCE = :FECHAVENCE
      INTO :MOVTOACTUALID;
   END

   -- Si no hay movto registrado, Insertar nuevo Movto.
   IF ((:MOVTOACTUALID IS NULL) OR (:MOVTOACTUALID = 0)) THEN
   BEGIN
      -- Solo para movimientos que tengan afectacion de inventarios.
      -- Por ahora solo excluir el Tipo 50 (Captura de inventario = Borrador)
      IF (:TIPODOCTOID <> 50) then   -- !!! temporal falta analisis de Gerardo
      BEGIN
         -- Obtener nuevo precio fn(Prod, TipoDocto, Sucursal, ...)
         -- Si es compra obtenemos el costo.
         SELECT PRECIO, ERRORCODE
         FROM GET_PRODUCTO_PRECIO_DOCTO(:PRODUCTOID, :PERSONAID, :CANTIDAD, :TIPODOCTOID, :SUCURSALID, :SUCURSALTID, :COSTO)
         INTO :PRECIONUEVO, :ERRORCODE;

         -- Calcular descuento.
         IF (:PRECIONUEVO < :PRECIOLISTA) THEN
         BEGIN
            DESCUENTO = :PRECIOLISTA - :PRECIONUEVO;
            
            --Manuel Llamas Evitar division entre 0
            IF (:PRECIOLISTA = 0) THEN
              DESCUENTOPORCENTAJE  =  0 ;
            ELSE
              DESCUENTOPORCENTAJE = (:DESCUENTO / :PRECIOLISTA) * 100.00;
         END
         ELSE
         BEGIN
            -- Si es producto de promocion, o sea gratis.
            -- El descuento es todo el precio.
            IF (:PROMOCION = 'S') THEN
               DESCUENTO = :PRECIOLISTA;
            ELSE
               DESCUENTO = 0.00;
            
             --Manuel Llamas Evitar division entre 0
             IF (:PRECIOLISTA = 0) then
                DESCUENTOPORCENTAJE  =  0 ;
             ELSE
                DESCUENTOPORCENTAJE = (:DESCUENTO / :PRECIOLISTA) * 100.00;
         
            IF (:PROMOCION = 'S') THEN
               PRECIONUEVO = 0.00;
         END

         IMPORTE = :CANTIDAD * :PRECIOLISTA;
         SUBTOTAL = :CANTIDAD * :PRECIONUEVO;

         IF (:TASAIVA > 0.00) THEN
           IVA = :SUBTOTAL * (:TASAIVA / 100.00);
         ELSE
           IVA = 0.00;

         TOTAL = :SUBTOTAL + :IVA;
         
         COSTOIMPORTE = :CANTIDAD * :COSTO;
      END

      INSERT INTO MOVTO (
         DOCTOID,
         ESTATUSMOVTOID,
         PARTIDA,
         PRODUCTOID,
         LOTE,
         FECHAVENCE,
         CANTIDAD,
         CANTIDADSURTIDA,
         CANTIDADFALTANTE,
         CANTIDADDEVUELTA,
         CANTIDADSALDO,
         PRECIO,
         PRECIOLISTA,
         IMPORTE,
         SUBTOTAL,
         DESCUENTO,
         IVA,
         TOTAL,
         COSTO,
         COSTOIMPORTE,
         TIPODIFERENCIAINVENTARIOID,
         PROMOCION)
      VALUES (
         :DOCTOID,
         :ESTATUSMOVTOID,
         :PARTIDA,
         :PRODUCTOID,
         :LOTE,
         :FECHAVENCE,
         :CANTIDAD,
         :CANTIDADSURTIDA,
         :CANTIDADFALTANTE,
         :CANTIDADDEVUELTA,
         :CANTIDADSALDO,
         :PRECIONUEVO,
         :PRECIOLISTA,
         :IMPORTE,
         :SUBTOTAL,
         :DESCUENTO,
         :IVA,
         :TOTAL,
         :COSTO,
         :COSTOIMPORTE,
         :TIPODIFERENCIAINVENTARIOID,
         :PROMOCION
      ) RETURNING ID INTO :MOVTOID;
   END
   -- Actualizar el movto ya existente.
   ELSE
   BEGIN
      MOVTOID = :MOVTOACTUALID;

      UPDATE MOVTO
      SET
         CANTIDAD = CANTIDAD + :CANTIDAD,
         CANTIDADSURTIDA = CANTIDADSURTIDA + coalesce(:CANTIDADSURTIDA, 0),
         IMPORTE = PRECIO * CANTIDAD
      WHERE ID = :MOVTOID
      RETURNING CANTIDAD, PRECIO
      INTO :CANTIDADACUM, :PRECIOACTUAL;

      -- Solo para movimientos que tengan afectacion de inventarios.
      -- Por ahora solo excluir el Tipo 50 (Captura de inventario = Borrador)
      IF (:TIPODOCTOID <> 50) then   -- !!! temporal falta analisis de Gerardo
      BEGIN
         --      IF (:PROMOCION = 'S') THEN
         --      BEGIN
         --         PRECIONUEVO = 0.00;
         --         ERRORCODE = 0;
         --      END
         --      ELSE
         --      BEGIN
         -- Ver si acumula un precio con descuento
         -- Obtener nuevo precio fn(Prod, TipoDocto, Sucursal, CantidadAcumulada)
         SELECT PRECIO, ERRORCODE
         FROM GET_PRODUCTO_PRECIO_DOCTO(:PRODUCTOID, :PERSONAID, :CANTIDADACUM,
            :TIPODOCTOID, :SUCURSALID, :SUCURSALTID, :COSTO)
         INTO :PRECIONUEVO, :ERRORCODE;
            --      END

         -- Calcular descuento.
         IF (:PRECIONUEVO < :PRECIOLISTA) THEN
         BEGIN
            DESCUENTO = :PRECIOLISTA - :PRECIONUEVO;
            --Manuel Llamas Evitar division entre 0
            IF (:PRECIOLISTA = 0) THEN
              DESCUENTOPORCENTAJE  =  0;
            ELSE
              DESCUENTOPORCENTAJE = (:DESCUENTO / :PRECIOLISTA) * 100.00;
         END
         ELSE
         BEGIN
            IF (:PROMOCION = 'S') THEN
              DESCUENTO = :PRECIOLISTA;
            ELSE
              DESCUENTO = 0.00;
            
            --Manuel Llamas Evitar division entre 0
            IF (:PRECIOLISTA = 0) THEN
               DESCUENTOPORCENTAJE  =  0 ;
            ELSE
               DESCUENTOPORCENTAJE = (:DESCUENTO / :PRECIOLISTA) * 100.00;

            IF (:PROMOCION = 'S') THEN
              PRECIONUEVO = 0.00;
         
          --DESCUENTO = 0.00;
          --DESCUENTOPORCENTAJE = 0.00;
         END
       
         IMPORTE = :CANTIDADACUM * :PRECIOLISTA;
         SUBTOTAL = :CANTIDADACUM * :PRECIONUEVO;
         IF (:TASAIVA > 0.00) THEN
            IVA = :SUBTOTAL * (:TASAIVA / 100.00);
         ELSE
            IVA = 0.00;
         TOTAL = :SUBTOTAL + :IVA;
         
         COSTOIMPORTE = :CANTIDADACUM * :COSTO;

         UPDATE MOVTO
         SET
            PRECIO = :PRECIONUEVO,
            IMPORTE = :IMPORTE,
            SUBTOTAL = :SUBTOTAL, 
            IVA = :IVA,
            TOTAL = :TOTAL,
            DESCUENTO = :DESCUENTO,
            DESCUENTOPORCENTAJE = :DESCUENTOPORCENTAJE,
            TIPODIFERENCIAINVENTARIOID = :TIPODIFERENCIAINVENTARIOID
         WHERE ID = :MOVTOID;
      END
   END

   IF ((:DOCTOID IS NULL) OR (:DOCTOID = 0) OR (:MOVTOID IS NULL) OR (:MOVTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1003;
   END

   SUSPEND;
END
