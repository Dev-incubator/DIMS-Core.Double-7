using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories.Base;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class DirectionRepository : Repository<Direction>
    {
        public DirectionRepository(DimsCoreContext context) : base(context)
        {
        }
    }
}