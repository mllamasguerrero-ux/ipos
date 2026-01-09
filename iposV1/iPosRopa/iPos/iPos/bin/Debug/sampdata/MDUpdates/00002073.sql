create or alter procedure MOVIL_PRE_INVENTARIO_UPDATE
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable NAMESEQ varchar(64);
declare variable COMM varchar(64);
BEGIN


   DELETE FROM INVENTARIO;

   UPDATE PRODUCTO SET EXISTENCIA = 0;



   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1016;
      SUSPEND;
   END 
 END