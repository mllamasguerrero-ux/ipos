execute block
as
begin

  
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10103, 'Borrar todas las promociones');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10104, 'Consultar Docto en Paralelo');
  	
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 10103);

end