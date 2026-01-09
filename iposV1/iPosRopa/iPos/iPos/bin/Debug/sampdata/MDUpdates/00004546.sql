create or alter procedure GET_TICKET_ABONO (
    DOCTOPAGOID D_FK)
returns (
    SUCURSALNOMBRE D_NOMBRE,
    SUCURSALDESCRIPCION D_DESCRIPCION,
    NOMBREEMPRESA D_STDTEXT_MEDIUM,
    RFC D_STDTEXT_MEDIUM,
    COLONIA D_STDTEXT_MEDIUM,
    DOMICILIO D_STDTEXT_MEDIUM,
    NUMEROEXTERIOR D_STDTEXT_SHORT,
    NUMEROINTERIOR D_STDTEXT_SHORT,
    CODIGOPOSTAL D_STDTEXT_MEDIUM,
    RAZON_SOCIAL D_STDTEXT_MEDIUM,
    TELEFONO D_STDTEXT_SHORT,
    CIUDAD D_STDTEXT_MEDIUM,
    ESTADO D_STDTEXT_MEDIUM,
    MUNICIPIO D_STDTEXT_MEDIUM,
    FECHAPAGO D_FECHA,
    IMPORTEPAGO D_IMPORTE,
    NUMEROPAGO D_FK,
    FOLIODOCTO D_DOCTOFOLIO,
    TOTALDOCTO D_PRECIO,
    SALDODOCTO D_PRECIO,
    CAJERO D_NOMBRE,
    PERSONANOMBRES D_STDTEXT_MEDIUM,
    PERSONAAPELLIDOS D_STDTEXT_MEDIUM,
    PERSONADOMICILIO D_STDTEXT_MEDIUM,
    PERSONANUMEROEXTERIOR D_STDTEXT_SHORT,
    PERSONANUMEROINTERIOR D_STDTEXT_SHORT,
    PERSONACODIGOPOSTAL D_STDTEXT_SHORT,
    PERSONACOLONIA D_STDTEXT_MEDIUM,
    PERSONATELEFONO1 D_STDTEXT_SHORT,
    FORMADEPAGO D_NOMBRE,
    IMPORTERECIBIDO D_IMPORTE,
    COMISION D_IMPORTE)
as
BEGIN
   
--Initialitation
    SUCURSALNOMBRE = '';
    SUCURSALDESCRIPCION = '';
    NOMBREEMPRESA = '';
    RFC   = '';
    COLONIA  = '';
    DOMICILIO  = '';
    NUMEROEXTERIOR = ''; 
    NUMEROINTERIOR = '';
    CODIGOPOSTAL  = '';
    RAZON_SOCIAL  = '';
    TELEFONO  = '';
    CIUDAD  = '';
    ESTADO  = '';
    MUNICIPIO  = '';
    FECHAPAGO = CURRENT_DATE;
    IMPORTEPAGO = 0;
    NUMEROPAGO = 0;
    FOLIODOCTO  = 0;
    TOTALDOCTO = 0;
    SALDODOCTO = 0;
    CAJERO  = '';
    PERSONANOMBRES  = '';
    PERSONAAPELLIDOS  = '';
    PERSONADOMICILIO  = '';
    PERSONANUMEROEXTERIOR  = '';
    PERSONANUMEROINTERIOR  = '';
    PERSONACODIGOPOSTAL  = '';
    PERSONACOLONIA  = '';
    PERSONATELEFONO1  = '';
    FORMADEPAGO = '';

    IMPORTERECIBIDO = 0;
    COMISION = 0;





   if(:DOCTOPAGOID is null) then
   BEGIN
     SUSPEND;
      EXIT;
   END






   FOR 
    SELECT
      SUCURSAL.nombre           SUCURSALNOMBRE,
      SUCURSAL.descripcion      SUCURSALDESCRIPCION,
      P.NOMBRE                  NOMBREEMPRESA,
      P.rfc                     RFC,
      P.colonia                 COLONIA,
      P.calle                   DOMICILIO,
      p.numeroexterior          NUMEROEXTERIOR,
      P.numeroINterior          NUMEROINTERIOR,
      P.cp                      CODIGOPOSTAL,
      'Razon Social'            RAZON_SOCIAL,
      P.telefono                TELEFONO,
      P.localidad               CIUDAD,
      P.estado                  ESTADO,
      P.localidad               MUNICIPIO ,
      DP.FECHA                  FECHAPAGO,
      DP.IMPORTE                IMPORTEPAGO,
      DP.id                     NUMEROPAGO,
      DOCTO.folio               FOLIODOCTO  ,
      DOCTO.TOTAL               TOTALDOCTO,
      DOCTO.SALDO               SALDODOCTO,
      V.NOMBRE                  CAJERO,
      case when DOCTO.TIPODOCTOID = 25 then A.NOMBRES  when DOCTO.TIPODOCTOID = 11 then E.NOMBRE       else e.NOMBRES          end  PERSONANOMBRES,
      case when DOCTO.TIPODOCTOID = 25 then A.APELLIDOS       else e.APELLIDOS        end  PERSONAAPELLIDOS,
      case when DOCTO.TIPODOCTOID = 25 then A.domicilio       else e.domicilio        end  PERSONADOMICILIO,
      case when DOCTO.TIPODOCTOID = 25 then ''                else E.numeroexterior   end  PERSONANUMEROEXTERIOR,
      case when DOCTO.TIPODOCTOID = 25 then ''                else E.numeroINterior   end  PERSONANUMEROINTERIOR,
      case when DOCTO.TIPODOCTOID = 25 then A.codigopostal    else e.codigopostal     end  PERSONACODIGOPOSTAL,
      case when DOCTO.TIPODOCTOID = 25 then A.colonia         else E.colonia          end  PERSONACOLONIA,
      case when DOCTO.TIPODOCTOID = 25 then A.telefono1       else E.telefono1        end  PERSONATELEFONO1,
      f.nombre                  FORMADEPAGO ,

      DP.IMPORTERECIBIDO     IMPORTERECIBIDO,
      DP.COMISION            COMISION



   FROM doctopago DP  LEFT JOIN  DOCTO  ON
      (DOCTO.ID = DP.DOCTOID AND DOCTO.tipodoctoid IN (21,24,25,12,13)) or (DOCTO.ID = DP.doctosalidaid AND DOCTO.TIPODOCTOID IN (11,15,22,23,26))
        LEFT JOIN SUCURSAL ON SUCURSAL.ID = DOCTO.SUCURSALID
        left join parametro P on p.sucursalid = sucursal.id
        left join corte  C on c.id = dp.corteid
        left join persona V on V.id = C.cajeroid
        left join persona e on e.id = DOCTO.personaid   
        left join personaapartado A on A.id = DOCTO.personaapartadoid
        left join formapago f on dp.formapagoid = f.id
        where dp.id = :DOCTOPAGOID
       INTO 
         :SUCURSALNOMBRE,
         :SUCURSALDESCRIPCION,
         :NOMBREEMPRESA,
         :RFC,
         :COLONIA,
         :DOMICILIO,
         :NUMEROEXTERIOR,
         :NUMEROINTERIOR,
         :CODIGOPOSTAL,
         :RAZON_SOCIAL,
         :TELEFONO,
         :CIUDAD,
         :ESTADO,
         :MUNICIPIO ,
         :FECHAPAGO,
         :IMPORTEPAGO,
         :NUMEROPAGO,
         :FOLIODOCTO  ,
         :TOTALDOCTO,
         :SALDODOCTO,
         :CAJERO,
         :PERSONANOMBRES,
         :PERSONAAPELLIDOS,
         :PERSONADOMICILIO,
         :PERSONANUMEROEXTERIOR,  
         :PERSONANUMEROINTERIOR,
         :PERSONACODIGOPOSTAL,
         :PERSONACOLONIA,
         :PERSONATELEFONO1 ,
         :FORMADEPAGO ,
         :IMPORTERECIBIDO,
         :COMISION

 
   DO
   BEGIN
           SUSPEND;
   END
    


   WHEN ANY DO
   BEGIN
      --ERRORCODE = 1016;
      SUSPEND;
   END 


END