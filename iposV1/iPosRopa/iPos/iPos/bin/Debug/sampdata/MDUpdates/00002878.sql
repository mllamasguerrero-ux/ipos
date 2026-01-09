CREATE or alter  trigger movto_au_ordencompra for movto
active after update position 8
AS
declare variable movtoidordencompra d_fk ;
--declare variable doctoid d_fk ;
begin
  /* Trigger text */



  IF(NEW.TIPODOCTOID = 11  ) THEN
  BEGIN

        if(old.estatusmovtoid = 0 and new.estatusmovtoid = 1) then
        begin
              select first 1 movto.id from docto left join movto on movto.doctoid = docto.doctorefid
              where docto.id = new.doctoid and movto.productoid = new.productoid and
              /*coalesce(movto.lote ,'') = coalesce(new.lote,'') and
              coalesce(movto.fechavence,current_date) = coalesce(new.fechavence, current_date) and*/
              coalesce(movto.precio,0) = coalesce(new.precio, 0) and
              docto.subtipodoctoid = 16

              into :movtoidordencompra;

              if (coalesce(:movtoidordencompra,0) <> 0) then
              begin
                update movto set
                cantidadsurtida = coalesce(cantidadsurtida,0) +  new.cantidad, 
                cantidadfaltante =  coalesce(cantidadfaltante,0) -  new.cantidad
                where id = :movtoidordencompra;
              end
        end


        
        if(old.estatusmovtoid = 1 and new.estatusmovtoid = 2) then
        begin
              select first 1 movto.id from docto left join movto on movto.doctoid = docto.doctorefid
              where docto.id = new.doctoid and movto.productoid = new.productoid and
              coalesce(movto.precio,0) = coalesce(new.precio, 0) and
              docto.subtipodoctoid = 16

              into :movtoidordencompra;

              if (coalesce(:movtoidordencompra,0) <> 0) then
              begin
                update movto set
                cantidadsurtida = coalesce(cantidadsurtida,0) -  new.cantidad,
                cantidadfaltante =  coalesce(cantidadfaltante,0) +  new.cantidad
                where id = :movtoidordencompra;
              end
        end

  END



       /*
  IF( NEW.TIPODOCTOID = 13 ) THEN
  BEGIN

        if(old.estatusmovtoid = 0 and new.estatusmovtoid = 1) then
        begin
              select first 1 movto.id from docto doctocanc
              left join docto on docto.id = doctocanc.doctorefid
              left join movto on movto.doctoid = docto.doctorefid
              where doctocanc.id = new.doctoid and movto.productoid = new.productoid and
              coalesce(movto.precio,0) = coalesce(new.precio, 0) and
              docto.subtipodoctoid = 16
              into :movtoidordencompra;

              insert into traza(valor) values(cast(:movtoidordencompra as varchar(20)));

              if (coalesce(:movtoidordencompra,0) <> 0) then
              begin
                update movto set
                cantidadsurtida = coalesce(cantidadsurtida,0) -  new.cantidad,
                cantidadfaltante =  coalesce(cantidadfaltante,0) +  new.cantidad
                where id = :movtoidordencompra;
              end
        end


  END



  IF(NEW.TIPODOCTOID = 15 ) THEN
  BEGIN

        if(old.estatusmovtoid = 0 and new.estatusmovtoid = 1) then
        begin
              select first 1 movto.id from docto devo
              left join docto doctocanc on doctocanc.id = devo.doctorefid
              left join docto on docto.id = doctocanc.doctorefid
              left join movto on movto.doctoid = docto.doctorefid
              where devo.id = new.doctoid and movto.productoid = new.productoid and

              coalesce(movto.precio,0) = coalesce(new.precio, 0) and
              docto.subtipodoctoid = 16
              into :movtoidordencompra;

              if (coalesce(:movtoidordencompra,0) <> 0) then
              begin
                update movto set
                cantidadsurtida = coalesce(cantidadsurtida,0) +  new.cantidad,
                cantidadfaltante =  coalesce(cantidadfaltante,0) -  new.cantidad
                 where id = :movtoidordencompra;
              end
        end


  END     */


end
