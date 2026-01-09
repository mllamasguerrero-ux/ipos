execute block
as
begin

  
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10089, 'Modificar estado de bitacora');
  	
	
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 10089);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 10089);





end