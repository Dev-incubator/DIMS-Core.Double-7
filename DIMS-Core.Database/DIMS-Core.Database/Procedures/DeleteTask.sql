CREATE PROCEDURE DeleteTask AS

DECLARE @id int;
SET @id = 1;

DELETE FROM Task WHERE Task.TaskId = @id;