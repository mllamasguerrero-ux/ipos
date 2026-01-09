CREATE TABLE CFDI_IMP (
    ID                    D_PK NOT NULL /* D_PK = BIGINT NOT NULL */,
    ACTIVO                D_BOOLCS /* D_BOOLCS = CHAR(1) DEFAULT 'S' NOT NULL CHECK (VALUE IN ('S', 'N')) */,
    CREADO                D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    CREADOPOR_USERID      D_FK DEFAULT 0 /* D_FK = BIGINT */,
    MODIFICADO            D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    MODIFICADOPOR_USERID  D_FK DEFAULT 0 /* D_FK = BIGINT */,
    TIPOLINEA             D_NOMBRE_NULL /* D_NOMBRE_NULL = VARCHAR(127) */,
    BASEIMP               D_PRECIO /* D_PRECIO = NUMERIC(18,2) DEFAULT 0.00 */,
    TIPOFACTOR            D_STDTEXT_64 /* D_STDTEXT_64 = VARCHAR(64) */,
    TASACUOTA             D_STDTEXT_64 /* D_STDTEXT_64 = VARCHAR(64) */,
    TASA                  D_PORCENTAJE /* D_PORCENTAJE = NUMERIC(18,2) DEFAULT 0.00 */,
    IMPUESTO              D_STDTEXT_64 /* D_STDTEXT_64 = VARCHAR(64) */,
    IMPORTE               D_IMPORTE /* D_IMPORTE = NUMERIC(18,2) DEFAULT 0.00 */,
    CFDIID                D_FK /* D_FK = BIGINT */
);