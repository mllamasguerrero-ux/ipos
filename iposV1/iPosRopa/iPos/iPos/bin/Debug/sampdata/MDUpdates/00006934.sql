create or alter procedure MOVILPAGO_PROCESAR (
    R_PAGOMOVILID D_FK,
    VENDEDORID D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable PERSONACLAVE D_CLAVE_NULL;
declare variable BANCOTEXT D_NOMBRE_NULL;
declare variable REFERENCIABANCARIA D_STDTEXT_LIGHT;
declare variable FORMAPAGOID D_FK;
declare variable PROCESADO D_CHAR;
declare variable FECHAELABORACION D_FECHA;
declare variable FECHARECEPCION D_FECHA;
declare variable VENTACOBRANZA D_STDTEXT_64;
declare variable IMPORTEPAGO D_IMPORTE;
declare variable CORTEID D_FK;
declare variable HAYCORTEACTIVO D_BOOLCN;
declare variable TIPOPAGOID D_FK;
declare variable FECHA D_FECHA;
declare variable FECHAHORA D_TIMESTAMP;
declare variable DOCTOID D_FK;
declare variable BANCOID D_FK;
declare variable NOTAS D_STDTEXT_MEDIUM;
declare variable PAGOID D_FK;
declare variable REFINTERNO D_STDTEXT_SHORT;
declare variable IMPORTE D_IMPORTE;
declare variable DOCTOPAGOID D_FK;
BEGIN





   SELECT   PERSONACLAVE , FORMAPAGOID  , BANCOTEXT, REFERENCIABANCARIA, PROCESADO,
            FECHAELABORACION, FECHARECEPCION , NOTAS , REFINTERNO , IMPORTE
   FROM R_PAGOMOVIL
   WHERE ID = :R_PAGOMOVILID --AND COALESCE(R_PAGOMOVIL.PROCESADO ,'') <> 'S'
   INTO :PERSONACLAVE, :FORMAPAGOID, :BANCOTEXT, :REFERENCIABANCARIA, :PROCESADO,
         :FECHAELABORACION, :FECHARECEPCION, :NOTAS, :REFINTERNO, :IMPORTE;



   IF(COALESCE(:FORMAPAGOID,1) = 2 ) then
   BEGIN
        FORMAPAGOID = 3;
   END 
   ELSE IF(COALESCE(:FORMAPAGOID,1) = 3 ) then
   BEGIN
        FORMAPAGOID = 20;
   END   
   ELSE IF(COALESCE(:FORMAPAGOID,1) = 7 ) then
   BEGIN
        FORMAPAGOID = 15;
   END

   
      --no se encontro el registro
   IF(COALESCE(:FORMAPAGOID,0) = 0) THEN
   BEGIN
      ERRORCODE = 6321;
      SUSPEND;
      EXIT;
   END

   --el registro ya esta procesado
   IF(COALESCE(:PROCESADO,'') = 'S') THEN
   BEGIN   
      ERRORCODE = 6322;
      SUSPEND;
      EXIT;
        
   END



    
   SELECT HAYCORTEACTIVO,CORTEID,ERRORCODE
   FROM HAY_CORTE_ACTIVO(:VENDEDORID)
   INTO :HAYCORTEACTIVO, :CORTEID, :ERRORCODE;


   IF (:ERRORCODE > 0) THEN
   BEGIN
      SUSPEND;
      EXIT;
   END

   
   IF (:HAYCORTEACTIVO <> 'S') THEN
   BEGIN
      ERRORCODE = 1016;
      SUSPEND;
      EXIT;
   END


    FECHA = CURRENT_DATE;
    FECHAHORA = CURRENT_TIME;

    SELECT BANCOS.id FROM BANCOS WHERE CLAVE = :BANCOTEXT INTO :BANCOID;



    SELECT PAGOID, ERRORCODE
    FROM  PAGO_INSERT (

                :FORMAPAGOID,
                :FECHA,
                :FECHAHORA,
                :CORTEID,
                :IMPORTE,
                0.00,
                0.00 ,
                1,--:TIPOPAGOID,
                'N',--:ESAPARTADO  ,
                1  ,
                :BANCOID,--:BANCOTRANSFERENCIA,
                :REFERENCIABANCARIA,--:REFERENCIABANCARIATRANSFERENCIA ,
                :NOTAS  ,
                :FECHAELABORACION,
                :FECHARECEPCION ,
                'N',--:ESPAGOINICIAL ,
                1,
                NULL  ,
                NULL ,
                NULL ,
                NULL ,
                NULL,
                NULL, 
                NULL,
                NULL,
                NULL,
                NULL,
                :REFINTERNO,
                NULL)
    INTO :PAGOID, :ERRORCODE;
    
    IF(COALESCE(:ERRORCODE,0) <> 0) THEN
    BEGIN
                      
                    SUSPEND;
                    EXIT;
    END



    FOR SELECT  rdp.VENTACOBRANZA, rdp.TIPOPAGOID, rdp.IMPORTE
        FROM r_doctopagomovil  rdp
        WHERE rdp.PAGOMOVILID =  :R_PAGOMOVILID
        INTO :VENTACOBRANZA, :TIPOPAGOID, :IMPORTEPAGO
        DO
        BEGIN

            SELECT DOCTO.ID FROM DOCTO
            INNER JOIN PARAMETRO P ON CAST(P.sucursalid  AS BIGINT)= DOCTO.sucursalid
            WHERE CAST(:VENTACOBRANZA AS D_DOCTOFOLIO ) = DOCTO.FOLIO
            AND DOCTO.TIPODOCTOID = 21 AND DOCTO.ESTATUSDOCTOID = 1
            INTO :DOCTOID;

            IF(COALESCE(:DOCTOID,0) = 0) THEN
            BEGIN
                  --VENTA INEXISTENTE
                ERRORCODE = 6322;
                SUSPEND;
                EXIT;  
            END

              
               SELECT DOCTOPAGOID, ERRORCODE
               FROM DOCTOPAGO_INSERT (
                :DOCTOID,
                :FORMAPAGOID,
                :FECHA,
                :FECHAHORA,
                :CORTEID,
                :IMPORTEPAGO,
                0.00,
                0.00 ,
                1,--:TIPOPAGOID,
                NULL,
                'N',--:ESAPARTADO  ,
                1  ,
                :BANCOID,--:BANCOTRANSFERENCIA,
                :REFERENCIABANCARIA,--:REFERENCIABANCARIATRANSFERENCIA ,
                :NOTAS  ,
                :FECHAELABORACION,
                :FECHARECEPCION ,
                'N',--:ESPAGOINICIAL ,
                1,
                NULL  ,
                NULL ,
                NULL ,
                NULL ,
                NULL,
                NULL, 
                NULL,
                NULL, 
                :PAGOID,
                NULL  ,
                NULL
                ) INTO :DOCTOPAGOID, :ERRORCODE;




               IF(COALESCE(:ERRORCODE,0) <> 0) THEN
               BEGIN
                      
                    SUSPEND;
                    EXIT;
               END

               
                UPDATE DOCTOPAGO
                SET  REFINTERNO = :REFINTERNO
                WHERE ID = :DOCTOPAGOID;


        END




       UPDATE R_PAGOMOVIL SET PROCESADO = 'S' WHERE ID =  :R_PAGOMOVILID;



   ERRORCODE = 0;
   SUSPEND;

  -- WHEN ANY DO
  -- BEGIN
  --    ERRORCODE = 1016;
  --    SUSPEND;
  -- END
END