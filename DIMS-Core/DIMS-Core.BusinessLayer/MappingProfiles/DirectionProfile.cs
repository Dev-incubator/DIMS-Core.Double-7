using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.MappingProfiles
{
    public class DirectionProfile : Profile
    {
        public DirectionProfile()
        {
            CreateMap<Direction, DirectionModel>()
                .ReverseMap();
        }
    }
}