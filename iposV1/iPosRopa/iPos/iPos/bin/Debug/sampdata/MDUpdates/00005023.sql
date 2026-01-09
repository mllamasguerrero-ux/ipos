CREATE OR ALTER trigger doctopago_ai_hdr for doctopago
active after insert position 999
AS
declare variable HEADERID D_FK;
declare variable STMT varchar(1024);
begin
  /* Trigger text */

  IF(COALESCE(NEW.PAGOID ,0) = 0) THEN
  BEGIN

    
  insert into pago
  (
    ACTIVO                 ,
    CREADO                 ,
    CREADOPOR_USERID       ,
    MODIFICADO             ,
    MODIFICADOPOR_USERID   ,
    FORMAPAGOID            ,
    FECHA                  ,
    FECHAHORA              ,
    CORTEID                ,
    IMPORTE                ,
    IMPORTERECIBIDO        ,
    IMPORTECAMBIO          ,
    TIPOPAGOID             ,
    ESAPARTADO             ,
    TIPOAPLICACIONCREDITOID,
    BANCO                  ,
    REFERENCIABANCARIA     ,
    NOTAS                  ,
    FECHAELABORACION       ,
    FECHARECEPCION         ,
    ESPAGOINICIAL          ,
    TIPOABONOID            ,
    PAGOREFID              ,
    REVERTIDO              ,
    CORTETRANSCANCELADA    ,
    FORMAPAGOSATID         ,
    FACTCONSID             ,
    RECIBOELECTRONICOID    ,
    CUENTAPAGOCREDITO      ,
    BANCOMERPARAMID        ,
    COMISION               ,
    PAGODOCTOSATID   )
    values(
    NEW.ACTIVO                 ,
    NEW.CREADO                 ,
    NEW.CREADOPOR_USERID       ,
    NEW.MODIFICADO             ,
    NEW.MODIFICADOPOR_USERID   ,
    NEW.FORMAPAGOID            ,
    NEW.FECHA                  ,
    NEW.FECHAHORA              ,
    NEW.CORTEID                ,
    NEW.IMPORTE                ,
    NEW.IMPORTERECIBIDO        ,
    NEW.IMPORTECAMBIO          ,
    NEW.TIPOPAGOID             ,
    NEW.ESAPARTADO             ,
    NEW.TIPOAPLICACIONCREDITOID,
    NEW.BANCO                  ,
    NEW.REFERENCIABANCARIA     ,
    NEW.NOTAS                  ,
    NEW.FECHAELABORACION       ,
    NEW.FECHARECEPCION         ,
    NEW.ESPAGOINICIAL          ,
    NEW.TIPOABONOID            ,
    NEW.DOCTOPAGOREFID         ,
    NEW.REVERTIDO              ,
    NEW.CORTETRANSCANCELADA    ,
    NEW.FORMAPAGOSATID         ,
    NEW.FACTCONSID             ,
    NEW.RECIBOELECTRONICOID    ,
    NEW.CUENTAPAGOCREDITO      ,
    NEW.BANCOMERPARAMID        ,
    NEW.COMISION               ,
    NEW.PAGODOCTOSATID  )
    RETURNING ID INTO  :HEADERID;



    UPDATE DOCTOPAGO SET PAGOID = :HEADERID WHERE ID = NEW.ID;


  END

end