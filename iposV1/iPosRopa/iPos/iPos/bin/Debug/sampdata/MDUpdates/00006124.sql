create or alter procedure POLIZALINEAV2_DET_PARTE1 (
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

        
        -- pana
        if( :tipolineapolizaid = 21) then
        begin
        
                HDR_CONCEPTO1 = 'DEPOSITO'; HDR_CONCEPTO2 = '';
                NUMLINEA = :NUMERO + 1; DTL_ORDEN = 0;
                for
                    select coalesce(docto.total, 0) * case when docto.tipodoctoid = 66 then 1 else -1 end  monto
                           ,docto.id , docto.fecha ,  docto.folio, docto.referencia
                    from docto
                    where docto.fecha = :fecha
                        and (docto.tipodoctoid in (66))
                        and docto.estatusdoctoid in (1)
                    into :monto ,
                        :DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1
                 do
                 begin
                       
                    DTL_NIV1_CONCEPTO = 'DEPOSITO';
                    DTL_NIV1_NOMBREID1 = 'DEPOSITO ID';
                    DTL_NIV1_NOMBREFECHA1 = 'FECHA DEPOSITO';
                    DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                    DTL_NIV1_MONTO1  = :monto;
                    DTL_NIV1_NOMBREID2 = 'FOLIO';
                    DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA';

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
                    end
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

           
        --Retiros
        if( :tipolineapolizaid = 1) then
        begin

        
            HDR_CONCEPTO1 = 'RETIROS'; HDR_CONCEPTO2 = '';
            NUMLINEA = :NUMERO + 1; DTL_ORDEN = 0;

            monto = 0;
            for
                select (coalesce(docto.total, 0) * case when docto.tipodoctoid in (62) then 1 else -1 end)  monto   
                           ,docto.id , docto.fecha ,  docto.folio, docto.referencia
                from docto
                left join docto doctoref on doctoref.id = docto.doctorefid 
                left join docto doctoref2 on doctoref2.id = doctoref.doctorefid
                where docto.fecha = :fecha
                and ((docto.tipodoctoid in (62/*,64*/)) or
                    (docto.tipodoctoid in (22) and coalesce(docto.hatenidocredito,'N') = 'N' and ( coalesce(doctoref.hatenidocredito,'N') = 'S' ) ) or 
                    (docto.tipodoctoid in (24) and coalesce(docto.hatenidocredito,'N') = 'N' and ( coalesce(doctoref2.hatenidocredito,'N') = 'S' ) )  )
                and docto.estatusdoctoid in (1)
                into :AUXMONTOSUMARIZADO1   ,
                        :DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1
             do
             begin
             
                    DTL_NIV1_CONCEPTO = 'RETIRO';
                    DTL_NIV1_NOMBREID1 = 'RETIRO ID';
                    DTL_NIV1_NOMBREFECHA1 = 'FECHA RETIRO';
                    DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                    DTL_NIV1_MONTO1  = :AUXMONTOSUMARIZADO1;
                    DTL_NIV1_NOMBREID2 = 'FOLIO';
                    DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA';

                    DTL_ORDEN = :DTL_ORDEN + 1;
                    IF(:MOSTRARDETALLE = 'S') THEN
                    BEGIN
                        SUSPEND;
                    END

                monto = :monto + coalesce(:AUXMONTOSUMARIZADO1,0);
             end

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

         --gastos
        if( :tipolineapolizaid = 2) then
        begin     
        
            HDR_CONCEPTO1 = 'GASTOS'; HDR_CONCEPTO2 = '';
            NUMLINEA = :NUMERO + 1; DTL_ORDEN = 0;

            monto = 0;
            for
                select (coalesce(docto.total, 0) * case when docto.tipodoctoid = 63 then 1 else -1 end  )  monto    
                           ,docto.id , docto.fecha ,  docto.folio, docto.referencia
                from docto
                where fecha = :fecha and tipodoctoid in (63/*,65*/) and estatusdoctoid in (1)
                into :AUXMONTOSUMARIZADO1    ,
                        :DTL_NIV1_ID1 ,:DTL_NIV1_FECHA1 ,:DTL_NIV1_ID2, :DTL_NIV1_REFERENCIA1
             do
             begin
             
                    DTL_NIV1_CONCEPTO = 'GASTO';
                    DTL_NIV1_NOMBREID1 = 'GASTO ID';
                    DTL_NIV1_NOMBREFECHA1 = 'FECHA GASTO';
                    DTL_NIV1_NOMBREMONTO1 = 'TOTAL';
                    DTL_NIV1_MONTO1  = :AUXMONTOSUMARIZADO1;
                    DTL_NIV1_NOMBREID2 = 'FOLIO';
                    DTL_NIV1_NOMBREREFERENCIA1 = 'REFERENCIA';

                    DTL_ORDEN = :DTL_ORDEN + 1;
                    IF(:MOSTRARDETALLE = 'S') THEN
                    BEGIN
                        SUSPEND;
                    END

                    monto = :monto + coalesce(:AUXMONTOSUMARIZADO1,0);
             end

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




   if (:numero = 0) then
   begin


   end


END