CREATE OR ALTER VIEW CLIENTE_SALDO_MOVTOS(
    DOCTOID,
    DOCTOFOLIO,
    TIPODOCTOID,
    TIPOABONOID,
    FORMAPAGOID,
    FECHA,
    IMPORTE,
    TIPOPAGOID,
    CARGOABONO,
    ESPARTADO,
    PERSONAID,
    PERSONAAPARTADOID,
    FECHAVENCE,
    IMPORTERELATIVO)
AS
SELECT D.id doctoid,
 d.folio DOCTOFOLIO,
d.tipodoctoid,
null tipoabonoid,
null formapagoid  ,
D.FECHA fecha,
D.TOTAL importe,

CASE WHEN D.TIPODOCTOID IN (21,24,25)  THEN 2
     WHEN D.TIPODOCTOID IN (22,23,26) THEN 1
     ELSE 0 END  tipopagoid,
'CARGO' cargoabono ,

D.ESAPARTADO,
D.PERSONAID,
D.PERSONAAPARTADOID,

case when d.esapartado <> 'S' then
   case when coalesce(pr.dias,0) > 0 then dateadd(pr.dias day to d.fecha) else null end
else
   null
end as fechavence  ,

CASE WHEN D.TIPODOCTOID IN (21,24,25)  THEN  coalesce(d.total,0) * -1
     WHEN D.TIPODOCTOID IN (22,23,26) THEN coalesce(d.total,0)
     ELSE 0 END  importerelativo


 FROM
 "DOCTO" D
  left join persona pr on pr.id = d.personaid
    left join personaapartado pa on pa.id = d.personaapartadoid
  WHERE d.TIPODOCTOID IN (21,22,23,24,25,26)

      UNION


  select
  
            case when p.tipopagoid = 2 then
                ds.id
            else
                de.id
            end doctoid,
                   
            case when p.tipopagoid = 2 then
                ds.folio
            else
                de.folio
            end doctofolio,


            case when p.tipopagoid = 2 then
                case when ds.esapartado = 'S' and ds.tipodoctoid = 23 then 26 else ds.tipodoctoid end
            else
                case when de.esapartado = 'S' and de.tipodoctoid = 21 then 25 else de.tipodoctoid end
            end tipodoctoid,
            p.tipoabonoid,
            p.formapagoid,
            p.fecha,
            coalesce((case when p.tipoabonoid = 3 then p.importe * -1 else p.importe end),0) importe,

            p.tipopagoid      ,
           'ABONO' cargoabono ,
           
            case when p.tipopagoid = 2 then
               ds.esapartado
            else
                de.esapartado
            end ESAPARTADO ,
            
            case when p.tipopagoid = 2 then
               ds.personaid
            else
               de.personaid
            end personaid,
            
            case when p.tipopagoid = 2 then
               ds.personaapartadoid
            else
               de.personaapartadoid
            end personaapartadoid  ,

            
            case when p.tipopagoid = 2 then
                case when ds.esapartado <> 'S' then
                    case when coalesce(prs.dias,0) > 0 then dateadd(prs.dias day to ds.fecha) else null end
                else
                    null
                end
            else      
                case when de.esapartado <> 'S' then
                    case when coalesce(pre.dias,0) > 0 then dateadd(pre.dias day to ds.fecha) else null end
                else
                    null
                end
            end   as fechavence  ,

            
            case when p.tipopagoid = 2 then
               coalesce((case when p.tipoabonoid = 3 then p.importe * -1 else p.importe end),0) * -1
            else
               coalesce((case when p.tipoabonoid = 3 then p.importe * -1 else p.importe end),0)
            end importerelativo





            from doctopago p
            left join docto de on p.doctoid = de.id
            left join docto ds on p.doctosalidaid = ds.id

            left join persona pre on pre.id = de.personaid
            left join personaapartado pae on pae.id = de.personaapartadoid

            
            left join persona prs on prs.id = ds.personaid
            left join personaapartado pas on pas.id = ds.personaapartadoid


            where p.formapagoid in (1,2,3,5,14,15,16)
;