create or alter procedure IMPORTAR_DBFLINE_PEDIDOMOVIL (
    DOCTOACTUALID D_FK,
    REFERENCIA D_REFERENCIA,
    SUCURSALID D_FK,
    USERID D_FK,
    PRODUCTO D_CLAVE,
    CANTIDAD D_CANTIDAD,
    REFERENCIAS varchar(255),
    SUCURSALTID D_FK,
    ALMACENTID D_FK,
    TIPODOCTOID D_FK,
    FECHA D_FECHA,
    DESCRIPCION D_DESCRIPCION,
    OBSERVACION D_OBSERVACION,
    CLAVECLIENTE D_CLAVE_NULL,
    NOMBRECLIENTE D_CLAVE_NULL,
    ESFACTURA D_BOOLCN_NULL,
    COSTO D_PRECIO)
returns (
    DOCTOID D_FK,
    ERRORCODE D_ERRORCODE)
as
declare variable PRODUCTOID D_FK;
declare variable PROVEEDORID D_FK;
declare variable MOVTOID D_FK;
declare variable PRECIORECEPCIONTRASLADO D_FK;
declare variable TIPOPRECIORECEPCIONTRASLADO D_FK;
declare variable SUPERLISTAPRECIOID D_FK;
declare variable MANEJASUPERLISTAPRECIO D_BOOLCN;
declare variable PERSONAID D_FK;
BEGIN



   SELECT ID
   FROM PRODUCTO
   WHERE CLAVE = :PRODUCTO
   INTO :PRODUCTOID;


      SUPERLISTAPRECIOID = 1;

      IF(COALESCE(CLAVECLIENTE,'') <> '') THEN
      BEGIN
                                   
         SELECT id from persona where clave = :CLAVECLIENTE AND TIPOPERSONAID = 50 into :personaid;
         
         IF(:PERSONAID IS  NULL) THEN
         BEGIN
                  
            insert into PERSONA ( clave, nombre, tipopersonaid)
            values ( :CLAVECLIENTE,'CLIENTE MOVIL NO IMPORTADO', 50)
            RETURNING ID INTO :PERSONAID;
         END
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
         :USERID,
         1,
         :SUCURSALID,
         :TIPODOCTOID,
         0,
         0,
         :PERSONAID,
         :USERID,
         1,
         :REFERENCIA,
         :REFERENCIAS,
         NULL,
         NULL,
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
   SET REFERENCIAS = :REFERENCIAS, DESCRIPCION = :DESCRIPCION  , OBSERVACION = :OBSERVACION,
       ESFACTURAELECTRONICA = :ESFACTURA
   WHERE ID = :DOCTOID;




   -- Guarda el movimiento en movto
   SELECT DOCTOID , MOVTOID
   FROM MOVTO_INSERT (
      :DOCTOID, 0, 1, 1, 331, 0, 0, 0, :USERID, 0,
      0, :PRODUCTOID, NULL, NULL, :CANTIDAD, 0, :CANTIDAD, 0, 0, :COSTO, 0,
      :REFERENCIA, :REFERENCIAS, 0, NULL, NULL, 'N', 0, :FECHA, NULL, 0.00, NULL,NULL,NULL,NULL,NULL , NULL, NULL, NULL , NULL , NULL , 'N','N'
   ) INTO :DOCTOID, :MOVTOID;



END