BEGIN TRAN
UPDATE Test SET [Value]='Value 1B' WHERE Id=1
WAITFOR DELAY '00:00:15'
ROLLBACK