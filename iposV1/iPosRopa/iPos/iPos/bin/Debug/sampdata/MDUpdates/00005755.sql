CREATE OR ALTER VIEW TRANSACCIONESLISTA(
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
    SERIESAT,
    FOLIOSAT,
    ESFACTURAELECTRONICA,
    SUCDESTCLAVE,
    SUCDESTNOMBRE,
    SUCDESTID)
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
       docto.total TOTAL  ,
       docto.estatusdoctoid,
       docto.tipodoctoid ,
       docto.referencia ,
       docto.folio,
       docto.seriesat, 
       docto.foliosat ,
       DOCTO.esfacturaelectronica ,
       sucDest.clave SUCDESTCLAVE,
       sucDest.nombre SUCDESTNOMBRE,
       sucDest.id SUCDESTID
       from docto
left join sucursal on docto.sucursalid = sucursal.id
left join caja on docto.cajaid = caja.id
left join turno on docto.turnoid = turno.id
left join sucursal sucDest on sucDest.id = docto.sucursaltid
where  docto.sucursalid = (select sucursalid from parametro)
;