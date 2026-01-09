create or alter procedure CORTE_MOVIL_ASEGURAR (
    VENDEDORID D_FK)
returns (
    ERRORCODE type of D_ERRORCODE)
as
declare variable SUCURSALID D_FK;
declare variable ESFACTURAELECTRONICA D_BOOLCN;
declare variable HAYCORTEACTIVO D_BOOLCN;
declare variable CORTEID D_FK;
declare variable FECHACORTE D_FECHA;
declare variable FECHA D_FECHA;
declare variable SALDOINICIAL D_IMPORTE;
declare variable INGRESO D_IMPORTE;
declare variable EGRESO D_IMPORTE;
declare variable DEVOLUCION D_IMPORTE;
declare variable APORTACION D_IMPORTE;
declare variable RETIRO D_IMPORTE;
declare variable SALDOFINAL D_IMPORTE;
declare variable SALDOREAL D_IMPORTE;
declare variable SALDOREALCREDITO D_IMPORTE;
declare variable FONDODINAMICO D_IMPORTE;
BEGIN

   ERRORCODE = 0;
 SELECT SUCURSALID FROM PARAMETRO INTO :SUCURSALID;
   
        SELECT HAYCORTEACTIVO,CORTEID,ERRORCODE, FECHACORTE
        FROM HAY_CORTE_ACTIVO(:VENDEDORID)
        INTO :HAYCORTEACTIVO, :CORTEID, :ERRORCODE, :FECHACORTE;
        
        IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0) and (:ERRORCODE <> 1001)) THEN
        BEGIN
                        SUSPEND;
                        EXIT;
        END


        IF(:HAYCORTEACTIVO = 'S' AND :FECHACORTE < CURRENT_DATE ) THEN
        BEGIN
           SELECT SALDOINICIAL ,
                  INGRESO ,
                  EGRESO ,
                  DEVOLUCION ,
                  APORTACION ,
                  RETIRO ,
                  SALDOFINAL ,
                  SALDOREAL ,
                  SALDOREALCREDITO   ,
                  FONDODINAMICO,
                  ERRORCODE
                  FROM CORTE_TOTALES ( :SUCURSALID , :VENDEDORID)
                  INTO
                    :SALDOINICIAL ,
                    :INGRESO ,
                    :EGRESO ,
                    :DEVOLUCION ,
                    :APORTACION ,
                    :RETIRO ,
                    :SALDOFINAL ,
                    :SALDOREAL ,
                    :SALDOREALCREDITO,
                    :FONDODINAMICO,
                    :ERRORCODE ;

                    
                    IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
                    BEGIN
                        SUSPEND;
                        EXIT;
                    END


                   SELECT ERRORCODE FROM CORTE_CERRAR (
                    :SUCURSALID ,
                    :CORTEID ,
                    :FECHACORTE ,
                    :VENDEDORID ,
                    :SALDOINICIAL ,
                    :INGRESO ,
                    :EGRESO ,
                    :DEVOLUCION ,
                    :APORTACION ,
                    :RETIRO ,
                    :SALDOFINAL ,
                    :SALDOREAL ,
                    :SALDOREAL - :SALDOFINAL,
                    :SALDOREALCREDITO,
                    :FONDODINAMICO)
                    INTO :ERRORCODE;

                IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
                BEGIN
                        SUSPEND;
                        EXIT;
                END

                HAYCORTEACTIVO = 'N';
        END

        IF(:HAYCORTEACTIVO = 'N') THEN
        BEGIN

                SELECT CORTEID, ERRORCODE FROM  CORTE_ABRIR (
                    CURRENT_DATE,
                    :SUCURSALID,
                    :VENDEDORID,
                    0,
                    2) INTO :CORTEID, :ERRORCODE;

                    
                IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
                BEGIN
                        SUSPEND;
                        EXIT;
                END

        END



   SUSPEND;

   
    WHEN ANY DO
    BEGIN
        ERRORCODE = 1001;
        SUSPEND;
    END

END