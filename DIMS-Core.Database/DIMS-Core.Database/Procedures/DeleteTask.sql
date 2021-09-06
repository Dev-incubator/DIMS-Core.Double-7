CREATE PROCEDURE DeleteTask AS

DECLARE @id int;
SET @id = 1;

Delete Task WHERE Task.TaskId = @id;

EXEC DeleteTask @id; 