create or alter procedure KIT_ACTUALIZARIMPUESTO_TODOS
RETURNS
(errorcode d_errorcode)
as
  declare variable productkitid d_fk;
begin

   for select id from producto where eskit = 'S'
      into :productkitid
      do
      begin
           select errorcode from KIT_ACTUALIZARIMPUESTOKIT (:productkitid) into :errorcode;
      end
   ERRORCODE = 0;
   SUSPEND;
end
