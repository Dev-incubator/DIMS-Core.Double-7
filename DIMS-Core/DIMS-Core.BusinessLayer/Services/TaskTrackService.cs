using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.Services
{
    public class TaskTrackService : Service<TaskTrackModel, TaskTrack, IRepository<TaskTrack>>, ITaskTrackService
    {
        public TaskTrackService(IRepository<TaskTrack> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}