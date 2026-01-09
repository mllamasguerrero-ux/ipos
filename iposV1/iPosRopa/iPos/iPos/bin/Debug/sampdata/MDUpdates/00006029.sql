create or alter procedure REP_VENTAXCORTE_DETALLE_EXP (
    FECHAINI D_FECHA,
    FECHAFIN D_FECHA,
    TIPODOCTOID D_FK,
    ALMACENID D_FK,
    VENDEDORID D_FK,
    STR_REMISIONFACTURA D_STDTEXT_LIGHT,
    DESENSAMBLADO D_BOOLCN)
returns (
    NUMERO integer,
    FECHA D_FECHA,
    SUBTOTAL D_IMPORTE,
    IVA D_IMPORTE,
    TOTAL D_IMPORTE,
    ESFACTURAELECTRONICA D_BOOLCN,
    IEPS D_IMPORTE,
    IMPUESTO D_IMPORTE,
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
    ESTATUS D_STDTEXT_MEDIUM,
    MARCAID D_FK,
    MARCACLAVE D_CLAVE,
    MARCANOMBRE D_NOMBRE,
    PRODUCTOID D_FK,
    PRODUCTOCLAVE D_CLAVE,
    PRODUCTONOMBRE D_NOMBRE,
    PRODUCTODESCRIPCION D_DESCRIPCION,
    MOVTOID D_FK,
    DOCTOFOLIO D_DOCTOFOLIO,
    SERIEFOLIOSAT D_NOMBRE,
    DOCTOREFKITID D_FK,
    NOMBREALMACEN D_STDTEXT_MEDIUM,
    PERSONA D_NOMBRE,
    VENDEDOR D_NOMBRE,
    PERSONACLAVE D_CLAVE_NULL,
    PERSONANOMBRES D_STDTEXT_MEDIUM,
    PERSONAAPELLIDOS D_STDTEXT_MEDIUM,
    FECHAVENCE D_FECHAVENCE,
    CANTIDAD D_CANTIDAD,
    PRECIO D_PRECIO,
    IMPORTE D_PRECIO,
    DESCUENTO D_PORCENTAJE,
    NOMBRESUCURSALDESTINO D_NOMBRE_NULL,
    NOMBREALMACENTRASPASO D_NOMBRE_NULL,
    COSTOPROMEDIO D_PRECIO,
    TIPODOC D_NOMBRE,
    LOTE D_LOTE,
    LOTEVENCE D_FECHAVENCE,
    FECHAHORA timestamp,
    ESKIT D_BOOLCN,
    ESPARTEKIT D_BOOLCN,
    CORTEID D_FK,
    IEPS_01_GPOIMP D_CLAVE_NULL,
    IEPS_02_GPOIMP D_CLAVE_NULL,
    IEPS_03_GPOIMP D_CLAVE_NULL,
    IEPS_04_GPOIMP D_CLAVE_NULL,
    IEPS_05_GPOIMP D_CLAVE_NULL,
    IEPS_06_GPOIMP D_CLAVE_NULL,
    IEPS_07_GPOIMP D_CLAVE_NULL,
    IEPS_08_GPOIMP D_CLAVE_NULL,
    IEPS_09_GPOIMP D_CLAVE_NULL,
    IEPS_10_GPOIMP D_CLAVE_NULL)
as
declare variable IEPS_X_IMPORTE D_IMPORTE;
declare variable IEPS_X_PORC D_PORCENTAJE;   
declare variable IEPS_X_GPOIMP D_CLAVE_NULL;
declare variable CUENTA integer;
declare variable REMISIONFACTURA integer;
declare variable CURR_ALMACENID D_FK;
declare variable CURR_VENDEDORID D_FK;
declare variable CURR_PERSONAID D_FK;
declare variable MOVTOMAINID D_FK;
declare variable DOCTOMAINREFKITID D_FK;
declare variable TASAIEPSDETALLE D_PORCENTAJE;
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

    IEPS_01_GPOIMP = '';
    IEPS_02_GPOIMP = '';
    IEPS_03_GPOIMP = '';
    IEPS_04_GPOIMP = '';
    IEPS_05_GPOIMP = '';
    IEPS_06_GPOIMP = '';
    IEPS_07_GPOIMP = '';
    IEPS_08_GPOIMP = '';
    IEPS_09_GPOIMP = '';
    IEPS_10_GPOIMP = '';

    ESTATUS = 'REMISION';
                            
    ALMACENID = COALESCE(:ALMACENID, 0);
    VENDEDORID = COALESCE(:vendedorid , 0);
            
     DOCTOREFKITID = 0;
     NOMBREALMACEN = '';

     
      PERSONA = ' ';
      VENDEDOR = '';
      PERSONACLAVE = '';
      PERSONANOMBRES = '';
      PERSONAAPELLIDOS = '';
      FECHAVENCE  = current_date;

      CANTIDAD = 0;
      PRECIO = 0;
      IMPORTE = 0;
      DESCUENTO = 0;
      NOMBRESUCURSALDESTINO = '';
      NOMBREALMACENTRASPASO = '';
      COSTOPROMEDIO = 0;
      TIPODOC = ''; 
      LOTE = '';
      LOTEVENCE = NULL;
      FECHAHORA = NULL;

  
  FOR SELECT TASA,  COALESCE(GPOIMP,'')
     FROM TASASIEPS
     WHERE TASASIEPS.ultimafecha >= :FECHAINI AND TASASIEPS.primerafecha <= :FECHAFIN
     ORDER BY COALESCE(TASASIEPS.cantidadreg,0)
    INTO :IEPS_X_PORC , :IEPS_X_GPOIMP
    DO
    BEGIN

        IF(:CUENTA = 1 ) THEN
        BEGIN
            IEPS_01_PORC =  :IEPS_X_PORC;
            IEPS_01_GPOIMP = :IEPS_X_GPOIMP;
        END        
        IF(:CUENTA = 2 ) THEN
        BEGIN
            IEPS_02_PORC =  :IEPS_X_PORC;  
            IEPS_02_GPOIMP = :IEPS_X_GPOIMP;
        END        
        IF(:CUENTA = 3 ) THEN
        BEGIN
            IEPS_03_PORC =  :IEPS_X_PORC;
            IEPS_03_GPOIMP = :IEPS_X_GPOIMP;
        END 
        IF(:CUENTA = 4 ) THEN
        BEGIN
            IEPS_04_PORC =  :IEPS_X_PORC; 
            IEPS_04_GPOIMP = :IEPS_X_GPOIMP;
        END 
        IF(:CUENTA = 5 ) THEN
        BEGIN
            IEPS_05_PORC =  :IEPS_X_PORC; 
            IEPS_05_GPOIMP = :IEPS_X_GPOIMP;
        END 
        IF(:CUENTA = 6 ) THEN
        BEGIN
            IEPS_06_PORC =  :IEPS_X_PORC;  
            IEPS_06_GPOIMP = :IEPS_X_GPOIMP;
        END 
        IF(:CUENTA = 7 ) THEN
        BEGIN
            IEPS_07_PORC =  :IEPS_X_PORC; 
            IEPS_07_GPOIMP = :IEPS_X_GPOIMP;
        END 
        IF(:CUENTA = 8 ) THEN
        BEGIN
            IEPS_08_PORC =  :IEPS_X_PORC; 
            IEPS_08_GPOIMP = :IEPS_X_GPOIMP;
        END 
        IF(:CUENTA = 9 ) THEN
        BEGIN
            IEPS_09_PORC =  :IEPS_X_PORC; 
            IEPS_09_GPOIMP = :IEPS_X_GPOIMP;
        END 
        IF(:CUENTA = 10 ) THEN
        BEGIN
            IEPS_10_PORC =  :IEPS_X_PORC; 
            IEPS_10_GPOIMP = :IEPS_X_GPOIMP;
        END
        CUENTA = CUENTA + 1;
    END




   FOR SELECT
      D.FECHA,
      COALESCE(M.SUBTOTAL,0) SUBTOTAL,
      COALESCE(M.IVA,0) IVA,
      COALESCE(M.TOTAL,0) TOTAL,
      D.esfacturaelectronica FACTURAELECTRONICA,

      COALESCE(M.IEPS,0)  IEPS,
      COALESCE(M.IMPUESTO,0) IMPUESTO,


      CASE WHEN COALESCE(D.ESFACTURAELECTRONICA,'N') <> 'S' THEN 'REMISION' ELSE 'FACTURA' END ESTATUS ,
      R.MARCAID MARCAID,
      P.CLAVE MARCACLAVE,
      P.NOMBRE MARCANOMBRE,


      M.PRODUCTOID PRODUCTOID,
      R.CLAVE PRODUCTOCLAVE,
      R.NOMBRE PRODUCTONOMBRE,
      R.DESCRIPCION PRODUCTODESCRIPCION,

      M.id MOVTOID  ,
                 D.FOLIO,
      coalesce(D.seriesat,'') || coalesce(D.foliosat,'') SERIEFOLIOSAT ,

      COALESCE(D.doctokitrefid,0) ,
      COALESCE(D.ALMACENID,0) ,
      COALESCE(D.VENDEDORID, 0),
      A.nombre NOMBREALMACEN,
      COALESCE(D.PERSONAID, 0) CURR_PERSONAID,
      M.CANTIDAD,
      M.PRECIO,
      M.IMPORTE,
      M.DESCUENTO,
      M.COSTOPROMEDIO ,
      COALESCE(ALT.nombre,'')  ALMACENTRASPASO,
      COALESCE(ST.NOMBRE,'') SUCURSALDESTINO    ,
      coalesce(TD.nombre, ' ') AS TIPODOC,
      COALESCE(M.LOTE,''),
      M.fechavence ,
      D.FECHAHORA  ,
      COALESCE(M.eskit,'N') ESKIT,
      'N' ESPARTEKIT  ,
      D.CORTEID ,
      LINEA.GPOIMP


   FROM CORTE
    INNER JOIN DOCTO D on CORTE.ID  = D.CORTEID
       Inner join MOVTO M
         ON M.doctoid = D.ID
         INNER JOIN PRODUCTO R ON R.ID = M.PRODUCTOID
        INNER JOIN MARCA P
        ON P.id = R.marcaid   
        left join almacen A on A.ID = D.almacenid   
        left join almacen ALT on ALT.ID = D.almacentid
        left join sucursal ST on ST.ID = D.sucursaltid  
         LEFT JOIN LINEA ON LINEA.ID = R.LINEAID
        left join TIPODOCTO  TD
         on  TD.id = d.tipodoctoid
         /*left join PERSONA PR
          on P.id = D.personaid
            left join PERSONA U
                on D.vendedorid = u.id*/
   WHERE (d.TIPODOCTOID = :TIPODOCTOID  OR (:TIPODOCTOID = -21 AND d.TIPODOCTOID IN (21,31,23,81))
          OR (:TIPODOCTOID = -31 AND d.TIPODOCTOID IN (31,81)) )
     AND CORTE.fechacorte BETWEEN :FECHAINI AND :FECHAFIN
     AND D.ESTATUSDOCTOID = 1
     AND ( CORTE.CAJEROID = COALESCE(:VENDEDORID,0) or COALESCE(:VENDEDORID,0) = 0 )
     --AND (:REMISIONFACTURA = 0 or (:REMISIONFACTURA = 1 AND Coalesce(D.esfacturaelectronica,'N') <> 'S') or (:REMISIONFACTURA = 2 AND Coalesce(D.esfacturaelectronica,'N') = 'S') )
     --AND COALESCE(m.IEPS,0) > 0

    -- GROUP BY D.FECHA,D.ESFACTURAELECTRONICA  ,m.productoid,P.CLAVE ,P.NOMBRE
   INTO
      :FECHA ,
      :SUBTOTAL,
      :IVA ,
      :TOTAL ,
      :ESFACTURAELECTRONICA  ,
      :IEPS,
      :IMPUESTO ,
      :ESTATUS  ,
      :MARCAID,
      :MARCACLAVE ,
      :MARCANOMBRE ,
      :PRODUCTOID,
      :PRODUCTOCLAVE ,
      :PRODUCTONOMBRE ,
      :PRODUCTODESCRIPCION,
      :MOVTOID ,
      :DOCTOFOLIO,
      :SERIEFOLIOSAT,
      :DOCTOREFKITID,
      :CURR_ALMACENID, :CURR_VENDEDORID  ,
      :NOMBREALMACEN,
      :CURR_PERSONAID,
      
      :CANTIDAD ,
      :PRECIO ,
      :IMPORTE ,
      :DESCUENTO ,
      :COSTOPROMEDIO,
      :NOMBREALMACENTRASPASO,
      :NOMBRESUCURSALDESTINO  ,
      :TIPODOC ,
      :LOTE,
      :LOTEVENCE,
      :FECHAHORA,
      :ESKIT ,
      :ESPARTEKIT,
      :CORTEID  ,
      :IEPS_X_GPOIMP

   DO
   BEGIN

     IF((:ALMACENID = 0 or  :CURR_ALMACENID = :ALMACENID) AND (COALESCE(:vendedorid,0) = 0 or :CURR_VENDEDORID = :VENDEDORID ) AND
         (:REMISIONFACTURA = 0 or (:REMISIONFACTURA = 1 AND Coalesce(:esfacturaelectronica,'N') <> 'S') or (:REMISIONFACTURA = 2 AND Coalesce(:esfacturaelectronica,'N') = 'S') )   ) THEN
    BEGIN


        SELECT COALESCE(U.nombre,0) VENDEDORNOMBRE FROM PERSONA U WHERE U.ID = :CURR_VENDEDORID INTO :vendedor;
        SELECT COALESCE(PR.clave,''),
                COALESCE(PR.nombres,''),
                COALESCE(PR.apellidos,''),
                dateadd (coalesce(PR.dias, 0) day to :fecha) fechavence  ,
                COALESCE(PR.NOMBRE,0)
                FROM PERSONA  PR
                WHERE PR.ID = :CURR_PERSONAID
                INTO    :PERSONACLAVE ,
                        :PERSONANOMBRES ,
                        :PERSONAAPELLIDOS ,
                        :FECHAVENCE ,
                        :PERSONA;

                        
            IEPS_01_IMPORTE = 0;
            IEPS_02_IMPORTE = 0;
            IEPS_03_IMPORTE = 0;
            IEPS_04_IMPORTE = 0;
            IEPS_05_IMPORTE = 0;
            IEPS_06_IMPORTE = 0;
            IEPS_07_IMPORTE = 0;
            IEPS_08_IMPORTE = 0;
            IEPS_09_IMPORTE = 0;
            IEPS_10_IMPORTE = 0;

       IF(COALESCE(:DESENSAMBLADO,'N') = 'N' and coalesce(:ESKIT,'N') = 'S') THEN
       BEGIN



        IF(:IEPS_01_PORC <> -1) THEN
        BEGIN     
            SELECT SUM(CASE WHEN COALESCE(MOVTO.ESKIT,'N') = 'N' OR COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S'  THEN COALESCE(IEPS,0) ELSE 0 END)
            FROM MOVTO     
            LEFT JOIN PRODUCTO ON MOVTO.PRODUCTOID = PRODUCTO.ID
            LEFT JOIN LINEA ON LINEA.ID = PRODUCTO.LINEAID
            WHERE (MOVTO.ID = :MOVTOID or (DOCTOID = :DOCTOREFKITID  AND MOVTOREFID = :MOVTOID))
                AND MOVTO.TASAIEPS = :IEPS_01_PORC   AND (COALESCE(:IEPS_01_GPOIMP,'') = COALESCE(LINEA.GPOIMP,''))
            INTO :IEPS_X_IMPORTE;
            IEPS_01_IMPORTE = :IEPS_X_IMPORTE;
        END
        
        IF(:IEPS_02_PORC <> -1) THEN
        BEGIN     
            SELECT SUM(CASE WHEN COALESCE(MOVTO.ESKIT,'N') = 'N' OR COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S'  THEN COALESCE(IEPS,0) ELSE 0 END)
            FROM MOVTO      
            LEFT JOIN PRODUCTO ON MOVTO.PRODUCTOID = PRODUCTO.ID
            LEFT JOIN LINEA ON LINEA.ID = PRODUCTO.LINEAID
            WHERE  (MOVTO.ID = :MOVTOID or (DOCTOID = :DOCTOREFKITID  AND MOVTOREFID = :MOVTOID))
            AND MOVTO.TASAIEPS = :IEPS_02_PORC AND (COALESCE(:IEPS_02_GPOIMP,'') = COALESCE(LINEA.GPOIMP,''))
            INTO :IEPS_X_IMPORTE;
            IEPS_02_IMPORTE = :IEPS_X_IMPORTE;
        END

        
        IF(:IEPS_03_PORC <> -1) THEN
        BEGIN     
            SELECT SUM(CASE WHEN COALESCE(MOVTO.ESKIT,'N') = 'N' OR COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S'  THEN COALESCE(IEPS,0) ELSE 0 END)
            FROM MOVTO   
            LEFT JOIN PRODUCTO ON MOVTO.PRODUCTOID = PRODUCTO.ID
            LEFT JOIN LINEA ON LINEA.ID = PRODUCTO.LINEAID
            WHERE (MOVTO.ID = :MOVTOID or (DOCTOID = :DOCTOREFKITID  AND MOVTOREFID = :MOVTOID))
            AND MOVTO.TASAIEPS = :IEPS_03_PORC  AND (COALESCE(:IEPS_03_GPOIMP,'') = COALESCE(LINEA.GPOIMP,''))
            INTO :IEPS_X_IMPORTE;
            IEPS_03_IMPORTE = :IEPS_X_IMPORTE;
        END

        
        IF(:IEPS_04_PORC <> -1) THEN
        BEGIN     
            SELECT SUM(CASE WHEN COALESCE(MOVTO.ESKIT,'N') = 'N' OR COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S'  THEN COALESCE(IEPS,0) ELSE 0 END)
            FROM MOVTO   
            LEFT JOIN PRODUCTO ON MOVTO.PRODUCTOID = PRODUCTO.ID
            LEFT JOIN LINEA ON LINEA.ID = PRODUCTO.LINEAID
            WHERE (MOVTO.ID = :MOVTOID or (DOCTOID = :DOCTOREFKITID  AND MOVTOREFID = :MOVTOID))
            AND MOVTO.TASAIEPS = :IEPS_04_PORC   AND (COALESCE(:IEPS_04_GPOIMP,'') = COALESCE(LINEA.GPOIMP,''))
            INTO :IEPS_X_IMPORTE;
            IEPS_04_IMPORTE = :IEPS_X_IMPORTE;
        END
              
        IF(:IEPS_05_PORC <> -1) THEN
        BEGIN     
            SELECT SUM(CASE WHEN COALESCE(MOVTO.ESKIT,'N') = 'N' OR COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S'  THEN COALESCE(IEPS,0) ELSE 0 END)
            FROM MOVTO    
            LEFT JOIN PRODUCTO ON MOVTO.PRODUCTOID = PRODUCTO.ID
            LEFT JOIN LINEA ON LINEA.ID = PRODUCTO.LINEAID
            WHERE (MOVTO.ID = :MOVTOID or (DOCTOID = :DOCTOREFKITID  AND MOVTOREFID = :MOVTOID))
            AND MOVTO.TASAIEPS = :IEPS_05_PORC  AND (COALESCE(:IEPS_05_GPOIMP,'') = COALESCE(LINEA.GPOIMP,''))
            INTO :IEPS_X_IMPORTE;
            IEPS_05_IMPORTE = :IEPS_X_IMPORTE;
        END       
              
        IF(:IEPS_06_PORC <> -1) THEN
        BEGIN     
            SELECT SUM(CASE WHEN COALESCE(MOVTO.ESKIT,'N') = 'N' OR COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S'  THEN COALESCE(IEPS,0) ELSE 0 END)
            FROM MOVTO 
            LEFT JOIN PRODUCTO ON MOVTO.PRODUCTOID = PRODUCTO.ID
            LEFT JOIN LINEA ON LINEA.ID = PRODUCTO.LINEAID
            WHERE (MOVTO.ID = :MOVTOID or (DOCTOID = :DOCTOREFKITID  AND MOVTOREFID = :MOVTOID))
            AND MOVTO.TASAIEPS = :IEPS_06_PORC   AND (COALESCE(:IEPS_06_GPOIMP,'') = COALESCE(LINEA.GPOIMP,''))
            INTO :IEPS_X_IMPORTE;
            IEPS_06_IMPORTE = :IEPS_X_IMPORTE;
        END        
              
        IF(:IEPS_07_PORC <> -1) THEN
        BEGIN     
            SELECT SUM(CASE WHEN COALESCE(MOVTO.ESKIT,'N') = 'N' OR COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S'  THEN COALESCE(IEPS,0) ELSE 0 END)
            FROM MOVTO  
            LEFT JOIN PRODUCTO ON MOVTO.PRODUCTOID = PRODUCTO.ID
            LEFT JOIN LINEA ON LINEA.ID = PRODUCTO.LINEAID
            WHERE (MOVTO.ID = :MOVTOID or (DOCTOID = :DOCTOREFKITID  AND MOVTOREFID = :MOVTOID))    
            AND MOVTO.TASAIEPS = :IEPS_07_PORC   AND (COALESCE(:IEPS_07_GPOIMP,'') = COALESCE(LINEA.GPOIMP,''))
            INTO :IEPS_X_IMPORTE;
            IEPS_07_IMPORTE = :IEPS_X_IMPORTE;
        END         
              
        IF(:IEPS_08_PORC <> -1) THEN
        BEGIN     
            SELECT SUM(CASE WHEN COALESCE(MOVTO.ESKIT,'N') = 'N' OR COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S'  THEN COALESCE(IEPS,0) ELSE 0 END)
            FROM MOVTO    
            LEFT JOIN PRODUCTO ON MOVTO.PRODUCTOID = PRODUCTO.ID
            LEFT JOIN LINEA ON LINEA.ID = PRODUCTO.LINEAID
            WHERE (MOVTO.ID = :MOVTOID or (DOCTOID = :DOCTOREFKITID  AND MOVTOREFID = :MOVTOID))
            AND MOVTO.TASAIEPS = :IEPS_08_PORC  AND (COALESCE(:IEPS_08_GPOIMP,'') = COALESCE(LINEA.GPOIMP,''))
            INTO :IEPS_X_IMPORTE;
            IEPS_08_IMPORTE = :IEPS_X_IMPORTE;
        END    
              
        IF(:IEPS_09_PORC <> -1) THEN
        BEGIN     
            SELECT SUM(CASE WHEN COALESCE(MOVTO.ESKIT,'N') = 'N' OR COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S'  THEN COALESCE(IEPS,0) ELSE 0 END)
            FROM MOVTO  
            LEFT JOIN PRODUCTO ON MOVTO.PRODUCTOID = PRODUCTO.ID
            LEFT JOIN LINEA ON LINEA.ID = PRODUCTO.LINEAID
            WHERE (MOVTO.ID = :MOVTOID or (DOCTOID = :DOCTOREFKITID  AND MOVTOREFID = :MOVTOID))
            AND MOVTO.TASAIEPS = :IEPS_09_PORC   AND (COALESCE(:IEPS_09_GPOIMP,'') = COALESCE(LINEA.GPOIMP,''))
            INTO :IEPS_X_IMPORTE;
            IEPS_09_IMPORTE = :IEPS_X_IMPORTE;
        END        
              
        IF(:IEPS_10_PORC <> -1) THEN
        BEGIN     
            SELECT SUM(CASE WHEN COALESCE(MOVTO.ESKIT,'N') = 'N' OR COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S'  THEN COALESCE(IEPS,0) ELSE 0 END)
            FROM MOVTO   
            LEFT JOIN PRODUCTO ON MOVTO.PRODUCTOID = PRODUCTO.ID
            LEFT JOIN LINEA ON LINEA.ID = PRODUCTO.LINEAID
            WHERE (MOVTO.ID = :MOVTOID or (DOCTOID = :DOCTOREFKITID  AND MOVTOREFID = :MOVTOID))
            AND MOVTO.TASAIEPS = :IEPS_10_PORC  AND (COALESCE(:IEPS_10_GPOIMP,'') = COALESCE(LINEA.GPOIMP,''))
            INTO :IEPS_X_IMPORTE;
            IEPS_10_IMPORTE = :IEPS_X_IMPORTE;
        END
      SUSPEND;
     END
     ELSE IF(COALESCE(:DESENSAMBLADO,'N') = 'N') THEN
     BEGIN


             IEPS_01_IMPORTE = 0;
            IEPS_02_IMPORTE = 0;
            IEPS_03_IMPORTE = 0;
            IEPS_04_IMPORTE = 0;
            IEPS_05_IMPORTE = 0;
            IEPS_06_IMPORTE = 0;
            IEPS_07_IMPORTE = 0;
            IEPS_08_IMPORTE = 0;
            IEPS_09_IMPORTE = 0;
            IEPS_10_IMPORTE = 0;

            IF((COALESCE(:IEPS_01_PORC,-1) <> -1 AND :IEPS_01_PORC = COALESCE(:TASAIEPSDETALLE,-1))
              AND (COALESCE(:IEPS_X_GPOIMP,'') = COALESCE(:IEPS_01_GPOIMP,'')))THEN
            BEGIN
                IEPS_01_IMPORTE = COALESCE(:IEPS,0);
            END   
            
            IF((COALESCE(:IEPS_02_PORC,-1) <> -1 AND :IEPS_02_PORC = COALESCE(:TASAIEPSDETALLE,-1))
              AND (COALESCE(:IEPS_X_GPOIMP,'') = COALESCE(:IEPS_02_GPOIMP,''))) THEN
            BEGIN
                IEPS_02_IMPORTE = COALESCE(:IEPS,0);
            END
               
            IF((COALESCE(:IEPS_03_PORC,-1) <> -1 AND :IEPS_03_PORC = COALESCE(:TASAIEPSDETALLE,-1))
              AND (COALESCE(:IEPS_X_GPOIMP,'') = COALESCE(:IEPS_03_GPOIMP,''))) THEN
            BEGIN
                IEPS_03_IMPORTE = COALESCE(:IEPS,0);
            END   
            
            IF((COALESCE(:IEPS_04_PORC,-1) <> -1 AND :IEPS_04_PORC = COALESCE(:TASAIEPSDETALLE,-1))
              AND (COALESCE(:IEPS_X_GPOIMP,'') = COALESCE(:IEPS_04_GPOIMP,''))) THEN
            BEGIN
                IEPS_04_IMPORTE = COALESCE(:IEPS,0);
            END   

            IF((COALESCE(:IEPS_05_PORC,-1) <> -1 AND :IEPS_05_PORC = COALESCE(:TASAIEPSDETALLE,-1))
              AND (COALESCE(:IEPS_X_GPOIMP,'') = COALESCE(:IEPS_05_GPOIMP,''))) THEN
            BEGIN
                IEPS_05_IMPORTE = COALESCE(:IEPS,0);
            END   
            
            IF((COALESCE(:IEPS_06_PORC,-1) <> -1 AND :IEPS_06_PORC = COALESCE(:TASAIEPSDETALLE,-1))
              AND (COALESCE(:IEPS_X_GPOIMP,'') = COALESCE(:IEPS_06_GPOIMP,''))) THEN
            BEGIN
                IEPS_06_IMPORTE = COALESCE(:IEPS,0);
            END    
            
            IF((COALESCE(:IEPS_07_PORC,-1) <> -1 AND :IEPS_07_PORC = COALESCE(:TASAIEPSDETALLE,-1))
              AND (COALESCE(:IEPS_X_GPOIMP,'') = COALESCE(:IEPS_07_GPOIMP,''))) THEN
            BEGIN
                IEPS_07_IMPORTE = COALESCE(:IEPS,0);
            END   
            
            IF((COALESCE(:IEPS_08_PORC,-1) <> -1 AND :IEPS_08_PORC = COALESCE(:TASAIEPSDETALLE,-1))
              AND (COALESCE(:IEPS_X_GPOIMP,'') = COALESCE(:IEPS_08_GPOIMP,''))) THEN
            BEGIN
                IEPS_08_IMPORTE = COALESCE(:IEPS,0);
            END   
            
            IF((COALESCE(:IEPS_09_PORC,-1) <> -1 AND :IEPS_09_PORC = COALESCE(:TASAIEPSDETALLE,-1))
              AND (COALESCE(:IEPS_X_GPOIMP,'') = COALESCE(:IEPS_09_GPOIMP,''))) THEN
            BEGIN
                IEPS_09_IMPORTE = COALESCE(:IEPS,0);
            END   
            
            IF((COALESCE(:IEPS_10_PORC,-1) <> -1 AND :IEPS_10_PORC = COALESCE(:TASAIEPSDETALLE,-1))
              AND (COALESCE(:IEPS_X_GPOIMP,'') = COALESCE(:IEPS_10_GPOIMP,'')))  THEN
            BEGIN
                IEPS_10_IMPORTE = COALESCE(:IEPS,0);
            END   

             SUSPEND;

            
     END
     ELSE
     BEGIN


         MOVTOMAINID = :MOVTOID;
         DOCTOMAINREFKITID = :DOCTOREFKITID;
              
         FOR SELECT
      D.FECHA,
      COALESCE(M.SUBTOTAL,0) SUBTOTAL,
      COALESCE(M.IVA,0) IVA,
      COALESCE(M.TOTAL,0) TOTAL,
      D.esfacturaelectronica FACTURAELECTRONICA,

      COALESCE(M.IEPS,0)  IEPS,
      COALESCE(M.IMPUESTO,0) IMPUESTO,


      CASE WHEN COALESCE(D.ESFACTURAELECTRONICA,'N') <> 'S' THEN 'REMISION' ELSE 'FACTURA' END ESTATUS ,
      R.MARCAID MARCAID,
      P.CLAVE MARCACLAVE,
      P.NOMBRE MARCANOMBRE,


      M.PRODUCTOID PRODUCTOID,
      R.CLAVE PRODUCTOCLAVE,
      R.NOMBRE PRODUCTONOMBRE,
      R.DESCRIPCION PRODUCTODESCRIPCION,

      M.id MOVTOID  ,
                 D.FOLIO,
      coalesce(D.seriesat,'') || coalesce(D.foliosat,'') SERIEFOLIOSAT ,

      COALESCE(D.doctokitrefid,0) ,
      COALESCE(D.ALMACENID,0) ,
      COALESCE(D.VENDEDORID, 0),
      A.nombre NOMBREALMACEN,
      COALESCE(D.PERSONAID, 0) CURR_PERSONAID,
      M.CANTIDAD,
      M.PRECIO,
      M.IMPORTE,
      M.DESCUENTO,
      M.COSTOPROMEDIO ,
      COALESCE(M.LOTE,''),
      M.fechavence ,
      D.FECHAHORA ,
      COALESCE(M.TASAIEPS,0) TASAIEPS ,
      'N' ESKIT ,
      'S' ESPARTEKIT,
      LINEA.GPOIMP


   FROM DOCTO D
       Inner join MOVTO M
         ON M.doctoid = D.ID
         INNER JOIN PRODUCTO R ON R.ID = M.PRODUCTOID
         LEFT JOIN LINEA ON LINEA.ID = R.LINEAID
        INNER JOIN MARCA P
        ON P.id = R.marcaid   
        left join almacen A on A.ID = D.almacenid   
        left join almacen ALT on ALT.ID = D.almacentid
        left join sucursal ST on ST.ID = D.sucursaltid  
        left join TIPODOCTO  TD
         on  TD.id = d.tipodoctoid
         /*left join PERSONA PR
          on P.id = D.personaid
            left join PERSONA U
                on D.vendedorid = u.id*/
   WHERE D.ID =  :DOCTOMAINREFKITID AND M.movtorefid =  :MOVTOMAINID

    -- GROUP BY D.FECHA,D.ESFACTURAELECTRONICA  ,m.productoid,P.CLAVE ,P.NOMBRE
   INTO
      :FECHA ,
      :SUBTOTAL,
      :IVA ,
      :TOTAL ,
      :ESFACTURAELECTRONICA  ,
      :IEPS,
      :IMPUESTO ,
      :ESTATUS  ,
      :MARCAID,
      :MARCACLAVE ,
      :MARCANOMBRE ,
      :PRODUCTOID,
      :PRODUCTOCLAVE ,
      :PRODUCTONOMBRE ,
      :PRODUCTODESCRIPCION,
      :MOVTOID ,
      :DOCTOFOLIO,
      :SERIEFOLIOSAT,
      :DOCTOREFKITID,
      :CURR_ALMACENID, :CURR_VENDEDORID  ,
      :NOMBREALMACEN,
      :CURR_PERSONAID,
      
      :CANTIDAD ,
      :PRECIO ,
      :IMPORTE ,
      :DESCUENTO ,
      :COSTOPROMEDIO,
      :LOTE,
      :LOTEVENCE,
      :FECHAHORA,
      :TASAIEPSDETALLE,
      :ESKIT ,
      :ESPARTEKIT ,
      :IEPS_X_GPOIMP

        DO
        BEGIN

             
             
            IEPS_01_IMPORTE = 0;
            IEPS_02_IMPORTE = 0;
            IEPS_03_IMPORTE = 0;
            IEPS_04_IMPORTE = 0;
            IEPS_05_IMPORTE = 0;
            IEPS_06_IMPORTE = 0;
            IEPS_07_IMPORTE = 0;
            IEPS_08_IMPORTE = 0;
            IEPS_09_IMPORTE = 0;
            IEPS_10_IMPORTE = 0;

            IF((COALESCE(:IEPS_01_PORC,-1) <> -1 AND :IEPS_01_PORC = COALESCE(:TASAIEPSDETALLE,-1))
              AND (COALESCE(:IEPS_X_GPOIMP,'') = COALESCE(:IEPS_01_GPOIMP,''))) THEN
            BEGIN
                IEPS_01_IMPORTE = COALESCE(:IEPS,0);
            END   
            
            IF((COALESCE(:IEPS_02_PORC,-1) <> -1 AND :IEPS_02_PORC = COALESCE(:TASAIEPSDETALLE,-1))
              AND (COALESCE(:IEPS_X_GPOIMP,'') = COALESCE(:IEPS_02_GPOIMP,''))) THEN
            BEGIN
                IEPS_02_IMPORTE = COALESCE(:IEPS,0);
            END
               
            IF((COALESCE(:IEPS_03_PORC,-1) <> -1 AND :IEPS_03_PORC = COALESCE(:TASAIEPSDETALLE,-1))
              AND (COALESCE(:IEPS_X_GPOIMP,'') = COALESCE(:IEPS_03_GPOIMP,''))) THEN
            BEGIN
                IEPS_03_IMPORTE = COALESCE(:IEPS,0);
            END   
            
            IF((COALESCE(:IEPS_04_PORC,-1) <> -1 AND :IEPS_04_PORC = COALESCE(:TASAIEPSDETALLE,-1))
              AND (COALESCE(:IEPS_X_GPOIMP,'') = COALESCE(:IEPS_04_GPOIMP,''))) THEN
            BEGIN
                IEPS_04_IMPORTE = COALESCE(:IEPS,0);
            END   

            IF((COALESCE(:IEPS_05_PORC,-1) <> -1 AND :IEPS_05_PORC = COALESCE(:TASAIEPSDETALLE,-1))
              AND (COALESCE(:IEPS_X_GPOIMP,'') = COALESCE(:IEPS_05_GPOIMP,''))) THEN
            BEGIN
                IEPS_05_IMPORTE = COALESCE(:IEPS,0);
            END   
            
            IF((COALESCE(:IEPS_06_PORC,-1) <> -1 AND :IEPS_06_PORC = COALESCE(:TASAIEPSDETALLE,-1))
              AND (COALESCE(:IEPS_X_GPOIMP,'') = COALESCE(:IEPS_06_GPOIMP,''))) THEN
            BEGIN
                IEPS_06_IMPORTE = COALESCE(:IEPS,0);
            END    
            
            IF((COALESCE(:IEPS_07_PORC,-1) <> -1 AND :IEPS_07_PORC = COALESCE(:TASAIEPSDETALLE,-1))
              AND (COALESCE(:IEPS_X_GPOIMP,'') = COALESCE(:IEPS_07_GPOIMP,''))) THEN
            BEGIN
                IEPS_07_IMPORTE = COALESCE(:IEPS,0);
            END   
            
            IF((COALESCE(:IEPS_08_PORC,-1) <> -1 AND :IEPS_08_PORC = COALESCE(:TASAIEPSDETALLE,-1))
              AND (COALESCE(:IEPS_X_GPOIMP,'') = COALESCE(:IEPS_08_GPOIMP,''))) THEN
            BEGIN
                IEPS_08_IMPORTE = COALESCE(:IEPS,0);
            END   
            
            IF((COALESCE(:IEPS_09_PORC,-1) <> -1 AND :IEPS_09_PORC = COALESCE(:TASAIEPSDETALLE,-1))
              AND (COALESCE(:IEPS_X_GPOIMP,'') = COALESCE(:IEPS_09_GPOIMP,''))) THEN
            BEGIN
                IEPS_09_IMPORTE = COALESCE(:IEPS,0);
            END   
            
            IF((COALESCE(:IEPS_10_PORC,-1) <> -1 AND :IEPS_10_PORC = COALESCE(:TASAIEPSDETALLE,-1))
              AND (COALESCE(:IEPS_X_GPOIMP,'') = COALESCE(:IEPS_10_GPOIMP,''))) THEN
            BEGIN
                IEPS_10_IMPORTE = COALESCE(:IEPS,0);
            END   

             SUSPEND;
        END

     END
    END





   END

   if (:numero = 0) then
   begin
      numero = 0;
      fecha = current_date;
      SUBTOTAL = 0.00;
      IVA = 0.00;
      TOTAL = 0.00;
      ESFACTURAELECTRONICA  = 'N';
      IEPS = 0;
      IMPUESTO = 0;
      -- sin suspend para no regresar renglon falso




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

      ESTATUS = '';
      MARCAID = 0;
    MARCACLAVE = '';
    MARCANOMBRE  = '';

    PRODUCTOID = 0;
    PRODUCTOCLAVE = '';
    PRODUCTONOMBRE = '';
    PRODUCTODESCRIPCION = '';

       movtoid = 0;

       
     DOCTOFOLIO = 0;
     SERIEFOLIOSAT = '';
     DOCTOREFKITID = 0;
     NOMBREALMACEN = '';

     
      PERSONA = ' ';
      VENDEDOR = '';
      PERSONACLAVE = '';
      PERSONANOMBRES = '';
      PERSONAAPELLIDOS = '';
      FECHAVENCE  = current_date;


      
      CANTIDAD = 0;
      PRECIO = 0;
      IMPORTE = 0;
      DESCUENTO = 0;
      NOMBRESUCURSALDESTINO = '';
      NOMBREALMACENTRASPASO = '';
      COSTOPROMEDIO = 0;
      TIPODOC = '';
      LOTE = '';
      LOTEVENCE = NULL;
      
      FECHAHORA = NULL;
      ESKIT = 'N';
      ESPARTEKIT = 'N';
      CORTEID = 0;
   end

END