EXECUTE BLOCK
AS
BEGIN


  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (315, 'Reporte de ventas con autorizacion por precio bajo');
  	
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (315, 111, 'Ventas con autorizacion por precio bajo', 'Ventas con autorizacion por precio bajo', 315, 2, 13);

	
	

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 315);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 315);

  

END