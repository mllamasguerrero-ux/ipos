CREATE OR ALTER VIEW VENTASLISTA(
    SUCURSAL,
    SUCURSALID,
    CAJA,
    CAJAID,
    TURNO,
    TURNOID,
    FECHA,
    SERIE,
    CONSECUTIVO,
    TOTAL,
    ESTATUSDOCTOID,
    TIPODOCTOID,
    REFERENCIA,
    FOLIO,
    DOCTOCORTEID,
    CAJACORTEID,
    TRANREGSERVER,
    SUCURSALDESTINO,
    SUCURSALDESTINONOMBRE,
    CAJEROID,
    SALDO,
    FOLIOSAT,
    SERIESAT,
    PERSONANOMBRE,
    CAJERONOMBRE,
    SUBTIPODOCTOID)
AS
select
       sucursal.clave SUCURSAL,
       docto.sucursalid,
       caja.clave CAJA,
       docto.cajaid,
       turno.clave TURNO,
       docto.turnoid, 
       docto.fecha FECHA,
       docto.serie SERIE,
       docto.id CONSECUTIVO,
       case when (docto.tipodoctoid = 41 or (docto.tipodoctoid = 11 and docto.subtipodoctoid = 23)) then docto.total - coalesce(dt.total,0) else docto.total end TOTAL  ,
       docto.estatusdoctoid,
       docto.tipodoctoid ,
       docto.referencia ,
       docto.folio    ,
       docto.corteid doctocorteid,
       c.corteid cajacorteid,
       docto.tranregserver ,
       str.clave SUCURSALDESTINO,
       str.nombre  SUCURSALNOMBRE,
       docto.vendedorid,
       docto.saldo ,
       docto.foliosat,
       docto.seriesat,
       p.nombre personanombre,
       c.nombre cajeronombre,
       DOCTO.SUBTIPODOCTOID
       from docto
left join sucursal on docto.sucursalid = sucursal.id
left join caja on docto.cajaid = caja.id
left join turno on docto.turnoid = turno.id
left join sucursal str on docto.sucursaltid = str.id
left join persona c on docto.vendedorid = c.id 
left join persona p on docto.personaid = p.id
left join docto dt on dt.fecha = docto.fecha and dt.tipodoctoid in (42,12)  and dt.doctorefid = docto.id --el traslado
where  docto.sucursalid = (select sucursalid from parametro)
;