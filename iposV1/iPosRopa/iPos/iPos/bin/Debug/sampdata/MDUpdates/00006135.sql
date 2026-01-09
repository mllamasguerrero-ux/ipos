CREATE OR ALTER trigger movto_bu99_nutil for movto
active before update position 99
AS
declare variable NUTIL D_PORCENTAJE;   
declare variable COMISION D_PRECIO;
declare variable COMISIONPORC D_PORCENTAJE;  
declare variable NPREC D_PORCENTAJE;
declare variable CDESCR D_PORCENTAJE;
declare variable VERSIONCOMISIONID d_fk;
declare variable subtipodoctoid d_fk; 
declare variable EMIDAUTILIDADPAGOSERVICIOS  D_PRECIO;


declare variable TASAIVA D_PORCENTAJE;
declare variable TASAIEPS D_PORCENTAJE; 
declare variable TASAIMPUESTO D_PORCENTAJE;
declare variable PZACAJA  D_CANTIDAD;
declare variable DESCPES  D_PORCENTAJE;
declare variable PROVEEDORCLAVE D_CLAVE_NULL;
declare variable ADESCPES D_PRECIO;
declare variable PRECIO1 D_PRECIO;

declare variable POR_COME D_PORCENTAJE;

declare variable RANGOENCONTRADO D_BOOLCN;
declare variable CUENTABUFFER INTEGER; 
declare variable COMISIONPORCBUFFER D_PORCENTAJE;
declare variable PERSONAID D_FK;

begin
  /* Trigger text */
               
   if(new.estatusmovtoid = 1 and old.estatusmovtoid = 0) then
   begin
          select subtipodoctoid from docto where id = new.doctoid into :subtipodoctoid;  
          subtipodoctoid = coalesce(:subtipodoctoid, 0);

          SELECT PARAMETRO.VERSIONCOMISIONID FROM PARAMETRO INTO :VERSIONCOMISIONID;

          IF(COALESCE(:VERSIONCOMISIONID,1) <> 2) THEN
          BEGIN
                EXIT;
          END



        if( (NEW.TIPODOCTOID IN (21,23,25,26) and :subtipodoctoid NOT IN (24,7,8)) or (new.tipodoctoid in (22,24) and :subtipodoctoid NOT IN (13,7,8)) ) then
        begin

                  
          SELECT  COALESCE(PRODUCTO.PZACAJA,0), COALESCE(PRODUCTO.DESCPES,0),
                    COALESCE(PROVEEDOR.CLAVE,0), COALESCE(PROVEEDOR.ADESCPES,0), COALESCE(PRODUCTO.PRECIO1,0)
          FROM PRODUCTO
          LEFT JOIN PERSONA PROVEEDOR ON PROVEEDOR.ID = PRODUCTO.PROVEEDOR1ID
          WHERE PRODUCTO.ID = NEW.PRODUCTOID
          INTO :PZACAJA, :DESCPES, :PROVEEDORCLAVE, :ADESCPES, :PRECIO1;


           SELECT COALESCE(PERSONA.POR_COME, 0) POR_COME
           FROM DOCTO
           INNER JOIN PERSONA ON PERSONA.ID = DOCTO.PERSONAID
           WHERE DOCTO.ID = NEW.DOCTOID
           INTO  :POR_COME;

          
           TASAIVA = COALESCE(NEW.TASAIVA,0);
           TASAIEPS = COALESCE(NEW.TASAIEPS,0);
           TASAIMPUESTO =  CAST(COALESCE(:TASAIEPS,0.00) + COALESCE(:TASAIVA,0.00)  + CAST(((COALESCE(:TASAIEPS,0.00) * COALESCE(:TASAIVA,0.00)) / 100.00) AS D_PORCENTAJE) AS D_PORCENTAJE) ;


             SELECT VERSIONCOMISIONID FROM PARAMETRO INTO :VERSIONCOMISIONID;


             NPREC =
                CAST(
                       CAST(  ( COALESCE(NEW.TOTALCONREBAJA,0.00) / CASE WHEN COALESCE(NEW.CANTIDAD, 0.00) = 0.00 THEN 1.00 ELSE NEW.CANTIDAD END)
                                --CAST( (:PRECIO1 * (1.00  - COALESCE(NEW.DESCUENTOPORCENTAJE,0)/100.00)) AS D_PRECIO ) *
                                --CAST( (1.00 + :TASAIMPUESTO/100.00) AS  D_PRECIO)

                            AS D_PRECIO)
                                    * :PZACAJA
                       AS D_PRECIO ) ;

                       /*insert into traza(valor) values(' cr ' || cast(coalesce(NEW.COSTOREPOSICION,0) as varchar(20)));

                       insert into traza(valor) values(' dp ' || cast(COALESCE(:DESCPES,0) as varchar(20)));
                       insert into traza(valor) values(' adp ' || cast(COALESCE(:ADESCPES,0) as varchar(20)));
                       insert into traza(valor) values(' pc ' || cast(coalesce(:pzacaja,0) as varchar(20)));
                       insert into traza(valor) values(' ti ' || cast(coalesce(:TASAIMPUESTO,0) as varchar(20))); */

             CDESCR =
                    CAST(
                      CAST(
                            CAST(
                                    COALESCE(NEW.COSTOREPOSICION,0.00)  *
                                    CAST( (1.00 - ((COALESCE(:DESCPES,0) + COALESCE(:ADESCPES,0))/100.00) ) AS D_PRECIO )
                                  AS D_PRECIO)
                                   *  :pzacaja
                            AS D_PRECIO
                       ) *
                        ( 1.00 + :TASAIMPUESTO/100.00)
                        AS D_PRECIO) ;






             NUTIL = CASE WHEN  COALESCE(:NPREC,0.00) > 0 THEN
                           CAST(ROUND(
                                100.00 - ( ( COALESCE(:CDESCR,0.00)/COALESCE(:NPREC,0.00) ) * 100.00)
                                , 2) AS D_PORCENTAJE)
                         ELSE 0.00
                    END;

             NEW.NUTIL = :NUTIL;
             NEW.CDESCR = :CDESCR;
             NEW.NPREC = :NPREC;


             RANGOENCONTRADO = 'N';

             IF(COALESCE(:POR_COME,0) > 0) THEN
             BEGIN

                SELECT COUNT(*) CUENTABUFFER, MIN(COALESCE(COMISION_CALC_V2.COMISION,0))  COMISIONPORCBUFFER
                FROM COMISION_CALC_V2
                 WHERE COALESCE(PROVEEDORCLAVE,'') =  COALESCE(:PROVEEDORCLAVE,'')  AND
                       COALESCE(CLIENTEPORCOME,'N') = 'S' AND
                       MARGENMIN <= :NUTIL AND (MARGENMAX > :NUTIL  OR MARGENMAX < 0)
                INTO :CUENTABUFFER, :COMISIONPORCBUFFER;

                IF(COALESCE(:CUENTABUFFER,0) > 0) THEN
                BEGIN 
                    RANGOENCONTRADO = 'S';
                    COMISIONPORC = CASE WHEN COALESCE(:COMISIONPORCBUFFER,0) = -2 THEN COALESCE(:POR_COME,0) ELSE COALESCE(:COMISIONPORCBUFFER,0) END ;

                END


                IF(COALESCE(:RANGOENCONTRADO,'N') = 'N') THEN
                BEGIN
                
                    SELECT COUNT(*) CUENTABUFFER, MIN(COALESCE(COMISION_CALC_V2.COMISION,0))  COMISIONPORCBUFFER
                    FROM COMISION_CALC_V2
                    WHERE COALESCE(PROVEEDORCLAVE,'') = ''  AND
                       COALESCE(CLIENTEPORCOME,'N') = 'S' AND
                       MARGENMIN <= :NUTIL AND (MARGENMAX > :NUTIL  OR MARGENMAX < 0)
                    INTO :CUENTABUFFER, :COMISIONPORCBUFFER;

                    IF(COALESCE(:CUENTABUFFER,0) > 0) THEN
                    BEGIN 
                        RANGOENCONTRADO = 'S';
                        COMISIONPORC = CASE WHEN COALESCE(:COMISIONPORCBUFFER,0) = -2 THEN COALESCE(:POR_COME,0) ELSE COALESCE(:COMISIONPORCBUFFER,0) END ;

                    END
                END


             END



             
             IF(COALESCE(:RANGOENCONTRADO,'N') = 'N') THEN
             BEGIN

                SELECT COUNT(*) CUENTABUFFER, MIN(COALESCE(COMISION_CALC_V2.COMISION,0))  COMISIONPORCBUFFER
                FROM COMISION_CALC_V2
                 WHERE COALESCE(PROVEEDORCLAVE,'') =  COALESCE(:PROVEEDORCLAVE,'')  AND
                       COALESCE(CLIENTEPORCOME,'N') = 'N' AND
                       MARGENMIN <= :NUTIL AND (MARGENMAX > :NUTIL  OR MARGENMAX < 0)
                INTO :CUENTABUFFER, :COMISIONPORCBUFFER;

                IF(COALESCE(:CUENTABUFFER,0) > 0) THEN
                BEGIN 
                    RANGOENCONTRADO = 'S';
                    COMISIONPORC = CASE WHEN COALESCE(:COMISIONPORCBUFFER,0) = -2 THEN COALESCE(:POR_COME,0) ELSE COALESCE(:COMISIONPORCBUFFER,0) END ;

                END


                IF(COALESCE(:RANGOENCONTRADO,'N') = 'N') THEN
                BEGIN
                
                    SELECT COUNT(*) CUENTABUFFER, MIN(COALESCE(COMISION_CALC_V2.COMISION,0))  COMISIONPORCBUFFER
                    FROM COMISION_CALC_V2
                    WHERE COALESCE(PROVEEDORCLAVE,'') = ''  AND
                       COALESCE(CLIENTEPORCOME,'N') = 'N' AND
                       MARGENMIN <= :NUTIL AND (MARGENMAX > :NUTIL  OR MARGENMAX < 0)
                    INTO :CUENTABUFFER, :COMISIONPORCBUFFER;

                    IF(COALESCE(:CUENTABUFFER,0) > 0) THEN
                    BEGIN 
                        RANGOENCONTRADO = 'S';
                        COMISIONPORC = CASE WHEN COALESCE(:COMISIONPORCBUFFER,0) = -2 THEN COALESCE(:POR_COME,0) ELSE COALESCE(:COMISIONPORCBUFFER,0) END ;

                    END
                END
             END

             NEW.COMISIONPORC = COALESCE(:COMISIONPORC,0);
             NEW.COMISION = round(CAST((COALESCE(:COMISIONPORC, 0)/100.00) * NEW.TOTAL AS D_PRECIO),2);



         end



   end

end