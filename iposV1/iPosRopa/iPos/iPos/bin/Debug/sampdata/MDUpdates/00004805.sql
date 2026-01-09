EXECUTE BLOCK
AS
BEGIN


  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10115, 'Permitir pago con tarjeta sin pinpad si esta configurada');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10116, 'Relacionar proveedor con cliente');
  	
  	
	
	

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 10115);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 10115);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 10116);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 10116);

  

END