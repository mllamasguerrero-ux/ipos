CREATE OR ALTER VIEW CORTE_CALCULO_DETALLE(
    TIPOCORTE,
    CORTEID,
    TIPODOCTOID,
    MISMOCORTE,
    EFECTIVO_APLICADO,
    TARJETA_APLICADO,
    CHEQUE_APLICADO,
    CAMBIOCHEQUE_APLICADO,
    CREDITO_APLICADO,
    VALE_APLICADO,
    MONEDERO_APLICADO,
    EFECTIVO_REAL,
    TARJETA_REAL,
    CHEQUE_REAL,
    CAMBIOCHEQUE_REAL,
    CREDITO_REAL,
    VALE_REAL,
    MONEDERO_REAL,
    TOTAL_APLICADO,
    APLICA,
    TRANSFERENCIA_REAL,
    TRANSFERENCIA_APLICADO,
    INDEFINIDO_REAL,
    INDEFINIDO_APLICADO)
AS
SELECT
cortecalculo.nombre,
trans.corteid,
trans.tipodoctoid,
trans.mismocorte,
(trans.efectivo * cortecalculo.sentidoefectivo) efectivo_aplicado,
(trans.tarjeta * cortecalculo.sentidotarjeta) tarjeta_aplicado,
(trans.cheque * cortecalculo.sentidocheque) cheque_aplicado,
(trans.cambiocheque * cortecalculo.sentidocambiocheque) cambiocheque_aplicado,
(trans.credito * cortecalculo.sentidocredito) credito_aplicado,
(trans.vale * cortecalculo.sentidovale) vale_aplicado    ,   
(trans.monedero * cortecalculo.sentidomonedero) monedero_aplicado    ,


(trans.efectivo ) efectivo_real, 
(trans.tarjeta ) tarjeta_real,
(trans.cheque ) cheque_real,    
(trans.cambiocheque ) cambiocheque_real,
(trans.credito ) credito_real,
(trans.vale ) vale_real ,     
(trans.monedero ) monedero_real ,

                  
((trans.efectivo * cortecalculo.sentidoefectivo) +
(trans.credito * cortecalculo.sentidocredito) +
(trans.tarjeta * cortecalculo.sentidotarjeta) +
(trans.cheque * cortecalculo.sentidocheque) +
(trans.cambiocheque * cortecalculo.sentidocambiocheque) +
(trans.vale * cortecalculo.sentidovale)+
(trans.monedero * cortecalculo.sentidomonedero)+
(trans.transferencia * cortecalculo.sentidotransferencia)+
(trans.indefinido * cortecalculo.sentidoindefinido) ) total_aplicado,


CASE when  (ABS(trans.efectivo * cortecalculo.sentidoefectivo) +
ABS(trans.credito * cortecalculo.sentidocredito) +
ABS(trans.tarjeta * cortecalculo.sentidotarjeta) +
ABS(trans.cheque * cortecalculo.sentidocheque) +
ABS(trans.cambiocheque * cortecalculo.sentidocambiocheque) +
ABS(trans.vale * cortecalculo.sentidovale) +
ABS(trans.monedero * cortecalculo.sentidomonedero) +
ABS(trans.transferencia * cortecalculo.sentidotransferencia) +
ABS(trans.indefinido * cortecalculo.sentidoindefinido) ) = 0 THEN 'N' ELSE 'S' END AS APLICA,


(trans.transferencia ) transferencia_real ,
(trans.transferencia * cortecalculo.sentidotransferencia) transferencia_aplicado  ,

(trans.indefinido ) indefinido_real ,
(trans.indefinido * cortecalculo.sentidoindefinido) indefinido_aplicado


from

CORTE_BASE trans

left join cortecalculo on cortecalculo.tipodoctoid = trans.tipodoctoid and
cortecalculo.tipoabonoid = trans.tipoabonoid and cortecalculo.mismocorte  =  trans.mismocorte
;