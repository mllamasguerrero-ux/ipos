create or alter procedure R_LISTALOTESINVENTARIO (
    DOCTOID D_FK,
    PRODUCTOID D_FK,
    SOLOCONEXISTENCIA char(1))
returns (
    LOTE D_LOTE,
    FECHAVENCE D_FECHAVENCE,
    VALOR D_STDTEXT_MEDIUM,
    NUMERO integer)
as
declare variable TIPODOCTOID D_FK;
BEGIN
    NUMERO = 0;

   FOR 
select inventario.lote, inventario.fechavence ,inventario.lote || ' | ' || case when inventario.fechavence is null  then '' else
EXTRACT(day FROM inventario.fechavence)||'/'
                || EXTRACT(month FROM inventario.fechavence)||'/'
                || EXTRACT(year FROM inventario.fechavence) END as valor
from inventario
where coalesce(inventario.lote,'')  <> ''
and productoid = :productoid  AND (:SOLOCONEXISTENCIA = 'N'  or coalesce(inventario.cantidad,0) > 0)
union
select movto.lote , movto.fechavence ,movto.lote || ' | ' || case when movto.fechavence is null  then '' else movto.fechavence END as valor
from movto
where movto.doctoid = :doctoid and movto.productoid = :productoid     and
coalesce(movto.lote,'')  <> ''
   INTO
      :LOTE,
      :FECHAVENCE,
      :VALOR


   DO
   BEGIN
   NUMERO = NUMERO + 1;
      SUSPEND;
   END

   if (:numero = 0) then
   begin
      LOTE = '';
      VALOR = '';
      FECHAVENCE  = current_date;
   end

END