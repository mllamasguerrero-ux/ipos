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
    UNIDAD varchar(10),
    PRODUCTOTEXTO1 D_STDTEXT_LIGHT,
    PRODUCTOTEXTO2 D_STDTEXT_LIGHT,
    PRODUCTOTEXTO3 D_STDTEXT_LIGHT,
    PRODUCTOTEXTO4 D_STDTEXT_LIGHT,
    PRODUCTOTEXTO5 D_STDTEXT_MEDIUM,
    PRODUCTOTEXTO6 D_STDTEXT_LARGE,
    PRODUCTONUMERO1 D_PRECIO,
    PRODUCTONUMERO2 D_PRECIO,
    PRODUCTONUMERO3 D_PRECIO,
    PRODUCTONUMERO4 D_PRECIO,
    PRODUCTOFECHA1 D_FECHA,
    PRODUCTOFECHA2 D_FECHA,
    CUENTAPREDIAL D_STDTEXT_64,
    PZACAJA D_CANTIDAD,
    CAJAS D_CANTIDAD,
    PIEZASSUELTAS D_CANTIDAD)
as
declare variable MONEDAID D_FK;
declare variable TIPOCAMBIO D_TIPOCAMBIO;
BEGIN
   NUMERO = 0;

   TIPOCAMBIO = 1;
  SELECT COALESCE(TIPOCAMBIO,1) FROM DOCTO WHERE ID = :DOCTOID INTO :TIPOCAMBIO;
  TIPOCAMBIO = COALESCE(:TIPOCAMBIO,1);
  IF(:TIPOCAMBIO = 0) then
  BEGIN
        TIPOCAMBIO = 1;
  END

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
      M.PRECIO / :TIPOCAMBIO,
      M.IMPORTE / :TIPOCAMBIO,
      M.DESCUENTO / :TIPOCAMBIO,
      M.SUBTOTAL / :TIPOCAMBIO,
      M.IVA / :TIPOCAMBIO,
      M.TOTAL  / :TIPOCAMBIO,
      coalesce(S.NOMBRE,' ') as SUCURSALT ,
      coalesce(TD.nombre, ' ') AS TIPODOC ,
      coalesce(M.tasaiva,0.00) ,
      coalesce(M.descuentoporcentaje,0.00) ,
      CASE WHEN COALESCE(P.unidad,'PZA') = '' THEN 'PZA' ELSE COALESCE(P.unidad,'PZA') end AS UNIDAD ,
      coalesce(c.texto1,''),
      coalesce(c.texto2,''),
                c.texto3,
                c.texto4,
                c.texto5,
                c.texto6,
                c.numero1,
                c.numero2,
                c.numero3,
                c.numero4,
                c.fecha1, 
                c.fecha2,
                coalesce(p.cuentapredial,''),
                coalesce(P.PZACAJA,0) ,

                case when coalesce(P.PZACAJA,0) = 0 then 0 else TRUNC( (M.CANTIDAD / p.pzacaja) ) end cajas,
                case when coalesce(P.PZACAJA,0) = 0 then 0 else mod(M.CANTIDAD , p.pzacaja) end piezassueltas

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
          left join PRODUCTOCARACTERISTICAS  c on c.productoid = p.id

   WHERE DOCTOID = :doctoid
   ORDER BY M.ORDEN, M.PARTIDA
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
      :UNIDAD   ,
      
      :PRODUCTOTEXTO1 ,
      :PRODUCTOTEXTO2 ,
      :PRODUCTOTEXTO3 ,
      :PRODUCTOTEXTO4 ,
      :PRODUCTOTEXTO5 ,
      :PRODUCTOTEXTO6 ,
      :PRODUCTONUMERO1 ,
      :PRODUCTONUMERO2 ,
      :PRODUCTONUMERO3 ,
      :PRODUCTONUMERO4 ,
      :PRODUCTOFECHA1 ,
      :PRODUCTOFECHA2 ,
      :cuentapredial ,
      :PZACAJA  ,
      :CAJAS ,
      :PIEZASSUELTAS
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
      PZACAJA = 0;
      CAJAS = 0 ;
      PIEZASSUELTAS = 0;
      -- sin suspend para no regresar renglon falso
   end

END