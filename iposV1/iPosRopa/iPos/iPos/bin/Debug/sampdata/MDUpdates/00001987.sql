create or alter procedure MOVTO_ADJUNTOELIMINARMOVIL (
    MOVTOPADREID D_PK)
returns (
    ERRORCODE D_ERRORCODE)
as
BEGIN


        UPDATE MOVTO SET 
            MOVTO.movtoadjuntoaid = NULL
        WHERE MOVTO.movtoadjuntoaid = :MOVTOPADREID;


       ERRORCODE = 0;
       SUSPEND;


END