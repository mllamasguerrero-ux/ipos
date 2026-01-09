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
    DESCRIPCION3 D_STDTEXT_64,
    PRECIOYAVALIDADO D_BOOLCN_NULL,
    LOTEIMPORTADO D_FK,
    CARGOTARJPRECIOMANUAL char(1),
    AGRUPAPORPARAMETRO D_BOOLCN)
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
declare variable ESKIT D_BOOLCN;
declare variable HAYEXISTENCIAPARAARMAR D_BOOLCN;
declare variable MANEJAKITS D_BOOLCN;
declare variable ENPROCESOPARTES D_CANTIDAD;
declare variable NUEVOSENPROCESOPARTES D_CANTIDAD;
declare variable CANTIDADPOSIBLEADEVOLVER D_CANTIDAD;
declare variable PORCENTAJEDESCUENTOORIGINAL D_PORCENTAJE;
declare variable PAGOCONTARJETA D_BOOLCN_NULL;
declare variable PAGOACREDITO D_BOOLCN_NULL;
declare variable TIPOMAYOREOID D_FK;
declare variable APLICARMAYOREOPORLINEA D_BOOLCN;
declare variable NUEVOTIPOMAYOREOID D_FK;
declare variable COSTOENDOLAR type of D_PRECIO;
declare variable PERSONAEXENTOIVA D_BOOLCN;
declare variable PAGOTARJMENORPRECIOLISTAALL D_BOOLCN;
declare variable PRECIO1 D_PRECIO;
declare variable PRECIO6 D_PRECIO;
declare variable AGRUPACIONVENTAID D_FK;
declare variable PRECIOMANUALBUFFER D_PRECIO;
declare variable ENPROCESOPARTESSALIDA D_CANTIDAD;
BEGIN
    ERRORCODE = 0;
   PORCENTAJEDESCUENTOORIGINAL = coalesce(:PORCENTAJEDESCUENTO,0);
   PORCENTAJEDESCUENTOMANUAL = coalesce(:PORCENTAJEDESCUENTO,0);
   SELECT COALESCE(TIPODESCUENTOPRODID,1), COALESCE(MANEJAKITS,'N'), COALESCE(APLICARMAYOREOPORLINEA,'N') FROM PARAMETRO
   INTO :TIPODESCUENTOPRODID, :MANEJAKITS, :APLICARMAYOREOPORLINEA;

   HAYEXISTENCIAPARAARMAR = 'N';
   ENPROCESOPARTES = 0;
   NUEVOSENPROCESOPARTES = 0;
   ESKIT = 'N';
   TIPOCAMBIO = 1;
   DESCUENTOCALCULADO = 'N';

   /*isr RETENIDO*/
   select RETENCIONISR, RETENCIONIVA from parametro into :TASAISRRETENIDO, :TASAIVARETENIDO;
   SELECT COALESCE(retieneisr,'N'),COALESCE(retieneiva,'N'), COALESCE(EXENTOIVA,'N') from PERSONA where id = :personaid into :PERSONARETIENEISR, :PERSONARETIENEIVA, :PERSONAEXENTOIVA;

   SELECT DESGLOSEIEPS,PAGOTARJMENORPRECIOLISTAALL FROM PARAMETRO INTO :DESGLOSEIEPS, :PAGOTARJMENORPRECIOLISTAALL;
   DESGLOSEIEPS = COALESCE(:DESGLOSEIEPS,'N');

  /*RESETEAR VARIABLES DE PROMOCION*/
  ESPROMOCION = 'N';
  PROMOCIONID = NULL;
  PROMOCIONDESGLOSE = NULL;
  INGRESOPRECIOMANUAL = 'N';
  MONEDEROABONO = 0;
  PRODUCTOCLAVE = null;
  LLEGOPRECIOMANUAL = CASE WHEN (:PRECIO IS NULL) THEN 'N' ELSE 'S' END;
  PRECIOMANUALBUFFER = :PRECIO;

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
   IF (:TIPODOCTOID in (21,25,321,821)) THEN
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
      IF(:TIPODOCTOID IN (12,15,1012,1015) AND :DOCTOREFID IS NOT NULL AND :DOCTOREFID <> 0) THEN
      BEGIN
           SELECT ORIGENFISCALID FROM DOCTO WHERE ID = :DOCTOREFID INTO :ORIGENFISCALID;
      END

      SELECT DOCTOID, ERRORCODE
      FROM DOCTO_INSERT (
         :CREADOPOR_USERID,:ALMACENID,:SUCURSALID,:TIPODOCTOID,:ESTATUSDOCTOID,:ESTATUSDOCTOPAGOID,:PERSONAID,
         :VENDEDORID,:CAJAID,:REFERENCIA, :REFERENCIAS,:SUCURSALTID,:ALMACENTID,:FECHA,:VENCE,:DOCTOREFID,
         :MERCANCIAENTREGADA ,:ORIGENFISCALID
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

    IF (:TIPODOCTOID in (21) AND :APLICARMAYOREOPORLINEA = 'S') then
    BEGIN
       SELECT TIPOMAYOREOID, ERRORCODE FROM GET_TIPOMAYOREO_DOCTO(:DOCTOID, :PRODUCTOID)
       INTO :TIPOMAYOREOID, :ERRORCODE;

       IF (:ERRORCODE <> 0) THEN
       BEGIN  
            SUSPEND;
            EXIT;
       END
     END
     ELSE
     BEGIN
        TIPOMAYOREOID = 1;
     END
   -- Tomar precio del producto.
   -- Si NO se recibe el costo, tomar costo promedio del producto
   IF ((:COSTO IS NULL) OR (:COSTO = 0))  THEN
   BEGIN
      SELECT PRECIO1, TASAIVA, COSTOPROMEDIO, COSTOREPOSICION, PRECIOMAXIMOPUBLICO, NEGATIVOS, INVENTARIABLE , UNIDAD, COMISION, SUM(COALESCE(PRODUCTOALMACEN.ENPROCESODESALIDA,0)) ENPROCESODESALIDA , TASAIEPS, TASAIMPUESTO, COSTOENDOLAR , ENPROCESOPARTESSALIDA
      FROM PRODUCTO
      left join PRODUCTOALMACEN ON PRODUCTO.ID = PRODUCTOALMACEN.PRODUCTOID AND PRODUCTOALMACEN.ALMACENID = :ALMACENID
      WHERE PRODUCTO.ID = :PRODUCTOID
      group by PRECIO1, TASAIVA, COSTOPROMEDIO, COSTOREPOSICION, PRECIOMAXIMOPUBLICO, NEGATIVOS, INVENTARIABLE , UNIDAD, COMISION,  TASAIEPS, TASAIMPUESTO, COSTOENDOLAR , ENPROCESOPARTESSALIDA
      INTO :PRECIOLISTA, :TASAIVA, :COSTOPROMEDIO, :COSTOREPOSICION, :PRECIOMAXIMOPUBLICO, :NEGATIVOS, :INVENTARIABLE, :UNIDADPRODUCTO, :COMISIONXUNIDAD, :ENPROCESODESALIDA, :TASAIEPS, :TASAIMPUESTO,:COSTOENDOLAR, :ENPROCESOPARTESSALIDA;

      COSTO = CASE WHEN :TIPODOCTOID not in ( 111, 121) THEN COALESCE(:COSTOPROMEDIO,0) ELSE COALESCE(:COSTOREPOSICION,0) END;
   END
    -- para que puedan ingresar compras con costo 0
   if(:COSTO = -0.01) THEN
   BEGIN
        COSTO = 0;
   end
   -- Si SI se recibe el costo, entonces tomar el costo que se recibe.
   ELSE
   BEGIN
      SELECT PRECIO1, coalesce(TASAIVA,0), COSTOREPOSICION, PRECIOMAXIMOPUBLICO, COSTOPROMEDIO, NEGATIVOS, INVENTARIABLE , UNIDAD, COMISION , SUM(COALESCE(PRODUCTOALMACEN.ENPROCESODESALIDA,0)) ENPROCESODESALIDA , TASAIEPS, TASAIMPUESTO , COSTOENDOLAR , ENPROCESOPARTESSALIDA
      FROM PRODUCTO   
      left join PRODUCTOALMACEN ON PRODUCTO.ID = PRODUCTOALMACEN.PRODUCTOID  AND PRODUCTOALMACEN.ALMACENID = :ALMACENID
      WHERE PRODUCTO.ID = :PRODUCTOID
      group by PRECIO1, TASAIVA, COSTOREPOSICION, PRECIOMAXIMOPUBLICO, COSTOPROMEDIO, NEGATIVOS, INVENTARIABLE , UNIDAD, COMISION  , TASAIEPS, TASAIMPUESTO ,COSTOENDOLAR , ENPROCESOPARTESSALIDA
      INTO :PRECIOLISTA, :TASAIVA, :COSTOREPOSICION, :PRECIOMAXIMOPUBLICO, :COSTOPROMEDIO, :NEGATIVOS, :INVENTARIABLE, :UNIDADPRODUCTO, :COMISIONXUNIDAD, :ENPROCESODESALIDA , :TASAIEPS, :TASAIMPUESTO, :COSTOENDOLAR, :ENPROCESOPARTESSALIDA;
   END

   IF(:UNIDADPRODUCTO <> 'KG' AND ABS(CANTIDAD - FLOOR(CANTIDAD)) >= 0.001 ) then
   BEGIN
         ERRORCODE = 1083;
         SUSPEND;
         EXIT;
   END
   -- Seleccionar el precio lista para calcular el descuento, Solo para Ventas.
   IF (:TIPODOCTOID  in (21,25, 321,821)) THEN
   BEGIN
         SELECT LISTAPRECIOID, SUPERLISTAPRECIOID FROM PERSONA WHERE ID = :PERSONAID INTO :LISTAPRECIOID, :SUPERLISTAPRECIOID;
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
                 ELSE PRECIO1
                 END
                ELSE
                 CASE WHEN COALESCE(:SUPERLISTAPRECIOID, 1) = 1 THEN SPRECIO1
                 WHEN COALESCE(:SUPERLISTAPRECIOID, 1) = 2 THEN SPRECIO2
                 WHEN COALESCE(:SUPERLISTAPRECIOID, 1) = 3 THEN SPRECIO3
                 WHEN COALESCE(:SUPERLISTAPRECIOID, 1) = 4 THEN SPRECIO4
                 WHEN COALESCE(:SUPERLISTAPRECIOID, 1) = 5 THEN SPRECIO5
                 ELSE PRECIO1
                 END
                END
            END
          FROM PRODUCTO
          WHERE PRODUCTO.ID = :PRODUCTOID
          INTO :PRECIOLISTA;

          --PAGO CON TARJETA
        select coalesce(SUBTIPODOCTOID,0), PAGOCONTARJETA, PAGOACREDITO from docto where id = :doctoid into :SUBTIPODOCTOID, :PAGOCONTARJETA/*, :TIPOMAYOREOID*/, :PAGOACREDITO;
        IF ((:PRECIO IS NOT NULL) AND :LLEGOPRECIOMANUAL = 'S' AND COALESCE(:CARGOTARJPRECIOMANUAL,'N') = 'S') THEN
         BEGIN
            IF(COALESCE(:PAGOCONTARJETA,'N') = 'S') THEN
                BEGIN

                    SELECT PRECIOEXPORTACIONLINEA, ERRORCODE FROM GET_PRECIO_CONCOMISIONTARJETA(:PRODUCTOID ,:PERSONAID, :CANTIDAD ,:PRECIO1 ,:PRECIO,:PAGOCONTARJETA)
                    INTO :PRECIO , :ERRORCODE;

                    --si el precio ya supera el precio de menudeo volver a poner el precio de menudeo
                    IF(:PRECIO > :PRECIOLISTA AND COALESCE(:PAGOTARJMENORPRECIOLISTAALL,'N') = 'S' ) THEN
                    BEGIN
                        PRECIO = :PRECIOLISTA;
                    END
                END
         END



   END
   -- Buscar el MovtoId  Si no recibimos lotepor (Docto, Producto) .. caso normal Si ya recibimos el movtoid entonces no intentar buscarlo
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

           SELECT MOVTOACTUALID ,MOVTOREFID , PRECIO_RET , COSTO_RET , LOTE_RET , FECHAVENCE_RET ,LOTEIMPORTADO_RET FROM MOVTO_INSERT_AGRUPADO(
            :DOCTOID , :TIPODOCTOID , :COSTO , :LOTE , :LOTEIMPORTADO , :PRODUCTOID  , :FECHAVENCE , :PRECIO  , :PORCENTAJEDESCUENTO  , :P_MOVTOREFID  , :ANAQUELID  , :LOCALIDAD)
            INTO :MOVTOACTUALID , :MOVTOREFID , :PRECIO , :COSTO ,:LOTE ,:FECHAVENCE ,:LOTEIMPORTADO ;

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

   /* Evitar juntar movtos cuando el parametro de AGRUPACIONVENTAID sea 2 o 3 y  AGRUPAPORPARAMETRO sea S*/
   SELECT FIRST 1 COALESCE(AGRUPACIONVENTAID,1) FROM PARAMETRO  INTO :AGRUPACIONVENTAID;
   IF( COALESCE(:CANTIDAD,0) > 0 AND  COALESCE(:AGRUPAPORPARAMETRO,'N') = 'S' AND :AGRUPACIONVENTAID IS NOT NULL AND COALESCE(:AGRUPACIONVENTAID,1) IN (2,3) ) THEN
   BEGIN
                  MOVTOACTUALID = NULL;
   END


    IF(:MOVTOACTUALID IS NOT NULL) THEN
    BEGIN
       select  INGRESOPRECIOMANUAL from movto  
       WHERE ID = :MOVTOACTUALID
       into :INGRESOPRECIOMANUAL;
    END

   -- Si no hay movto registrado, Insertar nuevo Movto.
   IF ((:MOVTOACTUALID IS NULL) OR (:MOVTOACTUALID = 0)) THEN
   BEGIN
    IF(coalesce(:CANTIDAD,0) = 0 AND :TIPODOCTOID IN (21,25)) THEN
    BEGIN

        MOVTOID = 0;
        ERRORCODE = 0;
        SUSPEND;
        EXIT;
    END

     -- producto clave
    select clave, ESKIT from producto where id = :productoid into :PRODUCTOCLAVE, :ESKIT;

      -- Solo para movimientos que tengan afectacion de inventarios. Por ahora solo excluir el Tipo 50 (Captura de inventario = Borrador)
      IF (:TIPODOCTOID not in (50,81,53)) then   -- !!! temporal falta analisis de Gerardo
      BEGIN
         -- Validar existencia bajo cero.
         IF ((:NEGATIVOS = 'N') AND (:INVENTARIABLE = 'S') and (:TIPODOCTOID not in (321,821,901,902)) AND COALESCE(:SUBTIPODOCTOID,0) <> 28 )  THEN
         BEGIN
            -- Solo para documentos con tipo que sea SALIDA del inventario: Ventas, devoluciones, etc.
            IF (:TIPODOCTOID IN (SELECT ID FROM TIPODOCTO WHERE SENTIDOINVENTARIO = -1)
                  AND COALESCE(:SUBTIPODOCTOID,0) NOT IN (22,27)
                  AND :TIPODOCTOID <> 52 --en los inventarios tipo salida hay que permitir por algunas situaciones
                  ) THEN
            BEGIN
               SELECT EXISTENCIA, EXISTENCIAFACTURADO, EXISTENCIAREMISIONADO, ERRORCODE
               FROM GET_EXISTENCIA(:PRODUCTOID, :ALMACENID, :LOTE, :FECHAVENCE)
               INTO :EXISTENCIAACTUAL, :EXISTENCIAFACTURADOACTUAL, :EXISTENCIAREMISIONADOACTUAL, :ERRORCODE;

               IF(:ERRORCODE <> 0) THEN
               BEGIN  
                  SUSPEND;
                  EXIT;
               END

               IF(:MANEJAKITS = 'S' AND :ESKIT = 'S' /*AND :TIPODOCTOID IN (21,31, 12, 13,24)*/ AND
                    (COALESCE(:EXISTENCIAACTUAL,0) - COALESCE(:ENPROCESODESALIDA,0) - COALESCE(:ENPROCESOPARTESSALIDA,0)) < :CANTIDAD) THEN
               BEGIN
                    SELECT HAYEXISTENCIA, ERRORCODE
                    FROM GET_EXISTENCIAPARAKIT(:PRODUCTOID, :ALMACENID, :CANTIDAD - (COALESCE(:EXISTENCIAACTUAL,0) - COALESCE(:ENPROCESODESALIDA,0) - COALESCE(:ENPROCESOPARTESSALIDA,0)))
                    INTO  :HAYEXISTENCIAPARAARMAR , :ERRORCODE;

                    NUEVOSENPROCESOPARTES =  :CANTIDAD - (COALESCE(:EXISTENCIAACTUAL,0) - COALESCE(:ENPROCESODESALIDA,0) - COALESCE(:ENPROCESOPARTESSALIDA,0));

               END

               IF (:EXISTENCIAACTUAL < :CANTIDAD AND COALESCE(:HAYEXISTENCIAPARAARMAR,'N') <> 'S' ) THEN
               BEGIN
                  ERRORCODE = 1081;
                  SUSPEND;
                  EXIT;
               END

               IF((:TIPODOCTOID IN (/*21,*/25,12,31, 121,1012) or (:TIPODOCTOID = 21 AND COALESCE(:SUBTIPODOCTOID ,0)<> 8 ) ) AND
                 COALESCE(:EXISTENCIAACTUAL,0) - COALESCE(:ENPROCESODESALIDA,0) < :CANTIDAD
                  AND COALESCE(:HAYEXISTENCIAPARAARMAR,'N') <> 'S'  )THEN
               BEGIN
                    ERRORCODE = 1081;
                    SUSPEND;
                    EXIT;
               END
            END
            IF(:TIPODOCTOID IN (501) AND COALESCE(:SUBTIPODOCTOID,0) <> 10) THEN
            begin

                 IF(:CANTIDAD > 0) THEN
                 BEGIN
                    SELECT HAYEXISTENCIA, ERRORCODE
                    FROM GET_EXISTENCIAPARAKIT(:PRODUCTOID, :ALMACENTID, :CANTIDAD )
                    INTO  :HAYEXISTENCIAPARAARMAR , :ERRORCODE;

                    IF (COALESCE(:HAYEXISTENCIAPARAARMAR,'N') <> 'S' ) THEN
                    BEGIN
                        ERRORCODE = 1081;
                        SUSPEND;
                        EXIT;
                    END
                 END
                 NUEVOSENPROCESOPARTES =  :CANTIDAD;
            end
            IF(:TIPODOCTOID IN (1001) ) THEN
            begin
                 IF(:CANTIDAD > 0) THEN
                 BEGIN
                    SELECT HAYEXISTENCIA, ERRORCODE
                    FROM GET_EXISTENCIAPARAPRODPROMO(:PRODUCTOID, :ALMACENTID, :CANTIDAD )
                    INTO  :HAYEXISTENCIAPARAARMAR , :ERRORCODE;
                    IF (COALESCE(:HAYEXISTENCIAPARAARMAR,'N') <> 'S' ) THEN
                    BEGIN
                        ERRORCODE = 1081;
                        SUSPEND;
                        EXIT;
                    END
                 END
            end
         END

         -- Obtener nuevo precio fn(Prod, TipoDocto, Sucursal, ...)
         -- Si es compra obtenemos el costo.
         SELECT PRECIO, ESPROMOCION, PROMOCIONID, PROMOCIONDESGLOSE, MONEDEROABONO, ERRORCODE
         FROM GET_PRODUCTO_PRECIO_DOCTO(:PRODUCTOID, :PERSONAID, :CANTIDAD,
                 :TIPODOCTOID, :SUCURSALID, :SUCURSALTID, :COSTO, :PAGOCONTARJETA, :TIPOMAYOREOID, :PAGOACREDITO)
         INTO :PRECIONUEVO, :ESPROMOCION, :PROMOCIONID, :PROMOCIONDESGLOSE, :MONEDEROABONO ,:ERRORCODE;

         -- Si es compra, para que el importe y descuento sean correctos.
         IF (:TIPODOCTOID in (11,50,51,52,53,54,55,41,16,17, 501,502,503,504, 32, 82,1011)) THEN
         BEGIN
            PRECIOLISTA = :COSTO;
            PRECIONUEVO = :COSTO * (1 - (coalesce(:porcentajedescuento, 0)/100));
         END

         --otras entradas
          IF (:TIPODOCTOID in (111)) THEN
         BEGIN
            PRECIOLISTA = :COSTO;
            PRECIONUEVO = :COSTO * (1 - (coalesce(:porcentajedescuento, 0)/100));
         END



         -- si es devolucion de venta hay que obtener el precio de la devolucion
         IF (:TIPODOCTOID = 22 AND COALESCE(:SUBTIPODOCTOID,0) <> 13/* y no es una nc x rebaja*/) THEN
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
               ELSE
               BEGIN

                   SELECT COALESCE(MOVTO.cantidad,0) - COALESCE(MOVTO.cantidaddevuelta,0)
                   FROM MOVTO   WHERE ID = :MOVTOREFID
                   INTO :CANTIDADPOSIBLEADEVOLVER;

                   IF(COALESCE(:CANTIDADPOSIBLEADEVOLVER,0) < COALESCE(:CANTIDAD,0)) THEN
                   BEGIN
                              
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
           END
           ELSE
           BEGIN
                SELECT PRODUCTO.costoreposicion FROM PRODUCTO WHERE ID = :PRODUCTOID INTO :PRECIONUEVO;
           END
           PRECIOLISTA = :PRECIONUEVO;
         END

         IF (:TIPODOCTOID = 22 AND COALESCE(:SUBTIPODOCTOID,0) = 13/* y  es una nc x rebaja*/) THEN
         BEGIN
               PRECIONUEVO = :PRECIO;
               PRECIOLISTA = :PRECIO;
               PRECIOMANUAL = :PRECIO;
               IF(COALESCE(:MOVTOREFID,0) <> 0) THEN
               BEGIN
                   SELECT TASAIVA, TASAIEPS, TASAIMPUESTO FROM MOVTO WHERE ID = :MOVTOREFID INTO :TASAIVA, :TASAIEPS, :TASAIMPUESTO  ;
               END
         end
           
         IF (:TIPODOCTOID in (24, 26, 331, 42, 901, 902 )) THEN
         BEGIN
               PRECIONUEVO = :PRECIO;
               PRECIOLISTA = :PRECIO;
         END

         IF (:TIPODOCTOID in (12,1012)) THEN
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

         IF (:TIPODOCTOID in ( 15, 23, 323, 823)) THEN
         BEGIN
         
               PRECIONUEVO = :PRECIO;
               PRECIOLISTA = :PRECIO;
         END

         IF (:TIPODOCTOID IN (121)) THEN
         BEGIN
         
            PRECIOLISTA = case when :LLEGOPRECIOMANUAL = 'S' THEN :PRECIO ELSE  :COSTO END;
            PRECIONUEVO = (case when :LLEGOPRECIOMANUAL = 'S' THEN :PRECIO ELSE  :COSTO END) * (1 - (coalesce(:porcentajedescuento, 0)/100));
         END


         -- Si es venta, y el precio < preciostd (2012-01-31: GAGL)
         -- Validar que el usuario tenga derecho a cambiar los precios.
         -- Para tipo 21=Venta
         IF ( :TIPODOCTOID  in (21,25,22, 321,821) AND COALESCE(:SUBTIPODOCTOID,0) NOT IN (13) /* y no es una nc x rebaja*/) THEN
         BEGIN
            IF ( (:PRECIO IS NOT NULL) AND
            (:PRECIO <> :PRECIONUEVO) AND
             :LLEGOPRECIOMANUAL = 'S') THEN
            BEGIN
                select costoreposicion from producto where id = :productoid into :COSTOREPOSICION;
                select coalesce(SUBTIPODOCTOID,0) from docto where id = :doctoid into :SUBTIPODOCTOID;


                IF( COALESCE(:PRECIOYAVALIDADO,'N') = 'N' AND  COALESCE(:SUBTIPODOCTOID,0) <> 15 AND COALESCE(:SUBTIPODOCTOID,0)  NOT IN (22,27)) THEN  /*Si no es una venta movil*/
                BEGIN

                 SELECT ERRORCODE
                 FROM VALIDAR_PRECIO(:PRODUCTOID, :PRECIO, :PRECIONUEVO, :COSTOREPOSICION, :VENDEDORID, :TIPODOCTOID, :SUBTIPODOCTOID)
                 INTO :ERRORCODE;
   
                 IF (:ERRORCODE > 0) THEN
                 BEGIN
                        SUSPEND;
                        EXIT;
                 END
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
         --   > El precio es el estandar > El precio es menor al estandar pero el usuario tiene derecho.
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
            -- Si es producto de promocion, o sea gratis.  El descuento es todo el precio.
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

         IMPORTE = CAST(:CANTIDAD * :PRECIOLISTA AS D_IMPORTE);
         SUBTOTAL = CAST(:CANTIDAD * :PRECIONUEVO AS D_IMPORTE);

         TASAIVA = COALESCE(:TASAIVA, 0);

         IF(COALESCE(:PERSONAEXENTOIVA,'N') = 'S') THEN
         BEGIN
            TASAIVA = 0.0;
         END

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
           IEPS =   CAST(:SUBTOTAL * (:TASAIEPS / 100.00) AS D_IMPORTE);
         ELSE
           IEPS = 0.00;

         IF (:TASAIVA > 0.00) THEN
           IVA = CAST((:SUBTOTAL * ( 1 + (:TASAIEPS / 100.00))) * (:TASAIVA / 100.00) AS D_IMPORTE);
         ELSE
           IVA = 0.00;

          IMPUESTO = CAST(IVA + IEPS AS D_IMPORTE);

         IF(:TASAIVARETENIDO > 0.00 AND :SUBTOTAL > 0 and :PERSONARETIENEIVA = 'S') THEN
            IVARETENIDO = CAST(:SUBTOTAL * (:TASAIVARETENIDO / 100.00) AS D_IMPORTE);
         ELSE
            IVARETENIDO = 0.00;
            
         IF(:TASAISRRETENIDO > 0.00 AND :SUBTOTAL > 0 and :PERSONARETIENEISR = 'S') THEN
            ISRRETENIDO = CAST(:SUBTOTAL * (:TASAISRRETENIDO / 100.00) AS D_IMPORTE);
         ELSE
            ISRRETENIDO = 0.00;

         TOTAL = CAST(:SUBTOTAL + :IMPUESTO AS D_IMPORTE);
         COSTOIMPORTE = :CANTIDAD * :COSTO;
      END

         IF (:TIPODOCTOID in (50)) THEN
         BEGIN
               SELECT PRECIODIFINVENTARIO FROM GET_PRECIO_AJUSTEINVENTARIO(:PRODUCTOID) INTO :PRECIONUEVO;
               PRECIOLISTA = :PRECIONUEVO;
         END

      SELECT ERRORCODE, CLASIFICACION
      FROM GET_PRECIO_CLASIFICACION(:PRODUCTOID, :PRECIO, :PRECIOLISTA,
            :PRECIOMAXIMOPUBLICO, :COSTO,:PERSONAID)
      INTO :ERRORCODE, :PRECIOCLASIFICACION;

      /* no puede haber cantidades negativas en compras , ventas, devoluciones de compras y devoluciones de ventas*/
      IF(:CANTIDAD < 0 AND :TIPODOCTOID IN (11,12,21,22,25,16,17, 321, 821, 111, 121,1011,1012)) THEN
      BEGIN 
            ERRORCODE = 3005;
            SUSPEND;
            EXIT;
      END

      --respeta el descuento puesto en compras
      IF(:TIPODOCTOID IN (11,12,13,14,15,16,17,18, 111, 113,1011,1012,1013,1015)) THEN
      BEGIN
            DESCUENTOPORCENTAJE = :PORCENTAJEDESCUENTOORIGINAL;
      END

       INSERT INTO MOVTO (
       DOCTOID, ESTATUSMOVTOID, PARTIDA, PRODUCTOID, LOTE, FECHAVENCE, CANTIDAD, CANTIDADSURTIDA, CANTIDADFALTANTE, CANTIDADDEVUELTA, CANTIDADSALDO, PRECIO, PRECIOLISTA, IMPORTE, SUBTOTAL, DESCUENTO, IVA, TOTAL, COSTO, COSTOIMPORTE, TIPODIFERENCIAINVENTARIOID, PROMOCION, PRECIOMANUAL, PORCENTAJEDESCUENTOMANUAL, COSTOREPOSICION, COSTOPROMEDIO, PRECIOMAXIMOPUBLICO, PRECIOCLASIFICACION, TASAIVA, INGRESOPRECIOMANUAL, MOVTOREFID, ESAPARTADO, COMISIONXUNIDAD, TIPODOCTOID, ANAQUELID, LOCALIDAD, PROMOCIONID, PROMOCIONDESGLOSE, MONEDEROABONO , CLAVEPROD, TASAISRRETENIDO, ISRRETENIDO, TASAIVARETENIDO, IVARETENIDO, TASAIEPS, IEPS, TASAIMPUESTO, IMPUESTO, DESCRIPCION1, DESCRIPCION2, DESCRIPCION3, DESCUENTOPORCENTAJE , ENPROCESOPARTES , ESKIT , LOTEIMPORTADO, COSTOENDOLAR , IMPORTEENDOLAR, LISTAPRECIOID )
      VALUES (
      :DOCTOID, :ESTATUSMOVTOID, :PARTIDA, :PRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDAD, :CANTIDADSURTIDA, :CANTIDADFALTANTE, :CANTIDADDEVUELTA, :CANTIDADSALDO, :PRECIONUEVO, :PRECIOLISTA, :IMPORTE, :SUBTOTAL, :DESCUENTO, :IVA, :TOTAL, :COSTO, :COSTOIMPORTE, :TIPODIFERENCIAINVENTARIOID, :ESPROMOCION, :PRECIOMANUAL, :PORCENTAJEDESCUENTOMANUAL, :COSTOREPOSICION, :COSTOPROMEDIO, :PRECIOMAXIMOPUBLICO, :PRECIOCLASIFICACION , coalesce(:TASAIVA,0), :INGRESOPRECIOMANUAL, :MOVTOREFID, :ESAPARTADO, :COMISIONXUNIDAD, :TIPODOCTOID, :ANAQUELID, :LOCALIDAD , :PROMOCIONID, :PROMOCIONDESGLOSE  , :MONEDEROABONO, :PRODUCTOCLAVE , :TASAISRRETENIDO, :ISRRETENIDO, :TASAIVARETENIDO, :IVARETENIDO, :TASAIEPS, :IEPS, :TASAIMPUESTO, :IMPUESTO, :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3  , :DESCUENTOPORCENTAJE , :NUEVOSENPROCESOPARTES , :ESKIT, :LOTEIMPORTADO , :COSTOENDOLAR , (:COSTOENDOLAR * :CANTIDAD), :LISTAPRECIOID
      ) RETURNING ID INTO :MOVTOID;

      SELECT ERRORCODE FROM KIT_AJUSTARIMPUESTOS(:DOCTOID, :movtoid, :ESKIT) INTO :ERRORCODE;

   END
   -- Actualizar el movto ya existente.
   ELSE
   BEGIN

      MOVTOID = :MOVTOACTUALID;

      SELECT CANTIDAD, ENPROCESOPARTES
      FROM MOVTO
      WHERE ID = :MOVTOID
      INTO :CANTIDADACTUAL, :ENPROCESOPARTES;

      select clave, ESKIT from producto where id = :productoid into :PRODUCTOCLAVE, :ESKIT;

      -- Validar existencia bajo cero.
      IF (((:NEGATIVOS = 'N') AND (:INVENTARIABLE = 'S')) AND (:TIPODOCTOID not in (50,81,53, 321, 821, 901,902))  AND COALESCE(:SUBTIPODOCTOID,0) <> 28 ) THEN
      BEGIN
         -- Solo para documentos con tipo que sea SALIDA del inventario:
         -- Ventas, devoluciones, etc.
         IF (:TIPODOCTOID IN (SELECT ID FROM TIPODOCTO WHERE SENTIDOINVENTARIO = -1)
                  AND COALESCE(:SUBTIPODOCTOID,0)  NOT IN (22,27) ) THEN
         BEGIN

            SELECT EXISTENCIA, EXISTENCIAFACTURADO, EXISTENCIAREMISIONADO, ERRORCODE
            FROM GET_EXISTENCIA(:PRODUCTOID, :ALMACENID, :LOTE, :FECHAVENCE)
            INTO :EXISTENCIAACTUAL, :EXISTENCIAFACTURADOACTUAL, :EXISTENCIAREMISIONADOACTUAL, :ERRORCODE;
                      
            IF(:MANEJAKITS = 'S' AND :ESKIT = 'S' /*AND :TIPODOCTOID IN (21,31,12, 13, 24)*/ AND
                    (COALESCE(:EXISTENCIAACTUAL,0) - COALESCE(:ENPROCESODESALIDA,0) - COALESCE(:ENPROCESOPARTESSALIDA,0)) < :CANTIDAD) THEN
            BEGIN
                    SELECT HAYEXISTENCIA, ERRORCODE
                    FROM GET_EXISTENCIAPARAKIT(:PRODUCTOID, :ALMACENID, :CANTIDAD - (COALESCE(:EXISTENCIAACTUAL,0) - COALESCE(:ENPROCESODESALIDA,0)- COALESCE(:ENPROCESOPARTESSALIDA,0)))
                    INTO  :HAYEXISTENCIAPARAARMAR , :ERRORCODE;

                    NUEVOSENPROCESOPARTES =  :CANTIDAD - (COALESCE(:EXISTENCIAACTUAL,0) - COALESCE(:ENPROCESODESALIDA,0)- COALESCE(:ENPROCESOPARTESSALIDA,0));

            END
            ELSE IF(:MANEJAKITS = 'S' AND :ESKIT = 'S' AND :TIPODOCTOID IN (21,31) AND :CANTIDAD < 0 AND :ENPROCESOPARTES >= (:CANTIDAD * -1)) THEN
            BEGIN
                    HAYEXISTENCIAPARAARMAR = 'S';
                    NUEVOSENPROCESOPARTES =  :CANTIDAD;
            END

            IF (:EXISTENCIAACTUAL < (:CANTIDADACTUAL + :CANTIDAD) AND COALESCE(:CANTIDAD,0)  > 0
                AND COALESCE(:HAYEXISTENCIAPARAARMAR,'N') <> 'S') THEN
            BEGIN
               ERRORCODE = 1081 ;
               SUSPEND;
               EXIT;
            END

            IF((:TIPODOCTOID IN (/*21,*/25,12,31, 121,1012) or (:TIPODOCTOID = 21 AND COALESCE(:SUBTIPODOCTOID,0) <> 8 ) ) AND
                 COALESCE(:EXISTENCIAACTUAL,0) - COALESCE(:ENPROCESODESALIDA,0) < ( :CANTIDAD)
                 AND COALESCE(:HAYEXISTENCIAPARAARMAR,'N') <> 'S')THEN
            BEGIN
                    ERRORCODE = 1081;
                    SUSPEND;
                    EXIT;
            END

         END
         
         IF(:TIPODOCTOID IN (501)  AND COALESCE(:SUBTIPODOCTOID,0) <> 10) THEN
         begin

                 IF(:CANTIDAD > 0) THEN
                 BEGIN
                    SELECT HAYEXISTENCIA, ERRORCODE
                    FROM GET_EXISTENCIAPARAKIT(:PRODUCTOID, :ALMACENTID, :CANTIDAD )
                    INTO  :HAYEXISTENCIAPARAARMAR , :ERRORCODE;

                    IF (COALESCE(:HAYEXISTENCIAPARAARMAR,'N') <> 'S' ) THEN
                    BEGIN
                        ERRORCODE = 1081;
                        SUSPEND;
                        EXIT;
                    END

                 END
                 NUEVOSENPROCESOPARTES =  :CANTIDAD;
         end
         IF(:TIPODOCTOID IN (1001) ) THEN
         begin
                 IF(:CANTIDAD > 0) THEN
                 BEGIN
                    SELECT HAYEXISTENCIA, ERRORCODE
                    FROM GET_EXISTENCIAPARAPRODPROMO(:PRODUCTOID, :ALMACENTID, :CANTIDAD )
                    INTO  :HAYEXISTENCIAPARAARMAR , :ERRORCODE;
                    IF (COALESCE(:HAYEXISTENCIAPARAARMAR,'N') <> 'S' ) THEN
                    BEGIN
                        ERRORCODE = 1081;
                        SUSPEND;
                        EXIT;
                    END
                 END
         end
      END

      /* no puede haber cantidades negativas en compras , ventas, devoluciones de compras y devoluciones de ventas*/
      IF((:CANTIDAD + :CANTIDADACTUAL) < 0 AND :TIPODOCTOID IN (11,12,21,22,25,16,17, 321, 821, 111, 121,1011,1012)) THEN
      BEGIN 
            ERRORCODE = 3005;
            SUSPEND;
            EXIT;
      END

      UPDATE MOVTO
      SET
         CANTIDAD = CANTIDAD + :CANTIDAD,
         CANTIDADSURTIDA = CANTIDADSURTIDA + coalesce(:CANTIDADSURTIDA, 0),
         IMPORTE = PRECIO * ( CANTIDAD + :CANTIDAD )  ,
         ENPROCESOPARTES =  :NUEVOSENPROCESOPARTES
      WHERE ID = :MOVTOID
      RETURNING CANTIDAD, PRECIO
      INTO :CANTIDADACUM, :PRECIOACTUAL;

      -- Solo para movimientos que tengan afectacion de inventarios. Por ahora solo excluir el Tipo 50 (Captura de inventario = Borrador)
      IF (:TIPODOCTOID not in (50,53)) then   -- !!! temporal falta analisis de Gerardo
      BEGIN
         -- Ver si acumula un precio con descuento Obtener nuevo precio fn(Prod, TipoDocto, Sucursal, CantidadAcumulada)
         SELECT PRECIO, ESPROMOCION, PROMOCIONID, PROMOCIONDESGLOSE, MONEDEROABONO, ERRORCODE
         FROM GET_PRODUCTO_PRECIO_DOCTO(:PRODUCTOID, :PERSONAID, :CANTIDADACUM,
            :TIPODOCTOID, :SUCURSALID, :SUCURSALTID, :COSTO, :PAGOCONTARJETA, :TIPOMAYOREOID, :PAGOACREDITO)
         INTO :PRECIONUEVO, :ESPROMOCION, :PROMOCIONID, :PROMOCIONDESGLOSE, :MONEDEROABONO, :ERRORCODE;

         -- Si es compra, para que el importe y descuento sean correctos.
         IF (:TIPODOCTOID in (11,50,51,52,53,54,55,41,16,17, 501,502,503,504, 32, 82,1011)) THEN
         BEGIN
            PRECIOLISTA = :COSTO;
            PRECIONUEVO = :COSTO * (1 - (coalesce(:porcentajedescuento, 0)/100));
         END
                   
         -- otras entradas
         IF (:TIPODOCTOID in (111)) THEN
         BEGIN
            PRECIOLISTA = :COSTO;
            PRECIONUEVO = :COSTO * (1 - (coalesce(:porcentajedescuento, 0)/100));
         END

        -- otras salidas
         IF (:TIPODOCTOID IN (121)) THEN
         BEGIN
         
            PRECIOLISTA = case when :LLEGOPRECIOMANUAL = 'S' THEN :PRECIO ELSE  :COSTO END;
            PRECIONUEVO = (case when :LLEGOPRECIOMANUAL = 'S' THEN :PRECIO ELSE  :COSTO END) * (1 - (coalesce(:porcentajedescuento, 0)/100));
         END
         
         -- si es devolucion de venta hay que obtener el precio de la devolucion
         IF (:TIPODOCTOID = 22 AND COALESCE(:SUBTIPODOCTOID,0) <> 13/* y no es una nc x rebaja*/) THEN
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
               ELSE
               BEGIN
                   SELECT COALESCE(MOVTO.cantidad,0) - COALESCE(MOVTO.cantidaddevuelta,0)
                   FROM MOVTO   WHERE ID = :MOVTOREFID
                   INTO :CANTIDADPOSIBLEADEVOLVER;

                   IF(COALESCE(:CANTIDADPOSIBLEADEVOLVER,0) < COALESCE(:CANTIDADACUM,0)) THEN
                   BEGIN
                              
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
           END
           ELSE
           BEGIN
                SELECT PRODUCTO.costoreposicion FROM PRODUCTO WHERE ID = :PRODUCTOID INTO :PRECIONUEVO;
           END
           PRECIOLISTA = :PRECIONUEVO;
         END

         IF (:TIPODOCTOID = 22 AND COALESCE(:SUBTIPODOCTOID,0) = 13/* y  es una nc x rebaja*/) THEN
         BEGIN
               PRECIONUEVO = :PRECIO;
               PRECIOLISTA = :PRECIO;
               PRECIOMANUAL = :PRECIO;
               
               IF(COALESCE(:MOVTOREFID,0) <> 0) THEN
               BEGIN
                   SELECT TASAIVA, TASAIEPS, TASAIMPUESTO FROM MOVTO WHERE ID = :MOVTOREFID INTO :TASAIVA, :TASAIEPS, :TASAIMPUESTO  ;
               END
         end

         IF (:TIPODOCTOID = 42) THEN
         BEGIN
               PRECIONUEVO = :PRECIO;
               PRECIOLISTA = :PRECIO;
         END
         
         IF (:TIPODOCTOID IN (901,902)) THEN
         BEGIN
               PRECIONUEVO = :PRECIO;
               PRECIOLISTA = :PRECIO;
         END
         
         IF (:TIPODOCTOID in (12,1012)) THEN
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

         -- Si es venta, y el precio < preciostd (2012-01-31: GAGL) Validar que el usuario tenga derecho a cambiar los precios.  Para tipo 21=Venta
         IF (:TIPODOCTOID  in (21,25,22, 321, 821) AND COALESCE(:SUBTIPODOCTOID,0) NOT IN (13)/* y no es una nc x rebaja*/ ) THEN
         BEGIN
            IF ((:PRECIO IS NOT NULL) AND
            (:PRECIO <> :PRECIONUEVO) AND
            (:LLEGOPRECIOMANUAL = 'S' or (:INGRESOPRECIOMANUAL = 'S' and :PORCENTAJEDESCUENTO IS NULL ) )) THEN
            BEGIN
                select costoreposicion from producto where id = :productoid into :COSTOREPOSICION;
                select coalesce(SUBTIPODOCTOID,0) from docto where id = :doctoid into :SUBTIPODOCTOID;

                IF( COALESCE(:PRECIOYAVALIDADO,'N') = 'N' AND COALESCE(:SUBTIPODOCTOID,0) <> 15  AND COALESCE(:SUBTIPODOCTOID,0)  NOT IN (22,27)) THEN  /*Si no es una venta movil*/
                BEGIN
                 SELECT ERRORCODE
                 FROM VALIDAR_PRECIO(:PRODUCTOID, :PRECIO, :PRECIONUEVO, :COSTOREPOSICION, :VENDEDORID, :TIPODOCTOID, :SUBTIPODOCTOID)
                 INTO :ERRORCODE;
   
                 IF (:ERRORCODE > 0) THEN
                 BEGIN
                  SUSPEND;
                  EXIT;
                 END
               END

                IF(COALESCE(:PRECIOMANUALBUFFER, 0) = 0) THEN
                BEGIN  
                    PRECIOMANUALBUFFER = :PRECIO;
                END


               --si estamos recalculando
                IF(COALESCE(:CANTIDAD,0) = 0 AND COALESCE(:CARGOTARJPRECIOMANUAL,'N') = 'R') THEN
                BEGIN 
                   SELECT PRECIOMANUAL FROM movto WHERE ID = :MOVTOACTUALID INTO :PRECIOMANUAL;
                   --PAGO CON TARJETA
                   IF ( COALESCE(:PAGOCONTARJETA,'N') = 'S') THEN    --si se esta intentando recalcular
                   BEGIN

                    SELECT PRECIOEXPORTACIONLINEA, ERRORCODE FROM GET_PRECIO_CONCOMISIONTARJETA(:PRODUCTOID ,:PERSONAID, :CANTIDAD ,:PRECIO1 ,:PRECIOMANUAL,:PAGOCONTARJETA)
                    INTO :PRECIO , :ERRORCODE;

                    --si el precio ya supera el precio de menudeo volver a poner el precio de menudeo
                    IF(:PRECIO > :PRECIOLISTA AND COALESCE(:PAGOTARJMENORPRECIOLISTAALL,'N') = 'S' ) THEN
                    BEGIN
                        PRECIO = :PRECIOLISTA;
                    END
                   END
                   ELSE
                   BEGIN
                       PRECIO = :PRECIOMANUAL;
                   END
                END


               PRECIONUEVO = :PRECIO;  
               PRECIOMANUAL = :PRECIOMANUALBUFFER;
               INGRESOPRECIOMANUAL = 'S';

               if(COALESCE(:CARGOTARJPRECIOMANUAL,'N') <> 'R') then
               begin
                UPDATE MOVTO SET PRECIOMANUAL = :PRECIOMANUAL WHERE ID = :MOVTOACTUALID;
               end
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
                    END
               END
               PRECIO = :PRECIONUEVO;
               PRECIOMANUAL = :PRECIO;

            END
         END
         -- Aqui llega si se cumplieron una de dos condiciones:   > El precio es el estandar --   > El precio es menor al estandar pero el usuario tiene derecho. -- Calcular descuento.
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
         END

         /*Aqui va lo del tipo de cambio para que se exacto a 2 puntos decimales si es que aplica*/
         SELECT COALESCE(TIPOCAMBIO ,1 ) FROM DOCTO WHERE ID = :DOCTOID INTO :TIPOCAMBIO;
         TIPOCAMBIO = CASE WHEN :TIPOCAMBIO = 0 THEN 1 ELSE COALESCE(:TIPOCAMBIO,1) END;
          IF(:TIPOCAMBIO <> 1) then
          BEGIN
            BUFFERPRECIOMONEDA2 =  ROUND( :PRECIONUEVO / :TIPOCAMBIO , 2);
            PRECIONUEVO = :BUFFERPRECIOMONEDA2 * :TIPOCAMBIO;
          END

         IMPORTE = CAST(:CANTIDADACUM * :PRECIOLISTA AS D_IMPORTE);
         SUBTOTAL = CAST(:CANTIDADACUM * :PRECIONUEVO AS D_IMPORTE);
         TASAIVA = COALESCE(:TASAIVA, 0);
         IF(COALESCE(:PERSONAEXENTOIVA,'N') = 'S') THEN
         BEGIN
            TASAIVA = 0.0;

         END
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
           IEPS =   CAST(:SUBTOTAL * (:TASAIEPS / 100.00) AS D_IMPORTE);
         ELSE
           IEPS = 0.00;

         IF (:TASAIVA > 0.00) THEN
           IVA = CAST((:SUBTOTAL * ( 1 + (:TASAIEPS / 100.00))) * (:TASAIVA / 100.00) AS D_IMPORTE);
         ELSE
           IVA = 0.00;

           IMPUESTO = IVA + IEPS;

         IF(:TASAIVARETENIDO > 0.00 AND :SUBTOTAL > 0 and :PERSONARETIENEIVA = 'S') THEN
            IVARETENIDO = CAST(:SUBTOTAL * (:TASAIVARETENIDO / 100.00) AS D_IMPORTE);
         ELSE
            IVARETENIDO = 0.00;
            
         IF(:TASAISRRETENIDO > 0.00 AND :SUBTOTAL > 0 and :PERSONARETIENEISR = 'S') THEN
            ISRRETENIDO = CAST(:SUBTOTAL * (:TASAISRRETENIDO / 100.00) AS D_IMPORTE);
         ELSE
            ISRRETENIDO = 0.00;

         TOTAL = CAST(:SUBTOTAL + :IMPUESTO AS D_IMPORTE);
         COSTOIMPORTE = :CANTIDADACUM * :COSTO;

         --respeta el descuento puesto en compras
         IF(:TIPODOCTOID IN (11,12,13,14,15,16,17,18, 111, 113,1011,1012,1013,1015)) THEN
         BEGIN
            DESCUENTOPORCENTAJE = :PORCENTAJEDESCUENTOORIGINAL;
         END

         UPDATE MOVTO
         SET
            PRECIO = :PRECIONUEVO,
            COSTO = :COSTO,
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
            PRECIOLISTA = :PRECIOLISTA ,
            IMPORTEENDOLAR = COALESCE(CANTIDAD,0.000) * COALESCE(costoendolar, 0.00)
         WHERE ID = :MOVTOID;
               
        
      SELECT ERRORCODE FROM KIT_AJUSTARIMPUESTOS(:DOCTOID, :movtoid, :ESKIT) INTO :ERRORCODE;

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
     --Ver si aplica algun cambio de tipo de mayoreo si esta activado mayoreo por linea y si es asi recalcula docto
      IF (:TIPODOCTOID in (21)) then
      BEGIN
         IF(:APLICARMAYOREOPORLINEA = 'S') THEN
         BEGIN
           SELECT TIPOMAYOREOID, ERRORCODE FROM GET_TIPOMAYOREO_DOCTO(:DOCTOID, :PRODUCTOID)
           INTO :NUEVOTIPOMAYOREOID, :ERRORCODE;
           IF (:ERRORCODE > 0) THEN
           BEGIN
               SUSPEND;
               EXIT;
           END

           IF(COALESCE(:TIPOMAYOREOID,1) <> COALESCE(:NUEVOTIPOMAYOREOID,1)) THEN
           BEGIN
                UPDATE DOCTO SET TIPOMAYOREOID = :NUEVOTIPOMAYOREOID WHERE ID = :DOCTOID;
                SELECT ERRORCODE FROM DOCTO_RECALCULAR_DETALLES(:DOCTOID) INTO :ERRORCODE;
                IF (:ERRORCODE > 0) THEN
                BEGIN
                     SUSPEND;
                     EXIT;
                END
           END
         END
      END

   SUSPEND;
END
