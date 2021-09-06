CREATE TABLE [dbo].[Tasks]
(
	[TaskId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NTEXT NOT NULL,
    [StateDate] DATETIME NOT NULL, 
    [DeadlineDate] DATETIME NOT NULL
)
