using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DIMS_Core.Models
{
    public class VUserProgressViewModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int TaskId { get; set; }
        [Required]
        public int TaskTrackId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        [JsonPropertyName("Task name")]
        public string TaskName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        [JsonPropertyName("Task note")]
        public string TrackNote { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [JsonPropertyName("Date")]
        public DateTime TrackDate { get; set; }
    }
}