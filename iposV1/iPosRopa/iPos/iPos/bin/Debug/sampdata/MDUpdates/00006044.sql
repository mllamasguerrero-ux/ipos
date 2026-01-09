create or alter procedure CUBOINFOVEDME (
FECHAINI D_FECHA,
FECHAFIN D_FECHA
)
RETURNS(
    VENTA  D_DOCTOFOLIO,
    CLIENTE  D_CLAVE_NULL,
    CANTIDAD  D_CANTIDAD,
    PRODUCTO  D_CLAVE_NULL,
    PROVEEDOR  D_CLAVE_NULL,
    LINEA  D_CLAVE_NULL,
    MARCA  D_CLAVE_NULL,
    VENDEDOR  D_CLAVE_NULL,
    TIPO  D_CLAVE_NULL,
    CLASIFICA  D_CLAVE_NULL,
    PRECIO  D_PRECIO,
    PREC_LISTA  D_PRECIO,
    FECHA  D_FECHA,
    ESTATUS  D_CLAVE_NULL,
    IMPORTE  D_PRECIO,
    IMPORTNETO  D_PRECIO,
    IMPORTOPE  D_PRECIO,
    TOTAL  D_PRECIO,
    UTILIDAD  D_PRECIO,
    COSTO_PU  D_PRECIO,
    TIENDA  D_CLAVE_NULL,
    COSTOTAL  D_PRECIO,
    DESCUENTO  D_PRECIO,
    COMISION  D_PRECIO,
    ID  D_CLAVE_NULL,
    ID_FECHA  D_FECHA,
    ID_HORA  D_STDTEXT_SHORT,
    IVA  D_PRECIO,
    IEPS19  D_PRECIO,
    IEPS20  D_PRECIO,
    IEPS25  D_PRECIO,
    IEPS30  D_PRECIO,
    IEPS60  D_PRECIO,
    EXPORTADOC  D_BOOLCN_NULL,
    CGO_EXC  D_PRECIO,
    OLLA  D_PRECIO,
    DESCTOPE  D_PRECIO,
    PROMOCION  D_STDTEXT_SHORT,
    SUCU  D_STDTEXT_SHORT,
    TIPO_VEDE  D_STDTEXT_SHORT,
    IEPS53  D_PRECIO,
    IEPS26  D_PRECIO,
    UTL_VENT  D_PRECIO,
    IEPS8 D_PRECIO,
    COSTO_REPO  D_PRECIO ,
    ESKIT D_BOOLCN_NULL,
    DOCTOID D_FK,
    MOVTOID D_FK,
    KITIMPFIJO D_BOOLCN_NULL,
    TIPODOCTOID D_FK  ,
    CONSECUTIVO D_FK
)
AS
DECLARE VARIABLE CONTADOR INTEGER;
DECLARE VARIABLE USUARIOID D_FK;
BEGIN
   CONSECUTIVO = 0;

    FOR SELECT                                  DOCTO.FOLIO AS VENTA,
                                                PERSONA.CLAVE  AS CLIENTE,
                                                MOVTO.CANTIDAD * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS CANTIDAD,
                                                PRODUCTO.CLAVE  AS PRODUCTO,
                                                PROVEEDOR.CLAVE  AS PROVEEDOR,
                                                LINEA.CLAVE  AS LINEA,
                                                MARCA.CLAVE  AS MARCA,
                                                VENDEDOR.CLAVE  AS VENDEDOR,
                                                ''  AS TIPO,
                                                MOVTO.PRECIOCLASIFICACION  AS CLASIFICA,
                                                MOVTO.PRECIO * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END)  AS PRECIO,
                                                MOVTO.PRECIOLISTA  * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS PREC_LISTA,
                                                DOCTO.FECHA AS FECHA,
                                                CASE WHEN  COALESCE(DOCTO.TIPODOCTOID,0) = 22 THEN 'D' WHEN COALESCE(DOCTO.ORIGENFISCALID, 2) IN (3) THEN 'F' ELSE 'R' END    AS ESTATUS,
                                                CAST(COALESCE(MOVTO.PRECIO, 0.00) * COALESCE(MOVTO.CANTIDAD,0.00) AS D_PRECIO)  * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS IMPORTE,
                                                CAST(COALESCE(MOVTO.PRECIO, 0.00) * COALESCE(MOVTO.CANTIDAD,0.00) AS D_PRECIO)  * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS IMPORTNETO,
                                                CAST(
                                                        CASE WHEN COALESCE(MOVTO.MONTOREBAJA, 0.00) > 0 THEN  COALESCE(MOVTO.PRECIOCONREBAJA, 0.00)
                                                                  ELSE COALESCE(MOVTO.PRECIO, 0.00)  END
                                                         * COALESCE(MOVTO.CANTIDAD,0.00) AS D_PRECIO

                                                        )  * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS IMPORTOPE,
                                                MOVTO.TOTAL  * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS TOTAL,
                                                (CAST(
                                                        CASE WHEN COALESCE(MOVTO.MONTOREBAJA, 0.00) > 0 THEN  COALESCE(MOVTO.PRECIOCONREBAJA, 0.00)
                                                                  ELSE COALESCE(MOVTO.PRECIO, 0.00)  END
                                                         * COALESCE(MOVTO.CANTIDAD,0.00) AS D_PRECIO

                                                        ) - CAST(COALESCE(MOVTO.COSTOREPOSICION, 0.00) * COALESCE(MOVTO.CANTIDAD,0.00) AS D_PRECIO))
                                                  * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS UTILIDAD,
                                                COALESCE(MOVTO.COSTOREPOSICION, 0.00) * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END)  AS COSTO_PU,
                                                ''  AS TIENDA,
                                                CAST(COALESCE(MOVTO.COSTOREPOSICION, 0.00) * COALESCE(MOVTO.CANTIDAD,0.00) AS D_PRECIO) * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END)  AS COSTOTAL,
                                                MOVTO.DESCUENTO * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END)  AS DESCUENTO,
                                                MOVTO.COMISION * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END)  AS COMISION,
                                                COALESCE(USUARIO.CLAVE,'')  AS ID,
                                                CURRENT_DATE AS ID_FECHA,
                                                    cast(Extract(hour FROM cast('NOW' as timestamp)) as varchar(2)) ||
                                                        cast(Extract(minute FROM cast('NOW' as timestamp)) as varchar(2)) ||
                                                            cast(trunc(Extract(second  FROM cast('NOW' as timestamp)))  as varchar(2))
                                                      AS ID_HORA,
                                                MOVTO.IVA * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END)  AS IVA,
                                                CASE WHEN MOVTO.TASAIEPS = 19 AND
                                                                                    (COALESCE(PRODUCTO.ESKIT,'N') = 'N' OR
                                                                                      COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S') THEN
                                                                                            COALESCE(MOVTO.TASAIEPS,0.00)
                                                     ELSE 0.00 END * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END)  AS IEPS19,
                                                CASE WHEN MOVTO.TASAIEPS = 20 AND
                                                                                    (COALESCE(PRODUCTO.ESKIT,'N') = 'N' OR
                                                                                      COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S') THEN
                                                                                            COALESCE(MOVTO.TASAIEPS,0.00)
                                                     ELSE 0.00 END * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END)  AS IEPS20,
                                                CASE WHEN MOVTO.TASAIEPS = 25 AND
                                                                                    (COALESCE(PRODUCTO.ESKIT,'N') = 'N' OR
                                                                                      COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S') THEN
                                                                                            COALESCE(MOVTO.TASAIEPS,0.00)
                                                     ELSE 0.00 END * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END)  AS IEPS25,
                                                CASE WHEN MOVTO.TASAIEPS = 30 AND
                                                                                    (COALESCE(PRODUCTO.ESKIT,'N') = 'N' OR
                                                                                      COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S') THEN
                                                                                            COALESCE(MOVTO.TASAIEPS,0.00)
                                                     ELSE 0.00 END * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END)  AS IEPS30,
                                                CASE WHEN MOVTO.TASAIEPS = 60 AND
                                                                                    (COALESCE(PRODUCTO.ESKIT,'N') = 'N' OR
                                                                                      COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S') THEN
                                                                                            COALESCE(MOVTO.TASAIEPS,0.00)
                                                     ELSE 0.00 END * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END)  AS IEPS60,
                                                'N' EXPORTADOC,
                                                0.00 AS CGO_EXC,
                                                0.00 AS OLLA,
                                                MOVTO.MONTOREBAJA AS DESCTOPE,
                                                ''  AS PROMOCION,
                                                SUCURSAL.NOMBRE AS SUCU,
                                                CASE WHEN COALESCE(PRODUCTO.ESKIT,'N') = 'S' THEN 'K' ELSE 'P' END AS TIPO_VEDE,
                                                CASE WHEN MOVTO.TASAIEPS = 53 AND
                                                                                    (COALESCE(PRODUCTO.ESKIT,'N') = 'N' OR
                                                                                      COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S') THEN
                                                                                            COALESCE(MOVTO.TASAIEPS,0.00)
                                                     ELSE 0.00 END * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END)  AS IEPS53,
                                                CASE WHEN MOVTO.TASAIEPS = 26.5 AND
                                                                                    (COALESCE(PRODUCTO.ESKIT,'N') = 'N' OR
                                                                                      COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S') THEN
                                                                                            COALESCE(MOVTO.TASAIEPS,0.00)
                                                     ELSE 0.00 END * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END)  AS IEPS26,
                                                MOVTO.UTILIDAD AS UTL_VENT,
                                                CASE WHEN MOVTO.TASAIEPS = 8 AND
                                                                                    (COALESCE(PRODUCTO.ESKIT,'N') = 'N' OR
                                                                                      COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S') THEN
                                                                                            COALESCE(MOVTO.TASAIEPS,0.00)
                                                     ELSE 0.00 END * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END)  AS IEPS8,
                                                MOVTO.COSTOREPOSICION * (CASE WHEN DOCTO.TIPODOCTOID = 22 THEN -1 ELSE 1 END)  AS COSTO_REPO ,
                                                PRODUCTO.ESKIT  ,
                                                DOCTO.ID DOCTOID,
                                                MOVTO.ID MOVTOID,
                                                PRODUCTO.KITIMPFIJO,
                                                DOCTO.TIPODOCTOID


                                   FROM            DOCTO INNER JOIN
                                                    MOVTO ON MOVTO.DOCTOID = DOCTO.ID LEFT  JOIN
                                                    PRODUCTO ON PRODUCTO.ID = MOVTO.PRODUCTOID left  JOIN
                                                    SUCURSAL ON SUCURSAL.ID = DOCTO.sucursalid LEFT  JOIN
                                                    MARCA  ON MARCA.ID = PRODUCTO.marcaid LEFT  JOIN
                                                    LINEA  ON LINEA.ID = PRODUCTO.lineaid LEFT JOIN
                                                    PERSONA ON PERSONA.ID = DOCTO.personaid LEFT JOIN
                                                    PERSONA VENDEDOR ON VENDEDOR.ID = DOCTO.VENDEDORID LEFT JOIN
                                                    PERSONA PROVEEDOR ON PROVEEDOR.ID = PRODUCTO.PROVEEDOR1ID LEFT JOIN
                                                    PROMOCION ON PROMOCION.ID = MOVTO.PROMOCIONID LEFT JOIN
                                                    PERSONA USUARIO ON USUARIO.ID = :USUARIOID
                                    WHERE DOCTO.FECHA >= :FECHAINI AND DOCTO.FECHA <= :FECHAFIN
                                          AND DOCTO.TIPODOCTOID IN (21,22) AND DOCTO.ESTATUSDOCTOID = 1 
                                          AND COALESCE(DOCTO.SUBTIPODOCTOID,0) NOT IN (7,8,27)
                                    ORDER BY DOCTO.ID, MOVTO.ID
                INTO                            :VENTA,
                                                :CLIENTE,
                                                :CANTIDAD,
                                                :PRODUCTO,
                                                :PROVEEDOR,
                                                :LINEA,
                                                :MARCA,
                                                :VENDEDOR,
                                                :TIPO,
                                                :CLASIFICA,
                                                :PRECIO,
                                                :PREC_LISTA,
                                                :FECHA,
                                                :ESTATUS,
                                                :IMPORTE,
                                                :IMPORTNETO,
                                                :IMPORTOPE,
                                                :TOTAL,
                                                :UTILIDAD,
                                                :COSTO_PU,
                                                :TIENDA,
                                                :COSTOTAL,
                                                :DESCUENTO,
                                                :COMISION,
                                                :ID,
                                                :ID_FECHA,
                                                :ID_HORA,
                                                :IVA,
                                                :IEPS19,
                                                :IEPS20,
                                                :IEPS25,
                                                :IEPS30,
                                                :IEPS60,
                                                :EXPORTADOC,
                                                :CGO_EXC,
                                                :OLLA,
                                                :DESCTOPE,
                                                :PROMOCION,
                                                :SUCU,
                                                :TIPO_VEDE,
                                                :IEPS53,
                                                :IEPS26,
                                                :UTL_VENT,
                                                :IEPS8,
                                                :COSTO_REPO ,
                                                :ESKIT,
                                                :DOCTOID,
                                                :MOVTOID,
                                                :KITIMPFIJO,
                                                :TIPODOCTOID

            DO
            BEGIN

                 IF(COALESCE(:ESKIT,'N') = 'S') THEN
                 BEGIN

                    IF(COALESCE(:KITIMPFIJO,'N') = 'S') THEN
                    BEGIN       
                        CONSECUTIVO = :CONSECUTIVO + 1;
                        SUSPEND;

                        ESKIT = 'N';

                        CONTADOR = 0;

                        FOR        SELECT
                                                MOVTO.CANTIDAD  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS CANTIDAD,
                                                PRODUCTO.CLAVE  AS PRODUCTO,
                                                PROVEEDOR.CLAVE  AS PROVEEDOR,
                                                LINEA.CLAVE  AS LINEA,
                                                MARCA.CLAVE  AS MARCA,
                                                ''  AS TIPO,
                                                MOVTO.PRECIOCLASIFICACION  AS CLASIFICA,
                                                CASE WHEN :CONTADOR = 0 THEN :PRECIO ELSE 0 END AS PRECIO,
                                                CASE WHEN :CONTADOR = 0 THEN :PREC_LISTA ELSE 0 END AS PREC_LISTA,
                                                CASE WHEN :CONTADOR = 0 THEN :IMPORTE ELSE 0 END AS IMPORTE,
                                                CASE WHEN :CONTADOR = 0 THEN :IMPORTNETO ELSE 0 END AS IMPORTNETO,
                                                CASE WHEN :CONTADOR = 0 THEN :IMPORTOPE ELSE 0 END AS IMPORTOPE,
                                                CASE WHEN :CONTADOR = 0 THEN :TOTAL ELSE 0 END  TOTAL,
                                                CASE WHEN :CONTADOR = 0 THEN :UTILIDAD ELSE 0 END  UTILIDAD,
                                                CASE WHEN :CONTADOR = 0 THEN :COSTO_PU ELSE 0 END  AS COSTO_PU,
                                                CASE WHEN :CONTADOR = 0 THEN :COSTOTAL ELSE 0 END  AS COSTOTAL,
                                                CASE WHEN :CONTADOR = 0 THEN :DESCUENTO ELSE 0 END  DESCUENTO,
                                                CASE WHEN :CONTADOR = 0 THEN :COMISION ELSE 0 END  AS COMISION,
                                                CASE WHEN :CONTADOR = 0 THEN :IVA ELSE 0 END  AS IVA,
                                                CASE WHEN :CONTADOR = 0 THEN :IEPS19 ELSE 0 END  AS IEPS19,
                                                CASE WHEN :CONTADOR = 0 THEN :IEPS20 ELSE 0 END  AS IEPS20,
                                                CASE WHEN :CONTADOR = 0 THEN :IEPS25 ELSE 0 END  AS IEPS25,
                                                CASE WHEN :CONTADOR = 0 THEN :IEPS30 ELSE 0 END  AS IEPS30,
                                                CASE WHEN :CONTADOR = 0 THEN :IEPS60 ELSE 0 END  AS IEPS60,
                                                CASE WHEN :CONTADOR = 0 THEN :DESCTOPE ELSE 0 END  AS DESCTOPE,
                                                'D' AS TIPO_VEDE,
                                                CASE WHEN :CONTADOR = 0 THEN :IEPS53 ELSE 0 END  AS IEPS53,
                                                CASE WHEN :CONTADOR = 0 THEN :IEPS26 ELSE 0 END  AS IEPS26, 
                                                CASE WHEN :CONTADOR = 0 THEN :UTL_VENT ELSE 0 END AS UTL_VENT,
                                                CASE WHEN :CONTADOR = 0 THEN :IEPS8 ELSE 0 END  AS IEPS8,
                                                CASE WHEN :CONTADOR = 0 THEN :COSTO_REPO ELSE 0 END AS COSTO_REPO


                                   FROM            DOCTO INNER JOIN
                                                    MOVTO ON MOVTO.DOCTOID = DOCTO.ID LEFT  JOIN
                                                    PRODUCTO ON PRODUCTO.ID = MOVTO.PRODUCTOID left  JOIN
                                                    SUCURSAL ON SUCURSAL.ID = DOCTO.sucursalid LEFT  JOIN
                                                    MARCA  ON MARCA.ID = PRODUCTO.marcaid LEFT  JOIN
                                                    LINEA  ON LINEA.ID = PRODUCTO.lineaid LEFT JOIN
                                                    PERSONA ON PERSONA.ID = DOCTO.personaid LEFT JOIN
                                                    PERSONA VENDEDOR ON VENDEDOR.ID = DOCTO.VENDEDORID LEFT JOIN
                                                    PERSONA PROVEEDOR ON PROVEEDOR.ID = PRODUCTO.PROVEEDOR1ID LEFT JOIN
                                                    PROMOCION ON PROMOCION.ID = MOVTO.PROMOCIONID
                                    WHERE DOCTO.TIPODOCTOID = 505 AND  MOVTO.MOVTOREFID = :MOVTOID
                                    ORDER BY DOCTO.ID, MOVTO.ID
                                          INTO      :CANTIDAD,
                                                :PRODUCTO,
                                                :PROVEEDOR,
                                                :LINEA,
                                                :MARCA,
                                                :TIPO,
                                                :CLASIFICA,
                                                :PRECIO,
                                                :PREC_LISTA,
                                                :IMPORTE,
                                                :IMPORTNETO,
                                                :IMPORTOPE,
                                                :TOTAL,
                                                :UTILIDAD,
                                                :COSTO_PU,
                                                :COSTOTAL,
                                                :DESCUENTO,
                                                :COMISION,
                                                :IVA,
                                                :IEPS19,
                                                :IEPS20,
                                                :IEPS25,
                                                :IEPS30,
                                                :IEPS60,
                                                :DESCTOPE,
                                                :TIPO_VEDE,
                                                :IEPS53,
                                                :IEPS26,
                                                :UTL_VENT,
                                                :IEPS8,
                                                :COSTO_REPO   
                                        DO
                                        BEGIN

                                            CONTADOR = :CONTADOR + 1;  
                                            CONSECUTIVO = :CONSECUTIVO + 1;
                                            SUSPEND;
                                        END

                    END
                    ELSE
                    BEGIN   
                        CONSECUTIVO = :CONSECUTIVO + 1;
                        SUSPEND;
                        ESKIT = 'N';

                        FOR        SELECT
                                                MOVTO.CANTIDAD  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END)AS CANTIDAD,
                                                PRODUCTO.CLAVE  AS PRODUCTO,
                                                PROVEEDOR.CLAVE  AS PROVEEDOR,
                                                LINEA.CLAVE  AS LINEA,
                                                MARCA.CLAVE  AS MARCA,
                                                ''  AS TIPO,
                                                MOVTO.PRECIOCLASIFICACION  AS CLASIFICA,
                                                MOVTO.PRECIO  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS PRECIO,
                                                MOVTO.PRECIOLISTA  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS PREC_LISTA,
                                                CAST(COALESCE(MOVTO.PRECIO, 0.00) * COALESCE(MOVTO.CANTIDAD,0.00) AS D_PRECIO) * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS IMPORTE,
                                                CAST(COALESCE(MOVTO.PRECIO, 0.00) * COALESCE(MOVTO.CANTIDAD,0.00) AS D_PRECIO) AS IMPORTNETO,
                                                CAST(
                                                       CAST(
                                                         CAST( CASE WHEN COALESCE(:IMPORTE, 0.00) > 0 THEN  COALESCE(:IMPORTOPE,0) / COALESCE(:IMPORTE, 0.00)
                                                           ELSE 1.00 END AS D_PRECIO)
                                                                  * COALESCE(MOVTO.PRECIO, 0.00)
                                                                   AS D_PRECIO
                                                           )
                                                         * COALESCE(MOVTO.CANTIDAD,0.00) AS D_PRECIO

                                                        )  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS IMPORTOPE,
                                                MOVTO.TOTAL  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS TOTAL,
                                                (CAST(
                                                       CAST(
                                                         CAST( CASE WHEN COALESCE(:IMPORTE, 0.00) > 0 THEN  COALESCE(:IMPORTOPE,0) / COALESCE(:IMPORTE, 0.00)
                                                           ELSE 1.00 END AS D_PRECIO)
                                                                  * COALESCE(MOVTO.PRECIO, 0.00)
                                                                   AS D_PRECIO
                                                           )
                                                         * COALESCE(MOVTO.CANTIDAD,0.00) AS D_PRECIO

                                                        )  - (CAST(COALESCE(MOVTO.COSTOREPOSICION, 0.00) * COALESCE(MOVTO.CANTIDAD,0.00) AS D_PRECIO)))
                                                  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END)  AS UTILIDAD,
                                                COALESCE(MOVTO.COSTOREPOSICION, 0.00)  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END)  AS COSTO_PU,
                                                CAST(COALESCE(MOVTO.COSTOREPOSICION, 0.00) * COALESCE(MOVTO.CANTIDAD,0.00) AS D_PRECIO)  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS COSTOTAL,
                                                MOVTO.DESCUENTO  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS DESCUENTO,
                                                MOVTO.COMISION  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS COMISION,
                                                MOVTO.IVA  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS IVA,
                                                CASE WHEN MOVTO.TASAIEPS = 19 AND
                                                                                    (COALESCE(PRODUCTO.ESKIT,'N') = 'N' OR
                                                                                      COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S') THEN
                                                                                            COALESCE(MOVTO.TASAIEPS,0.00)
                                                     ELSE 0.00 END  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS IEPS19,
                                                CASE WHEN MOVTO.TASAIEPS = 20 AND
                                                                                    (COALESCE(PRODUCTO.ESKIT,'N') = 'N' OR
                                                                                      COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S') THEN
                                                                                            COALESCE(MOVTO.TASAIEPS,0.00)
                                                     ELSE 0.00 END  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS IEPS20,
                                                CASE WHEN MOVTO.TASAIEPS = 25 AND
                                                                                    (COALESCE(PRODUCTO.ESKIT,'N') = 'N' OR
                                                                                      COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S') THEN
                                                                                            COALESCE(MOVTO.TASAIEPS,0.00)
                                                     ELSE 0.00 END  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS IEPS25,
                                                CASE WHEN MOVTO.TASAIEPS = 30 AND
                                                                                    (COALESCE(PRODUCTO.ESKIT,'N') = 'N' OR
                                                                                      COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S') THEN
                                                                                            COALESCE(MOVTO.TASAIEPS,0.00)
                                                     ELSE 0.00 END  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS IEPS30,
                                                CASE WHEN MOVTO.TASAIEPS = 60 AND
                                                                                    (COALESCE(PRODUCTO.ESKIT,'N') = 'N' OR
                                                                                      COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S') THEN
                                                                                            COALESCE(MOVTO.TASAIEPS,0.00)
                                                     ELSE 0.00 END  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS IEPS60,

                                                (CAST(COALESCE(MOVTO.PRECIO, 0.00) * COALESCE(MOVTO.CANTIDAD,0.00) AS D_PRECIO)
                                                  - CAST(
                                                       CAST(
                                                         CAST( CASE WHEN COALESCE(:IMPORTE, 0.00) > 0 THEN  COALESCE(:IMPORTOPE,0) / COALESCE(:IMPORTE, 0.00)
                                                           ELSE 1.00 END AS D_PRECIO)
                                                                  * COALESCE(MOVTO.PRECIO, 0.00)
                                                                   AS D_PRECIO
                                                           )
                                                         * COALESCE(MOVTO.CANTIDAD,0.00) AS D_PRECIO

                                                        ))   * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END)  AS DESCTOPE,



                                                'D' AS TIPO_VEDE,
                                                CASE WHEN MOVTO.TASAIEPS = 53 AND
                                                                                    (COALESCE(PRODUCTO.ESKIT,'N') = 'N' OR
                                                                                      COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S') THEN
                                                                                            COALESCE(MOVTO.TASAIEPS,0.00)
                                                     ELSE 0.00 END  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS IEPS53,
                                                CASE WHEN MOVTO.TASAIEPS = 26.5 AND
                                                                                    (COALESCE(PRODUCTO.ESKIT,'N') = 'N' OR
                                                                                      COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S') THEN
                                                                                            COALESCE(MOVTO.TASAIEPS,0.00)
                                                     ELSE 0.00 END  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS IEPS26,
                                                MOVTO.UTILIDAD AS UTL_VENT,
                                                CASE WHEN MOVTO.TASAIEPS = 8 AND
                                                                                    (COALESCE(PRODUCTO.ESKIT,'N') = 'N' OR
                                                                                      COALESCE(PRODUCTO.KITIMPFIJO,'N') = 'S') THEN
                                                                                            COALESCE(MOVTO.TASAIEPS,0.00)
                                                     ELSE 0.00 END  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS IEPS8,
                                                MOVTO.COSTOREPOSICION  * (CASE WHEN :TIPODOCTOID = 22 THEN -1 ELSE 1 END) AS COSTO_REPO


                                   FROM            DOCTO INNER JOIN
                                                    MOVTO ON MOVTO.DOCTOID = DOCTO.ID LEFT  JOIN
                                                    PRODUCTO ON PRODUCTO.ID = MOVTO.PRODUCTOID left  JOIN
                                                    SUCURSAL ON SUCURSAL.ID = DOCTO.sucursalid LEFT  JOIN
                                                    MARCA  ON MARCA.ID = PRODUCTO.marcaid LEFT  JOIN
                                                    LINEA  ON LINEA.ID = PRODUCTO.lineaid LEFT JOIN
                                                    PERSONA ON PERSONA.ID = DOCTO.personaid LEFT JOIN
                                                    PERSONA VENDEDOR ON VENDEDOR.ID = DOCTO.VENDEDORID LEFT JOIN
                                                    PERSONA PROVEEDOR ON PROVEEDOR.ID = PRODUCTO.PROVEEDOR1ID LEFT JOIN
                                                    PROMOCION ON PROMOCION.ID = MOVTO.PROMOCIONID
                                    WHERE DOCTO.TIPODOCTOID = 505 AND MOVTO.MOVTOREFID = :MOVTOID
                                    ORDER BY DOCTO.ID, MOVTO.ID
                                          INTO      :CANTIDAD,
                                                :PRODUCTO,
                                                :PROVEEDOR,
                                                :LINEA,
                                                :MARCA,
                                                :TIPO,
                                                :CLASIFICA,
                                                :PRECIO,
                                                :PREC_LISTA,
                                                :IMPORTE,
                                                :IMPORTNETO,
                                                :IMPORTOPE,
                                                :TOTAL,
                                                :UTILIDAD,
                                                :COSTO_PU,
                                                :COSTOTAL,
                                                :DESCUENTO,
                                                :COMISION,
                                                :IVA,
                                                :IEPS19,
                                                :IEPS20,
                                                :IEPS25,
                                                :IEPS30,
                                                :IEPS60,
                                                :DESCTOPE,
                                                :TIPO_VEDE,
                                                :IEPS53,
                                                :IEPS26,
                                                :UTL_VENT,
                                                :IEPS8,
                                                :COSTO_REPO
                                        DO
                                        BEGIN
                                                 
                                            CONSECUTIVO = :CONSECUTIVO + 1;
                                            SUSPEND;
                                        END
                    END

                     
                 END
                 ELSE
                 BEGIN  
                    CONSECUTIVO = :CONSECUTIVO + 1;
                    SUSPEND;
                 END


            END

END


