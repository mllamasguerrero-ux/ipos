execute block
as  
declare variable cuenta integer;
begin

select count(*) from subtipodocto where id = 17 into :cuenta;

if(coalesce(:cuenta,0) = 0 ) then
begin
    	INSERT INTO SUBTIPODOCTO
	(ID, CLAVE, NOMBRE)
	VALUES
	(17, 'INVENTARIO X CAMBIO MANEJA LOTE','INVENTARIO X CAMBIO MANEJA LOTE');
end


end