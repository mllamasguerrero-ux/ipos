CREATE OR ALTER trigger producto_au_10 for producto
active after update position 10
AS
declare variable FECHAPRECIO1 D_FECHA;
BEGIN
     
      if (
       (abs(COALESCE(new.precio1,0) - COALESCE(old.precio1,0)) >= 0.01) OR
       (abs(COALESCE(new.precio2,0) - COALESCE(old.precio2,0)) >= 0.01) OR
       (abs(COALESCE(new.precio3,0) - COALESCE(old.precio3,0)) >= 0.01) OR
       (abs(COALESCE(new.precio4,0) - COALESCE(old.precio4,0)) >= 0.01) OR
       (abs(COALESCE(new.precio5,0) - COALESCE(old.precio5,0)) >= 0.01) OR
       (abs(COALESCE(new.costoreposicion,0) - COALESCE(old.costoreposicion,0)) >= 0.01)
      ) then
      BEGIN


         FECHAPRECIO1 = NULL;
        IF( (abs(COALESCE(new.precio1,0) - COALESCE(old.precio1,0)) >= 0.01) ) THEN
        BEGIN
            FECHAPRECIO1 = CURRENT_DATE;
        END
        ELSE
        BEGIN
            SELECT FECHAPRECIO1 FROM PRODUCTOPRECIOLOG
            WHERE FECHA = CURRENT_DATE AND PRODUCTOID = new.id
            INTO :FECHAPRECIO1;
        END
        FECHAPRECIO1 = COALESCE(:FECHAPRECIO1,'01.01.2000');
      
        UPDATE OR INSERT INTO PRODUCTOPRECIOLOG
          (FECHA, PRODUCTOID, PRECIO1, PRECIO2, PRECIO3, PRECIO4, PRECIO5, FECHAPRECIO1, COSTOREPOSICION)
        VALUES 
          (CURRENT_DATE, new.ID, new.PRECIO1, new.PRECIO2, new.PRECIO3, new.PRECIO4, new.PRECIO5, :FECHAPRECIO1, new.COSTOREPOSICION)
        MATCHING (FECHA, PRODUCTOID);


      end




END