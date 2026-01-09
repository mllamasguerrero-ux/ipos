create or alter procedure FACTURAELECTRONICA_XML (
    DOCTOID D_FK)
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
    BASEIMP D_PRECIO,
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
    OMITIRVALES D_BOOLCN_NULL)
as
declare variable TIPODOCTOID D_FK;
BEGIN

  SELECT TIPODOCTOID, DOCTO.OMITIRVALES
   FROM DOCTO WHERE ID = :DOCTOID INTO :TIPODOCTOID, :OMITIRVALES;



  FOR SELECT
      ID    ,
    TIPOLINEA    ,
    PADRELINEA    ,
    ORDENLINEA    ,
    SUBORDEN    ,
    SERIE    ,
    FOLIO    ,
    FECHA    ,
    TIPOCOMPROBANTE    ,
    FORMAPAGO    ,
    SUBTOTAL    ,
    DESCUENTO    ,
    TOTAL    ,
    MONEDA    ,
    TIPOCAMBIO    ,
    CONDICIONESPAGO    ,
    METODOPAGO    ,
    MOTIVODESCUENTO    ,
    LUGAREXPEDICION    ,
    NUMEROCTAPAGO    ,
    SERIEFOLIOFISCALORIGINAL    ,
    FOLIOFISCALORIGINAL    ,
    MONTOFOLIOFISCALORIGINAL    ,
    FECHAFOLIOFISCALORIGINAL    ,
    RFC    ,
    RAZONSOCIAL    ,
    REGIMENFISCAL    ,
    CALLE    ,
    NOINTERIOR    ,
    NOEXTERIOR    ,
    COLONIA    ,
    LOCALIDAD    ,
    REFERENCIA    ,
    MUNICIPIO    ,
    ESTADO    ,
    PAIS    ,
    CODIGOPOSTAL    ,
    NOMBRE    ,
    RESIDENCIAFISCAL    ,
    NUMREGIDTRIB    ,
    USOCFDI    ,
    CANTIDAD    ,
    UNIDAD    ,
    DESCRIPCION    ,
    VALORUNITARIO    ,
    IMPORTE    ,
    NOIDENTIFICACION    ,
    CUENTAPREDIAL    ,
    CLAVEPRODSERV    ,
    CLAVEUNIDAD    ,
    NUMERO    ,
    ADUANA    ,
    IMPUESTO    ,
    TASA    ,
    BASEIMP    ,
    TIPOFACTOR    ,
    TASACUOTA    ,
    FECHAPAGO    ,
    FORMADEPAGOP    ,
    MONEDAP    ,
    TIPOCAMBIOP    ,
    MONTO    ,
    NUMOPERACION    ,
    RFCEMISORCTAORD    ,
    NOMBANCOORDEXT    ,
    CTAORDENANTE    ,
    RFCEMISORCTABEN    ,
    CTABENEFICIARIO    ,
    TIPOCADPAGO    ,
    CERTPAGO    ,
    CADPAGO    ,
    SELLOPAGO    ,
    IDDOCUMENTO    ,
    MONEDADR    ,
    TIPOCAMBIODR    ,
    METODODEPAGODR    ,
    NUMPARCIALIDAD    ,
    IMPSALDOANT    ,
    IMPPAGADO    ,
    IMPSALDOINSOLUTO    ,
    TOTALTRASLADOS    ,
    TOTALRETENCIONES    ,
    TIPORELACION    ,
    UUID    ,
    IMPRIMIRCOMPROBANTESPAGO    ,
    NUMEROPEDIMENTO    ,
    MOVTOID    ,
    MOVTOKITID    ,
    PAGOSATID


    FROM

    FACTURAELECTRONICA_XML_CORE(:DOCTOID, NULL, NULL)
    WHERE (:TIPODOCTOID <> 701 or  COALESCE(tipolinea,'') NOT IN('CONCEPTO_PARTE', 'CONCEPTO_ISRRETENIDO','CONCEPTO_IVARETENIDO', 'CONCEPTO_IVA', 'CONCEPTO_IEPS',  'TOTAL_TRASLADOSRETENCIONES', 'COMPROBANTE_ISRRETENIDO', 'COMPROBANTE_IVARETENIDO', 'COMPROBANTE_IVA','COMPROBANTE_IEPS' ))
     INTO
    :ID    ,
    :TIPOLINEA    ,
    :PADRELINEA    ,
    :ORDENLINEA    ,
    :SUBORDEN    ,
    :SERIE    ,
    :FOLIO    ,
    :FECHA    ,
    :TIPOCOMPROBANTE    ,
    :FORMAPAGO    ,
    :SUBTOTAL    ,
    :DESCUENTO    ,
    :TOTAL    ,
    :MONEDA    ,
    :TIPOCAMBIO    ,
    :CONDICIONESPAGO    ,
    :METODOPAGO    ,
    :MOTIVODESCUENTO    ,
    :LUGAREXPEDICION    ,
    :NUMEROCTAPAGO    ,
    :SERIEFOLIOFISCALORIGINAL    ,
    :FOLIOFISCALORIGINAL    ,
    :MONTOFOLIOFISCALORIGINAL    ,
    :FECHAFOLIOFISCALORIGINAL    ,
    :RFC    ,
    :RAZONSOCIAL    ,
    :REGIMENFISCAL    ,
    :CALLE    ,
    :NOINTERIOR    ,
    :NOEXTERIOR    ,
    :COLONIA    ,
    :LOCALIDAD    ,
    :REFERENCIA    ,
    :MUNICIPIO    ,
    :ESTADO    ,
    :PAIS    ,
    :CODIGOPOSTAL    ,
    :NOMBRE    ,
    :RESIDENCIAFISCAL    ,
    :NUMREGIDTRIB    ,
    :USOCFDI    ,
    :CANTIDAD    ,
    :UNIDAD    ,
    :DESCRIPCION    ,
    :VALORUNITARIO    ,
    :IMPORTE    ,
    :NOIDENTIFICACION    ,
    :CUENTAPREDIAL    ,
    :CLAVEPRODSERV    ,
    :CLAVEUNIDAD    ,
    :NUMERO    ,
    :ADUANA    ,
    :IMPUESTO    ,
    :TASA    ,
    :BASEIMP    ,
    :TIPOFACTOR    ,
    :TASACUOTA    ,
    :FECHAPAGO    ,
    :FORMADEPAGOP    ,
    :MONEDAP    ,
    :TIPOCAMBIOP    ,
    :MONTO    ,
    :NUMOPERACION    ,
    :RFCEMISORCTAORD    ,
    :NOMBANCOORDEXT    ,
    :CTAORDENANTE    ,
    :RFCEMISORCTABEN    ,
    :CTABENEFICIARIO    ,
    :TIPOCADPAGO    ,
    :CERTPAGO    ,
    :CADPAGO    ,
    :SELLOPAGO    ,
    :IDDOCUMENTO    ,
    :MONEDADR    ,
    :TIPOCAMBIODR    ,
    :METODODEPAGODR    ,
    :NUMPARCIALIDAD    ,
    :IMPSALDOANT    ,
    :IMPPAGADO    ,
    :IMPSALDOINSOLUTO    ,
    :TOTALTRASLADOS    ,
    :TOTALRETENCIONES    ,
    :TIPORELACION    ,
    :UUID    ,
    :IMPRIMIRCOMPROBANTESPAGO    ,
    :NUMEROPEDIMENTO    ,
    :MOVTOID    ,
    :MOVTOKITID    ,
    :PAGOSATID
    DO
    BEGIN

      SUSPEND;
    END

    IF(:TIPODOCTOID = 701) THEN
    BEGIN
    
      FOR SELECT
                                    MIN(ID),
                                    TIPOLINEA ,
                                    MIN(ORDENLINEA) ,
                                    SUM(COALESCE(IMPORTE,0)) ,
                                    IMPUESTO,
                                    Tasa ,
                                    TasaCuota ,
                                    TipoFactor ,
                                    CASE WHEN COALESCE(TASA,0) > 0 THEN SUM(COALESCE(IMPORTE,0)) / (COALESCE(TASA,0) / 100.00) ELSE  SUM(COALESCE(BaseImp,0)) END  BASEIMP,
                                    PADRELINEA
          FROM
                                    FACTURAELECTRONICA_XML_IMP(:DOCTOID, NULL, NULL)
                                    WHERE TIPOLINEA IN ('CONCEPTO_ISRRETENIDO','CONCEPTO_IVARETENIDO', 'CONCEPTO_IVA', 'CONCEPTO_IEPS')
                                    
          GROUP BY TIPOLINEA, IMPUESTO, TASA, TASACUOTA, TIPOFACTOR, PADRELINEA
                                    INTO
                                    :id, 
                                    :TIPOLINEA ,
                                    :ORDENLINEA ,
                                    :IMPORTE ,
                                    :IMPUESTO,
                                    :Tasa ,
                                    :TasaCuota ,
                                    :TipoFactor ,
                                    :BaseImp ,
                                    :PADRELINEA

              DO
              BEGIN

                 if(coalesce(:IMPORTE,0) <> 0  ) THEN
                 BEGIN  
                    SUSPEND;
                 END


              END




          TOTALTRASLADOS = 0;
          TOTALRETENCIONES = 0;
          ID = 10000000;
    
      FOR SELECT
                                    MIN(ID),
                                    TIPOLINEA ,
                                    MIN(ORDENLINEA) ,
                                    SUM(COALESCE(IMPORTE,0)) ,
                                    IMPUESTO,
                                    Tasa ,
                                    TasaCuota ,
                                    TipoFactor ,
                                    CASE WHEN COALESCE(TASA,0) > 0 THEN SUM(COALESCE(IMPORTE,0)) / (COALESCE(TASA,0) / 100.00) ELSE  SUM(COALESCE(BaseImp,0)) END  BASEIMP
          FROM
                                    FACTURAELECTRONICA_XML_IMP(:DOCTOID, NULL, NULL)
                                    WHERE TIPOLINEA IN ('CONCEPTO_ISRRETENIDO','CONCEPTO_IVARETENIDO', 'CONCEPTO_IVA', 'CONCEPTO_IEPS')
                                    
          GROUP BY TIPOLINEA, IMPUESTO, TASA, TASACUOTA, TIPOFACTOR
                                    INTO
                                    :id, 
                                    :TIPOLINEA ,
                                    :ORDENLINEA ,
                                    :IMPORTE ,
                                    :IMPUESTO,
                                    :Tasa ,
                                    :TasaCuota ,
                                    :TipoFactor ,
                                    :BaseImp

              DO
              BEGIN
                ID = :ID + 1;
                TIPOLINEA =  case WHEN TIPOLINEA = 'CONCEPTO_ISRRETENIDO' then 'COMPROBANTE_ISRRETENIDO'
                                  WHEN TIPOLINEA = 'CONCEPTO_IVARETENIDO' then 'COMPROBANTE_IVARETENIDO' 
                                  WHEN TIPOLINEA = 'CONCEPTO_IVA' then 'COMPROBANTE_IVA'
                                  WHEN TIPOLINEA = 'CONCEPTO_IEPS' then 'COMPROBANTE_IEPS' END;

                 IF(COALESCE(:TIPOLINEA,'') = 'COMPROBANTE_ISRRETENIDO' or COALESCE(:TIPOLINEA,'') = 'COMPROBANTE_IVARETENIDO') THEN
                 BEGIN
                    TOTALRETENCIONES =   :TOTALRETENCIONES + COALESCE(:IMPORTE,0);
                 END
                 ELSE
                 BEGIN    
                    TOTALTRASLADOS =   :TOTALTRASLADOS + COALESCE(:IMPORTE,0); 
                 END
                 
                 if(coalesce(:IMPORTE,0) <> 0  ) THEN
                 BEGIN  
                    SUSPEND;
                 END


              END


              ID = :ID + 1;
              TIPOLINEA = 'TOTAL_TRASLADOSRETENCIONES';
              SUSPEND;

      END



END