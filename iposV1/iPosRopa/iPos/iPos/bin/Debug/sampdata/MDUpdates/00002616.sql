create or alter procedure IMPORTAR_PEDIDO_MOVIL (
    DOCTOACTUALID D_FK,
    REFERENCIA D_REFERENCIA,
    CLAVEVENDEDOR D_CLAVE,
    PRODUCTO D_CLAVE,
    CANTIDAD D_CANTIDAD,
    REFERENCIAS varchar(255),
    FECHA D_FECHA,
    DESCRIPCION D_DESCRIPCION,
    PRECIO D_PRECIO,
    CLAVECLIENTE D_CLAVE,
    OBSERVACION D_OBSERVACION,
    ESFACTURAELECTRONICA D_BOOLCN)
returns (
    DOCTOID D_FK,
    ERRORCODE D_ERRORCODE)
as
declare variable PRODUCTOID D_FK;
declare variable PROVEEDORID D_FK;
declare variable MOVTOID D_FK;
declare variable PERSONAID D_FK;
declare variable TIPODOCTOID D_FK;
declare variable SUCURSALID D_FK;
declare variable VENDEDORID D_FK;
BEGIN

   TIPODOCTOID = 331;
   VENDEDORID = 17;
   PERSONAID = 1;

   SELECT SUCURSALID FROM PARAMETRO INTO :SUCURSALID;



   SELECT ID
   FROM PRODUCTO
   WHERE CLAVE = :PRODUCTO
   INTO :PRODUCTOID;



      IF(COALESCE(CLAVECLIENTE,'') <> '') THEN
      BEGIN
         SELECT first 1 id from persona where clave = :CLAVECLIENTE AND TIPOPERSONAID = 50 into :personaid;

      END

      IF(COALESCE(:PERSONAID,1) = 1) THEN
      BEGIN
         ERRORCODE = 5005;
      END


      
      IF(COALESCE(CLAVEVENDEDOR,'') <> '') THEN
      BEGIN
         SELECT first 1 id from persona where clave = :CLAVEVENDEDOR AND TIPOPERSONAID IN (20,22) into :VENDEDORID;

      END


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


   IF ((:DOCTOACTUALID IS NULL) or (:DOCTOACTUALID = 0)) THEN
   BEGIN
      SELECT DOCTOID, ERRORCODE
      FROM DOCTO_INSERT (
         :VENDEDORID,
         1,
         :SUCURSALID,
         :TIPODOCTOID,
         0,
         0,
         :PERSONAID,
         :VENDEDORID,
         1,
         :REFERENCIA,
         :REFERENCIAS,
         0,
         0,
         :FECHA,
         NULL,
         NULL ,
         'S' ,
         1
      ) INTO :DOCTOID, :ERRORCODE;
   END
   ELSE
   BEGIN
      DOCTOID = :DOCTOACTUALID;
   END

   -- provisional mientras cambio docto_insert y movto_insert.
   UPDATE DOCTO
   SET REFERENCIAS = :REFERENCIAS, DESCRIPCION = :DESCRIPCION , OBSERVACION = :OBSERVACION , ESFACTURAELECTRONICA = COALESCE(:ESFACTURAELECTRONICA,'N')
   WHERE ID = :DOCTOID;







   -- Guarda el movimiento en movto
   SELECT DOCTOID , MOVTOID
   FROM MOVTO_INSERT (
      :DOCTOID, 0, 1, :SUCURSALID, :TIPODOCTOID, 0, 0, :PERSONAID, :VENDEDORID, 0,
      0, :PRODUCTOID, NULL, NULL, :CANTIDAD, 0, :CANTIDAD, 0, 0, :PRECIO, 0,
      :REFERENCIA, :REFERENCIAS, 0, 0, 0, 'N', 0, :FECHA, NULL, 0.00, NULL,NULL,NULL,NULL,NULL , NULL, NULL, NULL
   ) INTO :DOCTOID, :MOVTOID;


   suspend;

END