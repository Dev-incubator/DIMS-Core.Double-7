using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories.Base;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class VUserTaskRepository : ReadOnlyRepository<VUserTask>
    {

        public VUserTaskRepository(DimsCoreContext context) : base(context)
        {

        }
    }
}