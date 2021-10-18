using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIMS_Core.Models
{
    public class TaskStateViewModel
    {
        public int StateId { get; set; }
        [Required]
        public string StateName { get; set; }
        
        public ICollection<UserTaskViewModel> UserTasks { get; set; }
    }
}