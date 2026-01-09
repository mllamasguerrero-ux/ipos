create or alter procedure FACTURAELECTRONICA_XML_CORE_3 (
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
declare variable MONTOSUBTOTALMOVTO D_IMPORTE;
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
declare variable PAGODOCTOSATID D_FK;
declare variable IDLINEAPAGO integer;
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

   
   DESGLOSEIEPSLOCAL = CASE WHEN
                                        (((COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' or COALESCE(:TIPODOCTOID,0) = 701 ) AND COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S') or (:DESGLOSEIEPSPARENT IS NOT NULL AND :DESGLOSEIEPSPARENT = 'S'))
                                        AND (:DESGLOSEIEPSPARENT IS  NULL OR :DESGLOSEIEPSPARENT <> 'N') THEN
                                        'S' ELSE 'N' END;


                 PADRELINEA = 0;
                  --CONCEPTO FACTURA GLOBAL
                  IF(COALESCE(:TIPODOCTOID,0) = 701) THEN
                  BEGIN

                     OMITIRVALES = COALESCE(:OMITIRVALES,'N');

                    FOR SELECT DOCTO.ID, DOCTO.folio,
                            CASE WHEN :OMITIRVALES = 'S' THEN DOCTO.sinvale_iva ELSE DOCTO.iva END,
                            CASE WHEN :OMITIRVALES = 'S' THEN DOCTO.SINVALE_TOTAL ELSE DOCTO.total END,
                            CASE WHEN :OMITIRVALES = 'S' THEN DOCTO.SINVALE_IEPS ELSE DOCTO.ieps END ,
                            COALESCE(
                                CASE WHEN :OMITIRVALES = 'S' THEN DOCTO.SINVALE_SUBTOTAL ELSE DOCTO.SUBTOTAL END
                                ,0) +    CASE when COALESCE(:DESGLOSEIEPSLOCAL,'N') = 'S'  THEN 0.0 ELSE COALESCE(
                                                                                                                    CASE WHEN :OMITIRVALES = 'S' THEN DOCTO.SINVALE_IEPS ELSE DOCTO.IEPS END
                                                                                                                    ,0.0) END +
                                            CASE WHEN COALESCE(:MOSTRARDESCUENTOENFACTURA,'N') = 'S' THEN COALESCE(
                                                                                                                    CASE WHEN :OMITIRVALES = 'S' THEN 0 ELSE DOCTO.DESCUENTO END
                                                                                                                    ,0) ELSE 0.0 END SUBTOTAL,
                                   PERSONA.desgloseieps PERSONADESGLOSAIEPSCONS
                        FROM DOCTO
                        LEFT JOIN TIPODOCTO ON TIPODOCTO.ID = DOCTO.TIPODOCTOID
                        LEFT JOIN PERSONA ON PERSONA.ID = DOCTO.PERSONAID
                        WHERE DOCTO.factconsid = :DOCTOID AND TIPODOCTO.sentidopago = 1
                        AND DOCTO.estatusdoctoid = 1
                        AND COALESCE(DOCTO.FACTCONSAPLICADO ,'S') = 'S'
                        INTO  :DOCTOIDCONS, :DOCTOFOLIOCONS,   :IVACONS, :totalcons , :IEPSCONS ,:SUBTOTALCONS ,:PERSONADESGLOSAIEPSCONS
                        DO
                        BEGIN

                             /*SELECT SUM(COALESCE(MOVTO.SUBTOTAL,0) +
                                        CASE when COALESCE(:DESGLOSEIEPSLOCAL,'N') = 'S'  THEN 0.0 ELSE COALESCE(MOVTO.IEPS,0.0) END +
                                        CASE WHEN COALESCE(:MOSTRARDESCUENTOENFACTURA,'N') = 'S' THEN COALESCE(MOVTO.DESCUENTO,0) ELSE 0.0 END
                                        ) SUMASUBTOTALDEVOCONS
                                     FROM DOCTO INNER JOIN MOVTO ON MOVTO.doctoid = DOCTO.id
                                     INNER JOIN MOVTO MOVTOREF ON MOVTO.movtorefid = MOVTOREF.ID
                                     WHERE DOCTO.tipodoctoid = 22 AND DOCTO.DOCTOREFID = :DOCTOIDCONS AND DOCTO.factconsid = :DOCTOID
                                     AND COALESCE(DOCTO.FACTCONSAPLICADO ,'S') = 'S'
                                     AND :OMITIRVALES = 'N'
                                     INTO :SUMASUBTOTALDEVOCONS;  */


                              

                             SELECT SUM(COALESCE(DOCTO.SUBTOTAL,0) +
                                        CASE when COALESCE(:DESGLOSEIEPSLOCAL,'N') = 'S'  THEN 0.0 ELSE COALESCE(DOCTO.IEPS,0.0) END +
                                        CASE WHEN COALESCE(:MOSTRARDESCUENTOENFACTURA,'N') = 'S' THEN COALESCE(DOCTO.DESCUENTO,0) ELSE 0.0 END
                                        ) SUMASUBTOTALDEVOCONS
                                     FROM DOCTO
                                     WHERE DOCTO.tipodoctoid = 22 AND DOCTO.DOCTOREFID = :DOCTOIDCONS AND DOCTO.factconsid = :DOCTOID
                                     AND COALESCE(DOCTO.FACTCONSAPLICADO ,'S') = 'S'
                                     AND :OMITIRVALES = 'N'
                                     INTO :SUMASUBTOTALDEVOCONS;

                              
                              SELECT
                                   CASE when (COALESCE(:DESGLOSEIEPSLOCAL,'N') <> 'S' or (SUM(COALESCE(M.IEPS,0)) = 0)) AND
                                        SUM(COALESCE(M.IVA,0)) = 0 THEN '03'
                                     --WHEN  (COALESCE(:DESGLOSEIEPSLOCAL,'N') = 'S' or (SUM(COALESCE(M.IEPS,0)) > 0)) AND
                                     --   SUM(COALESCE(M.IVA,0)) = 0  THEN '03'
                                    ELSE '02' END OBJETOIMP
                            FROM MOVTO M
                            WHERE M.DOCTOID = :DOCTOIDCONS
                            INTO :OBJETOIMP;

                            Cantidad = 1.0;
                            Unidad = '';
                            NOIDENTIFICACION = cast(coalesce(:doctofoliocons,'') as varchar(20));
                            Descripcion = 'Venta'  ;
                            ValorUnitario = COALESCE(:SUBTOTALCONS,0) -  COALESCE(:SUMASUBTOTALDEVOCONS, 0);
                            Importe = COALESCE(:SUBTOTALCONS,0) -  COALESCE(:SUMASUBTOTALDEVOCONS, 0);

                            CuentaPredial = '';
                            ClaveProdServ = '01010101';
                            ClaveUnidad = 'ACT';
                            Descuento = 0.0;
                            MOVTOID = :DOCTOIDCONS;
                            ID = :ID + 1;
                            TIPOLINEA = 'CONCEPTO';



                            IF(COALESCE(:VALORUNITARIO,0) <> 0) THEN
                            BEGIN
                                    SUSPEND;
                            END

                            PADRELINEA = :ID;

                            FOR SELECT
                                    TIPOLINEA ,ORDENLINEA , SUBTOTAL , DESCUENTO ,TOTAL ,MONEDA , TIPOCAMBIO , CANTIDAD , IMPORTE , IMPUESTO, Tasa , TasaCuota , TipoFactor , BaseImp , movtoid
                               FROM
                                    FACTURAELECTRONICA_XML_CORE(:DOCTOIDCONS, :DESGLOSEIEPSLOCAL, :MOSTRARDESCUENTOENFACTURA)
                                    WHERE TIPOLINEA IN ('CONCEPTO_ISRRETENIDO','CONCEPTO_IVARETENIDO', 'CONCEPTO_IVA', 'CONCEPTO_IEPS')
                                    AND COALESCE(:VALORUNITARIO,0) > 0
                                    INTO
                                    :TIPOLINEA ,:ORDENLINEA ,:SUBTOTAL ,:DESCUENTO ,:TOTAL ,:MONEDA ,:TIPOCAMBIO ,:CANTIDAD ,:IMPORTE ,:IMPUESTO, :Tasa , :TasaCuota ,:TipoFactor ,:BaseImp, :MOVTOID
                               DO
                               BEGIN

                                    ID = :ID + 1;
                                    SUSPEND;

                               END

                               FOR SELECT DOCTO.ID
                                    FROM DOCTO WHERE DOCTO.factconsid = :DOCTOID
                                    AND DOCTO.doctorefid = :DOCTOIDCONS
                                    AND DOCTO.tipodoctoid = 22
                                    AND :OMITIRVALES = 'N' 
                                    AND COALESCE(:VALORUNITARIO,0) <> 0
                                    INTO :DOCTODEVOCONSID
                               DO BEGIN

                                FOR SELECT
                                    TIPOLINEA ,ORDENLINEA , IMPORTE * -1, IMPUESTO , Tasa ,
                                    TasaCuota , TipoFactor ,BaseImp * -1,MOVTOID
                                FROM
                                    FACTURAELECTRONICA_XML_CORE(:DOCTODEVOCONSID, :DESGLOSEIEPSLOCAL, :MOSTRARDESCUENTOENFACTURA)
                                    WHERE TIPOLINEA IN ('CONCEPTO_ISRRETENIDO','CONCEPTO_IVARETENIDO', 'CONCEPTO_IVA', 'CONCEPTO_IEPS')
                                    AND COALESCE(MOVTOREFID,0) IN (SELECT MOVTO.ID FROM MOVTO WHERE DOCTOID = :DOCTOIDCONS)
                                    INTO
                                    :TIPOLINEA ,:ORDENLINEA , :IMPORTE ,:IMPUESTO,:Tasa ,
                                    :TasaCuota , :TipoFactor ,:BaseImp, :MOVTOID
                                DO
                                BEGIN
                                    ID = :ID + 1;
                                    SUSPEND;
                                END  
                               END
                        END
                  END


                 PADRELINEA = 0;

                  --CONCEPTO RECIBO ELECTRONICO
                  IF(COALESCE(:TIPODOCTOID,0) = 205) THEN
                  BEGIN

                       --DETERMINA EL OBJETOIMP
                        SELECT FIRST 1
                           CASE WHEN O02 = 0 and O03 = 0 THEN '03'
                                ELSE '02' end OBJETOIMP
                         FROM (
                            SELECT SUM(CASE WHEN PDS.objetoimpdr = '02' THEN 1 ELSE 0 END) O02,
                                   SUM(CASE WHEN PDS.objetoimpdr = '02' THEN 1 ELSE 0 END) O03
                            FROM PAGODOCTOSAT PDS
                                LEFT JOIN PAGOSAT ON PAGOSAT.ID = PDS.PAGOSATID
                                WHERE PAGOSAT.doctosatid = :DOCTOID)  q
                          into :OBJETOIMP;


                    Cantidad = 1.0;
                    Unidad = '';
                    Descripcion = 'Pago';
                    ValorUnitario = 0.0;
                    Importe = 0.0;
                    NoIdentificacion = '';
                    CuentaPredial = '';
                    ClaveProdServ = '84111506';
                    ClaveUnidad = 'ACT';
                    Descuento = 0.0;

                    objetoimp = coalesce(:objetoimp,'03');
                                    
                     ID = :ID + 1;
                     TIPOLINEA = 'CONCEPTO';
                     SUSPEND;
                  END
                  --PAGOS RECIBO ELECTRONICO
                  FOR SELECT FechaPago , FormaDePagoP , MonedaP , TipoCambioP , Monto , NumOperacion , RfcEmisorCtaOrd ,
                            NomBancoOrdExt ,CtaOrdenante , RfcEmisorCtaBen ,CtaBeneficiario ,TipoCadPago , CertPago ,
                            CadPago , SelloPago, ID
                        FROM PAGOSAT WHERE PAGOSAT.doctosatid = :DOCTOID
                        into 
                            :FechaPago ,:FormaDePagoP ,:MonedaP ,:TipoCambioP ,:Monto ,:NumOperacion ,:RfcEmisorCtaOrd ,
                            :NomBancoOrdExt ,:CtaOrdenante ,:RfcEmisorCtaBen ,:CtaBeneficiario , :TipoCadPago ,:CertPago ,
                            :CadPago ,:SelloPago,:PAGOSATID
                         DO
                         BEGIN     
                            ID = :ID + 1;
                            TIPOLINEA = 'PAGO';
                            SUSPEND;

                            IDLINEAPAGO = :ID;

                            FOR SELECT
                                PDS.IDDOCUMENTO,PDS.SERIE,PDS.FOLIO,
                                PDS.MONEDADR,PDS.TipoCambioDR, PDS.MetodoDePagoDR,
                                PDS.NumParcialidad,PDS.ImpSaldoAnt,PDS.ImpPagado,
                                PDS.ImpSaldoInsoluto  , PDS.ID , PDS.objetoimpdr
                                FROM PAGODOCTOSAT PDS
                                WHERE PDS.PAGOSATID = :PAGOSATID
                                INTO
                                  :IDDOCUMENTO,:SERIE,:FOLIO,
                                  :MONEDADR, :TipoCambioDR, :MetodoDePagoDR,
                                  :NumParcialidad, :ImpSaldoAnt, :ImpPagado,
                                  :ImpSaldoInsoluto ,:PAGODOCTOSATID , :OBJETOIMP
                                  DO
                                BEGIN
                                    
                                    PADRELINEA = :IDLINEAPAGO;

                                    ID = :ID + 1;
                                    TIPOLINEA = 'PAGODOCTO';
                                    SUSPEND;
                                             
                                    PADRELINEA = :ID;

                                    
                                    FOR SELECT I.BASEIMP  ,I.TIPOFACTOR  ,I.TASACUOTA ,I.TASA  ,I.IMPUESTO  ,I.IMPORTE
                                    FROM PAGODOCTOSAT_IMP I
                                    WHERE I.PAGODOCTOSATID = :PAGODOCTOSATID
                                    INTO :BASEIMP, :TIPOFACTOR, :TASACUOTA, :TASA, :IMPUESTO, :IMPORTE
                                    DO
                                    BEGIN   
                                        ID = :ID + 1;
                                        TIPOLINEA = 'PAGODOCTOIMPUESTO';
                                        SUSPEND;
                                    END




                                END
                         END

                 PADRELINEA = 0;
                  -- DOCUMENTOS RELACIONADOS
                  IF(COALESCE(:TIPODOCTOID,0) = 22 ) THEN
                  BEGIN
                     SELECT COALESCE(FACTCONS.timbradouuid, DOCTOREF.TIMBRADOUUID)
                        FROM DOCTO LEFT JOIN DOCTO DOCTOREF ON DOCTO.doctorefid = DOCTOREF.ID
                        LEFT JOIN DOCTO FACTCONS ON FACTCONS.ID = DOCTOREF.factconsid
                        WHERE DOCTO.ID = :DOCTOID
                        INTO :UUID ;

                        IF(COALESCE(:UUID,'') <> '') THEN
                        BEGIN  
                                    tiporelacion = '01';
                                    ID = :ID + 1;
                                    TIPOLINEA = 'DOCTORELACIONADO';
                                    SUSPEND;
                        END

                  END
                      
                  IF(COALESCE(:TIPODOCTOID,0) = 21 AND COALESCE(:subtipodoctoid, 0) = 26) THEN
                  BEGIN
                     SELECT DOCTOREF.TIMBRADOUUID
                        FROM DOCTO LEFT JOIN DOCTO DOCTOREF ON DOCTO.doctoasustituirid = DOCTOREF.ID
                        WHERE DOCTO.ID = :DOCTOID
                        INTO :UUID ;

                        IF(COALESCE(:UUID,'') <> '') THEN
                        BEGIN  
                                    tiporelacion = '04';
                                    ID = :ID + 1;
                                    TIPOLINEA = 'DOCTORELACIONADO';
                                    SUSPEND;
                        END

                  END

                 FOR
                    SELECT   COALESCE(TASAIEPS_, 0.0) TASAIEPS_, SUM(COALESCE(IEPS,0.0)) IEPS, SUM(COALESCE(SUBTOTAL,0.0)) SUBTOTAL
                      FROM(
                        SELECT
                            CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'   THEN COALESCE(MOVTO.tasaieps,0.0) ELSE 0.0 END TASAIEPS_,
                            CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'   THEN COALESCE(MOVTO.ieps,0.0) ELSE 0.0 END  IEPS,
                            COALESCE(MOVTO.SUBTOTAL,0.0) SUBTOTAL
                         FROM MOVTO
                                LEFT JOIN PRODUCTO ON PRODUCTO.ID = MOVTO.productoid
                        WHERE MOVTO.DOCTOID = :DOCTOID and
                            CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'   THEN MOVTO.tasaieps ELSE 0.0 END > 0.0
                            AND (COALESCE(PRODUCTO.eskit,'N') = 'N'  OR COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S')

                       UNION ALL
                        SELECT
                            CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'   THEN COALESCE(DETALLEKITtasaieps,0.0) ELSE 0.0 END TASAIEPS_,
                            CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'   THEN COALESCE(DETALLEKITieps,0.0) ELSE 0.0 END  IEPS ,
                            COALESCE(DETALLEKITSUBTOTAL,0.0) SUBTOTAL
                        FROM (SELECT DETALLEKITCANTIDAD ,DETALLEKITTASAIVA ,DETALLEKITTASAIEPS , DETALLEKITTASAIMPUESTO ,DETALLEKITTOTAL ,DETALLEKITSUBTOTAL ,DETALLEKITIVA ,DETALLEKITIEPS ,DETALLEKITPRECIO ,DETALLEKITPRECIOLISTA , DETALLEKITPRODUCTOID, 0.0 DETALLEKITTASAIVARETENIDO, 0.0 DETALLEKITIVARETENIDO, 0.0 DETALLEKITTASAISRRETENIDO, 0.0 DETALLEKITISRRETENIDO  FROM  KIT_OBTENREFERENCIA (:DOCTOID,0,'S')) KITREF
                            LEFT JOIN PRODUCTO ON PRODUCTO.ID = DETALLEKITproductoid
                        WHERE --RECIBOS_CORE.DOCTOID = :DOCTOID and
                            CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'   THEN DETALLEKITtasaieps ELSE 0.0 END > 0.0
                       ) BASE
                       GROUP BY TASAIEPS_
                       INTO
                        :PORCENTAJEIEPSMOVTO, :MONTOIEPSMOVTO, :MONTOSUBTOTALMOVTO
                        DO
                        BEGIN    
                            Impuesto = '003';
                            Tasa = :PORCENTAJEIEPSMOVTO;
                            TasaCuota = :PORCENTAJEIEPSMOVTO;
                            Importe = :MONTOIEPSMOVTO;
                            TipoFactor = 'Tasa';  
                            BaseImp = :MONTOSUBTOTALMOVTO;

                            ID = :ID + 1;
                            TIPOLINEA = 'COMPROBANTE_IEPS';
                            SUSPEND;
                        END

                        
                 FOR
                    SELECT   COALESCE(TASAIVA_, 0.0) TASAIVA_, SUM(COALESCE(IVA,0.0)) IVA , SUM(COALESCE(IEPS,0.0)) IEPS, SUM(COALESCE(SUBTOTAL,0.0)) SUBTOTAL
                      FROM(
                        SELECT
                            COALESCE(MOVTO.tasaiva, 0.0)  TASAIVA_,
                            COALESCE(MOVTO.IVA,0.0) IVA   ,
                            COALESCE(MOVTO.ieps,0.0) IEPS,
                            COALESCE(MOVTO.SUBTOTAL,0.0) SUBTOTAL
                         FROM MOVTO
                                LEFT JOIN PRODUCTO ON PRODUCTO.ID = MOVTO.productoid
                            LEFT JOIN SAT_PRODUCTOSERVICIO ON SAT_PRODUCTOSERVICIO.id = PRODUCTO.sat_productoservicioid
                            LEFT JOIN PARAMETRO ON 1 = 1
                        WHERE MOVTO.DOCTOID = :DOCTOID and
                             COALESCE(MOVTO.tasaiva,0)  >= 0
                            AND (COALESCE(PRODUCTO.eskit,'N') = 'N'  OR COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S')

                       UNION  ALL
                        SELECT
                            COALESCE(DETALLEKITtasaiva, 0.0)  TASAIVA_,
                            COALESCE(DETALLEKITIVA,0.0) IVA,
                            COALESCE(DETALLEKITIEPS,0.0) IEPS,
                            COALESCE(DETALLEKITSUBTOTAL,0.0) SUBTOTAL
                        FROM (SELECT DETALLEKITCANTIDAD ,DETALLEKITTASAIVA ,DETALLEKITTASAIEPS , DETALLEKITTASAIMPUESTO ,DETALLEKITTOTAL ,DETALLEKITSUBTOTAL ,DETALLEKITIVA ,DETALLEKITIEPS ,DETALLEKITPRECIO ,DETALLEKITPRECIOLISTA , DETALLEKITPRODUCTOID, 0.0 DETALLEKITTASAIVARETENIDO, 0.0 DETALLEKITIVARETENIDO, 0.0 DETALLEKITTASAISRRETENIDO, 0.0 DETALLEKITISRRETENIDO  FROM  KIT_OBTENREFERENCIA (:DOCTOID,0,'S')) KITREF
                            LEFT JOIN PRODUCTO ON PRODUCTO.ID = DETALLEKITproductoid
                        WHERE --RECIBOS_CORE.DOCTOID = :DOCTOID and
                         COALESCE(DETALLEKITtasaiva,0)  >= 0
                       ) BASE
                       GROUP BY TASAIVA_
                       INTO
                        :PORCENTAJEIVAMOVTO,  :MONTOIVAMOVTO , :MONTOIEPSMOVTO, :MONTOSUBTOTALMOVTO
                        DO
                        BEGIN    
                            Impuesto = '002';
                            Tasa = :PORCENTAJEIVAMOVTO;
                            TasaCuota = :PORCENTAJEIVAMOVTO;
                            Importe = :MONTOIVAMOVTO;
                            TipoFactor = 'Tasa';  
                            BaseImp = :MONTOSUBTOTALMOVTO + :MONTOIEPSMOVTO;

                            ID = :ID + 1;
                            TIPOLINEA = 'COMPROBANTE_IVA';

                            IF(COALESCE(:IMPORTE,0) >= 0.00 ) THEN
                            BEGIN   
                                SUSPEND;
                            END
                        END

                 IF( COALESCE(:PERSONARETIENEIVA,'N') = 'S' AND
                         COALESCE(:ESARRENDATARIO, 'N') = 'S') THEN
                   BEGIN

                    FOR
                      SELECT   COALESCE(TASAIVARETENIDO_, 0.0) TASAIVARETENIDO_, SUM(COALESCE(IVARETENIDO,0.0)) IVARETENIDO,  SUM(COALESCE(SUBTOTAL,0.0)) SUBTOTAL
                      FROM(
                        SELECT
                            COALESCE(MOVTO.tasaivaRETENIDO, 0.0)  TASAIVARETENIDO_,
                            COALESCE(MOVTO.IVARETENIDO,0.0) IVARETENIDO  ,
                            COALESCE(MOVTO.SUBTOTAL,0.0) SUBTOTAL
                         FROM MOVTO
                                LEFT JOIN PRODUCTO ON PRODUCTO.ID = MOVTO.productoid
                        WHERE MOVTO.DOCTOID = :DOCTOID and
                             COALESCE(MOVTO.tasaivaRETENIDO,0)  > 0
                            AND (COALESCE(PRODUCTO.eskit,'N') = 'N'  OR COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S')

                       UNION  ALL
                        SELECT
                            COALESCE(DETALLEKITtasaivaRETENIDO, 0.0)  TASAIVARETENIDO_,
                            COALESCE(DETALLEKITIVARETENIDO,0.0) IVARETENIDO,
                            COALESCE(DETALLEKITSUBTOTAL,0.0) SUBTOTAL
                        FROM (SELECT DETALLEKITCANTIDAD ,DETALLEKITTASAIVA ,DETALLEKITTASAIEPS , DETALLEKITTASAIMPUESTO ,DETALLEKITTOTAL ,DETALLEKITSUBTOTAL ,DETALLEKITIVA ,DETALLEKITIEPS ,DETALLEKITPRECIO ,DETALLEKITPRECIOLISTA , DETALLEKITPRODUCTOID, 0.0 DETALLEKITTASAIVARETENIDO, 0.0 DETALLEKITIVARETENIDO, 0.0 DETALLEKITTASAISRRETENIDO, 0.0 DETALLEKITISRRETENIDO  FROM  KIT_OBTENREFERENCIA (:DOCTOID,0,'S')) KITREF
                            LEFT JOIN PRODUCTO ON PRODUCTO.ID = DETALLEKITproductoid
                        --WHERE RECIBOS_CORE.DOCTOID = :DOCTOID and
                         WHERE COALESCE(DETALLEKITtasaivaRETENIDO,0)  > 0
                       ) BASE
                       GROUP BY TASAIVARETENIDO_
                       INTO
                         :PORCENTAJEIVARETENIDOMOVTO ,:MONTOIVARETENIDOMOVTO,  :MONTOSUBTOTALMOVTO
                        DO
                        BEGIN    
                            Impuesto = '002';
                            Tasa = :PORCENTAJEIVARETENIDOMOVTO;
                            Importe = :MONTOIVARETENIDOMOVTO;
                            BaseImp = :MONTOSUBTOTALMOVTO;
                            ID = :ID + 1;
                            TIPOLINEA = 'COMPROBANTE_IVARETENIDO';   
                            SUSPEND;
                        END

                   END

                 IF( COALESCE(:PERSONARETIENEISR,'N') = 'S' AND
                         COALESCE(:ESARRENDATARIO, 'N') = 'S') THEN
                   BEGIN

                    FOR
                      SELECT   COALESCE(TASAISRRETENIDO_, 0.0) TASAISRRETENIDO_, SUM(COALESCE(ISRRETENIDO,0.0)) ISRRETENIDO , SUM(COALESCE(SUBTOTAL,0.0)) SUBTOTAL
                      FROM(
                        SELECT
                            COALESCE(MOVTO.tasaiSRRETENIDO, 0.0)  TASAISRRETENIDO_,
                            COALESCE(MOVTO.ISRRETENIDO,0.0) ISRRETENIDO ,
                            COALESCE(MOVTO.SUBTOTAL,0.0) SUBTOTAL
                         FROM MOVTO
                                LEFT JOIN PRODUCTO ON PRODUCTO.ID = MOVTO.productoid
                        WHERE MOVTO.DOCTOID = :DOCTOID and
                             COALESCE(MOVTO.tasaiSRRETENIDO,0)  > 0
                            AND (COALESCE(PRODUCTO.eskit,'N') = 'N'  OR COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S')

                       UNION  ALL
                        SELECT
                            COALESCE(DETALLEKITtasaiSRRETENIDO, 0.0)  TASAISRRETENIDO_,
                            COALESCE(DETALLEKITISRRETENIDO,0.0) ISRRETENIDO ,
                            COALESCE(DETALLEKITSUBTOTAL,0.0) SUBTOTAL
                        FROM (SELECT DETALLEKITCANTIDAD ,DETALLEKITTASAIVA ,DETALLEKITTASAIEPS , DETALLEKITTASAIMPUESTO ,DETALLEKITTOTAL ,DETALLEKITSUBTOTAL ,DETALLEKITIVA ,DETALLEKITIEPS ,DETALLEKITPRECIO ,DETALLEKITPRECIOLISTA , DETALLEKITPRODUCTOID, 0.0 DETALLEKITTASAIVARETENIDO, 0.0 DETALLEKITIVARETENIDO, 0.0 DETALLEKITTASAISRRETENIDO, 0.0 DETALLEKITISRRETENIDO  FROM  KIT_OBTENREFERENCIA (:DOCTOID,0,'S')) KITREF
                            LEFT JOIN PRODUCTO ON PRODUCTO.ID = DETALLEKITproductoid
                        --WHERE RECIBOS_CORE.DOCTOID = :DOCTOID and
                         WHERE  COALESCE(DETALLEKITtasaiSRRETENIDO,0)  > 0
                       ) BASE
                       GROUP BY TASAISRRETENIDO_
                       INTO
                        :PORCENTAJEISRRETENIDOMOVTO, :MONTOISRRETENIDOMOVTO ,  :MONTOSUBTOTALMOVTO
                        DO
                        BEGIN    
                            Impuesto = '001';
                            Tasa = :PORCENTAJEISRRETENIDOMOVTO;
                            Importe = :MONTOISRRETENIDOMOVTO;
                            BaseImp = :MONTOSUBTOTALMOVTO;
                            ID = :ID + 1;
                            TIPOLINEA = 'COMPROBANTE_ISRRETENIDO'; 
                            SUSPEND;
                        END

                   END

                   SELECT    SUM(COALESCE(IEPS,0.0)) IEPS  ,SUM(COALESCE(IVA,0.0)) IVA  ,SUM(COALESCE(IVARETENIDO,0.0)) IVARETENIDO, SUM(COALESCE(ISRRETENIDO,0.0)) ISRRETENIDO
                      FROM(
                        SELECT
                            CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'   THEN COALESCE(MOVTO.ieps,0.0) ELSE 0.0 END  IEPS ,
                            COALESCE(MOVTO.IVA,0.0) IVA,
                            COALESCE(MOVTO.IVARETENIDO,0.0) IVARETENIDO ,
                            COALESCE(MOVTO.ISRRETENIDO,0.0) ISRRETENIDO

                         FROM MOVTO
                                LEFT JOIN PRODUCTO ON PRODUCTO.ID = MOVTO.productoid
                            LEFT JOIN SAT_PRODUCTOSERVICIO ON SAT_PRODUCTOSERVICIO.id = PRODUCTO.sat_productoservicioid
                            LEFT JOIN PARAMETRO ON 1 = 1
                        WHERE MOVTO.DOCTOID = :DOCTOID
                            AND (COALESCE(PRODUCTO.eskit,'N') = 'N'  OR COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S')

                       UNION ALL
                        SELECT
                            CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'   THEN COALESCE(DETALLEKITieps,0.0) ELSE 0.0 END  IEPS,
                            COALESCE(DETALLEKITIVA,0.0) IVA,
                            COALESCE(DETALLEKITIVARETENIDO,0.0) IVARETENIDO ,
                            COALESCE(DETALLEKITISRRETENIDO,0.0) ISRRETENIDO
                        FROM (SELECT DETALLEKITCANTIDAD ,DETALLEKITTASAIVA ,DETALLEKITTASAIEPS , DETALLEKITTASAIMPUESTO ,DETALLEKITTOTAL ,DETALLEKITSUBTOTAL ,DETALLEKITIVA ,DETALLEKITIEPS ,DETALLEKITPRECIO ,DETALLEKITPRECIOLISTA , DETALLEKITPRODUCTOID, 0.0 DETALLEKITTASAIVARETENIDO, 0.0 DETALLEKITIVARETENIDO, 0.0 DETALLEKITTASAISRRETENIDO, 0.0 DETALLEKITISRRETENIDO  FROM  KIT_OBTENREFERENCIA (:DOCTOID,0,'S')) KITREF
                            LEFT JOIN PRODUCTO ON PRODUCTO.ID = DETALLEKITproductoid
                        --WHERE RECIBOS_CORE.DOCTOID = :DOCTOID
                       ) BASE  
                    INTO :SUMAIEPSTRASLADADO,:SUMAIVATRASLADADO,:SUMAIVARETENIDO, :SUMAISRRETENIDO ;


                    totalTraslados  = COALESCE(:SUMAIEPSTRASLADADO,0.0) + COALESCE(:SUMAIVATRASLADADO,0.0);
                    totalRetenciones = COALESCE(:SUMAIVARETENIDO,0.0) + COALESCE(:SUMAISRRETENIDO,0.0);
                     
                    ID = :ID + 1;
                    TIPOLINEA = 'TOTAL_TRASLADOSRETENCIONES';
                    SUSPEND;


END