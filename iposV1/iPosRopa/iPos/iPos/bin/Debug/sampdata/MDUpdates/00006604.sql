create or alter procedure FACTURAELECTRONICA_GUARDAR (
    DOCTOID D_FK,
    TIPOCOMPROBANTEAGUARDAR varchar(10),
    CARTAPORTEGUARDAR D_BOOLCN)
returns (
    CFDIID D_FK,
    ERRORCODE D_ERRORCODE)
as
declare variable ID D_FK;
declare variable TIPOLINEA D_NOMBRE_NULL;
declare variable PADRELINEA integer;
declare variable ORDENLINEA integer;
declare variable SUBORDEN integer;
declare variable SERIE D_STDTEXT_64;
declare variable FOLIO D_STDTEXT_64;
declare variable FECHA D_TIMESTAMP;
declare variable TIPOCOMPROBANTE D_STDTEXT_64;
declare variable FORMAPAGO D_STDTEXT_64;
declare variable SUBTOTAL D_IMPORTE;
declare variable DESCUENTO D_IMPORTE;
declare variable TOTAL D_IMPORTE;
declare variable MONEDA D_STDTEXT_64;
declare variable TIPOCAMBIO D_STDTEXT_64;
declare variable CONDICIONESPAGO D_STDTEXT_LARGE;
declare variable METODOPAGO D_STDTEXT_64;
declare variable MOTIVODESCUENTO D_STDTEXT_64;
declare variable LUGAREXPEDICION D_STDTEXT_LARGE;
declare variable NUMEROCTAPAGO D_STDTEXT_LARGE;
declare variable SERIEFOLIOFISCALORIGINAL D_STDTEXT_64;
declare variable FOLIOFISCALORIGINAL D_STDTEXT_64;
declare variable MONTOFOLIOFISCALORIGINAL D_IMPORTE;
declare variable FECHAFOLIOFISCALORIGINAL D_FECHA;
declare variable RFC D_STDTEXT_64;
declare variable RAZONSOCIAL D_STDTEXT_LARGE;
declare variable REGIMENFISCAL D_STDTEXT_64;
declare variable CALLE D_STDTEXT_LARGE;
declare variable NOINTERIOR D_STDTEXT_64;
declare variable NOEXTERIOR D_STDTEXT_64;
declare variable COLONIA D_STDTEXT_LARGE;
declare variable LOCALIDAD D_STDTEXT_LARGE;
declare variable REFERENCIA D_STDTEXT_LARGE;
declare variable MUNICIPIO D_STDTEXT_LARGE;
declare variable ESTADO D_STDTEXT_MEDIUM;
declare variable PAIS D_STDTEXT_64;
declare variable CODIGOPOSTAL D_STDTEXT_64;
declare variable NOMBRE D_STDTEXT_LARGE;
declare variable RESIDENCIAFISCAL D_STDTEXT_LARGE;
declare variable NUMREGIDTRIB D_STDTEXT_64;
declare variable USOCFDI D_STDTEXT_64;
declare variable CANTIDAD D_CANTIDAD;
declare variable UNIDAD D_STDTEXT_64;
declare variable DESCRIPCION D_STDTEXT_LARGE;
declare variable VALORUNITARIO D_IMPORTE;
declare variable IMPORTE D_IMPORTE;
declare variable NOIDENTIFICACION D_STDTEXT_64;
declare variable CUENTAPREDIAL D_STDTEXT_64;
declare variable CLAVEPRODSERV D_STDTEXT_64;
declare variable CLAVEUNIDAD D_STDTEXT_64;
declare variable NUMERO D_STDTEXT_64;
declare variable ADUANA D_STDTEXT_64;
declare variable IMPUESTO D_STDTEXT_64;
declare variable TASA D_PORCENTAJE;
declare variable BASEIMP D_PRECIO;
declare variable TIPOFACTOR D_STDTEXT_64;
declare variable TASACUOTA D_STDTEXT_64;
declare variable FECHAPAGO D_FECHA;
declare variable FORMADEPAGOP D_STDTEXT_64;
declare variable MONEDAP D_STDTEXT_64;
declare variable TIPOCAMBIOP D_STDTEXT_64;
declare variable MONTO D_IMPORTE;
declare variable NUMOPERACION D_STDTEXT_64;
declare variable RFCEMISORCTAORD D_STDTEXT_64;
declare variable NOMBANCOORDEXT D_NOMBRE_NULL;
declare variable CTAORDENANTE D_STDTEXT_64;
declare variable RFCEMISORCTABEN D_STDTEXT_64;
declare variable CTABENEFICIARIO D_STDTEXT_64;
declare variable TIPOCADPAGO D_STDTEXT_64;
declare variable CERTPAGO D_STDTEXT_64;
declare variable CADPAGO D_STDTEXT_64;
declare variable SELLOPAGO D_STDTEXT_64;
declare variable IDDOCUMENTO D_STDTEXT_64;
declare variable MONEDADR D_STDTEXT_64;
declare variable TIPOCAMBIODR D_STDTEXT_64;
declare variable METODODEPAGODR D_STDTEXT_64;
declare variable NUMPARCIALIDAD D_STDTEXT_64;
declare variable IMPSALDOANT D_IMPORTE;
declare variable IMPPAGADO D_IMPORTE;
declare variable IMPSALDOINSOLUTO D_IMPORTE;
declare variable TOTALTRASLADOS D_IMPORTE;
declare variable TOTALRETENCIONES D_IMPORTE;
declare variable TIPORELACION D_STDTEXT_64;
declare variable UUID D_STDTEXT_64;
declare variable IMPRIMIRCOMPROBANTESPAGO D_BOOLCN;
declare variable NUMEROPEDIMENTO D_STDTEXT_64;
declare variable MOVTOID D_FK;
declare variable MOVTOKITID D_FK;
declare variable PAGOSATID D_FK;
declare variable CFDI_CONC_ID D_FK;
declare variable TRANSPINTERNAC D_STDTEXT_MEDIUM;
declare variable ENTRADASALIDAMERC D_STDTEXT_MEDIUM;
declare variable PAISORIGENDESTINO D_STDTEXT_MEDIUM;
declare variable VIAENTRADASALIDA D_STDTEXT_MEDIUM;
declare variable TOTALDISTREC D_STDTEXT_MEDIUM;
declare variable TIPOUBICACION D_STDTEXT_MEDIUM;
declare variable IDUBICACION D_STDTEXT_MEDIUM;
declare variable RFCREMITENTEDESTINATARIO D_STDTEXT_MEDIUM;
declare variable NOMBREREMITENTEDESTINATARIO D_STDTEXT_MEDIUM;
declare variable NUMESTACION D_STDTEXT_MEDIUM;
declare variable NOMBREESTACION D_STDTEXT_MEDIUM;
declare variable NAVEGACIONTRAFICO D_STDTEXT_MEDIUM;
declare variable FECHAHORASALIDALLEGADA D_STDTEXT_MEDIUM;
declare variable TIPOESTACION D_STDTEXT_MEDIUM;
declare variable DISTANCIARECORRIDA D_STDTEXT_MEDIUM;
declare variable NUMEROEXTERIOR D_STDTEXT_MEDIUM;
declare variable NUMEROINTERIOR D_STDTEXT_MEDIUM;
declare variable PESOBRUTOTOTAL D_STDTEXT_MEDIUM;
declare variable UNIDADPESO D_STDTEXT_MEDIUM;
declare variable PESONETOTOTAL D_STDTEXT_MEDIUM;
declare variable NUMTOTALMERCANCIAS D_STDTEXT_MEDIUM;
declare variable CARGOPORTASACION D_STDTEXT_MEDIUM;
declare variable BIENESTRANSP D_STDTEXT_MEDIUM;
declare variable CLAVESTCC D_STDTEXT_MEDIUM;
declare variable DIMENSIONES D_STDTEXT_MEDIUM;
declare variable MATERIALPELIGROSO D_STDTEXT_MEDIUM;
declare variable CVEMATERIALPELIGROSO D_STDTEXT_MEDIUM;
declare variable EMBALAJE D_STDTEXT_MEDIUM;
declare variable DESCRIPEMBALAJE D_STDTEXT_MEDIUM;
declare variable PESOENKG D_STDTEXT_MEDIUM;
declare variable VALORMERCANCIA D_STDTEXT_MEDIUM;
declare variable FRACCIONARANCELARIA D_STDTEXT_MEDIUM;
declare variable UUIDCOMERCIOEXT D_STDTEXT_MEDIUM;
declare variable UNIDADPESOMERC D_STDTEXT_MEDIUM;
declare variable PESOBRUTO D_STDTEXT_MEDIUM;
declare variable PESONETO D_STDTEXT_MEDIUM;
declare variable PESOTARA D_STDTEXT_MEDIUM;
declare variable NUMPIEZAS D_STDTEXT_MEDIUM;
declare variable IDORIGEN D_STDTEXT_MEDIUM;
declare variable IDDESTINO D_STDTEXT_MEDIUM;
declare variable CVESTRANSPORTE D_STDTEXT_MEDIUM;
declare variable TIPOFIGURA D_STDTEXT_MEDIUM;
declare variable RFCFIGURA D_STDTEXT_MEDIUM;
declare variable NUMLICENCIA D_STDTEXT_MEDIUM;
declare variable NOMBREFIGURA D_STDTEXT_MEDIUM;
declare variable NUMREGIDTRIBFIGURA D_STDTEXT_MEDIUM;
declare variable RESIDENCIAFISCALFIGURA D_STDTEXT_MEDIUM;
declare variable PARTETRANSPORTE D_STDTEXT_MEDIUM;
declare variable PERMSCT D_STDTEXT_MEDIUM;
declare variable NUMPERMISOSCT D_STDTEXT_MEDIUM;
declare variable CONFIGVEHICULAR D_STDTEXT_MEDIUM;
declare variable PLACAVM D_STDTEXT_MEDIUM;
declare variable ANIOMODELOVM D_STDTEXT_MEDIUM;
declare variable ASEGURARESPCIVIL D_STDTEXT_MEDIUM;
declare variable POLIZARESPCIVIL D_STDTEXT_MEDIUM;
declare variable ASEGURAMEDAMBIENTE D_STDTEXT_MEDIUM;
declare variable POLIZAMEDAMBIENTE D_STDTEXT_MEDIUM;
declare variable ASEGURACARGA D_STDTEXT_MEDIUM;
declare variable POLIZACARGA D_STDTEXT_MEDIUM;
declare variable PRIMASEGURO D_STDTEXT_MEDIUM;
declare variable SUBTIPOREM1 D_STDTEXT_MEDIUM;
declare variable PLACA1 D_STDTEXT_MEDIUM;
declare variable SUBTIPOREM2 D_STDTEXT_MEDIUM;
declare variable PLACA2 D_STDTEXT_MEDIUM;
declare variable CARTAPORTEID D_FK;
BEGIN

    CFDIID = 0;

    FOR SELECT 
        ID ,
        TIPOLINEA ,
        PADRELINEA ,
        ORDENLINEA ,
        SUBORDEN ,
        SERIE ,
        FOLIO ,
        FECHA ,
        TIPOCOMPROBANTE ,
        FORMAPAGO ,
        SUBTOTAL ,
        DESCUENTO ,
        TOTAL ,
        MONEDA ,
        TIPOCAMBIO ,
        CONDICIONESPAGO ,
        METODOPAGO ,
        MOTIVODESCUENTO ,
        LUGAREXPEDICION ,
        NUMEROCTAPAGO ,
        SERIEFOLIOFISCALORIGINAL ,
        FOLIOFISCALORIGINAL ,
        MONTOFOLIOFISCALORIGINAL ,
        FECHAFOLIOFISCALORIGINAL ,
        RFC ,
        RAZONSOCIAL ,
        REGIMENFISCAL ,
        CALLE ,
        NOINTERIOR ,
        NOEXTERIOR ,
        COLONIA ,
        LOCALIDAD ,
        REFERENCIA ,
        MUNICIPIO ,
        ESTADO ,
        PAIS ,
        CODIGOPOSTAL ,
        NOMBRE ,
        RESIDENCIAFISCAL ,
        NUMREGIDTRIB ,
        USOCFDI ,
        CANTIDAD ,
        UNIDAD ,
        DESCRIPCION ,
        VALORUNITARIO ,
        IMPORTE ,
        NOIDENTIFICACION ,
        CUENTAPREDIAL ,
        CLAVEPRODSERV ,
        CLAVEUNIDAD ,
        NUMERO ,
        ADUANA ,
        IMPUESTO ,
        TASA ,
        BASEIMP ,
        TIPOFACTOR ,
        TASACUOTA ,
        FECHAPAGO ,
        FORMADEPAGOP ,
        MONEDAP ,
        TIPOCAMBIOP ,
        MONTO ,
        NUMOPERACION ,
        RFCEMISORCTAORD ,
        NOMBANCOORDEXT ,
        CTAORDENANTE ,
        RFCEMISORCTABEN ,
        CTABENEFICIARIO ,
        TIPOCADPAGO ,
        CERTPAGO ,
        CADPAGO ,
        SELLOPAGO ,
        IDDOCUMENTO ,
        MONEDADR ,
        TIPOCAMBIODR ,
        METODODEPAGODR ,
        NUMPARCIALIDAD ,
        IMPSALDOANT ,
        IMPPAGADO ,
        IMPSALDOINSOLUTO ,
        TOTALTRASLADOS ,
        TOTALRETENCIONES ,
        TIPORELACION ,
        UUID ,
        IMPRIMIRCOMPROBANTESPAGO ,
        NUMEROPEDIMENTO ,
        MOVTOID ,
        MOVTOKITID ,
        PAGOSATID 
        FROM
        FACTURAELECTRONICA_XML (
            :DOCTOID, :TIPOCOMPROBANTEAGUARDAR)
        INTO 
        :ID ,
        :TIPOLINEA ,
        :PADRELINEA ,
        :ORDENLINEA ,
        :SUBORDEN ,
        :SERIE ,
        :FOLIO ,
        :FECHA ,
        :TIPOCOMPROBANTE ,
        :FORMAPAGO ,
        :SUBTOTAL ,
        :DESCUENTO ,
        :TOTAL ,
        :MONEDA ,
        :TIPOCAMBIO ,
        :CONDICIONESPAGO ,
        :METODOPAGO ,
        :MOTIVODESCUENTO ,
        :LUGAREXPEDICION ,
        :NUMEROCTAPAGO ,
        :SERIEFOLIOFISCALORIGINAL ,
        :FOLIOFISCALORIGINAL ,
        :MONTOFOLIOFISCALORIGINAL ,
        :FECHAFOLIOFISCALORIGINAL ,
        :RFC ,
        :RAZONSOCIAL ,
        :REGIMENFISCAL ,
        :CALLE ,
        :NOINTERIOR ,
        :NOEXTERIOR ,
        :COLONIA ,
        :LOCALIDAD ,
        :REFERENCIA ,
        :MUNICIPIO ,
        :ESTADO ,
        :PAIS ,
        :CODIGOPOSTAL ,
        :NOMBRE ,
        :RESIDENCIAFISCAL ,
        :NUMREGIDTRIB ,
        :USOCFDI ,
        :CANTIDAD ,
        :UNIDAD ,
        :DESCRIPCION ,
        :VALORUNITARIO ,
        :IMPORTE ,
        :NOIDENTIFICACION ,
        :CUENTAPREDIAL ,
        :CLAVEPRODSERV ,
        :CLAVEUNIDAD ,
        :NUMERO ,
        :ADUANA ,
        :IMPUESTO ,
        :TASA ,
        :BASEIMP ,
        :TIPOFACTOR ,
        :TASACUOTA ,
        :FECHAPAGO ,
        :FORMADEPAGOP ,
        :MONEDAP ,
        :TIPOCAMBIOP ,
        :MONTO ,
        :NUMOPERACION ,
        :RFCEMISORCTAORD ,
        :NOMBANCOORDEXT ,
        :CTAORDENANTE ,
        :RFCEMISORCTABEN ,
        :CTABENEFICIARIO ,
        :TIPOCADPAGO ,
        :CERTPAGO ,
        :CADPAGO ,
        :SELLOPAGO ,
        :IDDOCUMENTO ,
        :MONEDADR ,
        :TIPOCAMBIODR ,
        :METODODEPAGODR ,
        :NUMPARCIALIDAD ,
        :IMPSALDOANT ,
        :IMPPAGADO ,
        :IMPSALDOINSOLUTO ,
        :TOTALTRASLADOS ,
        :TOTALRETENCIONES ,
        :TIPORELACION ,
        :UUID ,
        :IMPRIMIRCOMPROBANTESPAGO ,
        :NUMEROPEDIMENTO ,
        :MOVTOID ,
        :MOVTOKITID ,
        :PAGOSATID
        DO
        BEGIN

          IF(COALESCE(:TIPOLINEA,'') = 'COMPROBANTE') THEN
          BEGIN

            IF(COALESCE(:TIPOCOMPROBANTEAGUARDAR , '') = 'T' ) THEN
            BEGIN
                 
                  TIPOCOMPROBANTE = 'T' ;
                  FORMAPAGO = '';
                  SUBTOTAL = 0;
                  DESCUENTO = 0;
                  TOTAL = 0;
                  CONDICIONESPAGO = '';
                  METODOPAGO = '';
            END


            INSERT INTO CFDI
            (
                  DOCTOID,
                  SERIE,
                  FOLIO ,
                  FECHA,
                  TIPOCOMPROBANTE,
                  FORMAPAGO,
                  SUBTOTAL,
                  DESCUENTO ,
                  TOTAL,
                  MONEDA,
                  TIPOCAMBIO,
                  CONDICIONESPAGO ,
                  METODOPAGO,
                  MOTIVODESCUENTO,
                  LUGAREXPEDICION
          )
          VALUES( 
                  :DOCTOID,
                  :SERIE,
                  :FOLIO ,
                  CAST(:FECHA AS D_FECHA),
                  :TIPOCOMPROBANTE,
                  :FORMAPAGO,
                  :SUBTOTAL,
                  :DESCUENTO ,
                  :TOTAL,
                  :MONEDA,
                  :TIPOCAMBIO,
                  :CONDICIONESPAGO ,
                  :METODOPAGO,
                  :MOTIVODESCUENTO,
                  :LUGAREXPEDICION

          ) RETURNING ID INTO :CFDIID;

          UPDATE DOCTO SET CFDIID = :CFDIID WHERE ID  = :DOCTOID;

         END
         ELSE IF(COALESCE(:TIPOLINEA,'') = 'COMPROBANTEINFOEX') THEN
         BEGIN
             UPDATE CFDI
             SET
                EX_LUGAREXPEDICION = :LUGAREXPEDICION,
                EX_NUMEROCTAPAGO = :NUMEROCTAPAGO,
                EX_SERIEFOLIOFISCALORIGINAL = :SERIEFOLIOFISCALORIGINAL,
                EX_FOLIOFISCALORIGINAL = :FOLIOFISCALORIGINAL,
                EX_MONTOFOLIOFISCALORIGINAL = :MONTOFOLIOFISCALORIGINAL,
                EX_FECHAFOLIOFISCALORIGINAL = :FECHAFOLIOFISCALORIGINAL
             WHERE ID = :CFDIID;

                


         END 
         ELSE IF(COALESCE(:TIPOLINEA,'') = 'EMISOR') THEN
         BEGIN

              
             UPDATE CFDI
             SET
                EM_RFC = :RFC,
                EM_RAZONSOCIAL = :RAZONSOCIAL,
                EM_REGIMENFISCAL = :REGIMENFISCAL,
                EM_CALLE = :CALLE,
                EM_NOEXTERIOR = :NOEXTERIOR,
                EM_NOINTERIOR = :NOINTERIOR,
                EM_COLONIA = :COLONIA,
                EM_LOCALIDAD = :LOCALIDAD,
                EM_REFERENCIA = :REFERENCIA,
                EM_MUNICIPIO = :MUNICIPIO,
                EM_ESTADO = :ESTADO,
                EM_PAIS = :PAIS,
                EM_CODIGOPOSTAL = :CODIGOPOSTAL

             WHERE ID = :CFDIID;


         END
         ELSE IF(COALESCE(:TIPOLINEA,'') = 'EMISOREXPEDIDOEN') THEN
         BEGIN
         
              
             UPDATE CFDI
             SET
                EE_CALLE = :CALLE,
                EE_NOEXTERIOR = :NOEXTERIOR,
                EE_NOINTERIOR = :NOINTERIOR,
                EE_COLONIA = :COLONIA,
                EE_LOCALIDAD = :LOCALIDAD,
                EE_REFERENCIA = :REFERENCIA,
                EE_MUNICIPIO = :MUNICIPIO,
                EE_ESTADO = :ESTADO,
                EE_PAIS = :PAIS,
                EE_CODIGOPOSTAL = :CODIGOPOSTAL
             WHERE ID = :CFDIID;

         END
         ELSE IF(COALESCE(:TIPOLINEA,'') = 'RECEPTORINFO') THEN
         BEGIN   
             UPDATE CFDI
             SET
                RC_RFC = :RFC,
                RC_RAZONSOCIAL = :RAZONSOCIAL,
                RC_RESIDENCIAFISCAL = :RESIDENCIAFISCAL,
                RC_NOMBRE = :NOMBRE,
                RC_NUMREGIDTRIB = :NUMREGIDTRIB,
                RC_USOCFDI = :USOCFDI,
                RC_CALLE = :CALLE,
                RC_NOEXTERIOR = :NOEXTERIOR,
                RC_NOINTERIOR = :NOINTERIOR,
                RC_COLONIA = :COLONIA,
                RC_LOCALIDAD = :LOCALIDAD,
                RC_REFERENCIA = :REFERENCIA,
                RC_MUNICIPIO = :MUNICIPIO,
                RC_ESTADO = :ESTADO,
                RC_PAIS = :PAIS,
                RC_CODIGOPOSTAL = :CODIGOPOSTAL

             WHERE ID = :CFDIID;

         END
         ELSE IF(COALESCE(:TIPOLINEA,'') = 'CONCEPTO') THEN
         BEGIN
            INSERT INTO CFDI_CONC
            (  
                CANTIDAD,
                UNIDAD,
                DESCRIPCION,
                VALORUNITARIO,
                IMPORTE,
                NOIDENTIFICACION,
                CUENTAPREDIAL,
                CLAVEPRODSERV,
                CLAVEUNIDAD,
                DESCUENTO,
                CFDIID,
                MOVTOID,
                CONSECUTIVO
            )
            VALUES
            (   
                :CANTIDAD,
                :UNIDAD,
                :DESCRIPCION,
                :VALORUNITARIO,
                :IMPORTE,
                :NOIDENTIFICACION,
                :CUENTAPREDIAL,
                :CLAVEPRODSERV,
                :CLAVEUNIDAD,
                :DESCUENTO,
                :CFDIID,
                :MOVTOID,
                :ID

            );
         END
         ELSE IF(COALESCE(:TIPOLINEA,'') = 'CONCEPTO_PARTE') THEN
         BEGIN
            SELECT ID FROM CFDI_CONC
            WHERE CFDIID = :CFDIID AND CONSECUTIVO = :PADRELINEA
            INTO :CFDI_CONC_ID;

            INSERT INTO CFDI_CONC_PART
            (     
                CLAVEPRODSERV,
                NOIDENTIFICACION,
                CANTIDAD,
                UNIDAD,
                DESCRIPCION,
                VALORUNITARIO,
                IMPORTE,
                NUMEROPEDIMENTO,
                CFDI_CONC_ID,
                MOVTOKITID

            )
            VALUES
            (   
                :CLAVEPRODSERV,
                :NOIDENTIFICACION,
                :CANTIDAD,
                :UNIDAD,
                :DESCRIPCION,
                :VALORUNITARIO,
                :IMPORTE,
                '',
                :CFDI_CONC_ID,
                :MOVTOKITID

            );


         END  
         ELSE IF(COALESCE(:TIPOLINEA,'') = 'INFORMACIONADUANERA' AND COALESCE(:TIPOCOMPROBANTE,'') <> 'T') THEN
         BEGIN   
            SELECT ID FROM CFDI_CONC
            WHERE CFDIID = :CFDIID AND CONSECUTIVO = :PADRELINEA
            INTO :CFDI_CONC_ID;

            INSERT INTO CFDI_CONC_ADU
            (
                FECHA,
                NUMERO,
                ADUANA,
                CFDI_CONC_ID

            )
            VALUES
            (
                CAST(:FECHA AS D_FECHA),
                :NUMERO,
                :ADUANA,
                :CFDI_CONC_ID

            );
         END
         ELSE IF(COALESCE(:TIPOLINEA,'') = 'CONCEPTO_IEPS' AND COALESCE(:TIPOCOMPROBANTE,'') <> 'T') THEN
         BEGIN
          
            SELECT ID FROM CFDI_CONC
            WHERE CFDIID = :CFDIID AND CONSECUTIVO = :PADRELINEA
            INTO :CFDI_CONC_ID;

            INSERT INTO CFDI_CONC_IMP
            (
                TIPOLINEA,
                BASEIMP,
                TIPOFACTOR,
                TASACUOTA,
                TASA,
                IMPUESTO,
                IMPORTE,
                CFDI_CONC_ID

            )
            VALUES
            (   
                :TIPOLINEA,
                :BASEIMP,
                :TIPOFACTOR,
                :TASACUOTA,
                :TASA,
                :IMPUESTO,
                :IMPORTE,
                :CFDI_CONC_ID
            );

         END
         ELSE IF(COALESCE(:TIPOLINEA,'') = 'CONCEPTO_IVA' AND COALESCE(:TIPOCOMPROBANTE,'') <> 'T') THEN
         BEGIN  
            SELECT ID FROM CFDI_CONC
            WHERE CFDIID = :CFDIID AND CONSECUTIVO = :PADRELINEA
            INTO :CFDI_CONC_ID;

            INSERT INTO CFDI_CONC_IMP
            (
                TIPOLINEA,
                BASEIMP,
                TIPOFACTOR,
                TASACUOTA,
                TASA,
                IMPUESTO,
                IMPORTE,
                CFDI_CONC_ID

            )
            VALUES
            (   
                :TIPOLINEA,
                :BASEIMP,
                :TIPOFACTOR,
                :TASACUOTA,
                :TASA,
                :IMPUESTO,
                :IMPORTE,
                :CFDI_CONC_ID
            );
         END
         ELSE IF(COALESCE(:TIPOLINEA,'') = 'CONCEPTO_IVARETENIDO' AND COALESCE(:TIPOCOMPROBANTE,'') <> 'T') THEN
         BEGIN 
            SELECT ID FROM CFDI_CONC
            WHERE CFDIID = :CFDIID AND CONSECUTIVO = :PADRELINEA
            INTO :CFDI_CONC_ID;

            INSERT INTO CFDI_CONC_IMP
            (
                TIPOLINEA,
                BASEIMP,
                TIPOFACTOR,
                TASACUOTA,
                TASA,
                IMPUESTO,
                IMPORTE,
                CFDI_CONC_ID

            )
            VALUES
            (   
                :TIPOLINEA,
                :BASEIMP,
                :TIPOFACTOR,
                :TASACUOTA,
                :TASA,
                :IMPUESTO,
                :IMPORTE,
                :CFDI_CONC_ID
            );
         END
         ELSE IF(COALESCE(:TIPOLINEA,'') = 'CONCEPTO_ISRRETENIDO' AND COALESCE(:TIPOCOMPROBANTE,'') <> 'T') THEN
         BEGIN   
            SELECT ID FROM CFDI_CONC
            WHERE CFDIID = :CFDIID AND CONSECUTIVO = :PADRELINEA
            INTO :CFDI_CONC_ID;

            INSERT INTO CFDI_CONC_IMP
            (
                TIPOLINEA,
                BASEIMP,
                TIPOFACTOR,
                TASACUOTA,
                TASA,
                IMPUESTO,
                IMPORTE,
                CFDI_CONC_ID

            )
            VALUES
            (   
                :TIPOLINEA,
                :BASEIMP,
                :TIPOFACTOR,
                :TASACUOTA,
                :TASA,
                :IMPUESTO,
                :IMPORTE,
                :CFDI_CONC_ID
            );
         END
         ELSE IF(COALESCE(:TIPOLINEA,'') = 'PAGO') THEN
         BEGIN

             UPDATE pagosat SET CFDIID = :CFDIID WHERE ID = :PAGOSATID;
         END
         --ELSE IF(COALESCE(:TIPOLINEA,'') = 'PAGODOCTO') THEN
         --BEGIN
         --END
         ELSE IF(COALESCE(:TIPOLINEA,'') = 'TOTAL_TRASLADOSRETENCIONES') THEN
         BEGIN
             UPDATE CFDI
             SET
                TOTALTRASLADOS = :TOTALTRASLADOS,
                TOTALRETENCIONES = :TOTALRETENCIONES
                WHERE ID = :CFDIID;

         END
         ELSE IF(COALESCE(:TIPOLINEA,'') = 'COMPROBANTE_IVA' AND COALESCE(:TIPOCOMPROBANTE,'') <> 'T') THEN
         BEGIN

            INSERT INTO CFDI_IMP
            (   TIPOLINEA,
                BASEIMP,
                TIPOFACTOR,
                TASACUOTA,
                TASA,
                IMPUESTO,
                IMPORTE,
                CFDIID
            )
            VALUES
            (
                :TIPOLINEA,
                :BASEIMP,
                :TIPOFACTOR,
                :TASACUOTA,
                :TASA,
                :IMPUESTO,
                :IMPORTE,
                :CFDIID
            );




         END
         ELSE IF(COALESCE(:TIPOLINEA,'') = 'COMPROBANTE_IEPS' AND COALESCE(:TIPOCOMPROBANTE,'') <> 'T') THEN
         BEGIN
            
            INSERT INTO CFDI_IMP
            (   TIPOLINEA,
                BASEIMP,
                TIPOFACTOR,
                TASACUOTA,
                TASA,
                IMPUESTO,
                IMPORTE,
                CFDIID
            )
            VALUES
            (
                :TIPOLINEA,
                :BASEIMP,
                :TIPOFACTOR,
                :TASACUOTA,
                :TASA,
                :IMPUESTO,
                :IMPORTE,
                :CFDIID
            );
         END
         ELSE IF(COALESCE(:TIPOLINEA,'') = 'COMPROBANTE_IVARETENIDO' AND COALESCE(:TIPOCOMPROBANTE,'') <> 'T') THEN
         BEGIN
         
            INSERT INTO CFDI_IMP
            (   TIPOLINEA,
                BASEIMP,
                TIPOFACTOR,
                TASACUOTA,
                TASA,
                IMPUESTO,
                IMPORTE,
                CFDIID
            )
            VALUES
            (
                :TIPOLINEA,
                :BASEIMP,
                :TIPOFACTOR,
                :TASACUOTA,
                :TASA,
                :IMPUESTO,
                :IMPORTE,
                :CFDIID
            );

         END  
         ELSE IF(COALESCE(:TIPOLINEA,'') = 'COMPROBANTE_ISRRETENIDO' AND COALESCE(:TIPOCOMPROBANTE,'') <> 'T') THEN
         BEGIN
         
            INSERT INTO CFDI_IMP
            (   TIPOLINEA,
                BASEIMP,
                TIPOFACTOR,
                TASACUOTA,
                TASA,
                IMPUESTO,
                IMPORTE,
                CFDIID
            )
            VALUES
            (
                :TIPOLINEA,
                :BASEIMP,
                :TIPOFACTOR,
                :TASACUOTA,
                :TASA,
                :IMPUESTO,
                :IMPORTE,
                :CFDIID
            );
         END 
         ELSE IF(COALESCE(:TIPOLINEA,'') = 'DOCTORELACIONADO') THEN
         BEGIN    
            INSERT INTO CFDI_REL
            (
                TIPORELACION,
                UUID,
                CFDIID
            )
            VALUES
            (   
                :TIPORELACION,
                :UUID,
                :CFDIID

            );
         END





        END


        IF(COALESCE(:CARTAPORTEGUARDAR,'N') = 'S') THEN
        BEGIN
        
            FOR SELECT 
                ID ,
                TIPOLINEA ,
                PADRELINEA ,
                ORDENLINEA ,
                SUBORDEN ,
                TRANSPINTERNAC,
                ENTRADASALIDAMERC ,
                PAISORIGENDESTINO ,
                VIAENTRADASALIDA ,
                TOTALDISTREC ,
                TIPOUBICACION ,
                IDUBICACION ,
                RFCREMITENTEDESTINATARIO  ,
                NOMBREREMITENTEDESTINATARIO ,
                NUMREGIDTRIB   ,
                RESIDENCIAFISCAL ,
                NUMESTACION  ,
                NOMBREESTACION ,
                NAVEGACIONTRAFICO ,
                FECHAHORASALIDALLEGADA  ,
                TIPOESTACION ,
                DISTANCIARECORRIDA ,
                CALLE ,
                NUMEROEXTERIOR ,
                NUMEROINTERIOR,
                COLONIA    ,
                LOCALIDAD  ,
                REFERENCIA ,
                MUNICIPIO,
                ESTADO ,
                PAIS    ,
                CODIGOPOSTAL  ,
                PESOBRUTOTOTAL ,
                UNIDADPESO  ,
                PESONETOTOTAL ,
                NUMTOTALMERCANCIAS ,
                CARGOPORTASACION ,
                BIENESTRANSP ,
                CLAVESTCC ,
                DESCRIPCION ,
                CANTIDAD  ,
                CLAVEUNIDAD ,
                UNIDAD  ,
                DIMENSIONES ,
                MATERIALPELIGROSO ,
                CVEMATERIALPELIGROSO ,
                EMBALAJE  ,
                DESCRIPEMBALAJE,
                PESOENKG      ,
                VALORMERCANCIA ,
                MONEDA ,
                FRACCIONARANCELARIA ,
                UUIDCOMERCIOEXT ,
                UNIDADPESOMERC ,
                PESOBRUTO,
                PESONETO ,
                PESOTARA ,
                NUMPIEZAS ,
                IDORIGEN ,
                IDDESTINO ,
                CVESTRANSPORTE ,
                TIPOFIGURA ,
                RFCFIGURA  ,
                NUMLICENCIA ,
                NOMBREFIGURA  ,
                NUMREGIDTRIBFIGURA,
                RESIDENCIAFISCALFIGURA ,
                PARTETRANSPORTE,
                PERMSCT   ,
                NUMPERMISOSCT  ,
                CONFIGVEHICULAR  ,
                PLACAVM   ,
                ANIOMODELOVM   ,
                ASEGURARESPCIVIL ,
                POLIZARESPCIVIL ,
                ASEGURAMEDAMBIENTE ,
                POLIZAMEDAMBIENTE ,
                ASEGURACARGA ,
                POLIZACARGA,
                PRIMASEGURO ,
                SUBTIPOREM1,
                PLACA1  ,
                SUBTIPOREM2 ,
                PLACA2
                FROM
                CARTAPORTE_XML (
                    :DOCTOID)
                ORDER BY  ORDENLINEA, ID
                INTO
                :ID,
                :TIPOLINEA  ,
                :PADRELINEA ,
                :ORDENLINEA ,
                :SUBORDEN   ,
                :TRANSPINTERNAC ,
                :ENTRADASALIDAMERC ,
                :PAISORIGENDESTINO ,
                :VIAENTRADASALIDA ,
                :TOTALDISTREC   ,
                :TIPOUBICACION ,
                :IDUBICACION  ,
                :RFCREMITENTEDESTINATARIO   ,
                :NOMBREREMITENTEDESTINATARIO ,
                :NUMREGIDTRIB  ,
                :RESIDENCIAFISCAL  ,
                :NUMESTACION    ,
                :NOMBREESTACION  ,
                :NAVEGACIONTRAFICO ,
                :FECHAHORASALIDALLEGADA ,
                :TIPOESTACION ,
                :DISTANCIARECORRIDA  ,
                :CALLE     ,
                :NUMEROEXTERIOR ,
                :NUMEROINTERIOR ,
                :COLONIA ,
                :LOCALIDAD ,
                :REFERENCIA ,
                :MUNICIPIO ,
                :ESTADO  ,
                :PAIS ,
                :CODIGOPOSTAL ,
                :PESOBRUTOTOTAL ,
                :UNIDADPESO ,
                :PESONETOTOTAL ,
                :NUMTOTALMERCANCIAS,
                :CARGOPORTASACION,
                :BIENESTRANSP,
                :CLAVESTCC   ,
                :DESCRIPCION ,
                :CANTIDAD  ,
                :CLAVEUNIDAD  ,
                :UNIDAD ,
                :DIMENSIONES ,
                :MATERIALPELIGROSO  ,
                :CVEMATERIALPELIGROSO ,
                :EMBALAJE ,
                :DESCRIPEMBALAJE ,
                :PESOENKG ,
                :VALORMERCANCIA ,
                :MONEDA ,
                :FRACCIONARANCELARIA  ,
                :UUIDCOMERCIOEXT,
                :UNIDADPESOMERC ,
                :PESOBRUTO  ,
                :PESONETO ,
                :PESOTARA  ,
                :NUMPIEZAS ,
                :IDORIGEN  ,
                :IDDESTINO  ,
                :CVESTRANSPORTE ,
                :TIPOFIGURA ,
                :RFCFIGURA ,
                :NUMLICENCIA ,
                :NOMBREFIGURA ,
                :NUMREGIDTRIBFIGURA  ,
                :RESIDENCIAFISCALFIGURA  ,
                :PARTETRANSPORTE  ,
                :PERMSCT ,
                :NUMPERMISOSCT ,
                :CONFIGVEHICULAR  ,
                :PLACAVM  ,
                :ANIOMODELOVM  ,
                :ASEGURARESPCIVIL ,
                :POLIZARESPCIVIL  ,
                :ASEGURAMEDAMBIENTE  ,
                :POLIZAMEDAMBIENTE  ,
                :ASEGURACARGA   ,
                :POLIZACARGA,
                :PRIMASEGURO,
                :SUBTIPOREM1  ,
                :PLACA1  ,
                :SUBTIPOREM2 ,
                :PLACA2
            DO
            BEGIN

                IF(COALESCE(:TIPOLINEA,'') = 'CARTAPORTE') THEN
                BEGIN

                        
                    INSERT INTO CARTAPORTE
                    (
                        ACTIVO,
                        TRANSPINTERNAC,
                        ENTRADASALIDAMERC,
                        PAISORIGENDESTINO,
                        VIAENTRADASALIDA,
                        TOTALDISTREC ,
                        DOCTOID
                    )
                    VALUES
                    (   
                        'S',
                        :TRANSPINTERNAC,
                        :ENTRADASALIDAMERC,
                        :PAISORIGENDESTINO,
                        :VIAENTRADASALIDA,
                        :TOTALDISTREC ,
                        :DOCTOID

                    ) RETURNING ID INTO :CARTAPORTEID;

                    UPDATE GUIADETALLE
                    SET  CARTAPORTEID = :CARTAPORTEID
                    WHERE  DOCTOID = :DOCTOID;
                END

                
                IF(COALESCE(:TIPOLINEA,'') = 'CARTAPORTE_UBICACION') THEN
                BEGIN

                        
                    INSERT INTO CARTAPORTEUBICACION
                    (
                        CARTAPORTEID,
                        TIPOUBICACION ,
                        IDUBICACION ,
                        RFCREMITENTEDESTINATARIO ,
                        NOMBREREMITENTEDESTINATARIO ,
                        NUMREGIDTRIB ,
                        RESIDENCIAFISCAL ,
                        NUMESTACION ,
                        NOMBREESTACION ,
                        NAVEGACIONTRAFICO ,
                        FECHAHORASALIDALLEGADA ,
                        TIPOESTACION ,
                        DISTANCIARECORRIDA ,
                        CALLE ,
                        NUMEROEXTERIOR ,
                        NUMEROINTERIOR ,
                        COLONIA ,
                        LOCALIDAD ,
                        REFERENCIA ,
                        MUNICIPIO ,
                        ESTADO ,
                        PAIS ,
                        CODIGOPOSTAL

                    )
                    VALUES
                    (
                    :CARTAPORTEID,
                    :TIPOUBICACION ,
                    :IDUBICACION ,
                    :RFCREMITENTEDESTINATARIO ,
                    :NOMBREREMITENTEDESTINATARIO ,
                    :NUMREGIDTRIB ,
                    :RESIDENCIAFISCAL ,
                    :NUMESTACION ,
                    :NOMBREESTACION ,
                    :NAVEGACIONTRAFICO ,
                    :FECHAHORASALIDALLEGADA ,
                    :TIPOESTACION ,
                    :DISTANCIARECORRIDA ,
                    :CALLE ,
                    :NUMEROEXTERIOR ,
                    :NUMEROINTERIOR ,
                    :COLONIA ,
                    :LOCALIDAD ,
                    :REFERENCIA ,
                    :MUNICIPIO ,
                    :ESTADO ,
                    :PAIS ,
                    :CODIGOPOSTAL


                    ) ;
                END

                
                IF(COALESCE(:TIPOLINEA,'') = 'CARTAPORTE_MERCANCIA') THEN
                BEGIN

                        
                    INSERT INTO CARTAPORTEMERCANCIA
                    (
                        CARTAPORTEID,
                        BIENESTRANSP ,
                        CLAVESTCC ,
                        DESCRIPCION ,
                        CANTIDAD ,
                        CLAVEUNIDAD ,
                        UNIDAD ,
                        DIMENSIONES ,
                        MATERIALPELIGROSO ,
                        CVEMATERIALPELIGROSO ,
                        EMBALAJE ,
                        DESCRIPEMBALAJE ,
                        PESOENKG ,
                        VALORMERCANCIA ,
                        MONEDA ,
                        FRACCIONARANCELARIA ,
                        UUIDCOMERCIOEXT ,
                        UNIDADPESOMERC ,
                        PESOBRUTO ,
                        PESONETO ,
                        PESOTARA ,
                        NUMPIEZAS


                    )
                    VALUES
                    (
                    :CARTAPORTEID,
                    :BIENESTRANSP ,
                    :CLAVESTCC ,
                    :DESCRIPCION ,
                    :CANTIDAD ,
                    :CLAVEUNIDAD ,
                    :UNIDAD ,
                    :DIMENSIONES ,
                    :MATERIALPELIGROSO ,
                    :CVEMATERIALPELIGROSO ,
                    :EMBALAJE ,
                    :DESCRIPEMBALAJE ,
                    :PESOENKG ,
                    :VALORMERCANCIA ,
                    :MONEDA ,
                    :FRACCIONARANCELARIA ,
                    :UUIDCOMERCIOEXT ,
                    :UNIDADPESOMERC ,
                    :PESOBRUTO ,
                    :PESONETO ,
                    :PESOTARA ,
                    :NUMPIEZAS

                    ) ;
                END

                
                
                IF(COALESCE(:TIPOLINEA,'') = 'CARTAPORTE_TOTALMERCANCIAS') THEN
                BEGIN
                        
                    INSERT INTO CARTAPORTETOTALMERCANCIAS
                    (
                        CARTAPORTEID,
                        PESOBRUTOTOTAL,
                        UNIDADPESO ,
                        PESONETOTOTAL ,
                        NUMTOTALMERCANCIAS ,
                        CARGOPORTASACION
                    )
                    VALUES
                    (
                        :CARTAPORTEID, 
                        :PESOBRUTOTOTAL,
                        :UNIDADPESO ,
                        :PESONETOTOTAL ,
                        :NUMTOTALMERCANCIAS ,
                        :CARGOPORTASACION

                    ) ;
                END
                  
                IF(COALESCE(:TIPOLINEA,'') = 'CARTAPORTE_CANTTRANSP') THEN
                BEGIN
                        
                    INSERT INTO CARTAPORTECANTTRANSP
                    (
                        CARTAPORTEID,
                        CANTIDAD ,
                        IDORIGEN ,
                        IDDESTINO ,
                        CVESTRANSPORTE

                    )
                    VALUES
                    (
                        :CARTAPORTEID,
                        :CANTIDAD ,
                        :IDORIGEN ,
                        :IDDESTINO ,
                        :CVESTRANSPORTE
                    ) ;
                END  
                  
                IF(COALESCE(:TIPOLINEA,'') = 'CARTAPORTE_AUTOTRANSP') THEN
                BEGIN
                        
                    INSERT INTO CARTAPORTEAUTOTRANSP
                    (
                        CARTAPORTEID,
                        PERMSCT,
                        NUMPERMISOSCT,
                        CONFIGVEHICULAR,
                        PLACAVM,
                        ANIOMODELOVM,
                        ASEGURARESPCIVIL,
                        POLIZARESPCIVIL,
                        ASEGURAMEDAMBIENTE,
                        POLIZAMEDAMBIENTE,
                        ASEGURACARGA,
                        POLIZACARGA,
                        PRIMASEGURO,
                        SUBTIPOREM1,
                        PLACA1,
                        SUBTIPOREM2,
                        PLACA2

                    )
                    VALUES
                    (   
                    :CARTAPORTEID,
                    :PERMSCT,
                    :NUMPERMISOSCT,
                    :CONFIGVEHICULAR,
                    :PLACAVM,
                    :ANIOMODELOVM,
                    :ASEGURARESPCIVIL,
                    :POLIZARESPCIVIL,
                    :ASEGURAMEDAMBIENTE,
                    :POLIZAMEDAMBIENTE,
                    :ASEGURACARGA,
                    :POLIZACARGA,
                    :PRIMASEGURO,
                    :SUBTIPOREM1,
                    :PLACA1,
                    :SUBTIPOREM2,
                    :PLACA2

                    ) ;
                END


                
                IF(COALESCE(:TIPOLINEA,'') = 'CARTAPORTE_TRANSPTIPOFIGURA') THEN
                BEGIN
                        
                    INSERT INTO CARTAPORTETRANSPTIPOFIGURA
                    (
                        CARTAPORTEID,
                        TIPOFIGURA ,
                        RFCFIGURA ,
                        NUMLICENCIA ,
                        NOMBREFIGURA ,
                        NUMREGIDTRIBFIGURA ,
                        RESIDENCIAFISCALFIGURA ,
                        PARTETRANSPORTE ,
                        CALLE ,
                        NUMEROEXTERIOR ,
                        NUMEROINTERIOR ,
                        COLONIA ,
                        LOCALIDAD ,
                        REFERENCIA ,
                        MUNICIPIO ,
                        ESTADO ,
                        PAIS ,
                        CODIGOPOSTAL

                    )
                    VALUES
                    (   
                    :CARTAPORTEID,
                    :TIPOFIGURA ,
                    :RFCFIGURA ,
                    :NUMLICENCIA ,
                    :NOMBREFIGURA ,
                    :NUMREGIDTRIBFIGURA ,
                    :RESIDENCIAFISCALFIGURA ,
                    :PARTETRANSPORTE ,
                    :CALLE ,
                    :NUMEROEXTERIOR ,
                    :NUMEROINTERIOR ,
                    :COLONIA ,
                    :LOCALIDAD ,
                    :REFERENCIA ,
                    :MUNICIPIO ,
                    :ESTADO ,
                    :PAIS ,
                    :CODIGOPOSTAL


                    ) ;
                END



            END

        END


END