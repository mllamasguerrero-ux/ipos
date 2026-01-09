create or alter procedure QUOTA_UPDATE (
    VENDEDORID D_FK,
    ANIO integer,
    MES integer,
    QUOTA D_PRECIO)
returns (
    ERRORCODE type of D_ERRORCODE)
as
declare variable IDNEW D_FK;
declare variable CURRENT_ID D_FK;
BEGIN

    CURRENT_ID = NULL;
    SELECT ID FROM QUOTA WHERE VENDEDORID = :VENDEDORID AND ANIO = :ANIO AND MES = :MES INTO :CURRENT_ID;

    IF(:CURRENT_ID IS NOT NULL) THEN
    BEGIN
       
                UPDATE QUOTA SET QUOTA = :QUOTA
                WHERE ID = :CURRENT_ID;
    END
    ELSE
    BEGIN   
                INSERT INTO QUOTA (VENDEDORID, ANIO, MES, QUOTA, LOGRO, UTILIDAD)
                VALUES ( :VENDEDORID, :ANIO, :MES, :QUOTA, 0,  0)
                RETURNING ID INTO :IDNEW;
                
                IF ((:IDNEW IS NULL) OR (:IDNEW = 0)) THEN
                BEGIN
                    ERRORCODE = 1002;
                END

    END




   SUSPEND;

   
    WHEN ANY DO
    BEGIN
        ERRORCODE = 1001;
        SUSPEND;
    END

END