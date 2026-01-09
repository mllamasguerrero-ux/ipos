update cuenta
set clave = replace(clave, ' CONTADO', '')
where tipolineapolizaid in (11,12,13)
