create or alter procedure MOVTO_CAMBIARTASAIVA (
    MOVTOID D_PK,
    PERSONAID D_PK,
    TASAIVA D_PORCENTAJE)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable TASAISRRETENIDO type of D_PORCENTAJE;
declare variable ISRRETENIDO type of D_PRECIO;
declare variable TASAIVARETENIDO type of D_PORCENTAJE;
declare variable IVARETENIDO type of D_PRECIO;
declare variable PERSONARETIENEISR type of D_BOOLCN;
declare variable PERSONARETIENEIVA type of D_BOOLCN;
declare variable SUBTOTAL type of D_PRECIO;
declare variable IVA type of D_PRECIO;
declare variable TOTAL type of D_PRECIO;
declare variable TASAIEPS type of D_PORCENTAJE;
declare variable IEPS type of D_PRECIO;
declare variable TASAIMPUESTO type of D_PORCENTAJE;
declare variable IMPUESTO type of D_PRECIO;
BEGIN
      select RETENCIONISR, RETENCIONIVA from parametro into :TASAISRRETENIDO, :TASAIVARETENIDO;

    SELECT COALESCE(retieneisr,'N'),COALESCE(retieneiva,'N') from PERSONA where id = :personaid into :PERSONARETIENEISR, :PERSONARETIENEIVA;

        SELECT SUBTOTAL FROM MOVTO WHERE ID = :MOVTOID INTO :SUBTOTAL;

      SELECT TASAIEPS, IEPS, TASAIMPUESTO FROM MOVTO WHERE ID = :MOVTOID INTO :TASAIEPS, :IEPS, :TASAIMPUESTO;
      TASAIVA = COALESCE(:TASAIVA, 0);
      TASAIEPS = COALESCE(:TASAIEPS, 0);
      TASAIMPUESTO = COALESCE(:TASAIMPUESTO,0);


         IF (:TASAIEPS > 0.00) THEN
           IEPS =   :SUBTOTAL * (:TASAIEPS / 100.00);
         ELSE
           IEPS = 0.00;

         IF (:TASAIVA > 0.00) THEN
           IVA = (:SUBTOTAL * ( 1 + (:TASAIEPS / 100.00))) * (:TASAIVA / 100.00);
         ELSE
           IVA = 0.00;

          IMPUESTO = IVA + IEPS;


        IF(:TASAIVARETENIDO > 0.00 AND :SUBTOTAL > 0 and :PERSONARETIENEIVA = 'S')     THEN
            IVARETENIDO = :SUBTOTAL * (:TASAIVARETENIDO / 100.00);
        ELSE
            IVARETENIDO = 0.00;
            
         IF(:TASAISRRETENIDO > 0.00 AND :SUBTOTAL > 0 and :PERSONARETIENEISR = 'S')     THEN
            ISRRETENIDO = :SUBTOTAL * (:TASAISRRETENIDO / 100.00);
         ELSE
            ISRRETENIDO = 0.00;


         TOTAL = :SUBTOTAL + :IMPUESTO;



        UPDATE MOVTO SET 
            IVA = :IVA,
            TOTAL = :TOTAL,
            TASAIVA = coalesce(:TASAIVA,0)  ,
            TASAISRRETENIDO = :TASAISRRETENIDO,
            ISRRETENIDO = :ISRRETENIDO,
            TASAIVARETENIDO = :TASAIVARETENIDO,
            IVARETENIDO = :IVARETENIDO,
            TASAIEPS =:TASAIEPS,
            IEPS = :IEPS,
            TASAIMPUESTO = :TASAIMPUESTO,
            IMPUESTO =  :IMPUESTO
        WHERE ID = :MOVTOID;


       ERRORCODE = 0;
       SUSPEND;

       WHEN ANY DO
       BEGIN
              ERRORCODE = 1015;
              SUSPEND;
       END 
END