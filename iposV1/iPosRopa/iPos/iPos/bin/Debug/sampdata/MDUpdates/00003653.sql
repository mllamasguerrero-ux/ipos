CREATE OR ALTER TRIGGER EMIDAREQUEST_TIMESTAMP FOR EMIDAREQUEST
ACTIVE BEFORE INSERT OR UPDATE POSITION 5
AS
begin
  /* Trigger text */

  IF(NEW.transtimestamp IS NULL) THEN
  BEGIN
    NEW.transtimestamp =  CAST((SUBSTRING ( NEW.transactiondatetime FROM 4 FOR 2)||'.'||SUBSTRING ( NEW.transactiondatetime FROM 1 FOR 2 )||'.'||SUBSTRING ( NEW.transactiondatetime FROM 7 FOR 4 ) || SUBSTRING ( NEW.transactiondatetime FROM 11 FOR 13 )) AS TIMESTAMP);
  END


  WHEN any DO
  BEGIN
  END

end