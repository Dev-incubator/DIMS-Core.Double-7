using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DIMS_Core.Models
{
    public class VUserTaskViewModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int TaskId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string TaskName { get; set; }
        [Required]
        [MinLength(5)]
        public string TaskDescription { get; set; }
        [Required]
        [JsonPropertyName("Start date")]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [JsonPropertyName("Deadline date")]
        public DateTime DeadlineDate { get; set; }
        [Required]
        public string StateName { get; set; }
    }
}