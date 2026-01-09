CREATE OR ALTER PROCEDURE REP_DOCTO_DET (
    FECHAINI D_FECHA,
    FECHAFIN D_FECHA,
    TIPODOCTOID D_FK)
RETURNS (
    NUMERO INTEGER,
    FECHA D_FECHA,
    FECHAHORA D_TIMESTAMP,
    TURNOCLAVE D_CLAVE,
    DOCTOFOLIO D_DOCTOFOLIO,
    PRODUCTOCLAVE D_CLAVE,
    PRODUCTODESCRIPCION D_DESCRIPCION,
    CANTIDAD D_CANTIDAD,
    PRECIO D_PRECIO,
    IMPORTE D_IMPORTE,
    DESCUENTO D_IMPORTE,
    SUBTOTAL D_IMPORTE,
    IVA D_IMPORTE,
    TOTAL D_IMPORTE)
AS
BEGIN
   NUMERO = 0;

   FOR SELECT
      D.FECHA,
      D.FECHAHORA,
      COALESCE(T.CLAVE, 'N/D'),
      D.FOLIO,
      P.CLAVE,
      P.DESCRIPCION1,
      M.CANTIDAD,
      M.PRECIO,
      M.IMPORTE,
      M.DESCUENTO,
      M.SUBTOTAL,
      M.IVA,
      M.TOTAL
   FROM MOVTO M
      LEFT JOIN DOCTO D
         ON D.ID = M.DOCTOID
      LEFT JOIN PRODUCTO P
         ON P.ID = M.PRODUCTOID
      LEFT JOIN TURNO T
         ON T.ID = D.TURNOID
   WHERE TIPODOCTOID = :TIPODOCTOID
     AND D.FECHA BETWEEN :FECHAINI AND :FECHAFIN
     AND D.ESTATUSDOCTOID = 1
   INTO
      :FECHA ,
      :FECHAHORA ,
      :TURNOCLAVE,
      :DOCTOFOLIO ,
      :PRODUCTOCLAVE ,
      :PRODUCTODESCRIPCION ,
      :CANTIDAD,
      :PRECIO ,
      :IMPORTE ,
      :DESCUENTO,
      :SUBTOTAL,
      :IVA ,
      :TOTAL
   DO
   BEGIN
      NUMERO = :NUMERO + 1;
      SUSPEND;
   END

   if (:numero = 0) then
   begin
      numero = 0;
      fecha = current_date;
      fechahora = current_date;
      TURNOCLAVE = 'N/D';
      doctofolio = 0;
      productoclave = '';
      productodescripcion = '';
      cantidad = 0;
      PRECIO = 0.00;
      IMPORTE = 0.00;
      SUBTOTAL = 0.00;
      IVA = 0.00;
      TOTAL = 0.00;
      -- sin suspend para no regresar renglon falso
   end

END;