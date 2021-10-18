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

        public static bool operator ==(DirectionModel firstModel, DirectionModel secondModel)
        {
            return secondModel is not null && 
                   firstModel is not null &&
                   firstModel.Name == secondModel.Name;
        }
        
        public static bool operator !=(DirectionModel firstModel, DirectionModel secondModel)
        {
            return secondModel is not null && 
                   firstModel is not null &&
                   firstModel.Name != secondModel.Name;
        }
    }
}