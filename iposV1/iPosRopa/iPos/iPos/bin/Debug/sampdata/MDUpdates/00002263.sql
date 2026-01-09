create or alter procedure REP_VENTA_CONIEPS_EXP (
    FECHAINI D_FECHA,
    FECHAFIN D_FECHA,
    TIPODOCTOID D_FK,
    ALMACENID D_FK,
    VENDEDORID D_FK,
    STR_REMISIONFACTURA D_STDTEXT_LIGHT)
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
    SUCURSALT D_NOMBRE,
    TIPODOC D_NOMBRE,
    SALDO D_PRECIO,
    ESTATUSDOCTONOMBRE D_NOMBRE,
    ESFACTURAELECTRONICA D_BOOLCN,
    SERIEFOLIOSAT D_NOMBRE,
    PERSONA D_NOMBRE,
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
    DOCTOID D_FK,
    ESTATUS D_STDTEXT_MEDIUM,
    DOCTOREFKITID D_FK,
    ALMACENTID D_FK,
    NOMBREALMACEN D_NOMBRE_NULL,
    NOMBREALMACENTRASPASO D_NOMBRE_NULL,
    SUMACOSTOPROMEDIO D_PRECIO)
as
declare variable IEPS_X_IMPORTE D_IMPORTE;
declare variable IEPS_X_PORC D_PORCENTAJE;
declare variable CUENTA integer;
declare variable CURR_ALMACENID D_FK;
declare variable CURR_VENDEDORID D_FK;
declare variable REMISIONFACTURA integer;
BEGIN


   if(:str_remisionfactura = 'F') then
    begin
      REMISIONFACTURA = 2;
    end
    else  if(:str_remisionfactura = 'R') then
    begin
        REMISIONFACTURA = 1;
    end
    else
    begin
      REMISIONFACTURA = 0;
    end

   --TIPODOCTOID = 21;

   NUMERO = 0;
   CUENTA = 1;

   DOCTOID = 0;

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

    ESTATUS = 'REMISION';

    ALMACENID = COALESCE(:ALMACENID, 0);
    VENDEDORID = COALESCE(:vendedorid , 0);


    
    NOMBREALMACEN = '';
    SUMACOSTOPROMEDIO = 0.0;

  FOR SELECT TASA
     FROM TASASIEPS
     WHERE TASASIEPS.ultimafecha >= :FECHAINI AND TASASIEPS.primerafecha <= :FECHAFIN
     ORDER BY COALESCE(TASASIEPS.cantidadreg,0)
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
      coalesce(S.NOMBRE,' ') as SUCURSALT ,
      coalesce(TD.nombre, ' ') AS TIPODOC,
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
      D.ID ,
      D.VENDEDORID,

      CASE WHEN COALESCE(D.ESFACTURAELECTRONICA,'N') <> 'S' THEN 'REMISION' ELSE 'FACTURA' END ESTATUS,
      COALESCE(D.doctokitrefid,0) ,
      COALESCE(D.ALMACENID,0) ,
      COALESCE(D.VENDEDORID, 0),
      D.almacentid  ,
      A.nombre NOMBREALMACEN  ,
      ALT.nombre NOMBREALMACENTRASPASO
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
                  left join almacen A on A.ID = D.almacenid
                    left join almacen ALT on ALT.ID = D.almacentid
   WHERE (TIPODOCTOID = :TIPODOCTOID  OR (:TIPODOCTOID = -21 AND TIPODOCTOID IN (21,31,23,81))
          OR (:TIPODOCTOID = -31 AND TIPODOCTOID IN (31,81)) )
     AND D.FECHA BETWEEN :FECHAINI AND :FECHAFIN
     AND D.ESTATUSDOCTOID = 1  
     --AND ( D.ALMACENID = COALESCE(:ALMACENID,0) or COALESCE(:ALMACENID,0) = 0 )
     --AND ( D.VENDEDORID = COALESCE(:VENDEDORID,0) or COALESCE(:VENDEDORID,0) = 0 )
     --AND (:REMISIONFACTURA = 0 or (:REMISIONFACTURA = 1 AND Coalesce(D.esfacturaelectronica,'N') <> 'S') or (:REMISIONFACTURA = 2 AND Coalesce(D.esfacturaelectronica,'N') = 'S') )
     AND COALESCE(D.IEPS,0) > 0
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
      :SUCURSALT ,
      :TIPODOC ,
      :PERSONA,
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
      :DOCTOID  ,
      :VENDEDORID ,
      :ESTATUS  ,
      :DOCTOREFKITID,
      :CURR_ALMACENID,
      :CURR_VENDEDORID,
      :ALMACENTID,
      :NOMBREALMACEN ,
      :NOMBREALMACENTRASPASO

   DO
   BEGIN

     IF((:ALMACENID = 0 or  :CURR_ALMACENID = :ALMACENID) AND (COALESCE(:vendedorid,0) = 0 or :CURR_VENDEDORID = :VENDEDORID )  AND
         (:REMISIONFACTURA = 0 or (:REMISIONFACTURA = 1 AND Coalesce(:esfacturaelectronica,'N') <> 'S') or (:REMISIONFACTURA = 2 AND Coalesce(:esfacturaelectronica,'N') = 'S') )  ) THEN
     BEGIN

        IF(:IEPS_01_PORC <> -1) THEN
        BEGIN     
            IEPS_X_IMPORTE = 0;
            SELECT SUM(CASE WHEN COALESCE(ESKIT,'N') = 'N' THEN COALESCE(IEPS,0) ELSE 0 END)
            FROM MOVTO
            WHERE (DOCTOID = :DOCTOID or DOCTOID = :DOCTOREFKITID)--IN (:DOCTOID, :DOCTOREFKITID) --AND COALESCE(ESKIT,'N') = 'N'
            AND TASAIEPS = :IEPS_01_PORC
            INTO :IEPS_X_IMPORTE;
            IEPS_01_IMPORTE = :IEPS_X_IMPORTE;
        END
        
        IF(:IEPS_02_PORC <> -1) THEN
        BEGIN       
            IEPS_X_IMPORTE = 0;
            SELECT SUM(CASE WHEN COALESCE(ESKIT,'N') = 'N' THEN COALESCE(IEPS,0) ELSE 0 END)
            FROM MOVTO
            WHERE (DOCTOID = :DOCTOID or DOCTOID = :DOCTOREFKITID)-- IN (:DOCTOID, :DOCTOREFKITID) --AND COALESCE(ESKIT,'N') = 'N'
            AND TASAIEPS = :IEPS_02_PORC
            INTO :IEPS_X_IMPORTE;
            IEPS_02_IMPORTE = :IEPS_X_IMPORTE;
        END

        
        IF(:IEPS_03_PORC <> -1) THEN
        BEGIN      
            IEPS_X_IMPORTE = 0;
            SELECT SUM(CASE WHEN COALESCE(ESKIT,'N') = 'N' THEN COALESCE(IEPS,0) ELSE 0 END)
            FROM MOVTO
            WHERE (DOCTOID = :DOCTOID or DOCTOID = :DOCTOREFKITID)-- IN (:DOCTOID, :DOCTOREFKITID) --AND COALESCE(ESKIT,'N') = 'N'
            AND TASAIEPS = :IEPS_03_PORC
            INTO :IEPS_X_IMPORTE;
            IEPS_03_IMPORTE = :IEPS_X_IMPORTE;
        END

        
        IF(:IEPS_04_PORC <> -1) THEN
        BEGIN     
            IEPS_X_IMPORTE = 0;
            SELECT SUM(CASE WHEN COALESCE(ESKIT,'N') = 'N' THEN COALESCE(IEPS,0) ELSE 0 END)
            FROM MOVTO
            WHERE (DOCTOID = :DOCTOID or DOCTOID = :DOCTOREFKITID)-- IN (:DOCTOID, :DOCTOREFKITID) --AND COALESCE(ESKIT,'N') = 'N'
            AND TASAIEPS = :IEPS_04_PORC
            INTO :IEPS_X_IMPORTE;
            IEPS_04_IMPORTE = :IEPS_X_IMPORTE;
        END
              
        IF(:IEPS_05_PORC <> -1) THEN
        BEGIN     
            IEPS_X_IMPORTE = 0;
            SELECT SUM(CASE WHEN COALESCE(ESKIT,'N') = 'N' THEN COALESCE(IEPS,0) ELSE 0 END)
            FROM MOVTO
            WHERE (DOCTOID = :DOCTOID or DOCTOID = :DOCTOREFKITID)-- IN (:DOCTOID, :DOCTOREFKITID) --AND COALESCE(ESKIT,'N') = 'N'
            AND TASAIEPS = :IEPS_05_PORC
            INTO :IEPS_X_IMPORTE;
            IEPS_05_IMPORTE = :IEPS_X_IMPORTE;
        END       
              
        IF(:IEPS_06_PORC <> -1) THEN
        BEGIN      
            IEPS_X_IMPORTE = 0;
            SELECT SUM(CASE WHEN COALESCE(ESKIT,'N') = 'N' THEN COALESCE(IEPS,0) ELSE 0 END)
            FROM MOVTO
            WHERE (DOCTOID = :DOCTOID or DOCTOID = :DOCTOREFKITID)-- IN (:DOCTOID, :DOCTOREFKITID)  --AND COALESCE(ESKIT,'N') = 'N'
            AND TASAIEPS = :IEPS_06_PORC
            INTO :IEPS_X_IMPORTE;
            IEPS_06_IMPORTE = :IEPS_X_IMPORTE;
        END        
              
        IF(:IEPS_07_PORC <> -1) THEN
        BEGIN     
            IEPS_X_IMPORTE = 0;
            SELECT SUM(CASE WHEN COALESCE(ESKIT,'N') = 'N' THEN COALESCE(IEPS,0) ELSE 0 END)
            FROM MOVTO
            WHERE (DOCTOID = :DOCTOID or DOCTOID = :DOCTOREFKITID)-- IN (:DOCTOID, :DOCTOREFKITID) --AND COALESCE(ESKIT,'N') = 'N'
            AND TASAIEPS = :IEPS_07_PORC
            INTO :IEPS_X_IMPORTE;
            IEPS_07_IMPORTE = :IEPS_X_IMPORTE;
        END         
              
        IF(:IEPS_08_PORC <> -1) THEN
        BEGIN   
            IEPS_X_IMPORTE = 0;  
            SELECT SUM(CASE WHEN COALESCE(ESKIT,'N') = 'N' THEN COALESCE(IEPS,0) ELSE 0 END)
            FROM MOVTO
            WHERE (DOCTOID = :DOCTOID or DOCTOID = :DOCTOREFKITID)-- IN (:DOCTOID, :DOCTOREFKITID) --AND COALESCE(ESKIT,'N') = 'N'
            AND TASAIEPS = :IEPS_08_PORC
            INTO :IEPS_X_IMPORTE;
            IEPS_08_IMPORTE = :IEPS_X_IMPORTE;
        END    
              
        IF(:IEPS_09_PORC <> -1) THEN
        BEGIN   
            IEPS_X_IMPORTE = 0;  
            SELECT SUM(CASE WHEN COALESCE(ESKIT,'N') = 'N' THEN COALESCE(IEPS,0) ELSE 0 END)
            FROM MOVTO
            WHERE (DOCTOID = :DOCTOID or DOCTOID = :DOCTOREFKITID)-- IN (:DOCTOID, :DOCTOREFKITID)  --AND COALESCE(ESKIT,'N') = 'N'
            AND TASAIEPS = :IEPS_09_PORC
            INTO :IEPS_X_IMPORTE;
            IEPS_09_IMPORTE = :IEPS_X_IMPORTE;
        END        
              
        IF(:IEPS_10_PORC <> -1) THEN
        BEGIN    
            IEPS_X_IMPORTE = 0; 
            SELECT SUM(CASE WHEN COALESCE(ESKIT,'N') = 'N' THEN COALESCE(IEPS,0) ELSE 0 END)
            FROM MOVTO
            WHERE (DOCTOID = :DOCTOID or DOCTOID = :DOCTOREFKITID)-- IN (:DOCTOID, :DOCTOREFKITID)  --AND COALESCE(ESKIT,'N') = 'N'
            AND TASAIEPS = :IEPS_10_PORC
            INTO :IEPS_X_IMPORTE;
            IEPS_10_IMPORTE = :IEPS_X_IMPORTE;
        END
      SUSPEND;
     END
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
      SUCURSALT = ' ';
      TIPODOC = ' ';  
      SALDO  = 0.00;
      ESTATUSDOCTONOMBRE  = ' ';
      ESFACTURAELECTRONICA  = 'N';
      SERIEFOLIOSAT  = ' ';
      PERSONA = ' ';
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

      ESTATUS = 'REMISION';

      VENDEDORID = 0;

      
      NOMBREALMACEN = ''; 
      ALMACENTID = 0;
      NOMBREALMACENTRASPASO = '';

      SUMACOSTOPROMEDIO = 0.0;


   end


END