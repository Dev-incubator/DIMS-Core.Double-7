using System;
using DIMS_Core.Common.Enums;

namespace DIMS_Core.BusinessLayer.Models
{
    public class UserProfileModel
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int DirectionId { get; set; }

        public string Education { get; set; }

        public string Address { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? StartDate { get; set; }

        public double UniversityAverageScore { get; set; }

        public double MathScore { get; set; }

        public SexType Sex { get; set; }

        public string Skype { get; set; }

        public string Email { get; set; }

        public string MobilePhone { get; set; }

        public static bool operator ==(UserProfileModel left, UserProfileModel right)
        {
            return left.FirstName == right.FirstName && left.LastName == right.LastName;
        }

        public static bool operator !=(UserProfileModel left, UserProfileModel right)
        {
            return left.FirstName != right.FirstName && left.LastName != right.LastName;
        }
    }
}