using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIMS_Core.Models
{
    public class UserTaskViewModel
    {
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