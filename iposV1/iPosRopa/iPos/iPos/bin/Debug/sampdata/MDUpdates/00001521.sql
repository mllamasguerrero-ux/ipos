create or alter procedure REP_COMPRA_CONIEPS (
    FECHAINI D_FECHA,
    FECHAFIN D_FECHA)
returns (
    NUMERO integer,
    FECHA D_FECHA,
    FECHAHORA D_TIMESTAMP,
    TURNOCLAVE D_CLAVE,
    DOCTOFOLIO D_DOCTOFOLIO,
    IMPORTE D_IMPORTE,
    DESCUENTO D_IMPORTE,
    SUBTOTAL D_IMPORTE,
    IVA D_IMPORTE,
    TOTAL D_IMPORTE,
    PROVEEDOR D_NOMBRE,
    SALDO D_PRECIO,
    ESTATUSDOCTONOMBRE D_NOMBRE,
    ESFACTURAELECTRONICA D_BOOLCN,
    SERIEFOLIOSAT D_NOMBRE,
    VENDEDOR D_NOMBRE,
    VENDEDORDELCLIENTEID D_ID,
    VENDEDORDELCLIENTENOMBRE D_NOMBRE,
    VENDEDORDELCLIENTECLAVE D_CLAVE_NULL,
    IEPS D_IMPORTE,
    IMPUESTO D_IMPORTE,
    PERSONACLAVE D_CLAVE_NULL,
    PERSONANOMBRES D_STDTEXT_MEDIUM,
    PERSONAAPELLIDOS D_STDTEXT_MEDIUM,
    FECHAVENCE D_FECHAVENCE,
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
    DOCTOID D_FK)
as
declare variable IEPS_X_IMPORTE D_IMPORTE;
declare variable IEPS_X_PORC D_PORCENTAJE;
declare variable CUENTA integer;
declare variable TIPODOCTOID D_FK;
BEGIN
   NUMERO = 0;
   CUENTA = 1;

   DOCTOID = 0;


   TIPODOCTOID = 11;



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


  FOR SELECT
       coalesce(m.TASAIEPS, 0)
       FROM MOVTO M
      LEFT JOIN DOCTO D
         ON D.ID = M.DOCTOID
      WHERE ( D.TIPODOCTOID = :TIPODOCTOID  OR (:TIPODOCTOID = -21 AND D.TIPODOCTOID IN (21,31,23))
          OR (:TIPODOCTOID = -31 AND d.TIPODOCTOID IN (31,81)) )
     AND D.FECHA BETWEEN :FECHAINI AND :FECHAFIN
     AND D.ESTATUSDOCTOID = 1
    group by m.tasaieps
    order by m.tasaieps desc
    INTO :IEPS_X_PORC
    DO
    BEGIN
        IF(:CUENTA = 1 ) THEN
        BEGIN
            IEPS_01_PORC =  :IEPS_X_PORC;
        END        
        IF(:CUENTA = 2 ) THEN
        BEGIN
            IEPS_02_PORC =  :IEPS_X_PORC;
        END        
        IF(:CUENTA = 3 ) THEN
        BEGIN
            IEPS_03_PORC =  :IEPS_X_PORC;
        END 
        IF(:CUENTA = 4 ) THEN
        BEGIN
            IEPS_04_PORC =  :IEPS_X_PORC;
        END 
        IF(:CUENTA = 5 ) THEN
        BEGIN
            IEPS_05_PORC =  :IEPS_X_PORC;
        END 
        IF(:CUENTA = 6 ) THEN
        BEGIN
            IEPS_06_PORC =  :IEPS_X_PORC;
        END 
        IF(:CUENTA = 7 ) THEN
        BEGIN
            IEPS_07_PORC =  :IEPS_X_PORC;
        END 
        IF(:CUENTA = 8 ) THEN
        BEGIN
            IEPS_08_PORC =  :IEPS_X_PORC;
        END 
        IF(:CUENTA = 9 ) THEN
        BEGIN
            IEPS_09_PORC =  :IEPS_X_PORC;
        END 
        IF(:CUENTA = 10 ) THEN
        BEGIN
            IEPS_10_PORC =  :IEPS_X_PORC;
        END
        CUENTA = CUENTA + 1;
    END




   FOR SELECT
       D.FECHA,
      D.FECHAHORA,
      COALESCE(T.CLAVE, ' '),
      D.FOLIO,
      D.IMPORTE,
      D.DESCUENTO,
      D.SUBTOTAL,
      D.IVA,
      D.TOTAL ,
      P.NOMBRE as PERSONA ,
      D.saldo, 
      ed.nombre estatusdoctonombre ,
      D.esfacturaelectronica ,
      coalesce(D.seriesat,'') || coalesce(D.foliosat,'') SERIEFOLIOSAT ,
      U.nombre VENDEDORNOMBRE ,
      coalesce(P.vendedorid,0) VENDEDORDELCLIENTEID,
      coalesce(uc.nombre,'') VENDEDORDELCLIENTENOMBRE ,
      coalesce(uc.clave,'') VENDEDORDELCLIENTECLAVE,

      D.IEPS,
      D.IMPUESTO ,

      p.clave,
      p.nombres,
      p.apellidos, 
      dateadd (coalesce(p.dias, 0) day to d.fecha) fechavence,
      D.ID



   FROM DOCTO D
      LEFT JOIN TURNO T
         ON T.ID = D.TURNOID
       left join SUCURSAL S
         ON S.ID = D.SUCURSALTID
        left join TIPODOCTO  TD
         on  TD.id = d.tipodoctoid
         left join PERSONA P
          on P.id = D.personaid
          left join ESTATUSDOCTO ED
            on ED.id = d.estatusdoctoid
            left join PERSONA U
                on D.vendedorid = u.id  
            left join PERSONA Uc
                on P.vendedorid = uc.id
   WHERE (TIPODOCTOID = :TIPODOCTOID  OR (:TIPODOCTOID = -21 AND TIPODOCTOID IN (21,31,23,81))
          OR (:TIPODOCTOID = -31 AND TIPODOCTOID IN (31,81)) )
     AND D.FECHA BETWEEN :FECHAINI AND :FECHAFIN
     AND D.ESTATUSDOCTOID = 1
   INTO
      :FECHA ,
      :FECHAHORA ,
      :TURNOCLAVE,
      :DOCTOFOLIO ,
      :IMPORTE ,
      :DESCUENTO,
      :SUBTOTAL,
      :IVA ,
      :TOTAL ,
      :PROVEEDOR,
      :SALDO,
      :ESTATUSDOCTONOMBRE ,
      :ESFACTURAELECTRONICA  ,
      :SERIEFOLIOSAT  ,
      :VENDEDOR        ,
      :VENDEDORDELCLIENTEID,
      :VENDEDORDELCLIENTENOMBRE ,
      :VENDEDORDELCLIENTECLAVE,
    
      :IEPS,
      :IMPUESTO ,
      :PERSONACLAVE ,
      :PERSONANOMBRES ,
      :PERSONAAPELLIDOS ,
      :FECHAVENCE,
      :DOCTOID


   DO
   BEGIN
        IF(:IEPS_01_PORC <> -1) THEN
        BEGIN     
            SELECT SUM(COALESCE(IEPS,0))
            FROM MOVTO
            WHERE DOCTOID = :DOCTOID
            AND TASAIEPS = :IEPS_01_PORC
            INTO :IEPS_X_IMPORTE;
            IEPS_01_IMPORTE = :IEPS_X_IMPORTE;
        END
        
        IF(:IEPS_02_PORC <> -1) THEN
        BEGIN     
            SELECT SUM(COALESCE(IEPS,0))
            FROM MOVTO
            WHERE DOCTOID = :DOCTOID
            AND TASAIEPS = :IEPS_02_PORC
            INTO :IEPS_X_IMPORTE;
            IEPS_02_IMPORTE = :IEPS_X_IMPORTE;
        END

        
        IF(:IEPS_03_PORC <> -1) THEN
        BEGIN     
            SELECT SUM(COALESCE(IEPS,0))
            FROM MOVTO
            WHERE DOCTOID = :DOCTOID
            AND TASAIEPS = :IEPS_03_PORC
            INTO :IEPS_X_IMPORTE;
            IEPS_03_IMPORTE = :IEPS_X_IMPORTE;
        END

        
        IF(:IEPS_04_PORC <> -1) THEN
        BEGIN     
            SELECT SUM(COALESCE(IEPS,0))
            FROM MOVTO
            WHERE DOCTOID = :DOCTOID
            AND TASAIEPS = :IEPS_04_PORC
            INTO :IEPS_X_IMPORTE;
            IEPS_04_IMPORTE = :IEPS_X_IMPORTE;
        END
              
        IF(:IEPS_05_PORC <> -1) THEN
        BEGIN     
            SELECT SUM(COALESCE(IEPS,0))
            FROM MOVTO
            WHERE DOCTOID = :DOCTOID
            AND TASAIEPS = :IEPS_05_PORC
            INTO :IEPS_X_IMPORTE;
            IEPS_05_IMPORTE = :IEPS_X_IMPORTE;
        END       
              
        IF(:IEPS_06_PORC <> -1) THEN
        BEGIN     
            SELECT SUM(COALESCE(IEPS,0))
            FROM MOVTO
            WHERE DOCTOID = :DOCTOID
            AND TASAIEPS = :IEPS_06_PORC
            INTO :IEPS_X_IMPORTE;
            IEPS_06_IMPORTE = :IEPS_X_IMPORTE;
        END        
              
        IF(:IEPS_07_PORC <> -1) THEN
        BEGIN     
            SELECT SUM(COALESCE(IEPS,0))
            FROM MOVTO
            WHERE DOCTOID = :DOCTOID
            AND TASAIEPS = :IEPS_07_PORC
            INTO :IEPS_X_IMPORTE;
            IEPS_07_IMPORTE = :IEPS_X_IMPORTE;
        END         
              
        IF(:IEPS_08_PORC <> -1) THEN
        BEGIN     
            SELECT SUM(COALESCE(IEPS,0))
            FROM MOVTO
            WHERE DOCTOID = :DOCTOID
            AND TASAIEPS = :IEPS_08_PORC
            INTO :IEPS_X_IMPORTE;
            IEPS_08_IMPORTE = :IEPS_X_IMPORTE;
        END    
              
        IF(:IEPS_09_PORC <> -1) THEN
        BEGIN     
            SELECT SUM(COALESCE(IEPS,0))
            FROM MOVTO
            WHERE DOCTOID = :DOCTOID
            AND TASAIEPS = :IEPS_09_PORC
            INTO :IEPS_X_IMPORTE;
            IEPS_09_IMPORTE = :IEPS_X_IMPORTE;
        END        
              
        IF(:IEPS_10_PORC <> -1) THEN
        BEGIN     
            SELECT SUM(COALESCE(IEPS,0))
            FROM MOVTO
            WHERE DOCTOID = :DOCTOID
            AND TASAIEPS = :IEPS_10_PORC
            INTO :IEPS_X_IMPORTE;
            IEPS_10_IMPORTE = :IEPS_X_IMPORTE;
        END
      SUSPEND;
   END

   if (:numero = 0) then
   begin
      numero = 0;
      fecha = current_date;
      fechahora = current_date;
      TURNOCLAVE = 'N/D';
      doctofolio = 0;
      IMPORTE = 0.00;
      SUBTOTAL = 0.00;
      IVA = 0.00;
      TOTAL = 0.00;
      SALDO  = 0.00;
      ESTATUSDOCTONOMBRE  = ' ';
      ESFACTURAELECTRONICA  = 'N';
      SERIEFOLIOSAT  = ' ';
      PROVEEDOR = ' ';
      VENDEDOR = '';

      
      VENDEDORDELCLIENTEID = 0;
      VENDEDORDELCLIENTENOMBRE = '';
      VENDEDORDELCLIENTECLAVE = '';
                         
      IEPS = 0;
      IMPUESTO = 0;
      -- sin suspend para no regresar renglon falso

      
      PERSONACLAVE = '';
      PERSONANOMBRES = '';
      PERSONAAPELLIDOS = '';
      FECHAVENCE  = current_date;


      IEPS_01_IMPORTE = NULL;
      IEPS_01_PORC  = NULL;
      IEPS_02_IMPORTE  = NULL;
      IEPS_02_PORC   = NULL;
      IEPS_03_IMPORTE  = NULL;
      IEPS_03_PORC    = NULL;
      IEPS_04_IMPORTE  = NULL;
      IEPS_04_PORC    = NULL;
      IEPS_05_IMPORTE  = NULL;
      IEPS_05_PORC    = NULL;
      IEPS_06_IMPORTE = NULL;
      IEPS_06_PORC    = NULL;
      IEPS_07_IMPORTE  = NULL;
      IEPS_07_PORC    = NULL;
      IEPS_08_IMPORTE  = NULL;
      IEPS_08_PORC    = NULL;
      IEPS_09_IMPORTE  = NULL;
      IEPS_09_PORC    = NULL;
      IEPS_10_IMPORTE  = NULL;
      IEPS_10_PORC    = NULL;


   end

END