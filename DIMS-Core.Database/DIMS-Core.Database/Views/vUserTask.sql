CREATE VIEW [dbo].[vUserTask]
	AS SELECT [dbo].[UserTasks].[UserId], [dbo].[UserTasks].[TaskId], [dbo].[Tasks].[Name] AS TaskName,
    [dbo].[Tasks].[Description] AS TaskDescription, [dbo].[Tasks].[StartDate], [dbo].[Tasks].[DeadlineDate], [dbo].[TaskStates].[StateName]
FROM            [dbo].[Tasks] INNER JOIN
                         [dbo].[UserTasks] ON [dbo].[Tasks].[TaskId] = [dbo].[UserTasks].[UserTaskId] INNER JOIN
                         [dbo].[TaskStates] ON [dbo].[UserTasks].[StateId] = [dbo].[TaskStates].[StateId]