create or alter procedure FACTURACIONXML_AUXREPORTE (
    DOCTOID D_FK,
    TIPOCOMPROBANTE varchar(10))
returns (
    TASA_IVA D_PORCENTAJE,
    IVA D_IMPORTE,
    IEPS_01_IMPORTE D_IMPORTE,
    IEPS_01_PORC D_PORCENTAJE,
    IEPS_02_IMPORTE D_IMPORTE,
    IEPS_02_PORC D_PORCENTAJE,
    IEPS_03_IMPORTE D_IMPORTE,
    IEPS_03_PORC D_PORCENTAJE,
    IEPS_04_IMPORTE D_IMPORTE,
    IEPS_04_PORC D_PORCENTAJE,
    IEPS_05_IMPORTE D_IMPORTE,
    IEPS_05_PORC D_PORCENTAJE,
    IEPS_06_IMPORTE D_IMPORTE,
    IEPS_06_PORC D_PORCENTAJE,
    IEPS_07_IMPORTE D_IMPORTE,
    IEPS_07_PORC D_PORCENTAJE,
    IEPS_08_IMPORTE D_IMPORTE,
    IEPS_08_PORC D_PORCENTAJE,
    IEPS_09_IMPORTE D_IMPORTE,
    IEPS_09_PORC D_PORCENTAJE,
    IEPS_10_IMPORTE D_IMPORTE,
    IEPS_10_PORC D_PORCENTAJE,
    IVARETENIDO D_IMPORTE,
    ISRRETENIDO D_IMPORTE)
as
--declare variable IEPS_PORC D_PORCENTAJE;
declare variable IEPS_IMPORTE D_IMPORTE;
declare variable CUENTA integer;
declare variable CFDIID D_FK;
declare variable IEPS_X_PORC D_PORCENTAJE;
BEGIN


   CUENTA = 1;

    IEPS_01_PORC  = -1;
    IEPS_02_PORC  = -1;
    IEPS_03_PORC  = -1;
    IEPS_04_PORC  = -1;
    IEPS_05_PORC  = -1;
    IEPS_06_PORC  = -1;
    IEPS_07_PORC  = -1;
    IEPS_08_PORC  = -1;
    IEPS_09_PORC  = -1;
    IEPS_10_PORC  = -1;
                        
    IEPS_01_IMPORTE  = 0;
    IEPS_02_IMPORTE  = 0;
    IEPS_03_IMPORTE  = 0;
    IEPS_04_IMPORTE  = 0;
    IEPS_05_IMPORTE  = 0;
    IEPS_06_IMPORTE  = 0;
    IEPS_07_IMPORTE  = 0;
    IEPS_08_IMPORTE  = 0;
    IEPS_09_IMPORTE  = 0;
    IEPS_10_IMPORTE  = 0;


    
    SELECT ID FROM CFDI WHERE DOCTOID = :DOCTOID  and
          ( coalesce(:TIPOCOMPROBANTE, '') = cfdi.tipocomprobante or
            (coalesce(:TIPOCOMPROBANTE,'') <> 'T' and coalesce(cfdi.tipocomprobante,'') in  ('I','E','P') ) ) INTO :CFDIID;


    SELECT SUM(CFDI_IMP.importe) IMPORTE
    FROM cfdi_imp
    WHERE  CFDI_IMP.tipolinea = 'COMPROBANTE_ISRRETENIDO'  AND CFDI_IMP.cfdiid = :CFDIID
    INTO :ISRRETENIDO;

      
    SELECT SUM(CFDI_IMP.importe) IMPORTE
    FROM cfdi_imp
    WHERE  CFDI_IMP.tipolinea = 'COMPROBANTE_IVARETENIDO'  AND CFDI_IMP.cfdiid = :CFDIID
    INTO :IVARETENIDO;

    
    SELECT first 1 CFDI_IMP.tasa, SUM(CFDI_IMP.importe) IMPORTE
    FROM cfdi_imp
    WHERE  CFDI_IMP.tipolinea = 'COMPROBANTE_IVA'  AND CFDI_IMP.cfdiid = :CFDIID AND CFDI_IMP.tasa = 16.0
    GROUP BY  CFDI_IMP.tasa
    INTO :TASA_IVA, :IVA;


  FOR SELECT CFDI_IMP.tasa , SUM(CFDI_IMP.IMPORTE) IMPORTESUMA
     FROM CFDI_IMP
     WHERE CFDI_IMP.tipolinea = 'COMPROBANTE_IEPS' AND CFDI_IMP.cfdiid = :CFDIID
     GROUP BY CFDI_IMP.tasa
     ORDER BY IMPORTESUMA
    INTO  :IEPS_X_PORC  , :IEPS_IMPORTE
    DO
    BEGIN

        IF(:CUENTA = 1 ) THEN
        BEGIN
            IEPS_01_PORC =  :IEPS_X_PORC;   
            IEPS_01_IMPORTE = :IEPS_IMPORTE;
        END        
        IF(:CUENTA = 2 ) THEN
        BEGIN
            IEPS_02_PORC =  :IEPS_X_PORC; 
            IEPS_02_IMPORTE = :IEPS_IMPORTE;
        END        
        IF(:CUENTA = 3 ) THEN
        BEGIN
            IEPS_03_PORC =  :IEPS_X_PORC; 
            IEPS_03_IMPORTE = :IEPS_IMPORTE;
        END 
        IF(:CUENTA = 4 ) THEN
        BEGIN
            IEPS_04_PORC =  :IEPS_X_PORC;
            IEPS_04_IMPORTE = :IEPS_IMPORTE;
        END 
        IF(:CUENTA = 5 ) THEN
        BEGIN
            IEPS_05_PORC =  :IEPS_X_PORC;
            IEPS_05_IMPORTE = :IEPS_IMPORTE;
        END 
        IF(:CUENTA = 6 ) THEN
        BEGIN
            IEPS_06_PORC =  :IEPS_X_PORC;
            IEPS_06_IMPORTE = :IEPS_IMPORTE;
        END 
        IF(:CUENTA = 7 ) THEN
        BEGIN
            IEPS_07_PORC =  :IEPS_X_PORC; 
            IEPS_07_IMPORTE = :IEPS_IMPORTE;
        END 
        IF(:CUENTA = 8 ) THEN
        BEGIN
            IEPS_08_PORC =  :IEPS_X_PORC; 
            IEPS_08_IMPORTE = :IEPS_IMPORTE;
        END 
        IF(:CUENTA = 9 ) THEN
        BEGIN
            IEPS_09_PORC =  :IEPS_X_PORC; 
            IEPS_09_IMPORTE = :IEPS_IMPORTE;
        END 
        IF(:CUENTA = 10 ) THEN
        BEGIN
            IEPS_10_PORC =  :IEPS_X_PORC;
            IEPS_10_IMPORTE = :IEPS_IMPORTE;
        END
        CUENTA = CUENTA + 1;
    END




      SUSPEND;
      EXIT;

END