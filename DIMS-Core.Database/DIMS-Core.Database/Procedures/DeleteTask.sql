CREATE PROCEDURE DeleteTask AS

DECLARE @id int;
SET @id = 1;

DELETE FROM Tasks WHERE Task.TaskId = @id;