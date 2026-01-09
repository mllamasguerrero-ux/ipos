create or alter procedure REP_FACTURAELECTRONICA_DET (
    DOCTOID D_FK)
returns (
    NUMERO integer,
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
    TOTAL D_IMPORTE,
    SUCURSALT D_NOMBRE,
    TIPODOC D_NOMBRE,
    PORCENTAJEIVA D_PORCENTAJE,
    DESCUENTOPORCENTAJE D_PORCENTAJE,
    UNIDAD varchar(10))
as
BEGIN
   NUMERO = 0;

   FOR SELECT
      D.FECHA,
      D.FECHAHORA,
      COALESCE(T.CLAVE, 'N/D'),
      D.FOLIO,
      P.CLAVE,


      CASE WHEN P.descripcion_comodin = 'S' AND M.descripcion1 IS NOT NULL AND M.descripcion1 <> '' THEN
        M.DESCRIPCION1 || ' ' ||  coalesce(m.descripcion2,'') || ' ' ||  coalesce(m.descripcion3,'')
        ELSE
        P.DESCRIPCION1 END
        ||
         case when p.manejalote = 'S' then ' ' || 'Lote: ' || m.lote || ' Fecha vencimiento: ' || CAST(m.fechavence AS DATE)
             else ''
          end




        AS DESCRIPCION1,
      M.CANTIDAD,
      M.PRECIO,
      M.IMPORTE,
      M.DESCUENTO,
      M.SUBTOTAL,
      M.IVA,
      M.TOTAL ,
      coalesce(S.NOMBRE,' ') as SUCURSALT ,
      coalesce(TD.nombre, ' ') AS TIPODOC ,
      coalesce(M.tasaiva,0.00) ,
      coalesce(M.descuentoporcentaje,0.00) ,
      CASE WHEN COALESCE(P.unidad,'PZA') = '' THEN 'PZA' ELSE COALESCE(P.unidad,'PZA') end AS UNIDAD
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
   WHERE DOCTOID = :doctoid
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
      :TIPODOC   ,
      :PORCENTAJEIVA,
      :DESCUENTOPORCENTAJE,
      :UNIDAD
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
      PORCENTAJEIVA = 0;
      -- sin suspend para no regresar renglon falso
   end

END