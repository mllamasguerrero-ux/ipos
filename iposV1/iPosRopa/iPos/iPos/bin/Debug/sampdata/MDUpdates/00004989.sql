CREATE OR ALTER VIEW PROD_CAMBIO_PRECIO(
    PRODUCTOID,
    CREADO,
    PRECIO1_PREVIO,
    PRECIO2_PREVIO,
    PRECIO3_PREVIO,
    PRECIO4_PREVIO,
    PRECIO5_PREVIO,
    COSTOREPOSICION_PREVIO,
    CLAVE,
    NOMBRE,
    PRECIO1_ACTUAL,
    PRECIO2_ACTUAL,
    PRECIO3_ACTUAL,
    PRECIO4_ACTUAL,
    PRECIO5_ACTUAL,
    COSTOREPOSICION_ACTUAL)
AS
SELECT
    l.productoid,
    l.fecha creado,
    l.precio1 AS precio1_previo,
    l.precio2 AS precio2_previo,
    l.precio3 AS precio3_previo,
    l.precio4 AS precio4_previo,
    l.precio5 AS precio5_previo,
    l.costoreposicion as costoreposicion_previo,
    p.clave,
    p.descripcion1,
    p.precio1 AS precio1_actual,
    p.precio2 AS precio2_actual,
    p.precio3 AS precio3_actual,
    p.precio4 AS precio4_actual,
    p.precio5 AS precio5_actual,
    p.costoreposicion AS costoreposicion_actual
FROM productopreciolog l
  left join producto p
    on p.id = l.productoid
;