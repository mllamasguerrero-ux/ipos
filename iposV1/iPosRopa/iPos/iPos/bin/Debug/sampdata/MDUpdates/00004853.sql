CREATE OR ALTER VIEW CORTE_BASE_POR_DOCTOYFORMAPAGO(
    CORTEID,
    DOCTOID,
    TIPODOCTOID,
    SUBTIPODOCTOID,
    FORMAPAGOID,
    MONTO)
AS
select
cortebaseformapago.corteid,
cortebaseformapago.doctoid,
   cortebaseformapago.tipodoctoid,
   cortebaseformapago.subtipodoctoid,
cortebaseformapago.formapagoid,

sum(case cortebaseformapago.formapagoid
    when  1 then   case when cortebaseformapago.tipodoctoid not in (60,61,62,63,64,65) then cortebaseformapago.importe * cortecalculo.sentidoefectivo else 0 end
    when  2 then   cortebaseformapago.importe * cortecalculo.sentidotarjeta
    when  3 then   cortebaseformapago.importe * cortecalculo.sentidocheque
    when  15 then   cortebaseformapago.importe * cortecalculo.sentidotransferencia   
    when  16 then   cortebaseformapago.importe * cortecalculo.sentidoindefinido
    when 4 then  case when cortebaseformapago.tipoabonoid = 1 then cortebaseformapago.importe * cortecalculo.sentidocredito else 0 end
    when 5 then   cortebaseformapago.importe * cortecalculo.sentidovale
    else cortebaseformapago.importe *  cortecalculo.sentidoefectivo
end) importe

from
(


  select
    base.corteid,
    base.doctoid ,
    base.tipoabonoid,
    base.tipodoctoid,
    base.mismocorte ,
    sum(base.importe) importe ,
    base.subtipodoctoid ,
    base.formapagoid

    from
    (
            select
            p.corteid,
            
            case when p.tipopagoid = 2 then
                ds.id
            else
                de.id
            end doctoid,

            p.tipoabonoid,

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
            p.formapagoid,
            coalesce((case when p.tipoabonoid = 3 then p.importe * -1 else p.importe end),0) importe   ,

            case when p.tipopagoid = 2 then
                case when ds.esapartado = 'S' and ds.subtipodoctoid = 23 then 26 else ds.subtipodoctoid end
            else
                case when de.esapartado = 'S' and de.subtipodoctoid = 21 then 25 else de.subtipodoctoid end
            end subtipodoctoid


            from doctopago p
            left join docto de on p.doctoid = de.id
            left join docto ds on p.doctosalidaid = ds.id
            where p.formapagoid in (1,2,3,4,5,14,15,16, 20, 21)




    )  base


        where base.tipodoctoid not in (64,65 ) and  (base.estatusdoctoid = 1 or (base.tipodoctoid not in (62,63)))
        group by base.corteid, base.doctoid, base.formapagoid, base.tipoabonoid, base.tipodoctoid,  base.mismocorte , base.subtipodoctoid
 )
   cortebaseformapago
   
    left join cortecalculo on cortecalculo.tipodoctoid = cortebaseformapago.tipodoctoid and
cortecalculo.tipoabonoid = cortebaseformapago.tipoabonoid and cortecalculo.mismocorte  =  cortebaseformapago.mismocorte





   group by       
   cortebaseformapago.corteid,
   cortebaseformapago.doctoid,
   cortebaseformapago.formapagoid ,
   cortebaseformapago.tipodoctoid,
   cortebaseformapago.subtipodoctoid
;