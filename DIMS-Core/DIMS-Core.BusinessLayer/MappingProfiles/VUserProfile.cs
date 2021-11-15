using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using VUserProfileEntity = DIMS_Core.DataAccessLayer.Models.VUserProfile;

namespace DIMS_Core.BusinessLayer.MappingProfiles
{
    public class VUserProfile : Profile
    {
        public VUserProfile()
        {
            CreateMap<VUserProfileEntity, VUserProfileModel>()
                .ReverseMap();
        }
    }
}