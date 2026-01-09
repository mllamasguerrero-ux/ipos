create or alter procedure CORTE_CERRAR (
    SUCURSALID D_FK,
    CORTEID D_FK,
    FECHACORTE D_FECHA,
    CAJEROID D_FK,
    SALDOINICIAL D_IMPORTE,
    INGRESO D_IMPORTE,
    EGRESO D_IMPORTE,
    DEVOLUCION D_IMPORTE,
    APORTACION D_IMPORTE,
    RETIRO D_IMPORTE,
    SALDOFINAL D_IMPORTE,
    SALDOREAL D_IMPORTE,
    DIFERENCIA D_IMPORTE,
    SALDOREALCREDITO D_IMPORTE)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable ACTIVO D_BOOLCN;
declare variable MANEJAIEPS D_BOOLCN;
declare variable PENDMAXDIAS D_DIAS;
declare variable MOVTOID D_FK;
declare variable DOCTOID D_FK;
declare variable CUENTAINCONCLUSOS integer;
BEGIN

  SELECT FIRST 1 PENDMAXDIAS FROM PARAMETRO  INTO :PENDMAXDIAS;

   SELECT ACTIVO
   FROM CORTE
   WHERE ID = :CORTEID
   INTO :ACTIVO;

   IF (:CORTEID IS NULL) THEN
   BEGIN
      ERRORCODE = 1023;
      SUSPEND;
      EXIT;
   END

   IF (:ACTIVO <> 'S') THEN
   BEGIN
      ERRORCODE = 1024;
      SUSPEND;
      EXIT;
   END


   SELECT CUENTAINCONCLUSOS from
   EMIDA_VENTASCORTE_INCONCLUSAS (:CAJEROID )
   INTO :CUENTAINCONCLUSOS;


   IF(COALESCE(:CUENTAINCONCLUSOS,0) > 0 ) THEN
   BEGIN
           
      ERRORCODE = 5011;
      SUSPEND;
      EXIT;
   END



   UPDATE CORTE
   SET
      SALDOREAL  = :SALDOREAL,
      DIFERENCIA = :DIFERENCIA,
      SALDOREALCREDITO = :SALDOREALCREDITO,
      ACTIVO = 'N',
      TERMINA = CURRENT_TIMESTAMP
   WHERE ID = :CORTEID;

   UPDATE PERSONA
   SET
      CORTEID = NULL
   WHERE ID = :CAJEROID;


   FOR  select docto.id from docto
                     where docto.corteid =  :CORTEID
                    and ((docto.tipodoctoid not in (29,50,51,52,53,60,61,71,201,202,203,204,16,17,18,81,41,11, 331))
                    or (docto.tipodoctoid = 11 and docto.fecha < dateadd( -20 day to current_date )) )
                    and docto.estatusdoctoid = 0  
                    and (coalesce(docto.subtipodoctoid, 0) <> 21)
                    and coalesce(docto.pendmaxfecha, docto.fecha) <= current_date
        into :doctoid
   do
   BEGIN
      delete from movto where doctoid = :doctoid;
   END

   
   delete from docto
   where docto.corteid =  :CORTEID
   and ( (docto.tipodoctoid not in (29,50,51,52,53,60,61,71,201,202,203,204,16,17,18,81,41,11, 331))
            or (docto.tipodoctoid = 11 and docto.fecha < dateadd( -20 day to current_date )) )
   and docto.estatusdoctoid = 0     
   and (coalesce(docto.subtipodoctoid, 0) <> 21)
   and coalesce(docto.pendmaxfecha, docto.fecha) <= current_date;

   
   FOR  select docto.id from
        docto
        where docto.vendedorid = :cajeroid
        and ( (docto.tipodoctoid not in (29,50,51,52,53,60,61,71,201,202,203,204,16,17,18,81,41,11, 331)))
        and fecha >= dateadd( (COALESCE(:PENDMAXDIAS,0) * -1) DAY TO CURRENT_DATE)  
        and coalesce(docto.pendmaxfecha, docto.fecha) <= current_date
        and docto.estatusdoctoid = 0   
        and (coalesce(docto.subtipodoctoid, 0) <> 21)
        into :doctoid
   do
   BEGIN
      delete from movto where doctoid = :doctoid;
   END
   
   delete from docto
   where docto.vendedorid = :cajeroid
   and ( (docto.tipodoctoid not in (29,50,51,52,53,60,61,71,201,202,203,204,16,17,18,81,41,11, 331, 14)))
   and fecha >= dateadd( (COALESCE(:PENDMAXDIAS,0) * -1) DAY TO CURRENT_DATE)  
   and coalesce(docto.pendmaxfecha, docto.fecha) <= current_date
   and docto.estatusdoctoid = 0
   and (coalesce(docto.subtipodoctoid, 0) not in (/*21,*/22,24));


            /*
   delete  from movto
   where movto.doctoid in
   (select docto.id from
    docto
   where docto.corteid =  :CORTEID
   and ((docto.tipodoctoid not in (29,50,51,52,53,60,61,71,201,202,203,204,16,17,18,81,41,11, 331))
        or (docto.tipodoctoid = 11 and docto.fecha < dateadd( -20 day to current_date )) )
   and docto.estatusdoctoid = 0  
   and coalesce(docto.pendmaxfecha, docto.fecha) <= current_date
   );

   delete from docto
   where docto.corteid =  :CORTEID
   and ( (docto.tipodoctoid not in (29,50,51,52,53,60,61,71,201,202,203,204,16,17,18,81,41,11, 331))
            or (docto.tipodoctoid = 11 and docto.fecha < dateadd( -20 day to current_date )) )
   and docto.estatusdoctoid = 0
   and coalesce(docto.pendmaxfecha, docto.fecha) <= current_date;

   delete  from movto
   where movto.doctoid in
   (select docto.id from
    docto
   where docto.vendedorid = :cajeroid
   and ( (docto.tipodoctoid not in (29,50,51,52,53,60,61,71,201,202,203,204,16,17,18,81,41,11, 331)))
   and fecha >= dateadd( (COALESCE(:PENDMAXDIAS,0) * -1) DAY TO CURRENT_DATE)  
   and coalesce(docto.pendmaxfecha, docto.fecha) <= current_date
   and docto.estatusdoctoid = 0
   );

   delete from docto
   where docto.vendedorid = :cajeroid
   and ( (docto.tipodoctoid not in (29,50,51,52,53,60,61,71,201,202,203,204,16,17,18,81,41,11, 331)))
   and fecha >= dateadd( (COALESCE(:PENDMAXDIAS,0) * -1) DAY TO CURRENT_DATE)  
   and coalesce(docto.pendmaxfecha, docto.fecha) <= current_date
   and docto.estatusdoctoid = 0;
                  */



    SELECT FIRST 1 PARAMETRO.desgloseieps FROM PARAMETRO INTO :MANEJAIEPS;

   IF(:MANEJAIEPS = 'S') THEN
   BEGIN


     delete from corteieps where corteid = :CORTEID;

     /*insert into corteieps
     ( corteid, tasaieps, monto)
     select d.corteid, coalesce(m.tasaieps ,0) tasaieps, sum(coalesce(m.ieps ,0) * td.sentidopago)  monto
      FROM DOCTO D
       Inner join MOVTO M
         ON M.doctoid = D.ID
        left join TIPODOCTO  TD
         on  TD.id = d.tipodoctoid
         WHERE d.TIPODOCTOID in (21,22,23,24,25,26)
         AND COALESCE(m.tasaieps,0) > 0
         AND D.CORTEID = :CORTEID
     GROUP BY  d.corteid,
     coalesce(m.tasaieps ,0) ; */

     
        insert into corteieps (corteid,tasaieps, monto)
        select CORTEID, TASAIEPS, round(coalesce(MONTOIEPS,0),2)
        from corte_base_por_ieps where corteid = :corteid;


   END


   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1025;
      SUSPEND;
   END 
END