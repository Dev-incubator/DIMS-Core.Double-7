using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories.Base;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class VUserProgressRepository : ReadOnlyRepository<VUserProgress>
    {
        public VUserProgressRepository(DimsCoreContext context) : base(context)
        {
        }
    }
}