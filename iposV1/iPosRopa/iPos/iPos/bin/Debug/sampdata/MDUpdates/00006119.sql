create or alter procedure POLIZALINEAV2_DET_PARTE5 (
    NUMEROINICIAL integer,
    CUADREINICIAL D_PRECIO,
    TIPOENTRADAINICIAL D_DIAS,
    NUMCUENTAINICIAL D_NOMBRE_NULL,
    LEYENDAINICIAL D_STDTEXT_SHORT,
    TIPOLINEAPOLIZAID D_FK,
    SUMARIZADO D_BOOLCN,
    MANEJATASA D_BOOLCN,
    MANEJAFORMAPAGO D_BOOLCN,
    MANEJAESFACT D_BOOLCN,
    ORDENTIPOLINEA integer,
    CLAVECUENTA D_CLAVE,
    FORMAPAGOSATID D_FK,
    ESFACT D_BOOLCN_I,
    TASA D_PORCENTAJE,
    TIPOLINEAPOLIZAESPECIALID D_FK,
    ORDENCUENTA integer,
    MOSTRARDETALLE D_BOOLCN,
    FECHA D_FECHA)
returns (
    NUMERO integer,
    NUMCUENTA D_NOMBRE_NULL,
    LEYENDA D_STDTEXT_SHORT,
    TIPOENTRADA D_DIAS,
    MONTO D_PRECIO,
    CUADRE D_PRECIO,
    NUMLINEA integer,
    DTL_ORDEN integer,
    HDR_CONCEPTO1 varchar(255),
    HDR_CONCEPTO2 varchar(255),
    DTL_NIV1_CONCEPTO varchar(255),
    DTL_NIV1_NOMBREID1 varchar(255),
    DTL_NIV1_ID1 bigint,
    DTL_NIV1_NOMBREID2 varchar(255),
    DTL_NIV1_ID2 bigint,
    DTL_NIV1_NOMBREFECHA1 varchar(255),
    DTL_NIV1_FECHA1 D_FECHA,
    DTL_NIV1_NOMBREREFERENCIA1 varchar(255),
    DTL_NIV1_REFERENCIA1 varchar(255),
    DTL_NIV1_NOMBREREFERENCIA2 varchar(255),
    DTL_NIV1_REFERENCIA2 varchar(255),
    DTL_NIV1_NOMBREREFERENCIA3 varchar(255),
    DTL_NIV1_REFERENCIA3 varchar(255),
    DTL_NIV1_NOMBREREFERENCIA4 varchar(255),
    DTL_NIV1_REFERENCIA4 varchar(255),
    DTL_NIV1_NOMBREREFERENCIA5 varchar(255),
    DTL_NIV1_REFERENCIA5 varchar(255),
    DTL_NIV1_NOMBREREFERENCIA6 varchar(255),
    DTL_NIV1_REFERENCIA6 varchar(255),
    DTL_NIV1_NOMBREREFERENCIA7 varchar(255),
    DTL_NIV1_REFERENCIA7 varchar(255),
    DTL_NIV1_NOMBREREFERENCIA8 varchar(255),
    DTL_NIV1_REFERENCIA8 varchar(255),
    DTL_NIV1_NOMBREREFERENCIA9 varchar(255),
    DTL_NIV1_REFERENCIA9 varchar(255),
    DTL_NIV1_NOMBREMONTO1 varchar(255),
    DTL_NIV1_MONTO1 D_PRECIO,
    DTL_NIV1_NOMBREMONTO2 varchar(255),
    DTL_NIV1_MONTO2 D_PRECIO,
    DTL_NIV1_NOMBREMONTO3 varchar(255),
    DTL_NIV1_MONTO3 D_PRECIO,
    DTL_NIV2_CONCEPTO varchar(255),
    DTL_NIV2_NOMBREID1 varchar(255),
    DTL_NIV2_ID1 bigint,
    DTL_NIV2_NOMBREID2 varchar(255),
    DTL_NIV2_ID2 bigint,
    DTL_NIV2_NOMBREFECHA1 varchar(255),
    DTL_NIV2_FECHA1 D_FECHA,
    DTL_NIV2_NOMBREREFERENCIA1 varchar(255),
    DTL_NIV2_REFERENCIA1 varchar(255),
    DTL_NIV2_NOMBREREFERENCIA2 varchar(255),
    DTL_NIV2_REFERENCIA2 varchar(255),
    DTL_NIV2_NOMBREREFERENCIA3 varchar(255),
    DTL_NIV2_REFERENCIA3 varchar(255),
    DTL_NIV2_NOMBREREFERENCIA4 varchar(255),
    DTL_NIV2_REFERENCIA4 varchar(255),
    DTL_NIV2_NOMBREREFERENCIA5 varchar(255),
    DTL_NIV2_REFERENCIA5 varchar(255),
    DTL_NIV2_NOMBREREFERENCIA6 varchar(255),
    DTL_NIV2_REFERENCIA6 varchar(255),
    DTL_NIV2_NOMBREREFERENCIA7 varchar(255),
    DTL_NIV2_REFERENCIA7 varchar(255),
    DTL_NIV2_NOMBREREFERENCIA8 varchar(255),
    DTL_NIV2_REFERENCIA8 varchar(255),
    DTL_NIV2_NOMBREREFERENCIA9 varchar(255),
    DTL_NIV2_REFERENCIA9 varchar(255),
    DTL_NIV2_NOMBREMONTO1 varchar(255),
    DTL_NIV2_MONTO1 D_PRECIO,
    DTL_NIV2_NOMBREMONTO2 varchar(255),
    DTL_NIV2_MONTO2 D_PRECIO,
    DTL_NIV2_NOMBREMONTO3 varchar(255),
    DTL_NIV2_MONTO3 D_PRECIO)
as
declare variable BUFFERMONTO1 D_PRECIO;
declare variable BUFFERMONTO2 D_PRECIO;
declare variable BUFFERMONTO3 D_PRECIO;
declare variable BUFFERMONTO4 D_PRECIO;
declare variable BUFFERMONTO5 D_PRECIO;
declare variable AUXDOCTOID D_FK;
declare variable AUXTASA D_PORCENTAJE;
declare variable AUXFECHA D_FECHA;
declare variable AUXESFACTURAELECTRONICA D_BOOLCN_NULL;
declare variable AUXMONTOSUMARIZADO1 D_PRECIO;
declare variable AUXMONTOSUMARIZADO2 D_PRECIO;
BEGIN
   NUMERO = :NUMEROINICIAL;
   CUADRE = :CUADREINICIAL;
                
    TIPOENTRADA = :TIPOENTRADAINICIAL;
    NUMCUENTA = :NUMCUENTAINICIAL;
    LEYENDA = :LEYENDAINICIAL;


        monto = 0;
        
        BUFFERMONTO1 = 0;
        BUFFERMONTO2 = 0;  
        BUFFERMONTO3 = 0; 
        BUFFERMONTO4 = 0;
        BUFFERMONTO5 = 0;


                        
        AUXMONTOSUMARIZADO1 = 0;
        AUXMONTOSUMARIZADO2 = 0;


        HDR_CONCEPTO1 = ''; HDR_CONCEPTO2 = '';
        NUMLINEA = 0; DTL_ORDEN = 0;
        DTL_NIV1_CONCEPTO = '';
        DTL_NIV1_NOMBREID1 = '';DTL_NIV1_ID1  = 0;DTL_NIV1_NOMBREID2 = '';DTL_NIV1_ID2  = 0;
        DTL_NIV1_NOMBREFECHA1 = '';DTL_NIV1_FECHA1 = NULL;
        DTL_NIV1_NOMBREREFERENCIA1 = '';DTL_NIV1_REFERENCIA1 = '';DTL_NIV1_NOMBREREFERENCIA2 = '';DTL_NIV1_REFERENCIA2 = ''; DTL_NIV1_NOMBREREFERENCIA3 = '';DTL_NIV1_REFERENCIA3  = '';    
        DTL_NIV1_NOMBREREFERENCIA4 = '';DTL_NIV1_REFERENCIA4 = '';DTL_NIV1_NOMBREREFERENCIA5 = '';DTL_NIV1_REFERENCIA5 = ''; DTL_NIV1_NOMBREREFERENCIA6 = '';DTL_NIV1_REFERENCIA6  = '';
        DTL_NIV1_NOMBREREFERENCIA7 = '';DTL_NIV1_REFERENCIA7 = '';DTL_NIV1_NOMBREREFERENCIA8 = '';DTL_NIV1_REFERENCIA8 = ''; DTL_NIV1_NOMBREREFERENCIA9 = '';DTL_NIV1_REFERENCIA9  = '';
        DTL_NIV1_NOMBREMONTO1 = '';DTL_NIV1_MONTO1  = 0; DTL_NIV1_NOMBREMONTO2 = '';DTL_NIV1_MONTO2  = 0;  DTL_NIV1_NOMBREMONTO3 = '';DTL_NIV1_MONTO3  = 0;
        DTL_NIV2_CONCEPTO = '';
        DTL_NIV2_NOMBREID1 = '';DTL_NIV2_ID1  = 0; DTL_NIV2_NOMBREID2 = '';DTL_NIV2_ID2  = 0;
        DTL_NIV2_NOMBREFECHA1 = '';DTL_NIV2_FECHA1 = NULL;
        DTL_NIV2_NOMBREREFERENCIA1 = '';DTL_NIV2_REFERENCIA1 = '';DTL_NIV2_NOMBREREFERENCIA2 = '';DTL_NIV2_REFERENCIA2 = '';DTL_NIV2_NOMBREREFERENCIA3 = '';DTL_NIV2_REFERENCIA3 = '';     
        DTL_NIV2_NOMBREREFERENCIA4 = '';DTL_NIV2_REFERENCIA4 = '';DTL_NIV2_NOMBREREFERENCIA5 = '';DTL_NIV2_REFERENCIA5 = ''; DTL_NIV2_NOMBREREFERENCIA6 = '';DTL_NIV2_REFERENCIA6  = '';
        DTL_NIV2_NOMBREREFERENCIA7 = '';DTL_NIV2_REFERENCIA7 = '';DTL_NIV2_NOMBREREFERENCIA8 = '';DTL_NIV2_REFERENCIA8 = ''; DTL_NIV2_NOMBREREFERENCIA9 = '';DTL_NIV2_REFERENCIA9  = '';
        DTL_NIV2_NOMBREMONTO1 = '';DTL_NIV2_MONTO1 = 0;DTL_NIV2_NOMBREMONTO2 = '';DTL_NIV2_MONTO2  = 0; DTL_NIV2_NOMBREMONTO3 = '';DTL_NIV2_MONTO3  = 0;


         --devolucion  contado
        if( :tipolineapolizaid = 15) then
        begin        
                HDR_CONCEPTO1 = 'DEVOLUCION,CRED/CONT: CONT,ESTATUS:TODAS,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ'  ;
                HDR_CONCEPTO2 = '';
                NUMLINEA = :NUMERO + 1; DTL_ORDEN = 0;

                for
                     select docto.id, sum(coalesce(docto.subtotal,0))  subtotal      
                           ,docto.id , docto.fecha ,  docto.folio, docto.referencia 
                           ,coalesce(docto.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,docto.hatenidocredito
                           ,coalesce(plazo.clave, '') plazo
                           ,case when (docto.tipodoctoid = 31 and coalesce(docto.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado 
                           ,doctoventa.id , doctoventa.fecha ,  doctoventa.folio, doctoventa.referencia  
                           ,coalesce(doctoventa.esfacturaelectronica,'N') || ' - ' || coalesce(doctoventa.timbradouuid,'') esfactura
                           ,doctoventa.hatenidocredito
                           ,coalesce(plazo.clave, '') plazo
                           ,case when (doctoventa.tipodoctoid = 31 and coalesce(doctoventa.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado
                        from docto
                        left join docto doctoventa on  doctoventa.tipodoctoid = 21 and doctoventa.id = docto.doctorefid                
                        left join plazo on plazo.id = 
                                         case when coalesce(docto.plazoid ,0) = 0 then coalesce(doctoventa.plazoid ,0) else coalesce(docto.plazoid ,0) end
                        
                        where docto.fecha = :fecha and
                        (not (coalesce(docto.hatenidocredito,'N') = 'S' or  ((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N' )))
                        and docto.tipodoctoid in (22) and docto.estatusdoctoid in (1,2)
                        and coalesce(docto.esfacturaelectronica,'N') = :esfact 
                        and coalesce(plazo.clave, '') <> 'T'
                        group by docto.id  , docto.fecha ,  docto.folio, docto.referencia    
                                ,docto.esfacturaelectronica ,docto.timbradouuid,docto.hatenidocredito,plazo.clave, docto.tipodoctoid,docto.subtipodoctoid
                                ,doctoventa.id , doctoventa.fecha ,  doctoventa.folio, doctoventa.referencia
                                ,doctoventa.esfacturaelectronica ,doctoventa.timbradouuid,doctoventa.hatenidocredito, doctoventa.tipodoctoid,doctoventa.subtipodoctoid
                        into :auxdoctoid, :monto    
                        ,:DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1   
                        ,:DTL_NIV1_REFERENCIA2,:DTL_NIV1_REFERENCIA3,:DTL_NIV1_REFERENCIA4,:DTL_NIV1_REFERENCIA5
                        ,:DTL_NIV2_ID1 ,:DTL_NIV2_FECHA1 ,:DTL_NIV2_ID2, :DTL_NIV2_REFERENCIA1   
                        ,:DTL_NIV2_REFERENCIA2,:DTL_NIV2_REFERENCIA3,:DTL_NIV2_REFERENCIA4,:DTL_NIV2_REFERENCIA5
                 do
                 begin   

                    DTL_NIV1_CONCEPTO = 'DEVOLUCION,CRED/CONT: CONT,ESTATUS:TODAS,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ'  ;
                    DTL_NIV1_NOMBREID1 = 'DEVOLUCION ID';
                    DTL_NIV1_NOMBREFECHA1 = 'FECHA DEVOLUCION';
                    DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                    DTL_NIV1_MONTO1  = :MONTO;
                    DTL_NIV1_NOMBREID2 = 'FOLIO';
                    DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA'; 
                    DTL_NIV1_NOMBREREFERENCIA2 = 'FORMAPAGO';
                    
                    DTL_NIV2_CONCEPTO = 'VENTA,CRED/CONT: CONT,ESTATUS:TODAS,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ'   ;
                    DTL_NIV2_NOMBREID1 = 'VENTA  ID';
                    DTL_NIV2_NOMBREFECHA1 = 'FECHA VENTA ';
                    DTL_NIV2_NOMBREMONTO1 = 'TOTAL';
                    DTL_NIV2_MONTO1  = :MONTO;
                    DTL_NIV2_NOMBREID2 = 'FOLIO';
                    DTL_NIV2_NOMBREREFERENCIA1 = 'REFERENCIA';

                    DTL_ORDEN = :DTL_ORDEN + 1;
                    IF(:MOSTRARDETALLE = 'S') THEN
                    BEGIN
                        SUSPEND;
                    END

                     
                    if(coalesce(:monto,0) <> 0 OR :MOSTRARDETALLE = 'S') then
                    begin
                        NUMERO = :NUMERO + 1;   
                        NUMLINEA = :NUMERO;
                        DTL_ORDEN  = 0;
                        CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                        suspend;   
                        NUMLINEA = :NUMERO + 1;

                               
                        HDR_CONCEPTO1 = 'IVA DEVOLUCION,CRED/CONT: CONT,ESTATUS:TODAS,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ'  ;
                        HDR_CONCEPTO2 = '';
                        NUMLINEA = :NUMERO + 1; DTL_ORDEN = 0;

                        -- INICIA DESGLOSE DE IVA E IEPS POR DOCUMENTO

                        --desglose de iva
                        select coalesce(docto.iva,0) iva ,docto.id , docto.fecha ,  docto.folio, docto.referencia
                        from docto
                        where id = :auxdoctoid
                        into :monto
                        ,:DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1 ;

                        if(coalesce(:monto,0) <> 0 OR :MOSTRARDETALLE = 'S') then
                        begin
                        
                            DTL_NIV1_CONCEPTO = 'IVA DEVOLUCION,CRED/CONT: CONT,ESTATUS:TODAS,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ'  ;
                            DTL_NIV1_NOMBREID1 = 'DEVOLUCION ID';
                            DTL_NIV1_NOMBREFECHA1 = 'FECHA DEVOLUCION';
                            DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                            DTL_NIV1_MONTO1  = :MONTO;
                            DTL_NIV1_NOMBREID2 = 'FOLIO';
                            DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA'; 
                            DTL_NIV1_NOMBREREFERENCIA2 = 'FORMAPAGO';

                            
                            DTL_NIV2_MONTO1  = :MONTO;

                            DTL_ORDEN = :DTL_ORDEN + 1;
                            IF(:MOSTRARDETALLE = 'S') THEN
                            BEGIN
                                SUSPEND;
                            END

                            --IVA
                            NUMCUENTA = '';
                            SELECT FIRST 1  CUENTA.NUMUCUENTA, coalesce(cuenta.leyenda,'') LEYENDA
                            FROM CUENTA WHERE CUENTA.tipolineapolizaid = 12 AND CUENTA.esfact = :ESFACT
                            INTO  :NUMCUENTA, :LEYENDA;

                            IF( COALESCE(:NUMCUENTA,'') <> '' OR :MOSTRARDETALLE = 'S') THEN
                            BEGIN
                                NUMERO = :NUMERO + 1;   
                                NUMLINEA = :NUMERO;
                                DTL_ORDEN  = 0;  
                                CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                                suspend; 
                                NUMLINEA = :NUMERO + 1;
                            END

                        end

                            
                        HDR_CONCEPTO1 = 'IEPS DEVOLUCION,CRED/CONT: CONT,ESTATUS:TODAS,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ'  ;
                        HDR_CONCEPTO2 = '';
                        NUMLINEA = :NUMERO + 1; DTL_ORDEN = 0;
                        
                        --desglose de IEPS
                        NUMCUENTA = '';
                        FOR
                                select sum(coalesce(movto.ieps ,0))  ieps, movto.tasaieps ,
                                        CUENTA.NUMUCUENTA, coalesce(cuenta.leyenda,'') LEYENDA
                                        ,docto.id , docto.fecha ,  docto.folio, docto.referencia 
                                        ,coalesce(docto.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                                        ,docto.hatenidocredito
                                        ,'' plazo
                                        ,case when (docto.tipodoctoid = 31 and coalesce(docto.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado 
                                from docto     
                                    inner join movto on movto.doctoid = docto.id  
                                    left join producto on movto.productoid = producto.id
                                    left join linea on linea.id = producto.lineaid
                                    inner join cuenta on cuenta.tasa = movto.tasaieps and
                                    cuenta.activo = 'S' and  CUENTA.esfact = :ESFACT and
                                    (cuenta.tipolineapolizaid = 13 or
                                        (cuenta.tipolineapolizaid = 19 and coalesce(linea.clave ,'') not in ('015','016') ) or
                                        (cuenta.tipolineapolizaid = 20 and coalesce(linea.clave ,'') in ('015','016') ) )
                                where docto.id = :auxdoctoid
                                group by  tasaieps, numucuenta, leyenda ,docto.id , docto.fecha ,  docto.folio, docto.referencia   
                                    ,docto.esfacturaelectronica ,docto.timbradouuid,docto.hatenidocredito, docto.tipodoctoid,docto.subtipodoctoid
                                into :monto, :auxtasa , :NUMCUENTA, :LEYENDA  
                                    ,:DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1
                                    ,:DTL_NIV1_REFERENCIA2,:DTL_NIV1_REFERENCIA3,:DTL_NIV1_REFERENCIA4,:DTL_NIV1_REFERENCIA5
                            DO
                         BEGIN   
                                    DTL_NIV1_CONCEPTO = 'IEPS DEVOLUCION,CRED/CONT: CONT,ESTATUS:TODAS,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ'  ;
                                    DTL_NIV1_NOMBREID1 = 'DEVOLUCION ID';
                                    DTL_NIV1_NOMBREFECHA1 = 'FECHA DEVOLUCION';
                                    DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                                    DTL_NIV1_MONTO1  = :MONTO;
                                    DTL_NIV1_NOMBREID2 = 'FOLIO';
                                    DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA'; 
                                    DTL_NIV1_NOMBREREFERENCIA2 = 'FORMAPAGO';

                                    DTL_NIV2_MONTO1  = :MONTO;

                                    DTL_ORDEN = :DTL_ORDEN + 1;
                                    IF(:MOSTRARDETALLE = 'S') THEN
                                    BEGIN
                                        SUSPEND;
                                    END

                                    IF( (coalesce(:monto,0) <> 0  and COALESCE(:NUMCUENTA,'') <> '') OR :MOSTRARDETALLE = 'S') THEN
                                    BEGIN
                                        NUMERO = :NUMERO + 1;  
                                        NUMLINEA = :NUMERO;
                                        DTL_ORDEN  = 0;  
                                        CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                                        suspend;
                                        NUMLINEA = :NUMERO + 1;
                                    END
                          END

                         -- FIN DESGLOSE DE IVA E IEPS POR DOCUMENTO*




                    end

                 end

                     
                HDR_CONCEPTO1 = 'CANCELACION DEVOLUCION,CRED/CONT: CONT,ESTATUS:TODAS,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ'  ;
                HDR_CONCEPTO2 = '';
                NUMLINEA = :NUMERO + 1; DTL_ORDEN = 0;

                 
                for
                     select docto.id, sum(coalesce(docto.total,0) * -1)   subtotal     
                           ,docto.id , docto.fecha ,  docto.folio, docto.referencia 
                           ,coalesce(docto.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,docto.hatenidocredito
                           ,coalesce(plazo.clave, '') plazo
                           ,case when (docto.tipodoctoid = 31 and coalesce(docto.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado 
                        from docto                
                        left join plazo on plazo.id = docto.plazoid   
                        
                        where docto.fecha = :fecha and
                        ( not (coalesce(docto.hatenidocredito,'N') = 'S' or  ((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N' )))
                        and docto.tipodoctoid in (24) and docto.estatusdoctoid in (1,2)
                        and coalesce(docto.esfacturaelectronica,'N') = :esfact    
                        and coalesce(plazo.clave, '') <> 'T'
                        group by docto.id , docto.fecha ,  docto.folio, docto.referencia 
                                ,docto.esfacturaelectronica ,docto.timbradouuid,docto.hatenidocredito,plazo.clave, docto.tipodoctoid,docto.subtipodoctoid
                        into :auxdoctoid, :monto   
                        ,:DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1 
                        ,:DTL_NIV1_REFERENCIA2,:DTL_NIV1_REFERENCIA3,:DTL_NIV1_REFERENCIA4,:DTL_NIV1_REFERENCIA5
                 do
                 begin
                          
                    DTL_NIV1_CONCEPTO = 'CANCELACION DEVOLUCION,CRED/CONT: CONT,ESTATUS:TODAS,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ'  ;
                    DTL_NIV1_NOMBREID1 = 'CANC DEVOLUCION ID';
                    DTL_NIV1_NOMBREFECHA1 = 'FECHA CANC DEVOLUCION';
                    DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                    DTL_NIV1_MONTO1  = :MONTO;
                    DTL_NIV1_NOMBREID2 = 'FOLIO';
                    DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA';
                    DTL_NIV1_NOMBREREFERENCIA2 = 'FORMAPAGO';
                    
                    DTL_NIV2_CONCEPTO =  '';
                    DTL_NIV2_NOMBREID1 = '';
                    DTL_NIV2_NOMBREFECHA1 = '';
                    DTL_NIV2_NOMBREMONTO1 = '';
                    DTL_NIV2_MONTO1  = 0;
                    DTL_NIV2_NOMBREID2 = '';
                    DTL_NIV2_NOMBREREFERENCIA1 = '';
                    DTL_NIV2_NOMBREREFERENCIA2 = '';


                    DTL_ORDEN = :DTL_ORDEN + 1;
                    IF(:MOSTRARDETALLE = 'S') THEN
                    BEGIN
                                        SUSPEND;
                    END


                    if(coalesce(:monto,0) <> 0 OR :MOSTRARDETALLE = 'S') then
                    begin
                        NUMERO = :NUMERO + 1;
                        NUMLINEA = :NUMERO;   
                        DTL_ORDEN  = 0;
                        CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                        suspend;      
                        NUMLINEA = :NUMERO + 1;


                           
                        HDR_CONCEPTO1 = 'IVA CANCELACION DEVOLUCION,CRED/CONT: CONT,ESTATUS:TODAS,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ'  ;
                        HDR_CONCEPTO2 = '';
                        NUMLINEA = :NUMERO + 1; DTL_ORDEN = 0;

                        -- INICIA DESGLOSE DE IVA E IEPS POR DOCUMENTO*

                        --desglose de iva
                        select coalesce(docto.iva,0) * -1 iva     
                           ,docto.id , docto.fecha ,  docto.folio, docto.referencia  
                           ,coalesce(docto.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,docto.hatenidocredito
                           ,'' plazo
                           ,case when (docto.tipodoctoid = 31 and coalesce(docto.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado 
                        from docto
                        where id = :auxdoctoid
                        into :monto  
                        ,:DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1
                        ,:DTL_NIV1_REFERENCIA2,:DTL_NIV1_REFERENCIA3,:DTL_NIV1_REFERENCIA4,:DTL_NIV1_REFERENCIA5 ;

                        if(coalesce(:monto,0) <> 0) then
                        begin
                                 
                            DTL_NIV1_CONCEPTO = 'IVA CANCELACION,CRED/CONT: CONT,ESTATUS:TODAS,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ'  ;
                            DTL_NIV1_NOMBREID1 = 'DEVOLUCION ID';
                            DTL_NIV1_NOMBREFECHA1 = 'FECHA DEVOLUCION';
                            DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                            DTL_NIV1_MONTO1  = :MONTO;
                            DTL_NIV1_NOMBREID2 = 'FOLIO';
                            DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA';
                            DTL_NIV1_NOMBREREFERENCIA2 = 'FORMAPAGO';

                            
                            DTL_NIV2_CONCEPTO =  '';
                            DTL_NIV2_NOMBREID1 = '';
                            DTL_NIV2_NOMBREFECHA1 = '';
                            DTL_NIV2_NOMBREMONTO1 = '';
                            DTL_NIV2_MONTO1  = 0;
                            DTL_NIV2_NOMBREID2 = '';
                            DTL_NIV2_NOMBREREFERENCIA1 = '';
                            DTL_NIV2_NOMBREREFERENCIA2 = '';

                            DTL_ORDEN = :DTL_ORDEN + 1;
                            IF(:MOSTRARDETALLE = 'S') THEN
                            BEGIN
                                        SUSPEND;
                            END


                            --IVA
                            NUMCUENTA = '';
                            SELECT FIRST 1  CUENTA.NUMUCUENTA, coalesce(cuenta.leyenda,'') LEYENDA
                            FROM CUENTA WHERE CUENTA.tipolineapolizaid = 12 AND CUENTA.esfact = :ESFACT
                            INTO  :NUMCUENTA, :LEYENDA;

                            IF( COALESCE(:NUMCUENTA,'') <> ''  OR :MOSTRARDETALLE = 'S') THEN
                            BEGIN
                                NUMERO = :NUMERO + 1;
                                NUMLINEA = :NUMERO;    
                                DTL_ORDEN  = 0;  
                                CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                                suspend;
                                NUMLINEA = :NUMERO + 1;
                            END

                        end

                              
                        HDR_CONCEPTO1 = 'IEPS CANCELACION DEVOLUCION,CRED/CONT: CONT,ESTATUS:TODAS,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ'  ;
                        HDR_CONCEPTO2 = '';
                        NUMLINEA = :NUMERO + 1; DTL_ORDEN = 0;
                        
                        --desglose de IEPS
                        NUMCUENTA = '';
                        FOR
                                select sum(coalesce(movto.ieps ,0)) * -1  ieps, movto.tasaieps ,
                                        CUENTA.NUMUCUENTA, coalesce(cuenta.leyenda,'') LEYENDA    
                                        ,docto.id , docto.fecha ,  docto.folio, docto.referencia
                                        ,coalesce(docto.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                                        ,docto.hatenidocredito
                                        ,'' plazo
                                        ,case when (docto.tipodoctoid = 31 and coalesce(docto.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado 
                                from docto     
                                    inner join movto on movto.doctoid = docto.id  
                                    left join producto on movto.productoid = producto.id
                                    left join linea on linea.id = producto.lineaid
                                    inner join cuenta on cuenta.tasa = movto.tasaieps and
                                    cuenta.activo = 'S' and  CUENTA.esfact = :ESFACT and
                                    (cuenta.tipolineapolizaid = 13 or
                                        (cuenta.tipolineapolizaid = 19 and coalesce(linea.clave ,'') not in ('015','016') ) or
                                        (cuenta.tipolineapolizaid = 20 and coalesce(linea.clave ,'') in ('015','016') ) )
                                where docto.id = :auxdoctoid
                                group by  tasaieps, numucuenta, leyenda  ,docto.id , docto.fecha ,  docto.folio, docto.referencia  
                                ,docto.esfacturaelectronica ,docto.timbradouuid,docto.hatenidocredito, docto.tipodoctoid,docto.subtipodoctoid
                                into :monto, :auxtasa , :NUMCUENTA, :LEYENDA    
                                    ,:DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1  
                                    ,:DTL_NIV1_REFERENCIA2,:DTL_NIV1_REFERENCIA3,:DTL_NIV1_REFERENCIA4,:DTL_NIV1_REFERENCIA5


                            DO
                         BEGIN   
                                    DTL_NIV1_CONCEPTO = 'IEPS CANCELACION,CRED/CONT: CONT,ESTATUS:TODAS,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ'  ;
                                    DTL_NIV1_NOMBREID1 = 'DEVOLUCION ID';
                                    DTL_NIV1_NOMBREFECHA1 = 'FECHA DEVOLUCION';
                                    DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                                    DTL_NIV1_MONTO1  = :MONTO;
                                    DTL_NIV1_NOMBREID2 = 'FOLIO';
                                    DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA';
                                    DTL_NIV1_NOMBREREFERENCIA2 = 'FORMAPAGO';

                                    
                                    DTL_NIV2_CONCEPTO =  '';
                                    DTL_NIV2_NOMBREID1 = '';
                                    DTL_NIV2_NOMBREFECHA1 = '';
                                    DTL_NIV2_NOMBREMONTO1 = '';
                                    DTL_NIV2_MONTO1  = 0;
                                    DTL_NIV2_NOMBREID2 = '';
                                    DTL_NIV2_NOMBREREFERENCIA1 = '';
                                    DTL_NIV2_NOMBREREFERENCIA2 = '';

                                    DTL_ORDEN = :DTL_ORDEN + 1;
                                    IF(:MOSTRARDETALLE = 'S') THEN
                                    BEGIN
                                        SUSPEND;
                                    END

                                    IF( (coalesce(:monto,0) <> 0 and COALESCE(:NUMCUENTA,'') <> '') OR  :MOSTRARDETALLE = 'S') THEN
                                    BEGIN
                                        NUMERO = :NUMERO + 1;  
                                        NUMLINEA = :NUMERO;
                                        DTL_ORDEN  = 0;  
                                        CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                                        suspend;  
                                        NUMLINEA = :NUMERO + 1;
                                    END
                          END

                         -- FIN DESGLOSE DE IVA E IEPS POR DOCUMENTO*


                    end
                 end



        end



END