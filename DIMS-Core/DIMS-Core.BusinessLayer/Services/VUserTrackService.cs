using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.Services
{
    public class VUserTrackService : ReadOnlyService<VUserTrackModel, VUserTrack, IReadOnlyRepository<VUserTrack>>, IVUserTrackService
    {
        public VUserTrackService(IReadOnlyRepository<VUserTrack> repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}