using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.Services
{
    public class VUserProgressService : ReadOnlyService<VUserProgressModel, VUserProgress, IReadOnlyRepository<VUserProgress>>, IVUserProgressService
    {
        public VUserProgressService(IReadOnlyRepository<VUserProgress> repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}