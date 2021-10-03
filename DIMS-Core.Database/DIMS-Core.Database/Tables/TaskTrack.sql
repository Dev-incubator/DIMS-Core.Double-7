CREATE TABLE [dbo].[TaskTracks](
	[TaskTrackId] [int] IDENTITY(1,1) NOT NULL,
	[UserTaskId] [int] NOT NULL,
	[TrackDate] [datetime] NOT NULL,
	[TrackNote] [nvarchar](50) NOT NULL,
	CONSTRAINT PK_TaskTracks_TaskTrackId PRIMARY KEY (TaskTrackId)
)
