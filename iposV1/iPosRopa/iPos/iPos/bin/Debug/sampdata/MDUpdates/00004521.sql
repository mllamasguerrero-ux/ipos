EXECUTE BLOCK
AS
BEGIN


  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (301, 'Catalogo Cuentas PVC');
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (301, 218, 'Catalogo Cuentas PVC', 'Catalogo Cuentas PVC', 301, 2, 7);

	

  

END