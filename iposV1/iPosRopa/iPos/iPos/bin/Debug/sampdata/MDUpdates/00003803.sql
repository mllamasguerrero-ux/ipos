execute block
as
begin

  update menuitems set mn_desc = 'Cuentas Por Pagar' , mn_etiqueta = 'Cuentas Por Pagar' where mn_id  = 119;

  update derechos set dr_descripcion = 'Cuentas Por Pagar'  where dr_derecho = 119;

  
  insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (253, 'Estados de Cuenta');
  insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (254, 'Abono a Proveedores');

	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (253, 119, 'Estados de Cuenta', 'Estados de Cuenta', 253, 2, 1);

	INSERT INTO MENUITEMS (MN_ID, MN_IDPARENT, MN_ETIQUETA, MN_DESC, MN_DERECHO, MN_LEVEL, MN_ORDEN) 
	VALUES (254, 119, 'Abono a Proveedores', 'Abono a Proveedores', 254, 2, 2);

	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 253);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 253);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (11, 254);
	INSERT INTO PERFIL_DER (PD_PERFIL, PD_DERECHO) VALUES (12, 254);


end
