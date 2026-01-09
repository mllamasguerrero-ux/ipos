CREATE OR ALTER VIEW CLIENTE_SALDO_MOVTOS_APARTADO(
    DOCTOID,
    DOCTOFOLIO,
    TIPODOCTOID,
    TIPOABONOID,
    FORMAPAGOID,
    FECHA,
    IMPORTE,
    TIPOPAGOID,
    CARGOABONO,
    ESAPARTADO,
    PERSONAID,
    PERSONAAPARTADOID,
    FECHAVENCE,
    IMPORTERELATIVO,
    IMPORTESALDOPORAPLICAR,
    PAGOID,
    FECHAHORA,
    FOLIOENTRADA,
    FOLIOSALIDA,
    ABONOID,
    ABONOREFID,
    ESREVERSION,
    APLICACIONSALDOS)
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
1 cargoabono ,

D.ESAPARTADO,
D.PERSONAID,
D.PERSONAAPARTADOID,


   null  ,

CASE WHEN D.TIPODOCTOID IN (21,25)  THEN  coalesce(d.total,0) * -1
     WHEN D.TIPODOCTOID IN (23,26) THEN coalesce(d.total,0)
     ELSE 0 END  importerelativo ,
    CASE WHEN D.TIPODOCTOID IN (22) THEN coalesce(d.total,0)
         WHEN D.TIPODOCTOID IN (24) THEN  coalesce(d.total,0) * -1
        ELSE 0 END IMPORTESALDOPORAPLICAR,

    0 PAGOID ,
    D.CREADO FECHAHORA ,

    CASE WHEN D.TIPODOCTOID IN (21,25,24)  THEN  D.FOLIO else dr.folio end FOLIOENTRADA,
    CASE WHEN D.TIPODOCTOID IN (22,23,26)  THEN  D.FOLIO else dr.folio end FOLIOSALIDA ,
     NULL ABONOID,
     NULL ABONOREFID ,
     'N' ESREVERSION  ,
     0 APLICACIONSALDOS




 FROM
 "DOCTO" D
  --left join persona pr on pr.id = d.personaid
    left join personaapartado pa on pa.id = d.personaapartadoid
    left join DOCTO dr on dr.id = d.doctorefid
  WHERE d.TIPODOCTOID IN (21,22,23,24,25,26)  --and d.personaid not in (1,1071)
  PLAN JOIN (JOIN (D INDEX (DOCTO_IDX4, DOCTO_IDX4, DOCTO_IDX4, DOCTO_IDX4, DOCTO_IDX4, DOCTO_IDX4), PA INDEX (PK_PERSONAAPARTADO)), DR INDEX (PK_DOCTO))

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
           2 cargoabono ,
           
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

            
            NULL as fechavence  ,




            case
                when p.formapagoid in (1,2,3,5,14,15,16) then
                    -- si es un pago en efectivo de devolucion entonces se restaria en importe saldo por aplicar
                    case when ((p.formapagoid = 1 and ds.tipodoctoid = 22) or (de.tipodoctoid in (201,203)))  then
                      0
                    else   -- en cualquier otro caso
                        case when p.tipopagoid = 2 then
                            coalesce(p.importe,0) * -1
                        else
                            coalesce(p.importe,0)
                        end
                     end
                when p.formapagoid in (6,7,8,9,10,11,12,13,18,19) then
                    case when p.FORMAPAGOID IN (6,18)  then
                            coalesce(p.importe,0)
                         when p.FORMAPAGOID IN (7,19) then
                            coalesce(p.importe,0)  * -1
                        else
                            0
                    end
                else 0
                end importerelativo  ,


            case when p.formapagoid in (6,7,8,9,10,11,12,13,18,19) then
                case when p.FORMAPAGOID IN (6,18)  then
                    coalesce(p.importe,0)  * -1
                  when p.FORMAPAGOID IN (7,19) then
                    coalesce(p.importe,0)
                 else
                    0
                end
                when ((p.formapagoid = 1 and ds.tipodoctoid = 22) or (de.tipodoctoid in (201,203)))  then
                        case when p.tipopagoid = 2 then
                            coalesce(p.importe,0) * -1
                        else
                            coalesce(p.importe,0)
                        end
                else
                      0
            end IMPORTESALDOPORAPLICAR  ,

            P.ID PAGOID,

            P.CREADO FECHAHORA ,

            de.folio FOLIOENTRADA,
            ds.folio FOLIOSALIDA  ,

            P.ID ABONOID,
            P.doctopagorefid ABONOREFID ,
            case when p.doctopagorefid is not null and p.importe < 0 then 'S'
                ELSE 'N' end ESREVERSION,

            case when p.FORMAPAGOID IN (6,18) and p.tipopagoid = 1 then
                    1
                  when p.FORMAPAGOID IN (7,19) and p.tipopagoid = 1 then
                    -1
                 else
                    0
            end APLICACIONSALDOS





            from doctopago p
            left join docto de on p.doctoid = de.id
            left join docto ds on p.doctosalidaid = ds.id

            --left join persona pre on pre.id = de.personaid
            left join personaapartado pae on pae.id = de.personaapartadoid

            
            --left join persona prs on prs.id = ds.personaid
            left join personaapartado pas on pas.id = ds.personaapartadoid


            where p.formapagoid in (1,2,3,5,6,7,8,9,10,11,12,13,14,15,16,18,19)
            and (p.tipopagoid = 2 and ds.tipodoctoid in (21,22,23,24,25,26,201.203) or (de.tipodoctoid in (21,22,23,24,25,26,201,203)) )
            and not(p.tipopagoid = 2 and ds.tipodoctoid = 23 and p.formapagoid = 7)
            and not(p.tipopagoid = 2 and ds.tipodoctoid = 22 and p.formapagoid = 7)
            and not(p.tipopagoid = 2 and ds.tipodoctoid = 201 and p.formapagoid = 7)
            and not(p.tipopagoid = 1 and ds.tipodoctoid = 22 and ds.estatusdoctoid = 2 and de.estatusdoctoid = 2 and p.formapagoid in (6,7,18,19))
            and not(p.tipopagoid = 1 and ds.tipodoctoid = 201 and ds.estatusdoctoid = 2 and de.estatusdoctoid = 2 and p.formapagoid in (6,7,18,19))
            and coalesce(ds.personaapartadoid,0) <> 0 or coalesce(de.personaapartadoid,0) <> 0
            PLAN JOIN (JOIN (JOIN (JOIN (P NATURAL, DE INDEX (PK_DOCTO)), DS INDEX (PK_DOCTO)), PAE INDEX (PK_PERSONAAPARTADO)), PAS INDEX (PK_PERSONAAPARTADO))
;