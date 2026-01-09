EXECUTE BLOCK
AS
BEGIN


  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10117, 'Consultar ventas pendientes de varios dias');
  	

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 10117);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 10117);

  	insert into formapago
		(id, clave, nombre, esefectivo, abona, afectasaldopersona, afectasaldoapartados)
	values
		(20,'20 DEPOSITO', 'DEPOSITO','N','S','S','N');


  	insert into formapago
		(id, clave, nombre, esefectivo, abona, afectasaldopersona, afectasaldoapartados)
	values
		(21,'21 DEPOSITO TERCEROS', 'DEPOSITO TERCEROS','N','S','S','N');


END