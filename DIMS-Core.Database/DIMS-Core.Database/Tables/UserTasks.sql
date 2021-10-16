CREATE TABLE [dbo].[UserTasks](
	[UserTaskId] [int] IDENTITY(1,1) NOT NULL,
	[TaskId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[StateId] [int] NOT NULL,
PRIMARY KEY ([UserTaskId]),
FOREIGN KEY([StateId])
REFERENCES [dbo].[TaskStates] ([StateId])
    ON DELETE CASCADE
    ON UPDATE CASCADE,
FOREIGN KEY([TaskId])
REFERENCES [dbo].[Tasks] ([TaskId])
    ON DELETE CASCADE
    ON UPDATE CASCADE,
FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfiles] ([UserId])
    ON DELETE CASCADE
    ON UPDATE CASCADE,
)