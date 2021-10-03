CREATE TABLE [dbo].[UserTasks](
	[UserTaskId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[TaskId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[StateId] [int] NOT NULL,
FOREIGN KEY([StateId])
REFERENCES [dbo].[TaskStates] ([StateId]),
FOREIGN KEY([TaskId])
REFERENCES [dbo].[TaskTracks] ([TaskTrackId]),
FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfiles] ([UserId])
)