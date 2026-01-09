create or alter procedure TTL_ACTUALIZAR
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable HABTOTALIZADOS D_BOOLCN;
declare variable FECHA_TTL_DOCTO_PERS_MES D_FECHA;
declare variable FECHA_TTL_PROD_TIPO_MES D_FECHA;
declare variable CUENTATTLCONTROL integer;
declare variable DESDE_PRIMER_DIA_MES D_FECHA;
declare variable DESDE_MES D_DIAS;
declare variable DESDE_ANIO D_DIAS;
declare variable TICKETSDEVOLUCION integer;
declare variable INGRESOPORIVA D_IMPORTE;
BEGIN

   ERRORCODE = 0;

   SELECT FIRST 1 PARAMETRO.habtotalizados
   FROM PARAMETRO
   INTO :HABTOTALIZADOS ;

        
   IF (COALESCE(:HABTOTALIZADOS,'N') <> 'S') THEN
   BEGIN
      SUSPEND;
      EXIT;
   END


   SELECT COUNT(*) FROM TTLCONTROL INTO :CUENTATTLCONTROL;


   IF(COALESCE(:CUENTATTLCONTROL ,0) = 0) THEN
   BEGIN

      INSERT INTO TTLCONTROL (  FECHA_TTL_PROD_TIPO_MES, FECHA_TTL_DOCTO_PERS_MES)
      VALUES('01.01.2000','01.01.2000');
   END


   SELECT FIRST 1 FECHA_TTL_DOCTO_PERS_MES, FECHA_TTL_PROD_TIPO_MES
   FROM TTLCONTROL
   INTO :FECHA_TTL_DOCTO_PERS_MES, :FECHA_TTL_PROD_TIPO_MES;

   
        
   FECHA_TTL_DOCTO_PERS_MES = COALESCE(:FECHA_TTL_DOCTO_PERS_MES, '01.01.2000'); 
   FECHA_TTL_PROD_TIPO_MES = COALESCE(:FECHA_TTL_PROD_TIPO_MES, '01.01.2000');




   
   IF(:FECHA_TTL_PROD_TIPO_MES < CURRENT_DATE) THEN
   BEGIN



     DESDE_MES = EXTRACT(MONTH from :FECHA_TTL_PROD_TIPO_MES);
     DESDE_ANIO = EXTRACT(YEAR from :FECHA_TTL_PROD_TIPO_MES);

     DESDE_PRIMER_DIA_MES = DATEADD(((EXTRACT(DAY from :FECHA_TTL_PROD_TIPO_MES) * -1) + 1) DAY TO  :FECHA_TTL_PROD_TIPO_MES);

     DELETE FROM TTL_PROD_TIPO_MES
     WHERE  ANIO > :DESDE_ANIO or (ANIO = :DESDE_ANIO AND MES >=:DESDE_MES);


     INSERT INTO ttl_prod_tipo_mes
     ( productoid, tipodoctoid, subtipodoctoid, anio, mes, cantidad, total, utilidad)
     select
        producto.id productoid,
        docto.tipodoctoid,
        docto.subtipodoctoid,
        extract(year from docto.fecha) anio,
        extract(month from docto.fecha) mes ,
        sum(coalesce(movto.cantidad,0)) cantidad ,
        sum(coalesce(movto.total,0)) total,
        sum(coalesce(movto.utilidad,0)) utilidad


      from docto inner join
            movto on movto.doctoid = docto.id
                left join producto on producto.id = movto.productoid

      where
        docto.tipodoctoid in (11,12,13,21,22,23,31,32,33,41,42,43,81,83) and
        docto.fecha >= :DESDE_PRIMER_DIA_MES AND 
        docto.estatusdoctoid <> 0

      group by producto.id,
            docto.tipodoctoid,
            docto.subtipodoctoid,
            extract(year from docto.fecha) ,
            extract(month from docto.fecha) ;




       UPDATE   TTLCONTROL SET  FECHA_TTL_PROD_TIPO_MES = CURRENT_DATE;

    END

   





   
   IF(:FECHA_TTL_DOCTO_PERS_MES < CURRENT_DATE) THEN
   BEGIN



     DESDE_MES = EXTRACT(MONTH from :FECHA_TTL_DOCTO_PERS_MES);
     DESDE_ANIO = EXTRACT(YEAR from :FECHA_TTL_DOCTO_PERS_MES);

     DESDE_PRIMER_DIA_MES = DATEADD(((EXTRACT(DAY from :FECHA_TTL_DOCTO_PERS_MES) * -1) + 1) DAY TO  :FECHA_TTL_DOCTO_PERS_MES);


     DELETE FROM TTL_DOCTO_PERS_MES
     WHERE  ANIO > :DESDE_ANIO or (ANIO = :DESDE_ANIO AND MES >=:DESDE_MES);


     INSERT INTO ttl_DOCTO_PERS_mes
     ( personaid, tipodoctoid, subtipodoctoid, anio, mes, cantidad, total, utilidad)
     select
        persona.id personaid,
        docto.tipodoctoid,
        docto.subtipodoctoid,
        extract(year from docto.fecha) anio,
        extract(month from docto.fecha) mes ,
        count(docto.id) cantidad ,
        sum(coalesce(docto.total,0)) total,
        sum(coalesce(docto.utilidad,0)) utilidad


      from docto inner join
                 persona on persona.id = docto.personaid

      where
        docto.tipodoctoid in (11,12,13,21,22,23,31,32,33,41,42,43,81,83) and
        docto.fecha >= :DESDE_PRIMER_DIA_MES AND 
        docto.estatusdoctoid <> 0

      group by persona.id,
            docto.tipodoctoid,
            docto.subtipodoctoid,
            extract(year from docto.fecha) ,
            extract(month from docto.fecha) ;









       UPDATE   TTLCONTROL SET  FECHA_TTL_DOCTO_PERS_MES = CURRENT_DATE;

    END


    SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 5010;
      SUSPEND;
   END
END