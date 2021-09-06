CREATE TABLE [dbo].[UserTask](
	[UserTaskId] [int] IDENTITY(1,1) NOT NULL,
	[TaskId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[StateId] [int] NOT NULL,
 CONSTRAINT [PK_UserTask] PRIMARY KEY CLUSTERED 
(
	[UserTaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserTask]  WITH CHECK ADD  CONSTRAINT [FK_UserTask_Task] FOREIGN KEY([UserTaskId])
REFERENCES [dbo].[Task] ([TaskId])
GO

ALTER TABLE [dbo].[UserTask] CHECK CONSTRAINT [FK_UserTask_Task]
GO

ALTER TABLE [dbo].[UserTask]  WITH CHECK ADD  CONSTRAINT [FK_UserTask_TaskState] FOREIGN KEY([StateId])
REFERENCES [dbo].[TaskState] ([StateId])
GO

ALTER TABLE [dbo].[UserTask] CHECK CONSTRAINT [FK_UserTask_TaskState]
GO

ALTER TABLE [dbo].[UserTask]  WITH CHECK ADD  CONSTRAINT [FK_UserTask_TaskTrack] FOREIGN KEY([TaskId])
REFERENCES [dbo].[TaskTrack] ([TaskTrackId])
GO

ALTER TABLE [dbo].[UserTask] CHECK CONSTRAINT [FK_UserTask_TaskTrack]
GO

ALTER TABLE [dbo].[UserTask]  WITH CHECK ADD  CONSTRAINT [FK_UserTask_UserProfiles] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfiles] ([UserId])
GO

ALTER TABLE [dbo].[UserTask] CHECK CONSTRAINT [FK_UserTask_UserProfiles]
GO