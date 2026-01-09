EXECUTE BLOCK
AS
BEGIN

execute statement
'CREATE SEQUENCE SEQ_MONTOBILLETES;';

execute statement
'ALTER SEQUENCE SEQ_MONTOBILLETES RESTART WITH 1;';

execute statement
'
CREATE TABLE MONTOBILLETES (
    ID                      D_PK NOT NULL /* D_PK = BIGINT NOT NULL */,
    ACTIVO                  D_BOOLCS ,
    CREADO                  D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    CREADOPOR_USERID        D_FK DEFAULT 0 /* D_FK = BIGINT */,
    MODIFICADO              D_TIMESTAMP /* D_TIMESTAMP = TIMESTAMP default current_timestamp NOT NULL */,
    MODIFICADOPOR_USERID    D_FK DEFAULT 0 /* D_FK = BIGINT */,
    CORTEID                 D_FK /* D_FK = BIGINT */,
    TIPODECAMBIO            D_TIPOCAMBIO /* D_TIPOCAMBIO = NUMERIC(15,2) */,
    P1000                   D_CANTIDAD /* D_CANTIDAD = NUMERIC(18,4) DEFAULT 0.0000 */,
    P500                    D_CANTIDAD /* D_CANTIDAD = NUMERIC(18,4) DEFAULT 0.0000 */,
    P200                    D_CANTIDAD /* D_CANTIDAD = NUMERIC(18,4) DEFAULT 0.0000 */,
    P100                    D_CANTIDAD /* D_CANTIDAD = NUMERIC(18,4) DEFAULT 0.0000 */,
    P50                     D_CANTIDAD /* D_CANTIDAD = NUMERIC(18,4) DEFAULT 0.0000 */,
    P20                     D_CANTIDAD /* D_CANTIDAD = NUMERIC(18,4) DEFAULT 0.0000 */,
    D100                    D_CANTIDAD /* D_CANTIDAD = NUMERIC(18,4) DEFAULT 0.0000 */,
    D50                     D_CANTIDAD /* D_CANTIDAD = NUMERIC(18,4) DEFAULT 0.0000 */,
    D20                     D_CANTIDAD /* D_CANTIDAD = NUMERIC(18,4) DEFAULT 0.0000 */,
    D10                     D_CANTIDAD /* D_CANTIDAD = NUMERIC(18,4) DEFAULT 0.0000 */,
    D5                      D_CANTIDAD /* D_CANTIDAD = NUMERIC(18,4) DEFAULT 0.0000 */,
    D2                      D_CANTIDAD /* D_CANTIDAD = NUMERIC(18,4) DEFAULT 0.0000 */,
    D1                      D_CANTIDAD /* D_CANTIDAD = NUMERIC(18,4) DEFAULT 0.0000 */,
    MORRALLAPESOS           D_IMPORTE /* D_IMPORTE = NUMERIC(18,2) DEFAULT 0.00 */,
    MORRALLADOLARES         D_IMPORTE /* D_IMPORTE = NUMERIC(18,2) DEFAULT 0.00 */,
    MORRALLADEDOLARENPESOS  D_IMPORTE /* D_IMPORTE = NUMERIC(18,2) DEFAULT 0.00 */,
    SALDOFINAL              D_IMPORTE /* D_IMPORTE = NUMERIC(18,2) DEFAULT 0.00 */,
    CHEQUES                 D_IMPORTE /* D_IMPORTE = NUMERIC(18,2) DEFAULT 0.00 */,
    VALES                   D_IMPORTE /* D_IMPORTE = NUMERIC(18,2) DEFAULT 0.00 */,
    TARJETA                 D_IMPORTE /* D_IMPORTE = NUMERIC(18,2) DEFAULT 0.00 */
);';




/******************************************************************************/
/***                              Primary Keys                              ***/
/******************************************************************************/
 execute statement
'ALTER TABLE MONTOBILLETES ADD CONSTRAINT PK_MONTOBILLETES PRIMARY KEY (ID);
';


/******************************************************************************/
/***                                Indices                                 ***/
/******************************************************************************/
 execute statement
'
CREATE INDEX MONTOBILLETES_IDX1 ON MONTOBILLETES (CORTEID);
';



/* Trigger: MONTOBILLETES_BI_01 */
execute statement
'
CREATE OR ALTER TRIGGER MONTOBILLETES_BI_01 FOR MONTOBILLETES
ACTIVE BEFORE INSERT POSITION 5
AS
BEGIN
  IF ((NEW.ID IS NULL) OR (NEW.ID = 0)) THEN
    NEW.ID = GEN_ID(SEQ_MONTOBILLETES, 1);
    
  IF (NEW.ACTIVO IS NULL) THEN
    NEW.ACTIVO = ''Y'';

  IF (NEW.CREADO IS NULL) THEN
    NEW.CREADO = CURRENT_TIMESTAMP;
    
  IF (NEW.MODIFICADO IS NULL) THEN
    NEW.MODIFICADO = CURRENT_TIMESTAMP;
END;
';


/******************************************************************************/
/***                          Triggers for tables                           ***/
/******************************************************************************/






/* Trigger: MONTOBILLETES_BU */
execute statement
'
CREATE OR ALTER TRIGGER MONTOBILLETES_BU FOR MONTOBILLETES
ACTIVE BEFORE UPDATE POSITION 0
AS
BEGIN
  IF (NEW.MODIFICADO IS NULL) THEN
    NEW.MODIFICADO = CURRENT_TIMESTAMP;
END;
';


/******************************************************************************/
/***                               Privileges                               ***/
/******************************************************************************/

END
