using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.Models;

namespace DIMS_Core.MappingProfiles
{
    public class TaskTrackViewModelProfile : Profile
    {
        public TaskTrackViewModelProfile()
        {
            CreateMap<TaskTrackModel, TaskTrackViewModel>()
                .ReverseMap();
            CreateMap<VUserTrackModel, VUserTrackViewModel>()
                .ReverseMap();
        }
    }
}