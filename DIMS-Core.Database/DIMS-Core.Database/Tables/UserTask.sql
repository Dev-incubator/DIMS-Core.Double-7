CREATE TABLE [dbo].[UserTasks](
	[UserTaskId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[TaskId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[StateId] [int] NOT NULL,
FOREIGN KEY([StateId])
REFERENCES [dbo].[TaskStates] ([StateId])
    ON DELETE CASCADE
    ON UPDATE CASCADE,
FOREIGN KEY([TaskId])
REFERENCES [dbo].[TaskTracks] ([TaskTrackId])
    ON DELETE CASCADE
    ON UPDATE CASCADE,
FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfiles] ([UserId])
    ON DELETE CASCADE
    ON UPDATE CASCADE,
)