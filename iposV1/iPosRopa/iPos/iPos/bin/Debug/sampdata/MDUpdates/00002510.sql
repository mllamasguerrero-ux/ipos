CREATE TABLE CONTRARECIBOHDR (
    ID                    D_PK NOT NULL /* D_PK = BIGINT NOT NULL */,
    ACTIVO                D_BOOLCS /* D_BOOLCS = CHAR(1) DEFAULT 'S' NOT NULL CHECK (VALUE IN ('S', 'N')) */,
    CREADO                D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    CREADOPOR_USERID      D_FK DEFAULT 0 /* D_FK = BIGINT */,
    MODIFICADO            D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    MODIFICADOPOR_USERID  D_FK DEFAULT 0 /* D_FK = BIGINT */,
    FECHA                 D_FECHA /* D_FECHA = DATE */,
    PERSONAID             D_FK /* D_FK = BIGINT */,
    VENDEDORID            D_FK /* D_FK = BIGINT */,
    ESTATUSID             D_FK /* D_FK = BIGINT */,
    TOTAL                 D_PRECIO /* D_PRECIO = NUMERIC(18,2) DEFAULT 0.00 */,
    ABONO                 D_PRECIO /* D_PRECIO = NUMERIC(18,2) DEFAULT 0.00 */,
    SALDO                 D_PRECIO /* D_PRECIO = NUMERIC(18,2) DEFAULT 0.00 */,
    FOLIO                 D_DOCTOFOLIO /* D_DOCTOFOLIO = INTEGER */,
    OBSERVACIONES         D_STDTEXT_LARGE /* D_STDTEXT_LARGE = VARCHAR(255) */
);