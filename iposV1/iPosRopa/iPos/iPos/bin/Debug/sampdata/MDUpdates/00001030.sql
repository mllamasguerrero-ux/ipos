insert into perfil_der ( pd_perfil, pd_derecho)
select pd_perfil,  mn_id + 3000
from menuitems inner join
perfil_der on pd_derecho = mn_id
where mn_idparent = 1
and mn_id   in (81,82,83,88,89,91,94,95,97);