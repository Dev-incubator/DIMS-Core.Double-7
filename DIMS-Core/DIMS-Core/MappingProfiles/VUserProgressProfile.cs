using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.Models;

namespace DIMS_Core.MappingProfiles
{
    public class VUserProgressProfile : Profile
    {
        public VUserProgressProfile()
        {
            CreateMap<VUserProgressViewModel, VUserProgressModel>()
                .ReverseMap();
        }
    }
}