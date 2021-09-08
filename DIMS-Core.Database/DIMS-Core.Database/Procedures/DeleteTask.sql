CREATE PROCEDURE DeleteTask AS

DECLARE @id int;
SET @id = 1;

DELETE Tasks WHERE Tasks.TaskId = @id;