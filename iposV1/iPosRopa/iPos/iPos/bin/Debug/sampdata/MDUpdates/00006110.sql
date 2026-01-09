CREATE OR ALTER trigger producto_logmgmt for producto
active after update position 100
AS
 declare variable ANTES D_MEMO;
 declare variable DESPUES D_MEMO;
 declare variable CAMBIOALGO D_BOOLCN;

 declare variable HABILITARLOG D_BOOLCN;

 declare variable BUFFERTEXT D_STDTEXT_MEDIUM;

begin
  /* Trigger text */

  SELECT FIRST 1 HABILITARLOG FROM PARAMETRO INTO :HABILITARLOG;
  IF(COALESCE(:HABILITARLOG, 'N') = 'N') THEN
  BEGIN
     EXIT;
  END


  ANTES = '{';
  DESPUES = '{';
  CAMBIOALGO = 'N';





   IF(NEW.PRECIO1 <> OLD.PRECIO1) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "PRECIO1":' || CAST(COALESCE(OLD.PRECIO1,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "PRECIO1":' || CAST(COALESCE(NEW.PRECIO1,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.PRECIO2 <> OLD.PRECIO2) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "PRECIO2":' || CAST(COALESCE(OLD.PRECIO2,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "PRECIO2":' || CAST(COALESCE(NEW.PRECIO2,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.EAN <> OLD.EAN) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "EAN":"' || REPLACE(COALESCE(OLD.EAN,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "EAN":"' || REPLACE(COALESCE(NEW.EAN,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END


  IF(NEW.FECHACAMBIOPRECIO <> OLD.FECHACAMBIOPRECIO) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "FECHACAMBIOPRECIO":"' || CAST(COALESCE(OLD.FECHACAMBIOPRECIO,'01.01.2000') AS VARCHAR(20)) || '"' ;
       DESPUES = :DESPUES ||  ' "FECHACAMBIOPRECIO":"' || CAST(COALESCE(NEW.FECHACAMBIOPRECIO,'01.01.2000') AS VARCHAR(20)) || '"' ;
       --CAMBIOALGO = 'S';
  END

  IF(NEW.CBARRAS <> OLD.CBARRAS) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "CBARRAS":"' || REPLACE(COALESCE(OLD.CBARRAS,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "CBARRAS":"' || REPLACE(COALESCE(NEW.CBARRAS,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END

    IF(NEW.NOMBRE <> OLD.NOMBRE) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "NOMBRE":"' || REPLACE(COALESCE(OLD.NOMBRE,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "NOMBRE":"' || REPLACE(COALESCE(NEW.NOMBRE,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.DESCRIPCION1 <> OLD.DESCRIPCION1) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "DESCRIPCION1":"' || REPLACE(COALESCE(OLD.DESCRIPCION1,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "DESCRIPCION1":"' || REPLACE(COALESCE(NEW.DESCRIPCION1,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.DESCRIPCION2 <> OLD.DESCRIPCION2) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "DESCRIPCION2":"' || REPLACE(COALESCE(OLD.DESCRIPCION2,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "DESCRIPCION2":"' || REPLACE(COALESCE(NEW.DESCRIPCION2,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.DESCRIPCION3 <> OLD.DESCRIPCION3) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "DESCRIPCION3":"' || REPLACE(COALESCE(OLD.DESCRIPCION3,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "DESCRIPCION3":"' || REPLACE(COALESCE(NEW.DESCRIPCION3,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END


    IF(NEW.PROVEEDOR1ID <> OLD.PROVEEDOR1ID) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       --ANTES = :ANTES ||  ' "PROVEEDOR1ID":' || CAST(COALESCE(OLD.PROVEEDOR1ID,0) AS VARCHAR(20)) ;
       --DESPUES = :DESPUES ||  ' "PROVEEDOR1ID":' || CAST(COALESCE(NEW.PROVEEDOR1ID,0) AS VARCHAR(20)) ;


       SELECT CLAVE FROM PERSONA where ID = OLD.PROVEEDOR1ID INTO :BUFFERTEXT;
       ANTES = :ANTES ||  ' "PROVEEDOR1CLAVE":"' || REPLACE(COALESCE(:BUFFERTEXT,''),'"','\"') || '"' ;
           
       SELECT CLAVE FROM PERSONA where ID = NEW.PROVEEDOR1ID INTO :BUFFERTEXT;
       DESPUES = :DESPUES ||  ' "PROVEEDOR1CLAVE":"' || REPLACE(COALESCE(:BUFFERTEXT,''),'"','\"') || '"' ;

        CAMBIOALGO = 'S';



  END
  IF(NEW.PROVEEDOR2ID <> OLD.PROVEEDOR2ID) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       --ANTES = :ANTES ||  ' "PROVEEDOR2ID":' || CAST(COALESCE(OLD.PROVEEDOR2ID,0) AS VARCHAR(20)) ;
       --DESPUES = :DESPUES ||  ' "PROVEEDOR2ID":' || CAST(COALESCE(NEW.PROVEEDOR2ID,0) AS VARCHAR(20)) ;

       SELECT CLAVE FROM PERSONA where ID = OLD.PROVEEDOR2ID INTO :BUFFERTEXT;
       ANTES = :ANTES ||  ' "PROVEEDOR2CLAVE":"' || REPLACE(COALESCE(:BUFFERTEXT,''),'"','\"') || '"' ;
           
       SELECT CLAVE FROM PERSONA where ID = NEW.PROVEEDOR2ID INTO :BUFFERTEXT;
       DESPUES = :DESPUES ||  ' "PROVEEDOR2CLAVE":"' || REPLACE(COALESCE(:BUFFERTEXT,''),'"','\"') || '"' ;

        CAMBIOALGO = 'S';
  END
  IF(NEW.LINEAID <> OLD.LINEAID) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       --ANTES = :ANTES ||  ' "LINEAID":' || CAST(COALESCE(OLD.LINEAID,0) AS VARCHAR(20)) ;
       --DESPUES = :DESPUES ||  ' "LINEAID":' || CAST(COALESCE(NEW.LINEAID,0) AS VARCHAR(20)) ;

       SELECT CLAVE FROM LINEA where ID = OLD.LINEAID INTO :BUFFERTEXT;
       ANTES = :ANTES ||  ' "LINEACLAVE":"' || REPLACE(COALESCE(:BUFFERTEXT,''),'"','\"') || '"' ;
           
       SELECT CLAVE FROM LINEA where ID = NEW.LINEAID INTO :BUFFERTEXT;
       DESPUES = :DESPUES ||  ' "LINEACLAVE":"' || REPLACE(COALESCE(:BUFFERTEXT,''),'"','\"') || '"' ;

        CAMBIOALGO = 'S';
  END

  IF(NEW.MARCAID <> OLD.MARCAID) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       --ANTES = :ANTES ||  ' "MARCAID":' || CAST(COALESCE(OLD.MARCAID,0) AS VARCHAR(20)) ;
       --DESPUES = :DESPUES ||  ' "MARCAID":' || CAST(COALESCE(NEW.MARCAID,0) AS VARCHAR(20)) ;

       SELECT CLAVE FROM MARCA where ID = OLD.MARCAID INTO :BUFFERTEXT;
       ANTES = :ANTES ||  ' "MARCACLAVE":"' || REPLACE(COALESCE(:BUFFERTEXT,''),'"','\"') || '"' ;
           
       SELECT CLAVE FROM MARCA where ID = NEW.MARCAID INTO :BUFFERTEXT;
       DESPUES = :DESPUES ||  ' "MARCACLAVE":"' || REPLACE(COALESCE(:BUFFERTEXT,''),'"','\"') || '"' ;

        CAMBIOALGO = 'S';
  END


    IF(NEW.MARCAID <> OLD.MARCAID) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "MARCAID":' || CAST(COALESCE(OLD.MARCAID,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "MARCAID":' || CAST(COALESCE(NEW.MARCAID,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.PRODUCTOSUSTITUTOID <> OLD.PRODUCTOSUSTITUTOID) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       --ANTES = :ANTES ||  ' "PRODUCTOSUSTITUTOID":' || CAST(COALESCE(OLD.PRODUCTOSUSTITUTOID,0) AS VARCHAR(20)) ;
       --DESPUES = :DESPUES ||  ' "PRODUCTOSUSTITUTOID":' || CAST(COALESCE(NEW.PRODUCTOSUSTITUTOID,0) AS VARCHAR(20)) ;

       SELECT CLAVE FROM PRODUCTO where ID = OLD.PRODUCTOSUSTITUTOID INTO :BUFFERTEXT;
       ANTES = :ANTES ||  ' "PRODUCTOSUSTITUTOCLAVE":"' || REPLACE(COALESCE(:BUFFERTEXT,''),'"','\"') || '"' ;
           
       SELECT CLAVE FROM PRODUCTO where ID = NEW.PRODUCTOSUSTITUTOID INTO :BUFFERTEXT;
       DESPUES = :DESPUES ||  ' "PRODUCTOSUSTITUTOCLAVE":"' || REPLACE(COALESCE(:BUFFERTEXT,''),'"','\"') || '"' ;

        CAMBIOALGO = 'S';
  END
  IF(NEW.MANEJALOTE <> OLD.MANEJALOTE) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "MANEJALOTE":"' || REPLACE(COALESCE(OLD.MANEJALOTE,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "MANEJALOTE":"' || REPLACE(COALESCE(NEW.MANEJALOTE,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.ESKIT <> OLD.ESKIT) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "ESKIT":"' || REPLACE(COALESCE(OLD.ESKIT,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "ESKIT":"' || REPLACE(COALESCE(NEW.ESKIT,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.UNIDAD <> OLD.UNIDAD) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "UNIDAD":"' || REPLACE(COALESCE(OLD.UNIDAD,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "UNIDAD":"' || REPLACE(COALESCE(NEW.UNIDAD,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.IMPRIMIR <> OLD.IMPRIMIR) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "IMPRIMIR":"' || REPLACE(COALESCE(OLD.IMPRIMIR,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "IMPRIMIR":"' || REPLACE(COALESCE(NEW.IMPRIMIR,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.INVENTARIABLE <> OLD.INVENTARIABLE) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "INVENTARIABLE":"' || REPLACE(COALESCE(OLD.INVENTARIABLE,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "INVENTARIABLE":"' || REPLACE(COALESCE(NEW.INVENTARIABLE,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.U_EMPAQUE <> OLD.U_EMPAQUE) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "U_EMPAQUE":' || CAST(COALESCE(OLD.U_EMPAQUE,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "U_EMPAQUE":' || CAST(COALESCE(NEW.U_EMPAQUE,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.STOCK <> OLD.STOCK) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "STOCK":' || CAST(COALESCE(OLD.STOCK,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "STOCK":' || CAST(COALESCE(NEW.STOCK,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.SURTIRPORCAJA <> OLD.SURTIRPORCAJA) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "SURTIRPORCAJA":"' || REPLACE(COALESCE(OLD.SURTIRPORCAJA,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "SURTIRPORCAJA":"' || REPLACE(COALESCE(NEW.SURTIRPORCAJA,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.STOCKMAX <> OLD.STOCKMAX) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "STOCKMAX":' || CAST(COALESCE(OLD.STOCKMAX,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "STOCKMAX":' || CAST(COALESCE(NEW.STOCKMAX,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.MAYOKGS <> OLD.MAYOKGS) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "MAYOKGS":"' || REPLACE(COALESCE(OLD.MAYOKGS,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "MAYOKGS":"' || REPLACE(COALESCE(NEW.MAYOKGS,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.INI_MAYO <> OLD.INI_MAYO) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "INI_MAYO":' || CAST(COALESCE(OLD.INI_MAYO,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "INI_MAYO":' || CAST(COALESCE(NEW.INI_MAYO,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.PZACAJA <> OLD.PZACAJA) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "PZACAJA":' || CAST(COALESCE(OLD.PZACAJA,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "PZACAJA":' || CAST(COALESCE(NEW.PZACAJA,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.NEGATIVOS <> OLD.NEGATIVOS) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "NEGATIVOS":"' || REPLACE(COALESCE(OLD.NEGATIVOS,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "NEGATIVOS":"' || REPLACE(COALESCE(NEW.NEGATIVOS,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.MANEJASTOCK <> OLD.MANEJASTOCK) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "MANEJASTOCK":"' || REPLACE(COALESCE(OLD.MANEJASTOCK,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "MANEJASTOCK":"' || REPLACE(COALESCE(NEW.MANEJASTOCK,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END


    IF(NEW.PRECIO3 <> OLD.PRECIO3) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "PRECIO3":' || CAST(COALESCE(OLD.PRECIO3,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "PRECIO3":' || CAST(COALESCE(NEW.PRECIO3,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.PRECIO4 <> OLD.PRECIO4) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "PRECIO4":' || CAST(COALESCE(OLD.PRECIO4,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "PRECIO4":' || CAST(COALESCE(NEW.PRECIO4,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.PRECIO5 <> OLD.PRECIO5) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "PRECIO5":' || CAST(COALESCE(OLD.PRECIO5,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "PRECIO5":' || CAST(COALESCE(NEW.PRECIO5,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.SPRECIO1 <> OLD.SPRECIO1) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "SPRECIO1":' || CAST(COALESCE(OLD.SPRECIO1,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "SPRECIO1":' || CAST(COALESCE(NEW.SPRECIO1,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.SPRECIO2 <> OLD.SPRECIO2) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "SPRECIO2":' || CAST(COALESCE(OLD.SPRECIO2,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "SPRECIO2":' || CAST(COALESCE(NEW.SPRECIO2,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.SPRECIO3 <> OLD.SPRECIO3) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "SPRECIO3":' || CAST(COALESCE(OLD.SPRECIO3,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "SPRECIO3":' || CAST(COALESCE(NEW.SPRECIO3,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.SPRECIO4 <> OLD.SPRECIO4) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "SPRECIO4":' || CAST(COALESCE(OLD.SPRECIO4,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "SPRECIO4":' || CAST(COALESCE(NEW.SPRECIO4,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.SPRECIO5 <> OLD.SPRECIO5) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "SPRECIO5":' || CAST(COALESCE(OLD.SPRECIO5,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "SPRECIO5":' || CAST(COALESCE(NEW.SPRECIO5,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.DESCRIPCION <> OLD.DESCRIPCION) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "DESCRIPCION":"' || REPLACE(COALESCE(OLD.DESCRIPCION,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "DESCRIPCION":"' || REPLACE(COALESCE(NEW.DESCRIPCION,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.DESCRIPCION2 <> OLD.DESCRIPCION2) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "DESCRIPCION2":"' || REPLACE(COALESCE(OLD.DESCRIPCION2,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "DESCRIPCION2":"' || REPLACE(COALESCE(NEW.DESCRIPCION2,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.LIMITEPRECIO2 <> OLD.LIMITEPRECIO2) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "LIMITEPRECIO2":' || CAST(COALESCE(OLD.LIMITEPRECIO2,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "LIMITEPRECIO2":' || CAST(COALESCE(NEW.LIMITEPRECIO2,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.PRECIOMAXIMOPUBLICO <> OLD.PRECIOMAXIMOPUBLICO) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "PRECIOMAXIMOPUBLICO":' || CAST(COALESCE(OLD.PRECIOMAXIMOPUBLICO,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "PRECIOMAXIMOPUBLICO":' || CAST(COALESCE(NEW.PRECIOMAXIMOPUBLICO,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.DESCUENTO <> OLD.DESCUENTO) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "DESCUENTO":' || CAST(COALESCE(OLD.DESCUENTO,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "DESCUENTO":' || CAST(COALESCE(NEW.DESCUENTO,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.PRECIOSUGERIDO <> OLD.PRECIOSUGERIDO) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "PRECIOSUGERIDO":' || CAST(COALESCE(OLD.PRECIOSUGERIDO,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "PRECIOSUGERIDO":' || CAST(COALESCE(NEW.PRECIOSUGERIDO,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.COSTOREPOSICION <> OLD.COSTOREPOSICION) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "COSTOREPOSICION":' || CAST(COALESCE(OLD.COSTOREPOSICION,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "COSTOREPOSICION":' || CAST(COALESCE(NEW.COSTOREPOSICION,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END


  IF(NEW.TASAIVAID <> OLD.TASAIVAID) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "TASAIVAID":' || CAST(COALESCE(OLD.TASAIVAID,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "TASAIVAID":' || CAST(COALESCE(NEW.TASAIVAID,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.TASAIEPS <> OLD.TASAIEPS) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "TASAIEPS":' || CAST(COALESCE(OLD.TASAIEPS,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "TASAIEPS":' || CAST(COALESCE(NEW.TASAIEPS,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.MONEDAID <> OLD.MONEDAID) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       --ANTES = :ANTES ||  ' "MONEDAID":' || CAST(COALESCE(OLD.MONEDAID,0) AS VARCHAR(20)) ;
       --DESPUES = :DESPUES ||  ' "MONEDAID":' || CAST(COALESCE(NEW.MONEDAID,0) AS VARCHAR(20)) ;

       SELECT CLAVE FROM MONEDA where ID = OLD.MONEDAID INTO :BUFFERTEXT;
       ANTES = :ANTES ||  ' "MONEDACLAVE":"' || REPLACE(COALESCE(:BUFFERTEXT,''),'"','\"') || '"' ;
           
       SELECT CLAVE FROM MONEDA where ID = NEW.MONEDAID INTO :BUFFERTEXT;
       DESPUES = :DESPUES ||  ' "MONEDACLAVE":"' || REPLACE(COALESCE(:BUFFERTEXT,''),'"','\"') || '"' ;

        CAMBIOALGO = 'S';
  END
  IF(NEW.COMISION <> OLD.COMISION) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "COMISION":' || CAST(COALESCE(OLD.COMISION,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "COMISION":' || CAST(COALESCE(NEW.COMISION,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.OFERTA <> OLD.OFERTA) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "OFERTA":' || CAST(COALESCE(OLD.OFERTA,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "OFERTA":' || CAST(COALESCE(NEW.OFERTA,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.CUENTAPREDIAL <> OLD.CUENTAPREDIAL) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "CUENTAPREDIAL":"' || REPLACE(COALESCE(OLD.CUENTAPREDIAL,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "CUENTAPREDIAL":"' || REPLACE(COALESCE(NEW.CUENTAPREDIAL,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.MINUTILIDAD <> OLD.MINUTILIDAD) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "MINUTILIDAD":' || CAST(COALESCE(OLD.MINUTILIDAD,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "MINUTILIDAD":' || CAST(COALESCE(NEW.MINUTILIDAD,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.PRECIOTOPE <> OLD.PRECIOTOPE) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "PRECIOTOPE":' || CAST(COALESCE(OLD.PRECIOTOPE,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "PRECIOTOPE":' || CAST(COALESCE(NEW.PRECIOTOPE,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.CAMBIARPRECIO <> OLD.CAMBIARPRECIO) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "CAMBIARPRECIO":"' || REPLACE(COALESCE(OLD.CAMBIARPRECIO,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "CAMBIARPRECIO":"' || REPLACE(COALESCE(NEW.CAMBIARPRECIO,''),'"','\"') || '"' ;
       --CAMBIOALGO = 'S';
  END



  ANTES = :ANTES || '}';
  DESPUES = :DESPUES || '}';


     IF(:CAMBIOALGO = 'S') THEN
     BEGIN
        INSERT INTO LOG(TABLAID, REGISTROID, FECHAHORA, USUARIOID, ANTES, DESPUES)
        VALUES(1, NEW.ID, CURRENT_TIMESTAMP,COALESCE( NEW.modificadopor_userid,17), :ANTES,:DESPUES)  ;
     END

end