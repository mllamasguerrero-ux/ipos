CREATE OR ALTER VIEW TESTING_CORTE(
    CORTEID,
    TOTAL,
    FORMAPAGOID,
    FORMAPAGO,
    TIPOPAGOID,
    TIPOPAGODOC,
    IDENTRADA,
    FOLIOENTRADA,
    TIPODOCTOENTRADA,
    IDSALIDA,
    FOLIOSALIDA,
    TIPODOCTOSALIDA,
    IMPORTE,
    FECHA,
    PERSONAID,
    PERSONA,
    PERSONAAPARTADOID,
    PERSONAAPARTADO)
AS
select encabezado.corteid, encabezado.importe as total, encabezado.formapagoid, encabezado.formapago, encabezado.tipopagoid, encabezado.tipopagodoc, detalle.identrada,  detalle.folioentrada, detalle.tipodoctoentrada,  detalle.idsalida,  detalle.foliosalida,  detalle.tipodoctosalida,
   detalle.importe  , detalle.fecha,
   detalle.personaid,
   detalle.persona,
   detalle.personaapartadoid,
   detalle.personaapartado
   from
   (

    select p.corteid ,sum(coalesce(p.importe,0)) importe  ,
   p.formapagoid,  f.nombre formapago  , p.tipopagoid, t.nombre tipopagodoc
   from doctopago P
   left join docto de on p.doctoid = de.id  
   left join docto ds on p.doctosalidaid = ds.id
   left join persona ge on de.personaid = ge.id
   left join persona gs on ds.personaid = gs.id  
   left join personaapartado gea on de.personaapartadoid = gea.id
   left join personaapartado gsa on ds.personaapartadoid = gsa.id
   left join formapago f on p.formapagoid = f.id
   left join tipopago t on p.tipopagoid = t.id
   left join tipodocto tde on de.tipodoctoid =tde.id  
   left join tipodocto tds on ds.tipodoctoid =tds.id
    WHERE P.FORMAPAGOID IN (1,2,3,4,5,14)
    group by p.corteid,p.formapagoid, p.tipopagoid ,f.nombre ,t.nombre
    order by p.corteid,p.formapagoid, p.tipopagoid
    ) encabezado
    inner join
    (
       select p.corteid, de.id identrada,  de.folio folioentrada, tde.nombre tipodoctoentrada,  ds.id idsalida,  ds.folio foliosalida,  tds.nombre tipodoctosalida,
   coalesce(p.importe,0) importe  , p.fecha,
   (case when de.id is null then  ds.personaid else de.personaid end) personaid,
   (case when de.id is null then  gs.nombre else ge.nombre end) persona,
   (case when de.id is null then  ds.personaapartadoid else de.personaapartadoid end) personaapartadoid,
   (case when de.id is null then  gsa.nombres else gea.nombres end) personaapartado,
   p.formapagoid,  f.nombre formapago  , p.tipopagoid, t.nombre tipopagodoc

   from doctopago P
   left join docto de on p.doctoid = de.id  
   left join docto ds on p.doctosalidaid = ds.id
   left join persona ge on de.personaid = ge.id
   left join persona gs on ds.personaid = gs.id  
   left join personaapartado gea on de.personaapartadoid = gea.id
   left join personaapartado gsa on ds.personaapartadoid = gsa.id
   left join formapago f on p.formapagoid = f.id
   left join tipopago t on p.tipopagoid = t.id
   left join tipodocto tde on de.tipodoctoid =tde.id
   left join tipodocto tds on ds.tipodoctoid =tds.id
    WHERE P.FORMAPAGOID IN (1,2,3,4,5,14)
    order by p.corteid,p.formapagoid, p.tipopagoid
    )
    detalle on encabezado.corteid = detalle.corteid and encabezado.formapagoid = detalle.formapagoid and encabezado.tipopagoid = detalle.tipopagoid
;