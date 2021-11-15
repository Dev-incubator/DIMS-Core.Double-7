using System.Collections.Generic;
using DIMS_Core.Common.Exceptions;

namespace DIMS_Core.BusinessLayer.Models
{
    public class DirectionModel
    {
        public int DirectionId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public virtual ICollection<UserProfileModel> UserProfiles { get; set; }

        public static bool operator ==(DirectionModel left, DirectionModel right)
        {
            return right is not null && 
                   left is not null &&
                   left.Name == right.Name;
        }
        
        public static bool operator !=(DirectionModel left, DirectionModel right)
        {
            return right is not null && 
                   left is not null &&
                   left.Name != right.Name;
        }
    }
}