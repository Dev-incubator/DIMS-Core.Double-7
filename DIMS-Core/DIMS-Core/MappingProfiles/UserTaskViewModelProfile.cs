using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.Models;

namespace DIMS_Core.MappingProfiles
{
    public class UserTaskViewModelProfile : Profile
    {
        public UserTaskViewModelProfile()
        {
            CreateMap<UserTaskModel, UserTaskViewModel>()
                .ReverseMap();
        }        
    }
}