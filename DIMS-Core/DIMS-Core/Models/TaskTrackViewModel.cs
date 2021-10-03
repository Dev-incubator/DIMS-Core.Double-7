using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.Models
{
    public class TaskTrackViewModel
    {
        public TaskTrackViewModel()
        {
            UserTasks = new HashSet<UserTask>();
        }
        
        public int TaskTrackId { get; set; }
        [Required]
        public int UserTaskId { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [JsonPropertyName("Track date")]
        public DateTime TrackDate { get; set; }
        
        [Required]
        [MinLength(5)]
        public string TrackNote { get; set; }

        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}