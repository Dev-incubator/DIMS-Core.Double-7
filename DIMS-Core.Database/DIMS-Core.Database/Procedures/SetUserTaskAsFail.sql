CREATE PROCEDURE [dbo].[SetUserTaskAsFail]
	@UserId int,
	@TaskId int
AS
	UPDATE [dbo].[UserTask] SET [dbo].[UserTask].[StateId]=3 WHERE [dbo].[UserTask].[TaskId] = @TaskId AND [dbo].[UserTask].[UserId]=@UserId
RETURN 0
