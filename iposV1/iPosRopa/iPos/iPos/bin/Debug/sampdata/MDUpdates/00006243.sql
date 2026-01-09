create or alter procedure CORTERECOLECCION_CANCEL (
    ID type of D_FK)
returns (
    ERRORCODE type of D_ERRORCODE)
as
declare variable FECHAULTIMA D_FECHA;
BEGIN

  ERRORCODE = 0;


    update  CORTERECOLECCION
    set
        ACTIVO = 'N'
    where
        ID=:ID;

     UPDATE CORTE SET CORTERECOLECCIONID = 0
     WHERE CORTERECOLECCIONID = :ID;

   SUSPEND;
END