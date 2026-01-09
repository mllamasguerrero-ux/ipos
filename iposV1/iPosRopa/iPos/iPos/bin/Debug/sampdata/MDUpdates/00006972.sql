create or alter procedure MATRIZ_ENVIOPEDIDO_COMPLETAR (
    DOCTOID D_FK,
    VENDEDORID D_FK,
    OBSERVACION D_OBSERVACION,
    ESFACTURAELECTRONICA D_BOOLCN)
returns (
    DOCTOVENTAID D_FK,
    ERRORCODE D_ERRORCODE)
as
declare variable TIPODOCTOID D_FK;
declare variable ESTATUSDOCTOID D_FK;
declare variable FALTANTES integer;
declare variable REFERENCIAS varchar(255);
declare variable EXISTENCIASINSUFICIENTES integer;
declare variable COSTOREPO D_COSTO;
declare variable PRECIOENVIOTRASLADO D_FK;
declare variable ESFRANQUICIA D_BOOLCN;
declare variable MOVTOID D_FK;
declare variable ALMACENID D_FK;
declare variable SUCURSALID D_FK;
declare variable PERSONAID D_FK;
declare variable PRODUCTOID D_FK;
declare variable LOTE D_LOTE;
declare variable FECHAVENCE D_FECHAVENCE;
declare variable CANTIDAD D_CANTIDAD;
declare variable PRECIO D_PRECIO;
declare variable COSTO D_COSTO;
declare variable REFERENCIA D_REFERENCIA;
declare variable SERIE varchar(31);
declare variable FOLIO integer;
declare variable ALMACENTID D_FK;
declare variable SUCURSALTID D_FK;
declare variable TIPODIFERENCIAINVENTARIOID D_FK;
declare variable CANTIDADDEFACTURA D_CANTIDAD;
declare variable CANTIDADDEREMISION D_CANTIDAD;
declare variable CANTIDADDEINDEFINIDO D_CANTIDAD;
declare variable NEWMOVTOID D_FK;
declare variable PERSONASUCURSALID D_FK;
declare variable DESCRIPCION1 D_STDTEXT_64;
declare variable DESCRIPCION2 D_STDTEXT_64;
declare variable DESCRIPCION3 D_STDTEXT_64;
declare variable SUPERLISTAPRECIOID D_FK;
declare variable MANEJASUPERLISTAPRECIO D_BOOLCN;
declare variable CLAVECLIENTESUCURSAL D_CLAVE_NULL;
declare variable ESTADOSURTIDOID D_FK;
declare variable LOTEIMPORTADO D_FK;
declare variable MANEJAALMACEN D_BOOLCN;
BEGIN


   
      CLAVECLIENTESUCURSAL = NULL;
      SUPERLISTAPRECIOID = 1;
      SELECT SUCURSAL.clienteclave FROM SUCURSAL WHERE ID = :SUCURSALTID AND SUCURSAL.esfranquicia = 'S'
      INTO :CLAVECLIENTESUCURSAL;

      IF(COALESCE(CLAVECLIENTESUCURSAL,'') <> '') THEN
      BEGIN
                                   
         SELECT id from persona where clave = :CLAVECLIENTESUCURSAL AND TIPOPERSONAID = 50 into :personasucursalid;
         
         IF(:PERSONASUCURSALID IS NOT NULL) THEN
         BEGIN
            SELECT MANEJASUPERLISTAPRECIO FROM PARAMETRO INTO :MANEJASUPERLISTAPRECIO;
            SELECT SUPERLISTAPRECIOID FROM persona WHERE ID = :PERSONASUCURSALID INTO :SUPERLISTAPRECIOID;

            IF(COALESCE(:MANEJASUPERLISTAPRECIO ,'N') = 'N') THEN
            BEGIN
                SUPERLISTAPRECIOID = 1;
            END
        END
      END



   SELECT S.preciorecepciontraslado FROM DOCTO D INNER JOIN SUCURSAL S ON D.SUCURSALTID = S.id
   where d.id = :doctoid
   into :PRECIOENVIOTRASLADO;



   -- Si no es documento de compra 11.
   IF ((:DOCTOID IS NULL) OR (:DOCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1060;
      SUSPEND;
      EXIT;
   END

   -- Validar estatus.
   SELECT TIPODOCTOID, ESTATUSDOCTOID, REFERENCIAS , ESTADOSURTIDOID , ALMACENID
   FROM DOCTO
   WHERE ID = :DOCTOID
   INTO :TIPODOCTOID, :ESTATUSDOCTOID, :REFERENCIAS, :ESTADOSURTIDOID, :ALMACENID;

   -- Si no es documento de compra 11.
   IF ((:TIPODOCTOID IS NULL) OR (:TIPODOCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1060;
      SUSPEND;
      EXIT;
   END

   -- Si no es documento de compra 11.
   IF (:TIPODOCTOID <> 81 ) THEN
   BEGIN
      ERRORCODE = 1061;
      SUSPEND;
      EXIT;
   END

   -- Si el estatus no es borrador .
   IF (:ESTATUSDOCTOID <> 0) THEN
   BEGIN
      ERRORCODE = 1062;
      SUSPEND;
      EXIT;
   END



   SELECT MANEJAALMACEN FROM PARAMETRO INTO :MANEJAALMACEN;
   IF( COALESCE(:MANEJAALMACEN , 'N') = 'S') THEN
   BEGIN
          
      select count(*) from
       (
        select movto.id, movto.cantidad, sum(coalesce(inventario.cantidad,0)) existencia
        from movto
        left join producto on movto.productoid = producto.id
        left join inventario on movto.productoid = inventario.productoid and inventario.almacenid =  COALESCE(:ALMACENID,1)
        where movto.doctoid = :doctoid
        and producto.inventariable = 'S'
        and (coalesce(producto.negativos,'N') = 'N' or coalesce(producto.manejalote,'N') = 'S' )
        group by  movto.id, movto.cantidad
       ) sq
       where (coalesce(sq.existencia,0) < coalesce(sq.cantidad,0))
        into :EXISTENCIASINSUFICIENTES  ;

   
        IF (coalesce(:EXISTENCIASINSUFICIENTES,0) <> 0) THEN
        BEGIN
            ERRORCODE = 3001;
            SUSPEND;
            EXIT;
        END
   END
   ELSE
   BEGIN

        
        select count(*) from movto left join producto on movto.productoid = producto.id
        where movto.doctoid = :doctoid and (coalesce(producto.existencia,0) < movto.cantidad)
            and producto.inventariable = 'S'
            and (coalesce(producto.negativos,'N') = 'N' or coalesce(producto.manejalote,'N') = 'S' )
        into :EXISTENCIASINSUFICIENTES  ;

   
        IF (coalesce(:EXISTENCIASINSUFICIENTES,0) <> 0) THEN
        BEGIN
            ERRORCODE = 3001;
            SUSPEND;
            EXIT;
        END

   END






   --delete from movto where cantidad = 0 and movto.doctoid = :doctoid;

   SELECT ERRORCODE FROM ASIGNARLOTE_SURTIRPEDIDO (
    :DOCTOID )
    INTO  :ERRORCODE;

    IF(:ERRORCODE <> 0) THEN
    BEGIN
        SUSPEND;
        EXIT;
    END

   update movto set costo = (

   select case
   when :precioenviotraslado = 1 then coalesce(costoreposicion,0)
   when :precioenviotraslado = 4 then CASE WHEN :SUPERLISTAPRECIOID = 2 THEN COALESCE(SPRECIO1,0) ELSE COALESCE(PRECIO1,0) END
   when :precioenviotraslado = 5 then CASE WHEN :SUPERLISTAPRECIOID = 2 THEN COALESCE(SPRECIO2,0) ELSE COALESCE(PRECIO2,0) END
   when :precioenviotraslado = 6 then CASE WHEN :SUPERLISTAPRECIOID = 2 THEN COALESCE(SPRECIO3,0) ELSE COALESCE(PRECIO3,0) END
   when :precioenviotraslado = 7 then CASE WHEN :SUPERLISTAPRECIOID = 2 THEN COALESCE(SPRECIO4,0) ELSE COALESCE(PRECIO4,0) END
   when :precioenviotraslado = 8 then CASE WHEN :SUPERLISTAPRECIOID = 2 THEN COALESCE(SPRECIO5,0) ELSE COALESCE(PRECIO5,0) END
   else coalesce(costoreposicion,0)
   end from producto where id = movto.productoid


   )
   where movto.doctoid = :doctoid;


   update movto set costoimporte = costo * movto.cantidad , precio = costo,
   importe = costo * movto.cantidad ,
   subtotal = costo * movto.cantidad  ,
   iva = round((coalesce(tasaiva,0)/100) * costo * (1 + (coalesce(tasaieps,0)/100)) * movto.cantidad, 2),
   ieps = round((coalesce(tasaieps,0)/100) * costo * movto.cantidad,2),
   impuesto = round((coalesce(tasaiva,0)/100) * costo * (1 + (coalesce(tasaieps,0)/100)) * movto.cantidad, 2) +
                round((coalesce(tasaieps,0)/100) * costo * movto.cantidad,2),
    total = costo * movto.cantidad  +
            round((coalesce(tasaiva,0)/100) * costo * (1 + (coalesce(tasaieps,0)/100)) * movto.cantidad, 2) +
                round((coalesce(tasaieps,0)/100) * costo * movto.cantidad,2)
   where movto.doctoid = :doctoid;

         update docto
         set importe =  (select sum(coalesce(m.importe,0)) from movto m where m.doctoid = :doctoid) ,
         subtotal    =  (select sum(coalesce(m.subtotal,0)) from movto m where m.doctoid = :doctoid) ,
         iva   =  (select sum(coalesce(m.iva,0)) from movto m where m.doctoid = :doctoid) , 
         ieps   =  (select sum(coalesce(m.ieps,0)) from movto m where m.doctoid = :doctoid) ,
         impuesto   =  (select sum(coalesce(m.impuesto,0)) from movto m where m.doctoid = :doctoid) ,
         total    =  (select sum(coalesce(m.total,0)) from movto m where m.doctoid = :doctoid)
         where id = :doctoid;






    UPDATE DOCTO SET VENDEDORID = :VENDEDORID WHERE ID = :DOCTOID;


   SELECT SUCURSAL.ESFRANQUICIA
   FROM DOCTO INNER JOIN SUCURSAL ON SUCURSAL.ID = DOCTO.SUCURSALTID
   WHERE DOCTO.ID = :DOCTOID
   INTO :ESFRANQUICIA;

   IF(COALESCE(:ESFRANQUICIA,'N') = 'S') THEN
   BEGIN

   SELECT persona.id
   FROM DOCTO INNER JOIN SUCURSAL ON SUCURSAL.ID = DOCTO.SUCURSALTID
   INNER JOIN PERSONA ON SUCURSAL.CLIENTECLAVE = PERSONA.CLAVE AND PERSONA.tipopersonaid = 50
   WHERE DOCTO.ID = :DOCTOID
   INTO :PERSONASUCURSALID;


        -- Agrega el DOCTO.
        INSERT INTO DOCTO
        (ALMACENID, SUCURSALID, TIPODOCTOID, ESTATUSDOCTOID, ESTATUSDOCTOPAGOID,
        PERSONAID, CAJEROID, VENDEDORID, CORTEID, FECHA, FECHAHORA, SERIE, FOLIO,
        PLAZO, VENCE, IMPORTE, DESCUENTO, SUBTOTAL, IVA, TOTAL, CARGO, ABONO, SALDO,
        CAJAID, REFERENCIA, REFERENCIAS, SUCURSALTID, ALMACENTID, PROMOCION, ESFACTURAELECTRONICA,
        FOLIOSAT,SERIESAT,TIMBRADOFECHA, TIMBRADOUUID,TIMBRADOCERTSAT,ESAPARTADO,DOCTOREFID, IEPS, IMPUESTO, SUBTIPODOCTOID, TIMBRADOFORMAPAGOSAT)
        SELECT
        ALMACENID, SUCURSALID, 21, 0, 0,
        COALESCE(:PERSONASUCURSALID,1), CAJEROID, :VENDEDORID, CORTEID, CURRENT_DATE, CURRENT_TIMESTAMP, NULL, NULL,
        PLAZO, CURRENT_DATE, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00,
        CAJAID, REFERENCIA, REFERENCIAS, SUCURSALTID, ALMACENTID, 'N' , :ESFACTURAELECTRONICA ,
        FOLIOSAT,SERIESAT,TIMBRADOFECHA, TIMBRADOUUID,TIMBRADOCERTSAT , ESAPARTADO,ID, 0.00, 0.00 ,7 , 99
        FROM DOCTO WHERE ID = :DOCTOID
        RETURNING ID INTO :DOCTOVENTAID;

        -- Agrega los MOVTO.
        FOR SELECT
            ID, PRODUCTOID, LOTE, FECHAVENCE, CANTIDAD, PRECIO, COSTO, 
            TIPODIFERENCIAINVENTARIOID  , CANTIDADDEFACTURA, CANTIDADDEREMISION, CANTIDADDEINDEFINIDO , DESCRIPCION1, DESCRIPCION2, DESCRIPCION3 , LOTEIMPORTADO
            FROM MOVTO
            WHERE DOCTOID = :DOCTOID AND CANTIDAD > 0.00
            INTO
            :MOVTOID, :PRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDAD, :PRECIO, :COSTO, 
            :TIPODIFERENCIAINVENTARIOID , :CANTIDADDEFACTURA, :CANTIDADDEREMISION, :CANTIDADDEINDEFINIDO  , :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3 , :LOTEIMPORTADO
        DO
        BEGIN
            SELECT ERRORCODE,MOVTOID
            FROM MOVTO_INSERT (
            :DOCTOVENTAID, 0, :ALMACENID, :SUCURSALID, 21, 0, 0, :PERSONAID, :VENDEDORID, 1,
            0, :PRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDAD, 0, 0, 0, 0, :PRECIO, 0,
            :REFERENCIA, :REFERENCIAS, :COSTO, :SUCURSALID, :ALMACENID, 'N', 
            :TIPODIFERENCIAINVENTARIOID, CURRENT_DATE, CURRENT_DATE, 0.00 ,NULL,NULL,NULL,NULL,NULL , :DESCRIPCION1, :DESCRIPCION2, :DESCRIPCION3, NULL, :LOTEIMPORTADO, 'N','N'
            ) INTO :ERRORCODE,:NEWMOVTOID;
            
            IF (:ERRORCODE <> 0) THEN
            BEGIN

                SUSPEND;
                EXIT;
            END


        END


        UPDATE DOCTO SET ESTADOSURTIDOID = :ESTADOSURTIDOID WHERE ID = :DOCTOVENTAID;
        UPDATE DOCTO SET SUBTIPODOCTOID = 7, DOCTOREFID = :DOCTOVENTAID, ESTADOSURTIDOID = 1 WHERE ID = :DOCTOID;

      /*UPDATE DOCTO SET TIPODOCTOID = 21, CARGO = TOTAL, SUBTIPODOCTOID = 7 WHERE ID = :DOCTOID;
      UPDATE MOVTO SET TIPODOCTOID = 21, CARGO = TOTAL WHERE DOCTOID = :DOCTOID; */



   END





   -- Completar el documento con afectacion de inventarios.
   SELECT ERRORCODE
   FROM DOCTO_SAVE(:DOCTOID)
   INTO :ERRORCODE;

   IF(COALESCE(:ESFRANQUICIA,'N') = 'S') THEN
   BEGIN
        SELECT ERRORCODE
        FROM DOCTO_SAVE(:DOCTOVENTAID)
        INTO :ERRORCODE;
   END
   
   IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
   BEGIN
      SUSPEND;
      EXIT;
   END
   



   UPDATE docto SET OBSERVACION = :OBSERVACION
   WHERE ID = :DOCTOID;





   SUSPEND;
   
   /*WHEN ANY DO
   BEGIN
      ERRORCODE = 1063;
      SUSPEND;
   END */
END