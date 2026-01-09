execute block
as
declare variable PROVEEDORID D_FK;
declare variable SUMAORDENESCOMPRA D_PRECIO;
begin
   FOR SELECT ID FROM PERSONA WHERE TIPOPERSONAID = 40
        INTO :PROVEEDORID
        DO
        BEGIN
                
                SELECT SUM(coalesce(saldo,0.0) *  coalesce(tipodocto.sentidopago,0)) FROM DOCTO
                left join tipodocto on docto.tipodoctoid = tipodocto.id
                 WHERE PERSONAID = :PROVEEDORID and estatusdoctoid <> 0 INTO :SUMAORDENESCOMPRA;

                UPDATE PERSONA SET SALDO =  COALESCE(:SUMAORDENESCOMPRA,0)  * -1
                WHERE ID = :PROVEEDORID;
        END

    

end