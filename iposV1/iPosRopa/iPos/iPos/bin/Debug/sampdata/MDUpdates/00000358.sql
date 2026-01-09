CREATE OR ALTER PROCEDURE INVENTARIO_UI (
    almacenid d_fk,
    productoid d_fk,
    lote d_lote,
    fechavence d_fechavence,
    cantidad d_cantidad,
    precio d_precio,
    costo d_costo)
returns (
    ok d_boolcn,
    errorcode d_errorcode)
as
declare variable inventarioid type of d_fk;
declare variable sentidoinv type of d_sentido;
declare variable manejalotes char(1);
BEGIN
   MANEJALOTES = 'N'; -- Este posteriormente proviene de parametros.

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
      INTO :INVENTARIOID;
   END
      
   IF (:INVENTARIOID IS NULL) THEN
   BEGIN
      INSERT INTO INVENTARIO
         (ALMACENID, PRODUCTOID, LOTE, FECHAVENCE, CANTIDAD)
      VALUES
         (:ALMACENID, :PRODUCTOID, :LOTE, :FECHAVENCE, :CANTIDAD)
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
         RETURNING ID
            INTO :INVENTARIOID;
      END
   END

   UPDATE PRODUCTO P
   SET P.EXISTENCIA = (
      SELECT SUM(I.CANTIDAD)
      FROM INVENTARIO I
      where i.productoid = :PRODUCTOID)
    WHERE P.ID = :PRODUCTOID ;

   
   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1027;
      SUSPEND;
   END 
END