using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.Services
{
    public class TaskService : Service<TaskModel, Task, IRepository<Task>>, ITaskService
    {
        public TaskService(IRepository<Task> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}