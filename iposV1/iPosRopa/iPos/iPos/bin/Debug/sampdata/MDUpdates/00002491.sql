CREATE OR ALTER VIEW PRODUCTOAUTOCOMPLETE(
    DESCRIPCION1,
    CLAVE,
    ADICIONAL)
AS
select descripcion1, clave,
    case when coalesce(producto.pzacaja,0) > 1 then
       cast( floor(coalesce(producto.existencia,0)/coalesce(producto.pzacaja,0)) as varchar(15)) || ' CJ '  ||  cast(floor((coalesce(producto.existencia,0)) -  (floor(coalesce(producto.existencia,0)/coalesce(producto.pzacaja,0)) * coalesce(producto.pzacaja,0))) as varchar(15)) || ' PZA'
    else cast(floor(coalesce(producto.existencia,0)) as varchar(15)) end adicional from producto    
      left join parametro PM on 1 = 1
      where coalesce(pm.esvendedormovil,'N') = 'N' or coalesce(producto.activo,'S') = 'S'
;