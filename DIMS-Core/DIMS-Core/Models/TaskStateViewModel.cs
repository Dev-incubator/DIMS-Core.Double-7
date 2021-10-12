using System.Collections.Generic;

namespace DIMS_Core.Models
{
    public class TaskStateViewModel
    {
        
        public TaskStateViewModel()
        {
            UserTasks = new HashSet<UserTaskViewModel>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }

        public ICollection<UserTaskViewModel> UserTasks { get; set; }
    }
}