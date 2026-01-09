create or alter procedure REP_COMPRA_DET (
    FECHAINI D_FECHA,
    FECHAFIN D_FECHA)
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
    PROVEEDOR D_NOMBRE,
    ESTATUSDOCTONOMBRE D_NOMBRE,
    VENDEDOR D_NOMBRE,
    IEPS D_IMPORTE,
    IMPUESTO D_IMPORTE,
    TASAIEPS D_PORCENTAJE)
as
declare variable TIPODOCTOID D_FK;
BEGIN
   NUMERO = 0;

   TIPODOCTOID = 11;

   FOR SELECT
      M.NUMERO,
      M.FECHA,
      M.FECHAHORA,
      COALESCE(M.TURNOCLAVE, 'N/D'),
      M.DOCTOFOLIO,
      M.PRODUCTOCLAVE,
      M.PRODUCTODESCRIPCION,
      M.CANTIDAD,
      M.PRECIO,
      M.IMPORTE,
      M.DESCUENTO,
      M.SUBTOTAL,
      M.IVA,
      M.TOTAL,
      M.PERSONA , 
      M.estatusdoctonombre ,
      M.VENDEDOR  ,
      M.IEPS,
      M.IMPUESTO  ,
      M.TASAIEPS
   FROM REP_DOCTO_DET(:FECHAINI, :FECHAFIN, :TIPODOCTOID) M
   INTO
      :NUMERO,
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
      :TOTAL,
      :PROVEEDOR,
      :ESTATUSDOCTONOMBRE ,
      :VENDEDOR ,  
      :IEPS,
      :IMPUESTO ,
      :TASAIEPS
   DO
   BEGIN
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
      PROVEEDOR = '';
      ESTATUSDOCTONOMBRE = '';
      VENDEDOR = '';
                         
      IEPS = 0;
      IMPUESTO = 0; 
      TASAIEPS = 0;
      -- sin suspend para no regresar renglon falso
   end

END