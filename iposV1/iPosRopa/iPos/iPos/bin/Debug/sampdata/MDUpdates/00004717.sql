update persona
set persona.pais = 'MEX', persona.sat_clave_pais = 'MEX'
where persona.tipopersonaid in (22,40,50,60)
and coalesce(persona.pais,'México') in ('mexico', 'MEXICO', 'Mexico', 'méxico', 'MéXICO', 'México')