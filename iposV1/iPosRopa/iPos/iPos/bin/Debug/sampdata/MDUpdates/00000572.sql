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
    PORCENTAJEDESCUENTO D_PORCENTAJE,
    DOCTOREFID D_FK,
    ANAQUELID D_FK,
    LOCALIDAD D_LOCACION,
    P_MOVTOID D_FK,
    P_MOVTOREFID D_FK)
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
declare variable MOVTOREFID D_FK;
declare variable ESAPARTADO D_BOOLCN;
declare variable MERCANCIAENTREGADA D_BOOLCS;
declare variable ORIGENFISCALID D_FK;
declare variable EXISTENCIAFACTURADOACTUAL D_CANTIDAD;
declare variable EXISTENCIAREMISIONADOACTUAL D_CANTIDAD;
declare variable COMISIONXUNIDAD D_PRECIO;
declare variable TIENEDERECHOCAMBIARPRECIO type of D_BOOLCN;
BEGIN

  INGRESOPRECIOMANUAL = 'N';

  IF( :TIPODOCTOID IN (25,26) ) THEN
  BEGIN
     ESAPARTADO = 'S';
     MERCANCIAENTREGADA = 'N';
  END
  ELSE
  BEGIN 
     ESAPARTADO = 'N';
     MERCANCIAENTREGADA = 'S';
  END


  --Checar producto descontinuado en venta
   IF (:TIPODOCTOID in (21,25)) THEN
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
      ORIGENFISCALID = 1;
      IF(:TIPODOCTOID IN (12,15) AND :DOCTOREFID IS NOT NULL AND :DOCTOREFID <> 0) THEN
      BEGIN
           SELECT ORIGENFISCALID FROM DOCTO WHERE ID = :DOCTOREFID INTO :ORIGENFISCALID;
      END

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
         :VENCE,
         :DOCTOREFID  ,
         :MERCANCIAENTREGADA ,
         :ORIGENFISCALID
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
      SELECT PRECIO1, TASAIVA, COSTOPROMEDIO, COSTOREPOSICION, PRECIOMAXIMOPUBLICO, NEGATIVOS, INVENTARIABLE , UNIDAD, COMISION
      FROM PRODUCTO
      WHERE ID = :PRODUCTOID
      INTO :PRECIOLISTA, :TASAIVA, :COSTOPROMEDIO, :COSTOREPOSICION, :PRECIOMAXIMOPUBLICO, :NEGATIVOS, :INVENTARIABLE, :UNIDADPRODUCTO, :COMISIONXUNIDAD;

      COSTO = :COSTOPROMEDIO;
   END
   -- Si SI se recibe el costo, entonces tomar el costo que se recibe.
   ELSE
   BEGIN
      SELECT PRECIO1, coalesce(TASAIVA,0), COSTOREPOSICION, PRECIOMAXIMOPUBLICO, COSTOPROMEDIO, NEGATIVOS, INVENTARIABLE , UNIDAD, COMISION
      FROM PRODUCTO
      WHERE ID = :PRODUCTOID
      INTO :PRECIOLISTA, :TASAIVA, :COSTOREPOSICION, :PRECIOMAXIMOPUBLICO, :COSTOPROMEDIO, :NEGATIVOS, :INVENTARIABLE, :UNIDADPRODUCTO, :COMISIONXUNIDAD;
   END


   IF(:UNIDADPRODUCTO <> 'KG' AND ABS(CANTIDAD - FLOOR(CANTIDAD)) >= 0.001 ) then
   BEGIN
         ERRORCODE = 1083;
         SUSPEND;
         EXIT;
   END

   -- Seleccionar el precio lista para calcular el descuento, Solo para Ventas.
   IF (:TIPODOCTOID  in (21,25)) THEN
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
   --caso normal

   --Si ya recibimos el movtoid entonces no intentar buscarlo
   if(COALESCE(:P_MOVTOID,0) <> 0) THEN
   BEGIN
       MOVTOACTUALID = :P_MOVTOID;

       IF(:PRECIO IS NULL) THEN
       BEGIN
            SELECT PRECIO FROM MOVTO
            WHERE ID = :P_MOVTOID
            INTO :PRECIO;
       END   
       IF(:COSTO IS NULL) THEN
       BEGIN
            SELECT COSTO FROM MOVTO
            WHERE ID = :P_MOVTOID
            INTO :COSTO;
       END


   END
   ELSE
   BEGIN
        -- COMPRAS
        IF (:TIPODOCTOID in (11)) THEN
        BEGIN       
               IF(:COSTO IS NOT NULL) THEN
               BEGIN
                    SELECT FIRST 1 ID FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                    AND COSTO = :COSTO --ORDER BY COSTO DESC
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE ))
                    INTO :MOVTOACTUALID;
               END
               ELSE
               BEGIN    
                    SELECT FIRST 1 ID, COSTO FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE ))
                    ORDER BY COSTO
                    INTO :MOVTOACTUALID, :COSTO;
               END
        END
        -- VENTAS Y VENTAS DE APARTADO
        ELSE if (:TIPODOCTOID IN (21,25)) then
        BEGIN
               IF(:PRECIO IS NOT NULL) THEN
               BEGIN      
                    SELECT FIRST 1 ID FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                    AND PRECIO = :PRECIO --ORDER BY PRECIO DESC     
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE ))
                    INTO :MOVTOACTUALID;
               END
               ELSE
               BEGIN   
                    SELECT FIRST 1 ID, PRECIO FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID  
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE ))
                    ORDER BY PRECIO DESC
                    INTO :MOVTOACTUALID, :PRECIO;
               END
        END   
        -- DEVOLUCION DE VENTA
        ELSE if (:TIPODOCTOID IN (22)) then
        BEGIN


               IF(COALESCE(:P_MOVTOREFID,0) <> 0) THEN
               BEGIN
                    MOVTOREFID = :P_MOVTOREFID;
               END

               IF(:PRECIO IS NOT NULL) THEN
               BEGIN
                    SELECT FIRST 1 ID FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                    AND PRECIO = :PRECIO
                    AND (:P_MOVTOREFID IS NULL or MOVTOREFID = :P_MOVTOREFID)
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE ))
                    INTO :MOVTOACTUALID;

               END
               ELSE
               BEGIN   

                    SELECT FIRST 1 ID, PRECIO FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                    AND (:P_MOVTOREFID IS NULL or MOVTOREFID = :P_MOVTOREFID)
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE ))
                    ORDER BY  PRECIO
                    INTO :MOVTOACTUALID, :PRECIO;
               END
        END  
        -- DEVOLUCION DE COMPRA
        ELSE if (:TIPODOCTOID IN (12)) then
        BEGIN

                

               IF(COALESCE(:P_MOVTOREFID,0) <> 0) THEN
               BEGIN
                    MOVTOREFID = :P_MOVTOREFID;
               END

               IF(:COSTO IS NOT NULL) THEN
               BEGIN
                    SELECT FIRST 1 ID FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                    AND COSTO= :COSTO
                    AND (:P_MOVTOREFID IS NULL or MOVTOREFID = :P_MOVTOREFID)
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE ))
                    INTO :MOVTOACTUALID;

               END
               ELSE
               BEGIN   
                    SELECT FIRST 1 ID, PRECIO FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                    AND (:P_MOVTOREFID IS NULL or MOVTOREFID = :P_MOVTOREFID)
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE ))
                    ORDER BY  COSTO DESC
                    INTO :MOVTOACTUALID, :PRECIO;
               END
        END  
        ELSE if (:TIPODOCTOID IN (53)) then
        BEGIN   
            SELECT COALESCE(ID, 0)
            FROM MOVTO
            WHERE DOCTOID = :DOCTOID
            AND PRODUCTOID = :PRODUCTOID
            AND COALESCE(ANAQUELID,0) = COALESCE(:ANAQUELID,0)
            AND COALESCE(LOCALIDAD,'') = COALESCE(:LOCALIDAD,'')
            INTO :MOVTOACTUALID;
        END
        ELSE
        BEGIN     
            SELECT COALESCE(ID, 0)
            FROM MOVTO
            WHERE DOCTOID = :DOCTOID
            AND PRODUCTOID = :PRODUCTOID
            INTO :MOVTOACTUALID;
        END
   END

   /*IF (:TIPODOCTOID  <> (53)) THEN
   BEGIN
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
   END
   --caso inventario x localidad
   ELSE
   BEGIN
            SELECT COALESCE(ID, 0)
            FROM MOVTO
            WHERE DOCTOID = :DOCTOID
            AND PRODUCTOID = :PRODUCTOID
            AND COALESCE(ANAQUELID,0) = COALESCE(:ANAQUELID,0)
            AND COALESCE(LOCALIDAD,'') = COALESCE(:LOCALIDAD,'')
            INTO :MOVTOACTUALID;
   END
      */





















   -- Si no hay movto registrado, Insertar nuevo Movto.
   IF ((:MOVTOACTUALID IS NULL) OR (:MOVTOACTUALID = 0)) THEN
   BEGIN
      -- Solo para movimientos que tengan afectacion de inventarios.
      -- Por ahora solo excluir el Tipo 50 (Captura de inventario = Borrador)
      IF (:TIPODOCTOID not in (50,81,53)) then   -- !!! temporal falta analisis de Gerardo
      BEGIN
         -- #########################################################
         -- Validar existencia bajo cero.
         IF ((:NEGATIVOS = 'N') AND (:INVENTARIABLE = 'S'))  THEN
         BEGIN
            -- Solo para documentos con tipo que sea SALIDA del inventario:
            -- Ventas, devoluciones, etc.
            IF (:TIPODOCTOID IN (SELECT ID FROM TIPODOCTO WHERE SENTIDOINVENTARIO = -1)) THEN
            BEGIN
               SELECT EXISTENCIA, EXISTENCIAFACTURADO, EXISTENCIAREMISIONADO, ERRORCODE
               FROM GET_EXISTENCIA(:PRODUCTOID, :ALMACENID, :LOTE, :FECHAVENCE)
               INTO :EXISTENCIAACTUAL, :EXISTENCIAFACTURADOACTUAL, :EXISTENCIAREMISIONADOACTUAL, :ERRORCODE;


               IF(:ERRORCODE <> 0) THEN
               BEGIN  
                  SUSPEND;
                  EXIT;
               END
      
               IF (:EXISTENCIAACTUAL < :CANTIDAD) THEN
               BEGIN
               
                 --INSERT INTO TRAZA (VALOR) VALUES ( 'movto_insert linea 152');
                  ERRORCODE = 1081;
                  SUSPEND;
                  EXIT;
               END

               /*IF( :TIPODOCTOID = 12 AND COALESCE(:DOCTOREFID,0)> 0 ) THEN
               BEGIN
                       SELECT ORIGENFISCALID FROM DOCTO WHERE ID = :DOCTOREFID INTO :ORIGENFISCALID;

                      IF((:ORIGENFISCALID = 2 and :EXISTENCIAREMISIONADOACTUAL < :CANTIDAD)
                         or (:ORIGENFISCALID = 3 and :EXISTENCIAFACTURADOACTUAL < :CANTIDAD) ) THEN
                      BEGIN   
                             ERRORCODE = 3001;
                             SUSPEND;
                             EXIT;
                      END
               END   */


            END
         END

         -- Obtener nuevo precio fn(Prod, TipoDocto, Sucursal, ...)
         -- Si es compra obtenemos el costo.
         SELECT PRECIO, ERRORCODE
         FROM GET_PRODUCTO_PRECIO_DOCTO(:PRODUCTOID, :PERSONAID, :CANTIDAD,
                 :TIPODOCTOID, :SUCURSALID, :SUCURSALTID, :COSTO)
         INTO :PRECIONUEVO, :ERRORCODE;



         -- Si es compra, para que el importe y descuento sean correctos.
         IF (:TIPODOCTOID in (11,50,51,52,53)) THEN
         BEGIN
            PRECIOLISTA = :COSTO;
            PRECIONUEVO = :COSTO;
         END

         -- si es devolucion de venta hay que obtener el precio de la devolucion
               
         IF (:TIPODOCTOID = 22) THEN
         BEGIN
          IF(COALESCE(:DOCTOREFID ,0) <> 0) THEN
          BEGIN
              SELECT PRECIODEVOLUCION,ERRORCODE, MOVTOREFID FROM GET_REFERENCIAS_DEVOLUCION(:productoid,  :DOCTOID, :DOCTOREFID, :P_MOVTOREFID)
               INTO :PRECIONUEVO, :ERRORCODE, :MOVTOREFID;
            
               IF (:ERRORCODE > 0) THEN
               BEGIN
                  SUSPEND;
                  EXIT;
               END

               IF(COALESCE(:MOVTOREFID ,0) = 0) THEN
               BEGIN
                -- Validar si el usuario puede devolver sin venta
                SELECT ACCESO
                FROM GET_DERECHO(:PERSONAID, 10012)
                INTO :TIENEDERECHOCAMBIARPRECIO;

                  IF(:TIENEDERECHOCAMBIARPRECIO <> 'S') THEN
                  BEGIN
                        ERRORCODE = 3004;   
                        SUSPEND;
                        EXIT;
                  END
               END


           END
           ELSE
           BEGIN
                SELECT PRODUCTO.costoreposicion FROM PRODUCTO WHERE ID = :PRODUCTOID INTO :PRECIONUEVO;
           END
           PRECIOLISTA = :PRECIONUEVO;
         END
           
         IF (:TIPODOCTOID = 24) THEN
         BEGIN
         
               PRECIONUEVO = :PRECIO;
               PRECIOLISTA = :PRECIO;
         END
         
         IF (:TIPODOCTOID = 26) THEN
         BEGIN
         
               PRECIONUEVO = :PRECIO;
               PRECIOLISTA = :PRECIO;
         END

         
         IF (:TIPODOCTOID = 12) THEN
         BEGIN
            SELECT PRECIODEVOLUCION,ERRORCODE, MOVTOREFID FROM GET_REFERENCIAS_COMPRADEVO(:productoid,  :DOCTOID, :DOCTOREFID, :P_MOVTOREFID)
            INTO :PRECIONUEVO, :ERRORCODE, :MOVTOREFID;
            
            IF (:ERRORCODE > 0) THEN
            BEGIN
                  SUSPEND;
                  EXIT;
            END
                
               IF(COALESCE(:MOVTOREFID ,0) = 0) THEN
               BEGIN
                -- Validar si el usuario tiene derecho a cambiar el precio.
                SELECT ACCESO
                FROM GET_DERECHO(:PERSONAID, 10013)
                INTO :TIENEDERECHOCAMBIARPRECIO;

                  IF(:TIENEDERECHOCAMBIARPRECIO <> 'S') THEN
                  BEGIN
                        ERRORCODE = 3004;   
                        SUSPEND;
                        EXIT;
                  END
               END

               
             IF(:COSTO IS NOT NULL ) THEN
             BEGIN
                    PRECIONUEVO = :COSTO;
             END
             PRECIOLISTA = :PRECIONUEVO;
            PRECIOLISTA = :PRECIONUEVO;

         END

         
         IF (:TIPODOCTOID = 15) THEN
         BEGIN
         
               PRECIONUEVO = :PRECIO;
               PRECIOLISTA = :PRECIO;
         END



         -- Si es venta, y el precio < preciostd (2012-01-31: GAGL)
         -- Validar que el usuario tenga derecho a cambiar los precios.
         -- Para tipo 21=Venta
         IF (:TIPODOCTOID  in (21,25,22)) THEN
         BEGIN
            IF ((:PRECIO IS NOT NULL) AND
            (:PRECIO <> :PRECIONUEVO)) THEN
            BEGIN
               SELECT ERRORCODE
               FROM VALIDAR_PRECIO(:PRODUCTOID, :PRECIO, :PRECIONUEVO, :COSTO, :VENDEDORID, :TIPODOCTOID)
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
         INGRESOPRECIOMANUAL,
         MOVTOREFID,
         ESAPARTADO,
         COMISIONXUNIDAD,
         TIPODOCTOID,
         ANAQUELID,
         LOCALIDAD
         )
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
         :INGRESOPRECIOMANUAL,
         :MOVTOREFID,
         :ESAPARTADO,
         :COMISIONXUNIDAD,
         :TIPODOCTOID,
         :ANAQUELID,
         :LOCALIDAD
      ) RETURNING ID INTO :MOVTOID;
   END
   -- Actualizar el movto ya existente.
   ELSE
   BEGIN
      MOVTOID = :MOVTOACTUALID;

      -- Validar existencia bajo cero.
      IF (((:NEGATIVOS = 'N') AND (:INVENTARIABLE = 'S')) AND (:TIPODOCTOID not in (50,81,53))) THEN
      BEGIN
         -- Solo para documentos con tipo que sea SALIDA del inventario:
         -- Ventas, devoluciones, etc.
         IF (:TIPODOCTOID IN (SELECT ID FROM TIPODOCTO WHERE SENTIDOINVENTARIO = -1)) THEN
         BEGIN
            SELECT CANTIDAD
            FROM MOVTO
            WHERE ID = :MOVTOID
            INTO :CANTIDADACTUAL;
   
            
            SELECT EXISTENCIA, EXISTENCIAFACTURADO, EXISTENCIAREMISIONADO, ERRORCODE
            FROM GET_EXISTENCIA(:PRODUCTOID, :ALMACENID, :LOTE, :FECHAVENCE)
            INTO :EXISTENCIAACTUAL, :EXISTENCIAFACTURADOACTUAL, :EXISTENCIAREMISIONADOACTUAL, :ERRORCODE;

   
            IF (:EXISTENCIAACTUAL < (:CANTIDADACTUAL + :CANTIDAD)) THEN
            BEGIN
               ERRORCODE = 1081;
               SUSPEND;
               EXIT;
            END

            
              /*IF( :TIPODOCTOID = 12 AND COALESCE(:DOCTOREFID,0)> 0 ) THEN
               BEGIN
                       SELECT ORIGENFISCALID FROM DOCTO WHERE ID = :DOCTOREFID INTO :ORIGENFISCALID;

                      IF((:ORIGENFISCALID = 2 and :EXISTENCIAREMISIONADOACTUAL < (:CANTIDADACTUAL + :CANTIDAD))
                         or (:ORIGENFISCALID = 3 and :EXISTENCIAFACTURADOACTUAL < (:CANTIDADACTUAL + :CANTIDAD)) ) THEN
                      BEGIN   
                             ERRORCODE = 3001;
                             SUSPEND;
                             EXIT;
                      END
               END */


         END
      END

      UPDATE MOVTO
      SET
         CANTIDAD = CANTIDAD + :CANTIDAD,
         CANTIDADSURTIDA = CANTIDADSURTIDA + coalesce(:CANTIDADSURTIDA, 0),
         IMPORTE = PRECIO * ( CANTIDAD + :CANTIDAD )
      WHERE ID = :MOVTOID
      RETURNING CANTIDAD, PRECIO
      INTO :CANTIDADACUM, :PRECIOACTUAL;

      -- Solo para movimientos que tengan afectacion de inventarios.
      -- Por ahora solo excluir el Tipo 50 (Captura de inventario = Borrador)
      IF (:TIPODOCTOID not in (50,53)) then   -- !!! temporal falta analisis de Gerardo
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

         
         -- Si es compra, para que el importe y descuento sean correctos.
         IF (:TIPODOCTOID in (11,50,51,52,53)) THEN
         BEGIN
            PRECIOLISTA = :COSTO;
            PRECIONUEVO = :COSTO;
         END

         
         -- si es devolucion de venta hay que obtener el precio de la devolucion
               
               
         IF (:TIPODOCTOID = 22) THEN
         BEGIN
          IF(COALESCE(:DOCTOREFID ,0) <> 0) THEN
          BEGIN
              SELECT PRECIODEVOLUCION,ERRORCODE, MOVTOREFID FROM GET_REFERENCIAS_DEVOLUCION(:productoid,  :DOCTOID, :DOCTOREFID, :P_MOVTOREFID)
               INTO :PRECIONUEVO, :ERRORCODE, :MOVTOREFID;
            
               IF (:ERRORCODE > 0) THEN
               BEGIN
                  SUSPEND;
                  EXIT;
               END

               
               IF(COALESCE(:MOVTOREFID ,0) = 0) THEN
               BEGIN
                    -- Validar si el usuario tiene derecho a cambiar el precio.
                    SELECT ACCESO
                    FROM GET_DERECHO(:PERSONAID, 10012)
                    INTO :TIENEDERECHOCAMBIARPRECIO;

                    IF(:TIENEDERECHOCAMBIARPRECIO <> 'S') THEN
                    BEGIN
                        ERRORCODE = 3004;   
                        SUSPEND;
                        EXIT;
                    END
               END
           END
           ELSE
           BEGIN
                SELECT PRODUCTO.costoreposicion FROM PRODUCTO WHERE ID = :PRODUCTOID INTO :PRECIONUEVO;
           END
           PRECIOLISTA = :PRECIONUEVO;
         END

         
         IF (:TIPODOCTOID = 12) THEN
         BEGIN
            SELECT PRECIODEVOLUCION,ERRORCODE, MOVTOREFID FROM GET_REFERENCIAS_COMPRADEVO(:productoid,  :DOCTOID, :DOCTOREFID, :P_MOVTOREFID)
            INTO :PRECIONUEVO, :ERRORCODE, :MOVTOREFID;
            
            IF (:ERRORCODE > 0) THEN
            BEGIN
                  SUSPEND;
                  EXIT;
            END

            
               IF(COALESCE(:MOVTOREFID ,0) = 0) THEN
               BEGIN
                -- Validar si el usuario tiene derecho a cambiar el precio.
                SELECT ACCESO
                FROM GET_DERECHO(:PERSONAID, 10013)
                INTO :TIENEDERECHOCAMBIARPRECIO;

                  IF(:TIENEDERECHOCAMBIARPRECIO <> 'S') THEN
                  BEGIN
                        ERRORCODE = 3004;   
                        SUSPEND;
                        EXIT;
                  END
               END
                
             IF(:COSTO IS NOT NULL ) THEN
             BEGIN
                    PRECIONUEVO = :COSTO;
             END
             PRECIOLISTA = :PRECIONUEVO;


         END

         
         IF (:TIPODOCTOID = 15) THEN
         BEGIN
         
               PRECIONUEVO = :PRECIO;
               PRECIOLISTA = :PRECIO;
         END


            --      END

         -- Si es venta, y el precio < preciostd (2012-01-31: GAGL)
         -- Validar que el usuario tenga derecho a cambiar los precios.
         -- Para tipo 21=Venta
         IF (:TIPODOCTOID  in (21,25,22)) THEN
         BEGIN
            IF ((:PRECIO IS NOT NULL) AND
            (:PRECIO <> :PRECIONUEVO)) THEN
            BEGIN
               SELECT ERRORCODE
               FROM VALIDAR_PRECIO(:PRODUCTOID, :PRECIO, :PRECIONUEVO, :COSTO, :VENDEDORID, :TIPODOCTOID)
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

              IF (:PRECIO IS  NULL) THEN
              BEGIN
                    -- Si se especifica PorcentajeDescuento, aplicar este descuento.
                    IF (:PORCENTAJEDESCUENTO IS NOT NULL) THEN
                    BEGIN
                        PRECIONUEVO = :PRECIONUEVO * (100.00 - :PORCENTAJEDESCUENTO) / 100.00;
                        PORCENTAJEDESCUENTOMANUAL = :PORCENTAJEDESCUENTO;
                    END
              END   
               PRECIO = :PRECIONUEVO;
               PRECIOMANUAL = :PRECIO;

            END
         END


         -- Aqui llega si se cumplieron una de dos condiciones:
         --   > El precio es el estandar
         --   > El precio es menor al estandar pero el usuario tiene derecho.





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

         --INSERT INTO TRAZA (VALOR) VALUES('PRECIONUEVO ' || CAST(:PRECIONUEVO AS VARCHAR(20)) || ' TOTAL ' || CAST(:TOTAL AS VARCHAR(20)) ) ;

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
            INGRESOPRECIOMANUAL  = :INGRESOPRECIOMANUAL  ,
            COSTOIMPORTE = :COSTOIMPORTE
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