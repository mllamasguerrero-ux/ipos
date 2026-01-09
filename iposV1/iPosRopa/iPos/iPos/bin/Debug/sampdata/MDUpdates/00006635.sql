create or alter procedure RECIBOELECTRONICO_P_GENERAR_33 (
    PAGOID D_FK,
    VENDEDORID D_FK)
returns (
    DOCTOID D_FK,
    ERRORCODE D_ERRORCODE)
as
declare variable ESTATUSDOCTOID D_FK;
declare variable MOVTOID D_FK;
declare variable ALMACENID D_FK;
declare variable SUCURSALID D_FK;
declare variable PERSONAID D_FK;
declare variable TIPODOCTOID D_FK;
declare variable PRODUCTOID D_FK;
declare variable LOTE D_LOTE;
declare variable FECHAVENCE D_FECHAVENCE;
declare variable CANTIDAD D_CANTIDAD;
declare variable PRECIO D_PRECIO;
declare variable COSTO D_COSTO;
declare variable REFERENCIA D_REFERENCIA;
declare variable REFERENCIAS varchar(255);
declare variable SERIE varchar(31);
declare variable FOLIO integer;
declare variable ALMACENTID D_FK;
declare variable SUCURSALTID D_FK;
declare variable TIPODIFERENCIAINVENTARIOID D_FK;
declare variable CANTIDADDEFACTURA D_CANTIDAD;
declare variable CANTIDADDEREMISION D_CANTIDAD;
declare variable CANTIDADDEINDEFINIDO D_CANTIDAD;
declare variable NEWMOVTOID D_FK;
declare variable PRODUCTOSINSUFICIENTES D_CANTIDAD;
declare variable DESCRIPCION1 D_STDTEXT_64;
declare variable DESCRIPCION2 D_STDTEXT_64;
declare variable DESCRIPCION3 D_STDTEXT_64;
declare variable SUBTOTAL D_IMPORTE;
declare variable TOTAL D_IMPORTE;
declare variable IVA D_IMPORTE;
declare variable IEPS D_IMPORTE;
declare variable IMPUESTO D_IMPORTE;
declare variable SUBTOTALORIGEN D_IMPORTE;
declare variable DOCTOIDORIGEN D_FK;
declare variable TOTALORIGEN D_IMPORTE;
declare variable IVAORIGEN D_IMPORTE;
declare variable IEPSORIGEN D_IMPORTE;
declare variable IMPUESTOORIGEN D_IMPORTE;
declare variable CORTEID D_FK;
declare variable HAYCORTEACTIVO D_BOOLCN;
declare variable FOLIOSAT D_DOCTOFOLIO;
declare variable SERIESAT D_DOCTOSERIE;
declare variable DOCTOITEMID D_FK;
declare variable TIPOAPLICACION D_FK;
declare variable FACTOR D_PRECIO;
declare variable CUENTAPARCIALIDADES integer;
declare variable FECHAHORA D_TIMESTAMP_NULLE;
declare variable FORMAPAGOCLAVE D_CLAVE_NULL;
declare variable REFERENCIABANCARIA D_STDTEXT_LIGHT;
declare variable CUENTAPAGOCREDITO D_STDTEXT_LIGHT;
declare variable BANCONOMBRE D_NOMBRE_NULL;
declare variable PAGOSATID D_FK;
declare variable TIMBRADOUUID D_STDTEXT_64;
declare variable IMPSALDOANT D_IMPORTE;
declare variable IMPSALDOINSOLUTO D_IMPORTE;
declare variable SAT_METODOPAGOCLAVE D_CLAVE_NULL;
declare variable PAGODOCTOSATID D_FK;
declare variable ABONOSSAT D_IMPORTE;
declare variable CUENTADOCTOSPAGO integer;
declare variable DOCTOPAGOID D_FK;
declare variable TOTALDETALLE D_IMPORTE;
declare variable TOTALORIGENDETALLE D_IMPORTE;
declare variable ABONOSSATDETALLE D_IMPORTE;
declare variable SAT_BANCARIZADO D_STDTEXT_LIGHT;
declare variable RFCEMISORCTAORD D_STDTEXT_SHORT;
declare variable NOMBANCOORDEXT D_NOMBRE_NULL;
declare variable CTAORDENANTE D_STDTEXT_SHORT;
declare variable RFCEMISORCTABEN D_STDTEXT_SHORT;
declare variable CTABENEFICIARIO D_STDTEXT_SHORT;
declare variable RFCBANCODELQUEHIZOPAGO D_STDTEXT_SHORT;
declare variable NOMBREBANCODELQUEHIZOPAGO D_NOMBRE_NULL;
declare variable CUENTABANCOEMPRESAID D_FK;
declare variable APLICADO D_BOOLCS;
declare variable IDDOCUMENTO D_STDTEXT_64;
declare variable MONEDADR D_STDTEXT_64;
declare variable TIPOCAMBIODR D_STDTEXT_64;
declare variable METODODEPAGODR D_STDTEXT_64;
declare variable NUMPARCIALIDAD D_STDTEXT_64;
declare variable IMPPAGADO D_IMPORTE;
declare variable TIPOIMPUESTO D_NOMBRE_NULL;
declare variable IMPORTE D_IMPORTE;
declare variable IVADOCTOPROP D_IMPORTE;
declare variable IVADOCTOAJUSTE D_IMPORTE;
declare variable IEPSDOCTOPROP D_IMPORTE;
declare variable IEPSDOCTOAJUSTE D_IMPORTE;
declare variable ISRRETDOCTOPROP D_IMPORTE;
declare variable ISRRETDOCTOAJUSTE D_IMPORTE;
declare variable IVARETDOCTOPROP D_IMPORTE;
declare variable IVARETDOCTOAJUSTE D_IMPORTE;
declare variable DOCTOPAGADOID D_FK;
declare variable IMPUESTO_TEXT D_STDTEXT_64;
declare variable TASA D_PORCENTAJE;
declare variable BASEIMP D_PRECIO;
declare variable TIPOFACTOR D_STDTEXT_64;
declare variable TASACUOTA D_STDTEXT_64;
declare variable FACTOR_IMPUESTO D_COSTO;
declare variable CUENTAIVAS integer;
declare variable CUENTAIEPS integer;
declare variable OBJETOIMP D_STDTEXT_64;
BEGIN


        
   SELECT HAYCORTEACTIVO, CORTEID,ERRORCODE
   FROM HAY_CORTE_ACTIVO(:VENDEDORID)
   INTO :HAYCORTEACTIVO, :CORTEID, :ERRORCODE;

   IF (:ERRORCODE > 0) THEN
   BEGIN
      DOCTOID = 0;
      SUSPEND;
      EXIT;
   END





  SELECT PARAMETRO.sucursalid, SAT_METODOPAGO.SAT_CLAVE
  FROM PARAMETRO LEFT JOIN SAT_METODOPAGO ON SAT_METODOPAGO.ID = PARAMETRO.sat_metodopagoid
  INTO :SUCURSALID, :SAT_METODOPAGOCLAVE;







  SELECT  importe, RECIBOELECTRONICOID,
    CASE WHEN COALESCE(FORMAPAGOSAT.CLAVE, '') = '02' THEN  -- SI ES CHEQUE ENTONCES TOMAR LA FECHA DE APLICADO
            CAST(PAGO.fechaaplicado AS D_TIMESTAMP_NULLE)  
         WHEN COALESCE(FORMAPAGOSAT.CLAVE, '') = '03' THEN  -- SI ES TRANSFERENCIA ENTONCES TOMAR LA FECHA DE RECEPCION
            CAST(PAGO.fecharecepcion AS D_TIMESTAMP_NULLE)
        ELSE
            FECHAHORA
    END FECHAHORA  ,
  FORMAPAGOSAT.CLAVE ,
  PAGO.referenciabancaria , PAGO.cuentapagocredito, BANCOS.nombre BANCONOMBRE, FORMAPAGOSAT.sat_bancarizado,
  BANCOS.rfc , PAGO.CUENTABANCOEMPRESAID , BANCOS.NOMBRE ,
  PAGO.aplicado
  FROM PAGO
  LEFT JOIN FORMAPAGOSAT ON PAGO.formapagosatid = FORMAPAGOSAT.ID
  LEFT JOIN BANCOS ON BANCOS.ID = PAGO.banco
  WHERE PAGO.ID = :PAGOID INTO  :TOTAL, :DOCTOID, :FECHAHORA, :FORMAPAGOCLAVE,
  :REFERENCIABANCARIA, :CUENTAPAGOCREDITO, :BANCONOMBRE, :SAT_BANCARIZADO,
  :RFCBANCODELQUEHIZOPAGO, :CUENTABANCOEMPRESAID, :NOMBREBANCODELQUEHIZOPAGO,
  :APLICADO;

  --LOS CHEQUES DEBEN ESTAR APLICADOS
  IF(COALESCE(:APLICADO,'S') <> 'S' AND COALESCE(:FORMAPAGOCLAVE,'') = '02') THEN
  BEGIN
    ERRORCODE = 5025;
    SUSPEND;
    EXIT;
  END

   
   IF ( COALESCE(:TOTAL,0) = 0 ) THEN
   BEGIN
      ERRORCODE = 11001;
      SUSPEND;
      EXIT;
   END

   -- si ya se hizo el recibo electronico
   IF(COALESCE(:DOCTOID,0) <> 0) THEN
   BEGIN  
      ERRORCODE = 11004;
      SUSPEND;
      EXIT;
   END




    SELECT SUM(COALESCE(DOCTO.SUBTOTAL,0.0)), SUM(COALESCE(DOCTO.TOTAL,0.0)), SUM(COALESCE(DOCTO.IVA,0)), SUM(COALESCE(DOCTO.IEPS,0)), SUM(COALESCE(DOCTO.IMPUESTO,0)),
        MAX(COALESCE(DOCTO.PERSONAID,0)), MIN(COALESCE(DOCTO.FOLIOSAT,0)), MIN(COALESCE(DOCTO.SERIESAT,'')), MAX(COALESCE(DOCTO.TIMBRADOUUID,''))
    FROM PAGO INNER JOIN  DOCTOPAGO ON DOCTOPAGO.PAGOID = PAGO.ID
        INNER JOIN  DOCTO ON DOCTOPAGO.DOCTOID = DOCTO.ID
    WHERE PAGO.ID = :PAGOID
    INTO  :SUBTOTALORIGEN, :TOTALORIGEN, :IVAORIGEN, :IEPSORIGEN, :IMPUESTOORIGEN, :PERSONAID, :FOLIOSAT, :SERIESAT, :TIMBRADOUUID;



            
   IF(COALESCE(:FOLIOSAT,0) = 0) THEN
   BEGIN
     ERRORCODE = 11002;
     SUSPEND;
     EXIT;
   END

   IF(COALESCE(:TOTALORIGEN,0) = 0) THEN
   BEGIN
     ERRORCODE = 11003;
     SUSPEND;
     EXIT;
   END
               
    FACTOR =  (COALESCE(:TOTAL,0) / COALESCE(:TOTALORIGEN,0));
    IVA =  ROUND( (COALESCE(:TOTAL,0) / COALESCE(:TOTALORIGEN,0))   * COALESCE(:IVAORIGEN,0),2) ;
    IEPS =  ROUND(  (COALESCE(:TOTAL,0) / COALESCE(:TOTALORIGEN,0)) * COALESCE(:IEPSORIGEN,0),2);
    IMPUESTO =  :IVA + :IEPS;
    SUBTOTAL = :TOTAL - :IMPUESTO;


    TIPODOCTOID = 205;

   -- Agrega el DOCTO.
   INSERT INTO DOCTO
    (ALMACENID, SUCURSALID, TIPODOCTOID, ESTATUSDOCTOID, ESTATUSDOCTOPAGOID,
    PERSONAID, CAJEROID, VENDEDORID, CORTEID, FECHA, FECHAHORA, SERIE, FOLIO,
    PLAZO, VENCE, IMPORTE, DESCUENTO, SUBTOTAL, IVA, TOTAL, CARGO, ABONO, SALDO,
    CAJAID, REFERENCIA,
    REFERENCIAS, SUCURSALTID, ALMACENTID, PROMOCION, IEPS, IMPUESTO, DOCTOREFID,
    FECHAINI, FECHAFIN, ESFACTURAELECTRONICA)
   VALUES
   (
    1, :SUCURSALID, :TIPODOCTOID, 0, 0,
    :PERSONAID, 0, :VENDEDORID, :CORTEID, CURRENT_DATE, CURRENT_TIMESTAMP, NULL, NULL,
    NULL, CURRENT_DATE, :SUBTOTAL, 0, :SUBTOTAL, :IVA, :TOTAL, :TOTAL, :TOTAL, 0,
    1,  CAST((:CUENTAPARCIALIDADES + 1 ) AS VARCHAR(10)) || ' DE ' || CAST((:CUENTAPARCIALIDADES + 1 ) AS VARCHAR(10)),
    'RECIBO ELECTRONICO', NULL, NULL, 'N', :IEPS, :IMPUESTO , NULL,NULL, NULL, 'S'
      )
    RETURNING ID INTO :DOCTOID;



      
    UPDATE PAGO SET RECIBOELECTRONICOID = :DOCTOID
    WHERE ID = :PAGOID;

    
    RFCEMISORCTAORD = '';
    NOMBANCOORDEXT = '';
    CTAORDENANTE = '';
    RFCEMISORCTABEN = '';
    CTABENEFICIARIO  = '';

    IF(COALESCE(:sat_bancarizado, 'N') like 'S%' AND
      (COALESCE(:RFCBANCODELQUEHIZOPAGO,'') <> '' ) AND
       (COALESCE(:CUENTABANCOEMPRESAID,0) <> 0)) THEN
    BEGIN

        --IF(COALESCE(:RFCBANCODELQUEHIZOPAGO,'') = '' )  THEN
        --BEGIN
            --ERRORCODE = 5023;
            --SUSPEND;
            --EXIT;
        --END

        
        --IF(COALESCE(:CUENTABANCOEMPRESAID,0) = 0) THEN
        --BEGIN
        --   ERRORCODE = 5022;
        --    SUSPEND;
        --    EXIT;
        --END

        IF(COALESCE(:CUENTAPAGOCREDITO,'') = '') THEN
        BEGIN
                
            ERRORCODE = 5024;
            SUSPEND;
            EXIT;
        END


        SELECT CUENTABANCO.rfc, CUENTABANCO.nocuenta
        FROM CUENTABANCO
        WHERE ID =  COALESCE(:CUENTABANCOEMPRESAID,0)
        INTO :RFCEMISORCTABEN, :CTABENEFICIARIO;

    
        RFCEMISORCTAORD = :RFCBANCODELQUEHIZOPAGO;
        NOMBANCOORDEXT = COALESCE(:NOMBREBANCODELQUEHIZOPAGO, '');
        CTAORDENANTE = :CUENTAPAGOCREDITO;
        RFCEMISORCTABEN = :RFCEMISORCTABEN;
        CTABENEFICIARIO  = :CTABENEFICIARIO;

    END
    ELSE
    BEGIN
       BANCONOMBRE = '';
    END


    
    INSERT INTO PAGOSAT (
        DOCTOSATID, FECHAPAGO , FORMADEPAGOP, MONEDAP,
        TIPOCAMBIOP, MONTO ,NUMOPERACION ,RFCEMISORCTAORD,
        NOMBANCOORDEXT, CTAORDENANTE, RFCEMISORCTABEN, CTABENEFICIARIO ,
        TIPOCADPAGO , CERTPAGO, CADPAGO, SELLOPAGO, PAGOID
           )
        VALUES ( :DOCTOID, :FECHAHORA, :FORMAPAGOCLAVE, 'MXN',
                 1, :TOTAL,:REFERENCIABANCARIA ,:RFCEMISORCTAORD,
                 :NOMBANCOORDEXT, :CTAORDENANTE , :RFCEMISORCTABEN, :CTABENEFICIARIO,
                 '','','', '', :PAGOID)
        RETURNING ID INTO :PAGOSATID;



     
    UPDATE DOCTO SET PAGOSAT = :PAGOSATID WHERE ID = :DOCTOID;
    UPDATE PAGO SET PAGO.pagosatid = :PAGOSATID WHERE ID =  :PAGOID;



    FOR SELECT DOCTOPAGO.ID, DOCTOPAGO.IMPORTE, DOCTOPAGO.DOCTOID, DOCTO.TIMBRADOUUID ,
                DOCTO.SERIESAT, DOCTO.FOLIOSAT
    FROM DOCTOPAGO
        INNER JOIN  DOCTO ON DOCTOPAGO.DOCTOID = DOCTO.ID
        WHERE PAGOID = :PAGOID
        INTO :DOCTOPAGOID , :TOTALDETALLE, :DOCTOIDORIGEN, :TIMBRADOUUID  ,
            :SERIESAT, :FOLIOSAT
        DO
        BEGIN


        

            SELECT TOTAL FROM DOCTO WHERE ID = :DOCTOIDORIGEN
            INTO   :TOTALORIGENDETALLE;


            SELECT COUNT(*) CUENTAFACTURADO,
                SUM(COALESCE(DOCTOPAGO.IMPORTE,0) *
                                 (CASE WHEN ((TIPOPAGOID = 1 AND FORMAPAGOID IN (1,2,3,5,6,14,15,16,17,18,19,20,21)) )  THEN 1
                                  when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND FORMAPAGOID NOT IN (4,6,7,18,19))  ) THEN -1
                                  else 0 end)
                    ) IMPORTEFACTURADO
            FROM DOCTOPAGO
            WHERE DOCTOID = :DOCTOIDORIGEN AND
                (COALESCE(RECIBOELECTRONICOID,0) <> 0  OR COALESCE(FORMAPAGOID,0) IN (6,7))
            INTO :CUENTAPARCIALIDADES, :ABONOSSATDETALLE;

            IMPSALDOANT =     COALESCE(:TOTALORIGENDETALLE, 0) - COALESCE(:ABONOSSATDETALLE, 0);
            IMPSALDOINSOLUTO = COALESCE(:IMPSALDOANT,0) - COALESCE(:TOTALDETALLE,0) ;


            CUENTAPARCIALIDADES = COALESCE(:CUENTAPARCIALIDADES,0);




            INSERT INTO PAGODOCTOSAT(
                DOCTOPAGOID  ,PAGOSATID    ,IDDOCUMENTO  ,SERIE        ,
                FOLIO        ,MONEDADR     ,TIPOCAMBIODR ,METODODEPAGODR,
                NUMPARCIALIDAD,IMPSALDOANT  ,IMPPAGADO    ,IMPSALDOINSOLUTO )
            VALUES (
                :DOCTOPAGOID ,:PAGOSATID  ,:TIMBRADOUUID, :SERIESAT,
                :FOLIOSAT, 'MXN', '', coalesce(:SAT_METODOPAGOCLAVE,'PPD'),
                :CUENTAPARCIALIDADES + 1, :IMPSALDOANT,:TOTALDETALLE, :IMPSALDOINSOLUTO)
            RETURNING ID INTO :PAGODOCTOSATID;


      
            UPDATE DOCTOPAGO SET RECIBOELECTRONICOID = :DOCTOID, PAGODOCTOSATID = :PAGODOCTOSATID
            WHERE  id  = :DOCTOPAGOID;
    END


    
    FOR SELECT
           PDS.IDDOCUMENTO,PDS.SERIE,PDS.FOLIO,
           PDS.MONEDADR,PDS.TipoCambioDR, PDS.MetodoDePagoDR,
           PDS.NumParcialidad,PDS.ImpSaldoAnt,PDS.ImpPagado,
           PDS.ImpSaldoInsoluto ,
           D.ID AS DOCTOPAGADOID, PDS.ID PAGODOCTOSATID ,
           case when coalesce(d.total,0) <> 0 then  cast(round(d.iva * cast(round((coalesce(PDS.ImpPagado,0.0) / d.total),4) as d_costo),2) as d_importe) else 0.00 end IVADOCTOPROP,
           case when coalesce(d.total,0) <> 0 then  cast(round(d.ieps * cast(round((coalesce(PDS.ImpPagado,0.0) / d.total),4) as d_costo),2) as d_importe) else 0.00 end IEPSDOCTOPROP,
           case when coalesce(d.total,0) <> 0 then  cast(round(d.isrretenido * cast(round((coalesce(PDS.ImpPagado,0.0) / d.total),4) as d_costo),2) as d_importe) else 0.00 end ISRRETDOCTOPROP,
           case when coalesce(d.total,0) <> 0 then  cast(round(d.ivaretenido * cast(round((coalesce(PDS.ImpPagado,0.0) / d.total),4) as d_costo),2) as d_importe) else 0.00 end IVARETDOCTOPROP,
           case when coalesce(d.total,0) <> 0 then  cast(round((coalesce(PDS.ImpPagado,0.0) / d.total),4) as d_costo) else 0.00 end FACTOR
         FROM PAGODOCTOSAT PDS
         LEFT JOIN DOCTOPAGO PD ON PDS.doctopagoid = PD.ID
         LEFT JOIN DOCTO D ON D.id = COALESCE(PD.doctoid , PD.doctosalidaid)
          WHERE PDS.PAGOSATID = :PAGOSATID
                                INTO
                                  :IDDOCUMENTO,:SERIE,:FOLIO,
                                  :MONEDADR, :TipoCambioDR, :MetodoDePagoDR,
                                  :NumParcialidad, :ImpSaldoAnt, :ImpPagado,
                                  :ImpSaldoInsoluto,
                                  :DOCTOPAGADOID, :PAGODOCTOSATID,
                                  :IVADOCTOPROP ,
                                  :IEPSDOCTOPROP ,
                                  :ISRRETDOCTOPROP ,
                                  :IVARETDOCTOPROP ,
                                  :FACTOR_IMPUESTO
                                  DO
           BEGIN


                                    SELECT
                                        COALESCE(:ISRRETDOCTOPROP, 0.00) - SUM(CASE WHEN TIPOLINEA = 'CONCEPTO_ISRRETENIDO' THEN  cast(round(IMPORTE * :FACTOR_IMPUESTO,2) as d_importe)  ELSE 0 END) ISRRETDOCTOAJUSTE,
                                        COALESCE(:IVARETDOCTOPROP, 0.00) -  SUM(CASE WHEN TIPOLINEA = 'CONCEPTO_IVARETENIDO' THEN cast(round(IMPORTE * :FACTOR_IMPUESTO,2) as d_importe) ELSE 0 END) IVARETDOCTOAJUSTE,
                                        COALESCE(:IVADOCTOPROP, 0.00) -  SUM(CASE WHEN TIPOLINEA = 'CONCEPTO_IVA' THEN cast(round(IMPORTE * :FACTOR_IMPUESTO,2) as d_importe) ELSE 0 END) IVADOCTOAJUSTE,
                                        COALESCE(:IEPSDOCTOPROP, 0.00) -  SUM(CASE WHEN TIPOLINEA = 'CONCEPTO_IEPS' THEN cast(round(IMPORTE * :FACTOR_IMPUESTO,2) as d_importe) ELSE 0 END) IEPSDOCTOAJUSTE
                                    FROM
                                        FACTURAELECTRONICA_XML_CORE(:DOCTOPAGADOID, NULL, NULL)
                                    WHERE TIPOLINEA IN ('CONCEPTO_ISRRETENIDO','CONCEPTO_IVARETENIDO', 'CONCEPTO_IVA', 'CONCEPTO_IEPS')
                                     INTO :ISRRETDOCTOAJUSTE, :IVARETDOCTOAJUSTE, :IVADOCTOAJUSTE , :IEPSDOCTOAJUSTE;


                                       
                                    FOR SELECT TIPOLINEA,
                                             cast(round(IMPORTE * :FACTOR,2) as d_importe) IMPORTE ,
                                            IMPUESTO, Tasa , TasaCuota , TipoFactor
                                        FROM
                                            FACTURAELECTRONICA_XML_CORE(:DOCTOPAGADOID, NULL, NULL)
                                        WHERE TIPOLINEA IN ('CONCEPTO_ISRRETENIDO','CONCEPTO_IVARETENIDO', 'CONCEPTO_IVA', 'CONCEPTO_IEPS')
                                        ORDER BY TIPOLINEA , IMPORTE DESC
                                        INTO
                                            :TIPOIMPUESTO,
                                            :IMPORTE ,
                                            :IMPUESTO_TEXT, :Tasa , :TasaCuota ,:TipoFactor
                                    DO
                                    BEGIN

                                         IF(COALESCE(:TIPOIMPUESTO,'') = 'CONCEPTO_IVA') THEN
                                         BEGIN
                                            IF(COALESCE(:IMPORTE,0.00) + COALESCE(:IVADOCTOAJUSTE , 0) > 0) THEN
                                            BEGIN
                                                IMPORTE =  COALESCE(:IMPORTE,0.00) + COALESCE(:IVADOCTOAJUSTE , 0);
                                                IVADOCTOAJUSTE = 0;
                                            END
                                            ELSE
                                            BEGIN     
                                                IVADOCTOAJUSTE =  COALESCE(:IVADOCTOAJUSTE , 0) + COALESCE(:IMPORTE,0.00);
                                                IMPORTE = 0;
                                            END

                                         END
                                         ELSE IF(COALESCE(:TIPOIMPUESTO,'') = 'CONCEPTO_IEPS') THEN
                                            IF(COALESCE(:IMPORTE,0.00) + COALESCE(:IEPSDOCTOAJUSTE , 0) > 0) THEN
                                            BEGIN
                                                IMPORTE =  COALESCE(:IMPORTE,0.00) + COALESCE(:IEPSDOCTOAJUSTE , 0);
                                                IEPSDOCTOAJUSTE = 0;
                                            END
                                            ELSE
                                            BEGIN     
                                                IEPSDOCTOAJUSTE =  COALESCE(:IEPSDOCTOAJUSTE , 0) + COALESCE(:IMPORTE,0.00);
                                                IMPORTE = 0;
                                            END
                                         ELSE IF(COALESCE(:TIPOIMPUESTO,'') = 'CONCEPTO_IVARETENIDO') THEN 
                                            IF(COALESCE(:IMPORTE,0.00) + COALESCE(:IVARETDOCTOAJUSTE , 0) > 0) THEN
                                            BEGIN
                                                IMPORTE =  COALESCE(:IMPORTE,0.00) + COALESCE(:IVARETDOCTOAJUSTE , 0);
                                                IVARETDOCTOAJUSTE = 0;
                                            END
                                            ELSE
                                            BEGIN     
                                                IVARETDOCTOAJUSTE =  COALESCE(:IVARETDOCTOAJUSTE , 0) + COALESCE(:IMPORTE,0.00);
                                                IMPORTE = 0;
                                            END
                                         ELSE IF(COALESCE(:TIPOIMPUESTO,'') = 'CONCEPTO_ISRRETENIDO') THEN 
                                            IF(COALESCE(:IMPORTE,0.00) + COALESCE(:ISRRETDOCTOAJUSTE , 0) > 0) THEN
                                            BEGIN
                                                IMPORTE =  COALESCE(:IMPORTE,0.00) + COALESCE(:ISRRETDOCTOAJUSTE , 0);
                                                ISRRETDOCTOAJUSTE = 0;
                                            END
                                            ELSE
                                            BEGIN     
                                                ISRRETDOCTOAJUSTE =  COALESCE(:ISRRETDOCTOAJUSTE , 0) + COALESCE(:IMPORTE,0.00);
                                                IMPORTE = 0;
                                            END

                                        BASEIMP = CAST(ROUND(CASE WHEN  COALESCE(:TASA,0) <> 0 THEN (COALESCE(:IMPORTE,0.00) * 100) / COALESCE(:Tasa,0.00) ELSE 0.00 END, 2) AS D_IMPORTE);

                                        INSERT INTO PAGODOCTOSAT_IMP (
                                                BASEIMP  ,TIPOFACTOR  ,TASACUOTA ,TASA  ,IMPUESTO  ,IMPORTE ,PAGODOCTOSATID, TIPOIMPUESTO)
                                        VALUES (    
                                                :BASEIMP  ,:TIPOFACTOR  ,:TASACUOTA ,:TASA  ,:IMPUESTO_TEXT  ,:IMPORTE ,:PAGODOCTOSATID, :TIPOIMPUESTO);


                                    END

                                   
                                    SELECT SUM( CASE WHEN IMPUESTO = '002' THEN 1 ELSE 0 END) CUENTAIVAS,
                                            SUM( CASE WHEN IMPUESTO = '003' THEN 1 ELSE 0 END) CUENTAIEPS
                                    FROM PAGODOCTOSAT_IMP I
                                    WHERE I.PAGODOCTOSATID = :PAGODOCTOSATID
                                    INTO :CUENTAIVAS, :CUENTAIEPS;
                                    
                                    IF(COALESCE(:CUENTAIVAS,0) = 0 AND COALESCE(:CUENTAIEPS,0) = 0) THEN
                                    BEGIN
                                        OBJETOIMP = '01';
                                    END
                                    ELSE IF(COALESCE(:CUENTAIVAS,0) = 0 AND COALESCE(:CUENTAIEPS,0) > 0) THEN
                                    BEGIN
                                        OBJETOIMP = '03';
                                    END
                                    ELSE
                                    BEGIN
                                        OBJETOIMP = '02';
                                    END

                                    UPDATE PAGODOCTOSAT
                                    SET   OBJETOIMPDR = :OBJETOIMP
                                    WHERE ID = :PAGODOCTOSATID;
    END

        






   -- Completa el documento.
   SELECT ERRORCODE
   FROM DOCTO_SAVE (:DOCTOID)
   INTO :ERRORCODE;

   
   IF(COALESCE(:ERRORCODE,0) <> 0) THEN
   BEGIN    
      SUSPEND;
      EXIT;
   END

   ERRORCODE = 0;
   SUSPEND;


  /* WHEN ANY DO
    BEGIN
        ERRORCODE = 1009;
        SUSPEND;
    END    */
END