using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class VUserTrackRepository : Repository<VUserTrack>
    {
        public VUserTrackRepository(DbContext context) : base(context)
        {
        }
    }
}