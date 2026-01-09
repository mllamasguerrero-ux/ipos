create or alter procedure FACTURAELECTRONICA_XML_IMP (
    DOCTOID D_FK,
    DESGLOSEIEPSPARENT D_BOOLCN_NULL,
    MOSTRARDESCUENTOPARENT D_BOOLCN_NULL)
returns (
    ID D_FK,
    TIPOLINEA D_NOMBRE_NULL,
    ORDENLINEA integer,
    IMPORTE D_IMPORTE,
    IMPUESTO D_STDTEXT_64,
    TASA D_PORCENTAJE,
    TASACUOTA D_STDTEXT_64,
    TIPOFACTOR D_STDTEXT_64,
    BASEIMP D_PRECIO,
    PADRELINEA integer)
as
declare variable TIPODOCTOID D_FK;
declare variable OMITIRVALES D_BOOLCN_NULL;
declare variable LC_IVA D_PRECIO;
declare variable LC_IEPS D_PRECIO;
declare variable LC_ISRRETENIDO D_PRECIO;
declare variable LC_IVARETENIDO D_PRECIO;
declare variable LC_SINVALE_IVA D_PRECIO;
declare variable LC_SINVALE_IEPS D_PRECIO;
declare variable LC_SINVALE_ISRRETENIDO D_PRECIO;
declare variable LC_SINVALE_IVARETENIDO D_PRECIO;
declare variable CONC_CONVALE_IVA D_PRECIO;
declare variable CONC_CONVALE_IEPS D_PRECIO;
declare variable CONC_CONVALE_ISRRETENIDO D_PRECIO;
declare variable CONC_CONVALE_IVARETENIDO D_PRECIO;
declare variable RESULTADOEXACTOIVA D_DECIMAL_EXACT;
declare variable RESULTADOEXACTOIVAANTERIOR D_DECIMAL_EXACT;
declare variable RESULTADOEXACTOIEPS D_DECIMAL_EXACT;
declare variable RESULTADOEXACTOIEPSANTERIOR D_DECIMAL_EXACT;
declare variable RESULTADOEXACTOIVARET D_DECIMAL_EXACT;
declare variable RESULTADOEXACTOIVARETANTERIOR D_DECIMAL_EXACT;
declare variable RESULTADOEXACTOISRRET D_DECIMAL_EXACT;
declare variable RESULTADOEXACTOISRRETANTERIOR D_DECIMAL_EXACT;
declare variable HAYDATOS D_BOOLCN;
declare variable CONC_IMPORTE D_IMPORTE;
declare variable CONC_BASEIMP D_PRECIO;
declare variable MOVTOID D_FK;
declare variable SUMADIF_IVA D_PRECIO;
declare variable SUMADIF_IEPS D_PRECIO;
declare variable SUMADIF_ISRRETENIDO D_PRECIO;
declare variable SUMADIF_IVARETENIDO D_PRECIO;
declare variable DIF D_DECIMAL_EXACT;
declare variable TOTALDIF_IVA D_PRECIO;
declare variable TOTALDIF_IEPS D_PRECIO;
declare variable TOTALDIF_ISRRETENIDO D_PRECIO;
declare variable TOTALDIF_IVARETENIDO D_PRECIO;
begin



  SELECT TIPODOCTOID, DOCTO.OMITIRVALES
   FROM DOCTO WHERE ID = :DOCTOID INTO :TIPODOCTOID, :OMITIRVALES;

      --SI ES CONSOLIDADO CON OMITIR VALES.. LOS TOTALES CON Y SIN VALES ESTAN INTERCAMBIADOS
   IF(COALESCE(:OMITIRVALES,'N') = 'S') THEN
   BEGIN
        
        SELECT TIPODOCTOID, DOCTO.OMITIRVALES,
            SINVALE_IVA , SINVALE_IEPS , SINVALE_ISR_RET,SINVALE_IVA_RET ,
            IVA, IEPS, ISRRETENIDO, IVARETENIDO
        FROM DOCTO WHERE ID = :DOCTOID INTO :TIPODOCTOID, :OMITIRVALES,
            :LC_IVA, :LC_IEPS, :LC_ISRRETENIDO, :LC_IVARETENIDO,
            :LC_SINVALE_IVA, :LC_SINVALE_IEPS, :LC_SINVALE_ISRRETENIDO, :LC_SINVALE_IVARETENIDO;


   END
   ELSE
   BEGIN
    
        SELECT TIPODOCTOID, DOCTO.OMITIRVALES,
            IVA, IEPS, ISRRETENIDO, IVARETENIDO,
            SINVALE_IVA, SINVALE_IEPS, SINVALE_ISR_RET,SINVALE_IVA_RET
        FROM DOCTO WHERE ID = :DOCTOID INTO :TIPODOCTOID, :OMITIRVALES,
            :LC_IVA, :LC_IEPS, :LC_ISRRETENIDO, :LC_IVARETENIDO,
            :LC_SINVALE_IVA, :LC_SINVALE_IEPS, :LC_SINVALE_ISRRETENIDO, :LC_SINVALE_IVARETENIDO;
   END

   TOTALDIF_IVA = COALESCE(:LC_IVA, 0) -  COALESCE(:LC_SINVALE_IVA,0);
   TOTALDIF_IEPS = COALESCE(:LC_IEPS, 0) -  COALESCE(:LC_SINVALE_IEPS,0);
   TOTALDIF_ISRRETENIDO = COALESCE(:LC_ISRRETENIDO, 0) -  COALESCE(:LC_SINVALE_ISRRETENIDO,0);
   TOTALDIF_IVARETENIDO = COALESCE(:LC_IVARETENIDO, 0) -  COALESCE(:LC_SINVALE_IVARETENIDO,0);



    IF(COALESCE(:OMITIRVALES,'N') = 'N') THEN
    BEGIN

        FOR SELECT                  ID,
                                    TIPOLINEA ,
                                    ORDENLINEA ,
                                    IMPORTE ,
                                    IMPUESTO,
                                    Tasa ,
                                    TasaCuota ,
                                    TipoFactor ,
                                    BASEIMP,
                                    PADRELINEA
                                    
          FROM
                                    FACTURAELECTRONICA_XML_CORE(:DOCTOID, :DESGLOSEIEPSPARENT, :MOSTRARDESCUENTOPARENT)
                                    WHERE TIPOLINEA IN ('CONCEPTO_ISRRETENIDO','CONCEPTO_IVARETENIDO', 'CONCEPTO_IVA', 'CONCEPTO_IEPS')
                                    INTO
                                        :ID,
                                        :TIPOLINEA ,
                                        :ORDENLINEA ,
                                        :IMPORTE ,
                                        :IMPUESTO,
                                        :Tasa ,
                                        :TasaCuota ,
                                        :TipoFactor ,
                                        :BaseImp,
                                        :PADRELINEA
          DO
          BEGIN
            HAYDATOS = 'S';
             SUSPEND;
          END


    END
    ELSE
    BEGIN



         SELECT  SUM(CASE WHEN FX.TIPOLINEA <> 'CONCEPTO_ISRRETENIDO' THEN 0.00 ELSE
                                    CAST(ROUND(FX.IMPORTE *  (CASE WHEN MOVTO.ISRRETENIDO > 0 THEN
                                                    ((COALESCE(MOVTO.ISRRETENIDO,0) - COALESCE(MOVTO.sinvale_ISR_RET,0))/ COALESCE(MOVTO.ISRRETENIDO,0))
                                                      ELSE 0.0
                                                    END),2) AS D_PRECIO)
                                     END) ISR_RETENIDO_DIF,
                 SUM(CASE WHEN FX.TIPOLINEA <> 'CONCEPTO_IVARETENIDO' THEN 0.00 ELSE
                                    CAST(ROUND(FX.IMPORTE *  (CASE WHEN MOVTO.IVARETENIDO > 0 THEN
                                                    ((COALESCE(MOVTO.IVARETENIDO,0) - COALESCE(MOVTO.sinvale_IVA_RET,0))/ COALESCE(MOVTO.IVARETENIDO,0))
                                                      ELSE 0.0
                                                    END),2) AS D_PRECIO)
                                     END) IVA_RETENIDO_DIF,
                 SUM(CASE WHEN FX.TIPOLINEA <> 'CONCEPTO_IVA' THEN 0.00 ELSE
                                    CAST(ROUND(FX.IMPORTE *  (CASE WHEN MOVTO.IVA > 0 THEN
                                                    ((COALESCE(MOVTO.IVA,0) - COALESCE(MOVTO.sinvale_IVA,0))/ COALESCE(MOVTO.IVA,0))
                                                      ELSE 0.0
                                                    END), 2) AS D_decimal_exact)
                                     END) IVA_DIF, 
                 SUM(CASE WHEN FX.TIPOLINEA <> 'CONCEPTO_IEPS' THEN 0.00 ELSE
                                    CAST(ROUND(FX.IMPORTE *  (CASE WHEN MOVTO.IEPS > 0 THEN
                                                    ((COALESCE(MOVTO.IEPS,0) - COALESCE(MOVTO.sinvale_IEPS,0))/ COALESCE(MOVTO.IEPS,0))
                                                      ELSE 0.0
                                                    END), 2) AS D_decimal_exact)
                                     END)  IEPS_DIF
                                    
          FROM
                                    FACTURAELECTRONICA_XML_CORE(:DOCTOID, :DESGLOSEIEPSPARENT, :MOSTRARDESCUENTOPARENT) FX
                                    LEFT JOIN MOVTO ON MOVTO.ID =  FX.MOVTOID
                                    WHERE TIPOLINEA IN ('CONCEPTO_ISRRETENIDO','CONCEPTO_IVARETENIDO', 'CONCEPTO_IVA', 'CONCEPTO_IEPS') 
                                    INTO
                                        :SUMADIF_ISRRETENIDO,
                                        :SUMADIF_IVARETENIDO,
                                        :SUMADIF_IVA,
                                        :SUMADIF_IEPS;



        RESULTADOEXACTOIVA = 0; 
        RESULTADOEXACTOIVAANTERIOR = 0;
        RESULTADOEXACTOIEPS = 0; 
        RESULTADOEXACTOIEPSANTERIOR = 0;
        RESULTADOEXACTOIVARET = 0;   
        RESULTADOEXACTOIVARETANTERIOR = 0;
        RESULTADOEXACTOISRRET = 0;   
        RESULTADOEXACTOISRRETANTERIOR = 0;

        FOR SELECT                  FX.ID,
                                    FX.TIPOLINEA ,
                                    FX.ORDENLINEA ,
                                    FX.IMPORTE ,
                                    FX.IMPUESTO,
                                    FX.Tasa ,
                                    FX.TasaCuota ,
                                    FX.TipoFactor ,
                                    FX.BASEIMP,
                                    FX.PADRELINEA ,
                                    FX.MOVTOID,
                                    CAST(ROUND( COALESCE(FX.IMPORTE,0) *
                                                    (
                                                        CASE
                                                            WHEN TIPOLINEA = 'CONCEPTO_ISRRETENIDO'  THEN
                                                                CASE WHEN MOVTO.ISRRETENIDO > 0 THEN
                                                                    ((COALESCE(MOVTO.ISRRETENIDO,0) - COALESCE(MOVTO.SINVALE_ISR_RET,0))/ COALESCE(MOVTO.ISRRETENIDO,0))
                                                                ELSE 0.0
                                                                END 
                                                            WHEN TIPOLINEA = 'CONCEPTO_IVARETENIDO'  THEN
                                                                CASE WHEN MOVTO.IVARETENIDO > 0 THEN
                                                                    ((COALESCE(MOVTO.IVARETENIDO,0) - COALESCE(MOVTO.SINVALE_IVA_RET,0))/ COALESCE(MOVTO.IVARETENIDO,0))
                                                                ELSE 0.0
                                                                END
                                                            WHEN TIPOLINEA = 'CONCEPTO_IVA'  THEN
                                                                CASE WHEN MOVTO.IVA > 0 THEN
                                                                    ((COALESCE(MOVTO.IVA,0) - COALESCE(MOVTO.SINVALE_IVA,0))/ COALESCE(MOVTO.IVA,0))
                                                                ELSE 0.0
                                                                END
                                                            WHEN TIPOLINEA = 'CONCEPTO_IEPS'  THEN
                                                                CASE WHEN MOVTO.IEPS > 0 THEN
                                                                    ((COALESCE(MOVTO.IEPS,0) - COALESCE(MOVTO.SINVALE_IEPS,0))/ COALESCE(MOVTO.Ieps,0))
                                                                ELSE 0.0
                                                                END
                                                            ELSE
                                                               0.0
                                                        END
                                                        ) , 6)


                                                     AS D_DECIMAL_EXACT)  DIF
                                    
          FROM
                                    FACTURAELECTRONICA_XML_CORE(:DOCTOID, :DESGLOSEIEPSPARENT, :MOSTRARDESCUENTOPARENT) FX 
                                    LEFT JOIN MOVTO ON MOVTO.ID =  FX.MOVTOID
                                    WHERE TIPOLINEA IN ('CONCEPTO_ISRRETENIDO','CONCEPTO_IVARETENIDO', 'CONCEPTO_IVA', 'CONCEPTO_IEPS') 
                                    INTO
                                        :ID,
                                        :TIPOLINEA ,
                                        :ORDENLINEA ,
                                        :CONC_IMPORTE ,
                                        :IMPUESTO,
                                        :Tasa ,
                                        :TasaCuota ,
                                        :TipoFactor ,
                                        :CONC_BaseImp,
                                        :PADRELINEA  ,
                                        :MOVTOID ,
                                        :DIF
          DO
          BEGIN


                IF(COALESCE(:TIPOLINEA ,'') = 'CONCEPTO_IVA') THEN
                BEGIN
                    RESULTADOEXACTOIVAANTERIOR = COALESCE(:RESULTADOEXACTOIVA, 0);
                    IF( COALESCE(:SUMADIF_IVA,0) > 0 AND COALESCE(:DIF, 0) > 0 ) THEN
                    BEGIN
                        RESULTADOEXACTOIVA =  ROUND( 0.005 + COALESCE(:RESULTADOEXACTOIVA,0.00) + CAST((    ROUND((0.5 + (COALESCE(:DIF,0.00) / COALESCE(:SUMADIF_IVA,0.00))),1)  * COALESCE(:TOTALDIF_IVA,0.00)) AS D_DECIMAL_EXACT),2);
                     END
                    IF(COALESCE(:RESULTADOEXACTOIVA,0) >  COALESCE(:TOTALDIF_IVA,0)) THEN
                    BEGIN
                        RESULTADOEXACTOIVA = COALESCE(:TOTALDIF_IVA,0);
                    END

                    IF((COALESCE(:CONC_IMPORTE,0) -  (COALESCE(:RESULTADOEXACTOIVA, 0) - COALESCE(:RESULTADOEXACTOIVAANTERIOR, 0))) < 0 ) THEN
                    BEGIN
                        RESULTADOEXACTOIVA =  COALESCE(:RESULTADOEXACTOIVAANTERIOR, 0) + COALESCE(:CONC_IMPORTE,0);
                    END

                    IMPORTE =  COALESCE(:CONC_IMPORTE,0) -  (COALESCE(:RESULTADOEXACTOIVA, 0) - COALESCE(:RESULTADOEXACTOIVAANTERIOR, 0));

                    IF(COALESCE(:Tasa,0) = 0) THEN
                    BEGIN
                        IF(COALESCE(:LC_IVA,0) > 0) THEN
                        BEGIN
                            BASEIMP = Round(:CONC_BASEIMP * Round((:LC_SINVALE_IVA / :LC_IVA),2),2);
                        END
                        ELSE
                        BEGIN
                            BASEIMP = :CONC_BASEIMP;
                        END
                    END
                    ELSE
                    BEGIN
                            BASEIMP =  :IMPORTE / (:TASA / 100.00);
                    END
                END
                ELSE IF(COALESCE(:TIPOLINEA ,'') = 'CONCEPTO_IEPS') THEN
                BEGIN
                    RESULTADOEXACTOIEPSANTERIOR = COALESCE(:RESULTADOEXACTOIEPS, 0);
                    IF( COALESCE(:SUMADIF_IEPS,0) > 0 AND COALESCE(:DIF, 0) > 0 ) THEN
                    BEGIN
                        RESULTADOEXACTOIEPS =  ROUND(0.005 +  COALESCE(:RESULTADOEXACTOIEPS,0) + CAST((    ROUND((0.5 + (COALESCE(:DIF,0.00) / COALESCE(:SUMADIF_IEPS,0.00))),1) * COALESCE(:TOTALDIF_IEPS,0.00)) AS D_DECIMAL_EXACT),2);
                    END
                     
                    IF(COALESCE(:RESULTADOEXACTOIEPS,0) >  COALESCE(:TOTALDIF_IEPS,0)) THEN
                    BEGIN
                        RESULTADOEXACTOIEPS = COALESCE(:TOTALDIF_IEPS,0);
                    END

                    IF((COALESCE(:CONC_IMPORTE,0) -  (COALESCE(:RESULTADOEXACTOIEPS, 0) - COALESCE(:RESULTADOEXACTOIEPSANTERIOR, 0))) < 0 ) THEN
                    BEGIN
                        RESULTADOEXACTOIEPS =  COALESCE(:RESULTADOEXACTOIEPSANTERIOR, 0) + COALESCE(:CONC_IMPORTE,0);
                    END

                    IMPORTE =  COALESCE(:CONC_IMPORTE,0) -  (Round(:RESULTADOEXACTOIEPS, 2) - Round(:RESULTADOEXACTOIEPSANTERIOR, 2));

                    IF(COALESCE(:Tasa,0) = 0) THEN
                    BEGIN
                        IF(COALESCE(:LC_IEPS,0) > 0) THEN
                        BEGIN
                            BASEIMP = Round(:CONC_BASEIMP * Round((:LC_SINVALE_IEPS / :LC_IEPS),2),2);
                        END
                        ELSE
                        BEGIN
                            BASEIMP = :CONC_BASEIMP;
                        END
                    END
                    ELSE
                    BEGIN
                            BASEIMP =  :IMPORTE / (:TASA / 100.00);
                    END
                END
                ELSE IF(COALESCE(:TIPOLINEA ,'') = 'CONCEPTO_IVARETENIDO') THEN
                BEGIN
                    RESULTADOEXACTOIVARETANTERIOR = COALESCE(:RESULTADOEXACTOIVARET, 0);
                    IF( COALESCE(:SUMADIF_IVARETENIDO,0) > 0 AND COALESCE(:DIF, 0) > 0 ) THEN
                    BEGIN
                        RESULTADOEXACTOIVARET =  ROUND(0.005 +  COALESCE(:RESULTADOEXACTOIVARET,0) + CAST(( ROUND((0.5 + (COALESCE(:DIF,0.00) / COALESCE(:SUMADIF_IVARETENIDO,0.00))),1) * COALESCE(:TOTALDIF_IVARETENIDO,0.00)) AS D_DECIMAL_EXACT),2);
                    END
                    
                    IF(COALESCE(:RESULTADOEXACTOIVARET,0) >  COALESCE(:TOTALDIF_IVARETENIDO,0)) THEN
                    BEGIN
                        RESULTADOEXACTOIVARET = COALESCE(:TOTALDIF_IVARETENIDO,0);
                    END

                    IF((COALESCE(:CONC_IMPORTE,0) -  (COALESCE(:RESULTADOEXACTOIVARET, 0) - COALESCE(:RESULTADOEXACTOIVARETANTERIOR, 0))) < 0 ) THEN
                    BEGIN
                        RESULTADOEXACTOIVARET =  COALESCE(:RESULTADOEXACTOIVARETANTERIOR, 0) + COALESCE(:CONC_IMPORTE,0);
                    END

                    IMPORTE =  COALESCE(:CONC_IMPORTE,0) -  (Round(:RESULTADOEXACTOIVARET, 2) - Round(:RESULTADOEXACTOIVARETANTERIOR, 2));



                    IF(COALESCE(:Tasa,0) = 0) THEN
                    BEGIN
                        IF(COALESCE(:LC_IVARETENIDO,0) > 0) THEN
                        BEGIN
                            BASEIMP = Round(:CONC_BASEIMP * Round((:LC_SINVALE_IVARETENIDO / :LC_IEPS),2),2);
                        END
                        ELSE
                        BEGIN
                            BASEIMP = :CONC_BASEIMP;
                        END
                    END
                    ELSE
                    BEGIN
                            BASEIMP =  :IMPORTE / (:TASA / 100.00);
                    END
                END
                ELSE IF(COALESCE(:TIPOLINEA ,'') = 'CONCEPTO_ISRRETENIDO') THEN
                BEGIN
                    RESULTADOEXACTOISRRETANTERIOR = COALESCE(:RESULTADOEXACTOISRRET, 0);
                    IF( COALESCE(:SUMADIF_ISRRETENIDO,0) > 0 AND COALESCE(:DIF, 0) > 0 ) THEN
                    BEGIN
                        RESULTADOEXACTOISRRET =  ROUND(0.005 + COALESCE(:RESULTADOEXACTOISRRET,0) + CAST(( ROUND((0.5 + (COALESCE(:DIF,0.00) / COALESCE(:SUMADIF_ISRRETENIDO,0.00))),1) * COALESCE(:TOTALDIF_ISRRETENIDO,0.00)) AS D_DECIMAL_EXACT), 2);
                    END
                    
                    IF(COALESCE(:RESULTADOEXACTOISRRET,0) >  COALESCE(:TOTALDIF_ISRRETENIDO,0)) THEN
                    BEGIN
                        RESULTADOEXACTOISRRET = COALESCE(:TOTALDIF_ISRRETENIDO,0);
                    END

                    IF((COALESCE(:CONC_IMPORTE,0) -  (COALESCE(:RESULTADOEXACTOISRRET, 0) - COALESCE(:RESULTADOEXACTOISRRETANTERIOR, 0))) < 0 ) THEN
                    BEGIN
                        RESULTADOEXACTOISRRET =  COALESCE(:RESULTADOEXACTOISRRETANTERIOR, 0) + COALESCE(:CONC_IMPORTE,0);
                    END

                    IMPORTE =  COALESCE(:CONC_IMPORTE,0) -  (Round(:RESULTADOEXACTOISRRET, 2) - Round(:RESULTADOEXACTOISRRETANTERIOR, 2));

                    IF(COALESCE(:Tasa,0) = 0) THEN
                    BEGIN
                        IF(COALESCE(:LC_ISRRETENIDO,0) > 0) THEN
                        BEGIN
                            BASEIMP = Round(:CONC_BASEIMP * Round((:LC_SINVALE_ISRRETENIDO / :LC_IEPS),2),2);
                        END
                        ELSE
                        BEGIN
                            BASEIMP = :CONC_BASEIMP;
                        END
                    END
                    ELSE
                    BEGIN
                            BASEIMP =  :IMPORTE / (:TASA / 100.00);
                    END
                END
            
                IF(COALESCE(:BASEIMP, 0) > 0 ) THEN
                BEGIN 
                    HAYDATOS = 'S';
                    SUSPEND;
                END

          END


    END

        

   IF(COALESCE(:HAYDATOS,'N') = 'N') THEN
   BEGIN
            SUSPEND;
   END

end