CREATE TABLE [dbo].[TaskStates](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [nvarchar](50) NOT NULL,
    CONSTRAINT PK_TaskStates_TaskStateId PRIMARY KEY (StateId)
)