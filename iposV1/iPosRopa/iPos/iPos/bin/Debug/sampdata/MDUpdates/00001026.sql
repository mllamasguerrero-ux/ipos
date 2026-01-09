insert into derechos (dr_derecho, dr_descripcion)
select mn_id + 2000, mn_desc || ' - Eliminacion'from menuitems
where mn_idparent = 1
and mn_id  in (81,82,83,88,89,91,94,95,97) ;