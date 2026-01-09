REM echo (1) %1 (2) %2 (3) %3 (4) %4 (5) %5 (6) %6
setlocal
SET PGPASSWORD=%6
"%~7createdb.exe" -U %3 --encoding=UTF8 --owner=%3 %4 
"%~7pg_restore.exe" --no-owner --dbname=postgresql://%3:%6@%1:%2/%4 %5
endlocal