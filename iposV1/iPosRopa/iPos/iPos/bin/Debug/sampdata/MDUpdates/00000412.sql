create or alter procedure UPD_EXP_FILES_PED (
    FECHAFROM D_FECHA,
    FECHATO D_FECHA,
    UNSOLOARCHIVO D_BOOLCN)
returns (
    ERRORCODE D_ERRORCODE)
as
BEGIN


   IF(UNSOLOARCHIVO = 'N') THEN
   BEGIN


  /* inserta los archivos de pedidos a exportar */
      insert into exp_files
       (tipo,nombre,archivoftp,turnoid, fecha,estatus,fechato)
      select 'P' as tipo,
             ('veds' || EXTRACT(DAY FROM (fechas.dia)) || /*turno.id ||*/ '.dbf') nombre,
             ('veds' || EXTRACT(DAY FROM (fechas.dia)) || /*turno.id ||*/ '.dbf') archivoftp,
              0 turnoid,--turno.id turnoid,
             fechas.dia  as fecha,
              'A' as estatus ,
              fechas.dia  as fechato
              from /*turno
              cross join*/
              --here we should put all the dates that we want to process
              fechashabiles fechas
              where (fechas.dia <= :FECHATO and fechas.dia >= :FECHAFROM /*and turno.id  = :TURNOID*/)
                  and  (select count(*) cuenta from exp_files where tipo = 'P'
                                                               and fecha = (fechas.dia)
                                                               /*and turnoid = turno.id*/) = 0;


          update exp_files set estatus = 'A' where  tipo = 'P' and           
                    (fecha <= :FECHATO and fecha >= :FECHAFROM /*and turnoid  = :TURNOID*/);


    END
    ELSE
    BEGIN
    
          update exp_files set estatus = 'C' where  tipo = 'P' and
                    (fecha <= :FECHATO and fecha >= :FECHAFROM and estatus  <> 'E');

            insert into exp_files
       (tipo,nombre,archivoftp,turnoid, fecha,estatus,fechato)
       VALUES( 'P' ,
             ('veds' || LPAD(CAST(EXTRACT(DAY FROM (CURRENT_DATE)) AS VARCHAR(2)),2,'0') || LPAD(CAST(EXTRACT(MONTH FROM (CURRENT_DATE)) AS VARCHAR(2)),2,'0') ||  '.dbf'),
             ('veds' || LPAD(CAST(EXTRACT(DAY FROM (CURRENT_DATE)) AS VARCHAR(2)),2,'0') || LPAD(CAST(EXTRACT(MONTH FROM (CURRENT_DATE)) AS VARCHAR(2)),2,'0') ||  '.dbf'),
              0 ,--turno.id turnoid,
             :FECHAFROM  ,
              'A'   ,
              :FECHATO
              );




    END

   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1004;
      SUSPEND;
   END 
END