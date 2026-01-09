create or alter procedure UPD_EXP_FILES_PED (
    FECHAFROM D_FECHA,
    TURNOIDFROM D_FK,
    FECHATO D_FECHA,
    TURNOIDTO D_FK)
returns (
    ERRORCODE D_ERRORCODE)
as
BEGIN




  /* inserta los archivos de pedidos a exportar */
      insert into exp_files
       (tipo,nombre,archivoftp,turnoid, fecha,estatus)
      select 'P' as tipo,
             ('veds' || EXTRACT(DAY FROM (fechas.dia)) || turno.id || '.dbf') nombre,
             ('veds' || EXTRACT(DAY FROM (fechas.dia)) || turno.id || '.dbf') archivoftp,
              turno.id turnoid,  
             fechas.dia  as fecha,
              'A' as estatus
              from turno
              cross join
              --here we should put all the dates that we want to process
              fechashabiles fechas
              where ((fechas.dia < :FECHATO) or (fechas.dia = :FECHATO and turno.id <= :TURNOIDFROM)) and
                    ((fechas.dia > :FECHAFROM ) or (fechas.dia = :FECHAFROM and turno.id  >= :TURNOIDFROM) )
                  and  (select count(*) cuenta from exp_files where tipo = 'P'
                                                               and fecha = (fechas.dia)
                                                               and turnoid = turno.id) = 0;


          update exp_files set estatus = 'A' where  tipo = 'P' and
          ((fecha < :FECHATO) or (fecha = :FECHATO and turnoid <= :TURNOIDFROM)) and
                    ((fecha > :FECHAFROM ) or (fecha = :FECHAFROM and turnoid >= :TURNOIDFROM) );




   ERRORCODE = 0;
   SUSPEND;

   WHEN ANY DO
   BEGIN
      ERRORCODE = 1004;
      SUSPEND;
   END 
END;





