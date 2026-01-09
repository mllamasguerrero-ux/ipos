create or alter procedure LOTESINVENTARIOLIST (
    PRODUCTID D_FK,
    DOCTOID D_FK,
    ALMACENID D_FK)
returns (
    PRODUCTOID D_FK,
    PRODUCTO D_CLAVE_NULL,
    LOTE D_LOTE,
    CANTIDAD D_CANTIDAD,
    FECHAVENCE D_FECHAVENCE,
    CADUCADO D_BOOLCN,
    PORCADUCAR D_BOOLCN,
    CANTIDADENDOCTO D_CANTIDAD)
as
declare variable NUMERO integer;
BEGIN
   numero = 0;

   FOR SELECT
    L.PRODUCTOID,
    L.PRODUCTO,
    L.LOTE,
    L.CANTIDAD,
    L.FECHAVENCE,
    L.CADUCADO,
    L.PORCADUCAR,
    coalesce(SUM(M.CANTIDAD),0) AS CANTIDADENDOCTO
    FROM            LOTESINVENTARIOVIEW L LEFT OUTER JOIN
                         MOVTO M ON M.LOTE = L.LOTE AND M.PRODUCTOID = L.PRODUCTOID AND L.FECHAVENCE = M.FECHAVENCE
                         AND M.DOCTOID = :doctoid
    WHERE        (L.PRODUCTOID = :productid) AND (COALESCE(:ALMACENID,0) = 0 or L.ALMACENID = :ALMACENID  )
    GROUP BY L.PRODUCTOID, L.PRODUCTO, L.LOTE, L.CANTIDAD, L.FECHAVENCE, L.CADUCADO, L.PORCADUCAR
    having coalesce(L.CANTIDAD , 0) - coalesce(sum(m.cantidad) ,0) > 0
    ORDER BY L.LOTE
   INTO
     :PRODUCTOID,
     :PRODUCTO,
     :LOTE,
     :CANTIDAD,
     :FECHAVENCE,
     :CADUCADO,
     :PORCADUCAR,
     :CANTIDADENDOCTO
   DO
   BEGIN
      NUMERO = :NUMERO + 1;
      SUSPEND;
   END

   if (:numero = 0) then
   begin
     PRODUCTOID = 0;
     PRODUCTO = '';
     LOTE = '';
     CANTIDAD = 0;
     FECHAVENCE = current_date;
     CADUCADO = 'N';
     PORCADUCAR = 'N';
     CANTIDADENDOCTO = 0;
      -- sin suspend para no regresar renglon falso
   end

END