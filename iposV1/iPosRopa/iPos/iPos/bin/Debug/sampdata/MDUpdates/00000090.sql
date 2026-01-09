insert into perfil_der( pd_perfil, pd_derecho)
select 8,MN_ID + 1000 from menuitems where mn_derecho = 1
