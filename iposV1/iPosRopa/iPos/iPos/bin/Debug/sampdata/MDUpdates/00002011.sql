create or alter procedure PRODUCTO_PRECIOS
as
declare variable UTILIDAD D_PORCENTAJE;
declare variable PRODUCTOID D_FK;
declare variable PRECIO1 D_PRECIO;
declare variable PRECIO2 D_PRECIO;
declare variable PRECIO3 D_PRECIO;
declare variable PRECIO4 D_PRECIO;
declare variable PRECIO5 D_PRECIO;
declare variable APRECIO1 D_PRECIO;
declare variable APRECIO2 D_PRECIO;
declare variable APRECIO3 D_PRECIO;
declare variable APRECIO4 D_PRECIO;
declare variable APRECIO5 D_PRECIO;
declare variable PRODUCTOPRECIOID D_FK;
declare variable ESVENDEDORMOVIL D_BOOLCN;
BEGIN
   SELECT COALESCE(UTILIDAD, 0.0000)  , COALESCE(ESVENDEDORMOVIL ,'N')
   FROM PARAMETRO
   INTO :UTILIDAD, :ESVENDEDORMOVIL;

   FOR SELECT ID
   FROM PRODUCTO
   INTO :PRODUCTOID
   DO
   BEGIN
      IF (:UTILIDAD > 0.0000) THEN
      BEGIN
         UPDATE
            PRODUCTO
         SET
            PRECIO1 = PRECIO1 * (100.00 + :UTILIDAD) / 100.00,
            PRECIO2 = PRECIO2 * (100.00 + :UTILIDAD) / 100.00,
            PRECIO3 = PRECIO3 * (100.00 + :UTILIDAD) / 100.00
         WHERE
            ID = :PRODUCTOID;
      END

      SELECT ID, PRECIO1, PRECIO2, PRECIO3
      FROM PRODUCTOPRECIO
      WHERE PRODUCTOID = :PRODUCTOID
      INTO :PRODUCTOPRECIOID, :PRECIO1, :PRECIO2, :PRECIO3;

      IF (:PRODUCTOPRECIOID > 0) THEN
      BEGIN
         UPDATE
            PRODUCTO
         SET
            PRECIO1 = :PRECIO1,
            PRECIO2 = :PRECIO2,
            PRECIO3 = :PRECIO3
         WHERE
            ID = :PRODUCTOID;
      END

      -- tomar el precio nuevo de producto.
      select
        precio1, precio2, precio3, precio4, precio5
      from producto
      where id = :PRODUCTOID
      into
        :precio1, :precio2, :precio3, :precio4, :precio5;

      -- tomar el precio anterior de productopreciolog.
      select first 1
        precio1, precio2, precio3, precio4, precio5
      from productopreciolog
      where productoid = :PRODUCTOID
      order by fecha desc
      into
        :aprecio1, :aprecio2, :aprecio3, :aprecio4, :aprecio5;

      if (
       (abs(precio1 - aprecio1) >= 0.01) OR
       (abs(precio2 - aprecio2) >= 0.01) OR
       (abs(precio3 - aprecio3) >= 0.01) OR
       (abs(precio4 - aprecio4) >= 0.01) OR
       (abs(precio5 - aprecio5) >= 0.01)
      ) then
      BEGIN

      IF(:ESVENDEDORMOVIL = 'S') THEN
      BEGIN

        UPDATE OR INSERT INTO PRODUCTOPRECIOLOG
          (FECHA, PRODUCTOID, PRECIO1, PRECIO2, PRECIO3, PRECIO4, PRECIO5)
        VALUES 
          (CURRENT_DATE, :PRODUCTOID, :PRECIO1, :PRECIO2, :PRECIO3, :PRECIO4, :PRECIO5)
        MATCHING (FECHA, PRODUCTOID, PRECIO1, PRECIO2, PRECIO3, PRECIO4, PRECIO5);
      END
      ELSE
      BEGIN
      
        UPDATE OR INSERT INTO PRODUCTOPRECIOLOG
          (FECHA, PRODUCTOID, PRECIO1, PRECIO2, PRECIO3, PRECIO4, PRECIO5)
        VALUES 
          (CURRENT_DATE, :PRODUCTOID, :PRECIO1, :PRECIO2, :PRECIO3, :PRECIO4, :PRECIO5)
        MATCHING (FECHA, PRODUCTOID);
      END

        UPDATE PRODUCTO
        SET fechacambioprecio = current_date
        WHERE id = :PRODUCTOID;
      END


   END
END