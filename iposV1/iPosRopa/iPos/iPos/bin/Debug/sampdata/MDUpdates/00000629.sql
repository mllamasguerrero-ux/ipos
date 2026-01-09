CREATE OR ALTER VIEW CORTE_CALCULO_SIN_EFECTIVO(
    TIPOCORTE,
    CORTEID,
    TIPODOCTOID,
    MISMOCORTE,
    TARJETA_APLICADO,
    CHEQUE_APLICADO,
    CAMBIOCHEQUE_APLICADO,
    CREDITO_APLICADO,
    VALE_APLICADO,
    MONEDERO_APLICADO,
    TARJETA_REAL,
    CHEQUE_REAL,
    CAMBIOCHEQUE_REAL,
    CREDITO_REAL,
    VALE_REAL,
    MONEDERO_REAL,
    TOTAL_APLICADO,
    APLICA)
AS
SELECT
cortecalculo.nombre,
trans.corteid,
trans.tipodoctoid,
trans.mismocorte,
(trans.tarjeta * cortecalculo.sentidotarjeta) tarjeta_aplicado,
(trans.cheque * cortecalculo.sentidocheque) cheque_aplicado,
(trans.cambiocheque * cortecalculo.sentidocambiocheque) cambiocheque_aplicado,
(trans.credito * cortecalculo.sentidocredito) credito_aplicado,
(trans.vale * cortecalculo.sentidovale) vale_aplicado    , 
(trans.monedero * cortecalculo.sentidomonedero) monedero_aplicado    ,

(trans.tarjeta ) tarjeta_real,
(trans.cheque ) cheque_real,    
(trans.cambiocheque ) cambiocheque_real,
(trans.credito ) credito_real,
(trans.vale ) vale_real ,     
(trans.monedero ) monedero_real ,

                  
(--(trans.efectivo * cortecalculo.sentidoefectivo) +
(trans.credito * cortecalculo.sentidocredito) +
(trans.tarjeta * cortecalculo.sentidotarjeta) +
(trans.cheque * cortecalculo.sentidocheque) +
(trans.cambiocheque * cortecalculo.sentidocambiocheque) +
(trans.vale * cortecalculo.sentidovale) +
(trans.monedero * cortecalculo.sentidomonedero) ) total_aplicado,


CASE when  (--ABS(trans.efectivo * cortecalculo.sentidoefectivo) +
ABS(trans.credito * cortecalculo.sentidocredito) +
ABS(trans.tarjeta * cortecalculo.sentidotarjeta) +
ABS(trans.cheque * cortecalculo.sentidocheque) +
ABS(trans.cambiocheque * cortecalculo.sentidocambiocheque) +
ABS(trans.vale * cortecalculo.sentidovale) +
ABS(trans.monedero * cortecalculo.sentidomonedero) ) = 0 THEN 'N' ELSE 'S' END AS APLICA




from

CORTE_BASE trans

left join cortecalculo on cortecalculo.tipodoctoid = trans.tipodoctoid and
cortecalculo.tipoabonoid = trans.tipoabonoid and cortecalculo.mismocorte  =  trans.mismocorte
;