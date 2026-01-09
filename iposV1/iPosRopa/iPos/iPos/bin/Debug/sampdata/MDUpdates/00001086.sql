CREATE OR ALTER VIEW CORTE_CALCULO_TOTALES(
    CORTEID,
    EFECTIVO,
    CREDITO,
    TARJETA,
    CHEQUE,
    CAMBIOCHEQUE,
    VALE,
    MONEDERO,
    INGRESOEFECTIVO,
    EGRESOEFECTIVO,
    INGRESOCREDITO,
    EGRESOCREDITO,
    INGRESOTARJETA,
    EGRESOTARJETA,
    INGRESOCHEQUE,
    EGRESOCHEQUE,
    INGRESOVALE,
    EGRESOVALE,
    INGRESOMONEDERO,
    EGRESOMONEDERO,
    DEVOLUCION,
    PAGOPROVEEDORES,
    RETIRO,
    APORTACION,
    INGRESO,
    EGRESO,
    TOTAL,
    SUBTOTALSINIVA,
    SUBTOTALCONIVA,
    MONTOIVA)
AS
SELECT
trans.corteid,



sum(case when trans.tipodoctoid not in (60,61) then trans.efectivo * cortecalculo.sentidoefectivo else 0 end) efectivo,
sum(trans.credito * cortecalculo.sentidocredito) credito,
sum(trans.tarjeta * cortecalculo.sentidotarjeta) tarjeta,
sum(trans.cheque * cortecalculo.sentidocheque) cheque,
sum(trans.cambiocheque * cortecalculo.sentidocambiocheque) cambiocheque,
sum(trans.vale * cortecalculo.sentidovale) vale  ,  
sum(trans.monedero * cortecalculo.sentidomonedero) monedero  ,



sum(case when cortecalculo.sentidoefectivo = 1 and trans.tipodoctoid not in (60,61) then trans.efectivo else 0 end ) efectivo_ingreso,
sum(case when cortecalculo.sentidoefectivo = -1 and trans.tipodoctoid not in (60,61) then trans.efectivo else 0 end ) efectivo_egreso,
sum(case when cortecalculo.sentidocredito = 1 then trans.credito else 0 end ) credito_ingreso,
sum(case when cortecalculo.sentidocredito = -1 then trans.credito else 0 end ) credito_egreso,
sum(case when cortecalculo.sentidotarjeta = 1 then trans.tarjeta else 0 end ) tarjeta_ingreso,
sum(case when cortecalculo.sentidotarjeta = -1 then trans.tarjeta else 0 end ) tarjeta_egreso,
sum(case when cortecalculo.sentidocheque = 1 then trans.cheque  else 0 end ) cheque_ingreso,
sum(case when cortecalculo.sentidocheque = -1 then trans.cheque  else 0 end ) cheque_egreso, 



sum(case when cortecalculo.sentidovale = 1 then trans.vale else 0 end ) vale_ingreso,
sum(case when cortecalculo.sentidovale = -1 then trans.vale else 0 end ) vale_egreso,

sum(case when cortecalculo.sentidomonedero = 1 then trans.monedero else 0 end ) monedero_ingreso,
sum(case when cortecalculo.sentidomonedero = -1 then trans.monedero else 0 end ) monedero_egreso,



sum(((case when trans.tipodoctoid = 22 then trans.efectivo * cortecalculo.sentidoefectivo else 0 end )) +
((case when trans.tipodoctoid = 22 then trans.credito * cortecalculo.sentidocredito else 0 end )) +
((case when trans.tipodoctoid = 22 then trans.tarjeta * cortecalculo.sentidotarjeta else 0 end )) +
((case when trans.tipodoctoid = 22 then trans.cheque * cortecalculo.sentidocheque else 0 end )) +
((case when trans.tipodoctoid = 22 then trans.cambiocheque * cortecalculo.sentidocambiocheque else 0 end )) +
((case when trans.tipodoctoid = 22 then trans.vale * cortecalculo.sentidovale else 0 end )) +
((case when trans.tipodoctoid = 22 then trans.monedero * cortecalculo.sentidomonedero else 0 end ))) devolucion,


sum(((case when trans.tipodoctoid = 60 then trans.efectivo * cortecalculo.sentidoefectivo else 0 end )) +
((case when trans.tipodoctoid = 60 then trans.credito * cortecalculo.sentidocredito else 0 end )) +
((case when trans.tipodoctoid = 60 then trans.tarjeta * cortecalculo.sentidotarjeta else 0 end )) +
((case when trans.tipodoctoid = 60 then trans.cheque * cortecalculo.sentidocheque else 0 end )) +
((case when trans.tipodoctoid = 60 then trans.cambiocheque * cortecalculo.sentidocambiocheque else 0 end )) +
((case when trans.tipodoctoid = 60 then trans.vale * cortecalculo.sentidovale else 0 end )) +
((case when trans.tipodoctoid = 60 then trans.monedero * cortecalculo.sentidomonedero else 0 end ))) pagoproveedores,

sum(((case when trans.tipodoctoid = 61 then trans.efectivo * cortecalculo.sentidoefectivo else 0 end )) +
((case when trans.tipodoctoid = 61 then trans.credito * cortecalculo.sentidocredito else 0 end )) +
((case when trans.tipodoctoid = 61 then trans.tarjeta * cortecalculo.sentidotarjeta else 0 end )) +
((case when trans.tipodoctoid = 61 then trans.cheque * cortecalculo.sentidocheque else 0 end )) +
((case when trans.tipodoctoid = 61 then trans.cambiocheque * cortecalculo.sentidocambiocheque else 0 end )) +
((case when trans.tipodoctoid = 61 then trans.vale * cortecalculo.sentidovale else 0 end )) +
((case when trans.tipodoctoid = 61 then trans.monedero * cortecalculo.sentidomonedero else 0 end ))) retiro,

0.00 aportacion ,

  
( sum(case when cortecalculo.sentidoefectivo = 1 then trans.efectivo else 0 end ) +
sum(case when cortecalculo.sentidocredito = 1 then trans.credito else 0 end ) +
sum(case when cortecalculo.sentidotarjeta = 1 then trans.tarjeta else 0 end ) +
sum(case when cortecalculo.sentidocheque = 1 then (trans.cheque - trans.cambiocheque) else 0 end ) +
sum(case when cortecalculo.sentidovale = 1 then trans.vale else 0 end ) +
sum(case when cortecalculo.sentidomonedero = 1 then trans.monedero else 0 end ) ) ingreso,


( sum(case when cortecalculo.sentidoefectivo = -1 then trans.efectivo else 0 end ) +
sum(case when cortecalculo.sentidocredito = -1 then trans.credito else 0 end ) +
sum(case when cortecalculo.sentidotarjeta = -1 then trans.tarjeta else 0 end ) +
sum(case when cortecalculo.sentidocheque = -1 then (trans.cheque - trans.cambiocheque) else 0 end ) +
sum(case when cortecalculo.sentidovale = -1 then trans.vale else 0 end ) +
sum(case when cortecalculo.sentidomonedero = -1 then trans.monedero else 0 end ) ) egreso,



sum((trans.efectivo * cortecalculo.sentidoefectivo) +
(trans.credito * cortecalculo.sentidocredito) +
(trans.tarjeta * cortecalculo.sentidotarjeta) +
(trans.cheque * cortecalculo.sentidocheque) +
(trans.cambiocheque * cortecalculo.sentidocambiocheque) +
(trans.vale * cortecalculo.sentidovale) +
(trans.monedero * cortecalculo.sentidomonedero)) total ,

sum(case when trans.tipodoctoid in (21,22,23,24,25,26) then coalesce(trans.subtotalsiniva,0) * cortecalculo.sentidoefectivo else 0 end) subtotalsiniva,
sum(case when trans.tipodoctoid in (21,22,23,24,25,26) then coalesce(trans.subtotalconiva,0)* cortecalculo.sentidoefectivo else 0 end) subtotalconiva,
sum(case when trans.tipodoctoid in (21,22,23,24,25,26) then coalesce(trans.montoiva,0) * cortecalculo.sentidoefectivo else 0 end) montoiva






from

CORTE_BASE trans

left join cortecalculo on cortecalculo.tipodoctoid = trans.tipodoctoid and
cortecalculo.tipoabonoid = trans.tipoabonoid and cortecalculo.mismocorte  =  trans.mismocorte

group by   trans.corteid
;