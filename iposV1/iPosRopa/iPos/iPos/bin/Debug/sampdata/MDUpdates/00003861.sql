create or alter procedure GET_MOVTOS (
    FECHAINI D_FECHA,
    FECHAFIN D_FECHA,
    TIPODOCTOID D_FK)
returns (
    NUMERO integer,
    FECHA D_FECHA,
    FECHAHORA D_TIMESTAMP,
    DOCTOFOLIO D_DOCTOFOLIO,
    PRODUCTOCLAVE D_CLAVE,
    PRODUCTODESCRIPCION D_DESCRIPCION,
    CANTIDAD D_CANTIDAD,
    PRECIO D_PRECIO,
    IMPORTE D_IMPORTE,
    DESCUENTO D_IMPORTE,
    SUBTOTAL D_IMPORTE,
    IVA D_IMPORTE,
    TOTAL D_IMPORTE,
    IEPS D_IMPORTE,
    IMPUESTO D_IMPORTE)
as
BEGIN
   NUMERO = 0;
  
   FOR SELECT
      D.FECHA,
      D.FECHAHORA,
      D.FOLIO,
      P.CLAVE,
      P.DESCRIPCION1,
      M.CANTIDAD,
      M.PRECIO,
      M.IMPORTE,
      M.DESCUENTO,
      M.SUBTOTAL,
      M.IVA,
      M.TOTAL,
      M.IEPS,
      M.IMPUESTO
   FROM MOVTO M
      LEFT JOIN DOCTO D
         ON D.ID = M.DOCTOID
      LEFT JOIN PRODUCTO P
         ON P.ID = M.PRODUCTOID
   WHERE D.TIPODOCTOID = :TIPODOCTOID
   and  ( COALESCE(:tipodoctoid, 0) NOT IN (11,21) or
                                        (
                                            (COALESCE(:tipodoctoid, 0) = 11 AND COALESCE(D.subtipodoctoid, 0) NOT IN (6,7,23)) OR
                                            (COALESCE(:tipodoctoid, 0) = 21 AND COALESCE(D.subtipodoctoid, 0) NOT IN (8))
                                        )
         )
     AND D.FECHA BETWEEN :FECHAINI AND :FECHAFIN
   INTO
      :FECHA ,
      :FECHAHORA ,
      :DOCTOFOLIO ,
      :PRODUCTOCLAVE ,
      :PRODUCTODESCRIPCION ,
      :CANTIDAD,
      :PRECIO ,
      :IMPORTE ,
      :DESCUENTO,
      :SUBTOTAL,
      :IVA ,
      :TOTAL,
      :IEPS,
      :IMPUESTO
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
      doctofolio = 0;
      productoclave = '';
      productodescripcion = '';
      cantidad = 0;
      PRECIO = 0.00;
      IMPORTE = 0.00;
      SUBTOTAL = 0.00;
      IVA = 0.00;
      TOTAL = 0.00;
      IEPS = 0.00;
      IMPUESTO = 0.00;
      -- sin suspend para no regresar renglon falso
   end

END