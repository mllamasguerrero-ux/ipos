execute block
as  
declare variable cuenta integer;
begin

select count(*) from subtipodocto where id = 18 into :cuenta;

if(coalesce(:cuenta,0) = 0 ) then
begin
    	INSERT INTO SUBTIPODOCTO
	(ID, CLAVE, NOMBRE)
	VALUES
	(18, 'INV. SALIDA CAMB. MANEJALOTE','INV. SALIDA CAMB. MANEJALOTE');
end


end