CREATE OR ALTER TRIGGER MOVTO_AU_20 FOR MOVTO
ACTIVE AFTER UPDATE POSITION 20
AS
   DECLARE VARIABLE ERRORCODE D_ERRORCODE;
   DECLARE VARIABLE INVENTARIABLE D_BOOLCS;
   
           declare variable TIPODOCTOID type of D_FK;
declare variable ALMACENID D_FK;
declare variable FECHA D_FECHA;
declare variable FECHAHORA D_TIMESTAMP;
declare variable cuentaproductoalmacen INTEGER;
declare variable sumaenprocesodesalidaalmacen d_cantidad;
BEGIN



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
   
      --INSERT INTO TRAZA(VALOR) VALUES ('v ' || cast (coalesce(NEW.ESTATUSMOVTOID,9) as varchar(10)) || cast (coalesce(OLD.ESTATUSMOVTOID,9) as varchar(10)) );

      IF ((OLD.ESTATUSMOVTOID = 0) AND (NEW.ESTATUSMOVTOID = 1))THEN
      BEGIN


         SELECT TIPODOCTOID FROM DOCTO WHERE ID = nEW.DOCTOID INTO :TIPODOCTOID;

         /**/

         SELECT ERRORCODE FROM KARDEX_INSERT (
            NEW.DOCTOID,
            NEW.ID,
            NEW.PRODUCTOID,
            NEW.LOTE,
            NEW.FECHAVENCE,
            CASE when (:TIPODOCTOID = 41) THEN NEW.cantidadsurtida ELSE NEW.CANTIDAD END,
            NEW.PRECIO,
            NEW.COSTO ,
            'N'--NEW.ESAPARTADO
         ) INTO ERRORCODE;


         IF(nEW.ESAPARTADO = 'S') THEN
         BEGIN
         SELECT ERRORCODE FROM KARDEX_INSERT (
            NEW.DOCTOID,
            NEW.ID,
            NEW.PRODUCTOID,
            NEW.LOTE,
            NEW.FECHAVENCE,
            NEW.CANTIDAD,
            NEW.PRECIO,
            NEW.COSTO ,
            NEW.ESAPARTADO
         ) INTO ERRORCODE;
         END

         /*Quita la canitdad de pedidos*/
         IF(:tipodoctoid IN (21,25,12,31, 501) AND OLD.registroprocesosalida = 'S' ) THEN
         BEGIN

            UPDATE PRODUCTO
            SET ENPROCESODESALIDA = IIF(((COALESCE(ENPROCESODESALIDA,0) - (COALESCE(NEW.CANTIDAD,0) - COALESCE(NEW.enprocesopartes,0))) > 0),(COALESCE(ENPROCESODESALIDA,0) - (COALESCE(NEW.CANTIDAD,0) - COALESCE(NEW.enprocesopartes,0))),0)
            WHERE ID = NEW.PRODUCTOID ;

            SELECT  ALMACENID FROM DOCTO WHERE ID = NEW.DOCTOID INTO  :ALMACENID;

            SELECT COUNT(*),SUM(COALESCE(ENPROCESODESALIDA,0)) FROM PRODUCTOALMACEN WHERE PRODUCTOID = NEW.PRODUCTOID AND ALMACENID = :ALMACENID INTO :cuentaproductoalmacen, :sumaenprocesodesalidaalmacen;
            IF(:cuentaproductoalmacen > 0) THEN
            BEGIN

                IF((COALESCE(:sumaenprocesodesalidaalmacen,0) - (COALESCE(NEW.CANTIDAD,0) - COALESCE(NEW.enprocesopartes,0))) > 0) THEN
                BEGIN



                    UPDATE PRODUCTOALMACEN
                    SET ENPROCESODESALIDA = IIF(((COALESCE(ENPROCESODESALIDA,0) - (COALESCE(NEW.CANTIDAD,0) - COALESCE(NEW.enprocesopartes,0))) > 0),(COALESCE(ENPROCESODESALIDA,0) - (COALESCE(NEW.CANTIDAD,0) - COALESCE(NEW.enprocesopartes,0))),0)
                    WHERE PRODUCTOID = NEW.PRODUCTOID AND ALMACENID = :ALMACENID;
                END
                ELSE
                BEGIN

                    DELETE FROM productoalmacen  WHERE PRODUCTOID = NEW.PRODUCTOID AND ALMACENID = :ALMACENID;
                END
            END


            IF(COALESCE(NEW.enprocesopartes,0) > 0 ) THEN
            BEGIN
                  SELECT ERRORCODE FROM  KIT_ADDENPROCESODESALIDA (
                        NEW.PRODUCTOID, :ALMACENID,  COALESCE(NEW.enprocesopartes,0) * -1)
                    INTO :ERRORCODE;

                    
                  UPDATE PRODUCTO
                  SET ENPROCESOPARTESSALIDA = COALESCE(ENPROCESOPARTESSALIDA,0) - (COALESCE(NEW.enprocesopartes,0) )
                  WHERE ID = NEW.PRODUCTOID;
            END



         END

   END

   IF ((OLD.ESTATUSMOVTOID = 0) AND (NEW.ESTATUSMOVTOID = 0))THEN
   BEGIN
        --SELECT TIPODOCTOID FROM DOCTO WHERE ID = nEW.DOCTOID INTO :TIPODOCTOID;
        --IF(:tipodoctoid IN (21,25,12) AND COALESCE(NEW.CANTIDAD,0) <> COALESCE(OLD.CANTIDAD,0)) THEN
        IF(NEW.registroprocesosalida = 'S' ) THEN
        BEGIN
          
          SELECT  ALMACENID FROM DOCTO WHERE ID = NEW.DOCTOID INTO  :ALMACENID;

         IF( ((COALESCE(NEW.CANTIDAD,0) - COALESCE(NEW.enprocesopartes,0)) - (COALESCE(OLD.CANTIDAD,0) - COALESCE(OLD.enprocesopartes,0))) <> 0 ) THEN
         BEGIN
            UPDATE PRODUCTO
            SET ENPROCESODESALIDA = COALESCE(ENPROCESODESALIDA,0) + ((COALESCE(NEW.CANTIDAD,0) - COALESCE(NEW.enprocesopartes,0)) - (COALESCE(OLD.CANTIDAD,0) - COALESCE(OLD.enprocesopartes,0)))
            WHERE ID = NEW.PRODUCTOID;


            SELECT COUNT(*) FROM PRODUCTOALMACEN WHERE PRODUCTOID = NEW.PRODUCTOID AND ALMACENID = :ALMACENID INTO :cuentaproductoalmacen;
            IF(:cuentaproductoalmacen > 0) THEN
            BEGIN
            
                UPDATE PRODUCTOALMACEN
                SET ENPROCESODESALIDA = COALESCE(ENPROCESODESALIDA,0) + ((COALESCE(NEW.CANTIDAD,0) - COALESCE(NEW.enprocesopartes,0)) - (COALESCE(OLD.CANTIDAD,0) - COALESCE(OLD.enprocesopartes,0)))
                WHERE PRODUCTOID = NEW.PRODUCTOID AND ALMACENID = :ALMACENID;
            END
            ELSE
            BEGIN

                INSERT INTO PRODUCTOALMACEN(ACTIVO,PRODUCTOCLAVE, PRODUCTOID, ALMACENID, ENPROCESODESALIDA)
                VALUES('S',NEW.claveprod,new.productoid, :almacenid ,((COALESCE(NEW.CANTIDAD,0) - COALESCE(NEW.enprocesopartes,0)) - (COALESCE(OLD.CANTIDAD,0) - COALESCE(OLD.enprocesopartes,0))));
            END

          END
            
          IF(COALESCE(NEW.enprocesopartes,0) <> COALESCE(OLD.enprocesopartes,0)   ) THEN
          BEGIN
                  SELECT ERRORCODE FROM  KIT_ADDENPROCESODESALIDA (
                        NEW.PRODUCTOID, :ALMACENID,  (COALESCE(NEW.enprocesopartes,0) - COALESCE(OLD.enprocesopartes,0)) )
                    INTO :ERRORCODE;

                    
                  UPDATE PRODUCTO
                  SET ENPROCESOPARTESSALIDA = COALESCE(ENPROCESOPARTESSALIDA,0) + (COALESCE(NEW.enprocesopartes,0) - COALESCE(OLD.enprocesopartes,0))
                  WHERE ID = NEW.PRODUCTOID;
          END


        END
   END


      
      IF ( OLD.esapartado <> 'N' AND NEW.esapartado = 'N'  )THEN
      BEGIN
           IF((OLD.ESTATUSMOVTOID = 1 AND NEW.ESTATUSMOVTOID = 1) or (NEW.ESTATUSMOVTOID = 2)  ) THEN
           begin



              select TIPODOCTOID, FECHA, FECHAHORA, ALMACENID
              from DOCTO
              where ID = NEW.DOCTOID
              into :TIPODOCTOID, :FECHA, :FECHAHORA, :ALMACENID;


              IF (NEW.CANTIDADDEFACTURA > 0 ) THEN
              BEGIN
      
                  INSERT INTO KARDEX
                  (TIPODOCTOID, DOCTOID, MOVTOID, FECHA, FECHAHORA,
                   ALMACENID, PRODUCTOID, LOTE, FECHAVENCE, CANTIDAD, PRECIO, COSTO, ORIGENFISCALID, ESAPARTADO)
                  VALUES
                   (:TIPODOCTOID, NEW.DOCTOID, NEW.ID, :FECHA, :FECHAHORA,
                  :AlmacenId, NEW.PRODUCTOID, NEW.LOTE, NEW.FECHAVENCE, NEW.CANTIDADDEFACTURA*-1, NEW.PRECIO, NEW.COSTO,3, 'S');

              END

   
              IF (NEW.CANTIDADDEREMISION > 0 ) THEN
              BEGIN
      
                 INSERT INTO KARDEX
                 (TIPODOCTOID, DOCTOID, MOVTOID, FECHA, FECHAHORA,
                  ALMACENID, PRODUCTOID, LOTE, FECHAVENCE, CANTIDAD, PRECIO, COSTO, ORIGENFISCALID, ESAPARTADO)
                  VALUES          
                   (:TIPODOCTOID, NEW.DOCTOID, NEW.ID, :FECHA, :FECHAHORA,
                  :AlmacenId, NEW.PRODUCTOID, NEW.LOTE, NEW.FECHAVENCE, NEW.CANTIDADDEREMISION*-1, NEW.PRECIO, NEW.COSTO,2,  'S');

              END

     
              IF (NEW.CANTIDADDEINDEFINIDO > 0 ) THEN
              BEGIN
      
                  INSERT INTO KARDEX
                  (TIPODOCTOID, DOCTOID, MOVTOID, FECHA, FECHAHORA,
                  ALMACENID, PRODUCTOID, LOTE, FECHAVENCE, CANTIDAD, PRECIO, COSTO, ORIGENFISCALID, ESAPARTADO)
                  VALUES       
                   (:TIPODOCTOID, NEW.DOCTOID, NEW.ID, :FECHA, :FECHAHORA,
                  :AlmacenId, NEW.PRODUCTOID, NEW.LOTE, NEW.FECHAVENCE, NEW.CANTIDADDEINDEFINIDO*-1, NEW.PRECIO, NEW.COSTO,1, 'S');

              END



           end

      END




      
      
      IF ( OLD.esapartado = 'N' AND NEW.esapartado = 'S'  )THEN
      BEGIN


           IF((OLD.ESTATUSMOVTOID = 1 AND NEW.ESTATUSMOVTOID = 1) /*or (NEW.ESTATUSMOVTOID = 2)*/  ) THEN
           begin


              select TIPODOCTOID, FECHA, FECHAHORA, ALMACENID
              from DOCTO
              where ID = NEW.DOCTOID
              into :TIPODOCTOID, :FECHA, :FECHAHORA, :ALMACENID;


              IF (NEW.CANTIDADDEFACTURA > 0 ) THEN
              BEGIN


                  INSERT INTO KARDEX
                  (TIPODOCTOID, DOCTOID, MOVTOID, FECHA, FECHAHORA,
                   ALMACENID, PRODUCTOID, LOTE, FECHAVENCE, CANTIDAD, PRECIO, COSTO, ORIGENFISCALID, ESAPARTADO)
                  VALUES
                   (:TIPODOCTOID, NEW.DOCTOID, NEW.ID, :FECHA, :FECHAHORA,
                  :AlmacenId, NEW.PRODUCTOID, NEW.LOTE, NEW.FECHAVENCE, NEW.CANTIDADDEFACTURA, NEW.PRECIO, NEW.COSTO,3, 'S');

              END

   
              IF (NEW.CANTIDADDEREMISION > 0 ) THEN
              BEGIN
      
                 INSERT INTO KARDEX
                 (TIPODOCTOID, DOCTOID, MOVTOID, FECHA, FECHAHORA,
                  ALMACENID, PRODUCTOID, LOTE, FECHAVENCE, CANTIDAD, PRECIO, COSTO, ORIGENFISCALID, ESAPARTADO)
                  VALUES          
                   (:TIPODOCTOID, NEW.DOCTOID, NEW.ID, :FECHA, :FECHAHORA,
                  :AlmacenId, NEW.PRODUCTOID, NEW.LOTE, NEW.FECHAVENCE, NEW.CANTIDADDEREMISION, NEW.PRECIO, NEW.COSTO,2,  'S');

              END

     
              IF (NEW.CANTIDADDEINDEFINIDO > 0 ) THEN
              BEGIN
      
                  INSERT INTO KARDEX
                  (TIPODOCTOID, DOCTOID, MOVTOID, FECHA, FECHAHORA,
                  ALMACENID, PRODUCTOID, LOTE, FECHAVENCE, CANTIDAD, PRECIO, COSTO, ORIGENFISCALID, ESAPARTADO)
                  VALUES       
                   (:TIPODOCTOID, NEW.DOCTOID, NEW.ID, :FECHA, :FECHAHORA,
                  :AlmacenId, NEW.PRODUCTOID, NEW.LOTE, NEW.FECHAVENCE, NEW.CANTIDADDEINDEFINIDO, NEW.PRECIO, NEW.COSTO,1, 'S');

              END



           end

      END



   END
END