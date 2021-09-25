CREATE PROCEDURE DeleteTask
    @taskId int   
AS  
    DELETE Tasks WHERE Tasks.TaskId = @taskId;