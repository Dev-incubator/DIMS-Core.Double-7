using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DIMS_Core.Models
{
    public class VUserTrackViewModel
    {
        public int UserId { get; set; }
        
        public int TaskId { get; set; }
        public int TaskTrackId { get; set; }
        
        [JsonPropertyName("Task name")]
        public string TaskName { get; set; }
        
        [JsonPropertyName("Track note")]
        public string TrackNote { get; set; }
        [DataType(DataType.Date)]
        [JsonPropertyName("Track date")]
        public DateTime TrackDate { get; set; }
    }
}