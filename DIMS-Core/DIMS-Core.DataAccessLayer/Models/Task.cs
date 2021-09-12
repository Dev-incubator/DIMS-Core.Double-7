using System;

#nullable disable

namespace DIMS_Core.DataAccessLayer.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StateDate { get; set; }
        public DateTime DeadlineDate { get; set; }

        public virtual UserTask UserTask { get; set; }
    }
}
