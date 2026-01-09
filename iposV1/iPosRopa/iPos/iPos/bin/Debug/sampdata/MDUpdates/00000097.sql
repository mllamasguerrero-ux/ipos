insert into perfil_der( pd_perfil, pd_derecho)
select 12,MN_ID + 3000  from menuitems where mn_derecho in (1,2)



