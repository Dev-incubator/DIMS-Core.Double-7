using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DIMS_Core.Models
{
    public class VTaskViewModel
    {
        public int TaskId { get; set; }
        
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }
        
        [MinLength(10)]
        public string Description { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DeadlineDate { get; set; }
    }
}