CREATE OR ALTER trigger cliente_logmgmt_ins for persona
active after insert position 101
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

  if( new.TIPOPERSONAID <> 50 ) then
  begin
   exit;
  end

  ANTES = '{';
  DESPUES = '{';
  CAMBIOALGO = 'S';

       ANTES = :ANTES ||  ' "NOMBRE":' || '""' ;
       DESPUES = :DESPUES ||  ' "NOMBRE":"' || REPLACE(COALESCE(NEW.NOMBRE,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "ACTIVO":' || '""' ;
       DESPUES = :DESPUES ||  ' "ACTIVO":"' || REPLACE(COALESCE(NEW.ACTIVO,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "VIGENCIA":' || '""' ;
       DESPUES = :DESPUES ||  ' "VIGENCIA":"' || CAST(COALESCE(NEW.VIGENCIA,'') AS VARCHAR(20)) || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';


       ANTES = :ANTES ||  ' "NOMBRES":' || '""' ;
       DESPUES = :DESPUES ||  ' "NOMBRES":"' || REPLACE(COALESCE(NEW.NOMBRES,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "APELLIDOS":' || '""' ;
       DESPUES = :DESPUES ||  ' "APELLIDOS":"' || REPLACE(COALESCE(NEW.APELLIDOS,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "RAZONSOCIAL":' || '""' ;
       DESPUES = :DESPUES ||  ' "RAZONSOCIAL":"' || REPLACE(COALESCE(NEW.RAZONSOCIAL,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "DOMICILIO":' || '""' ;
       DESPUES = :DESPUES ||  ' "DOMICILIO":"' || REPLACE(COALESCE(NEW.DOMICILIO,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "NUMEROEXTERIOR":' || '""' ;
       DESPUES = :DESPUES ||  ' "NUMEROEXTERIOR":"' || REPLACE(COALESCE(NEW.NUMEROEXTERIOR,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "NUMEROINTERIOR":' || '""' ;
       DESPUES = :DESPUES ||  ' "NUMEROINTERIOR":"' || REPLACE(COALESCE(NEW.NUMEROINTERIOR,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "COLONIA":' || '""' ;
       DESPUES = :DESPUES ||  ' "COLONIA":"' || REPLACE(COALESCE(NEW.COLONIA,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "CIUDAD":' || '""' ;
       DESPUES = :DESPUES ||  ' "CIUDAD":"' || REPLACE(COALESCE(NEW.CIUDAD,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "ESTADO":' || '""' ;
       DESPUES = :DESPUES ||  ' "ESTADO":"' || REPLACE(COALESCE(NEW.ESTADO,''),'"','\"') || '"' ;

        ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "PAIS":' || '""' ;
       DESPUES = :DESPUES ||  ' "PAIS":"' || REPLACE(COALESCE(NEW.PAIS,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "CODIGOPOSTAL":' || '""' ;
       DESPUES = :DESPUES ||  ' "CODIGOPOSTAL":"' || REPLACE(COALESCE(NEW.CODIGOPOSTAL,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "RFC":' || '""' ;
       DESPUES = :DESPUES ||  ' "RFC":"' || REPLACE(COALESCE(NEW.RFC,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "EMAIL1":' || '""' ;
       DESPUES = :DESPUES ||  ' "EMAIL1":"' || REPLACE(COALESCE(NEW.EMAIL1,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "EMAIL2":' || '""' ;
       DESPUES = :DESPUES ||  ' "EMAIL2":"' || REPLACE(COALESCE(NEW.EMAIL2,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "TELEFONO1":' || '""' ;
       DESPUES = :DESPUES ||  ' "TELEFONO1":"' || REPLACE(COALESCE(NEW.TELEFONO1,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "TELEFONO2":' || '""' ;
       DESPUES = :DESPUES ||  ' "TELEFONO2":"' || REPLACE(COALESCE(NEW.TELEFONO2,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "CONTACTO1":' || '""' ;
       DESPUES = :DESPUES ||  ' "CONTACTO1":"' || REPLACE(COALESCE(NEW.CONTACTO1,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "CONTACTO2":' || '""' ;
       DESPUES = :DESPUES ||  ' "CONTACTO2":"' || REPLACE(COALESCE(NEW.CONTACTO2,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "MEMO":' || '""' ;
       DESPUES = :DESPUES ||  ' "MEMO":"' || REPLACE(COALESCE(NEW.MEMO,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "MONEDACLAVE":"' || '"' ;
       SELECT CLAVE FROM MONEDA where ID = NEW.MONEDAID INTO :BUFFERTEXT;
       DESPUES = :DESPUES ||  ' "MONEDACLAVE":"' || REPLACE(COALESCE(:BUFFERTEXT,''),'"','\"') || '"' ;

       --ANTES = :ANTES ||  ' "MONEDAID":' || '0' ;
       --DESPUES = :DESPUES ||  ' "MONEDAID":' || CAST(COALESCE(NEW.MONEDAID,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "VENDEDORCLAVE":"' || '"' ;
       SELECT CLAVE FROM PERSONA where ID = NEW.VENDEDORID INTO :BUFFERTEXT;
       DESPUES = :DESPUES ||  ' "VENDEDORCLAVE":"' || REPLACE(COALESCE(:BUFFERTEXT,''),'"','\"') || '"' ;

      -- ANTES = :ANTES ||  ' "VENDEDORID":' || '0' ;
      -- DESPUES = :DESPUES ||  ' "VENDEDORID":' || CAST(COALESCE(NEW.VENDEDORID,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "DESGLOSEIEPS":' || '""' ;
       DESPUES = :DESPUES ||  ' "DESGLOSEIEPS":"' || REPLACE(COALESCE(NEW.DESGLOSEIEPS,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "CUENTAIEPS":' || '""' ;
       DESPUES = :DESPUES ||  ' "CUENTAIEPS":"' || REPLACE(COALESCE(NEW.CUENTAIEPS,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "HAB_PAGOTARJETA":' || '""' ;
       DESPUES = :DESPUES ||  ' "HAB_PAGOTARJETA":"' || REPLACE(COALESCE(NEW.HAB_PAGOTARJETA,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "HAB_PAGOCREDITO":' || '""' ;
       DESPUES = :DESPUES ||  ' "HAB_PAGOCREDITO":"' || REPLACE(COALESCE(NEW.HAB_PAGOCREDITO,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "HAB_PAGOCHEQUE":' || '""' ;
       DESPUES = :DESPUES ||  ' "HAB_PAGOCHEQUE":"' || REPLACE(COALESCE(NEW.HAB_PAGOCHEQUE,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "HAB_PAGOTRANSFERENCIA":' || '""' ;
       DESPUES = :DESPUES ||  ' "HAB_PAGOTRANSFERENCIA":"' || REPLACE(COALESCE(NEW.HAB_PAGOTRANSFERENCIA,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "LIMITECREDITO":' || '0.0' ;
       DESPUES = :DESPUES ||  ' "LIMITECREDITO":' || CAST(COALESCE(NEW.LIMITECREDITO,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "DIAS":' || '0' ;
       DESPUES = :DESPUES ||  ' "DIAS":' || CAST(COALESCE(NEW.DIAS,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "REVISION":' || '""' ;
       DESPUES = :DESPUES ||  ' "REVISION":"' || REPLACE(COALESCE(NEW.REVISION,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "PAGOS":' || '""' ;
       DESPUES = :DESPUES ||  ' "PAGOS":"' || REPLACE(COALESCE(NEW.PAGOS,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "LISTAPRECIOID":' || '0' ;
       DESPUES = :DESPUES ||  ' "LISTAPRECIOID":' || CAST(COALESCE(NEW.LISTAPRECIOID,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "SUPERLISTAPRECIOID":' || '0' ;
       DESPUES = :DESPUES ||  ' "SUPERLISTAPRECIOID":' || CAST(COALESCE(NEW.SUPERLISTAPRECIOID,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "BLOQUEADO":' || '""' ;
       DESPUES = :DESPUES ||  ' "BLOQUEADO":"' || REPLACE(COALESCE(NEW.BLOQUEADO,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "CREDITOFORMAPAGOABONOS":' || '0' ;
       DESPUES = :DESPUES ||  ' "CREDITOFORMAPAGOABONOS":' || CAST(COALESCE(NEW.CREDITOFORMAPAGOABONOS,0) AS VARCHAR(20)) ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "CREDITOREFERENCIAABONOS":' || '""' ;
       DESPUES = :DESPUES ||  ' "CREDITOREFERENCIAABONOS":"' || REPLACE(COALESCE(NEW.CREDITOREFERENCIAABONOS,''),'"','\"') || '"' ;

       ANTES = :ANTES || ',';
       DESPUES = :DESPUES || ',';

       ANTES = :ANTES ||  ' "PAGOPARCIALIDADES":' || '""' ;
       DESPUES = :DESPUES ||  ' "PAGOPARCIALIDADES":"' || REPLACE(COALESCE(NEW.PAGOPARCIALIDADES,''),'"','\"') || '"' ;




    ANTES = :ANTES || '}';
  DESPUES = :DESPUES || '}';


     IF(:CAMBIOALGO = 'S') THEN
     BEGIN
        INSERT INTO LOG(TABLAID, REGISTROID, FECHAHORA, USUARIOID, ANTES, DESPUES)
        VALUES(2, NEW.ID, CURRENT_TIMESTAMP,COALESCE( NEW.modificadopor_userid,17), :ANTES,:DESPUES)  ;
     END

end