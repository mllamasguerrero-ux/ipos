execute block
as
begin

  
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (297, 'Informe facturas y notas de crédito fiscales');
  	
	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (297, 112, 'Informe facturas y notas de crédito fiscales', 'Informe facturas y notas de crédito fiscales', 297, 2, 2);

	
	

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 297);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 297);

INSERT INTO ERRORCODE (ID, CLAVE, NOMBRE)
  VALUES (5018, 'PRODUCTO NO APTO PARA LA IMPORT', 'PRODUCTO NO APTO PARA LA IMPORTACION, DEBE SER COMODIN, IVA IGUAL A 0 Y NO INVENTARIABLE');


end