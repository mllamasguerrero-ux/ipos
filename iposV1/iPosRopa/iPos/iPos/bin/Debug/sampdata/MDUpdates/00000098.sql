insert into perfil_der( pd_perfil, pd_derecho)
select 11,MN_ID + 3000  from menuitems where mn_derecho in (1,2,3)



