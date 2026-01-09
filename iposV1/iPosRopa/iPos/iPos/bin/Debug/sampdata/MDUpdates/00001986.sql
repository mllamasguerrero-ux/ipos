create or alter procedure MOVTO_ADJUNTARMOVIL (
    MOVTOPADREID D_PK,
    MOVTOADJUNTARID D_PK)
returns (
    ERRORCODE D_ERRORCODE)
as
BEGIN


        UPDATE MOVTO SET 
            MOVTO.movtoadjuntoaid = :MOVTOPADREID
        WHERE ID = :MOVTOADJUNTARID AND MOVTO.movtoadjuntoaid IS NULL;


       ERRORCODE = 0;
       SUSPEND;


END