CREATE OR ALTER TRIGGER DOCTOPAGO_AIU0 FOR DOCTOPAGO
ACTIVE AFTER INSERT OR UPDATE POSITION 0
AS
declare variable ABONO d_precio;  
declare variable ABONOTARJETA d_precio;
declare variable TIPODOCTOIDENTRADA d_fk;
declare variable TIPODOCTOIDSALIDA d_fk;
declare variable ABONA d_boolcn;
declare variable AFECTASALDOPERSONA D_BOOLCN ;
declare variable SENTIDO d_precio;
declare variable PERSONAIDENTRADA D_FK;
declare variable PERSONAIDSALIDA D_FK;
declare variable DOCTOIDBUFFER D_FK;
declare variable SALDOBUFFER D_PRECIO;   
declare variable RESTANTEBUFFER D_PRECIO;
declare variable abono_aux d_precio;   
declare variable FACTCONSID D_FK;
declare variable VENTAFUTUIDENTRADA D_FK;
declare variable SUBTIPODOCTOIDENTRADA D_FK;

declare variable ES_UPDATE D_BOOLCN;
declare variable ES_DESAPLICACION D_BOOLCN; 
declare variable ES_POSTAPLICACION D_BOOLCN; 
declare variable ES_APLICACIONINICIAL D_BOOLCN;
declare variable ES_NOAPLICACIONINICIAL  D_BOOLCN;
declare variable SOLOABONOAPLICADO D_BOOLCN; 
declare variable ABONONOAPLICADO d_precio;
declare variable IMPORTEAPLICAR d_precio;
declare variable IMPORTENOAPLICAR d_precio;
declare variable SENTIDOPORAPLICACION d_precio; 
declare variable SENTIDOPORNOAPLICACION d_precio;

BEGIN


   IF(NEW.formapagoid IN (18,19)) THEN
   BEGIN
    EXIT;
   END

   ES_UPDATE = CASE WHEN OLD.ID IS NOT NULL THEN 'S' ELSE 'N' END;


-- Los pagos de apartados no se procesan aqui
IF(NEW.ESAPARTADO = 'N' ) THEN
BEGIN

   SELECT tipodoctoid from docto where  id = NEW.DOCTOID  INTO :TIPODOCTOIDENTRADA;
   SELECT tipodoctoid from docto where  id = NEW.DOCTOSALIDAID  INTO :TIPODOCTOIDSALIDA;

   if(:TIPODOCTOIDENTRADA  in (11,12,13,15,60,16,18,202,204) or :TIPODOCTOIDSALIDA in (11,12,13,15,60,16,18,202,204)) then
   begin
     exit;
   end

   --si es update solo manejariamos aqui cuando aplique y desaplique  
   SELECT FIRST 1  SOLOABONOAPLICADO FROM PARAMETRO INTO :SOLOABONOAPLICADO;
   IF(COALESCE(:ES_UPDATE,'N') = 'S' AND COALESCE(OLD.APLICADO,'N') = COALESCE(NEW.APLICADO,'N')
        AND COALESCE(:SOLOABONOAPLICADO,'N') = 'S') THEN
   BEGIN
        EXIT;
   END


   SELECT abona, afectasaldopersona from formapago where id = new.formapagoid into :ABONA,:AFECTASALDOPERSONA;
   SELECT personaid, subtipodoctoid, ventafutuid FROM DOCTO WHERE ID = NEW.DOCTOID INTO :PERSONAIDENTRADA, :SUBTIPODOCTOIDENTRADA, :VENTAFUTUIDENTRADA;
   SELECT personaid FROM DOCTO WHERE ID = NEW.DOCTOSALIDAID INTO :PERSONAIDSALIDA;

   --APLICADO Y NO APLICADO
   --BEGIN
   ES_DESAPLICACION =  CASE WHEN COALESCE(:ES_UPDATE,'N') = 'S' AND COALESCE(:SOLOABONOAPLICADO,'N') = 'S' AND NEW.FORMAPAGOID = 3 AND
                                 COALESCE(OLD.APLICADO,'N') = 'S' AND COALESCE(NEW.APLICADO,'N') = 'N'
                                 THEN 'S' ELSE 'N' END;
   ES_POSTAPLICACION =  CASE WHEN COALESCE(:ES_UPDATE,'N') = 'S' AND COALESCE(:SOLOABONOAPLICADO,'N') = 'S' AND NEW.FORMAPAGOID = 3 AND
                                 COALESCE(OLD.APLICADO,'N') = 'N' AND COALESCE(NEW.APLICADO,'N') = 'S'
                                 THEN 'S' ELSE 'N' END;
   ES_APLICACIONINICIAL =  CASE WHEN COALESCE(:ES_UPDATE,'N') = 'N' AND (COALESCE(:SOLOABONOAPLICADO,'N') = 'N' OR COALESCE(NEW.APLICADO,'N') = 'S' OR NEW.FORMAPAGOID <> 3)THEN 'S' ELSE 'N' END;
   ES_NOAPLICACIONINICIAL =  CASE WHEN COALESCE(:ES_UPDATE,'N') = 'N' AND COALESCE(:ES_APLICACIONINICIAL,'N') = 'N' THEN 'S' ELSE 'N' END;
   --END



   IF(:ABONA = 'S') then
   begin
       --if (:TIPODOCTOIDENTRADA IN (21,24,25) AND (NEW.formapagoid in (6,7) or NEW.tipopagoid = 1 ) ) THEN
        IF(NEW.DOCTOID  IS NOT NULL) THEN
       BEGIN

           /*repeticion codigo 1*/
          select coalesce(sum(
           p.importe *
            (
                CASE WHEN ((TIPOPAGOID = 1 AND FORMAPAGOID IN (1,2,3,4,5,14,15,16,17,18,20,21)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (7,19)))  THEN 1
                    when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6,18))) THEN -1      
                    --  por la aplicacion de saldo a ventas sobrepagadas
                    when TIPOPAGOID = 1 and formapagoid = 6 and  p.doctosalidaid = NEW.DOCTOID  then -1
                    when TIPOPAGOID = 1 and formapagoid = 6 and  p.doctoid = NEW.DOCTOID  then 1
                    --  fin por la aplicacion de saldo a ventas sobrepagadas
                ELSE 0 END
            ) *
            (
                CASE WHEN COALESCE(:SOLOABONOAPLICADO,'N') = 'N' OR COALESCE(APLICADO,'N') = 'S' OR FORMAPAGOID <> 3 THEN 1
                ELSE 0 END
             )
          ),0) ABONO ,

          coalesce(sum(p.importe *
          (CASE WHEN ((TIPOPAGOID = 1 AND FORMAPAGOID IN (2)) )   THEN 1
                ELSE 0 END)
          ),0) ABONOTARJETA  ,

          coalesce(sum(
           p.importe *
            (
                CASE WHEN ((TIPOPAGOID = 1 AND FORMAPAGOID IN (1,2,3,4,5,6,14,15,16,17,18,20,21)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (7,19)))  THEN 1
                    when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6,18))) THEN -1
                ELSE 0 END
            ) *
            (
                CASE WHEN COALESCE(:SOLOABONOAPLICADO,'N') = 'N' OR COALESCE(APLICADO,'N') = 'S' OR FORMAPAGOID <> 3 THEN 0
                ELSE 1 END
             )
          ),0) ABONONOAPLICADO

           from doctopago p inner join formapago f on p.formapagoid = f.id
          where (p.doctoid = new.doctoid or p.doctosalidaid = new.doctoid ) and f.abona = 'S' into :abono, :ABONOTARJETA, :ABONONOAPLICADO;


                       /* anticipo */
          if(  :TIPODOCTOIDENTRADA = 203) then
          begin
                select coalesce(sum(p.importe *
                (
                    CASE WHEN ((TIPOPAGOID = 2 AND FORMAPAGOID IN (1,2,3,4,5,7,14,15,16,17,19,20,21)) or (TIPOPAGOID = 1 AND FORMAPAGOID IN (6,18)))  THEN 1
                        when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6,18)))  THEN -1
                    ELSE 0 END)  *
                (
                    CASE WHEN COALESCE(:SOLOABONOAPLICADO,'N') = 'N' OR COALESCE(APLICADO,'N') = 'S' OR FORMAPAGOID <> 3 THEN 1
                    ELSE 0 END
                )
                ),0) from doctopago p inner join formapago f on p.formapagoid = f.id
                where p.doctosalidaid = new.doctoid and f.abona = 'S' into :abono_aux;
                abono = :abono_aux - :abono;
          end


          UPDATE DOCTO SET ABONO = :ABONO , SALDO = CARGO - :ABONO, ABONONOAPLICADO = :ABONONOAPLICADO, ABONOTARJETA = :ABONOTARJETA WHERE ID = NEW.DOCTOID;

          
          /*fin repeticion codigo 1*/

          SELECT FACTCONSID FROM DOCTO WHERE ID = NEW.DOCTOID INTO :FACTCONSID;
          IF(COALESCE(:FACTCONSID,0) > 0 ) THEN
          BEGIN

            --APLICADO Y NO APLICADO
            --BEGIN
            IMPORTEAPLICAR =  0;
            IMPORTENOAPLICAR = 0;

            IF(COALESCE(:ES_DESAPLICACION,'N') = 'S') THEN
            BEGIN  
                IMPORTEAPLICAR =  NEW.IMPORTE * -1;
                IMPORTENOAPLICAR = NEW.IMPORTE ;
            END
            ELSE IF(COALESCE(:ES_POSTAPLICACION,'N') = 'S') THEN
            BEGIN  
                IMPORTEAPLICAR =  NEW.IMPORTE;
                IMPORTENOAPLICAR = NEW.IMPORTE * -1;
            END
            ELSE IF( COALESCE(:ES_APLICACIONINICIAL,'N') = 'S') THEN
            BEGIN      
                IMPORTEAPLICAR =  NEW.IMPORTE;
            END
            ELSE IF( COALESCE(:ES_NOAPLICACIONINICIAL,'N') = 'S') THEN
            BEGIN      
                IMPORTENOAPLICAR =  NEW.IMPORTE;
            END
            --END


            UPDATE DOCTO SET ABONO = COALESCE(ABONO,0) + :IMPORTEAPLICAR,
                             ABONONOAPLICADO = COALESCE(:ABONONOAPLICADO,0) + COALESCE(:IMPORTENOAPLICAR,0),
                              SALDO = COALESCE(CARGO,0) - (COALESCE(ABONO,0) + :IMPORTEAPLICAR),
                              ABONOTARJETA = :ABONOTARJETA WHERE ID = :FACTCONSID;
          END


       END


       FACTCONSID = 0;
       
       --if (:TIPODOCTOIDSALIDA = 22 AND (NEW.formapagoid  in (6,7) or NEW.tipopagoid = 2 )) THEN
       IF(NEW.DOCTOSALIDAID  IS NOT NULL) THEN
       BEGIN
          select coalesce(sum(p.importe *
                (
                CASE WHEN ((TIPOPAGOID = 2 AND FORMAPAGOID IN (1,2,3,4,5,7,14,15,16,17,19,20,21)) or (TIPOPAGOID = 1 AND FORMAPAGOID IN (6,18)))  THEN 1
                when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6,18)))  THEN -1
                ELSE 0 END
                )  *
                (
                CASE WHEN COALESCE(:SOLOABONOAPLICADO,'N') = 'N' OR COALESCE(APLICADO,'N') = 'S' OR FORMAPAGOID <> 3 THEN 1
                ELSE 0 END
                )
          ),0) abono,  

          coalesce(sum(p.importe *
          (CASE WHEN ((TIPOPAGOID = 1 AND FORMAPAGOID IN (2)) )   THEN 1
                ELSE 0 END)
          ),0) ABONOTARJETA  ,

          
          coalesce(sum(p.importe *
                (
                CASE WHEN ((TIPOPAGOID = 2 AND FORMAPAGOID IN (1,2,3,4,5,7,14,15,16,17,19,20,21)) or (TIPOPAGOID = 1 AND FORMAPAGOID IN (6,18)))  THEN 1
                when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6,18)))  THEN -1
                ELSE 0 END)
                *
                (
                CASE WHEN COALESCE(:SOLOABONOAPLICADO,'N') = 'N' OR COALESCE(APLICADO,'N') = 'S' OR FORMAPAGOID <> 3 THEN 0
                ELSE 1 END
                )
          ),0) ABONONOAPLICADO from doctopago p inner join formapago f on p.formapagoid = f.id
          where p.doctosalidaid = new.doctosalidaid and f.abona = 'S' into :abono, :ABONOTARJETA , :ABONONOAPLICADO;

          /* anticipo */
          if(  :TIPODOCTOIDSALIDA in  (201)) then
          begin
                select coalesce(sum(p.importe *
                (CASE WHEN ((TIPOPAGOID = 1 AND FORMAPAGOID IN (1,2,3,4,5,6,14,15,16,17,18,20,21)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (7,19)))  THEN 1
                    when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6,18))) THEN -1
                    ELSE 0 END)
                    *
                    (
                        CASE WHEN COALESCE(:SOLOABONOAPLICADO,'N') = 'N' OR COALESCE(APLICADO,'N') = 'S' OR FORMAPAGOID <> 3 THEN 1
                        ELSE 0 END
                    )
                ),0) from doctopago p inner join formapago f on p.formapagoid = f.id
                where p.doctoid = new.doctosalidaid and f.abona = 'S' into :abono_aux;
                abono = :abono_aux - :abono;
          end


          UPDATE DOCTO SET ABONO = :ABONO , SALDO = CARGO - :ABONO, ABONONOAPLICADO = :ABONONOAPLICADO WHERE ID = NEW.DOCTOSALIDAID;
          
          SELECT FACTCONSID FROM DOCTO WHERE ID = NEW.DOCTOSALIDAID INTO :FACTCONSID;
          IF(COALESCE(:FACTCONSID,0) > 0 ) THEN
          BEGIN

          
            --APLICADO Y NO APLICADO
            --BEGIN
            IMPORTEAPLICAR =  0;
            IMPORTENOAPLICAR = 0;

            IF(COALESCE(:ES_DESAPLICACION,'N') = 'S') THEN
            BEGIN  
                IMPORTEAPLICAR =  NEW.IMPORTE * -1;
                IMPORTENOAPLICAR = NEW.IMPORTE ;
            END
            ELSE IF(COALESCE(:ES_POSTAPLICACION,'N') = 'S') THEN
            BEGIN  
                IMPORTEAPLICAR =  NEW.IMPORTE;
                IMPORTENOAPLICAR = NEW.IMPORTE * -1;
            END
            ELSE IF( COALESCE(:ES_APLICACIONINICIAL,'N') = 'S') THEN
            BEGIN      
                IMPORTEAPLICAR =  NEW.IMPORTE;
            END
            ELSE IF( COALESCE(:ES_NOAPLICACIONINICIAL,'N') = 'S') THEN
            BEGIN      
                IMPORTENOAPLICAR =  NEW.IMPORTE;
            END
            --END
                      
            UPDATE DOCTO SET ABONO = COALESCE(ABONO,0) + :IMPORTEAPLICAR,
                             ABONONOAPLICADO = COALESCE(:ABONONOAPLICADO,0) + COALESCE(:IMPORTENOAPLICAR,0),
                              SALDO = COALESCE(CARGO,0) - (COALESCE(ABONO,0) + :IMPORTEAPLICAR) WHERE ID = :FACTCONSID;

          END

       END

    END

    
     --ESTO SOLO APLICA SI ES INSERT
    IF(COALESCE(:ES_UPDATE,'N') = 'N') THEN
    BEGIN

     IF(:afectasaldopersona  = 'S') THEN
     BEGIN

       IF(new.tipopagoid = 1) then
       begin
            SENTIDO = 1.00;
       end
       ELSE IF(new.tipopagoid = 2) THEN
       BEGIN
            SENTIDO = -1.00;
       END
       else
       begin
          SENTIDO = 0;
       end

       
       --APLICADO Y NO APLICADO
        --BEGIN
       SENTIDOPORAPLICACION = 1;
       SENTIDOPORNOAPLICACION = 0;
       IF(COALESCE(:ES_DESAPLICACION,'N') = 'S') THEN
       BEGIN
            SENTIDOPORAPLICACION = -1; 
            SENTIDOPORNOAPLICACION = 1;
       END
       ELSE IF(COALESCE(:ES_POSTAPLICACION,'N') = 'S')  THEN
       BEGIN
            SENTIDOPORAPLICACION = 1; 
            SENTIDOPORNOAPLICACION = -1;
       END    
       ELSE IF( COALESCE(:ES_APLICACIONINICIAL,'N') = 'S') THEN
       BEGIN
            SENTIDOPORAPLICACION = 1; 
            SENTIDOPORNOAPLICACION = 0;
       END
       ELSE IF(COALESCE(:ES_NOAPLICACIONINICIAL,'N') = 'S') THEN
       BEGIN    
            SENTIDOPORAPLICACION = 0;  
            SENTIDOPORNOAPLICACION = 1;
            
       END


     
        if (:TIPODOCTOIDENTRADA IN (21,24,25,201,31) AND NEW.TIPOPAGOID = 1 AND COALESCE(:PERSONAIDENTRADA,0) <> 0) THEN
        BEGIN
           UPDATE PERSONA SET SALDO = coalesce(SALDO,0) + (NEW.IMPORTE * :SENTIDO * :SENTIDOPORAPLICACION) ,
                              ABONONOAPLICADO =  coalesce(ABONONOAPLICADO,0) + (NEW.IMPORTE * :SENTIDO * :SENTIDOPORNOAPLICACION)
                    WHERE ID = :PERSONAIDENTRADA;
        END
        ELSE if (:TIPODOCTOIDSALIDA in (22,23,203,33)  AND NEW.TIPOPAGOID = 2 AND COALESCE(:PERSONAIDSALIDA,0) <> 0) then
        BEGIN
           UPDATE PERSONA SET SALDO = coalesce(SALDO,0) + (NEW.IMPORTE * :SENTIDO * :SENTIDOPORAPLICACION) ,
                              ABONONOAPLICADO =  coalesce(ABONONOAPLICADO,0) + (NEW.IMPORTE * :SENTIDO * :SENTIDOPORNOAPLICACION) WHERE ID = :PERSONAIDSALIDA;
        END
     END



     RESTANTEBUFFER =   NEW.IMPORTE;





      --APLICACION CREIDTO
     IF(NEW.FORMAPAGOID = 4 AND NEW.TIPOPAGOID = 2 AND :TIPODOCTOIDSALIDA in (22) AND :RESTANTEBUFFER > 0
        AND NEW.tipoaplicacioncreditoid = 2 AND NEW.DOCTOID IS NOT NULL) THEN
     BEGIN
            SELECT D.ID, D.SALDO
            FROM DOCTO D
            WHERE D.SALDO > 0 AND D.ID = NEW.doctoid
            INTO   :DOCTOIDBUFFER, :SALDOBUFFER;

            IF(:DOCTOIDBUFFER IS NOT NULL AND COALESCE(:SALDOBUFFER,0)>0) THEN
            BEGIN
            
              IF(:RESTANTEBUFFER > :SALDOBUFFER) THEN
              BEGIN
                 INSERT INTO DOCTOPAGO ( DOCTOID, FORMAPAGOID, FECHA, FECHAHORA, CORTEID, IMPORTE, IMPORTERECIBIDO, IMPORTECAMBIO, TIPOPAGOID, DOCTOSALIDAID)
                             VALUES (:DOCTOIDBUFFER, 6, NEW.FECHA, NEW.FECHAHORA,NEW.CORTEID, :SALDOBUFFER,:SALDOBUFFER, 0, 1, NEW.DOCTOSALIDAID);
                  RESTANTEBUFFER = :RESTANTEBUFFER - :SALDOBUFFER;
              END
              ELSE
              BEGIN
                  
                   INSERT INTO DOCTOPAGO ( DOCTOID, FORMAPAGOID, FECHA, FECHAHORA, CORTEID, IMPORTE, IMPORTERECIBIDO, IMPORTECAMBIO, TIPOPAGOID, DOCTOSALIDAID)
                             VALUES (:DOCTOIDBUFFER, 6, NEW.FECHA, NEW.FECHAHORA,NEW.CORTEID, :RESTANTEBUFFER,:RESTANTEBUFFER, 0, 1, NEW.DOCTOSALIDAID);
                    RESTANTEBUFFER = 0;
              END
            END


     END


       --MANEJO DE ANTICIPIOS DE CLIENTES
     IF(NEW.FORMAPAGOID = 4 AND NEW.TIPOPAGOID = 1 AND :TIPODOCTOIDENTRADA in (21) AND :SUBTIPODOCTOIDENTRADA = 22 AND :RESTANTEBUFFER > 0
        AND NEW.tipoaplicacioncreditoid = 2 AND :VENTAFUTUIDENTRADA IS NOT NULL) THEN
     BEGIN



       FOR
            SELECT D.ID, D.SALDO * -1
            FROM DOCTO D
            WHERE D.SALDO * -1 > 0 AND D.TIPODOCTOID = 201 AND D.ESTATUSDOCTOID = 1 AND D.ventafutuid = :VENTAFUTUIDENTRADA
            INTO   :DOCTOIDBUFFER, :SALDOBUFFER
        DO
        BEGIN


            IF(:DOCTOIDBUFFER IS NOT NULL AND COALESCE(:SALDOBUFFER,0)>0) THEN
            BEGIN



            
              IF(:RESTANTEBUFFER > :SALDOBUFFER) THEN
              BEGIN
                 INSERT INTO DOCTOPAGO ( DOCTOID, FORMAPAGOID, FECHA, FECHAHORA, CORTEID, IMPORTE, IMPORTERECIBIDO, IMPORTECAMBIO, TIPOPAGOID, DOCTOSALIDAID)
                             VALUES (NEW.DOCTOID, 7, NEW.FECHA, NEW.FECHAHORA,NEW.CORTEID, :SALDOBUFFER,:SALDOBUFFER, 0, 2, :DOCTOIDBUFFER);
                  RESTANTEBUFFER = :RESTANTEBUFFER - :SALDOBUFFER;
              END
              ELSE
              BEGIN
                  
                   INSERT INTO DOCTOPAGO ( DOCTOID, FORMAPAGOID, FECHA, FECHAHORA, CORTEID, IMPORTE, IMPORTERECIBIDO, IMPORTECAMBIO, TIPOPAGOID, DOCTOSALIDAID)
                             VALUES (NEW.DOCTOID, 7, NEW.FECHA, NEW.FECHAHORA,NEW.CORTEID, :RESTANTEBUFFER,:RESTANTEBUFFER, 0, 2, :DOCTOIDBUFFER);
                    RESTANTEBUFFER = 0;
              END
            END
        END


     END



     --  cuando se esta aplicando saldo de una venta pagada de mas.. CAMBIAR SOLO EL NEW.DOCTOID POR NEW.DOCTOSALIDAID
     /*repeticion codigo 1*/
      IF(NEW.DOCTOSALIDAID  IS NOT NULL AND :TIPODOCTOIDSALIDA = 21) THEN
       BEGIN
          select coalesce(sum(
           p.importe *
            (
                CASE WHEN ((TIPOPAGOID = 1 AND FORMAPAGOID IN (1,2,3,4,5,14,15,16,17,18,20,21)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (7,19)))  THEN 1
                    when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6,18))) THEN -1
                    --   por la aplicacion de saldo a ventas sobrepagadas
                    when TIPOPAGOID = 1 and formapagoid = 6 and  p.doctosalidaid = NEW.DOCTOSALIDAID  then -1   
                    when TIPOPAGOID = 1 and formapagoid = 6 and  p.doctoid = NEW.DOCTOSALIDAID  then 1
                    --  fin por la aplicacion de saldo a ventas sobrepagadas
                ELSE 0 END
            ) *
            (
                CASE WHEN COALESCE(:SOLOABONOAPLICADO,'N') = 'N' OR COALESCE(APLICADO,'N') = 'S' OR FORMAPAGOID <> 3 THEN 1
                ELSE 0 END
             )
          ),0) ABONO ,

          coalesce(sum(p.importe *
          (CASE WHEN ((TIPOPAGOID = 1 AND FORMAPAGOID IN (2)) )   THEN 1
                ELSE 0 END)
          ),0) ABONOTARJETA  ,

          coalesce(sum(
           p.importe *
            (
                CASE WHEN ((TIPOPAGOID = 1 AND FORMAPAGOID IN (1,2,3,4,5,6,14,15,16,17,18,20,21)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (7,19)))  THEN 1
                    when ((TIPOPAGOID = 1 AND FORMAPAGOID IN (7,19)) or (TIPOPAGOID = 2 AND FORMAPAGOID IN (6,18))) THEN -1
                ELSE 0 END
            ) *
            (
                CASE WHEN COALESCE(:SOLOABONOAPLICADO,'N') = 'N' OR COALESCE(APLICADO,'N') = 'S' OR FORMAPAGOID <> 3 THEN 0
                ELSE 1 END
             )
          ),0) ABONONOAPLICADO

           from doctopago p inner join formapago f on p.formapagoid = f.id
          where (p.doctosalidaid = NEW.DOCTOSALIDAID or p.doctoid = NEW.DOCTOSALIDAID ) and f.abona = 'S' into :abono, :ABONOTARJETA, :ABONONOAPLICADO;




          UPDATE DOCTO SET ABONO = :ABONO , SALDO = CARGO - :ABONO, ABONONOAPLICADO = :ABONONOAPLICADO, ABONOTARJETA = :ABONOTARJETA WHERE ID = NEW.DOCTOSALIDAID;

       END
      /*fin repeticion codigo 1*/

    END
     






 END
END