CREATE VIEW [dbo].[vUserTask]
	AS SELECT [dbo].[UserTask].[UserId], [dbo].[UserTask].[TaskId], Task.Name AS TaskName, Task.Description AS TaskDescription, Task.StartDate, Task.DeadlineDate, [dbo].[TaskState].[StateName]
FROM            [dbo].[Task] INNER JOIN
                         [dbo].[UserTask] ON Task.TaskId = [dbo].[UserTask].[UserTaskId] INNER JOIN
                         [dbo].[TaskState] ON [dbo].[UserTask].[StateId] = [dbo].[TaskState].[StateId]
