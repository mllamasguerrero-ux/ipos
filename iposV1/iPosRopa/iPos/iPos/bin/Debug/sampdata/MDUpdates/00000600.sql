CREATE TABLE MONEDEROMOVTO (
    ID                    D_PK NOT NULL /* D_PK = BIGINT NOT NULL */,
    ACTIVO                D_BOOLCS /* D_BOOLCS = CHAR(1) DEFAULT 'S' NOT NULL CHECK (VALUE IN ('S', 'N')) */,
    CREADO                D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    CREADOPOR_USERID      D_FK DEFAULT 0 /* D_FK = BIGINT */,
    MODIFICADO            D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    MODIFICADOPOR_USERID  D_FK DEFAULT 0 /* D_FK = BIGINT */,
    MONEDERO              D_FK /* D_FK = BIGINT */,
    TIPOMONEDEROMOVTOID   D_FK /* D_FK = BIGINT */,
    DOCTOID               D_FK /* D_FK = BIGINT */,
    MONTO                 D_PRECIO /* D_PRECIO = NUMERIC(18,2) DEFAULT 0.00 */,
    FECHA                 D_FECHA /* D_FECHA = DATE */,
    CADUCIDAD             D_DIAS /* D_DIAS = INTEGER */,
    MONTOMONEDERO         D_PRECIO /* D_PRECIO = NUMERIC(18,2) DEFAULT 0.00 */,
    VIGENCIAMONEDERO      D_FECHA /* D_FECHA = DATE */
);
