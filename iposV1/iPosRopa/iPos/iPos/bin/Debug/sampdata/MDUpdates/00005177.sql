execute block
as
begin
insert into subtipodocto 
(id, activo, clave, nombre)
values
(26,'S','SUSTITUTO SAT','SUSTITUTO SAT');


update or insert into subtipodocto  (id, activo, clave, nombre)
  values (25,'S','VENTA FUTURO APLICADA','VENTA FUTURO APLICADA')
  matching (id);

end