CREATE VIEW [dbo].[vTasks]
AS
SELECT TaskId, Name, Description, StartDate, DeadlineDate 
FROM [Tasks]
