CREATE OR ALTER PROCEDURE MOVTO_INSERT (
    doctoactualid type of d_fk,
    creadopor_userid type of d_fk,
    almacenid type of d_fk,
    sucursalid type of d_fk,
    tipodoctoid type of d_fk,
    estatusdoctoid type of d_fk,
    estatusdoctopagoid type of d_fk,
    personaid type of d_fk,
    vendedorid type of d_fk,
    cajaid type of d_fk,
    partida smallint,
    productoid type of d_fk,
    lote type of d_lote,
    fechavence type of d_fechavence,
    cantidad type of d_cantidad,
    cantidadsurtida type of d_cantidad,
    cantidadfaltante type of d_cantidad,
    cantidaddevuelta type of d_cantidad,
    cantidadsaldo type of d_cantidad,
    precio type of d_precio,
    estatusmovtoid type of d_fk,
    referencia type of d_referencia,
    referencias varchar(255),
    costo type of d_costo,
    sucursaltid type of d_fk,
    almacentid type of d_fk,
    promocion type of d_boolcn,
    tipodiferenciainventarioid type of d_fk,
    fecha d_fecha,
    vence d_fecha,
    porcentajedescuento d_porcentaje)
returns (
    doctoid type of d_pk,
    movtoid type of d_pk,
    errorcode type of d_errorcode)
as
declare variable preciolista type of d_precio;
declare variable descuentoporcentaje type of d_porcentaje;
declare variable descuento type of d_precio;
declare variable importe type of d_precio;
declare variable subtotal type of d_precio;
declare variable tasaiva type of d_porcentaje;
declare variable iva type of d_precio;
declare variable total type of d_precio;
declare variable costopromedio type of d_costo;
declare variable costoimporte type of d_costo;
declare variable costoreposicion type of d_costo;
declare variable cargo type of d_precio;
declare variable abono type of d_precio;
declare variable saldo type of d_precio;
declare variable doctoerrorcode type of d_fk;
declare variable cantidadacum type of d_cantidad;
declare variable precioactual type of d_precio;
declare variable precionuevo type of d_precio;
declare variable movtoactualid type of d_fk;
declare variable preciominimo type of d_precio;
declare variable tienederecho type of d_boolcn;
declare variable preciomanual type of d_precio;
declare variable preciomaximopublico type of d_precio;
declare variable porcentajedescuentomanual type of d_porcentaje;
declare variable precioclasificacion integer;
declare variable tipopreciolistaparadescuento integer;
declare variable existenciaactual d_cantidad;
declare variable negativos d_boolcn;
declare variable inventariable d_boolcs;
declare variable cantidadactual d_cantidad;
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
      SELECT PRECIO1, TASAIVA, COSTOPROMEDIO, COSTOREPOSICION, PRECIOMAXIMOPUBLICO, NEGATIVOS, INVENTARIABLE
      FROM PRODUCTO
      WHERE ID = :PRODUCTOID
      INTO :PRECIOLISTA, :TASAIVA, :COSTOPROMEDIO, :COSTOREPOSICION, :PRECIOMAXIMOPUBLICO, :NEGATIVOS, :INVENTARIABLE;

      COSTO = :COSTOPROMEDIO;
   END
   -- Si SI se recibe el costo, entonces tomar el costo que se recibe.
   ELSE
   BEGIN
      SELECT PRECIO1, TASAIVA, COSTOREPOSICION, PRECIOMAXIMOPUBLICO, COSTOPROMEDIO, NEGATIVOS, INVENTARIABLE
      FROM PRODUCTO
      WHERE ID = :PRODUCTOID
      INTO :PRECIOLISTA, :TASAIVA, :COSTOREPOSICION, :PRECIOMAXIMOPUBLICO, :COSTOPROMEDIO, :NEGATIVOS, :INVENTARIABLE;
   END

   -- Seleccionar el precio lista para calcular el descuento, Solo para Ventas.
   IF (:TIPODOCTOID = 21) THEN
   BEGIN
      -- Seleccionar el tipo de precio lista para calcular el descuento.
      SELECT TIPOPRECIOLISTAPARADESCUENTO
      FROM IPOSTYPE WHERE ID = (SELECT IPOS_TYPE FROM PARAMETRO)
      INTO :TIPOPRECIOLISTAPARADESCUENTO;
   
      -- Seleccionar el precio lista para calcular el descuento
      IF (:TIPOPRECIOLISTAPARADESCUENTO = 0) THEN
         PRECIOLISTA = :PRECIOMAXIMOPUBLICO;
      ELSE IF (:TIPOPRECIOLISTAPARADESCUENTO = 1) THEN
         PRECIOLISTA = :PRECIOLISTA;
      ELSE
         PRECIOLISTA = :PRECIOMAXIMOPUBLICO;
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
         -- #########################################################
         -- Validar existencia bajo cero.
         IF ((:NEGATIVOS = 'N') AND (:INVENTARIABLE = 'S'))  THEN
         BEGIN
            -- Solo para documentos con tipo que sea SALIDA del inventario:
            -- Ventas, devoluciones, etc.
            IF (:TIPODOCTOID IN (SELECT ID FROM TIPODOCTO WHERE SENTIDOINVENTARIO = -1)) THEN
            BEGIN
               SELECT EXISTENCIA, ERRORCODE
               FROM GET_EXISTENCIA(:PRODUCTOID, :ALMACENID, :LOTE, :FECHAVENCE)
               INTO :EXISTENCIAACTUAL, :ERRORCODE;
      
               IF (:EXISTENCIAACTUAL < :CANTIDAD) THEN
               BEGIN
                  ERRORCODE = 1081;
                  SUSPEND;
                  EXIT;
               END
            END
         END

         -- Obtener nuevo precio fn(Prod, TipoDocto, Sucursal, ...)
         -- Si es compra obtenemos el costo.
         SELECT PRECIO, ERRORCODE
         FROM GET_PRODUCTO_PRECIO_DOCTO(:PRODUCTOID, :PERSONAID, :CANTIDAD,
                 :TIPODOCTOID, :SUCURSALID, :SUCURSALTID, :COSTO)
         INTO :PRECIONUEVO, :ERRORCODE;

         -- Si es compra, para que el importe y descuento sean correctos.
         IF (:TIPODOCTOID = 11) THEN
         BEGIN
            PRECIOLISTA = :COSTO;
            PRECIONUEVO = :COSTO;
         END

         -- Si es venta, y el precio < preciostd (2012-01-31: GAGL)
         -- Validar que el usuario tenga derecho a cambiar los precios.
         -- Para tipo 21=Venta
         IF (:TIPODOCTOID = 21) THEN
         BEGIN
            IF ((:PRECIO IS NOT NULL) AND
            (:PRECIO < :PRECIONUEVO)) THEN
            BEGIN
               SELECT ERRORCODE
               FROM VALIDAR_PRECIO(:PRODUCTOID, :PRECIO, :PRECIONUEVO, :COSTO, :PERSONAID)
               INTO :ERRORCODE;
   
               IF (:ERRORCODE > 0) THEN
               BEGIN
                  SUSPEND;
                  EXIT;
               END
   
               PRECIONUEVO = :PRECIO;
               PRECIOMANUAL = :PRECIO;
            END
            ELSE
            BEGIN
               PRECIO = :PRECIONUEVO;
               PRECIOMANUAL = :PRECIO;
            END
         END

         -- Aqui llega si se cumplieron una de dos condiciones:
         --   > El precio es el estandar
         --   > El precio es menor al estandar pero el usuario tiene derecho.

         -- Si se especifica PorcentajeDescuento, aplicar este descuento.
         IF (:PORCENTAJEDESCUENTO IS NOT NULL) THEN
         BEGIN
            PRECIONUEVO = :PRECIONUEVO * (100.00 - :PORCENTAJEDESCUENTO) / 100.00;
            PORCENTAJEDESCUENTOMANUAL = :PORCENTAJEDESCUENTO;
         END

         -- Calcular descuento FINAL, ya en relacion al precio de lista.
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

      SELECT ERRORCODE, CLASIFICACION
      FROM GET_PRECIO_CLASIFICACION(:PRODUCTOID, :PRECIO, :PRECIOLISTA,
            :PRECIOMAXIMOPUBLICO, :COSTO)
      INTO :ERRORCODE, :PRECIOCLASIFICACION;

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
         PROMOCION,
         PRECIOMANUAL,
         PORCENTAJEDESCUENTOMANUAL,
         COSTOREPOSICION,
         COSTOPROMEDIO,
         PRECIOMAXIMOPUBLICO,
         PRECIOCLASIFICACION)
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
         :PROMOCION,
         :PRECIOMANUAL,
         :PORCENTAJEDESCUENTOMANUAL,
         :COSTOREPOSICION,
         :COSTOPROMEDIO,
         :PRECIOMAXIMOPUBLICO,
         :PRECIOCLASIFICACION
      ) RETURNING ID INTO :MOVTOID;
   END
   -- Actualizar el movto ya existente.
   ELSE
   BEGIN
      MOVTOID = :MOVTOACTUALID;

      -- Validar existencia bajo cero.
      IF (((:NEGATIVOS = 'N') AND (:INVENTARIABLE = 'S')) AND (:TIPODOCTOID <> 50)) THEN
      BEGIN
         -- Solo para documentos con tipo que sea SALIDA del inventario:
         -- Ventas, devoluciones, etc.
         IF (:TIPODOCTOID IN (SELECT ID FROM TIPODOCTO WHERE SENTIDOINVENTARIO = -1)) THEN
         BEGIN
            SELECT CANTIDAD
            FROM MOVTO
            WHERE ID = :MOVTOID
            INTO :CANTIDADACTUAL;
   
            SELECT EXISTENCIA, ERRORCODE
            FROM GET_EXISTENCIA(:PRODUCTOID, :ALMACENID, :LOTE, :FECHAVENCE)
            INTO :EXISTENCIAACTUAL, :ERRORCODE;
   
            IF (:EXISTENCIAACTUAL < (:CANTIDADACTUAL + :CANTIDAD)) THEN
            BEGIN
               ERRORCODE = 1081;
               SUSPEND;
               EXIT;
            END
         END
      END

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

         -- Si es venta, y el precio < preciostd (2012-01-31: GAGL)
         -- Validar que el usuario tenga derecho a cambiar los precios.
         -- Para tipo 21=Venta
         IF (:TIPODOCTOID = 21) THEN
         BEGIN
            IF ((:PRECIO IS NOT NULL) AND
            (:PRECIO < :PRECIONUEVO)) THEN
            BEGIN
               SELECT ERRORCODE
               FROM VALIDAR_PRECIO(:PRODUCTOID, :PRECIO, :PRECIONUEVO, :COSTO, :PERSONAID)
               INTO :ERRORCODE;
   
               IF (:ERRORCODE > 0) THEN
               BEGIN
                  SUSPEND;
                  EXIT;
               END
   
               PRECIONUEVO = :PRECIO;
               PRECIOMANUAL = :PRECIO;
            END
            ELSE
            BEGIN
               PRECIO = :PRECIONUEVO;
               PRECIOMANUAL = :PRECIO;
            END
         END

         -- Aqui llega si se cumplieron una de dos condiciones:
         --   > El precio es el estandar
         --   > El precio es menor al estandar pero el usuario tiene derecho.

         -- Si se especifica PorcentajeDescuento, aplicar este descuento.
         IF (:PORCENTAJEDESCUENTO IS NOT NULL) THEN
         BEGIN
            PRECIONUEVO = :PRECIONUEVO * (100.00 - :PORCENTAJEDESCUENTO) / 100.00;
            PORCENTAJEDESCUENTOMANUAL = :PORCENTAJEDESCUENTO;
         END

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

   IF ((:DOCTOID IS NULL) OR
      (:DOCTOID = 0) OR
      (:MOVTOID IS NULL) OR
      (:MOVTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1003;
   END

   SUSPEND;
END