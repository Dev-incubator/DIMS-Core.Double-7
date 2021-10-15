using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DIMS_Core.Models
{
    public class VUserTrackViewModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int TaskId { get; set; }
        
        public int TaskTrackId { get; set; }
        [Required]
        [JsonPropertyName("Task name")]
        public string TaskName { get; set; }
        [Required]
        [JsonPropertyName("Track note")]
        public string TrackNote { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [JsonPropertyName("Track date")]
        public DateTime TrackDate { get; set; }
    }
}