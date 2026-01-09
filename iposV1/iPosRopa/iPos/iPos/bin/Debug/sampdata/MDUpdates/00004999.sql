EXECUTE BLOCK
AS
BEGIN
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (326, 'Reporte de faltantes de vendedor movil');
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (326, 320, 'Reporte de faltantes de vendedor movil', 'Reporte de faltantes de vendedor movil', 326, 2, 5);

	
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 326);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 326);

END