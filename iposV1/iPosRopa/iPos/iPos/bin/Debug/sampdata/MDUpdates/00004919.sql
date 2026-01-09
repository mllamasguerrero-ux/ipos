execute block
as
declare variable tipoutilidadid D_FK;
begin
   SELECT FIRST 1 TIPOUTILIDADID FROM PARAMETRO INTO :TIPOUTILIDADID;

    UPDATE MOVTO
    SET UTILIDAD =  (  (case when coalesce(movto.estadorebaja,0) = 1 then cast(coalesce(movto.precioconrebaja,0.0) as d_precio) else cast(coalesce(movto.precio,0.0) as d_precio) end) -
                                                        (CASE WHEN :tipoutilidadid = 1 THEN cast(COALESCE(movto.costoreposicion,0.0) as d_precio)
                                                           WHEN :tipoutilidadid = 3 THEN cast(COALESCE(movto.costoultimo,0.0) as d_precio)
                                                           ELSE cast(COALESCE(movto.costopromedio,0.0) as d_precio) END ) )
                                                            * COALESCE(movto.cantidad, 0.0)
     WHERE MOVTO.fecha >= '01.01.2017' AND MOVTO.tipodoctoid = 21;

end