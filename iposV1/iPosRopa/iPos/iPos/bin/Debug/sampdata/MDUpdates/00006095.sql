execute block
as
declare variable PERSONAID D_FK;
declare variable ERRORCODE D_ERRORCODE;
begin


    FOR SELECT ID FROM PERSONA WHERE TIPOPERSONAID = 50
        INTO :PERSONAID
        DO
        BEGIN
            
            SELECT ERRORCODE FROM PERSONA_AJUSTAR_SALDOS(:PERSONAID) INTO :ERRORCODE;
        END

end