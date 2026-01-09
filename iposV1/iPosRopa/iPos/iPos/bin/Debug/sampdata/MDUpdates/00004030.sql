execute block
as
begin

  
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10097, 'Editar precios por cliente');
  	
	
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 10097);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 10097);






end