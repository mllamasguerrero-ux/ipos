create or alter procedure INGRESUC_QUERY
(
    FECHAINICIO D_FECHA,
    FECHAFIN D_FECHA
)
returns (
    SUCURSAL VARCHAR(31) ,
    F_FACTURA D_FECHA,
    SUMA D_PRECIO,
    IEPS8 D_PRECIO,
    IEPS20 D_PRECIO,
    CERVE D_PRECIO,
    REFES D_PRECIO,
    CERVE26 D_PRECIO,
    IEPS26 D_PRECIO,
    ALOCH D_PRECIO,
    OTROS D_PRECIO,
    IEPS30 D_PRECIO,
    IEPS50 D_PRECIO,
    ALCOH53 D_PRECIO,
    IEPS53 D_PRECIO,
    IVA D_PRECIO,
    TOTAL  D_PRECIO,
    EST D_CLAVE_NULL,
    DESC_ D_NOMBRE_NULL)
as

declare variable  ESTEQUILENO VARCHAR(1);
declare variable  ESFACTURA VARCHAR(1);
declare variable  ESCREDITO VARCHAR(1);
declare variable  TIPOREG VARCHAR(1);



declare variable FECHAACTUAL D_FECHA ;

           
declare variable FECHAMINIMA D_FECHA ;


declare variable BUFF_SUMA D_PRECIO;
declare variable BUFF_IEPS8 D_PRECIO;
declare variable BUFF_IEPS20 D_PRECIO;
declare variable BUFF_CERVE D_PRECIO;
declare variable BUFF_REFES D_PRECIO;
declare variable BUFF_CERVE26 D_PRECIO;
declare variable BUFF_IEPS26 D_PRECIO;
declare variable BUFF_ALOCH D_PRECIO;
declare variable BUFF_OTROS D_PRECIO;
declare variable BUFF_IEPS30 D_PRECIO;
declare variable BUFF_IEPS50 D_PRECIO;
declare variable BUFF_ALCOH53 D_PRECIO;
declare variable BUFF_IEPS53 D_PRECIO;
declare variable BUFF_IVA D_PRECIO;
declare variable BUFF_TOTAL  D_PRECIO;


BEGIN

    sucursal = 'DANZANTE';




    FECHAACTUAL = :FECHAINICIO;
    FECHAMINIMA =  CAST('1990.01.01' AS DATE);

    while ( :FECHAACTUAL <= :FECHAFIN ) do
    BEGIN


        FOR
        SELECT  ESTEQUILENO, ESFACTURA, ESCREDITO/*, TIPOREG*/ FROM INGRESUC_TIPOLINEA
        GROUP BY  ESTEQUILENO, ESFACTURA, ESCREDITO
        INTO  :ESTEQUILENO, :ESFACTURA, :ESCREDITO/*, :TIPOREG*/
        DO
        BEGIN


        
            SUMA = 0;
            IEPS8 = 0;
            IEPS20 = 0;
            CERVE = 0;
            REFES = 0;
            CERVE26 = 0;
            IEPS26 = 0;
            ALOCH = 0;
            OTROS = 0;
            IEPS30 = 0;
            IEPS50 = 0;
            ALCOH53 = 0;
            IEPS53 = 0;
            IVA = 0;
            TOTAL  = 0;


                      
            BUFF_SUMA = 0;
            BUFF_IEPS8 = 0;
            BUFF_IEPS20 = 0;
            BUFF_CERVE = 0;
            BUFF_REFES = 0;
            BUFF_CERVE26 = 0;
            BUFF_IEPS26 = 0;
            BUFF_ALOCH = 0;
            BUFF_OTROS = 0;
            BUFF_IEPS30 = 0;
            BUFF_IEPS50 = 0;
            BUFF_ALCOH53 = 0;
            BUFF_IEPS53 = 0;
            BUFF_IVA = 0;
            BUFF_TOTAL  = 0;


            SELECT CLAVE, DESCRIPCION FROM  INGRESUC_TIPOLINEA
            WHERE ESTEQUILENO = :ESTEQUILENO AND  ESFACTURA = :ESFACTURA AND ESCREDITO = :ESCREDITO AND
                  TIPOREG = 'V'
                INTO :EST, :DESC_;

            select
                :FECHAACTUAL F_FACTURA,
                SUM(COALESCE(MOVTO.SUBTOTAL,0)) SUMA,
                SUM( CASE WHEN movto.tasaieps = 8  THEN COALESCE(MOVTO.IEPS,0) ELSE 0 END) IEPS8,  
                SUM( CASE WHEN movto.tasaieps = 20  THEN COALESCE(MOVTO.IEPS,0) ELSE 0 END) IEPS20,
                0.00 CERVE,
                0.00 REFES,                         
                SUM( CASE WHEN movto.tasaieps = 26.5 AND coalesce(linea.clave ,'') in ('015','016')  THEN COALESCE(MOVTO.IEPS,0) ELSE 0 END) CERVE26,
                SUM( CASE WHEN movto.tasaieps = 26.5 and coalesce(linea.clave ,'') not in ('015','016') THEN COALESCE(MOVTO.IEPS,0) ELSE 0 END) IEPS26,
                0.00 ALCOH,
                0.00 OTROS,
                SUM( CASE WHEN movto.tasaieps = 30  THEN COALESCE(MOVTO.IEPS,0) ELSE 0 END) IEPS30,
                SUM( CASE WHEN movto.tasaieps = 50  THEN COALESCE(MOVTO.IEPS,0) ELSE 0 END) IEPS50,
                0.00 ALCOH53,
                SUM( CASE WHEN movto.tasaieps = 53  THEN COALESCE(MOVTO.IEPS,0) ELSE 0 END) IEPS53,
                SUM(COALESCE(MOVTO.IVA,0)) IVA,
                --SUM( COALESCE(MOVTO.TOTAL,0)) TOTAL
                SUM(COALESCE(MOVTO.SUBTOTAL,0) + COALESCE(MOVTO.IEPS,0) + COALESCE(MOVTO.IVA,0)) TOTAL

                        from docto
                        inner join movto on movto.doctoid = docto.id
                        left join plazo on plazo.id = docto.plazoid 
                        left join producto on movto.productoid = producto.id
                        left join linea on linea.id = producto.lineaid
                        --left join (
                        --            select max(doctopago.fecha) fecha, doctopago.doctoid
                        --            from doctopago  where doctopago.formapagoid not in (4)
                        --            group by doctopago.doctoid
                        --        )  ultimopago on ultimopago.doctoid = docto.id
                        where docto.fecha = :FECHAACTUAL and
                         docto.tipodoctoid in (21) and docto.estatusdoctoid in (1)
                        and coalesce(docto.esfacturaelectronica,'N') = :ESFACTURA--:esfact
                        and :ESTEQUILENO =  CASE WHEN coalesce(plazo.clave, '') = 'T' THEN 'S' ELSE 'N' END
                        and
                            --:ESCREDITO = (CASE WHEN (( abs(coalesce(docto.saldo,0.00)) <= 0.01 and ( coalesce(ultimopago.fecha,:fechaminima) = docto.fecha ))) THEN 'N' ELSE 'S' END )
                            :ESCREDITO =  CASE WHEN (
                                                        coalesce(docto.hatenidocredito,'N') = 'S' or
                                                        ((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N' )
                                            ) THEN 'S' ELSE 'N' END
                        --y no es traslado remision
                        and not (((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N' ))
                
                INTO
                    :F_FACTURA ,
                    :SUMA ,
                    :IEPS8 ,
                    :IEPS20 ,
                    :CERVE ,
                    :REFES ,
                    :CERVE26 ,
                    :IEPS26 ,
                    :ALOCH ,
                    :OTROS ,
                    :IEPS30 ,
                    :IEPS50 ,
                    :ALCOH53 ,
                    :IEPS53 ,
                    :IVA ,
                    :TOTAL;



                    
                    SUMA = COALESCE(:SUMA,0);
                    IEPS8 = COALESCE(:IEPS8,0);
                    IEPS20 = COALESCE(:IEPS20,0);
                    CERVE = COALESCE(:CERVE,0);
                    REFES = COALESCE(:REFES,0);
                    CERVE26 = COALESCE(:CERVE26,0);
                    IEPS26 = COALESCE(:IEPS26,0);
                    ALOCH = COALESCE(:ALOCH,0);
                    OTROS = COALESCE(:OTROS,0);
                    IEPS30 = COALESCE(:IEPS30,0);
                    IEPS50 =  COALESCE(:IEPS50,0);
                    ALCOH53 = COALESCE(:ALCOH53,0);
                    IEPS53 = COALESCE(:IEPS53,0);
                    IVA = COALESCE(:IVA,0);
                    TOTAL  =  COALESCE(:TOTAL,0);

                    
                    IF(--(:EST IN ('DRF','TRF')) AND
                        (:FECHAACTUAL = :FECHAINICIO or
                        :SUMA > 0 or
                        :IEPS8 > 0 or
                        :IEPS20 > 0 or
                        :CERVE > 0 or
                        :REFES > 0 or
                        :CERVE26 > 0 or
                        :IEPS26 > 0 or
                        :ALOCH > 0 or
                        :OTROS > 0 or
                        :IEPS30 > 0 or
                        :IEPS50 > 0 or
                        :ALCOH53 > 0 or
                        :IEPS53 > 0 or
                        :IVA > 0 or
                        :TOTAL > 0 )  ) THEN
                    BEGIN    
                        SUSPEND;
                    END


                    BUFF_SUMA = COALESCE(:SUMA,0);
                    BUFF_IEPS8 = COALESCE(:IEPS8,0);
                    BUFF_IEPS20 = COALESCE(:IEPS20,0);
                    BUFF_CERVE = COALESCE(:CERVE,0);
                    BUFF_REFES = COALESCE(:REFES,0);
                    BUFF_CERVE26 = COALESCE(:CERVE26,0);
                    BUFF_IEPS26 = COALESCE(:IEPS26,0);
                    BUFF_ALOCH = COALESCE(:ALOCH,0);
                    BUFF_OTROS = COALESCE(:OTROS,0);
                    BUFF_IEPS30 = COALESCE(:IEPS30,0);
                    BUFF_IEPS50 =  COALESCE(:IEPS50,0);
                    BUFF_ALCOH53 = COALESCE(:ALCOH53,0);
                    BUFF_IEPS53 = COALESCE(:IEPS53,0);
                    BUFF_IVA = COALESCE(:IVA,0);
                    BUFF_TOTAL  =  COALESCE(:TOTAL,0);

                                    
        
                    SUMA = 0;
                    IEPS8 = 0;
                    IEPS20 = 0;
                    CERVE = 0;
                    REFES = 0;
                    CERVE26 = 0;
                    IEPS26 = 0;
                    ALOCH = 0;
                    OTROS = 0;
                    IEPS30 = 0;
                    IEPS50 = 0;
                    ALCOH53 = 0;
                    IEPS53 = 0;
                    IVA = 0;
                    TOTAL  = 0;


                 
            SELECT CLAVE, DESCRIPCION FROM  INGRESUC_TIPOLINEA
            WHERE
                  ESTEQUILENO = :ESTEQUILENO AND  ESFACTURA = :ESFACTURA AND ESCREDITO = :ESCREDITO AND
                  TIPOREG = 'D'
                INTO :EST, :DESC_;


                    
            select
                :FECHAACTUAL F_FACTURA,
                SUM(COALESCE(MOVTO.SUBTOTAL,0)) SUMA,
                SUM( CASE WHEN movto.tasaieps = 8  THEN COALESCE(MOVTO.IEPS,0) ELSE 0 END) IEPS8,  
                SUM( CASE WHEN movto.tasaieps = 20  THEN COALESCE(MOVTO.IEPS,0) ELSE 0 END) IEPS20,
                0.00 CERVE,
                0.00 REFES,                         
                SUM( CASE WHEN movto.tasaieps = 26.5 AND coalesce(linea.clave ,'') in ('015','016')  THEN COALESCE(MOVTO.IEPS,0) ELSE 0 END) CERVE26,
                SUM( CASE WHEN movto.tasaieps = 26.5 and coalesce(linea.clave ,'') not in ('015','016') THEN COALESCE(MOVTO.IEPS,0) ELSE 0 END) IEPS26,
                0.00 ALCOH,
                0.00 OTROS,
                SUM( CASE WHEN movto.tasaieps = 30  THEN COALESCE(MOVTO.IEPS,0) ELSE 0 END) IEPS30,
                SUM( CASE WHEN movto.tasaieps = 50  THEN COALESCE(MOVTO.IEPS,0) ELSE 0 END) IEPS50,
                0.00 ALCOH53,
                SUM( CASE WHEN movto.tasaieps = 53  THEN COALESCE(MOVTO.IEPS,0) ELSE 0 END) IEPS53,
                SUM(COALESCE(MOVTO.IVA,0)) IVA,
                --SUM( COALESCE(MOVTO.TOTAL,0)) TOTAL 
                SUM(COALESCE(MOVTO.SUBTOTAL,0) + COALESCE(MOVTO.IEPS,0) + COALESCE(MOVTO.IVA,0)) TOTAL

                        from docto    
                        left join docto doctoventa on  doctoventa.tipodoctoid = 21 and doctoventa.id = docto.doctorefid and extract(month from docto.fecha) = extract(month from doctoventa.fecha)
                        inner join movto on movto.doctoid = docto.id
                        left join plazo on plazo.id = doctoventa.plazoid
                        left join producto on movto.productoid = producto.id
                        left join linea on linea.id = producto.lineaid
                        left join (
                                    
                                    select max(doctopago.fecha) fecha, doctopago.doctoid
                                    from doctopago  where doctopago.formapagoid = 1
                                    group by doctopago.doctoid
                                )  ultimopago on ultimopago.doctoid = docto.id
                        where

                        COALESCE(CASE WHEN (:ESFACTURA = 'N'   AND :ESCREDITO = 'S') THEN DOCTOVENTA.FECHA ELSE DOCTO.FECHA END, :FECHAMINIMA) =  :FECHAACTUAL

                         AND docto.tipodoctoid in (22) and docto.estatusdoctoid in (1)

                        and (coalesce(docto.esfacturaelectronica,'N') = :ESFACTURA) --:esfact

                        and :ESTEQUILENO =  CASE WHEN coalesce(plazo.clave, '') = 'T' THEN 'S' ELSE 'N' END
                        and
                            --:ESCREDITO = (CASE WHEN (( abs(coalesce(docto.saldo,0.00)) <= 0.01 and ( coalesce(ultimopago.fecha,:fechaminima) = docto.fecha ))) THEN 'N' ELSE 'S' END )   
                            :ESCREDITO =  CASE WHEN (
                                                        coalesce(docto.hatenidocredito,'N') = 'S' or
                                                        ((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N' )
                                            ) THEN 'S' ELSE 'N' END
                                            
                        --y no es traslado remision
                        and not (((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N' ))

                        --esta condicion si no la ubico
                            and (coalesce(ultimopago.fecha,:fechaminima) > :fechaminima or :ESFACTURA = 'N'   )
                

                INTO
                    :F_FACTURA ,
                    :SUMA ,
                    :IEPS8 ,
                    :IEPS20 ,
                    :CERVE ,
                    :REFES ,
                    :CERVE26 ,
                    :IEPS26 ,
                    :ALOCH ,
                    :OTROS ,
                    :IEPS30 ,
                    :IEPS50 ,
                    :ALCOH53 ,
                    :IEPS53 ,
                    :IVA ,
                    :TOTAL;

                    
                    
                    SUMA = COALESCE(:SUMA,0);
                    IEPS8 = COALESCE(:IEPS8,0);
                    IEPS20 = COALESCE(:IEPS20,0);
                    CERVE = COALESCE(:CERVE,0);
                    REFES = COALESCE(:REFES,0);
                    CERVE26 = COALESCE(:CERVE26,0);
                    IEPS26 = COALESCE(:IEPS26,0);
                    ALOCH = COALESCE(:ALOCH,0);
                    OTROS = COALESCE(:OTROS,0);
                    IEPS30 = COALESCE(:IEPS30,0);
                    IEPS50 =  COALESCE(:IEPS50,0);
                    ALCOH53 = COALESCE(:ALCOH53,0);
                    IEPS53 = COALESCE(:IEPS53,0);
                    IVA = COALESCE(:IVA,0);
                    TOTAL  =  COALESCE(:TOTAL,0);

                    
                    IF(--(:EST IN ('DRF','TRF')) AND
                        (:FECHAACTUAL = :FECHAINICIO or
                        :SUMA > 0 or
                        :IEPS8 > 0 or
                        :IEPS20 > 0 or
                        :CERVE > 0 or
                        :REFES > 0 or
                        :CERVE26 > 0 or
                        :IEPS26 > 0 or
                        :ALOCH > 0 or
                        :OTROS > 0 or
                        :IEPS30 > 0 or
                        :IEPS50 > 0 or
                        :ALCOH53 > 0 or
                        :IEPS53 > 0 or
                        :IVA > 0 or
                        :TOTAL > 0 )  ) THEN
                    BEGIN    
                        SUSPEND;
                    END

                    
                SELECT CLAVE, DESCRIPCION FROM  INGRESUC_TIPOLINEA
                WHERE
                  ESTEQUILENO = :ESTEQUILENO AND  ESFACTURA = :ESFACTURA AND ESCREDITO = :ESCREDITO AND
                  TIPOREG = 'T'
                INTO :EST, :DESC_;

                 
                    SUMA = COALESCE(:BUFF_SUMA,0) - COALESCE(:SUMA,0);
                    IEPS8 = COALESCE(:BUFF_IEPS8,0) - COALESCE(:IEPS8,0);
                    IEPS20 = COALESCE(:BUFF_IEPS20,0) - COALESCE(:IEPS20,0);
                    CERVE = COALESCE(:BUFF_CERVE,0) - COALESCE(:CERVE,0);
                    REFES = COALESCE(:BUFF_REFES,0) - COALESCE(:REFES,0);
                    CERVE26 = COALESCE(:BUFF_CERVE26,0) - COALESCE(:CERVE26,0);
                    IEPS26 = COALESCE(:BUFF_IEPS26,0) - COALESCE(:IEPS26,0);
                    ALOCH = COALESCE(:BUFF_ALOCH,0) - COALESCE(:ALOCH,0);
                    OTROS = COALESCE(:BUFF_OTROS,0) - COALESCE(:OTROS,0);
                    IEPS30 = COALESCE(:BUFF_IEPS30,0) - COALESCE(:IEPS30,0);
                    IEPS50 =  COALESCE(:BUFF_IEPS50,0) - COALESCE(:IEPS50,0);
                    ALCOH53 = COALESCE(:BUFF_ALCOH53,0) - COALESCE(:ALCOH53,0);
                    IEPS53 = COALESCE(:BUFF_IEPS53,0) - COALESCE(:IEPS53,0);
                    IVA = COALESCE(:BUFF_IVA,0) - COALESCE(:IVA,0);
                    TOTAL  =  COALESCE(:BUFF_TOTAL,0) - COALESCE(:TOTAL,0);

                    
                    IF(--(:EST IN ('DRF','TRF')) AND
                         (:FECHAACTUAL = :FECHAINICIO or
                        :SUMA > 0 or
                        :IEPS8 > 0 or
                        :IEPS20 > 0 or
                        :CERVE > 0 or
                        :REFES > 0 or
                        :CERVE26 > 0 or
                        :IEPS26 > 0 or
                        :ALOCH > 0 or
                        :OTROS > 0 or
                        :IEPS30 > 0 or
                        :IEPS50 > 0 or
                        :ALCOH53 > 0 or
                        :IEPS53 > 0 or
                        :IVA > 0 or
                        :TOTAL > 0 )  ) THEN
                    BEGIN    
                        SUSPEND;
                    END

            END
    
            FECHAACTUAL = DATEADD(1 DAY TO :FECHAACTUAL);
    END


END
