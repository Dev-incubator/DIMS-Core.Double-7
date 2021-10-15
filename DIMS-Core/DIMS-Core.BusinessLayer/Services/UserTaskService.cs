using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.Services
{
    public class UserTaskService : Service<UserTaskModel, UserTask, IRepository<UserTask>>, IUserTaskService
    {
        public UserTaskService(IRepository<UserTask> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}