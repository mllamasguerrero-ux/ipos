CREATE OR ALTER VIEW ANTICIPOSLISTA(
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
    PERSONAID)
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
       docto.totalanticipo TOTAL  ,
       docto.estatusanticipoid ESTATUSDOCTOID,
       docto.tipodoctoid ,
       docto.referencia ,
       docto.folio    ,
       docto.corteid doctocorteid,
       c.corteid cajacorteid,
       docto.tranregserver ,
       str.clave SUCURSALDESTINO,
       str.nombre  SUCURSALNOMBRE,
       docto.vendedorid,
       docto.saldo * -1,
       docto.foliosat,
       docto.seriesat,
       p.nombre personanombre ,
       P.id personaid
       from docto
left join sucursal on docto.sucursalid = sucursal.id
left join caja on docto.cajaid = caja.id
left join turno on docto.turnoid = turno.id
left join sucursal str on docto.sucursaltid = str.id
left join persona c on docto.vendedorid = c.id 
left join persona p on docto.personaid = p.id
where  docto.sucursalid = (select sucursalid from parametro)
;