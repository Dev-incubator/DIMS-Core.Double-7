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
            ModelException.IsNotNull(firstModel, typeof(DirectionModel).FullName);
            
            ModelException.IsNotNull(secondModel, typeof(DirectionModel).FullName);

            return firstModel.Name == secondModel.Name;
        }
        
        public static bool operator !=(DirectionModel firstModel, DirectionModel secondModel)
        {
            ModelException.IsNotNull(firstModel, typeof(DirectionModel).FullName);
            
            ModelException.IsNotNull(secondModel, typeof(DirectionModel).FullName);

            return firstModel.Name != secondModel.Name;
        }
    }
}