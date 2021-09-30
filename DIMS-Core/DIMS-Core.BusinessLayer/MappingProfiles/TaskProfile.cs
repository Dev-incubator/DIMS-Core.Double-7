using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Models;

namespace DIMS_Core.BusinessLayer.MappingProfiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Task, TaskModel>()
                .ReverseMap();
        }
    }
}