using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class VTaskRepository : ReadOnlyRepository<VTask>
    {
        protected VTaskRepository(DimsCoreContext context) : base(context)
        {
        }
    }
}