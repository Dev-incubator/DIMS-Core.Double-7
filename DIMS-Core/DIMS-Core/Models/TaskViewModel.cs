using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.Models
{
    public class TaskViewModel
    {
        public int TaskId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
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