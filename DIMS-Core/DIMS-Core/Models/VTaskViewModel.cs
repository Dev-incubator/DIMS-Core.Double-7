using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DIMS_Core.Models
{
    public class VTaskViewModel
    {
        public int TaskId { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }
        
        [Required]
        [MinLength(10)]
        public string Description { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [JsonPropertyName("Start date")]
        public DateTime StartDate { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [JsonPropertyName("Deadline date")]
        public DateTime DeadlineDate { get; set; }
    }
}