CREATE VIEW [dbo].[vUserTrack]
AS
SELECT UserTasks.UserId,
       UserTasks.TaskId,
       TaskTracks.TaskTrackId,
       Tasks.Name AS TaskName,
       TaskTracks.TrackNote,
       TaskTracks.TrackDate
       
FROM [UserTasks]
     INNER JOIN [Tasks] ON Tasks.TaskId = UserTasks.TaskId
     INNER JOIN [TaskTracks] ON TaskTracks.UserTaskId = UserTasks.UserTaskId