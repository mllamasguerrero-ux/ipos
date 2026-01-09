create or alter procedure GET_PRECIO_AJUSTEINVENTARIO (
    PRODUCTOID D_FK)
returns (
    PRECIODIFINVENTARIO D_PRECIO,
    ERRORCODE D_ERRORCODE)
as
declare variable PRECIOAJUSTEDIFINV D_STDTEXT_SHORT;
BEGIN
   ERRORCODE = 0;

   SELECT PRECIOAJUSTEDIFINV FROM PARAMETRO INTO :PRECIOAJUSTEDIFINV;


   SELECT
        CASE COALESCE(:PRECIOAJUSTEDIFINV, '')
                              WHEN 'PRECIO 1'  THEN PRODUCTO.precio1
                              WHEN 'PRECIO 2'  THEN PRODUCTO.precio2
                              WHEN 'PRECIO 3'  THEN PRODUCTO.precio3
                              WHEN 'PRECIO 4'  THEN PRODUCTO.precio4
                              WHEN 'PRECIO 5'  THEN PRODUCTO.precio5 
                              WHEN 'COSTO ULTIMO'  THEN PRODUCTO.costoultimo
                              WHEN 'REPOSICION'  THEN PRODUCTO.costoreposicion
                              WHEN 'SIN PRECIO'  THEN PRODUCTO.precio1
                              ELSE PRODUCTO.PRECIO1
          END  PRECIODIFINVENTARIO
          FROM PRODUCTO WHERE ID = :PRODUCTOID
          INTO :PRECIODIFINVENTARIO ;


   ERRORCODE = 0;
   PRECIODIFINVENTARIO = COALESCE(:PRECIODIFINVENTARIO, 0.00);

   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1001;
      PRECIODIFINVENTARIO = 0.0;
      SUSPEND;
      EXIT;
   END
      
END