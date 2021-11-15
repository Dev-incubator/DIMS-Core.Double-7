using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DIMS_Core.Models
{
    public class VUserTaskViewModel
    {
        public int UserId { get; set; }
        
        public int TaskId { get; set; }
        
        [StringLength(50, MinimumLength = 5)]
        public string TaskName { get; set; }
        
        [MinLength(5)]
        public string TaskDescription { get; set; }
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime DeadlineDate { get; set; }
        public string StateName { get; set; }
    }
}