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
    MONTOIVA,
    TRANSFERENCIA,
    INDEFINIDO,
    MONTOIEPS,
    MONTOIMPUESTO,
    SUBTIPODOCTOID,
    ABONOOTROCORTE,
    ABONOREFERENCIAOTROCORTE)
AS
select
    base.corteid,
    base.tipodoctoid,
    base.tipoabonoid,base.mismocorte,
    sum(case when base.formapagoid = 1 then base.importe else 0 end) efectivo, 
    sum(case when base.formapagoid = 2 then base.importe else 0 end) tarjeta,
    sum(case when base.formapagoid = 3 then base.importerecibido else 0 end) cheque, 
    sum(case when base.formapagoid = 3 then base.importecambio else 0 end) cambiocheque,
    (case when base.tipoabonoid = 1 then (sum(case when base.formapagoid = 4 then base.importe else 0 end) /*- min(case when base.formapagoid = 4 then coalesce(abonos_mc.abonomismocorte,0) else 0 end)*/) else 0 end) - ( case when base.tipoabonoid = 1 then coalesce(abonos_mc.abonomismocorte,0) else 0 end) credito,
    sum(case when base.formapagoid = 5 then base.importe else 0 end) vale ,
    sum(case when base.formapagoid = 14 then base.importe else 0 end) monedero, 
    sum(base.subtotalsiniva) subtotalsiniva , 
    sum(base.subtotalconiva) subtotalconiva,
    sum(base.montoiva) montoiva  ,
    
    sum(case when base.formapagoid = 15 then base.importe else 0 end) transferencia,  
    sum(case when base.formapagoid = 16 then base.importe else 0 end) indefinido  ,
    sum(base.montoieps) montoieps  ,
    sum(base.montoimpuesto) montoimpuesto ,
    base.subtipodoctoid ,
    base.abonootrocorte ,
    base.abonoreferenciaotrocorte

    from
    (
            select
            p.corteid,
            case when p.tipopagoid = 2 then
                case when ds.esapartado = 'S' and ds.tipodoctoid = 23 then 26 else ds.tipodoctoid end
            else
                case when de.esapartado = 'S' and de.tipodoctoid = 21 then 25 else de.tipodoctoid end
            end tipodoctoid,     
            case when p.tipopagoid = 2 then
                case when ds.esapartado = 'S' and ds.tipodoctoid = 23 then 26 else ds.estatusdoctoid end
            else
                case when de.esapartado = 'S' and de.tipodoctoid = 21 then 25 else de.estatusdoctoid end
            end estatusdoctoid,
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
                case when coalesce(ds.total,0) <> 0 then coalesce((case when p.tipoabonoid = 3 then (p.importe/ ds.total) * -1 * coalesce(ds.subtotalsiniva,0)   else (p.importe / ds.total ) * coalesce(ds.subtotalsiniva,0)   end),0) else 0 end
            else
                case when coalesce(de.total,0) <> 0 then coalesce((case when p.tipoabonoid = 3 then (p.importe/ de.total) * -1 * coalesce(de.subtotalsiniva,0)   else (p.importe / de.total ) * coalesce(de.subtotalsiniva,0)   end),0) else 0 end
            end subtotalsiniva     
            , 
            case when p.tipopagoid = 2 then
                case when coalesce(ds.total,0) <> 0 then coalesce((case when p.tipoabonoid = 3 then (p.importe / ds.total) * -1 * coalesce(ds.subtotalconiva,0)  else (p.importe / ds.total ) * coalesce(ds.subtotalconiva,0)   end),0) else 0 end
            else
                case when coalesce(de.total,0) <> 0 then coalesce((case when p.tipoabonoid = 3 then (p.importe/ de.total) * -1 * coalesce(de.subtotalconiva,0)   else (p.importe / de.total ) * coalesce(de.subtotalconiva,0)   end),0) else 0 end
            end subtotalconiva
            ,  
            case when p.tipopagoid = 2 then
                case when coalesce(ds.iva,0) <> 0 and coalesce(ds.total,0) <> 0 then
                          ( ds.iva  *  coalesce((case when p.tipoabonoid = 3 then (p.importe/ ds.total) * -1 else (p.importe/ ds.total) end),0)  )
                         else 0 end
            else
                
                case when coalesce(de.iva,0) <> 0 and coalesce(de.total,0) <> 0 then
                          ( de.iva  *  coalesce((case when p.tipoabonoid = 3 then (p.importe/ de.total) * -1 else (p.importe/ de.total) end),0)  )
                         else 0 end
            end montoiva
            
            ,  
            case when p.tipopagoid = 2 then
                case when coalesce(ds.ieps,0) <> 0 and coalesce(ds.total,0) <> 0 then
                          ( ds.ieps  *  coalesce((case when p.tipoabonoid = 3 then (p.importe/ ds.total) * -1 else (p.importe/ ds.total) end),0)  )
                         else 0 end
            else
                
                case when coalesce(de.ieps,0) <> 0 and coalesce(de.total,0) <> 0 then
                          ( de.ieps  *  coalesce((case when p.tipoabonoid = 3 then (p.importe/ de.total) * -1 else (p.importe/ de.total) end),0)  )
                         else 0 end
            end montoieps   
            ,  
            case when p.tipopagoid = 2 then
                case when coalesce(ds.impuesto,0) <> 0 and coalesce(ds.total,0) <> 0 then
                          ( ds.impuesto  *  coalesce((case when p.tipoabonoid = 3 then (p.importe/ ds.total) * -1 else (p.importe/ ds.total) end),0)  )
                         else 0 end
            else
                
                case when coalesce(de.impuesto,0) <> 0 and coalesce(de.total,0) <> 0 then
                          ( de.impuesto  *  coalesce((case when p.tipoabonoid = 3 then (p.importe/ de.total) * -1 else (p.importe/ de.total) end),0)  )
                         else 0 end
            end montoimpuesto ,

            case when p.tipopagoid = 2 then
                case when ds.esapartado = 'S' and ds.subtipodoctoid = 23 then 26 else ds.subtipodoctoid end
            else
                case when de.esapartado = 'S' and de.subtipodoctoid = 21 then 25 else de.subtipodoctoid end
            end subtipodoctoid  ,
            case when p.tipopagoid = 2 then
                case when p.corteid = ds.corteid then 'N' else 'S' end
            else
                case when p.corteid = de.corteid then 'N' else 'S' end
            end abonootrocorte  ,

            case when p.tipoabonoid = 3 and coalesce(p.corteid,0) <> coalesce(pref.corteid,0)  then
                 'S'
            else
               'N'
            end ABONOREFERENCIAOTROCORTE


            from doctopago p
            left join docto de on p.doctoid = de.id
            left join docto ds on p.doctosalidaid = ds.id
            left join doctopago pref on pref.id = p.doctopagorefid
            where p.formapagoid in (1,2,3,4,5,14,15,16)




    )  base




    left join
    (
        select
          a_i.corteid, a_i.tipodoctoid, a_i.estatusdoctoid,sum(a_i.abonomismocorte) as abonomismocorte
        from
            (
            select
             p.corteid,
            case when p.tipopagoid = 2 then
                case when ds.esapartado = 'S' and ds.tipodoctoid = 23 then 26 else ds.tipodoctoid end
            else
                case when de.esapartado = 'S' and de.tipodoctoid = 21 then 25 else de.tipodoctoid end
            end tipodoctoid ,         
            case when p.tipopagoid = 2 then
                case when ds.esapartado = 'S' and ds.tipodoctoid = 23 then 26 else ds.estatusdoctoid end
            else
                case when de.esapartado = 'S' and de.tipodoctoid = 21 then 25 else de.estatusdoctoid end
            end estatusdoctoid ,

            sum(
                (case when (case when p.tipopagoid = 2 then ds.corteid else de.corteid end ) = p.corteid then coalesce(p.importe,0)
                else 0 end)
                )  abonomismocorte

            from doctopago p
            left join docto de on p.doctoid = de.id
            left join docto ds on p.doctosalidaid = ds.id
            where p.formapagoid in (1,2,3,5,14,15,16) and p.tipoabonoid in ( 2,3)

            group by p.corteid, p.tipopagoid, ds.tipodoctoid, de.tipodoctoid, ds.estatusdoctoid, de.estatusdoctoid, ds.esapartado, de.esapartado
          ) a_i
          group by a_i.corteid, a_i.tipodoctoid , a_i.estatusdoctoid


        )   abonos_mc



        on base.corteid = abonos_mc.corteid and base.tipodoctoid = abonos_mc.tipodoctoid  and base.estatusdoctoid = abonos_mc.estatusdoctoid
         where base.tipodoctoid not in (64,65 ) and  (base.estatusdoctoid = 1 or (base.tipodoctoid not in (62,63)))
        group by base.corteid,base.tipodoctoid, base.tipoabonoid, base.mismocorte ,abonos_mc.abonomismocorte , base.subtipodoctoid , base.abonootrocorte, base.ABONOREFERENCIAOTROCORTE
;