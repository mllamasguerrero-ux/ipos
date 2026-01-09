UPDATE EMIDAREQUEST
SET  TRANSTIMESTAMP = CAST((SUBSTRING ( transactiondatetime FROM 4 FOR 2)||'.'||SUBSTRING ( transactiondatetime FROM 1 FOR 2 )||'.'||SUBSTRING ( transactiondatetime FROM 7 FOR 4 ) || SUBSTRING ( transactiondatetime FROM 11 FOR 13 )) AS TIMESTAMP)
