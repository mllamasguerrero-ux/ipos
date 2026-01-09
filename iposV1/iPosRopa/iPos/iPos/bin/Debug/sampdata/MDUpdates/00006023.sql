create or alter procedure IMPORTAR_DBFLINE_PAGO (
    DOCTOID D_FK,
    MONTOTARJETA D_IMPORTE,
    MONTOCREDITO D_IMPORTE)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable ACTIVO D_BOOLCS;
declare variable FORMAPAGOID D_FK;
declare variable TIPOPAGOID D_FK;
declare variable DOCTO_P_ID D_FK;
declare variable DOCTOSALIDA_P_ID D_FK;
declare variable ESAPARTADO D_BOOLCN;
declare variable BANCOTARJETA D_FK;
declare variable REFERENCIABANCARIATARJETA D_REFERENCIA;
declare variable ESPAGOINICIAL D_BOOLCN;
declare variable TARJETAFORMAPAGOSATID D_FK;
declare variable BANCOMERPARAMID D_FK;
declare variable CORTEID D_FK;
declare variable SUCURSALID D_FK;
declare variable CAJEROID D_FK;
declare variable FORMAPAGOSATID D_FK;
declare variable DOCTOREFID D_FK;
declare variable DOCTOTOTAL D_IMPORTE;
declare variable TIPODOCTOID D_FK;
declare variable FECHA D_FECHA;
declare variable FECHAHORA D_TIMESTAMP;
BEGIN

  SELECT PARAMETRO.sucursalid FROM PARAMETRO INTO :SUCURSALID;

  CAJEROID = 1331;

   SELECT ID FROM CORTE WHERE CAJEROID = :CAJEROID AND FECHACORTE = :FECHA INTO :CORTEID;

   IF(COALESCE(:CORTEID , 0) = 0) THEN
   BEGIN
       SELECT ERRORCODE,  CORTEID FROM
        CORTE_ABRIR (
                :FECHA,
                :SUCURSALID ,
                :CAJEROID ,
                0,
            1) INTO :ERRORCODE,  :CORTEID;

            
        IF (:ERRORCODE > 0) THEN
        BEGIN
            SUSPEND;
            EXIT;
        END
   END


   SELECT DOCTOREFID, TOTAL, FECHA, TIPODOCTOID FROM DOCTO WHERE ID = :DOCTOID
   INTO :DOCTOREFID, :DOCTOTOTAL, :FECHA, :TIPODOCTOID;

   FECHAHORA = CAST(:fecha AS TIMESTAMP);

           
   TIPOPAGOID = CASE WHEN :TIPODOCTOID = 22 THEN 2 ELSE 1 END;
   DOCTO_P_ID = CASE WHEN :TIPODOCTOID = 22 THEN :DOCTOREFID ELSE :DOCTOID END;
   DOCTOSALIDA_P_ID = CASE WHEN :TIPODOCTOID = 22 THEN :DOCTOID ELSE :DOCTOREFID END; 
     ESAPARTADO = 'N';            
      BANCOMERPARAMID = NULL; 
     ESPAGOINICIAL = 'S';

   IF(COALESCE(:MONTOTARJETA,0) > 0) THEN
   BEGIN

   
     FORMAPAGOID = 2; -- Tarjeta

     BANCOTARJETA = 1;
     REFERENCIABANCARIATARJETA = '123456';
     
      FORMAPAGOSATID  = 4;


      SELECT ERRORCODE
      FROM DOCTOPAGO_INSERT (
         :DOCTO_P_ID,
         :FORMAPAGOID,
         :FECHA,
         :FECHA,
         :CORTEID,
         :MONTOTARJETA,
         0.00, 0.00 ,
         :TIPOPAGOID,
         :DOCTOSALIDA_P_ID,
         :ESAPARTADO  ,
         1  ,
         :BANCOTARJETA,
         :REFERENCIABANCARIATARJETA ,
         NULL  ,
         CURRENT_DATE,
         CURRENT_DATE ,
         :ESPAGOINICIAL ,
         1,
         NULL,
         :FORMAPAGOSATID ,
         :BANCOMERPARAMID ,
         NULL ,
         NULL,
         NULL,
         'S',
         CURRENT_DATE,
         NULL,
         NULL
      ) INTO :ERRORCODE;

      
        IF (:ERRORCODE > 0) THEN
        BEGIN
            SUSPEND;
            EXIT;
        END
   END

   
   IF(COALESCE(:MONTOCREDITO,0) > 0) THEN
   BEGIN

   
     FORMAPAGOID = 4; -- Tarjeta

     BANCOTARJETA = 0;
     REFERENCIABANCARIATARJETA = '';
     
      FORMAPAGOSATID  = NULL;


      SELECT ERRORCODE
      FROM DOCTOPAGO_INSERT (
         :DOCTO_P_ID,
         :FORMAPAGOID,
         :FECHA,
         :FECHA,
         :CORTEID,
         :MONTOCREDITO,
         0.00, 0.00 ,
         :TIPOPAGOID,
         :DOCTOSALIDA_P_ID,
         :ESAPARTADO  ,
         1  ,
         :BANCOTARJETA,
         :REFERENCIABANCARIATARJETA ,
         NULL  ,
         CURRENT_DATE,
         CURRENT_DATE ,
         :ESPAGOINICIAL ,
         1,
         NULL,
         :FORMAPAGOSATID ,
         :BANCOMERPARAMID ,
         NULL ,
         NULL,
         NULL,
         'S',
         CURRENT_DATE,
         NULL,
         NULL
      ) INTO :ERRORCODE;

      
        IF (:ERRORCODE > 0) THEN
        BEGIN
            SUSPEND;
            EXIT;
        END
   END

   
   
   IF(COALESCE(:DOCTOTOTAL,0) - COALESCE(:MONTOTARJETA, 0) - COALESCE(:MONTOCREDITO, 0) > 0) THEN
   BEGIN


     FORMAPAGOID = 1; -- Efectivo

   
     BANCOTARJETA = NULL;
     REFERENCIABANCARIATARJETA = NULL;
     
      FORMAPAGOSATID  = 1;

      SELECT ERRORCODE
      FROM DOCTOPAGO_INSERT (
         :DOCTO_P_ID,
         :FORMAPAGOID,
         :FECHA, :FECHAHORA, :CORTEID,
         :DOCTOTOTAL - COALESCE(:MONTOTARJETA, 0) - COALESCE(:MONTOCREDITO, 0),
         :DOCTOTOTAL - COALESCE(:MONTOTARJETA, 0)- COALESCE(:MONTOCREDITO, 0),
         0 ,
          :TIPOPAGOID,
         :DOCTOSALIDA_P_ID,
         :ESAPARTADO ,
         1,
         NULL,
         NULL,
         NULL,
         CURRENT_DATE ,
         CURRENT_DATE,
         :ESPAGOINICIAL,
         1,
         NULL,
         1 ,
         NULL ,
         NULL,
         NULL ,
         NULL,
         'S',
         CURRENT_DATE,
         NULL,
         NULL
      ) INTO :ERRORCODE;


              
        IF (:ERRORCODE > 0) THEN
        BEGIN
            SUSPEND;
            EXIT;
        END

     END




END