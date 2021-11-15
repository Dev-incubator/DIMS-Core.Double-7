using System;
using System.ComponentModel.DataAnnotations;

namespace DIMS_Core.Models
{
    public class VUserProfileViewModel
    {
        public int UserId { get; set; }

        [StringLength(100, MinimumLength = 5)]
        public string FullName { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string Direction { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string Education { get; set; }

        [Range(0, 120)]
        public int? Age { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
    }
}