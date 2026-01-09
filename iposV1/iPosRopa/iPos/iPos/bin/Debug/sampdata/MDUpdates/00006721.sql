EXECUTE BLOCK
AS
BEGIN
      insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (10173, 'Venta de stand');

	insert into subtipodocto 
	(id, activo, clave, nombre)
	values
	(31,'S','VENTA STAND','VENTA STAND');

end