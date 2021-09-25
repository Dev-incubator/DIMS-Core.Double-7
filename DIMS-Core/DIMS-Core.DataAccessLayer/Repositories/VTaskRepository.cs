using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class VTaskRepository : ReadOnlyRepository<VTask>
    {
        public VTaskRepository(DimsCoreContext context) : base(context)
        {
        }
    }
}