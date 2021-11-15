using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.Models
{
    public class TaskTrackViewModel
    {
        
        public int TaskTrackId { get; set; }
        
        public int UserTaskId { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [JsonPropertyName("Track date")]
        public DateTime TrackDate { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string TrackNote { get; set; }
        
        public virtual UserTaskViewModel UserTask { get; set; }
    }
}