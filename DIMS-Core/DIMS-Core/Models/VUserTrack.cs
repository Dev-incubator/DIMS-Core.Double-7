using System;
using System.Collections.Generic;

#nullable disable

namespace DIMS_Core.Models
{
    public partial class VUserTrack
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Direction { get; set; }
        public byte Sex { get; set; }
        public string Education { get; set; }
        public int? Age { get; set; }
        public double UniversityAverageScore { get; set; }
        public double MathScore { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string Skype { get; set; }
        public DateTime? StartDate { get; set; }
    }
}
