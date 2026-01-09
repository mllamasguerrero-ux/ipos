create or alter procedure IMPORTAR_HISTORIALMOVIL (
    DOCTOACTUALID D_FK,
    REFERENCIA D_REFERENCIA,
    SUCURSALID D_FK,
    USERID D_FK,
    PRODUCTO D_CLAVE,
    LINEA D_CLAVE,
    MARCA D_CLAVE,
    CLIENTE D_CLAVE,
    CANTIDAD D_CANTIDAD,
    FALTANTE D_CANTIDAD,
    COSTO D_COSTO,
    CARGOS_U D_PRECIO,
    IMPORTE D_PRECIO,
    IMPORTENETO D_PRECIO,
    LOTE D_LOTE,
    FECHAVENCE D_FECHAVENCE,
    REFERENCIAS varchar(255),
    SUCURSALTID D_FK,
    ALMACENTID D_FK,
    TIPODOCTOID D_FK,
    FECHA D_FECHA,
    VENCE D_FECHA,
    CANTIDADDEFACTURA D_CANTIDAD,
    CANTIDADDEREMISION D_CANTIDAD,
    CANTIDADDEINDEFINIDO D_CANTIDAD,
    PRECIOVISIBLETRASLADO D_PRECIO)
returns (
    DOCTOID D_FK,
    ERRORCODE D_ERRORCODE)
as
declare variable PRODUCTOID D_FK;
declare variable CLIENTEID D_FK;
declare variable MOVTOID D_FK;
BEGIN
   SELECT ID
   FROM PRODUCTO
   WHERE CLAVE = :PRODUCTO
   INTO :PRODUCTOID;

   if( :PRODUCTOID is null )  then
   begin
      insert into producto (
         clave,
         nombre,
         ean ,
         descripcion1 ,
         manejalote,
         eskit,
         negativos
      ) values (
         :PRODUCTO,
         'PRODUCTO NO REGISTRADO',
         '',
         'PRODUCTO NO REGISTRADO',
         'N',
         'N',
         'S'
      ) RETURNING ID INTO :PRODUCTOID;
   end

   SELECT ID
   FROM PERSONA
   WHERE CLAVE = :CLIENTE AND TIPOPERSONAID  = 50
   INTO :CLIENTEID;

   IF ((:DOCTOACTUALID IS NULL) or (:DOCTOACTUALID = 0)) THEN
   BEGIN
      SELECT DOCTOID, ERRORCODE
      FROM DOCTO_INSERT (
         :USERID,
         1,
         :SUCURSALID,
         :TIPODOCTOID,
         0,
         0,
         :CLIENTEID,
         :USERID,
         1,
         :REFERENCIA,
         :REFERENCIAS,
         :SUCURSALTID,
         :ALMACENTID,
         :FECHA,
         :VENCE,
         NULL  ,
         'S',
         1
      ) INTO :DOCTOID, :ERRORCODE;
   END
   ELSE
   BEGIN
      DOCTOID = :DOCTOACTUALID;
   END

   -- provisional mientras cambio docto_insert y movto_insert.
   UPDATE DOCTO
   SET REFERENCIAS = :REFERENCIAS
   WHERE ID = :DOCTOID;

   -- Guarda el movimiento en movto
   SELECT DOCTOID , MOVTOID
   FROM MOVTO_INSERT (
      :DOCTOID, 0, 1, 1, :TIPODOCTOID, 0, 0, 0, :USERID, 0,
      0, :PRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDAD, 0, :CANTIDAD, 0, 0,:COSTO, 0,
      :REFERENCIA, :REFERENCIAS, :COSTO, :SUCURSALTID, :ALMACENTID, 'N', 0, :FECHA, :VENCE, 0.00 ,NULL,NULL,NULL,NULL,NULL, NULL, NULL, NULL
   ) INTO :DOCTOID, :MOVTOID;

    
   UPDATE MOVTO SET  PRECIOLISTA = :PRECIOVISIBLETRASLADO WHERE ID = :MOVTOID ;

END