CREATE OR ALTER VIEW DESGLOSE_COMISIONES(
    TIPOCOMISION,
    TIPOMOVIMIENTO,
    FECHA,
    CLAVEVENDEDOR,
    NOMBRE,
    USERNAME,
    NOMBRES,
    APELLIDOS,
    GAFFETE,
    CLAVEPRODUCTO,
    NOMBREPRODUCTO,
    DESCRIPCIO1PRODUCTO,
    DESCRIPCIO2PRODUCTO,
    COMISION_CU,
    CANTIDAD,
    MONTOPAGO,
    TOTAL,
    FACTORPAGO,
    COMISION_TOTAL,
    PORCENTAJE_COMISION,
    COMISION_PERSONA,
    FOLIO,
    FOLIODEVOLUCION)
AS
select
'VENDEDOR DE PISO' TIPOCOMISION ,
(CASE WHEN dp.formapagoid IN (7) then 'SALDO DESAPLICADO'
      WHEN dp.formapagoid IN (6) then 'SALDO APLICADO'
      ELSE 'PAGO VENTA' END)   TIPOMOVIMIENTO,
dp.fecha ,
v.clave CLAVEVENDEDOR,
v.nombre,
v.username,
v.nombres,
v.apellidos,
v.gaffete,
p.clave CLAVEPRODUCTO,
p.nombre NOMBREPRODUCTO,
p.descripcion1 DESCRIPCIO1PRODUCTO,
p.descripcion2 DESCRIPCIO2PRODUCTO,
m.comisionxunidad comision_cu,
m.cantidad  ,
dp.importe montopago,
d.total,
dp.importe * (case when dp.formapagoid = 7 then -1 else 1 end)/d.total factorpago,
((m.cantidad * m.comisionxunidad) * dp.importe * (case when dp.formapagoid = 7 then -1 else 1 end)/d.total)
 comision_total,
t.porc_comisionvendedor porcentaje_comision,
((t.porc_comisionvendedor/100)*
((m.cantidad * m.comisionxunidad)  * dp.importe * (case when dp.formapagoid = 7 then -1 else 1 end) /d.total)
) comision_persona ,
d.folio   folio,
null foliodevolucion

from movto m  
inner join doctopago dp on m.doctoid = dp.doctoid and dp.formapagoid in (1,2,3,5,6,7,14,15,16)  and dp.tipopagoid = 1
inner join docto d on dp.doctoid = d.id
left join docto ds on dp.doctosalidaid = ds.id
inner join producto p on m.productoid = p.id
inner join persona v on v.id = d.vendedorfinal
inner join parametro t on 1 = 1
where d.tipodoctoid in (21,25) and t.encargadoid <> d.vendedorfinal   and m.comisionxunidad > 0   
and ( dp.formapagoid in (1,2,3,5,14) or coalesce(d.id,0) <> coalesce(ds.doctorefid,-1))




 union  all

 select 
'ENCARGADO' TIPOCOMISION  ,
(CASE WHEN dp.formapagoid IN (7) then 'SALDO DESAPLICADO'
      WHEN dp.formapagoid IN (6) then 'SALDO APLICADO'
      ELSE 'PAGO VENTA' END)   TIPOMOVIMIENTO,
dp.fecha ,
v.clave CLAVEVENDEDOR,
v.nombre,
v.username,
v.nombres,
v.apellidos,
v.gaffete,
p.clave CLAVEPRODUCTO,
p.nombre NOMBREPRODUCTO,
p.descripcion1 DESCRIPCIO1PRODUCTO,
p.descripcion2 DESCRIPCIO2PRODUCTO,
m.comisionxunidad comision_cu,
m.cantidad ,
dp.importe montopago,
d.total,
dp.importe * (case when dp.formapagoid = 7 then -1 else 1 end)/d.total factorpago,
((m.cantidad * m.comisionxunidad)  * dp.importe * (case when dp.formapagoid = 7 then -1 else 1 end)/d.total)   comision_total,
(case when t.encargadoid = d.vendedorfinal then  t.porc_comisionencargado + t.porc_comisionvendedor else t.porc_comisionencargado end) porcentaje_comision,


((
(case when t.encargadoid = d.vendedorfinal then  t.porc_comisionencargado + t.porc_comisionvendedor else t.porc_comisionencargado end)
/100)*
((m.cantidad * m.comisionxunidad)  * dp.importe * (case when dp.formapagoid = 7 then -1 else 1 end)/d.total)
) comision_persona      ,

d.folio,
null foliodevolucion
from movto m
inner join doctopago dp on m.doctoid = dp.doctoid and dp.formapagoid in (1,2,3,5,6,7,14)  and dp.tipopagoid = 1
inner join docto d on dp.doctoid = d.id and coalesce(d.total,0) > 0 
left join docto ds on dp.doctosalidaid = ds.id
inner join producto p on m.productoid = p.id
inner join parametro t on 1 = 1    
inner join persona v on v.id = t.encargadoid
where d.tipodoctoid in (21,25) and m.comisionxunidad > 0
and ( dp.formapagoid in (1,2,3,5,14) or coalesce(d.id,0) <> coalesce(ds.doctorefid,-1))


  union all

select
'VENDEDOR DE PISO' TIPOCOMISION ,
(CASE WHEN ds.tipodoctoid IN (23,26) THEN 'CANCELACION' ELSE 'DEVOLUCION' END) TIPOMOVIMIENTO,
dp.fecha ,
v.clave CLAVEVENDEDOR,
v.nombre,
v.username,
v.nombres,
v.apellidos,
v.gaffete,
p.clave CLAVEPRODUCTO,
p.nombre NOMBREPRODUCTO,
p.descripcion1 DESCRIPCIO1PRODUCTO,
p.descripcion2 DESCRIPCIO2PRODUCTO,
m.comisionxunidad comision_cu,
m.cantidad  ,
dp.importe montopago,
ds.total,
(dp.importe * -1/ds.total) factorpago,
((m.cantidad * m.comisionxunidad)   * dp.importe * -1/ds.total)
 comision_total,
t.porc_comisionvendedor porcentaje_comision,
((t.porc_comisionvendedor/100)*
((m.cantidad * m.comisionxunidad)    * dp.importe * -1/ds.total)
) comision_persona ,
d.folio ,
ds.folio foliodevolucion

from movto m  
inner join doctopago dp on m.doctoid = dp.doctosalidaid and dp.formapagoid in (1,2,3,5,6,14) and (dp.tipopagoid = 2 or (dp.tipopagoid = 1 and dp.formapagoid = 6) )
inner join docto d on dp.doctoid = d.id
inner join docto ds on dp.doctosalidaid = ds.id
inner join producto p on m.productoid = p.id
inner join persona v on v.id = d.vendedorfinal
inner join parametro t on 1 = 1
where ds.tipodoctoid in (22,23,26) and t.encargadoid <> d.vendedorfinal and m.comisionxunidad > 0
and coalesce(d.id,0) = coalesce(ds.doctorefid,-1)
and dp.formapagoid in (1,2,3,5,14)
--and (dp.formapagoid in (1,2,3,5) or coalesce(d.id,0) <> coalesce(ds.doctorefid,-1))




 union all

 select 
'ENCARGADO' TIPOCOMISION  ,
(CASE WHEN ds.tipodoctoid IN (23,26) THEN 'CANCELACION' ELSE 'DEVOLUCION' END) TIPOMOVIMIENTO,
dp.fecha ,
v.clave CLAVEVENDEDOR,
v.nombre,
v.username,
v.nombres,
v.apellidos,
v.gaffete,
p.clave CLAVEPRODUCTO,
p.nombre NOMBREPRODUCTO,
p.descripcion1 DESCRIPCIO1PRODUCTO,
p.descripcion2 DESCRIPCIO2PRODUCTO,
m.comisionxunidad comision_cu,
m.cantidad ,
dp.importe montopago,
ds.total,
(dp.importe * -1/ds.total) factorpago,
((m.cantidad * m.comisionxunidad)  * dp.importe * -1/ds.total)   comision_total,
(case when t.encargadoid = d.vendedorfinal then  t.porc_comisionencargado + t.porc_comisionvendedor else t.porc_comisionencargado end) porcentaje_comision,


((
(case when t.encargadoid = d.vendedorfinal then  t.porc_comisionencargado + t.porc_comisionvendedor else t.porc_comisionencargado end)
/100)*
((m.cantidad * m.comisionxunidad)  * dp.importe * -1/ds.total)
) comision_persona      ,

d.folio ,
ds.folio foliodevolucion

from movto m
inner join doctopago dp on m.doctoid = dp.doctosalidaid and dp.formapagoid in (1,2,3,5,6,14)  and (dp.tipopagoid = 2 or (dp.tipopagoid = 1 and dp.formapagoid = 6))
inner join docto d on dp.doctoid = d.id and coalesce(d.total,0) > 0
inner join docto ds on dp.doctosalidaid = ds.id
inner join producto p on m.productoid = p.id
inner join parametro t on 1 = 1    
inner join persona v on v.id = t.encargadoid
where ds.tipodoctoid in (22,23,26) and m.comisionxunidad > 0
and coalesce(d.id,0) = coalesce(ds.doctorefid,-1)   
and dp.formapagoid in (1,2,3,5,14)
--and (dp.formapagoid in (1,2,3,5) or coalesce(d.id,0) <> coalesce(ds.doctorefid,-1))


    union all

    select
'VENDEDOR DE PISO' TIPOCOMISION ,
'CANCELACION DE DEVOLUCION' TIPOMOVIMIENTO,
dp.fecha ,
v.clave CLAVEVENDEDOR,
v.nombre,
v.username,
v.nombres,
v.apellidos,
v.gaffete,
p.clave CLAVEPRODUCTO,
p.nombre NOMBREPRODUCTO,
p.descripcion1 DESCRIPCIO1PRODUCTO,
p.descripcion2 DESCRIPCIO2PRODUCTO,
m.comisionxunidad comision_cu,
m.cantidad  ,
dp.importe montopago,
ds.total,
(dp.importe * -1/dc.total) factorpago,
((m.cantidad * m.comisionxunidad) * dp.importe /dc.total)
 comision_total,
t.porc_comisionvendedor porcentaje_comision,
((t.porc_comisionvendedor/100)*
((m.cantidad * m.comisionxunidad)  * dp.importe /dc.total)
) comision_persona ,
d.folio   ,
ds.folio foliodevolucion

from movto m  
inner join doctopago dp on m.doctoid = dp.doctoid and dp.formapagoid in (1,2,3,5,7,14) and (dp.tipopagoid = 1 or (dp.tipopagoid = 2 and dp.formapagoid = 7))
inner join docto dc on dp.doctoid = dc.id
inner join docto ds on dp.doctosalidaid = ds.id
inner join docto d on ds.doctorefid = d.id
inner join producto p on m.productoid = p.id
inner join persona v on v.id = d.vendedorfinal
inner join parametro t on 1 = 1
where dc.tipodoctoid in (24) and t.encargadoid <> d.vendedorfinal and m.comisionxunidad > 0
   and dp.formapagoid in (1,2,3,5,14)



 union  all

 select 
'ENCARGADO' TIPOCOMISION  ,
'CANCELACION DE DEVOLUCION' TIPOMOVIMIENTO,
dp.fecha ,
v.clave CLAVEVENDEDOR,
v.nombre,
v.username,
v.nombres,
v.apellidos,
v.gaffete,
p.clave CLAVEPRODUCTO,
p.nombre NOMBREPRODUCTO,
p.descripcion1 DESCRIPCIO1PRODUCTO,
p.descripcion2 DESCRIPCIO2PRODUCTO,
m.comisionxunidad comision_cu,
m.cantidad ,
dp.importe montopago,
ds.total,
(dp.importe * -1/dc.total) factorpago,
((m.cantidad * m.comisionxunidad)  * dp.importe/dc.total)   comision_total,
(case when t.encargadoid = d.vendedorfinal then  t.porc_comisionencargado + t.porc_comisionvendedor else t.porc_comisionencargado end) porcentaje_comision,


((
(case when t.encargadoid = d.vendedorfinal then  t.porc_comisionencargado + t.porc_comisionvendedor else t.porc_comisionencargado end)
/100)*
((m.cantidad * m.comisionxunidad)  * dp.importe/dc.total)
) comision_persona      ,

d.folio,
ds.folio foliodevolucion
from movto m
inner join doctopago dp on m.doctoid = dp.doctoid and dp.formapagoid in (1,2,3,5,7,14)   and (dp.tipopagoid = 1 or (dp.tipopagoid = 2 and dp.formapagoid = 7))
inner join docto dc on dp.doctoid = dc.id
inner join docto ds on dp.doctosalidaid = ds.id
inner join docto d on ds.doctorefid = d.id
inner join producto p on m.productoid = p.id
inner join parametro t on 1 = 1    
inner join persona v on v.id = t.encargadoid
where dc.tipodoctoid in (24)   and m.comisionxunidad > 0
and dp.formapagoid in (1,2,3,5,14)
;