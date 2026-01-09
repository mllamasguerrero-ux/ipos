create or alter procedure POLIZALINEA_DET (
    FECHA D_FECHA)
returns (
    NUMERO integer,
    NUMCUENTA D_NOMBRE,
    LEYENDA D_STDTEXT_SHORT,
    TIPOENTRADA D_DIAS,
    MONTO D_PRECIO)
as
declare variable TIPOLINEAPOLIZAID D_FK;
declare variable SUMARIZADO D_BOOLCN;
declare variable MANEJATASA D_BOOLCN;
declare variable MANEJAFORMAPAGO D_BOOLCN;
declare variable MANEJAESFACT D_BOOLCN;
declare variable ORDENTIPOLINEA integer;
declare variable CLAVECUENTA D_CLAVE;
declare variable FORMAPAGOSATID D_FK;
declare variable ESFACT D_BOOLCN_I;
declare variable TASA D_PORCENTAJE;
declare variable TIPOLINEAPOLIZAESPECIALID D_FK;
declare variable ORDENCUENTA integer;
declare variable BUFFERMONTO1 D_PRECIO;
declare variable BUFFERMONTO2 D_PRECIO;
declare variable CUADRE D_PRECIO;
BEGIN
   NUMERO = 0;
   CUADRE = 0;




   for
    select
        tipolineapoliza.id,
        tipolineapoliza.sumarizado ,
        tipolineapoliza.manejatasa ,
        tipolineapoliza.manejaformapago ,
        tipolineapoliza.manejaesfact ,
        tipolineapoliza.orden,
        tipolineapoliza.tipoentrada,
        cuenta.clave ,
        cuenta.numucuenta ,
        cuenta.formapagosatid ,
        cuenta.esfact ,
        cuenta.tasa ,
        cuenta.tipolineapolizaespecialid ,
        coalesce(cuenta.leyenda,'') ,
        cuenta.orden

        from tipolineapoliza inner join cuenta on cuenta.tipolineapolizaid = tipolineapoliza.id
        where cuenta.activo = 'S' and tipolineapoliza.activo = 'S'
        into
        :tipolineapolizaid ,
        :sumarizado ,
        :manejatasa ,
        :manejaformapago ,
        :manejaesfact ,
        :ordentipolinea ,
        :tipoentrada ,
        :clavecuenta ,
        :numcuenta ,
        :formapagosatid ,
        :esfact ,
        :tasa ,
        :tipolineapolizaespecialid ,
        :leyenda ,
        :ordencuenta

    do
    begin


        monto = 0;

        --Retiros
        if( :tipolineapolizaid = 1) then
        begin
           if(coalesce(:sumarizado,'N') = 'S') then
           begin

                select sum(coalesce(docto.total, 0) * case when docto.tipodoctoid = 62 then 1 else -1 end  )
                from docto
                where fecha = :fecha and tipodoctoid in (62,64) and estatusdoctoid in (1,2)
                into :monto;

                if(coalesce(:monto,0) <> 0) then
                begin
                    NUMERO = :NUMERO + 1;
                    CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                    suspend;
                end
           end
           else
           begin
                for
                    select coalesce(docto.total, 0) * case when docto.tipodoctoid = 62 then 1 else -1 end  monto
                    from docto
                    where fecha = :fecha and tipodoctoid in (62,64) and estatusdoctoid in (1,2)
                    into :monto
                 do
                 begin
                     
                    if(coalesce(:monto,0) <> 0) then
                    begin
                        NUMERO = :NUMERO + 1;   
                        CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                        suspend;
                    end
                 end

           end

        end



         --gastos
        if( :tipolineapolizaid = 2) then
        begin
           if(coalesce(:sumarizado,'N') = 'S') then
           begin

                select sum(coalesce(docto.total, 0) * case when docto.tipodoctoid = 63 then 1 else -1 end  )
                from docto
                where fecha = :fecha and tipodoctoid in (63,65) and estatusdoctoid in (1,2)
                into :monto;

                if(coalesce(:monto,0) <> 0) then
                begin
                    NUMERO = :NUMERO + 1;  
                    CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                    suspend;
                end
           end
           else
           begin
                for
                    select coalesce(docto.total, 0) * case when docto.tipodoctoid = 62 then 1 else -1 end  monto
                    from docto
                    where fecha = :fecha and tipodoctoid in (63,65) and estatusdoctoid in (1,2)
                    into :monto
                 do
                 begin
                     
                    if(coalesce(:monto,0) <> 0) then
                    begin
                        NUMERO = :NUMERO + 1;  
                        CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                        suspend;
                    end
                 end

           end

        end

          
         --venta credito
         if( :tipolineapolizaid = 6) then
        begin
                select coalesce(docto.total,0)  - sum(case when coalesce(docto.esfacturaelectronica,'N') = 'S' then 0 else coalesce(doctodev.total,0) end )
                from docto
                left join docto doctodev on doctodev.tipodoctoid = 22 and docto.id = doctodev.doctorefid and doctodev.estatusdoctoid = 1  and extract(month from docto.fecha) = extract(month from doctodev.fecha)
                where docto.fecha = :fecha and
                coalesce(docto.hatenidocredito,'N') = 'S' and docto.tipodoctoid in (21) and docto.estatusdoctoid = 1
                and coalesce(docto.esfacturaelectronica,'N') = :esfact
                group by docto.id, docto.total
                into :monto;


                if(coalesce(:monto,0) <> 0) then
                begin
                    NUMERO = :NUMERO + 1;
                    CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                    suspend;
                end

        end



         --venta contado
        if( :tipolineapolizaid = 10) then
        begin
                for
                     select sum(coalesce(doctopago.importe,0))  subtotal
                        from docto
                        inner join doctopago on doctopago.doctoid = docto.id
                        where docto.fecha = :fecha and coalesce(docto.hatenidocredito,'N') = 'N'
                        and docto.tipodoctoid in (21) and docto.estatusdoctoid in (1,2)
                        and coalesce(docto.esfacturaelectronica,'N') = :esfact and doctopago.tipopagoid = 1
                        and coalesce(doctopago.formapagosatid,0) = :formapagosatid
                        group by docto.id
                        into :monto
                 do
                 begin
                     
                    if(coalesce(:monto,0) <> 0) then
                    begin
                        NUMERO = :NUMERO + 1;
                        CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                        suspend;
                    end
                 end



                 
                for
                     select sum(coalesce(doctopago.importe,0) * -1)   subtotal
                        from docto
                        inner join doctopago on doctopago.doctoid = docto.id
                        where docto.fecha = :fecha and coalesce(docto.hatenidocredito,'N') = 'N'
                        and docto.tipodoctoid in (23) and docto.estatusdoctoid in (1,2)
                        and coalesce(docto.esfacturaelectronica,'N') = :esfact and doctopago.tipopagoid = 2
                        and coalesce(doctopago.formapagosatid,0) = :formapagosatid
                        group by docto.id
                        into :monto
                 do
                 begin
                     
                    if(coalesce(:monto,0) <> 0) then
                    begin
                        NUMERO = :NUMERO + 1;
                        CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                        suspend;
                    end
                 end



        end



         --subtotales venta
        if( :tipolineapolizaid = 11) then
        begin
                --suma todos los subtotales
                select sum((coalesce(docto.total,0) - coalesce(docto.impuesto ,0)) * case when docto.tipodoctoid = 21 then 1 else -1 end)  subtotal
                from docto
                where docto.fecha = :fecha and
                ((coalesce(docto.hatenidocredito,'N') = 'S' and docto.tipodoctoid in (21) and docto.estatusdoctoid = 1)
                 or  (coalesce(docto.hatenidocredito,'N') = 'N' and docto.tipodoctoid in (21,23) and docto.estatusdoctoid in (1,2)))
                and coalesce(docto.esfacturaelectronica,'N') = :esfact
                into :BUFFERMONTO1;


                --restale las devoluciones que apliquen
                select sum((coalesce(doctodev.total,0) - coalesce(doctodev.impuesto ,0)) )  subtotal
                from docto
                inner join docto doctodev on doctodev.tipodoctoid = 22 and docto.id = doctodev.doctorefid and doctodev.estatusdoctoid = 1  and extract(month from docto.fecha) = extract(month from doctodev.fecha)
                where docto.fecha = :fecha and
                coalesce(docto.hatenidocredito,'N') = 'S' and docto.tipodoctoid in (21) and docto.estatusdoctoid = 1
                and coalesce(docto.esfacturaelectronica,'N') = :esfact
                into :BUFFERMONTO2;

                monto = coalesce(:buffermonto1,0) - coalesce(:buffermonto2,0);

                if(coalesce(:monto,0) <> 0) then
                begin
                    NUMERO = :NUMERO + 1;  
                    CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                    suspend;
                end


        end




         -- iva venta
        if( :tipolineapolizaid = 12) then
        begin
                -- suma todos los ivas
                select sum(coalesce(docto.iva ,0) * case when docto.tipodoctoid = 21 then 1 else -1 end)  subtotal
                from docto
                where docto.fecha = :fecha and
                ((coalesce(docto.hatenidocredito,'N') = 'S' and docto.tipodoctoid in (21) and docto.estatusdoctoid = 1)
                 or  (coalesce(docto.hatenidocredito,'N') = 'N' and docto.tipodoctoid in (21,23) and docto.estatusdoctoid in (1,2)))
                and coalesce(docto.esfacturaelectronica,'N') = :esfact
                into :BUFFERMONTO1;

                               
                --restale las devoluciones que apliquen
                select  sum(coalesce(doctodev.iva ,0))   subtotal
                from docto
                inner join docto doctodev on doctodev.tipodoctoid = 22 and docto.id = doctodev.doctorefid and doctodev.estatusdoctoid = 1  and extract(month from docto.fecha) = extract(month from doctodev.fecha)
                where docto.fecha = :fecha and
                coalesce(docto.hatenidocredito,'N') = 'S' and docto.tipodoctoid in (21) and docto.estatusdoctoid = 1
                and coalesce(docto.esfacturaelectronica,'N') = :esfact
                into :BUFFERMONTO2;

                          
                monto = coalesce(:buffermonto1,0) - coalesce(:buffermonto2,0);

                if(coalesce(:monto,0) <> 0) then
                begin
                    NUMERO = :NUMERO + 1;  
                    CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                    suspend;
                end

        end

         -- ieps venta
        if( :tipolineapolizaid = 13) then
        begin

                --suma todos los ieps
                select sum(coalesce(movto.ieps ,0) * case when docto.tipodoctoid = 21 then 1 else -1 end)  subtotal
                from docto     
                inner join docto doctodev on doctodev.tipodoctoid = 22 and docto.id = doctodev.doctorefid and doctodev.estatusdoctoid = 1  and extract(month from docto.fecha) = extract(month from doctodev.fecha)
                inner join movto on movto.doctoid = docto.id
                where docto.fecha = :fecha and
                ((coalesce(docto.hatenidocredito,'N') = 'S' and docto.tipodoctoid in (21) and docto.estatusdoctoid = 1)
                 or  (coalesce(docto.hatenidocredito,'N') = 'N' and docto.tipodoctoid in (21,23) and docto.estatusdoctoid in (1,2)))
                and coalesce(docto.esfacturaelectronica,'N') = :esfact
                and movto.tasaieps = :tasa
                into :BUFFERMONTO1;

                            
                --restale las devoluciones que apliquen 
                select sum(coalesce(movtodev.ieps ,0) )   subtotal
                from docto  
                inner join docto doctodev on doctodev.tipodoctoid = 22 and docto.id = doctodev.doctorefid and doctodev.estatusdoctoid = 1  and extract(month from docto.fecha) = extract(month from doctodev.fecha)
                inner join movto movtodev on movtodev.doctoid = doctodev.id
                where docto.fecha = :fecha and
                ((coalesce(docto.hatenidocredito,'N') = 'S' and docto.tipodoctoid in (21) and docto.estatusdoctoid = 1)
                 or  (coalesce(docto.hatenidocredito,'N') = 'N' and docto.tipodoctoid in (21,23) and docto.estatusdoctoid in (1,2)))
                and coalesce(docto.esfacturaelectronica,'N') = :esfact
                and movtodev.tasaieps = :tasa
                into :BUFFERMONTO2;


                       
                monto = coalesce(:buffermonto1,0) - coalesce(:buffermonto2,0);


                if(coalesce(:monto,0) <> 0) then
                begin
                    NUMERO = :NUMERO + 1; 
                    CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                    suspend;
                end

        end




        
         --devolucion  contado
        if( :tipolineapolizaid = 15) then
        begin
                for
                     select sum(coalesce(docto.total,0))  subtotal
                        from docto
                        where docto.fecha = :fecha and coalesce(docto.hatenidocredito,'N') = 'N'
                        and docto.tipodoctoid in (22) and docto.estatusdoctoid in (1,2)
                        and coalesce(docto.esfacturaelectronica,'N') = :esfact
                        group by docto.id
                        into :monto
                 do
                 begin
                     
                    if(coalesce(:monto,0) <> 0) then
                    begin
                        NUMERO = :NUMERO + 1;  
                        CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                        suspend;
                    end
                 end



                 
                for
                     select sum(coalesce(docto.total,0) * -1)   subtotal
                        from docto
                        where docto.fecha = :fecha and coalesce(docto.hatenidocredito,'N') = 'N'
                        and docto.tipodoctoid in (24) and docto.estatusdoctoid in (1,2)
                        and coalesce(docto.esfacturaelectronica,'N') = :esfact
                        group by docto.id
                        into :monto
                 do
                 begin
                     
                    if(coalesce(:monto,0) <> 0) then
                    begin
                        NUMERO = :NUMERO + 1; 
                        CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                        suspend;
                    end
                 end



        end



         --devolucion  credito
        if( :tipolineapolizaid = 14) then
        begin
                for
                     select sum(coalesce(docto.total,0)) * -1  subtotal
                        from docto
                        left join docto doctoventa on  doctoventa.tipodoctoid = 21 and doctoventa.id = docto.doctorefid
                        where docto.fecha = :fecha and coalesce(docto.hatenidocredito,'N') = 'S'
                        and docto.tipodoctoid in (22) and docto.estatusdoctoid in (1,2)
                        and coalesce(docto.esfacturaelectronica,'N') = :esfact
                        and (:esfact = 'S' or  doctoventa.fecha is null or  extract(month from docto.fecha) <> extract(month from doctoventa.fecha))
                        group by docto.id
                        into :monto
                 do
                 begin
                     
                    if(coalesce(:monto,0) <> 0) then
                    begin
                        NUMERO = :NUMERO + 1;  
                        CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                        suspend;
                    end
                 end



                 
                for
                     select sum(coalesce(docto.importe,0) * -1)  subtotal
                        from docto
                        left join docto doctoventa on doctoventa.tipodoctoid = 21 and doctoventa.id = docto.doctorefid
                        where docto.fecha = :fecha and coalesce(docto.hatenidocredito,'N') = 'S'
                        and docto.tipodoctoid in (24) and docto.estatusdoctoid in (1,2)
                        and coalesce(docto.esfacturaelectronica,'N') = :esfact
                        and (doctoventa.fecha is null or  extract(month from docto.fecha) <> extract(month from doctoventa.fecha))
                        group by docto.id
                        into :monto
                 do
                 begin
                     
                    if(coalesce(:monto,0) <> 0) then
                    begin
                        NUMERO = :NUMERO + 1;  
                        CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                        suspend;
                    end
                 end



        end



        
         --comision bancaria
        if( :tipolineapolizaid = 3) then
        begin

                     select sum(coalesce(doctopago.importe,0) * (coalesce(docto.comisiontarjetaempresa,0)/100))   subtotal
                        from docto
                        inner join doctopago on doctopago.doctoid = docto.id
                        where docto.fecha = :fecha and coalesce(docto.hatenidocredito,'N') = 'N'
                        and docto.tipodoctoid in (21) and docto.estatusdoctoid in (1,2)
                        and coalesce(docto.esfacturaelectronica,'N') = :esfact and doctopago.tipopagoid = 1
                        and coalesce(doctopago.formapagosatid,0) = 4--:formapagosatid
                        group by docto.id
                        into :BUFFERMONTO1;



                     select sum(coalesce(doctopago.importe,0) * (coalesce(docto.comisiontarjetaempresa,0)/100) * -1)   subtotal
                        from docto
                        inner join doctopago on doctopago.doctoid = docto.id
                        where docto.fecha = :fecha and coalesce(docto.hatenidocredito,'N') = 'N'
                        and docto.tipodoctoid in (23) and docto.estatusdoctoid in (1,2)
                        and coalesce(docto.esfacturaelectronica,'N') = :esfact and doctopago.tipopagoid = 2
                        and coalesce(doctopago.formapagosatid,0) = 4--:formapagosatid
                        group by docto.id
                        into :BUFFERMONTO2;

                        monto = coalesce(:buffermonto1,0) - coalesce(:buffermonto2,0);

                        if(coalesce(:monto,0) <> 0) then
                        begin
                            NUMERO = :NUMERO + 1;  
                            CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                            suspend;
                        end
        end



        
         --iva comision bancaria
        if( :tipolineapolizaid = 4) then
        begin

                     select sum(coalesce(doctopago.importe,0) * (coalesce(docto.comisiontarjetaempresa,0)/100) * (coalesce(docto.ivacomisiontarjetaempresa,0)/100))   subtotal
                        from docto
                        inner join doctopago on doctopago.doctoid = docto.id
                        where docto.fecha = :fecha and coalesce(docto.hatenidocredito,'N') = 'N'
                        and docto.tipodoctoid in (21) and docto.estatusdoctoid in (1,2)
                        and coalesce(docto.esfacturaelectronica,'N') = :esfact and doctopago.tipopagoid = 1
                        and coalesce(doctopago.formapagosatid,0) = 4--:formapagosatid
                        group by docto.id
                        into :BUFFERMONTO1;



                     select sum(coalesce(doctopago.importe,0) * (coalesce(docto.comisiontarjetaempresa,0)/100) * (coalesce(docto.ivacomisiontarjetaempresa,0)/100) * -1)   subtotal
                        from docto
                        inner join doctopago on doctopago.doctoid = docto.id
                        where docto.fecha = :fecha and coalesce(docto.hatenidocredito,'N') = 'N'
                        and docto.tipodoctoid in (23) and docto.estatusdoctoid in (1,2)
                        and coalesce(docto.esfacturaelectronica,'N') = :esfact and doctopago.tipopagoid = 2
                        and coalesce(doctopago.formapagosatid,0) = 4--:formapagosatid
                        group by docto.id
                        into :BUFFERMONTO2;

                        monto = coalesce(:buffermonto1,0) - coalesce(:buffermonto2,0);

                        if(coalesce(:monto,0) <> 0) then
                        begin
                            NUMERO = :NUMERO + 1;  
                            CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                            suspend;
                        end
        end


        
         --contra comision y su iva bancaria
        if( :tipolineapolizaid = 5) then
        begin

                     select    sum(coalesce(doctopago.importe,0) * (coalesce(docto.comisiontarjetaempresa,0)/100) * (1 + (coalesce(docto.ivacomisiontarjetaempresa,0)/100)))   subtotal
                        from docto
                        inner join doctopago on doctopago.doctoid = docto.id
                        where docto.fecha = :fecha and coalesce(docto.hatenidocredito,'N') = 'N'
                        and docto.tipodoctoid in (21) and docto.estatusdoctoid in (1,2)
                        and coalesce(docto.esfacturaelectronica,'N') = :esfact and doctopago.tipopagoid = 1
                        and coalesce(doctopago.formapagosatid,0) = :formapagosatid  AND :formapagosatid in (4,28,29)
                        group by docto.id
                        into :BUFFERMONTO1;



                     select   sum(coalesce(doctopago.importe,0) * (coalesce(docto.comisiontarjetaempresa,0)/100) * (1 + (coalesce(docto.ivacomisiontarjetaempresa,0)/100)))   * -1   subtotal
                        from docto
                        inner join doctopago on doctopago.doctoid = docto.id
                        where docto.fecha = :fecha and coalesce(docto.hatenidocredito,'N') = 'N'
                        and docto.tipodoctoid in (23) and docto.estatusdoctoid in (1,2)
                        and coalesce(docto.esfacturaelectronica,'N') = :esfact and doctopago.tipopagoid = 2
                        and coalesce(doctopago.formapagosatid,0) = :formapagosatid   AND :formapagosatid in (4,28,29)
                        group by docto.id
                        into :BUFFERMONTO2;

                        monto = coalesce(:buffermonto1,0) - coalesce(:buffermonto2,0);

                        if(coalesce(:monto,0) <> 0) then
                        begin
                            NUMERO = :NUMERO + 1;      
                            CUADRE = CUADRE + (:MONTO * (CASE WHEN :TIPOENTRADA = 1 THEN -1 ELSE 1 END));
                            suspend;
                        end
        end


        
        if( :tipolineapolizaid = 16) then
        begin      
             monto = :CUADRE;

             if(coalesce(:monto,0) <> 0) then
             begin
                    NUMERO = :NUMERO + 1;
                    suspend;
             end
        END


    end


   /*FOR SELECT

   FROM MOVTO M
   WHERE D.ESTATUSDOCTOID = 1
   INTO
      :FECHA
   DO
   BEGIN
      NUMERO = :NUMERO + 1;
      SUSPEND;
   END*/

   if (:numero = 0) then
   begin


   end


END