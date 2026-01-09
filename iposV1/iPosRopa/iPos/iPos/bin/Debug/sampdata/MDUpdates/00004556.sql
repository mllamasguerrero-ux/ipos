EXECUTE BLOCK
AS
BEGIN


  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10105, 'Ver saldo en listado de proveedores');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10106, 'Ver saldo en listado de clientes');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10107, 'Ordenar detalles por descripcion en venta');
  	
	

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 10105);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 10105);


	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 10106);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 10106);

  

END