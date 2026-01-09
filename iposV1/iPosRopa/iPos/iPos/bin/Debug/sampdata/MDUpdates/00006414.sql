create or alter procedure INVFIS_DIF_EXISTACTUAL_XLOC (
    INVENTARIODOCTOID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable MOVTOID D_FK;
declare variable PRODUCTOID D_FK;
declare variable LOTE D_LOTE;
declare variable FECHAVENCE D_FECHAVENCE;
declare variable CANTIDAD D_CANTIDAD;
declare variable ALMACENID D_FK;
BEGIN
   IF ((:INVENTARIODOCTOID IS NULL) OR (:INVENTARIODOCTOID = 0)) THEN
   BEGIN
      ERRORCODE = 1073;
      SUSPEND;
      EXIT;
   END



   -- Agrega un MOVTO para cada registro con diferencia
   -- entre CANTIDAD y CANTIDADSURTIDA
   FOR SELECT
      --M.ID,
      M.PRODUCTOID,
      M.LOTE,
      M.FECHAVENCE,
      D.ALMACENID
   FROM MOVTO M
     LEFT JOIN DOCTO D
       ON D.ID = M.DOCTOID
   WHERE M.DOCTOID = :INVENTARIODOCTOID   
      GROUP BY   M.PRODUCTOID, M.LOTE, M.FECHAVENCE, D.ALMACENID
   INTO
      --:MOVTOID,
      :PRODUCTOID, :LOTE, :FECHAVENCE , :ALMACENID
   DO
   BEGIN

        select COALESCE(sum(cantidad),0) from inventario
        where  productoid = :PRODUCTOID and
              coalesce(lote,'') = coalesce(:LOTE,'') AND
              coalesce(fechavence,current_date) = coalesce(:FECHAVENCE,current_date)   AND
              almacenid = :almacenid  AND COALESCE(ESAPARTADO,'N') = 'N'
        into :CANTIDAD;

        UPDATE MOVTO
        SET
           CANTIDAD = :cantidad
        WHERE DOCTOID = :INVENTARIODOCTOID AND PRODUCTOID = :PRODUCTOID ;

            IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
            BEGIN
               SUSPEND;
               EXIT;
            END
         --END
      END




   ERRORCODE = 0;
   SUSPEND;
   
   WHEN ANY DO
   BEGIN
     ERRORCODE = 1076;
     SUSPEND;
   END
END