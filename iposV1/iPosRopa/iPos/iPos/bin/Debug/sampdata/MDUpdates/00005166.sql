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
    FECHA D_FECHA,
    TIPOCOMPROBANTE D_STDTEXT_64,
    FORMAPAGO D_STDTEXT_64,
    SUBTOTAL D_IMPORTE,
    DESCUENTO D_IMPORTE,
    TOTAL D_IMPORTE,
    MONEDA D_STDTEXT_64,
    TIPOCAMBIO D_STDTEXT_64,
    CONDICIONESPAGO D_STDTEXT_64,
    METODOPAGO D_STDTEXT_64,
    MOTIVODESCUENTO D_STDTEXT_64,
    LUGAREXPEDICION D_STDTEXT_64,
    NUMEROCTAPAGO D_STDTEXT_64,
    SERIEFOLIOFISCALORIGINAL D_STDTEXT_64,
    FOLIOFISCALORIGINAL D_STDTEXT_64,
    MONTOFOLIOFISCALORIGINAL D_IMPORTE,
    FECHAFOLIOFISCALORIGINAL D_FECHA,
    RFC D_STDTEXT_64,
    RAZONSOCIAL D_STDTEXT_64,
    REGIMENFISCAL D_STDTEXT_64,
    CALLE D_STDTEXT_64,
    NOINTERIOR D_STDTEXT_64,
    NOEXTERIOR D_STDTEXT_64,
    COLONIA D_STDTEXT_64,
    LOCALIDAD D_STDTEXT_64,
    REFERENCIA D_STDTEXT_64,
    MUNICIPIO D_STDTEXT_64,
    ESTADO D_STDTEXT_64,
    PAIS D_STDTEXT_64,
    CODIGOPOSTAL D_STDTEXT_64,
    NOMBRE D_STDTEXT_64,
    RESIDENCIAFISCAL D_STDTEXT_64,
    NUMREGIDTRIB D_STDTEXT_64,
    USOCFDI D_STDTEXT_64,
    CANTIDAD D_CANTIDAD,
    UNIDAD D_STDTEXT_64,
    DESCRIPCION D_STDTEXT_64,
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
    BASEIMP D_STDTEXT_64,
    TIPOFACTOR D_STDTEXT_64,
    TASACUOTA D_STDTEXT_64,
    FECHAPAGO D_FECHA,
    FORMADEPAGOP D_STDTEXT_64,
    MONEDAP D_STDTEXT_64,
    TIPOCAMBIOP D_STDTEXT_64,
    MONTO D_IMPORTE,
    NUMOPERACION D_STDTEXT_64,
    RFCEMISORCTAORD D_STDTEXT_64,
    NOMBANCOORDEXT D_STDTEXT_64,
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
    MOVTOID D_FK)
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
declare variable PAGOSATID D_FK;
declare variable SUMAIEPSTRASLADADO D_IMPORTE;
declare variable SUMAIVATRASLADADO D_IMPORTE;
declare variable SUMAISRRETENIDO D_IMPORTE;
declare variable SUMAIVARETENIDO D_IMPORTE;
declare variable ESKIT D_BOOLCN;
declare variable ERRORCODE D_ERRORCODE;
declare variable DOCTOKITREFID D_FK;
declare variable DESCUENTOMOVTO D_IMPORTE;
BEGIN

   ID = 1;
   TIPOLINEA = 'COMPROBANTE';
   ESVERSION33 = 'S';
   ESRECIBOELECTRONICO = 'N';
   IMPRIMIRCOMPROBANTESPAGO = 'N';
   PAGOENUNASOLAEXIBICION = 'N';

   MONEDA = 'MXN'; MONEDAP = 'MXN'; MONEDADR = 'MXN'; TIPOCAMBIO = ''; TIPOCAMBIOP = ''; TIPOCAMBIODR = '';

   
   SELECT PARAMETRO.fiscalcodigopostal, PARAMETRO.desgloseieps,PARAMETRO.mostrardescuentofactura , USARFISCALESENEXPEDICION   ,
      PARAMETRO.manejarloteimportacion , PARAMETRO.arrendatario
    FROM PARAMETRO
    INTO :EMPRESA_FISCALCODIGOPOSTAL, :EMPRESADESGLOSAIEPS, :MOSTRARDESCUENTOENFACTURA, :USARFISCALESENEXPEDICION,
      :MANEJALOTEIMPORTACION, :ESARRENDATARIO;
                   
   SELECT PERSONAID, TIPODOCTOID, PAGOACREDITO FROM docto WHERE ID = :DOCTOID INTO :PERSONAID, :TIPODOCTOID, :PAGOACREDITO;

    SELECT PERSONA.desgloseieps, PERSONA.retieneisr ,PERSONA.RETIENEIVA FROM PERSONA WHERE ID = :PERSONAID INTO :PERSONADESGLOSAIEPS, :PERSONARETIENEISR,  :PERSONARETIENEIVA;



   IF(:TIPODOCTOID IN (21)) THEN
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


   --COMPROBANTE
   IF(:TIPODOCTOID IN (21,22)) THEN
   BEGIN
        
        SELECT COUNT(*) FROM DOCTOPAGO WHERE DOCTOID = :DOCTOID
          AND DOCTOPAGO.formapagoid = 4 INTO :CUENTADOCTOPAGOCREDITO;
          
        SELECT COUNT(*) FROM doctopago
           WHERE ((:TIPODOCTOID = 21 AND DOCTOID = :DOCTOID) or (:TIPODOCTOID = 22 AND DOCTOSALIDAID = :DOCTOID)  )
                    AND COALESCE(DOCTOPAGO.formapagosatid,0) <> 0 AND
                    COALESCE(DOCTOPAGO.revertido, 'N') = 'N'  AND DOCTOPAGO.formapagoid IN (1,2,3,5,15)
           INTO :CUENTAPAGOSNOCREDITO;



        IF(COALESCE(:PAGOACREDITO,'N') = 'S' ) THEN
        BEGIN      
            FORMAPAGO = '99';
            PAGOENUNASOLAEXIBICION = 'N';

           IF(COALESCE(:CUENTAPAGOSNOCREDITO, 0) > 0 ) THEN
           BEGIN
                    IMPRIMIRCOMPROBANTESPAGO = 'S';
           END


        END
        ELSE
        BEGIN
           SELECT FIRST 1 FORMAPAGOSAT.CLAVE --DOCTOPAGO.formapagosatid
           FROM doctopago
           LEFT JOIN FORMAPAGOSAT ON FORMAPAGOSAT.ID = DOCTOPAGO.FORMAPAGOSATID
           WHERE ((:TIPODOCTOID = 21 AND DOCTOID = :DOCTOID) or (:TIPODOCTOID = 22 AND DOCTOSALIDAID = :DOCTOID)  )
                    AND COALESCE(DOCTOPAGO.formapagosatid,0) <> 0 AND
                    COALESCE(DOCTOPAGO.revertido, 'N') = 'N'  AND DOCTOPAGO.formapagoid IN (1,2,3,5,15)
           GROUP BY DOCTOPAGO.formapagosatid ,FORMAPAGOSAT.CLAVE
           ORDER by SUM(COALESCE(DOCTOPAGO.IMPORTE,0)) DESC
           INTO :FORMAPAGO;

           
           IF(COALESCE(:CUENTAPAGOSNOCREDITO, 0) > 0 ) THEN
           BEGIN
                    PAGOENUNASOLAEXIBICION = 'S';
           END
        END


            SELECT FIRST 1 DOCTOPAGO.REFERENCIABANCARIA FROM DOCTOPAGO
            WHERE ((:TIPODOCTOID = 21 AND DOCTOID = :DOCTOID) or (:TIPODOCTOID = 22 AND DOCTOSALIDAID = :DOCTOID)  )
                    AND COALESCE(DOCTOPAGO.formapagosatid,0) <> 0 AND
                    COALESCE(DOCTOPAGO.revertido, 'N') = 'N'  AND DOCTOPAGO.formapagoid IN (1,2,3,5,15)
            INTO :NUMEROCTAPAGO;


            SELECT
                SERIESAT, FOLIOSAT, DATEADD(-5 MINUTE TO TIMBRADOFECHAFACTURA) FECHA, TOTAL, 'MXN' ,'', '',
                CASE WHEN :PAGOENUNASOLAEXIBICION = 'S' THEN 'PUE' ELSE 'PPD' END  ,
                'X',  :EMPRESA_FISCALCODIGOPOSTAL

                FROM DOCTO
                WHERE DOCTO.ID = :DOCTOID

            INTO
                :SERIE, :FOLIO, :FECHA, :TOTAL, :MONEDA, :TIPOCAMBIO, :CONDICIONESPAGO,
                :METODOPAGO ,
                :MOTIVODESCUENTO, :LUGAREXPEDICION;
                 
            SUBTOTAL = 0.0;
            DESCUENTO = 0.0;

            SELECT SUM(COALESCE(SUBTOTAL,0) +
                  CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND
                  COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'  THEN 0.0 ELSE COALESCE(MOVTO.IEPS,0.0) END   +
                  CASE WHEN COALESCE(:MOSTRARDESCUENTOENFACTURA,'N') = 'S' THEN COALESCE(MOVTO.DESCUENTO,0) ELSE 0.0 END)
                   SUBTOTAL ,

                   SUM( CASE WHEN COALESCE(:MOSTRARDESCUENTOENFACTURA,'N') = 'S' THEN COALESCE(MOVTO.DESCUENTO,0) ELSE 0.0 END) DESCUENTO

                   FROM MOVTO LEFT JOIN PRODUCTO ON PRODUCTO.ID = MOVTO.PRODUCTOID
                      LEFT JOIN sat_productoservicio ON SAT_PRODUCTOSERVICIO.id = PRODUCTO.sat_productoservicioid
                      WHERE MOVTO.DOCTOID = :DOCTOID
                  INTO :SUBTOTAL, :DESCUENTO;






   END
   ELSE IF(:TIPODOCTOID = 205) THEN
   BEGIN
            ESRECIBOELECTRONICO = 'S';
            FORMAPAGO = '';
       
            SELECT FIRST 1 DOCTOPAGO.CUENTAPAGOCREDITO FROM DOCTOPAGO
            WHERE ((:TIPODOCTOID = 21 AND DOCTOID = :DOCTOID) or (:TIPODOCTOID = 22 AND DOCTOSALIDAID = :DOCTOID)  )
                    AND COALESCE(DOCTOPAGO.formapagosatid,0) <> 0 AND
                    COALESCE(DOCTOPAGO.revertido, 'N') = 'N'  AND DOCTOPAGO.formapagoid IN (1,2,3,5,15)
            INTO :NUMEROCTAPAGO;

            SELECT
                SERIESAT, FOLIOSAT, DATEADD(-5 MINUTE TO TIMBRADOFECHAFACTURA) FECHA, '0', 'XXX' ,'', '',
                '' METODOPAGO,
                'X' MOTIVODESCUENTO, :EMPRESA_FISCALCODIGOPOSTAL

                FROM DOCTO
                WHERE DOCTO.ID = :DOCTOID
            INTO
                :SERIE, :FOLIO, :FECHA, :TOTAL, :MONEDA, :TIPOCAMBIO, :CONDICIONESPAGO,
                :METODOPAGO ,
                :MOTIVODESCUENTO, :LUGAREXPEDICION;

            SUBTOTAL = 0.0;
            DESCUENTO = 0.0;



   END

   ID = :ID + 1;
   TIPOLINEA = 'COMPROBANTE';
   SUSPEND;

   --COMPROBANTE INFO EXP
   ID = :ID + 1;
   TIPOLINEA = 'COMPROBANTEINFOEX';
   LUGAREXPEDICION = :EMPRESA_FISCALCODIGOPOSTAL;
   --NUMEROCTAPAGO
   IF(:TIPODOCTOID IN (22)) THEN
   BEGIN
   
        SELECT DOCTOREF.SERIESAT, DOCTOREF.FOLIOSAT, DOCTOREF.TOTAL, CAST(DOCTOREF.TIMBRADOFECHAFACTURA AS DATE)
        FROM DOCTO LEFT JOIN DOCTO DOCTOREF ON DOCTO.doctorefid = DOCTOREF.ID
        WHERE DOCTO.ID = :DOCTOID
        INTO :SERIEFOLIOFISCALORIGINAL, :FOLIOFISCALORIGINAL , :MONTOFOLIOFISCALORIGINAL , :FECHAFOLIOFISCALORIGINAL ;

   END

   SUSPEND;

   --EMISOR
   ID = :ID + 1;
   TIPOLINEA = 'EMISOR';
     SELECT PARAMETRO.FISCALCALLE, PARAMETRO.FISCALNUMEROEXTERIOR,
                CASE WHEN COALESCE( PARAMETRO.FISCALNUMEROINTERIOR, '') = '' THEN '_' ELSE COALESCE( PARAMETRO.FISCALNUMEROINTERIOR, '') END NOINTERIOR,
                PARAMETRO.FISCALCOLONIA,  '.' LOCALIDAD,  '.' REFERENCIA,
                PARAMETRO.FISCALMUNICIPIO, PARAMETRO.FISCALESTADO, 'MEX',
                PARAMETRO.FISCALCODIGOPOSTAL,PARAMETRO.RFC, PARAMETRO.nombre, SAT_REGIMENFISCAL.sat_CLAVE
                FROM PARAMETRO
                    LEFT JOIN SAT_REGIMENFISCAL ON PARAMETRO.sat_regimenfiscalid = SAT_REGIMENFISCAL.ID
                INTO :CALLE, :NOEXTERIOR, :NOINTERIOR, :COLONIA, :LOCALIDAD, :REFERENCIA, :MUNICIPIO,
                    :ESTADO, :PAIS, :CODIGOPOSTAL, :RFC, :RAZONSOCIAL, :REGIMENFISCAL
                    ;

      SUSPEND;
      
   --EMISOR EXPEDIDO EN
   ID = :ID + 1;
   TIPOLINEA = 'EMISOREXPEDIDOEN';

   IF(COALESCE(:USARFISCALESENEXPEDICION,'S') = 'S') THEN
   BEGIN
        
     SELECT PARAMETRO.FISCALCALLE, PARAMETRO.FISCALNUMEROEXTERIOR,
                CASE WHEN COALESCE( PARAMETRO.FISCALNUMEROINTERIOR, '') = '' THEN '_' ELSE COALESCE( PARAMETRO.FISCALNUMEROINTERIOR, '') END NOINTERIOR,
                PARAMETRO.FISCALCOLONIA,  '.' LOCALIDAD,  '.' REFERENCIA,
                PARAMETRO.FISCALMUNICIPIO, PARAMETRO.FISCALESTADO, 'MEX',
                PARAMETRO.FISCALCODIGOPOSTAL,PARAMETRO.RFC, PARAMETRO.nombre, SAT_REGIMENFISCAL.sat_CLAVE
                FROM PARAMETRO
                    LEFT JOIN SAT_REGIMENFISCAL ON PARAMETRO.sat_regimenfiscalid = SAT_REGIMENFISCAL.ID
                INTO :CALLE, :NOEXTERIOR, :NOINTERIOR, :COLONIA, :LOCALIDAD, :REFERENCIA, :MUNICIPIO,
                    :ESTADO, :PAIS, :CODIGOPOSTAL, :RFC, :RAZONSOCIAL, :REGIMENFISCAL
                    ;

   END
   ELSE
   BEGIN  
     SELECT PARAMETRO.CALLE, PARAMETRO.NUMEROEXTERIOR,
                CASE WHEN COALESCE( PARAMETRO.NUMEROINTERIOR, '') = '' THEN '_' ELSE COALESCE( PARAMETRO.NUMEROINTERIOR, '') END NOINTERIOR,
                PARAMETRO.COLONIA,  '.' LOCALIDAD,  '.' REFERENCIA,
                PARAMETRO.LOCALIDAD, PARAMETRO.ESTADO, 'MEX',
                PARAMETRO.CP,PARAMETRO.RFC, PARAMETRO.nombre, SAT_REGIMENFISCAL.sat_CLAVE
                FROM PARAMETRO
                    LEFT JOIN SAT_REGIMENFISCAL ON PARAMETRO.sat_regimenfiscalid = SAT_REGIMENFISCAL.ID
                INTO :CALLE, :NOEXTERIOR, :NOINTERIOR, :COLONIA, :LOCALIDAD, :REFERENCIA, :MUNICIPIO,
                    :ESTADO, :PAIS, :CODIGOPOSTAL, :RFC, :RAZONSOCIAL, :REGIMENFISCAL
                    ;
   END
        
      SUSPEND;

      --RECEPTOR INFO
     SELECT PERSONA.DOMICILIO, PERSONA.NUMEROEXTERIOR,
                CASE WHEN COALESCE( PERSONA.NUMEROINTERIOR, '') = '' THEN '_' ELSE COALESCE( PERSONA.NUMEROINTERIOR, '') END NOINTERIOR,
                PERSONA.COLONIA,  COALESCE(PERSONA.LOCALIDAD,'.'),  COALESCE(PERSONA.referenciadom,'.') REFERENCIA,
                PERSONA.CIUDAD, PERSONA.ESTADO, 'MEX',
                PERSONA.CODIGOPOSTAL,PERSONA.RFC, PERSONA.nombres || ' ' || PERSONA.apellidos, '',
                PERSONA.nombres || ' ' || PERSONA.apellidos ,''
                FROM PERSONA
                WHERE ID = :PERSONAID
                INTO :CALLE, :NOEXTERIOR, :NOINTERIOR, :COLONIA, :LOCALIDAD, :REFERENCIA, :MUNICIPIO,
                    :ESTADO, :PAIS, :CODIGOPOSTAL, :RFC, :RAZONSOCIAL, :RESIDENCIAFISCAL ,
                    :NOMBRE, :NUMREGIDTRIB
                    ;

        SELECT sat_usocfdi.sat_clave FROM
        DOCTO LEFT JOIN SAT_USOCFDI ON DOCTO.sat_usocfdiid = SAT_USOCFDI.id
        WHERE DOCTO.ID = :DOCTOID
        INTO :USOCFDI;

        IF(COALESCE(:usoCFDI ,'') = '') THEN
        BEGIN
            USOCFDI = CASE WHEN :TIPODOCTOID IN (21) THEN 'G01'
                                    WHEN :TIPODOCTOID IN (22) THEN 'G02'
                                    WHEN :TIPODOCTOID IN (205) THEN 'P01'
                                    ELSE  'G01'
                                    END;
        END
        ID = :ID + 1;
         TIPOLINEA = 'RECEPTORINFO';

      SUSPEND;

         --CONCEPTOS SI NO ESTAMOS EN RECIBO ELECTRONICO
      FOR SELECT MOVTO.ID, MOVTO.CANTIDAD, SAT_UNIDADMEDIDA.sat_nombre,
                 PRODUCTO.descripcion1,


                ROUND( (COALESCE(MOVTO.SUBTOTAL,0) +
                        CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND
                        COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'  THEN 0.0 ELSE COALESCE(MOVTO.IEPS,0.0) END +
                        CASE WHEN COALESCE(:MOSTRARDESCUENTOENFACTURA,'N') = 'S' THEN COALESCE(MOVTO.DESCUENTO,0) ELSE 0.0 END)  / COALESCE(MOVTO.cantidad, 1.0)
                     , 2) VALORUNITARIO ,

                 COALESCE(MOVTO.SUBTOTAL,0) +
                  CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND
                  COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'  THEN 0.0 ELSE COALESCE(MOVTO.IEPS,0.0) END +
                  CASE WHEN COALESCE(:MOSTRARDESCUENTOENFACTURA,'N') = 'S' THEN COALESCE(MOVTO.DESCUENTO,0) ELSE 0.0 END SUBTOTAL,

                  PRODUCTO.CLAVE,
                  CASE WHEN COALESCE(PARAMETRO.ARRENDATARIO,'') = 'S' AND COALESCE(PRODUCTO.CUENTAPREDIAL,'') <> '' THEN  PRODUCTO.cuentapredial ELSE '' END,
                 SAT_PRODUCTOSERVICIO.sat_claveprodserv,
                 SAT_UNIDADMEDIDA.sat_clave,
                 CASE WHEN COALESCE(:MOSTRARDESCUENTOENFACTURA,'N') = 'S' THEN COALESCE(MOVTO.DESCUENTO,0) ELSE 0.0 END DESCUENTO,
                 CASE WHEN COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S' THEN 'S' ELSE 'N' END DESGLOSARIEPSMOVTO,
                 
                 CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND
                  COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'   THEN MOVTO.TASAieps ELSE 0.0 END TASAIEPS,

                  MOVTO.tasaiva ,
                 MOVTO.IVA,

                 CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND
                  COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S' THEN MOVTO.ieps ELSE 0.0 END,

                   MOVTO.IVARETENIDO  , MOVTO.tasaivaretenido  ,
                   MOVTO.isrretenido, MOVTO.TASAISRRETENIDO , PRODUCTO.ESKIT
                 FROM MOVTO
                 LEFT JOIN PRODUCTO ON PRODUCTO.ID = MOVTO.productoid
                 LEFT JOIN UNIDAD ON UNIDAD.CLAVE = PRODUCTO.unidad
                 LEFT JOIN SAT_UNIDADMEDIDA ON SAT_UNIDADMEDIDA.ID = UNIDAD.sat_unidadmedidaid
                 LEFT JOIN SAT_PRODUCTOSERVICIO ON SAT_PRODUCTOSERVICIO.id = PRODUCTO.sat_productoservicioid
                 LEFT JOIN PARAMETRO ON 1 = 1
                 WHERE MOVTO.DOCTOID = :DOCTOID
                      AND :TIPODOCTOID NOT IN (205)--Y NO ESTAMOS EN RECIBO ELECTRONICO
                 INTO
                 :MOVTOID, :cantidad , :unidad ,
                 :descripcion , :valorUnitario , :SUBTOTALMOVTO,
                 :noIdentificacion, :cuentaPredial, :claveProdServ ,
                 :claveUnidad , :descuentoMOVTO, :DESGLOSARIEPSMOVTO,
                 :PORCENTAJEIEPSMOVTO, :PORCENTAJEIVAMOVTO , :MONTOIVAMOVTO , :MONTOIEPSMOVTO , :MONTOIVARETENIDOMOVTO, :PORCENTAJEIVARETENIDOMOVTO,
                  :MONTOISRRETENIDOMOVTO, :PORCENTAJEISRRETENIDOMOVTO, :ESKIT
                 DO
                 BEGIN

                   IMPORTE = :SUBTOTALMOVTO;
                   DESCUENTO = :DESCUENTOMOVTO;

                   ID = :ID + 1;
                   TIPOLINEA = 'CONCEPTO';
                   SUSPEND;

                   PADRELINEA = :ID;



                   --INFORMACION ADUANERA
                   IF(COALESCE(:MANEJALOTEIMPORTACION,'N') = 'S') THEN
                   BEGIN
                    
                    FOR select --movto.id MOVTOID,
                        lotesimportados.pedimento IMPORTACION_PEDIMENTO,
                        lotesimportados.fechaimportacion IMPORTACION_FECHA,
                        sat_aduana.sat_claveaduana  IMPORTACION_ADUANA_SAT
                    from docto
                        inner join movto on movto.doctoid = docto.id
                        inner join movto mlp on mlp.doctoid = coalesce(docto.loteimportadodoctoid, docto.id) and mlp.productoid = movto.productoid  and coalesce(mlp.lote,'') = coalesce(movto.lote,'')  and mlp.precio = movto.precio
                        inner join lotesimportados on lotesimportados.id = mlp.loteimportado
                        inner join sat_aduana on lotesimportados.sataduanaid = sat_aduana.id
                    where docto.id = :DOCTOID  AND MOVTO.ID = :MOVTOID
                     INTO :NUMERO, :FECHA, :ADUANA
                     DO
                     BEGIN
                          ID = :ID + 1;
                          TIPOLINEA = 'INFORMACIONADUANERA';
                          SUSPEND;

                     END  
                   END

                   IF(COALESCE(:ESKIT,'N') <> 'S') THEN
                   BEGIN

                     --IEPS
                     IF( COALESCE(:DESGLOSARIEPSMOVTO,'N') = 'S' /*AND COALESCE(:MONTOIEPSMOVTO,0.0) > 0.01*/) THEN
                     BEGIN
                        Impuesto = '003';
                        Tasa = :PORCENTAJEIEPSMOVTO;
                        TasaCuota = :PORCENTAJEIEPSMOVTO;
                        Importe = :MONTOIEPSMOVTO;
                        TipoFactor = 'Tasa';
                        BaseImp = :SUBTOTALMOVTO - :DESCUENTOMOVTO;
                        ID = :ID + 1;
                        TIPOLINEA = 'CONCEPTO_IEPS';
                        SUSPEND;

                     END

                       
                     --IVA
                     IF( COALESCE(:MONTOIVAMOVTO,0.0) > 0.01) THEN
                     BEGIN
                        Impuesto = '002';
                        Tasa = :PORCENTAJEIVAMOVTO;
                        TasaCuota = :PORCENTAJEIVAMOVTO;
                        Importe = :MONTOIVAMOVTO;
                        TipoFactor = 'Tasa';
                        BaseImp = COALESCE(:SUBTOTALMOVTO,0.0) + COALESCE(:MONTOIEPSMOVTO,0.0) -  :DESCUENTOMOVTO;

                        ID = :ID + 1;
                        TIPOLINEA = 'CONCEPTO_IVA';
                        SUSPEND;

                     END

                      
                     --RETIENE IVA
                     IF( COALESCE(:PERSONARETIENEIVA,'N') = 'S' AND
                         COALESCE(:ESARRENDATARIO, 'N') = 'S'  AND
                         COALESCE(:MONTOIVARETENIDOMOVTO,0.0) > 0.01)THEN
                     BEGIN  
                        Impuesto = '002';
                        Tasa = :PORCENTAJEIVARETENIDOMOVTO;
                        TasaCuota = :PORCENTAJEIVARETENIDOMOVTO;
                        Importe = :MONTOIVARETENIDOMOVTO;
                        TipoFactor = 'Tasa';
                        BaseImp = COALESCE(:SUBTOTALMOVTO,0) + COALESCE(:MONTOIEPSMOVTO,0) - :DESCUENTOMOVTO;

                        ID = :ID + 1;
                        TIPOLINEA = 'CONCEPTO_IVARETENIDO';
                        SUSPEND;
                     END

                     
                     --RETIENE ISR
                     IF( COALESCE(:PERSONARETIENEISR,'N') = 'S' AND
                         COALESCE(:ESARRENDATARIO, 'N') = 'S'  AND
                         COALESCE(:MONTOISRRETENIDOMOVTO,0.0) > 0.01)THEN
                     BEGIN  
                        Impuesto = '001';
                        Tasa = :PORCENTAJEISRRETENIDOMOVTO;
                        TasaCuota = :PORCENTAJEISRRETENIDOMOVTO;
                        Importe = :MONTOISRRETENIDOMOVTO;
                        TipoFactor = 'Tasa';
                        BaseImp = COALESCE(:SUBTOTALMOVTO,0) + COALESCE(:MONTOIEPSMOVTO,0) - :DESCUENTOMOVTO;

                        ID = :ID + 1;
                        TIPOLINEA = 'CONCEPTO_ISRRETENIDO';
                        SUSPEND;
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
                             '' NUMEROPEDIMENTO
                        FROM
                            (SELECT DETALLEKITCANTIDAD ,DETALLEKITTASAIVA ,DETALLEKITTASAIEPS , DETALLEKITTASAIMPUESTO ,DETALLEKITTOTAL ,DETALLEKITSUBTOTAL ,DETALLEKITIVA ,DETALLEKITIEPS ,DETALLEKITPRECIO ,DETALLEKITPRECIOLISTA , DETALLEKITPRODUCTOID, 0.0 DETALLEKITTASAIVARETENIDO, 0.0 DETALLEKITIVARETENIDO, 0.0 DETALLEKITTASAISRRETENIDO, 0.0 DETALLEKITISRRETENIDO  FROM  KIT_OBTENREFERENCIA (:DOCTOID,:MOVTOID)) KITREF
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
                            :VALORUNITARIO, :IMPORTE , :NUMEROPEDIMENTO
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
                                    FROM  (SELECT DETALLEKITCANTIDAD ,DETALLEKITTASAIVA ,DETALLEKITTASAIEPS , DETALLEKITTASAIMPUESTO ,DETALLEKITTOTAL ,DETALLEKITSUBTOTAL ,DETALLEKITIVA ,DETALLEKITIEPS ,DETALLEKITPRECIO ,DETALLEKITPRECIOLISTA , DETALLEKITPRODUCTOID, 0.0 DETALLEKITTASAIVARETENIDO, 0.0 DETALLEKITIVARETENIDO, 0.0 DETALLEKITTASAISRRETENIDO, 0.0 DETALLEKITISRRETENIDO, DETALLEKITBASEIVA, DETALLEKITBASEIEPS  FROM  KIT_OBTENREFERENCIA (:DOCTOID,:MOVTOID)) KITREF
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
                                    SUM(COALESCE(DETALLEKITBASEIVA,0)) BASEIMP
                                    FROM  (SELECT DETALLEKITCANTIDAD ,DETALLEKITTASAIVA ,DETALLEKITTASAIEPS , DETALLEKITTASAIMPUESTO ,DETALLEKITTOTAL ,DETALLEKITSUBTOTAL ,DETALLEKITIVA ,DETALLEKITIEPS ,DETALLEKITPRECIO ,DETALLEKITPRECIOLISTA , DETALLEKITPRODUCTOID, 0.0 DETALLEKITTASAIVARETENIDO, 0.0 DETALLEKITIVARETENIDO, 0.0 DETALLEKITTASAISRRETENIDO, 0.0 DETALLEKITISRRETENIDO, DETALLEKITBASEIVA, DETALLEKITBASEIEPS  FROM  KIT_OBTENREFERENCIA (:DOCTOID,:MOVTOID)) KITREF
                                    LEFT JOIN PRODUCTO ON PRODUCTO.ID = DETALLEKITproductoid
                                --WHERE RECIBOS_CORE.MOVTOID = :MOVTOID
                                GROUP BY  DETALLEKITTASAIVA
                                INTO :IMPUESTO, :TASA, :TASACUOTA , :IMPORTE, :TIPOFACTOR, :BASEIMP
                                DO BEGIN
                                    IF(COALESCE(:importe, 0.0) > 0) THEN
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
                                    FROM  (SELECT DETALLEKITCANTIDAD ,DETALLEKITTASAIVA ,DETALLEKITTASAIEPS , DETALLEKITTASAIMPUESTO ,DETALLEKITTOTAL ,DETALLEKITSUBTOTAL ,DETALLEKITIVA ,DETALLEKITIEPS ,DETALLEKITPRECIO ,DETALLEKITPRECIOLISTA , DETALLEKITPRODUCTOID, 0.0 DETALLEKITTASAIVARETENIDO, 0.0 DETALLEKITIVARETENIDO, 0.0 DETALLEKITTASAISRRETENIDO, 0.0 DETALLEKITISRRETENIDO, DETALLEKITBASEIVA, DETALLEKITBASEIEPS  FROM  KIT_OBTENREFERENCIA (:DOCTOID,:MOVTOID)) KITREF
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
                                    FROM  (SELECT DETALLEKITCANTIDAD ,DETALLEKITTASAIVA ,DETALLEKITTASAIEPS , DETALLEKITTASAIMPUESTO ,DETALLEKITTOTAL ,DETALLEKITSUBTOTAL ,DETALLEKITIVA ,DETALLEKITIEPS ,DETALLEKITPRECIO ,DETALLEKITPRECIOLISTA , DETALLEKITPRODUCTOID, 0.0 DETALLEKITTASAIVARETENIDO, 0.0 DETALLEKITIVARETENIDO, 0.0 DETALLEKITTASAISRRETENIDO, 0.0 DETALLEKITISRRETENIDO, DETALLEKITBASEIVA, DETALLEKITBASEIEPS  FROM  KIT_OBTENREFERENCIA (:DOCTOID,:MOVTOID)) KITREF
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


                 PADRELINEA = 0;

                  --CONCEPTO RECIBO ELECTRONICO
                  IF(COALESCE(:TIPODOCTOID,0) = 205) THEN
                  BEGIN
                        
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
                                    
                     ID = :ID + 1;
                     TIPOLINEA = 'CONCEPTO';
                     SUSPEND;


                  END


                  --PAGOS RECIBO ELECTRONICO
                  FOR SELECT 
                        FechaPago ,
                        FormaDePagoP ,
                        MonedaP ,
                        TipoCambioP ,
                        Monto ,
                        NumOperacion ,
                        RfcEmisorCtaOrd ,
                        NomBancoOrdExt ,
                        CtaOrdenante ,
                        RfcEmisorCtaBen ,
                        CtaBeneficiario ,
                        TipoCadPago ,
                        CertPago ,
                        CadPago ,
                        SelloPago,
                        ID
                        FROM PAGOSAT WHERE PAGOSAT.doctosatid = :DOCTOID
                        into 
                            :FechaPago ,
                            :FormaDePagoP ,
                            :MonedaP ,
                            :TipoCambioP ,
                            :Monto ,
                            :NumOperacion ,
                            :RfcEmisorCtaOrd ,
                            :NomBancoOrdExt ,
                            :CtaOrdenante ,
                            :RfcEmisorCtaBen ,
                            :CtaBeneficiario ,
                            :TipoCadPago ,
                            :CertPago ,
                            :CadPago ,
                            :SelloPago,
                            :PAGOSATID
                         DO
                         BEGIN     
                            ID = :ID + 1;
                            TIPOLINEA = 'PAGO';
                            SUSPEND;

                            PADRELINEA = :ID;

                            FOR SELECT
                               IDDOCUMENTO,SERIE,FOLIO,
                                MONEDADR,TipoCambioDR, MetodoDePagoDR,
                                NumParcialidad,ImpSaldoAnt,ImpPagado,
                                ImpSaldoInsoluto
                                 FROM PAGODOCTOSAT
                                WHERE PAGOSATID = :PAGOSATID
                                INTO
                                  :IDDOCUMENTO,:SERIE,:FOLIO,
                                  :MONEDADR, :TipoCambioDR, :MetodoDePagoDR,
                                  :NumParcialidad, :ImpSaldoAnt, :ImpPagado,
                                  :ImpSaldoInsoluto
                                  DO
                                BEGIN 
                                    ID = :ID + 1;
                                    TIPOLINEA = 'PAGODOCTO';
                                    SUSPEND;
                                END


                         END


                         

                 PADRELINEA = 0;
                  -- DOCUMENTOS RELACIONADOS
                  IF(COALESCE(:TIPODOCTOID,0) = 22 ) THEN
                  BEGIN
                     SELECT DOCTOREF.TIMBRADOUUID
                        FROM DOCTO LEFT JOIN DOCTO DOCTOREF ON DOCTO.doctorefid = DOCTOREF.ID
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



                 FOR
                    SELECT   COALESCE(TASAIEPS_, 0.0) TASAIEPS_, SUM(COALESCE(IEPS,0.0)) IEPS
                      FROM(
                        SELECT
                            CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'   THEN COALESCE(MOVTO.tasaieps,0.0) ELSE 0.0 END TASAIEPS_,
                            CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'   THEN COALESCE(MOVTO.ieps,0.0) ELSE 0.0 END  IEPS
                         FROM MOVTO
                                LEFT JOIN PRODUCTO ON PRODUCTO.ID = MOVTO.productoid
                        WHERE MOVTO.DOCTOID = :DOCTOID and
                            CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'   THEN MOVTO.tasaieps ELSE 0.0 END > 0.0
                            AND COALESCE(PRODUCTO.eskit,'N') = 'N'

                       UNION ALL
                        SELECT
                            CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'   THEN COALESCE(DETALLEKITtasaieps,0.0) ELSE 0.0 END TASAIEPS_,
                            CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'   THEN COALESCE(DETALLEKITieps,0.0) ELSE 0.0 END  IEPS
                        FROM (SELECT DETALLEKITCANTIDAD ,DETALLEKITTASAIVA ,DETALLEKITTASAIEPS , DETALLEKITTASAIMPUESTO ,DETALLEKITTOTAL ,DETALLEKITSUBTOTAL ,DETALLEKITIVA ,DETALLEKITIEPS ,DETALLEKITPRECIO ,DETALLEKITPRECIOLISTA , DETALLEKITPRODUCTOID, 0.0 DETALLEKITTASAIVARETENIDO, 0.0 DETALLEKITIVARETENIDO, 0.0 DETALLEKITTASAISRRETENIDO, 0.0 DETALLEKITISRRETENIDO  FROM  KIT_OBTENREFERENCIA (:DOCTOID,0)) KITREF
                            LEFT JOIN PRODUCTO ON PRODUCTO.ID = DETALLEKITproductoid
                        WHERE --RECIBOS_CORE.DOCTOID = :DOCTOID and
                            CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'   THEN DETALLEKITtasaieps ELSE 0.0 END > 0.0
                       ) BASE
                       GROUP BY TASAIEPS_
                       INTO
                        :PORCENTAJEIEPSMOVTO, :MONTOIEPSMOVTO
                        DO
                        BEGIN    
                            Impuesto = '003';
                            Tasa = :PORCENTAJEIEPSMOVTO;
                            TasaCuota = :PORCENTAJEIEPSMOVTO;
                            Importe = :MONTOIEPSMOVTO;
                            TipoFactor = 'Tasa';
                            ID = :ID + 1;
                            TIPOLINEA = 'COMPROBANTE_IEPS';
                            SUSPEND;
                        END

                        
                 FOR
                    SELECT   COALESCE(TASAIVA_, 0.0) TASAIVA_, SUM(COALESCE(IVA,0.0)) IVA
                      FROM(
                        SELECT
                            COALESCE(MOVTO.tasaiva, 0.0)  TASAIVA_,
                            COALESCE(MOVTO.IVA,0.0) IVA
                         FROM MOVTO
                                LEFT JOIN PRODUCTO ON PRODUCTO.ID = MOVTO.productoid
                            LEFT JOIN SAT_PRODUCTOSERVICIO ON SAT_PRODUCTOSERVICIO.id = PRODUCTO.sat_productoservicioid
                            LEFT JOIN PARAMETRO ON 1 = 1
                        WHERE MOVTO.DOCTOID = :DOCTOID and
                             COALESCE(MOVTO.tasaiva,0)  > 0
                            AND COALESCE(PRODUCTO.eskit,'N') = 'N'

                       UNION  ALL
                        SELECT
                            COALESCE(DETALLEKITtasaiva, 0.0)  TASAIVA_,
                            COALESCE(DETALLEKITIVA,0.0) IVA
                        FROM (SELECT DETALLEKITCANTIDAD ,DETALLEKITTASAIVA ,DETALLEKITTASAIEPS , DETALLEKITTASAIMPUESTO ,DETALLEKITTOTAL ,DETALLEKITSUBTOTAL ,DETALLEKITIVA ,DETALLEKITIEPS ,DETALLEKITPRECIO ,DETALLEKITPRECIOLISTA , DETALLEKITPRODUCTOID, 0.0 DETALLEKITTASAIVARETENIDO, 0.0 DETALLEKITIVARETENIDO, 0.0 DETALLEKITTASAISRRETENIDO, 0.0 DETALLEKITISRRETENIDO  FROM  KIT_OBTENREFERENCIA (:DOCTOID,0)) KITREF
                            LEFT JOIN PRODUCTO ON PRODUCTO.ID = DETALLEKITproductoid
                        WHERE --RECIBOS_CORE.DOCTOID = :DOCTOID and
                         COALESCE(DETALLEKITtasaiva,0)  > 0
                       ) BASE
                       GROUP BY TASAIVA_
                       INTO
                        :PORCENTAJEIVAMOVTO,  :MONTOIVAMOVTO
                        DO
                        BEGIN    
                            Impuesto = '002';
                            Tasa = :PORCENTAJEIVAMOVTO;
                            TasaCuota = :PORCENTAJEIVAMOVTO;
                            Importe = :MONTOIVAMOVTO;
                            TipoFactor = 'Tasa';

                            ID = :ID + 1;
                            TIPOLINEA = 'COMPROBANTE_IVA';

                            IF(COALESCE(:IMPORTE,0) > 0 ) THEN
                            BEGIN   
                                SUSPEND;
                            END
                        END




                 IF( COALESCE(:PERSONARETIENEIVA,'N') = 'S' AND
                         COALESCE(:ESARRENDATARIO, 'N') = 'S') THEN
                   BEGIN

                    FOR
                      SELECT   COALESCE(TASAIVARETENIDO_, 0.0) TASAIVARETENIDO_, SUM(COALESCE(IVARETENIDO,0.0)) IVARETENIDO
                      FROM(
                        SELECT
                            COALESCE(MOVTO.tasaivaRETENIDO, 0.0)  TASAIVARETENIDO_,
                            COALESCE(MOVTO.IVARETENIDO,0.0) IVARETENIDO
                         FROM MOVTO
                                LEFT JOIN PRODUCTO ON PRODUCTO.ID = MOVTO.productoid
                        WHERE MOVTO.DOCTOID = :DOCTOID and
                             COALESCE(MOVTO.tasaivaRETENIDO,0)  > 0
                            AND COALESCE(PRODUCTO.eskit,'N') = 'N'

                       UNION  ALL
                        SELECT
                            COALESCE(DETALLEKITtasaivaRETENIDO, 0.0)  TASAIVARETENIDO_,
                            COALESCE(DETALLEKITIVARETENIDO,0.0) IVARETENIDO
                        FROM (SELECT DETALLEKITCANTIDAD ,DETALLEKITTASAIVA ,DETALLEKITTASAIEPS , DETALLEKITTASAIMPUESTO ,DETALLEKITTOTAL ,DETALLEKITSUBTOTAL ,DETALLEKITIVA ,DETALLEKITIEPS ,DETALLEKITPRECIO ,DETALLEKITPRECIOLISTA , DETALLEKITPRODUCTOID, 0.0 DETALLEKITTASAIVARETENIDO, 0.0 DETALLEKITIVARETENIDO, 0.0 DETALLEKITTASAISRRETENIDO, 0.0 DETALLEKITISRRETENIDO  FROM  KIT_OBTENREFERENCIA (:DOCTOID,0)) KITREF
                            LEFT JOIN PRODUCTO ON PRODUCTO.ID = DETALLEKITproductoid
                        --WHERE RECIBOS_CORE.DOCTOID = :DOCTOID and
                         WHERE COALESCE(DETALLEKITtasaivaRETENIDO,0)  > 0
                       ) BASE
                       GROUP BY TASAIVARETENIDO_
                       INTO
                        :MONTOIVARETENIDOMOVTO, :PORCENTAJEIVARETENIDOMOVTO
                        DO
                        BEGIN    
                            Impuesto = '002';
                            Tasa = :PORCENTAJEIVARETENIDOMOVTO;
                            Importe = :MONTOIVARETENIDOMOVTO;
                            ID = :ID + 1;
                            TIPOLINEA = 'COMPROBANTE_IVARETENIDO';   
                            SUSPEND;
                        END

                   END


                 IF( COALESCE(:PERSONARETIENEISR,'N') = 'S' AND
                         COALESCE(:ESARRENDATARIO, 'N') = 'S') THEN
                   BEGIN

                   
                    FOR
                      SELECT   COALESCE(TASAISRRETENIDO_, 0.0) TASAISRRETENIDO_, SUM(COALESCE(ISRRETENIDO,0.0)) ISRRETENIDO
                      FROM(
                        SELECT
                            COALESCE(MOVTO.tasaiSRRETENIDO, 0.0)  TASAISRRETENIDO_,
                            COALESCE(MOVTO.ISRRETENIDO,0.0) ISRRETENIDO
                         FROM MOVTO
                                LEFT JOIN PRODUCTO ON PRODUCTO.ID = MOVTO.productoid
                        WHERE MOVTO.DOCTOID = :DOCTOID and
                             COALESCE(MOVTO.tasaiSRRETENIDO,0)  > 0
                            AND COALESCE(PRODUCTO.eskit,'N') = 'N'

                       UNION  ALL
                        SELECT
                            COALESCE(DETALLEKITtasaiSRRETENIDO, 0.0)  TASAISRRETENIDO_,
                            COALESCE(DETALLEKITISRRETENIDO,0.0) ISRRETENIDO
                        FROM (SELECT DETALLEKITCANTIDAD ,DETALLEKITTASAIVA ,DETALLEKITTASAIEPS , DETALLEKITTASAIMPUESTO ,DETALLEKITTOTAL ,DETALLEKITSUBTOTAL ,DETALLEKITIVA ,DETALLEKITIEPS ,DETALLEKITPRECIO ,DETALLEKITPRECIOLISTA , DETALLEKITPRODUCTOID, 0.0 DETALLEKITTASAIVARETENIDO, 0.0 DETALLEKITIVARETENIDO, 0.0 DETALLEKITTASAISRRETENIDO, 0.0 DETALLEKITISRRETENIDO  FROM  KIT_OBTENREFERENCIA (:DOCTOID,0)) KITREF
                            LEFT JOIN PRODUCTO ON PRODUCTO.ID = DETALLEKITproductoid
                        --WHERE RECIBOS_CORE.DOCTOID = :DOCTOID and
                         WHERE  COALESCE(DETALLEKITtasaiSRRETENIDO,0)  > 0
                       ) BASE
                       GROUP BY TASAISRRETENIDO_
                       INTO
                        :MONTOISRRETENIDOMOVTO, :PORCENTAJEISRRETENIDOMOVTO
                        DO
                        BEGIN    
                            Impuesto = '001';
                            Tasa = :PORCENTAJEISRRETENIDOMOVTO;
                            Importe = :MONTOISRRETENIDOMOVTO;
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
                            AND COALESCE(PRODUCTO.eskit,'N') = 'N'

                       UNION ALL
                        SELECT
                            CASE when COALESCE(:PERSONADESGLOSAIEPS,'N') = 'S' AND COALESCE(:EMPRESADESGLOSAIEPS,'N') = 'S'   THEN COALESCE(DETALLEKITieps,0.0) ELSE 0.0 END  IEPS,
                            COALESCE(DETALLEKITIVA,0.0) IVA,
                            COALESCE(DETALLEKITIVARETENIDO,0.0) IVARETENIDO ,
                            COALESCE(DETALLEKITISRRETENIDO,0.0) ISRRETENIDO
                        FROM (SELECT DETALLEKITCANTIDAD ,DETALLEKITTASAIVA ,DETALLEKITTASAIEPS , DETALLEKITTASAIMPUESTO ,DETALLEKITTOTAL ,DETALLEKITSUBTOTAL ,DETALLEKITIVA ,DETALLEKITIEPS ,DETALLEKITPRECIO ,DETALLEKITPRECIOLISTA , DETALLEKITPRODUCTOID, 0.0 DETALLEKITTASAIVARETENIDO, 0.0 DETALLEKITIVARETENIDO, 0.0 DETALLEKITTASAISRRETENIDO, 0.0 DETALLEKITISRRETENIDO  FROM  KIT_OBTENREFERENCIA (:DOCTOID,0)) KITREF
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