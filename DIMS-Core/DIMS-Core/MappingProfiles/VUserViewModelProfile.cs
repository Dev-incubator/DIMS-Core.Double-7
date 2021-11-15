using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.Models;

namespace DIMS_Core.MappingProfiles
{
    public class VUserViewModelProfile : Profile
    {
        public VUserViewModelProfile()
        {
            CreateMap<VUserProfileViewModel, VUserProfileModel>()
                .ReverseMap();
        }
    }
}