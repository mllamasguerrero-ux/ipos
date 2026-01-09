CREATE TABLE INCIDENCIA (
    ID                    D_PK NOT NULL /* D_PK = BIGINT NOT NULL */,
    ACTIVO                D_BOOLCS /* D_BOOLCS = CHAR(1) DEFAULT 'S' NOT NULL CHECK (VALUE IN ('S', 'N')) */,
    CREADO                D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    CREADOPOR_USERID      D_FK DEFAULT 0 /* D_FK = BIGINT */,
    MODIFICADO            D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    MODIFICADOPOR_USERID  D_FK DEFAULT 0 /* D_FK = BIGINT */,
    TIPOINCIDENCIAID      D_FK /* D_FK = BIGINT */,
    FECHAHORA             D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    VENDEDORID            D_FK /* D_FK = BIGINT */,
    DOCTOID               D_FK /* D_FK = BIGINT */,
    MOVTOID               D_FK /* D_FK = BIGINT */,
    PRODUCTOID            D_FK /* D_FK = BIGINT */,
    NOTA1                 D_STDTEXT_LARGE /* D_STDTEXT_LARGE = VARCHAR(255) */,
    NOTA2                 D_STDTEXT_LARGE /* D_STDTEXT_LARGE = VARCHAR(255) */,
    CANTIDAD1             D_CANTIDAD /* D_CANTIDAD = NUMERIC(18,4) DEFAULT 0.0000 */,
    CANTIDAD2             D_CANTIDAD /* D_CANTIDAD = NUMERIC(18,4) DEFAULT 0.0000 */
);