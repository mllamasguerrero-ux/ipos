UPDATE MOVTO SET
 MOVTO.TASAIVA = (select first 1 coalesce(producto.tasaiva,0) from PRODUCTO
                       where producto.id = MOVTO.PRODUCTOID);
