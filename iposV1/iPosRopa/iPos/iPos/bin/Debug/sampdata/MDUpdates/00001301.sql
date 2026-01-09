CREATE OR ALTER VIEW CLIENTE_SALDO_VENCIDO(
    PERSONAID,
    SALDOVENCIDO)
AS
select d.personaid,  sum(d.saldo) saldovencido from docto d
inner join persona pr on d.personaid = pr.id
where d.tipodoctoid in (21,24)
and coalesce(d.saldo,0) > 0 and d.estatusdoctoid = 1
--and d.esapartado <> 'N'
and coalesce(pr.dias,0) > 0
and  dateadd(coalesce(pr.dias,0) day to d.fecha) < current_date
group by d.personaid
;