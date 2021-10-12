using System.Collections.Generic;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.Models
{
    public class UserTaskViewModel
    {
        public UserTaskViewModel()
        {
            TaskTracks = new HashSet<TaskTrackViewModel>();
        }

        public int UserTaskId { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public int StateId { get; set; }

        public TaskStateViewModel State { get; set; }
        public TaskViewModel Task { get; set; }
        public UserProfileViewModel User { get; set; }
        public ICollection<TaskTrackViewModel> TaskTracks { get; set; }
    }
}