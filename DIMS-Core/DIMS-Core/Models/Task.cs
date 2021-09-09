using System;
using System.Collections.Generic;

#nullable disable

namespace DIMS_Core.Models
{
    public partial class Task
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StateDate { get; set; }
        public DateTime DeadlineDate { get; set; }
    }
}
