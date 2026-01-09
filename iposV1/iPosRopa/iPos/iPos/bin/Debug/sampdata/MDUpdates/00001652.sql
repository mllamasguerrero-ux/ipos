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
    P_MOVTOREFID D_FK,
    DESCRIPCION1 D_STDTEXT_64,
    DESCRIPCION2 D_STDTEXT_64,
    DESCRIPCION3 D_STDTEXT_64)
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
declare variable LLEGOPRECIOMANUAL D_BOOLCN;
declare variable ESPROMOCION D_BOOLCN;
declare variable PROMOCIONID D_FK;
declare variable PROMOCIONDESGLOSE D_STDTEXT_64;
declare variable MONEDEROABONO D_PRECIO;
declare variable ENPROCESODESALIDA D_CANTIDAD;
declare variable PRODUCTOCLAVE D_CLAVE_NULL;
declare variable TASAISRRETENIDO type of D_PORCENTAJE;
declare variable ISRRETENIDO type of D_PRECIO;
declare variable TASAIVARETENIDO type of D_PORCENTAJE;
declare variable IVARETENIDO type of D_PRECIO;
declare variable PERSONARETIENEISR type of D_BOOLCN;
declare variable PERSONARETIENEIVA type of D_BOOLCN;
declare variable TIPOCAMBIO type of D_TIPOCAMBIO;
declare variable BUFFERPRECIOMONEDA2 type of D_PRECIO;
declare variable TASAIEPS type of D_PORCENTAJE;
declare variable IEPS type of D_PRECIO;
declare variable TASAIMPUESTO type of D_PORCENTAJE;
declare variable IMPUESTO type of D_PRECIO;
declare variable DESGLOSEIEPS type of D_BOOLCN;
declare variable SUBTIPODOCTOID type of D_FK;
declare variable DESCRIPCION1_ACTUAL D_STDTEXT_64;
declare variable DESCRIPCION2_ACTUAL D_STDTEXT_64;
declare variable DESCRIPCION3_ACTUAL D_STDTEXT_64;
declare variable DESCRIPCION_COMODIN D_BOOLCN;
declare variable TIPODESCUENTOPRODID D_FK;
declare variable TEMPPRECIO D_PRECIO;
declare variable LISTAPRECIOCLIENTE varchar(1);
declare variable DESCUENTOCALCULADO D_BOOLCN;
declare variable LISTAPRECIOID varchar(1);
declare variable SUPERLISTAPRECIOID D_FK;
declare variable MANEJASUPERLISTAPRECIO D_BOOLCN;
BEGIN


   PORCENTAJEDESCUENTOMANUAL = coalesce(:PORCENTAJEDESCUENTO,0);
   SELECT COALESCE(TIPODESCUENTOPRODID,1) FROM PARAMETRO INTO :TIPODESCUENTOPRODID;


   

/* tipo cambio*/
   TIPOCAMBIO = 1;

   DESCUENTOCALCULADO = 'N';

   /*isr RETENIDO*/
   select RETENCIONISR, RETENCIONIVA from parametro into :TASAISRRETENIDO, :TASAIVARETENIDO;
   SELECT COALESCE(retieneisr,'N'),COALESCE(retieneiva,'N') from PERSONA where id = :personaid into :PERSONARETIENEISR, :PERSONARETIENEIVA;

   SELECT DESGLOSEIEPS FROM PARAMETRO INTO :DESGLOSEIEPS;
   DESGLOSEIEPS = COALESCE(:DESGLOSEIEPS,'N');


  /*RESETEAR VARIABLES DE PROMOCION*/
  ESPROMOCION = 'N';
  PROMOCIONID = NULL;
  PROMOCIONDESGLOSE = NULL;

  INGRESOPRECIOMANUAL = 'N';
  MONEDEROABONO = 0;

  PRODUCTOCLAVE = null;

  IF(:PRECIO IS NULL) THEN
  BEGIN
        LLEGOPRECIOMANUAL = 'N';
  END
  ELSE
  BEGIN   
        LLEGOPRECIOMANUAL = 'S';
  END




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
      SELECT PRECIO1, TASAIVA, COSTOPROMEDIO, COSTOREPOSICION, PRECIOMAXIMOPUBLICO, NEGATIVOS, INVENTARIABLE , UNIDAD, COMISION, ENPROCESODESALIDA , TASAIEPS, TASAIMPUESTO
      FROM PRODUCTO
      WHERE ID = :PRODUCTOID
      INTO :PRECIOLISTA, :TASAIVA, :COSTOPROMEDIO, :COSTOREPOSICION, :PRECIOMAXIMOPUBLICO, :NEGATIVOS, :INVENTARIABLE, :UNIDADPRODUCTO, :COMISIONXUNIDAD, :ENPROCESODESALIDA, :TASAIEPS, :TASAIMPUESTO;

      COSTO = :COSTOPROMEDIO;

   END
    -- para que puedan ingresar compras con costo 0
   if(:COSTO = -0.01) THEN
   BEGIN
        COSTO = 0;
   end

   -- Si SI se recibe el costo, entonces tomar el costo que se recibe.
   ELSE
   BEGIN
      SELECT PRECIO1, coalesce(TASAIVA,0), COSTOREPOSICION, PRECIOMAXIMOPUBLICO, COSTOPROMEDIO, NEGATIVOS, INVENTARIABLE , UNIDAD, COMISION , ENPROCESODESALIDA , TASAIEPS, TASAIMPUESTO
      FROM PRODUCTO
      WHERE ID = :PRODUCTOID
      INTO :PRECIOLISTA, :TASAIVA, :COSTOREPOSICION, :PRECIOMAXIMOPUBLICO, :COSTOPROMEDIO, :NEGATIVOS, :INVENTARIABLE, :UNIDADPRODUCTO, :COMISIONXUNIDAD, :ENPROCESODESALIDA , :TASAIEPS, :TASAIMPUESTO;
   END


   IF(:UNIDADPRODUCTO <> 'KG' AND ABS(CANTIDAD - FLOOR(CANTIDAD)) >= 0.001 ) then
   BEGIN
         ERRORCODE = 1083;
         SUSPEND;
         EXIT;
   END

   -- Seleccionar el precio lista para calcular el descuento, Solo para Ventas.
   IF (:TIPODOCTOID  in (21,25)) THEN
   BEGIN  /*
      -- Seleccionar el tipo de precio lista para calcular el descuento.
      SELECT TIPOPRECIOLISTAPARADESCUENTO
      FROM IPOSTYPE WHERE ID = (SELECT IPOS_TYPE FROM PARAMETRO)
      INTO :TIPOPRECIOLISTAPARADESCUENTO;
   
      -- Seleccionar el precio lista para calcular el descuento
      IF (:TIPOPRECIOLISTAPARADESCUENTO = 0) THEN
         PRECIOLISTA = :PRECIOMAXIMOPUBLICO;
       ELSE
       BEGIN    */

           SELECT LISTAPRECIOID, SUPERLISTAPRECIOID FROM
           PERSONA WHERE ID = :PERSONAID
           INTO :LISTAPRECIOID, :SUPERLISTAPRECIOID;

           SELECT MANEJASUPERLISTAPRECIO FROM PARAMETRO INTO :MANEJASUPERLISTAPRECIO;

          SELECT  FIRST 1

          
            CASE WHEN :TIPODESCUENTOPRODID = 1 THEN PRECIO1
            ELSE

                CASE WHEN COALESCE(:MANEJASUPERLISTAPRECIO ,'N') = 'N' THEN
                 CASE WHEN COALESCE(:LISTAPRECIOID, 1) = 1 THEN PRECIO1
                 WHEN COALESCE(:LISTAPRECIOID, 1) = 2 THEN PRECIO2
                 WHEN COALESCE(:LISTAPRECIOID, 1) = 3 THEN PRECIO3
                 WHEN COALESCE(:LISTAPRECIOID, 1) = 4 THEN PRECIO4
                 WHEN COALESCE(:LISTAPRECIOID, 1) = 5 THEN PRECIO5
                 ELSE PRECIO1 END

                ELSE
                 CASE WHEN COALESCE(:SUPERLISTAPRECIOID, 1) = 1 THEN SPRECIO1
                 WHEN COALESCE(:SUPERLISTAPRECIOID, 1) = 2 THEN SPRECIO2
                 WHEN COALESCE(:SUPERLISTAPRECIOID, 1) = 3 THEN SPRECIO3
                 WHEN COALESCE(:SUPERLISTAPRECIOID, 1) = 4 THEN SPRECIO4
                 WHEN COALESCE(:SUPERLISTAPRECIOID, 1) = 5 THEN SPRECIO5
                 ELSE PRECIO1 END

                END

            END


          FROM PRODUCTO
          WHERE PRODUCTO.ID = :PRODUCTOID
          INTO :PRECIOLISTA;
       --END
         /*
      ELSE IF (:TIPOPRECIOLISTAPARADESCUENTO = 1) THEN
         PRECIOLISTA = :PRECIOLISTA;
      ELSE
         PRECIOLISTA = :PRECIOMAXIMOPUBLICO; */
   END



   -- Buscar el MovtoId
   -- Si no recibimos lotepor (Docto, Producto)
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
        IF (:TIPODOCTOID in (11,16,17)) THEN
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
        ELSE if (:TIPODOCTOID IN (21,25,23)) then
        BEGIN


               IF(:PRECIO IS NOT NULL) THEN
               BEGIN
                    SELECT FIRST 1 ID FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                    AND PRECIO = :PRECIO
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE ))
                    INTO :MOVTOACTUALID;
               END
               ELSE
               BEGIN   
                    SELECT FIRST 1 ID, PRECIO FROM MOVTO
                    WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID  
                    AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE AND FECHAVENCE = :FECHAVENCE ))
                    AND (COALESCE(DESCUENTOPORCENTAJE,0) = COALESCE(:PORCENTAJEDESCUENTO,0) or :PORCENTAJEDESCUENTO is null)
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

                    select lote, fechavence from movto where id = :p_movtorefid into :lote, :fechavence;
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
                    select lote, fechavence from movto where id = :p_movtorefid into :lote, :fechavence;
              
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
        ELSE if (:TIPODOCTOID IN (81)) then
        BEGIN 
                SELECT COALESCE(ID, 0) FROM MOVTO
                WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE
                AND FECHAVENCE = :FECHAVENCE ))
                INTO :MOVTOACTUALID;


        END
        ELSE if (:TIPODOCTOID IN (50,51,52)) then
        BEGIN 
                SELECT COALESCE(ID, 0) FROM MOVTO
                WHERE DOCTOID = :DOCTOID AND PRODUCTOID = :PRODUCTOID
                AND (COALESCE(:LOTE,'') = '' OR  (COALESCE(:LOTE,'') = LOTE
                AND FECHAVENCE = :FECHAVENCE ))
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


   /* Evitar juntar movtos de productos comodin con distinta descripcion */
   SELECT COALESCE(DESCRIPCION_COMODIN,'N') FROM PRODUCTO WHERE ID = :PRODUCTOID INTO :DESCRIPCION_COMODIN;
   IF(COALESCE(:DESCRIPCION_COMODIN,'N') = 'S' AND :MOVTOACTUALID IS NOT NULL AND COALESCE(:DESCRIPCION1,'') <> '' ) THEN
   BEGIN
        select DESCRIPCION1, DESCRIPCION2, DESCRIPCION3 FROM MOVTO WHERE ID = :MOVTOACTUALID
        INTO :DESCRIPCION1_ACTUAL , :DESCRIPCION2_ACTUAL , :DESCRIPCION3_ACTUAL;

        IF(:DESCRIPCION1 <> :DESCRIPCION1_ACTUAL OR
           :DESCRIPCION2 <> :DESCRIPCION2_ACTUAL OR
           :DESCRIPCION3 <> :DESCRIPCION3_ACTUAL  )
           THEN
           BEGIN
                  MOVTOACTUALID = NULL;
           END


   END


    IF(:MOVTOACTUALID IS NOT NULL) THEN
    BEGIN
       select  INGRESOPRECIOMANUAL from movto  
       WHERE ID = :MOVTOACTUALID
       into :INGRESOPRECIOMANUAL;
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

   
     -- producto clave
    select clave from producto where id = :productoid into :PRODUCTOCLAVE;

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
               
                 --INSERT INTO TRAZA (VALOR) VALUES ( 'movto_insert linea x1');
                  ERRORCODE = 1081;
                  SUSPEND;
                  EXIT;
               END

               IF(:TIPODOCTOID IN (21,25,12,31) AND
                 COALESCE(:EXISTENCIAACTUAL,0) - COALESCE(:ENPROCESODESALIDA,0) < :CANTIDAD )THEN
               BEGIN
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
         SELECT PRECIO, ESPROMOCION, PROMOCIONID, PROMOCIONDESGLOSE, MONEDEROABONO, ERRORCODE
         FROM GET_PRODUCTO_PRECIO_DOCTO(:PRODUCTOID, :PERSONAID, :CANTIDAD,
                 :TIPODOCTOID, :SUCURSALID, :SUCURSALTID, :COSTO)
         INTO :PRECIONUEVO, :ESPROMOCION, :PROMOCIONID, :PROMOCIONDESGLOSE, :MONEDEROABONO ,:ERRORCODE;

         -- insert into traza(valor) values(:precionuevo);

         -- Si es compra, para que el importe y descuento sean correctos.
         IF (:TIPODOCTOID in (11,50,51,52,53,41,16,17)) THEN
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
                FROM GET_DERECHO(:VENDEDORID, 10012)
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
                FROM GET_DERECHO(:VENDEDORID, 10013)
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


         IF (:TIPODOCTOID = 23) THEN
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
            (:PRECIO <> :PRECIONUEVO) AND
             :LLEGOPRECIOMANUAL = 'S') THEN
            BEGIN
                select costoreposicion from producto where id = :productoid into :COSTOREPOSICION;
                select coalesce(SUBTIPODOCTOID,0) from docto where id = :doctoid into :SUBTIPODOCTOID;



                SELECT ERRORCODE
                FROM VALIDAR_PRECIO(:PRODUCTOID, :PRECIO, :PRECIONUEVO, :COSTOREPOSICION, :VENDEDORID, :TIPODOCTOID, :SUBTIPODOCTOID)
                INTO :ERRORCODE;
   
                IF (:ERRORCODE > 0) THEN
                BEGIN
                        SUSPEND;
                        EXIT;
                END
   
               PRECIONUEVO = :PRECIO;
               PRECIOMANUAL = :PRECIO;
               INGRESOPRECIOMANUAL = 'S';

               ESPROMOCION = 'N';
               PROMOCIONID = NULL;
               PROMOCIONDESGLOSE = NULL;
               MONEDEROABONO = 0;


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
         IF (:PORCENTAJEDESCUENTO IS NOT NULL and :LLEGOPRECIOMANUAL = 'N' ) THEN
         BEGIN
                IF(:TIPODESCUENTOPRODID = 1) THEN
                BEGIN
                    SELECT PRECIO1 FROM  PRODUCTO WHERE ID = :PRODUCTOID INTO :TEMPPRECIO;
                END
                ELSE
                BEGIN     
                    SELECT CAST(COALESCE(LISTAPRECIOID, 1) AS CHAR(1))
                    FROM PERSONA
                    WHERE ID = :PERSONAID
                    INTO :LISTAPRECIOCLIENTE;

                    SELECT CASE WHEN :LISTAPRECIOCLIENTE = '1' THEN PRECIO1
                            WHEN :LISTAPRECIOCLIENTE = '2' THEN PRECIO2
                            WHEN :LISTAPRECIOCLIENTE = '3' THEN PRECIO3
                            WHEN :LISTAPRECIOCLIENTE = '4' THEN PRECIO4
                            WHEN :LISTAPRECIOCLIENTE = '5' THEN PRECIO5
                            ELSE PRECIO1 END
                    FROM  PRODUCTO WHERE ID = :PRODUCTOID INTO :TEMPPRECIO;
                END
                       
                DESCUENTO = COALESCE(:TEMPPRECIO,0) * (:PORCENTAJEDESCUENTO) / 100.00;
                TEMPPRECIO = COALESCE(:TEMPPRECIO,0) * (100.00 - :PORCENTAJEDESCUENTO) / 100.00;
                IF(:PRECIONUEVO > :TEMPPRECIO AND :TEMPPRECIO > 0) THEN
                BEGIN   

                    PRECIONUEVO =  :TEMPPRECIO;
                    SELECT ERRORCODE
                    FROM VALIDAR_PRECIO(:PRODUCTOID, :PRECIONUEVO, :PRECIONUEVO, :COSTOREPOSICION, :VENDEDORID, :TIPODOCTOID, :SUBTIPODOCTOID)
                    INTO :ERRORCODE;
                    IF (:ERRORCODE > 0) THEN
                    BEGIN
                        SUSPEND;
                        EXIT;
                    END
                    
                    DESCUENTOPORCENTAJE =   :PORCENTAJEDESCUENTO;
                    DESCUENTOCALCULADO = 'S';  
                    PORCENTAJEDESCUENTOMANUAL = :PORCENTAJEDESCUENTO;

                END
                --PRECIONUEVO = :PRECIONUEVO * (100.00 - :PORCENTAJEDESCUENTO) / 100.00;
         END


         -- Calcular descuento FINAL, ya en relacion al precio de lista O precio 1.
         IF(:TIPODESCUENTOPRODID = 1 and :DESCUENTOCALCULADO = 'N') THEN
         BEGIN
                    SELECT PRECIO1 FROM  PRODUCTO WHERE ID = :PRODUCTOID INTO :TEMPPRECIO;
         END
         ELSE
         BEGIN
                   TEMPPRECIO = :PRECIOLISTA;
         END

         IF (:PRECIONUEVO < :PRECIOLISTA and :DESCUENTOCALCULADO = 'N') THEN
         BEGIN
            DESCUENTO = :PRECIOLISTA - :PRECIONUEVO;

            --Manuel Llamas Evitar division entre 0
            IF (COALESCE(:TEMPPRECIO,0) = 0) THEN
              DESCUENTOPORCENTAJE  =  0 ;
            ELSE
            BEGIN
                DESCUENTOPORCENTAJE = (:DESCUENTO / :TEMPPRECIO) * 100.00;
            END
         END
         ELSE  IF (:DESCUENTOCALCULADO = 'N') THEN
         BEGIN
            -- Si es producto de promocion, o sea gratis.
            -- El descuento es todo el precio.
            IF (:PROMOCION = 'S') THEN
               DESCUENTO = :PRECIOLISTA;
            ELSE
               DESCUENTO = 0.00;
            
             --Manuel Llamas Evitar division entre 0
             IF (COALESCE(:TEMPPRECIO,0) = 0) then
                DESCUENTOPORCENTAJE  =  0 ;
             ELSE
                DESCUENTOPORCENTAJE = (:DESCUENTO / :TEMPPRECIO) * 100.00;
         
            IF (:PROMOCION = 'S') THEN
               PRECIONUEVO = 0.00;
         END




         /*Aqui va lo del tipo de cambio para que se exacto a 2 puntos decimales si es que aplica*/
         SELECT COALESCE(TIPOCAMBIO ,1 ) FROM DOCTO WHERE ID = :DOCTOID INTO :TIPOCAMBIO;
         TIPOCAMBIO = CASE WHEN :TIPOCAMBIO = 0 THEN 1 ELSE COALESCE(:TIPOCAMBIO,1) END;
          IF(:TIPOCAMBIO <> 1) then
          BEGIN
            BUFFERPRECIOMONEDA2 =  ROUND( :PRECIONUEVO / :TIPOCAMBIO , 2);
            PRECIONUEVO = :BUFFERPRECIOMONEDA2 * :TIPOCAMBIO;
          END



         IMPORTE = :CANTIDAD * :PRECIOLISTA;
         SUBTOTAL = :CANTIDAD * :PRECIONUEVO;

         TASAIVA = COALESCE(:TASAIVA, 0);

         IF(:DESGLOSEIEPS = 'N') then
         BEGIN
            TASAIEPS = 0.00;
            TASAIMPUESTO = 0.00;
         END
         ELSE
         BEGIN
            TASAIEPS = COALESCE(:TASAIEPS, 0);
         END

         
         IF (:TASAIEPS > 0.00) THEN
           IEPS =   :SUBTOTAL * (:TASAIEPS / 100.00);
         ELSE
           IEPS = 0.00;

         IF (:TASAIVA > 0.00) THEN
           IVA = (:SUBTOTAL * ( 1 + (:TASAIEPS / 100.00))) * (:TASAIVA / 100.00);
         ELSE
           IVA = 0.00;


          IMPUESTO = IVA + IEPS;

         IF(:TASAIVARETENIDO > 0.00 AND :SUBTOTAL > 0 and :PERSONARETIENEIVA = 'S') THEN
            IVARETENIDO = :SUBTOTAL * (:TASAIVARETENIDO / 100.00);
         ELSE
            IVARETENIDO = 0.00;
            
         IF(:TASAISRRETENIDO > 0.00 AND :SUBTOTAL > 0 and :PERSONARETIENEISR = 'S') THEN
            ISRRETENIDO = :SUBTOTAL * (:TASAISRRETENIDO / 100.00);
         ELSE
            ISRRETENIDO = 0.00;





         TOTAL = :SUBTOTAL + :IMPUESTO;
         
         COSTOIMPORTE = :CANTIDAD * :COSTO;
      END

      SELECT ERRORCODE, CLASIFICACION
      FROM GET_PRECIO_CLASIFICACION(:PRODUCTOID, :PRECIO, :PRECIOLISTA,
            :PRECIOMAXIMOPUBLICO, :COSTO,:PERSONAID)
      INTO :ERRORCODE, :PRECIOCLASIFICACION;


      /* no puede haber cantidades negativas en compras , ventas, devoluciones de compras y devoluciones de ventas*/
      IF(:CANTIDAD < 0 AND :TIPODOCTOID IN (11,12,21,22,25,16,17)) THEN
      BEGIN 
            ERRORCODE = 3005;
            SUSPEND;
            EXIT;
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
         LOCALIDAD,
         PROMOCIONID,
         PROMOCIONDESGLOSE,
         MONEDEROABONO ,
         CLAVEPROD,
         TASAISRRETENIDO,
         ISRRETENIDO,
         TASAIVARETENIDO,
         IVARETENIDO,
         TASAIEPS,
         IEPS,
         TASAIMPUESTO,
         IMPUESTO,
         DESCRIPCION1,
         DESCRIPCION2,
         DESCRIPCION3,
         DESCUENTOPORCENTAJE
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
         :ESPROMOCION,--:PROMOCION,
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
         :LOCALIDAD ,
         :PROMOCIONID,
         :PROMOCIONDESGLOSE  ,
         :MONEDEROABONO,
         :PRODUCTOCLAVE ,
         :TASAISRRETENIDO,
         :ISRRETENIDO,
         :TASAIVARETENIDO,
         :IVARETENIDO,
         :TASAIEPS,
         :IEPS,
         :TASAIMPUESTO,
         :IMPUESTO,
         :DESCRIPCION1,
         :DESCRIPCION2,
         :DESCRIPCION3  ,
         :DESCUENTOPORCENTAJE
      ) RETURNING ID INTO :MOVTOID;
   END
   -- Actualizar el movto ya existente.
   ELSE
   BEGIN


      MOVTOID = :MOVTOACTUALID;

      SELECT CANTIDAD
      FROM MOVTO
      WHERE ID = :MOVTOID
      INTO :CANTIDADACTUAL;

      -- Validar existencia bajo cero.
      IF (((:NEGATIVOS = 'N') AND (:INVENTARIABLE = 'S')) AND (:TIPODOCTOID not in (50,81,53))) THEN
      BEGIN
         -- Solo para documentos con tipo que sea SALIDA del inventario:
         -- Ventas, devoluciones, etc.
         IF (:TIPODOCTOID IN (SELECT ID FROM TIPODOCTO WHERE SENTIDOINVENTARIO = -1)) THEN
         BEGIN
   
            
            SELECT EXISTENCIA, EXISTENCIAFACTURADO, EXISTENCIAREMISIONADO, ERRORCODE
            FROM GET_EXISTENCIA(:PRODUCTOID, :ALMACENID, :LOTE, :FECHAVENCE)
            INTO :EXISTENCIAACTUAL, :EXISTENCIAFACTURADOACTUAL, :EXISTENCIAREMISIONADOACTUAL, :ERRORCODE;

   
            IF (:EXISTENCIAACTUAL < (:CANTIDADACTUAL + :CANTIDAD)) THEN
            BEGIN           
                 --INSERT INTO TRAZA (VALOR) VALUES ( 'movto_insert linea x2');
               ERRORCODE = 1081;
               SUSPEND;
               EXIT;
            END

            
            IF(:TIPODOCTOID IN (21,25,12,31) AND
                 COALESCE(:EXISTENCIAACTUAL,0) - COALESCE(:ENPROCESODESALIDA,0) < ( :CANTIDAD) )THEN
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


       
      /* no puede haber cantidades negativas en compras , ventas, devoluciones de compras y devoluciones de ventas*/
      IF((:CANTIDAD + :CANTIDADACTUAL) < 0 AND :TIPODOCTOID IN (11,12,21,22,25,16,17)) THEN
      BEGIN 
            ERRORCODE = 3005;
            SUSPEND;
            EXIT;
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
         SELECT PRECIO, ESPROMOCION, PROMOCIONID, PROMOCIONDESGLOSE, MONEDEROABONO, ERRORCODE
         FROM GET_PRODUCTO_PRECIO_DOCTO(:PRODUCTOID, :PERSONAID, :CANTIDADACUM,
            :TIPODOCTOID, :SUCURSALID, :SUCURSALTID, :COSTO)
         INTO :PRECIONUEVO, :ESPROMOCION, :PROMOCIONID, :PROMOCIONDESGLOSE, :MONEDEROABONO, :ERRORCODE;

         
         -- Si es compra, para que el importe y descuento sean correctos.
         IF (:TIPODOCTOID in (11,50,51,52,53,41,16,17)) THEN
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
                    FROM GET_DERECHO(:VENDEDORID, 10012)
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
                FROM GET_DERECHO(:VENDEDORID, 10013)
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
            (:PRECIO <> :PRECIONUEVO) AND
            (:LLEGOPRECIOMANUAL = 'S' or (:INGRESOPRECIOMANUAL = 'S' and :PORCENTAJEDESCUENTO IS NULL ) )) THEN
            BEGIN
            


                select costoreposicion from producto where id = :productoid into :COSTOREPOSICION;
                select coalesce(SUBTIPODOCTOID,0) from docto where id = :doctoid into :SUBTIPODOCTOID;

               SELECT ERRORCODE
               FROM VALIDAR_PRECIO(:PRODUCTOID, :PRECIO, :PRECIONUEVO, :COSTOREPOSICION, :VENDEDORID, :TIPODOCTOID, :SUBTIPODOCTOID)
               INTO :ERRORCODE;
   
               IF (:ERRORCODE > 0) THEN
               BEGIN
                  SUSPEND;
                  EXIT;
               END
   
               PRECIONUEVO = :PRECIO;
               PRECIOMANUAL = :PRECIO;  
               INGRESOPRECIOMANUAL = 'S';
               
               ESPROMOCION = 'N';
               PROMOCIONID = NULL;
               PROMOCIONDESGLOSE = NULL;
               MONEDEROABONO = 0;
            END
            ELSE
            BEGIN


              IF (/*:PRECIO IS  NULL*/:LLEGOPRECIOMANUAL = 'N' and (:PORCENTAJEDESCUENTO IS NOT NULL) ) THEN
              BEGIN

                    -- Si se especifica PorcentajeDescuento, aplicar este descuento.
                    IF (:PORCENTAJEDESCUENTO IS NOT NULL) THEN
                    BEGIN


                        IF(:TIPODESCUENTOPRODID = 1) THEN
                        BEGIN

                            SELECT PRECIO1 FROM  PRODUCTO WHERE ID = :PRODUCTOID INTO :TEMPPRECIO;
                        END
                        ELSE
                        BEGIN     

                            SELECT CAST(COALESCE(LISTAPRECIOID, 1) AS CHAR(1))
                            FROM PERSONA
                            WHERE ID = :PERSONAID
                            INTO :LISTAPRECIOCLIENTE;

                            SELECT CASE WHEN :LISTAPRECIOCLIENTE = '1' THEN PRECIO1
                            WHEN :LISTAPRECIOCLIENTE = '2' THEN PRECIO2
                            WHEN :LISTAPRECIOCLIENTE = '3' THEN PRECIO3
                            WHEN :LISTAPRECIOCLIENTE = '4' THEN PRECIO4
                            WHEN :LISTAPRECIOCLIENTE = '5' THEN PRECIO5
                            ELSE PRECIO1 END
                            FROM  PRODUCTO WHERE ID = :PRODUCTOID INTO :TEMPPRECIO;
                        END
                       
                        DESCUENTO = COALESCE(:TEMPPRECIO,0) * (:PORCENTAJEDESCUENTO) / 100.00;
                        TEMPPRECIO = COALESCE(:TEMPPRECIO,0) * (100.00 - :PORCENTAJEDESCUENTO) / 100.00;


                        IF(:PRECIONUEVO > :TEMPPRECIO AND :TEMPPRECIO > 0) THEN
                        BEGIN   

                            PRECIONUEVO =  :TEMPPRECIO;
                            SELECT ERRORCODE
                            FROM VALIDAR_PRECIO(:PRODUCTOID, :PRECIONUEVO, :PRECIONUEVO, :COSTOREPOSICION, :VENDEDORID, :TIPODOCTOID, :SUBTIPODOCTOID)
                            INTO :ERRORCODE;
                            IF (:ERRORCODE > 0) THEN
                            BEGIN
                                SUSPEND;
                                EXIT;
                            END
                              

                            DESCUENTOPORCENTAJE =   :PORCENTAJEDESCUENTO;
                            DESCUENTOCALCULADO = 'S';
                            PORCENTAJEDESCUENTOMANUAL = :PORCENTAJEDESCUENTO;




                        END
                        --PRECIONUEVO = :PRECIONUEVO * (100.00 - :PORCENTAJEDESCUENTO) / 100.00;


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
         IF(:TIPODESCUENTOPRODID = 1 and :DESCUENTOCALCULADO = 'N') THEN
         BEGIN
                    SELECT PRECIO1 FROM  PRODUCTO WHERE ID = :PRODUCTOID INTO :TEMPPRECIO;
         END
         ELSE
         BEGIN
                   TEMPPRECIO = :PRECIOLISTA;
         END

         IF (:PRECIONUEVO < :PRECIOLISTA and :DESCUENTOCALCULADO = 'N') THEN
         BEGIN
            DESCUENTO = :PRECIOLISTA - :PRECIONUEVO;
            --Manuel Llamas Evitar division entre 0
            IF (coalesce(:TEMPPRECIO,0) = 0) THEN
              DESCUENTOPORCENTAJE  =  0;
            ELSE
              DESCUENTOPORCENTAJE = (:DESCUENTO / :TEMPPRECIO) * 100.00;
         END
         ELSE  IF (:DESCUENTOCALCULADO = 'N') THEN
         BEGIN
            IF (:PROMOCION = 'S') THEN
              DESCUENTO = :PRECIOLISTA;
            ELSE
              DESCUENTO = 0.00;
            
            --Manuel Llamas Evitar division entre 0
            IF (coalesce(:TEMPPRECIO,0) = 0) THEN
               DESCUENTOPORCENTAJE  =  0 ;
            ELSE
               DESCUENTOPORCENTAJE = (:DESCUENTO / :TEMPPRECIO) * 100.00;

            IF (:PROMOCION = 'S') THEN
              PRECIONUEVO = 0.00;
         
          --DESCUENTO = 0.00;
          --DESCUENTOPORCENTAJE = 0.00;
         END


         
         /*Aqui va lo del tipo de cambio para que se exacto a 2 puntos decimales si es que aplica*/
         SELECT COALESCE(TIPOCAMBIO ,1 ) FROM DOCTO WHERE ID = :DOCTOID INTO :TIPOCAMBIO;
         TIPOCAMBIO = CASE WHEN :TIPOCAMBIO = 0 THEN 1 ELSE COALESCE(:TIPOCAMBIO,1) END;
          IF(:TIPOCAMBIO <> 1) then
          BEGIN
            BUFFERPRECIOMONEDA2 =  ROUND( :PRECIONUEVO / :TIPOCAMBIO , 2);
            PRECIONUEVO = :BUFFERPRECIOMONEDA2 * :TIPOCAMBIO;
          END

       
         IMPORTE = :CANTIDADACUM * :PRECIOLISTA;
         SUBTOTAL = :CANTIDADACUM * :PRECIONUEVO;

         TASAIVA = COALESCE(:TASAIVA, 0);

         
         IF(:DESGLOSEIEPS = 'N') then
         BEGIN
            TASAIEPS = 0.00;
            TASAIMPUESTO = 0.00;
         END
         ELSE
         BEGIN
            TASAIEPS = COALESCE(:TASAIEPS, 0);
         END

         
         IF (:TASAIEPS > 0.00) THEN
           IEPS =   :SUBTOTAL * (:TASAIEPS / 100.00);
         ELSE
           IEPS = 0.00;

         IF (:TASAIVA > 0.00) THEN
           IVA = (:SUBTOTAL * ( 1 + (:TASAIEPS / 100.00))) * (:TASAIVA / 100.00);
         ELSE
           IVA = 0.00;

           IMPUESTO = IVA + IEPS;

         IF(:TASAIVARETENIDO > 0.00 AND :SUBTOTAL > 0 and :PERSONARETIENEIVA = 'S') THEN
            IVARETENIDO = :SUBTOTAL * (:TASAIVARETENIDO / 100.00);
         ELSE
            IVARETENIDO = 0.00;
            
         IF(:TASAISRRETENIDO > 0.00 AND :SUBTOTAL > 0 and :PERSONARETIENEISR = 'S') THEN
            ISRRETENIDO = :SUBTOTAL * (:TASAISRRETENIDO / 100.00);
         ELSE
            ISRRETENIDO = 0.00;


         TOTAL = :SUBTOTAL + :IMPUESTO;
         
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
            COSTOIMPORTE = :COSTOIMPORTE  ,
            PROMOCION  = :ESPROMOCION,
            PROMOCIONID = :PROMOCIONID,
            PROMOCIONDESGLOSE = :PROMOCIONDESGLOSE ,
            MONEDEROABONO = :MONEDEROABONO,
            TASAISRRETENIDO = :TASAISRRETENIDO,
            ISRRETENIDO = :ISRRETENIDO,
            TASAIVARETENIDO = :TASAIVARETENIDO,
            IVARETENIDO = :IVARETENIDO ,
            TASAIEPS = :TASAIEPS,
            IEPS = :IEPS,
            TASAIMPUESTO = :TASAIMPUESTO,
            IMPUESTO = :IMPUESTO,
            PORCENTAJEDESCUENTOMANUAL = :PORCENTAJEDESCUENTOMANUAL ,
            PRECIOLISTA = :PRECIOLISTA
         WHERE ID = :MOVTOID;
      END
   END

   IF ((:DOCTOID IS NULL) OR
      (:DOCTOID = 0) OR
      (:MOVTOID IS NULL) OR
      (:MOVTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1003;
      SUSPEND;
      EXIT;
   END

     IF(:TIPODOCTOID IN (81,31)) THEN
     BEGIN
            SELECT ERRORCODE FROM update_preciorecepciontraslado(:productoid, :tipodoctoid, :sucursalid, :sucursaltid, :movtoid)
            into :ERRORCODE;
     END


   SUSPEND;
END