CREATE OR ALTER trigger movto_ai_20 for movto
active after insert position 20
AS
   DECLARE VARIABLE ERRORCODE D_ERRORCODE;
   DECLARE VARIABLE INVENTARIABLE D_BOOLCS;
   declare variable TIPODOCTOID D_FK;    
   declare variable ALMACENID type of D_FK;
   declare variable cuentaproductoalmacen INTEGER;
   declare variable PRODUCTOCLAVE D_CLAVE;
BEGIN
   IF ((NEW.ESTATUSMOVTOID IS NULL) OR (NEW.ESTATUSMOVTOID = 0)) THEN
   BEGIN    
      IF(NEW.registroprocesosalida = 'S' ) THEN
      BEGIN
            UPDATE PRODUCTO
            SET ENPROCESODESALIDA = COALESCE(ENPROCESODESALIDA,0) + (COALESCE(NEW.CANTIDAD,0) - COALESCE(NEW.enprocesopartes,0))
            WHERE ID = NEW.PRODUCTOID;

            SELECT  ALMACENID FROM DOCTO WHERE ID = NEW.DOCTOID INTO  :ALMACENID;

           IF((COALESCE(NEW.CANTIDAD,0) - COALESCE(NEW.enprocesopartes,0)) > 0) THEN
           BEGIN

                SELECT COUNT(*) FROM PRODUCTOALMACEN WHERE PRODUCTOID = NEW.PRODUCTOID AND ALMACENID = :ALMACENID INTO :cuentaproductoalmacen;
                IF(:cuentaproductoalmacen > 0) THEN
                BEGIN
            
                    UPDATE PRODUCTOALMACEN
                    SET ENPROCESODESALIDA = COALESCE(ENPROCESODESALIDA,0) + (COALESCE(NEW.CANTIDAD,0) - COALESCE(NEW.enprocesopartes,0))
                    WHERE PRODUCTOID = NEW.PRODUCTOID AND ALMACENID = :ALMACENID;
                END
                ELSE
                BEGIN

                    INSERT INTO PRODUCTOALMACEN(ACTIVO,PRODUCTOCLAVE, PRODUCTOID, ALMACENID, ENPROCESODESALIDA)
                    VALUES('S',NEW.claveprod,new.productoid, :almacenid ,(COALESCE(NEW.CANTIDAD,0) - COALESCE(NEW.enprocesopartes,0)));
                END
           END


            
            IF(COALESCE(new.enprocesopartes,0) > 0 ) THEN
            BEGIN
                  SELECT ERRORCODE FROM  KIT_ADDENPROCESODESALIDA (
                        NEW.PRODUCTOID, :ALMACENID,  COALESCE(NEW.enprocesopartes,0) )
                    INTO :ERRORCODE;

                  UPDATE PRODUCTO
                  SET ENPROCESOPARTESSALIDA = COALESCE(ENPROCESOPARTESSALIDA,0) + COALESCE(NEW.enprocesopartes,0)
                  WHERE ID = NEW.PRODUCTOID;

            END

      END
      EXIT;
   END

   --IF ((NEW.TOTAL IS NULL) OR (NEW.TOTAL = 0)) THEN
   IF ((NEW.CANTIDAD IS NULL) OR (NEW.CANTIDAD = 0)) THEN
   BEGIN

      EXIT;
   END

    -- Determinar si es inventariable para registrar kardex o no.
   SELECT COALESCE(P.INVENTARIABLE, 'S')
   FROM PRODUCTO P
   WHERE P.ID = NEW.PRODUCTOID
   INTO :INVENTARIABLE;




    -- Solo si es inventariable.
   IF (:INVENTARIABLE = 'S') THEN
   BEGIN
   
   SELECT TIPODOCTOID FROM DOCTO WHERE ID = nEW.DOCTOID INTO :TIPODOCTOID;

      SELECT ERRORCODE FROM KARDEX_INSERT (
         NEW.DOCTOID,
         NEW.ID,
         NEW.PRODUCTOID,
         NEW.LOTE,
         NEW.FECHAVENCE,
         CASE when (:TIPODOCTOID IN (41,32)) THEN NEW.cantidadsurtida ELSE NEW.CANTIDAD END,
         NEW.PRECIO,
         NEW.COSTO ,
         NEW.esapartado,
         NEW.LOTEIMPORTADO
      ) INTO ERRORCODE;
   END
END