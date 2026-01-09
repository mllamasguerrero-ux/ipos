CREATE OR ALTER PROCEDURE GET_PRECIOS_PRODUCTO_LISTA (
    productoid d_fk,
    personaid d_fk,
    cantidad d_cantidad,
    sucursaltid d_fk)
returns (
    preciolista d_precio,
    preciotraspaso d_precio,
    preciominimo d_precio,
    costo d_costo,
    errorcode d_errorcode)
as
declare variable precio1 d_precio;
declare variable precio2 d_precio;
declare variable precio3 d_precio;
declare variable precio4 d_precio;
declare variable precio5 d_precio;
declare variable listaprecio varchar(1);
BEGIN
   IF ((:PRODUCTOID IS NULL) OR (:PRODUCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1048;
      SUSPEND;
      EXIT;
   END


      --Costo 
      SELECT PRECIO1, PRECIO2, PRECIO3, PRECIO4, PRECIO5,COSTOPROMEDIO
      FROM PRODUCTO
      WHERE ID = :PRODUCTOID
      INTO :PRECIO1, :PRECIO2, :PRECIO3, :PRECIO4, :PRECIO5, :COSTO;




      --precio lista
      SELECT PRECIO FROM GET_PRODUCTO_PRECIO (:PRODUCTOID,
                                         :personaid,
                         :cantidad) 
      into :PRECIOLISTA;   




      --precio minimo
      SELECT PRECIOMINIMO
      FROM GET_PRECIOMINIMO(:PRODUCTOID)
      INTO :PRECIOMINIMO;




      --precio traspaso
      if( :SUCURSALTID  is not NULL) then
      begin
        SELECT CAST(COALESCE(LISTA_PRECIO_TRASPASO, '4') AS CHAR(1))
        FROM SUCURSAL
        WHERE ID = :SUCURSALTID
        INTO :LISTAPRECIO;


        IF (:LISTAPRECIO = '1') THEN
            precioTraspaso = :PRECIO1;
        ELSE IF (:LISTAPRECIO = '2') THEN
            precioTraspaso = PRECIO2;
        ELSE IF (:LISTAPRECIO = '3') THEN
            precioTraspaso = PRECIO3;
        ELSE IF (:LISTAPRECIO = '4') THEN
            precioTraspaso = PRECIO4;
        ELSE IF (:LISTAPRECIO = '5') THEN
            precioTraspaso = PRECIO5;
        ELSE 
            precioTraspaso = PRECIO4;
       end
       else
        begin
            precioTraspaso = NULL;
        end

      SUSPEND;



END