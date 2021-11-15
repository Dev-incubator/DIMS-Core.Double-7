using System.Collections.Generic;

namespace DIMS_Core.BusinessLayer.Models
{
    public class UserTaskModel
    {
        public int UserTaskId { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public int StateId { get; set; }

        public TaskStateModel State { get; set; }
        public TaskModel Task { get; set; }
        public UserProfileModel User { get; set; }
        public ICollection<TaskTrackModel> TaskTracks { get; set; }
    }
}