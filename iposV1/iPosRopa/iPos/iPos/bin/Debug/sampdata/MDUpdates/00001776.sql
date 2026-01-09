create or alter procedure LIMPIARPARAMOVIL
as
BEGIN
  
   DELETE FROM CORTE;
   DELETE FROM KARDEX;
   DELETE FROM MOVTO;
   DELETE FROM DOCTOPAGO;
   DELETE FROM DOCTO;

   DELETE FROM IMP_FILES;
   DELETE FROM EXP_FILES;
   
   --UPDATE INVENTARIO SET CANTIDAD = 0;
   delete from inventario;

   update producto set existencia = 0;     
   update producto set existenciafacturado = 0;
   update producto set existenciaremisionado = 0;

   
   update producto set existenciafacturadoapartado = 0;
   update producto set existenciaremisionadoapartado = 0;
   update producto set comision = 0;

   update producto set exist_fac_intercambio = 0;
   update producto set exist_rem_intercambio = 0;

   
   update producto set COSTOULTIMO = 0, COSTOPROMEDIO = 0, COSTOREPOSICION = 0, CANTTOTALENTRADAS = NULL, COSTOTOTALENTRADAS = NULL;

   --update parametro set HABILITAR_IMPEXP_AUT = 'N';

   
   update parametro set CAMBIARPRECIO = 'N';



   update persona
   set saldo = 0, saldoapartado = 0, saldospositivos = 0, saldosnegativos = 0, saldoapartadopositivo = 0, saldoapartadonegativo = 0, corteid = null;



   update personaapartado set saldoapartado = 0;
   
delete from montobilletes;  
delete from productoprecio;
delete from productopreciolog;


   UPDATE CAJA
   SET
      CORTEID = NULL, 
      FECHACORTE = NULL,
      CAJEROID = NULL,
      TURNOID = NULL;

      delete from traza;

      --UPDATE parametro set DESGLOSEIEPS = 'N', ARRENDATARIO = 'N';

      delete from quota;
END