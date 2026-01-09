execute block
as  
declare variable cuenta integer;
begin

select count(*) from subtipodocto where id = 19 into :cuenta;

if(coalesce(:cuenta,0) = 0 ) then
begin
    	INSERT INTO SUBTIPODOCTO
	(ID, CLAVE, NOMBRE)
	VALUES
	(19, 'INV. ENTRADA CAMB. MANEJALOTE','INV. ENTRADA CAMB. MANEJALOTE');
end


end