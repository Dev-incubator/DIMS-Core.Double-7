using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.Models;

namespace DIMS_Core.MappingProfiles
{
    public class VTaskTrackViewModelProfile : Profile
    {
        public VTaskTrackViewModelProfile()
        {
            CreateMap<VUserTrackModel, VUserTrackViewModel>()
                .ReverseMap();
        }
    }
}