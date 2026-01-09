CREATE OR ALTER PROCEDURE REP_DOCTO_DET (
    fechaini d_fecha,
    fechafin d_fecha,
    tipodoctoid d_fk)
returns (
    numero integer,
    fecha d_fecha,
    fechahora d_timestamp,
    turnoclave d_clave,
    doctofolio d_doctofolio,
    productoclave d_clave,
    productodescripcion d_descripcion,
    cantidad d_cantidad,
    precio d_precio,
    importe d_importe,
    descuento d_importe,
    subtotal d_importe,
    iva d_importe,
    total d_importe,
    sucursalT d_nombre,
    tipoDoc d_nombre)
as
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
      M.TOTAL ,
      coalesce(S.NOMBRE,' ') as SUCURSALT ,
      coalesce(TD.nombre, ' ') AS TIPODOC
   FROM MOVTO M
      LEFT JOIN DOCTO D
         ON D.ID = M.DOCTOID
      LEFT JOIN PRODUCTO P
         ON P.ID = M.PRODUCTOID
      LEFT JOIN TURNO T
         ON T.ID = D.TURNOID 
       left join SUCURSAL S
         ON S.ID = D.SUCURSALTID
        left join TIPODOCTO  TD
         on  TD.id = d.tipodoctoid
   WHERE (TIPODOCTOID = :TIPODOCTOID  OR (:TIPODOCTOID = -21 AND TIPODOCTOID IN (21,31,23)))
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
      :TOTAL ,
      :SUCURSALT ,
      :TIPODOC
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
      SUCURSALT = ' ';
      TIPODOC = ' ';
      -- sin suspend para no regresar renglon falso
   end

END
