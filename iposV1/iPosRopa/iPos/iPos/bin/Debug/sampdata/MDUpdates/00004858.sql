CREATE OR ALTER VIEW CORTE_CALCULO_NOAPLICADO(
    TIPOCORTE,
    CORTEID,
    TIPODOCTOID,
    MISMOCORTE,
    EFECTIVO_NOAPLICADO,
    TARJETA_NOAPLICADO,
    CHEQUE_NOAPLICADO,
    CAMBIOCHEQUE_NOAPLICADO,
    CREDITO_NOAPLICADO,
    VALE_NOAPLICADO,
    MONEDERO_NOAPLICADO,
    TOTAL_NOAPLICADO,
    NOAPLICA)
AS
SELECT
cortecalculo.nombre,
trans.corteid,
trans.tipodoctoid,
trans.mismocorte,


(trans.efectivo * (case when cortecalculo.sentidoefectivo = 0 then 1 else 0 end )) efectivo_noaplicado,
(trans.tarjeta * (case when cortecalculo.sentidotarjeta = 0 then 1 else 0 end )) tarjeta_noaplicado,
(trans.cheque * (case when cortecalculo.sentidocheque = 0 then 1 else 0 end )) cheque_noaplicado,
(trans.cambiocheque * (case when cortecalculo.sentidocambiocheque = 0 then 1 else 0 end )) cambiocheque_noaplicado,
(trans.credito * (case when cortecalculo.sentidocredito = 0 then 1 else 0 end )) credito_noaplicado,
(trans.vale * (case when cortecalculo.sentidovale = 0 then 1 else 0 end )) vale_noaplicado    ,      
(trans.monedero * (case when cortecalculo.sentidomonedero = 0 then 1 else 0 end )) monedero_noaplicado    ,



                  
((trans.efectivo * (case when cortecalculo.sentidoefectivo = 0 then 1 else 0 end )) +
(trans.credito * (case when cortecalculo.sentidocredito = 0 then 1 else 0 end )) +
(trans.tarjeta * (case when cortecalculo.sentidotarjeta = 0 then 1 else 0 end )) +
(trans.cheque * (case when cortecalculo.sentidocheque = 0 then 1 else 0 end )) +
(trans.cambiocheque * (case when cortecalculo.sentidocambiocheque = 0 then 1 else 0 end )) +
(trans.vale * (case when cortecalculo.sentidovale = 0 then 1 else 0 end )) +
(trans.monedero * (case when cortecalculo.sentidomonedero = 0 then 1 else 0 end )) ) total_noaplicado,


CASE when  (ABS(trans.efectivo * (case when cortecalculo.sentidoefectivo = 0 then 1 else 0 end )) +
ABS(trans.credito * (case when cortecalculo.sentidocredito = 0 then 1 else 0 end )) +
ABS(trans.tarjeta * (case when cortecalculo.sentidotarjeta = 0 then 1 else 0 end )) +
ABS(trans.cheque * (case when cortecalculo.sentidocheque = 0 then 1 else 0 end )) +
ABS(trans.cambiocheque * (case when cortecalculo.sentidocambiocheque = 0 then 1 else 0 end )) +
ABS(trans.vale * (case when cortecalculo.sentidovale = 0 then 1 else 0 end )) +
ABS(trans.monedero * (case when cortecalculo.sentidomonedero = 0 then 1 else 0 end )) ) = 0 THEN 'N' ELSE 'S' END AS NOAPLICA




from

CORTE_BASE trans

left join cortecalculo on cortecalculo.tipodoctoid = trans.tipodoctoid and
cortecalculo.tipoabonoid = trans.tipoabonoid and cortecalculo.mismocorte  =  trans.mismocorte
;