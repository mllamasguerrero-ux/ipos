execute block
as
begin

  insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10068, 'Agregar productos al surtir ventas a futuro');


	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 10068);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 10068);


end
