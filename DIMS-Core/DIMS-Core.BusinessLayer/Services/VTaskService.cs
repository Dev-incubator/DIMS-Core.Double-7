using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Task = DIMS_Core.DataAccessLayer.Models.Task;

namespace DIMS_Core.BusinessLayer.Services
{
    public class VTaskService : ReadOnlyService<VTaskModel, VTask, IReadOnlyRepository<VTask>>, IVTaskService
    {
        public VTaskService(IReadOnlyRepository<VTask> repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}