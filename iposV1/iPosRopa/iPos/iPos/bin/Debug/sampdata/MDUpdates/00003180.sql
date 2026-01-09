update persona set persona.creditoformapagosatabonos =
(select first 1 id from formapagosat where formapagosat.formapagoid = persona.creditoformapagosatabonos)
where persona.tipopersonaid = 50 and coalesce(persona.creditoformapagoabonos ,0) <> 0
and coalesce(persona.creditoformapagosatabonos,0) = 0

