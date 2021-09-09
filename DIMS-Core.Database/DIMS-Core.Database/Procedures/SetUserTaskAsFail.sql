CREATE PROCEDURE [dbo].[SetUserTaskAsFail]
	@UserId int,
	@TaskId int
AS
	UPDATE [dbo].[UserTasks] SET [dbo].[UserTasks].[StateId]=3 WHERE [dbo].[UserTasks].[TaskId] = @TaskId AND [dbo].[UserTasks].[UserId]=@UserId
RETURN 0
