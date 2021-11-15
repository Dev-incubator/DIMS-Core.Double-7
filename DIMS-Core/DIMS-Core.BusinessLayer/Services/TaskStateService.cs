using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.BusinessLayer.Services
{
    public class TaskStateService : Service<TaskStateModel, TaskState, IRepository<TaskState>>, ITaskStateService
    {
        public TaskStateService(TaskStateRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}