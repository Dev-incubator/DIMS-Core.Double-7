CREATE PROCEDURE [dbo].[SetUserTaskAsSuccess]
	@UserId int,
	@TaskId int
AS
	UPDATE [dbo].[UserTask] SET [dbo].[UserTask].[StateId]=2 WHERE [dbo].[UserTask].[TaskId] = @TaskId AND [dbo].[UserTask].[UserId]=@UserId
RETURN 0
