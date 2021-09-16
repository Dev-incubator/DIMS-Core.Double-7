using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class VUserTrackRepository : ReadOnlyRepository<VUserTrack>
    {
        protected VUserTrackRepository(DimsCoreContext context) : base(context)
        {
        }
    }
}