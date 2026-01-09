create or alter procedure KIT_HAYEXISTENCIAPARAENSAMBLAR (
    DOCTOID D_FK)
returns (
    HAYEXISTENCIA D_BOOLCS,
    ERRORCODE D_ERRORCODE)
as
BEGIN

    ERRORCODE = 0;
    HAYEXISTENCIA = 'S';


    select case when coalesce(count(*),0) = 0  then 'S' else 'N' end HAYEXISTENCIASUFICIENTE
    FROM
    (

        SELECT
        PPARTE.id PRODUCTOID,
        PPARTE.CLAVE PRODUCTOCLAVE,
        PPARTE.nombre PRODUCTONOMBRE,
        PPARTE.descripcion PRODUCTOdescripcion,
        PPARTE.existencia EXISTENCIA,
        SUM(COALESCE(M.CANTIDAD,0) * COALESCE(K.cantidadparte,0)) CANTIDADREQUERIDA,
        (SUM(COALESCE(M.CANTIDAD,0) * COALESCE(K.cantidadparte,0))) - sum(COALESCE(INV.cantidad,0) ) FALTANTE

         FROM MOVTO M
             LEFT JOIN DOCTO D
               ON D.ID = M.DOCTOID
                INNER JOIN KITDEFINICION  K
                  ON  K.productokitid = M.PRODUCTOID 
                  LEFT JOIN PRODUCTO PKIT
                    ON PKIT.ID = M.productoid
                  LEFT JOIN PRODUCTO PPARTE
                    ON PPARTE.ID = K.productoparteid
                    LEFT JOIN INVENTARIO INV
                      ON INV.productoid = K.PRODUCTOPARTEID AND INV.almacenid = D.almacentid
           WHERE M.DOCTOID = :DOCTOID
              AND (M.CANTIDAD >0) AND COALESCE(PKIT.eskit,'N') = 'S'

              GROUP BY
                PPARTE.id ,
                PPARTE.CLAVE ,
                PPARTE.nombre ,
                PPARTE.descripcion ,
                PPARTE.existencia

           HAVING   (SUM(COALESCE(M.CANTIDAD,0) * COALESCE(K.cantidadparte,0))) - sum(COALESCE(INV.cantidad,0) ) > 0
           ) FALTANTES
           INTO :HAYEXISTENCIA;


   

   ERRORCODE = 0;
   SUSPEND;
   
   WHEN ANY DO
   BEGIN
     ERRORCODE = 1076;
     SUSPEND;
   END

END