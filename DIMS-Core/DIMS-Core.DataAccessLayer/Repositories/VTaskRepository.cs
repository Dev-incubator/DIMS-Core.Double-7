using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class VTaskRepository : Repository<VTask>
    {
        public VTaskRepository(DbContext context) : base(context)
        {
        }
    }
}