create or alter procedure GET_INVENTARIOFISICO_INFO (
    PRODUCTO varchar(255),
    LOTE D_LOTE,
    FECHAVENCE D_FECHAVENCE,
    DOCTOID D_FK,
    ALMACENID D_FK)
returns (
    PRODUCTOID D_FK,
    PRODUCTONOMBRE D_NOMBRE,
    PRODUCTODESCRIPCION varchar(40),
    PRODUCTOLOTE D_LOTE,
    CANTIDADTEORICA D_CANTIDAD,
    CANTIDADFISICA D_CANTIDAD,
    CANTIDADDIFERENCIA D_CANTIDAD,
    APARTADOS D_CANTIDAD,
    PZACAJA D_CANTIDAD,
    ERRORCODE D_ERRORCODE)
as
BEGIN
   
    PRODUCTONOMBRE = '';
    PRODUCTODESCRIPCION = '';
    PRODUCTOLOTE  = :LOTE;
    CANTIDADTEORICA = 0;
    CANTIDADFISICA  = 0;
    CANTIDADDIFERENCIA  = 0;
    APARTADOS = 0;
    PZACAJA = 0;

   selecT ID,NOMBRE, DESCRIPCION1
   FROM PRODUCTO WHERE EAN = :PRODUCTO
   INTO :PRODUCTOID, :PRODUCTONOMBRE, :PRODUCTODESCRIPCION;

   if(:PRODUCTOID is null) then
   BEGIN
          selecT ID,NOMBRE, DESCRIPCION1, PZACAJA
         FROM PRODUCTO WHERE CLAVE = :PRODUCTO
         INTO :PRODUCTOID, :PRODUCTONOMBRE, :PRODUCTODESCRIPCION, :PZACAJA;
   END
  
   if(:PRODUCTOID is null) then
   BEGIN
      ERRORCODE = 1070;
      SUSPEND;
      EXIT;
   END

   if(:DOCTOID IS NOT NULL) then
   BEGIN
        select COALESCE(sum(cantidadsurtida),0) from movto
        where doctoid = :DOCTOID and
              productoid = :PRODUCTOID and
              coalesce(lote,'') = coalesce(:lote,'') AND
              coalesce(fechavence,current_date) = coalesce(:FECHAVENCE,current_date)
        into :CANTIDADFISICA;

   END
   else
   BEGIN
         CANTIDADFISICA = 0;
   END


   
        select COALESCE(sum(cantidad),0) from inventario
        where  productoid = :PRODUCTOID and
              coalesce(lote,'') = coalesce(:lote,'') AND
              coalesce(fechavence,current_date) = coalesce(:FECHAVENCE,current_date) and
              ESAPARTADO = 'S'
              AND ALMACENID = :ALMACENID
        into :APARTADOS;


        select COALESCE(sum(cantidad),0) from inventario
        where  productoid = :PRODUCTOID and
              coalesce(lote,'') = coalesce(:lote,'') AND
              coalesce(fechavence,current_date) = coalesce(:FECHAVENCE,current_date)  
              AND ALMACENID = :ALMACENID
        into :CANTIDADTEORICA;

        
        CANTIDADDIFERENCIA = :CANTIDADFISICA - :CANTIDADTEORICA;


   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1016;
      SUSPEND;
   END 


END