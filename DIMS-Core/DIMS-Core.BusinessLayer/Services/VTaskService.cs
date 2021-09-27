using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.Services
{
    public class VTaskService : Service<VTaskModel, Task, IRepository<Task>>
    {
        public VTaskService(IRepository<Task> repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}