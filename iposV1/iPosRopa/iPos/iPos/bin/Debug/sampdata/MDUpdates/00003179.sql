update doctopago
set doctopago.formapagosatid =
(select first 1 id from formapagosat where formapagosat.formapagoid = doctopago.formapagoid)
where doctopago.formapagosatid is null  and doctopago.formapagoid in (1,2,3,5,14,15,16)
