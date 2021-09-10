CREATE TABLE [dbo].[Tasks]
(
	[TaskId]       INT           NOT NULL IDENTITY, 
    [Name]         NVARCHAR(50)  NOT NULL, 
    [Description]  NVARCHAR(max) NOT NULL,
    [StartDate]    DATETIME      NOT NULL, 
    [DeadlineDate] DATETIME      NOT NULL,
    CONSTRAINT PK_Tasks_TaskId PRIMARY KEY (TaskId)
)
