using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using DIMS_Core.DataAccessLayer.Repositories.Base;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class TaskTrackRepository : Repository<TaskTrack>
    {
        public TaskTrackRepository(DbContext context) : base(context) { }
    }
}
