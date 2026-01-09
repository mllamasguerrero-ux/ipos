create or alter procedure INVENTARIO_UI (
    ALMACENID D_FK,
    PRODUCTOID D_FK,
    LOTE D_LOTE,
    FECHAVENCE D_FECHAVENCE,
    CANTIDAD D_CANTIDAD,
    PRECIO D_PRECIO,
    COSTO D_COSTO,
    ORIGENFISCALID D_FK,
    ESAPARTADO D_BOOLCN)
returns (
    OK D_BOOLCN,
    ERRORCODE D_ERRORCODE)
as
declare variable INVENTARIOID type of D_FK;
declare variable SENTIDOINV type of D_SENTIDO;
declare variable MANEJALOTES char(1);
BEGIN
   --MANEJALOTES = 'N'; -- Este posteriormente proviene de parametros.
   select manejalote from producto where id = :productoid into :manejalotes;

   IF ((:CANTIDAD IS NULL) OR (:CANTIDAD = 0)) THEN
   BEGIN
      ERRORCODE = 1026;
      SUSPEND;
      EXIT;
   END

   IF ((:LOTE IS NULL) OR (:MANEJALOTES = 'N')) THEN
   BEGIN
      SELECT ID
      FROM INVENTARIO
      WHERE  PRODUCTOID = :PRODUCTOID
      AND ORIGENFISCALID = :ORIGENFISCALID
      AND ESAPARTADO = :ESAPARTADO
      INTO :INVENTARIOID;

      LOTE = NULL;
      FECHAVENCE = NULL;
   END
   ELSE
   BEGIN
      SELECT ID
      FROM INVENTARIO
      WHERE PRODUCTOID = :PRODUCTOID
        AND LOTE = :LOTE
        AND FECHAVENCE = :FECHAVENCE
         AND ORIGENFISCALID = :ORIGENFISCALID  
        AND ESAPARTADO = :ESAPARTADO
      INTO :INVENTARIOID;
   END
      
   IF (:INVENTARIOID IS NULL) THEN
   BEGIN
      INSERT INTO INVENTARIO
         (ALMACENID, PRODUCTOID, LOTE, FECHAVENCE, CANTIDAD,ORIGENFISCALID,ESAPARTADO)
      VALUES
         (:ALMACENID, :PRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDAD,:ORIGENFISCALID, :ESAPARTADO)
      RETURNING ID
         INTO :INVENTARIOID;
   END
   ELSE
   BEGIN
      IF ((:LOTE IS NULL) OR (:MANEJALOTES = 'N')) THEN
      BEGIN
         UPDATE INVENTARIO
         SET
            CANTIDAD = CANTIDAD + :CANTIDAD
         WHERE  PRODUCTOID = :PRODUCTOID  
         AND ORIGENFISCALID = :ORIGENFISCALID  
        AND ESAPARTADO = :ESAPARTADO
         RETURNING ID
            INTO :INVENTARIOID;
      END
      ELSE
      BEGIN
         UPDATE INVENTARIO
         SET
            CANTIDAD = CANTIDAD + :CANTIDAD
         WHERE  PRODUCTOID = :PRODUCTOID
           AND LOTE = :LOTE
           AND FECHAVENCE = :FECHAVENCE  
         AND ORIGENFISCALID = :ORIGENFISCALID  
        AND ESAPARTADO = :ESAPARTADO
         RETURNING ID
            INTO :INVENTARIOID;
      END
   END

   UPDATE PRODUCTO P
   SET P.EXISTENCIA = (
      SELECT SUM(I.CANTIDAD)
      FROM INVENTARIO I
      where i.productoid = :PRODUCTOID and ESAPARTADO = 'N') ,
       P.existenciafacturado =  (
           SELECT SUM(I.CANTIDAD)
           FROM INVENTARIO I
           where i.productoid = :PRODUCTOID
           AND ORIGENFISCALID = 3
           AND ESAPARTADO = 'N') ,
       P.existenciaremisionado =  (
           SELECT SUM(I.CANTIDAD)
           FROM INVENTARIO I
           where i.productoid = :PRODUCTOID
           AND ORIGENFISCALID = 2
           AND ESAPARTADO = 'N')  ,
       P.EXISTENCIAAPARTADO = (
      SELECT SUM(I.CANTIDAD)
      FROM INVENTARIO I
      where i.productoid = :PRODUCTOID and ESAPARTADO = 'S') ,
       P.existenciafacturadoapartado =  (
           SELECT SUM(I.CANTIDAD)
           FROM INVENTARIO I
           where i.productoid = :PRODUCTOID
           AND ORIGENFISCALID = 3
           AND ESAPARTADO = 'S') ,
       P.existenciaremisionadoapartado =  (
           SELECT SUM(I.CANTIDAD)
           FROM INVENTARIO I
           where i.productoid = :PRODUCTOID
           AND ORIGENFISCALID = 2
           AND ESAPARTADO = 'S')
    WHERE P.ID = :PRODUCTOID ;

   
   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1027;
      SUSPEND;
   END 
END