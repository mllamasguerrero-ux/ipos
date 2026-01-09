CREATE TABLE CORTERECOLECCION (
    ID                    D_ID NOT NULL /* D_ID = BIGINT NOT NULL */,
    ACTIVO                D_BOOLCS /* D_BOOLCS = CHAR(1) DEFAULT 'S' NOT NULL CHECK (VALUE IN ('S', 'N')) */,
    CREADO                D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    CREADOPOR_USERID      D_FK DEFAULT 0 /* D_FK = BIGINT */,
    MODIFICADO            D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    MODIFICADOPOR_USERID  D_FK DEFAULT 0 /* D_FK = BIGINT */,
    ENCARGADOID           D_FK /* D_FK = BIGINT */,
    FECHAHORA             D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    MONTO                 D_PRECIO /* D_PRECIO = NUMERIC(18,2) DEFAULT 0.00 */,
    OBSERVACIONES         D_STDTEXT_LARGE /* D_STDTEXT_LARGE = VARCHAR(255) */
);
