UPDATE CORTE
   SET

   
        INGRESO =
            (SELECT COALESCE(SUM(TOTAL), 0.00)
                FROM DOCTO
                WHERE TIPODOCTOID = 21
                AND CORTEID = CORTE.ID
                AND ESTATUSDOCTOID IN (1,2) ) ,

        INGRESOPORIVA = 
            (SELECT COALESCE(SUM(IVA), 0.00)
                FROM DOCTO
                WHERE TIPODOCTOID = 21
                AND CORTEID = CORTE.ID
                AND ESTATUSDOCTOID IN (1,2) ) ,

         INGRESOSUBTOTAL  = 
            (SELECT COALESCE(SUM(SUBTOTAL), 0.00)
                FROM DOCTO
                WHERE TIPODOCTOID = 21
                AND CORTEID = CORTE.ID
                AND ESTATUSDOCTOID IN (1,2) ) ,  

         INGRESODESCUENTO  =
            (SELECT COALESCE(SUM(DESCUENTO), 0.00)
                FROM DOCTO
                WHERE TIPODOCTOID = 21
                AND CORTEID = CORTE.ID
                AND ESTATUSDOCTOID IN (1,2) ) ,

                
         INGRESOIMPORTE  =
            (SELECT COALESCE(SUM(IMPORTE), 0.00)
                FROM DOCTO
                WHERE TIPODOCTOID = 21
                AND CORTEID = CORTE.ID
                AND ESTATUSDOCTOID IN (1,2) )
                  ;