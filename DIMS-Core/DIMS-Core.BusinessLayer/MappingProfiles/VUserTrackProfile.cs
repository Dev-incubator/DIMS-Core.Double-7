using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.MappingProfiles
{
    public class VUserTrackProfile : Profile
    {
        public VUserTrackProfile()
        {
            CreateMap<VUserTrack, VUserTrackModel>()
                .ReverseMap();
        }
    }
}