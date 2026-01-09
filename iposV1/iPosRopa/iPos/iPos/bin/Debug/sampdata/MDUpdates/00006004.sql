EXECUTE BLOCK
AS
BEGIN


     insert into tipoincidencia(id,clave, nombre) values(1,'MAYORCANTIDAD','SE REGISTRO MAYOR CANTIDAD EN SURTIDO');

     insert into tipoincidencia(id,clave, nombre) values(2,'MENORCANTIDAD','SE REGISTRO MENOR CANTIDAD EN SURTIDO');

     insert into tipoincidencia(id,clave, nombre) values(3,'CANCELACION SURTIDO','CANCELACION SURTIDO');

     insert into tipoincidencia(id,clave, nombre) values(4,'NOTA SURTIDO','NOTA SURTIDO');

     insert into tipoincidencia(id,clave, nombre) values(5,'CAMBIO DIRECTO DE CANTIDAD','CAMBIO DIRECTO DE CANTIDAD');



     insert into ESTADOREVISADO(id,clave, nombre) values(1,'REVISADO','REVISADO');
     insert into ESTADOREVISADO(id,clave, nombre) values(2,'ENPROCESO','ENPROCESO');


end