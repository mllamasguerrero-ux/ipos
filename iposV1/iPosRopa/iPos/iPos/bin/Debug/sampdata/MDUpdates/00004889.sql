create or alter procedure REP_FACTURAELECTRONICA_DET (
    DOCTOID D_FK,
    DESGLOSEKITS varchar(1))
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
    PIEZASSUELTAS D_CANTIDAD,
    IEPS D_IMPORTE,
    IMPUESTO D_IMPORTE,
    PORCENTAJEIEPS D_PORCENTAJE,
    PRECIOLISTA D_PRECIO,
    ESKIT D_BOOLCN,
    ESPARTEKIT D_BOOLCN,
    MOVTOID D_FK,
    PRODUCTOID D_FK,
    DOCTOKITREFID D_FK,
    MOVTOREFID D_FK,
    DESCPZACAJA D_DESCRIPCION,
    STRPEDIMENTO varchar(1000),
    KITMOVTOID D_FK,
    KITPRODUCTOID D_FK,
    KITPRODCLAVE D_CLAVE_NULL,
    KITPRODNOMBRE D_NOMBRE_NULL,
    KITPRODDESCRIPCION1 D_DESCRIPCION,
    KITPRECIOLISTA D_PRECIO,
    KITPRECIO D_PRECIO,
    KITTASAIVA D_PRECIO,
    KITTASAIEPS D_PRECIO,
    KITTASAIMPUESTO D_PRECIO,
    KITIVA D_PRECIO,
    KITIEPS D_PRECIO,
    KITIMPUESTO D_PRECIO,
    KITSUBTOTAL D_PRECIO,
    KITTOTAL D_PRECIO,
    KITCANTIDAD D_CANTIDAD,
    KITDESCPZACAJA D_STDTEXT_LARGE,
    SAT_CLAVEPRODSERV D_CLAVE_NULL,
    SAT_CLAVEUNIDAD D_CLAVE_NULL,
    SAT_DESCRIPCIONUNIDAD D_STDTEXT_MAX,
    IVARETENIDO D_IMPORTE,
    ISRRETENIDO D_IMPORTE,
    SAT_NOMBRE_UNIDAD D_NOMBRE_NULL,
    SAT_IVATRASLADADO_CONC D_STDTEXT_SHORT,
    SAT_IEPSTRASLADADO_CONC D_STDTEXT_SHORT,
    PLAZOCLAVE D_CLAVE_NULL)
as
declare variable MONEDAID D_FK;
declare variable TIPOCAMBIO D_TIPOCAMBIO;
declare variable TIPODOCTOID D_FK;
declare variable DOCTOIDBUSCAR D_FK;
declare variable DOCTOREFID2 D_FK;
declare variable FOLIOINI D_DOCTOFOLIO;
declare variable FOLIOFIN D_DOCTOFOLIO;
declare variable FECHAINI D_FECHA;
declare variable FECHAFIN D_FECHA;
BEGIN





   NUMERO = 0;

   TIPOCAMBIO = 1;
  SELECT COALESCE(TIPOCAMBIO,1), TIPODOCTOID, DOCTOREFID2 FROM DOCTO WHERE ID = :DOCTOID INTO :TIPOCAMBIO, :TIPODOCTOID, :DOCTOREFID2;
  TIPOCAMBIO = COALESCE(:TIPOCAMBIO,1);
  IF(:TIPOCAMBIO = 0) then
  BEGIN
        TIPOCAMBIO = 1;
  END


 IF(COALESCE(:TIPODOCTOID,1) NOT IN (701,205)) THEN
 BEGIN



  IF(COALESCE(:TIPODOCTOID,1) = 702 ) THEN
  BEGIN
    DOCTOIDBUSCAR = :DOCTOREFID2;
  END
  else
  BEGIN
    DOCTOIDBUSCAR = :DOCTOID;
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
      CORE.CANTIDAD,
      M.PRECIO / :TIPOCAMBIO,
      CORE.IMPORTE / :TIPOCAMBIO,
      CORE.DESCUENTO / :TIPOCAMBIO,
      CORE.SUBTOTAL / :TIPOCAMBIO,
      CORE.IVA / :TIPOCAMBIO,
      CORE.TOTAL  / :TIPOCAMBIO,
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


                
                case
                    when  p.unidad = 'KG' then
                        0.00
                    when  ( coalesce(p.pzacaja,0) = 0 or  coalesce(p.pzacaja,0) = 1 ) then
                        0.00
                    else
                        trunc(coalesce(     (CASE WHEN (d.tipodoctoid in  (41)) THEN core.cantidadsurtida ELSE core.cantidad END   )   ,0)/coalesce(p.pzacaja,1))
                end   cajas ,

                case
                    when  p.unidad = 'KG' then
                        0.00
                    when  ( coalesce(p.pzacaja,0) = 0 or  coalesce(p.pzacaja,0) = 1 ) then
                        (CASE WHEN (d.tipodoctoid in  (41)) THEN core.cantidadsurtida ELSE core.cantidad END )
                    else
                        mod(coalesce(    (CASE WHEN (d.tipodoctoid in  (41)) THEN core.cantidadsurtida ELSE core.cantidad END )   ,0),coalesce(p.pzacaja,1))
                end  piezassueltas   ,


                CORE.IEPS / :TIPOCAMBIO,
                CORE.IMPUESTO / :TIPOCAMBIO ,
                M.TASAIEPS  ,
                case when coalesce(M.PRECIOLISTA,0) = 0 then m.precio else m.preciolista end PRECIOLISTA ,
                CASE WHEN COALESCE(PARAMETRO.manejakits ,'N') = 'S' THEN COALESCE(P.eskit,'N') ELSE 'N' END  ESKIT,
                CASE WHEN COALESCE(PARAMETRO.manejakits ,'N') = 'S' THEN COALESCE(case when m.doctoid = COALESCE(D.doctokitrefid,0) then 'S' else 'N' end, 'N') ELSE 'N' END  ESPARTEKIT ,


                M.ID MOVTOID,
                M.PRODUCTOID ,
                D.DOCTOKITREFID ,
                M.MOVTOREFID ,
                case
                    when  P.unidad = 'KG' then
                        cast(     (CASE WHEN (D.tipodoctoid in  (41)) THEN cast(CORE.cantidadsurtida as numeric(18,3)) ELSE cast(CORE.cantidad as numeric(18,3)) END ) as varchar(20) ) || (case when (CASE WHEN (D.tipodoctoid in  (41)) THEN cast(CORE.cantidadsurtida as numeric(18,3)) ELSE cast(CORE.cantidad as numeric(18,3)) END )  >= 1 then ' KG' else ' GM' end)
                    when P.unidad <> 'PZA' and P.unidad <> 'KG' then
                        cast(     (CASE WHEN (D.tipodoctoid in  (41)) THEN CORE.cantidadsurtida ELSE CORE.cantidad END )  as varchar(20))
                    when  ( coalesce(P.pzacaja,0) = 0 or  coalesce(P.pzacaja,0) = 1 ) then
                        cast(     (CASE WHEN (D.tipodoctoid in  (41)) THEN CORE.cantidadsurtida ELSE CORE.cantidad END )  as varchar(20)) || ' PZAS'
                    else
                        cast(trunc(coalesce(     (CASE WHEN (D.tipodoctoid in  (41)) THEN CORE.cantidadsurtida ELSE CORE.cantidad END   )   ,0)/coalesce(P.pzacaja,1)) as varchar(20)) || ' cajas ' ||  cast(mod(coalesce(    (CASE WHEN (D.tipodoctoid in  (41)) THEN CORE.cantidadsurtida ELSE CORE.cantidad END )   ,0),coalesce(P.pzacaja,1)) as varchar(10)) || ' piezas '
                    end 

                DESCPZACAJA ,
       CORE.STRPEDIMENTO ,


    CORE.KITMOVTOID ,
    CORE.KITPRODUCTOID ,
    PKITREF.CLAVE KITPRODCLAVE,
    PKITREF.NOMBRE KITPRODNOMBRE,
    PKITREF.DESCRIPCION1  KITPRODDESCRIPCION1,
    CORE.KITPRECIOLISTA ,
    CORE.KITPRECIO ,
    CORE.KITTASAIVA ,
    CORE.KITTASAIEPS ,
    CORE.KITTASAIMPUESTO ,
    CORE.KITIVA ,
    CORE.KITIEPS ,
    CORE.KITIMPUESTO ,
    CORE.KITSUBTOTAL ,
    CORE.KITTOTAL ,
    CORE.KITCANTIDAD ,
    
        case when coalesce(PKITREF.pzacaja,0) = 0 then
        cast(CORE.KITCANTIDAD as varchar(10)) || ' P' else
        cast(trunc(coalesce(CORE.KITCANTIDAD,0)/coalesce(PKITREF.pzacaja,1)) as varchar(10)) || ' C. ' ||  cast(mod(coalesce(CORE.KITCANTIDAD,0),coalesce(PKITREF.pzacaja,1)) as varchar(10)) || ' P.'
        end  KITDESCPZACAJA ,
        SATPROD.SAT_CLAVEPRODSERV,
        SATUNIMED.SAT_CLAVE  SAT_CLAVE_UNIDAD,
        SATUNIMED.SAT_DESCRIPCION SAT_DESCRIPCION_UNIDAD ,
        M.ivaretenido IVARETENIDO,
        M.isrretenido ISRRETENIDO ,
        SATUNIMED.SAT_NOMBRE SAT_NOMBRE_UNIDAD,
        SATPROD.SAT_IVATRASLADADO,
        SATPROD.SAT_IEPSTRASLADADO ,
        PLAZO.CLAVE PLAZOCLAVE

   FROM
   (SELECT * FROM RECIBOS_CORE WHERE DOCTOID = :DOCTOID) CORE
    LEFT JOIN DOCTO D ON D.ID = CORE.DOCTOID
    LEFT JOIN MOVTO M ON M.ID = CORE.MOVTOID AND M.DOCTOID = CORE.DOCTOID
    LEFT JOIN PRODUCTO P ON P.ID = M.PRODUCTOID
    LEFT JOIN TURNO T ON T.ID = D.TURNOID
    LEFT JOIN SUCURSAL S ON S.ID = D.SUCURSALTID
    LEFT JOIN TIPODOCTO  TD ON  TD.id = d.tipodoctoid
    LEFT JOIN PRODUCTOCARACTERISTICAS  c ON c.productoid = p.id
    LEFT JOIN parametro on 1 = 1
    LEFT JOIN PRODUCTO PKITREF ON PKITREF.ID = CORE.KITPRODUCTOID
    LEFT JOIN LOTESIMPORTADOS ON LOTESIMPORTADOS.ID = M.loteimportado
    LEFT JOIN UNIDAD U ON U.CLAVE = P.UNIDAD
    LEFT JOIN SAT_PRODUCTOSERVICIO SATPROD ON SATPROD.ID =  P.SAT_PRODUCTOSERVICIOID
    LEFT JOIN SAT_UNIDADMEDIDA SATUNIMED ON SATUNIMED.ID = U.SAT_UNIDADMEDIDAID
    LEFT JOIN PLAZO ON PLAZO.id = P.plazoid

   WHERE D.ID = :DOCTOIDBUSCAR
       order by 
       case when coalesce(parametro.ordenimpresion,'') = 'DESCRIPCION' then
                 p.descripcion
            when coalesce(parametro.ordenimpresion,'') = 'DESCRIPCION1' then
                 p.descripcion1
            when coalesce(parametro.ordenimpresion,'') = 'DESCRIPCION2' then
                 p.descripcion2
            else  m.orden
        end,
         m.orden  ,
         m.partida ,
         m.ID
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
      :PIEZASSUELTAS,
      :IEPS,
      :IMPUESTO ,
      :PORCENTAJEIEPS ,
      :PRECIOLISTA ,

      :ESKIT,
      :ESPARTEKIT,

      :MOVTOID ,
      :PRODUCTOID ,
      :DOCTOKITREFID ,
      :MOVTOREFID ,
      :DESCPZACAJA   ,
      :STRPEDIMENTO  ,
   
      :KITMOVTOID ,
      :KITPRODUCTOID ,
      :KITPRODCLAVE ,
      :KITPRODNOMBRE ,
      :KITPRODDESCRIPCION1 ,
      :KITPRECIOLISTA ,
      :KITPRECIO ,
      :KITTASAIVA ,
      :KITTASAIEPS ,
      :KITTASAIMPUESTO ,
      :KITIVA ,
      :KITIEPS ,
      :KITIMPUESTO ,
      :KITSUBTOTAL ,
      :KITTOTAL ,
      :KITCANTIDAD ,
      :KITDESCPZACAJA ,
      :SAT_CLAVEPRODSERV,
      :SAT_CLAVEUNIDAD,
      :SAT_DESCRIPCIONUNIDAD ,
      :IVARETENIDO,
      :ISRRETENIDO,
      :SAT_NOMBRE_UNIDAD,
      :SAT_IVATRASLADADO_CONC,
      :SAT_IEPSTRASLADADO_CONC,
      :PLAZOCLAVE

   DO
   BEGIN

      IF(COALESCE(:DESGLOSEKITS,'N') = 'S' OR COALESCE(:ESPARTEKIT,'N') <> 'S') THEN
      BEGIN
        NUMERO = :NUMERO + 1;
        SUSPEND;
      END
   END

 END
 ELSE if (COALESCE(:TIPODOCTOID,1) = 701) then
 BEGIN

    -- reset datos de importacion aduanera
    STRPEDIMENTO = '';

       
      --reset kit
    KITMOVTOID = 0;
    KITPRODUCTOID = 0;
    KITPRODCLAVE  = '';
    KITPRODNOMBRE  = '';
    KITPRODDESCRIPCION1  = '';
    KITPRECIOLISTA  = 0.0;
    KITPRECIO  = 0.0;
    KITTASAIVA  = 0.0;
    KITTASAIEPS  = 0.0;
    KITTASAIMPUESTO = 0.0;
    KITIVA  = 0.0;
    KITIEPS  = 0.0;
    KITIMPUESTO  = 0.0;
    KITSUBTOTAL  = 0.0;
    KITTOTAL  = 0.0;
    KITCANTIDAD  = 0.0;

    --RESET DATOS SAT
    SAT_CLAVEPRODSERV = NULL;
    SAT_CLAVEUNIDAD = NULL;
    SAT_DESCRIPCIONUNIDAD = NULL;
    IVARETENIDO = 0.00;
    ISRRETENIDO = 0.00;
    SAT_NOMBRE_UNIDAD = NULL;
    SAT_IVATRASLADADO_CONC = NULL;
    SAT_IEPSTRASLADADO_CONC = NULL;
    PLAZOCLAVE = NULL;


    SELECT FECHAINI, FECHAFIN FROM DOCTO WHERE ID = :DOCTOID INTO :FECHAINI, :FECHAFIN;
    SELECT MAX(FOLIO) , MIN(FOLIO) FROM DOCTO
    WHERE DOCTO.FECHA >= :FECHAINI AND DOCTO.FECHA <= :FECHAFIN
     AND DOCTO.factconsid = :DOCTOID
     AND DOCTO.tipodoctoid = 21
     AND DOCTO.estatusdoctoid = 1
    INTO :FOLIOINI, :FOLIOFIN;

    SELECT FIRST 1
      D.FECHA,
      D.FECHAHORA,
      COALESCE(T.CLAVE, 'N/D'),
      D.FOLIO,
      'FACTURACONSOLIDADA',
      'El presente comprobante ampara las ventas al publico en general de la fecha :' ||  CAST(Extract(day  FROM d.fechaini ) AS VARCHAR(2)) || '/' || CAST(Extract(month FROM d.fechaini ) AS VARCHAR(2)) || '/' || CAST(Extract(year FROM d.fechaini ) AS VARCHAR(4)) ||
      ' a la fecha : ' || CAST(Extract(day  FROM d.fechafin ) AS VARCHAR(2)) || '/' || CAST(Extract(month FROM d.fechafin ) AS VARCHAR(2)) || '/' || CAST(Extract(year FROM d.fechafin ) AS VARCHAR(4))   ||
      ' del folio ' ||
      COALESCE(d.referencia, ''),
      1,
      D.TOTAL,
      D.TOTAL,
      0,
      D.TOTAL,
      0,
      D.TOTAL,
      coalesce(S.NOMBRE,' ') as SUCURSALT ,
      coalesce(TD.nombre, ' ') AS TIPODOC ,
      0.00 ,
      0.00 ,
      'PZA',
      '',
      '',
      '',
      '',
      '',
      '',
      0.00,
      0.00,
      0.00,
      0.00,
      CURRENT_DATE,
      CURRENT_DATE,
      '',
      1 ,
      0 cajas,
      1 piezassueltas ,
      0.00,
      0.00 ,
      0.00  ,
      D.TOTAL PRECIOLISTA ,
      'N'  ESKIT,
      'N'  ESPARTEKIT ,
      0 MOVTOID,
      0 PRODUCTOID ,
      D.DOCTOKITREFID ,
      0 MOVTOREFID,
      '',
      NULL,
      NULL,
      NULL

   FROM DOCTO D
   LEFT JOIN TURNO T ON T.ID = D.TURNOID
   LEFT JOIN SUCURSAL S ON S.ID = D.SUCURSALTID
   LEFT JOIN TIPODOCTO  TD ON  TD.id = d.tipodoctoid
   LEFT JOIN parametro on 1 = 1
   WHERE D.ID = :DOCTOID
   into
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
      :UNIDAD,
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
      :PIEZASSUELTAS,
      :IEPS,
      :IMPUESTO ,
      :PORCENTAJEIEPS ,
      :PRECIOLISTA ,
      :ESKIT,
      :ESPARTEKIT,
      :MOVTOID ,
      :PRODUCTOID ,
      :DOCTOKITREFID ,
      :MOVTOREFID,
      :DESCPZACAJA,
      :SAT_CLAVEPRODSERV,
      :SAT_CLAVEUNIDAD,
      :SAT_DESCRIPCIONUNIDAD;

       SUSPEND;


 END
 ELSE IF (COALESCE(:TIPODOCTOID,1) = 205) THEN
 BEGIN
           
    -- reset datos de importacion aduanera   
    STRPEDIMENTO = '';

      --reset kit
    KITMOVTOID = 0;
    KITPRODUCTOID = 0;
    KITPRODCLAVE  = '';
    KITPRODNOMBRE  = '';
    KITPRODDESCRIPCION1  = '';
    KITPRECIOLISTA  = 0.0;
    KITPRECIO  = 0.0;
    KITTASAIVA  = 0.0;
    KITTASAIEPS  = 0.0;
    KITTASAIMPUESTO = 0.0;
    KITIVA  = 0.0;
    KITIEPS  = 0.0;
    KITIMPUESTO  = 0.0;
    KITSUBTOTAL  = 0.0;
    KITTOTAL  = 0.0;
    KITCANTIDAD  = 0.0;
    SAT_CLAVEPRODSERV = NULL;
    SAT_CLAVEUNIDAD = NULL;
    SAT_DESCRIPCIONUNIDAD = NULL;     
    IVARETENIDO = 0.00;
    ISRRETENIDO = 0.00;  
    SAT_NOMBRE_UNIDAD = NULL;    
    SAT_IVATRASLADADO_CONC = NULL;
    SAT_IEPSTRASLADADO_CONC = NULL;  
    PLAZOCLAVE = NULL;

    SELECT  first 1
      D.FECHA,
      D.FECHAHORA,
      COALESCE(T.CLAVE, 'N/D'),
      D.FOLIO,
      'ABONOELECTRONICO',
      'Parcialidad ' ||  COALESCE(d.referencia, '') || ' de la factura ' || COALESCE(dr.seriesat,'') || ' '  || cast(COALESCE(DR.foliosat, 0) AS varchar(20))
      || ' con monto origen de ' || cast(coalesce(dr.total,0) as varchar(25))  || ' de la fecha origen ' || cast(COALESCE(DR.timbradofecha, '') AS varchar(20))  || ' con uuid de timbrado origen ' || COALESCE(DR.timbradouuid, '')   ,
      1,
      D.TOTAL,
      D.IMPORTE / :TIPOCAMBIO,
      D.DESCUENTO / :TIPOCAMBIO,
      D.SUBTOTAL / :TIPOCAMBIO,
      D.IVA / :TIPOCAMBIO,
      D.TOTAL  / :TIPOCAMBIO,
      coalesce(S.NOMBRE,' ') as SUCURSALT ,
      coalesce(TD.nombre, ' ') AS TIPODOC ,
      0.00 ,
      0.00 ,
      'PZA',
      '',
      '',
      '',
      '',
      '',
      '',
      0.00,
      0.00,
      0.00,
      0.00,
      CURRENT_DATE,
      CURRENT_DATE,
      '',
      1 ,

      0 cajas,
      1 piezassueltas ,

     
      D.IEPS / :TIPOCAMBIO,
      D.IMPUESTO / :TIPOCAMBIO ,
      0.0,--M.TASAIEPS  ,
      D.TOTAL PRECIOLISTA ,
      'N'  ESKIT,
      'N'  ESPARTEKIT,
      0 MOVTOID,
      0 PRODUCTOID ,
      D.DOCTOKITREFID ,
      0 MOVTOREFID ,
      '' ,
      NULL,
      NULL,
      NULL

   FROM DOCTO D
   LEFT JOIN TURNO T ON T.ID = D.TURNOID
   LEFT JOIN SUCURSAL S ON S.ID = D.SUCURSALTID
   LEFT JOIN TIPODOCTO  TD ON  TD.id = d.tipodoctoid
   LEFT JOIN parametro ON 1 = 1
   LEFT JOIN DOCTO DR ON DR.ID = D.DOCTOREFID
   WHERE D.id = :DOCTOID
   into
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
      :PIEZASSUELTAS,
      :IEPS,
      :IMPUESTO ,
      :PORCENTAJEIEPS ,
      :PRECIOLISTA ,

      :ESKIT,
      :ESPARTEKIT,

      :MOVTOID ,
      :PRODUCTOID ,
      :DOCTOKITREFID ,
      :MOVTOREFID,
      :DESCPZACAJA,
      :SAT_CLAVEPRODSERV,
      :SAT_CLAVEUNIDAD,
      :SAT_DESCRIPCIONUNIDAD;

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

      IEPS = 0;
      IMPUESTO = 0;
      PORCENTAJEIEPS = 0;
      PRECIOLISTA = 0;

      ESKIT = 'N';
      ESPARTEKIT = 'N';

      
      DOCTOID = 0;
      MOVTOID = 0;
      PRODUCTOID = 0;
      DOCTOKITREFID = 0;
      MOVTOREFID = 0;
      DESCPZACAJA = '';

      STRPEDIMENTO = '';

      
    KITMOVTOID  = 0;
    KITPRODUCTOID  = 0;
    KITPRODCLAVE  = '';
    KITPRODNOMBRE  = '';
    KITPRODDESCRIPCION1 = '';
    KITCANTIDAD  = 0.0;

    KITDESCPZACAJA = '';

    SAT_CLAVEPRODSERV = NULL;
    SAT_CLAVEUNIDAD = NULL;
    SAT_DESCRIPCIONUNIDAD = NULL; 
    IVARETENIDO = 0.00;
    ISRRETENIDO = 0.00;  
    SAT_NOMBRE_UNIDAD = NULL;     
    SAT_IVATRASLADADO_CONC = NULL;
    SAT_IEPSTRASLADADO_CONC = NULL; 
    PLAZOCLAVE = NULL;
      -- sin suspend para no regresar renglon falso
   end

END