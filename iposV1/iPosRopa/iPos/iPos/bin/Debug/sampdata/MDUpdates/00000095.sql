insert into perfil_der( pd_perfil, pd_derecho)
select 11,MN_ID + 2000  from menuitems where mn_derecho in (1,2,3)

