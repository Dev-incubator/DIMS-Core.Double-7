using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.Models;

namespace DIMS_Core.MappingProfiles
{
    public class VTaskViewModelProfile : Profile
    {
        public VTaskViewModelProfile()
        {
            CreateMap<VTaskModel, VTaskViewModel>()
                .ReverseMap();
        }
    }
}