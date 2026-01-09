CREATE OR ALTER TRIGGER MOVTO_AD20 FOR MOVTO
ACTIVE AFTER DELETE POSITION 20
AS        
declare variable TIPODOCTOID type of D_FK;
declare variable ALMACENID type of D_FK;   
declare variable cuentaproductoalmacen INTEGER;
declare variable CURRENTENPROCESOSALIDA INTEGER;
declare variable ERRORCODE D_ERRORCODE;
begin
  /* Trigger text */

   IF ((OLD.ESTATUSMOVTOID = 0 AND OLD.registroprocesosalida = 'S') )THEN
   BEGIN
        SELECT TIPODOCTOID, ALMACENID FROM DOCTO WHERE ID = OLD.DOCTOID INTO :TIPODOCTOID, :ALMACENID;
         /*Quita la canitdad de pedidos*/
         IF(:tipodoctoid IN (21,25,12,31, 501, 121) ) THEN
         BEGIN
            UPDATE PRODUCTO
            SET ENPROCESODESALIDA = IIF(((COALESCE(ENPROCESODESALIDA,0) - (COALESCE(OLD.CANTIDAD,0) - COALESCE(OLD.enprocesopartes,0))) > 0),(COALESCE(ENPROCESODESALIDA,0) - (COALESCE(OLD.CANTIDAD,0) - COALESCE(OLD.enprocesopartes,0))),0)
            WHERE ID = OLD.PRODUCTOID ;


            SELECT COUNT(*) FROM PRODUCTOALMACEN WHERE PRODUCTOID = OLD.PRODUCTOID AND ALMACENID = :ALMACENID INTO :cuentaproductoalmacen;
            IF(:cuentaproductoalmacen > 0) THEN
            BEGIN

                SELECT ENPROCESODESALIDA FROM  PRODUCTOALMACEN WHERE PRODUCTOID = OLD.PRODUCTOID AND ALMACENID = :ALMACENID
                INTO  :CURRENTENPROCESOSALIDA ;


                IF((COALESCE(:CURRENTENPROCESOSALIDA,0) - (COALESCE(OLD.CANTIDAD,0) - COALESCE(OLD.enprocesopartes,0))) <= 0) THEN
                BEGIN
                     DELETE FROM PRODUCTOALMACEN
                     WHERE PRODUCTOID = OLD.PRODUCTOID AND ALMACENID = :ALMACENID;
                END
                ELSE
                BEGIN

                    UPDATE PRODUCTOALMACEN
                    SET ENPROCESODESALIDA = IIF(((COALESCE(ENPROCESODESALIDA,0) - (COALESCE(OLD.CANTIDAD,0) - COALESCE(OLD.enprocesopartes,0))) > 0),(COALESCE(ENPROCESODESALIDA,0) - (COALESCE(OLD.CANTIDAD,0) - COALESCE(OLD.enprocesopartes,0))),0)
                    WHERE PRODUCTOID = OLD.PRODUCTOID AND ALMACENID = :ALMACENID;
                END
            END


            IF(COALESCE(OLD.enprocesopartes,0) > 0 ) THEN
            BEGIN
                  SELECT ERRORCODE FROM  KIT_ADDENPROCESODESALIDA (
                        OLD.PRODUCTOID, :ALMACENID,  COALESCE(OLD.enprocesopartes,0) * -1)
                    INTO :ERRORCODE;

                   UPDATE PRODUCTO SET ENPROCESOPARTESSALIDA =  IIF(((COALESCE(ENPROCESOPARTESSALIDA,0) - COALESCE(OLD.enprocesopartes,0)) > 0),(COALESCE(ENPROCESOPARTESSALIDA,0) -  COALESCE(OLD.enprocesopartes,0)),0)
                   WHERE ID = OLD.PRODUCTOID ;
            END


         END
     END
end