create or alter procedure MENSAJES_ALERTAUSUARIO (
    USUARIOID D_FK,
    USUARIOESADMIN D_BOOLCN)
returns (
    CUENTAMENSAJESSINLEER integer,
    CUENTAMENSAJESSINLEERRESTR integer,
    CUENTAMENSAJESSINLEERADM integer,
    CUENTAMENSAJESSINLEERADMRESTR integer,
    ERRORCODE D_ERRORCODE)
as
BEGIN

SELECT COUNT(*)
from
(
SELECT        MENSAJE.ID
FROM            MENSAJE LEFT OUTER JOIN
                         MENSAJEUSUARIO ON MENSAJE.ID = MENSAJEUSUARIO.IDMENSAJE
                         AND MENSAJEUSUARIO.PERSONAID = :USUARIOID
                         LEFT OUTER JOIN
                         MENSAJEAREA ON MENSAJE.ID = MENSAJEAREA.IDMENSAJE
                         LEFT OUTER JOIN
                         AREADERECHOS ON AREADERECHOS.idarea = MENSAJEAREA.id  
                         LEFT OUTER JOIN
                         usuario_perfil ON USUARIO_PERFIL.up_personaid = :USUARIOID
                         LEFT OUTER JOIN
                         PERFIL_DER ON PERFIL_DER.pd_perfil = USUARIO_PERFIL.up_perfil AND PERFIL_DER.pd_derecho = AREADERECHOS.idderecho


WHERE        (MENSAJE.MENSAJETIPOID = 1) AND (:USUARIOESADMIN = 'S' or  MENSAJE.SOLOADMIN <> 'S')
and
(CASE WHEN MENSAJEUSUARIO.MENSAJEESTADOID IS NULL THEN 2 ELSE MENSAJEUSUARIO.MENSAJEESTADOID END) = 2 
AND
(COALESCE(MENSAJE.paratodasareas ,'S' ) = 'S' or coalesce(perfil_der.pd_derecho,0) <> 0 )
GROUP BY MENSAJE.id
)
INTO  :CUENTAMENSAJESSINLEER;



SELECT COUNT(*)
from
(
SELECT MENSAJE.ID
FROM            MENSAJE       
                         LEFT OUTER JOIN
                         MENSAJEAREA ON MENSAJE.ID = MENSAJEAREA.IDMENSAJE
                         LEFT OUTER JOIN
                         AREADERECHOS ON AREADERECHOS.idarea = MENSAJEAREA.id  
                         LEFT OUTER JOIN
                         usuario_perfil ON USUARIO_PERFIL.up_personaid = :USUARIOID
                         LEFT OUTER JOIN
                         PERFIL_DER ON PERFIL_DER.pd_perfil = USUARIO_PERFIL.up_perfil AND PERFIL_DER.pd_derecho = AREADERECHOS.idderecho

WHERE        MENSAJE.MENSAJETIPOID = 1 AND :USUARIOESADMIN = 'N' and  MENSAJE.SOLOADMIN = 'S'
AND COALESCE(MENSAJE.MENSAJEESTADOID,2) = 2         
AND
(COALESCE(MENSAJE.paratodasareas ,'S' ) = 'S' or coalesce(perfil_der.pd_derecho,0) <> 0 )
GROUP BY MENSAJE.id
)INTO  :CUENTAMENSAJESSINLEERADM;


SELECT COUNT(*)
from
(
SELECT        MENSAJE.ID
FROM            MENSAJE LEFT OUTER JOIN
                         MENSAJEUSUARIO ON MENSAJE.ID = MENSAJEUSUARIO.IDMENSAJE
                         AND MENSAJEUSUARIO.PERSONAID = :USUARIOID  
                         LEFT OUTER JOIN
                         MENSAJEAREA ON MENSAJE.ID = MENSAJEAREA.IDMENSAJE
                         LEFT OUTER JOIN
                         AREADERECHOS ON AREADERECHOS.idarea = MENSAJEAREA.id  
                         LEFT OUTER JOIN
                         usuario_perfil ON USUARIO_PERFIL.up_personaid = :USUARIOID
                         LEFT OUTER JOIN
                         PERFIL_DER ON PERFIL_DER.pd_perfil = USUARIO_PERFIL.up_perfil AND PERFIL_DER.pd_derecho = AREADERECHOS.idderecho

WHERE        (MENSAJE.MENSAJETIPOID = 1) AND (:USUARIOESADMIN = 'S' or  MENSAJE.SOLOADMIN <> 'S')
AND MENSAJE.RESTRICTIVO = 'S' 
and (CASE WHEN MENSAJEUSUARIO.MENSAJEESTADOID IS NULL THEN 2 ELSE MENSAJEUSUARIO.MENSAJEESTADOID END) = 2 
AND
(COALESCE(MENSAJE.paratodasareas ,'S' ) = 'S' or coalesce(perfil_der.pd_derecho,0) <> 0 )
GROUP BY MENSAJE.id
)INTO  :CUENTAMENSAJESSINLEERRESTR;


SELECT COUNT(*)
from
(
SELECT        MENSAJE.ID
FROM            MENSAJE        
                         LEFT OUTER JOIN
                         MENSAJEAREA ON MENSAJE.ID = MENSAJEAREA.IDMENSAJE
                         LEFT OUTER JOIN
                         AREADERECHOS ON AREADERECHOS.idarea = MENSAJEAREA.id  
                         LEFT OUTER JOIN
                         usuario_perfil ON USUARIO_PERFIL.up_personaid = :USUARIOID
                         LEFT OUTER JOIN
                         PERFIL_DER ON PERFIL_DER.pd_perfil = USUARIO_PERFIL.up_perfil AND PERFIL_DER.pd_derecho = AREADERECHOS.idderecho

WHERE        MENSAJE.MENSAJETIPOID = 1 AND :USUARIOESADMIN = 'N' and  MENSAJE.SOLOADMIN = 'S'
AND MENSAJE.RESTRICTIVO = 'S'   
AND COALESCE(MENSAJE.MENSAJEESTADOID,2) = 2    
AND
(COALESCE(MENSAJE.paratodasareas ,'S' ) = 'S' or coalesce(perfil_der.pd_derecho,0) <> 0 )
GROUP BY MENSAJE.id
)
INTO  :CUENTAMENSAJESSINLEERADMRESTR;



   ERRORCODE = 0;
   SUSPEND;


   WHEN ANY DO
    BEGIN
        ERRORCODE = 1009;
        SUSPEND;
    END
END