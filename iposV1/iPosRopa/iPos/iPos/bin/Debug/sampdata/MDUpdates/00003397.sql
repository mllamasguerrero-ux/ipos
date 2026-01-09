execute block
as
declare corteid d_fk;
begin

   for select id from corte
        into :corteid
        do
        begin

        delete from corteieps where corteid = :corteid;

        insert into corteieps (corteid,tasaieps, monto)
        select CORTEID, TASAIEPS, round(coalesce(MONTOIEPS,0),2)
        from corte_base_por_ieps where corteid = :corteid;


        end


end