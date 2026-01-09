CREATE OR ALTER PROCEDURE GET_KARDEX_REPORT_SUMMARY (
    prod_clave_ini varchar(31),
    prod_clave_fin varchar(31),
    fechaini d_fecha,
    fechafin d_fecha,
    almacenid d_fk)
returns (
    numero integer,
    productoid d_fk,
    productoclave d_clave,
    productodescripcion d_descripcion,
    cantidadini d_cantidad,
    cantidadentradas d_cantidad,
    cantidadsalidas d_cantidad,
    cantidadfin d_cantidad,
    productoprecio d_precio,
    productocostorepo d_costo)
as
declare variable existenciainicial d_cantidad;
declare variable fechainicial d_fecha;
declare variable cantidadmovtosinicial d_cantidad;
declare variable producto_id d_fk;
declare variable cuenta integer;
BEGIN


   if (:PROD_CLAVE_FIN = '') then
   BEGIN
      PROD_CLAVE_FIN = 'ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ';
   END


         
   FOR SELECT
      PRODUCTO.ID,producto.clave,producto.descripcion1 , producto.precio1  , producto.costoreposicion
      FROM PRODUCTO
      WHERE  PRODUCTO.CLAVE BETWEEN :PROD_CLAVE_INI AND :PROD_CLAVE_FIN
      INTO   :PRODUCTO_ID,:productoclave,:productodescripcion, :productoprecio,  :productocostorepo
   DO
   BEGIN

   -- Tomar existencia inicial de INVENTARIO
   SELECT sum(CANTIDADINICIAL), MIN(FECHAINICIAL)
   FROM INVENTARIO
   WHERE ALMACENID = :ALMACENID
     AND PRODUCTOID = :PRODUCTO_ID
   GROUP BY ALMACENID, PRODUCTOID
   INTO :EXISTENCIAINICIAL, :FECHAINICIAL;

   -- Calcular existencia incial antes de la fecha del rango.
   IF (:FECHAINI > :FECHAINICIAL) THEN
   BEGIN
      SELECT
         COALESCE(SUM(TD.SENTIDOINVENTARIO * K.CANTIDAD), 0.00)
      FROM KARDEX K
         LEFT JOIN DOCTO D
            ON D.ID = K.DOCTOID
         LEFT JOIN TIPODOCTO TD
            ON TD.ID = D.TIPODOCTOID
      WHERE K.PRODUCTOID = :PRODUCTO_ID
        AND K.FECHA < :FECHAINI
        AND K.ALMACENID = :ALMACENID
      INTO :CANTIDADMOVTOSINICIAL;
   END
   ELSE
   BEGIN
      CANTIDADMOVTOSINICIAL = 0;
   END

   numero = 0;
   productoid = :producto_id;
   CANTIDADINI= :EXISTENCIAINICIAL + :CANTIDADMOVTOSINICIAL;



   SELECT
      count(*) cuenta,
      sum(case TD.SENTIDOINVENTARIO  when 1 then  K.CANTIDAD else 0 end) cantidadentradas  ,
      sum(case TD.SENTIDOINVENTARIO  when -1 then  K.CANTIDAD else 0 end) cantidadsalidas
   FROM KARDEX K
      LEFT JOIN DOCTO D
         ON D.ID = K.DOCTOID
      LEFT JOIN TIPODOCTO TD
         ON TD.ID = D.TIPODOCTOID
      LEFT JOIN PRODUCTO P
         ON P.ID = K.PRODUCTOID/*K.PRODUCTOID*/
      LEFT JOIN SUCURSAL S
         ON S.ID = D.SUCURSALID
   WHERE K.PRODUCTOID = :PRODUCTO_ID
     AND K.FECHA BETWEEN :FECHAINI AND :FECHAFIN
   INTO
      :cuenta, :cantidadentradas, :cantidadsalidas   ;  


       CANTIDADFIN= :CANTIDADINI + :cantidadentradas - :cantidadsalidas;

      numero = :numero + :cuenta;
       if(:cuenta>0) then
       begin
        suspend;
       end
   END

   if (:NUMERO = 0) then
   BEGIN
    productoid = 0; 
    productoclave = '--';
    productodescripcion = '-- sin movimientos --';  
    cantidadini = 0;
    cantidadentradas = 0; 
    cantidadsalidas = 0;
    cantidadfin = 0;
    productoprecio = 0;
    productocostorepo = 0;
    --suspend; --sin suspend es mejor, no regresa renglon falso
   END


END