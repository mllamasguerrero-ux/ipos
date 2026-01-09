execute block
as
begin

	UPDATE MENUITEMS
	SET MN_IDPARENT = 119 , MN_ORDEN = 1 
	WHERE MN_ID = 215;


  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10069, 'Atajo ctrl+p imprimir cotizacion, dejar pendiente y nueva');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10070, 'Eliminar abonos de clientes otros dias (revertir)');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10071, 'Eliminar abonos de clientes otros cajeros (revertir)');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10072, 'Eliminar abonos de clientes mismo dia ( revertir)');
  	insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10073, 'Eliminar abonos de clientes mismo cajero (revertir)');

 	insert into perfil_der
 	( pd_derecho, pd_perfil)
 	select 10070, pd_perfil
 	from perfil_der where pd_derecho = 79;

  	insert into perfil_der
 	( pd_derecho, pd_perfil)
 	select 10071, pd_perfil
 	from perfil_der where pd_derecho = 79;

 
  	insert into perfil_der
 	( pd_derecho, pd_perfil)
 	select 10072, pd_perfil
 	from perfil_der where pd_derecho = 79;

   	insert into perfil_der
 	( pd_derecho, pd_perfil)
 	select 10073, pd_perfil
 	from perfil_der where pd_derecho = 79;



end
