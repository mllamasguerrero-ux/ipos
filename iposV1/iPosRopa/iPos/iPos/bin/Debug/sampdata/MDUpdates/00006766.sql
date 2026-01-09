create or alter procedure FACTURAELECTRONICA_XML_CORE_2 (
    DOCTOID D_FK,
    DESGLOSEIEPSPARENT D_BOOLCN_NULL,
    MOSTRARDESCUENTOPARENT D_BOOLCN_NULL)
returns (
    ID D_FK,
    TIPOLINEA D_NOMBRE_NULL,
    PADRELINEA integer,
    ORDENLINEA integer,
    SUBORDEN integer,
    SERIE D_STDTEXT_64,
    FOLIO D_STDTEXT_64,
    FECHA D_TIMESTAMP,
    TIPOCOMPROBANTE D_STDTEXT_64,
    FORMAPAGO D_STDTEXT_64,
    SUBTOTAL D_IMPORTE,
    DESCUENTO D_IMPORTE,
    TOTAL D_IMPORTE,
    MONEDA D_STDTEXT_64,
    TIPOCAMBIO D_STDTEXT_64,
    CONDICIONESPAGO D_STDTEXT_LARGE,
    METODOPAGO D_STDTEXT_64,
    MOTIVODESCUENTO D_STDTEXT_64,
    LUGAREXPEDICION D_STDTEXT_LARGE,
    NUMEROCTAPAGO D_STDTEXT_LARGE,
    SERIEFOLIOFISCALORIGINAL D_STDTEXT_64,
    FOLIOFISCALORIGINAL D_STDTEXT_64,
    MONTOFOLIOFISCALORIGINAL D_IMPORTE,
    FECHAFOLIOFISCALORIGINAL D_FECHA,
    RFC D_STDTEXT_64,
    RAZONSOCIAL D_STDTEXT_LARGE,
    REGIMENFISCAL D_STDTEXT_64,
    CALLE D_STDTEXT_LARGE,
    NOINTERIOR D_STDTEXT_64,
    NOEXTERIOR D_STDTEXT_64,
    COLONIA D_STDTEXT_LARGE,
    LOCALIDAD D_STDTEXT_LARGE,
    REFERENCIA D_STDTEXT_LARGE,
    MUNICIPIO D_STDTEXT_LARGE,
    ESTADO D_STDTEXT_MEDIUM,
    PAIS D_STDTEXT_64,
    CODIGOPOSTAL D_STDTEXT_64,
    NOMBRE D_STDTEXT_LARGE,
    RESIDENCIAFISCAL D_STDTEXT_LARGE,
    NUMREGIDTRIB D_STDTEXT_64,
    USOCFDI D_STDTEXT_64,
    CANTIDAD D_CANTIDAD,
    UNIDAD D_STDTEXT_64,
    DESCRIPCION D_SAT_DESCRIPCION,
    VALORUNITARIO D_IMPORTE,
    IMPORTE D_IMPORTE,
    NOIDENTIFICACION D_STDTEXT_64,
    CUENTAPREDIAL D_STDTEXT_64,
    CLAVEPRODSERV D_STDTEXT_64,
    CLAVEUNIDAD D_STDTEXT_64,
    NUMERO D_STDTEXT_64,
    ADUANA D_STDTEXT_64,
    IMPUESTO D_STDTEXT_64,
    TASA D_PORCENTAJE,
    BASEIMP D_COSTO,
    TIPOFACTOR D_STDTEXT_64,
    TASACUOTA D_STDTEXT_64,
    FECHAPAGO D_FECHA,
    FORMADEPAGOP D_STDTEXT_64,
    MONEDAP D_STDTEXT_64,
    TIPOCAMBIOP D_STDTEXT_64,
    MONTO D_IMPORTE,
    NUMOPERACION D_STDTEXT_64,
    RFCEMISORCTAORD D_STDTEXT_64,
    NOMBANCOORDEXT D_NOMBRE_NULL,
    CTAORDENANTE D_STDTEXT_64,
    RFCEMISORCTABEN D_STDTEXT_64,
    CTABENEFICIARIO D_STDTEXT_64,
    TIPOCADPAGO D_STDTEXT_64,
    CERTPAGO D_STDTEXT_64,
    CADPAGO D_STDTEXT_64,
    SELLOPAGO D_STDTEXT_64,
    IDDOCUMENTO D_STDTEXT_64,
    MONEDADR D_STDTEXT_64,
    TIPOCAMBIODR D_STDTEXT_64,
    METODODEPAGODR D_STDTEXT_64,
    NUMPARCIALIDAD D_STDTEXT_64,
    IMPSALDOANT D_IMPORTE,
    IMPPAGADO D_IMPORTE,
    IMPSALDOINSOLUTO D_IMPORTE,
    TOTALTRASLADOS D_IMPORTE,
    TOTALRETENCIONES D_IMPORTE,
    TIPORELACION D_STDTEXT_64,
    UUID D_STDTEXT_64,
    IMPRIMIRCOMPROBANTESPAGO D_BOOLCN,
    NUMEROPEDIMENTO D_STDTEXT_64,
    MOVTOID D_FK,
    MOVTOKITID D_FK,
    PAGOSATID D_FK,
    MOVTOREFID D_FK,
    EXPORTACION D_STDTEXT_64,
    OBJETOIMP D_STDTEXT_64,
    DOMICILIOFISCAL D_STDTEXT_64,
    PERIODICIDAD D_STDTEXT_64,
    MESES D_STDTEXT_64,
    ANIO D_STDTEXT_64)
as
declare variable TIPODOCTOID D_FK;
declare variable ESVERSION33 D_BOOLCS;
declare variable ESRECIBOELECTRONICO D_BOOLCN;
declare variable CUENTADOCTOPAGOCREDITO integer;
declare variable PAGOACREDITO D_BOOLCN;
declare variable CUENTAPAGOSNOCREDITO integer;
declare variable PAGOENUNASOLAEXIBICION D_BOOLCN;
declare variable EMPRESA_FISCALCODIGOPOSTAL D_STDTEXT_64;
declare variable PERSONADESGLOSAIEPS D_BOOLCN;
declare variable EMPRESADESGLOSAIEPS D_BOOLCN;
declare variable PERSONAID D_FK;
declare variable MOSTRARDESCUENTOENFACTURA D_BOOLCN;
declare variable SUBTOTAL_D D_IMPORTE;
declare variable DESCUENTO_D D_IMPORTE;
declare variable USARFISCALESENEXPEDICION D_BOOLCN;
declare variable IDLINEANIVEL1 D_FK;
declare variable IDLINEANIVEL2 D_FK;
declare variable MANEJALOTEIMPORTACION D_BOOLCN;
declare variable DESGLOSARIEPSMOVTO D_BOOLCN;
declare variable SUBTOTALMOVTO D_IMPORTE;
declare variable PORCENTAJEIEPSMOVTO D_PORCENTAJE;
declare variable PORCENTAJEIVAMOVTO D_PORCENTAJE;
declare variable MONTOIVAMOVTO D_IMPORTE;
declare variable MONTOIEPSMOVTO D_PORCENTAJE;
declare variable MONTOIVARETENIDOMOVTO D_IMPORTE;
declare variable PORCENTAJEIVARETENIDOMOVTO D_PORCENTAJE;
declare variable PERSONARETIENEIVA D_BOOLCN;
declare variable PERSONARETIENEISR D_BOOLCN;
declare variable ESARRENDATARIO D_BOOLCN;
declare variable MONTOISRRETENIDOMOVTO D_IMPORTE;
declare variable PORCENTAJEISRRETENIDOMOVTO D_PORCENTAJE;
declare variable SUMAIEPSTRASLADADO D_IMPORTE;
declare variable SUMAIVATRASLADADO D_IMPORTE;
declare variable SUMAISRRETENIDO D_IMPORTE;
declare variable SUMAIVARETENIDO D_IMPORTE;
declare variable ESKIT D_BOOLCN;
declare variable ERRORCODE D_ERRORCODE;
declare variable DOCTOKITREFID D_FK;
declare variable DESCUENTOMOVTO D_IMPORTE;
declare variable PRE_FORMAPAGOSAT D_STDTEXT_SHORT;
declare variable SUBTIPODOCTOID D_FK;
declare variable ANIOADUANEROMIN varchar(2);
declare variable ANIOADUANERO varchar(2);
declare variable DOCTOREFID D_FK;
declare variable CUENTADESCUENTOSNEGATIVOS integer;
declare variable SUBTOTALCONS D_IMPORTE;
declare variable DOCTOIDCONS D_FK;
declare variable DOCTOFOLIOCONS D_DOCTOFOLIO;
declare variable IVACONS D_IMPORTE;
declare variable TOTALCONS D_IMPORTE;
declare variable IEPSCONS D_IMPORTE;
declare variable SUMASUBTOTALDEVOCONS D_IMPORTE;
declare variable PERSONADESGLOSAIEPSCONS D_BOOLCN;
declare variable DOCTODEVOCONSID D_FK;
declare variable DESGLOSEIEPSLOCAL D_BOOLCN_NULL;
declare variable DOCTOIDCONSMAYOR D_FK;
declare variable OMITIRVALES D_BOOLCN_NULL;
declare variable PREGUNTARDATOSENTREGA D_BOOLCN;
declare variable PERSONAENTREGACALLE D_STDTEXT_MEDIUM;
declare variable DESGLOSEIEPSFACTURA D_BOOLCN;
declare variable KITIMPFIJO D_BOOLCN;
BEGIN

   ID = 1;
   TIPOLINEA = 'COMPROBANTE';
   ESVERSION33 = 'S';
   ESRECIBOELECTRONICO = 'N';
   IMPRIMIRCOMPROBANTESPAGO = 'N';
   PAGOENUNASOLAEXIBICION = 'N';
   MONEDA = 'MXN'; MONEDAP = 'MXN'; MONEDADR = 'MXN'; TIPOCAMBIO = ''; TIPOCAMBIOP = ''; TIPOCAMBIODR = '';

   
   SELECT PARAMETRO.fiscalcodigopostal,  parametro.desgloseieps,PARAMETRO.mostrardescuentofactura , USARFISCALESENEXPEDICION   ,
      PARAMETRO.manejarloteimportacion , PARAMETRO.arrendatario, PARAMETRO.preguntardatosentrega  , PARAMETRO.desgloseiepsfactura
    FROM PARAMETRO
    INTO :EMPRESA_FISCALCODIGOPOSTAL, :EMPRESADESGLOSAIEPS, :MOSTRARDESCUENTOENFACTURA, :USARFISCALESENEXPEDICION,
      :MANEJALOTEIMPORTACION, :ESARRENDATARIO, :PREGUNTARDATOSENTREGA, :DESGLOSEIEPSFACTURA;


    IF( :MOSTRARDESCUENTOPARENT IS NOT NULL ) THEN
    BEGIN
        MOSTRARDESCUENTOENFACTURA = :MOSTRARDESCUENTOPARENT;
    END

   SELECT PERSONAID, TIPODOCTOID, PAGOACREDITO,  TIMBRADOFORMAPAGOSAT , SUBTIPODOCTOID , DOCTOREFID
    FROM docto WHERE ID = :DOCTOID
    INTO :PERSONAID, :TIPODOCTOID, :PAGOACREDITO, :PRE_FORMAPAGOSAT, :SUBTIPODOCTOID, :DOCTOREFID;

    SELECT PERSONA.desgloseieps, PERSONA.retieneisr ,PERSONA.RETIENEIVA FROM PERSONA WHERE ID = :PERSONAID INTO :PERSONADESGLOSAIEPS, :PERSONARETIENEISR,  :PERSONARETIENEIVA;

   IF(:TIPODOCTOID IN (21,701)) THEN
   BEGIN    
        TIPOCOMPROBANTE = 'I';
   END
   ELSE IF(:TIPODOCTOID IN (22)) THEN
   BEGIN  
        TIPOCOMPROBANTE = 'E';
   END 
   ELSE IF(:TIPODOCTOID IN (205)) THEN
   BEGIN  
        TIPOCOMPROBANTE = 'P';
   END

   IF(:TIPODOCTOID IN (701)) THEN
   BEGIN
        MOSTRARDESCUENTOENFACTURA = 'N';
   END

   
   DESGLOSEIEPSLOCAL = CASE WHEN
                                        (((COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' or COALESCE(:TIPODOCTOID,0) = 701 ) AND COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S') or (:DESGLOSEIEPSPARENT IS NOT NULL AND :DESGLOSEIEPSPARENT = 'S'))
                                        AND (:DESGLOSEIEPSPARENT IS  NULL OR :DESGLOSEIEPSPARENT <> 'N') THEN
                                        'S' ELSE 'N' END;

   --CONCEPTOS SI NO ESTAMOS EN RECIBO ELECTRONICO
      FOR SELECT M.ID, M.CANTIDAD, SATUM.sat_nombre,
                 CASE WHEN P.descripcion_comodin = 'S' AND M.descripcion1 IS NOT NULL AND M.descripcion1 <> '' THEN M.DESCRIPCION1 || ' ' || COALESCE(M.descripcion2,  '')  || ' ' || COALESCE(M.descripcion3,  '') ELSE  P.DESCRIPCION1   END descripcion1,
                ROUND( (COALESCE(M.SUBTOTAL,0) +
                        CASE when COALESCE(:DESGLOSEIEPSLOCAL,'N') = 'S'   THEN 0.0 ELSE COALESCE(M.IEPS,0.0) END +
                        CASE WHEN COALESCE(:MOSTRARDESCUENTOENFACTURA,'N') = 'S' THEN COALESCE(M.DESCUENTO,0) ELSE 0.0 END)  / COALESCE(M.cantidad, 1.0)
                     , 2) VALORUNITARIO ,
                 COALESCE(M.SUBTOTAL,0) +
                  CASE when COALESCE(:DESGLOSEIEPSLOCAL,'N') = 'S'   THEN 0.0 ELSE COALESCE(M.IEPS,0.0) END +
                  CASE WHEN COALESCE(:MOSTRARDESCUENTOENFACTURA,'N') = 'S' THEN COALESCE(M.DESCUENTO,0) ELSE 0.0 END SUBTOTAL,
                  P.CLAVE,
                  CASE WHEN COALESCE(PRM.ARRENDATARIO,'') = 'S' AND COALESCE(P.CUENTAPREDIAL,'') <> '' THEN  P.cuentapredial ELSE '' END,
                 SATPS.sat_claveprodserv,
                 SATUM.sat_clave,
                 CASE WHEN COALESCE(:MOSTRARDESCUENTOENFACTURA,'N') = 'S' THEN COALESCE(M.DESCUENTO,0) ELSE 0.0 END DESCUENTO,
                 :DESGLOSEIEPSLOCAL  DESGLOSARIEPSMOVTO,
                CASE when COALESCE(:DESGLOSEIEPSLOCAL,'N') = 'S'  THEN M.TASAieps ELSE 0.0 END TASAIEPS,
                 M.tasaiva ,
                 M.IVA,
                 CASE when COALESCE(:DESGLOSEIEPSLOCAL,'N') = 'S'  THEN M.ieps ELSE 0.0 END,
                   M.IVARETENIDO  , M.tasaivaretenido  ,
                   M.isrretenido, M.TASAISRRETENIDO ,
                   P.ESKIT,
                   P.KITIMPFIJO,
                   M.MOVTOREFID,
                   CASE when (COALESCE(:DESGLOSEIEPSLOCAL,'N') <> 'S' or (COALESCE(M.IEPS,0) = 0)) AND
                              COALESCE(M.IVA,0) = 0 THEN '03'
                        --WHEN  (COALESCE(:DESGLOSEIEPSLOCAL,'N') = 'S' or (COALESCE(M.IEPS,0) > 0)) AND
                       --       COALESCE(M.IVA,0) = 0  THEN '03'
                   ELSE '02' END
                   OBJETOIMP
                 FROM MOVTO M
                 LEFT JOIN PRODUCTO P ON P.ID = M.productoid
                 LEFT JOIN UNIDAD U ON U.CLAVE = P.unidad
                 LEFT JOIN SAT_UNIDADMEDIDA SATUM ON SATUM.ID = U.sat_unidadmedidaid
                 LEFT JOIN SAT_PRODUCTOSERVICIO SATPS ON SATPS.id = P.sat_productoservicioid
                 LEFT JOIN PARAMETRO PRM ON 1 = 1
                 WHERE M.DOCTOID = :DOCTOID
                      AND :TIPODOCTOID NOT IN (701,205)
                      and coalesce(M.cantidad,0) > 0
                 INTO
                 :MOVTOID, :cantidad , :unidad ,
                 :descripcion , :valorUnitario , :SUBTOTALMOVTO,
                 :noIdentificacion, :cuentaPredial, :claveProdServ ,
                 :claveUnidad , :descuentoMOVTO, :DESGLOSARIEPSMOVTO,
                 :PORCENTAJEIEPSMOVTO, :PORCENTAJEIVAMOVTO , :MONTOIVAMOVTO , :MONTOIEPSMOVTO , :MONTOIVARETENIDOMOVTO, :PORCENTAJEIVARETENIDOMOVTO,
                  :MONTOISRRETENIDOMOVTO, :PORCENTAJEISRRETENIDOMOVTO, :ESKIT, :KITIMPFIJO, :MOVTOREFID, :OBJETOIMP
                 DO
                 BEGIN

                   IMPORTE = :SUBTOTALMOVTO;
                   DESCUENTO = :DESCUENTOMOVTO;

                   ID = :ID + 1;
                   TIPOLINEA = 'CONCEPTO';
                   SUSPEND;

                   PADRELINEA = :ID;


                   select  lpad(cast((mod(extract(year from current_date), 1000) - 10) as varchar(2)) , 2, '0')
                    from rdb$database
                    INTO :ANIOADUANEROMIN;

                   IF(COALESCE(:MANEJALOTEIMPORTACION,'N') = 'S') THEN
                   BEGIN
                    
                    FOR select
                        lotesimportados.pedimento IMPORTACION_PEDIMENTO,
                        lotesimportados.fechaimportacion IMPORTACION_FECHA,
                        coalesce(sat_aduana.sat_claveaduana, lotesimportados.aduana)  IMPORTACION_ADUANA_SAT
                    from docto
                        inner join movto on movto.doctoid = docto.id
                        inner join movto mlp on mlp.doctoid = coalesce(docto.loteimportadodoctoid, docto.id) and mlp.productoid = movto.productoid  and coalesce(mlp.lote,'') = coalesce(movto.lote,'')  and mlp.precio = movto.precio
                        inner join lotesimportados on lotesimportados.id = mlp.loteimportado
                        left join sat_aduana on lotesimportados.sataduanaid = sat_aduana.id
                    where docto.id = :DOCTOID  AND MOVTO.ID = :MOVTOID
                     INTO :NUMERO, :FECHA, :ADUANA
                     DO
                     BEGIN
                          ANIOADUANERO = SUBSTRING(:NUMERO FROM 1 FOR 2);
                          IF(COALESCE(:anioaduanero, '') >= COALESCE(:ANIOADUANEROMIN,'')) THEN
                          BEGIN
                                ID = :ID + 1;
                                TIPOLINEA = 'INFORMACIONADUANERA';
                                SUSPEND;
                          END
                     END  
                   END

                   IF(COALESCE(:ESKIT,'N') <> 'S' OR COALESCE(:KITIMPFIJO,'N') = 'S') THEN
                   BEGIN

                     --IEPS
                     IF( COALESCE(:DESGLOSARIEPSMOVTO,'N') = 'S' ) THEN
                     BEGIN
                        Impuesto = '003';
                        Tasa = :PORCENTAJEIEPSMOVTO;
                        TasaCuota = :PORCENTAJEIEPSMOVTO;
                        Importe = :MONTOIEPSMOVTO;
                        TipoFactor = 'Tasa';
                        ID = :ID + 1;
                        TIPOLINEA = 'CONCEPTO_IEPS';
                        BaseImp = :SUBTOTALMOVTO - :DESCUENTOMOVTO;

                        IF(COALESCE(:IMPORTE,0) <> 0 ) THEN
                        BEGIN   
                            SUSPEND;
                        END

                     END

                       
                     --IVA
                     IF( COALESCE(:MONTOIVAMOVTO,0.0) >= 0.00) THEN
                     BEGIN
                        Impuesto = '002';
                        Tasa = :PORCENTAJEIVAMOVTO;
                        TasaCuota = :PORCENTAJEIVAMOVTO;
                        Importe = :MONTOIVAMOVTO;
                        TipoFactor = 'Tasa';
                        BaseImp =  COALESCE(:SUBTOTALMOVTO,0.0) + COALESCE(:MONTOIEPSMOVTO,0.0) -  :DESCUENTOMOVTO;

                        ID = :ID + 1;
                        TIPOLINEA = 'CONCEPTO_IVA';
                        
                        IF(COALESCE(:IMPORTE,0) >= 0.00 ) THEN
                        BEGIN   
                            SUSPEND;
                        END

                     END

                     --RETIENE IVA
                     IF( COALESCE(:PERSONARETIENEIVA,'N') = 'S' AND
                         COALESCE(:ESARRENDATARIO, 'N') = 'S'  AND
                         COALESCE(:MONTOIVARETENIDOMOVTO,0.0) >= 0.01)THEN
                     BEGIN  
                        Impuesto = '002';
                        Tasa = :PORCENTAJEIVARETENIDOMOVTO;
                        TasaCuota = :PORCENTAJEIVARETENIDOMOVTO;
                        Importe = :MONTOIVARETENIDOMOVTO;
                        TipoFactor = 'Tasa';
                        BaseImp = COALESCE(:SUBTOTALMOVTO,0) + COALESCE(:MONTOIEPSMOVTO,0) - :DESCUENTOMOVTO;

                        ID = :ID + 1;
                        TIPOLINEA = 'CONCEPTO_IVARETENIDO';
                        
                        IF(COALESCE(:IMPORTE,0) <> 0 ) THEN
                        BEGIN   
                            SUSPEND;
                        END
                     END

                     --RETIENE ISR
                     IF( COALESCE(:PERSONARETIENEISR,'N') = 'S' AND
                         COALESCE(:ESARRENDATARIO, 'N') = 'S'  AND
                         COALESCE(:MONTOISRRETENIDOMOVTO,0.0) >= 0.01)THEN
                     BEGIN  
                        Impuesto = '001';
                        Tasa = :PORCENTAJEISRRETENIDOMOVTO;
                        TasaCuota = :PORCENTAJEISRRETENIDOMOVTO;
                        Importe = :MONTOISRRETENIDOMOVTO;
                        TipoFactor = 'Tasa';
                        BaseImp = COALESCE(:SUBTOTALMOVTO,0) + COALESCE(:MONTOIEPSMOVTO,0) - :DESCUENTOMOVTO;

                        ID = :ID + 1;
                        TIPOLINEA = 'CONCEPTO_ISRRETENIDO';
                        
                        IF(COALESCE(:IMPORTE,0) <> 0 ) THEN
                        BEGIN   
                            SUSPEND;
                        END
                     END

                   END
                   ELSE
                   BEGIN
                        FOR SELECT SAT_PRODUCTOSERVICIO.sat_claveprodserv, PRODUCTO.CLAVE, DETALLEKITCANTIDAD, SAT_UNIDADMEDIDA.sat_nombre, PRODUCTO.descripcion1,
                        ROUND( CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'  AND COALESCE(DETALLEKITCANTIDAD,0.0) <> 0 THEN
                                        COALESCE(DETALLEKITPRECIO,0.0)
                                    ELSE
                                        (COALESCE(DETALLEKITSUBTOTAL,0) + COALESCE(DETALLEKITIEPS,0.0)) / COALESCE(DETALLEKITCANTIDAD,0)
                                END, 2) VALORUNITARIO ,

                        COALESCE(DETALLEKITSUBTOTAL,0) +
                            CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND
                            COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'  THEN 0.0 ELSE COALESCE(DETALLEKITIEPS,0.0) END SUBTOTAL,
                             '' NUMEROPEDIMENTO ,
                             DETALLEKITMOVTOID
                        FROM
                            (SELECT DETALLEKITCANTIDAD ,DETALLEKITTASAIVA ,DETALLEKITTASAIEPS , DETALLEKITTASAIMPUESTO ,DETALLEKITTOTAL ,DETALLEKITSUBTOTAL ,DETALLEKITIVA ,DETALLEKITIEPS ,DETALLEKITPRECIO ,DETALLEKITPRECIOLISTA , DETALLEKITPRODUCTOID, 0.0 DETALLEKITTASAIVARETENIDO, 0.0 DETALLEKITIVARETENIDO, 0.0 DETALLEKITTASAISRRETENIDO, 0.0 DETALLEKITISRRETENIDO, DETALLEKITMOVTOID  FROM  KIT_OBTENREFERENCIA (:DOCTOID,:MOVTOID,'S')) KITREF
                            LEFT JOIN PRODUCTO ON PRODUCTO.ID = KITREF.DETALLEKITPRODUCTOID
                            LEFT JOIN UNIDAD ON UNIDAD.CLAVE = PRODUCTO.unidad
                            LEFT JOIN SAT_UNIDADMEDIDA ON SAT_UNIDADMEDIDA.ID = UNIDAD.sat_unidadmedidaid
                            LEFT JOIN SAT_PRODUCTOSERVICIO ON SAT_PRODUCTOSERVICIO.id = PRODUCTO.sat_productoservicioid
                            LEFT JOIN PARAMETRO ON 1 = 1
                        WHERE ROUND( CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'  AND COALESCE(DETALLEKITCANTIDAD,0.0) <> 0 THEN
                                        COALESCE(DETALLEKITPRECIO,0.0)
                                    ELSE
                                        (COALESCE(DETALLEKITSUBTOTAL,0) + COALESCE(DETALLEKITIEPS,0.0)) / COALESCE(DETALLEKITCANTIDAD,0)
                                END, 2) > 0.0 --que valor unitario sea mayor que cero
                        INTO
                            :CLAVEPRODSERV, :NOIDENTIFICACION ,:CANTIDAD , :UNIDAD , :DESCRIPCION ,
                            :VALORUNITARIO, :IMPORTE , :NUMEROPEDIMENTO , :MOVTOKITID
                        DO
                        BEGIN
                                ID = :ID + 1;
                                TIPOLINEA = 'CONCEPTO_PARTE';
                                SUSPEND;
                        END

                        --IEPS
                        IF(COALESCE(:DESGLOSARIEPSMOVTO,'N') = 'S' ) THEN
                        BEGIN

                            FOR SELECT '003' IMPUESTO, DETALLEKITTASAIEPS TASA, COALESCE(DETALLEKITTASAIEPS, 0.0) TASACUOTA, SUM(COALESCE(DETALLEKITIEPS, 0.0)) IMPORTE, 'Tasa' tipofactor,
                                    SUM(COALESCE(DETALLEKITBASEIEPS,0)) BASEIMP
                                    FROM  (SELECT DETALLEKITCANTIDAD ,DETALLEKITTASAIVA ,DETALLEKITTASAIEPS , DETALLEKITTASAIMPUESTO ,DETALLEKITTOTAL ,DETALLEKITSUBTOTAL ,DETALLEKITIVA ,DETALLEKITIEPS ,DETALLEKITPRECIO ,DETALLEKITPRECIOLISTA , DETALLEKITPRODUCTOID, 0.0 DETALLEKITTASAIVARETENIDO, 0.0 DETALLEKITIVARETENIDO, 0.0 DETALLEKITTASAISRRETENIDO, 0.0 DETALLEKITISRRETENIDO, DETALLEKITBASEIVA, DETALLEKITBASEIEPS  FROM  KIT_OBTENREFERENCIA (:DOCTOID,:MOVTOID,'S')) KITREF
                                    LEFT JOIN PRODUCTO ON PRODUCTO.ID = DETALLEKITproductoid
                                --WHERE RECIBOS_CORE.MOVTOID = :MOVTOID
                                GROUP BY  DETALLEKITtasaieps
                                INTO :IMPUESTO, :TASA, :TASACUOTA , :IMPORTE, :TIPOFACTOR, :BASEIMP
                                DO BEGIN
                                    IF(COALESCE(:importe, 0.0) > 0) THEN
                                    BEGIN
                                        ID = :ID + 1;
                                        TIPOLINEA = 'CONCEPTO_IEPS';
                                        SUSPEND;
                                    END
                                END
                        END

                        --IVA
                            FOR SELECT '002' IMPUESTO, DETALLEKITTASAIVA TASA, COALESCE(DETALLEKITTASAIVA, 0.0) TASACUOTA, SUM(COALESCE(DETALLEKITIVA, 0.0)) IMPORTE, 'Tasa' tipofactor,
                                     SUM( CASE WHEN DETALLEKITTASAIVA = 0.00 THEN COALESCE(DETALLEKITSUBTOTAL,0) ELSE COALESCE(DETALLEKITBASEIVA,0) END  ) BASEIMP
                                    FROM  (SELECT DETALLEKITCANTIDAD ,DETALLEKITTASAIVA ,DETALLEKITTASAIEPS , DETALLEKITTASAIMPUESTO ,DETALLEKITTOTAL ,DETALLEKITSUBTOTAL ,DETALLEKITIVA ,DETALLEKITIEPS ,DETALLEKITPRECIO ,DETALLEKITPRECIOLISTA , DETALLEKITPRODUCTOID, 0.0 DETALLEKITTASAIVARETENIDO, 0.0 DETALLEKITIVARETENIDO, 0.0 DETALLEKITTASAISRRETENIDO, 0.0 DETALLEKITISRRETENIDO, DETALLEKITBASEIVA, DETALLEKITBASEIEPS  FROM  KIT_OBTENREFERENCIA (:DOCTOID,:MOVTOID,'S')) KITREF
                                    LEFT JOIN PRODUCTO ON PRODUCTO.ID = DETALLEKITproductoid
                                --WHERE RECIBOS_CORE.MOVTOID = :MOVTOID
                                GROUP BY  DETALLEKITTASAIVA
                                INTO :IMPUESTO, :TASA, :TASACUOTA , :IMPORTE, :TIPOFACTOR, :BASEIMP
                                DO BEGIN
                                    IF(COALESCE(:importe, 0.0) >= 0.00) THEN
                                    BEGIN
                                        ID = :ID + 1;
                                        TIPOLINEA = 'CONCEPTO_IVA';
                                        SUSPEND;
                                    END
                                END

                        --RETIENE IVA
                        IF( COALESCE(:PERSONARETIENEIVA,'N') = 'S' AND
                            COALESCE(:ESARRENDATARIO, 'N') = 'S' ) THEN
                        BEGIN
                            FOR SELECT '002' IMPUESTO, DETALLEKITTASAIVARETENIDO TASA, COALESCE(DETALLEKITTASAIVARETENIDO, 0.0) TASACUOTA, SUM(COALESCE(DETALLEKITivaretenido, 0.0)) IMPORTE, 'Tasa' tipofactor,
                                    SUM(COALESCE(DETALLEKITSUBTOTAL,0) + COALESCE(DETALLEKITIEPS,0.0) ) BASEIMP
                                    FROM  (SELECT DETALLEKITCANTIDAD ,DETALLEKITTASAIVA ,DETALLEKITTASAIEPS , DETALLEKITTASAIMPUESTO ,DETALLEKITTOTAL ,DETALLEKITSUBTOTAL ,DETALLEKITIVA ,DETALLEKITIEPS ,DETALLEKITPRECIO ,DETALLEKITPRECIOLISTA , DETALLEKITPRODUCTOID, 0.0 DETALLEKITTASAIVARETENIDO, 0.0 DETALLEKITIVARETENIDO, 0.0 DETALLEKITTASAISRRETENIDO, 0.0 DETALLEKITISRRETENIDO, DETALLEKITBASEIVA, DETALLEKITBASEIEPS  FROM  KIT_OBTENREFERENCIA (:DOCTOID,:MOVTOID,'S')) KITREF
                                    LEFT JOIN PRODUCTO ON PRODUCTO.ID = DETALLEKITproductoid
                                --WHERE RECIBOS_CORE.MOVTOID = :MOVTOID
                                GROUP BY  DETALLEKITTASAIVARETENIDO
                                INTO :IMPUESTO, :TASA, :TASACUOTA , :IMPORTE, :TIPOFACTOR, :BASEIMP
                                DO BEGIN
                                    IF(COALESCE(:importe, 0.0) > 0) THEN
                                    BEGIN
                                        ID = :ID + 1;
                                        TIPOLINEA = 'CONCEPTO_IVARETENIDO';
                                        SUSPEND;
                                    END
                                END
                        END

                        --RETIENE ISR
                        IF( COALESCE(:PERSONARETIENEISR,'N') = 'S' AND
                            COALESCE(:ESARRENDATARIO, 'N') = 'S' ) THEN
                        BEGIN
                            FOR SELECT '001' IMPUESTO, DETALLEKITTASAISRRETENIDO TASA, COALESCE(DETALLEKITTASAISRRETENIDO, 0.0) TASACUOTA, SUM(COALESCE(DETALLEKITisrretenido, 0.0)) IMPORTE, 'Tasa' tipofactor,
                                    SUM(COALESCE(DETALLEKITSUBTOTAL,0) + COALESCE(DETALLEKITIEPS,0.0) ) BASEIMP
                                    FROM  (SELECT DETALLEKITCANTIDAD ,DETALLEKITTASAIVA ,DETALLEKITTASAIEPS , DETALLEKITTASAIMPUESTO ,DETALLEKITTOTAL ,DETALLEKITSUBTOTAL ,DETALLEKITIVA ,DETALLEKITIEPS ,DETALLEKITPRECIO ,DETALLEKITPRECIOLISTA , DETALLEKITPRODUCTOID, 0.0 DETALLEKITTASAIVARETENIDO, 0.0 DETALLEKITIVARETENIDO, 0.0 DETALLEKITTASAISRRETENIDO, 0.0 DETALLEKITISRRETENIDO, DETALLEKITBASEIVA, DETALLEKITBASEIEPS  FROM  KIT_OBTENREFERENCIA (:DOCTOID,:MOVTOID,'S')) KITREF
                                    LEFT JOIN PRODUCTO ON PRODUCTO.ID = DETALLEKITproductoid
                                --WHERE RECIBOS_CORE.MOVTOID = :MOVTOID
                                GROUP BY  DETALLEKITTASAISRRETENIDO
                                INTO :IMPUESTO, :TASA, :TASACUOTA , :IMPORTE, :TIPOFACTOR, :BASEIMP
                                DO BEGIN
                                    IF(COALESCE(:importe, 0.0) > 0) THEN
                                    BEGIN
                                        ID = :ID + 1;
                                        TIPOLINEA = 'CONCEPTO_ISRRETENIDO';
                                        SUSPEND;
                                    END
                                END
                        END
                   END
                 END

END