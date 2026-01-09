execute block
as  
declare variable cuenta integer;
begin

select count(*) from derechos where dr_derecho = 1 into :cuenta;

if(coalesce(:cuenta,0) = 0 ) then
begin
    	INSERT INTO DERECHOS
	(DR_DERECHO, DR_DESCRIPCION)
	VALUES
	(1, 'Catalogos');
end


end