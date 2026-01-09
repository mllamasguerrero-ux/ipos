 
update SUCURSAL 
set gruposucursalid = (select max(id) from gruposucursal) 
where gruposucursalid = 200; 