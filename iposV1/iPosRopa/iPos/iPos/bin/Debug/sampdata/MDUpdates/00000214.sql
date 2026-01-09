CREATE OR ALTER PROCEDURE IMPORTAR_DBFLINE (
    DOCTOACTUALID D_FK,
    REFERENCIA D_REFERENCIA,
    SUCURSALID D_FK,
    USERID D_FK,
    PRODUCTO D_CLAVE,
    LINEA D_CLAVE,
    MARCA D_CLAVE,
    PROVEEDOR D_CLAVE,
    CANTIDAD D_CANTIDAD,
    FALTANTE D_CANTIDAD,
    COSTO D_COSTO,
    CARGOS_U D_PRECIO,
    IMPORTE D_PRECIO,
    IMPORTENETO D_PRECIO,
    LOTE D_LOTE,
    FECHAVENCE D_FECHAVENCE,
    REFERENCIAS VARCHAR(255),
    SUCURSALTID D_FK,
    ALMACENTID D_FK,
    TIPODOCTOID D_FK,
    FECHA D_FECHA,
    VENCE D_FECHA)
RETURNS (
    DOCTOID D_FK,
    ERRORCODE D_ERRORCODE)
AS
DECLARE VARIABLE PRODUCTOID D_FK;
DECLARE VARIABLE PROVEEDORID D_FK;
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
   WHERE CLAVE = :PROVEEDOR
   INTO :PROVEEDORID;

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
         :PROVEEDORID,
         :USERID,
         1,
         :REFERENCIA,
         :REFERENCIAS,
         :SUCURSALTID,
         :ALMACENTID,
         :FECHA,
         :VENCE
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
   SELECT DOCTOID
   FROM MOVTO_INSERT (
      :DOCTOID, 0, 1, 1, 11, 0, 0, 0, :USERID, 0,
      0, :PRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDAD, 0, :CANTIDAD, 0, 0,:COSTO, 0,
      :REFERENCIA, :REFERENCIAS, :COSTO, :SUCURSALTID, :ALMACENTID, 'N', 0, :FECHA, :VENCE, 0.00
   ) INTO :DOCTOID;
END;



