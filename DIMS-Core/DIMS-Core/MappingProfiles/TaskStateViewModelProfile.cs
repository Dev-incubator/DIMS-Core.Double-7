using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.Models;

namespace DIMS_Core.MappingProfiles
{
    public class TaskStateViewModelProfile : Profile
    {
        public TaskStateViewModelProfile()
        {
            CreateMap<TaskStateModel, TaskStateViewModel>()
                .ReverseMap();
        }
    }
}