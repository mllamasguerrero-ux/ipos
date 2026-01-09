CREATE OR ALTER TRIGGER DOCTO_REPL_AU FOR DOCTO
ACTIVE AFTER UPDATE POSITION 0
AS
declare variable HABILITARREPL D_BOOLCN;
declare variable REPLID D_FK;
begin
  /* Trigger text */

  IF( COALESCE(NEW.tipodoctoid,0) IN (21, 22, 23, 24, 25) AND coalesce(new.personaid,1) <> 1 AND
     ((COALESCE(NEW.estatusdoctoid,0) <> COALESCE(OLD.estatusdoctoid,0)) or (COALESCE(NEW.saldo, 0) > COALESCE(OLD.SALDO,0) ))
     ) THEN
   BEGIN

     SELECT FIRST 1 habilitarrepl FROM PARAMETRO INTO :HABILITARREPL;

     IF(COALESCE(:HABILITARREPL,'N') = 'S') THEN
     BEGIN
        
        SELECT REPLID FROM REPLDOCTO WHERE ID = NEW.ID INTO :REPLID;

        IF(COALESCE(:REPLID,0) = 0) THEN
        BEGIN

          
         INSERT INTO REPLDOCTO
         (
              
          ID,
          
          ACTIVO,
          
          CREADO,
          
          CREADOPOR_USERID,
          
          MODIFICADO,
          
          MODIFICADOPOR_USERID,
          
          ALMACENID,
          
          SUCURSALID,
          
          TIPODOCTOID,
          
          ESTATUSDOCTOID,
          
          ESTATUSDOCTOPAGOID,
          
          PERSONAID,
          
          CAJEROID,
          
          VENDEDORID,
          
          CORTEID,
          
          FECHA,
          
          FECHAHORA,
          
          SERIE,
          
          FOLIO,
          
          PLAZO,
          
          VENCE,
          
          REFERENCIA,
          
          REFERENCIAS,
          
          DESCRIPCION,
          
          OBSERVACION,
          
          OBSERVACIONES,
          
          IMPORTE,
          
          DESCUENTO,
          
          SUBTOTAL,
          
          IVA,
          
          TOTAL,
          
          CARGO,
          
          ABONO,
          
          SALDO,
          
          CAJAID,
          
          TURNOID,
          
          ESTATUSDOCTOPEDIDOID,
          
          ENVIADOFTP,
          
          DOCTOREFID,
          
          HORA,
          
          FECHACORTE,
          
          SUCURSALTID,
          
          ALMACENTID,
          
          PROMOCION,
          
          TRASLADOAFTP,
          
          TRANREGSERVER,
          
          ORIGENFISCALID,
          
          FOLIOORIGENFACTURADO,
          
          MONTOORIGENFACTURADO,
          
          VENDEDORFINAL,
          
          SERIEORIGENFACTURADO,
          
          APLICADOREF,
          
          MERCANCIAENTREGADA,
          
          PERSONAAPARTADOID,
          
          TIMBRADOUUID,
          
          TIMBRADOFECHA,
          
          TIMBRADOCERTSAT,
          
          TIMBRADOSELLOSAT,
          
          TIMBRADOSELLOCFDI,
          
          FOLIOSAT,
          
          SERIESAT,
          
          DOCTOPAGOSAT,
          
          ESAPARTADO,
          
          ESFACTURAELECTRONICA,
          
          SUBTIPODOCTOID,
          
          FECHAINI,
          
          FECHAFIN,
          
          MONEDERO,
          
          DESCMONEDERO,
          
          ABONOMONEDERO,
          
          SUPERVISORID,
          
          SUBTOTALCONIVA,
          
          SUBTOTALSINIVA,
          
          USARDATOSENTREGA,
          
          ISRRETENIDO,
          
          IVARETENIDO,
          
          MONEDAID,
          
          TIPOCAMBIO,
          
          IEPS,
          
          IMPUESTO,
          
          ESTATUSANTICIPOID,
          
          TOTALANTICIPO,
          
          FECHAFACTURA,
          
          NOTAPAGO,
          
          MANEJORECETA,
          
          UTILIDAD,
          
          VENDEDORUTILIDADID,
          
          MOVILPLAZOS,
          
          MOVILCONTADO,
          
          TIMBRADOCANCELADO,
          
          TIMBRADOFECHACANCELACION,
          
          TIMBRADOUUIDCANCELACION,
          
          TIMBRADOFECHAFACTURA,
          
          DOCTOKITREFID,
          
          PREKITESTATUS,
          
          POSTKITESTATUS,
          
          TOTALCONREBAJA
                   )
           values(   NEW.ID,
                    NEW.ACTIVO,
                    NEW.CREADO,
                    NEW.CREADOPOR_USERID,
                    NEW.MODIFICADO,
                    NEW.MODIFICADOPOR_USERID,
                    NEW.ALMACENID,
                    NEW.SUCURSALID,
                    NEW.TIPODOCTOID,
                    NEW.ESTATUSDOCTOID,
                    NEW.ESTATUSDOCTOPAGOID,
                    NEW.PERSONAID,
                    NEW.CAJEROID,
                    NEW.VENDEDORID,
                    NEW.CORTEID,
                    NEW.FECHA,
                    NEW.FECHAHORA,
                    NEW.SERIE,
                    NEW.FOLIO,
                    NEW.PLAZO,
                    NEW.VENCE,
                    NEW.REFERENCIA,
                    NEW.REFERENCIAS,
                    NEW.DESCRIPCION,
                    NEW.OBSERVACION,
                    NEW.OBSERVACIONES,
                    NEW.IMPORTE,
                    NEW.DESCUENTO,
                    NEW.SUBTOTAL,
                    NEW.IVA,
                    NEW.TOTAL,
                    NEW.CARGO,
                    NEW.ABONO,
                    NEW.SALDO,
                    NEW.CAJAID,
                    NEW.TURNOID,
                    NEW.ESTATUSDOCTOPEDIDOID,
                    NEW.ENVIADOFTP,
                    NEW.DOCTOREFID,
                    NEW.HORA,
                    NEW.FECHACORTE,
                    NEW.SUCURSALTID,
                    NEW.ALMACENTID,
                    NEW.PROMOCION,
                    NEW.TRASLADOAFTP,
                    NEW.TRANREGSERVER,
                    NEW.ORIGENFISCALID,
                    NEW.FOLIOORIGENFACTURADO,
                    NEW.MONTOORIGENFACTURADO,
                    NEW.VENDEDORFINAL,
                    NEW.SERIEORIGENFACTURADO,
                    NEW.APLICADOREF,
                    NEW.MERCANCIAENTREGADA,
                    NEW.PERSONAAPARTADOID,
                    NEW.TIMBRADOUUID,
                    NEW.TIMBRADOFECHA,
                    NEW.TIMBRADOCERTSAT,
                    NEW.TIMBRADOSELLOSAT,
                    NEW.TIMBRADOSELLOCFDI,
                    NEW.FOLIOSAT,
                    NEW.SERIESAT,
                    NEW.DOCTOPAGOSAT,
                    NEW.ESAPARTADO,
                    NEW.ESFACTURAELECTRONICA,
                    NEW.SUBTIPODOCTOID,
                    NEW.FECHAINI,
                    NEW.FECHAFIN,
                    NEW.MONEDERO,
                    NEW.DESCMONEDERO,
                    NEW.ABONOMONEDERO,
                    NEW.SUPERVISORID,
                    NEW.SUBTOTALCONIVA,
                    NEW.SUBTOTALSINIVA,
                    NEW.USARDATOSENTREGA,
                    NEW.ISRRETENIDO,
                    NEW.IVARETENIDO,
                    NEW.MONEDAID,
                    NEW.TIPOCAMBIO,
                    NEW.IEPS,
                    NEW.IMPUESTO,
                    NEW.ESTATUSANTICIPOID,
                    NEW.TOTALANTICIPO,
                    NEW.FECHAFACTURA,
                    NEW.NOTAPAGO,
                    NEW.MANEJORECETA,
                    NEW.UTILIDAD,
                    NEW.VENDEDORUTILIDADID,
                    NEW.MOVILPLAZOS,
                    NEW.MOVILCONTADO,
                    NEW.TIMBRADOCANCELADO,
                    NEW.TIMBRADOFECHACANCELACION,
                    NEW.TIMBRADOUUIDCANCELACION,
                    NEW.TIMBRADOFECHAFACTURA,
                    NEW.DOCTOKITREFID,
                    NEW.PREKITESTATUS,
                    NEW.POSTKITESTATUS,
                    NEW.TOTALCONREBAJA
              );
          END
          ELSE
          BEGIN

               update  REPLDOCTO
  set

ID=NEW.ID,

ACTIVO=NEW.ACTIVO,

CREADOPOR_USERID=NEW.CREADOPOR_USERID,

MODIFICADO = NEW.MODIFICADO,

MODIFICADOPOR_USERID=NEW.MODIFICADOPOR_USERID,

ALMACENID=NEW.ALMACENID,

SUCURSALID=NEW.SUCURSALID,

TIPODOCTOID=NEW.TIPODOCTOID,

ESTATUSDOCTOID=NEW.ESTATUSDOCTOID,

ESTATUSDOCTOPAGOID=NEW.ESTATUSDOCTOPAGOID,

PERSONAID=NEW.PERSONAID,

CAJEROID=NEW.CAJEROID,

VENDEDORID=NEW.VENDEDORID,

CORTEID=NEW.CORTEID,

FECHA=NEW.FECHA,

FECHAHORA = NEW.FECHAHORA,

SERIE=NEW.SERIE,

FOLIO=NEW.FOLIO,

PLAZO=NEW.PLAZO,

VENCE=NEW.VENCE,

REFERENCIA=NEW.REFERENCIA,

REFERENCIAS=NEW.REFERENCIAS,

DESCRIPCION=NEW.DESCRIPCION,

OBSERVACION=NEW.OBSERVACION,

OBSERVACIONES=NEW.OBSERVACIONES,

IMPORTE=NEW.IMPORTE,

DESCUENTO=NEW.DESCUENTO,

SUBTOTAL=NEW.SUBTOTAL,

IVA=NEW.IVA,

TOTAL=NEW.TOTAL,

CARGO=NEW.CARGO,

ABONO=NEW.ABONO,

SALDO=NEW.SALDO,

CAJAID=NEW.CAJAID,

TURNOID=NEW.TURNOID,

ESTATUSDOCTOPEDIDOID=NEW.ESTATUSDOCTOPEDIDOID,

ENVIADOFTP=NEW.ENVIADOFTP,

DOCTOREFID=NEW.DOCTOREFID,

HORA=NEW.HORA,

FECHACORTE=NEW.FECHACORTE,

SUCURSALTID=NEW.SUCURSALTID,

ALMACENTID=NEW.ALMACENTID,

PROMOCION=NEW.PROMOCION,

TRASLADOAFTP=NEW.TRASLADOAFTP,

TRANREGSERVER=NEW.TRANREGSERVER,

ORIGENFISCALID=NEW.ORIGENFISCALID,

FOLIOORIGENFACTURADO=NEW.FOLIOORIGENFACTURADO,

MONTOORIGENFACTURADO=NEW.MONTOORIGENFACTURADO,

VENDEDORFINAL=NEW.VENDEDORFINAL,

SERIEORIGENFACTURADO=NEW.SERIEORIGENFACTURADO,

APLICADOREF=NEW.APLICADOREF,

MERCANCIAENTREGADA=NEW.MERCANCIAENTREGADA,

PERSONAAPARTADOID=NEW.PERSONAAPARTADOID,

TIMBRADOUUID=NEW.TIMBRADOUUID,

TIMBRADOFECHA=NEW.TIMBRADOFECHA,

TIMBRADOCERTSAT=NEW.TIMBRADOCERTSAT,

TIMBRADOSELLOSAT=NEW.TIMBRADOSELLOSAT,

TIMBRADOSELLOCFDI=NEW.TIMBRADOSELLOCFDI,

FOLIOSAT=NEW.FOLIOSAT,

SERIESAT=NEW.SERIESAT,

DOCTOPAGOSAT=NEW.DOCTOPAGOSAT,

ESAPARTADO=NEW.ESAPARTADO,

ESFACTURAELECTRONICA=NEW.ESFACTURAELECTRONICA,

SUBTIPODOCTOID=NEW.SUBTIPODOCTOID,

FECHAINI=NEW.FECHAINI,

FECHAFIN=NEW.FECHAFIN,

MONEDERO=NEW.MONEDERO,

DESCMONEDERO=NEW.DESCMONEDERO,

ABONOMONEDERO=NEW.ABONOMONEDERO,

SUPERVISORID=NEW.SUPERVISORID,

SUBTOTALCONIVA=NEW.SUBTOTALCONIVA,

SUBTOTALSINIVA=NEW.SUBTOTALSINIVA,

USARDATOSENTREGA=NEW.USARDATOSENTREGA,

ISRRETENIDO=NEW.ISRRETENIDO,

IVARETENIDO=NEW.IVARETENIDO,

MONEDAID=NEW.MONEDAID,

TIPOCAMBIO=NEW.TIPOCAMBIO,

IEPS=NEW.IEPS,

IMPUESTO=NEW.IMPUESTO,

ESTATUSANTICIPOID=NEW.ESTATUSANTICIPOID,

TOTALANTICIPO=NEW.TOTALANTICIPO,

FECHAFACTURA=NEW.FECHAFACTURA,

NOTAPAGO=NEW.NOTAPAGO,

MANEJORECETA=NEW.MANEJORECETA,

UTILIDAD=NEW.UTILIDAD,

VENDEDORUTILIDADID=NEW.VENDEDORUTILIDADID,

MOVILPLAZOS=NEW.MOVILPLAZOS,

MOVILCONTADO=NEW.MOVILCONTADO,

TIMBRADOCANCELADO=NEW.TIMBRADOCANCELADO,

TIMBRADOFECHACANCELACION=NEW.TIMBRADOFECHACANCELACION,

TIMBRADOUUIDCANCELACION=NEW.TIMBRADOUUIDCANCELACION,

TIMBRADOFECHAFACTURA = NEW.TIMBRADOFECHAFACTURA,

DOCTOKITREFID=NEW.DOCTOKITREFID,

PREKITESTATUS=NEW.PREKITESTATUS,

POSTKITESTATUS=NEW.POSTKITESTATUS,

TOTALCONREBAJA=NEW.TOTALCONREBAJA,

REPLTIMECAMBIO = current_timestamp
  where 

REPLID=:REPLID
  ;
            

          END







          



     END

   END

end