create or alter procedure DEVO_REASIGNARCORTEYFECHA (
    DOCTOID D_FK,
    FECHA D_FECHA,
    VENDEDORID D_FK,
    OPCIONVENDEDOR D_CLAVE_NULL
    )
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable VENDEDORAPLICARID D_FK;   
declare variable VENDEDORNCID D_FK;
declare variable VENDEDORVENTAID D_FK;  
declare variable VENTAID D_FK;
declare variable SUCURSALID D_FK;
declare variable CORTEID D_FK;

declare variable CORTEEXISTENTE D_BOOLCN; 
declare variable CORTEACTIVOPREVIAMENTE D_BOOLCN;

declare variable SALDOINICIAL D_IMPORTE;
declare variable INGRESO D_IMPORTE;
declare variable EGRESO D_IMPORTE;
declare variable DEVOLUCION D_IMPORTE;
declare variable APORTACION D_IMPORTE;
declare variable RETIRO D_IMPORTE;
declare variable SALDOFINAL D_IMPORTE;
declare variable SALDOREAL D_IMPORTE;
declare variable SALDOREALCREDITO D_IMPORTE;
                                               
declare variable CORTEANTERIORID D_FK;
         
declare variable CORTEVENDEDORID D_FK;

BEGIN

   VENTAID = 0;
   VENDEDORVENTAID = 0;


   SELECT DOCTO.doctorefid , DOCTO.VENDEDORID, DOCTO.CORTEID
   FROM DOCTO
   WHERE ID = :DOCTOID
   INTO :VENTAID, :VENDEDORNCID, :CORTEANTERIORID;


   IF(COALESCE(:VENTAID,0) <> 0 ) THEN
   BEGIN
        SELECT VENDEDORID FROM DOCTO WHERE ID = :VENTAID INTO :VENDEDORVENTAID;
   END


   IF(COALESCE(:OPCIONVENDEDOR ,'MISMONC') = 'MISMONC') THEN
   BEGIN
         VENDEDORAPLICARID =  :VENDEDORNCID;
   END
   ELSE IF(COALESCE(:OPCIONVENDEDOR ,'MISMONC') = 'MISMOVENTA') THEN
   BEGIN
         VENDEDORAPLICARID =  :VENDEDORVENTAID;
   END  
   ELSE IF(COALESCE(:OPCIONVENDEDOR ,'MISMONC') = 'ESPECIFICO') THEN
   BEGIN
         VENDEDORAPLICARID =  :VENDEDORID;
   END
   ELSE
   BEGIN
       VENDEDORAPLICARID =  :VENDEDORNCID;
   END




             -- SELECCIONAR EL CORTE CORRSPONDIENTE
  SELECT PARAMETRO.sucursalid FROM PARAMETRO INTO :SUCURSALID;

   SELECT ID,
         ACTIVO
    FROM CORTE WHERE CAJEROID = :VENDEDORAPLICARID AND FECHACORTE = :FECHA INTO :CORTEID, :CORTEACTIVOPREVIAMENTE;


   --CONSERVAR EL CORTE ORIGINAL DEL VENDEDOR
    SELECT CORTEID FROM PERSONA WHERE ID = :VENDEDORAPLICARID INTO :CORTEVENDEDORID;


   IF(COALESCE(:CORTEID , 0) = 0) THEN
   BEGIN
       CORTEEXISTENTE = 'N';
       CORTEACTIVOPREVIAMENTE = 'N';


       SELECT ERRORCODE,  CORTEID FROM
        CORTE_ABRIR (
                :FECHA,
                :SUCURSALID ,
                :VENDEDORAPLICARID ,
                0,
            1) INTO :ERRORCODE, :CORTEID;


         UPDATE PERSONA SET CORTEID = :CORTEVENDEDORID WHERE ID = :VENDEDORAPLICARID;

            
        IF (:ERRORCODE > 0) THEN
        BEGIN
            SUSPEND;
            EXIT;
        END
   END
   ELSE
   BEGIN
       CORTEEXISTENTE = 'S';
   END




   update DOCTO SET
   FECHA = :FECHA,
   CORTEID = :CORTEID ,
   VENDEDORID = :VENDEDORAPLICARID
   WHERE ID = :DOCTOID;

   update doctopago set corteid = :CORTEID
   where doctosalidaid = :doctoid and corteid = :CORTEANTERIORID;




   
   --actualizar corte anterior
      SELECT ERRORCODE
                  FROM CORTE_TOTALES_PORID( :CORTEANTERIORID) INTO :ERRORCODE;


                  
      IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
      BEGIN
                        SUSPEND;
                        EXIT;
      END



      -- actualizar corte nuevo


           SELECT SALDOINICIAL ,
                  INGRESO ,
                  EGRESO ,
                  DEVOLUCION ,
                  APORTACION ,
                  RETIRO ,
                  SALDOFINAL ,
                  SALDOREAL ,
                  SALDOREALCREDITO   ,
                  ERRORCODE
                  FROM CORTE_TOTALES_PORID( :CORTEID)
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
                    :ERRORCODE ;

                    
                    IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
                    BEGIN
                        SUSPEND;
                        EXIT;
                    END

   IF(  :CORTEEXISTENTE = 'N' ) THEN
   BEGIN
        



                   SELECT ERRORCODE FROM CORTE_CERRAR (
                    :SUCURSALID ,
                    :CORTEID ,
                    :FECHA ,
                    :VENDEDORAPLICARID ,
                    :SALDOINICIAL ,
                    :INGRESO ,
                    :EGRESO ,
                    :DEVOLUCION ,
                    :APORTACION ,
                    :RETIRO ,
                    :SALDOFINAL ,
                    :SALDOREAL ,
                    :SALDOREAL - :SALDOFINAL,
                    :SALDOREALCREDITO)
                    INTO :ERRORCODE;

                    
                    UPDATE PERSONA SET CORTEID = :CORTEVENDEDORID WHERE ID = :VENDEDORAPLICARID;

                IF ((:ERRORCODE IS NOT NULL) AND (:ERRORCODE > 0)) THEN
                BEGIN
                        SUSPEND;
                        EXIT;
                END


   END










END
