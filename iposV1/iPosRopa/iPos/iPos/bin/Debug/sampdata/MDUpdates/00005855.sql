CREATE OR ALTER trigger doctopago_aiu99_comision for doctopago
active before insert or update position 99
AS
declare variable ABONO d_precio;
declare variable TIPODOCTOID d_fk;
declare variable SUBTIPODOCTOID d_fk;
declare variable ABONA d_boolcn;
declare variable DOCTOIDBUFFER D_FK;
declare variable VIGENCIA D_FECHA;
declare variable DIAS_EXTR D_DIAS;
declare variable DOCTOCOMISION D_PRECIO;
declare variable DOCTOTOTAL D_PRECIO; 
declare variable ES_UPDATE D_BOOLCN;   
declare variable CAMBIARONDATOS D_BOOLCN;

BEGIN

      
   ES_UPDATE = CASE WHEN OLD.ID IS NOT NULL THEN 'S' ELSE 'N' END;
   CAMBIARONDATOS =  CASE WHEN COALESCE(:ES_UPDATE,'N') = 'N' THEN 'S'
                        ELSE
                             CASE WHEN
                                COALESCE(NEW.IMPORTE,0) = COALESCE(OLD.IMPORTE,0) AND
                                COALESCE(NEW.APLICADO,'N') = COALESCE(OLD.APLICADO,'N') AND
                                COALESCE(NEW.DEVUELTO,'N') = COALESCE(OLD.DEVUELTO,'N') THEN
                                    'S'
                                ELSE
                                    'N'
                                END
                      END;



   IF(
        NEW.formapagoid not IN (1,2,3,5,15,20,21) OR
        (
            COALESCE(:CAMBIARONDATOS,'N') = 'N'
            )  OR
      (NEW.FORMAPAGOID = 3 AND (COALESCE(NEW.APLICADO,'N') = 'N' OR COALESCE(NEW.DEVUELTO,'N') = 'S') ) OR
      COALESCE(NEW.ESAPARTADO,'N') = 'S' OR
      COALESCE(NEW.TIPOPAGOID ,0) <> 1
      ) THEN
   BEGIN
        EXIT;
   END


   
   SELECT docto.tipodoctoid , persona.vigencia, persona.dias_extr , docto.subtipodoctoid,
          docto.comision, docto.total
    from docto
    left join persona on persona.id = docto.personaid
    where  DOCTO.id = NEW.DOCTOID
    INTO :TIPODOCTOID, :VIGENCIA, :DIAS_EXTR, :SUBTIPODOCTOID, :DOCTOCOMISION, :DOCTOTOTAL;

   IF(COALESCE(:TIPODOCTOID,0) NOT IN (21) OR  COALESCE(:SUBTIPODOCTOID,0) IN (13,7,8)) THEN
   BEGIN
        EXIT;

   END

   NEW.COMISION2 = CAST(COALESCE(NEW.IMPORTE,0) * CAST((COALESCE(:DOCTOCOMISION,0) / COALESCE(:DOCTOTOTAL,0)) AS D_PRECIO) AS D_PRECIO);



END