EXECUTE BLOCK
AS
BEGIN
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (323, 'Generar datos para vendedor movil');
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (323, 320, 'Generar datos para vendedor movil', 'Generar datos para vendedor movil', 323, 2, 3);

	
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 323);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 323);

END