create or alter procedure POLIZALINEAV2_DET_PARTE3 (
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


         --subtotales venta
        if( :tipolineapolizaid = 11) then
        begin
        
             HDR_CONCEPTO1 = 'VENTA,CRED/CONT: CRED,ESTATUS:COMP,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ'  ;
             HDR_CONCEPTO2 = '';
             NUMLINEA = :NUMERO + 1; DTL_ORDEN = 0;

                --suma todos los subtotales
              BUFFERMONTO1 = 0;
              for
                select ((coalesce(docto.total,0) - coalesce(docto.impuesto ,0)) * case when docto.tipodoctoid = 21 then 1 else -1 end)  subtotal     
                           ,docto.id , docto.fecha ,  docto.folio, docto.referencia  
                           ,coalesce(docto.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,docto.hatenidocredito
                           ,coalesce(plazo.clave, '') plazo
                           ,case when (docto.tipodoctoid = 31 and coalesce(docto.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado
                from docto
                left join plazo on plazo.id = docto.plazoid
                where docto.fecha = :fecha and
                ((  (coalesce(docto.hatenidocredito,'N') = 'S' or  ((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N' ))
                     and docto.tipodoctoid in (21) and docto.estatusdoctoid = 1
                  )
                 or  (coalesce(docto.hatenidocredito,'N') = 'N' and docto.tipodoctoid in (21,23) and docto.estatusdoctoid in (1,2))
                )
                and coalesce(docto.esfacturaelectronica,'N') = :esfact
                and coalesce(plazo.clave, '') <> 'T'
                into  :AUXMONTOSUMARIZADO1     
                        ,:DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1  
                        ,:DTL_NIV1_REFERENCIA2,:DTL_NIV1_REFERENCIA3,:DTL_NIV1_REFERENCIA4,:DTL_NIV1_REFERENCIA5
               do
               begin    
                    DTL_NIV1_CONCEPTO =  'VENTA,CRED/CONT: CRED,ESTATUS:COMP,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ';
                    DTL_NIV1_NOMBREID1 = 'VENTA ID';
                    DTL_NIV1_NOMBREFECHA1 = 'FECHA VENTA';
                    DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                    DTL_NIV1_MONTO1  = :AUXMONTOSUMARIZADO1;
                    DTL_NIV1_NOMBREID2 = 'FOLIO';
                    DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA';
                    
                    DTL_NIV2_CONCEPTO =  '';
                    DTL_NIV2_NOMBREID1 = '';
                    DTL_NIV2_NOMBREFECHA1 = '';
                    DTL_NIV2_NOMBREMONTO1 = '';
                    DTL_NIV2_MONTO1  = 0;
                    DTL_NIV2_NOMBREID2 = '';
                    DTL_NIV2_NOMBREREFERENCIA1 = '';
                    DTL_NIV2_NOMBREREFERENCIA2 = '';

                    
                    DTL_NIV1_NOMBREREFERENCIA2 = 'ESFACTURA';
                    DTL_NIV1_NOMBREREFERENCIA3 = 'HATENIDOCREDITO';
                    DTL_NIV1_NOMBREREFERENCIA4 = 'PLAZO';
                    DTL_NIV1_NOMBREREFERENCIA5 = 'ESTRASLADO';



                    DTL_ORDEN = :DTL_ORDEN + 1;
                    IF(:MOSTRARDETALLE = 'S') THEN
                    BEGIN
                        SUSPEND;
                    END

                    BUFFERMONTO1   = coalesce(:BUFFERMONTO1,0) +   coalesce(:AUXMONTOSUMARIZADO1,0);
               end

                        
                --DEVOLUCION  DE LA FECHA ESPECIFICA DE VENTAS DEL MISMO MES
                BUFFERMONTO2 = 0;
               for select ((coalesce(doctodev.total,0) - coalesce(doctodev.impuesto ,0)) )  subtotal     
                           ,doctodev.id , doctodev.fecha ,  doctodev.folio, doctodev.referencia
                           ,coalesce(doctodev.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,doctodev.hatenidocredito
                           ,coalesce(plazo.clave, '') plazo
                           ,case when (doctodev.tipodoctoid = 31 and coalesce(doctodev.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado

                           ,docto.id , docto.fecha ,  docto.folio, docto.referencia
                           ,coalesce(docto.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,docto.hatenidocredito
                           ,coalesce(plazo.clave, '') plazo
                           ,case when (docto.tipodoctoid = 31 and coalesce(docto.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado
                from docto
                inner join docto doctodev on doctodev.tipodoctoid = 22 and docto.id = doctodev.doctorefid and doctodev.estatusdoctoid = 1  and extract(month from docto.fecha) = extract(month from doctodev.fecha)
                left join plazo on plazo.id = docto.plazoid
                where doctodev.fecha = :fecha and
                (not (coalesce(docto.hatenidocredito,'N') = 'S' or  ((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N' )))
                and docto.tipodoctoid in (21) and docto.estatusdoctoid = 1
                and coalesce(docto.esfacturaelectronica,'N') = :esfact
                and :esfact = 'N'
                and coalesce(plazo.clave, '') <> 'T'
               into :AUXMONTOSUMARIZADO1   
                        ,:DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1   
                        ,:DTL_NIV1_REFERENCIA2,:DTL_NIV1_REFERENCIA3,:DTL_NIV1_REFERENCIA4,:DTL_NIV1_REFERENCIA5
                        ,:DTL_NIV2_ID1 ,:DTL_NIV2_FECHA1 ,:DTL_NIV2_ID2, :DTL_NIV2_REFERENCIA1
                        ,:DTL_NIV2_REFERENCIA2,:DTL_NIV2_REFERENCIA3,:DTL_NIV2_REFERENCIA4,:DTL_NIV2_REFERENCIA5
               do
               begin      
                    DTL_NIV1_CONCEPTO =  'DEVOLUCION MISMO MES, FECHA:DEVOLUCION, CRED/CONT: CONT,ESTATUS:COMP,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ';
                    DTL_NIV1_NOMBREID1 = 'DEVOLUCION ID';
                    DTL_NIV1_NOMBREFECHA1 = 'FECHA DEVOLUCION';
                    DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                    DTL_NIV1_MONTO1  = :AUXMONTOSUMARIZADO1 * -1;
                    DTL_NIV1_NOMBREID2 = 'FOLIO';
                    DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA'; 
                    DTL_NIV1_NOMBREREFERENCIA2 = 'FORMAPAGO';
                                         
                    DTL_NIV2_CONCEPTO =  'VENTA MISMO MES, FECHA:DEVOLUCION, CRED/CONT: CONT,ESTATUS:COMP,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ';
                    DTL_NIV2_NOMBREID1 = 'VENTA ID';
                    DTL_NIV2_NOMBREFECHA1 = 'FECHA VENTA';
                    DTL_NIV2_NOMBREMONTO1 = 'TOTAL';
                    DTL_NIV2_MONTO1  = :AUXMONTOSUMARIZADO1;
                    DTL_NIV2_NOMBREID2 = 'FOLIO';
                    DTL_NIV2_NOMBREREFERENCIA1 = 'REFERENCIA';
                    
                    DTL_NIV1_NOMBREREFERENCIA2 = 'ESFACTURA';
                    DTL_NIV1_NOMBREREFERENCIA3 = 'HATENIDOCREDITO';
                    DTL_NIV1_NOMBREREFERENCIA4 = 'PLAZO';
                    DTL_NIV1_NOMBREREFERENCIA5 = 'ESTRASLADO';
                       
                    DTL_NIV2_NOMBREREFERENCIA2 = 'ESFACTURA';
                    DTL_NIV2_NOMBREREFERENCIA3 = 'HATENIDOCREDITO';
                    DTL_NIV2_NOMBREREFERENCIA4 = 'PLAZO';
                    DTL_NIV2_NOMBREREFERENCIA5 = 'ESTRASLADO';


                    DTL_ORDEN = :DTL_ORDEN + 1;
                    IF(:MOSTRARDETALLE = 'S') THEN
                    BEGIN
                        SUSPEND;
                    END

                    BUFFERMONTO2   = coalesce(:BUFFERMONTO2,0) +   coalesce(:AUXMONTOSUMARIZADO1,0);
               end
               


                --restale las devoluciones de credito sobre ventas de otros meses
                --select sum((coalesce(doctodev.total,0) - coalesce(doctodev.impuesto ,0)) )  subtotal
                --from docto doctodev
                --inner join docto on docto.tipodoctoid = 21 and docto.id = doctodev.doctorefid and docto.estatusdoctoid = 1  and extract(month from docto.fecha) <> extract(month from doctodev.fecha)
                --left join plazo on plazo.id = docto.plazoid
                --where doctodev.fecha = :fecha and
                --(coalesce(docto.hatenidocredito,'N') = 'S' or  ((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N' ))
                --and doctodev.tipodoctoid in (22) and doctodev.estatusdoctoid = 1
                --and coalesce(docto.esfacturaelectronica,'N') = :esfact
                --and coalesce(plazo.clave, '') <> 'T'
                --into :BUFFERMONTO3;

                BUFFERMONTO3 = 0;  --REVISAR TOLEDO



                --DEVOLUCION DIF MES DE VENTAS DE LA FECHA ESPECIFICA
                BUFFERMONTO4 = 0;
               for
                select ((coalesce(doctodev.total,0) - coalesce(doctodev.impuesto ,0)) )  subtotal      
                           ,doctodev.id , doctodev.fecha ,  doctodev.folio, doctodev.referencia
                           ,coalesce(doctodev.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,doctodev.hatenidocredito
                           ,coalesce(plazo.clave, '') plazo
                           ,case when (doctodev.tipodoctoid = 31 and coalesce(doctodev.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado     
                           ,docto.id , docto.fecha ,  docto.folio, docto.referencia
                           ,coalesce(docto.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,docto.hatenidocredito
                           ,coalesce(plazo.clave, '') plazo
                           ,case when (docto.tipodoctoid = 31 and coalesce(docto.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado
                from docto
                inner join docto doctodev on doctodev.tipodoctoid = 22 and docto.id = doctodev.doctorefid and doctodev.estatusdoctoid = 1  and extract(month from docto.fecha) = extract(month from doctodev.fecha)
                left join plazo on plazo.id = docto.plazoid
                where docto.fecha = :fecha  and
                ( (coalesce(docto.hatenidocredito,'N') = 'S' or  ((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N' )))
                and
                docto.tipodoctoid in (21) and docto.estatusdoctoid = 1
                and coalesce(docto.esfacturaelectronica,'N') = :esfact
                and :esfact = 'N'
                and coalesce(plazo.clave, '') <> 'T' 
               into :AUXMONTOSUMARIZADO1    
                        ,:DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1   
                        ,:DTL_NIV1_REFERENCIA2,:DTL_NIV1_REFERENCIA3,:DTL_NIV1_REFERENCIA4,:DTL_NIV1_REFERENCIA5
                        ,:DTL_NIV2_ID1 ,:DTL_NIV2_FECHA1 ,:DTL_NIV2_ID2, :DTL_NIV2_REFERENCIA1
                        ,:DTL_NIV2_REFERENCIA2,:DTL_NIV2_REFERENCIA3,:DTL_NIV2_REFERENCIA4,:DTL_NIV2_REFERENCIA5
               do
               begin        
                    DTL_NIV1_CONCEPTO = 'DEVOLUCION DIF MES, FECHA:VENTA, CRED/CONT: CRED,ESTATUS:COMP,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ';
                    DTL_NIV1_NOMBREID1 = 'DEVOLUCION ID';
                    DTL_NIV1_NOMBREFECHA1 = 'DEVOLUCION VENTA';
                    DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                    DTL_NIV1_MONTO1  = :AUXMONTOSUMARIZADO1 * -1;
                    DTL_NIV1_NOMBREID2 = 'FOLIO';
                    DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA';
                    
                    DTL_NIV2_CONCEPTO =  'VENTA DIF MES, , FECHA:VENTA, CRED/CONT: CRED,ESTATUS:COMP,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ';
                    DTL_NIV2_NOMBREID1 = 'VENTA ID';
                    DTL_NIV2_NOMBREFECHA1 = 'FECHA VENTA';
                    DTL_NIV2_NOMBREMONTO1 = 'TOTAL';
                    DTL_NIV2_MONTO1  = :AUXMONTOSUMARIZADO1;
                    DTL_NIV2_NOMBREID2 = 'FOLIO';
                    DTL_NIV2_NOMBREREFERENCIA1 = 'REFERENCIA';
                    DTL_NIV2_NOMBREREFERENCIA2 = 'FORMAPAGO';
                    
                    DTL_NIV1_NOMBREREFERENCIA2 = 'ESFACTURA';
                    DTL_NIV1_NOMBREREFERENCIA3 = 'HATENIDOCREDITO';
                    DTL_NIV1_NOMBREREFERENCIA4 = 'PLAZO';
                    DTL_NIV1_NOMBREREFERENCIA5 = 'ESTRASLADO';
                       
                    DTL_NIV2_NOMBREREFERENCIA2 = 'ESFACTURA';
                    DTL_NIV2_NOMBREREFERENCIA3 = 'HATENIDOCREDITO';
                    DTL_NIV2_NOMBREREFERENCIA4 = 'PLAZO';
                    DTL_NIV2_NOMBREREFERENCIA5 = 'ESTRASLADO';

                    DTL_ORDEN = :DTL_ORDEN + 1;
                    IF(:MOSTRARDETALLE = 'S') THEN
                    BEGIN
                        SUSPEND;
                    END

                    BUFFERMONTO4   = coalesce(:BUFFERMONTO4,0) +   coalesce(:AUXMONTOSUMARIZADO1,0);
               end


                                                                          
                BUFFERMONTO5 = 0;
                --restale los traslados a clientes con mismo rfc  cuando no es factura electronica
               for
                select ((coalesce(docto.total,0) - coalesce(docto.impuesto ,0)) * case when docto.tipodoctoid = 21 then 1 else -1 end)  subtotal       
                           ,docto.id , docto.fecha ,  docto.folio, docto.referencia
                           ,coalesce(docto.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,docto.hatenidocredito
                           ,coalesce(plazo.clave, '') plazo
                           ,case when (docto.tipodoctoid = 31 and coalesce(docto.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado
                from docto
                left join plazo on plazo.id = docto.plazoid
                where docto.fecha = :fecha and
                docto.tipodoctoid in (21)
                and coalesce(docto.subtipodoctoid,0) in (7,8)
                and docto.estatusdoctoid = 1
                and coalesce(docto.esfacturaelectronica,'N') = :esfact
                and :esfact = 'N'
                and coalesce(plazo.clave, '') <> 'T'  
               into :AUXMONTOSUMARIZADO1    
                        ,:DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1
                        ,:DTL_NIV1_REFERENCIA2,:DTL_NIV1_REFERENCIA3,:DTL_NIV1_REFERENCIA4,:DTL_NIV1_REFERENCIA5
               do
               begin       
                    DTL_NIV1_CONCEPTO = 'TRASLADO, FECHA:TRSLADO, CRED/CONT: TODOS,ESTATUS:COMP,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ';
                    DTL_NIV1_NOMBREID1 = 'TRASLADO ID';
                    DTL_NIV1_NOMBREFECHA1 = 'TRASLADO VENTA';
                    DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                    DTL_NIV1_MONTO1  = :AUXMONTOSUMARIZADO1 * -1;
                    DTL_NIV1_NOMBREID2 = 'FOLIO';
                    DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA';

                    
                    DTL_NIV2_CONCEPTO =  '';
                    DTL_NIV2_NOMBREID1 = '';
                    DTL_NIV2_NOMBREFECHA1 = '';
                    DTL_NIV2_NOMBREMONTO1 = '';
                    DTL_NIV2_MONTO1  = 0;
                    DTL_NIV2_NOMBREID2 = '';
                    DTL_NIV2_NOMBREREFERENCIA1 = '';
                    DTL_NIV2_NOMBREREFERENCIA2 = '';
                    
                    DTL_NIV1_NOMBREREFERENCIA2 = 'ESFACTURA';
                    DTL_NIV1_NOMBREREFERENCIA3 = 'HATENIDOCREDITO';
                    DTL_NIV1_NOMBREREFERENCIA4 = 'PLAZO';
                    DTL_NIV1_NOMBREREFERENCIA5 = 'ESTRASLADO';



                    DTL_ORDEN = :DTL_ORDEN + 1;
                    IF(:MOSTRARDETALLE = 'S') THEN
                    BEGIN
                        SUSPEND;
                    END

                    BUFFERMONTO5   = coalesce(:BUFFERMONTO5,0) +   coalesce(:AUXMONTOSUMARIZADO1,0);
               end



                monto = coalesce(:buffermonto1,0) - coalesce(:buffermonto2,0) - coalesce(:buffermonto3,0) - coalesce(:buffermonto4,0) - coalesce(:buffermonto5,0);

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



         -- iva venta
        if( :tipolineapolizaid = 12) then
        begin            
             HDR_CONCEPTO1 = 'IVA,CRED/CONT: CRED,ESTATUS:COMP,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ'  ;
             HDR_CONCEPTO2 = '';
             NUMLINEA = :NUMERO + 1; DTL_ORDEN = 0;
                    
               BUFFERMONTO1 = 0;
                -- suma todos los ivas
               for
                select (coalesce(docto.iva ,0.00) * case when docto.tipodoctoid = 21 then 1.00 else -1.00 end)  subtotal       
                           ,docto.id , docto.fecha ,  docto.folio, docto.referencia
                           ,coalesce(docto.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,docto.hatenidocredito
                           ,coalesce(plazo.clave, '') plazo
                           ,case when (docto.tipodoctoid = 31 and coalesce(docto.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado
                from docto
                left join plazo on plazo.id = docto.plazoid
                where docto.fecha = :fecha and
                (((coalesce(docto.hatenidocredito,'N') = 'S' or  ((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N' ))
                   and docto.tipodoctoid in (21) and docto.estatusdoctoid = 1
                  )
                 or  (coalesce(docto.hatenidocredito,'N') = 'N' and docto.tipodoctoid in (21,23) and docto.estatusdoctoid in (1,2))
                )
                and coalesce(docto.esfacturaelectronica,'N') = :esfact 
                and coalesce(plazo.clave, '') <> 'T'
                into  :AUXMONTOSUMARIZADO1   
                        ,:DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1    
                        ,:DTL_NIV1_REFERENCIA2,:DTL_NIV1_REFERENCIA3,:DTL_NIV1_REFERENCIA4,:DTL_NIV1_REFERENCIA5
               do
               begin
               
                    DTL_NIV1_CONCEPTO =  'IVA VENTA,CRED/CONT: CRED,ESTATUS:COMP,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ';
                    DTL_NIV1_NOMBREID1 = 'VENTA ID';
                    DTL_NIV1_NOMBREFECHA1 = 'FECHA VENTA';
                    DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                    DTL_NIV1_MONTO1  = :AUXMONTOSUMARIZADO1;
                    DTL_NIV1_NOMBREID2 = 'FOLIO';
                    DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA';

                    
                    DTL_NIV2_CONCEPTO =  '';
                    DTL_NIV2_NOMBREID1 = '';
                    DTL_NIV2_NOMBREFECHA1 = '';
                    DTL_NIV2_NOMBREMONTO1 = '';
                    DTL_NIV2_MONTO1  = 0;
                    DTL_NIV2_NOMBREID2 = '';
                    DTL_NIV2_NOMBREREFERENCIA1 = '';
                    DTL_NIV2_NOMBREREFERENCIA2 = '';
                    
                    DTL_NIV1_NOMBREREFERENCIA2 = 'ESFACTURA';
                    DTL_NIV1_NOMBREREFERENCIA3 = 'HATENIDOCREDITO';
                    DTL_NIV1_NOMBREREFERENCIA4 = 'PLAZO';
                    DTL_NIV1_NOMBREREFERENCIA5 = 'ESTRASLADO';


                    DTL_ORDEN = :DTL_ORDEN + 1;
                    IF(:MOSTRARDETALLE = 'S') THEN
                    BEGIN
                        SUSPEND;
                    END
                    BUFFERMONTO1   = coalesce(:BUFFERMONTO1,0) +   coalesce(:AUXMONTOSUMARIZADO1,0);
               end

                      
               BUFFERMONTO2 = 0;
                --restale las devoluciones que apliquen 
               for
                select  (coalesce(doctodev.iva ,0.0))   subtotal    
                           ,doctodev.id , doctodev.fecha ,  doctodev.folio, doctodev.referencia   
                           ,coalesce(doctodev.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,doctodev.hatenidocredito
                           ,coalesce(plazo.clave, '') plazo
                           ,case when (doctodev.tipodoctoid = 31 and coalesce(doctodev.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado       
                           ,docto.id , docto.fecha ,  docto.folio, docto.referencia
                           ,coalesce(docto.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,docto.hatenidocredito
                           ,coalesce(plazo.clave, '') plazo
                           ,case when (docto.tipodoctoid = 31 and coalesce(docto.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado
                from docto
                inner join docto doctodev on doctodev.tipodoctoid = 22 and docto.id = doctodev.doctorefid and doctodev.estatusdoctoid = 1  and extract(month from docto.fecha) = extract(month from doctodev.fecha)
                left join plazo on plazo.id = docto.plazoid
                where doctodev.fecha = :fecha and
                (not (coalesce(docto.hatenidocredito,'N') = 'S' or  ((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N' )))
                 and docto.tipodoctoid in (21) and docto.estatusdoctoid = 1
                and coalesce(docto.esfacturaelectronica,'N') = :esfact
                and :esfact = 'N'                 
                and coalesce(plazo.clave, '') <> 'T'
                into  :AUXMONTOSUMARIZADO1   
                        ,:DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1
                        ,:DTL_NIV1_REFERENCIA2,:DTL_NIV1_REFERENCIA3,:DTL_NIV1_REFERENCIA4,:DTL_NIV1_REFERENCIA5  
                        ,:DTL_NIV2_ID1 ,:DTL_NIV2_FECHA1 ,:DTL_NIV2_ID2, :DTL_NIV2_REFERENCIA1
                        ,:DTL_NIV2_REFERENCIA2,:DTL_NIV2_REFERENCIA3,:DTL_NIV2_REFERENCIA4,:DTL_NIV2_REFERENCIA5
               do
               begin
               
                    DTL_NIV1_CONCEPTO =  'IVA DEVOLUCION MISMO MES, FECHA:DEVOLUCION, CRED/CONT: CONT,ESTATUS:COMP,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ';
                    DTL_NIV1_NOMBREID1 = 'DEVOLUCION ID';
                    DTL_NIV1_NOMBREFECHA1 = 'FECHA DEVOLUCION';
                    DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                    DTL_NIV1_MONTO1  = :AUXMONTOSUMARIZADO1 * -1;
                    DTL_NIV1_NOMBREID2 = 'FOLIO';
                    DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA';


                    DTL_NIV2_CONCEPTO =  'IVA VENTA MISMO MES, FECHA:DEVOLUCION, CRED/CONT: CONT,ESTATUS:COMP,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ';
                    DTL_NIV2_NOMBREID1 = 'VENTA ID';
                    DTL_NIV2_NOMBREFECHA1 = 'FECHA VENTA';
                    DTL_NIV2_NOMBREMONTO1 = 'TOTAL';
                    DTL_NIV2_MONTO1  = :AUXMONTOSUMARIZADO1;
                    DTL_NIV2_NOMBREID2 = 'FOLIO';
                    
                    DTL_NIV1_NOMBREREFERENCIA2 = 'ESFACTURA';
                    DTL_NIV1_NOMBREREFERENCIA3 = 'HATENIDOCREDITO';
                    DTL_NIV1_NOMBREREFERENCIA4 = 'PLAZO';
                    DTL_NIV1_NOMBREREFERENCIA5 = 'ESTRASLADO';
                       
                    DTL_NIV2_NOMBREREFERENCIA2 = 'ESFACTURA';
                    DTL_NIV2_NOMBREREFERENCIA3 = 'HATENIDOCREDITO';
                    DTL_NIV2_NOMBREREFERENCIA4 = 'PLAZO';
                    DTL_NIV2_NOMBREREFERENCIA5 = 'ESTRASLADO';

                    DTL_ORDEN = :DTL_ORDEN + 1;
                    IF(:MOSTRARDETALLE = 'S') THEN
                    BEGIN
                        SUSPEND;
                    END

                    BUFFERMONTO2   = coalesce(:BUFFERMONTO2,0) +   coalesce(:AUXMONTOSUMARIZADO1,0);
               end


                
                --restale las devoluciones de credito sobre ventas de otros meses
                --select sum(coalesce(doctodev.iva ,0.00))   subtotal
                --from docto doctodev
                --inner join docto on docto.tipodoctoid = 21 and docto.id = doctodev.doctorefid and docto.estatusdoctoid = 1  and extract(month from docto.fecha) <> extract(month from doctodev.fecha)
                --left join plazo on plazo.id = docto.plazoid
                --where doctodev.fecha = :fecha and
               -- (coalesce(docto.hatenidocredito,'N') = 'S' or  ((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N' ))
                -- and doctodev.tipodoctoid in (22) and doctodev.estatusdoctoid = 1
                --and coalesce(docto.esfacturaelectronica,'N') = :esfact 
                --and coalesce(plazo.clave, '') <> 'T'
                --into :BUFFERMONTO3;
                BUFFERMONTO3 = 0;  --REVISAR TOLEDO
                   
               BUFFERMONTO4 = 0;      
               for
                select (coalesce(doctodev.iva,0))   subtotal    
                           ,doctodev.id , doctodev.fecha ,  doctodev.folio, doctodev.referencia   
                           ,coalesce(doctodev.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,doctodev.hatenidocredito
                           ,coalesce(plazo.clave, '') plazo
                           ,case when (doctodev.tipodoctoid = 31 and coalesce(doctodev.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado       
                           ,docto.id , docto.fecha ,  docto.folio, docto.referencia
                           ,coalesce(docto.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,docto.hatenidocredito
                           ,coalesce(plazo.clave, '') plazo
                           ,case when (docto.tipodoctoid = 31 and coalesce(docto.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado
                from docto
                inner join docto doctodev on doctodev.tipodoctoid = 22 and docto.id = doctodev.doctorefid and doctodev.estatusdoctoid = 1  and extract(month from docto.fecha) = extract(month from doctodev.fecha)
                left join plazo on plazo.id = docto.plazoid   
                where docto.fecha = :fecha  and
                ((coalesce(docto.hatenidocredito,'N') = 'S' or  ((coalesce(docto.subtipodoctoid,0) in (7,8) or docto.tipodoctoid = 31) and coalesce(docto.esfacturaelectronica,'N') = 'N')))
                and
                docto.tipodoctoid in (21) and docto.estatusdoctoid = 1
                and coalesce(docto.esfacturaelectronica,'N') = :esfact
                and :esfact = 'N'
                and coalesce(plazo.clave, '') <> 'T'  
                into  :AUXMONTOSUMARIZADO1  
                        ,:DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1   
                        ,:DTL_NIV1_REFERENCIA2,:DTL_NIV1_REFERENCIA3,:DTL_NIV1_REFERENCIA4,:DTL_NIV1_REFERENCIA5
                        ,:DTL_NIV2_ID1 ,:DTL_NIV2_FECHA1 ,:DTL_NIV2_ID2, :DTL_NIV2_REFERENCIA1
                        ,:DTL_NIV2_REFERENCIA2,:DTL_NIV2_REFERENCIA3,:DTL_NIV2_REFERENCIA4,:DTL_NIV2_REFERENCIA5
               do
               begin
               
                    DTL_NIV1_CONCEPTO = 'IVA DEVOLUCION DIF MES, FECHA:VENTA, CRED/CONT: CRED,ESTATUS:COMP,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ';
                    DTL_NIV1_NOMBREID1 = 'DEVOLUCION ID';
                    DTL_NIV1_NOMBREFECHA1 = 'DEVOLUCION VENTA';
                    DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                    DTL_NIV1_MONTO1  = :AUXMONTOSUMARIZADO1 * -1;
                    DTL_NIV1_NOMBREID2 = 'FOLIO';
                    DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA';
                    
                    DTL_NIV2_CONCEPTO =  'IVA VENTA DIF MES, FECHA:VENTA, CRED/CONT: CRED,ESTATUS:COMP,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ';
                    DTL_NIV2_NOMBREID1 = 'VENTA ID';
                    DTL_NIV2_NOMBREFECHA1 = 'FECHA VENTA';
                    DTL_NIV2_NOMBREMONTO1 = 'TOTAL';
                    DTL_NIV2_MONTO1  = :AUXMONTOSUMARIZADO1;
                    DTL_NIV2_NOMBREID2 = 'FOLIO';
                    DTL_NIV2_NOMBREREFERENCIA1 = 'REFERENCIA';

                    
                    DTL_NIV1_NOMBREREFERENCIA2 = 'ESFACTURA';
                    DTL_NIV1_NOMBREREFERENCIA3 = 'HATENIDOCREDITO';
                    DTL_NIV1_NOMBREREFERENCIA4 = 'PLAZO';
                    DTL_NIV1_NOMBREREFERENCIA5 = 'ESTRASLADO';
                       
                    DTL_NIV2_NOMBREREFERENCIA2 = 'ESFACTURA';
                    DTL_NIV2_NOMBREREFERENCIA3 = 'HATENIDOCREDITO';
                    DTL_NIV2_NOMBREREFERENCIA4 = 'PLAZO';
                    DTL_NIV2_NOMBREREFERENCIA5 = 'ESTRASLADO';

                    DTL_ORDEN = :DTL_ORDEN + 1;
                    IF(:MOSTRARDETALLE = 'S') THEN
                    BEGIN
                        SUSPEND;
                    END

                    BUFFERMONTO4   = coalesce(:BUFFERMONTO4,0) +   coalesce(:AUXMONTOSUMARIZADO1,0);
               end

                
               BUFFERMONTO5 = 0;
                --restale los traslados a clientes con mismo rfc  cuando no es factura electronica   
               for
                select (coalesce(docto.iva,0))   subtotal      
                           ,docto.id , docto.fecha ,  docto.folio, docto.referencia  
                           ,coalesce(docto.esfacturaelectronica,'N') || ' - ' || coalesce(docto.timbradouuid,'') esfactura
                           ,docto.hatenidocredito
                           ,coalesce(plazo.clave, '') plazo
                           ,case when (docto.tipodoctoid = 31 and coalesce(docto.subtipodoctoid,0) not in (7,8)) then 'S' else 'N' end estraslado
                from docto
                left join plazo on plazo.id = docto.plazoid
                where docto.fecha = :fecha and
                docto.tipodoctoid in (21)
                and coalesce(docto.subtipodoctoid,0) in (7,8)
                and docto.estatusdoctoid = 1
                and coalesce(docto.esfacturaelectronica,'N') = :esfact
                and :esfact = 'N'
                and coalesce(plazo.clave, '') <> 'T'
                into  :AUXMONTOSUMARIZADO1   
                        ,:DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1 
                        ,:DTL_NIV1_REFERENCIA2,:DTL_NIV1_REFERENCIA3,:DTL_NIV1_REFERENCIA4,:DTL_NIV1_REFERENCIA5
               do
               begin     
                    DTL_NIV1_CONCEPTO = 'IVA TRASLADO, FECHA:TRSLADO, CRED/CONT: TODOS,ESTATUS:COMP,FACT/REM:' || CASE WHEN COALESCE(:ESFACT,'N') = 'S' THEN 'FACT' ELSE 'REM' END || ', PZO: NO TEQ';
                    DTL_NIV1_NOMBREID1 = 'TRASLADO ID';
                    DTL_NIV1_NOMBREFECHA1 = 'TRASLADO VENTA';
                    DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                    DTL_NIV1_MONTO1  = :AUXMONTOSUMARIZADO1 * -1;
                    DTL_NIV1_NOMBREID2 = 'FOLIO';
                    DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA';

                    
                    DTL_NIV2_CONCEPTO =  '';
                    DTL_NIV2_NOMBREID1 = '';
                    DTL_NIV2_NOMBREFECHA1 = '';
                    DTL_NIV2_NOMBREMONTO1 = '';
                    DTL_NIV2_MONTO1  = 0;
                    DTL_NIV2_NOMBREID2 = '';
                    DTL_NIV2_NOMBREREFERENCIA1 = '';
                    DTL_NIV2_NOMBREREFERENCIA2 = '';
                    
                    DTL_NIV1_NOMBREREFERENCIA2 = 'ESFACTURA';
                    DTL_NIV1_NOMBREREFERENCIA3 = 'HATENIDOCREDITO';
                    DTL_NIV1_NOMBREREFERENCIA4 = 'PLAZO';
                    DTL_NIV1_NOMBREREFERENCIA5 = 'ESTRASLADO';


                    DTL_ORDEN = :DTL_ORDEN + 1;
                    IF(:MOSTRARDETALLE = 'S') THEN
                    BEGIN
                        SUSPEND;
                    END

                    BUFFERMONTO5   = coalesce(:BUFFERMONTO5,0) +   coalesce(:AUXMONTOSUMARIZADO1,0);
               end


                          
                monto = coalesce(:buffermonto1,0) - coalesce(:buffermonto2,0) - coalesce(:buffermonto3,0) - coalesce(:buffermonto4,0) - coalesce(:buffermonto5,0);

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










   if (:numero = 0) then
   begin


   end


END