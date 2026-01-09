update parametro
set sucursalnumero = (select max(sucursal.clave) from sucursal where  sucursal.id = parametro.sucursalid)
