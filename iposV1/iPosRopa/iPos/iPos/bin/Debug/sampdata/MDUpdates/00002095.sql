create or alter procedure MOVILVISITA_ASIGNARHIZOPEDIDO (
    VISITAID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable CANTIDADVENTAS integer;
declare variable CANTIDADPEDIDOS integer;
declare variable HIZOPEDIDO D_CHAR;
BEGIN

select sum(case when docto.estatusdoctoid = 1 then 1 else 0 end) ventas,
sum(case when docto.estatusdoctoid = 0 then 1 else 0 end) pedidos
  from VISITA inner join DOCTO  on visita.personaid = docto.personaid
and visita.horainicio <= docto.fechahora and coalesce(visita.horafin, '2200-01-01') >= docto.fechahora
where docto.estatusdoctoid in (0,1) and docto.tipodoctoid = 321 AND visita.id = :VISITAID
INTO :CANTIDADVENTAS, :CANTIDADPEDIDOS;


IF(:CANTIDADVENTAS > 0) THEN
BEGIN
        UPDATE VISITA SET HIZOPEDIDO = 'V' WHERE ID = :VISITAID;
END
ELSE IF(:CANTIDADPEDIDOS > 0) THEN
BEGIN              
        UPDATE VISITA SET HIZOPEDIDO = 'P' WHERE ID = :VISITAID;

END
ELSE
BEGIN
         UPDATE VISITA SET HIZOPEDIDO = 'N' WHERE ID = :VISITAID;
END


   ERRORCODE = 0;
   SUSPEND;
   
    WHEN ANY DO
    BEGIN
        ERRORCODE = 3501;
        SUSPEND;
    END


END