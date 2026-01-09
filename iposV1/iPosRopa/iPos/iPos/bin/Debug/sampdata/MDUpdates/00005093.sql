execute block
as
declare variable CONSECUTIVOPAGO D_FK;
declare variable STMT varchar(1024);
begin

  insert into pago
  (
    ID                     ,
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
    PAGODOCTOSATID         ,
    MONTOPORAPLICAR ,
    PERSONAID)
  SELECT
    DOCTOPAGO.ID                     ,
    DOCTOPAGO.ACTIVO                 ,
    DOCTOPAGO.CREADO                 ,
    DOCTOPAGO.CREADOPOR_USERID       ,
    DOCTOPAGO.MODIFICADO             ,
    DOCTOPAGO.MODIFICADOPOR_USERID   ,
    DOCTOPAGO.FORMAPAGOID            ,
    DOCTOPAGO.FECHA                  ,
    DOCTOPAGO.FECHAHORA              ,
    DOCTOPAGO.CORTEID                ,
    DOCTOPAGO.IMPORTE                ,
    DOCTOPAGO.IMPORTERECIBIDO        ,
    DOCTOPAGO.IMPORTECAMBIO          ,
    DOCTOPAGO.TIPOPAGOID             ,
    DOCTOPAGO.ESAPARTADO             ,
    DOCTOPAGO.TIPOAPLICACIONCREDITOID,
    DOCTOPAGO.BANCO                  ,
    DOCTOPAGO.REFERENCIABANCARIA     ,
    DOCTOPAGO.NOTAS                  ,
    DOCTOPAGO.FECHAELABORACION       ,
    DOCTOPAGO.FECHARECEPCION         ,
    DOCTOPAGO.ESPAGOINICIAL          ,
    DOCTOPAGO.TIPOABONOID            ,
    DOCTOPAGO.DOCTOPAGOREFID         ,
    DOCTOPAGO.REVERTIDO              ,
    DOCTOPAGO.CORTETRANSCANCELADA    ,
    DOCTOPAGO.FORMAPAGOSATID         ,
    DOCTOPAGO.FACTCONSID             ,
    DOCTOPAGO.RECIBOELECTRONICOID    ,
    DOCTOPAGO.CUENTAPAGOCREDITO      ,
    DOCTOPAGO.BANCOMERPARAMID        ,
    DOCTOPAGO.COMISION               ,
    DOCTOPAGO.PAGODOCTOSATID         ,
    0.00,
    COALESCE(DOCTO.PERSONAID, DOCTOSALIDA.PERSONAID)
    FROM
     DOCTOPAGO
    LEFT JOIN DOCTO ON DOCTOPAGO.ID = DOCTO.ID
    LEFT JOIN DOCTO DOCTOSALIDA ON DOCTOPAGO.DOCTOSALIDAID = DOCTOSALIDA.ID;

     SELECT MAX(ID) FROM PAGO INTO :CONSECUTIVOPAGO;
     CONSECUTIVOPAGO = coalesce(:CONSECUTIVOPAGO,0) + 1;

     STMT =  'ALTER SEQUENCE SEQ_PAGO RESTART WITH ' ||  CAST( coalesce(:CONSECUTIVOPAGO,0) AS VARCHAR(32));

     EXECUTE STATEMENT STMT;
     
     UPDATE DOCTOPAGO SET PAGOID = ID;


end