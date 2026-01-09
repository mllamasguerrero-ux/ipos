CREATE OR ALTER trigger producto_logmgmt_ins for producto
active after insert position 100
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
  CAMBIOALGO = 'S';




       ANTES = :ANTES ||  ' "PRECIO1":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "PRECIO1":' || CAST(COALESCE(NEW.PRECIO1,00) AS VARCHAR(20)) ;


       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "PRECIO2":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "PRECIO2":' || CAST(COALESCE(NEW.PRECIO2,0) AS VARCHAR(20)) ;


       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "EAN":' ||  '""' ;
       DESPUES = :DESPUES ||  ' "EAN":"' || REPLACE(COALESCE(NEW.EAN,''),'"','\"') || '"' ;
 
       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "FECHACAMBIOPRECIO":' || '""' ;
       DESPUES = :DESPUES ||  ' "FECHACAMBIOPRECIO":"' || CAST(COALESCE(NEW.FECHACAMBIOPRECIO,'') AS VARCHAR(20)) || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "CBARRAS":' || '""' ;
       DESPUES = :DESPUES ||  ' "CBARRAS":"' || REPLACE(COALESCE(NEW.CBARRAS,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "NOMBRE":' || '""' ;
       DESPUES = :DESPUES ||  ' "NOMBRE":"' || REPLACE(COALESCE(NEW.NOMBRE,''),'"','\"') || '"' ;
                          
       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "DESCRIPCION1":' || '""' ;
       DESPUES = :DESPUES ||  ' "DESCRIPCION1":"' || REPLACE(COALESCE(NEW.DESCRIPCION1,''),'"','\"') || '"' ;
                          
       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "DESCRIPCION2":' || '""' ;
       DESPUES = :DESPUES ||  ' "DESCRIPCION2":"' || REPLACE(COALESCE(NEW.DESCRIPCION2,''),'"','\"') || '"' ;
                          
       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "DESCRIPCION3":' || '""' ;
       DESPUES = :DESPUES ||  ' "DESCRIPCION3":"' || REPLACE(COALESCE(NEW.DESCRIPCION3,''),'"','\"') || '"' ;

                        
       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "PROVEEDOR1CLAVE":"' || '"' ;
       SELECT CLAVE FROM PERSONA where ID = NEW.PROVEEDOR1ID INTO :BUFFERTEXT;
       DESPUES = :DESPUES ||  ' "PROVEEDOR1CLAVE":"' || REPLACE(COALESCE(:BUFFERTEXT,''),'"','\"') || '"' ;

       --ANTES = :ANTES ||  ' "PROVEEDOR1ID":' || '0' ;
       --DESPUES = :DESPUES ||  ' "PROVEEDOR1ID":' || CAST(COALESCE(NEW.PROVEEDOR1ID,0) AS VARCHAR(20)) ;
        
       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "PROVEEDOR2CLAVE":"' || '"' ;
       SELECT CLAVE FROM PERSONA where ID = NEW.PROVEEDOR2ID INTO :BUFFERTEXT;
       DESPUES = :DESPUES ||  ' "PROVEEDOR2CLAVE":"' || REPLACE(COALESCE(:BUFFERTEXT,''),'"','\"') || '"' ;

       --ANTES = :ANTES ||  ' "PROVEEDOR2ID":' || '0' ;
       --DESPUES = :DESPUES ||  ' "PROVEEDOR2ID":' || CAST(COALESCE(NEW.PROVEEDOR2ID,0) AS VARCHAR(20)) ;

       
       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "LINEACLAVE":"' || '"' ;
       SELECT CLAVE FROM LINEA where ID = NEW.LINEAID INTO :BUFFERTEXT;
       DESPUES = :DESPUES ||  ' "LINEACLAVE":"' || REPLACE(COALESCE(:BUFFERTEXT,''),'"','\"') || '"' ;

       --ANTES = :ANTES ||  ' "LINEAID":' || '0' ;
       --DESPUES = :DESPUES ||  ' "LINEAID":' || CAST(COALESCE(NEW.LINEAID,0) AS VARCHAR(20)) ;

       
       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "MARCACLAVE":"' || '"' ;
       SELECT CLAVE FROM MARCA where ID = NEW.MARCAID INTO :BUFFERTEXT;
       DESPUES = :DESPUES ||  ' "MARCACLAVE":"' || REPLACE(COALESCE(:BUFFERTEXT,''),'"','\"') || '"' ;

       --ANTES = :ANTES ||  ' "MARCAID":' || '0' ;
       --DESPUES = :DESPUES ||  ' "MARCAID":' || CAST(COALESCE(NEW.MARCAID,0) AS VARCHAR(20)) ;

       
       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "MARCAID":' || '0' ;
       DESPUES = :DESPUES ||  ' "MARCAID":' || CAST(COALESCE(NEW.MARCAID,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "PRODUCTOSUSTITUTOCLAVE":"' || '"' ;
       SELECT CLAVE FROM PRODUCTO where ID = NEW.MARCAID INTO :BUFFERTEXT;
       DESPUES = :DESPUES ||  ' "PRODUCTOSUSTITUTOCLAVE":"' || REPLACE(COALESCE(:BUFFERTEXT,''),'"','\"') || '"' ;

       --ANTES = :ANTES ||  ' "PRODUCTOSUSTITUTOID":' || '0' ;
       --DESPUES = :DESPUES ||  ' "PRODUCTOSUSTITUTOID":' || CAST(coalesce(NEW.PRODUCTOSUSTITUTOID,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "MANEJALOTE":' || '""' ;
       DESPUES = :DESPUES ||  ' "MANEJALOTE":"' || REPLACE(COALESCE(NEW.MANEJALOTE,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "ESKIT":' || '""' ;
       DESPUES = :DESPUES ||  ' "ESKIT":"' || REPLACE(COALESCE(NEW.ESKIT,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "UNIDAD":' || '""' ;
       DESPUES = :DESPUES ||  ' "UNIDAD":"' || REPLACE(COALESCE(NEW.UNIDAD,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "IMPRIMIR":' || '""' ;
       DESPUES = :DESPUES ||  ' "IMPRIMIR":"' || REPLACE(COALESCE(NEW.IMPRIMIR,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "INVENTARIABLE":' || '""' ;
       DESPUES = :DESPUES ||  ' "INVENTARIABLE":"' || REPLACE(COALESCE(NEW.INVENTARIABLE,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "U_EMPAQUE":' || '0.0';
       DESPUES = :DESPUES ||  ' "U_EMPAQUE":' || CAST(COALESCE(NEW.U_EMPAQUE,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "STOCK":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "STOCK":' || CAST(COALESCE(NEW.STOCK,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "SURTIRPORCAJA":' || '""' ;
       DESPUES = :DESPUES ||  ' "SURTIRPORCAJA":"' || REPLACE(COALESCE(NEW.SURTIRPORCAJA,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "STOCKMAX":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "STOCKMAX":' || CAST(COALESCE(NEW.STOCKMAX,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "MAYOKGS":' || '""' ;
       DESPUES = :DESPUES ||  ' "MAYOKGS":"' || REPLACE(COALESCE(NEW.MAYOKGS,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "INI_MAYO":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "INI_MAYO":' || CAST(COALESCE(NEW.INI_MAYO,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "PZACAJA":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "PZACAJA":' || CAST(COALESCE(NEW.PZACAJA,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "NEGATIVOS":' || '""' ;
       DESPUES = :DESPUES ||  ' "NEGATIVOS":"' || REPLACE(COALESCE(NEW.NEGATIVOS,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "MANEJASTOCK":' || '""' ;
       DESPUES = :DESPUES ||  ' "MANEJASTOCK":"' || REPLACE(COALESCE(NEW.MANEJASTOCK,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "PRECIO3":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "PRECIO3":' || CAST(COALESCE(NEW.PRECIO3,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "PRECIO4":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "PRECIO4":' || CAST(COALESCE(NEW.PRECIO4,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "PRECIO5":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "PRECIO5":' || CAST(COALESCE(NEW.PRECIO5,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "SPRECIO1":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "SPRECIO1":' || CAST(COALESCE(NEW.SPRECIO1,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "SPRECIO2":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "SPRECIO2":' || CAST(COALESCE(NEW.SPRECIO2,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "SPRECIO3":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "SPRECIO3":' || CAST(COALESCE(NEW.SPRECIO3,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "SPRECIO4":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "SPRECIO4":' || CAST(COALESCE(NEW.SPRECIO4,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "SPRECIO5":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "SPRECIO5":' || CAST(coalesce(NEW.SPRECIO5,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "DESCRIPCION":' || '""' ;
       DESPUES = :DESPUES ||  ' "DESCRIPCION":"' || REPLACE(COALESCE(NEW.DESCRIPCION,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "DESCRIPCION2":' || '""' ;
       DESPUES = :DESPUES ||  ' "DESCRIPCION2":"' || REPLACE(COALESCE(NEW.DESCRIPCION2,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';



       ANTES = :ANTES ||  ' "LIMITEPRECIO2":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "LIMITEPRECIO2":' || CAST(COALESCE(NEW.LIMITEPRECIO2,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "PRECIOMAXIMOPUBLICO":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "PRECIOMAXIMOPUBLICO":' || CAST(COALESCE(NEW.PRECIOMAXIMOPUBLICO,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "DESCUENTO":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "DESCUENTO":' || CAST(COALESCE(NEW.DESCUENTO,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "PRECIOSUGERIDO":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "PRECIOSUGERIDO":' || CAST(COALESCE(NEW.PRECIOSUGERIDO,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "COSTOREPOSICION":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "COSTOREPOSICION":' || CAST(COALESCE(NEW.COSTOREPOSICION,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "TASAIVAID":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "TASAIVAID":' || CAST(COALESCE(NEW.TASAIVAID,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "TASAIEPS":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "TASAIEPS":' || CAST(COALESCE(NEW.TASAIEPS,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "MONEDACLAVE":"' || '"' ;
       SELECT CLAVE FROM MONEDA where ID = NEW.MONEDAID INTO :BUFFERTEXT;
       DESPUES = :DESPUES ||  ' "MONEDACLAVE":"' || REPLACE(COALESCE(:BUFFERTEXT,''),'"','\"') || '"' ;

       --ANTES = :ANTES ||  ' "MONEDAID":' || '0' ;
       --DESPUES = :DESPUES ||  ' "MONEDAID":' || CAST(COALESCE(NEW.MONEDAID,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "COMISION":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "COMISION":' || CAST(COALESCE(NEW.COMISION,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "OFERTA":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "OFERTA":' || CAST(COALESCE(NEW.OFERTA,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "CUENTAPREDIAL":' || '""' ;
       DESPUES = :DESPUES ||  ' "CUENTAPREDIAL":"' || REPLACE(COALESCE(NEW.CUENTAPREDIAL,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "MINUTILIDAD":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "MINUTILIDAD":' || CAST(COALESCE(NEW.MINUTILIDAD,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "PRECIOTOPE":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "PRECIOTOPE":' || CAST(COALESCE(NEW.PRECIOTOPE,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';
  


       ANTES = :ANTES ||  ' "CAMBIARPRECIO":' || '""' ;
       DESPUES = :DESPUES ||  ' "CAMBIARPRECIO":"' || REPLACE(COALESCE(NEW.CAMBIARPRECIO,''),'"','\"') || '"' ;






  ANTES = :ANTES || '}';
  DESPUES = :DESPUES || '}';


     IF(:CAMBIOALGO = 'S') THEN
     BEGIN
        INSERT INTO LOG(TABLAID, REGISTROID, FECHAHORA, USUARIOID, ANTES, DESPUES)
        VALUES(1, NEW.ID, CURRENT_TIMESTAMP,COALESCE( NEW.modificadopor_userid,17), :ANTES,:DESPUES)  ;
     END

end