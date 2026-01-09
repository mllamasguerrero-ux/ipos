execute block
as  
declare variable cuenta integer;
begin

select count(*) from derechos where dr_derecho = 220 into :cuenta;

if(coalesce(:cuenta,0) = 0 ) then
begin
    insert into derechos(DR_DERECHO, DR_DESCRIPCION) values (220, 'Gastos de contabilidad');
end


end