CREATE PROCEDURE [dbo].[SetUserTaskAsSuccess]
	@UserId int,
	@TaskId int
AS
	UPDATE [dbo].[UserTasks] SET [dbo].[UserTasks].[StateId]=2 WHERE [dbo].[UserTasks].[TaskId] = @TaskId AND [dbo].[UserTasks].[UserId]=@UserId
RETURN 0
