create or alter procedure POLIZALINEAV2_DET_PARTE6 (
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



         --comision bancaria
        if( :tipolineapolizaid = 3) then
        begin            
                HDR_CONCEPTO1 = 'COMISION ' ; HDR_CONCEPTO2 = '';
                NUMLINEA = :NUMERO + 1; DTL_ORDEN = 0;

                    BUFFERMONTO1 = 0;
                    for
                     select docto.id, sum(coalesce(doctopago.importe,0) * (
                                                                            coalesce(docto.comisiontarjetaempresa,0)
                                        /100.00))   subtotal
                           ,docto.id , docto.fecha ,  docto.folio, docto.referencia , formapagosat.nombre  
                           ,coalesce(docto.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,docto.hatenidocredito
                           ,case when (docto.tipodoctoid = 31 and coalesce(docto.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado
                        from docto
                        inner join doctopago on doctopago.doctoid = docto.id  
                        left join formapagosat  on formapagosat.id = coalesce(doctopago.formapagosatid,0)
                        
                        where docto.fecha = :fecha and
                        (not (coalesce(docto.hatenidocredito,'N') = 'S' or  ((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N' )))
                        and docto.tipodoctoid in (21) and docto.estatusdoctoid in (1,2)
                        and  doctopago.tipopagoid = 1   --coalesce(docto.esfacturaelectronica,'N') = :esfact and
                        and coalesce(doctopago.formapagosatid,0)  in (28,4,29)  --= :formapagosatid
                        group by docto.id , docto.fecha ,  docto.folio, docto.referencia , formapagosat.nombre 
                                ,docto.esfacturaelectronica ,docto.timbradouuid,docto.hatenidocredito, docto.tipodoctoid,docto.subtipodoctoid
                        into :auxdoctoid, :AUXMONTOSUMARIZADO1    
                        ,:DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1  , :DTL_NIV1_REFERENCIA2
                        ,:DTL_NIV1_REFERENCIA3,:DTL_NIV1_REFERENCIA4,:DTL_NIV1_REFERENCIA5
                        do
                        begin     
                            DTL_NIV1_CONCEPTO = 'COMISION BANCARIA';
                            DTL_NIV1_NOMBREID1 = 'VENTA ID';
                            DTL_NIV1_NOMBREFECHA1 = 'FECHA VENTA';
                            DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                            DTL_NIV1_MONTO1  = :AUXMONTOSUMARIZADO1;
                            DTL_NIV1_NOMBREID2 = 'FOLIO';
                            DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA'; 
                            DTL_NIV1_NOMBREREFERENCIA2 = 'FORMAPAGO';
                            
                            DTL_NIV1_NOMBREREFERENCIA3 = 'ESFACTURA';
                            DTL_NIV1_NOMBREREFERENCIA4 = 'HATENIDOCREDITO';
                            DTL_NIV1_NOMBREREFERENCIA5 = 'PLAZO';
                            DTL_NIV1_NOMBREREFERENCIA6 = 'ESTRASLADO';

                            DTL_ORDEN = :DTL_ORDEN + 1;
                            IF(:MOSTRARDETALLE = 'S') THEN
                            BEGIN
                                SUSPEND;
                            END


                             BUFFERMONTO1 = coalesce(:BUFFERMONTO1,0) + coalesce(:AUXMONTOSUMARIZADO1, 0);
                        end


                          
                    BUFFERMONTO2 = 0;
                     for
                        select docto.id, sum(coalesce(doctopago.importe,0) * (
                                                                                coalesce(docto.comisiontarjetaempresa,0)
                                        /100.00) * -1)   subtotal
                           ,docto.id , docto.fecha ,  docto.folio, docto.referencia , formapagosat.nombre   
                           ,coalesce(docto.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,docto.hatenidocredito
                           ,case when (docto.tipodoctoid = 31 and coalesce(docto.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado
                        from docto
                        inner join doctopago on doctopago.doctoid = docto.id  
                        left join formapagosat  on formapagosat.id = coalesce(doctopago.formapagosatid,0)
                        
                        where docto.fecha = :fecha and
                        (not (coalesce(docto.hatenidocredito,'N') = 'S' or  ((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N' )))
                        and docto.tipodoctoid in (23) and docto.estatusdoctoid in (1,2)
                        and  doctopago.tipopagoid = 2  --coalesce(docto.esfacturaelectronica,'N') = :esfact and
                        and coalesce(doctopago.formapagosatid,0)  in (28,4,29)  -- :formapagosatid
                        group by docto.id , docto.fecha ,  docto.folio, docto.referencia , formapagosat.nombre 
                                ,docto.esfacturaelectronica ,docto.timbradouuid,docto.hatenidocredito, docto.tipodoctoid,docto.subtipodoctoid 
                        into :auxdoctoid, :AUXMONTOSUMARIZADO1  
                        ,:DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1  , :DTL_NIV1_REFERENCIA2  
                        ,:DTL_NIV1_REFERENCIA3,:DTL_NIV1_REFERENCIA4,:DTL_NIV1_REFERENCIA5
                        do
                        begin
                         
                            DTL_NIV1_CONCEPTO = 'COMISION CANC PAGO';
                            DTL_NIV1_NOMBREID1 = 'VENTA CANC ID';
                            DTL_NIV1_NOMBREFECHA1 = 'FECHA VENTA CANC';
                            DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                            DTL_NIV1_MONTO1  = :AUXMONTOSUMARIZADO1 * -1;
                            DTL_NIV1_NOMBREID2 = 'FOLIO';
                            DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA'; 
                            DTL_NIV1_NOMBREREFERENCIA2 = 'FORMAPAGO';
                            
                            DTL_NIV1_NOMBREREFERENCIA3 = 'ESFACTURA';
                            DTL_NIV1_NOMBREREFERENCIA4 = 'HATENIDOCREDITO';
                            DTL_NIV1_NOMBREREFERENCIA5 = 'PLAZO';
                            DTL_NIV1_NOMBREREFERENCIA6 = 'ESTRASLADO';


                            DTL_ORDEN = :DTL_ORDEN + 1;
                            IF(:MOSTRARDETALLE = 'S') THEN
                            BEGIN
                                SUSPEND;
                            END


                             BUFFERMONTO2 = coalesce(:BUFFERMONTO2,0) + coalesce(:AUXMONTOSUMARIZADO1, 0);
                        end

                        monto = coalesce(:buffermonto1,0) - coalesce(:buffermonto2,0);
                        if(coalesce(:monto,0) <> 0 OR :MOSTRARDETALLE = 'S') then
                        begin
                            NUMERO = :NUMERO + 1; 
                            NUMLINEA = :NUMERO; 
                            DTL_ORDEN  = 0; 
                            CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                            suspend;   
                            NUMLINEA = :NUMERO + 1;

                        end
        end

               
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

        
         --iva comision bancaria
        if( :tipolineapolizaid = 4) then
        begin                    
                HDR_CONCEPTO1 = 'IVA COMISION ' ; HDR_CONCEPTO2 = '';
                NUMLINEA = :NUMERO + 1; DTL_ORDEN = 0;
                          
                    BUFFERMONTO1 = 0;
                    for
                     select docto.id, sum(coalesce(doctopago.importe,0) * (
                                                                            coalesce(docto.comisiontarjetaempresa,0)
                                        /100.00) * (
                                                                            coalesce(docto.ivacomisiontarjetaempresa,0)
                                        /100))   subtotal
                           ,docto.id , docto.fecha ,  docto.folio, docto.referencia , formapagosat.nombre 
                           ,coalesce(docto.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,docto.hatenidocredito
                           ,case when (docto.tipodoctoid = 31 and coalesce(docto.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado
                        from docto
                        inner join doctopago on doctopago.doctoid = docto.id 
                        left join formapagosat  on formapagosat.id = coalesce(doctopago.formapagosatid,0)
                        
                        where docto.fecha = :fecha and
                        (not (coalesce(docto.hatenidocredito,'N') = 'S' or  ((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N' )))
                        and docto.tipodoctoid in (21) and docto.estatusdoctoid in (1,2)
                        and  doctopago.tipopagoid = 1  --coalesce(docto.esfacturaelectronica,'N') = :esfact and
                        and coalesce(doctopago.formapagosatid,0)  in (28,4,29)  -- :formapagosatid
                        group by docto.id , docto.fecha ,  docto.folio, docto.referencia , formapagosat.nombre 
                                ,docto.esfacturaelectronica ,docto.timbradouuid,docto.hatenidocredito, docto.tipodoctoid,docto.subtipodoctoid 
                        into :auxdoctoid, :AUXMONTOSUMARIZADO1  
                        ,:DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1  , :DTL_NIV1_REFERENCIA2 
                        ,:DTL_NIV1_REFERENCIA3,:DTL_NIV1_REFERENCIA4,:DTL_NIV1_REFERENCIA5
                        do
                        begin   
                            DTL_NIV1_CONCEPTO = 'IVA COMISION';
                            DTL_NIV1_NOMBREID1 = 'VENTA  ID';
                            DTL_NIV1_NOMBREFECHA1 = 'FECHA VENTA ';
                            DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                            DTL_NIV1_MONTO1  = :AUXMONTOSUMARIZADO1;
                            DTL_NIV1_NOMBREID2 = 'FOLIO';
                            DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA'; 
                            DTL_NIV1_NOMBREREFERENCIA2 = 'FORMAPAGO';
                            
                            DTL_NIV1_NOMBREREFERENCIA3 = 'ESFACTURA';
                            DTL_NIV1_NOMBREREFERENCIA4 = 'HATENIDOCREDITO';
                            DTL_NIV1_NOMBREREFERENCIA5 = 'PLAZO';
                            DTL_NIV1_NOMBREREFERENCIA6 = 'ESTRASLADO';

                            DTL_ORDEN = :DTL_ORDEN + 1;
                            IF(:MOSTRARDETALLE = 'S') THEN
                            BEGIN
                                SUSPEND;
                            END

                             BUFFERMONTO1 = coalesce(:BUFFERMONTO1,0) + coalesce(:AUXMONTOSUMARIZADO1, 0);
                        end


                           
                    BUFFERMONTO2 = 0;
                     for
                     select docto.id, sum(coalesce(doctopago.importe,0) * (
                                                                            coalesce(docto.comisiontarjetaempresa,0)
                                        /100.00) * (
                                                                            coalesce(docto.ivacomisiontarjetaempresa,0)
                                        /100) * -1)   subtotal
                           ,docto.id , docto.fecha ,  docto.folio, docto.referencia , formapagosat.nombre  
                           ,coalesce(docto.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,docto.hatenidocredito
                           ,case when (docto.tipodoctoid = 31 and coalesce(docto.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado
                        from docto
                        inner join doctopago on doctopago.doctoid = docto.id 
                        left join formapagosat  on formapagosat.id = coalesce(doctopago.formapagosatid,0)
                        
                        where docto.fecha = :fecha and
                        (not (coalesce(docto.hatenidocredito,'N') = 'S' or  ((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N' )))
                        and docto.tipodoctoid in (23) and docto.estatusdoctoid in (1,2)
                        and doctopago.tipopagoid = 2   --coalesce(docto.esfacturaelectronica,'N') = :esfact and
                        and coalesce(doctopago.formapagosatid,0)  in (28,4,29)  -- :formapagosatid
                        group by docto.id  , docto.fecha ,  docto.folio, docto.referencia , formapagosat.nombre     
                                ,docto.esfacturaelectronica ,docto.timbradouuid,docto.hatenidocredito, docto.tipodoctoid,docto.subtipodoctoid
                        into :auxdoctoid, :AUXMONTOSUMARIZADO1   
                        ,:DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1  , :DTL_NIV1_REFERENCIA2
                        ,:DTL_NIV1_REFERENCIA3,:DTL_NIV1_REFERENCIA4,:DTL_NIV1_REFERENCIA5
                        do
                        begin     
                            DTL_NIV1_CONCEPTO = 'CANC IVA COMISION';
                            DTL_NIV1_NOMBREID1 = 'VENTA CANC ID';
                            DTL_NIV1_NOMBREFECHA1 = 'FECHA VENTA CANC';
                            DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                            DTL_NIV1_MONTO1  = :AUXMONTOSUMARIZADO1 * -1;
                            DTL_NIV1_NOMBREID2 = 'FOLIO';
                            DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA'; 
                            DTL_NIV1_NOMBREREFERENCIA2 = 'FORMAPAGO';
                            
                            DTL_NIV1_NOMBREREFERENCIA3 = 'ESFACTURA';
                            DTL_NIV1_NOMBREREFERENCIA4 = 'HATENIDOCREDITO';
                            DTL_NIV1_NOMBREREFERENCIA5 = 'PLAZO';
                            DTL_NIV1_NOMBREREFERENCIA6 = 'ESTRASLADO';

                            DTL_ORDEN = :DTL_ORDEN + 1;
                            IF(:MOSTRARDETALLE = 'S') THEN
                            BEGIN
                                SUSPEND;
                            END


                             BUFFERMONTO2 = coalesce(:BUFFERMONTO2,0) + coalesce(:AUXMONTOSUMARIZADO1, 0);
                        end

                        monto = coalesce(:buffermonto1,0) - coalesce(:buffermonto2,0);

                        if(coalesce(:monto,0) <> 0 OR :MOSTRARDETALLE = 'S') then
                        begin
                            NUMERO = :NUMERO + 1;  
                            NUMLINEA = :NUMERO;
                            DTL_ORDEN  = 0; 
                            CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                            suspend; 
                            NUMLINEA = :NUMERO + 1;
                        end
        end

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

        
         --contra comision y su iva bancaria
        if( :tipolineapolizaid = 5) then
        begin               
                HDR_CONCEPTO1 = 'CONTRA COMISION CON IVA ' ; HDR_CONCEPTO2 = '';
                NUMLINEA = :NUMERO + 1; DTL_ORDEN = 0;
                           
                    BUFFERMONTO1 = 0;
                    for
                     select   docto.id, sum(coalesce(doctopago.importe,0) * (
                                                                            coalesce(docto.comisiontarjetaempresa,0)
                                        /100.00) * (1 + (
                                                                            coalesce(docto.ivacomisiontarjetaempresa,0)
                                        /100)))   subtotal
                           ,docto.id , docto.fecha ,  docto.folio, docto.referencia , formapagosat.nombre    
                           ,coalesce(docto.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,docto.hatenidocredito
                           ,case when (docto.tipodoctoid = 31 and coalesce(docto.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado
                        from docto
                        inner join doctopago on doctopago.doctoid = docto.id 
                        left join formapagosat  on formapagosat.id = coalesce(doctopago.formapagosatid,0)
                        
                        where docto.fecha = :fecha and
                        ( not(coalesce(docto.hatenidocredito,'N') = 'S' or  ((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N' )))
                        and docto.tipodoctoid in (21) and docto.estatusdoctoid in (1,2)
                        and  doctopago.tipopagoid = 1  --coalesce(docto.esfacturaelectronica,'N') = :esfact and
                        and coalesce(doctopago.formapagosatid,0)  in (28,4,29)  -- :formapagosatid  AND :formapagosatid in (4,28,29)
                        group by docto.id, docto.fecha ,  docto.folio, docto.referencia , formapagosat.nombre 
                                ,docto.esfacturaelectronica ,docto.timbradouuid,docto.hatenidocredito, docto.tipodoctoid,docto.subtipodoctoid  
                        into :auxdoctoid, :AUXMONTOSUMARIZADO1   
                        ,:DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1  , :DTL_NIV1_REFERENCIA2 
                        ,:DTL_NIV1_REFERENCIA3,:DTL_NIV1_REFERENCIA4,:DTL_NIV1_REFERENCIA5
                        do
                        begin   
                            DTL_NIV1_CONCEPTO = 'CONTRA COMISION CON IVA';
                            DTL_NIV1_NOMBREID1 = 'VENTA  ID';
                            DTL_NIV1_NOMBREFECHA1 = 'FECHA VENTA ';
                            DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                            DTL_NIV1_MONTO1  = :AUXMONTOSUMARIZADO1;
                            DTL_NIV1_NOMBREID2 = 'FOLIO';
                            DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA'; 
                            DTL_NIV1_NOMBREREFERENCIA2 = 'FORMAPAGO';
                            
                            DTL_NIV1_NOMBREREFERENCIA3 = 'ESFACTURA';
                            DTL_NIV1_NOMBREREFERENCIA4 = 'HATENIDOCREDITO';
                            DTL_NIV1_NOMBREREFERENCIA5 = 'PLAZO';
                            DTL_NIV1_NOMBREREFERENCIA6 = 'ESTRASLADO';

                            DTL_ORDEN = :DTL_ORDEN + 1;
                            IF(:MOSTRARDETALLE = 'S') THEN
                            BEGIN
                                SUSPEND;
                            END

                             BUFFERMONTO1 = coalesce(:BUFFERMONTO1,0) + coalesce(:AUXMONTOSUMARIZADO1, 0);
                        end


                          
                    BUFFERMONTO2 = 0;
                     for
                     select  docto.id, sum(coalesce(doctopago.importe,0) * (
                                                                            coalesce(docto.comisiontarjetaempresa,0)
                                        /100.00) * (1 + (
                                                                            coalesce(docto.ivacomisiontarjetaempresa,0)
                                        /100)))   * -1   subtotal
                           ,docto.id , docto.fecha ,  docto.folio, docto.referencia , formapagosat.nombre  
                           ,coalesce(docto.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,docto.hatenidocredito
                           ,case when (docto.tipodoctoid = 31 and coalesce(docto.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado
                        from docto
                        inner join doctopago on doctopago.doctoid = docto.id   
                        left join formapagosat  on formapagosat.id = coalesce(doctopago.formapagosatid,0)
                        
                        where docto.fecha = :fecha and
                        (not (coalesce(docto.hatenidocredito,'N') = 'S' or  ((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N' )))
                        and docto.tipodoctoid in (23) and docto.estatusdoctoid in (1,2)
                        and  doctopago.tipopagoid = 2   --coalesce(docto.esfacturaelectronica,'N') = :esfact and
                        and coalesce(doctopago.formapagosatid,0)  in (28,4,29)  -- :formapagosatid   AND :formapagosatid in (4,28,29)
                        group by docto.id , docto.fecha ,  docto.folio, docto.referencia , formapagosat.nombre  
                                ,docto.esfacturaelectronica ,docto.timbradouuid,docto.hatenidocredito, docto.tipodoctoid,docto.subtipodoctoid
                        into :auxdoctoid, :AUXMONTOSUMARIZADO1   
                        ,:DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1  , :DTL_NIV1_REFERENCIA2 
                        ,:DTL_NIV1_REFERENCIA3,:DTL_NIV1_REFERENCIA4,:DTL_NIV1_REFERENCIA5
                        do
                        begin    
                            DTL_NIV1_CONCEPTO = 'CANC CONTRACOMISIO IVA';
                            DTL_NIV1_NOMBREID1 = 'VENTA CANC ID';
                            DTL_NIV1_NOMBREFECHA1 = 'FECHA VENTA CANC';
                            DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                            DTL_NIV1_MONTO1  = :AUXMONTOSUMARIZADO1 * -1;
                            DTL_NIV1_NOMBREID2 = 'FOLIO';
                            DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA'; 
                            DTL_NIV1_NOMBREREFERENCIA2 = 'FORMAPAGO';
                            
                            DTL_NIV1_NOMBREREFERENCIA3 = 'ESFACTURA';
                            DTL_NIV1_NOMBREREFERENCIA4 = 'HATENIDOCREDITO';
                            DTL_NIV1_NOMBREREFERENCIA5 = 'PLAZO';
                            DTL_NIV1_NOMBREREFERENCIA6 = 'ESTRASLADO';

                            DTL_ORDEN = :DTL_ORDEN + 1;
                            IF(:MOSTRARDETALLE = 'S') THEN
                            BEGIN
                                SUSPEND;
                            END


                             BUFFERMONTO2 = coalesce(:BUFFERMONTO2,0) + coalesce(:AUXMONTOSUMARIZADO1, 0);
                        end

                        monto = coalesce(:buffermonto1,0) - coalesce(:buffermonto2,0);

                        if(coalesce(:monto,0)  <> 0 OR :MOSTRARDETALLE = 'S') then
                        begin
                            NUMERO = :NUMERO + 1; 
                            NUMLINEA = :NUMERO; 
                            DTL_ORDEN  = 0;     
                            CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                            suspend; 
                            NUMLINEA = :NUMERO + 1;
                        end
        end


        
        if( :tipolineapolizaid = 16) then
        begin      


            --CUADRE POR TRASLADOS ENTRE SUCURSAL
             select sum( docto.total * case when docto.tipodoctoid in (21) then 1 else -1 end) monto
             from docto
             where  docto.fecha = :fecha and
             docto.tipodoctoid in (21,22) and docto.estatusdoctoid = 1 and
            ((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N' )
            into :BUFFERMONTO1;

            monto = coalesce(:BUFFERMONTO1, 0.00);

            if(coAlesce(:monto,0) < 0) THEN
             BEGIN
                TIPOENTRADA = 1;
                MONTO = coAlesce(:monto,0) * -1;
             END
             ELSE
             BEGIN  
                TIPOENTRADA = 2;
             END


             if(coalesce(:monto,0) <> 0) then
             begin
                    NUMERO = :NUMERO + 1; 
                    NUMLINEA = :NUMERO;
                    DTL_ORDEN  = 0;
                    suspend; 
                    NUMLINEA = :NUMERO + 1;
             end
             
            CUADRE = :CUADRE + COALESCE(:BUFFERMONTO1,0);


            --CUADRE NORMAL
             monto = :CUADRE * -1;


             if(coAlesce(:monto,0) < 0) THEN
             BEGIN
                TIPOENTRADA = 1;
                MONTO = coAlesce(:monto,0) * -1;
             END
             ELSE
             BEGIN  
                TIPOENTRADA = 2;
             END


             if(coalesce(:monto,0) <> 0) then
             begin
                    NUMERO = :NUMERO + 1; 
                    NUMLINEA = :NUMERO;
                    DTL_ORDEN  = 0;
                    suspend; 
                    NUMLINEA = :NUMERO + 1;
             end
        END









   if (:numero = 0) then
   begin


   end


END