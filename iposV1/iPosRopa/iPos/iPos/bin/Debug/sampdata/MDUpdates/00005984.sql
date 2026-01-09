create or alter procedure LIMPIARVENTASPENDIENTES
as
declare variable DOCTOID D_FK;
BEGIN



   FOR  select docto.id from
        docto
        where  ( (docto.tipodoctoid not in (29,50,51,52,53,60,61,71,201,202,203,204,16,17,18,81,41,11, 331)))
         and docto.estatusdoctoid = 0
        and (coalesce(docto.subtipodoctoid, 0) <> 21)
        into :doctoid
   do
   BEGIN
      delete from movto where doctoid = :doctoid;
   END
   
   delete from docto
   where  ( (docto.tipodoctoid not in (29,50,51,52,53,60,61,71,201,202,203,204,16,17,18,81,41,11, 331, 14)))
   and docto.estatusdoctoid = 0
   and (coalesce(docto.subtipodoctoid, 0) not in (/*21,*/22,24));



END