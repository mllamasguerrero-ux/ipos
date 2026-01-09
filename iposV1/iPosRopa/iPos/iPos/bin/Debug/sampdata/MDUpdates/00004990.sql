create or alter procedure PRODUCTO_PRECIOS_MATRIZ
as
declare variable UTILIDAD D_PORCENTAJE;
declare variable PRODUCTOID D_FK;
declare variable PRECIO1 D_PRECIO;
declare variable PRECIO2 D_PRECIO;
declare variable PRECIO3 D_PRECIO;
declare variable PRECIO4 D_PRECIO;
declare variable PRECIO5 D_PRECIO;
declare variable COSTOREPOSICION D_COSTO;
declare variable APRECIO1 D_PRECIO;
declare variable APRECIO2 D_PRECIO;
declare variable APRECIO3 D_PRECIO;
declare variable APRECIO4 D_PRECIO;
declare variable APRECIO5 D_PRECIO;
declare variable ACOSTOREPOSICION D_COSTO;
declare variable PRODUCTOPRECIOID D_FK;
declare variable ESVENDEDORMOVIL D_BOOLCN;
declare variable FECHAPRECIO1 D_FECHA;
BEGIN

   FOR SELECT ID
   FROM PRODUCTO
   INTO :PRODUCTOID
   DO
   BEGIN


      -- tomar el precio nuevo de producto.
      select
        precio1, precio2, precio3, precio4, precio5 , costoreposicion
      from producto
      where id = :PRODUCTOID
      into
        :precio1, :precio2, :precio3, :precio4, :precio5, :costoreposicion;

      -- tomar el precio anterior de productopreciolog.
      select first 1
        precio1, precio2, precio3, precio4, precio5 , costoreposicion
      from productopreciolog
      where productoid = :PRODUCTOID
      order by fecha desc
      into
        :aprecio1, :aprecio2, :aprecio3, :aprecio4, :aprecio5, :acostoreposicion;

      if (
       (abs(COALESCE(precio1,0) - COALESCE(aprecio1,0)) >= 0.01) OR
       (abs(COALESCE(precio2,0) - COALESCE(aprecio2,0)) >= 0.01) OR
       (abs(COALESCE(precio3,0) - COALESCE(aprecio3,0)) >= 0.01) OR
       (abs(COALESCE(precio4,0) - COALESCE(aprecio4,0)) >= 0.01) OR
       (abs(COALESCE(precio5,0) - COALESCE(aprecio5,0)) >= 0.01) OR
       (abs(COALESCE(costoreposicion,0) - COALESCE(acostoreposicion,0)) >= 0.01)
      ) then
      BEGIN





        FECHAPRECIO1 = NULL;
        IF( (abs(COALESCE(precio1,0) - COALESCE(aprecio1,0)) >= 0.01) ) THEN
        BEGIN
            FECHAPRECIO1 = CURRENT_DATE;
        END
        ELSE
        BEGIN
            SELECT FECHAPRECIO1 FROM PRODUCTOPRECIOLOG
            WHERE FECHA = CURRENT_DATE AND PRODUCTOID = :PRODUCTOID
            INTO :FECHAPRECIO1;
        END
        FECHAPRECIO1 = COALESCE(:FECHAPRECIO1,'01.01.2000');
      
        UPDATE OR INSERT INTO PRODUCTOPRECIOLOG
          (FECHA, PRODUCTOID, PRECIO1, PRECIO2, PRECIO3, PRECIO4, PRECIO5, FECHAPRECIO1, COSTOREPOSICION)
        VALUES 
          (CURRENT_DATE, :PRODUCTOID, :PRECIO1, :PRECIO2, :PRECIO3, :PRECIO4, :PRECIO5, :FECHAPRECIO1, :COSTOREPOSICION)
        MATCHING (FECHA, PRODUCTOID);

       END



   END
END