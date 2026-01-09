create or alter procedure GET_PRODUCTO_PRECIO (
    PRODUCTOID D_FK,
    PERSONAID D_FK,
    CANTIDAD D_CANTIDAD)
returns (
    PRECIO D_PRECIO,
    ERRORCODE D_ERRORCODE)
as
declare variable PRECIO1 D_PRECIO;
declare variable PRECIO2 D_PRECIO;
declare variable PRECIO3 D_PRECIO;
declare variable PRECIO4 D_PRECIO;
declare variable PRECIO5 D_PRECIO;
declare variable LISTAPRECIO varchar(1);
declare variable LIMITEPRECIO2 D_CANTIDAD;
declare variable U_EMPAQUE D_CANTIDAD;
declare variable PZACAJA D_CANTIDAD;
declare variable UNIDAD varchar(10);
declare variable INI_MAYO D_CANTIDAD;
declare variable MAYOKGS char(1);
declare variable LISTAPRECIOCLIENTE varchar(1);
declare variable CAMBIARPRECIOXUEMPAQUE D_BOOLCN;
declare variable CAMBIARPRECIOXPZACAJA D_BOOLCN;
declare variable LISTAPRECIOXUEMPAQUE D_FK;
declare variable LISTAPRECIOXPZACAJA D_FK;
declare variable LISTAPRECIOINIMAYO D_FK;
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
   SELECT CAST(COALESCE(LISTAPRECIOID, 1) AS CHAR(1))
   FROM PERSONA
   WHERE ID = :PERSONAID
   INTO :LISTAPRECIOCLIENTE;

   select first 1 CAST(COALESCE(LISTA_PRECIO_DEF, 1) AS CHAR(1)),
   CAMBIARPRECIOXUEMPAQUE, CAMBIARPRECIOXPZACAJA ,
   LISTAPRECIOXUEMPAQUE, LISTAPRECIOXPZACAJA , LISTAPRECIOINIMAYO
   FROM parametro
   INTO :LISTAPRECIO, :CAMBIARPRECIOXUEMPAQUE, :CAMBIARPRECIOXPZACAJA
   , :LISTAPRECIOXUEMPAQUE, :LISTAPRECIOXPZACAJA , :LISTAPRECIOINIMAYO ;

   -- Tomar los precios y el LimitePrecio2 del Producto.
   SELECT PRECIO1, PRECIO2, PRECIO3, PRECIO4, PRECIO5, COALESCE(LIMITEPRECIO2, 0.00)
     ,COALESCE(U_EMPAQUE ,0), COALESCE(PZACAJA,0), COALESCE(UNIDAD, ' '), COALESCE(INI_MAYO,0) , COALESCE(MAYOKGS,'N')
   FROM PRODUCTO
   WHERE ID = :PRODUCTOID
   INTO :PRECIO1, :PRECIO2, :PRECIO3, :PRECIO4, :PRECIO5, :LIMITEPRECIO2,
      :U_EMPAQUE, :PZACAJA , :UNIDAD ,  :INI_MAYO, :MAYOKGS;


   -- Para la lista de precio1
   PRECIO = :PRECIO1;


   if(:CANTIDAD >= :LIMITEPRECIO2  AND coalesce(:LIMITEPRECIO2,0) > 1)then
   begin
         PRECIO = :PRECIO2;
   end


   if (:PZACAJA > 1  AND :LISTAPRECIO = '1' AND :CANTIDAD>= :U_EMPAQUE AND :U_EMPAQUE>1  AND :CAMBIARPRECIOXUEMPAQUE = 'S' ) then
   begin
            --PRECIO = :PRECIO2;
            PRECIO = (case when :LISTAPRECIOXUEMPAQUE = 1 then :PRECIO1
              when :LISTAPRECIOXUEMPAQUE = 2 then  :PRECIO2
              when :LISTAPRECIOXUEMPAQUE = 3 then  :PRECIO3
              when :LISTAPRECIOXUEMPAQUE = 4 then  :PRECIO4
              when :LISTAPRECIOXUEMPAQUE = 5 then  :PRECIO5
              else  :PRECIO2
            end);
   end
   if (:PZACAJA > 1  AND :LISTAPRECIO = '1' AND :CANTIDAD>= :PZACAJA   AND :CAMBIARPRECIOXPZACAJA = 'S' ) then
   begin
            --PRECIO = :PRECIO3;  
            PRECIO = (case when :LISTAPRECIOXPZACAJA = 1 then :PRECIO1
              when :LISTAPRECIOXPZACAJA = 2 then  :PRECIO2
              when :LISTAPRECIOXPZACAJA = 3 then  :PRECIO3
              when :LISTAPRECIOXPZACAJA = 4 then  :PRECIO4
              when :LISTAPRECIOXPZACAJA = 5 then  :PRECIO5
              else  :PRECIO3
            end);
   end
   if(trim(:UNIDAD) = 'KG' /*AND :LISTAPRECIO = '1'*/ AND :CANTIDAD>= :INI_MAYO AND :MAYOKGS = 'S') then
   begin
            --PRECIO = :PRECIO3;  
            PRECIO = (case when :LISTAPRECIOINIMAYO = 1 then :PRECIO1
              when :LISTAPRECIOINIMAYO = 2 then  :PRECIO2
              when :LISTAPRECIOINIMAYO = 3 then  :PRECIO3
              when :LISTAPRECIOINIMAYO = 4 then  :PRECIO4
              when :LISTAPRECIOINIMAYO = 5 then  :PRECIO5
              else  :PRECIO3
            end);
   end


   IF (:LISTAPRECIOCLIENTE = '2' AND :PRECIO > :PRECIO2 ) THEN
      PRECIO = :PRECIO2;
   IF (:LISTAPRECIOCLIENTE = '3' AND :PRECIO > :PRECIO3 ) THEN
      PRECIO = :PRECIO3;
   ELSE IF (:LISTAPRECIOCLIENTE = '4' AND :PRECIO > :PRECIO4) THEN
      PRECIO = :PRECIO4;
   ELSE IF (:LISTAPRECIOCLIENTE = '5' AND :PRECIO > :PRECIO5) THEN
      PRECIO = :PRECIO5;




   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1051;
      SUSPEND;
   END 
END