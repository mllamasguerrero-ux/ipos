create or alter procedure LIMPIARPARAMOVIL
as
BEGIN



  
   UPDATE PARAMETRO SET PARAMETRO.fechaultima = CURRENT_DATE;
   DELETE FROM CORTE;
   DELETE FROM KARDEX;
   DELETE FROM MOVTO;
   DELETE FROM DOCTOPAGO;
   DELETE FROM DOCTO;

   DELETE FROM IMP_FILES;
   DELETE FROM EXP_FILES;
   
   --UPDATE INVENTARIO SET CANTIDAD = 0;
   delete from inventario;     
    delete from productoalmacen;

   update producto set existencia = 0, existenciafacturado = 0, existenciaremisionado = 0, existenciafacturadoapartado = 0,
                       existenciaremisionadoapartado = 0, --comision = 0,
                       exist_fac_intercambio = 0,exist_rem_intercambio = 0,
                        COSTOULTIMO = 0, COSTOPROMEDIO = 0, --COSTOREPOSICION = 0,
                        CANTTOTALENTRADAS = NULL, COSTOTOTALENTRADAS = NULL, enprocesodesalida = 0;

   --update parametro set HABILITAR_IMPEXP_AUT = 'N';

   
   update parametro set CAMBIARPRECIO = 'N';



   update persona
   set saldo = 0, saldoapartado = 0, saldospositivos = 0, saldosnegativos = 0, saldoapartadopositivo = 0, saldoapartadonegativo = 0, corteid = null;

   update persona
   set activo = 'N'
   where  tipopersonaid = 50;


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

      delete from cobranzamovil;
      delete from pagomovil;
      delete from doctopagomovil;

      update parametro set fechaultima = current_date;

      delete from persona where tipopersonaid = 50 and id <> 1;

      update parametro set movilcierrecobranza = 0,movilcierreventa = 0;



      DELETE FROM CACHE_PRODMOVIL;
      EXECUTE STATEMENT 'ALTER SEQUENCE SEQ_CACHE_PRODMOVIL RESTART WITH 1';



END