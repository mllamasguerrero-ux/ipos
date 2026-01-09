create or alter procedure POLIZALINEA_DET_PVC (
    FECHA D_FECHA)
returns (
    NUMERO integer,
    NUMCUENTA D_NOMBRE,
    LEYENDA D_STDTEXT_SHORT,
    TIPOENTRADA D_DIAS,
    MONTO D_PRECIO)
as
declare variable CLIENTEID D_FK;
declare variable CUENTACONTPAQ D_STDTEXT_MEDIUM;
declare variable CUENTASUMAVENTA D_STDTEXT_MEDIUM;
declare variable CUENTASUMANOTACREDITO D_STDTEXT_MEDIUM;
declare variable CUENTAIMPUESTO D_STDTEXT_MEDIUM;
BEGIN
   NUMERO = 0;
   LEYENDA = '';


      SELECT FIRST 1 CUENTAIMPUESTOS, CUENTASUMAVENTAS, CUENTASUMNOTASCREDITO
      FROM CUENTASPVC
      INTO :CUENTAIMPUESTO, :CUENTASUMAVENTA, :CUENTASUMANOTACREDITO;


     --VENTAS


     for select docto.personaid, persona.cuentacontpaq from docto
                        left join persona on persona.id = docto.personaid
                        where coalesce(cast(docto.timbradofechafactura as date), docto.fecha) = :fecha
                        and docto.tipodoctoid in (21,22,23,24) and docto.estatusdoctoid in (1,2)
        group by docto.personaid , persona.cuentacontpaq
        into :CLIENTEID , :CUENTACONTPAQ
        DO
        BEGIN
               -- calcula el total de las ventas (ventas - cancelaciones)

                     select sum( COALESCE(docto.total,0) * (case when docto.tipodoctoid = 21 then 1 else -1 end))
                        from docto
                        where coalesce(cast(docto.timbradofechafactura as date), docto.fecha) = :fecha
                        and docto.tipodoctoid in (21,23) and docto.estatusdoctoid in (1,2)
                        and docto.personaid = :CLIENTEID
                        -- and coalesce(docto.hatenidocredito,'N') = 'N' ( si quiere solo las de contado , descomentar)
                        into :monto;

                     
                    if(coalesce(:monto,0) <> 0) then
                    begin
                        NUMERO = :NUMERO + 1;
                        NUMCUENTA = :CUENTACONTPAQ;
                        TIPOENTRADA = 1;
                        suspend;
                    end

                   -- calcula el subtotal (ventas - cancelaciones)

                     select sum( COALESCE(docto.subtotal,0) * (case when docto.tipodoctoid = 21 then 1 else -1 end))
                        from docto
                        where coalesce(cast(docto.timbradofechafactura as date), docto.fecha) = :fecha
                        and docto.tipodoctoid in (21,23) and docto.estatusdoctoid in (1,2)
                        and docto.personaid = :CLIENTEID     
                        -- and coalesce(docto.hatenidocredito,'N') = 'N' ( si quiere solo las de contado , descomentar)
                        into :monto ;
                     
                    if(coalesce(:monto,0) <> 0) then
                    begin
                        NUMERO = :NUMERO + 1; 
                        NUMCUENTA = :CUENTASUMAVENTA;
                        TIPOENTRADA = 2;
                        suspend;
                    end



                    
                   -- calcula el IMPUESTO (ventas - cancelaciones)

                     select sum( COALESCE(docto.impuesto,0) * (case when docto.tipodoctoid = 21 then 1 else -1 end))
                        from docto
                        where coalesce(cast(docto.timbradofechafactura as date), docto.fecha) = :fecha
                        and docto.tipodoctoid in (21,23) and docto.estatusdoctoid in (1,2)
                        and docto.personaid = :CLIENTEID  
                        -- and coalesce(docto.hatenidocredito,'N') = 'N' ( si quiere solo las de contado , descomentar)
                        into :monto ;
                     
                    if(coalesce(:monto,0) <> 0) then
                    begin
                        NUMERO = :NUMERO + 1; 
                        NUMCUENTA = :CUENTAIMPUESTO;
                        TIPOENTRADA = 2;
                        suspend;
                    end




                    
               -- calcula el total de las notas de credito (notas de credito - cancelaciones de nc)

                     select sum( COALESCE(docto.total,0) * (case when docto.tipodoctoid = 22 then 1 else -1 end))
                        from docto
                        where coalesce(cast(docto.timbradofechafactura as date), docto.fecha) = :fecha
                        and docto.tipodoctoid in (22,24) and docto.estatusdoctoid in (1,2)
                        and docto.personaid = :CLIENTEID   
                        -- and coalesce(docto.hatenidocredito,'N') = 'N' ( si quiere solo las de contado , descomentar)
                        into :monto  ;

                     
                    if(coalesce(:monto,0) <> 0) then
                    begin
                        NUMERO = :NUMERO + 1;
                        NUMCUENTA = :CUENTACONTPAQ;
                        TIPOENTRADA = 2;
                        suspend;
                    end

                   -- calcula el subtotal notas de credito (notas de credito - cancelaciones de nc)

                     select sum( COALESCE(docto.subtotal,0) * (case when docto.tipodoctoid = 22 then 1 else -1 end))
                        from docto
                        where coalesce(cast(docto.timbradofechafactura as date), docto.fecha) = :fecha
                        and docto.tipodoctoid in (22,24) and docto.estatusdoctoid in (1,2)
                        and docto.personaid = :CLIENTEID 
                        -- and coalesce(docto.hatenidocredito,'N') = 'N' ( si quiere solo las de contado , descomentar)
                        into :monto ;
                     
                    if(coalesce(:monto,0) <> 0) then
                    begin
                        NUMERO = :NUMERO + 1; 
                        NUMCUENTA = :CUENTASUMANOTACREDITO;
                        TIPOENTRADA = 1;
                        suspend;
                    end



                    
                   -- calcula el IMPUESTO notas de credito (notas de credito - cancelaciones de nc)

                     select sum( COALESCE(docto.impuesto,0) * (case when docto.tipodoctoid = 22 then 1 else -1 end))
                        from docto
                        where coalesce(cast(docto.timbradofechafactura as date), docto.fecha) = :fecha
                        and docto.tipodoctoid in (22,24) and docto.estatusdoctoid in (1,2)
                        and docto.personaid = :CLIENTEID 
                        -- and coalesce(docto.hatenidocredito,'N') = 'N' ( si quiere solo las de contado , descomentar)
                        into :monto ;
                     
                    if(coalesce(:monto,0) <> 0) then
                    begin
                        NUMERO = :NUMERO + 1; 
                        NUMCUENTA = :CUENTAIMPUESTO;
                        TIPOENTRADA = 1;
                        suspend;
                    end


        END











END