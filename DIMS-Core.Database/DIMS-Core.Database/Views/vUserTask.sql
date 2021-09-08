CREATE VIEW [dbo].[vUserTask]
	AS SELECT [dbo].[UserTask].[UserId], [dbo].[UserTask].[TaskId], [dbo].[Task].[Name] AS TaskName,
    [dbo].[Task].[Description] AS TaskDescription, [dbo].[Task].[StartDate], [dbo].[Task].[DeadlineDate], [dbo].[TaskState].[StateName]
FROM            [dbo].[Task] INNER JOIN
                         [dbo].[UserTask] ON [dbo].[Task].[TaskId] = [dbo].[UserTask].[UserTaskId] INNER JOIN
                         [dbo].[TaskState] ON [dbo].[UserTask].[StateId] = [dbo].[TaskState].[StateId]
