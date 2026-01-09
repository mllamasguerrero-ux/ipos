CREATE OR ALTER VIEW CORTE_BASE_POR_IEPS(
    CORTEID,
    TASAIEPS,
    MONTOIEPS)
AS
select
cortebaseieps.corteid,
coalesce(movto.tasaieps,0) tasaieps,
sum((cortebaseieps.montoieps / cortebaseieps.iepsdocto) * movto.ieps  * cortecalculo.sentidoefectivo ) montoieps

from
(


  select
    base.corteid,
    base.doctoid,
    base.tipoabonoid,
    base.tipodoctoid,
    base.mismocorte ,
    sum(base.montoieps) montoieps  ,
    base.subtipodoctoid ,
    base.iepsdocto

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
            case when p.tipopagoid = 2 then
                case when coalesce(ds.ieps,0) <> 0 and coalesce(ds.total,0) <> 0 then
                          ( ds.ieps  *  coalesce((case when p.tipoabonoid = 3 then (p.importe/ ds.total) * -1 else (p.importe/ ds.total) end),0)  )
                         else 0 end
            else
                
                case when coalesce(de.ieps,0) <> 0 and coalesce(de.total,0) <> 0 then
                          ( de.ieps  *  coalesce((case when p.tipoabonoid = 3 then (p.importe/ de.total) * -1 else (p.importe/ de.total) end),0)  )
                         else 0 end
            end montoieps   ,

            case when p.tipopagoid = 2 then
                case when ds.esapartado = 'S' and ds.subtipodoctoid = 23 then 26 else ds.subtipodoctoid end
            else
                case when de.esapartado = 'S' and de.subtipodoctoid = 21 then 25 else de.subtipodoctoid end
            end subtipodoctoid ,
            
            case when p.tipopagoid = 2 then
                ds.ieps
            else
                de.ieps
            end iepsdocto


            from doctopago p
            left join docto de on p.doctoid = de.id
            left join docto ds on p.doctosalidaid = ds.id
            where p.formapagoid in (1,2,3,4,5,14,15,16)




    )  base


        where base.tipodoctoid not in (64,65 ) and  (base.estatusdoctoid = 1 or (base.tipodoctoid not in (62,63)))
        group by base.corteid, base.doctoid, base.tipoabonoid, base.tipodoctoid,  base.mismocorte , base.subtipodoctoid , base.iepsdocto
 )
   cortebaseieps
   
    left join cortecalculo on cortecalculo.tipodoctoid = cortebaseieps.tipodoctoid and
cortecalculo.tipoabonoid = cortebaseieps.tipoabonoid and cortecalculo.mismocorte  =  cortebaseieps.mismocorte



   left join movto on movto.doctoid = cortebaseieps.doctoid

   where coalesce(cortebaseieps.iepsdocto,0) <> 0 and
         cortebaseieps.tipodoctoid in (21,22,23,24,25,26) and
         coalesce(movto.tasaieps,0) <> 0

   group by cortebaseieps.corteid,
            coalesce(movto.tasaieps,0)
;