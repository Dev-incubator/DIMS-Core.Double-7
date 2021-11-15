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
        
        public string TaskName { get; set; }
        
        public string TrackNote { get; set; }
        [DataType(DataType.Date)]
        public DateTime TrackDate { get; set; }
    }
}