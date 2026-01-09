create or alter procedure GET_LISTA_ABONOS_DOCTO (
    DOCTOID D_FK)
returns (
    ID D_FK,
    FECHA D_FECHA,
    FORMADEPAGO D_NOMBRE,
    MONTO D_PRECIO,
    BANCO D_NOMBRE,
    REFERENCIABANCARIA D_STDTEXT_LIGHT,
    FORMAPAGOID D_FK,
    TIPOABONODESCRIPCION D_STDTEXT_MEDIUM,
    TIPOABONOID D_FK,
    REVERTIDO D_BOOLCN,
    FOLIOREF D_DOCTOFOLIO,
    FECHAELABORACION D_FECHA,
    FECHARECEPCION D_FECHA,
    NOMBREVENDEDOR D_NOMBRE_NULL,
    FORMAPAGOSATID D_FK,
    RECIBOELECTRONICOID D_FK,
    FOLIOSATRECIBO D_DOCTOFOLIO,
    FOLIOSATSERIE D_DOCTOSERIE,
    ESCONPINPADBANCOMER D_BOOLCN,
    BANCOMERPARAMID D_FK,
    COMISION D_IMPORTE)
as
declare variable TIPODOCTOID D_FK;
declare variable PERSONAID D_FK;
declare variable BANCOID D_FK;
BEGIN
   
     ID = 0;
    FECHA = CURRENT_DATE;
    FORMADEPAGO = '';
    MONTO = 0;
    BANCO = '';
    REFERENCIABANCARIA = '';
    TIPOABONODESCRIPCION = '';
    REVERTIDO = 'N'; 
    FOLIOREF = 0;
    FECHAELABORACION = CURRENT_DATE;
    FECHARECEPCION = CURRENT_DATE;
    NOMBREVENDEDOR = '';
    FORMAPAGOSATID = 0;
    RECIBOELECTRONICOID = 0;
    FOLIOSATRECIBO = 0;
    FOLIOSATSERIE = '';
    ESCONPINPADBANCOMER = 'N';
    BANCOMERPARAMID = 0;
    COMISION = 0;


    SELECT PERSONAID, TIPODOCTOID FROM DOCTO WHERE ID = :DOCTOID INTO :PERSONAID, :TIPODOCTOID;

     

   if(:DOCTOID is null) then
   BEGIN
      --ERRORCODE = 1001;
      EXIT;
   END


   IF(:TIPODOCTOID IN (21,25, 201,31)) THEN
   BEGIN
      FOR
            select P.ID, p.fecha,
            case when fs.nombre is null or p.formapagosatid = 99  then f.nombre else fs.nombre end  as formapago,
            coalesce((p.importe *
          (CASE WHEN ((TIPOPAGOID = 1 AND p.FORMAPAGOID IN (1,2,3,4,5,6,14,15,16,17,18)) or (TIPOPAGOID = 2 AND p.FORMAPAGOID IN (7,19)))  THEN 1
                when ((TIPOPAGOID = 1 AND p.FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND p.FORMAPAGOID IN (6,18))) THEN -1
                ELSE 0 END)
          ),0) as monto,  p.referenciabancaria , coalesce(b.nombre,''), p.formapagoid ,
           (case when p.tipoabonoid in (3) then coalesce(a.nombre,'') || ' de #' || coalesce(cast(p.doctopagorefid as varchar(20)),'')
           else  coalesce(a.nombre,'') end ) TIPOABONODESCRIPCION ,
           coalesce(P.tipoabonoid,2) tipoabonoid , P.revertido  ,
           doctoref.folio folioref ,
           p.fechaelaboracion ,
           p.fecharecepcion ,
           v.nombre as nombrevendedor,
           P.formapagosatid  ,
           P.reciboelectronicoid ,
           case when p.bancomerparamid = 0 THEN 'N' else 'S' end ESCONPINPADBANCOMER ,
           p.BANCOMERPARAMID,
           P.COMISION

          from doctopago p
          inner join formapago f on p.formapagoid = f.id
          left join bancos b on b.id = p.banco
          left join tipoabono a on a.id = p.tipoabonoid
          left join docto doctoref on doctoref.id = p.doctosalidaid
          left join corte c on c.id = p.corteid
          left join persona v on v.id = c.cajeroid
          left join formapagosat fs on fs.id = p.formapagosatid
          where p.doctoid =:DOCTOID and f.abona = 'S'
          order by p.id
      INTO
            :ID, :FECHA, :FORMADEPAGO, :MONTO,  :REFERENCIABANCARIA  ,:BANCO , :FORMAPAGOID, :TIPOABONODESCRIPCION  , :TIPOABONOID  , :REVERTIDO  , :FOLIOREF, :FECHAELABORACION, :FECHARECEPCION  , :NOMBREVENDEDOR , :FORMAPAGOSATID  , :RECIBOELECTRONICOID , :ESCONPINPADBANCOMER ,:BANCOMERPARAMID  , :COMISION
      DO
      BEGIN
           --BANCO = '';
           --SELECT NOMBRE FROM BANCOS WHERE ID =:BANCOID INTO :BANCO;

           IF(COALESCE(:RECIBOELECTRONICOID,0) <> 0) THEN
           BEGIN
                SELECT DOCTO.foliosat, SERIESAT FROM DOCTO WHERE ID = :RECIBOELECTRONICOID
                INTO :FOLIOSATRECIBO, :FOLIOSATSERIE;
           end
           ELSE
           BEGIN   
                FOLIOSATRECIBO = 0;
                FOLIOSATSERIE = '';
           END

           SUSPEND;
      END

   END
   ELSE IF(:TIPODOCTOID IN (11,22,202)) THEN
   BEGIN
      FOR
            select P.ID,p.fecha,
            case when fs.nombre is null or p.formapagosatid = 99  then f.nombre else fs.nombre end  as formapago,
            coalesce((p.importe *
           (CASE WHEN ((TIPOPAGOID = 2 AND p.FORMAPAGOID IN (1,2,3,4,5,7,14,15,16,17,19)) or (TIPOPAGOID = 1 AND p.FORMAPAGOID IN (6,18)))  THEN 1
                when ((TIPOPAGOID = 1 AND p.FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND p.FORMAPAGOID IN (6,18)))  THEN -1
                ELSE 0 END)
          ),0) as monto, coalesce(b.nombre,''), p.referenciabancaria , p.formapagoid ,
           (case when p.tipoabonoid in (3) then coalesce(a.nombre,'') || ' de #' || cast(p.doctopagorefid as varchar(20))
           else  coalesce(a.nombre,'') end ) TIPOABONODESCRIPCION   ,
           coalesce(P.tipoabonoid,2) tipoabonoid  , P.revertido  ,
           doctoref.folio folioref   ,
           p.fechaelaboracion ,
           p.fecharecepcion ,
           P.formapagosatid ,
           P.reciboelectronicoid   ,
           case when p.bancomerparamid = 0 THEN 'N' else 'S' end ESCONPINPADBANCOMER ,
           p.BANCOMERPARAMID ,
           P.COMISION
          from doctopago p
          inner join formapago f on p.formapagoid = f.id  
          left join bancos b on b.id = p.banco     
          left join tipoabono a on a.id = p.tipoabonoid
          left join docto doctoref on doctoref.id = p.doctoid  
          left join formapagosat fs on fs.id = p.formapagosatid
          where p.doctosalidaid = :DOCTOID and f.abona = 'S'  
          order by p.id
      INTO
            :ID, :FECHA, :FORMADEPAGO, :MONTO, :BANCO, :REFERENCIABANCARIA, :FORMAPAGOID, :TIPOABONODESCRIPCION   , :TIPOABONOID , :REVERTIDO , :FOLIOREF , :FECHAELABORACION, :FECHARECEPCION , :FORMAPAGOSATID , :RECIBOELECTRONICOID   , :ESCONPINPADBANCOMER ,:BANCOMERPARAMID , :COMISION
      DO
      BEGIN
                
           --BANCO = '';
           --SELECT NOMBRE FROM BANCOS WHERE ID =:BANCOID INTO :BANCO;
           
           IF(COALESCE(:RECIBOELECTRONICOID,0) <> 0) THEN
           BEGIN
                SELECT DOCTO.foliosat, SERIESAT FROM DOCTO WHERE ID = :RECIBOELECTRONICOID
                INTO :FOLIOSATRECIBO, :FOLIOSATSERIE;
           end
           ELSE
           BEGIN   
                FOLIOSATRECIBO = 0;
                FOLIOSATSERIE = '';
           END

           SUSPEND;
      END
   END









   WHEN ANY DO
   BEGIN
      --ERRORCODE = 1016;
      SUSPEND;
   END 


END