using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DIMS_Core.Models
{
    public class VUserProgressViewModel
    {
        public int UserId { get; set; }
        
        public int TaskId { get; set; }
        
        public int TaskTrackId { get; set; }
        
        [StringLength(50, MinimumLength = 5)]
        public string UserName { get; set; }
        
        [StringLength(50, MinimumLength = 5)]
        public string TaskName { get; set; }
        
        [StringLength(50, MinimumLength = 5)]
        public string TrackNote { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime TrackDate { get; set; }
    }
}