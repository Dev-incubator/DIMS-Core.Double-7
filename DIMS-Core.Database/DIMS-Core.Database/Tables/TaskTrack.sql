CREATE TABLE [dbo].[TaskTracks](
	[TaskTrackId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[UserTaskId] [int] NOT NULL,
	[TrackDate] [datetime] NOT NULL,
	[TrackNote] [nvarchar](50) NOT NULL,
)
