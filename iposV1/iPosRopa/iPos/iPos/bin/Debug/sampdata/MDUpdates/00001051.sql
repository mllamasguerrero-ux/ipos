CREATE OR ALTER VIEW CORTE_BASE(
    CORTEID,
    TIPODOCTOID,
    TIPOABONOID,
    MISMOCORTE,
    EFECTIVO,
    TARJETA,
    CHEQUE,
    CAMBIOCHEQUE,
    CREDITO,
    VALE,
    MONEDERO,
    SUBTOTALSINIVA,
    SUBTOTALCONIVA,
    MONTOIVA)
AS
select
    base.corteid,
    base.tipodoctoid,base.tipoabonoid,base.mismocorte,
    sum(case when base.formapagoid = 1 then base.importe else 0 end) efectivo, 
    sum(case when base.formapagoid = 2 then base.importe else 0 end) tarjeta,
    sum(case when base.formapagoid = 3 then base.importerecibido else 0 end) cheque, 
    sum(case when base.formapagoid = 3 then base.importecambio else 0 end) cambiocheque,
    (case when base.tipoabonoid = 1 then (sum(case when base.formapagoid = 4 then base.importe else 0 end) - sum(case when base.formapagoid = 4 then coalesce(abonos_mc.abonomismocorte,0) else 0 end)) else 0 end) credito,
    sum(case when base.formapagoid = 5 then base.importe else 0 end) vale ,
    sum(case when base.formapagoid = 14 then base.importe else 0 end) monedero, 
    sum(base.subtotalsiniva) subtotalsiniva , 
    sum(base.subtotalconiva) subtotalconiva,
    sum(base.montoiva) montoiva

    from
    (
            select
            p.corteid,
            case when p.tipopagoid = 2 then
                case when ds.esapartado = 'S' and ds.tipodoctoid = 23 then 26 else ds.tipodoctoid end
            else
                case when de.esapartado = 'S' and de.tipodoctoid = 21 then 25 else de.tipodoctoid end
            end tipodoctoid,
            p.tipoabonoid,
            p.formapagoid,
            case when p.tipopagoid = 2 then
                case when  ds.tipodoctoid in  (23,24,26) then
                    (case when p.cortetranscancelada = ds.corteid then 'S' else 'N' end)
                else 'S' end
            else
                case when  de.tipodoctoid in  (23,24,26) then
                    (case when p.cortetranscancelada = de.corteid then 'S' else 'N' end)
                else 'S' end
            end
            mismocorte,
            coalesce((case when p.tipoabonoid = 3 then p.importe * -1 else p.importe end),0) importe,
            coalesce((case when p.tipoabonoid = 3 then p.importerecibido * -1 else p.importerecibido end),0) importerecibido,
            coalesce((case when p.tipoabonoid = 3 then p.importecambio * -1 else p.importecambio end),0) importecambio

            , 
            case when p.tipopagoid = 2 then
                case when coalesce(ds.iva,0) = 0  then coalesce((case when p.tipoabonoid = 3 then p.importe * -1 else p.importe end),0) else 0 end
            else
                case when coalesce(de.iva,0) = 0  then coalesce((case when p.tipoabonoid = 3 then p.importe * -1 else p.importe end),0) else 0 end
            end subtotalsiniva     
            , 
            case when p.tipopagoid = 2 then
                case when coalesce(ds.iva,0) <> 0  then coalesce((case when p.tipoabonoid = 3 then p.importe * -1 else p.importe end),0) else 0 end
            else
                case when coalesce(de.iva,0) <> 0  then coalesce((case when p.tipoabonoid = 3 then p.importe * -1 else p.importe end),0) else 0 end
            end subtotalconiva
            ,  
            case when p.tipopagoid = 2 then
                case when coalesce(ds.iva,0) <> 0 and coalesce(ds.total,0) <> 0 then
                          ( (ds.iva / ds.total) *  coalesce((case when p.tipoabonoid = 3 then p.importe * -1 else p.importe end),0)  )
                         else 0 end
            else
                
                case when coalesce(de.iva,0) <> 0 and coalesce(de.total,0) <> 0 then
                          ( (de.iva / de.total) *  coalesce((case when p.tipoabonoid = 3 then p.importe * -1 else p.importe end),0)  )
                         else 0 end
            end montoiva



            from doctopago p
            left join docto de on p.doctoid = de.id
            left join docto ds on p.doctosalidaid = ds.id
            where p.formapagoid in (1,2,3,4,5,14)
    )  base
    left join
    (
        select
        p.corteid,
        case when p.tipopagoid = 2 then
            case when ds.esapartado = 'S' and ds.tipodoctoid = 23 then 26 else ds.tipodoctoid end
        else
            case when de.esapartado = 'S' and de.tipodoctoid = 21 then 25 else de.tipodoctoid end
        end tipodoctoid ,

        sum(
            (case when (case when p.tipopagoid = 2 then ds.corteid else de.corteid end ) = p.corteid then coalesce(p.importe,0)
            else 0 end)
            )  abonomismocorte

        from doctopago p
        left join docto de on p.doctoid = de.id
        left join docto ds on p.doctosalidaid = ds.id
        where p.formapagoid in (1,2,3,5,14) and p.tipoabonoid in ( 2,3)
        group by p.corteid, p.tipopagoid, ds.tipodoctoid, de.tipodoctoid, ds.esapartado, de.esapartado)   abonos_mc
        on base.corteid = abonos_mc.corteid and base.tipodoctoid = abonos_mc.tipodoctoid
        group by base.corteid,base.tipodoctoid, base.tipoabonoid, base.mismocorte
;