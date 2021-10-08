using System;
using System.ComponentModel.DataAnnotations;

namespace DIMS_Core.Models
{
    public class VUserProfileViewModel
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string FullName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Direction { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Education { get; set; }

        [Required]
        [Range(0, 120)]
        public int? Age { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }
    }
}