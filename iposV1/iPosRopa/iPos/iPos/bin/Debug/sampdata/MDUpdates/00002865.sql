CREATE OR ALTER TRIGGER CLIENTE_LOGMGMT FOR PERSONA
ACTIVE AFTER UPDATE POSITION 101
AS
 declare variable ANTES BLOB;  
 declare variable DESPUES BLOB;
 declare variable CAMBIOALGO D_BOOLCN;  
 declare variable HABILITARLOG D_BOOLCN;

 begin
  /* Trigger text */
  
  SELECT FIRST 1 HABILITARLOG FROM PARAMETRO INTO :HABILITARLOG;
  IF(COALESCE(:HABILITARLOG, 'N') = 'N') THEN
  BEGIN
     EXIT;
  END

  if( new.TIPOPERSONAID <> 50 ) then
  begin
   exit;
  end

  ANTES = '{';
  DESPUES = '{';
  CAMBIOALGO = 'N';

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
  IF(NEW.ACTIVO <> OLD.ACTIVO) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "ACTIVO":"' || REPLACE(COALESCE(OLD.ACTIVO,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "ACTIVO":"' || REPLACE(COALESCE(NEW.ACTIVO,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.VIGENCIA <> OLD.VIGENCIA) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "VIGENCIA":"' || CAST(COALESCE(OLD.VIGENCIA,'01.01.2000') AS VARCHAR(20)) || '"' ;
       DESPUES = :DESPUES ||  ' "VIGENCIA":"' || CAST(COALESCE(NEW.VIGENCIA,'01.01.2000') AS VARCHAR(20)) || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.NOMBRES <> OLD.NOMBRES) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "NOMBRES":"' || REPLACE(COALESCE(OLD.NOMBRES,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "NOMBRES":"' || REPLACE(COALESCE(NEW.NOMBRES,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.APELLIDOS <> OLD.APELLIDOS) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "APELLIDOS":"' || REPLACE(COALESCE(OLD.APELLIDOS,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "APELLIDOS":"' || REPLACE(COALESCE(NEW.APELLIDOS,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.RAZONSOCIAL <> OLD.RAZONSOCIAL) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "RAZONSOCIAL":"' || REPLACE(COALESCE(OLD.RAZONSOCIAL,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "RAZONSOCIAL":"' || REPLACE(COALESCE(NEW.RAZONSOCIAL,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.DOMICILIO <> OLD.DOMICILIO) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "DOMICILIO":"' || REPLACE(COALESCE(OLD.DOMICILIO,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "DOMICILIO":"' || REPLACE(COALESCE(NEW.DOMICILIO,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.NUMEROEXTERIOR <> OLD.NUMEROEXTERIOR) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "NUMEROEXTERIOR":"' || REPLACE(COALESCE(OLD.NUMEROEXTERIOR,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "NUMEROEXTERIOR":"' || REPLACE(COALESCE(NEW.NUMEROEXTERIOR,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.NUMEROINTERIOR <> OLD.NUMEROINTERIOR) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "NUMEROINTERIOR":"' || REPLACE(COALESCE(OLD.NUMEROINTERIOR,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "NUMEROINTERIOR":"' || REPLACE(COALESCE(NEW.NUMEROINTERIOR,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.COLONIA <> OLD.COLONIA) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "COLONIA":"' || REPLACE(COALESCE(OLD.COLONIA,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "COLONIA":"' || REPLACE(COALESCE(NEW.COLONIA,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.CIUDAD <> OLD.CIUDAD) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "CIUDAD":"' || REPLACE(COALESCE(OLD.CIUDAD,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "CIUDAD":"' || REPLACE(COALESCE(NEW.CIUDAD,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.ESTADO <> OLD.ESTADO) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "ESTADO":"' || REPLACE(COALESCE(OLD.ESTADO,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "ESTADO":"' || REPLACE(COALESCE(NEW.ESTADO,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.PAIS <> OLD.PAIS) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "PAIS":"' || REPLACE(COALESCE(OLD.PAIS,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "PAIS":"' || REPLACE(COALESCE(NEW.PAIS,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.CODIGOPOSTAL <> OLD.CODIGOPOSTAL) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "CODIGOPOSTAL":"' || REPLACE(COALESCE(OLD.CODIGOPOSTAL,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "CODIGOPOSTAL":"' || REPLACE(COALESCE(NEW.CODIGOPOSTAL,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.RFC <> OLD.RFC) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "RFC":"' || REPLACE(COALESCE(OLD.RFC,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "RFC":"' || REPLACE(COALESCE(NEW.RFC,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.EMAIL1 <> OLD.EMAIL1) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "EMAIL1":"' || REPLACE(COALESCE(OLD.EMAIL1,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "EMAIL1":"' || REPLACE(COALESCE(NEW.EMAIL1,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.EMAIL2 <> OLD.EMAIL2) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "EMAIL2":"' || REPLACE(COALESCE(OLD.EMAIL2,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "EMAIL2":"' || REPLACE(COALESCE(NEW.EMAIL2,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.TELEFONO1 <> OLD.TELEFONO1) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "TELEFONO1":"' || REPLACE(COALESCE(OLD.TELEFONO1,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "TELEFONO1":"' || REPLACE(COALESCE(NEW.TELEFONO1,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.TELEFONO2 <> OLD.TELEFONO2) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "TELEFONO2":"' || REPLACE(COALESCE(OLD.TELEFONO2,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "TELEFONO2":"' || REPLACE(COALESCE(NEW.TELEFONO2,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.CONTACTO1 <> OLD.CONTACTO1) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "CONTACTO1":"' || REPLACE(COALESCE(OLD.CONTACTO1,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "CONTACTO1":"' || REPLACE(COALESCE(NEW.CONTACTO1,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.CONTACTO2 <> OLD.CONTACTO2) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "CONTACTO2":"' || REPLACE(COALESCE(OLD.CONTACTO2,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "CONTACTO2":"' || REPLACE(COALESCE(NEW.CONTACTO2,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.MEMO <> OLD.MEMO) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "MEMO":"' || REPLACE(COALESCE(OLD.MEMO,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "MEMO":"' || REPLACE(COALESCE(NEW.MEMO,''),'"','\"') || '"' ;
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

       ANTES = :ANTES ||  ' "MONEDAID":' || CAST(COALESCE(OLD.MONEDAID,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "MONEDAID":' || CAST(COALESCE(NEW.MONEDAID,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.VENDEDORID <> OLD.VENDEDORID) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "VENDEDORID":' || CAST(COALESCE(OLD.VENDEDORID,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "VENDEDORID":' || CAST(COALESCE(NEW.VENDEDORID,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.DESGLOSEIEPS <> OLD.DESGLOSEIEPS) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "DESGLOSEIEPS":"' || REPLACE(COALESCE(OLD.DESGLOSEIEPS,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "DESGLOSEIEPS":"' || REPLACE(COALESCE(NEW.DESGLOSEIEPS,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.CUENTAIEPS <> OLD.CUENTAIEPS) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "CUENTAIEPS":"' || REPLACE(COALESCE(OLD.CUENTAIEPS,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "CUENTAIEPS":"' || REPLACE(COALESCE(NEW.CUENTAIEPS,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END




     IF(NEW.HAB_PAGOTARJETA <> OLD.HAB_PAGOTARJETA) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "HAB_PAGOTARJETA":"' || REPLACE(COALESCE(OLD.HAB_PAGOTARJETA,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "HAB_PAGOTARJETA":"' || REPLACE(COALESCE(NEW.HAB_PAGOTARJETA,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.HAB_PAGOCREDITO <> OLD.HAB_PAGOCREDITO) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "HAB_PAGOCREDITO":"' || REPLACE(COALESCE(OLD.HAB_PAGOCREDITO,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "HAB_PAGOCREDITO":"' || REPLACE(COALESCE(NEW.HAB_PAGOCREDITO,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.HAB_PAGOCHEQUE <> OLD.HAB_PAGOCHEQUE) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "HAB_PAGOCHEQUE":"' || REPLACE(COALESCE(OLD.HAB_PAGOCHEQUE,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "HAB_PAGOCHEQUE":"' || REPLACE(COALESCE(NEW.HAB_PAGOCHEQUE,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.HAB_PAGOTRANSFERENCIA <> OLD.HAB_PAGOTRANSFERENCIA) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "HAB_PAGOTRANSFERENCIA":"' || REPLACE(COALESCE(OLD.HAB_PAGOTRANSFERENCIA,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "HAB_PAGOTRANSFERENCIA":"' || REPLACE(COALESCE(NEW.HAB_PAGOTRANSFERENCIA,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.LIMITECREDITO <> OLD.LIMITECREDITO) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "LIMITECREDITO":' || CAST(COALESCE(OLD.LIMITECREDITO,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "LIMITECREDITO":' || CAST(COALESCE(NEW.LIMITECREDITO,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.DIAS <> OLD.DIAS) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "DIAS":' || CAST(COALESCE(OLD.DIAS,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "DIAS":' || CAST(COALESCE(NEW.DIAS,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.REVISION <> OLD.REVISION) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "REVISION":"' || REPLACE(COALESCE(OLD.REVISION,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "REVISION":"' || REPLACE(COALESCE(NEW.REVISION,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.PAGOS <> OLD.PAGOS) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "PAGOS":"' || REPLACE(COALESCE(OLD.PAGOS,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "PAGOS":"' || REPLACE(COALESCE(NEW.PAGOS,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.LISTAPRECIOID <> OLD.LISTAPRECIOID) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "LISTAPRECIOID":' || CAST(COALESCE(OLD.LISTAPRECIOID,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "LISTAPRECIOID":' || CAST(COALESCE(NEW.LISTAPRECIOID,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.SUPERLISTAPRECIOID <> OLD.SUPERLISTAPRECIOID) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "SUPERLISTAPRECIOID":' || CAST(COALESCE(OLD.SUPERLISTAPRECIOID,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "SUPERLISTAPRECIOID":' || CAST(COALESCE(NEW.SUPERLISTAPRECIOID,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.BLOQUEADO <> OLD.BLOQUEADO) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "BLOQUEADO":"' || REPLACE(COALESCE(OLD.BLOQUEADO,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "BLOQUEADO":"' || REPLACE(COALESCE(NEW.BLOQUEADO,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END


      IF(NEW.CREDITOFORMAPAGOABONOS <> OLD.CREDITOFORMAPAGOABONOS) THEN
  BEGIN

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "CREDITOFORMAPAGOABONOS":' || CAST(COALESCE(OLD.CREDITOFORMAPAGOABONOS,0) AS VARCHAR(20)) ;
       DESPUES = :DESPUES ||  ' "CREDITOFORMAPAGOABONOS":' || CAST(COALESCE(NEW.CREDITOFORMAPAGOABONOS,0) AS VARCHAR(20)) ;
        CAMBIOALGO = 'S';
  END
  IF(NEW.CREDITOREFERENCIAABONOS <> OLD.CREDITOREFERENCIAABONOS) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "CREDITOREFERENCIAABONOS":"' || REPLACE(COALESCE(OLD.CREDITOREFERENCIAABONOS,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "CREDITOREFERENCIAABONOS":"' || REPLACE(COALESCE(NEW.CREDITOREFERENCIAABONOS,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END
  IF(NEW.PAGOPARCIALIDADES <> OLD.PAGOPARCIALIDADES) THEN
  BEGIN
  

        IF(:ANTES <> '{') THEN
        BEGIN
         ANTES = :ANTES || ',';
        END
        
        IF(:DESPUES <> '{') THEN
        BEGIN
         DESPUES = :DESPUES || ',';
        END

       ANTES = :ANTES ||  ' "PAGOPARCIALIDADES":"' || REPLACE(COALESCE(OLD.PAGOPARCIALIDADES,''),'"','\"') || '"' ;
       DESPUES = :DESPUES ||  ' "PAGOPARCIALIDADES":"' || REPLACE(COALESCE(NEW.PAGOPARCIALIDADES,''),'"','\"') || '"' ;
       CAMBIOALGO = 'S';
  END




    ANTES = :ANTES || '}';
  DESPUES = :DESPUES || '}';


     IF(:CAMBIOALGO = 'S') THEN
     BEGIN
        INSERT INTO LOG(TABLAID, REGISTROID, FECHAHORA, USUARIOID, ANTES, DESPUES)
        VALUES(2, NEW.ID, CURRENT_TIMESTAMP,COALESCE( NEW.modificadopor_userid,17), :ANTES,:DESPUES)  ;
     END

end
