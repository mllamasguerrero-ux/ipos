create or alter procedure MOVTO_INSERT (
    DOCTOACTUALID type of D_FK,
    CREADOPOR_USERID type of D_FK,
    ALMACENID type of D_FK,
    SUCURSALID type of D_FK,
    TIPODOCTOID type of D_FK,
    ESTATUSDOCTOID type of D_FK,
    ESTATUSDOCTOPAGOID type of D_FK,
    PERSONAID type of D_FK,
    VENDEDORID type of D_FK,
    CAJAID type of D_FK,
    PARTIDA smallint,
    PRODUCTOID type of D_FK,
    LOTE type of D_LOTE,
    FECHAVENCE type of D_FECHAVENCE,
    CANTIDAD type of D_CANTIDAD,
    CANTIDADSURTIDA type of D_CANTIDAD,
    CANTIDADFALTANTE type of D_CANTIDAD,
    CANTIDADDEVUELTA type of D_CANTIDAD,
    CANTIDADSALDO type of D_CANTIDAD,
    PRECIO type of D_PRECIO,
    ESTATUSMOVTOID type of D_FK,
    REFERENCIA type of D_REFERENCIA,
    REFERENCIAS varchar(255),
    COSTO type of D_COSTO,
    SUCURSALTID type of D_FK,
    ALMACENTID type of D_FK,
    PROMOCION type of D_BOOLCN,
    TIPODIFERENCIAINVENTARIOID type of D_FK,
    FECHA D_FECHA,
    VENCE D_FECHA,
    PORCENTAJEDESCUENTO D_PORCENTAJE)
returns (
    DOCTOID type of D_PK,
    MOVTOID type of D_PK,
    ERRORCODE type of D_ERRORCODE)
as
declare variable PRECIOLISTA type of D_PRECIO;
declare variable DESCUENTOPORCENTAJE type of D_PORCENTAJE;
declare variable DESCUENTO type of D_PRECIO;
declare variable IMPORTE type of D_PRECIO;
declare variable SUBTOTAL type of D_PRECIO;
declare variable TASAIVA type of D_PORCENTAJE;
declare variable IVA type of D_PRECIO;
declare variable TOTAL type of D_PRECIO;
declare variable COSTOPROMEDIO type of D_COSTO;
declare variable COSTOIMPORTE type of D_COSTO;
declare variable COSTOREPOSICION type of D_COSTO;
declare variable CARGO type of D_PRECIO;
declare variable ABONO type of D_PRECIO;
declare variable SALDO type of D_PRECIO;
declare variable DOCTOERRORCODE type of D_FK;
declare variable CANTIDADACUM type of D_CANTIDAD;
declare variable PRECIOACTUAL type of D_PRECIO;
declare variable PRECIONUEVO type of D_PRECIO;
declare variable MOVTOACTUALID type of D_FK;
declare variable PRECIOMINIMO type of D_PRECIO;
declare variable TIENEDERECHO type of D_BOOLCN;
declare variable PRECIOMANUAL type of D_PRECIO;
declare variable PRECIOMAXIMOPUBLICO type of D_PRECIO;
declare variable PORCENTAJEDESCUENTOMANUAL type of D_PORCENTAJE;
declare variable PRECIOCLASIFICACION integer;
declare variable TIPOPRECIOLISTAPARADESCUENTO integer;
declare variable EXISTENCIAACTUAL D_CANTIDAD;
declare variable NEGATIVOS D_BOOLCN;
declare variable INVENTARIABLE D_BOOLCS;
declare variable CANTIDADACTUAL D_CANTIDAD;
declare variable UNIDADPRODUCTO varchar(10);
declare variable INGRESOPRECIOMANUAL D_BOOLCN;
declare variable DESCONTINUADO D_BOOLCN;
BEGIN

  INGRESOPRECIOMANUAL = 'N';



  --Checar producto descontinuado en venta
   IF (:TIPODOCTOID = 21) THEN
   BEGIN
      SELECT COALESCE(M.DESCONTINUADO,'N') FROM PRODUCTO P
      LEFT JOIN MARCA M ON M.ID = P.MARCAID
      WHERE P.id = :PRODUCTOID
      INTO :DESCONTINUADO;

      IF(:DESCONTINUADO = 'S') THEN
      BEGIN
        ERRORCODE = 2084;
        SUSPEND;
        EXIT;
      END
   END




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
      SELECT PRECIO1, TASAIVA, COSTOPROMEDIO, COSTOREPOSICION, PRECIOMAXIMOPUBLICO, NEGATIVOS, INVENTARIABLE , UNIDAD
      FROM PRODUCTO
      WHERE ID = :PRODUCTOID
      INTO :PRECIOLISTA, :TASAIVA, :COSTOPROMEDIO, :COSTOREPOSICION, :PRECIOMAXIMOPUBLICO, :NEGATIVOS, :INVENTARIABLE, :UNIDADPRODUCTO;

      COSTO = :COSTOPROMEDIO;
   END
   -- Si SI se recibe el costo, entonces tomar el costo que se recibe.
   ELSE
   BEGIN
      SELECT PRECIO1, coalesce(TASAIVA,0), COSTOREPOSICION, PRECIOMAXIMOPUBLICO, COSTOPROMEDIO, NEGATIVOS, INVENTARIABLE , UNIDAD
      FROM PRODUCTO
      WHERE ID = :PRODUCTOID
      INTO :PRECIOLISTA, :TASAIVA, :COSTOREPOSICION, :PRECIOMAXIMOPUBLICO, :COSTOPROMEDIO, :NEGATIVOS, :INVENTARIABLE, :UNIDADPRODUCTO;
   END


   IF(:UNIDADPRODUCTO <> 'KG' AND ABS(CANTIDAD - FLOOR(CANTIDAD)) >= 0.001 ) then
   BEGIN
         ERRORCODE = 1083;
         SUSPEND;
         EXIT;
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
            (:PRECIO <> :PRECIONUEVO)) THEN
            BEGIN
               SELECT ERRORCODE
               FROM VALIDAR_PRECIO(:PRODUCTOID, :PRECIO, :PRECIONUEVO, :COSTO, :VENDEDORID)
               INTO :ERRORCODE;
   
               IF (:ERRORCODE > 0) THEN
               BEGIN
                  SUSPEND;
                  EXIT;
               END
   
               PRECIONUEVO = :PRECIO;
               PRECIOMANUAL = :PRECIO;
               INGRESOPRECIOMANUAL = 'S';

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
         PRECIOCLASIFICACION,
         TASAIVA,
         INGRESOPRECIOMANUAL)
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
         :PRECIOCLASIFICACION ,
         coalesce(:TASAIVA,0),
         :INGRESOPRECIOMANUAL
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
            (:PRECIO <> :PRECIONUEVO)) THEN
            BEGIN
               SELECT ERRORCODE
               FROM VALIDAR_PRECIO(:PRODUCTOID, :PRECIO, :PRECIONUEVO, :COSTO, :VENDEDORID)
               INTO :ERRORCODE;
   
               IF (:ERRORCODE > 0) THEN
               BEGIN
                  SUSPEND;
                  EXIT;
               END
   
               PRECIONUEVO = :PRECIO;
               PRECIOMANUAL = :PRECIO;  
               INGRESOPRECIOMANUAL = 'S';
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
            TIPODIFERENCIAINVENTARIOID = :TIPODIFERENCIAINVENTARIOID ,
            TASAIVA = coalesce(:TASAIVA,0)  ,
            INGRESOPRECIOMANUAL  = :INGRESOPRECIOMANUAL
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