EXECUTE BLOCK
AS
BEGIN


  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (303, 'Importacion de ventas/nc/otros');
  	
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (303, 263, 'Importacion de ventas/nc/otros', 'Importacion de ventas/nc/otros', 303, 2, 90);

	
	
  

END