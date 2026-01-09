create or alter procedure PROMOCIONEXISTEPARALINEA (
    PROMOCIONID D_FK,
    LINEAID D_FK,
    FECHAINICIO D_FECHA,
    FECHAFIN D_FECHA,
    LUNES D_BOOLCN,
    MARTES D_BOOLCN,
    MIERCOLES D_BOOLCN,
    JUEVES D_BOOLCN,
    VIERNES D_BOOLCN,
    SABADO D_BOOLCN,
    DOMINGO D_BOOLCN)
returns (
    EXISTE D_BOOLCN,
    ERRORCODE type of D_ERRORCODE)
as
declare variable CUENTA integer;
BEGIN

   EXISTE = 'N';

   SELECT count(PROMOCION.ID)
    FROM PROMOCION WHERE 
     (PROMOCION.rangopromocionid = 2 AND PROMOCION.lineaid = :LINEAID )
     AND PROMOCION.fechainicio <= :FECHAINICIO AND PROMOCION.FECHAFIN >= :FECHAFIN
     AND
     (
     (PROMOCION.lunes = 'S' AND :LUNES = 'S' ) or
     (PROMOCION.martes = 'S' AND :MARTES  = 'S' ) or
     (PROMOCION.miercoles = 'S' AND :MIERCOLES  = 'S' ) or
     (PROMOCION.jueves = 'S' AND :JUEVES  = 'S' ) or
     (PROMOCION.viernes = 'S' AND :VIERNES  = 'S' ) or
     (PROMOCION.sabado = 'S' AND :SABADO  = 'S' ) or
     (PROMOCION.domingo = 'S' AND :DOMINGO  = 'S' )

     )
     AND PROMOCION.activo = 'S'
     AND COALESCE(PROMOCION.ID,0) <> :PROMOCIONID 
      INTO :CUENTA;


      IF(COALESCE(:CUENTA,0) > 0) THEN
      BEGIN
           EXISTE = 'S';
      END


   SUSPEND;

   
    WHEN ANY DO
    BEGIN
        ERRORCODE = 1001;
        SUSPEND;
    END

END