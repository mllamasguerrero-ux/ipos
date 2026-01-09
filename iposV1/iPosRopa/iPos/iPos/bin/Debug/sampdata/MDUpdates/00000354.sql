CREATE OR ALTER PROCEDURE GET_PRODUCTO_PRECIO (
    productoid d_fk,
    personaid d_fk,
    cantidad d_cantidad)
returns (
    precio d_precio,
    errorcode d_errorcode)
as
declare variable precio1 d_precio;
declare variable precio2 d_precio;
declare variable precio3 d_precio;
declare variable precio4 d_precio;
declare variable precio5 d_precio;
declare variable listaprecio varchar(1);
declare variable limiteprecio2 d_cantidad;
declare variable u_empaque d_cantidad;
declare variable pzacaja d_cantidad;
declare variable unidad varchar(10);
declare variable ini_mayo d_cantidad;
declare variable mayokgs char(1);
BEGIN
   IF ((:PRODUCTOID IS NULL) OR (:PRODUCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1048;
      SUSPEND;
      EXIT;
   END
   
   IF ((:PERSONAID IS NULL) OR (:PERSONAID = 0)) THEN
   BEGIN
      ERRORCODE = 1049;
      SUSPEND;
      EXIT;
   END
   
   IF ((:CANTIDAD IS NULL) OR (:CANTIDAD = 0)) THEN
   BEGIN
      ERRORCODE = 1050;
      SUSPEND;
      EXIT;
   END
   
   -- Tomar la lista de precios correspondiente a la persona.
   -- Null, 1..5. Para Precio1, ... Precio5
   /*SELECT CAST(COALESCE(LISTAPRECIOID, 1) AS CHAR(1))
   FROM PERSONA
   WHERE ID = :PERSONAID
   INTO :LISTAPRECIO;*/
   select first 1 CAST(COALESCE(LISTA_PRECIO_DEF, 1) AS CHAR(1))
   FROM parametro
   INTO :LISTAPRECIO;

   -- Tomar los precios y el LimitePrecio2 del Producto.
   SELECT PRECIO1, PRECIO2, PRECIO3, PRECIO4, PRECIO5, COALESCE(LIMITEPRECIO2, 0.00)
     ,COALESCE(U_EMPAQUE ,0), COALESCE(PZACAJA,0), COALESCE(UNIDAD, ' '), COALESCE(INI_MAYO,0) , COALESCE(MAYOKGS,'N')
   FROM PRODUCTO
   WHERE ID = :PRODUCTOID
   INTO :PRECIO1, :PRECIO2, :PRECIO3, :PRECIO4, :PRECIO5, :LIMITEPRECIO2,
      :U_EMPAQUE, :PZACAJA , :UNIDAD ,  :INI_MAYO, :MAYOKGS;


   -- Para la lista de precio1
   PRECIO = :PRECIO1;

   if (:PZACAJA > 1  AND :LISTAPRECIO = '1' AND :CANTIDAD>= :U_EMPAQUE AND :U_EMPAQUE>1) then
            PRECIO = :PRECIO2;
   if (:PZACAJA > 1  AND :LISTAPRECIO = '1' AND :CANTIDAD>= :PZACAJA) then
            PRECIO = :PRECIO3;
   if(trim(:UNIDAD) = 'KG' /*AND :LISTAPRECIO = '1'*/ AND :CANTIDAD>= :INI_MAYO AND :MAYOKGS = 'S') then
            PRECIO = :PRECIO3;

   IF (:LISTAPRECIO = '3') THEN
      PRECIO = PRECIO3;
   ELSE IF (:LISTAPRECIO = '4') THEN
      PRECIO = PRECIO4;
   ELSE IF (:LISTAPRECIO = '5') THEN
      PRECIO = PRECIO5;




   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1051;
      SUSPEND;
   END 
END