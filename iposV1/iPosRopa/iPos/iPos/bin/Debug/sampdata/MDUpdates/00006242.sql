create or alter procedure CORTERECOLECCION_MONTOUPDATE (
    ID type of D_FK)
returns (
    ERRORCODE type of D_ERRORCODE)
as
declare variable MONTO D_PRECIO;
BEGIN

  ERRORCODE = 0;

    SELECT SUM(CORTE.saldoreal)
    FROM CORTE
    WHERE CORTERECOLECCIONID = :ID
    INTO :MONTO;


    update  CORTERECOLECCION
    set
        MONTO = :MONTO
    where
        ID=:ID;


   SUSPEND;
END