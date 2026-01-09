create or alter procedure PRODUCTOS_IMPORTAR (
    CLAVE D_CLAVE,
    NOMBRE D_NOMBRE,
    DESCRIPCION D_DESCRIPCION,
    EAN D_CLAVE,
    DESCRIPCION1 D_STDTEXT_MEDIUM,
    DESCRIPCION2 D_STDTEXT_MEDIUM,
    DESCRIPCION3 varchar(40),
    PROVEEDOR1ID integer,
    PROVEEDOR2ID integer,
    CLAVE_LINEA D_CLAVE,
    CLAVE_MARCA D_CLAVE,
    PRECIO1 D_PRECIO,
    PRECIO2 D_PRECIO,
    PRECIO3 D_PRECIO,
    PRECIO4 D_PRECIO,
    PRECIO5 D_PRECIO,
    TASAIVAID D_FK,
    TASAIVA D_PORCENTAJE,
    CLAVE_MONEDA D_CLAVE,
    COSTOREPOSICION D_COSTO,
    COSTOULTIMO D_COSTO,
    COSTOPROMEDIO D_COSTO,
    CLAVE_SUSTITUTO D_CLAVE,
    MANEJALOTE D_BOOLCN,
    ESKIT D_BOOLCN,
    IMPRIMIR D_BOOLCS,
    INVENTARIABLE D_BOOLCS,
    NEGATIVOS D_BOOLCN,
    LIMITEPRECIO2 D_CANTIDAD,
    PRECIOMAXIMOPUBLICO D_PRECIO,
    CLAVE_PROVEEDOR1 D_CLAVE,
    CLAVE_PROVEEDOR2 D_CLAVE,
    CAMBIARPRECIO D_BOOLCN,
    SUBSTITUTO D_CLAVE_NULL,
    CBARRAS D_CLAVE_NULL,
    CEMPAQUE D_CLAVE_NULL,
    PZACAJA D_CANTIDAD,
    U_EMPAQUE D_CANTIDAD,
    UNIDAD D_CLAVE_NULL,
    INI_MAYO D_CANTIDAD,
    MAYOKGS D_BOOLCN,
    TIPOABC D_BOOLCN,
    CLAVE_TASAIVA D_CLAVE_NULL,
    TEXTO1 D_STDTEXT_LIGHT,
    TEXTO2 D_STDTEXT_LIGHT,
    TEXTO3 D_STDTEXT_LIGHT,
    TEXTO4 D_STDTEXT_LIGHT,
    TEXTO5 D_STDTEXT_MEDIUM,
    TEXTO6 D_STDTEXT_LARGE,
    NUMERO1 D_PRECIO,
    NUMERO2 D_PRECIO,
    NUMERO3 D_PRECIO,
    NUMERO4 D_PRECIO,
    FECHA1 D_FECHA,
    FECHA2 D_FECHA,
    CLAVE_PRODUCTOPADRE D_CLAVE_NULL,
    ESPRODUCTOPADRE D_BOOLCN,
    ESPRODUCTOFINAL D_BOOLCN,
    ESSUBPRODUCTO D_BOOLCN,
    TOMARPRECIOPADRE D_BOOLCN,
    TOMARCOMISIONPADRE D_BOOLCN,
    TOMAROFERTAPADRE D_BOOLCN,
    COMISION D_PRECIO,
    OFERTA D_PRECIO,
    PLUG D_CLAVE_NULL,
    TASAIEPS D_PORCENTAJE,
    MINUTILIDAD D_PORCENTAJE,
    AUTO_INSERT_FK D_BOOLCS,
    SPRECIO1 D_PRECIO,
    SPRECIO2 D_PRECIO,
    SPRECIO3 D_PRECIO,
    SPRECIO4 D_PRECIO,
    SPRECIO5 D_PRECIO,
    REQUIERERECETA D_BOOLCN,
    CLASIFICA D_PCLASIF,
    PROMOMOVIL D_BOOLCN,
    PRECIOSUGERIDO D_PRECIO,
    PRECIOTOPE D_PRECIO,
    PRECIOMAT char(1),
    PRECIO6 D_PRECIO,
    MENUDEO D_CANTIDAD,
    CLAVE_CONTENIDO D_CLAVE_UNI,
    CONTENIDOVALOR D_CONTENIDO,
    CLAVE_CLASIFICA D_CLAVE_TRI,
    UNIDAD2 D_CLAVE_NULL,
    CANTXPIEZA D_CANTIDAD,
    MANEJALOTEIMPORTADO D_BOOLCN,
    COSTOENDOLAR D_COSTO,
    PLAZOCLAVE D_CLAVE_NULL,
    CLAVESAT D_CLAVE,
    ESPRODPROM D_BOOLCN_NULL,
    BASEPROM D_CLAVE,
    VIGPROM D_FECHA,
    VIGKIT D_FECHA,
    KITCVIG D_BOOLCN,
    VALXSUC D_BOOLCN_NULL,
    DESCTOPE D_PORCENTAJE,
    MARGEN D_PORCENTAJE,
    DESCPES D_PORCENTAJE,
    KITIMPFIJO D_BOOLCN,
    PORCUTILPRECIO1 D_PRECIO,
    PORCUTILPRECIO2 D_PRECIO,
    PORCUTILPRECIO3 D_PRECIO,
    PORCUTILPRECIO4 D_PRECIO,
    PORCUTILPRECIO5 D_PRECIO,
    IMPRIMIRCOMANDA D_BOOLCN,
    
    LISTAPRECMEDIOMAYID D_FK,
    LISTAPRECMAYOREOID D_FK,
    CANTMEDIOMAY D_CANTIDAD,
    CANTMAYOREO D_CANTIDAD)
returns (
    ERRORCODE D_ERRORCODE)
as
declare variable PRODUCTID D_FK;
declare variable SATID D_FK;
declare variable PRODUCTOSUSTITUTOID D_FK;
declare variable LINEAID integer;
declare variable MARCAID integer;
declare variable MONEDAID D_FK;
declare variable PRODUCTOPADREID D_FK;
declare variable CARACTERISTICASID D_FK;
declare variable TASAIMPUESTO D_PORCENTAJE;
declare variable DESGLOSAIEPS D_BOOLCN;
declare variable CONTENIDOID D_FK;
declare variable CLASIFICAID D_FK;
declare variable CLAVEIVAGENERADA D_CLAVE;
declare variable IDIVAGENERADA D_FK;
declare variable PLAZOID D_FK;
declare variable BASEPRODPROMOID D_FK;
BEGIN

   SELECT FIRST 1 PARAMETRO.desgloseieps FROM PARAMETRO INTO :DESGLOSAIEPS;

   select min(id) productID from producto 
   where  clave = :CLAVE
   into :PRODUCTID;

   if(:CLAVE_SUSTITUTO = '') then
   begin
       PRODUCTOSUSTITUTOID = null;
   end
   else
   begin
      select min(id) productID from producto
      where  clave = :CLAVE_SUSTITUTO
      into :PRODUCTOSUSTITUTOID;
   end

   select min(id) lineaID from linea 
   where  clave = :CLAVE_LINEA
   into :LINEAID;

   select min(id) marcaID from marca
   where  clave = :CLAVE_MARCA
   into :MARCAID;

   select min(id) monedaID from moneda
   where  clave = :CLAVE_MONEDA
   into :MONEDAID;
   
   select min(id)  from persona
   where  clave = :clave_proveedor1 and  tipopersonaid = 40
   into :proveedor1id;

   select min(id)  from persona
   where  clave = :clave_proveedor2  and  tipopersonaid = 40
   into :proveedor2id;

   select min(id) CONTENIDOID from CONTENIDO
   where  clave = :CLAVE_CONTENIDO
   into :CONTENIDOID;

   select min(id) CLASIFICAID from CLASIFICA
   where  clave = :CLAVE_CLASIFICA
   into :CLASIFICAID;
   
   select min(id)  from PLAZO
   where  clave = :PLAZOCLAVE
   into :PLAZOID;


   
   select min(id)  from tasaiva
   where  clave = :CLAVE_TASAIVA
   into :TASAIVAID;

   select min(id) from sat_productoservicio
   where sat_claveprodserv = :CLAVESAT
   into :SATID;

   TASAIMPUESTO =  (CASE WHEN COALESCE(:DESGLOSAIEPS,'N') <> 'S' THEN 0 ELSE COALESCE(:TASAIEPS,0) END)  +  COALESCE(:TASAIVA,0) +  ((  (CASE WHEN COALESCE(:DESGLOSAIEPS,'N') <> 'S' THEN 0 ELSE COALESCE(:TASAIEPS,0) END)  * COALESCE(:TASAIVA,0))/100) ;

   
   if(:CLAVE_PRODUCTOPADRE = '') then
   begin
       PRODUCTOPADREID = null;
   end
   else
   begin
      select min(id) productID from producto
       where  clave = :CLAVE_PRODUCTOPADRE
        into :PRODUCTOPADREID;
   end


  if(:tasaivaid is null ) then
  begin

      if(TRIM(COALESCE(:CLAVE_TASAIVA,'')) <> '') then
      begin
            
            insert into tasaiva ( clave, nombre, tasa, fechainicia)
            values ( :CLAVE_TASAIVA,:CLAVE_TASAIVA, coalesce(:TASAIVA,0), CURRENT_DATE)
            RETURNING ID INTO :tasaivaid;
      end
      else
      begin
            SELECT max(ID) FROM TASAIVA WHERE tasa = coalesce(:TASAIVA,0) INTO :TASAIVAID;
             
            if(:tasaivaid is null and coalesce(:tasaiva,0) > 0) then
            begin
                
                 CLAVEIVAGENERADA = 'TI_' || cast(coalesce(:TASAIVA,0) as varchar(10));

                 SELECT MAX(ID) FROM TASAIVA INTO :IDIVAGENERADA;

                 IDIVAGENERADA = COALESCE(:IDIVAGENERADA,0) + 1;

                insert into tasaiva (id, clave, nombre, tasa, fechainicia)
                values ( :IDIVAGENERADA, :CLAVEIVAGENERADA, :CLAVEIVAGENERADA , coalesce(:TASAIVA,0), CURRENT_DATE)
                RETURNING ID INTO :tasaivaid;
            end
      end
  end



  
  if(:PRODUCTOPADREID is null AND TRIM(COALESCE(:CLAVE_PRODUCTOPADRE,'')) <> '') then
  begin
      insert into PRODUCTO ( clave, nombre, ean, esproductopadre)
      values ( :CLAVE_PRODUCTOPADRE,'PRODUCTO NO REGISTRADO', '', 'S')
      RETURNING ID INTO :PRODUCTOPADREID;
  end

        
  if(:proveedor1id is null AND TRIM(COALESCE(:clave_proveedor1,'')) <> '') then
  begin
      insert into PERSONA ( clave, nombre, tipopersonaid)
      values ( :clave_proveedor1,'PROVEEDOR NO REGISTRADO', 40)
      RETURNING ID INTO :proveedor1id;
  end

            
  if(:proveedor2id is null AND TRIM(COALESCE(:clave_proveedor2,'')) <> '') then
  begin

      IF( TRIM(COALESCE(:clave_proveedor1,'')) <> TRIM(COALESCE(:clave_proveedor2,'')) ) THEN
      BEGIN
        insert into PERSONA ( clave, nombre, tipopersonaid)
        values ( :clave_proveedor2,'PROVEEDOR NO REGISTRADO', 40)
        RETURNING ID INTO :proveedor2id;
      END
      ELSE
      BEGIN
           proveedor1id = :proveedor2id;
      END
  end

  BASEPRODPROMOID = NULL;
  IF(COALESCE(:BASEPROM, '') <> '') THEN
  BEGIN
     SELECT ID FROM PRODUCTO WHERE CLAVE = :BASEPROM INTO :BASEPRODPROMOID;
  END




   if(:PRODUCTID IS NOT NULL) Then
   BEGIN

    update  PRODUCTO

    set
    NOMBRE=:NOMBRE,
    DESCRIPCION=:DESCRIPCION,
    EAN=:EAN,
    DESCRIPCION1=:DESCRIPCION1,
    DESCRIPCION2=:DESCRIPCION2,
    DESCRIPCION3=:DESCRIPCION3,
    LINEAID=:LINEAID,
    MARCAID=:MARCAID,
    PRECIO1=:PRECIO1,
    PRECIO2=:PRECIO2,
    PRECIO3=:PRECIO3,
    PRECIO4=:PRECIO4,
    PRECIO5=:PRECIO5,
    TASAIVAID=:TASAIVAID,
    TASAIVA=:TASAIVA,
    MONEDAID=:MONEDAID,
    COSTOREPOSICION=:COSTOREPOSICION,
    COSTOULTIMO=:COSTOULTIMO,
    --COSTOPROMEDIO=:COSTOPROMEDIO,
    PRODUCTOSUSTITUTOID=:PRODUCTOSUSTITUTOID,
    MANEJALOTE=:MANEJALOTE,
    ESKIT=:ESKIT,
    IMPRIMIR=:IMPRIMIR,
    INVENTARIABLE=:INVENTARIABLE,
    NEGATIVOS=:NEGATIVOS,
    LIMITEPRECIO2=:LIMITEPRECIO2,
    PRECIOMAXIMOPUBLICO =:PRECIOMAXIMOPUBLICO ,
    proveedor1id = :proveedor1id , 
    proveedor2id = :proveedor2id  ,
    cambiarprecio = :cambiarprecio ,

    SUBSTITUTO = :SUBSTITUTO,
    CBARRAS = :CBARRAS,
    CEMPAQUE =:CEMPAQUE,
    PZACAJA = :PZACAJA,
    U_EMPAQUE = :U_EMPAQUE,
    UNIDAD = :UNIDAD ,
    INI_MAYO = :INI_MAYO ,
    MAYOKGS = :MAYOKGS ,
    TIPOABC = :TIPOABC ,
    PRODUCTOPADRE = :PRODUCTOPADREID  ,


    ESPRODUCTOPADRE = :ESPRODUCTOPADRE,
    ESPRODUCTOFINAL = :ESPRODUCTOFINAL,
    ESSUBPRODUCTO = :ESSUBPRODUCTO,
    TOMARPRECIOPADRE  = :TOMARPRECIOPADRE,
    TOMARCOMISIONPADRE  = :TOMARCOMISIONPADRE,
    TOMAROFERTAPADRE  =  :TOMAROFERTAPADRE,

    COMISION = :COMISION,

    OFERTA = :OFERTA,

    PLUG = :PLUG,

    TASAIEPS = :TASAIEPS,
    TASAIMPUESTO = :TASAIMPUESTO,

    MINUTILIDAD = :MINUTILIDAD ,
    SPRECIO1=:SPRECIO1,
    SPRECIO2=:SPRECIO2,
    SPRECIO3=:SPRECIO3,
    SPRECIO4=:SPRECIO4,
    SPRECIO5=:SPRECIO5,

    REQUIERERECETA = :REQUIERERECETA,

    CLASIFICA = :CLASIFICA,

    PROMOMOVIL = :PROMOMOVIL,

    PRECIOSUGERIDO = :PRECIOSUGERIDO,

    PRECIOTOPE  = :PRECIOTOPE,

    PRECIOMAT = :PRECIOMAT,
    PRECIO6 = :PRECIO6,

    MENUDEO = :MENUDEO,

    CONTENIDOID = :CONTENIDOID,

    CONTENIDOVALOR = :CONTENIDOVALOR,

    CLASIFICAID = :CLASIFICAID,

    UNIDAD2 = :UNIDAD2,

    CANTXPIEZA = :CANTXPIEZA,

    MANEJALOTEIMPORTADO = :MANEJALOTEIMPORTADO,

    COSTOENDOLAR = :COSTOENDOLAR,

    PLAZOID = :PLAZOID,

    SAT_PRODUCTOSERVICIOID = :SATID ,

    ESPRODPROMO = :ESPRODPROM  ,

    VIGENCIAPRODPROMO = :VIGPROM ,

    BASEPRODPROMOID = :BASEPRODPROMOID,

    VIGENCIAPRODKIT = :VIGKIT ,

    KITTIENEVIG = :KITCVIG ,

    VALXSUC = :VALXSUC  ,

    DESCTOPE = :DESCTOPE,
    MARGEN = :MARGEN,
    DESCPES = :DESCPES,
    KITIMPFIJO =  :KITIMPFIJO ,

    
    PORCUTILPRECIO1 = :PORCUTILPRECIO1,
    PORCUTILPRECIO2 = :PORCUTILPRECIO2,
    PORCUTILPRECIO3 = :PORCUTILPRECIO3,
    PORCUTILPRECIO4 = :PORCUTILPRECIO4,
    PORCUTILPRECIO5 = :PORCUTILPRECIO5,

    IMPRIMIRCOMANDA = :IMPRIMIRCOMANDA,
    
    LISTAPRECMEDIOMAYID = :LISTAPRECMEDIOMAYID,
    LISTAPRECMAYOREOID = :LISTAPRECMAYOREOID,
    CANTMEDIOMAY = :CANTMEDIOMAY,
    CANTMAYOREO = :CANTMAYOREO

    
    where ID=:PRODUCTID;
   END
   ELSE
   BEGIN

   --temporal toledo
    NEGATIVOS = 'S';


       insert into producto
       (
        ACTIVO,
        CLAVE,
    NOMBRE,
    DESCRIPCION,
    EAN,
    DESCRIPCION1,
    DESCRIPCION2,
    DESCRIPCION3,
    LINEAID,
    MARCAID,
    PRECIO1,
    PRECIO2,
    PRECIO3,
    PRECIO4,
    PRECIO5,
    TASAIVAID,
    TASAIVA,
    MONEDAID,
    COSTOREPOSICION,
    COSTOULTIMO,
    --COSTOPROMEDIO,
    PRODUCTOSUSTITUTOID,
    MANEJALOTE,
    ESKIT,
    IMPRIMIR,
    INVENTARIABLE,
    NEGATIVOS,
    LIMITEPRECIO2,
    PRECIOMAXIMOPUBLICO,
    proveedor1id,
    proveedor2id,

    SUBSTITUTO,
    CBARRAS,
    CEMPAQUE,
    PZACAJA,
    U_EMPAQUE,
    UNIDAD ,
    INI_MAYO ,
    MAYOKGS ,
    TIPOABC  ,
    PRODUCTOPADRE,


    ESPRODUCTOPADRE ,
    ESPRODUCTOFINAL,
    ESSUBPRODUCTO,
    TOMARPRECIOPADRE,
    TOMARCOMISIONPADRE ,
    TOMAROFERTAPADRE,

    COMISION ,
    OFERTA ,
    CAMBIARPRECIO ,
    PLUG  ,
    TASAIEPS,
    TASAIMPUESTO  ,
    MINUTILIDAD,
    SPRECIO1,
    SPRECIO2,
    SPRECIO3,
    SPRECIO4,
    SPRECIO5,

    REQUIERERECETA  ,

    CLASIFICA  ,
    PROMOMOVIL ,

    PRECIOSUGERIDO ,

    PRECIOTOPE ,

    PRECIOMAT ,

    PRECIO6 ,

    MENUDEO ,

    CONTENIDOID  ,

    CONTENIDOVALOR,

    CLASIFICAID ,

    UNIDAD2 ,

    CANTXPIEZA,

    MANEJALOTEIMPORTADO,

    COSTOENDOLAR ,

    PLAZOID,

    SAT_PRODUCTOSERVICIOID,

    ESPRODPROMO,

    VIGENCIAPRODPROMO,

    BASEPRODPROMOID ,

    KITTIENEVIG,

    VALXSUC ,

    DESCTOPE,

    MARGEN,

    DESCPES,

    KITIMPFIJO,


    PORCUTILPRECIO1 ,
    PORCUTILPRECIO2 ,
    PORCUTILPRECIO3 ,
    PORCUTILPRECIO4 ,
    PORCUTILPRECIO5 ,

    IMPRIMIRCOMANDA ,

    LISTAPRECMEDIOMAYID,
    LISTAPRECMAYOREOID,
    CANTMEDIOMAY,
    CANTMAYOREO

   )

           VALUES
        (    
        'S',
        :CLAVE,
    :NOMBRE,
    :DESCRIPCION,
    :EAN,
    :DESCRIPCION1,
    :DESCRIPCION2,
    :DESCRIPCION3,
    :LINEAID,
    :MARCAID,
    :PRECIO1,
    :PRECIO2,
    :PRECIO3,
    :PRECIO4,
    :PRECIO5,
    :TASAIVAID,
    :TASAIVA,
    :MONEDAID,
    :COSTOREPOSICION,
    :COSTOULTIMO,
    --:COSTOPROMEDIO,
    :PRODUCTOSUSTITUTOID,
    :MANEJALOTE,
    :ESKIT,
    :IMPRIMIR,
    :INVENTARIABLE,
    :NEGATIVOS,
    :LIMITEPRECIO2,
    :PRECIOMAXIMOPUBLICO,
    :proveedor1id,
    :proveedor2id,

    :SUBSTITUTO,
    :CBARRAS,
    :CEMPAQUE,
    :PZACAJA,
    :U_EMPAQUE,
    :UNIDAD ,
    :INI_MAYO ,
    :MAYOKGS  ,
    :TIPOABC ,
    :PRODUCTOPADREID ,
    :ESPRODUCTOPADRE ,
    :ESPRODUCTOFINAL,
    :ESSUBPRODUCTO,
    :TOMARPRECIOPADRE,
    :TOMARCOMISIONPADRE ,
    :TOMAROFERTAPADRE  ,
    :COMISION,
    :OFERTA  ,
    :CAMBIARPRECIO  ,

    :PLUG ,
    :TASAIEPS,
    :TASAIMPUESTO ,
    :MINUTILIDAD ,
    :SPRECIO1,
    :SPRECIO2,
    :SPRECIO3,
    :SPRECIO4,
    :SPRECIO5,

    :REQUIERERECETA ,

    :CLASIFICA,
    :PROMOMOVIL,

    :PRECIOSUGERIDO  ,

    :PRECIOTOPE  ,

    :PRECIOMAT   ,

    :PRECIO6 ,

    :MENUDEO ,

    :CONTENIDOID  ,

    :CONTENIDOVALOR,

    :CLASIFICAID  ,

    :UNIDAD2  ,

    :CANTXPIEZA,

    :MANEJALOTEIMPORTADO,

    :COSTOENDOLAR,

    :PLAZOID,

    :SATID ,

    :ESPRODPROM,

    :VIGPROM ,

    :BASEPRODPROMOID ,

    :KITCVIG,

    :VALXSUC ,

    :DESCTOPE,

    :MARGEN,

    :DESCPES ,

    :KITIMPFIJO,


    :PORCUTILPRECIO1 ,
    :PORCUTILPRECIO2 ,
    :PORCUTILPRECIO3 ,
    :PORCUTILPRECIO4 ,
    :PORCUTILPRECIO5 ,

    :IMPRIMIRCOMANDA   ,

    :LISTAPRECMEDIOMAYID,
    :LISTAPRECMAYOREOID,
    :CANTMEDIOMAY,
    :CANTMAYOREO

    )
    returning id into :PRODUCTID;
   END

      
   select min(id) from productocaracteristicas
   where  productocaracteristicas.productoid = :PRODUCTID
   into :CARACTERISTICASID;


   if(:CARACTERISTICASID IS NOT NULL) Then
   BEGIN

    update  productocaracteristicas
    set
     texto1 = :texto1 ,
     texto2 = :texto2 ,
     texto3 = :texto3 , 
     texto4 = :texto4 ,
     texto5 = :texto5 ,
     texto6 = :texto6 , 
     numero1 = :numero1 ,  
     numero2 = :numero2 ,  
     numero3 = :numero3 ,
     numero4 = :numero4 ,  
     fecha1 = :fecha1 ,
     fecha2 = :fecha2
     where ID=:CARACTERISTICASID;
   END
   ELSE
   BEGIN
       insert into productocaracteristicas
       (
     clave,
     texto1,
     texto2,
     texto3,
     texto4,
     texto5,
     texto6,
     numero1,
     numero2,
     numero3,
     numero4,
     fecha1,
     fecha2,
     productoid)
     values
     (
     'test',
     :texto1,
     :texto2 ,
     :texto3 ,
     :texto4 ,
     :texto5 ,
     :texto6 ,
     :numero1  ,
     :numero2  ,
     :numero3  ,
     :numero4  ,
     :fecha1 ,
     :fecha2,
     :productid
     )  ;
       
   END





   ERRORCODE = 0;
   SUSPEND;

   /*WHEN ANY DO
   BEGIN
      ERRORCODE = 1022;
      SUSPEND;
   END */
END
