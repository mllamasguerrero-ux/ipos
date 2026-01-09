execute block
as
  declare variable productkitid d_fk;
  declare variable errorcode d_errorcode;
begin

   for select id from producto where eskit = 'S'
      into :productkitid
      do
      begin
           select errorcode from KIT_ACTUALIZARIMPUESTOKIT (:productkitid) into :errorcode;
      end

end