EXECUTE BLOCK
AS
BEGIN

  insert into derechos
  (dr_derecho, dr_descripcion)
  values(10184, 'Filtrar gastos por almacen');

  insert into perfil_der
  (pd_perfil, pd_derecho)
  values(11, 10184);
  
  insert into perfil_der
  (pd_perfil, pd_derecho)
  values(12, 10184);


END
