create or alter procedure GET_DOCTO_MONTOTIPOAPLICACION (
    DOCTOID D_FK)
returns (
    APLICADO D_PRECIO,
    PAGADO D_PRECIO,
    ERRORCODE D_ERRORCODE)
as
declare variable TIPODOCTOID D_FK;
BEGIN
   SELECT TIPODOCTOID FROM DOCTO WHERE ID = :DOCTOID INTO :TIPODOCTOID;

   APLICADO = 0;
   PAGADO = 0;

   IF(:TIPODOCTOID IN ( 11, 15,22,23)) THEN
   BEGIN

   
          select coalesce(sum(p.importe *
           (CASE WHEN ((TIPOPAGOID = 2 AND FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 1 AND FORMAPAGOID IN (6,18)))  THEN 1
                when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6,18)))  THEN -1
                ELSE 0 END)
          ),0) from doctopago p inner join formapago f on p.formapagoid = f.id
          where p.doctosalidaid = :DOCTOID and f.abona = 'S'  INTO :APLICADO;

          select coalesce(sum(p.importe *
           (CASE WHEN ((TIPOPAGOID = 2 AND FORMAPAGOID IN (1,2,3,4,5,14,15,16)) )  THEN 1
                ELSE 0 END)
          ),0) from doctopago p inner join formapago f on p.formapagoid = f.id
          where p.doctosalidaid = :DOCTOID and f.abona = 'S' INTO :PAGADO;

   END 
   IF(:TIPODOCTOID IN ( 21, 24,12,13)) THEN
   BEGIN
        select coalesce(sum(p.importe *
          (CASE WHEN ((TIPOPAGOID = 1 AND FORMAPAGOID IN (6,18)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (7,19)))  THEN 1
                when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6,18))) THEN -1
                ELSE 0 END)
          ),0) from doctopago p inner join formapago f on p.formapagoid = f.id
          where p.doctoid = :DOCTOID and f.abona = 'S'  INTO :APLICADO;

          
        select coalesce(sum(p.importe *
          (CASE WHEN ((TIPOPAGOID = 1 AND FORMAPAGOID IN (1,2,3,4,5,14,15,16)) )  THEN 1
                ELSE 0 END)
          ),0) from doctopago p inner join formapago f on p.formapagoid = f.id
          where p.doctoid = :DOCTOID and f.abona = 'S'  INTO :PAGADO;
   END



   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1051;
      SUSPEND;
   END 

END