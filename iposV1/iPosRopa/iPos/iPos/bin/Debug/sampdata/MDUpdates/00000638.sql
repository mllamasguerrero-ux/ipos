CREATE OR ALTER VIEW TESTING_DOCTOS(
    TIPODOCTOID,
    TIPODOC,
    ID,
    FOLIO,
    CORTEID,
    ESTATUSDOCTOID,
    ESTATUSDOC,
    TOTAL,
    ABONO,
    SALDO,
    MONTOORIGENFACTURADO,
    FOLIOORIGENFACTURADO,
    PERSONAID,
    PERSONA,
    PERSONAAPARTADOID,
    PERSONAAPARTADO,
    DOCTOREFID,
    FOLIOREF,
    MONTOPAGO,
    FORMAPAGO,
    TIPOPAGO,
    REFPAGO)
AS
select  d.tipodoctoid,  t.nombre as tipodoc, d.id , d.folio, d.corteid,
d.estatusdoctoid, e.nombre estatusdoc , d.total, d.abono, d.saldo,
d.montoorigenfacturado, d.folioorigenfacturado ,  d.personaid, p.nombre persona,
d.personaapartadoid, pa.nombres personaapartado  , d.doctorefid , dr.folio folioref ,
(
case when d.tipodoctoid in (12, 13) then

coalesce((dpe.importe *
          (CASE WHEN ((dpe.TIPOPAGOID = 1 AND dpe.FORMAPAGOID IN (1,2,3,4,5,6,9,14)) or (dpe.TIPOPAGOID = 2 AND dpe.FORMAPAGOID IN (7)))  THEN 1
                when ((dpe.TIPOPAGOID = 1 AND dpe.FORMAPAGOID IN (7)) or (dpe.TIPOPAGOID = 2 AND dpe.FORMAPAGOID IN (6,8))) THEN -1
                ELSE 0 END)
          ),0)

when  d.tipodoctoid in (11, 15)  then

coalesce((dps.importe *
           (CASE WHEN ((dps.TIPOPAGOID = 2 AND dps.FORMAPAGOID IN (1,2,3,4,5,7,14)) or (dps.TIPOPAGOID = 1 AND dps.FORMAPAGOID IN (6)))  THEN 1
                when ((dps.TIPOPAGOID = 1 AND dps.FORMAPAGOID IN (7)) or (dps.TIPOPAGOID = 2 AND dps.FORMAPAGOID IN (6)))  THEN -1
                ELSE 0 END)
          ),0)

          
when  d.tipodoctoid in (21, 24) then
coalesce((dpe.importe *
          (CASE WHEN ((dpe.TIPOPAGOID = 1 AND dpe.FORMAPAGOID IN (1,2,3,4,5,6,14)) or (dpe.TIPOPAGOID = 2 AND dpe.FORMAPAGOID IN (7)))  THEN 1
                when ((dpe.TIPOPAGOID = 1 AND dpe.FORMAPAGOID IN (7)) or (dpe.TIPOPAGOID = 2 AND dpe.FORMAPAGOID IN (6))) THEN -1
                ELSE 0 END)
          ),0)
          
when  d.tipodoctoid in (22, 23)  then
coalesce((dps.importe *
           (CASE WHEN ((dps.TIPOPAGOID = 2 AND dps.FORMAPAGOID IN (1,2,3,4,5,7,14)) or (dps.TIPOPAGOID = 1 AND dps.FORMAPAGOID IN (6)))  THEN 1
                when ((dps.TIPOPAGOID = 1 AND dps.FORMAPAGOID IN (7)) or (dps.TIPOPAGOID = 2 AND dps.FORMAPAGOID IN (6)))  THEN -1
                ELSE 0 END)
          ),0)

when  d.tipodoctoid in (25)  then
coalesce((dpe.importe *
          (CASE WHEN ((dpe.TIPOPAGOID = 1 AND dpe.FORMAPAGOID IN (1,2,3,4,5,6,9,14)) or (dpe.TIPOPAGOID = 2 AND dpe.FORMAPAGOID IN (7)))  THEN 1
                when ((dpe.TIPOPAGOID = 1 AND dpe.FORMAPAGOID IN (7)) or (dpe.TIPOPAGOID = 2 AND dpe.FORMAPAGOID IN (6,8))) THEN -1
                ELSE 0 END)
          ),0)
           
when  d.tipodoctoid in (26)  then
coalesce((dps.importe *
           (CASE WHEN ((dps.TIPOPAGOID = 2 AND dps.FORMAPAGOID IN (1,2,3,4,5,7,14)) or (dps.TIPOPAGOID = 1 AND dps.FORMAPAGOID IN (6,9)))  THEN 1
                when ((dps.TIPOPAGOID = 1 AND dps.FORMAPAGOID IN (7)) or (dps.TIPOPAGOID = 2 AND dps.FORMAPAGOID IN (6,8)))  THEN -1
                ELSE 0 END)
          ),0)

          end
)
MontoPago  ,

(case when  d.tipodoctoid in (12,13,21,24,25) then fe.nombre else fs.nombre end ) formapago,
 (case when  d.tipodoctoid in (12,13,21,24,25) then tpe.nombre else tps.nombre end ) tipopago ,
 (case when  d.tipodoctoid in (12,13,21,24,25) then dpe.doctosalidaid else dps.doctoid end ) refpago


from docto d
left join estatusdocto e  on d.estatusdoctoid = e.id
left join tipodocto t on d.tipodoctoid = t.id
left join persona p on d.personaid = p.id
left join personaapartado pa on d.personaapartadoid = pa.id
left join docto dr on d.doctorefid = dr.id
left join doctopago dpe on dpe.doctoid = d.id and dpe.formapagoid <> 4
left join formapago fe on dpe.formapagoid = fe.id  and fe.abona = 'S'
left join tipopago tpe on dpe.tipopagoid = tpe.id
left join doctopago dps on dps.doctosalidaid = d.id  and dps.formapagoid <> 4
left join formapago fs on dps.formapagoid = fs.id  and fs.abona = 'S'  
left join tipopago tps on dps.tipopagoid = tps.id
where d.tipodoctoid in ( 11,12,13,15,21,22,23,24,25,26)
;