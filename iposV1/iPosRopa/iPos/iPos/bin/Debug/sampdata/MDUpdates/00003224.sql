update docto
set hatenidocredito =
(select case when count(*) > 0 then 'S' else null end from doctopago where formapagoid in (4,6,7) and doctopago.doctoid = docto.id )
;
