using System;
using System.Collections.Generic;

#nullable disable

namespace DIMS_Core.Models
{
    public partial class TaskTrack
    {
        public TaskTrack()
        {
            UserTasks = new HashSet<UserTask>();
        }

        public int TaskTrackId { get; set; }
        public int UserTaskId { get; set; }
        public DateTime TrackDate { get; set; }
        public string TrackNote { get; set; }

        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
