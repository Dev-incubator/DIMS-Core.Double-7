using System.Collections.Generic;

namespace DIMS_Core.BusinessLayer.Models
{
    public class TaskStateModel
    {
        public int StateId { get; set; }
        public string StateName { get; set; }

        public ICollection<UserTaskModel> UserTasks { get; set; }
    }
}