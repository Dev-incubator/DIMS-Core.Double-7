using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using DIMS_Core.DataAccessLayer.Repositories.Base;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class TaskTrackRepository : Repository<TaskTrack>
    {
        public TaskTrackRepository(DimsCoreContext context) : base(context) { }
    }
}
