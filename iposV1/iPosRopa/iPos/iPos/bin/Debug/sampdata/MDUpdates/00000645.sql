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
    FOLIOREF D_DOCTOFOLIO)
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


    SELECT PERSONAID, TIPODOCTOID FROM DOCTO WHERE ID = :DOCTOID INTO :PERSONAID, :TIPODOCTOID;

     

   if(:DOCTOID is null) then
   BEGIN
      --ERRORCODE = 1001;
      EXIT;
   END


   IF(:TIPODOCTOID IN (21,25)) THEN
   BEGIN
      FOR
            select P.ID, p.fecha, f.nombre as formapago, coalesce((p.importe *
          (CASE WHEN ((TIPOPAGOID = 1 AND FORMAPAGOID IN (1,2,3,4,5,6,14)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (7)))  THEN 1
                when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6))) THEN -1
                ELSE 0 END)
          ),0) as monto,  p.referenciabancaria , coalesce(b.nombre,''), p.formapagoid ,
           (case when p.tipoabonoid in (3) then coalesce(a.nombre,'') || ' de #' || coalesce(cast(p.doctopagorefid as varchar(20)),'')
           else  coalesce(a.nombre,'') end ) TIPOABONODESCRIPCION ,
           coalesce(P.tipoabonoid,2) tipoabonoid , P.revertido  ,
           doctoref.folio folioref

          from doctopago p
          inner join formapago f on p.formapagoid = f.id
          left join bancos b on b.id = p.banco
          left join tipoabono a on a.id = p.tipoabonoid
          left join docto doctoref on doctoref.id = p.doctosalidaid
          where p.doctoid =:DOCTOID and f.abona = 'S'
          order by p.id
      INTO
            :ID, :FECHA, :FORMADEPAGO, :MONTO,  :REFERENCIABANCARIA  ,:BANCO , :FORMAPAGOID, :TIPOABONODESCRIPCION  , :TIPOABONOID  , :REVERTIDO  , :FOLIOREF
      DO
      BEGIN
           --BANCO = '';
           --SELECT NOMBRE FROM BANCOS WHERE ID =:BANCOID INTO :BANCO;
           SUSPEND;
      END

   END
   ELSE IF(:TIPODOCTOID IN (11)) THEN
   BEGIN
      FOR
            select P.ID,p.fecha, f.nombre as formapago,coalesce((p.importe *
           (CASE WHEN ((TIPOPAGOID = 2 AND FORMAPAGOID IN (1,2,3,4,5,7,14)) or (TIPOPAGOID = 1 AND FORMAPAGOID IN (6)))  THEN 1
                when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6)))  THEN -1
                ELSE 0 END)
          ),0) as monto, coalesce(b.nombre,''), p.referenciabancaria , p.formapagoid ,
           (case when p.tipoabonoid in (3) then coalesce(a.nombre,'') || ' de #' || cast(p.doctopagorefid as varchar(20))
           else  coalesce(a.nombre,'') end ) TIPOABONODESCRIPCION   ,
           coalesce(P.tipoabonoid,2) tipoabonoid  , P.revertido  ,
           doctoref.folio folioref
          from doctopago p
          inner join formapago f on p.formapagoid = f.id  
          left join bancos b on b.id = p.banco     
          left join tipoabono a on a.id = p.tipoabonoid
          left join docto doctoref on doctoref.id = p.doctoid
          where p.doctosalidaid = :DOCTOID and f.abona = 'S'  
          order by p.id
      INTO
            :ID, :FECHA, :FORMADEPAGO, :MONTO, :BANCO, :REFERENCIABANCARIA, :FORMAPAGOID, :TIPOABONODESCRIPCION   , :TIPOABONOID , :REVERTIDO , :FOLIOREF
      DO
      BEGIN
                
           --BANCO = '';
           --SELECT NOMBRE FROM BANCOS WHERE ID =:BANCOID INTO :BANCO;
           SUSPEND;
      END
   END









   WHEN ANY DO
   BEGIN
      --ERRORCODE = 1016;
      SUSPEND;
   END 


END