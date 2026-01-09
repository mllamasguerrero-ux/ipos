EXECUTE BLOCK
AS
BEGIN
      
   insert into TIPOEVENTOTABLA(ID, ACTIVO, CLAVE, NOMBRE) 
     values (1, 'S', 'NOTACLIENTE' , 'NOTA CLIENTE');


   insert into TIPOEVENTOTABLA(ID, ACTIVO, CLAVE, NOMBRE) 
     values (2, 'S', 'BLOQUEO' , 'BLOQUEO');


   insert into TIPOEVENTOTABLA(ID, ACTIVO, CLAVE, NOMBRE) 
     values (3, 'S', 'DESBLOQUEO' , 'DESBLOQUEO');


end